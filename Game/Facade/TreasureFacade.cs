using Game.Data.Factory;
using Game.Entity.Treasure;
using Game.IData;
using Game.Kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
namespace Game.Facade
{
	public class TreasureFacade
	{
		private ITreasureDataProvider treasureData;
       

		public TreasureFacade()
		{
			this.treasureData = ClassFactory.GetITreasureDataProvider();
		}
		public TreasureFacade(int kindID)
		{
			this.treasureData = ClassFactory.GetITreasureDataProvider(kindID);
		}
		public DataSet GetPaySetting()
		{
			string sqlQuery = "SELECT ID,QudaoName FROM T_PayQudaoInfo WHERE IsShow=1 ORDER BY SortID ASC;SELECT QudaoID,Limit FROM T_QudaoLimit";
			return this.treasureData.GetDataSetByWhere(sqlQuery);
		}
		public Message RequestOrder(OnLineOrder orderInfo)
		{
			return this.treasureData.RequestOrder(orderInfo);
		}
		public void WriteReturnDayDetail(ReturnDayDetailInfo returnDay)
		{
			this.treasureData.WriteReturnDayDetail(returnDay);
		}
		public void WriteReturnKQDetail(ReturnKQDetailInfo returnKQ)
		{
			this.treasureData.WriteReturnKQDetail(returnKQ);
		}
		public Message WriteReturnVBDetail(ReturnVBDetailInfo returnVB)
		{
			return this.treasureData.WriteReturnVBDetail(returnVB);
		}
		public Message WriteReturnYBDetail(ReturnYPDetailInfo returnYB)
		{
			return this.treasureData.WriteReturnYBDetail(returnYB);
		}
		public Message FilliedOnline(ShareDetialInfo olDetial, int isVB)
		{
			return this.treasureData.FilliedOnline(olDetial, isVB);
		}
		public Message FilliedApp(ShareDetialInfo olDetial, string productID)
		{
			return this.treasureData.FilliedApp(olDetial, productID);
		}
		public Message FilliedMobile(ShareDetialInfo olDetial)
		{
			return this.treasureData.FilliedMobile(olDetial);
		}
		public Message FilledLivcard(ShareDetialInfo detialInfo, string password)
		{
			return this.treasureData.FilledLivcard(detialInfo, password);
		}
		public OnLineOrder GetOnlineOrder(string orderID)
		{
			return this.treasureData.GetOnlineOrder(orderID);
		}
		public DataSet GetAppList()
		{
			return this.treasureData.GetAppList();
		}
		public DataSet GetAppListByTagID(int tagID)
		{
			return this.treasureData.GetAppListByTagID(tagID);
		}
		public DataSet GetAppInfoByProductID(string productID)
		{
			return this.treasureData.GetAppInfoByProductID(productID);
		}

        public void WriteOffLinePayment( OffLinePayOrders OffLinePayOrdersInfo)
        {
            this.treasureData.WriteOffLinePayment(OffLinePayOrdersInfo);
        }
        public void WriteReturnAppDetail(ShareDetialInfo detialInfo, AppReceiptInfo receipt)
		{
			this.treasureData.WriteReturnAppDetail(detialInfo, receipt);
		}
		public DataTable GetPayList()
		{
			string sqlQuery = "SELECT * FROM View_PayInfo WHERE Nullity=0 Order BY SortID";
			return this.treasureData.GetDataSetByWhere(sqlQuery).Tables[0];
		}
		public DataTable GetPayInfo(int qudaoId)
		{
			string sqlQuery = "SELECT TOP 1 * FROM View_PayInfo WHERE Nullity=0 AND QudaoID=" + qudaoId + " ORDER BY NEWID()";
			return this.treasureData.GetDataSetByWhere(sqlQuery).Tables[0];
		}

        public DataTable GetOffPayQrCodeInfo()
        {
            string sqlQuery = "SELECT * FROM View_OffLinePayQrCode";
            return this.treasureData.GetDataSetByWhere(sqlQuery).Tables[0];
          
        }

