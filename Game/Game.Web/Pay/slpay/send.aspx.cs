using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
namespace Game.Web.Pay.slpay
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
			if (formInt < 1)
			{
				base.Response.Write("充值金额不能低于1元");
				base.Response.End();
			}
			string text = GameRequest.GetFormString("type");
			OnLineOrder onLineOrder = new OnLineOrder();
			onLineOrder.OrderID = PayHelper.GetOrderIDByPrefix("sl");
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
			string text3 = text;
			switch (text3)
			{
			case "alipay":
				if (formInt < 50)
				{
					base.Response.Write("<h1>该通道不能低于50元</h1>");
					base.Response.End();
				}
				text = "2";
				onLineOrder.ShareID = 2;
				goto IL_2B6;
			case "weixin":
				text = "3";
				onLineOrder.ShareID = 3;
				goto IL_2B6;
			case "alipay-scan":
				text = "0";
				this.paytype = "支付宝";
				onLineOrder.ShareID = 4;
				goto IL_2B6;
			case "weixin-scan":
				text = "1";
				this.paytype = "微信";
				onLineOrder.ShareID = 5;
				goto IL_2B6;
			case "qq":
				text = "8";
				onLineOrder.ShareID = 6;
				goto IL_2B6;
			case "kuaijie":
				text = "bank";
				onLineOrder.ShareID = 7;
				goto IL_2B6;
			case "qq-scan":
				text = "7";
				this.paytype = "QQ";
				onLineOrder.ShareID = 8;
				goto IL_2B6;
			case "jd":
				text = "6";
				onLineOrder.ShareID = 9;
				goto IL_2B6;
			case "baidu":
				text = "5";
				onLineOrder.ShareID = 10;
				goto IL_2B6;
			}
			text = "4";
			onLineOrder.ShareID = 1;
			IL_2B6:
			Message message = FacadeManage.aideTreasureFacade.RequestOrder(onLineOrder);
			if (!message.Success)
			{
				base.Response.Write(message.Content);
				base.Response.End();
			}
			string str = ApplicationSettings.Get("url_sl");
			string value = ApplicationSettings.Get("parter_sl");
			string str2 = ApplicationSettings.Get("key_sl");
			string text2 = ApplicationSettings.Get("pay_url");
			if (text2 == "")
			{
				text2 = "http://" + base.Request.Url.Host;
			}
			string orderID = onLineOrder.OrderID;
			string value2 = text2 + "/pay/slpay/notify_url.aspx";
			System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
			dictionary["parter"] = value;
			dictionary["b_type"] = text;
			dictionary["amount"] = formInt.ToString();
			dictionary["orderid"] = orderID;
			dictionary["callbackurl"] = value2;
			dictionary["goodsinfo"] = "shop";
			dictionary["nonce_str"] = orderID;
			dictionary = (
				from p in dictionary
				orderby p.Key
				select p).ToDictionary((System.Collections.Generic.KeyValuePair<string, string> p) => p.Key, (System.Collections.Generic.KeyValuePair<string, string> o) => o.Value);
			string password = PayHelper.PrepareSign(dictionary) + str2;
			dictionary["hrefbackurl"] = "";
			dictionary["attach"] = "";
			dictionary["sign"] = TextEncrypt.EncryptPassword(password);
			string url = str + "?" + PayHelper.PrepareSign(dictionary);
			base.Response.Redirect(url);
		}
	}
}
