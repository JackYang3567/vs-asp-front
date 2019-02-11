using Game.Entity.NativeWeb;
using Game.Facade;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Game.Web
{
	public class index : System.Web.UI.Page
	{
		protected new Head Header;
		protected Notice Notice;
		protected System.Web.UI.WebControls.Repeater rptData;
		protected System.Web.UI.WebControls.Literal ltlPhone;
		protected System.Web.UI.WebControls.Literal ltlQQ;
		protected System.Web.UI.WebControls.Literal ltlEmail;
		protected Foot Foot;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.rptData.DataSource = FacadeManage.aideNativeWebFacade.GetGameRulesList(10);
				this.rptData.DataBind();
				ConfigInfo configInfo = FacadeManage.aideNativeWebFacade.GetConfigInfo(AppConfig.SiteConfigKey.ContactConfig.ToString());
				if (configInfo != null)
				{
					this.ltlPhone.Text = configInfo.Field1;
					this.ltlQQ.Text = configInfo.Field2;
					this.ltlEmail.Text = configInfo.Field3;
				}
			}
		}
	}
}
