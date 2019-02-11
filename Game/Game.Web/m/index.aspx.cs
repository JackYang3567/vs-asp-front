using Game.Entity.NativeWeb;
using Game.Facade;
using Game.Kernel;
using System.Text;

namespace Game.Web.m
{
    public partial class index : System.Web.UI.Page
    {
        protected string zhuce = "";
        protected System.Web.UI.HtmlControls.HtmlForm form1;
        protected System.Web.UI.WebControls.Repeater rptData;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script>");
            sb.Append("var _hmt = _hmt || [];");
            sb.Append("(function() {");
            sb.Append("  var hm = document.createElement('script');");
            sb.Append("hm.src = 'https://hm.baidu.com/hm.js?8ee3ec23e73c6dcda2c7c9c489c151aa';");
            sb.Append("var s = document.getElementsByTagName('script')[0]; ");
            sb.Append("s.parentNode.insertBefore(hm, s);");
            sb.Append("})();");
            sb.Append("</script>");
            ClientScript.RegisterStartupScript(this.GetType(), "LoadScript", sb.ToString());

            //PagerSet mobileNotcieList = FacadeManage.aideNativeWebFacade.GetMobileNotcieList(1, 10);
            //this.rptData.DataSource = mobileNotcieList.PageSet;
            //this.rptData.DataBind();
            //if (System.Web.HttpRuntime.Cache["zhuce"] == null)
            //{
            //    ConfigInfo configInfo = FacadeManage.aideNativeWebFacade.GetConfigInfo(AppConfig.SiteConfigKey.SiteConfig.ToString());
            //    if (configInfo != null)
            //    {
            //        this.zhuce = configInfo.Field3;
            //        CacheHelper.AddCache("zhuce", this.zhuce);
            //    }
            //}
            //else
            //{
            //    this.zhuce = System.Web.HttpRuntime.Cache["zhuce"].ToString();
            //}
        }
    }
}