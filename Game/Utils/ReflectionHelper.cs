using System;
using System.Reflection;
namespace Game.Utils
{
	public class ReflectionHelper
	{
		public static Type GetType(string typeAndAssName)
		{
			string[] array = typeAndAssName.Split(new char[]
			{
				','
			});
			if (array.Length < 2)
			{
				return Type.GetType(typeAndAssName);
			}
			return ReflectionHelper.GetType(array[0].Trim(), array[1].Trim());
		}
		public static Type GetType(string typeFullName, string assemblyName)
		{
			if (assemblyName == null)
			{
				return Type.GetType(typeFullName);
			}
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			Assembly[] array = assemblies;
			for (int i = 0; i < array.Length; i++)
			{
				Assembly assembly = array[i];
				if (assembly.FullName.Split(new char[]
				{
					','
				})[0].Trim() == assemblyName.Trim())
				{
					return assembly.GetType(typeFullName);
				}
			}
			Assembly assembly2 = Assembly.Load(assemblyName);
			if (assembly2 != null)
			{
				return assembly2.GetType(typeFullName);
			}
			return null;
		}
	}
}
