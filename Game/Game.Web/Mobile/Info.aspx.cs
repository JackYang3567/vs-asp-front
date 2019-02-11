using Game.Entity.NativeWeb;
using Game.Facade;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Game.Web.Mobile
{
	public partial class Info : System.Web.UI.Page
	{
		public int terminalType;
		public GameRulesInfo model;
		protected System.Web.UI.WebControls.Repeater rptMoblieGame;
		protected System.Web.UI.WebControls.Panel plNotData;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			int queryInt = GameRequest.GetQueryInt("id", 0);
			if (queryInt == 0)
			{
				base.Response.Redirect("/404.html");
			}
			this.model = FacadeManage.aideNativeWebFacade.GetGameHelp(queryInt);
			if (this.model == null)
			{
				base.Response.Redirect("/404.html");
			}
			this.model.HelpIntro = Utility.HtmlDecode(this.model.HelpIntro);
			this.terminalType = Fetch.GetTerminalType(this.Page.Request);
			this.BindMoblieGame(queryInt);
		}
		private void BindMoblieGame(int id)
		{
			System.Data.DataSet moblieGame = FacadeManage.aideNativeWebFacade.GetMoblieGame();
			if (moblieGame.Tables[0].Rows.Count > 0)
			{
				System.Collections.Generic.IList<GameRulesInfo> list = DataHelper.ConvertDataTableToObjects<GameRulesInfo>(moblieGame.Tables[0]);
				if (list.Count > 0)
				{
					System.Collections.Generic.IList<GameRulesInfo> list2 = (
						from e in list
						where e.KindID != id
						select e).ToList<GameRulesInfo>();
					if (list2.Count > 0)
					{
						this.rptMoblieGame.DataSource = list2;
						this.rptMoblieGame.DataBind();
						return;
					}
				}
				this.rptMoblieGame.Visible = false;
				this.plNotData.Visible = true;
			}
		}
	}
}
