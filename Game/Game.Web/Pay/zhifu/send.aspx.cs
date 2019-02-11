using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;
using System.Xml.XPath;
using testOrder;
namespace Game.Web.Pay.zhifu
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
			if (formInt < 20)
			{
				base.Response.Write("充值金额不能低于20");
				base.Response.End();
			}
			string text = GameRequest.GetFormString("type");
			OnLineOrder onLineOrder = new OnLineOrder();
			onLineOrder.OrderID = PayHelper.GetOrderIDByPrefix("zf");
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
			if (text == "alipay-wap")
			{
				text = "alipay_scan";
				onLineOrder.ShareID = 2;
			}
			if (text == "weixin-wap")
			{
				text = "weixin_scan";
				onLineOrder.ShareID = 3;
			}
			if (text == "alipay")
			{
				text = "alipay_scan";
				onLineOrder.ShareID = 4;
			}
			string text2 = ApplicationSettings.Get("parter_zhifu");
			string text3 = ApplicationSettings.Get("priKey_zhifu");
			string str = ApplicationSettings.Get("pay_url");
			string text4 = "V3.1";
			string text5 = text;
			string text6 = "RSA-S";
			string text7 = text2;
			this.order_no = onLineOrder.OrderID;
			string text8 = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Trim();
			this.order_amount = formInt.ToString().Trim();
			string text9 = "shop";
			string text10 = "";
			string text11 = "";
			string text12 = "";
			string text13 = "";
			string text14 = "";
			string text15 = str + "/pay/zhifu/notify_url.aspx";
			string userIP = GameRequest.GetUserIP();
			string text16 = "";
			if (userIP != "")
			{
				text16 = text16 + "client_ip=" + userIP + "&";
			}
			if (text14 != "")
			{
				text16 = text16 + "extend_param=" + text14 + "&";
			}
			if (text13 != "")
			{
				text16 = text16 + "extra_return_param=" + text13 + "&";
			}
			if (text4 != "")
			{
				text16 = text16 + "interface_version=" + text4 + "&";
			}
			if (text7 != "")
			{
				text16 = text16 + "merchant_code=" + text7 + "&";
			}
			if (text15 != "")
			{
				text16 = text16 + "notify_url=" + text15 + "&";
			}
			if (this.order_amount != "")
			{
				text16 = text16 + "order_amount=" + this.order_amount + "&";
			}
			if (this.order_no != "")
			{
				text16 = text16 + "order_no=" + this.order_no + "&";
			}
			if (text8 != "")
			{
				text16 = text16 + "order_time=" + text8 + "&";
			}
			if (text10 != "")
			{
				text16 = text16 + "product_code=" + text10 + "&";
			}
			if (text12 != "")
			{
				text16 = text16 + "product_desc=" + text12 + "&";
			}
			if (text9 != "")
			{
				text16 = text16 + "product_name=" + text9 + "&";
			}
			if (text11 != "")
			{
				text16 = text16 + "product_num=" + text11 + "&";
			}
			if (text5 != "")
			{
				text16 = text16 + "service_type=" + text5;
			}
			if (text6 == "RSA-S")
			{
				string privateKey = text3;
				privateKey = HttpHelp.RSAPrivateKeyJava2DotNet(privateKey);
				string text17 = HttpHelp.RSASign(text16, privateKey);
				text17 = System.Web.HttpUtility.UrlEncode(text17);
				string postData = string.Concat(new string[]
				{
					text16,
					"&sign_type=",
					text6,
					"&sign=",
					text17
				});
				string text18 = HttpHelp.HttpPost("https://api.zhihpay.com/gateway/api/scanpay", postData);
				XElement node = XElement.Load(new System.IO.StringReader(text18));
				XElement xElement = node.XPathSelectElement("/response/qrcode");
				if (xElement == null)
				{
					base.Response.Write("状态:" + text18 + "<br/>");
					base.Response.End();
				}
				this.qrcode = Regex.Match(xElement.ToString(), "(?<=>).*?(?=<)").Value;
				Message message = FacadeManage.aideTreasureFacade.RequestOrder(onLineOrder);
				if (!message.Success)
				{
					base.Response.Write(message.Content);
					base.Response.End();
				}
				if (text == "alipay-wap")
				{
					base.Response.Redirect(this.qrcode);
				}
			}
		}
	}
}
