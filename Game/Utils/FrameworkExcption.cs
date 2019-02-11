using Game.Utils.Properties;
using System;
namespace Game.Utils
{
	public class FrameworkExcption : Exception
	{
		public FrameworkExcption(string message) : base(FrameworkExcption.GetException(message))
		{
		}
		public FrameworkExcption(string message, params string[] args) : base(FrameworkExcption.GetException(message, args))
		{
		}
		internal static string GetException(string name)
		{
			return AppExceptions.ResourceManager.GetString(name);
		}
		internal static string GetException(string name, params string[] args)
		{
			return string.Format(AppExceptions.ResourceManager.GetString(name), (object[])args);
		}
	}
}
