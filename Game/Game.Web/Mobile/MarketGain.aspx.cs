using Game.Entity.Accounts;
using Game.Entity.NativeWeb;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Web;
using System.Web.UI;
namespace Game.Web.Mobile
{
	public partial class MarketGain : System.Web.UI.Page
	{
		protected int id;
		protected string url = "";
		protected void Page_Load(object sender, System.EventArgs e)
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
			ConfigInfo configInfo = new ConfigInfo();
			if (System.Web.HttpRuntime.Cache["configInfo"] == null)
			{
				configInfo = FacadeManage.aideNativeWebFacade.GetConfigInfo("ShareConfig");
				if (configInfo != null)
				{
					CacheHelper.AddCache("configInfo", configInfo);
				}
			}
			else
			{
				configInfo = (System.Web.HttpRuntime.Cache["configInfo"] as ConfigInfo);
			}
			if (configInfo.Field6 != "")
			{
				this.url = string.Concat(new object[]
				{
					"http://",
					userTicketInfo.GameID,
					".",
					configInfo.Field6
				});
			}
			else
			{
				string host = base.Request.Url.Host;
				string[] array = host.Split(new char[]
				{
					'.'
				});
				if (array.Length == 3)
				{
					this.url = string.Concat(new object[]
					{
						"http://",
						userTicketInfo.GameID,
						".",
						array[1],
						".",
						array[2]
					});
				}
				else
				{
					if (array.Length == 2)
					{
						this.url = string.Concat(new object[]
						{
							"http://",
							userTicketInfo.GameID,
							".",
							host
						});
					}
					else
					{
						this.url = "http://" + host;
					}
				}
			}
		}
	}
}
