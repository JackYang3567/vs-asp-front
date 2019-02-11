using Game.Entity.NativeWeb;
using Game.Facade;
using System;
using System.Web;
using System.Web.UI;
namespace Game.Web.m
{
    public partial class register : System.Web.UI.Page
	{
		protected string zhuce = "";
		protected void Page_Load(object sender, System.EventArgs e)
		{
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
