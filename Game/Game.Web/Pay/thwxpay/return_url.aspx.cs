using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Game.Web.Pay.thwxpay
{
    public partial class return_url : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label label_result;
		protected System.Web.UI.WebControls.Label label_order_no;
		protected System.Web.UI.WebControls.Label label_order_amount;
		protected System.Web.UI.WebControls.Label label_order_time;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			string value = base.Request["merchant_code"];
			string value2 = base.Request["notify_type"];
			string text = base.Request["sign"];
			string text2 = base.Request["order_no"];
			string text3 = base.Request["order_amount"];
			string text4 = base.Request["order_time"];
			string value3 = base.Request["return_params"];
			string value4 = base.Request["trade_no"];
			string value5 = base.Request["trade_time"];
			string text5 = base.Request["trade_status"];
			string str = ApplicationSettings.Get("key_41");
			SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>();
			sortedDictionary.Add("merchant_code", value);
			sortedDictionary.Add("notify_type", value2);
			sortedDictionary.Add("order_no", text2);
			sortedDictionary.Add("order_amount", text3);
			sortedDictionary.Add("order_time", text4);
			sortedDictionary.Add("return_params", value3);
			sortedDictionary.Add("trade_no", value4);
			sortedDictionary.Add("trade_time", value5);
			sortedDictionary.Add("trade_status", text5);
			string text6 = "";
			foreach (System.Collections.Generic.KeyValuePair<string, string> current in sortedDictionary)
			{
				string text7 = text6;
				text6 = string.Concat(new string[]
				{
					text7,
					current.Key,
					"=",
					current.Value,
					"&"
				});
			}
			string text8 = text6 + "key=" + str;
			text6 = Jiami.MD5(text8, "UTF-8");
			string text9;
			if (text6 == text)
			{
				if ("success" == text5)
				{
					ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
					shareDetialInfo.OrderID = text2;
					shareDetialInfo.IPAddress = Utility.UserIP;
					shareDetialInfo.PayAmount = System.Convert.ToDecimal(text3);
					Message message = FacadeManage.aideTreasureFacade.FilliedOnline(shareDetialInfo, 0);
					if (message.Success)
					{
						Log.Write("充值成功");
						text9 = "充值成功";
					}
					else
					{
						Log.Write(message.Content);
						text9 = message.Content;
					}
				}
				else
				{
					Log.Write("支付失败");
					text9 = "支付失败";
				}
			}
			else
			{
				Log.Write(string.Concat(new string[]
				{
					"签名错误—加密前：",
					text8,
					"—加密后：",
					text6,
					"—sign：",
					text
				}));
				text9 = "签名错误";
			}
			this.label_result.Text = text9;
			this.label_order_no.Text = text2;
			this.label_order_amount.Text = text3;
			this.label_order_time.Text = text4;
		}
	}
}
