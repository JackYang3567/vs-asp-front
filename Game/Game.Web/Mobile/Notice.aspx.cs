using Game.Facade;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Game.Web.Mobile
{
    public partial class Notice : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Literal ltlNotice;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.ltlNotice.Text = FacadeManage.aideNativeWebFacade.GetGameNotice("登录公告");
			}
		}
	}
}
