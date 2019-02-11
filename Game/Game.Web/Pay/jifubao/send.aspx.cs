using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Game.Web.Pay.jifubao
{
    public partial  class send : System.Web.UI.Page
	{
		protected string ordernumber = "";
		protected string paymoney = "";
		protected string qrCode = "";
		protected System.Web.UI.HtmlControls.HtmlForm form1;
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
			onLineOrder.OrderID = PayHelper.GetOrderIDByPrefix("jfb");
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
			if (text == "alipay")
			{
				text = "1";
				onLineOrder.ShareID = 2;
			}
			if (text == "weixin")
			{
				text = "2";
				onLineOrder.ShareID = 3;
			}
			if (text == "qq")
			{
				text = "3";
				onLineOrder.ShareID = 6;
			}
			Message message = FacadeManage.aideTreasureFacade.RequestOrder(onLineOrder);
			if (!message.Success)
			{
				base.Response.Write(message.Content);
				base.Response.End();
			}
			string gateway = ApplicationSettings.Get("url_jifubao");
			string value = ApplicationSettings.Get("partner_jifubao");
			string str = ApplicationSettings.Get("key_jifubao");
			string text2 = ApplicationSettings.Get("pay_url");
			this.ordernumber = onLineOrder.OrderID;
			this.paymoney = num.ToString();
			if (text2 == "")
			{
				text2 = "http://" + base.Request.Url.Host;
			}
			string value2 = text2 + "/pay/jifubao/notify_url.aspx";
			System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
			dictionary["service"] = "TRADE.H5PAY";
			dictionary["version"] = "1.0.0.0";
			dictionary["merId"] = value;
			dictionary["typeId"] = text;
			dictionary["tradeNo"] = this.ordernumber;
			dictionary["tradeDate"] = System.DateTime.Now.ToString("yyyyMMdd");
			dictionary["amount"] = this.paymoney;
			dictionary["notifyUrl"] = value2;
			dictionary["extra"] = "";
			dictionary["summary"] = "shop";
			dictionary["expireTime"] = "";
			dictionary["clientIp"] = GameRequest.GetUserIP();
			string str2 = PayHelper.PrepareSign(dictionary);
			string value3 = TextEncrypt.EncryptPassword(str2 + str).ToLower();
			dictionary["sign"] = value3;
			base.Response.Write(PayHelper.BuildForm(dictionary, gateway));
			base.Response.End();
		}
	}
}
