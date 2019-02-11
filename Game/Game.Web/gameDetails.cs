using Game.Facade;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Game.Web
{
	public class gameDetails : System.Web.UI.Page
	{
		protected System.Data.DataTable dtGame;
		protected System.Web.UI.HtmlControls.HtmlForm form1;
		protected new Head Header;
		protected Notice Notice;
		protected Foot Foot;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.dtGame = FacadeManage.aideNativeWebFacade.GameRulesList(0);
			}
		}
	}
}
