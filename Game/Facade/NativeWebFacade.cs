using Game.Data.Factory;
using Game.Entity.NativeWeb;
using Game.IData;
using Game.Kernel;
using System;
using System.Collections.Generic;
using System.Data;
namespace Game.Facade
{
	public class NativeWebFacade
	{
		private INativeWebDataProvider webData;
		public NativeWebFacade()
		{
			this.webData = ClassFactory.GetINativeWebDataProvider();
		}
		public DataTable GetNewList(int top)
		{
			string text = "SELECT ";
			if (top > 0)
			{
				text = text + " TOP " + top;
			}
			text += " NewsID,Subject,IssueDate FROM News WHERE ClassID<>3 ORDER BY NewsID DESC";
			return this.webData.GetDataSetBySql(text).Tables[0];
		}
		public System.Collections.Generic.IList<News> GetTopNewsList(int typeID, int hot, int elite, int top)
		{
			return this.webData.GetTopNewsList(typeID, hot, elite, top);
		}
		public PagerSet GetNewsList(int pageIndex, int pageSize)
		{
			return this.webData.GetNewsList(pageIndex, pageSize);
		}
		public PagerSet GetNewsList(int pageIndex, int pageSize, int classID)
		{
			return this.webData.GetNewsList(pageIndex, pageSize, classID);
		}
		public News GetNewsByNewsID(int newsID, byte mode)
		{
			return this.webData.GetNewsByNewsID(newsID, mode);
		}
		public Notice GetNotice(int noticeID)
		{
			return this.webData.GetNotice(noticeID);
		}
		public System.Collections.Generic.IList<News> GetMobileNotcie()
		{
			return this.webData.GetMobileNotcie();
		}
		public PagerSet GetMobileNotcieList(int pageIndex, int pageSize)
		{
			return this.webData.GetMobileNotcieList(pageIndex, pageSize);
		}
		public string GetGameNotice(string title)
		{
			string sqlQuery = "SELECT TOP 1 Body FROM News WHERE Subject='" + title + "' AND IsDelete=0";
			object objectBySql = this.webData.GetObjectBySql(sqlQuery);
			if (objectBySql == null)
			{
				return "";
			}
			return objectBySql.ToString();
		}
		public System.Collections.Generic.IList<GameIssueInfo> GetTopIssueList(int top)
		{
			return this.webData.GetTopIssueList(top);
		}
		public System.Collections.Generic.IList<GameIssueInfo> GetTopIssueList(int top, int typeID)
		{
			return this.webData.GetTopIssueList(top, typeID);
		}
		public System.Collections.Generic.IList<GameIssueInfo> GetIssueList()
		{
			return this.webData.GetIssueList();
		}
		public PagerSet GetIssueList(int pageIndex, int pageSize)
		{
			return this.webData.GetIssueList(pageIndex, pageSize);
		}
		public PagerSet GetIssueList(string whereQuery, int pageIndex, int pageSize)
		{
			return this.webData.GetIssueList(whereQuery, pageIndex, pageSize);
		}
		public GameIssueInfo GetIssueByIssueID(int issueID, byte mode)
		{
			return this.webData.GetIssueByIssueID(issueID, mode);
		}
		public GameIssueInfo GetIssueByIssueID(int typeID, int issueID, byte mode)
		{
			return this.webData.GetIssueByIssueID(typeID, issueID, mode);
		}
		public PagerSet GetFeedbacklist(int pageIndex, int pageSize, int userId)
		{
			return this.webData.GetFeedbacklist(pageIndex, pageSize, userId);
		}
		public GameFeedbackInfo GetGameFeedBackInfo(int feedID, byte mode)
		{
			return this.webData.GetGameFeedBackInfo(feedID, mode);
		}
		public void UpdateFeedbackViewCount(int feedID)
		{
			this.webData.UpdateFeedbackViewCount(feedID);
		}
		public Message PublishFeedback(GameFeedbackInfo info, string accouts)
		{
			return this.webData.PublishFeedback(info, accouts);
		}
		public DataSet GetGameHelps(int top)
		{
			return this.webData.GetGameHelps(top);
		}
		public GameRulesInfo GetGameHelp(int kindID)
		{
			return this.webData.GetGameHelp(kindID);
		}
		public DataSet GetMoblieGame()
		{
			return this.webData.GetMoblieGame();
		}
		public DataTable GetGameRulesList(int top)
		{
			string text = "SELECT ";
			if (top > 0)
			{
				text = text + " TOP " + top;
			}
			text += " KindID,KindName,ImgRuleUrl FROM GameRulesInfo WHERE ImgRuleUrl<>'' and ImgRuleUrl is not null  ORDER BY KindID DESC";
			return this.webData.GetDataSetBySql(text).Tables[0];
		}
		public DataTable GameRulesList(int top)
		{
			string text = "SELECT ";
			if (top > 0)
			{
				text = text + " TOP " + top;
			}
			text += " KindID,KindName,ImgRuleUrl,HelpRule FROM GameRulesInfo  ORDER BY KindID DESC";
			return this.webData.GetDataSetBySql(text).Tables[0];
		}
		public System.Collections.Generic.IList<GameMatchInfo> GetMatchList()
		{
			return this.webData.GetMatchList();
		}
		public GameMatchInfo GetMatchInfo(int matchID)
		{
			return this.webData.GetMatchInfo(matchID);
		}
		public Message AddGameMatch(GameMatchUserInfo userInfo, string password)
		{
			return this.webData.AddGameMatch(userInfo, password);
		}
		public ConfigInfo GetConfigInfo(string key)
		{
			return this.webData.GetConfigInfo(key);
		}
		public DataSet GetAppStoreById(int agentId)
		{
			string sql = "SELECT IsIOSShop,VersionNo,SrcVersionNo FROM RYAgentDB.dbo.T_AgentIsIOS WHERE AgentID = " + agentId;
			return this.webData.GetDataSetBySql(sql);
		}
		public DataSet GetAppStore(string agentAcc)
		{
			return this.webData.GetAppStore(agentAcc);
		}
		public AwardType GetAwardType(int typeID)
		{
			return this.webData.GetAwardType(typeID);
		}
		public DataSet GetShopList(int counts)
		{
			return this.webData.GetShopList(counts);
		}
		public DataSet GetShopTypeListByParentId(int parentID)
		{
			return this.webData.GetShopTypeListByParentId(parentID);
		}
		public AwardInfo GetAwardInfo(int AwardID)
		{
			return this.webData.GetAwardInfo(AwardID);
		}
		public Message BuyAward(AwardOrder awardOrder)
		{
			return this.webData.BuyAward(awardOrder);
		}
		public PagerSet GetOrderList(int pageIndex, int pageSize, string where, string orderBy)
		{
			return this.webData.GetOrderList(pageIndex, pageSize, where, orderBy);
		}
		public int GetProcessingOrderCount(int userID)
		{
			return this.webData.GetProcessingOrderCount(userID);
		}
		public AwardOrder GetAwardOrder(int orderID, int userID)
		{
			return this.webData.GetAwardOrder(orderID, userID);
		}
		public int UpdateAwardOrderStatus(AwardOrder awardOrder)
		{
			return this.webData.UpdateAwardOrderStatus(awardOrder);
		}
		public DataSet GetTopOrder(int count)
		{
			return this.webData.GetTopOrder(count);
		}
		public DataSet GetWebHomeAdsList(int counts)
		{
			return this.webData.GetWebHomeAdsList(counts);
		}
		public Ads GetAds(int ID)
		{
			return this.webData.GetAds(ID);
		}
		public SinglePage GetSinglePage(string keyValue)
		{
			return this.webData.GetSinglePage(keyValue);
		}
		public void SaveLossReport(LossReport lossReport)
		{
			this.webData.SaveLossReport(lossReport);
		}
		public LossReport GetLossReport(string reportNo, string account)
		{
			return this.webData.GetLossReport(reportNo, account);
		}
		public LossReport GetLossReport(string reportNo)
		{
			return this.webData.GetLossReport(reportNo);
		}
		public DataSet GetActivityList(int counts)
		{
			return this.webData.GetActivityList(counts);
		}
		public Activity GetActivity(int id)
		{
			return this.webData.GetActivity(id);
		}
		public DataTable GetActiveList(int top)
		{
			string text = "SELECT ";
			if (top > 0)
			{
				text = text + " TOP " + top;
			}
			text += " ImageUrl,Describe FROM Activity WHERE ImageUrl<>'' ORDER BY ActivityID DESC";
			return this.webData.GetDataSetBySql(text).Tables[0];
		}
		public PagerSet GetList(string tableName, int pageIndex, int pageSize, string pkey, string whereQuery)
		{
			return this.webData.GetList(tableName, pageIndex, pageSize, pkey, whereQuery);
		}
		public object GetObjectBySql(string sqlQuery)
		{
			return this.webData.GetObjectBySql(sqlQuery);
		}
		public Message ExcuteByProce(string proceName, System.Collections.Generic.Dictionary<string, object> dir)
		{
			return this.webData.ExcuteByProce(proceName, dir);
		}
		public DataTable GetQuestionList(string sWhere, string title)
		{
			return this.webData.GetQuestionList(sWhere, title);
		}
		public DataTable GetReport(int userid)
		{
			string sqlQuery = "SELECT AccuseID,TypeName,AccuseTime,[Content],TarGameID,DealerMark FROM GameAccuseInfo g INNER JOIN RYTreasureDB.dbo.RecordType  t  ON t.TabName = 'GameAccuseInfo' AND t.ID = g.TypeID  WHERE UserID=" + userid;
			return this.webData.GetDataSetByWhere(sqlQuery).Tables[0];
		}
		public DataTable GetMessage(int userid)
		{
			string sqlQuery = "SELECT FeedbackID,FeedbackTitle AS Contact,FeedbackContent,TypeName,FeedbackDate,RevertContent FROM GameFeedbackInfo g INNER JOIN RYTreasureDB.dbo.RecordType  t  ON t.TabName = 'GameFeedbackInfo' AND t.ID = g.TypeID  WHERE UserID=" + userid;
			return this.webData.GetDataSetByWhere(sqlQuery).Tables[0];
		}
	}
}
