using Game.Entity.NativeWeb;
using Game.IData;
using Game.Kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
namespace Game.Data
{
	public class NativeWebDataProvider : BaseDataProvider, INativeWebDataProvider
	{
		private ITableProvider aideAdsProvider;
		private ITableProvider aideLossReport;
		public NativeWebDataProvider(string connString) : base(connString)
		{
			this.aideAdsProvider = this.GetTableProvider("Ads");
			this.aideLossReport = this.GetTableProvider("LossReport");
		}
		public System.Collections.Generic.IList<News> GetTopNewsList(int typeID, int hot, int elite, int top)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder().AppendFormat("SELECT TOP({0}) ", top).Append("NewsID, Subject,OnTop,OnTopAll,IsElite,IsHot,IsLinks,LinkUrl,HighLight,ClassID,IssueDate,LastModifyDate ").Append("FROM News ");
			stringBuilder.Append(" WHERE IsLock=1 AND IsDelete=0 ");
			if (typeID != 0)
			{
				stringBuilder.AppendFormat(" AND {0}={1} ", "ClassID", typeID);
			}
			if (hot > 0)
			{
				stringBuilder.AppendFormat(" AND {0}={1} ", "IsHot", hot);
			}
			if (elite > 0)
			{
				stringBuilder.AppendFormat(" AND {0}={1} ", "IsElite", elite);
			}
			stringBuilder.Append(" ORDER By OnTopAll DESC,OnTop DESC,IssueDate DESC ,NewsID DESC");
			return base.Database.ExecuteObjectList<News>(stringBuilder.ToString());
		}
		public System.Collections.Generic.IList<News> GetNewsList()
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("SELECT NewsID,Subject,OnTop,OnTopAll,IsElite,IsHot,IsLinks,LinkUrl,ClassID,IssueDate, HighLight ").Append("FROM News ").Append("WHERE  IsLock=1 AND IsDelete=0 AND IssueDate <= ' AND ClassID IN(1,2)").Append(System.DateTime.Now.Date.ToString()).Append("' ORDER By OnTopAll DESC,OnTop DESC,IssueDate DESC ,NewsID DESC");
			return base.Database.ExecuteObjectList<News>(stringBuilder.ToString());
		}
		public PagerSet GetNewsList(int pageIndex, int pageSize)
		{
			string whereStr = "WHERE  IsLock=1 AND IsDelete=0 ";
			string pkey = "ORDER By OnTopAll DESC,OnTop DESC,IssueDate DESC ,NewsID DESC";
			string[] fields = new string[]
			{
				"NewsID",
				"Subject",
				"OnTop",
				"OnTopAll",
				"IsElite",
				"IsHot",
				"Islinks",
				"LinkUrl",
				"ClassID",
				"IssueDate",
				"HighLight"
			};
			return this.GetPagerSet2(new PagerParameters("News", pkey, whereStr, pageIndex, pageSize)
			{
				Fields = fields,
				CacherSize = 2
			});
		}
		public PagerSet GetNewsList(int pageIndex, int pageSize, int classID)
		{
			string whereStr = string.Format("WHERE  IsLock=1 AND IsDelete=0 AND ClassID={0} ", classID);
			string pkey = "ORDER By OnTopAll DESC,OnTop DESC,IssueDate DESC ,NewsID DESC";
			string[] fields = new string[]
			{
				"NewsID",
				"Subject",
				"OnTop",
				"OnTopAll",
				"IsElite",
				"IsHot",
				"Islinks",
				"LinkUrl",
				"ClassID",
				"IssueDate",
				"HighLight"
			};
			return this.GetPagerSet2(new PagerParameters("News", pkey, whereStr, pageIndex, pageSize)
			{
				Fields = fields,
				CacherSize = 2
			});
		}
		public News GetNewsByNewsID(int newsID, byte mode)
		{
			News result;
			switch (mode)
			{
			case 1:
			{
				System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
				list.Add(base.Database.MakeInParam("dwNewsID", newsID));
				list.Add(base.Database.MakeInParam("dwMode", 1));
				News news = base.Database.RunProcObject<News>("NET_PW_GetNewsInfoByID", list);
				result = news;
				break;
			}
			case 2:
			{
				System.Collections.Generic.List<System.Data.Common.DbParameter> list2 = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
				list2.Add(base.Database.MakeInParam("dwNewsID", newsID));
				list2.Add(base.Database.MakeInParam("dwMode", 2));
				News news = base.Database.RunProcObject<News>("NET_PW_GetNewsInfoByID", list2);
				result = news;
				break;
			}
			default:
			{
				News news = base.Database.ExecuteObject<News>(string.Format("SELECT * FROM News(NOLOCK) WHERE IsLock=1 AND IsDelete=0 AND NewsID={0}", newsID));
				result = news;
				break;
			}
			}
			return result;
		}
		public Notice GetNotice(int noticeID)
		{
			string commandText = string.Format("SELECT * FROM Notice(NOLOCK) WHERE NoticeID={0}", noticeID);
			return base.Database.ExecuteObject<Notice>(commandText);
		}
		public System.Collections.Generic.IList<News> GetMobileNotcie()
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("SELECT NewsID,Subject,Body,IssueDate,GameRange,ImageUrl ").Append("FROM News ").Append("WHERE ClassID=3 AND IsDelete=0").Append("ORDER By OnTop DESC,IssueDate DESC");
			return base.Database.ExecuteObjectList<News>(stringBuilder.ToString());
		}
		public PagerSet GetMobileNotcieList(int pageIndex, int pageSize)
		{
			string whereStr = string.Format("WHERE ClassID=3 AND IsDelete=0", new object[0]);
			string pkey = "ORDER By OnTopAll DESC,OnTop DESC,IssueDate DESC ,NewsID DESC";
			string[] fields = new string[]
			{
				"NewsID",
				"Subject",
				"Body",
				"IssueDate",
				"ImageUrl"
			};
			return this.GetPagerSet2(new PagerParameters("News", pkey, whereStr, pageIndex, pageSize)
			{
				Fields = fields,
				CacherSize = 2
			});
		}
		public System.Collections.Generic.IList<GameIssueInfo> GetTopIssueList(int top)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder().AppendFormat("SELECT TOP({0}) ", top).Append("IssueID,IssueTitle,IssueContent,Nullity,CollectDate,ModifyDate ").Append("FROM GameIssueInfo ");
			stringBuilder.Append(" WHERE Nullity=0 ");
			stringBuilder.Append(" ORDER By CollectDate DESC");
			return base.Database.ExecuteObjectList<GameIssueInfo>(stringBuilder.ToString());
		}
		public System.Collections.Generic.IList<GameIssueInfo> GetTopIssueList(int top, int typeID)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder().AppendFormat("SELECT TOP({0}) ", top).Append("IssueID,IssueTitle,IssueContent,Nullity,CollectDate,ModifyDate ").Append("FROM GameIssueInfo ");
			stringBuilder.AppendFormat(" WHERE Nullity=0 AND TypeID={0}", typeID);
			stringBuilder.Append(" ORDER By CollectDate DESC");
			return base.Database.ExecuteObjectList<GameIssueInfo>(stringBuilder.ToString());
		}
		public System.Collections.Generic.IList<GameIssueInfo> GetIssueList()
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("SELECT IssueID,IssueTitle,IssueContent,Nullity,CollectDate,ModifyDate ").Append("FROM GameIssueInfo ").Append("WHERE Nullity=0 AND CollectDate <= '").Append(System.DateTime.Now.Date.ToString()).Append("' ORDER By CollectDate DESC");
			return base.Database.ExecuteObjectList<GameIssueInfo>(stringBuilder.ToString());
		}
		public PagerSet GetIssueList(int pageIndex, int pageSize)
		{
			string whereStr = "WHERE Nullity=0 ";
			string pkey = "ORDER By CollectDate DESC";
			string[] fields = new string[]
			{
				"IssueID",
				"IssueTitle",
				"IssueContent",
				"Nullity",
				"CollectDate",
				"ModifyDate"
			};
			return this.GetPagerSet2(new PagerParameters("GameIssueInfo", pkey, whereStr, pageIndex, pageSize)
			{
				Fields = fields,
				CacherSize = 2
			});
		}
		public PagerSet GetIssueList(string whereQuery, int pageIndex, int pageSize)
		{
			string pkey = "ORDER By CollectDate DESC";
			string[] fields = new string[]
			{
				"IssueID",
				"IssueTitle",
				"IssueContent",
				"Nullity",
				"CollectDate",
				"ModifyDate"
			};
			return this.GetPagerSet2(new PagerParameters("GameIssueInfo", pkey, whereQuery, pageIndex, pageSize)
			{
				Fields = fields,
				CacherSize = 2
			});
		}
		public GameIssueInfo GetIssueByIssueID(int issueID, byte mode)
		{
			GameIssueInfo result;
			switch (mode)
			{
			case 1:
			{
				GameIssueInfo gameIssueInfo = base.Database.ExecuteObject<GameIssueInfo>(string.Format("SELECT * FROM GameIssueInfo(NOLOCK) WHERE Nullity=0 AND IssueID>{0} ORDER BY CollectDate ASC", issueID));
				result = gameIssueInfo;
				break;
			}
			case 2:
			{
				GameIssueInfo gameIssueInfo = base.Database.ExecuteObject<GameIssueInfo>(string.Format("SELECT * FROM GameIssueInfo(NOLOCK) WHERE Nullity=0 AND IssueID<{0} ORDER BY CollectDate DESC", issueID));
				result = gameIssueInfo;
				break;
			}
			default:
			{
				GameIssueInfo gameIssueInfo = base.Database.ExecuteObject<GameIssueInfo>(string.Format("SELECT * FROM GameIssueInfo(NOLOCK) WHERE Nullity=0 AND IssueID={0}", issueID));
				result = gameIssueInfo;
				break;
			}
			}
			return result;
		}
		public GameIssueInfo GetIssueByIssueID(int typeID, int issueID, byte mode)
		{
			GameIssueInfo result;
			switch (mode)
			{
			case 1:
			{
				GameIssueInfo gameIssueInfo = base.Database.ExecuteObject<GameIssueInfo>(string.Format("SELECT * FROM GameIssueInfo(NOLOCK) WHERE TypeID={0} AND Nullity=0 AND IssueID>{1} ORDER BY CollectDate ASC", typeID, issueID));
				result = gameIssueInfo;
				break;
			}
			case 2:
			{
				GameIssueInfo gameIssueInfo = base.Database.ExecuteObject<GameIssueInfo>(string.Format("SELECT * FROM GameIssueInfo(NOLOCK) WHERE TypeID={0} AND Nullity=0 AND IssueID<{1} ORDER BY CollectDate DESC", typeID, issueID));
				result = gameIssueInfo;
				break;
			}
			default:
			{
				GameIssueInfo gameIssueInfo = base.Database.ExecuteObject<GameIssueInfo>(string.Format("SELECT * FROM GameIssueInfo(NOLOCK) WHERE Nullity=0 AND IssueID={0}", issueID));
				result = gameIssueInfo;
				break;
			}
			}
			return result;
		}
		public PagerSet GetFeedbacklist(int pageIndex, int pageSize, int userId)
		{
			string whereStr = "WHERE Nullity=0";
			if (userId != 0)
			{
				whereStr = string.Format("WHERE UserID={0}", userId);
			}
			string pkey = "ORDER By FeedbackDate DESC";
			string[] fields = new string[]
			{
				"FeedbackID",
				"FeedbackTitle",
				"FeedbackContent",
				"Nullity",
				"UserID",
				"FeedbackDate",
				"ViewCount",
				"RevertContent",
				"RevertDate"
			};
			return this.GetPagerSet2(new PagerParameters("GameFeedbackInfo", pkey, whereStr, pageIndex, pageSize)
			{
				Fields = fields,
				CacherSize = 2
			});
		}
		public GameFeedbackInfo GetGameFeedBackInfo(int feedID, byte mode)
		{
			GameFeedbackInfo result;
			switch (mode)
			{
			case 1:
			{
				GameFeedbackInfo gameFeedbackInfo = base.Database.ExecuteObject<GameFeedbackInfo>(string.Format("SELECT * FROM GameFeedbackInfo(NOLOCK) WHERE Nullity=-0 AND FeedbackID<{0} ORDER BY FeedbackID DESC", feedID));
				result = gameFeedbackInfo;
				break;
			}
			case 2:
			{
				GameFeedbackInfo gameFeedbackInfo = base.Database.ExecuteObject<GameFeedbackInfo>(string.Format("SELECT * FROM GameFeedbackInfo(NOLOCK) WHERE Nullity=0 AND FeedbackID>{0} ORDER BY FeedbackID ASC", feedID));
				result = gameFeedbackInfo;
				break;
			}
			default:
			{
				GameFeedbackInfo gameFeedbackInfo = base.Database.ExecuteObject<GameFeedbackInfo>(string.Format("SELECT * FROM GameFeedbackInfo(NOLOCK) WHERE Nullity=0 AND FeedbackID={0}", feedID));
				result = gameFeedbackInfo;
				break;
			}
			}
			return result;
		}
		public void UpdateFeedbackViewCount(int feedID)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwFeedbackID", feedID));
			base.Database.RunProc("NET_PW_UpdateViewCount", list);
		}
		public Message PublishFeedback(GameFeedbackInfo info, string accounts)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("strAccounts", accounts));
			list.Add(base.Database.MakeInParam("strTitle", info.FeedbackTitle));
			list.Add(base.Database.MakeInParam("strContent", info.FeedbackContent));
			list.Add(base.Database.MakeInParam("strClientIP", info.ClientIP));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "NET_PW_AddGameFeedback", list);
		}
		public System.Data.DataSet GetGameHelps(int top)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.AppendFormat("SELECT TOP({0}) ", top).Append("KindID, KindName, ImgRuleUrl, ThumbnailUrl, HelpIntro, HelpRule, HelpGrade, JoinIntro, Nullity, CollectDate, ModifyDate ").Append("FROM GameRulesInfo ").Append("WHERE  Nullity=0").Append(" ORDER By CollectDate DESC");
			return base.Database.ExecuteDataset(stringBuilder.ToString());
		}
		public GameRulesInfo GetGameHelp(int kindID)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("SELECT KindID, KindName, ImgRuleUrl, ThumbnailUrl, MobileImgUrl,HelpIntro, HelpRule, HelpGrade, JoinIntro, Nullity, CollectDate, ModifyDate,AndroidDownloadUrl,IOSDownloadUrl,MobileSize,MobileDate,MobileVersion ").Append("FROM GameRulesInfo ").AppendFormat("WHERE KindID={0} ", kindID).Append(" ORDER By CollectDate DESC");
			return base.Database.ExecuteObject<GameRulesInfo>(stringBuilder.ToString());
		}
		public System.Data.DataSet GetMoblieGame()
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.AppendFormat("SELECT ", new object[0]).Append("KindID,KindName,ImgRuleUrl,ThumbnailUrl,MobileGameType,AndroidDownloadUrl,IOSDownloadUrl ").Append("FROM GameRulesInfo ").Append("WHERE Nullity=0 AND MobileGameType!=0 ").Append("ORDER By CollectDate DESC ");
			return base.Database.ExecuteDataset(stringBuilder.ToString());
		}
		public System.Collections.Generic.IList<GameMatchInfo> GetMatchList()
		{
			string commandText = "SELECT * FROM GameMatchInfo WHERE Nullity = 0 ORDER BY CollectDate DESC";
			return base.Database.ExecuteObjectList<GameMatchInfo>(commandText);
		}
		public GameMatchInfo GetMatchInfo(int matchID)
		{
			string commandText = "SELECT * FROM GameMatchInfo WHERE MatchID = @MatchID";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("MatchID", matchID));
			return base.Database.ExecuteObject<GameMatchInfo>(commandText, list);
		}
		public Message AddGameMatch(GameMatchUserInfo userInfo, string password)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwMatchID", userInfo.MatchID));
			list.Add(base.Database.MakeInParam("strAccounts", userInfo.Accounts));
			list.Add(base.Database.MakeInParam("strPassword", password));
			list.Add(base.Database.MakeInParam("strCompellation", userInfo.Compellation));
			list.Add(base.Database.MakeInParam("dwGender", userInfo.Gender));
			list.Add(base.Database.MakeInParam("strPassportID", userInfo.PassportID));
			list.Add(base.Database.MakeInParam("strMobilePhone", userInfo.MobilePhone));
			list.Add(base.Database.MakeInParam("strEMail", userInfo.EMail));
			list.Add(base.Database.MakeInParam("strQQ", userInfo.QQ));
			list.Add(base.Database.MakeInParam("strDwellingPlace", userInfo.DwellingPlace));
			list.Add(base.Database.MakeInParam("strPostalCode", userInfo.PostalCode));
			list.Add(base.Database.MakeInParam("strClientIP", userInfo.ClientIP));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "NET_PW_AddGameMatchUser", list);
		}
		public ConfigInfo GetConfigInfo(string key)
		{
			string commandText = "SELECT * FROM ConfigInfo WHERE ConfigKey = @ConfigKey";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("ConfigKey", key));
			return base.Database.ExecuteObject<ConfigInfo>(commandText, list);
		}
		public System.Data.DataSet GetAppStore(string agentAcc)
		{
			string commandText = "SELECT IsIOSShop,VersionNo,SrcVersionNo,AppUrl FROM RYAgentDB.dbo.T_AgentIsIOS WHERE AgentAcc = @AgentAcc";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("AgentAcc", agentAcc));
			return base.Database.ExecuteDataset(System.Data.CommandType.Text, commandText, list.ToArray());
		}
		public AwardType GetAwardType(int typeID)
		{
			string commandText = "SELECT * FROM AwardType WHERE TypeID=@typeID";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("TypeID", typeID));
			return base.Database.ExecuteObject<AwardType>(commandText, list);
		}
		public System.Data.DataSet GetShopList(int counts)
		{
			string commandText = string.Format("SELECT TOP {0} * FROM AwardInfo WHERE Nullity=0 ORDER BY SortID ASC", counts);
			return base.Database.ExecuteDataset(commandText);
		}
		public System.Data.DataSet GetShopTypeListByParentId(int parentID)
		{
			string commandText = string.Format("SELECT * FROM AwardType WHERE ParentID={0} AND Nullity=0 ORDER BY SortID ASC", parentID);
			return base.Database.ExecuteDataset(commandText);
		}
		public AwardInfo GetAwardInfo(int awardID)
		{
			string commandText = "SELECT * FROM AwardInfo WHERE AwardID=@AwardID";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("AwardID", awardID));
			return base.Database.ExecuteObject<AwardInfo>(commandText, list);
		}
		public Message BuyAward(AwardOrder awardOrder)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("UserID", awardOrder.UserID));
			list.Add(base.Database.MakeInParam("AwardID", awardOrder.AwardID));
			list.Add(base.Database.MakeInParam("AwardPrice", awardOrder.AwardPrice));
			list.Add(base.Database.MakeInParam("AwardCount", awardOrder.AwardCount));
			list.Add(base.Database.MakeInParam("TotalAmount", awardOrder.TotalAmount));
			list.Add(base.Database.MakeInParam("Compellation", awardOrder.Compellation));
			list.Add(base.Database.MakeInParam("MobilePhone", awardOrder.MobilePhone));
			list.Add(base.Database.MakeInParam("QQ", awardOrder.QQ));
			list.Add(base.Database.MakeInParam("Province", awardOrder.Province));
			list.Add(base.Database.MakeInParam("City", awardOrder.City));
			list.Add(base.Database.MakeInParam("Area", awardOrder.Area));
			list.Add(base.Database.MakeInParam("DwellingPlace", awardOrder.DwellingPlace));
			list.Add(base.Database.MakeInParam("PostalCode", awardOrder.PostalCode));
			list.Add(base.Database.MakeInParam("BuyIP", awardOrder.BuyIP));
			list.Add(base.Database.MakeOutParam("OrderID", typeof(int)));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessageForObject<AwardOrder>(base.Database, "WSP_PW_BuyAward", list);
		}
		public PagerSet GetOrderList(int pageIndex, int pageSize, string where, string orderBy)
		{
			string tableName = "(SELECT A.*,B.AwardName,B.SmallImage,B.IsReturn FROM AwardOrder AS A LEFT JOIN AwardInfo AS B ON A.AwardID=B.AwardID) AS D ";
			return this.GetList(tableName, pageIndex, pageSize, orderBy, where);
		}
		public int GetProcessingOrderCount(int userID)
		{
			string commandText = "SELECT COUNT(OrderID) FROM AwardOrder WHERE OrderStatus=0 AND UserID=" + userID;
			object obj = base.Database.ExecuteScalar(System.Data.CommandType.Text, commandText);
			int result;
			if (obj != null)
			{
				result = System.Convert.ToInt32(obj);
			}
			else
			{
				result = 0;
			}
			return result;
		}
		public AwardOrder GetAwardOrder(int orderID, int userID)
		{
			string commandText = "SELECT * FROM AwardOrder WHERE OrderID=@OrderID AND UserID=@UserID";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("OrderID", orderID));
			list.Add(base.Database.MakeInParam("UserID", userID));
			return base.Database.ExecuteObject<AwardOrder>(commandText, list);
		}
		public int UpdateAwardOrderStatus(AwardOrder awardOrder)
		{
			string commandText = "UPDATE AwardOrder SET OrderStatus=@OrderStatus WHERE OrderID=@OrderID";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("OrderStatus", awardOrder.OrderStatus));
			list.Add(base.Database.MakeInParam("OrderID", awardOrder.OrderID));
			return base.Database.ExecuteNonQuery(System.Data.CommandType.Text, commandText, list.ToArray());
		}
		public System.Data.DataSet GetTopOrder(int count)
		{
			string commandText = string.Format("SELECT TOP {0} A.UserID,A.BuyDate,B.AwardName FROM AwardOrder AS A LEFT JOIN AwardInfo AS B ON A.AwardID=B.AwardID ORDER BY BuyDate DESC", count);
			return base.Database.ExecuteDataset(commandText);
		}
		public System.Data.DataSet GetWebHomeAdsList(int counts)
		{
			string commandText = string.Format("SELECT TOP {0} * FROM Ads WHERE Type=0 ORDER BY SortID DESC", counts);
			return base.Database.ExecuteDataset(commandText);
		}
		public Ads GetAds(int ID)
		{
			string where = string.Format(" WHERE ID={0}", ID);
			return this.aideAdsProvider.GetObject<Ads>(where);
		}
		public SinglePage GetSinglePage(string keyValue)
		{
			string commandText = "SELECT * FROM SinglePage WHERE KeyValue=@KeyValue";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("KeyValue", keyValue));
			return base.Database.ExecuteObject<SinglePage>(commandText, list);
		}
		public void SaveLossReport(LossReport lossReport)
		{
			System.Data.DataRow dataRow = this.aideLossReport.NewRow();
			dataRow["ReportNo"] = lossReport.ReportNo;
			dataRow["ReportEmail"] = lossReport.ReportEmail;
			dataRow["Accounts"] = lossReport.Accounts;
			dataRow["RegisterDate"] = lossReport.RegisterDate;
			dataRow["Compellation"] = lossReport.Compellation;
			dataRow["PassportID"] = lossReport.PassportID;
			dataRow["MobilePhone"] = lossReport.MobilePhone;
			dataRow["OldNickName1"] = lossReport.OldNickName1;
			dataRow["OldNickName2"] = lossReport.OldNickName2;
			dataRow["OldNickName3"] = lossReport.OldNickName3;
			dataRow["OldLogonPass1"] = lossReport.OldLogonPass1;
			dataRow["OldLogonPass2"] = lossReport.OldLogonPass2;
			dataRow["OldLogonPass3"] = lossReport.OldLogonPass3;
			dataRow["ReportIP"] = lossReport.ReportIP;
			dataRow["Random"] = lossReport.Random;
			dataRow["GameID"] = lossReport.GameID;
			dataRow["UserID"] = lossReport.UserID;
			dataRow["OldQuestion1"] = lossReport.OldQuestion1;
			dataRow["OldResponse1"] = lossReport.OldResponse1;
			dataRow["OldQuestion2"] = lossReport.OldQuestion2;
			dataRow["OldResponse2"] = lossReport.OldResponse2;
			dataRow["OldQuestion3"] = lossReport.OldQuestion3;
			dataRow["OldResponse3"] = lossReport.OldResponse3;
			dataRow["SuppInfo"] = lossReport.SuppInfo;
			dataRow["FixedPhone"] = lossReport.FixedPhone;
			dataRow["ProcessStatus"] = lossReport.ProcessStatus;
			dataRow["OverDate"] = lossReport.OverDate;
			dataRow["ReportDate"] = lossReport.ReportDate;
			dataRow["SendCount"] = lossReport.SendCount;
			this.aideLossReport.Insert(dataRow);
		}
		public LossReport GetLossReport(string reportNo, string account)
		{
			string commandText = "SELECT * FROM LossReport WHERE ReportNo=@ReportNo AND Accounts=@Accounts";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("ReportNo", reportNo));
			list.Add(base.Database.MakeInParam("Accounts", account));
			return base.Database.ExecuteObject<LossReport>(commandText, list);
		}
		public LossReport GetLossReport(string reportNo)
		{
			string commandText = "SELECT * FROM LossReport WHERE ReportNo=@ReportNo";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("ReportNo", reportNo));
			return base.Database.ExecuteObject<LossReport>(commandText, list);
		}
		public System.Data.DataSet GetActivityList(int counts)
		{
			string commandText = string.Format("SELECT TOP {0} * FROM Activity WHERE IsRecommend=1 ORDER BY SortID ASC,InputDate DESC", counts);
			return base.Database.ExecuteDataset(commandText);
		}
		public Activity GetActivity(int id)
		{
			string commandText = "SELECT * FROM Activity WHERE ActivityID=@ActivityID";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("ActivityID", id));
			return base.Database.ExecuteObject<Activity>(commandText, list);
		}
		public PagerSet GetList(string tableName, int pageIndex, int pageSize, string pkey, string whereQuery)
		{
			return this.GetPagerSet2(new PagerParameters(tableName, pkey, whereQuery, pageIndex, pageSize)
			{
				CacherSize = 2
			});
		}
		public object GetObjectBySql(string sqlQuery)
		{
			return base.Database.ExecuteScalar(System.Data.CommandType.Text, sqlQuery);
		}
		public System.Data.DataSet GetDataSetBySql(string sql)
		{
			return base.Database.ExecuteDataset(sql);
		}
		public Message ExcuteByProce(string proceName, System.Collections.Generic.Dictionary<string, object> dir)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			if (dir != null)
			{
				int num = 0;
				foreach (System.Collections.Generic.KeyValuePair<string, object> current in dir)
				{
					if (num == dir.Count - 1)
					{
						list.Add(base.Database.MakeOutParam(current.Key, typeof(string), 127));
					}
					else
					{
						list.Add(base.Database.MakeInParam(current.Key, current.Value));
					}
					num++;
				}
			}
			return MessageHelper.GetMessage(base.Database, proceName, list);
		}
		public System.Data.DataSet GetDataSetByWhere(string sqlQuery)
		{
			return base.Database.ExecuteDataset(sqlQuery);
		}
		public System.Data.DataTable GetQuestionList(string sWhere, string title)
		{
			string commandText = "SELECT IssueTitle,IssueContent FROM GameIssueInfo " + sWhere + " Order By IssueID ASC";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("title", title));
			return base.Database.ExecuteDataset(System.Data.CommandType.Text, commandText, list.ToArray()).Tables[0];
		}
	}
}
