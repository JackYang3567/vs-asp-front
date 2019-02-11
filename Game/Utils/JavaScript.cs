using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Game.Utils
{
	public class JavaScript
	{
		public static void RegJs(Page page, string js, bool bottom)
		{
			if (bottom)
			{
				page.ClientScript.RegisterStartupScript(page.GetType(), new Random().Next(1000, 9999).ToString(), "<script type=\"text/javascript\" language=\"javascript\">" + js + "</script>");
				return;
			}
			page.ClientScript.RegisterClientScriptBlock(page.GetType(), new Random().Next(1000, 9999).ToString(), "<script type=\"text/javascript\" language=\"javascript\">" + js + "</script>");
		}
		public static void RegJs(Page page, string url)
		{
			HtmlGenericControl child = JavaScript.CreateGenericControl("script", new Dictionary<string, string>
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
		public static void RegJsToBottom(Page page, string url)
		{
			page.ClientScript.RegisterStartupScript(page.GetType(), new Random().Next().ToString(), "<script src='" + url + "' type='text/javascript'></script>");
		}
		protected static void Alert(string message, bool IsBack)
		{
			if (IsBack)
			{
				HttpContext.Current.Response.Write("<script language='javascript'>alert('" + message.Replace("'", "\\'") + "');history.back();</script>");
				return;
			}
			HttpContext.Current.Response.Write("<script language='javascript'>alert('" + message.Replace("'", "\\'") + "');</script>");
		}
		protected static void Alert(string message, string url)
		{
			HttpContext.Current.Response.Write(string.Concat(new string[]
			{
				"<script language='javascript'>alert('",
				message.Replace("'", "\\'"),
				"');location.href='",
				url,
				"';</script>"
			}));
		}
		public static HtmlGenericControl CreateGenericControl(string tagName, IDictionary<string, string> dic)
		{
			HtmlGenericControl htmlGenericControl = new HtmlGenericControl();
			htmlGenericControl.TagName = tagName;
			foreach (KeyValuePair<string, string> current in dic)
			{
				htmlGenericControl.Attributes.Add(current.Key, current.Value);
			}
			return htmlGenericControl;
		}
		public static HtmlLink CreateCssInclude(string cssUrl)
		{
			HtmlLink htmlLink = new HtmlLink();
			htmlLink.Href = cssUrl;
			htmlLink.Attributes.Add("type", "text/css");
			htmlLink.Attributes.Add("rel", "Stylesheet");
			return htmlLink;
		}
		public static HtmlMeta CreateMeta(IDictionary<string, string> dic)
		{
			HtmlMeta htmlMeta = new HtmlMeta();
			foreach (KeyValuePair<string, string> current in dic)
			{
				htmlMeta.Attributes.Add(current.Key, current.Value);
			}
			return htmlMeta;
		}
	}
}
