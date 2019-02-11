using System;
using System.Web.UI;
namespace Game.Web.UserService
{
	public partial class UserService4 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			base.Response.Redirect("/Pay/Index.aspx");
		}
	}
}
