using Game.Facade;
using Game.Utils;
using System;
using System.Data;
using System.Web.UI.WebControls;
namespace Game.Web.Mobile.Shop
{
    public partial class Goods : UCPageBase
	{
		protected System.Web.UI.WebControls.Repeater rptData;
		protected override bool IsAuthenticatedUser
		{
			get
			{
				return true;
			}
		}
		protected void Page_Load(object sender, System.EventArgs e)
		{
			this.BindData();
		}
		private void BindData()
		{
			System.Data.DataSet shopList = FacadeManage.aideNativeWebFacade.GetShopList(2147483647);
			this.rptData.DataSource = shopList;
			this.rptData.DataBind();
		}
		protected override void AddHeaderTitle()
		{
			this.AddMetaTitle("商城 - " + ApplicationSettings.Get("title"));
			this.AddMetaKeywords(ApplicationSettings.Get("keywords"));
			this.AddMetaDescription(ApplicationSettings.Get("description"));
		}
	}
}
