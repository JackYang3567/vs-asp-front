using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Game.Web.Pay.epay
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
			onLineOrder.OrderID = PayHelper.GetOrderIDByPrefix("e");
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
				text = "alipay.wap";
				onLineOrder.ShareID = 2;
				goto IL_240;
			case "weixin":
				text = "wxpay.wap";
				onLineOrder.ShareID = 3;
				goto IL_240;
			case "alipay-scan":
				text = "alipay.ma";
				this.paytype = "支付宝";
				onLineOrder.ShareID = 4;
				goto IL_240;
			case "weixin-scan":
				text = "wxpay.ma";
				this.paytype = "微信";
				onLineOrder.ShareID = 5;
				goto IL_240;
			case "qq":
				text = "qqpay.wap";
				onLineOrder.ShareID = 6;
				goto IL_240;
			case "qq-scan":
				text = "qqpay.ma";
				this.paytype = "QQ";
				onLineOrder.ShareID = 8;
				goto IL_240;
			case "kuaijie":
				text = "wangyin.wap";
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
			string url = ApplicationSettings.Get("url_e");
			string value = ApplicationSettings.Get("parter_e");
			string str = ApplicationSettings.Get("key_e");
			string text2 = ApplicationSettings.Get("pay_url");
			if (text2 == "")
			{
				text2 = "http://" + base.Request.Url.Host;
			}
			string orderID = onLineOrder.OrderID;
			string value2 = text2 + "/pay/epay/notify_url.aspx";
			SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>();
			sortedDictionary["out_trade_no"] = orderID;
			sortedDictionary["service"] = text;
			sortedDictionary["partner"] = value;
			sortedDictionary["version"] = "";
			sortedDictionary["charset"] = "utf-8";
			sortedDictionary["sign_type"] = "";
			sortedDictionary["total_fee"] = formInt.ToString("#0.00");
			sortedDictionary["notify_url"] = value2;
			sortedDictionary["return_url"] = value2;
			sortedDictionary["nonce_str"] = TextUtility.CreateAuthStr(20, false);
			string str2 = PayHelper.PrepareSign(sortedDictionary);
			string str3 = TextEncrypt.EncryptPassword(str2 + str).ToLower();
			string param = str2 + "&sign=" + str3;
			string s = HttpHelper.HttpRequest(url, param);
			base.Response.Write(s);
			base.Response.End();
		}
	}
}
