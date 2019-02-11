using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Game.Web.Pay.yifu
{
    public partial class return_urlbank : PageBase
    {
        protected string payKey = ApplicationSettings.Get("payKey_yifu").ToStringOrEmpty();
        protected string paySecret = ApplicationSettings.Get("paySecret_yifu").ToStringOrEmpty();
        protected void Page_Load(object sender, EventArgs e)
        {
            Logger.Info("Game.Web.Pay.yifu.return_url开始");

            string payKey = Request["payKey"].Trim();
            Logger.Info("payKey" + payKey);
            string productName = Request["productName"].Trim();
            Logger.Info("productName" + productName);
            string productType = Request["productType"].Trim();
            Logger.Info("productType" + productType);
            string orderPrice = Request["orderPrice"].Trim();
            Logger.Info("orderPrice" + orderPrice);
            string orderTime = Request["orderTime"].Trim();
            Logger.Info("orderTime" + orderTime);
            string outTradeNo = Request["outTradeNo"].Trim();
            Logger.Info("outTradeNo" + outTradeNo);
            string tradeStatus = Request["tradeStatus"].Trim();
            Logger.Info("tradeStatus" + tradeStatus);
            string trxNo = Request["trxNo"].Trim();
            Logger.Info("trxNo" + trxNo);
            string successTime = Request["successTime"].Trim();
            Logger.Info("successTime" + successTime);

            string remark = Request["remark"].Trim();
            Logger.Info("remark" + remark);
            string sign = Request["sign"].Trim();
            Logger.Info("sign " + sign);
            if (!IsPostBack)
            {
                string str = "orderPrice=" + orderPrice + "&orderTime=" + orderTime + "&outTradeNo=" + outTradeNo + "&payKey=" + payKey + "&productName=" + productName + "&productType=" + productType + "&remark=" + remark + "&successTime=" + successTime + "&tradeStatus=" + tradeStatus + "&trxNo=" + trxNo + "&paySecret=" + paySecret;
                Logger.Info("str" + str);

                MD5 md = new MD5CryptoServiceProvider();
                byte[] ss = md.ComputeHash(UnicodeEncoding.UTF8.GetBytes(str));
                Game.Web.Pay.yifu.send send = new yifu.send();
                string sign1 = send.byteArrayToHexString(ss).ToUpper();

                Logger.Info("sign" + sign);
                Logger.Info("sign1" + sign1);
                if (sign == sign1 && tradeStatus == "SUCCESS")
                {
                    Logger.Info("处理订单开始");
                    //处理订单
                    ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
                    shareDetialInfo.OrderID = outTradeNo;
                    shareDetialInfo.IPAddress = Utility.UserIP;
                    shareDetialInfo.PayAmount = System.Convert.ToDecimal(orderPrice);
                    Message message = FacadeManage.aideTreasureFacade.FilliedOnline(shareDetialInfo, 0);
                    Logger.Info("message" + message.ToJson());
                    if (message.Success)
                    {
                        Logger.Info("充值成功");
                        base.Response.Write("充值成功");
                    }
                    else
                    {
                        Log.Write(message.Content);
                        base.Response.Write("充值失败：" + message.Content + "<br/>订单号：" + outTradeNo);
                    }
                    Response.Write("SUCCESS");
                }
            }
        }
    }
}