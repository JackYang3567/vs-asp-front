using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace Game.Web.UserService
{
	public partial class PayCardFill : UCPageBase
	{
		protected System.Web.UI.HtmlControls.HtmlForm fmStep1;
		protected System.Web.UI.WebControls.TextBox txtAccounts;
		protected System.Web.UI.WebControls.TextBox txtAccounts2;
		protected System.Web.UI.WebControls.TextBox txtSerialID;
		protected System.Web.UI.WebControls.TextBox txtPassword;
		protected System.Web.UI.WebControls.Button btnPay;
		protected System.Web.UI.HtmlControls.HtmlForm fmStep2;
		protected System.Web.UI.WebControls.Label lblAlertIcon;
		protected System.Web.UI.WebControls.Label lblAlertInfo;
		protected System.Web.UI.HtmlControls.HtmlGenericControl pnlContinue;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.SwitchStep(1);
				if (Fetch.GetUserCookie() != null)
				{
					this.txtAccounts.Text = Fetch.GetUserCookie().Accounts;
					this.txtAccounts2.Text = Fetch.GetUserCookie().Accounts;
					this.txtAccounts.Focus();
				}
			}
		}
		protected override void AddHeaderTitle()
		{
			this.AddMetaTitle("实卡充值 - " + ApplicationSettings.Get("title"));
			this.AddMetaKeywords(ApplicationSettings.Get("keywords"));
			this.AddMetaDescription(ApplicationSettings.Get("description"));
		}
		protected void btnPay_Click(object sender, System.EventArgs e)
		{
			string text = CtrlHelper.GetText(this.txtAccounts);
			string text2 = CtrlHelper.GetText(this.txtAccounts2);
			string text3 = CtrlHelper.GetText(this.txtSerialID);
			string text4 = CtrlHelper.GetText(this.txtPassword);
			if (text == "")
			{
				this.RenderAlertInfo(true, "抱歉，请输入游戏帐号。", 2);
			}
			else
			{
				if (text2 != text)
				{
					this.RenderAlertInfo(true, "抱歉，两次输入的帐号不一致。", 2);
				}
				else
				{
					if (text3 == "")
					{
						this.RenderAlertInfo(true, "抱歉，请输入充值卡号。", 2);
					}
					else
					{
						if (text4 == "")
						{
							this.RenderAlertInfo(true, "抱歉，请输入卡号密码。", 2);
						}
						else
						{
							ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
							shareDetialInfo.SerialID = CtrlHelper.GetText(this.txtSerialID);
							if (this.userTicket == null)
							{
								shareDetialInfo.OperUserID = 0;
							}
							else
							{
								shareDetialInfo.OperUserID = this.userTicket.UserID;
							}
							shareDetialInfo.Accounts = text;
							shareDetialInfo.ShareID = 1;
							shareDetialInfo.IPAddress = Utility.UserIP;
							Message message = FacadeManage.aideTreasureFacade.FilledLivcard(shareDetialInfo, TextEncrypt.EncryptPassword(this.txtPassword.Text.Trim()));
							if (message.Success)
							{
								this.RenderAlertInfo(false, "实卡充值成功，如数量显示未及时刷新，请稍候重新查看。", 2);
							}
							else
							{
								this.RenderAlertInfo(true, message.Content, 2);
							}
						}
					}
				}
			}
		}
	}
}
