using Game.Entity.Accounts;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Web.UI;
namespace Game.Web
{
    public partial class SyncLogin : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			int queryInt = GameRequest.GetQueryInt("userid", 0);
			string queryString = GameRequest.GetQueryString("signature");
			string queryString2 = GameRequest.GetQueryString("time");
			string queryString3 = GameRequest.GetQueryString("url");
			if (queryInt == 0)
			{
				base.Response.Redirect(queryString3);
			}
			else
			{
				UserTicketInfo userCookie = Fetch.GetUserCookie();
				if (userCookie != null && userCookie.UserID == queryInt)
				{
					base.Response.Redirect(queryString3);
				}
				else
				{
					Message userGlobalInfo = FacadeManage.aideAccountsFacade.GetUserGlobalInfo(queryInt, 0, "");
					if (!userGlobalInfo.Success)
					{
						base.Response.Redirect(queryString3);
					}
					else
					{
						UserInfo userInfo = userGlobalInfo.EntityList[0] as UserInfo;
						if (userInfo == null)
						{
							base.Response.Redirect(queryString3);
						}
						else
						{
							if (string.IsNullOrEmpty(userInfo.DynamicPass.Trim()))
							{
								base.Response.Redirect(queryString3);
							}
							else
							{
								string text = queryInt.ToString() + userInfo.DynamicPass + queryString2.ToString() + AppConfig.SyncLoginKey;
								string text2 = Utility.MD5(text);
								if (queryString != text2)
								{
									FileManager.WriteFile(base.Server.MapPath("/Log/1.txt"), string.Format("md5Str={0}&webSignature={1}&signature={2}&UserID={3}\n", new object[]
									{
										text,
										text2,
										queryString,
										queryInt
									}), true);
									base.Response.Redirect(queryString3);
								}
								else
								{
									System.DateTime t = userInfo.DynamicPassTime.AddMilliseconds(System.Convert.ToDouble(queryString2) + System.Convert.ToDouble(AppConfig.SyncUrlTimeOut));
									if (t < System.DateTime.Now)
									{
										base.Response.Redirect(queryString3);
									}
									else
									{
										Fetch.SetUserCookie(userInfo.ToUserTicketInfo());
										base.Response.Redirect(queryString3);
									}
								}
							}
						}
					}
				}
			}
		}
	}
}
