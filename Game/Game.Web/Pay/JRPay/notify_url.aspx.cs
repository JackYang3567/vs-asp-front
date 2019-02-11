using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;

namespace Game.Web.Pay.JRPay
{
    public partial class notify_url : System.Web.UI.Page
    {
        protected internal TreasureFacade aideTreasureFacade = new TreasureFacade();
        protected void Page_Load(object sender, EventArgs e)
        {
            string partner = ApplicationSettings.Get("parter_jr");  //商户ID
            Log.Write("partner" + partner);
            string Key = ApplicationSettings.Get("key_jr");  //商户KEY
            Log.Write("Key" + Key);
            int orderstatus = Convert.ToInt32(Request["orderstatus"]);
            Log.Write("orderstatus" + orderstatus);
            string ordernumber = Request["ordernumber"];
            Log.Write("ordernumber" + ordernumber);
            string paymoney = Request["paymoney"];
            Log.Write("paymoney" + paymoney);
            string sign = Request["sign"];
            Log.Write("sign" + sign);
            string attach = Request["attach"];
            Log.Write("attach" + attach);
            string signSource = string.Format("partner={0}&ordernumber={1}&orderstatus={2}&paymoney={3}{4}", partner, ordernumber, orderstatus, paymoney, Key);
            Log.Write("sign" + sign);
            Log.Write("signSource" + signSource);
            if (sign.ToUpper() == JRAPI_NET_DEMO.JRAPICommon.MD5(signSource, false).ToUpper())//签名正确
            {
                ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
                shareDetialInfo.OrderID = ordernumber;
                shareDetialInfo.IPAddress = Utility.UserIP;
                shareDetialInfo.PayAmount = System.Convert.ToDecimal(paymoney);
                Message message = FacadeManage.aideTreasureFacade.FilliedOnline(shareDetialInfo, 0);
                if (message.Success)
                {
                    Log.Write("充值成功");
                    base.Response.Write("充值成功！订单号：" + ordernumber);
                }
                else
                {
                    var dt = aideTreasureFacade.GetDataSetBySql("select OrderStatus from OnLineOrder where orderid = '" + ordernumber + "'").Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToStringOrEmpty() == "2")
                        {
                            Log.Write(message.Content);
                            base.Response.Write("充值成功！订单号：" + ordernumber);
                        }
                        else
                        {
                            Log.Write(message.Content);
                            base.Response.Write("充值失败：" + message.Content + "<br/>订单号：" + ordernumber);
                        }
                    }
                    else
                    {
                        Log.Write(message.Content);
                        base.Response.Write("充值失败：" + message.Content + "<br/>订单号：" + ordernumber);
                    }
                    
                }
            }
            Response.Write("ok");
            Response.End();
        }
    }
}