using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Game.Web.Pay.uepay
{
    public partial class notify_url : PageBase
    {
        protected string Md5key = ApplicationSettings.Get("key_ue").ToStringOrEmpty();

        protected void Page_Load(object sender, EventArgs e)
        {
            Logger.Info("Game.Web.Pay.uepay.notify_url开始");
            string memberid = Request["memberid"].Trim();//商户编号
            Logger.Info("memberid" + memberid);
            string orderid = Request["orderid"].Trim();//订单号
            Logger.Info("orderid" + orderid);
            string amount = Request["amount"].Trim();//订单金额
            Logger.Info("amount" + amount);
            string datetime = Request["datetime"].Trim();//交易时间
            Logger.Info("datetime" + datetime);
            string returncode = Request["returncode"].Trim();//交易状态
            Logger.Info("returncode" + returncode);
            string transaction_id = Request["transaction_id"].Trim();//交易流水号
            Logger.Info("transaction_id" + transaction_id);
            string sign = Request["sign"].Trim();//验证签名
            Logger.Info("sign" + sign);
            Log.Write("sign" + sign);
            if (!IsPostBack)
            {
                string str = "amount=" + amount + "&datetime=" + datetime + "&memberid=" + memberid + "&orderid=" + orderid + "&returncode=" + returncode + "&transaction_id=" + transaction_id + "&key=" + Md5key;
                Logger.Info("str" + str);
                byte[] result = Encoding.Default.GetBytes(str);
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] output = md5.ComputeHash(result);
                string signStr = BitConverter.ToString(output).Replace("-", "");
                signStr = signStr.ToUpper();
                Logger.Info("signStr" + signStr);
                if (signStr == sign)
                {
                    Logger.Info("处理订单开始");
                    //处理订单
                    ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
                    shareDetialInfo.OrderID = orderid;
                    shareDetialInfo.IPAddress = Utility.UserIP;
                    shareDetialInfo.PayAmount = System.Convert.ToDecimal(amount);
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
                        base.Response.Write("充值失败：" + message.Content + "<br/>订单号：" + orderid);
                    }
                    Response.Write("ok");
                }
            }
        }
    }
}