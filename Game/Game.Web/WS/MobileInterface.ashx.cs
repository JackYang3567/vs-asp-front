using Game.Entity.Accounts;
using Game.Entity.NativeWeb;
using Game.Entity.Platform;
using Game.Entity.Treasure;
using Game.Facade;
using Game.Facade.DataStruct;
using Game.Kernel;
using Game.Utils;
using Game.Web.Pay.WX;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
namespace Game.Web.WS
{
	public class MobileInterface : System.Web.IHttpHandler
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
			string text2 = text;
			switch (text2)
			{
			case "getscorerank":
				this.GetScoreRank(context);
				break;
			case "getscorerank2":
				this.GetScoreRank2(context);
				break;
			case "getmobilefeedback":
				this.GetMobileFeedback(context);
				break;
			case "getmobilefaq":
				this.GetMobileFaq(context);
				break;
			case "getmobilenotice":
				this.GetMobileNotice(context);
				break;
			case "getmobilerollnotice":
				this.GetMobileRollNotice(context);
				break;
			case "getmobileloginnotice":
				this.GetMobileLoginNotice(context);
				break;
			case "getmobilepropertytype":
				this.GetMobilePropertyType(context);
				break;
			case "getmobileproperty":
				this.GetMobileProperty(context);
				break;
			case "getmobileshare":
				this.GetMobileShare(context);
				break;
			case "getmobileshareconfig":
				this.GetMobileShareConfig(context);
				break;
			case "getscoreinfo":
				this.GetScoreInfo(context);
				break;
			case "getpayrate":
				this.GetPayRate(context);
				break;
			case "getpayproduct":
				this.GetPayProduct(context);
				break;
			case "getpaylist":
				this.GetPayList(context);
				break;
			case "getagentpay":
				this.GetAgentPay(context);
				break;
			case "agentpayorder":
				this.AgentPayOrder(context);
				break;
			case "onlinecountlist":
				this.OnlineCountList(context);
				break;
			case "getpayconfig":
				this.GetPayConfig(context);
				break;
			case "creatpayorderid":
				this.CreatPayOrderID(context);
				break;
			case "getiosversion":
				this.GetIosVersion(context);
				break;
			case "getandriodversion":
				this.GetAndriodVersion(context);
				break;
			case "getorderrecord":
				this.GetOrderRecord(context);
				break;
			case "getpayrecord":
				this.GetPayRecord(context);
				break;
			case "getbankrecord":
				this.GetBankRecord(context);
				break;
			case "gettixianrecord":
				this.GetTixianRecord(context);
				break;
			case "getlotterynumberrank":
				this.GetLotteryNumberRank(context);
				break;
			case "getlotterywinrank":
				this.GetLotteryWinRank(context);
				break;
			case "getawardorderlist":
				this.GetAwardOrderList(context);
				break;
			case "getgamelist":
				this.GetGameList(context);
				break;
			case "getserverconfig":
				this.GetServerConfig(context);
				break;
			case "getagentchildlist":
				this.GetAgentChildList(context);
				break;
			case "getagentpaylist":
				this.GetAgentPayList(context);
				break;
			case "getagentpaybacklist":
				this.GetAgentPayBackList(context);
				break;
			case "getagentrevenuelist":
				this.GetAgentRevenueList(context);
				break;
			case "sendcode":
				this.SendCode(context);
				break;
			case "setpass":
				this.SetPass(context);
				break;
			case "bindphone":
				this.BindPhone(context);
				break;
			case "getcode":
				this.GetCode(context);
				break;
			}
		}
		protected void GetOrderRecord(System.Web.HttpContext context)
		{
			int queryInt = GameRequest.GetQueryInt("userid", 0);
			string queryString = GameRequest.GetQueryString("signature");
			string queryString2 = GameRequest.GetQueryString("time");
			int queryInt2 = GameRequest.GetQueryInt("number", 20);
			GameRequest.GetQueryInt("page", 1);
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			Message message = FacadeManage.aideAccountsFacade.CheckUserSignature(queryInt, queryString2, queryString);
			if (!message.Success)
			{
				ajaxJsonValid.msg = message.Content;
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
			else
			{
				string where = string.Format(" WHERE UserID={0}", queryInt);
				string orderBy = "ORDER By BuyDate DESC";
				PagerSet orderList = FacadeManage.aideNativeWebFacade.GetOrderList(1, queryInt2, where, orderBy);
				System.Collections.Generic.IList<MobileAwardOrder> list = null;
				if (orderList.RecordCount > 0)
				{
					list = DataHelper.ConvertDataTableToObjects<MobileAwardOrder>(orderList.PageSet.Tables[0]);
					for (int i = 0; i < list.Count<MobileAwardOrder>(); i++)
					{
						list[i].SolveNote = "";
						list[i].OrderStatusDescription = System.Enum.GetName(typeof(AppConfig.AwardOrderStatus), list[i].OrderStatus);
					}
				}
				ajaxJsonValid.AddDataItem("total", orderList.RecordCount);
				ajaxJsonValid.AddDataItem("list", list);
				ajaxJsonValid.SetValidDataValue(true);
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
		}
		protected void GetPayRecord(System.Web.HttpContext context)
		{
			int queryInt = GameRequest.GetQueryInt("userid", 0);
			string queryString = GameRequest.GetQueryString("signature");
			string queryString2 = GameRequest.GetQueryString("time");
			int queryInt2 = GameRequest.GetQueryInt("number", 20);
			GameRequest.GetQueryInt("page", 1);
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			Message message = FacadeManage.aideAccountsFacade.CheckUserSignature(queryInt, queryString2, queryString);
			if (!message.Success)
			{
				ajaxJsonValid.msg = message.Content;
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
			else
			{
				string whereQuery = string.Format(" WHERE UserID={0}", queryInt);
				string[] returnField = new string[]
				{
					"PayAmount",
					"Currency",
					"ApplyDate"
				};
				PagerSet payRecord = FacadeManage.aideTreasureFacade.GetPayRecord(whereQuery, 1, queryInt2, returnField);
				System.Collections.Generic.IList<MobilePayRecordData> value = null;
				if (payRecord.RecordCount > 0)
				{
					value = DataHelper.ConvertDataTableToObjects<MobilePayRecordData>(payRecord.PageSet.Tables[0]);
				}
				ajaxJsonValid.AddDataItem("total", payRecord.RecordCount);
				ajaxJsonValid.AddDataItem("list", value);
				ajaxJsonValid.SetValidDataValue(true);
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
		}
		protected void GetBankRecord(System.Web.HttpContext context)
		{
			int queryInt = GameRequest.GetQueryInt("userid", 0);
			string queryString = GameRequest.GetQueryString("signature");
			string queryString2 = GameRequest.GetQueryString("time");
			int queryInt2 = GameRequest.GetQueryInt("number", 20);
			GameRequest.GetQueryInt("page", 1);
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			Message message = FacadeManage.aideAccountsFacade.CheckUserSignature(queryInt, queryString2, queryString);
			if (!message.Success)
			{
				ajaxJsonValid.msg = message.Content;
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
			else
			{
				string whereQuery = string.Format(" WHERE SourceUserID={0} OR TargetUserID={0} ", queryInt);
				PagerSet insureTradeRecord = FacadeManage.aideTreasureFacade.GetInsureTradeRecord(whereQuery, 1, queryInt2);
				System.Collections.Generic.IList<MobileRecordInsure> list = null;
				if (insureTradeRecord.RecordCount > 0)
				{
					list = DataHelper.ConvertDataTableToObjects<MobileRecordInsure>(insureTradeRecord.PageSet.Tables[0]);
					for (int i = 0; i < list.Count<MobileRecordInsure>(); i++)
					{
						if (list[i].TradeType == 1)
						{
							list[i].TradeTypeDescription = "银行存款";
							list[i].TransferAccounts = "";
						}
						else
						{
							if (list[i].TradeType == 2)
							{
								list[i].TradeTypeDescription = "银行取款";
								list[i].TransferAccounts = "";
							}
							else
							{
								if (list[i].SourceUserID == queryInt)
								{
									list[i].SwapScore = -list[i].SwapScore;
									list[i].TradeTypeDescription = "银行转帐";
									list[i].TransferAccounts = FacadeManage.aideAccountsFacade.GetUserBaseInfoByUserID(list[i].TargetUserID).GameID.ToString();
								}
								else
								{
									list[i].TradeTypeDescription = "银行收款";
									list[i].TransferAccounts = FacadeManage.aideAccountsFacade.GetUserBaseInfoByUserID(list[i].SourceUserID).GameID.ToString();
								}
							}
						}
					}
				}
				ajaxJsonValid.AddDataItem("total", insureTradeRecord.RecordCount);
				ajaxJsonValid.AddDataItem("list", list);
				ajaxJsonValid.SetValidDataValue(true);
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
		}
		protected void GetTixianRecord(System.Web.HttpContext context)
		{
			int queryInt = GameRequest.GetQueryInt("userid", 0);
			string queryString = GameRequest.GetQueryString("signature");
			string queryString2 = GameRequest.GetQueryString("time");
			int queryInt2 = GameRequest.GetQueryInt("number", 20);
			int queryInt3 = GameRequest.GetQueryInt("page", 1);
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			Message message = FacadeManage.aideAccountsFacade.CheckUserSignature(queryInt, queryString2, queryString);
			if (!message.Success)
			{
				ajaxJsonValid.msg = message.Content;
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
			else
			{
				string condition = string.Format(" WHERE ApplicantID={0} ", queryInt);
				string[] fields = new string[]
				{
					"OrderID",
					"SellMoney",
					"RejectReason",
					"Status",
					"ApplyDate"
				};
				PagerSet list = FacadeManage.aideAccountsFacade.GetList("ApplyOrder", queryInt3, queryInt2, condition, " ORDER BY ID DESC ", fields);
				System.Collections.Generic.IList<ApplyOrder> value = null;
				if (list.RecordCount > 0)
				{
					value = DataHelper.ConvertDataTableToObjects<ApplyOrder>(list.PageSet.Tables[0]);
				}
				ajaxJsonValid.AddDataItem("total", list.RecordCount);
				ajaxJsonValid.AddDataItem("list", value);
				ajaxJsonValid.SetValidDataValue(true);
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
		}
		protected void GetLotteryNumberRank(System.Web.HttpContext context)
		{
			GameRequest.GetQueryInt("kindid", 0);
			int queryInt = GameRequest.GetQueryInt("userID", 0);
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			System.Collections.Generic.IList<UserGameInfo> userGameWinMaxRank = FacadeManage.aideTreasureFacade.GetUserGameWinMaxRank(100, Fetch.GetDateID(System.DateTime.Now.AddDays(-1.0)));
			System.Collections.Generic.Dictionary<int, int> dictionary = new System.Collections.Generic.Dictionary<int, int>();
			if (userGameWinMaxRank != null)
			{
				int num = userGameWinMaxRank.Count<UserGameInfo>();
				int num2 = 0;
				int num3 = 0;
				for (int i = 0; i < num; i++)
				{
					if (userGameWinMaxRank[i].LineGrandTotal != num3)
					{
						num2++;
						if (num2 > 20)
						{
							break;
						}
						num3 = userGameWinMaxRank[i].LineWinMax;
					}
					dictionary.Add(userGameWinMaxRank[i].UserID, num2);
				}
			}
			System.Collections.Generic.IList<UserGameInfo> userGameGrandTotalRank = FacadeManage.aideTreasureFacade.GetUserGameGrandTotalRank(100, Fetch.GetDateID(System.DateTime.Now));
			System.Collections.Generic.IList<UserGameInfoRank> listRank = new System.Collections.Generic.List<UserGameInfoRank>();
			int num4 = 0;
			if (userGameGrandTotalRank != null)
			{
				int num5 = userGameGrandTotalRank.Count<UserGameInfo>();
				int num6 = 0;
				int num7 = 0;
				int l;
				for (l = 0; l < num5; l++)
				{
					UserGameInfoRank userGameInfoRank = new UserGameInfoRank();
					if (userGameGrandTotalRank[l].LineGrandTotal != num7)
					{
						num6++;
						if (num6 > 20)
						{
							break;
						}
						num7 = userGameGrandTotalRank[l].LineWinMax;
					}
					userGameInfoRank.Ranking = num6;
					userGameInfoRank.LineGrandTotal = userGameGrandTotalRank[l].LineGrandTotal;
					userGameInfoRank.UserID = userGameGrandTotalRank[l].UserID;
					if (dictionary.Count > 0 && dictionary.Keys.Contains(userGameGrandTotalRank[l].UserID))
					{
						if (dictionary[userGameGrandTotalRank[l].UserID] < num6)
						{
							userGameInfoRank.Trend = 0;
						}
						else
						{
							if (dictionary[userGameGrandTotalRank[l].UserID] > num6)
							{
								userGameInfoRank.Trend = 1;
							}
							else
							{
								userGameInfoRank.Trend = 2;
							}
						}
					}
					else
					{
						userGameInfoRank.Trend = 0;
					}
					listRank.Add(userGameInfoRank);
				}
				l--;
				System.Collections.ArrayList arrayList = new System.Collections.ArrayList();
				for (int k = 0; k <= l; k++)
				{
					if (listRank[k].UserID == queryInt)
					{
						num4 = listRank[k].Ranking;
					}
					arrayList.Add(listRank[k].UserID);
				}
				System.Collections.Generic.IList<AccountsInfo> accountsInfoList = FacadeManage.aideAccountsFacade.GetAccountsInfoList(arrayList);
				if (accountsInfoList != null && accountsInfoList.Count > 0)
				{
					int j;
					for (j = 0; j <= l; j++)
					{
						AccountsInfo accountsInfo = (
							from e in accountsInfoList
							where e.UserID == listRank[j].UserID
							select e).FirstOrDefault<AccountsInfo>();
						if (accountsInfo != null)
						{
							listRank[j].NickName = accountsInfo.NickName;
							listRank[j].FaceID = (int)accountsInfo.FaceID;
							listRank[j].CustomID = accountsInfo.CustomID;
							listRank[j].Gender = (int)accountsInfo.Gender;
						}
					}
				}
			}
			ajaxJsonValid.AddDataItem("ranking", num4);
			ajaxJsonValid.AddDataItem("list", listRank);
			ajaxJsonValid.SetValidDataValue(true);
			context.Response.Write(ajaxJsonValid.SerializeToJson());
		}
		protected void GetLotteryWinRank(System.Web.HttpContext context)
		{
			int queryInt = GameRequest.GetQueryInt("kindid", 0);
			int queryInt2 = GameRequest.GetQueryInt("userID", 0);
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			if (queryInt == 0 || queryInt2 == 0)
			{
				ajaxJsonValid.msg = "缺少参数！";
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
			else
			{
				System.Collections.Generic.IList<UserGameInfo> userGameWinMaxRank = FacadeManage.aideTreasureFacade.GetUserGameWinMaxRank(100, Fetch.GetDateID(System.DateTime.Now.AddDays(-1.0)));
				System.Collections.Generic.Dictionary<int, int> dictionary = new System.Collections.Generic.Dictionary<int, int>();
				if (userGameWinMaxRank != null)
				{
					int num = userGameWinMaxRank.Count<UserGameInfo>();
					int num2 = 0;
					int num3 = 0;
					for (int i = 0; i < num; i++)
					{
						if (userGameWinMaxRank[i].LineGrandTotal != num3)
						{
							num2++;
							if (num2 > 20)
							{
								break;
							}
							num3 = userGameWinMaxRank[i].LineWinMax;
						}
						dictionary.Add(userGameWinMaxRank[i].UserID, num2);
					}
				}
				System.Collections.Generic.IList<UserGameInfo> userGameWinMaxRank2 = FacadeManage.aideTreasureFacade.GetUserGameWinMaxRank(100, Fetch.GetDateID(System.DateTime.Now));
				System.Collections.Generic.IList<UserGameInfoRank> listRank = new System.Collections.Generic.List<UserGameInfoRank>();
				int num4 = 0;
				if (userGameWinMaxRank2 != null)
				{
					int num5 = userGameWinMaxRank2.Count<UserGameInfo>();
					int num6 = 0;
					int num7 = 0;
					int l;
					for (l = 0; l < num5; l++)
					{
						UserGameInfoRank userGameInfoRank = new UserGameInfoRank();
						if (userGameWinMaxRank2[l].LineGrandTotal != num7)
						{
							num6++;
							if (num6 > 20)
							{
								break;
							}
							num7 = userGameWinMaxRank2[l].LineWinMax;
						}
						userGameInfoRank.Ranking = num6;
						userGameInfoRank.LineWinMax = userGameWinMaxRank2[l].LineWinMax;
						userGameInfoRank.UserID = userGameWinMaxRank2[l].UserID;
						if (dictionary.Count > 0 && dictionary.Keys.Contains(userGameWinMaxRank2[l].UserID))
						{
							if (dictionary[userGameWinMaxRank2[l].UserID] < num6)
							{
								userGameInfoRank.Trend = 0;
							}
							else
							{
								if (dictionary[userGameWinMaxRank2[l].UserID] > num6)
								{
									userGameInfoRank.Trend = 1;
								}
								else
								{
									userGameInfoRank.Trend = 2;
								}
							}
						}
						else
						{
							userGameInfoRank.Trend = 0;
						}
						listRank.Add(userGameInfoRank);
					}
					l--;
					System.Collections.ArrayList arrayList = new System.Collections.ArrayList();
					for (int k = 0; k <= l; k++)
					{
						if (listRank[k].UserID == queryInt2)
						{
							num4 = listRank[k].Ranking;
						}
						arrayList.Add(listRank[k].UserID);
					}
					System.Collections.Generic.IList<AccountsInfo> accountsInfoList = FacadeManage.aideAccountsFacade.GetAccountsInfoList(arrayList);
					if (accountsInfoList != null && accountsInfoList.Count > 0)
					{
						int j;
						for (j = 0; j <= l; j++)
						{
							AccountsInfo accountsInfo = (
								from e in accountsInfoList
								where e.UserID == listRank[j].UserID
								select e).FirstOrDefault<AccountsInfo>();
							if (accountsInfo != null)
							{
								listRank[j].NickName = accountsInfo.NickName;
								listRank[j].FaceID = (int)accountsInfo.FaceID;
								listRank[j].CustomID = accountsInfo.CustomID;
								listRank[j].Gender = (int)accountsInfo.Gender;
							}
						}
					}
				}
				ajaxJsonValid.AddDataItem("ranking", num4);
				ajaxJsonValid.AddDataItem("list", listRank);
				ajaxJsonValid.SetValidDataValue(true);
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
		}
		protected void GetScoreRank2(System.Web.HttpContext context)
		{
			int queryInt = GameRequest.GetQueryInt("userID", 0);
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			System.Collections.Generic.IList<UserScoreRank> list = new System.Collections.Generic.List<UserScoreRank>();
			System.Data.DataSet scoreRanking = FacadeManage.aideTreasureFacade.GetScoreRanking(100);
			int num = 1;
			int num2 = 0;
			if (scoreRanking.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < scoreRanking.Tables[0].Rows.Count; i++)
				{
					if (i != 0 && System.Convert.ToInt64(scoreRanking.Tables[0].Rows[i]["Score"]) != System.Convert.ToInt64(scoreRanking.Tables[0].Rows[i - 1]["Score"]))
					{
						num++;
					}
					if (num > 20)
					{
						break;
					}
					UserScoreRank userScoreRank = new UserScoreRank();
					userScoreRank.Ranking = num;
					userScoreRank.UserID = System.Convert.ToInt32(scoreRanking.Tables[0].Rows[i]["UserID"]);
					userScoreRank.Score = System.Convert.ToInt64(scoreRanking.Tables[0].Rows[i]["Score"]);
					userScoreRank.FaceID = System.Convert.ToInt32(scoreRanking.Tables[0].Rows[i]["FaceID"]);
					userScoreRank.CustomID = System.Convert.ToInt32(scoreRanking.Tables[0].Rows[i]["CustomID"]);
					userScoreRank.NickName = scoreRanking.Tables[0].Rows[i]["NickName"].ToString();
					list.Add(userScoreRank);
					if (userScoreRank.UserID == queryInt)
					{
						num2 = num;
					}
				}
			}
			ajaxJsonValid.AddDataItem("UserRanking", num2);
			ajaxJsonValid.AddDataItem("list", list);
			ajaxJsonValid.SetValidDataValue(true);
			context.Response.Write(ajaxJsonValid.SerializeToJson());
		}
		protected void GetScoreRank(System.Web.HttpContext context)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			int num = GameRequest.GetInt("pageindex", 1);
			int num2 = GameRequest.GetInt("pagesize", 10);
			int @int = GameRequest.GetInt("UserID", 0);
			if (num <= 0)
			{
				num = 1;
			}
			if (num2 <= 0)
			{
				num2 = 10;
			}
			if (num2 > 50)
			{
				num2 = 50;
			}
			string sqlQuery = string.Format("SELECT * FROM (SELECT ROW_NUMBER() OVER (ORDER BY Score DESC) as ChartID,UserID,Score FROM GameScoreInfo) a WHERE UserID={0}", @int);
			System.Data.DataSet dataSetByWhere = FacadeManage.aideTreasureFacade.GetDataSetByWhere(sqlQuery);
			int num3 = 0;
			long num4 = 0L;
			if (dataSetByWhere.Tables[0].Rows.Count != 0)
			{
				num3 = System.Convert.ToInt32(dataSetByWhere.Tables[0].Rows[0]["ChartID"]);
				num4 = System.Convert.ToInt64(dataSetByWhere.Tables[0].Rows[0]["Score"]);
			}
			System.Data.DataSet pageSet = FacadeManage.aideTreasureFacade.GetList("GameScoreInfo", num, num2, " ORDER BY Score DESC", " ", "UserID,Score").PageSet;
			if (pageSet.Tables[0].Rows.Count > 0)
			{
				stringBuilder.Append("[");
				stringBuilder.Append(string.Concat(new object[]
				{
					"{\"NickName\":\"",
					Fetch.GetNickNameByUserID(@int),
					"\",\"Score\":",
					num4,
					",\"Rank\":",
					num3,
					"},"
				}));
				foreach (System.Data.DataRow dataRow in pageSet.Tables[0].Rows)
				{
					stringBuilder.Append(string.Concat(new object[]
					{
						"{\"NickName\":\"",
						Fetch.GetNickNameByUserID(System.Convert.ToInt32(dataRow["UserID"])),
						"\",\"Score\":",
						dataRow["Score"],
						"},"
					}));
				}
				stringBuilder.Remove(stringBuilder.Length - 1, 1);
				stringBuilder.Append("]");
			}
			else
			{
				stringBuilder.Append("{}");
			}
			context.Response.Write(stringBuilder.ToString());
		}
		private void GetMobileFeedback(System.Web.HttpContext context)
		{
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			if (!Fetch.IsUserOnline())
			{
				ajaxJsonValid.code = 0;
				ajaxJsonValid.msg = "请先登录";
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
			else
			{
				new System.Text.StringBuilder();
				int queryInt = GameRequest.GetQueryInt("pageSize", 10);
				int queryInt2 = GameRequest.GetQueryInt("page", 1);
				PagerSet feedbacklist = FacadeManage.aideNativeWebFacade.GetFeedbacklist(queryInt2, queryInt, Fetch.GetUserCookie().UserID);
                Game.Utils.Template template = new Game.Utils.Template("/Template/MobileFeedback.html");
				string value = string.Empty;
				if (feedbacklist.PageSet.Tables[0].Rows.Count > 0)
				{
					feedbacklist.PageSet.Tables[0].Columns.Add("Date");
					feedbacklist.PageSet.Tables[0].Columns.Add("Time");
					feedbacklist.PageSet.Tables[0].Columns.Add("RevertStatus");
					for (int i = 0; i < feedbacklist.PageSet.Tables[0].Rows.Count; i++)
					{
						feedbacklist.PageSet.Tables[0].Rows[i]["FeedbackTitle"] = TextUtility.CutLeft(feedbacklist.PageSet.Tables[0].Rows[i]["FeedbackContent"].ToString(), 10);
						feedbacklist.PageSet.Tables[0].Rows[i]["Date"] = System.Convert.ToDateTime(feedbacklist.PageSet.Tables[0].Rows[i]["FeedbackDate"]).ToString("yyyy-MM-dd");
						feedbacklist.PageSet.Tables[0].Rows[i]["Time"] = System.Convert.ToDateTime(feedbacklist.PageSet.Tables[0].Rows[i]["FeedbackDate"]).ToString("HH:mm:ss");
						feedbacklist.PageSet.Tables[0].Rows[i]["FeedbackContent"] = Utility.HtmlDecode(feedbacklist.PageSet.Tables[0].Rows[i]["FeedbackContent"].ToString());
						if (feedbacklist.PageSet.Tables[0].Rows[i]["RevertContent"].ToString() == "")
						{
							feedbacklist.PageSet.Tables[0].Rows[i]["RevertStatus"] = "回复状态：客服未回复";
						}
						else
						{
							feedbacklist.PageSet.Tables[0].Rows[i]["RevertStatus"] = "";
						}
					}
					template.ForDataScoureList = new System.Collections.Generic.Dictionary<string, System.Data.DataTable>
					{

						{
							"list",
							feedbacklist.PageSet.Tables[0]
						}
					};
					value = template.OutputHTML();
				}
				else
				{
					value = "<tr><td colspan=\"6\">无兑换记录！</td></tr>";
				}
				ajaxJsonValid.AddDataItem("html", value);
				ajaxJsonValid.AddDataItem("total", feedbacklist.RecordCount);
				ajaxJsonValid.SetValidDataValue(true);
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
		}
		private void GetMobileFaq(System.Web.HttpContext context)
		{
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			int queryInt = GameRequest.GetQueryInt("pageSize", 10);
			int queryInt2 = GameRequest.GetQueryInt("page", 1);
			PagerSet issueList = FacadeManage.aideNativeWebFacade.GetIssueList("WHERE TypeID=1 AND Nullity=0", queryInt2, queryInt);
			System.Data.DataSet pageSet = issueList.PageSet;
			string value = string.Empty;
			if (pageSet.Tables[0].Rows.Count > 0)
			{
				foreach (System.Data.DataRow dataRow in pageSet.Tables[0].Rows)
				{
					stringBuilder.AppendFormat("<h2>{0}</h2>", dataRow["IssueTitle"]);
					stringBuilder.AppendLine();
					stringBuilder.AppendFormat("<p>{0}</p>", Utility.HtmlDecode(dataRow["IssueContent"].ToString()));
				}
				value = stringBuilder.ToString();
			}
			else
			{
				value = "<tr><td colspan=\"6\">无记录！</td></tr>";
			}
			ajaxJsonValid.AddDataItem("html", value);
			ajaxJsonValid.AddDataItem("total", issueList.RecordCount);
			ajaxJsonValid.SetValidDataValue(true);
			context.Response.Write(ajaxJsonValid.SerializeToJson());
		}
		private void GetMobileNotice(System.Web.HttpContext context)
		{
			new AjaxJsonValid();
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			int queryInt = GameRequest.GetQueryInt("number", 10);
			int queryInt2 = GameRequest.GetQueryInt("page", 1);
			PagerSet mobileNotcieList = FacadeManage.aideNativeWebFacade.GetMobileNotcieList(queryInt2, queryInt);
			System.Data.DataSet pageSet = mobileNotcieList.PageSet;
			if (pageSet.Tables[0].Rows.Count > 0)
			{
				stringBuilder.Append("{\"total\":" + mobileNotcieList.RecordCount);
				stringBuilder.Append(",\"list\":{");
				foreach (System.Data.DataRow dataRow in pageSet.Tables[0].Rows)
				{
					stringBuilder.Append("\"" + dataRow["NewsID"] + "\":");
					stringBuilder.Append(string.Concat(new object[]
					{
						"{\"Subject\":\"",
						dataRow["Subject"],
						"\",\"Body\":\"",
						dataRow["Body"],
						"\",\"IssueDate\":\"",
						dataRow["IssueDate"],
						"\",\"ImageUrl\":\"",
						Fetch.GetUploadFileUrl(dataRow["ImageUrl"].ToString()),
						"\"},"
					}));
				}
				stringBuilder.Remove(stringBuilder.Length - 1, 1);
				stringBuilder.Append("}}");
			}
			else
			{
				stringBuilder.Append("{}");
			}
			context.Response.Write(stringBuilder.ToString());
		}
		private void GetMobileRollNotice(System.Web.HttpContext context)
		{
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
            System.Collections.Generic.List<Entity.NativeWeb.News> list = FacadeManage.aideNativeWebFacade.GetMobileNotcie() as System.Collections.Generic.List<Entity.NativeWeb.News>;
			System.Collections.Generic.List<MobileNotice> list2 = new System.Collections.Generic.List<MobileNotice>();
			if (list != null)
			{
                foreach (Entity.NativeWeb.News current in list)
				{
					list2.Add(new MobileNotice(current.NewsID, current.Subject, current.IssueDate, current.Body));
				}
			}
			ajaxJsonValid.AddDataItem("notice", list2);
			ajaxJsonValid.SetValidDataValue(true);
			context.Response.Write(ajaxJsonValid.SerializeToJson());
		}
		private void GetMobileLoginNotice(System.Web.HttpContext context)
		{
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
            System.Collections.Generic.List<Entity.NativeWeb.News> list = FacadeManage.aideNativeWebFacade.GetMobileNotcie() as System.Collections.Generic.List<Entity.NativeWeb.News>;
			System.Collections.Generic.List<MobileNotice> list2 = new System.Collections.Generic.List<MobileNotice>();
			if (list != null)
			{
                foreach (Entity.NativeWeb.News current in list)
				{
					list2.Add(new MobileNotice(current.NewsID, current.Subject, current.IssueDate, current.Body));
				}
			}
			ajaxJsonValid.AddDataItem("notice", list2);
			ajaxJsonValid.SetValidDataValue(true);
			context.Response.Write(ajaxJsonValid.SerializeToJson());
		}
		private void GetMobilePropertyType(System.Web.HttpContext context)
		{
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			System.Collections.Generic.IList<GamePropertyType> mobilePropertyType = FacadeManage.aidePlatformFacade.GetMobilePropertyType(1);
			ajaxJsonValid.AddDataItem("list", mobilePropertyType);
			ajaxJsonValid.SetValidDataValue(true);
			context.Response.Write(ajaxJsonValid.SerializeToJson());
		}
		private void GetMobileProperty(System.Web.HttpContext context)
		{
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			int queryInt = GameRequest.GetQueryInt("TypeID", 0);
			System.Collections.Generic.IList<Game.Entity.Platform.GameProperty> mobileProperty = FacadeManage.aidePlatformFacade.GetMobileProperty(queryInt);
			ajaxJsonValid.AddDataItem("list", mobileProperty);
			ajaxJsonValid.SetValidDataValue(true);
			context.Response.Write(ajaxJsonValid.SerializeToJson());
		}
		private void GetMobileShare(System.Web.HttpContext context)
		{
			int queryInt = GameRequest.GetQueryInt("userid", 0);
			string queryString = GameRequest.GetQueryString("signature");
			string queryString2 = GameRequest.GetQueryString("time");
			string queryString3 = GameRequest.GetQueryString("machineid");
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
				message = FacadeManage.aideTreasureFacade.SharePresent(queryInt, logonPass, queryString3, Utility.UserIP);
				if (!message.Success)
				{
					ajaxJsonValid.msg = message.Content;
					context.Response.Write(ajaxJsonValid.SerializeToJson());
				}
				else
				{
					GameScoreInfo treasureInfo = FacadeManage.aideTreasureFacade.GetTreasureInfo2(queryInt);
					decimal score = treasureInfo.Score;
					ajaxJsonValid.msg = message.Content;
					ajaxJsonValid.AddDataItem("Score", score);
					ajaxJsonValid.SetValidDataValue(true);
					context.Response.Write(ajaxJsonValid.SerializeToJson());
				}
			}
		}
		private void GetMobileShareConfig(System.Web.HttpContext context)
		{
			int queryInt = GameRequest.GetQueryInt("userid", 0);
			string queryString = GameRequest.GetQueryString("signature");
			string queryString2 = GameRequest.GetQueryString("time");
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			new Message();
			FacadeManage.aideAccountsFacade.CheckUserSignature(queryInt, queryString2, queryString);
			int num = 0;
			AppConfig.SystemConfigKey systemConfigKey = AppConfig.SystemConfigKey.SharePresent;
			SystemStatusInfo systemStatusInfo = FacadeManage.aideAccountsFacade.GetSystemStatusInfo(systemConfigKey.ToString());
			if (systemStatusInfo != null)
			{
				num = systemStatusInfo.StatusValue;
			}
			int num2 = 3;
			LotteryConfig lotteryConfig = FacadeManage.aideTreasureFacade.GetLotteryConfig();
			if (lotteryConfig != null)
			{
				num2 = lotteryConfig.FreeCount;
			}
			AppConfig.SiteConfigKey siteConfigKey = AppConfig.SiteConfigKey.DayTaskConfig;
			ConfigInfo configInfo = FacadeManage.aideNativeWebFacade.GetConfigInfo(siteConfigKey.ToString());
			MobileDayTask value = new MobileDayTask("0", "0", "0", "0", "0", "0");
			if (configInfo != null)
			{
				value = new MobileDayTask(configInfo.Field1, configInfo.Field2, configInfo.Field3, configInfo.Field4, configInfo.Field5, configInfo.Field6);
			}
			int num3 = 1888;
			GlobalSpreadInfo globalSpreadInfo = new GlobalSpreadInfo();
			globalSpreadInfo = FacadeManage.aideTreasureFacade.GetGlobalSpreadInfo();
			if (globalSpreadInfo != null)
			{
				num3 = globalSpreadInfo.RegisterGrantScore;
			}
			ajaxJsonValid.AddDataItem("SharePresent", num);
			ajaxJsonValid.AddDataItem("FreeCount", num2);
			ajaxJsonValid.AddDataItem("DayTask", value);
			ajaxJsonValid.AddDataItem("RegGold", num3);
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
			string value2 = "";
			string value3 = "";
			string value4 = "";
			string value5 = "";
			if (configInfo != null)
			{
				value2 = configInfo.Field1;
				value3 = configInfo.Field2;
				value4 = configInfo.Field3;
				value5 = configInfo.Field7;
			}
			ajaxJsonValid.AddDataItem("ShareUrl", value2);
			ajaxJsonValid.AddDataItem("ShareTitle", value3);
			ajaxJsonValid.AddDataItem("ShareContent", value4);
			ajaxJsonValid.AddDataItem("EarnShareContent", value5);
			ajaxJsonValid.SetValidDataValue(true);
			context.Response.Write(ajaxJsonValid.SerializeToJson());
		}
		private void GetScoreInfo(System.Web.HttpContext context)
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
				decimal num = 0m;
				decimal num2 = 0m;
				decimal num3 = 0m;
				int num4 = 0;
				int num5 = 0;
				UserCurrencyInfo userCurrencyInfo = FacadeManage.aideTreasureFacade.GetUserCurrencyInfo(queryInt);
				if (userCurrencyInfo != null)
				{
					num = userCurrencyInfo.Currency;
				}
				GameScoreInfo treasureInfo = FacadeManage.aideTreasureFacade.GetTreasureInfo2(queryInt);
				if (treasureInfo != null)
				{
					num2 = treasureInfo.Score;
					num3 = treasureInfo.InsureScore;
				}
				UserInfo userBaseInfoByUserID = FacadeManage.aideAccountsFacade.GetUserBaseInfoByUserID(queryInt);
				if (userBaseInfoByUserID != null)
				{
					num4 = userBaseInfoByUserID.UserMedal;
				}
				UserRoomCard userRoomCard = FacadeManage.aideTreasureFacade.GetUserRoomCard(queryInt);
				if (userRoomCard != null)
				{
					num5 = userRoomCard.RoomCard;
				}
				ajaxJsonValid.msg = message.Content;
				ajaxJsonValid.AddDataItem("Currency", num);
				ajaxJsonValid.AddDataItem("Score", num2);
				ajaxJsonValid.AddDataItem("UserMedal", num4);
				ajaxJsonValid.AddDataItem("RoomCard", num5);
				ajaxJsonValid.AddDataItem("InsureScore", num3);
				ajaxJsonValid.SetValidDataValue(true);
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
		}
		public void GetPayRate(System.Web.HttpContext context)
		{
			int num = 1;
			SystemStatusInfo systemStatusInfo = FacadeManage.aideAccountsFacade.GetSystemStatusInfo(AppConfig.SystemConfigKey.RateCurrency.ToString());
			if (systemStatusInfo != null)
			{
				num = systemStatusInfo.StatusValue;
			}
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			ajaxJsonValid.AddDataItem("Rate", num);
			ajaxJsonValid.SetValidDataValue(true);
			context.Response.Write(ajaxJsonValid.SerializeToJson());
		}
		public void GetPayProduct(System.Web.HttpContext context)
		{
			int queryInt = GameRequest.GetQueryInt("userid", 0);
			string queryString = GameRequest.GetQueryString("signature");
			string queryString2 = GameRequest.GetQueryString("time");
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			Message message = FacadeManage.aideAccountsFacade.CheckUserSignature(queryInt, queryString2, queryString);
			if (!message.Success)
			{
				ajaxJsonValid.msg = message.Content;
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
			else
			{
				int queryInt2 = GameRequest.GetQueryInt("tagId", 1);
				System.Data.DataSet appListByTagID = FacadeManage.aideTreasureFacade.GetAppListByTagID(queryInt2);
				System.Collections.Generic.IList<GlobalAppInfo> value = DataHelper.ConvertDataTableToObjects<GlobalAppInfo>(appListByTagID.Tables[0]);
				int num = 0;
				PagerSet payRecord = FacadeManage.aideTreasureFacade.GetPayRecord(string.Format("WHERE UserID={0} AND DATEDIFF(d,ApplyDate,GETDATE())=0", queryInt), 1, 10);
				if (payRecord.RecordCount > 0)
				{
					num = 1;
				}
				ajaxJsonValid.AddDataItem("IsPay", num);
				ajaxJsonValid.AddDataItem("list", value);
				ajaxJsonValid.SetValidDataValue(true);
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
		}
		public void GetPayList(System.Web.HttpContext context)
		{
			System.Data.DataSet dataSet = new System.Data.DataSet();
			if (System.Web.HttpRuntime.Cache["paysetting"] == null)
			{
				dataSet = FacadeManage.aideTreasureFacade.GetPaySetting();
				if (dataSet != null)
				{
					CacheHelper.AddCache("paysetting", dataSet);
				}
			}
			else
			{
				dataSet = (System.Web.HttpRuntime.Cache["paysetting"] as System.Data.DataSet);
			}
			context.Response.Write(JsonHelper.SerializeObject(dataSet));
		}
		public void GetAgentPay(System.Web.HttpContext context)
		{
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			System.Data.DataSet agentList = FacadeManage.aideAccountsFacade.GetAgentList();
			System.Collections.Generic.IList<AgentInfo> value = DataHelper.ConvertDataTableToObjects<AgentInfo>(agentList.Tables[0]);
			ajaxJsonValid.AddDataItem("list", value);
			ajaxJsonValid.SetValidDataValue(true);
			context.Response.Write(ajaxJsonValid.SerializeToJson());
		}
		public void AgentPayOrder(System.Web.HttpContext context)
		{
			int queryInt = GameRequest.GetQueryInt("userid", 0);
			string queryString = GameRequest.GetQueryString("signature");
			string queryString2 = GameRequest.GetQueryString("time");
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			ajaxJsonValid.code = 1;
			Message message = FacadeManage.aideAccountsFacade.CheckUserSignature(queryInt, queryString2, queryString);
			if (!message.Success)
			{
				ajaxJsonValid.msg = message.Content;
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
			else
			{
				string queryString3 = GameRequest.GetQueryString("orderId");
				if (queryString3 == "")
				{
					ajaxJsonValid.msg = "订单号错误，请重新生成";
					context.Response.Write(ajaxJsonValid.SerializeToJson());
				}
				else
				{
					System.Collections.Generic.Dictionary<string, object> dictionary = new System.Collections.Generic.Dictionary<string, object>();
					dictionary["UserID"] = queryInt;
					dictionary["OrderId"] = queryString3;
					dictionary["ClientIP"] = GameRequest.GetUserIP();
					dictionary["StrErr"] = "";
					Message message2 = FacadeManage.aideAccountsFacade.ExcuteByProce("RYAgentDB..P_GenerateFillOrder", dictionary);
					if (message2.Success)
					{
						ajaxJsonValid.code = 0;
					}
					ajaxJsonValid.msg = message2.Content;
					context.Response.Write(ajaxJsonValid.SerializeToJson());
				}
			}
		}
		public void OnlineCountList(System.Web.HttpContext context)
		{
			System.Data.DataTable onlineCount = FacadeManage.aidePlatformFacade.GetOnlineCount();
			System.Collections.Generic.IList<OnlineCount> value = DataHelper.ConvertDataTableToObjects<OnlineCount>(onlineCount);
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			ajaxJsonValid.AddDataItem("list", value);
			ajaxJsonValid.SetValidDataValue(true);
			context.Response.Write(ajaxJsonValid.SerializeToJson());
		}
		public void GetPayConfig(System.Web.HttpContext context)
		{
			int num = 0;
			SystemStatusInfo systemStatusInfo = FacadeManage.aideAccountsFacade.GetSystemStatusInfo(AppConfig.SystemConfigKey.PayConfig.ToString());
			if (systemStatusInfo != null)
			{
				num = systemStatusInfo.StatusValue;
			}
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			ajaxJsonValid.AddDataItem("version", num);
			ajaxJsonValid.SetValidDataValue(true);
			context.Response.Write(ajaxJsonValid.SerializeToJson());
		}
		public void CreatPayOrderID(System.Web.HttpContext context)
		{
			string @string = GameRequest.GetString("paytype");
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			string string2 = GameRequest.GetString("accounts");
			if (string.IsNullOrEmpty(string2))
			{
				ajaxJsonValid.msg = "请输入充值的账号！";
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
			else
			{
				string string3 = GameRequest.GetString("amount");
				Regex regex = new Regex("^\\d{1,18}(.\\d{1,2})?$");
				if (!regex.IsMatch(string3))
				{
					ajaxJsonValid.msg = "请输入正确的充值金额！";
					context.Response.Write(ajaxJsonValid.SerializeToJson());
				}
				else
				{
					decimal orderAmount = System.Convert.ToDecimal(string3);
					OnLineOrder onLineOrder = new OnLineOrder();
					string a;
					if ((a = @string) != null)
					{
						if (!(a == "jft"))
						{
							if (!(a == "zfb"))
							{
								if (a == "wx")
								{
									onLineOrder.ShareID = 400;
									onLineOrder.OrderID = PayHelper.GetOrderIDByPrefix("WXAPP");
								}
							}
							else
							{
								onLineOrder.ShareID = 300;
								onLineOrder.OrderID = PayHelper.GetOrderIDByPrefix("ZFBAPP");
							}
						}
						else
						{
							onLineOrder.ShareID = 200;
							onLineOrder.OrderID = PayHelper.GetOrderIDByPrefix("JFTAPP");
						}
					}
					onLineOrder.Accounts = string2;
					onLineOrder.OrderAmount = orderAmount;
					onLineOrder.IPAddress = GameRequest.GetUserIP();
					Message message = FacadeManage.aideTreasureFacade.RequestOrder(onLineOrder);
					if (!message.Success)
					{
						ajaxJsonValid.msg = message.Content;
					}
					else
					{
						if (@string == "wx")
						{
							XZAppPay xZAppPay = new XZAppPay();
							xZAppPay.SetParameter("out_trade_no", onLineOrder.OrderID);
							xZAppPay.SetParameter("body", string3);
							xZAppPay.SetParameter("total_fee", (onLineOrder.OrderAmount * 100m).ToString("F0"));
							string prepayIDSign = xZAppPay.GetPrepayIDSign();
							ajaxJsonValid.AddDataItem("PayPackage", prepayIDSign);
						}
						ajaxJsonValid.AddDataItem("OrderID", onLineOrder.OrderID);
						ajaxJsonValid.msg = "下单成功";
					}
					ajaxJsonValid.SetValidDataValue(message.Success);
					context.Response.Write(ajaxJsonValid.SerializeToJson());
				}
			}
		}
		public void GetIosVersion(System.Web.HttpContext context)
		{
			string value = "V1.0";
			string value2 = "";
			ConfigInfo configInfo = FacadeManage.aideNativeWebFacade.GetConfigInfo(AppConfig.SiteConfigKey.GameIosConfig.ToString());
			if (configInfo != null)
			{
				value = configInfo.Field2;
				value2 = configInfo.Field1;
			}
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			ajaxJsonValid.AddDataItem("Version", value);
			ajaxJsonValid.AddDataItem("ForcedUpdate", configInfo.Field3 == "1");
			ajaxJsonValid.AddDataItem("DownloadURL", value2);
			ajaxJsonValid.SetValidDataValue(true);
			context.Response.Write(ajaxJsonValid.SerializeToJson());
		}
		public void GetAndriodVersion(System.Web.HttpContext context)
		{
			string value = "V1.0";
			string value2 = "";
			ConfigInfo configInfo = FacadeManage.aideNativeWebFacade.GetConfigInfo(AppConfig.SiteConfigKey.GameAndroidConfig.ToString());
			if (configInfo != null)
			{
				value = configInfo.Field2;
				value2 = configInfo.Field1;
			}
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			ajaxJsonValid.AddDataItem("Version", value);
			ajaxJsonValid.AddDataItem("ForcedUpdate", configInfo.Field3 == "1");
			ajaxJsonValid.AddDataItem("DownloadURL", value2);
			ajaxJsonValid.SetValidDataValue(true);
			context.Response.Write(ajaxJsonValid.SerializeToJson());
		}
		public void GetAwardOrderList(System.Web.HttpContext context)
		{
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			if (!Fetch.IsUserOnline())
			{
				ajaxJsonValid.code = 0;
				ajaxJsonValid.msg = "请先登录";
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
			else
			{
				int queryInt = GameRequest.GetQueryInt("page", 1);
				int queryInt2 = GameRequest.GetQueryInt("pageSize", 10);
				string where = string.Format(" WHERE UserID={0}", Fetch.GetUserCookie().UserID);
				PagerSet orderList = FacadeManage.aideNativeWebFacade.GetOrderList(queryInt, queryInt2, where, " ORDER BY BuyDate DESC");
                Game.Utils.Template template = new Game.Utils.Template("/Template/MobileAwardOrder.html");
				string value = string.Empty;
				if (orderList.PageSet.Tables[0].Rows.Count > 0)
				{
					orderList.PageSet.Tables[0].Columns.Add("OrderStatusDescribe");
					orderList.PageSet.Tables[0].Columns.Add("TimeDescribe");
					for (int i = 0; i < orderList.PageSet.Tables[0].Rows.Count; i++)
					{
						orderList.PageSet.Tables[0].Rows[i]["OrderStatusDescribe"] = System.Enum.GetName(typeof(AppConfig.AwardOrderStatus), orderList.PageSet.Tables[0].Rows[i]["OrderStatus"]);
						orderList.PageSet.Tables[0].Rows[i]["TimeDescribe"] = System.Convert.ToDateTime(orderList.PageSet.Tables[0].Rows[i]["BuyDate"]).ToString("yyyy-MM-dd HH:mm");
					}
					template.ForDataScoureList = new System.Collections.Generic.Dictionary<string, System.Data.DataTable>
					{

						{
							"Order",
							orderList.PageSet.Tables[0]
						}
					};
					value = template.OutputHTML();
				}
				else
				{
					value = "<tr><td colspan=\"6\">无兑换记录！</td></tr>";
				}
				ajaxJsonValid.AddDataItem("html", value);
				ajaxJsonValid.AddDataItem("total", orderList.RecordCount);
				ajaxJsonValid.SetValidDataValue(true);
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
		}
		public void GetGameList(System.Web.HttpContext context)
		{
			int num = GameRequest.GetQueryInt("TypeID", 1);
			if (num != 1 && num != 2)
			{
				num = 1;
			}
			string value = "";
			string value2 = "";
			string value3 = "";
			string value4 = "";
			string value5 = "";
			string value6 = "";
			string value7 = "";
			string value8 = "";
			string queryString = GameRequest.GetQueryString("key");
			AppConfig.SiteConfigKey siteConfigKey = AppConfig.SiteConfigKey.MobilePlatformVersion;
			string a;
			if ((a = queryString) != null)
			{
				if (!(a == "android"))
				{
					if (!(a == "ios"))
					{
						if (a == "win32")
						{
							siteConfigKey = AppConfig.SiteConfigKey.GameWin32Config;
						}
					}
					else
					{
						siteConfigKey = AppConfig.SiteConfigKey.GameIosConfig;
					}
				}
				else
				{
					siteConfigKey = AppConfig.SiteConfigKey.GameAndroidConfig;
				}
			}
			ConfigInfo configInfo;
			if (context.Request.Url.Host == "wwww.saoduanzi.com")
			{
				configInfo = FacadeManage.aideNativeWebFacade.GetConfigInfo("MobilePlatformVersion_dfh");
			}
			else
			{
				configInfo = FacadeManage.aideNativeWebFacade.GetConfigInfo(siteConfigKey.ToString());
			}
			if (configInfo != null)
			{
				value2 = configInfo.Field1;
				value = configInfo.Field2;
				value3 = configInfo.Field3;
				value4 = configInfo.Field4;
				value5 = configInfo.Field5;
				value6 = configInfo.Field6;
				value7 = configInfo.Field7;
			}
			AppConfig.SystemConfigKey systemConfigKey = AppConfig.SystemConfigKey.IsOpenRoomCard;
			SystemStatusInfo systemStatusInfo = FacadeManage.aideAccountsFacade.GetSystemStatusInfo(systemConfigKey.ToString());
			int num2 = 0;
			systemConfigKey = AppConfig.SystemConfigKey.WxLogon;
			SystemStatusInfo systemStatusInfo2 = FacadeManage.aideAccountsFacade.GetSystemStatusInfo(systemConfigKey.ToString());
			if (systemStatusInfo2 != null)
			{
				num2 = systemStatusInfo2.StatusValue;
			}
			System.Data.DataSet mobileKindList = FacadeManage.aidePlatformFacade.GetMobileKindList(num);
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			ajaxJsonValid.AddDataItem("downloadurl", value2);
			ajaxJsonValid.AddDataItem("debug_url", value5);
			ajaxJsonValid.AddDataItem("wxLogon", num2);
			ajaxJsonValid.AddDataItem("isOpenCard", (systemStatusInfo != null) ? systemStatusInfo.StatusValue : 1);
			ajaxJsonValid.AddDataItem("gamelist", ConventDataTableToJson.ConventDataTableToList(mobileKindList.Tables[0]));
			ajaxJsonValid.AddDataItem("packagename", value6);
			int num3 = 0;
			if (context.Request["agentId"] != null)
			{
				int agentId = System.Convert.ToInt32(context.Request["agentId"]);
				System.Data.DataTable dataTable = FacadeManage.aideNativeWebFacade.GetAppStoreById(agentId).Tables[0];
				if (dataTable.Rows.Count > 0)
				{
					num3 = System.Convert.ToInt32(dataTable.Rows[0]["IsIOSShop"]);
					value = dataTable.Rows[0]["VersionNo"].ToString();
					value3 = dataTable.Rows[0]["SrcVersionNo"].ToString();
				}
			}
			else
			{
				string @string = GameRequest.GetString("agentAcc");
				if (@string == "")
				{
					num3 = System.Convert.ToInt32(value7);
				}
				else
				{
					System.Data.DataTable dataTable2 = FacadeManage.aideNativeWebFacade.GetAppStore(@string).Tables[0];
					if (dataTable2.Rows.Count > 0)
					{
						System.Data.DataRow dataRow = dataTable2.Rows[0];
						num3 = System.Convert.ToInt32(dataRow["IsIOSShop"]);
						value = dataRow["VersionNo"].ToString();
						value3 = dataRow["SrcVersionNo"].ToString();
						value4 = dataRow["AppUrl"].ToString();
					}
				}
			}
			ajaxJsonValid.AddDataItem("ios_url", value4);
			ajaxJsonValid.AddDataItem("clientversion", value);
			ajaxJsonValid.AddDataItem("resversion", value3);
			ajaxJsonValid.AddDataItem("appstore", num3);
			ajaxJsonValid.AddDataItem("iosVersion", value8);
			ajaxJsonValid.SetValidDataValue(true);
			context.Response.Write(ajaxJsonValid.SerializeToJson());
		}
		public void GetServerConfig(System.Web.HttpContext context)
		{
			string value = "";
			string value2 = "";
			string value3 = "";
			string value4 = "";
			string value5 = "";
			string value6 = "";
			string value7 = "";
			string value8 = "";
			AppConfig.SiteConfigKey siteConfigKey = AppConfig.SiteConfigKey.ServerConfig;
			ConfigInfo configInfo = FacadeManage.aideNativeWebFacade.GetConfigInfo(siteConfigKey.ToString());
			if (configInfo != null)
			{
				if (context.Request.Url.Host == "wwww.saoduanzi.com")
				{
					value = configInfo.Field4;
				}
				else
				{
					value = configInfo.Field1;
				}
				value2 = configInfo.Field2;
				value3 = configInfo.Field3;
				value4 = configInfo.Field4;
				value5 = configInfo.Field5;
				value6 = configInfo.Field6;
				value7 = configInfo.Field7;
				value8 = configInfo.Field8;
			}
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			ajaxJsonValid.AddDataItem("str1", value);
			ajaxJsonValid.AddDataItem("str2", value2);
			ajaxJsonValid.AddDataItem("str3", value3);
			ajaxJsonValid.AddDataItem("str4", value4);
			ajaxJsonValid.AddDataItem("str5", value5);
			ajaxJsonValid.AddDataItem("str6", value6);
			ajaxJsonValid.AddDataItem("str7", value7);
			ajaxJsonValid.AddDataItem("str8", value8);
			ajaxJsonValid.SetValidDataValue(true);
			context.Response.Write(ajaxJsonValid.SerializeToJson());
		}
		public void GetAgentChildList(System.Web.HttpContext context)
		{
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			if (!Fetch.IsUserOnline())
			{
				ajaxJsonValid.code = 0;
				ajaxJsonValid.msg = "请先登录";
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
			else
			{
				int queryInt = GameRequest.GetQueryInt("page", 1);
				int queryInt2 = GameRequest.GetQueryInt("pageSize", 10);
				string condition = string.Format(" WHERE SpreaderID={0}", Fetch.GetUserCookie().UserID);
				PagerSet list = FacadeManage.aideAccountsFacade.GetList("AccountsInfo", queryInt, queryInt2, condition, " ORDER BY RegisterDate DESC");
                Game.Utils.Template template = new Game.Utils.Template("/Template/MobileAgentChild.html");
				string value = string.Empty;
				if (list.PageSet.Tables[0].Rows.Count > 0)
				{
					list.PageSet.Tables[0].Columns.Add("RevenueProvide");
					list.PageSet.Tables[0].Columns.Add("PayProvide");
					for (int i = 0; i < list.PageSet.Tables[0].Rows.Count; i++)
					{
						list.PageSet.Tables[0].Rows[i]["NickName"] = TextUtility.CutString(list.PageSet.Tables[0].Rows[i]["NickName"].ToString(), 0, 10);
						list.PageSet.Tables[0].Rows[i]["RevenueProvide"] = FacadeManage.aideTreasureFacade.GetChildRevenueProvide(System.Convert.ToInt32(list.PageSet.Tables[0].Rows[i]["UserID"]));
						list.PageSet.Tables[0].Rows[i]["PayProvide"] = FacadeManage.aideTreasureFacade.GetChildPayProvide(System.Convert.ToInt32(list.PageSet.Tables[0].Rows[i]["UserID"]));
					}
					template.ForDataScoureList = new System.Collections.Generic.Dictionary<string, System.Data.DataTable>
					{

						{
							"list",
							list.PageSet.Tables[0]
						}
					};
					value = template.OutputHTML();
				}
				else
				{
					value = "<tr><td colspan=\"10\">无兑换记录！</td></tr>";
				}
				ajaxJsonValid.AddDataItem("html", value);
				ajaxJsonValid.AddDataItem("total", list.RecordCount);
				ajaxJsonValid.SetValidDataValue(true);
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
		}
		public void GetAgentPayList(System.Web.HttpContext context)
		{
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			if (!Fetch.IsUserOnline())
			{
				ajaxJsonValid.code = 0;
				ajaxJsonValid.msg = "请先登录";
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
			else
			{
				int queryInt = GameRequest.GetQueryInt("page", 1);
				int queryInt2 = GameRequest.GetQueryInt("pageSize", 10);
				string whereQuery = string.Format("WHERE UserID={0} AND TypeID=1", Fetch.GetUserCookie().UserID);
				PagerSet list = FacadeManage.aideTreasureFacade.GetList("RecordAgentInfo", queryInt, queryInt2, "ORDER BY CollectDate DESC", whereQuery);
                Game.Utils.Template template = new Game.Utils.Template("/Template/MobileAgentPay.html");
				string value = string.Empty;
				if (list.PageSet.Tables[0].Rows.Count > 0)
				{
					list.PageSet.Tables[0].Columns.Add("NickName");
					list.PageSet.Tables[0].Columns.Add("AgentScaleFomart");
					for (int i = 0; i < list.PageSet.Tables[0].Rows.Count; i++)
					{
						list.PageSet.Tables[0].Rows[i]["NickName"] = TextUtility.CutString(FacadeManage.aideAccountsFacade.GetNickNameByUserID(System.Convert.ToInt32(list.PageSet.Tables[0].Rows[i]["ChildrenID"])), 0, 10);
						list.PageSet.Tables[0].Rows[i]["AgentScaleFomart"] = System.Convert.ToInt32(System.Convert.ToDecimal(list.PageSet.Tables[0].Rows[i]["AgentScale"]) * 1000m) + "‰";
					}
					template.ForDataScoureList = new System.Collections.Generic.Dictionary<string, System.Data.DataTable>
					{

						{
							"list",
							list.PageSet.Tables[0]
						}
					};
					value = template.OutputHTML();
				}
				else
				{
					value = "<tr><td colspan=\"10\">无兑换记录！</td></tr>";
				}
				ajaxJsonValid.AddDataItem("html", value);
				ajaxJsonValid.AddDataItem("total", list.RecordCount);
				ajaxJsonValid.SetValidDataValue(true);
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
		}
		public void GetAgentRevenueList(System.Web.HttpContext context)
		{
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			if (!Fetch.IsUserOnline())
			{
				ajaxJsonValid.code = 0;
				ajaxJsonValid.msg = "请先登录";
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
			else
			{
				int queryInt = GameRequest.GetQueryInt("page", 1);
				int queryInt2 = GameRequest.GetQueryInt("pageSize", 10);
				string whereQuery = string.Format("WHERE AgentUserID={0}", Fetch.GetUserCookie().UserID);
				PagerSet list = FacadeManage.aideTreasureFacade.GetList("RecordUserRevenue", queryInt, queryInt2, "ORDER BY CollectDate DESC", whereQuery);
                Game.Utils.Template template = new Game.Utils.Template("/Template/MobileAgentRevenue.html");
				string value = string.Empty;
				if (list.PageSet.Tables[0].Rows.Count > 0)
				{
					list.PageSet.Tables[0].Columns.Add("DateIDFormat");
					list.PageSet.Tables[0].Columns.Add("NickName");
					list.PageSet.Tables[0].Columns.Add("AgentScaleFormat");
					for (int i = 0; i < list.PageSet.Tables[0].Rows.Count; i++)
					{
						list.PageSet.Tables[0].Rows[i]["DateIDFormat"] = Fetch.ShowDate(System.Convert.ToInt32(list.PageSet.Tables[0].Rows[i]["DateID"]));
						list.PageSet.Tables[0].Rows[i]["NickName"] = TextUtility.CutString(FacadeManage.aideAccountsFacade.GetNickNameByUserID(System.Convert.ToInt32(list.PageSet.Tables[0].Rows[i]["UserID"])), 0, 10);
						list.PageSet.Tables[0].Rows[i]["AgentScaleFormat"] = System.Convert.ToInt32(System.Convert.ToDecimal(list.PageSet.Tables[0].Rows[i]["AgentScale"]) * 1000m) + "‰";
					}
					template.ForDataScoureList = new System.Collections.Generic.Dictionary<string, System.Data.DataTable>
					{

						{
							"list",
							list.PageSet.Tables[0]
						}
					};
					value = template.OutputHTML();
				}
				else
				{
					value = "<tr><td colspan=\"10\">无兑换记录！</td></tr>";
				}
				ajaxJsonValid.AddDataItem("html", value);
				ajaxJsonValid.AddDataItem("total", list.RecordCount);
				ajaxJsonValid.SetValidDataValue(true);
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
		}
		public void GetAgentPayBackList(System.Web.HttpContext context)
		{
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			if (!Fetch.IsUserOnline())
			{
				ajaxJsonValid.code = 0;
				ajaxJsonValid.msg = "请先登录";
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
			else
			{
				int queryInt = GameRequest.GetQueryInt("page", 1);
				int queryInt2 = GameRequest.GetQueryInt("pageSize", 10);
				string whereQuery = string.Format("WHERE UserID={0} AND TypeID=2", Fetch.GetUserCookie().UserID);
				PagerSet list = FacadeManage.aideTreasureFacade.GetList("RecordAgentInfo", queryInt, queryInt2, "ORDER BY CollectDate DESC", whereQuery);
                Game.Utils.Template template = new Game.Utils.Template("/Template/MobileAgentPayBack.html");
				string value = string.Empty;
				if (list.PageSet.Tables[0].Rows.Count > 0)
				{
					list.PageSet.Tables[0].Columns.Add("DateIDFormat");
					list.PageSet.Tables[0].Columns.Add("PayBackScaleFormat");
					for (int i = 0; i < list.PageSet.Tables[0].Rows.Count; i++)
					{
						list.PageSet.Tables[0].Rows[i]["DateIDFormat"] = Fetch.ShowDate(System.Convert.ToInt32(list.PageSet.Tables[0].Rows[i]["DateID"]));
						list.PageSet.Tables[0].Rows[i]["PayBackScaleFormat"] = System.Convert.ToInt32(System.Convert.ToDecimal(list.PageSet.Tables[0].Rows[i]["PayBackScale"]) * 1000m) + "‰";
					}
					template.ForDataScoureList = new System.Collections.Generic.Dictionary<string, System.Data.DataTable>
					{

						{
							"list",
							list.PageSet.Tables[0]
						}
					};
					value = template.OutputHTML();
				}
				else
				{
					value = "<tr><td colspan=\"10\">无兑换记录！</td></tr>";
				}
				ajaxJsonValid.AddDataItem("html", value);
				ajaxJsonValid.AddDataItem("total", list.RecordCount);
				ajaxJsonValid.SetValidDataValue(true);
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
		}
		public void SendCode(System.Web.HttpContext context)
		{
			int queryInt = GameRequest.GetQueryInt("userid", 0);
			string queryString = GameRequest.GetQueryString("signature");
			string queryString2 = GameRequest.GetQueryString("time");
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			Message message = new Message();
			ajaxJsonValid.code = 1;
			message = FacadeManage.aideAccountsFacade.CheckUserSignature(queryInt, queryString2, queryString);
			if (!message.Success)
			{
				ajaxJsonValid.msg = message.Content;
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
			else
			{
				string queryString3 = GameRequest.GetQueryString("phone");
				if (queryString3.Length < 11)
				{
					ajaxJsonValid.msg = "手机号格式错误";
					context.Response.Write(ajaxJsonValid.SerializeToJson());
				}
				else
				{
					string arg_B7_0 = GameRequest.GetQueryString("type");
					string text = ApplicationSettings.Get("phoneContent");
					string a = arg_B7_0;
					if (arg_B7_0 != null)
					{
						if (a == "SetPass")
						{
							text = text.Replace("注册", "设置密码");
							goto IL_18F;
						}
						if (a == "BindPhone")
						{
							if (FacadeManage.aideAccountsFacade.GetUserIDByAccounts(queryString3) > 0)
							{
								ajaxJsonValid.msg = "手机号已绑定游客";
								context.Response.Write(ajaxJsonValid.SerializeToJson());
								return;
							}
							text = text.Replace("注册", "手机绑定");
							goto IL_18F;
						}
					}
					text = text.Replace("注册", "设置密码");
					IL_18F:
					string text2 = TextUtility.CreateAuthStr(6, true);
					string text3 = CodeHelper.SendCode(queryString3, text2, text);
					if (text3 == "提交成功")
					{
						System.Collections.Generic.Dictionary<string, string> expr_16A = new System.Collections.Generic.Dictionary<string, string>();
						expr_16A["phone"] = queryString3;
						expr_16A["code"] = text2;
						string value = AES.Encrypt(JsonHelper.SerializeObject(expr_16A), AppConfig.UserLoginCacheEncryptKey);
						ajaxJsonValid.data.Add("cookie", value);
						ajaxJsonValid.code = 0;
					}
					ajaxJsonValid.msg = text3;
					context.Response.Write(ajaxJsonValid.SerializeToJson());
				}
			}
		}
		public void SetPass(System.Web.HttpContext context)
		{
			int queryInt = GameRequest.GetQueryInt("userid", 0);
			string queryString = GameRequest.GetQueryString("signature");
			string queryString2 = GameRequest.GetQueryString("time");
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			Message message = new Message();
			ajaxJsonValid.code = 1;
			message = FacadeManage.aideAccountsFacade.CheckUserSignature(queryInt, queryString2, queryString);
			if (!message.Success)
			{
				ajaxJsonValid.msg = message.Content;
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
			else
			{
				string queryString3 = GameRequest.GetQueryString("phone");
				string queryString4 = GameRequest.GetQueryString("code");
				string text = context.Request["cookie"];
				if (string.IsNullOrEmpty(text))
				{
					ajaxJsonValid.msg = "验证码不存在或已过期，请发送验证码";
					context.Response.Write(ajaxJsonValid.SerializeToJson());
				}
				else
				{
					text = text.Replace(" ", "+");
					string json = AES.Decrypt(text, AppConfig.UserLoginCacheEncryptKey);
					System.Collections.Generic.Dictionary<string, string> dictionary = JsonHelper.DeserializeJsonToObject<System.Collections.Generic.Dictionary<string, string>>(json);
					if (dictionary == null)
					{
						ajaxJsonValid.msg = "验证码已过期，请发送验证码";
						context.Response.Write(ajaxJsonValid.SerializeToJson());
					}
					else
					{
						if (queryString3 != dictionary["phone"])
						{
							ajaxJsonValid.msg = "要修改的手机号和发送验证码的不符合";
							context.Response.Write(ajaxJsonValid.SerializeToJson());
						}
						else
						{
							if (queryString4 != dictionary["code"])
							{
								ajaxJsonValid.msg = "验证码错误";
								context.Response.Write(ajaxJsonValid.SerializeToJson());
							}
							else
							{
								string queryString5 = GameRequest.GetQueryString("type");
								string queryString6 = GameRequest.GetQueryString("pass");
								if (queryString6.Length < 6)
								{
									ajaxJsonValid.msg = "密码长度不能低于6位";
									context.Response.Write(ajaxJsonValid.SerializeToJson());
								}
								else
								{
									string a;
									bool flag;
									if ((a = queryString5) != null)
									{
										if (a == "LoginPass")
										{
											flag = true;
											goto IL_24C;
										}
										if (a == "InsurePass")
										{
											flag = false;
											goto IL_24C;
										}
									}
									flag = true;
									IL_24C:
									System.Collections.Generic.Dictionary<string, object> dictionary2 = new System.Collections.Generic.Dictionary<string, object>();
									dictionary2["Acc"] = queryString3;
									dictionary2["IsLogon"] = flag;
									dictionary2["Pwd"] = TextEncrypt.EncryptPassword(queryString6);
									dictionary2["StrClientIP"] = GameRequest.GetUserIP();
									dictionary2["StrErr"] = "";
									Message message2 = FacadeManage.aideAccountsFacade.ExcuteByProce("P_Acc_SetPass", dictionary2);
									if (message2.Success)
									{
										ajaxJsonValid.code = 0;
									}
									ajaxJsonValid.msg = message2.Content;
									context.Response.Write(ajaxJsonValid.SerializeToJson());
								}
							}
						}
					}
				}
			}
		}
		public void BindPhone(System.Web.HttpContext context)
		{
			int queryInt = GameRequest.GetQueryInt("userid", 0);
			string queryString = GameRequest.GetQueryString("signature");
			string queryString2 = GameRequest.GetQueryString("time");
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			Message message = new Message();
			ajaxJsonValid.code = 1;
			message = FacadeManage.aideAccountsFacade.CheckUserSignature(queryInt, queryString2, queryString);
			if (!message.Success)
			{
				ajaxJsonValid.msg = message.Content;
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
			else
			{
				string queryString3 = GameRequest.GetQueryString("phone");
				string queryString4 = GameRequest.GetQueryString("code");
				string text = context.Request["cookie"];
				if (string.IsNullOrEmpty(text))
				{
					ajaxJsonValid.msg = "验证码不存在或已过期，请发送验证码";
					context.Response.Write(ajaxJsonValid.SerializeToJson());
				}
				else
				{
					text = text.Replace(" ", "+");
					System.Collections.Generic.Dictionary<string, string> dictionary = JsonHelper.DeserializeJsonToObject<System.Collections.Generic.Dictionary<string, string>>(AES.Decrypt(text, AppConfig.UserLoginCacheEncryptKey));
					if (dictionary == null)
					{
						ajaxJsonValid.msg = "验证码已过期，请发送验证码";
						context.Response.Write(ajaxJsonValid.SerializeToJson());
					}
					else
					{
						if (queryString3 != dictionary["phone"])
						{
							ajaxJsonValid.msg = "绑定的手机号和发送验证码的不符合";
							context.Response.Write(ajaxJsonValid.SerializeToJson());
						}
						else
						{
							if (queryString4 != dictionary["code"])
							{
								ajaxJsonValid.msg = "验证码错误";
								context.Response.Write(ajaxJsonValid.SerializeToJson());
							}
							else
							{
								string queryString5 = GameRequest.GetQueryString("pass");
								if (queryString5.Length < 6)
								{
									ajaxJsonValid.msg = "密码长度不能低于6位";
									context.Response.Write(ajaxJsonValid.SerializeToJson());
								}
								else
								{
									System.Collections.Generic.Dictionary<string, object> dictionary2 = new System.Collections.Generic.Dictionary<string, object>();
									dictionary2["dwUserID"] = queryInt;
									dictionary2["strBindAccounts"] = queryString3;
									dictionary2["strBindPassword"] = TextEncrypt.EncryptPassword(queryString5);
									dictionary2["strErrorDescribe"] = "";
									string value = "";
									Message message2 = FacadeManage.aideAccountsFacade.ExcuteByProceDataSet("P_VisitorBind", dictionary2);
									if (message2.Success)
									{
										ajaxJsonValid.code = 0;
										System.Data.DataSet dataSet = message2.EntityList[0] as System.Data.DataSet;
										if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
										{
											value = dataSet.Tables[0].Rows[0][0].ToString();
										}
									}
									ajaxJsonValid.data.Add("score", value);
									ajaxJsonValid.msg = message2.Content;
									context.Response.Write(ajaxJsonValid.SerializeToJson());
								}
							}
						}
					}
				}
			}
		}
		public void GetCode(System.Web.HttpContext context)
		{
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			new Message();
			ajaxJsonValid.code = 1;
			string queryString = GameRequest.GetQueryString("phone");
			if (queryString.Length < 11)
			{
				ajaxJsonValid.msg = "手机号格式错误";
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
			else
			{
				string arg_5A_0 = GameRequest.GetQueryString("type");
				string text = ApplicationSettings.Get("phoneContent");
				string a = arg_5A_0;
				if (arg_5A_0 != null)
				{
					if (!(a == "SetPass"))
					{
						if (!(a == "BindPhone"))
						{
							if (a == "ModifyBankInfo")
							{
								text = text.Replace("注册", "修改银行信息");
							}
						}
						else
						{
							text = text.Replace("注册", "手机绑定");
						}
					}
					else
					{
						text = text.Replace("注册", "设置密码");
					}
				}
				string text2 = TextUtility.CreateAuthStr(6, true);
				string text3 = CodeHelper.SendCode(queryString, text2, text);
				if (text3 == "提交成功")
				{
					ajaxJsonValid.data.Add("code", text2);
					ajaxJsonValid.code = 0;
				}
				ajaxJsonValid.msg = text3;
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
		}
	}
}
