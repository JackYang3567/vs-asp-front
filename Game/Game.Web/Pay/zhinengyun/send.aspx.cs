using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Web.UI;
namespace Game.Web.Pay.zhinengyun
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
			string formString2 = GameRequest.GetFormString("type");
			OnLineOrder onLineOrder = new OnLineOrder();
			onLineOrder.OrderID = PayHelper.GetOrderIDByPrefix("zny");
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
			string text = "";
			if (formString2 == "alipay")
			{
				text = "10001";
				onLineOrder.ShareID = 2;
				this.paytype = "支付宝";
			}
			if (formString2 == "weixin")
			{
				text = "20001";
				onLineOrder.ShareID = 3;
				this.paytype = "微信";
			}
			if (formString2 == "weixin-scan")
			{
				text = "20001";
				onLineOrder.ShareID = 5;
				this.paytype = "微信";
			}
			Message message = FacadeManage.aideTreasureFacade.RequestOrder(onLineOrder);
			if (!message.Success)
			{
				base.Response.Write(message.Content);
				base.Response.End();
			}
			string url = ApplicationSettings.Get("url_zny");
			string value = ApplicationSettings.Get("parter_zny");
			string text2 = ApplicationSettings.Get("key_zny");
			string text3 = ApplicationSettings.Get("pay_url");
			if (text3 == "")
			{
				text3 = "http://" + base.Request.Url.Host;
			}
			string value2 = text3 + "/pay/zhinengyun/notify_url.aspx";
			System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
			dictionary["uid"] = value;
			dictionary["orderid"] = onLineOrder.OrderID;
			dictionary["istype"] = text;
			dictionary["price"] = formInt.ToString();
			dictionary["goodsname"] = "shop";
			dictionary["orderuid"] = TextUtility.CreateAuthStr(20, false);
			dictionary["notify_url"] = value2;
			dictionary["return_url"] = value2;
			dictionary["format "] = "json";
			string password = string.Concat(new string[]
			{
				dictionary["goodsname"],
				dictionary["istype"],
				dictionary["notify_url"],
				dictionary["orderid"],
				dictionary["orderuid"],
				dictionary["price"],
				dictionary["return_url"],
				text2,
				dictionary["uid"]
			});
			string value3 = TextEncrypt.EncryptPassword(password).ToLower();
			dictionary["key"] = value3;
			string param = PayHelper.PrepareSign(dictionary);
			string json = HttpHelper.HttpRequest(url, param);
			System.Collections.Generic.Dictionary<string, object> dictionary2 = JsonHelper.DeserializeJsonToObject<System.Collections.Generic.Dictionary<string, object>>(json);
			if (!dictionary2.ContainsKey("code"))
			{
				base.Response.Write("接口正在维护中...");
			}
			else
			{
				if (!(dictionary2["code"].ToString() == "200"))
				{
					base.Response.Write(dictionary2["msg"].ToString());
				}
				else
				{
					Log.Write(dictionary2["data"].ToString());
					System.Collections.Generic.Dictionary<string, string> dictionary3 = JsonHelper.DeserializeJsonToObject<System.Collections.Generic.Dictionary<string, string>>(dictionary2["data"].ToString());
					if (text == "10001")
					{
						base.Response.Redirect(dictionary3["qrcode"]);
					}
					else
					{
						this.order_no = onLineOrder.OrderID;
						this.order_amount = formInt.ToString();
						this.qrcode = dictionary3["qrcode"];
					}
				}
			}
		}
	}
}
