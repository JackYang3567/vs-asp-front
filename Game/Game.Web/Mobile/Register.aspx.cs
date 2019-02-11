using Game.Entity.Accounts;
using Game.Entity.NativeWeb;
using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using Game.Utils.Cache;
using System;
using System.Web.UI.WebControls;
namespace Game.Web.Mobile
{
    public partial class Register : UCPageBase
	{
		protected string accounts = "";
		protected string score = "0";
		protected string downLoadIosUrl = "";
		protected string downLoadAndroidUrl = "";
		protected string downLoadUrl = "";
		protected System.Web.UI.WebControls.Panel pnlStep1;
		protected System.Web.UI.WebControls.TextBox txtAccounts;
		protected System.Web.UI.WebControls.TextBox txtLogonPass;
		protected System.Web.UI.WebControls.TextBox txtLogonPass2;
		protected System.Web.UI.WebControls.TextBox txtCode;
		protected System.Web.UI.WebControls.TextBox txtSpreader;
		protected System.Web.UI.WebControls.Panel pnlStep2;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.SwitchStep(1);
				string authority = base.Request.Url.Authority;
				int userID = FacadeManage.aideAccountsFacade.GetAccountAgentByDomain(authority).UserID;
				string accountsByUserID = FacadeManage.aideAccountsFacade.GetAccountsByUserID(userID);
				if (!string.IsNullOrEmpty(accountsByUserID))
				{
					this.txtSpreader.Text = accountsByUserID;
					return;
				}
				string subDomain = GameRequest.GetSubDomain();
				if (!string.IsNullOrEmpty(subDomain) && subDomain != "www" && Game.Utils.Validate.IsNumeric(subDomain))
				{
					string accountsBySubDomain = FacadeManage.aideAccountsFacade.GetAccountsBySubDomain(subDomain);
					if (!string.IsNullOrEmpty(accountsBySubDomain))
					{
						this.txtSpreader.Text = accountsBySubDomain;
						return;
					}
				}
				if (base.IntParam != 0)
				{
					WHCache.Default.Save<CookiesCache>("SpreadID", base.IntParam);
				}
				object obj = WHCache.Default.Get<CookiesCache>("SpreadID");
				if (obj != null && Game.Utils.Validate.IsNumeric(obj))
				{
					this.txtSpreader.Text = base.GetAccountsByUserID(System.Convert.ToInt32(obj));
				}
			}
			if (base.IsPostBack)
			{
				this.RegisterAccounts();
			}
		}
		protected override void AddHeaderTitle()
		{
			this.AddMetaTitle("用户注册 - " + ApplicationSettings.Get("title"));
			this.AddMetaKeywords(ApplicationSettings.Get("keywords"));
			this.AddMetaDescription(ApplicationSettings.Get("description"));
		}
		private void RegisterAccounts()
		{
			if (TextUtility.EmptyTrimOrNull(this.txtAccounts.Text.Trim()) || TextUtility.EmptyTrimOrNull(this.txtLogonPass.Text.Trim()))
			{
				base.Show("抱歉！您输入的帐号或密码错误了。");
				this.txtAccounts.Focus();
			}
			else
			{
				if (!this.txtCode.Text.Trim().Equals(Fetch.GetVerifyCode(), System.StringComparison.InvariantCultureIgnoreCase))
				{
					base.Show("抱歉！您输入的验证码错误了。");
					this.txtAccounts.Focus();
				}
				else
				{
					Message message = FacadeManage.aideAccountsFacade.IsAccountsExist(CtrlHelper.GetTextAndFilter(this.txtAccounts));
					if (!message.Success)
					{
						base.Show(message.Content);
						this.txtAccounts.Focus();
					}
					else
					{
						UserInfo userInfo = new UserInfo();
						userInfo.Accounts = CtrlHelper.GetTextAndFilter(this.txtAccounts);
						userInfo.InsurePass = TextEncrypt.EncryptPassword(CtrlHelper.GetTextAndFilter(this.txtLogonPass));
						userInfo.LastLogonDate = System.DateTime.Now;
						userInfo.LastLogonIP = GameRequest.GetUserIP();
						userInfo.LogonPass = TextEncrypt.EncryptPassword(CtrlHelper.GetText(this.txtLogonPass));
						userInfo.NickName = CtrlHelper.GetTextAndFilter(this.txtAccounts);
						userInfo.RegisterDate = System.DateTime.Now;
						userInfo.RegisterIP = GameRequest.GetUserIP();
						userInfo.DynamicPass = System.Guid.NewGuid().ToString().Replace("-", "").ToUpper();
						Message message2 = FacadeManage.aideAccountsFacade.Register(userInfo, CtrlHelper.GetText(this.txtSpreader), "");
						if (!message2.Success)
						{
							base.Show(message2.Content);
							this.txtAccounts.Focus();
						}
						else
						{
							UserInfo userInfo2 = message2.EntityList[0] as UserInfo;
							userInfo2.LogonPass = TextEncrypt.EncryptPassword(CtrlHelper.GetText(this.txtLogonPass));
							Fetch.SetUserCookie(userInfo2.ToUserTicketInfo());
							this.SwitchStep(2);
							this.accounts = CtrlHelper.GetTextAndFilter(this.txtAccounts);
							GameScoreInfo treasureInfo = FacadeManage.aideTreasureFacade.GetTreasureInfo2(userInfo2.UserID);
							if (treasureInfo != null)
							{
								this.score = treasureInfo.Score.ToString();
							}
							ConfigInfo configInfo = FacadeManage.aideNativeWebFacade.GetConfigInfo(AppConfig.SiteConfigKey.GameAndroidConfig.ToString());
							if (configInfo != null)
							{
								this.downLoadAndroidUrl = configInfo.Field1;
							}
							configInfo = FacadeManage.aideNativeWebFacade.GetConfigInfo(AppConfig.SiteConfigKey.GameIosConfig.ToString());
							if (configInfo != null)
							{
								this.downLoadIosUrl = configInfo.Field1;
							}
							if (Fetch.GetTerminalType(this.Page.Request) == 1)
							{
								this.downLoadUrl = this.downLoadAndroidUrl;
							}
							else
							{
								this.downLoadUrl = this.downLoadIosUrl;
							}
						}
					}
				}
			}
		}
	}
}
