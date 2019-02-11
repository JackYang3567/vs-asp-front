using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Game.Web.Pay.guifu
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
			string text = GameRequest.GetFormString("type");
			OnLineOrder onLineOrder = new OnLineOrder();
			onLineOrder.OrderID = PayHelper.GetOrderIDByPrefix("gf");
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
				text = "1006";
				onLineOrder.ShareID = 2;
				goto IL_240;
			case "weixin":
				text = "1007";
				onLineOrder.ShareID = 3;
				goto IL_240;
			case "alipay-scan":
				text = "992";
				this.paytype = "支付宝";
				onLineOrder.ShareID = 4;
				goto IL_240;
			case "weixin-scan":
				text = "1004";
				this.paytype = "微信";
				onLineOrder.ShareID = 5;
				goto IL_240;
			case "qq":
				text = "92";
				onLineOrder.ShareID = 6;
				goto IL_240;
			case "qq-scan":
				text = "993";
				this.paytype = "QQ";
				onLineOrder.ShareID = 8;
				goto IL_240;
			case "kuaijie":
				text = "1005";
				onLineOrder.ShareID = 7;
				goto IL_240;
			}
			text = "1";
			onLineOrder.ShareID = 1;
			IL_240:
			Message message = FacadeManage.aideTreasureFacade.RequestOrder(onLineOrder);
			if (!message.Success)
			{
				base.Response.Write(message.Content);
				base.Response.End();
			}
			string str = ApplicationSettings.Get("url_gf");
			string value = ApplicationSettings.Get("parter_gf");
			string str2 = ApplicationSettings.Get("key_gf");
			string text2 = ApplicationSettings.Get("pay_url");
			if (text2 == "")
			{
				text2 = "http://" + base.Request.Url.Host;
			}
			string orderID = onLineOrder.OrderID;
			string value2 = text2 + "/pay/guifu/notify_url.aspx";
			System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
			dictionary["parter"] = value;
			dictionary["type"] = text;
			dictionary["value"] = formInt.ToString("#0.00");
			dictionary["orderid"] = orderID;
			dictionary["callbackurl"] = value2;
			string str3 = PayHelper.PrepareSign(dictionary);
			string value3 = TextEncrypt.EncryptPassword(str3 + str2).ToLower();
			dictionary["hrefbackurl"] = value2;
			dictionary["sign"] = value3;
			string url = str + "?" + PayHelper.PrepareSign(dictionary);
			base.Response.Redirect(url);
		}
	}
}
