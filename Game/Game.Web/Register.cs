using Game.Utils;
using System;
using System.Web.UI;
namespace Game.Web
{
	public class Register : System.Web.UI.Page
	{
		public string adid = "";
		public string adname = "";
		protected new Head Header;
		protected Notice Notice;
		protected Foot Foot;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			this.adname = GameRequest.GetString("adname");
			if (!string.IsNullOrEmpty(this.adname))
			{
				string a;
				if ((a = this.adname) != null)
				{
					if (a == "蛋蛋")
					{
						this.adid = GameRequest.GetString("pcid");
						return;
					}
					if (a == "蹦蹦")
					{
						this.adid = GameRequest.GetString("annalID");
						return;
					}
					if (a == "聚聚玩")
					{
						this.adid = GameRequest.GetString("jjwID");
						return;
					}
				}
				this.adid = "";
			}
		}
	}
}
