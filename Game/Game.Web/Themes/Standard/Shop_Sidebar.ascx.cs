using Game.Facade;
using Game.Utils;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Game.Web.Themes.Standard
{
    public partial class Shop_Sidebar : System.Web.UI.UserControl
	{
		protected int typeID;
		public int ShopPageID;
		protected System.Web.UI.WebControls.Repeater rptTopType;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			this.typeID = GameRequest.GetQueryInt("param", 0);
			System.Data.DataSet shopTypeListByParentId = FacadeManage.aideNativeWebFacade.GetShopTypeListByParentId(0);
			if (shopTypeListByParentId.Tables[0].Rows.Count > 0)
			{
				this.rptTopType.DataSource = shopTypeListByParentId;
				this.rptTopType.DataBind();
			}
		}
	}
}
