using Game.Entity.Accounts;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Game.Web.Mobile
{
	public partial class Exchange : System.Web.UI.Page
	{
		protected int UId;
		protected string account = "";
		protected string insure = "";
		protected string name = "";
		public string InsurePass = "";
		protected string BalancePrice = "0";
		protected string MinBalance = "0";
		protected string MinCounterFee = "0";
		protected double CounterFee;
		protected int isBind;
		protected System.Web.UI.HtmlControls.HtmlForm form1;
		protected System.Web.UI.HtmlControls.HtmlInputText dwScore;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!base.IsPostBack)
			{
				int queryInt = GameRequest.GetQueryInt("userid", 0);
				this.UId = queryInt;
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
				if (!bankBindInfo.Success)
				{
					Log.Write(bankBindInfo.Content, "tixian");
				}
				else
				{
					this.isBind = 1;
					System.Data.DataSet dataSet = (bankBindInfo.EntityList != null && bankBindInfo.EntityList.Count > 0) ? (bankBindInfo.EntityList[0] as System.Data.DataSet) : null;
					if (dataSet != null && dataSet.Tables.Count > 0)
					{
						System.Data.DataTable dataTable = dataSet.Tables[0];
						this.name = dataTable.Rows[0]["Compellation"].ToString();
						string text = dataTable.Rows[0]["BankNo"].ToString();
						if (!string.IsNullOrEmpty(text) && text.Length >= 16)
						{
							this.account = text.Substring(0, 4) + "**********" + text.Substring(13);
						}
						this.insure = dataTable.Rows[0]["InsureScore"].ToString();
					}
					CashSetting cashSetting = FacadeManage.aideAccountsFacade.PlayerCashInfo();
					if (cashSetting != null)
					{
						this.BalancePrice = cashSetting.BalancePrice.ToString();
						this.MinBalance = cashSetting.MinBalance.ToString();
						this.MinCounterFee = cashSetting.MinCounterFee.ToString();
						this.CounterFee = cashSetting.CounterFee * 100.0;
					}
				}
			}
		}
	}
}
