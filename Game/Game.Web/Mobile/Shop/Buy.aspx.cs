using Game.Entity.Accounts;
using Game.Entity.NativeWeb;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
namespace Game.Web.Mobile.Shop
{
	public partial class Buy : UCPageBase
	{
		protected string imgUrl = string.Empty;
		protected int price;
		public string name = string.Empty;
		public int inventory;
		public int userMedals;
		protected string realName = string.Empty;
		protected string phone = string.Empty;
		protected int province = -1;
		protected int city = -1;
		protected int area = -1;
		protected string address = string.Empty;
		protected override bool IsAuthenticatedUser
		{
			get
			{
				return true;
			}
		}
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
			this.inventory = awardInfo.Inventory;
			Message userGlobalInfo = FacadeManage.aideAccountsFacade.GetUserGlobalInfo(Fetch.GetUserCookie().UserID, 0, "");
			UserInfo userInfo = userGlobalInfo.EntityList[0] as UserInfo;
			this.userMedals = userInfo.UserMedal;
			this.realName = userInfo.Compellation;
			IndividualDatum userContactInfoByUserID = FacadeManage.aideAccountsFacade.GetUserContactInfoByUserID(Fetch.GetUserCookie().UserID);
			this.phone = userContactInfoByUserID.MobilePhone;
			this.address = userContactInfoByUserID.DwellingPlace;
		}
		protected override void AddHeaderTitle()
		{
			this.AddMetaTitle("商城 - " + ApplicationSettings.Get("title"));
			this.AddMetaKeywords(ApplicationSettings.Get("keywords"));
			this.AddMetaDescription(ApplicationSettings.Get("description"));
		}
	}
}
