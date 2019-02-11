using Game.Entity.NativeWeb;
using Game.Facade;
using Game.Utils;
using System;
using System.Web.UI;
namespace Game.Web.Themes.Standard
{
	public partial class Common_Footer : System.Web.UI.UserControl
	{
		protected string contents = string.Empty;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			ConfigInfo configInfo = FacadeManage.aideNativeWebFacade.GetConfigInfo(AppConfig.SiteConfigKey.SiteConfig.ToString());
			if (configInfo != null)
			{
				this.contents = Utility.HtmlDecode(configInfo.Field8);
			}
		}
	}
}
