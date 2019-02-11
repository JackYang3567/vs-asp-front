using Game.Entity.NativeWeb;
using Game.Facade;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
namespace Game.Web.UserService
{
	public partial class PayIndex : UCPageBase
	{
		protected System.Web.UI.WebControls.Repeater rptIssueList;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.BindIssueData();
			}
		}
		private void BindIssueData()
		{
			System.Collections.Generic.IList<GameIssueInfo> topIssueList = FacadeManage.aideNativeWebFacade.GetTopIssueList(4, 2);
			if (topIssueList != null)
			{
				this.rptIssueList.DataSource = topIssueList;
				this.rptIssueList.DataBind();
			}
		}
		protected string GetIssueContent(string content)
		{
			string result = "";
			if (!string.IsNullOrEmpty(content))
			{
				if (content.Length > 30)
				{
					result = TextUtility.CutLeft(Utility.HtmlDecode(content), 30) + "...";
				}
				else
				{
					result = Utility.HtmlDecode(content);
				}
			}
			return result;
		}
	}
}
