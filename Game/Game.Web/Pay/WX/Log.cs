using System;
using System.IO;
using System.Web;
namespace Game.Web.Pay.WX
{
	public class Log
	{
		public static string path = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "logs";
		public static void Debug(string className, string content)
		{
		}
		public static void Info(string className, string content)
		{
		}
		public static void Error(string className, string content)
		{
		}
		protected static void WriteLog(string type, string className, string content)
		{
			if (!System.IO.Directory.Exists(Log.path))
			{
				System.IO.Directory.CreateDirectory(Log.path);
			}
			string text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
			string text2 = Log.path + "/" + System.DateTime.Now.ToString("yyyy-MM-dd") + ".log";
			System.IO.StreamWriter streamWriter = System.IO.File.AppendText(text2);
			string value = string.Concat(new string[]
			{
				text,
				" ",
				type,
				" ",
				className,
				": ",
				content
			});
			streamWriter.WriteLine(value);
			streamWriter.Close();
		}
	}
}
