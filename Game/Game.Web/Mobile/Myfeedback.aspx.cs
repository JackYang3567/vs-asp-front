using Game.Facade;
using System;
namespace Game.Web.Mobile
{
    public partial class Myfeedback : UCPageBase
	{
		protected override bool IsAuthenticatedUser
		{
			get
			{
				return true;
			}
		}
		protected void Page_Load(object sender, System.EventArgs e)
		{
		}
	}
}
