using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Web.UI;
namespace Game.Web.Pay.thwxpay
{
    public partial class notify_url : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			string value = base.Request["merchant_code"];
			string value2 = base.Request["notify_type"];
			string text = base.Request["sign"];
			string text2 = base.Request["order_no"];
			string value3 = base.Request["order_amount"];
			string value4 = base.Request["order_time"];
			string value5 = base.Request["return_params"];
			string value6 = base.Request["trade_no"];
			string value7 = base.Request["trade_time"];
			string text3 = base.Request["trade_status"];
			string str = ApplicationSettings.Get("key_41");
			SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>();
			sortedDictionary.Add("merchant_code", value);
			sortedDictionary.Add("notify_type", value2);
			sortedDictionary.Add("order_no", text2);
			sortedDictionary.Add("order_amount", value3);
			sortedDictionary.Add("order_time", value4);
			sortedDictionary.Add("return_params", value5);
			sortedDictionary.Add("trade_no", value6);
			sortedDictionary.Add("trade_time", value7);
			sortedDictionary.Add("trade_status", text3);
			string text4 = "";
			foreach (System.Collections.Generic.KeyValuePair<string, string> current in sortedDictionary)
			{
				if (current.Value != "")
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
			}
			string text6 = text4 + "key=" + str;
			text4 = Jiami.MD5(text6, "UTF-8");
			if (!(text4 == text))
			{
				Log.Write(string.Concat(new string[]
				{
					"签名错误—加密前：",
					text6,
					"—加密后：",
					text4,
					"—sign：",
					text
				}));
				base.Response.Write("不合法数据");
			}
			else
			{
				if (!("success" == text3))
				{
					Log.Write("支付失败");
					base.Response.Write("支付失败");
				}
				else
				{
					ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
					shareDetialInfo.OrderID = text2;
					shareDetialInfo.IPAddress = Utility.UserIP;
					shareDetialInfo.PayAmount = System.Convert.ToDecimal(value3);
					Message message = FacadeManage.aideTreasureFacade.FilliedOnline(shareDetialInfo, 0);
					if (message.Success)
					{
						Log.Write("充值成功");
						base.Response.Write("success");
					}
					else
					{
						Log.Write(message.Content);
					}
				}
			}
		}
	}
}
