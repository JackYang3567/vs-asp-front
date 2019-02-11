using Game.Entity.NativeWeb;
using Game.Facade;
using Game.Utils;
using Game.Web.Themes.Standard;
using System;
using System.Web.UI.WebControls;
namespace Game.Web.Games
{
    public partial class Index : UCPageBase
    {
        protected string fullDownloadURL = string.Empty;
        protected string janeDownloadURL = string.Empty;
        protected string androidDownloadURL = string.Empty;
        protected string iosDownloadURL = string.Empty;
        protected int isShowMoblieDownload;
        protected string domain = string.Empty;
        protected Common_Header sHeader;
        protected System.Web.UI.WebControls.Repeater rptGame;
        protected System.Web.UI.WebControls.Repeater rptMoblieGame;
        protected Common_Footer sFooter;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.domain = "http://" + base.Request.Url.Authority.ToString();
                this.isShowMoblieDownload = (int)AppConfig.IsShowMoblieDownload;
                this.BindGameInfo();
                this.BindGameList();
                this.BindMoblieGame();
            }
        }
        protected override void AddHeaderTitle()
        {
            this.AddMetaTitle("游戏列表 - " + ApplicationSettings.Get("title"));
            this.AddMetaKeywords(ApplicationSettings.Get("keywords"));
            this.AddMetaDescription(ApplicationSettings.Get("description"));
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
        private void BindGameList()
        {
            this.rptGame.DataSource = FacadeManage.aideNativeWebFacade.GetGameHelps(30);
            this.rptGame.DataBind();
        }
        private void BindMoblieGame()
        {
            if (this.isShowMoblieDownload == 1)
            {
                this.rptMoblieGame.DataSource = FacadeManage.aideNativeWebFacade.GetMoblieGame();
                this.rptMoblieGame.DataBind();
            }
        }
    }
}
