using Game.Entity.NativeWeb;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.UI.HtmlControls;
namespace Game.Web.Mobile
{
    public partial class Feedback : UCPageBase
	{
		protected string contents = string.Empty;
		protected System.Web.UI.HtmlControls.HtmlForm form1;
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
				ConfigInfo configInfo = FacadeManage.aideNativeWebFacade.GetConfigInfo(AppConfig.SiteConfigKey.ContactConfig.ToString());
				if (configInfo != null)
				{
					this.contents = configInfo.Field1;
				}
			}
			if (this.Page.IsPostBack)
			{
				this.PostData();
			}
		}
		private void PostData()
		{
			string text = GameRequest.GetFormString("content");
			System.Web.HttpPostedFile httpPostedFile = null;
			if (base.Request.Files.Count != 0)
			{
				httpPostedFile = base.Request.Files[0];
			}
			string text2 = "";
			if (httpPostedFile != null && httpPostedFile.ContentLength != 0)
			{
				try
				{
					Image image = Image.FromStream(httpPostedFile.InputStream);
					image.Dispose();
				}
				catch
				{
					base.ShowAndRedirect("目前只支持图片格式文件,对您使用不便感到非常抱歉。", "/Mobile/Feedback.aspx");
					return;
				}
				string text3 = "/Upload/Feedback/";
				string text4 = base.Server.MapPath(text3);
				if (!System.IO.Directory.Exists(text4))
				{
					System.IO.Directory.CreateDirectory(text4);
				}
				string fileName = httpPostedFile.FileName;
				string str = System.IO.Path.GetExtension(fileName).ToLower();
				string str2 = System.DateTime.Now.ToString("yyyyMMddHHmmss_ffff", System.Globalization.DateTimeFormatInfo.InvariantInfo) + str;
				string filename = text4 + str2;
				text2 = text3 + str2;
				httpPostedFile.SaveAs(filename);
			}
			if (text == "")
			{
				base.ShowAndRedirect("反馈意见不能为空。", "/Mobile/Feedback.aspx");
			}
			else
			{
				if (text.Length < 10)
				{
					base.ShowAndRedirect("反馈意见最少输入10个字符。", "/Mobile/Feedback.aspx");
				}
				else
				{
					string accouts = "";
					if (Fetch.GetUserCookie() != null)
					{
						accouts = Fetch.GetUserCookie().Accounts;
					}
					if (text2 != "")
					{
						text += string.Format("<image src=\"{0}\"></image>", text2);
					}
					GameFeedbackInfo gameFeedbackInfo = new GameFeedbackInfo();
					gameFeedbackInfo.FeedbackContent = Utility.HtmlEncode(text);
					gameFeedbackInfo.FeedbackTitle = "";
					gameFeedbackInfo.ClientIP = GameRequest.GetUserIP();
					Message message = FacadeManage.aideNativeWebFacade.PublishFeedback(gameFeedbackInfo, accouts);
					if (message.Success)
					{
						base.ShowAndRedirect("感谢您的问题反馈，我们将尽快给予回复，敬请留意！", "/Mobile/Feedback.aspx");
					}
					else
					{
						base.Show(message.Content);
					}
				}
			}
		}
	}
}
