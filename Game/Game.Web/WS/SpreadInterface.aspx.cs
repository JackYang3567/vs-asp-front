using Game.Entity.Accounts;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Web.UI;
namespace Game.Web.WS
{
	public partial class SpreadInterface : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			string s = string.Empty;
			try
			{
				string name = base.Request["action"];
				object obj = base.GetType().InvokeMember(name, System.Reflection.BindingFlags.InvokeMethod, null, this, new object[0]);
				if (obj != null)
				{
					s = obj.ToString();
				}
			}
			catch (System.Exception ex)
			{
				s = ex.Message;
			}
			base.Response.Write(s);
			base.Response.End();
		}
		public string GetSpreadLevCfg()
		{
			System.Data.DataTable dataTable;
			if (base.Cache["SpreadLevCfg"] == null)
			{
				dataTable = FacadeManage.aideTreasureFacade.GetSpreadLevCfg();
				CacheHelper.AddCache("SpreadLevCfg", dataTable);
			}
			else
			{
				dataTable = (base.Cache["SpreadLevCfg"] as System.Data.DataTable);
			}
			return JsonHelper.SerializeObject(dataTable);
		}
		public string GetMySpread()
		{
			int @int = GameRequest.GetInt("userid", 0);
			string @string = GameRequest.GetString("signature");
			string string2 = GameRequest.GetString("time");
			string result;
			if (@int <= 0)
			{
				result = JsonHelper.SerializeObject(new
				{
					Code = 1,
					Msg = "参数错误"
				});
			}
			else
			{
				Message message = FacadeManage.aideAccountsFacade.CheckUserSignature(@int, string2, @string);
				if (!message.Success)
				{
					result = JsonHelper.SerializeObject(new
					{
						Code = 1,
						Msg = message.Content
					});
				}
				else
				{
					UserTicketInfo userCookie = Fetch.GetUserCookie();
					if (userCookie == null || userCookie.UserID != @int)
					{
						UserInfo userInfo = message.EntityList[0] as UserInfo;
						Fetch.SetUserCookie(userInfo.ToUserTicketInfo());
					}
					System.Data.DataTable mySpread = FacadeManage.aideTreasureFacade.GetMySpread(@int);
					result = JsonHelper.SerializeObject(new
					{
						Code = 0,
						Data = mySpread
					});
				}
			}
			return result;
		}
		public string GetMyLowerMember()
		{
			int @int = GameRequest.GetInt("userid", 0);
			string @string = GameRequest.GetString("signature");
			string string2 = GameRequest.GetString("time");
			int int2 = GameRequest.GetInt("pageIndex", 1);
			int int3 = GameRequest.GetInt("pageSize", 20);
			string result;
			if (@int <= 0)
			{
				result = JsonHelper.SerializeObject(new
				{
					Code = 1,
					Msg = "参数错误"
				});
			}
			else
			{
				Message message = FacadeManage.aideAccountsFacade.CheckUserSignature(@int, string2, @string);
				if (!message.Success)
				{
					result = JsonHelper.SerializeObject(new
					{
						Code = 1,
						Msg = message.Content
					});
				}
				else
				{
					PagerSet list = FacadeManage.aideTreasureFacade.GetList("(SELECT * FROM RYAgentDB.dbo.Fn_GetSpreadDowns(" + @int + ",0)) as tab", int2, int3, "Order By NowYj", "");
					System.Data.DataTable data = list.PageSet.Tables[0];
					result = JsonHelper.SerializeObject(new
					{
						Code = 0,
						Data = data,
						Total = list.RecordCount
					});
				}
			}
			return result;
		}
		public string GetMyLowerAgent()
		{
			int @int = GameRequest.GetInt("userid", 0);
			string @string = GameRequest.GetString("signature");
			string string2 = GameRequest.GetString("time");
			int int2 = GameRequest.GetInt("pageIndex", 1);
			int int3 = GameRequest.GetInt("pageSize", 20);
			string result;
			if (@int <= 0)
			{
				result = JsonHelper.SerializeObject(new
				{
					Code = 1,
					Msg = "参数错误"
				});
			}
			else
			{
				Message message = FacadeManage.aideAccountsFacade.CheckUserSignature(@int, string2, @string);
				if (!message.Success)
				{
					result = JsonHelper.SerializeObject(new
					{
						Code = 1,
						Msg = message.Content
					});
				}
				else
				{
					PagerSet list = FacadeManage.aideTreasureFacade.GetList("(SELECT * FROM RYAgentDB.dbo.Fn_GetSpreadDowns(" + @int + ",1)) as tab", int2, int3, "Order By NowYj", "");
					System.Data.DataTable data = list.PageSet.Tables[0];
					result = JsonHelper.SerializeObject(new
					{
						Code = 0,
						Data = data,
						Total = list.RecordCount
					});
				}
			}
			return result;
		}
		public string GetWithdrawals()
		{
			int @int = GameRequest.GetInt("userid", 0);
			string @string = GameRequest.GetString("signature");
			string string2 = GameRequest.GetString("time");
			int int2 = GameRequest.GetInt("pageIndex", 1);
			int int3 = GameRequest.GetInt("pageSize", 20);
			string result;
			if (@int <= 0)
			{
				result = JsonHelper.SerializeObject(new
				{
					Code = 1,
					Msg = "参数错误"
				});
			}
			else
			{
				Message message = FacadeManage.aideAccountsFacade.CheckUserSignature(@int, string2, @string);
				if (!message.Success)
				{
					result = JsonHelper.SerializeObject(new
					{
						Code = 1,
						Msg = message.Content
					});
				}
				else
				{
					PagerSet list = FacadeManage.aideTreasureFacade.GetList("(select * from RYAgentDB.dbo.T_SpreadBalance where  userid = " + @int + ") as tab", int2, int3, "Order By ID DESC", "");
					System.Data.DataTable data = list.PageSet.Tables[0];
					result = JsonHelper.SerializeObject(new
					{
						Code = 0,
						Data = data,
						Total = list.RecordCount
					});
				}
			}
			return result;
		}
		public string Balance()
		{
			int @int = GameRequest.GetInt("userid", 0);
			string result;
			if (@int <= 0)
			{
				result = JsonHelper.SerializeObject(new
				{
					Code = 1,
					Msg = "参数错误"
				});
			}
			else
			{
				UserTicketInfo userCookie = Fetch.GetUserCookie();
				if (userCookie == null || userCookie.UserID != @int)
				{
					result = JsonHelper.SerializeObject(new
					{
						Code = 1,
						Msg = "已超时，请从大厅重新操作"
					});
				}
				else
				{
					double num = System.Convert.ToDouble(base.Request["rtnFee"]);
					if (num <= 0.0)
					{
						result = JsonHelper.SerializeObject(new
						{
							Code = 1,
							Msg = "提现金额必须大于0"
						});
					}
					else
					{
						System.Collections.Generic.Dictionary<string, object> dictionary = new System.Collections.Generic.Dictionary<string, object>();
						dictionary["dwUserID"] = @int;
						dictionary["strOrderID"] = PayHelper.GetOrderIDByPrefix("tg");
						dictionary["dwRtnFee"] = num;
						dictionary["strClientIP"] = GameRequest.GetUserIP();
						dictionary["strErr"] = "";
						Message message = FacadeManage.aideAccountsFacade.ExcuteByProce("RYAgentDB.dbo.P_SpreadBalance", dictionary);
						if (message.Success)
						{
							result = JsonHelper.SerializeObject(new
							{
								Code = 0,
								Msg = "提现申请成功，请等待处理！"
							});
						}
						else
						{
							result = JsonHelper.SerializeObject(new
							{
								Code = 1,
								Msg = message.Content
							});
						}
					}
				}
			}
			return result;
		}
	}
}
