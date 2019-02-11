using Game.Entity.Treasure;
using Game.Facade;
using Game.Utils;
using System;
using System.Web.UI;
namespace Game.Web.Pay.WX
{
	public class ResultNotify : Notify
	{
		public ResultNotify(System.Web.UI.Page page) : base(page)
		{
		}
		public override void ProcessNotify()
		{
			Log.Info(base.GetType().ToString(), "AAAAAAAAAAAAAAAAAAAAAAA");
			WxPayData notifyData = base.GetNotifyData();
			if (!notifyData.IsSet("transaction_id"))
			{
				WxPayData wxPayData = new WxPayData();
				wxPayData.SetValue("return_code", "FAIL");
				wxPayData.SetValue("return_msg", "支付结果中微信订单号不存在");
				Log.Error(base.GetType().ToString(), "The Pay result is error : " + wxPayData.ToXml());
				base.page.Response.Write(wxPayData.ToXml());
				base.page.Response.End();
			}
			string transaction_id = notifyData.GetValue("transaction_id").ToString();
			if (!this.QueryOrder(transaction_id))
			{
				WxPayData wxPayData2 = new WxPayData();
				wxPayData2.SetValue("return_code", "FAIL");
				wxPayData2.SetValue("return_msg", "订单查询失败");
				Log.Error(base.GetType().ToString(), "Order query failure : " + wxPayData2.ToXml());
				base.page.Response.Write(wxPayData2.ToXml());
				base.page.Response.End();
			}
			else
			{
				decimal payAmount = System.Convert.ToDecimal(notifyData.GetValue("total_fee")) / 100m;
				ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
				shareDetialInfo.OrderID = notifyData.GetValue("out_trade_no").ToString();
				shareDetialInfo.IPAddress = Utility.UserIP;
				shareDetialInfo.PayAmount = payAmount;
				FacadeManage.aideTreasureFacade.FilliedMobile(shareDetialInfo);
				WxPayData wxPayData3 = new WxPayData();
				wxPayData3.SetValue("return_code", "SUCCESS");
				wxPayData3.SetValue("return_msg", "OK");
				Log.Info(base.GetType().ToString(), "order query success : " + wxPayData3.ToXml());
				base.page.Response.Write(wxPayData3.ToXml());
				base.page.Response.End();
			}
		}
		private bool QueryOrder(string transaction_id)
		{
			WxPayData wxPayData = new WxPayData();
			wxPayData.SetValue("transaction_id", transaction_id);
			WxPayData wxPayData2 = WxPayApi.OrderQuery(wxPayData);
			return wxPayData2.GetValue("return_code").ToString() == "SUCCESS" && wxPayData2.GetValue("result_code").ToString() == "SUCCESS";
		}
	}
}
