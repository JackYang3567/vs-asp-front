using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Game.Web.Pay.yyb
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
			onLineOrder.OrderID = PayHelper.GetOrderIDByPrefix("yyb");
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
			string a;
			if ((a = text) != null)
			{
				if (!(a == "weixin"))
				{
					if (!(a == "alipay-scan"))
					{
						if (!(a == "weixin-scan"))
						{
							if (a == "qq-scan")
							{
								text = "2";
								this.paytype = "QQ";
								onLineOrder.ShareID = 8;
							}
						}
						else
						{
							text = "3";
							this.paytype = "微信";
							onLineOrder.ShareID = 5;
						}
					}
					else
					{
						text = "1";
						this.paytype = "支付宝";
						onLineOrder.ShareID = 4;
					}
				}
				else
				{
					text = "3";
					onLineOrder.ShareID = 3;
				}
			}
			Message message = FacadeManage.aideTreasureFacade.RequestOrder(onLineOrder);
			if (!message.Success)
			{
				base.Response.Write(message.Content);
				base.Response.End();
			}
			string str = ApplicationSettings.Get("url_yyb");
			string value = ApplicationSettings.Get("parter_yyb");
			ApplicationSettings.Get("key_yyb");
			string text2 = ApplicationSettings.Get("pay_url");
			if (text2 == "")
			{
				text2 = "http://" + base.Request.Url.Host;
			}
			string orderID = onLineOrder.OrderID;
			string value2 = text2 + "/pay/yyb/notify_url.aspx";
			System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
			dictionary["pid"] = value;
			dictionary["lb"] = text;
			dictionary["money"] = formInt.ToString();
			dictionary["data"] = orderID;
			dictionary["url"] = value2;
			dictionary["m"] = "0";
			dictionary["bk"] = "1";
			string url = str + "?" + PayHelper.PrepareSign(dictionary);
			base.Response.Redirect(url);
		}
	}
}
