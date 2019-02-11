using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Game.Web.Pay.laifu
{
    public partial  class send : System.Web.UI.Page
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
			string text = GameRequest.GetFormString("type");
			OnLineOrder onLineOrder = new OnLineOrder();
			onLineOrder.OrderID = PayHelper.GetOrderIDByPrefix("lf");
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
			string text4 = text;
			switch (text4)
			{
			case "alipay":
				text = "alipaywap";
				onLineOrder.ShareID = 2;
				goto IL_240;
			case "weixin":
				text = "wxh5";
				onLineOrder.ShareID = 3;
				goto IL_240;
			case "alipay-scan":
				text = "alipay";
				this.paytype = "支付宝";
				onLineOrder.ShareID = 4;
				goto IL_240;
			case "weixin-scan":
				text = "weixin";
				this.paytype = "微信";
				onLineOrder.ShareID = 5;
				goto IL_240;
			case "qq":
				text = "qqwallet";
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
			string str = ApplicationSettings.Get("url_lf");
			string value = ApplicationSettings.Get("parter_lf");
			string text2 = ApplicationSettings.Get("key_lf");
			string text3 = ApplicationSettings.Get("pay_url");
			if (text3 == "")
			{
				text3 = "http://" + base.Request.Url.Host;
			}
			string orderID = onLineOrder.OrderID;
			string value2 = text3 + "/pay/laifu/notify_url.aspx";
			System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
			dictionary["version"] = "1.0";
			dictionary["customerid"] = value;
			dictionary["sdorderno"] = orderID;
			dictionary["total_fee"] = formInt.ToString("#0.00");
			dictionary["paytype"] = text;
			dictionary["notifyurl"] = value2;
			dictionary["returnurl"] = value2;
			string password = string.Format("version={0}&customerid={1}&total_fee={2}&sdorderno={3}&notifyurl={4}&returnurl={5}&{6}", new object[]
			{
				dictionary["version"],
				dictionary["customerid"],
				dictionary["total_fee"],
				dictionary["sdorderno"],
				dictionary["notifyurl"],
				dictionary["returnurl"],
				text2
			});
			string value3 = TextEncrypt.EncryptPassword(password).ToLower();
			dictionary["bankcode"] = "";
			dictionary["remark"] = "";
			dictionary["sign"] = value3;
			string url = str + "?" + PayHelper.PrepareSign(dictionary);
			base.Response.Redirect(url);
		}
	}
}
