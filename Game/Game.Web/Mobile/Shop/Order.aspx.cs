using Game.Entity.NativeWeb;
using Game.Facade;
using Game.Utils;
using System;
namespace Game.Web.Mobile.Shop
{
	public partial class Order : UCPageBase
	{
		protected string imgUrl = string.Empty;
		protected int price;
		public string name = string.Empty;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (base.IntParam == 0)
			{
				base.Response.Redirect("/Mobile/Shop404.html");
			}
			AwardInfo awardInfo = FacadeManage.aideNativeWebFacade.GetAwardInfo(base.IntParam);
			if (awardInfo == null)
			{
				base.Response.Redirect("/Mobile/Shop404.html");
			}
			this.imgUrl = Fetch.GetUploadFileUrl(awardInfo.SmallImage);
			this.price = awardInfo.Price;
			this.name = awardInfo.AwardName;
		}
		protected override void AddHeaderTitle()
		{
			this.AddMetaTitle("商城 - " + ApplicationSettings.Get("title"));
			this.AddMetaKeywords(ApplicationSettings.Get("keywords"));
			this.AddMetaDescription(ApplicationSettings.Get("description"));
		}
	}
}
