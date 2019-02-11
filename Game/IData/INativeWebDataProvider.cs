using Game.Entity.NativeWeb;
using Game.Kernel;
using System;
using System.Collections.Generic;
using System.Data;
namespace Game.IData
{
	public interface INativeWebDataProvider
	{
		IList<News> GetTopNewsList(int typeID, int hot, int elite, int top);
		IList<News> GetNewsList();
		PagerSet GetNewsList(int pageIndex, int pageSize);
		PagerSet GetNewsList(int pageIndex, int pageSize, int classID);
		News GetNewsByNewsID(int newsID, byte mode);
		Notice GetNotice(int noticeID);
		IList<News> GetMobileNotcie();
		PagerSet GetMobileNotcieList(int pageIndex, int pageSize);
		IList<GameIssueInfo> GetTopIssueList(int top);
		IList<GameIssueInfo> GetTopIssueList(int top, int typeID);
		IList<GameIssueInfo> GetIssueList();
		PagerSet GetIssueList(int pageIndex, int pageSize);
		PagerSet GetIssueList(string whereQuery, int pageIndex, int pageSize);
		GameIssueInfo GetIssueByIssueID(int issueID, byte mode);
		GameIssueInfo GetIssueByIssueID(int typeID, int issueID, byte mode);
		PagerSet GetFeedbacklist(int pageIndex, int pageSize, int userId);
		GameFeedbackInfo GetGameFeedBackInfo(int feedID, byte mode);
		void UpdateFeedbackViewCount(int feedID);
		Message PublishFeedback(GameFeedbackInfo info, string accounts);
		DataSet GetGameHelps(int top);
		GameRulesInfo GetGameHelp(int kindID);
		DataSet GetMoblieGame();
		IList<GameMatchInfo> GetMatchList();
		GameMatchInfo GetMatchInfo(int matchID);
		Message AddGameMatch(GameMatchUserInfo userInfo, string password);
		ConfigInfo GetConfigInfo(string key);
		DataSet GetAppStore(string agentAcc);
		AwardType GetAwardType(int typeID);
		DataSet GetShopList(int counts);
		DataSet GetShopTypeListByParentId(int parentID);
		AwardInfo GetAwardInfo(int AwardID);
		Message BuyAward(AwardOrder awardOrder);
		PagerSet GetOrderList(int pageIndex, int pageSize, string where, string orderBy);
		int GetProcessingOrderCount(int userID);
		AwardOrder GetAwardOrder(int orderID, int userID);
		int UpdateAwardOrderStatus(AwardOrder awardOrder);
		DataSet GetTopOrder(int count);
		DataSet GetWebHomeAdsList(int counts);
		Ads GetAds(int ID);
		SinglePage GetSinglePage(string keyValue);
		void SaveLossReport(LossReport lossReport);
		LossReport GetLossReport(string reportNo, string account);
		LossReport GetLossReport(string reportNo);
		DataSet GetActivityList(int counts);
		Activity GetActivity(int id);
		PagerSet GetList(string tableName, int pageIndex, int pageSize, string pkey, string whereQuery);
		object GetObjectBySql(string sqlQuery);
		DataSet GetDataSetBySql(string sql);
		Message ExcuteByProce(string proceName, Dictionary<string, object> dir);
		DataSet GetDataSetByWhere(string sqlQuery);
		DataTable GetQuestionList(string sWhere, string title);
	}
}
