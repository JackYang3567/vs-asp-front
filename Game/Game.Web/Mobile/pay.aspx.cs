using Game.Facade;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace Game.Web.Mobile
{
    public partial class pay : System.Web.UI.Page
	{
		protected int payType;
		protected System.Web.UI.HtmlControls.HtmlForm form1;
		protected System.Web.UI.WebControls.Repeater rpt_Data;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			System.Data.DataTable dataTable = new System.Data.DataTable();
			if (System.Web.HttpRuntime.Cache["payInfo"] == null)
			{
				dataTable = FacadeManage.aideTreasureFacade.GetPayList();
				if (dataTable != null)
				{
					CacheHelper.AddCache("payInfo", dataTable);
				}
			}
			else
			{
				dataTable = (System.Web.HttpRuntime.Cache["payInfo"] as System.Data.DataTable);
			}
			this.rpt_Data.DataSource = dataTable;
			this.rpt_Data.DataBind();
		}
	}
}
