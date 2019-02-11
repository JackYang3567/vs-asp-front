using Game.Utils;
using System;
using System.Web;
namespace Game.Web.Pay.JFPay
{
	public class Config
	{
		public static string userCode;
		public static string compKey;
		public static string sign;
		public static string signtype;
		public static string requestUrl;
		public static string notify_url;
		public static string return_url;
		public static string myappid;
		static Config()
		{
			Config.userCode = ApplicationSettings.Get("userCode");
			Config.compKey = ApplicationSettings.Get("compKey");
			Config.myappid = ApplicationSettings.Get("myappid");
			Config.sign = "";
			Config.signtype = "1";
			Config.requestUrl = "http://order.z.jtpay.com/jh-web-order/order/receiveOrder";
			Config.notify_url = "http://" + System.Web.HttpContext.Current.Request.Url.Host + ((System.Web.HttpContext.Current.Request.Url.Port == 80) ? "" : (":" + System.Web.HttpContext.Current.Request.Url.Port)) + "/Pay/JFPay/notify_url.aspx";
			Config.return_url = "http://" + System.Web.HttpContext.Current.Request.Url.Host + ((System.Web.HttpContext.Current.Request.Url.Port == 80) ? "" : (":" + System.Web.HttpContext.Current.Request.Url.Port)) + "/Pay/JFPay/return_url.aspx";
		}
	}
}
