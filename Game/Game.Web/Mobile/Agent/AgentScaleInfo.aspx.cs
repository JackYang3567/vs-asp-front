using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace Game.Web.Mobile.Agent
{
    public partial class AgentScaleInfo : UCPageBase
	{
		protected string childCount = string.Empty;
		protected string agentRevenue = string.Empty;
		protected string agentPay = string.Empty;
		protected string agentPayBack = string.Empty;
		protected string agentIn = string.Empty;
		protected string agentOut = string.Empty;
		protected string agentRemain = string.Empty;
		protected System.Web.UI.HtmlControls.HtmlForm form1;
		protected System.Web.UI.WebControls.TextBox txtScore;
		protected System.Web.UI.WebControls.Button btnUpdate;
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
				this.childCount = FacadeManage.aideAccountsFacade.GetAgentChildCount(Fetch.GetUserCookie().UserID).ToString();
				System.Data.DataSet agentFinance = FacadeManage.aideTreasureFacade.GetAgentFinance(Fetch.GetUserCookie().UserID);
				this.agentRevenue = System.Convert.ToInt64(agentFinance.Tables[0].Rows[0]["AgentRevenue"]).ToString();
				this.agentPay = System.Convert.ToInt64(agentFinance.Tables[0].Rows[0]["AgentPay"]).ToString();
				this.agentPayBack = System.Convert.ToInt64(agentFinance.Tables[0].Rows[0]["AgentPayBack"]).ToString();
				this.agentIn = (System.Convert.ToInt64(agentFinance.Tables[0].Rows[0]["AgentRevenue"]) + System.Convert.ToInt64(agentFinance.Tables[0].Rows[0]["AgentPay"]) + System.Convert.ToInt64(agentFinance.Tables[0].Rows[0]["AgentPayBack"])).ToString();
				this.agentOut = System.Convert.ToInt64(agentFinance.Tables[0].Rows[0]["AgentOut"]).ToString();
				this.agentRemain = (System.Convert.ToInt64(this.agentIn) - System.Convert.ToInt64(this.agentOut)).ToString();
				this.txtScore.Text = this.agentRemain.ToString();
			}
		}
		protected void btnUpdate_Click(object sender, System.EventArgs e)
		{
			Message agentBalance = FacadeManage.aideTreasureFacade.GetAgentBalance(Utility.StrToInt(this.txtScore.Text.Trim(), 0), Fetch.GetUserCookie().UserID, GameRequest.GetUserIP());
			if (agentBalance.Success)
			{
				base.ShowAndRedirect("结算成功!", "/Mobile/Agent/AgentScaleInfo.aspx");
			}
			else
			{
				base.ShowAndRedirect(agentBalance.Content, "/Mobile/Agent/AgentScaleInfo.aspx");
			}
		}
	}
}
