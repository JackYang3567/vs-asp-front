using Game.Entity.Accounts;
using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Web;
namespace Game.Web.WS
{
	public class Lottery : System.Web.IHttpHandler
	{
		public bool IsReusable
		{
			get
			{
				return false;
			}
		}
		public void ProcessRequest(System.Web.HttpContext context)
		{
			context.Response.ContentType = "application/json";
			string text = GameRequest.GetQueryString("action").ToLower();
			string a;
			if ((a = text) != null)
			{
				if (a == "lotteryconfig")
				{
					this.LotteryConfig(context);
				}
				else
				{
					if (a == "lotteryuserinfo")
					{
						this.LotteryUserInfo(context);
					}
					else
					{
						if (a == "lotterystart")
						{
							this.LotteryStart(context);
						}
					}
				}
			}
		}
		protected void LotteryConfig(System.Web.HttpContext context)
		{
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			System.Collections.Generic.IList<LotteryItem> lotteryItem = FacadeManage.aideTreasureFacade.GetLotteryItem();
			ajaxJsonValid.AddDataItem("list", lotteryItem);
			ajaxJsonValid.SetValidDataValue(true);
			context.Response.Write(ajaxJsonValid.SerializeToJson());
		}
		protected void LotteryUserInfo(System.Web.HttpContext context)
		{
			int queryInt = GameRequest.GetQueryInt("userid", 0);
			string queryString = GameRequest.GetQueryString("signature");
			string queryString2 = GameRequest.GetQueryString("time");
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			Message message = new Message();
			message = FacadeManage.aideAccountsFacade.CheckUserSignature(queryInt, queryString2, queryString);
			if (!message.Success)
			{
				ajaxJsonValid.msg = message.Content;
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
			else
			{
				UserInfo userInfo = message.EntityList[0] as UserInfo;
				string logonPass = userInfo.LogonPass;
				message = FacadeManage.aideTreasureFacade.GetLotteryUserInfo(queryInt, logonPass);
				if (!message.Success)
				{
					ajaxJsonValid.msg = message.Content;
					context.Response.Write(ajaxJsonValid.SerializeToJson());
				}
				else
				{
					LotteryUserInfo value = message.EntityList[0] as LotteryUserInfo;
					ajaxJsonValid.AddDataItem("list", value);
					ajaxJsonValid.SetValidDataValue(true);
					context.Response.Write(ajaxJsonValid.SerializeToJson());
				}
			}
		}
		protected void LotteryStart(System.Web.HttpContext context)
		{
			int queryInt = GameRequest.GetQueryInt("userid", 0);
			string queryString = GameRequest.GetQueryString("signature");
			string queryString2 = GameRequest.GetQueryString("time");
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			Message message = new Message();
			message = FacadeManage.aideAccountsFacade.CheckUserSignature(queryInt, queryString2, queryString);
			if (!message.Success)
			{
				ajaxJsonValid.msg = message.Content;
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
			else
			{
				UserInfo userInfo = message.EntityList[0] as UserInfo;
				string logonPass = userInfo.LogonPass;
				message = FacadeManage.aideTreasureFacade.GetLotteryStart(queryInt, logonPass, Utility.UserIP);
				if (!message.Success)
				{
					ajaxJsonValid.msg = message.Content;
					context.Response.Write(ajaxJsonValid.SerializeToJson());
				}
				else
				{
					LotteryReturn value = message.EntityList[0] as LotteryReturn;
					ajaxJsonValid.AddDataItem("list", value);
					ajaxJsonValid.SetValidDataValue(true);
					context.Response.Write(ajaxJsonValid.SerializeToJson());
				}
			}
		}
	}
}
