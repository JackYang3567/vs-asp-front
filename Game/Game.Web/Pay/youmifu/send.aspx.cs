using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Web.UI;
namespace Game.Web.Pay.youmifu
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
			onLineOrder.OrderID = PayHelper.GetOrderIDByPrefix("ymf");
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
				text = "9";
				onLineOrder.ShareID = 2;
				goto IL_283;
			case "weixin":
				text = "13";
				onLineOrder.ShareID = 3;
				goto IL_283;
			case "alipay-scan":
				text = "4";
				this.paytype = "支付宝";
				onLineOrder.ShareID = 4;
				goto IL_283;
			case "weixin-scan":
				text = "5";
				this.paytype = "微信";
				onLineOrder.ShareID = 5;
				goto IL_283;
			case "qq":
				text = "15";
				onLineOrder.ShareID = 6;
				goto IL_283;
			case "qq-scan":
				text = "6";
				this.paytype = "QQ";
				onLineOrder.ShareID = 8;
				goto IL_283;
			case "jd":
				text = "21";
				onLineOrder.ShareID = 9;
				goto IL_283;
			case "jd-scan":
				text = "8";
				onLineOrder.ShareID = 13;
				goto IL_283;
			case "kuaijie":
				text = "1";
				onLineOrder.ShareID = 7;
				goto IL_283;
			}
			onLineOrder.ShareID = 1;
			IL_283:
			Message message = FacadeManage.aideTreasureFacade.RequestOrder(onLineOrder);
			if (!message.Success)
			{
				base.Response.Write(message.Content);
				base.Response.End();
			}
			string value = ApplicationSettings.Get("parter_ymf");
			string key2 = ApplicationSettings.Get("key_ymf");
			string text2 = ApplicationSettings.Get("pay_url");
			string gateway = ApplicationSettings.Get("url_ymf");
			if (text2 == "")
			{
				text2 = "http://" + base.Request.Url.Host;
			}
			string value2 = text2 + "/pay/youmifu/notify_url.aspx";
			System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
			dictionary["apiName"] = "WAP_PAY_B2C";
			if (text == "wangyin")
			{
				dictionary["apiName"] = "WEB_PAY_B2C";
			}
			dictionary["apiVersion"] = "1.0.0.1";
			dictionary["platformID"] = value;
			dictionary["merchNo"] = value;
			dictionary["orderNo"] = onLineOrder.OrderID;
			dictionary["tradeDate"] = System.DateTime.Now.ToString("yyyyMMdd");
			dictionary["amt"] = formInt.ToString() + ".00";
			dictionary["merchUrl"] = value2;
			dictionary["merchParam"] = TextUtility.CreateAuthStr(20, false);
			dictionary["tradeSummary"] = "shop";
			dictionary["customerIP"] = GameRequest.GetUserIP();
			string sourceData = PayHelper.PrepareSign(dictionary);
			string value3 = Jiami.sign(sourceData, key2);
			dictionary["signMsg"] = value3;
			dictionary["choosePayType"] = text;
			if (text == "wangyin")
			{
				dictionary["choosePayType"] = "1";
			}
			dictionary["bankCode"] = "";
			base.Response.Write(PayHelper.BuildForm(dictionary, gateway));
			base.Response.End();
		}
	}
}
