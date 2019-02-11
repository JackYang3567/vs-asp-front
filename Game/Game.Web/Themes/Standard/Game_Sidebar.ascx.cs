using Game.Entity.Platform;
using Game.Facade;
using Game.Utils;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace Game.Web.Themes.Standard
{
    public partial class Game_Sidebar : System.Web.UI.UserControl
	{
		protected int kindID = GameRequest.GetQueryInt("KindID", 0);
		protected System.Web.UI.WebControls.Repeater rptGameTypes;
		protected System.Web.UI.HtmlControls.HtmlInputHidden TCount;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.BindGameTypes();
			}
		}
		private void BindGameTypes()
		{
			this.rptGameTypes.DataSource = FacadeManage.aidePlatformFacade.GetGameTypes();
			this.rptGameTypes.DataBind();
			this.TCount.Value = this.rptGameTypes.Items.Count.ToString();
		}
		protected void rptGameTypes_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == System.Web.UI.WebControls.ListItemType.Item || e.Item.ItemType == System.Web.UI.WebControls.ListItemType.AlternatingItem)
			{
				System.Web.UI.WebControls.Repeater repeater = (System.Web.UI.WebControls.Repeater)e.Item.FindControl("rptGameList");
				GameTypeItem gameTypeItem = (GameTypeItem)e.Item.DataItem;
				int num = System.Convert.ToInt32(gameTypeItem.TypeID);
				if (num == 2)
				{
					repeater.DataSource = FacadeManage.aidePlatformFacade.GetRecommendGame();
				}
				else
				{
					repeater.DataSource = FacadeManage.aidePlatformFacade.GetGameKindsByTypeID(num);
				}
				repeater.DataBind();
			}
		}
	}
}
