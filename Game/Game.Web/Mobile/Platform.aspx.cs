using Game.Entity.NativeWeb;
using Game.Facade;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Game.Web.Mobile
{
    public partial class Platform : System.Web.UI.Page
	{
		protected int terminalType;
		protected string platformIntro = string.Empty;
		protected string platformDownloadUrl = string.Empty;
		protected System.Web.UI.WebControls.Repeater rptMoblieGame;
		protected System.Web.UI.WebControls.Panel plNotData;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			this.terminalType = Fetch.GetTerminalType(this.Page.Request);
			ConfigInfo configInfo = FacadeManage.aideNativeWebFacade.GetConfigInfo(AppConfig.SiteConfigKey.GameAndroidConfig.ToString());
			ConfigInfo configInfo2 = FacadeManage.aideNativeWebFacade.GetConfigInfo(AppConfig.SiteConfigKey.GameIosConfig.ToString());
			if (configInfo.Field1 != "" || configInfo2.Field1 != "")
			{
				if (this.terminalType == 1)
				{
					this.platformDownloadUrl = configInfo.Field1;
				}
				else
				{
					this.platformDownloadUrl = configInfo2.Field1;
				}
			}
			this.platformIntro = "";
			this.BindMoblieGame();
		}
		private void BindMoblieGame()
		{
			System.Data.DataSet moblieGame = FacadeManage.aideNativeWebFacade.GetMoblieGame();
			if (moblieGame.Tables[0].Rows.Count > 0)
			{
				this.rptMoblieGame.DataSource = moblieGame.Tables[0];
				this.rptMoblieGame.DataBind();
			}
			else
			{
				this.rptMoblieGame.Visible = false;
				this.plNotData.Visible = true;
			}
		}
	}
}
