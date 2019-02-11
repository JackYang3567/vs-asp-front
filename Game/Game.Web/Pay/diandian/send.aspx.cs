using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Game.Web.Pay.diandian
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
			onLineOrder.OrderID = PayHelper.GetOrderIDByPrefix("dd");
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
				text = "010008";
				onLineOrder.ShareID = 2;
				goto IL_289;
			case "weixin":
				text = "010007";
				onLineOrder.ShareID = 3;
				goto IL_289;
			case "alipay-scan":
				text = "010002";
				this.paytype = "支付宝";
				onLineOrder.ShareID = 4;
				goto IL_289;
			case "weixin-scan":
				text = "010001";
				this.paytype = "微信";
				onLineOrder.ShareID = 5;
				goto IL_289;
			case "qq":
				text = "7";
				onLineOrder.ShareID = 6;
				goto IL_289;
			case "kuaijie":
				text = "010010";
				onLineOrder.ShareID = 7;
				goto IL_289;
			case "qq-scan":
				text = "010000";
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
			string url = ApplicationSettings.Get("url_dd");
			string value = ApplicationSettings.Get("parter_dd");
			string str = ApplicationSettings.Get("key_dd");
			string text2 = ApplicationSettings.Get("pay_url");
			if (text2 == "")
			{
				text2 = "http://" + base.Request.Url.Host;
			}
			string orderID = onLineOrder.OrderID;
			string value2 = text2 + "/pay/diandian/notify_url.aspx";
			string str2 = "{\"mch_app_id\":\"http://www.qp137.com\",\"device_info\":\"AND_WAP\",\"ua\":\"Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.100 Safari/537.36\",\"mch_app_name\":\"支付测试\",\"cashier_desk\":\"1\"}";
			string s = System.Web.HttpUtility.UrlEncode(str2);
			byte[] bytes = System.Text.Encoding.UTF8.GetBytes(s);
			string value3 = System.Convert.ToBase64String(bytes);
			System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
			dictionary["version"] = "1.0";
			dictionary["charset"] = "utf-8";
			dictionary["merchant_id"] = value;
			dictionary["out_trade_no"] = orderID;
			dictionary["user_ip"] = GameRequest.GetUserIP();
			dictionary["subject"] = "支付测试";
			dictionary["body"] = "支付测试";
			dictionary["user_id"] = formString;
			dictionary["total_fee"] = formInt.ToString("#0.00");
			dictionary["notify_url"] = value2;
			dictionary["return_url"] = value2;
			dictionary["nonce_str"] = TextUtility.CreateAuthStr(20, false);
			dictionary["biz_content"] = value3;
			dictionary["trade_type"] = text;
			dictionary = (
				from p in dictionary
				orderby p.Key
				select p).ToDictionary((System.Collections.Generic.KeyValuePair<string, string> p) => p.Key, (System.Collections.Generic.KeyValuePair<string, string> o) => o.Value);
			string str3 = PayHelper.PrepareSign(dictionary) + "&key=" + str;
			dictionary["sign"] = Jiami.MD5(str3).ToUpper();
			string param = PayHelper.ToXml(dictionary);
			string text3 = HttpHelper.HttpRequest(url, param, "post", "utf-8", "text/xml");
			System.Collections.Generic.Dictionary<string, string> dictionary2 = PayHelper.XmlToDic(text3);
			if (!dictionary2.ContainsKey("status"))
			{
				base.Response.Write(text3);
				base.Response.End();
			}
			else
			{
				string a = dictionary2["status"];
				if (a == "0")
				{
					this.order_no = orderID;
					this.order_amount = formInt.ToString();
					this.qrcode = dictionary2["pay_info"];
					base.Response.Redirect(this.qrcode);
				}
				else
				{
					base.Response.Write(dictionary2["message"]);
					base.Response.End();
				}
			}
		}
	}
}
