using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Game.Web.Pay.yika
{
    public partial class send : System.Web.UI.Page
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
			onLineOrder.OrderID = PayHelper.GetOrderIDByPrefix("y");
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
			if (text == "bank")
			{
				text = "1000";
				onLineOrder.ShareID = 1;
			}
			if (text == "alipay-wap-yika")
			{
				text = "1006";
				onLineOrder.ShareID = 2;
			}
			if (text == "weixin-wap-yika")
			{
				text = "1007";
				onLineOrder.ShareID = 3;
			}
			if (text == "alipay")
			{
				text = "992";
				onLineOrder.ShareID = 4;
			}
			if (text == "weixin")
			{
				text = "1004";
				onLineOrder.ShareID = 5;
			}
			if (text == "qq-wap")
			{
				text = "1008";
				onLineOrder.ShareID = 6;
			}
			Message message = FacadeManage.aideTreasureFacade.RequestOrder(onLineOrder);
			if (!message.Success)
			{
				base.Response.Write(message.Content);
				base.Response.End();
			}
			string str = ApplicationSettings.Get("url_yika");
			string text2 = ApplicationSettings.Get("parter_yika");
			string text3 = ApplicationSettings.Get("key_yika");
			string text4 = ApplicationSettings.Get("pay_url");
			if (text4 == "")
			{
				text4 = "http://" + base.Request.Url.Host;
			}
			string orderID = onLineOrder.OrderID;
			string text5 = text4 + "/pay/yika/notify_url.aspx";
			string str2 = text4 + "/pay/yika/return_url.aspx";
			string password = string.Format("parter={0}&type={1}&value={2}&orderid={3}&callbackurl={4}{5}", new object[]
			{
				text2,
				text,
				formInt,
				orderID,
				text5,
				text3
			});
			string str3 = TextEncrypt.EncryptPassword(password).ToLower();
			string value = str + "?parter=" + text2;
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(value);
			stringBuilder.Append("&type=" + text);
			stringBuilder.Append("&value=" + formInt);
			stringBuilder.Append("&orderid=" + orderID);
			stringBuilder.Append("&callbackurl=" + text5);
			stringBuilder.Append("&hrefbackurl=" + str2);
			stringBuilder.Append("&payerIp=" + onLineOrder.IPAddress);
			stringBuilder.Append("&attach=");
			stringBuilder.Append("&sign=" + str3);
			stringBuilder.Append("&agent=");
			stringBuilder.Append("&playerId=");
			base.Response.Redirect(stringBuilder.ToString());
		}
	}
}
