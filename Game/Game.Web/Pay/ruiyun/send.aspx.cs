using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Game.Web.Pay.ruiyun
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
			onLineOrder.OrderID = PayHelper.GetOrderIDByPrefix("ruiyun");
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
			string text6 = text;
			switch (text6)
			{
			case "alipay":
				text = "1006";
				onLineOrder.ShareID = 2;
				goto IL_240;
			case "weixin":
				text = "1005";
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
				text = "1594";
				onLineOrder.ShareID = 6;
				goto IL_240;
			case "qq-scan":
				text = "1593";
				this.paytype = "QQ";
				onLineOrder.ShareID = 8;
				goto IL_240;
			case "kuaijie":
				text = "2088";
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
			string arg = ApplicationSettings.Get("url_ruiyun");
			string text2 = ApplicationSettings.Get("parter_ruiyun");
			string str = ApplicationSettings.Get("key_ruiyun");
			string text3 = ApplicationSettings.Get("pay_url");
			if (text3 == "")
			{
				text3 = "http://" + base.Request.Url.Host;
			}
			string arg_29A_0 = onLineOrder.OrderID;
			string text4 = text3 + "/pay/ruiyun/notify_url.aspx";
			string text5 = string.Format("parter={0}&type={1}&value={2}&orderid={3}&callbackurl={4}", new object[]
			{
				text2,
				text,
				onLineOrder.OrderAmount,
				onLineOrder.OrderID,
				text4
			});
			string url = string.Format("{0}?{1}&sign={2}", arg, text5, System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(text5 + str, "MD5").ToLower());
			base.Response.Redirect(url);
		}
	}
}
