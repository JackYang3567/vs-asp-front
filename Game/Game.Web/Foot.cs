using Game.Entity.NativeWeb;
using Game.Facade;
using System;
using System.Web.UI;
namespace Game.Web
{
	public class Foot : System.Web.UI.UserControl
	{
		protected string kf = "";
		protected void Page_Load(object sender, System.EventArgs e)
		{
			ConfigInfo configInfo = FacadeManage.aideNativeWebFacade.GetConfigInfo(AppConfig.SiteConfigKey.ContactConfig.ToString());
			if (configInfo != null)
			{
				this.kf = configInfo.Field4;
			}
		}
	}
}
