using Game.Entity.Accounts;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
namespace Game.Web.UserService
{
	public partial class InsureTransferRecord : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlForm form1;
		protected System.Web.UI.WebControls.Repeater rptInsureList;
		protected System.Web.UI.WebControls.Literal litNoData;
		protected AspNetPager anpPage;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Fetch.GetUserCookie();
			if (Fetch.IsUserOnline())
			{
				if (!base.IsPostBack)
				{
					this.DataBindInsure();
				}
			}
		}
		private void DataBindInsure()
		{
			if (Fetch.IsUserOnline())
			{
				System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
				stringBuilder.AppendFormat("WHERE SourceUserID = {0} OR TargetUserID = {0} ", Fetch.GetUserCookie().UserID);
				int queryInt = GameRequest.GetQueryInt("page", 1);
				int pageSize = this.anpPage.PageSize;
				PagerSet insureTradeRecord = FacadeManage.aideTreasureFacade.GetInsureTradeRecord(stringBuilder.ToString(), queryInt, pageSize);
				this.anpPage.RecordCount = insureTradeRecord.RecordCount;
				if (insureTradeRecord.PageSet.Tables[0].Rows.Count > 0)
				{
					this.rptInsureList.DataSource = insureTradeRecord.PageSet;
					this.rptInsureList.DataBind();
					this.rptInsureList.Visible = true;
					this.litNoData.Visible = false;
				}
				else
				{
					this.rptInsureList.Visible = false;
					this.litNoData.Visible = true;
				}
			}
		}
		public string GetNickNameByUserID(int userID)
		{
			UserInfo userBaseInfoByUserID = FacadeManage.aideAccountsFacade.GetUserBaseInfoByUserID(userID);
			string result;
			if (userBaseInfoByUserID == null)
			{
				result = "";
			}
			else
			{
				result = userBaseInfoByUserID.NickName;
			}
			return result;
		}
	}
}
