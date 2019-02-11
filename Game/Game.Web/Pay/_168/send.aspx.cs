using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Web.UI;
namespace Game.Web.Pay._168
{
    public partial class send : System.Web.UI.Page
	{
		protected string qrcode = "";
		protected string order_no = "";
		protected string order_amount = "";
		protected string paytype = "";
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
			onLineOrder.OrderID = PayHelper.GetOrderIDByPrefix("zlf");
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
			string text4 = formString2;
			switch (text4)
			{
			case "alipay":
				onLineOrder.ShareID = 2;
				goto IL_241;
			case "weixin":
				onLineOrder.ShareID = 3;
				goto IL_241;
			case "alipay-scan":
				this.paytype = "支付宝";
				onLineOrder.ShareID = 4;
				goto IL_241;
			case "weixin-scan":
				this.paytype = "微信";
				onLineOrder.ShareID = 5;
				goto IL_241;
			case "qq":
				onLineOrder.ShareID = 6;
				goto IL_241;
			case "kuaijie":
				onLineOrder.ShareID = 7;
				goto IL_241;
			case "qq-scan":
				this.paytype = "QQ";
				onLineOrder.ShareID = 8;
				goto IL_241;
			case "jd":
				onLineOrder.ShareID = 9;
				goto IL_241;
			case "baidu":
				onLineOrder.ShareID = 10;
				goto IL_241;
			}
			onLineOrder.ShareID = 1;
			IL_241:
			Message message = FacadeManage.aideTreasureFacade.RequestOrder(onLineOrder);
			if (!message.Success)
			{
				base.Response.Write(message.Content);
				base.Response.End();
			}
			string url = ApplicationSettings.Get("url_168");
			string value = ApplicationSettings.Get("parter_168");
			string text = ApplicationSettings.Get("key_168");
			string text2 = ApplicationSettings.Get("pay_url");
			if (text2 == "")
			{
				text2 = "http://" + base.Request.Url.Host;
			}
			string orderID = onLineOrder.OrderID;
			string value2 = text2 + "/pay/168/notify_url.aspx";
			System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
			dictionary["mchid"] = value;
			System.Collections.Generic.Dictionary<string, string> arg_31F_0 = dictionary;
			string arg_31F_1 = "fee";
			int num = formInt * 100;
			arg_31F_0[arg_31F_1] = num.ToString();
			dictionary["order_sn"] = orderID;
			dictionary["notify_url"] = value2;
			string password = string.Concat(new string[]
			{
				dictionary["mchid"],
				"&",
				dictionary["fee"],
				"&",
				dictionary["order_sn"],
				"&",
				text
			});
			dictionary["sign"] = TextEncrypt.EncryptPassword(password).ToLower();
			string param = PayHelper.PrepareSign(dictionary);
			string text3 = HttpHelper.HttpRequest(url, param);
			if (!text3.Contains("rtn"))
			{
				base.Response.Write(text3);
				base.Response.End();
			}
			else
			{
				System.Collections.Generic.Dictionary<string, string> dictionary2 = JsonHelper.DeserializeJsonToObject<System.Collections.Generic.Dictionary<string, string>>(text3);
				if (dictionary2["rtn"] == "0")
				{
					this.order_no = orderID;
					this.order_amount = formInt.ToString();
					this.qrcode = dictionary2["qrurl"];
					base.Response.Redirect(this.qrcode);
				}
				else
				{
					base.Response.Write(dictionary2["message"]);
					base.Response.End();
				}
			}
		}
	}
}
