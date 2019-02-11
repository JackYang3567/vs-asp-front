using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Web.UI;
namespace Game.Web.Pay.ftpay
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
			string text = GameRequest.GetFormString("type");
			OnLineOrder onLineOrder = new OnLineOrder();
			onLineOrder.OrderID = PayHelper.GetOrderIDByPrefix("ft");
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
			string text5 = text;
			switch (text5)
			{
			case "alipay":
				text = "alipaywap";
				onLineOrder.ShareID = 2;
				goto IL_240;
			case "weixin":
				text = "wxpaywap";
				onLineOrder.ShareID = 3;
				goto IL_240;
			case "alipay-scan":
				text = "ZFBZF";
				this.paytype = "支付宝";
				onLineOrder.ShareID = 4;
				goto IL_240;
			case "weixin-scan":
				text = "WXZF";
				this.paytype = "微信";
				onLineOrder.ShareID = 5;
				goto IL_240;
			case "qq":
				text = "qqwap";
				onLineOrder.ShareID = 6;
				goto IL_240;
			case "qq-scan":
				text = "QQZF";
				this.paytype = "QQ";
				onLineOrder.ShareID = 8;
				goto IL_240;
			case "kuaijie":
				text = "bank";
				onLineOrder.ShareID = 7;
				goto IL_240;
			}
			text = "bank";
			onLineOrder.ShareID = 1;
			IL_240:
			Message message = FacadeManage.aideTreasureFacade.RequestOrder(onLineOrder);
			if (!message.Success)
			{
				base.Response.Write(message.Content);
				base.Response.End();
			}
			string url = ApplicationSettings.Get("url_ft");
			string text2 = ApplicationSettings.Get("parter_ft");
			string text3 = ApplicationSettings.Get("key_ft");
			string text4 = ApplicationSettings.Get("pay_url");
			if (text4 == "")
			{
				text4 = "http://" + base.Request.Url.Host;
			}
			string orderID = onLineOrder.OrderID;
			string value = text4 + "/pay/ftpay/notify_url.aspx";
			string value2 = "2001";
			System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
			dictionary["amt"] = formInt.ToString();
			dictionary["payType"] = text;
			dictionary["subject"] = "shop";
			dictionary["notifyUrl"] = value;
			string password = string.Format("orgCode={0}&amt={1}&payType ={2}&md5={3}", new object[]
			{
				text2,
				formInt,
				text,
				text3
			});
			string value3 = TextEncrypt.EncryptPassword(password).ToLower();
			System.Collections.Generic.Dictionary<string, string> dictionary2 = new System.Collections.Generic.Dictionary<string, string>();
			dictionary2["orgCode"] = text2;
			dictionary2["serviceCode"] = value2;
			dictionary2["orgNo"] = orderID;
			dictionary2["jsonData"] = JsonHelper.SerializeObject(dictionary);
			dictionary2["sign"] = value3;
			this.order_no = orderID;
			this.order_amount = formInt.ToString();
			string param = PayHelper.PrepareSign(dictionary2);
			string json = HttpHelper.HttpRequest(url, param);
			System.Collections.Generic.Dictionary<string, string> dictionary3 = JsonHelper.DeserializeJsonToObject<System.Collections.Generic.Dictionary<string, string>>(json);
			if (dictionary3.ContainsKey("respCode"))
			{
				if (!(dictionary3["respCode"] == "0000") && !(dictionary3["respCode"] == "0001"))
				{
					base.Response.Write(dictionary3["respDesc"]);
				}
				else
				{
					string json2 = dictionary3["jsonData"];
					System.Collections.Generic.Dictionary<string, string> dictionary4 = JsonHelper.DeserializeJsonToObject<System.Collections.Generic.Dictionary<string, string>>(json2);
					if (dictionary4.ContainsKey("payUrl"))
					{
						this.qrcode = dictionary4["payUrl"];
					}
				}
			}
			else
			{
				base.Response.Write("下单失败");
			}
		}
	}
}
