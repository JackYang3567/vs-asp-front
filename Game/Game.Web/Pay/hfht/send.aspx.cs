using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Web.UI;
namespace Game.Web.Pay.hfht
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
			onLineOrder.OrderID = PayHelper.GetOrderIDByPrefix("hfht");
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
				text = "alipaywap";
				onLineOrder.ShareID = 2;
				goto IL_289;
			case "weixin":
				text = "wxwap";
				onLineOrder.ShareID = 3;
				goto IL_289;
			case "alipay-scan":
				text = "alipay";
				this.paytype = "支付宝";
				onLineOrder.ShareID = 4;
				goto IL_289;
			case "weixin-scan":
				text = "weixin";
				this.paytype = "微信";
				onLineOrder.ShareID = 5;
				goto IL_289;
			case "qq":
				text = "qqwap";
				onLineOrder.ShareID = 6;
				goto IL_289;
			case "kuaijie":
				text = "bank";
				onLineOrder.ShareID = 7;
				goto IL_289;
			case "qq-scan":
				text = "qqcode";
				this.paytype = "QQ";
				onLineOrder.ShareID = 8;
				goto IL_289;
			case "jd":
				text = "6";
				onLineOrder.ShareID = 9;
				goto IL_289;
			case "baidu":
				text = "5";
				onLineOrder.ShareID = 10;
				goto IL_289;
			}
			text = "4";
			onLineOrder.ShareID = 1;
			IL_289:
			Message message = FacadeManage.aideTreasureFacade.RequestOrder(onLineOrder);
			if (!message.Success)
			{
				base.Response.Write(message.Content);
				base.Response.End();
			}
			string gateway = ApplicationSettings.Get("url_hfht");
			string value = ApplicationSettings.Get("parter_hfht");
			string aKey = ApplicationSettings.Get("key_hfht");
			string text2 = ApplicationSettings.Get("pay_url");
			if (text2 == "")
			{
				text2 = "http://" + base.Request.Url.Host;
			}
			string orderID = onLineOrder.OrderID;
			string value2 = text2 + "/pay/hfht/notify_url.aspx";
			System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
			dictionary["p0_Cmd"] = "Buy";
			dictionary["p1_MerId"] = value;
			dictionary["p2_Order"] = orderID;
			dictionary["p3_Amt"] = formInt.ToString();
			dictionary["p4_Cur"] = "CNY";
			dictionary["p5_Pid"] = "shop";
			dictionary["p6_Pcat"] = "shop";
			dictionary["p7_Pdesc"] = "shop";
			dictionary["p8_Url"] = value2;
			dictionary["pa_MP"] = "shop";
			dictionary["pd_FrpId"] = text;
			dictionary["pr_NeedResponse"] = "1";
			string signSource = PayHelper.GetSignSource(dictionary);
			dictionary["hmac"] = Encrypt.HmacSign(signSource, aKey);
			base.Response.Write(PayHelper.BuildForm(dictionary, gateway));
		}
	}
}
