using Game.Utils;
using Game.Utils.Cache;
using System;
using System.IO;
using System.Text;
using System.Web;
namespace Game.Web
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, System.EventArgs e)
        {
        }
        protected void Session_Start(object sender, System.EventArgs e)
        {
        }
        protected void Application_BeginRequest(object sender, System.EventArgs e)
        {
        }
        protected void Application_AuthenticateRequest(object sender, System.EventArgs e)
        {
        }
        protected void Application_Error(object sender, System.EventArgs e)
        {
            System.Exception lastError = base.Context.Server.GetLastError();
            if (lastError != null)
            {
                string key = "LastWritErrorLogTime";
                object obj = WHCache.Default.Get<AspNetCache>(key);
                if (obj == null || (System.DateTime.Now - System.Convert.ToDateTime(obj)).TotalMilliseconds >= 500.0)
                {
                    System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
                    stringBuilder.Append(System.DateTime.Now);
                    stringBuilder.Append(" 源：" + base.Request.Url.ToString());
                    stringBuilder.Append(" IP：" + GameRequest.GetUserIP());
                    stringBuilder.Append(" 描述：" + lastError.Message + "\r\n");
                    string text = base.Server.MapPath("/Log/");
                    if (!System.IO.Directory.Exists(text))
                    {
                        System.IO.Directory.CreateDirectory(text);
                    }
                    string text2 = text + "ErrorLog" + System.DateTime.Now.ToString("yyyy-MM-dd") + ".log";
                    int num = 0;
                    text2 = FileManager.GetCurrentLogName(text, text2, ref num);
                    if (System.IO.File.Exists(text2))
                    {
                        System.IO.FileInfo fileInfo = new System.IO.FileInfo(text2);
                        if (fileInfo.Length > 31457280L)
                        {
                            text2 = string.Concat(new object[]
							{
								text,
								"ErrorLog",
								System.DateTime.Now.ToString("yyyy-MM-dd"),
								"[",
								num,
								"].log"
							});
                        }
                    }
                    System.IO.File.AppendAllText(text2, stringBuilder.ToString(), System.Text.Encoding.Unicode);
                    WHCache.Default.Save<AspNetCache>(key, System.DateTime.Now, new int?(1));
                }
            }
        }
        protected void Session_End(object sender, System.EventArgs e)
        {
        }
        protected void Application_End(object sender, System.EventArgs e)
        {
        }
    }
}
