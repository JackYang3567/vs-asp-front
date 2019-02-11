using Game.Facade;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Game.Web.Mobile
{
    public partial class activity : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Repeater rptData;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!base.IsPostBack)
			{
				if (base.Request.Url.Host == "wwww.pyxpw.com")
				{
					base.Response.Redirect("http://www.pyxpw.com/Mobile/activity.aspx");
				}
				else
				{
					System.Data.DataSet pageSet = FacadeManage.aideNativeWebFacade.GetList("Activity", 1, 4, " ORDER BY SortID ASC,InputDate DESC", "WHERE IsRecommend=1").PageSet;
					this.rptData.DataSource = pageSet;
					this.rptData.DataBind();
				}
			}
		}
	}
}
