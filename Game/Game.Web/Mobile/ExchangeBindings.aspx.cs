using Game.Entity.Accounts;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Data;
using System.Web.UI;
namespace Game.Web.Mobile
{
    public partial class ExchangeBindings : System.Web.UI.Page
	{
		protected bool isBind;
		protected string msgInfo = "";
		protected void Page_Load(object sender, System.EventArgs e)
		{
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
				Message bankBindInfo = FacadeManage.aideAccountsFacade.GetBankBindInfo(queryInt);
				this.isBind = bankBindInfo.Success;
				if (bankBindInfo.Success)
				{
					if (bankBindInfo.EntityList == null || bankBindInfo.EntityList.Count <= 0)
					{
						this.msgInfo = "未绑定";
					}
					else
					{
						System.Data.DataSet dataSet = bankBindInfo.EntityList[0] as System.Data.DataSet;
						if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows[0]["BankNo"].ToString().Length >= 16)
						{
							this.msgInfo = dataSet.Tables[0].Rows[0]["BankNo"].ToString().Substring(0, 4) + "**********" + dataSet.Tables[0].Rows[0]["BankNo"].ToString().Substring(13);
						}
						else
						{
							this.msgInfo = "****************";
						}
					}
				}
				else
				{
					this.msgInfo = bankBindInfo.Content;
				}
			}
		}
	}
}
