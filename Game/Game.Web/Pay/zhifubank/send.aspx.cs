using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using testOrder;
namespace Game.Web.Pay.zhifubank
{
    public partial class send : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlForm dinpayForm;
		protected System.Web.UI.HtmlControls.HtmlInputHidden sign;
		protected System.Web.UI.HtmlControls.HtmlInputHidden merchant_code;
		protected System.Web.UI.HtmlControls.HtmlInputHidden bank_code;
		protected System.Web.UI.HtmlControls.HtmlInputHidden order_no;
		protected System.Web.UI.HtmlControls.HtmlInputHidden order_amount;
		protected System.Web.UI.HtmlControls.HtmlInputHidden service_type;
		protected System.Web.UI.HtmlControls.HtmlInputHidden input_charset;
		protected System.Web.UI.HtmlControls.HtmlInputHidden notify_url;
		protected System.Web.UI.HtmlControls.HtmlInputHidden interface_version;
		protected System.Web.UI.HtmlControls.HtmlInputHidden sign_type;
		protected System.Web.UI.HtmlControls.HtmlInputHidden order_time;
		protected System.Web.UI.HtmlControls.HtmlInputHidden product_name;
		protected System.Web.UI.HtmlControls.HtmlInputHidden client_ip_check;
		protected System.Web.UI.HtmlControls.HtmlInputHidden client_ip;
		protected System.Web.UI.HtmlControls.HtmlInputHidden extend_param;
		protected System.Web.UI.HtmlControls.HtmlInputHidden extra_return_param;
		protected System.Web.UI.HtmlControls.HtmlInputHidden product_code;
		protected System.Web.UI.HtmlControls.HtmlInputHidden product_desc;
		protected System.Web.UI.HtmlControls.HtmlInputHidden product_num;
		protected System.Web.UI.HtmlControls.HtmlInputHidden return_url;
		protected System.Web.UI.HtmlControls.HtmlInputHidden show_url;
		protected System.Web.UI.HtmlControls.HtmlInputHidden redo_flag;
		protected System.Web.UI.HtmlControls.HtmlInputHidden pay_type;
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
			GameRequest.GetFormString("type");
			string str = "http://pay.cffsye.top";
			string text = "UTF-8";
			string text2 = "V3.0";
			string text3 = ApplicationSettings.Get("parter_zhifu");
			string text4 = str + "/pay/zhifubank/notify_url.aspx";
			string text5 = formInt.ToString();
			string orderIDByPrefix = PayHelper.GetOrderIDByPrefix("zf");
			string text6 = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			string text7 = "RSA-S";
			string text8 = "";
			string text9 = "";
			string text10 = "test";
			string text11 = "";
			string text12 = str + "/pay/zhifubank/notify_url.aspx";
			string text13 = "direct_pay";
			string text14 = "";
			string text15 = "";
			string text16 = "";
			string text17 = "";
			string text18 = "";
			string text19 = "";
			string text20 = "";
			string text21 = "";
			string text22 = "";
			if (text17 != "")
			{
				text22 = text22 + "bank_code=" + text17 + "&";
			}
			if (text18 != "")
			{
				text22 = text22 + "client_ip=" + text18 + "&";
			}
			if (text19 != "")
			{
				text22 = text22 + "client_ip_check=" + text19 + "&";
			}
			if (text15 != "")
			{
				text22 = text22 + "extend_param=" + text15 + "&";
			}
			if (text16 != "")
			{
				text22 = text22 + "extra_return_param=" + text16 + "&";
			}
			if (text != "")
			{
				text22 = text22 + "input_charset=" + text + "&";
			}
			if (text2 != "")
			{
				text22 = text22 + "interface_version=" + text2 + "&";
			}
			if (text3 != "")
			{
				text22 = text22 + "merchant_code=" + text3 + "&";
			}
			if (text4 != "")
			{
				text22 = text22 + "notify_url=" + text4 + "&";
			}
			if (text5 != "")
			{
				text22 = text22 + "order_amount=" + text5 + "&";
			}
			if (orderIDByPrefix != "")
			{
				text22 = text22 + "order_no=" + orderIDByPrefix + "&";
			}
			if (text6 != "")
			{
				text22 = text22 + "order_time=" + text6 + "&";
			}
			if (text21 != "")
			{
				text22 = text22 + "pay_type=" + text21 + "&";
			}
			if (text8 != "")
			{
				text22 = text22 + "product_code=" + text8 + "&";
			}
			if (text9 != "")
			{
				text22 = text22 + "product_desc=" + text9 + "&";
			}
			if (text10 != "")
			{
				text22 = text22 + "product_name=" + text10 + "&";
			}
			if (text11 != "")
			{
				text22 = text22 + "product_num=" + text11 + "&";
			}
			if (text20 != "")
			{
				text22 = text22 + "redo_flag=" + text20 + "&";
			}
			if (text12 != "")
			{
				text22 = text22 + "return_url=" + text12 + "&";
			}
			if (text13 != "")
			{
				text22 = text22 + "service_type=" + text13;
			}
			if (text14 != "")
			{
				text22 = text22 + "&show_url=" + text14;
			}
			if (text7 == "RSA-S")
			{
				string privateKey = ApplicationSettings.Get("merPriKey_zhifu");
				privateKey = HttpHelp.RSAPrivateKeyJava2DotNet(privateKey);
				string value = HttpHelp.RSASign(text22, privateKey);
				this.sign.Value = value;
			}
			this.merchant_code.Value = text3;
			this.bank_code.Value = text17;
			this.order_no.Value = orderIDByPrefix;
			this.order_amount.Value = text5;
			this.service_type.Value = text13;
			this.input_charset.Value = text;
			this.notify_url.Value = text4;
			this.interface_version.Value = text2;
			this.sign_type.Value = text7;
			this.order_time.Value = text6;
			this.product_name.Value = text10;
			this.client_ip.Value = text18;
			this.client_ip_check.Value = text19;
			this.extend_param.Value = text15;
			this.extra_return_param.Value = text16;
			this.product_code.Value = text8;
			this.product_desc.Value = text9;
			this.product_num.Value = text11;
			this.return_url.Value = text12;
			this.show_url.Value = text14;
			this.redo_flag.Value = text20;
			this.pay_type.Value = text21;
			OnLineOrder onLineOrder = new OnLineOrder();
			onLineOrder.OrderID = orderIDByPrefix;
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
			onLineOrder.ShareID = 1;
			Message message = FacadeManage.aideTreasureFacade.RequestOrder(onLineOrder);
			if (!message.Success)
			{
				base.Response.Write(message.Content);
				base.Response.End();
			}
		}
	}
}
