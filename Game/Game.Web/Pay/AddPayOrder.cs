using Game.Facade;
using Game.Utils;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Game.Web.Pay
{
    public class AddPayOrder : ClassBase
    {
        protected internal PlatformFacade aidePlatformFacade = new PlatformFacade();
        protected internal AccountsFacade aideAccountsFacade = new AccountsFacade();
        protected internal TreasureFacade aideTreasureFacade = new TreasureFacade();

        public string AddOrder(int UserId, decimal Price, string IPAddress, int priceType, int share = 13)
        {
            string secretstr = "";
            try
            {
                if (IPAddress == "")
                {
                    return "{\"return_code\":\"\", \"return_msg\":\"\", \"prepay_id\":\"\",\"errorcode\":-3,\"errormsg\":\"IP获取错误\",\"secretstr\":\"" + secretstr + "\",\"nonce_str\":\"\",\"partner_id\":\"\",\"key\":\"\"}";
                }
                else
                {
                    if (Price < 0)
                    {
                        return "{\"return_code\":\"\", \"return_msg\":\"\", \"prepay_id\":\"\",\"errorcode\":-2,\"errormsg\":\"充值金额错误\",\"secretstr\":\"" + secretstr + "\",\"nonce_str\":\"\",\"partner_id\":\"\",\"key\":\"\"}";
                    }
                    else
                    {
                        decimal CardGold = 0;

                        var CardGolddt = aidePlatformFacade.GetDataSetBySql("select isnull(max(amount),0)+isnull(max(GiveAmount),0) from  PriceSetting where priceType = " + priceType + " and price = " + Price.ToSingle());

                        if (CardGolddt.Rows.Count > 0)
                        {
                            CardGold = CardGolddt.Rows[0][0].ToDecimal(0);
                        }
                        if (CardGold == 0 && Price>0)
                        {
                            Logger.Info("没有价格列表");
                            decimal Bilv = ConfigurationManager.AppSettings["BiLv_wangyin"].ToDecimal(0);
                            Logger.Info("Bilv" + Bilv);
                            CardGold = Price * Bilv;
                            Logger.Info("CardGold" + CardGold);
                        }
                        Logger.Debug("CardGold=" + CardGold);
                        DataTable dt = aideAccountsFacade.GetDataTableBySql("select * from accountsinfo where userid = " + UserId);
                        if (dt.Rows.Count > 0)
                        {
                            int GameID = dt.Rows[0]["gameid"].ToInt(0);
                            string Account = dt.Rows[0]["accounts"].ToStringOrEmpty();
                            string OrderNumber = "YB" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + Game.Utils.Common.GetRandomNumber(5);

                            DateTime ApplyDate = DateTime.Now;
                            string sql = "if not exists(select * from OnLineOrder where OrderID=@OrderID) begin INSERT INTO [dbo].[OnLineOrder]([OperUserID],[ShareID],[UserID],[GameID],[Accounts],[OrderID], [OrderAmount],[DiscountScale],[PayAmount],[currency],[OrderStatus],[IPAddress],[ApplyDate],OrderType,CurType)VALUES(@OperUserID,@ShareID,@UserID,@GameID,@Accounts,@OrderID, @OrderAmount,@DiscountScale,@PayAmount,@currency,@OrderStatus,@IPAddress,@ApplyDate,@OrderType,@CurType) end";
                            object DiscountScale = 0;
                            SqlParameter[] par = new SqlParameter[]{
                            new SqlParameter("@OperUserID",UserId),
                            new SqlParameter("@ShareID",share),
                            new SqlParameter("@UserID",UserId),
                            new SqlParameter("@GameID",GameID),
                            new SqlParameter("@Accounts",Account),
                            new SqlParameter("@OrderID",OrderNumber),
                            //new SqlParameter("@CardTypeID",CardTypeID),
                            //new SqlParameter("@CardPrice",Price),
                            //new SqlParameter("@CardGold",CardGold),
                            //new SqlParameter("@CardTotal",CardGold),
                            new SqlParameter("@OrderAmount",Price),
                            new SqlParameter("@DiscountScale",0 as object),
                            new SqlParameter("@PayAmount",Price),
                               new SqlParameter("@currency",CardGold),
                            new SqlParameter("@OrderStatus",0 as object),
                            new SqlParameter("@IPAddress",IPAddress),
                            new SqlParameter("@ApplyDate",ApplyDate),
                             new SqlParameter("@OrderType",priceType),
                              new SqlParameter("@CurType","1"),
                        };

                            var re = aideTreasureFacade.ExecuteNonQuery(sql, par);
                            if (re > 0)
                            {
                                secretstr = Game.Utils.Common.MD5(UserId.ToString() + "|" + GameID + "|" + OrderNumber + "|" + IPAddress + "|" + ApplyDate, 32);
                                return "{\"return_code\":\"\", \"return_msg\":\"\", \"prepay_id\":\"\",\"errorcode\":1,\"errormsg\":\"" + OrderNumber + "\",\"secretstr\":\"" + secretstr + "\",\"nonce_str\":\"\",\"partner_id\":\"\",\"key\":\"\"}";
                            }
                            else
                                return "{\"return_code\":\"\", \"return_msg\":\"\", \"prepay_id\":\"\",\"errorcode\":0,\"errormsg\":\"系统错误\",\"secretstr\":\"" + secretstr + "\",\"nonce_str\":\"\",\"partner_id\":\"\",\"key\":\"\"}";
                        }
                        else
                        {
                            return "{\"return_code\":\"\", \"return_msg\":\"\", \"prepay_id\":\"\",\"errorcode\":-1,\"errormsg\":\"用户不存在\",\"secretstr\":\"" + secretstr + "\",\"nonce_str\":\"\",\"partner_id\":\"\",\"key\":\"\"}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Debug(ex);
                throw new Exception("{\"return_code\":\"\", \"return_msg\":\"\", \"prepay_id\":\"\",\"errorcode\":0,\"errormsg\":\"系统错误\",\"secretstr\":\"" + secretstr + "\",\"nonce_str\":\"\",\"partner_id\":\"\",\"key\":\"\"}");
            }
        }
    }
}