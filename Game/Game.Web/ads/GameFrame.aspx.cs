using Game.Entity.NativeWeb;
using Game.Facade;
using System;
using System.Web.UI;
namespace Game.Web.ads
{
    public partial class GameFrame : System.Web.UI.Page
	{
		protected string resourceURL = string.Empty;
		protected string targetURL = string.Empty;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Ads ads = FacadeManage.aideNativeWebFacade.GetAds(6);
			if (ads != null)
			{
				this.resourceURL = Fetch.GetUploadFileUrl(ads.ResourceURL);
				this.targetURL = ads.LinkURL;
			}
		}
	}
}
