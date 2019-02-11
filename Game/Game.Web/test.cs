using Game.Facade;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Game.Web
{
	public class test : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlForm form1;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
			NameValueCollection form = System.Web.HttpContext.Current.Request.Form;
			foreach (string text in form)
			{
				dictionary.Add(text, form[text]);
			}
			base.Response.Write(JsonHelper.SerializeObject(dictionary));
		}
		public System.DateTime NewDate(long timestamp)
		{
			System.DateTime dateTime = new System.DateTime(1970, 1, 1, 8, 0, 0, 0);
			long ticks = dateTime.Ticks + timestamp * 10000L;
			return new System.DateTime(ticks);
		}
	}
}
