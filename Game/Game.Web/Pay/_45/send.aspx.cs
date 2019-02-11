using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Game.Web.Pay._45
{
    public partial class send : System.Web.UI.Page
	{
		protected string qrcode = "";
		protected string order_no = "";
		protected string order_amount = "";
		protected string paytype = "";
		protected System.Web.UI.HtmlControls.HtmlForm form1;
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
			onLineOrder.OrderID = PayHelper.GetOrderIDByPrefix("45");
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
				value = "";
				onLineOrder.ShareID = 2;
				this.paytype = "支付宝";
			}
			if (formString2 == "weixin")
			{
				value = "";
				onLineOrder.ShareID = 3;
				this.paytype = "微信";
			}
			if (formString2 == "weixin-scan")
			{
				value = "";
				onLineOrder.ShareID = 5;
				this.paytype = "微信";
			}
			Message message = FacadeManage.aideTreasureFacade.RequestOrder(onLineOrder);
			if (!message.Success)
			{
				base.Response.Write(message.Content);
				base.Response.End();
			}
			string url = ApplicationSettings.Get("url_45");
			string value2 = ApplicationSettings.Get("parter_45");
			string text = ApplicationSettings.Get("key_45");
			string text2 = ApplicationSettings.Get("pay_url");
			if (text2 == "")
			{
				text2 = "http://" + base.Request.Url.Host;
			}
			string value3 = text2 + "/pay/45/notify_url.aspx";
			System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
			dictionary["v"] = "1.0";
			dictionary["uid"] = value2;
			dictionary["orderid"] = onLineOrder.OrderID;
			dictionary["title"] = "shop";
			dictionary["note"] = "";
			dictionary["istype"] = value;
			dictionary["amount"] = formInt.ToString();
			dictionary["userpara"] = "";
			dictionary["receiveurl"] = value3;
			dictionary["userIP "] = GameRequest.GetUserIP();
			dictionary["returnurl"] = value3;
			string password = string.Concat(new object[]
			{
				dictionary["uid"],
				dictionary["orderid"],
				formInt,
				dictionary["receiveurl"],
				text
			});
			string value4 = TextEncrypt.EncryptPassword(password).ToLower();
			dictionary["sign"] = value4;
			string param = PayHelper.PrepareSign(dictionary);
			string json = HttpHelper.HttpRequest(url, param);
			System.Collections.Generic.Dictionary<string, string> dictionary2 = JsonHelper.DeserializeJsonToObject<System.Collections.Generic.Dictionary<string, string>>(json);
			if (!dictionary2.ContainsKey("result"))
			{
				base.Response.Write("接口正在维护中...");
			}
			else
			{
				if (dictionary2["result"].ToString() == "ok")
				{
					base.Response.Redirect(dictionary2["data"]);
				}
				else
				{
					base.Response.Write(dictionary2["msg"].ToString());
				}
			}
		}
	}
}
