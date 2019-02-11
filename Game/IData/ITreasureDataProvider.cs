using Game.Entity.Treasure;
using Game.Kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Game.IData
{
    public interface ITreasureDataProvider
    {
        Message RequestOrder(OnLineOrder orderInfo);

        void WriteReturnDayDetail(ReturnDayDetailInfo returnDay);

        void WriteReturnKQDetail(ReturnKQDetailInfo returnKQ);

        Message WriteReturnVBDetail(ReturnVBDetailInfo returnVB);

        Message WriteReturnYBDetail(ReturnYPDetailInfo returnYB);

        Message FilliedOnline(ShareDetialInfo olDetial, int isVB);

        Message FilliedApp(ShareDetialInfo olDetial, string productID);

        Message FilliedMobile(ShareDetialInfo olDetial);

        Message FilledLivcard(ShareDetialInfo detialInfo, string password);

        OnLineOrder GetOnlineOrder(string orderID);

        DataSet GetAppList();

        DataSet GetAppListByTagID(int tagID);

        DataSet GetAppInfoByProductID(string productID);

        void WriteReturnAppDetail(ShareDetialInfo detialInfo, AppReceiptInfo receiptt);

        void WriteOffLinePayment( OffLinePayOrders OffLinePayOrdersInfo);

        PagerSet GetPayRecord(string whereQuery, int pageIndex, int pageSize);

        PagerSet GetPayRecord(string whereQuery, int pageIndex, int pageSize, string[] returnField = null);

        Message GetUserSpreadInfo(int userID);

        Message GetUserSpreadBalance(int balance, int userID, string ip);

        PagerSet GetSpreaderRecord(string whereQuery, int pageIndex, int pageSize);

        DataSet GetUserSpreaderList(int userID, int pageIndex, int pageSize);

        long GetUserSpreaderTotal(string sWhere);

        GlobalSpreadInfo GetGlobalSpreadInfo();

        Message InsureIn(int userID, long TradeScore, string clientIP, string note);

        Message InsureOut(int userID, string insurePass, long TradeScore, string clientIP, string note);

        Message InsureTransfer(int srcUserID, string insurePass, int dstUserID, long TradeScore, string clientIP, string note);

        PagerSet GetInsureTradeRecord(string whereQuery, int pageIndex, int pageSize);

        GameScoreInfo GetTreasureInfo2(int UserID);

        UserRoomCard GetUserRoomCard(int userID);

        IList<GameScoreInfo> GetGameScoreInfoOrderByScore();

        DataSet GetScoreRanking(int num);

        UserCurrencyInfo GetUserCurrencyInfo(int userId);

        Message ClearGameScore(int userID, string ip);

        Message ClearGameFlee(int userID, string ip);

        PagerSet GetDrawInfoRecord(string whereQuery, int pageIndex, int pageSize);

        PagerSet GetDrawScoreRecord(string whereQuery, int pageIndex, int pageSize);

        PagerSet GetList(string tableName, int pageIndex, int pageSize, string pkey, string whereQuery);

        PagerSet GetList(string tableName, int pageIndex, int pageSize, string pkey, string whereQuery, string[] fields);

        DataSet GetDataSetByWhere(string sqlQuery);

        T GetEntity<T>(string commandText, List<DbParameter> parms);

        T GetEntity<T>(string commandText);

        Message WriteCheckIn(int userID, string strClientIP);

        DataSet GetMemberCardList();

        MemberCard GetMemberCard(int cardID);

        Message CurrencyExchange(int userID, int cardID, int num, string insurePassword, string IP);

        IList<UserGameInfo> GetUserGameGrandTotalRank(int number, int dateID);

        IList<UserGameInfo> GetUserGameWinMaxRank(int number, int dateID);

        long GetChildRevenueProvide(int userID);

        long GetChildPayProvide(int userID);

        DataSet GetAgentFinance(int userID);

        Message GetAgentBalance(int balance, int userID, string ip);

        LotteryConfig GetLotteryConfig();

        IList<LotteryItem> GetLotteryItem();

        Message GetLotteryUserInfo(int userID, string password);

        Message GetLotteryStart(int userID, string password, string ip);

        Message SharePresent(int userID, string password, string machineID, string ip);

        int ExecuteNonQuery(string sql);

        int ExecuteNonQuery(string sql, params SqlParameter[] cmdParms);
    }
}