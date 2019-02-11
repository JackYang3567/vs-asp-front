using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Web.UI;
using testOrder;
namespace Game.Web.Pay.zhifubank
{
    public partial class notify_url : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			string str = base.Request.Form["merchant_code"].ToString().Trim();
			string text = base.Request.Form["notify_type"].ToString().Trim();
			string text2 = base.Request.Form["notify_id"].ToString().Trim();
			base.Request.Form["interface_version"].ToString().Trim();
			string text3 = base.Request.Form["sign_type"].ToString().Trim();
			string signedData = base.Request.Form["sign"].ToString().Trim();
			string text4 = base.Request.Form["order_no"].ToString().Trim();
			string str2 = base.Request.Form["order_time"].ToString().Trim();
			string text5 = base.Request.Form["order_amount"].ToString().Trim();
			string text6 = base.Request.Form["extra_return_param"];
			string str3 = base.Request.Form["trade_no"].ToString().Trim();
			string text7 = base.Request.Form["trade_time"].ToString().Trim();
			string str4 = base.Request.Form["trade_status"].ToString().Trim();
			string text8 = base.Request.Form["bank_seq_no"];
			string text9 = "";
			if (text8 != null && text8 != "")
			{
				text9 = text9 + "bank_seq_no=" + text8.ToString().Trim() + "&";
			}
			if (text6 != null && text6 != "")
			{
				text9 = text9 + "extra_return_param=" + text6 + "&";
			}
			text9 += "interface_version=V3.0&";
			text9 = text9 + "merchant_code=" + str + "&";
			if (text2 != null && text2 != "")
			{
				text9 = string.Concat(new string[]
				{
					text9,
					"notify_id=",
					text2,
					"&notify_type=",
					text,
					"&"
				});
			}
			text9 = text9 + "order_amount=" + text5 + "&";
			text9 = text9 + "order_no=" + text4 + "&";
			text9 = text9 + "order_time=" + str2 + "&";
			text9 = text9 + "trade_no=" + str3 + "&";
			text9 = text9 + "trade_status=" + str4 + "&";
			if (text7 != null && text7 != "")
			{
				text9 = text9 + "trade_time=" + text7;
			}
			if (!(text3 == "RSA-S"))
			{
				Log.Write(text3);
			}
			else
			{
				string publicKey = ApplicationSettings.Get("dinpayPubKey_zhifu");
				publicKey = HttpHelp.RSAPublicKeyJava2DotNet(publicKey);
				if (!HttpHelp.ValidateRsaSign(text9, publicKey, signedData))
				{
					Log.Write("验签失败");
					base.Response.Write("验签失败");
				}
				else
				{
					ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
					shareDetialInfo.OrderID = text4;
					shareDetialInfo.IPAddress = Utility.UserIP;
					shareDetialInfo.PayAmount = System.Convert.ToDecimal(text5);
					Message message = FacadeManage.aideTreasureFacade.FilliedOnline(shareDetialInfo, 0);
					if (message.Success)
					{
						Log.Write("充值成功");
						base.Response.Write("SUCCESS");
					}
					else
					{
						Log.Write(message.Content);
						base.Response.Write(message.Content);
					}
				}
			}
		}
	}
}
