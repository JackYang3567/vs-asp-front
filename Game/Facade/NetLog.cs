using System;
using System.Globalization;
using System.IO;
using System.Web;
namespace Game.Facade
{
	public class NetLog
	{
		public static void WriteError(string errorMessage)
		{
			try
			{
				string path = "~/Log/" + System.DateTime.Today.ToString("yyMMdd") + ".txt";
				if (!System.IO.File.Exists(HttpContext.Current.Server.MapPath(path)))
				{
					System.IO.File.Create(HttpContext.Current.Server.MapPath(path)).Close();
				}
				using (System.IO.StreamWriter streamWriter = System.IO.File.AppendText(HttpContext.Current.Server.MapPath(path)))
				{
					streamWriter.WriteLine("\r\nLog Entry : ");
					streamWriter.WriteLine("{0}", System.DateTime.Now.ToString(System.Globalization.CultureInfo.InvariantCulture));
					streamWriter.WriteLine(errorMessage);
					streamWriter.WriteLine("________________________________________________________");
					streamWriter.Flush();
					streamWriter.Close();
				}
			}
			catch (System.Exception ex)
			{
				NetLog.WriteError(ex.Message);
			}
		}
	}
}
