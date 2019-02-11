using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Web.UI;
using testOrder;
namespace Game.Web.Pay.duodebao
{
    public partial class send : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			string formString = GameRequest.GetFormString("account");
			if (formString == "")
			{
				base.Response.Write("充值账号错误");
				base.Response.End();
			}
			int formInt = GameRequest.GetFormInt("amount", 0);
			if (formInt < 6)
			{
				base.Response.Write("充值金额不能低于6元");
				base.Response.End();
			}
			string formString2 = GameRequest.GetFormString("type");
			OnLineOrder onLineOrder = new OnLineOrder();
			onLineOrder.OrderID = PayHelper.GetOrderIDByPrefix("ddb");
			if (Fetch.GetUserCookie() == null)
			{
				onLineOrder.OperUserID = 0;
			}
			else
			{
				onLineOrder.OperUserID = Fetch.GetUserCookie().UserID;
			}
			onLineOrder.Accounts = formString;
			onLineOrder.OrderAmount = formInt;
			onLineOrder.IPAddress = GameRequest.GetUserIP();
			string value = "";
			if (formString2 == "alipay")
			{
				value = "alipay_h5";
				onLineOrder.ShareID = 2;
			}
			if (formString2 == "weixin")
			{
				value = "wxpay_h5";
				onLineOrder.ShareID = 3;
			}
			if (formString2 == "qq")
			{
				value = "qqpay_h5";
				onLineOrder.ShareID = 6;
			}
			Message message = FacadeManage.aideTreasureFacade.RequestOrder(onLineOrder);
			if (!message.Success)
			{
				base.Response.Write(message.Content);
				base.Response.End();
			}
			string value2 = ApplicationSettings.Get("parter_duodebao");
			string text = ApplicationSettings.Get("priKey_duodebao");
			string text2 = ApplicationSettings.Get("pay_url");
			string actionUrl = ApplicationSettings.Get("url_duodebao");
			if (text2 == "")
			{
				text2 = "http://" + base.Request.Url.Host;
			}
			string value3 = text2 + "/pay/duodebao/notify_url.aspx";
			SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>();
			sortedDictionary["merchant_code"] = value2;
			sortedDictionary["service_type"] = value;
			sortedDictionary["notify_url"] = value3;
			sortedDictionary["interface_version"] = "V3.3";
			sortedDictionary["client_ip"] = GameRequest.GetUserIP();
			sortedDictionary["input_charset"] = "UTF-8";
			sortedDictionary["order_no"] = onLineOrder.OrderID;
			sortedDictionary["order_time"] = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			sortedDictionary["order_amount"] = formInt.ToString();
			sortedDictionary["product_name"] = "shop";
			sortedDictionary["return_url"] = value3;
			string text3 = "";
			foreach (System.Collections.Generic.KeyValuePair<string, string> current in sortedDictionary)
			{
				if (current.Value != "")
				{
					string text4 = text3;
					text3 = string.Concat(new string[]
					{
						text4,
						current.Key,
						"=",
						current.Value,
						"&"
					});
				}
			}
			text3 = text3.Remove(text3.Length - 1);
			string privateKey = text;
			privateKey = HttpHelp.RSAPrivateKeyJava2DotNet(privateKey);
			string value4 = HttpHelp.RSASign(text3, privateKey);
			sortedDictionary["sign_type"] = "RSA-S";
			sortedDictionary["sign"] = value4;
			base.Response.Write(HttpHelper.CreatFormHtml(actionUrl, sortedDictionary, "post"));
		}
	}
}
