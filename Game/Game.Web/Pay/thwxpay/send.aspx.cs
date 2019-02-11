using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Game.Web.Pay.thwxpay
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
			if (formInt < 20)
			{
				base.Response.Write("充值金额不能低于20");
				base.Response.End();
			}
			string text = base.Request["type"];
			if (string.IsNullOrEmpty(text))
			{
				base.Response.Write("请选择支付方式");
				base.Response.End();
			}
			double num = System.Convert.ToDouble(base.Request["money"]);
			if (num < 0.0)
			{
				base.Response.Write("充值金额不能低于0元");
				base.Response.End();
			}
			OnLineOrder onLineOrder = new OnLineOrder();
			onLineOrder.OrderID = PayHelper.GetOrderIDByPrefix("th");
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
				if (!(a == "alipay-wap"))
				{
					if (!(a == "weixin-wap"))
					{
						if (!(a == "alipay"))
						{
							if (a == "weixin")
							{
								text = "WEIXIN";
								onLineOrder.ShareID = 5;
							}
						}
						else
						{
							text = "ZHIFUBAO";
							onLineOrder.ShareID = 4;
						}
					}
					else
					{
						text = "WEIXIN_H5";
						onLineOrder.ShareID = 3;
					}
				}
				else
				{
					text = "ZHIFUBAO_H5";
					onLineOrder.ShareID = 2;
				}
			}
			Message message = FacadeManage.aideTreasureFacade.RequestOrder(onLineOrder);
			if (!message.Success)
			{
				base.Response.Write(message.Content);
				base.Response.End();
			}
			string value = ApplicationSettings.Get("partner_41");
			string str = ApplicationSettings.Get("key_41");
			string actionUrl = ApplicationSettings.Get("url_41");
			string str2 = ApplicationSettings.Get("pay_url");
			string value2 = str2 + "/pay/41/notify_url.aspx";
			string value3 = str2 + "/pay/41/return_url.aspx";
			string value4 = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>();
			sortedDictionary.Add("input_charset", "UTF-8");
			sortedDictionary.Add("notify_url", value2);
			sortedDictionary.Add("return_url", value3);
			sortedDictionary.Add("pay_type", "1");
			sortedDictionary.Add("bank_code", text);
			sortedDictionary.Add("merchant_code", value);
			sortedDictionary.Add("order_no", onLineOrder.OrderID);
			sortedDictionary.Add("order_amount", num.ToString());
			sortedDictionary.Add("order_time", value4);
			sortedDictionary.Add("product_name", "");
			sortedDictionary.Add("product_num", "");
			sortedDictionary.Add("req_referer", "");
			sortedDictionary.Add("customer_ip", "");
			sortedDictionary.Add("customer_phone", "");
			sortedDictionary.Add("receive_address", "");
			sortedDictionary.Add("return_params", "");
			string text2 = "";
			foreach (System.Collections.Generic.KeyValuePair<string, string> current in sortedDictionary)
			{
				if (current.Value != "")
				{
					string text3 = text2;
					text2 = string.Concat(new string[]
					{
						text3,
						current.Key,
						"=",
						current.Value,
						"&"
					});
				}
			}
			text2 = text2 + "key=" + str;
			sortedDictionary.Add("sign", Jiami.MD5(text2, "UTF-8"));
			base.Response.Write(HttpHelper.CreatFormHtml(actionUrl, sortedDictionary, "post"));
		}
	}
}