		public PagerSet GetPayRecord(string whereQuery, int pageIndex, int pageSize)
		{
			return this.treasureData.GetPayRecord(whereQuery, pageIndex, pageSize);
		}
		public PagerSet GetPayRecord(string whereQuery, int pageIndex, int pageSize, string[] returnField = null)
		{
			return this.treasureData.GetPayRecord(whereQuery, pageIndex, pageSize, returnField);
		}
		public Message GetUserSpreadInfo(int userID)
		{
			return this.treasureData.GetUserSpreadInfo(userID);
		}
		public Message GetUserSpreadBalance(int balance, int userID, string ip)
		{
			return this.treasureData.GetUserSpreadBalance(balance, userID, ip);
		}
		public PagerSet GetSpreaderRecord(string whereQuery, int pageIndex, int pageSize)
		{
			return this.treasureData.GetSpreaderRecord(whereQuery, pageIndex, pageSize);
		}
		public DataSet GetUserSpreaderList(int userID, int pageIndex, int pageSize)
		{
			return this.treasureData.GetUserSpreaderList(userID, pageIndex, pageSize);
		}
		public long GetUserSpreaderTotal(string sWhere)
		{
			return this.treasureData.GetUserSpreaderTotal(sWhere);
		}
		public GlobalSpreadInfo GetGlobalSpreadInfo()
		{
			return this.treasureData.GetGlobalSpreadInfo();
		}
		public Message InsureIn(int userID, long TradeScore, string clientIP, string note)
		{
			return this.treasureData.InsureIn(userID, TradeScore, clientIP, note);
		}
		public Message InsureOut(int userID, string insurePass, long TradeScore, string clientIP, string note)
		{
			return this.treasureData.InsureOut(userID, insurePass, TradeScore, clientIP, note);
		}
		public Message InsureTransfer(int srcUserID, string insurePass, int dstUserID, long TradeScore, string clientIP, string note)
		{
			return this.treasureData.InsureTransfer(srcUserID, insurePass, dstUserID, TradeScore, clientIP, note);
		}
		public PagerSet GetInsureTradeRecord(string whereQuery, int pageIndex, int pageSize)
		{
			return this.treasureData.GetInsureTradeRecord(whereQuery, pageIndex, pageSize);
		}
		public GameScoreInfo GetTreasureInfo2(int UserID)
		{
			if (this.treasureData == null)
			{
				return null;
			}
			return this.treasureData.GetTreasureInfo2(UserID);
		}
		public UserRoomCard GetUserRoomCard(int userID)
		{
			return this.treasureData.GetUserRoomCard(userID);
		}
		public System.Collections.Generic.IList<GameScoreInfo> GetGameScoreInfoOrderByScore()
		{
			return this.treasureData.GetGameScoreInfoOrderByScore();
		}
		public DataSet GetScoreRanking(int num)
		{
			return this.treasureData.GetScoreRanking(num);
		}
		public UserCurrencyInfo GetUserCurrencyInfo(int userId)
		{
			return this.treasureData.GetUserCurrencyInfo(userId);
		}
		public Message ClearGameScore(int userID, string ip)
		{
			return this.treasureData.ClearGameScore(userID, ip);
		}
		public Message ClearGameFlee(int userID, string ip)
		{
			return this.treasureData.ClearGameFlee(userID, ip);
		}
		public PagerSet GetDrawInfoRecord(string whereQuery, int pageIndex, int pageSize)
		{
			return this.treasureData.GetDrawInfoRecord(whereQuery, pageIndex, pageSize);
		}
		public PagerSet GetDrawScoreRecord(string whereQuery, int pageIndex, int pageSize)
		{
			return this.treasureData.GetDrawScoreRecord(whereQuery, pageIndex, pageSize);
		}
		public PagerSet GetList(string tableName, int pageIndex, int pageSize, string pkey, string whereQuery)
		{
			return this.treasureData.GetList(tableName, pageIndex, pageSize, pkey, whereQuery);
		}
		public PagerSet GetList(string tableName, int pageIndex, int pageSize, string pkey, string whereQuery, string fieldsList)
		{
			string[] fields = fieldsList.Split(new char[]
			{
				','
			});
			return this.treasureData.GetList(tableName, pageIndex, pageSize, pkey, whereQuery, fields);
		}
		public DataSet GetDataSetByWhere(string sqlQuery)
		{
			return this.treasureData.GetDataSetByWhere(sqlQuery);
		}
		public DataSet GetDataSetBySql(string sqlQuery)
		{
			return this.treasureData.GetDataSetByWhere(sqlQuery);
		}
		public T GetEntity<T>(string commandText, System.Collections.Generic.List<DbParameter> parms)
		{
			return this.treasureData.GetEntity<T>(commandText, parms);
		}
		public T GetEntity<T>(string commandText)
		{
			return this.treasureData.GetEntity<T>(commandText);
		}
		public Message WriteCheckIn(int userID, string strClientIP)
		{
			return this.treasureData.WriteCheckIn(userID, strClientIP);
		}
		public DataSet GetMemberCardList()
		{
			return this.treasureData.GetMemberCardList();
		}
		public MemberCard GetMemberCard(int cardID)
		{
			return this.treasureData.GetMemberCard(cardID);
		}
		public Message CurrencyExchange(int userID, int cardID, int num, string insurePassword, string IP)
		{
			return this.treasureData.CurrencyExchange(userID, cardID, num, insurePassword, IP);
		}
		public System.Collections.Generic.IList<UserGameInfo> GetUserGameGrandTotalRank(int number, int dateID)
		{
			return this.treasureData.GetUserGameGrandTotalRank(number, dateID);
		}
		public System.Collections.Generic.IList<UserGameInfo> GetUserGameWinMaxRank(int number, int dateID)
		{
			return this.treasureData.GetUserGameWinMaxRank(number, dateID);
		}
		public long GetChildRevenueProvide(int userID)
		{
			return this.treasureData.GetChildRevenueProvide(userID);
		}
		public long GetChildPayProvide(int userID)
		{
			return this.treasureData.GetChildPayProvide(userID);
		}
		public DataSet GetAgentFinance(int userID)
		{
			return this.treasureData.GetAgentFinance(userID);
		}
		public Message GetAgentBalance(int balance, int userID, string ip)
		{
			return this.treasureData.GetAgentBalance(balance, userID, ip);
		}
		public LotteryConfig GetLotteryConfig()
		{
			return this.treasureData.GetLotteryConfig();
		}
		public System.Collections.Generic.IList<LotteryItem> GetLotteryItem()
		{
			return this.treasureData.GetLotteryItem();
		}
		public Message GetLotteryUserInfo(int userID, string password)
		{
			return this.treasureData.GetLotteryUserInfo(userID, password);
		}
		public Message GetLotteryStart(int userID, string password, string ip)
		{
			return this.treasureData.GetLotteryStart(userID, password, ip);
		}
		public Message SharePresent(int userID, string password, string machineID, string ip)
		{
			return this.treasureData.SharePresent(userID, password, machineID, ip);
		}
		public DataTable GetType(string tabName)
		{
			string sqlQuery = "SELECT ID,TypeName,IsShow FROM RecordType WHERE TabName='" + tabName + "'";
			return this.treasureData.GetDataSetByWhere(sqlQuery).Tables[0];
		}
		public DataTable GetSpreadLevCfg()
		{
			string sqlQuery = "SELECT * FROM RYAgentDB.dbo.view_SpreadLevCfg";
			return this.GetDataSetBySql(sqlQuery).Tables[0];
		}
		public DataTable GetMySpread(int uid)
		{
			string sqlQuery = "EXEC RYAgentDB.dbo.P_QueryYjSpread " + uid;
			return this.GetDataSetBySql(sqlQuery).Tables[0];
		}
		public DataTable GetMyLowerMember(int uid)
		{
			string sqlQuery = "EXEC RYAgentDB.dbo.P_QueryDownSpread " + uid + ",0";
			return this.GetDataSetBySql(sqlQuery).Tables[0];
		}
        public int ExecuteNonQuery(string sql)
        {
            return this.ExecuteNonQuery(sql);
        }
        public int ExecuteNonQuery(string sql, params SqlParameter[] cmdParms)
        {
            return this.treasureData.ExecuteNonQuery(sql, cmdParms);
        }
	}
}
