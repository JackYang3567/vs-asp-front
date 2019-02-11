using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Web.UI;
namespace Game.Web.Pay.hfht
{
    public partial class notify_url : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
			dictionary["p1_MerId"] = base.Request["p1_MerId"];
			dictionary["r0_Cmd"] = base.Request["r0_Cmd"];
			dictionary["R1_Code"] = base.Request["R1_Code"];
			dictionary["R2_TrxId"] = base.Request["R2_TrxId"];
			dictionary["r3_Amt"] = base.Request["r3_Amt"];
			dictionary["r4_Cur"] = base.Request["r4_Cur"];
			dictionary["r5_Order"] = base.Request["r5_Order"];
			dictionary["r6_Type"] = base.Request["r6_Type"];
			string text = base.Request["hmac"];
			if (!(dictionary["R1_Code"] == "1"))
			{
				Log.Write("支付系统错误 R1_Code:" + dictionary["R1_Code"] + " orderid:" + dictionary["r5_Order"]);
				base.Response.Write("支付系统错误");
			}
			else
			{
				string signSource = PayHelper.GetSignSource(dictionary);
				string aKey = ApplicationSettings.Get("key_hfht");
				string text2 = Encrypt.HmacSign(signSource, aKey);
				if (!(text.ToLower() == text2.ToLower()))
				{
					Log.Write(string.Concat(new string[]
					{
						"签名错误，signSource=",
						signSource,
						" mySign=",
						text2,
						" Sign=",
						text
					}));
					base.Response.Write("签名错误");
				}
				else
				{
					ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
					shareDetialInfo.OrderID = dictionary["r5_Order"];
					shareDetialInfo.IPAddress = Utility.UserIP;
					shareDetialInfo.PayAmount = System.Convert.ToDecimal(dictionary["r3_Amt"]);
					Message message = FacadeManage.aideTreasureFacade.FilliedOnline(shareDetialInfo, 0);
					if (message.Success)
					{
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
