using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Game.Web.Pay.san
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
			string formString2 = GameRequest.GetFormString("type");
			OnLineOrder onLineOrder = new OnLineOrder();
			onLineOrder.OrderID = PayHelper.GetOrderIDByPrefix("txf");
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
			string value = "";
			string text = ApplicationSettings.Get("url_san");
			if (formString2 == "alipay")
			{
				value = "2";
				onLineOrder.ShareID = 2;
				text += "/Pay/GateWayAliPay.aspx";
			}
			else
			{
				text += "/Pay/GateWayTencent.aspx";
			}
			if (formString2 == "weixin")
			{
				value = "2";
				onLineOrder.ShareID = 3;
			}
			if (formString2 == "qq")
			{
				value = "4";
				onLineOrder.ShareID = 6;
			}
			if (formString2 == "jd")
			{
				value = "5";
				onLineOrder.ShareID = 9;
			}
			Message message = FacadeManage.aideTreasureFacade.RequestOrder(onLineOrder);
			if (!message.Success)
			{
				base.Response.Write(message.Content);
				base.Response.End();
			}
			string value2 = ApplicationSettings.Get("partner_san");
			string text2 = ApplicationSettings.Get("key_san");
			string text3 = ApplicationSettings.Get("pay_url");
			if (text3 == "")
			{
				text3 = "http://" + base.Request.Url.Host;
			}
			string value3 = text3 + "/pay/san/notify_url.aspx";
			System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
			dictionary["app_id"] = value2;
			dictionary["pay_type"] = value;
			dictionary["order_id"] = onLineOrder.OrderID;
			dictionary["order_amt"] = formInt.ToString();
			dictionary["notify_url"] = value3;
			dictionary["return_url"] = value3;
			dictionary["time_stamp"] = System.DateTime.Now.ToString("yyyyMMddHHmmss");
			string text4 = "";
			foreach (System.Collections.Generic.KeyValuePair<string, string> current in dictionary)
			{
				string text5 = text4;
				text4 = string.Concat(new string[]
				{
					text5,
					current.Key,
					"=",
					current.Value,
					"&"
				});
			}
			text2 = TextEncrypt.EncryptPassword(text2).ToLower();
			string value4 = TextEncrypt.EncryptPassword(text4 + "key=" + text2).ToLower();
			dictionary["goods_name"] = "shop";
			dictionary["sign"] = value4;
			string param = PayHelper.PrepareSign(dictionary);
			string json = HttpHelper.HttpRequest(text, param);
			System.Collections.Generic.Dictionary<string, string> dictionary2 = JsonHelper.DeserializeJsonToObject<System.Collections.Generic.Dictionary<string, string>>(json);
			if (!dictionary2.ContainsKey("status_code"))
			{
				base.Response.Write("下单失败");
			}
			else
			{
				if (dictionary2["status_code"] == "0")
				{
					base.Response.Redirect(dictionary2["pay_url"]);
				}
				else
				{
					base.Response.Write(dictionary2["status_msg"]);
				}
			}
		}
	}
}
