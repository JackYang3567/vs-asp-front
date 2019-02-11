using Game.Entity.Treasure;
using Game.Facade;
using Game.Utils;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Game.Web.UserService.JFT
{
    public partial class CardReturn : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblAlertIcon;
		protected System.Web.UI.WebControls.Label lblAlertInfo;
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
			string a = base.Request["p10_sign"];
			string text10 = ApplicationSettings.Get("jftBankKey");
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
				text10
			});
			string b = Utility.MD5(s).ToUpper();
			if (a == b && text4 == "1")
			{
				ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
				shareDetialInfo.OrderID = text2;
				shareDetialInfo.IPAddress = Utility.UserIP;
				shareDetialInfo.PayAmount = System.Convert.ToDecimal(text3);
				FacadeManage.aideTreasureFacade.FilliedOnline(shareDetialInfo, 0);
			}
			if (text4 == "1")
			{
				this.lblAlertIcon.CssClass = "ui-result-pic-1";
				this.lblAlertInfo.CssClass = "ui-result-success";
				this.lblAlertInfo.Text = string.Format("恭喜您，充值成功！您的订单号为：{0}。", text2);
			}
			else
			{
				if (!string.IsNullOrEmpty(text2))
				{
					this.lblAlertIcon.CssClass = "ui-result-pic-2";
					this.lblAlertInfo.CssClass = "ui-result-fail";
					this.lblAlertInfo.Text = string.Format("充值失败。请确认卡号与密码是否输入正确！您的订单号为：{0}。", text2);
				}
				else
				{
					this.lblAlertIcon.CssClass = "ui-result-pic-2";
					this.lblAlertInfo.CssClass = "ui-result-fail";
					this.lblAlertInfo.Text = "提交完成。如游戏豆未到账，请确认卡号与密码是否输入正确！";
				}
			}
		}
	}
}
