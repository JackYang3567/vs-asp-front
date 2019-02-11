using System;
using System.Collections.Generic;
namespace Game.Web.Pay.WX
{
	public class XZAppPay
	{
		private System.Collections.Generic.Dictionary<string, string> parameters;
		public XZAppPay()
		{
			this.parameters = new System.Collections.Generic.Dictionary<string, string>();
		}
		public void SetParameter(string key, string value_ren)
		{
			this.parameters.Add(key, value_ren);
		}
		public string GetParameter(string key)
		{
			return this.parameters[key];
		}
		public string GetPrepayIDSign()
		{
			WxPayData wxPayData = new WxPayData();
			wxPayData.SetValue("body", this.parameters["body"]);
			wxPayData.SetValue("attach", this.parameters["body"]);
			wxPayData.SetValue("out_trade_no", this.parameters["out_trade_no"]);
			wxPayData.SetValue("total_fee", this.parameters["total_fee"]);
			wxPayData.SetValue("time_start", System.DateTime.Now.ToString("yyyyMMddHHmmss"));
			wxPayData.SetValue("time_expire", System.DateTime.Now.AddMinutes(10.0).ToString("yyyyMMddHHmmss"));
			wxPayData.SetValue("trade_type", "APP");
			WxPayData wxPayData2 = WxPayApi.UnifiedOrder(wxPayData);
			string result;
			if (!wxPayData2.IsSet("prepay_id"))
			{
				Log.Error(base.GetType().ToString(), "The prepay_id is null");
				result = "";
			}
			else
			{
				string text = wxPayData2.GetValue("prepay_id").ToString();
				Log.Info(base.GetType().ToString(), "Get prepay_id : " + text);
				result = this.CreateAppPayPackage(text);
			}
			return result;
		}
		public string CreateAppPayPackage(string prepayid)
		{
			WxPayData wxPayData = new WxPayData();
			wxPayData.SetValue("appid", WxPayConfig.APPID);
			wxPayData.SetValue("noncestr", System.Guid.NewGuid().ToString().Replace("-", ""));
			wxPayData.SetValue("package", "Sign=WXPay");
			wxPayData.SetValue("partnerid", WxPayConfig.MCHID);
			wxPayData.SetValue("prepayid", prepayid);
			wxPayData.SetValue("timestamp", ((System.DateTime.Now.ToUniversalTime().Ticks - 621355968000000000L) / 10000000L).ToString());
			wxPayData.SetValue("sign", wxPayData.MakeSign());
			return wxPayData.ToJson();
		}
		private string ToUrlParams(SortedDictionary<string, object> map)
		{
			string text = "";
			foreach (System.Collections.Generic.KeyValuePair<string, object> current in map)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					current.Key,
					"=",
					current.Value,
					"&"
				});
			}
			text = text.Trim(new char[]
			{
				'&'
			});
			return text;
		}
	}
}
