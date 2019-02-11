using Game.Entity.Accounts;
using Game.Facade;
using System;
namespace Game.Web.Mobile.Agent
{
    public partial class AgentInfo : UCPageBase
	{
		protected string accounts = string.Empty;
		protected string agentID = string.Empty;
		protected string compellation = string.Empty;
		protected string domain = string.Empty;
		protected string agentType = string.Empty;
		protected string agentScale = string.Empty;
		protected string payBackScore = string.Empty;
		protected string payBackScale = string.Empty;
		protected string mobilePhone = string.Empty;
		protected string eMail = string.Empty;
		protected string dwellingPlace = string.Empty;
		protected string collectDate = string.Empty;
		protected override bool IsAuthenticatedUser
		{
			get
			{
				return true;
			}
		}
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!base.IsPostBack)
			{
				AccountsAgent accountAgentByUserID = FacadeManage.aideAccountsFacade.GetAccountAgentByUserID(Fetch.GetUserCookie().UserID);
				if (accountAgentByUserID.AgentID != 0)
				{
					this.agentID = accountAgentByUserID.AgentID.ToString();
					this.compellation = accountAgentByUserID.Compellation;
					this.domain = accountAgentByUserID.Domain;
					this.agentType = ((accountAgentByUserID.AgentType == 1) ? "充值分成" : "税收分成");
					this.agentScale = System.Convert.ToInt32(accountAgentByUserID.AgentScale * 1000m).ToString() + "‰";
					this.payBackScore = accountAgentByUserID.PayBackScore.ToString();
					this.payBackScale = System.Convert.ToInt32(accountAgentByUserID.PayBackScale * 1000m).ToString() + "‰";
					this.mobilePhone = accountAgentByUserID.MobilePhone;
					this.eMail = accountAgentByUserID.EMail;
					this.dwellingPlace = accountAgentByUserID.DwellingPlace;
					this.collectDate = accountAgentByUserID.CollectDate.ToString("yyyy-MM-dd");
				}
			}
		}
	}
}
