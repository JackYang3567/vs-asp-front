using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Game.Web.Pay._168
{
	public partial class notify_url : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlForm form1;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			string text = base.Request["mchid"];
			string text2 = base.Request["out_trade_no"];
			string text3 = base.Request["fee"];
			string text4 = base.Request["sign"];
			string text5 = base.Request["result_code"];
			string arg_66_0 = base.Request["time_end"];
			if (!(text5 == "0"))
			{
				Log.Write("支付系统错误 opstate:" + text5 + " orderid:" + text2);
				base.Response.Write("支付系统错误");
			}
			else
			{
				string text6 = ApplicationSettings.Get("key_168");
				string text7 = string.Concat(new string[]
				{
					text,
					"&",
					text3,
					"&",
					text2,
					"&",
					text6
				});
				string text8 = TextEncrypt.EncryptPassword(text7);
				if (!(text4.ToLower() == text8.ToLower()))
				{
					Log.Write(string.Concat(new string[]
					{
						"签名错误，signSource=",
						text7,
						" mySign=",
						text8,
						" Sign=",
						text4
					}));
					base.Response.Write("签名错误");
				}
				else
				{
					ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
					shareDetialInfo.OrderID = text2;
					shareDetialInfo.IPAddress = Utility.UserIP;
					shareDetialInfo.PayAmount = System.Convert.ToDecimal(text3) / 100m;
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
