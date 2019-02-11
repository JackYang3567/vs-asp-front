using System;
using System.Web.UI;
namespace Game.Web.Pay.WX
{
	public partial class notify_url : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			ResultNotify resultNotify = new ResultNotify(this);
			resultNotify.ProcessNotify();
		}
	}
}
