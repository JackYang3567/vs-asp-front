using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Web.UI;
namespace Game.Web.Pay.heyifu
{
    public partial class send : System.Web.UI.Page
	{
		protected string ordernumber = "";
		protected string paymoney = "";
		protected string qrCode = "";
		protected void Page_Load(object sender, System.EventArgs e)
		{
			string formString = GameRequest.GetFormString("account");
			if (formString == "")
			{
				base.Response.Write("充值账号错误");
				base.Response.End();
			}
			decimal num = GameRequest.GetFormInt("amount", 0);
			if (num < 6m)
			{
				base.Response.Write("充值金额不能低于6元");
				base.Response.End();
			}
			string text = GameRequest.GetFormString("type");
			OnLineOrder onLineOrder = new OnLineOrder();
			onLineOrder.OrderID = PayHelper.GetOrderIDByPrefix("hyf");
			if (Fetch.GetUserCookie() == null)
			{
				onLineOrder.OperUserID = 0;
			}
			else
			{
				onLineOrder.OperUserID = Fetch.GetUserCookie().UserID;
			}
			onLineOrder.Accounts = formString;
			onLineOrder.OrderAmount = num;
			onLineOrder.IPAddress = GameRequest.GetUserIP();
			if (text == "alipay-scan")
			{
				text = "4";
				onLineOrder.ShareID = 4;
			}
			else
			{
				if (text == "weixin-scan")
				{
					onLineOrder.ShareID = 5;
				}
				else
				{
					if (text == "kuaijie")
					{
						text = "10";
						onLineOrder.ShareID = 7;
					}
				}
			}
			Message message = FacadeManage.aideTreasureFacade.RequestOrder(onLineOrder);
			if (!message.Success)
			{
				base.Response.Write(message.Content);
				base.Response.End();
			}
			string gateway = ApplicationSettings.Get("url_heyifu");
			string value = ApplicationSettings.Get("partner_heyifu");
			string str = ApplicationSettings.Get("key_heyifu");
			string text2 = ApplicationSettings.Get("pay_url");
			this.ordernumber = onLineOrder.OrderID;
			this.paymoney = num.ToString();
			if (text2 == "")
			{
				text2 = "http://" + base.Request.Url.Host;
			}
			string value2 = text2 + "/pay/heyifu/notify_url.aspx";
			System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
			dictionary["apiName"] = "WEB_PAY_B2C";
			dictionary["apiVersion"] = "1.0.0.0";
			dictionary["platformID"] = value;
			dictionary["merchNo"] = value;
			dictionary["orderNo"] = this.ordernumber;
			dictionary["tradeDate"] = System.DateTime.Now.ToString("yyyyMMdd");
			dictionary["amt"] = this.paymoney;
			dictionary["merchUrl"] = value2;
			dictionary["merchParam"] = "";
			dictionary["tradeSummary"] = "1|1";
			string str2 = PayHelper.PrepareSign(dictionary);
			string value3 = TextEncrypt.EncryptPassword(str2 + str);
			dictionary["bankCode"] = "";
			dictionary["choosePayType"] = text;
			dictionary["signMsg"] = value3;
			dictionary["overTime"] = "";
			dictionary["customerIP"] = GameRequest.GetUserIP();
			base.Response.Write(PayHelper.BuildForm(dictionary, gateway));
			base.Response.End();
		}
	}
}
