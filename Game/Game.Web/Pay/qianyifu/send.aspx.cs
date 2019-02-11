using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Game.Web.Pay.qianyifu
{
    public partial  class send : System.Web.UI.Page
	{
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
			onLineOrder.OrderID = PayHelper.GetOrderIDByPrefix("qyf");
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
			string text5 = text;
			switch (text5)
			{
			case "alipay":
				text = "zhifubao-wap";
				onLineOrder.ShareID = 2;
				goto IL_237;
			case "weixin":
				text = "weixin-wap";
				onLineOrder.ShareID = 3;
				goto IL_237;
			case "alipay-scan":
				text = "zhifubao";
				onLineOrder.ShareID = 4;
				goto IL_237;
			case "weixin-scan":
				text = "weixin";
				onLineOrder.ShareID = 5;
				goto IL_237;
			case "qq":
				text = "qq-wap";
				onLineOrder.ShareID = 6;
				goto IL_237;
			case "qq-scan":
				text = "qqsm";
				onLineOrder.ShareID = 8;
				goto IL_237;
			case "kuaijie":
				text = "wangyin-kj";
				onLineOrder.ShareID = 7;
				goto IL_237;
			case "jd":
				text = "jd-wap";
				onLineOrder.ShareID = 9;
				goto IL_237;
			}
			onLineOrder.ShareID = 1;
			IL_237:
			Message message = FacadeManage.aideTreasureFacade.RequestOrder(onLineOrder);
			if (!message.Success)
			{
				base.Response.Write(message.Content);
				base.Response.End();
			}
			string str = ApplicationSettings.Get("url_qianyifu");
			string text2 = ApplicationSettings.Get("partner_qianyifu");
			string text3 = ApplicationSettings.Get("key_qianyifu");
			string text4 = ApplicationSettings.Get("pay_url");
			if (text4 == "")
			{
				text4 = "http://" + base.Request.Url.Host;
			}
			string orderID = onLineOrder.OrderID;
			string str2 = text4 + "/pay/qianyifu/notify_url.aspx";
			text4 += "/pay/qianyifu/return_url.aspx";
			string password = string.Format("userid={0}&orderid={1}&bankid={2}&keyvalue={3}", new object[]
			{
				text2,
				orderID,
				text,
				text3
			});
			string str3 = TextEncrypt.EncryptPassword(password).ToLower();
			string value = str + "?userid=" + text2;
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(value);
			stringBuilder.Append("&orderid=" + orderID);
			stringBuilder.Append("&money=" + formInt.ToString());
			stringBuilder.Append("&hrefurl=" + str2);
			stringBuilder.Append("&url=" + str2);
			stringBuilder.Append("&bankid=" + text);
			stringBuilder.Append("&sign=" + str3);
			stringBuilder.Append("&ext=" + formString);
			base.Response.Redirect(stringBuilder.ToString());
		}
	}
}
