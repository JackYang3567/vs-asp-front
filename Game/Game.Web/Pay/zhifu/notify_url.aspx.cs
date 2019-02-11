using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Web.UI;
using testOrder;
namespace Game.Web.Pay.zhifu
{
    public partial class notify_url : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			string text = base.Request.Form["merchant_code"].ToString().Trim();
			string text2 = base.Request.Form["notify_id"].ToString().Trim();
			string text3 = base.Request.Form["notify_type"].ToString().Trim();
			string text4 = base.Request.Form["interface_version"].ToString().Trim();
			string text5 = base.Request.Form["sign_type"].ToString().Trim();
			string signedData = base.Request.Form["sign"].ToString().Trim();
			string text6 = base.Request.Form["order_no"].ToString().Trim();
			string text7 = base.Request.Form["order_time"].ToString().Trim();
			string text8 = base.Request.Form["order_amount"].ToString().Trim();
			string text9 = "";
			string text10 = base.Request.Form["trade_no"].ToString().Trim();
			string text11 = base.Request.Form["trade_time"].ToString().Trim();
			string text12 = base.Request["bank_seq_no"].ToString();
			string text13 = base.Request.Form["trade_status"].ToString().Trim();
			string text14 = "";
			if (text12 != "")
			{
				text14 = text14 + "bank_seq_no=" + text12 + "&";
			}
			if (text9 != "")
			{
				text14 = text14 + "extra_return_param=" + text9 + "&";
			}
			if (text4 != "")
			{
				text14 = text14 + "interface_version=" + text4 + "&";
			}
			if (text != "")
			{
				text14 = text14 + "merchant_code=" + text + "&";
			}
			if (text2 != "")
			{
				text14 = text14 + "notify_id=" + text2 + "&";
			}
			if (text3 != "")
			{
				text14 = text14 + "notify_type=" + text3 + "&";
			}
			if (text8 != "")
			{
				text14 = text14 + "order_amount=" + text8 + "&";
			}
			if (text6 != "")
			{
				text14 = text14 + "order_no=" + text6 + "&";
			}
			if (text7 != "")
			{
				text14 = text14 + "order_time=" + text7 + "&";
			}
			if (text10 != "")
			{
				text14 = text14 + "trade_no=" + text10 + "&";
			}
			if (text13 != "")
			{
				text14 = text14 + "trade_status=" + text13 + "&";
			}
			if (text11 != "")
			{
				text14 = text14 + "trade_time=" + text11;
			}
			if (!(text5 == "RSA-S"))
			{
				Log.Write(text5);
			}
			else
			{
				string publicKey = ApplicationSettings.Get("pubKey_zhifu");
				publicKey = HttpHelp.RSAPublicKeyJava2DotNet(publicKey);
				if (!HttpHelp.ValidateRsaSign(text14, publicKey, signedData))
				{
					Log.Write("验签失败");
					base.Response.Write("验签失败");
				}
				else
				{
					ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
					shareDetialInfo.OrderID = text6;
					shareDetialInfo.IPAddress = Utility.UserIP;
					shareDetialInfo.PayAmount = System.Convert.ToDecimal(text8);
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
