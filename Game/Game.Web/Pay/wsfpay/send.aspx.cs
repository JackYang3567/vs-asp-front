using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Web.UI;
namespace Game.Web.Pay.wsfpay
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
			string text = base.Request["type"];
			OnLineOrder onLineOrder = new OnLineOrder();
			onLineOrder.OrderID = PayHelper.GetOrderIDByPrefix("wsf");
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
			string text4 = text;
			switch (text4)
			{
			case "alipay":
				text = "4";
				value = "2";
				onLineOrder.ShareID = 2;
				goto IL_23F;
			case "weixin":
				text = "3";
				value = "2";
				onLineOrder.ShareID = 3;
				goto IL_23F;
			case "alipay-scan":
				text = "4";
				value = "1";
				onLineOrder.ShareID = 4;
				goto IL_23F;
			case "weixin-scan":
				text = "3";
				value = "1";
				onLineOrder.ShareID = 5;
				goto IL_23F;
			case "qq":
				text = "qq-wap";
				onLineOrder.ShareID = 6;
				goto IL_23F;
			case "qq-scan":
				text = "qqsm";
				onLineOrder.ShareID = 8;
				goto IL_23F;
			case "kuaijie":
				text = "wangyin-kj";
				onLineOrder.ShareID = 7;
				goto IL_23F;
			}
			onLineOrder.ShareID = 1;
			IL_23F:
			Message message = FacadeManage.aideTreasureFacade.RequestOrder(onLineOrder);
			if (!message.Success)
			{
				base.Response.Write(message.Content);
				base.Response.End();
			}
			string text2 = ApplicationSettings.Get("pay_url");
			if (text2 == "")
			{
				text2 = "http://" + base.Request.Url.Host;
			}
			string value2 = text2 + "/pay/wsfpay/notify_url.aspx";
			string value3 = ApplicationSettings.Get("parter_wsf");
			string str = ApplicationSettings.Get("key_wsf");
			string gateway = ApplicationSettings.Get("url_wsf");
			System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
			dictionary["p1_usercode"] = value3;
			dictionary["p2_order"] = onLineOrder.OrderID;
			dictionary["p3_money"] = onLineOrder.OrderAmount.ToString();
			dictionary["p4_returnurl"] = value2;
			dictionary["p5_notifyurl"] = value2;
			dictionary["p6_ordertime"] = System.DateTime.Now.ToString("yyyyMMddHHmmss");
			string text3 = "";
			foreach (System.Collections.Generic.KeyValuePair<string, string> current in dictionary)
			{
				text3 = text3 + current.Value + "&";
			}
			text3 = text3.Remove(text3.Length - 1);
			string value4 = TextEncrypt.EncryptPassword(text3 + str);
			dictionary["p7_sign"] = value4;
			dictionary["p8_signtype"] = "1";
			dictionary["p9_paymethod"] = text;
			dictionary["p18_product"] = "productname";
			dictionary["p25_terminal"] = value;
			dictionary["p26_iswappay"] = value;
			base.Response.Write(PayHelper.BuildForm(dictionary, gateway));
			base.Response.End();
		}
	}
}
