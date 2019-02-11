using Game.Facade;
using Game.Utils;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Game.Web.Mobile
{
    public partial class AdsNotice : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Literal ltlNotice;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.ltlNotice.Text = FacadeManage.aideNativeWebFacade.GetGameNotice("游戏公告").Replace("/Content/Upload", ApplicationSettings.Get("fileUrl"));
			}
		}
	}
}
