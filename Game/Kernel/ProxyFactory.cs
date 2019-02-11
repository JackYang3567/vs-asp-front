using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;
namespace Game.Kernel
{
	public sealed class ProxyFactory
	{
		public delegate object CreateInstanceHandler(object[] parameters);
		private static Dictionary<string, ProxyFactory.CreateInstanceHandler> m_Handlers = new Dictionary<string, ProxyFactory.CreateInstanceHandler>();
		private ProxyFactory()
		{
		}
		private static void CreateHandler(Type objtype, string key, Type[] ptypes)
		{
			Type typeFromHandle;
			Monitor.Enter(typeFromHandle = typeof(ProxyFactory));
			try
			{
				if (!ProxyFactory.m_Handlers.ContainsKey(key))
				{
					DynamicMethod dynamicMethod = new DynamicMethod(key, typeof(object), new Type[]
					{
						typeof(object[])
					}, typeof(ProxyFactory).Module);
					ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
					ConstructorInfo constructor = objtype.GetConstructor(ptypes);
					iLGenerator.Emit(OpCodes.Nop);
					for (int i = 0; i < ptypes.Length; i++)
					{
						iLGenerator.Emit(OpCodes.Ldarg_0);
						iLGenerator.Emit(OpCodes.Ldc_I4, i);
						iLGenerator.Emit(OpCodes.Ldelem_Ref);
						if (ptypes[i].IsValueType)
						{
							iLGenerator.Emit(OpCodes.Unbox_Any, ptypes[i]);
						}
						else
						{
							iLGenerator.Emit(OpCodes.Castclass, ptypes[i]);
						}
					}
					iLGenerator.Emit(OpCodes.Newobj, constructor);
					iLGenerator.Emit(OpCodes.Ret);
					ProxyFactory.CreateInstanceHandler value = (ProxyFactory.CreateInstanceHandler)dynamicMethod.CreateDelegate(typeof(ProxyFactory.CreateInstanceHandler));
					ProxyFactory.m_Handlers.Add(key, value);
				}
			}
			finally
			{
				Monitor.Exit(typeFromHandle);
			}
		}
		public static T CreateInstance<T>()
		{
			return ProxyFactory.CreateInstance<T>(null);
		}
		public static T CreateInstance<T>(params object[] parameters)
		{
			Type typeFromHandle = typeof(T);
			Type[] parameterTypes = ProxyFactory.GetParameterTypes(parameters);
			string key = typeof(T).FullName + "_" + ProxyFactory.GetKey(parameterTypes);
			if (!ProxyFactory.m_Handlers.ContainsKey(key))
			{
				ProxyFactory.CreateHandler(typeFromHandle, key, parameterTypes);
			}
			return (T)((object)ProxyFactory.m_Handlers[key](parameters));
		}
		private static string GetKey(params Type[] types)
		{
			if (types == null || types.Length == 0)
			{
				return "null";
			}
			return string.Concat((object[])types);
		}
		private static Type[] GetParameterTypes(params object[] parameters)
		{
			if (parameters == null)
			{
				return new Type[0];
			}
			Type[] array = new Type[parameters.Length];
			for (int i = 0; i < parameters.Length; i++)
			{
				array[i] = parameters[i].GetType();
			}
			return array;
		}
	}
}
