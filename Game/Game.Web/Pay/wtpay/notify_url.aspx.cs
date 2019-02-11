using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Game.Web.Pay.wtpay
{
    public partial class notify_url : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlForm form1;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			string text = base.Request["customerid"];
			string text2 = base.Request["sdorderno"];
			string text3 = base.Request["total_fee"];
			string text4 = base.Request["status"];
			string text5 = base.Request["paytype"];
			string text6 = base.Request["sdpayno"];
			string arg_78_0 = base.Request["remark"];
			string text7 = base.Request["sign"];
			if (!(text4 == "1"))
			{
				Log.Write("支付系统错误 opstate:" + text4 + " orderid:" + text2);
				base.Response.Write("支付系统错误");
			}
			else
			{
				string text8 = ApplicationSettings.Get("key_wt");
				string text9 = string.Format("customerid={0}&status={1}&sdpayno={2}&sdorderno={3}&total_fee={4}&paytype={5}&{6}", new object[]
				{
					text,
					text4,
					text6,
					text2,
					text3,
					text5,
					text8
				});
				string text10 = TextEncrypt.EncryptPassword(text9);
				if (!(text7.ToLower() == text10.ToLower()))
				{
					Log.Write(string.Concat(new string[]
					{
						"签名错误，signSource=",
						text9,
						" mySign=",
						text10,
						" Sign=",
						text7
					}));
					base.Response.Write("签名错误");
				}
				else
				{
					ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
					shareDetialInfo.OrderID = text2;
					shareDetialInfo.IPAddress = Utility.UserIP;
					shareDetialInfo.PayAmount = System.Convert.ToDecimal(text3);
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
