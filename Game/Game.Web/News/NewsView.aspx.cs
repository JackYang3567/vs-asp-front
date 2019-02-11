using Game.Entity.NativeWeb;
using Game.Facade;
using Game.Utils;
using Game.Web.Themes.Standard;
using System;
using System.Web.UI.HtmlControls;
namespace Game.Web.News
{
	public partial class NewsView : UCPageBase
	{
		public string source = "";
		public string type = "";
		public string issueDate = "";
		public string title = "";
		public string content = "";
		protected Common_Header sHeader;
		protected Common_Download sDownload;
		protected Common_Speedy sSpeedy;
		protected System.Web.UI.HtmlControls.HtmlAnchor next1;
		protected System.Web.UI.HtmlControls.HtmlAnchor last1;
		protected Common_Footer sFooter;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!base.IsPostBack)
			{
                Game.Entity.NativeWeb.News newsByNewsID = FacadeManage.aideNativeWebFacade.GetNewsByNewsID(base.IntParam, 0);
				if (newsByNewsID != null)
				{
					this.source = ((newsByNewsID.IsLinks == 1) ? newsByNewsID.LinkUrl : ApplicationSettings.Get("title"));
					this.type = ((newsByNewsID.ClassID == 1) ? "新闻" : "公告");
					this.issueDate = newsByNewsID.IssueDate.ToString("yyyy-MM-dd HH:mm:ss");
					this.title = newsByNewsID.Subject;
					this.content = Utility.HtmlDecode(newsByNewsID.Body);
                    Game.Entity.NativeWeb.News newsByNewsID2 = FacadeManage.aideNativeWebFacade.GetNewsByNewsID(base.IntParam, 1);
					if (newsByNewsID2 != null)
					{
						this.next1.Title = "上一篇新闻：" + newsByNewsID2.Subject;
						this.next1.HRef = "NewsView.aspx?param=" + newsByNewsID2.NewsID;
					}
					else
					{
						this.next1.Title = "已经是第一篇了！";
						this.next1.Disabled = true;
						this.next1.Attributes.Add("class", "ui-news-text-prev ui-no-page");
					}
                    Game.Entity.NativeWeb.News newsByNewsID3 = FacadeManage.aideNativeWebFacade.GetNewsByNewsID(base.IntParam, 2);
					if (newsByNewsID3 != null)
					{
						this.last1.Title = "下一篇新闻：" + newsByNewsID3.Subject;
						this.last1.HRef = "NewsView.aspx?param=" + newsByNewsID3.NewsID;
					}
					else
					{
						this.last1.Title = "已经是最后一篇了！";
						this.last1.Disabled = true;
						this.last1.Attributes.Add("class", "ui-news-text-next ui-no-page");
					}
				}
			}
		}
		protected override void AddHeaderTitle()
		{
            Game.Entity.NativeWeb.News newsByNewsID = FacadeManage.aideNativeWebFacade.GetNewsByNewsID(base.IntParam, 0);
			if (newsByNewsID != null)
			{
				this.AddMetaTitle(newsByNewsID.Subject + " - " + ApplicationSettings.Get("title"));
			}
			this.AddMetaKeywords(ApplicationSettings.Get("keywords"));
			this.AddMetaDescription(ApplicationSettings.Get("description"));
		}
	}
}
