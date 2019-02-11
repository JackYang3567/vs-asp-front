using Game.Entity.Accounts;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Data;
using System.Web.UI;
namespace Game.Web.WS
{
    public partial class Promoter : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			string text = GameRequest.GetFormString("action").ToLower();
			string a;
			if ((a = text) != null)
			{
				if (a == "userspreadinfo")
				{
					this.UserSpreadInfo();
				}
				else
				{
					if (a == "spreadbalance")
					{
						this.SpreadBalance();
					}
					else
					{
						if (a == "myspreadcheck")
						{
							this.MySpreadCheck();
						}
					}
				}
			}
		}
		protected void UserSpreadInfo()
		{
			UserTicketInfo userCookie = Fetch.GetUserCookie();
			if (userCookie == null)
			{
				base.Response.Write("{\"code\":-1,\"msg\":\"由于长时间未操作，请重新从大厅操作\"}");
				base.Response.End();
			}
			else
			{
				int formInt = GameRequest.GetFormInt("dtype", 0);
				System.Data.DataTable o = FacadeManage.aideAccountsFacade.MySpreadInfo(userCookie.UserID, formInt);
				string str = JsonHelper.SerializeObject(o);
				base.Response.Write("{\"code\":0,\"data\":" + str + "}");
				base.Response.End();
			}
		}
		protected void SpreadBalance()
		{
			UserTicketInfo userCookie = Fetch.GetUserCookie();
			if (userCookie == null)
			{
				base.Response.Write("{\"code\":-1,\"msg\":\"由于长时间未操作，请重新从大厅操作\"}");
				base.Response.End();
			}
			else
			{
				double num = System.Convert.ToDouble(base.Request.Form["gold"]);
				if (num <= 0.0)
				{
					base.Response.Write("{\"code\":1,\"msg\":\"提取金额错误\"}");
					base.Response.End();
				}
				else
				{
					Message message = FacadeManage.aideAccountsFacade.SpreadBalance(userCookie.UserID, num, GameRequest.GetUserIP());
					if (message.Success)
					{
						base.Response.Write("{\"code\":0}");
						base.Response.End();
					}
					else
					{
						base.Response.Write("{\"code\":1,\"msg\":\"" + message.Content + "\"}");
						base.Response.End();
					}
				}
			}
		}
		protected void MySpreadCheck()
		{
			int formInt = GameRequest.GetFormInt("id", 0);
			if (formInt <= 0)
			{
				base.Response.Write("{\"code\":-1,\"msg\":\"推广码只能为数字\"}");
				base.Response.End();
			}
			Message message = FacadeManage.aideAccountsFacade.MySpreadCheck(formInt);
			if (message.Success)
			{
				System.Data.DataSet dataSet = message.EntityList[0] as System.Data.DataSet;
				base.Response.Write("{\"code\":0,\"data\":" + JsonHelper.SerializeObject(dataSet.Tables[0]) + "}");
				base.Response.End();
			}
			else
			{
				base.Response.Write("{\"code\":-1,\"msg\":\"" + message.Content + "\"}");
				base.Response.End();
			}
		}
	}
}
