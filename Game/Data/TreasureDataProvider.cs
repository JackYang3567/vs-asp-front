using Game.Entity.Treasure;
using Game.IData;
using Game.Kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
namespace Game.Data
{
	public class TreasureDataProvider : BaseDataProvider, ITreasureDataProvider
	{
		public TreasureDataProvider(string connString) : base(connString)
		{
		}
		public Message RequestOrder(OnLineOrder orderInfo)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwOperUserID", orderInfo.OperUserID));
			list.Add(base.Database.MakeInParam("dwShareID", orderInfo.ShareID));
			list.Add(base.Database.MakeInParam("strAccounts", orderInfo.Accounts));
			list.Add(base.Database.MakeInParam("strOrderID", orderInfo.OrderID));
			list.Add(base.Database.MakeInParam("dcOrderAmount", orderInfo.OrderAmount));
			list.Add(base.Database.MakeInParam("strIPAddress", orderInfo.IPAddress));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessageForObject<OnLineOrder>(base.Database, "NET_PW_ApplyOnLineOrder", list);
		}
		public void WriteReturnDayDetail(ReturnDayDetailInfo returnDay)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("@OrderID", returnDay.OrderID));
			list.Add(base.Database.MakeInParam("@MerID", returnDay.MerID));
			list.Add(base.Database.MakeInParam("@PayMoney", returnDay.PayMoney));
			list.Add(base.Database.MakeInParam("@UserName", returnDay.UserName));
			list.Add(base.Database.MakeInParam("@Sign", returnDay.Sign));
			list.Add(base.Database.MakeInParam("@PayType", returnDay.PayType));
			list.Add(base.Database.MakeInParam("@Status", returnDay.Status));
			base.Database.RunProc("NET_PW_AddReturnDayInfo", list);
		}
		public void WriteReturnKQDetail(ReturnKQDetailInfo returnKQ)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("strMerchantAcctID", returnKQ.MerchantAcctID));
			list.Add(base.Database.MakeInParam("strVersion", returnKQ.Version));
			list.Add(base.Database.MakeInParam("dwLanguage", returnKQ.Language));
			list.Add(base.Database.MakeInParam("dwSignType", returnKQ.SignType));
			list.Add(base.Database.MakeInParam("strPayType", returnKQ.PayType));
			list.Add(base.Database.MakeInParam("strBankID", returnKQ.BankID));
			list.Add(base.Database.MakeInParam("strOrderID", returnKQ.OrderID));
			list.Add(base.Database.MakeInParam("dtOrderTime", returnKQ.OrderTime));
			list.Add(base.Database.MakeInParam("fOrderAmount", returnKQ.OrderAmount));
			list.Add(base.Database.MakeInParam("strDealID", returnKQ.DealID));
			list.Add(base.Database.MakeInParam("strBankDealID", returnKQ.BankDealID));
			list.Add(base.Database.MakeInParam("dtDealTime", returnKQ.DealTime));
			list.Add(base.Database.MakeInParam("fPayAmount", returnKQ.PayAmount));
			list.Add(base.Database.MakeInParam("fFee", returnKQ.Fee));
			list.Add(base.Database.MakeInParam("strPayResult", returnKQ.PayResult));
			list.Add(base.Database.MakeInParam("strErrCode", returnKQ.ErrCode));
			list.Add(base.Database.MakeInParam("strSignMsg", returnKQ.SignMsg));
			list.Add(base.Database.MakeInParam("strExt1", returnKQ.Ext1));
			list.Add(base.Database.MakeInParam("strExt2", returnKQ.Ext2));
			list.Add(base.Database.MakeInParam("CardNumber", returnKQ.CardNumber));
			list.Add(base.Database.MakeInParam("CardPwd", returnKQ.CardPwd));
			list.Add(base.Database.MakeInParam("BossType", returnKQ.BossType));
			list.Add(base.Database.MakeInParam("ReceiveBossType", returnKQ.ReceiveBossType));
			list.Add(base.Database.MakeInParam("ReceiverAcctId", returnKQ.ReceiverAcctId));
			base.Database.RunProc("NET_PW_AddReturnKQInfo", list);
		}
		public Message WriteReturnVBDetail(ReturnVBDetailInfo returnVB)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("Rtmd5", returnVB.Rtmd5));
			list.Add(base.Database.MakeInParam("Rtka", returnVB.Rtka));
			list.Add(base.Database.MakeInParam("Rtmi", returnVB.Rtmi));
			list.Add(base.Database.MakeInParam("Rtmz", returnVB.Rtmz));
			list.Add(base.Database.MakeInParam("Rtlx", returnVB.Rtlx));
			list.Add(base.Database.MakeInParam("Rtoid", returnVB.Rtoid));
			list.Add(base.Database.MakeInParam("OrderID", returnVB.OrderID));
			list.Add(base.Database.MakeInParam("Rtuserid", returnVB.Rtuserid));
			list.Add(base.Database.MakeInParam("Rtcustom", returnVB.Rtcustom));
			list.Add(base.Database.MakeInParam("Rtflag", returnVB.Rtflag));
			list.Add(base.Database.MakeInParam("EcryptStr", returnVB.EcryptStr));
			list.Add(base.Database.MakeInParam("SignMsg", returnVB.SignMsg));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "NET_PW_AddReturnVBInfo", list);
		}
		public Message WriteReturnYBDetail(ReturnYPDetailInfo returnYB)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("p1_MerId", returnYB.P1_MerId));
			list.Add(base.Database.MakeInParam("r0_Cmd", returnYB.R0_Cmd));
			list.Add(base.Database.MakeInParam("r1_Code", returnYB.R1_Code));
			list.Add(base.Database.MakeInParam("r2_TrxId", returnYB.R2_TrxId));
			list.Add(base.Database.MakeInParam("r3_Amt", returnYB.R3_Amt));
			list.Add(base.Database.MakeInParam("r4_Cur", returnYB.R4_Cur));
			list.Add(base.Database.MakeInParam("r5_Pid", returnYB.R5_Pid));
			list.Add(base.Database.MakeInParam("r6_Order", returnYB.R6_Order));
			list.Add(base.Database.MakeInParam("r7_Uid", returnYB.R7_Uid));
			list.Add(base.Database.MakeInParam("r8_MP", returnYB.R8_MP));
			list.Add(base.Database.MakeInParam("r9_BType", returnYB.R9_BType));
			list.Add(base.Database.MakeInParam("rb_BankId", returnYB.Rb_BankId));
			list.Add(base.Database.MakeInParam("ro_BankOrderId", returnYB.Ro_BankOrderId));
			list.Add(base.Database.MakeInParam("rp_PayDate", returnYB.Rp_PayDate));
			list.Add(base.Database.MakeInParam("rq_CardNo", returnYB.Rq_CardNo));
			list.Add(base.Database.MakeInParam("ru_Trxtime", returnYB.Ru_Trxtime));
			list.Add(base.Database.MakeInParam("hmac", returnYB.Hmac));
			return MessageHelper.GetMessage(base.Database, "NET_PW_AddReturnYBInfo", list);
		}
		public Message FilliedOnline(ShareDetialInfo olDetial, int isVB)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("strOrdersID", olDetial.OrderID));
			list.Add(base.Database.MakeInParam("PayAmount", System.Convert.ToDecimal(olDetial.PayAmount)));
			list.Add(base.Database.MakeInParam("isVB", isVB));
			list.Add(base.Database.MakeInParam("strIPAddress", olDetial.IPAddress));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "NET_PW_FilledOnLine", list);
		}
		public Message FilliedApp(ShareDetialInfo olDetial, string productID)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", olDetial.UserID));
			list.Add(base.Database.MakeInParam("strOrdersID", olDetial.OrderID));
			list.Add(base.Database.MakeInParam("PayAmount", olDetial.PayAmount));
			list.Add(base.Database.MakeInParam("strProductID", productID));
			list.Add(base.Database.MakeInParam("dwShareID", olDetial.ShareID));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "NET_PW_FilledApp", list);
		}
		public Message FilliedMobile(ShareDetialInfo olDetial)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("strOrdersID", olDetial.OrderID));
			list.Add(base.Database.MakeInParam("PayAmount", olDetial.PayAmount));
			list.Add(base.Database.MakeInParam("strIPAddress", olDetial.IPAddress));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "NET_PW_FilledMobile", list);
		}
		public Message FilledLivcard(ShareDetialInfo detialInfo, string password)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwOperUserID", detialInfo.OperUserID));
			list.Add(base.Database.MakeInParam("strSerialID", detialInfo.SerialID));
			list.Add(base.Database.MakeInParam("strPassword", password));
			list.Add(base.Database.MakeInParam("strAccounts", detialInfo.Accounts));
			list.Add(base.Database.MakeInParam("strClientIP", detialInfo.IPAddress));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "NET_PW_FilledLivcard", list);
		}
		public OnLineOrder GetOnlineOrder(string orderID)
		{
			string commandText = string.Format("SELECT * FROM OnLineOrder(NOLOCK) WHERE OrderID=@OrderID", new object[0]);
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("OrderID", orderID));
			return base.Database.ExecuteObject<OnLineOrder>(commandText, list);
		}
		public System.Data.DataSet GetAppList()
		{
			string commandText = string.Format("SELECT AppID,ProductID,ProductName,Description,Price,AttachCurrency,SortID,PresentCurrency FROM GlobalAppInfo(NOLOCK) ORDER BY SortID ASC", new object[0]);
			return base.Database.ExecuteDataset(System.Data.CommandType.Text, commandText);
		}
		public System.Data.DataSet GetAppListByTagID(int tagID)
		{
			string commandText = string.Format("SELECT AppID,ProductID,ProductName,Description,Price,AttachCurrency,SortID,PresentCurrency FROM GlobalAppInfo(NOLOCK) WHERE TagID={0} ORDER BY AppID ASC", tagID);
			return base.Database.ExecuteDataset(System.Data.CommandType.Text, commandText);
		}
		public System.Data.DataSet GetAppInfoByProductID(string productID)
		{
			string commandText = string.Format("SELECT ProductID,ProductName,Description,Price FROM GlobalAppInfo(NOLOCK) WHERE ProductID=@ProductID", new object[0]);
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("ProductID", productID));
			return base.Database.ExecuteDataset(System.Data.CommandType.Text, commandText, list.ToArray());
		}

        public void WriteOffLinePayment( OffLinePayOrders OffLinePayOrdersInfo)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
           // stringBuilder.Append("INSERT INTO OffLinePayOrders(Accounts,OrderID,PayAmount,ApplyDate)");
           stringBuilder.Append("INSERT INTO OffLinePayOrders(Accounts,OrderID,PayAmount,PaymentType,BankName,ApplyDate)");
            stringBuilder.Append(" VALUES(");
           // stringBuilder.Append("@Accounts,@OrderID,@PayAmount,@ApplyDate)");
                  stringBuilder.Append("@Accounts,@OrderID,@PayAmount,@PaymentType,@BankName,@ApplyDate)");
            System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
            list.Add(base.Database.MakeInParam("Accounts", OffLinePayOrdersInfo.Accounts));
            list.Add(base.Database.MakeInParam("OrderID", OffLinePayOrdersInfo.OrderID));
            list.Add(base.Database.MakeInParam("PayAmount", OffLinePayOrdersInfo.PayAmount));
            list.Add(base.Database.MakeInParam("ApplyDate", OffLinePayOrdersInfo.ApplyDate));
            list.Add(base.Database.MakeInParam("PaymentType", OffLinePayOrdersInfo.PaymentType));
            list.Add(base.Database.MakeInParam("BankName", OffLinePayOrdersInfo.BankName));

           
            base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
        }

		public void WriteReturnAppDetail(ShareDetialInfo detialInfo, AppReceiptInfo receipt)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("INSERT INTO ReturnAppDetailInfo(UserID,OrderID,PayAmount,Status,quantity,product_id,transaction_id,purchase_date,original_transaction_id,");
			stringBuilder.Append("original_purchase_date,app_item_id,version_external_identifier,bid,bvrs)");
			stringBuilder.Append(" VALUES(");
			stringBuilder.Append("@UserID,@OrderID,@PayAmount,@Status,@quantity,@product_id,@transaction_id,@purchase_date,@original_transaction_id,");
			stringBuilder.Append("@original_purchase_date,@app_item_id,@version_external_identifier,@bid,@bvrs)");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("UserID", detialInfo.UserID));
			list.Add(base.Database.MakeInParam("OrderID", detialInfo.OrderID));
			list.Add(base.Database.MakeInParam("PayAmount", detialInfo.PayAmount));
			list.Add(base.Database.MakeInParam("Status", receipt.Status));
			list.Add(base.Database.MakeInParam("quantity", receipt.Receipt.quantity));
			list.Add(base.Database.MakeInParam("product_id", receipt.Receipt.product_id));
			list.Add(base.Database.MakeInParam("transaction_id", receipt.Receipt.transaction_id));
			list.Add(base.Database.MakeInParam("purchase_date", receipt.Receipt.purchase_date));
			list.Add(base.Database.MakeInParam("original_transaction_id", receipt.Receipt.original_transaction_id));
			list.Add(base.Database.MakeInParam("original_purchase_date", receipt.Receipt.original_purchase_date));
			list.Add(base.Database.MakeInParam("app_item_id", receipt.Receipt.app_item_id));
			list.Add(base.Database.MakeInParam("version_external_identifier", receipt.Receipt.version_external_identifier));
			list.Add(base.Database.MakeInParam("bid", receipt.Receipt.bid));
			list.Add(base.Database.MakeInParam("bvrs", receipt.Receipt.bvrs));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public PagerSet GetPayRecord(string whereQuery, int pageIndex, int pageSize)
		{
			string pkey = "ORDER By ApplyDate DESC";
			string[] fields = new string[]
			{
				"DetailID",
				"OperUserID",
				"ShareID",
				"UserID",
				"GameID",
				"Accounts",
				"SerialID",
				"OrderID",
				"CardTypeID",
				"Currency",
				"BeforeCurrency",
				"OrderAmount",
				"DiscountScale",
				"PayAmount",
				"IPAddress",
				"ApplyDate"
			};
			return this.GetPagerSet2(new PagerParameters("ShareDetailInfo", pkey, whereQuery, pageIndex, pageSize)
			{
				Fields = fields,
				CacherSize = 2
			});
		}
		public PagerSet GetPayRecord(string whereQuery, int pageIndex, int pageSize, string[] returnField = null)
		{
			string pkey = "ORDER By ApplyDate DESC";
			returnField = ((returnField == null) ? new string[]
			{
				"DetailID",
				"OperUserID",
				"ShareID",
				"UserID",
				"GameID",
				"Accounts",
				"SerialID",
				"OrderID",
				"CardTypeID",
				"Currency",
				"BeforeCurrency",
				"OrderAmount",
				"DiscountScale",
				"PayAmount",
				"IPAddress",
				"ApplyDate"
			} : returnField);
			return this.GetPagerSet2(new PagerParameters("ShareDetailInfo", pkey, whereQuery, pageIndex, pageSize)
			{
				Fields = returnField,
				CacherSize = 2
			});
		}
		public Message GetUserSpreadInfo(int userID)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", userID));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessageForObject<RecordSpreadInfo>(base.Database, "NET_PW_GetUserSpreadInfo", list);
		}
		public Message GetUserSpreadBalance(int balance, int userID, string ip)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", userID));
			list.Add(base.Database.MakeInParam("dwBalance", balance));
			list.Add(base.Database.MakeInParam("strClientIP", ip));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "NET_PW_SpreadBalance", list);
		}
		public PagerSet GetSpreaderRecord(string whereQuery, int pageIndex, int pageSize)
		{
			string pkey = "ORDER By CollectDate DESC";
			string[] fields = new string[]
			{
				"RecordID",
				"UserID",
				"Score",
				"TypeID",
				"ChildrenID",
				"InsureScore",
				"CollectDate",
				"CollectNote"
			};
			return this.GetPagerSet2(new PagerParameters("RecordSpreadInfo", pkey, whereQuery, pageIndex, pageSize)
			{
				Fields = fields,
				CacherSize = 2
			});
		}
		public System.Data.DataSet GetUserSpreaderList(int userID, int pageIndex, int pageSize)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", userID));
			list.Add(base.Database.MakeInParam("dwPageIndex", pageIndex));
			list.Add(base.Database.MakeInParam("dwPageSize", pageSize));
			System.Data.DataSet result = new System.Data.DataSet();
			base.Database.RunProc("NET_PW_GetAllChildrenInfoByUserID", list, out result);
			return result;
		}
		public long GetUserSpreaderTotal(string sWhere)
		{
			string text = "SELECT SUM(Score) AS Score FROM RecordSpreadInfo ";
			if (sWhere != "" && sWhere != null)
			{
				text += sWhere;
			}
			RecordSpreadInfo recordSpreadInfo = base.Database.ExecuteObject<RecordSpreadInfo>(text);
			long result;
			if (recordSpreadInfo != null)
			{
				result = recordSpreadInfo.Score;
			}
			else
			{
				result = 0L;
			}
			return result;
		}
		public GlobalSpreadInfo GetGlobalSpreadInfo()
		{
			string commandText = "SELECT TOP 1 * FROM GlobalSpreadInfo ORDER BY ID DESC";
			return base.Database.ExecuteObject<GlobalSpreadInfo>(commandText);
		}
		public Message InsureIn(int userID, long TradeScore, string clientIP, string note)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", userID));
			list.Add(base.Database.MakeInParam("dwSwapScore", TradeScore));
			list.Add(base.Database.MakeInParam("strClientIP", clientIP));
			list.Add(base.Database.MakeInParam("strCollectNote", note));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessageForObject<GameScoreInfo>(base.Database, "NET_PW_InsureIn", list);
		}
		public Message InsureOut(int userID, string insurePass, long TradeScore, string clientIP, string note)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", userID));
			list.Add(base.Database.MakeInParam("strInsurePass", insurePass));
			list.Add(base.Database.MakeInParam("dwSwapScore", TradeScore));
			list.Add(base.Database.MakeInParam("strClientIP", clientIP));
			list.Add(base.Database.MakeInParam("strCollectNote", note));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessageForObject<GameScoreInfo>(base.Database, "NET_PW_InsureOut", list);
		}
		public Message InsureTransfer(int srcUserID, string insurePass, int dstUserID, long TradeScore, string clientIP, string note)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwSrcUserID", srcUserID));
			list.Add(base.Database.MakeInParam("strInsurePass", insurePass));
			list.Add(base.Database.MakeInParam("dwDstUserID", dstUserID));
			list.Add(base.Database.MakeInParam("dwSwapScore", TradeScore));
			list.Add(base.Database.MakeInParam("strClientIP", clientIP));
			list.Add(base.Database.MakeInParam("strCollectNote", note));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "NET_PW_InsureTransfer", list);
		}
		public PagerSet GetInsureTradeRecord(string whereQuery, int pageIndex, int pageSize)
		{
			string pkey = "ORDER By CollectDate DESC";
			string[] fields = new string[]
			{
				"RecordID",
				"KindID",
				"ServerID",
				"SourceUserID",
				"SourceGold",
				"SourceBank",
				"TargetUserID",
				"TargetGold",
				"TargetBank",
				"SwapScore",
				"Revenue",
				"IsGamePlaza",
				"TradeType",
				"ClientIP",
				"CollectDate",
				"CollectNote"
			};
			return this.GetPagerSet2(new PagerParameters("RecordInsure", pkey, whereQuery, pageIndex, pageSize)
			{
				Fields = fields,
				CacherSize = 2
			});
		}
		public GameScoreInfo GetTreasureInfo2(int UserID)
		{
			string commandText = string.Format("SELECT * FROM GameScoreInfo(NOLOCK) WHERE UserID={0}", UserID);
			return base.Database.ExecuteObject<GameScoreInfo>(commandText);
		}
		public UserRoomCard GetUserRoomCard(int userID)
		{
			string commandText = string.Format("SELECT * FROM UserRoomCard(NOLOCK) WHERE UserID= {0}", userID);
			UserRoomCard userRoomCard = base.Database.ExecuteObject<UserRoomCard>(commandText);
			UserRoomCard result;
			if (userRoomCard != null)
			{
				result = userRoomCard;
			}
			else
			{
				result = new UserRoomCard();
			}
			return result;
		}
		public System.Collections.Generic.IList<GameScoreInfo> GetGameScoreInfoOrderByScore()
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("SELECT TOP 10 UserID, Score, InsureScore ").Append(" FROM GameScoreInfo ").Append(" ORDER BY Score DESC,InsureScore DESC ");
			return base.Database.ExecuteObjectList<GameScoreInfo>(stringBuilder.ToString());
		}
		public System.Data.DataSet GetScoreRanking(int num)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.AppendFormat("SELECT TOP {0} A.UserID,Score,NickName,Nullity,GameID,WinCount,LostCount ", num).Append(" FROM GameScoreInfo AS A LEFT JOIN RYAccountsDBLink.RYAccountsDB.dbo.AccountsInfo AS B ").Append(" ON A.UserID = B.UserID WHERE B.Nullity=0 AND Score>0 AND IsAndroid=0 ORDER BY A.Score DESC ");
			return base.Database.ExecuteDataset(stringBuilder.ToString());
		}
		public UserCurrencyInfo GetUserCurrencyInfo(int userId)
		{
			string commandText = "SELECT * FROM UserCurrencyInfo WHERE UserID=@UserID";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("UserID", userId));
			return base.Database.ExecuteObject<UserCurrencyInfo>(commandText, list);
		}
		public Message ClearGameScore(int userID, string ip)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", userID));
			list.Add(base.Database.MakeInParam("strClientIP", ip));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "NET_PW_ResetGameScore", list);
		}
		public Message ClearGameFlee(int userID, string ip)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", userID));
			list.Add(base.Database.MakeInParam("strClientIP", ip));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "NET_PW_ResetGameFlee", list);
		}
		public PagerSet GetDrawInfoRecord(string whereQuery, int pageIndex, int pageSize)
		{
			string pkey = "ORDER By InsertTime DESC";
			string[] fields = new string[]
			{
				"DrawID",
				"KindID",
				"ServerID",
				"TableID",
				"UserCount",
				"AndroidCount",
				"Waste",
				"Revenue",
				"UserMedal",
				"StartTime",
				"ConcludeTime",
				"InsertTime",
				"DrawCourse"
			};
			return this.GetPagerSet2(new PagerParameters("RecordDrawInfo", pkey, whereQuery, pageIndex, pageSize)
			{
				Fields = fields,
				CacherSize = 2
			});
		}
		public PagerSet GetDrawScoreRecord(string whereQuery, int pageIndex, int pageSize)
		{
			string pkey = "ORDER By InsertTime DESC";
			string[] fields = new string[]
			{
				"DrawID",
				"UserID",
				"ChairID",
				"Score",
				"Grade",
				"Revenue",
				"UserMedal",
				"PlayTimeCount",
				"InsertTime"
			};
			return this.GetPagerSet2(new PagerParameters("RecordDrawScore", pkey, whereQuery, pageIndex, pageSize)
			{
				Fields = fields,
				CacherSize = 2
			});
		}
		public PagerSet GetList(string tableName, int pageIndex, int pageSize, string pkey, string whereQuery)
		{
			return this.GetPagerSet2(new PagerParameters(tableName, pkey, whereQuery, pageIndex, pageSize)
			{
				CacherSize = 2
			});
		}
		public PagerSet GetList(string tableName, int pageIndex, int pageSize, string pkey, string whereQuery, string[] fields)
		{
			return this.GetPagerSet2(new PagerParameters(tableName, pkey, whereQuery, pageIndex, pageSize, fields)
			{
				CacherSize = 2
			});
		}
		public System.Data.DataSet GetDataSetByWhere(string sqlQuery)
		{
			return base.Database.ExecuteDataset(sqlQuery);
		}
		public T GetEntity<T>(string commandText, System.Collections.Generic.List<System.Data.Common.DbParameter> parms)
		{
			return base.Database.ExecuteObject<T>(commandText, parms);
		}
		public T GetEntity<T>(string commandText)
		{
			return base.Database.ExecuteObject<T>(commandText);
		}
		public Message WriteCheckIn(int userID, string strClientIP)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", userID));
			list.Add(base.Database.MakeInParam("strClientIP", strClientIP));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "NET_PW_WriteCheckIn", list);
		}
		public System.Data.DataSet GetMemberCardList()
		{
			string commandText = "SELECT * FROM MemberCard";
			return base.Database.ExecuteDataset(commandText);
		}
		public MemberCard GetMemberCard(int cardID)
		{
			string commandText = "SELECT * FROM MemberCard WHERE CardID=@CardID";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("CardID", cardID));
			return base.Database.ExecuteObject<MemberCard>(commandText, list);
		}
		public Message CurrencyExchange(int userID, int cardID, int num, string insurePassword, string IP)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", userID));
			list.Add(base.Database.MakeInParam("dwCardID", cardID));
			list.Add(base.Database.MakeInParam("dwNum", num));
			list.Add(base.Database.MakeInParam("strInsurePassword", insurePassword));
			list.Add(base.Database.MakeInParam("strClientIP", IP));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "WSP_PW_CurrencyExchange", list);
		}
		public System.Collections.Generic.IList<UserGameInfo> GetUserGameGrandTotalRank(int number, int dateID)
		{
			string commandText = string.Format("SELECT TOP({0}) * FROM UserGameInfo_Line WHERE DateID=@DateID AND LineGrandTotal>0 ORDER BY LineGrandTotal DESC", number);
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("DateID", dateID));
			return base.Database.ExecuteObjectList<UserGameInfo>(commandText, list);
		}
		public System.Collections.Generic.IList<UserGameInfo> GetUserGameWinMaxRank(int number, int dateID)
		{
			string commandText = string.Format("SELECT TOP({0}) * FROM UserGameInfo_Line WHERE DateID=@DateID AND LineWinMax>0 ORDER BY LineWinMax DESC", number);
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("DateID", dateID));
			return base.Database.ExecuteObjectList<UserGameInfo>(commandText, list);
		}
		public long GetChildRevenueProvide(int userID)
		{
			string commandText = string.Format("SELECT ISNULL(SUM(AgentRevenue),0) FROM RecordUserRevenue WHERE UserID= {0}", userID);
			object obj = base.Database.ExecuteScalar(System.Data.CommandType.Text, commandText);
			long result;
			if (obj == null || obj.ToString().Length <= 0)
			{
				result = 0L;
			}
			else
			{
				result = System.Convert.ToInt64(obj);
			}
			return result;
		}
		public long GetChildPayProvide(int userID)
		{
			string commandText = string.Format("SELECT ISNULL(SUM(Score),0) FROM RecordAgentInfo WHERE ChildrenID= {0} AND TypeID=1", userID);
			object obj = base.Database.ExecuteScalar(System.Data.CommandType.Text, commandText);
			long result;
			if (obj == null || obj.ToString().Length <= 0)
			{
				result = 0L;
			}
			else
			{
				result = System.Convert.ToInt64(obj);
			}
			return result;
		}
		public System.Data.DataSet GetAgentFinance(int userID)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", userID));
			return base.Database.ExecuteDataset(System.Data.CommandType.StoredProcedure, "WSP_PM_GetAgentFinance", list.ToArray());
		}
		public Message GetAgentBalance(int balance, int userID, string ip)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", userID));
			list.Add(base.Database.MakeInParam("dwBalance", balance));
			list.Add(base.Database.MakeInParam("strClientIP", ip));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "NET_PW_AgentBalance", list);
		}
		public LotteryConfig GetLotteryConfig()
		{
			string commandText = string.Format("SELECT * FROM LotteryConfig(NOLOCK) WHERE ID=1", new object[0]);
			return base.Database.ExecuteObject<LotteryConfig>(commandText);
		}
		public System.Collections.Generic.IList<LotteryItem> GetLotteryItem()
		{
			string commandText = "SELECT * FROM LotteryItem";
			return base.Database.ExecuteObjectList<LotteryItem>(commandText);
		}
		public Message GetLotteryUserInfo(int userID, string password)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", userID));
			list.Add(base.Database.MakeInParam("strLogonPass", password));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessageForObject<LotteryUserInfo>(base.Database, "NET_PW_LotteryUserInfo", list);
		}
		public Message GetLotteryStart(int userID, string password, string ip)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", userID));
			list.Add(base.Database.MakeInParam("strLogonPass", password));
			list.Add(base.Database.MakeInParam("strClientIP", ip));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessageForObject<LotteryReturn>(base.Database, "NET_PW_LotteryStart", list);
		}
		public Message SharePresent(int userID, string password, string machineID, string ip)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", userID));
			list.Add(base.Database.MakeInParam("strPassword", password));
			list.Add(base.Database.MakeInParam("strMachineID", machineID));
			list.Add(base.Database.MakeInParam("strClientIP", ip));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "NET_PW_SharePresent", list);
		}
        public int ExecuteNonQuery(string sql)
        {
            return base.Database.ExecuteNonQuery(sql);
        }
        public int ExecuteNonQuery(string sql, params SqlParameter[] cmdParms)
        {
            return base.Database.ExecuteNonQuery(CommandType.Text, sql, cmdParms);
        }
	}
}
