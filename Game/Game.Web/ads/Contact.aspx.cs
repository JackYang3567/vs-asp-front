using Game.Entity.NativeWeb;
using Game.Facade;
using System;
using System.Web.UI;
namespace Game.Web.ads
{
	public partial class Contact : System.Web.UI.Page
	{
		protected string phone = string.Empty;
		protected string fax = string.Empty;
		protected string email = string.Empty;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			ConfigInfo configInfo = FacadeManage.aideNativeWebFacade.GetConfigInfo(AppConfig.SiteConfigKey.ContactConfig.ToString());
			if (configInfo != null)
			{
				this.phone = configInfo.Field1;
				this.fax = configInfo.Field2;
				this.email = configInfo.Field3;
			}
		}
	}
}
