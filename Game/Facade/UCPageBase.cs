using Game.Entity.Accounts;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace Game.Facade
{
	public abstract class UCPageBase : Page
	{
		private const string SEPARATE_LINE = " - ";
		private bool m_isAuthenticatedUser;
		private bool m_isAuthenticatedMember;
		private bool m_isOnLine = Fetch.IsUserOnline();
		protected string LogonUrl;
		protected string RawUrl;
		protected string RedirectUrl;
		protected UserTicketInfo userTicket;
		private static string[] ALERT_STYLE_CLASS = new string[]
		{
			"ui-result-pic-1",
			"ui-result-success",
			"ui-result-pic-2",
			"ui-result-fail"
		};
		protected virtual bool IsAuthenticatedUser
		{
			get
			{
				return this.m_isAuthenticatedUser;
			}
		}
		protected virtual bool IsAuthenticatedMember
		{
			get
			{
				return this.m_isAuthenticatedMember;
			}
		}
		public virtual string ChannelTitle
		{
			get
			{
				return "首页";
			}
		}
		protected bool IsOnLine
		{
			get
			{
				return this.m_isOnLine;
			}
		}
		protected string action
		{
			get
			{
				return GameRequest.GetQueryString("action");
			}
		}
		protected int IntParam
		{
			get
			{
				return GameRequest.GetQueryInt("param", 0);
			}
		}
		protected string StrParam
		{
			get
			{
				return GameRequest.GetQueryString("param");
			}
		}
		protected int PageIndex
		{
			get
			{
				return GameRequest.GetQueryInt("page", 1);
			}
		}
		public virtual bool IsNotice
		{
			get
			{
				return true;
			}
		}
		public UCPageBase()
		{
			this.LogonUrl = "/Login.aspx";
			this.RawUrl = HttpUtility.UrlEncode(GameRequest.GetUrl());
			this.RedirectUrl = Utility.UrlDecode(GameRequest.GetQueryString("redirectUrl"));
		}
		protected override void OnInit(System.EventArgs e)
		{
			base.OnInit(e);
			if (Fetch.GetTerminalType(this.Page.Request) != 0 && !this.Page.Request.Url.AbsoluteUri.ToLower().Contains("mobile"))
			{
				base.Response.Redirect("/Mobile/Index.aspx");
			}
			if (this.IsAuthenticatedUser)
			{
				this.UserLogon();
			}
			else
			{
				if (this.IsOnLine)
				{
					this.userTicket = Fetch.GetUserCookie();
				}
			}
			this.SetStyle();
		}
		protected override void OnLoad(System.EventArgs e)
		{
			base.OnLoad(e);
			this.AddHeaderTitle();
			if (!this.Page.IsCallback && !this.Page.IsPostBack)
			{
				this.AddDefaultLanguages();
				this.OnInitLoad();
			}
		}
		protected override void OnPreRenderComplete(System.EventArgs e)
		{
			base.OnPreRenderComplete(e);
		}
		protected virtual void OnInitLoad()
		{
		}
		protected virtual void AddDefaultLanguages()
		{
			base.Response.AppendHeader("Content-Style-Type", "text/css");
			base.Response.AppendHeader("Content-Script-Type", "text/javascript");
		}
		protected virtual void AddHeaderTitle()
		{
			this.AddMetaTitle(ApplicationSettings.Get("title"));
		}
		protected virtual void AddMetaTitle(string content)
		{
			if (content == "")
			{
				return;
			}
			HtmlTitle htmlTitle = new HtmlTitle();
			htmlTitle.Text = content;
			this.Page.Header.Controls.Add(htmlTitle);
		}
		protected virtual void AddMetaTag(string name, string value)
		{
			if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(value))
			{
				return;
			}
			HtmlMeta htmlMeta = new HtmlMeta();
			htmlMeta.Name = name;
			htmlMeta.Content = value;
			this.Page.Header.Controls.Add(htmlMeta);
		}
		protected virtual void AddMetaTagForHttpEquiv(string httpEquiv, string content)
		{
			if (string.IsNullOrEmpty(httpEquiv) || string.IsNullOrEmpty(content))
			{
				return;
			}
			HtmlMeta htmlMeta = new HtmlMeta();
			htmlMeta.HttpEquiv = httpEquiv;
			htmlMeta.Content = content;
			this.Page.Header.Controls.Add(htmlMeta);
		}
		public virtual void AddGenericLink(string relation, string title, string href)
		{
			HtmlLink htmlLink = new HtmlLink();
			htmlLink.Attributes["rel"] = relation;
			htmlLink.Attributes["title"] = title;
			htmlLink.Attributes["href"] = href;
			this.Page.Header.Controls.Add(htmlLink);
		}
		public virtual void AddGenericLink(string type, string relation, string title, string href)
		{
			HtmlLink htmlLink = new HtmlLink();
			htmlLink.Attributes["type"] = type;
			htmlLink.Attributes["rel"] = relation;
			htmlLink.Attributes["title"] = title;
			htmlLink.Attributes["href"] = href;
			this.Page.Header.Controls.Add(htmlLink);
		}
		public virtual void AddJavaScriptInclude(string url)
		{
			HtmlGenericControl htmlGenericControl = new HtmlGenericControl("script");
			htmlGenericControl.Attributes["type"] = "text/javascript";
			htmlGenericControl.Attributes["src"] = url;
			this.Page.Header.Controls.Add(htmlGenericControl);
		}
		public virtual void AddStylesheetInclude(string url)
		{
			HtmlLink htmlLink = new HtmlLink();
			htmlLink.Attributes["type"] = "text/css";
			htmlLink.Attributes["href"] = url;
			htmlLink.Attributes["rel"] = "stylesheet";
			htmlLink.Attributes["media"] = "screen";
			this.Page.Header.Controls.Add(htmlLink);
		}
		protected virtual void AddMetaDescription(string description)
		{
			this.AddMetaTag("description", HttpUtility.HtmlEncode(description));
		}
		protected virtual void AddMetaKeywords(string keywords)
		{
			this.AddMetaTag("keywords", HttpUtility.HtmlEncode(keywords));
		}
		protected virtual void AddMetaClearCache()
		{
			this.AddMetaTagForHttpEquiv("Pragma", "no-cache");
			this.AddMetaTagForHttpEquiv("Cache-Control", "no-cache");
			this.AddMetaTagForHttpEquiv("Expires", "0");
			Utility.ClearPageClientCache();
		}
		protected virtual void Redirect(string url)
		{
			base.Response.Redirect(url);
			base.Response.End();
		}
		protected virtual void RedirectAndValidUrl(string url)
		{
			string url2 = string.Format("{0}&RedirectUrl={1}", url, Utility.UrlEncode(this.RawUrl));
			this.Redirect(url2);
		}
		protected virtual void RedirectByClient(string url)
		{
		}
		protected virtual UserInfo GetCurrentUser()
		{
			return FacadeManage.aideAccountsFacade.GetUserBaseInfoByUserID(this.userTicket.UserID);
		}
		public string GetAccountsByUserID(int userID)
		{
			UserInfo userBaseInfoByUserID = FacadeManage.aideAccountsFacade.GetUserBaseInfoByUserID(userID);
			if (userBaseInfoByUserID == null)
			{
				return "";
			}
			return userBaseInfoByUserID.Accounts;
		}
		public string GetGameIDByUserID(int userID)
		{
			UserInfo userBaseInfoByUserID = FacadeManage.aideAccountsFacade.GetUserBaseInfoByUserID(userID);
			if (userBaseInfoByUserID == null)
			{
				return "";
			}
			return userBaseInfoByUserID.GameID.ToString();
		}
		public string GetNickNameByUserID(int userID)
		{
			return FacadeManage.aideAccountsFacade.GetNickNameByUserID(userID);
		}
		protected virtual void UserLogon()
		{
			if (Fetch.IsUserOnline())
			{
				this.userTicket = Fetch.GetUserCookie();
				if (this.IsAuthenticatedMember)
				{
					this.IsMember();
					return;
				}
			}
			else
			{
				this.ReLogon();
			}
		}
		protected virtual void ReLogon()
		{
			string url = string.Format("{0}?url={1}", this.LogonUrl, this.RawUrl);
			this.Redirect(url);
		}
		protected virtual void IsMember()
		{
			UserInfo userBaseInfoByUserID = FacadeManage.aideAccountsFacade.GetUserBaseInfoByUserID(this.userTicket.UserID);
			if (userBaseInfoByUserID == null || userBaseInfoByUserID.MasterOrder == 0)
			{
				this.ShowAndRedirect("会员功能页面，欢迎充值成为会员！", "CardSelect.aspx");
			}
		}
		protected virtual bool IsApplyProtection()
		{
			UserInfo userBaseInfoByUserID = FacadeManage.aideAccountsFacade.GetUserBaseInfoByUserID(this.userTicket.UserID);
			return userBaseInfoByUserID.ProtectID > 0;
		}
		protected virtual bool IsApplyProtection(string strUserID, out AccountsProtect protectInfo)
		{
			int userID = TypeParse.StrToInt(CWHEncryptNet.XorCrevasse(strUserID), 0);
			return this.IsApplyProtection(userID, out protectInfo);
		}
		protected virtual bool IsApplyProtection(int userID, out AccountsProtect protectInfo)
		{
			protectInfo = null;
			if (userID <= 0)
			{
				return false;
			}
			Message userSecurityByUserID = FacadeManage.aideAccountsFacade.GetUserSecurityByUserID(userID);
			if (userSecurityByUserID == null || !userSecurityByUserID.Success)
			{
				return false;
			}
			protectInfo = (userSecurityByUserID.EntityList[0] as AccountsProtect);
			return protectInfo.ProtectID > 0;
		}
		public string GetMemberInfo(byte memberOrder)
		{
			string result;
			switch (memberOrder)
			{
			case 0:
				result = "普通用户";
				break;
			case 1:
				result = "<img src=\"/images/vip_lv/vip_1.png\" />";
				break;
			case 2:
				result = "<img src=\"/images/vip_lv/vip_2.png\" />";
				break;
			case 3:
				result = "<img src=\"/images/vip_lv/vip_3.png\" />";
				break;
			case 4:
				result = "<img src=\"/images/vip_lv/vip_4.png\" />";
				break;
			case 5:
				result = "<img src=\"/images/vip_lv/vip_5.png\" />";
				break;
			default:
				result = "普通用户";
				break;
			}
			return result;
		}
		public void Show(string msg)
		{
			this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "message", "<script type='text/javascript'>alert('" + msg.ToString() + "');</script>");
		}
		public static void ShowConfirm(WebControl Control, string msg)
		{
			Control.Attributes.Add("onclick", "return confirm('" + msg + "');");
		}
		public void ShowAndRedirect(string msg, string url)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("<script language='javascript' defer>");
			stringBuilder.AppendFormat("alert('{0}');", msg);
			stringBuilder.AppendFormat("top.location.href='{0}'", url);
			stringBuilder.Append("</script>");
			this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "message", stringBuilder.ToString());
		}
		public virtual void RenderAlertInfo(bool isError, string alertText, int step)
		{
			bool flag = this.SwitchStep(step);
			if (flag)
			{
				Label label = this.FindControl("lblAlertIcon") as Label;
				Label label2 = this.FindControl("lblAlertInfo") as Label;
				if (label != null && label2 != null)
				{
					if (isError)
					{
						label.CssClass = UCPageBase.ALERT_STYLE_CLASS[2];
						label2.CssClass = UCPageBase.ALERT_STYLE_CLASS[3];
						label2.Text = alertText;
						return;
					}
					label.CssClass = UCPageBase.ALERT_STYLE_CLASS[0];
					label2.CssClass = UCPageBase.ALERT_STYLE_CLASS[1];
					label2.Text = alertText;
				}
			}
		}
		public virtual void RenderAlertInfo2(bool isError, string alertText)
		{
			this.RenderAlertInfo(isError, alertText, 2);
		}
		public virtual void RenderAlertInfo3(bool isError, string alertText)
		{
			this.RenderAlertInfo(isError, alertText, 3);
		}
		public virtual bool SwitchStep(int moveStep)
		{
			Control control = this.FindControl("pnlStep1");
			Control control2 = this.FindControl("pnlStep2");
			Control control3 = this.FindControl("pnlStep3");
			if (control == null)
			{
				control = this.FindControl("phStep1");
			}
			if (control2 == null)
			{
				control2 = this.FindControl("phStep2");
			}
			if (control3 == null)
			{
				control3 = this.FindControl("phStep3");
			}
			if (control == null)
			{
				control = this.FindControl("fmStep1");
			}
			if (control2 == null)
			{
				control2 = this.FindControl("fmStep2");
			}
			if (control3 == null)
			{
				control3 = this.FindControl("fmStep3");
			}
			bool result = false;
			if (control != null)
			{
				result = true;
				control.Visible = (moveStep == 1 || moveStep == 0);
			}
			if (control2 != null)
			{
				result = true;
				control2.Visible = (moveStep == 2);
			}
			if (control3 != null)
			{
				result = true;
				control3.Visible = (moveStep == 3);
			}
			return result;
		}
		private void SetStyle()
		{
			if (base.Header != null)
			{
				this.RegJs(this, "/js/Common.js");
			}
		}
		public void RegJs(Page page, string url)
		{
			HtmlGenericControl child = this.CreateGenericControl("script", new System.Collections.Generic.Dictionary<string, string>
			{

				{
					"type",
					"text/javascript"
				},

				{
					"src",
					url
				}
			});
			page.Header.Controls.Add(child);
		}
		public HtmlGenericControl CreateGenericControl(string tagName, System.Collections.Generic.IDictionary<string, string> dic)
		{
			HtmlGenericControl htmlGenericControl = new HtmlGenericControl();
			htmlGenericControl.TagName = tagName;
			foreach (System.Collections.Generic.KeyValuePair<string, string> current in dic)
			{
				htmlGenericControl.Attributes.Add(current.Key, current.Value);
			}
			return htmlGenericControl;
		}
		public static int StrDateDiffDays(System.DateTime date)
		{
			System.TimeSpan timeSpan = System.DateTime.Now - date;
			if (timeSpan.TotalDays > 2147483647.0)
			{
				return 2147483647;
			}
			if (timeSpan.TotalSeconds < -2147483648.0)
			{
				return -2147483648;
			}
			return (int)timeSpan.TotalDays;
		}
		public static int StrDateDiffHours(string time, int hours)
		{
			if (time == "" || time == null)
			{
				return 1;
			}
			System.TimeSpan timeSpan = System.DateTime.Now - System.DateTime.Parse(time).AddHours((double)hours);
			if (timeSpan.TotalHours > 2147483647.0)
			{
				return 2147483647;
			}
			if (timeSpan.TotalHours < -2147483648.0)
			{
				return -2147483648;
			}
			return (int)timeSpan.TotalHours;
		}
		public static int StrDateDiffMinutes(string time, int minutes)
		{
			if (time == "" || time == null)
			{
				return 1;
			}
			System.TimeSpan timeSpan = System.DateTime.Now - System.DateTime.Parse(time).AddMinutes((double)minutes);
			if (timeSpan.TotalMinutes > 2147483647.0)
			{
				return 2147483647;
			}
			if (timeSpan.TotalMinutes < -2147483648.0)
			{
				return -2147483648;
			}
			return (int)timeSpan.TotalMinutes;
		}
		public static int StrDateDiffSeconds(string time, int sec)
		{
			System.TimeSpan timeSpan = System.DateTime.Now - System.DateTime.Parse(time).AddSeconds((double)sec);
			if (timeSpan.TotalSeconds > 2147483647.0)
			{
				return 2147483647;
			}
			if (timeSpan.TotalSeconds < -2147483648.0)
			{
				return -2147483648;
			}
			return (int)timeSpan.TotalSeconds;
		}
		public static string FormatDateSpan(object dateSpan)
		{
			System.DateTime d = (System.DateTime)dateSpan;
			System.TimeSpan timeSpan = System.DateTime.Now - d;
			if (timeSpan.TotalDays >= 365.0)
			{
				return string.Format("{0} 年前", (int)(timeSpan.TotalDays / 365.0));
			}
			if (timeSpan.TotalDays >= 30.0)
			{
				return string.Format("{0} 月前", (int)(timeSpan.TotalDays / 30.0));
			}
			if (timeSpan.TotalDays > 7.0 && timeSpan.TotalDays / 7.0 <= 4.0)
			{
				return string.Format("{0} 周前", (int)(timeSpan.TotalDays / 7.0));
			}
			if (timeSpan.TotalDays >= 1.0)
			{
				return string.Format("{0} 天前", (int)timeSpan.TotalDays);
			}
			if (timeSpan.TotalHours >= 1.0)
			{
				return string.Format("{0} 小时前", (int)timeSpan.TotalHours);
			}
			if (timeSpan.TotalMinutes >= 1.0)
			{
				return string.Format("{0} 分钟前", (int)timeSpan.TotalMinutes);
			}
			return "1 分钟前";
		}
		public string EncryptMD5(string text, bool isLower, int bit)
		{
			string text2 = string.Empty;
			if (bit != 32 && bit != 16)
			{
				return text2;
			}
			if (bit == 32)
			{
				System.Security.Cryptography.MD5 mD = System.Security.Cryptography.MD5.Create();
				byte[] array = mD.ComputeHash(System.Text.Encoding.UTF8.GetBytes(text));
				for (int i = 0; i < array.Length; i++)
				{
					text2 += array[i].ToString("X");
				}
			}
			else
			{
				System.Security.Cryptography.MD5CryptoServiceProvider mD5CryptoServiceProvider = new System.Security.Cryptography.MD5CryptoServiceProvider();
				text2 = System.BitConverter.ToString(mD5CryptoServiceProvider.ComputeHash(System.Text.Encoding.Default.GetBytes(text)), 4, 8);
				text2 = text2.Replace("-", "");
			}
			if (isLower)
			{
				text2 = text2.ToLower();
			}
			return text2;
		}
		public string GetChinaString(long num)
		{
			string result = num.ToString();
			if (num.ToString().Length == 7)
			{
				result = (System.Convert.ToDecimal(num) / 1000000m).ToString("f2") + "百万";
			}
			if (num.ToString().Length == 8)
			{
				result = (System.Convert.ToDecimal(num) / 10000000m).ToString("f2") + "千万";
			}
			if (num.ToString().Length == 9)
			{
				result = (System.Convert.ToDecimal(num) / 100000000m).ToString("f2") + "亿";
			}
			if (num.ToString().Length == 10)
			{
				result = (System.Convert.ToDecimal(num) / 1000000000m).ToString("f2") + "十亿";
			}
			if (num.ToString().Length == 11)
			{
				result = (System.Convert.ToDecimal(num) / new decimal(10000000000L)).ToString("f2") + "百亿";
			}
			if (num.ToString().Length == 12)
			{
				result = (System.Convert.ToDecimal(num) / new decimal(100000000000L)).ToString("f2") + "千亿";
			}
			if (num.ToString().Length == 13)
			{
				result = (System.Convert.ToDecimal(num) / new decimal(1000000000000L)).ToString("f2") + "万亿";
			}
			return result;
		}
	}
}
