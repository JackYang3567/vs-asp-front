using Game.Entity.NativeWeb;
using Game.Facade;
using Game.Utils;
using Game.Web.Themes.Standard;
using System;
namespace Game.Web.About
{
    public class Index : UCPageBase
    {
        public SinglePage singlePage = new SinglePage();
        protected string contents = string.Empty;
        protected Common_Header sHeader;
        protected About_Sidebar sAboutSidebar;
        protected Common_Download sDownload;
        protected Common_Speedy sSpeedy;
        protected Common_Footer sFooter;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.singlePage = FacadeManage.aideNativeWebFacade.GetSinglePage(AppConfig.SinglePageKey.AboutUs.ToString());
            this.contents = Utility.HtmlDecode(this.singlePage.Contents);
        }
        protected override void AddHeaderTitle()
        {
            this.AddMetaTitle("关于我们 - " + ApplicationSettings.Get("title"));
            this.AddMetaKeywords(string.IsNullOrEmpty(this.singlePage.KeyWords) ? ApplicationSettings.Get("keywords") : this.singlePage.KeyWords);
            this.AddMetaDescription(string.IsNullOrEmpty(this.singlePage.Description) ? ApplicationSettings.Get("description") : this.singlePage.Description);
        }
    }
}
