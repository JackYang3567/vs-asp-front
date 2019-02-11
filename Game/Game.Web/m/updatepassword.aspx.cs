using Game.Entity.NativeWeb;
using Game.Facade;
using Game.Kernel;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Game.Web.m
{
    public partial class updatepassword : System.Web.UI.Page
    {
        protected string zhuce = "";
        protected System.Web.UI.HtmlControls.HtmlForm form1;
        protected System.Web.UI.WebControls.Repeater rptData;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            PagerSet mobileNotcieList = FacadeManage.aideNativeWebFacade.GetMobileNotcieList(1, 10);
            this.rptData.DataSource = mobileNotcieList.PageSet;
            this.rptData.DataBind();
            if (System.Web.HttpRuntime.Cache["zhuce"] == null)
            {
                ConfigInfo configInfo = FacadeManage.aideNativeWebFacade.GetConfigInfo(AppConfig.SiteConfigKey.SiteConfig.ToString());
                if (configInfo != null)
                {
                    this.zhuce = configInfo.Field3;
                    CacheHelper.AddCache("zhuce", this.zhuce);
                }
            }
            else
            {
                this.zhuce = System.Web.HttpRuntime.Cache["zhuce"].ToString();
            }
        }
    }
}