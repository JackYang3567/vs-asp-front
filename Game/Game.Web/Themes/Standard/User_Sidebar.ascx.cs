using Game.Entity.Accounts;
using Game.Facade;
using System;
using System.Web.UI;
namespace Game.Web.Themes.Standard
{
    public partial  class User_Sidebar : System.Web.UI.UserControl
	{
		public int MemberID;
		protected int agentID;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			UserTicketInfo userCookie = Fetch.GetUserCookie();
			if (userCookie != null)
			{
				UserInfo userBaseInfoByUserID = FacadeManage.aideAccountsFacade.GetUserBaseInfoByUserID(userCookie.UserID);
				this.agentID = userBaseInfoByUserID.AgentID;
			}
		}
	}
}
