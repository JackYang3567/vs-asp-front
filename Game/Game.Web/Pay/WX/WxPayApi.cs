using System;
namespace Game.Web.Pay.WX
{
	public class WxPayApi
	{
		public static WxPayData Micropay(WxPayData inputObj)
		{
			string text = "https://api.mch.weixin.qq.com/pay/micropay";
			if (!inputObj.IsSet("body"))
			{
				throw new WxPayException("提交被扫支付API接口中，缺少必填参数body！");
			}
			if (!inputObj.IsSet("out_trade_no"))
			{
				throw new WxPayException("提交被扫支付API接口中，缺少必填参数out_trade_no！");
			}
			if (!inputObj.IsSet("total_fee"))
			{
				throw new WxPayException("提交被扫支付API接口中，缺少必填参数total_fee！");
			}
			if (!inputObj.IsSet("auth_code"))
			{
				throw new WxPayException("提交被扫支付API接口中，缺少必填参数auth_code！");
			}
			inputObj.SetValue("spbill_create_ip", "");
			inputObj.SetValue("appid", WxPayConfig.APPID);
			inputObj.SetValue("mch_id", WxPayConfig.MCHID);
			inputObj.SetValue("nonce_str", System.Guid.NewGuid().ToString().Replace("-", ""));
			inputObj.SetValue("sign", inputObj.MakeSign());
			string text2 = inputObj.ToXml();
			System.DateTime now = System.DateTime.Now;
			Log.Debug("WxPayApi", "MicroPay request : " + text2);
			string text3 = HttpService.Post(text2, text, false, 10);
			Log.Debug("WxPayApi", "MicroPay response : " + text3);
			System.DateTime now2 = System.DateTime.Now;
			int timeCost = (int)(now2 - now).TotalMilliseconds;
			WxPayData wxPayData = new WxPayData();
			wxPayData.FromXml(text3);
			WxPayApi.ReportCostTime(text, timeCost, wxPayData);
			return wxPayData;
		}
		public static WxPayData OrderQuery(WxPayData inputObj)
		{
			string text = "https://api.mch.weixin.qq.com/pay/orderquery";
			if (!inputObj.IsSet("out_trade_no") && !inputObj.IsSet("transaction_id"))
			{
				throw new WxPayException("订单查询接口中，out_trade_no、transaction_id至少填一个！");
			}
			inputObj.SetValue("appid", WxPayConfig.APPID);
			inputObj.SetValue("mch_id", WxPayConfig.MCHID);
			inputObj.SetValue("nonce_str", WxPayApi.GenerateNonceStr());
			inputObj.SetValue("sign", inputObj.MakeSign());
			string text2 = inputObj.ToXml();
			System.DateTime now = System.DateTime.Now;
			Log.Debug("WxPayApi", "OrderQuery request : " + text2);
			string text3 = HttpService.Post(text2, text, false, 6);
			Log.Debug("WxPayApi", "OrderQuery response : " + text3);
			System.DateTime now2 = System.DateTime.Now;
			int timeCost = (int)(now2 - now).TotalMilliseconds;
			WxPayData wxPayData = new WxPayData();
			wxPayData.FromXml(text3);
			WxPayApi.ReportCostTime(text, timeCost, wxPayData);
			return wxPayData;
		}
		public static WxPayData Reverse(WxPayData inputObj)
		{
			string text = "https://api.mch.weixin.qq.com/secapi/pay/reverse";
			if (!inputObj.IsSet("out_trade_no") && !inputObj.IsSet("transaction_id"))
			{
				throw new WxPayException("撤销订单API接口中，参数out_trade_no和transaction_id必须填写一个！");
			}
			inputObj.SetValue("appid", WxPayConfig.APPID);
			inputObj.SetValue("mch_id", WxPayConfig.MCHID);
			inputObj.SetValue("nonce_str", WxPayApi.GenerateNonceStr());
			inputObj.SetValue("sign", inputObj.MakeSign());
			string text2 = inputObj.ToXml();
			System.DateTime now = System.DateTime.Now;
			Log.Debug("WxPayApi", "Reverse request : " + text2);
			string text3 = HttpService.Post(text2, text, true, 6);
			Log.Debug("WxPayApi", "Reverse response : " + text3);
			System.DateTime now2 = System.DateTime.Now;
			int timeCost = (int)(now2 - now).TotalMilliseconds;
			WxPayData wxPayData = new WxPayData();
			wxPayData.FromXml(text3);
			WxPayApi.ReportCostTime(text, timeCost, wxPayData);
			return wxPayData;
		}
		public static WxPayData Refund(WxPayData inputObj)
		{
			string text = "https://api.mch.weixin.qq.com/secapi/pay/refund";
			if (!inputObj.IsSet("out_trade_no") && !inputObj.IsSet("transaction_id"))
			{
				throw new WxPayException("退款申请接口中，out_trade_no、transaction_id至少填一个！");
			}
			if (!inputObj.IsSet("out_refund_no"))
			{
				throw new WxPayException("退款申请接口中，缺少必填参数out_refund_no！");
			}
			if (!inputObj.IsSet("total_fee"))
			{
				throw new WxPayException("退款申请接口中，缺少必填参数total_fee！");
			}
			if (!inputObj.IsSet("refund_fee"))
			{
				throw new WxPayException("退款申请接口中，缺少必填参数refund_fee！");
			}
			if (!inputObj.IsSet("op_user_id"))
			{
				throw new WxPayException("退款申请接口中，缺少必填参数op_user_id！");
			}
			inputObj.SetValue("appid", WxPayConfig.APPID);
			inputObj.SetValue("mch_id", WxPayConfig.MCHID);
			inputObj.SetValue("nonce_str", System.Guid.NewGuid().ToString().Replace("-", ""));
			inputObj.SetValue("sign", inputObj.MakeSign());
			string text2 = inputObj.ToXml();
			System.DateTime now = System.DateTime.Now;
			Log.Debug("WxPayApi", "Refund request : " + text2);
			string text3 = HttpService.Post(text2, text, true, 6);
			Log.Debug("WxPayApi", "Refund response : " + text3);
			System.DateTime now2 = System.DateTime.Now;
			int timeCost = (int)(now2 - now).TotalMilliseconds;
			WxPayData wxPayData = new WxPayData();
			wxPayData.FromXml(text3);
			WxPayApi.ReportCostTime(text, timeCost, wxPayData);
			return wxPayData;
		}
		public static WxPayData RefundQuery(WxPayData inputObj)
		{
			string text = "https://api.mch.weixin.qq.com/pay/refundquery";
			if (!inputObj.IsSet("out_refund_no") && !inputObj.IsSet("out_trade_no") && !inputObj.IsSet("transaction_id") && !inputObj.IsSet("refund_id"))
			{
				throw new WxPayException("退款查询接口中，out_refund_no、out_trade_no、transaction_id、refund_id四个参数必填一个！");
			}
			inputObj.SetValue("appid", WxPayConfig.APPID);
			inputObj.SetValue("mch_id", WxPayConfig.MCHID);
			inputObj.SetValue("nonce_str", WxPayApi.GenerateNonceStr());
			inputObj.SetValue("sign", inputObj.MakeSign());
			string text2 = inputObj.ToXml();
			System.DateTime now = System.DateTime.Now;
			Log.Debug("WxPayApi", "RefundQuery request : " + text2);
			string text3 = HttpService.Post(text2, text, false, 6);
			Log.Debug("WxPayApi", "RefundQuery response : " + text3);
			System.DateTime now2 = System.DateTime.Now;
			int timeCost = (int)(now2 - now).TotalMilliseconds;
			WxPayData wxPayData = new WxPayData();
			wxPayData.FromXml(text3);
			WxPayApi.ReportCostTime(text, timeCost, wxPayData);
			return wxPayData;
		}
		public static WxPayData DownloadBill(WxPayData inputObj)
		{
			string url = "https://api.mch.weixin.qq.com/pay/downloadbill";
			if (!inputObj.IsSet("bill_date"))
			{
				throw new WxPayException("对账单接口中，缺少必填参数bill_date！");
			}
			inputObj.SetValue("appid", WxPayConfig.APPID);
			inputObj.SetValue("mch_id", WxPayConfig.MCHID);
			inputObj.SetValue("nonce_str", WxPayApi.GenerateNonceStr());
			inputObj.SetValue("sign", inputObj.MakeSign());
			string text = inputObj.ToXml();
			Log.Debug("WxPayApi", "DownloadBill request : " + text);
			string text2 = HttpService.Post(text, url, false, 6);
			Log.Debug("WxPayApi", "DownloadBill result : " + text2);
			WxPayData wxPayData = new WxPayData();
			if (text2.Substring(0, 5) == "<xml>")
			{
				wxPayData.FromXml(text2);
			}
			else
			{
				wxPayData.SetValue("result", text2);
			}
			return wxPayData;
		}
		public static WxPayData ShortUrl(WxPayData inputObj)
		{
			string text = "https://api.mch.weixin.qq.com/tools/shorturl";
			if (!inputObj.IsSet("long_url"))
			{
				throw new WxPayException("需要转换的URL，签名用原串，传输需URL encode！");
			}
			inputObj.SetValue("appid", WxPayConfig.APPID);
			inputObj.SetValue("mch_id", WxPayConfig.MCHID);
			inputObj.SetValue("nonce_str", WxPayApi.GenerateNonceStr());
			inputObj.SetValue("sign", inputObj.MakeSign());
			string text2 = inputObj.ToXml();
			System.DateTime now = System.DateTime.Now;
			Log.Debug("WxPayApi", "ShortUrl request : " + text2);
			string text3 = HttpService.Post(text2, text, false, 6);
			Log.Debug("WxPayApi", "ShortUrl response : " + text3);
			System.DateTime now2 = System.DateTime.Now;
			int timeCost = (int)(now2 - now).TotalMilliseconds;
			WxPayData wxPayData = new WxPayData();
			wxPayData.FromXml(text3);
			WxPayApi.ReportCostTime(text, timeCost, wxPayData);
			return wxPayData;
		}
		public static WxPayData UnifiedOrder(WxPayData inputObj)
		{
			string text = "https://api.mch.weixin.qq.com/pay/unifiedorder";
			if (!inputObj.IsSet("out_trade_no"))
			{
				throw new WxPayException("缺少统一支付接口必填参数out_trade_no！");
			}
			if (!inputObj.IsSet("body"))
			{
				throw new WxPayException("缺少统一支付接口必填参数body！");
			}
			if (!inputObj.IsSet("total_fee"))
			{
				throw new WxPayException("缺少统一支付接口必填参数total_fee！");
			}
			if (!inputObj.IsSet("trade_type"))
			{
				throw new WxPayException("缺少统一支付接口必填参数trade_type！");
			}
			if (inputObj.GetValue("trade_type").ToString() == "JSAPI" && !inputObj.IsSet("openid"))
			{
				throw new WxPayException("统一支付接口中，缺少必填参数openid！trade_type为JSAPI时，openid为必填参数！");
			}
			if (inputObj.GetValue("trade_type").ToString() == "NATIVE" && !inputObj.IsSet("product_id"))
			{
				throw new WxPayException("统一支付接口中，缺少必填参数product_id！trade_type为JSAPI时，product_id为必填参数！");
			}
			if (!inputObj.IsSet("notify_url"))
			{
				inputObj.SetValue("notify_url", WxPayConfig.NOTIFY_URL);
			}
			inputObj.SetValue("appid", WxPayConfig.APPID);
			inputObj.SetValue("mch_id", WxPayConfig.MCHID);
			inputObj.SetValue("spbill_create_ip", "");
			inputObj.SetValue("nonce_str", WxPayApi.GenerateNonceStr());
			inputObj.SetValue("sign", inputObj.MakeSign());
			string text2 = inputObj.ToXml();
			System.DateTime now = System.DateTime.Now;
			Log.Debug("WxPayApi", "UnfiedOrder request : " + text2);
			string text3 = HttpService.Post(text2, text, false, 6);
			Log.Debug("WxPayApi", "UnfiedOrder response : " + text3);
			System.DateTime now2 = System.DateTime.Now;
			int timeCost = (int)(now2 - now).TotalMilliseconds;
			WxPayData wxPayData = new WxPayData();
			wxPayData.FromXml(text3);
			WxPayApi.ReportCostTime(text, timeCost, wxPayData);
			return wxPayData;
		}
		public static WxPayData CloseOrder(WxPayData inputObj)
		{
			string text = "https://api.mch.weixin.qq.com/pay/closeorder";
			if (!inputObj.IsSet("out_trade_no"))
			{
				throw new WxPayException("关闭订单接口中，out_trade_no必填！");
			}
			inputObj.SetValue("appid", WxPayConfig.APPID);
			inputObj.SetValue("mch_id", WxPayConfig.MCHID);
			inputObj.SetValue("nonce_str", WxPayApi.GenerateNonceStr());
			inputObj.SetValue("sign", inputObj.MakeSign());
			string xml = inputObj.ToXml();
			System.DateTime now = System.DateTime.Now;
			string xml2 = HttpService.Post(xml, text, false, 6);
			System.DateTime now2 = System.DateTime.Now;
			int timeCost = (int)(now2 - now).TotalMilliseconds;
			WxPayData wxPayData = new WxPayData();
			wxPayData.FromXml(xml2);
			WxPayApi.ReportCostTime(text, timeCost, wxPayData);
			return wxPayData;
		}
		private static void ReportCostTime(string interface_url, int timeCost, WxPayData inputObj)
		{
			if (!inputObj.IsSet("return_code") || !(inputObj.GetValue("return_code").ToString() == "SUCCESS") || !inputObj.IsSet("result_code") || !(inputObj.GetValue("result_code").ToString() == "SUCCESS"))
			{
				WxPayData wxPayData = new WxPayData();
				wxPayData.SetValue("interface_url", interface_url);
				wxPayData.SetValue("execute_time_", timeCost);
				if (inputObj.IsSet("return_code"))
				{
					wxPayData.SetValue("return_code", inputObj.GetValue("return_code"));
				}
				if (inputObj.IsSet("return_msg"))
				{
					wxPayData.SetValue("return_msg", inputObj.GetValue("return_msg"));
				}
				if (inputObj.IsSet("result_code"))
				{
					wxPayData.SetValue("result_code", inputObj.GetValue("result_code"));
				}
				if (inputObj.IsSet("err_code"))
				{
					wxPayData.SetValue("err_code", inputObj.GetValue("err_code"));
				}
				if (inputObj.IsSet("err_code_des"))
				{
					wxPayData.SetValue("err_code_des", inputObj.GetValue("err_code_des"));
				}
				if (inputObj.IsSet("out_trade_no"))
				{
					wxPayData.SetValue("out_trade_no", inputObj.GetValue("out_trade_no"));
				}
				if (inputObj.IsSet("device_info"))
				{
					wxPayData.SetValue("device_info", inputObj.GetValue("device_info"));
				}
				try
				{
					WxPayApi.Report(wxPayData);
				}
				catch (WxPayException)
				{
				}
			}
		}
		public static WxPayData Report(WxPayData inputObj)
		{
			string url = "https://api.mch.weixin.qq.com/payitil/report";
			if (!inputObj.IsSet("interface_url"))
			{
				throw new WxPayException("接口URL，缺少必填参数interface_url！");
			}
			if (!inputObj.IsSet("return_code"))
			{
				throw new WxPayException("返回状态码，缺少必填参数return_code！");
			}
			if (!inputObj.IsSet("result_code"))
			{
				throw new WxPayException("业务结果，缺少必填参数result_code！");
			}
			if (!inputObj.IsSet("user_ip"))
			{
				throw new WxPayException("访问接口IP，缺少必填参数user_ip！");
			}
			if (!inputObj.IsSet("execute_time_"))
			{
				throw new WxPayException("接口耗时，缺少必填参数execute_time_！");
			}
			inputObj.SetValue("appid", WxPayConfig.APPID);
			inputObj.SetValue("mch_id", WxPayConfig.MCHID);
			inputObj.SetValue("user_ip", "");
			inputObj.SetValue("time", System.DateTime.Now.ToString("yyyyMMddHHmmss"));
			inputObj.SetValue("nonce_str", WxPayApi.GenerateNonceStr());
			inputObj.SetValue("sign", inputObj.MakeSign());
			string text = inputObj.ToXml();
			Log.Info("WxPayApi", "Report request : " + text);
			string text2 = HttpService.Post(text, url, false, 1);
			Log.Info("WxPayApi", "Report response : " + text2);
			WxPayData wxPayData = new WxPayData();
			wxPayData.FromXml(text2);
			return wxPayData;
		}
		public static string GenerateOutTradeNo()
		{
			System.Random random = new System.Random();
			return string.Format("{0}{1}{2}", WxPayConfig.MCHID, System.DateTime.Now.ToString("yyyyMMddHHmmss"), random.Next(999));
		}
		public static string GenerateTimeStamp()
		{
			return System.Convert.ToInt64((System.DateTime.UtcNow - new System.DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds).ToString();
		}
		public static string GenerateNonceStr()
		{
			return System.Guid.NewGuid().ToString().Replace("-", "");
		}
	}
}
