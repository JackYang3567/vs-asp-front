using Game.Facade;
using Game.Kernel;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Game.Web
{
	public class Notice : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Repeater rptData;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!base.IsPostBack)
			{
				PagerSet mobileNotcieList = FacadeManage.aideNativeWebFacade.GetMobileNotcieList(1, 10);
				this.rptData.DataSource = mobileNotcieList.PageSet;
				this.rptData.DataBind();
			}
		}
	}
}
