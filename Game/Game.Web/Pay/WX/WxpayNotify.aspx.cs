using Game.Entity.Treasure;
using Game.Facade;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Web.UI;
namespace Game.Web.Pay.WX
{
    public partial class WxpayNotify : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			string format = "<xml> <return_code><![CDATA[{0}]]></return_code> <return_msg><![CDATA[{1}]]></return_msg> </xml>";
			SortedDictionary<string, object> returnData = WeiXinHelper.GetReturnData();
			string a = returnData["sign"].ToString();
			if (!(returnData["return_code"].ToString() == "SUCCESS"))
			{
				base.Response.Write(string.Format(format, "FAIL", "微信交易失败！"));
			}
			else
			{
				string makeSign = WeiXinHelper.GetMakeSign(returnData);
				if (!(a == makeSign))
				{
					base.Response.Write(string.Format(format, "FAIL", "签名错误！"));
				}
				else
				{
					decimal payAmount = System.Convert.ToDecimal(returnData["total_fee"]) / 100m;
					if (returnData["result_code"].ToString() == "SUCCESS")
					{
						ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
						shareDetialInfo.OrderID = returnData["out_trade_no"].ToString();
						shareDetialInfo.IPAddress = Utility.UserIP;
						shareDetialInfo.PayAmount = payAmount;
						FacadeManage.aideTreasureFacade.FilliedOnline(shareDetialInfo, 0);
						base.Response.Write(string.Format(format, "SUCCESS", "支付成功！"));
					}
					else
					{
						base.Response.Write(string.Format(format, "FAIL", "微信交易失败！"));
					}
				}
			}
		}
	}
}
