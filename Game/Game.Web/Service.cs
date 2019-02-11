using Game.Entity.NativeWeb;
using Game.Facade;
using Game.Utils;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace Game.Web
{
	public class Service : System.Web.UI.Page
	{
		protected string qq1 = "";
		protected string qq2 = "";
		protected string kf = "";
		protected System.Web.UI.HtmlControls.HtmlForm form1;
		protected new Head Header;
		protected Notice Notice;
		protected System.Web.UI.WebControls.Literal ltlAbout;
		protected Foot Foot;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.ltlAbout.Text = FacadeManage.aideNativeWebFacade.GetGameNotice("关于我们").Replace("/Content/Upload", ApplicationSettings.Get("fileUrl"));
				ConfigInfo configInfo = FacadeManage.aideNativeWebFacade.GetConfigInfo("ContactConfig");
				if (configInfo != null)
				{
					this.qq1 = configInfo.Field2;
					this.kf = configInfo.Field4;
				}
			}
		}
	}
}
