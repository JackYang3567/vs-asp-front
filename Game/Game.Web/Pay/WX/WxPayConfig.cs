using Game.Utils;
using System;
using System.Web;
namespace Game.Web.Pay.WX
{
	public class WxPayConfig
	{
		public const string SSLCERT_PATH = "cert/apiclient_cert.p12";
		public const string SSLCERT_PASSWORD = "1233410002";
		public const string IP = "";
		public const int REPORT_LEVENL = 1;
		public const int LOG_LEVENL = 0;
		public static string APPID = ApplicationSettings.Get("WXAPPID");
		public static string MCHID = ApplicationSettings.Get("WXMCHID");
		public static string KEY = ApplicationSettings.Get("WXKEY");
		public static string APPSECRET = ApplicationSettings.Get("WXAPPSECRET");
		public static string NOTIFY_URL = "http://" + System.Web.HttpContext.Current.Request.Url.Authority + "/Pay/WX/notify_url.aspx";
	}
}
