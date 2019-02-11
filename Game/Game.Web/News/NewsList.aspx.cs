using Game.Facade;
using Game.Kernel;
using Game.Utils;
using Game.Web.Themes.Standard;
using System;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
namespace Game.Web.News
{
	public partial class NewsList : UCPageBase
	{
		protected Common_Header sHeader;
		protected Common_Download sDownload;
		protected Common_Speedy sSpeedy;
		protected System.Web.UI.WebControls.Repeater rptNewsList;
		protected AspNetPager anpPage;
		protected Common_Footer sFooter;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.BindNewsData();
			}
			Common_Header common_Header = (Common_Header)this.FindControl("sHeader");
			common_Header.title = "新闻公告";
		}
		protected override void AddHeaderTitle()
		{
			this.AddMetaTitle("新闻列表 - " + ApplicationSettings.Get("title"));
			this.AddMetaKeywords(ApplicationSettings.Get("keywords"));
			this.AddMetaDescription(ApplicationSettings.Get("description"));
		}
		private void BindNewsData()
		{
			int pageSize = this.anpPage.PageSize;
			PagerSet newsList;
			if (base.IntParam != 0)
			{
				newsList = FacadeManage.aideNativeWebFacade.GetNewsList(base.PageIndex, pageSize, base.IntParam);
			}
			else
			{
				newsList = FacadeManage.aideNativeWebFacade.GetNewsList(base.PageIndex, pageSize);
			}
			this.anpPage.RecordCount = newsList.RecordCount;
			if (newsList.PageSet.Tables[0].Rows.Count > 0)
			{
				this.rptNewsList.DataSource = newsList.PageSet;
				this.rptNewsList.DataBind();
			}
			if (newsList.RecordCount < pageSize)
			{
				this.anpPage.Visible = false;
			}
		}
	}
}
