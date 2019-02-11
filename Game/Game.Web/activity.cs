using Game.Facade;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace Game.Web
{
	public class activity : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlForm form1;
		protected new Head Header;
		protected Notice Notice;
		protected System.Web.UI.WebControls.Repeater rptData;
		protected Foot Foot;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			System.Data.DataTable activeList = FacadeManage.aideNativeWebFacade.GetActiveList(0);
			this.rptData.DataSource = activeList;
			this.rptData.DataBind();
		}
	}
}
