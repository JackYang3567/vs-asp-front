using Game.Entity.NativeWeb;
using Game.Facade;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Game.Web.m
{
    public partial class service : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlForm form1;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
			if (System.Web.HttpRuntime.Cache["kefu"] == null)
			{
				ConfigInfo configInfo = FacadeManage.aideNativeWebFacade.GetConfigInfo(AppConfig.SiteConfigKey.ContactConfig.ToString());
				if (configInfo != null)
				{
					dictionary["kefu53"] = configInfo.Field4;
					dictionary["kefuinfo"] = configInfo.Field5;
					CacheHelper.AddCache("kefu", dictionary);
				}
			}
			else
			{
				dictionary = (System.Web.HttpRuntime.Cache["kefu"] as System.Collections.Generic.Dictionary<string, string>);
			}
			string text = dictionary["kefu53"];
			string arg_91_0 = dictionary["kefuinfo"];
			if (text != "")
			{
				base.Response.Redirect(text);
			}
		}
	}
}
