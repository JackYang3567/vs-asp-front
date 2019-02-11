using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using testOrder;
namespace Game.Web.Pay.duodebao
{
	public  partial class notify_url : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlForm form1;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			string str = base.Request.Form["merchant_code"].ToString().Trim();
			string text = base.Request.Form["notify_type"].ToString().Trim();
			string text2 = base.Request.Form["notify_id"].ToString().Trim();
			string str2 = base.Request.Form["interface_version"].ToString().Trim();
			base.Request.Form["sign_type"].ToString().Trim();
			string signedData = base.Request.Form["sign"].ToString().Trim();
			string text3 = base.Request.Form["order_no"].ToString().Trim();
			string str3 = base.Request.Form["order_time"].ToString().Trim();
			string text4 = base.Request.Form["order_amount"].ToString().Trim();
			string text5 = base.Request.Form["extra_return_param"];
			string str4 = base.Request.Form["trade_no"].ToString().Trim();
			string text6 = base.Request.Form["trade_time"].ToString().Trim();
			string str5 = base.Request.Form["trade_status"].ToString().Trim();
			string text7 = base.Request.Form["bank_seq_no"];
			string str6 = base.Request.Form["orginal_money"];
			string text8 = "";
			if (text7 != null && text7 != "")
			{
				text8 = text8 + "bank_seq_no=" + text7.ToString().Trim() + "&";
			}
			if (text5 != null && text5 != "")
			{
				text8 = text8 + "extra_return_param=" + text5 + "&";
			}
			text8 = text8 + "interface_version=" + str2 + "&";
			text8 = text8 + "merchant_code=" + str + "&";
			if (text2 != null && text2 != "")
			{
				text8 = string.Concat(new string[]
				{
					text8,
					"notify_id=",
					text2,
					"&notify_type=",
					text,
					"&"
				});
			}
			text8 = text8 + "order_amount=" + text4 + "&";
			text8 = text8 + "order_no=" + text3 + "&";
			text8 = text8 + "order_time=" + str3 + "&";
			text8 = text8 + "orginal_money=" + str6 + "&";
			text8 = text8 + "trade_no=" + str4 + "&";
			text8 = text8 + "trade_status=" + str5 + "&";
			if (text6 != null && text6 != "")
			{
				text8 = text8 + "trade_time=" + text6;
			}
			string publicKey = ApplicationSettings.Get("pubKey_duodebao");
			publicKey = HttpHelp.RSAPublicKeyJava2DotNet(publicKey);
			if (!HttpHelp.ValidateRsaSign(text8, publicKey, signedData))
			{
				Log.Write("验签失败");
				base.Response.Write("验签失败");
			}
			else
			{
				ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
				shareDetialInfo.OrderID = text3;
				shareDetialInfo.IPAddress = Utility.UserIP;
				shareDetialInfo.PayAmount = System.Convert.ToDecimal(text4);
				Message message = FacadeManage.aideTreasureFacade.FilliedOnline(shareDetialInfo, 0);
				if (message.Success)
				{
					base.Response.Write("SUCCESS");
				}
				else
				{
					Log.Write(message.Content + "：" + text3);
					base.Response.Write(message.Content);
				}
			}
		}
	}
}
