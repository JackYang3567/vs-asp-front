using Game.Entity.NativeWeb;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
namespace Game.Web.UserService
{
    public partial class Feedback : UCPageBase
	{
		protected string pageInfo = string.Empty;
		protected System.Web.UI.HtmlControls.HtmlForm form1;
		protected System.Web.UI.HtmlControls.HtmlGenericControl litMessage;
		protected System.Web.UI.WebControls.Repeater rptFeedBackList;
		protected AspNetPager anpPage;
		protected System.Web.UI.HtmlControls.HtmlAnchor preLink;
		protected System.Web.UI.HtmlControls.HtmlAnchor nextLink;
		protected System.Web.UI.WebControls.TextBox txtContent;
		protected System.Web.UI.WebControls.Button btnPublish;
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
				this.BindFeedBackData();
			}
		}
		private void BindFeedBackData()
		{
			int pageSize = this.anpPage.PageSize;
			PagerSet feedbacklist = FacadeManage.aideNativeWebFacade.GetFeedbacklist(base.PageIndex, pageSize, Fetch.GetUserCookie().UserID);
			this.anpPage.RecordCount = feedbacklist.RecordCount;
			if (feedbacklist.PageSet.Tables[0].Rows.Count > 0)
			{
				this.rptFeedBackList.DataSource = feedbacklist.PageSet;
				this.rptFeedBackList.DataBind();
				this.litMessage.Visible = false;
			}
			else
			{
				this.litMessage.Visible = true;
			}
			this.pageInfo = string.Format("<span class=\"ui-orange\">{0}</span><span class=\"ui-gray\">/</span><span class=\"ui-white\">{1}</span>", base.PageIndex, this.anpPage.PageCount);
			if (this.anpPage.PageCount == 1)
			{
				this.preLink.Attributes.Add("class", "ui-no-next");
				this.nextLink.Attributes.Add("class", "ui-no-next");
			}
			else
			{
				if (base.PageIndex == 1)
				{
					this.nextLink.Attributes.Add("href", TextUtility.SetQueryValueReturnUrl("page", (base.PageIndex + 1).ToString()));
					this.preLink.Attributes.Add("class", "ui-no-next");
				}
				else
				{
					if (base.PageIndex == this.anpPage.PageCount)
					{
						this.preLink.Attributes.Add("href", TextUtility.SetQueryValueReturnUrl("page", (base.PageIndex - 1).ToString()));
						this.nextLink.Attributes.Add("class", "ui-no-next");
					}
					else
					{
						this.preLink.Attributes.Add("href", TextUtility.SetQueryValueReturnUrl("page", (base.PageIndex - 1).ToString()));
						this.nextLink.Attributes.Add("href", TextUtility.SetQueryValueReturnUrl("page", (base.PageIndex + 1).ToString()));
					}
				}
			}
		}
		protected void btnPublish_Click(object sender, System.EventArgs e)
		{
			string accouts = "";
			if (Fetch.GetUserCookie() != null)
			{
				accouts = Fetch.GetUserCookie().Accounts;
			}
			GameFeedbackInfo gameFeedbackInfo = new GameFeedbackInfo();
			gameFeedbackInfo.FeedbackContent = CtrlHelper.GetTextAndFilter(this.txtContent);
			gameFeedbackInfo.FeedbackTitle = "";
			gameFeedbackInfo.ClientIP = GameRequest.GetUserIP();
			Message message = FacadeManage.aideNativeWebFacade.PublishFeedback(gameFeedbackInfo, accouts);
			if (message.Success)
			{
				this.ShowAndRedirect("感谢您的问题反馈，我们将尽快给予回复，敬请留意！");
			}
			else
			{
				this.ShowMessage(message.Content);
			}
		}
		public void ShowAndRedirect(string msg)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("<script language='javascript' defer>");
			stringBuilder.AppendFormat("msgBox('{0}');", msg);
			stringBuilder.AppendFormat("document.location.href=document.location.href", new object[0]);
			stringBuilder.Append("</script>");
			this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "message", stringBuilder.ToString());
		}
		public void ShowMessage(string msg)
		{
			this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "message", "<script type='text/javascript'>msgBox('" + msg.ToString() + "');</script>");
		}
	}
}
