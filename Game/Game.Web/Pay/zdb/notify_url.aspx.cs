using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Web.UI;
using testOrder;
namespace Game.Web.Pay.zdb
{
    public partial class notify_url : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>();
			sortedDictionary["merchant_code"] = base.Request.Form["merchant_code"];
			sortedDictionary["notify_type"] = base.Request.Form["notify_type"];
			sortedDictionary["notify_id"] = base.Request.Form["notify_id"];
			sortedDictionary["interface_version"] = base.Request.Form["interface_version"];
			sortedDictionary["order_no"] = base.Request.Form["order_no"];
			sortedDictionary["order_time"] = base.Request.Form["order_time"];
			sortedDictionary["order_amount"] = base.Request.Form["order_amount"];
			sortedDictionary["extra_return_param"] = base.Request.Form["extra_return_param"];
			sortedDictionary["trade_no"] = base.Request.Form["trade_no"];
			sortedDictionary["trade_time"] = base.Request.Form["trade_time"];
			sortedDictionary["trade_status"] = base.Request.Form["trade_status"];
			sortedDictionary["bank_seq_no"] = base.Request["bank_seq_no"];
			string plainText = PayHelper.PrepareSign(sortedDictionary);
			sortedDictionary["sign_type"] = base.Request.Form["sign_type"];
			sortedDictionary["sign"] = base.Request.Form["sign"];
			if (!(sortedDictionary["sign_type"] == "RSA-S"))
			{
				Log.Write(JsonHelper.SerializeObject(sortedDictionary));
			}
			else
			{
				string publicKey = ApplicationSettings.Get("pubKey_zdb");
				publicKey = HttpHelp.RSAPublicKeyJava2DotNet(publicKey);
				if (!HttpHelp.ValidateRsaSign(plainText, publicKey, sortedDictionary["sign"]))
				{
					Log.Write("验签失败：" + JsonHelper.SerializeObject(sortedDictionary));
					base.Response.Write("验签失败");
				}
				else
				{
					ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
					shareDetialInfo.OrderID = sortedDictionary["order_no"];
					shareDetialInfo.IPAddress = Utility.UserIP;
					shareDetialInfo.PayAmount = System.Convert.ToDecimal(sortedDictionary["order_amount"]);
					Message message = FacadeManage.aideTreasureFacade.FilliedOnline(shareDetialInfo, 0);
					if (message.Success)
					{
						base.Response.Write("SUCCESS");
					}
					else
					{
						Log.Write(message.Content + "：" + JsonHelper.SerializeObject(sortedDictionary));
						base.Response.Write(message.Content);
					}
				}
			}
		}
	}
}
