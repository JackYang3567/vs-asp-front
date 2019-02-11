using Game.Entity.Accounts;
using Game.Facade;
using Game.Utils;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Game.Web.Themes.Standard
{
	public partial class Shop_Top : System.Web.UI.UserControl
	{
		protected string faceUrl = string.Empty;
		protected string accounts = string.Empty;
		protected string memberIcon = string.Empty;
		protected int medal;
		protected string returnUrl = string.Empty;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divLogon;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divNoLogon;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (Fetch.GetUserCookie() == null)
			{
				this.divLogon.Visible = false;
				this.divNoLogon.Visible = true;
				this.returnUrl = GameRequest.GetRawUrl();
			}
			else
			{
				UserInfo userInfo = FacadeManage.aideAccountsFacade.GetUserGlobalInfo(Fetch.GetUserCookie().UserID, 0, "").EntityList[0] as UserInfo;
				if (userInfo == null)
				{
					this.divLogon.Visible = false;
					this.divNoLogon.Visible = true;
				}
				else
				{
					this.faceUrl = FacadeManage.aideAccountsFacade.GetUserFaceUrl((int)userInfo.FaceID, userInfo.CustomID);
					this.accounts = userInfo.Accounts;
					this.medal = userInfo.UserMedal;
				}
			}
		}
	}
}
