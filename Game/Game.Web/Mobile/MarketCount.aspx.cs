using Game.Entity.Accounts;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Data;
using System.Web.UI;
namespace Game.Web.Mobile
{
	public partial class MarketCount : System.Web.UI.Page
	{
		protected double tjone;
		protected double tjtwo;
		protected double tjthree;
		protected double tjfourth;
		protected double tjfive;
		protected int total;
		protected int zhijie;
		protected int jianjie;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (base.Request.Url.Host == "wwww.pyxpw.com")
			{
				base.Response.Redirect(base.Request.Url.ToString().Replace("wwww", "www"));
			}
			if (!base.IsPostBack)
			{
				int queryInt = GameRequest.GetQueryInt("userid", 0);
				UserTicketInfo userTicketInfo = Fetch.GetUserCookie();
				if (userTicketInfo == null || userTicketInfo.UserID != queryInt)
				{
					string queryString = GameRequest.GetQueryString("signature");
					string queryString2 = GameRequest.GetQueryString("time");
					Message message = FacadeManage.aideAccountsFacade.CheckUserSignature(queryInt, queryString2, queryString);
					if (!message.Success)
					{
						base.Response.Write(message.Content);
						base.Response.End();
					}
					UserInfo userInfo = message.EntityList[0] as UserInfo;
					userTicketInfo = userInfo.ToUserTicketInfo();
					Fetch.SetUserCookie(userTicketInfo);
				}
				System.Data.DataTable dataTable = FacadeManage.aideAccountsFacade.MyOwnSpreadCount(userTicketInfo.UserID);
				if (dataTable.Rows.Count > 0)
				{
					this.tjone = System.Convert.ToDouble(dataTable.Rows[0][0]);
					this.tjtwo = System.Convert.ToDouble(dataTable.Rows[0][1]);
					this.tjthree = System.Convert.ToDouble(dataTable.Rows[0][2]);
					this.tjfourth = System.Convert.ToDouble(dataTable.Rows[0][3]);
					this.tjfive = System.Convert.ToDouble(dataTable.Rows[0][4]);
				}
				this.zhijie = FacadeManage.aideAccountsFacade.GetZhiJie(userTicketInfo.UserID);
				this.jianjie = FacadeManage.aideAccountsFacade.GetJianJie(userTicketInfo.UserID);
				this.total = this.zhijie + this.jianjie;
			}
		}
	}
}
