using Game.Entity.NativeWeb;
using Game.Facade;
using System;
using System.Web.UI;
namespace Game.Web.Themes.Standard
{
	public partial class Common_Download : System.Web.UI.UserControl
	{
		protected string fullDownloadURL = string.Empty;
		protected string janeDownloadURL = string.Empty;
		protected string androidDownloadURL = string.Empty;
		protected string iosDownloadURL = string.Empty;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.BindGameInfo();
			}
		}
		private void BindGameInfo()
		{
			ConfigInfo configInfo = FacadeManage.aideNativeWebFacade.GetConfigInfo(AppConfig.SiteConfigKey.GameFullPackageConfig.ToString());
			if (configInfo != null)
			{
				this.fullDownloadURL = configInfo.Field1;
			}
			configInfo = FacadeManage.aideNativeWebFacade.GetConfigInfo(AppConfig.SiteConfigKey.GameJanePackageConfig.ToString());
			if (configInfo != null)
			{
				this.janeDownloadURL = configInfo.Field1;
			}
			configInfo = FacadeManage.aideNativeWebFacade.GetConfigInfo(AppConfig.SiteConfigKey.GameAndroidConfig.ToString());
			if (configInfo != null)
			{
				this.androidDownloadURL = configInfo.Field1;
			}
			configInfo = FacadeManage.aideNativeWebFacade.GetConfigInfo(AppConfig.SiteConfigKey.GameIosConfig.ToString());
			if (configInfo != null)
			{
				this.iosDownloadURL = configInfo.Field1;
			}
		}
	}
}
