using Game.Entity.Treasure;
using Game.Facade;
using Game.Utils;
using System;
using System.Web.UI;
namespace Game.Web.UserService.JFT
{
	public partial class PublicAdvice : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			string text = base.Request["p1_usercode"];
			string text2 = base.Request["p2_order"];
			string text3 = base.Request["p3_money"];
			string text4 = base.Request["p4_status"];
			string text5 = base.Request["p5_jtpayorder"];
			string text6 = base.Request["p6_paymethod"];
			string text7 = base.Request["p7_paychannelnum"];
			string text8 = base.Request["p8_charset"];
			string text9 = base.Request["p9_signtype"];
			string text10 = base.Request["p10_sign"];
			string text11 = ApplicationSettings.Get("jftBankKey");
			if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(text2) || string.IsNullOrEmpty(text3) || string.IsNullOrEmpty(text4) || string.IsNullOrEmpty(text10))
			{
				base.Response.Write("success");
			}
			else
			{
				string s = string.Format("{0}&{1}&{2}&{3}&{4}&{5}&{6}&{7}&{8}&{9}", new object[]
				{
					text,
					text2,
					text3,
					text4,
					text5,
					text6,
					text7,
					text8,
					text9,
					text11
				});
				string b = Utility.MD5(s).ToUpper();
				if (text10 == b && text4 == "1")
				{
					ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
					shareDetialInfo.OrderID = text2;
					shareDetialInfo.IPAddress = Utility.UserIP;
					shareDetialInfo.PayAmount = System.Convert.ToDecimal(text3);
					FacadeManage.aideTreasureFacade.FilliedOnline(shareDetialInfo, 0);
				}
				base.Response.Write("success");
			}
		}
	}
}
