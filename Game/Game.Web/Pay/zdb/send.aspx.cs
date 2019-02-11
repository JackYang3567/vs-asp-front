using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;
using System.Xml.XPath;
using testOrder;
namespace Game.Web.Pay.zdb
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
			onLineOrder.OrderID = PayHelper.GetOrderIDByPrefix("zdb");
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
			string text8 = text;
			switch (text8)
			{
			case "alipay":
				text = "aliapi_h5api";
				onLineOrder.ShareID = 2;
				goto IL_23A;
			case "weixin":
				text = "weixin_h5api";
				onLineOrder.ShareID = 3;
				goto IL_23A;
			case "alipay-scan":
				text = "alipay_scan";
				this.paytype = "支付宝";
				onLineOrder.ShareID = 4;
				goto IL_23A;
			case "weixin-scan":
				text = "weixin_scan";
				this.paytype = "微信";
				onLineOrder.ShareID = 5;
				goto IL_23A;
			case "qq":
				text = "qq_h5api";
				onLineOrder.ShareID = 6;
				goto IL_23A;
			case "qq-scan":
				text = "tenpay_scan";
				this.paytype = "QQ";
				onLineOrder.ShareID = 8;
				goto IL_23A;
			case "kuaijie":
				text = "wangyin-kj";
				onLineOrder.ShareID = 7;
				goto IL_23A;
			}
			onLineOrder.ShareID = 1;
			IL_23A:
			Message message = FacadeManage.aideTreasureFacade.RequestOrder(onLineOrder);
			if (!message.Success)
			{
				base.Response.Write(message.Content);
				base.Response.End();
			}
			string value = ApplicationSettings.Get("parter_zdb");
			string text2 = ApplicationSettings.Get("priKey_zdb");
			string text3 = ApplicationSettings.Get("pay_url");
			string text4 = ApplicationSettings.Get("url_zdb");
			if (text.Contains("_scan"))
			{
				text4 += "scanpay";
			}
			if (text.Contains("_h5api"))
			{
				text4 += "h5apipay";
			}
			if (text3 == "")
			{
				text3 = "http://" + base.Request.Url.Host;
			}
			string value2 = text3 + "/pay/zdb/notify_url.aspx";
			SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>();
			sortedDictionary["merchant_code"] = value;
			sortedDictionary["service_type"] = text;
			sortedDictionary["notify_url"] = value2;
			sortedDictionary["interface_version"] = "V3.1";
			sortedDictionary["client_ip"] = GameRequest.GetUserIP();
			sortedDictionary["order_no"] = onLineOrder.OrderID;
			sortedDictionary["order_time"] = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			sortedDictionary["order_amount"] = formInt.ToString();
			sortedDictionary["product_name"] = "shop";
			sortedDictionary["product_code"] = "";
			sortedDictionary["product_num"] = "";
			sortedDictionary["product_desc"] = "";
			sortedDictionary["extra_return_param"] = "";
			sortedDictionary["extend_param"] = "";
			string text5 = PayHelper.PrepareSign(sortedDictionary);
			string privateKey = text2;
			privateKey = HttpHelp.RSAPrivateKeyJava2DotNet(privateKey);
			string text6 = HttpHelp.RSASign(text5, privateKey);
			text6 = System.Web.HttpUtility.UrlEncode(text6);
			sortedDictionary["sign_type"] = "RSA-S";
			sortedDictionary["sign"] = text6;
			string postData = string.Concat(new string[]
			{
				text5,
				"&sign_type=",
				sortedDictionary["sign_type"],
				"&sign=",
				text6
			});
			string text7 = HttpHelp.HttpPost(text4, postData);
			XElement node = XElement.Load(new System.IO.StringReader(text7));
			if (!text.Contains("_h5api"))
			{
				XElement xElement = node.XPathSelectElement("/response/qrcode");
				if (xElement == null)
				{
					base.Response.Write("状态:" + text7 + "<br/>");
					base.Response.End();
				}
				this.qrcode = Regex.Match(xElement.ToString(), "(?<=>).*?(?=<)").Value;
				this.order_no = onLineOrder.OrderID;
				this.order_amount = formInt.ToString();
			}
			else
			{
				XElement xElement2 = node.XPathSelectElement("/response/apiURL");
				if (xElement2 == null)
				{
					base.Response.Write("状态:" + text7 + "<br/>");
					base.Response.End();
				}
				else
				{
					base.Response.Redirect(xElement2.ToString());
				}
			}
		}
	}
}
