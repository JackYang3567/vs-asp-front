using Game.Facade;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Game.Web.m
{
    public partial class activity : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Repeater rptData;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			System.Data.DataSet pageSet = FacadeManage.aideNativeWebFacade.GetList("Activity", 1, 4, " ORDER BY SortID ASC,InputDate DESC", "").PageSet;
			this.rptData.DataSource = pageSet;
			this.rptData.DataBind();
		}
	}
}
