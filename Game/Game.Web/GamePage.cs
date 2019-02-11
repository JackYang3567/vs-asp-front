using Game.Facade;
using Game.Utils;
using System;
using System.Web.UI;
namespace Game.Web
{
	public class GamePage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			int @int = GameRequest.GetInt("PageID", 0);
			string sqlQuery = "Select ResponseUrl From GamePageItem(nolock) Where PageID=" + @int;
			object objectBySql = FacadeManage.aidePlatformFacade.GetObjectBySql(sqlQuery);
			if (objectBySql != null)
			{
				string url = objectBySql.ToString();
				base.Response.Redirect(url);
			}
		}
	}
}
