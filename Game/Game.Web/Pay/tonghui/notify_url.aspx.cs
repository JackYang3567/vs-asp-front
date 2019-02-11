using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Game.Web.Pay.tonghui
{
    public partial class notify_url : Page
    {
        protected HtmlForm form1;

        public notify_url()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string str = ApplicationSettings.Get("key_th");
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary["versionId"] = base.Request["versionId"];
            dictionary["transType"] = base.Request["transType"];
            dictionary["asynNotifyUrl"] = base.Request["asynNotifyUrl"];
            dictionary["synNotifyUrl"] = base.Request["synNotifyUrl"];
            dictionary["merId"] = base.Request["merId"];
            dictionary["orderAmount"] = base.Request["orderAmount"];
            dictionary["prdOrdNo"] = base.Request["prdOrdNo"];
            dictionary["orderStatus"] = base.Request["orderStatus"];
            dictionary["payId"] = base.Request["payId"];
            dictionary["payTime"] = base.Request["payTime"];
            dictionary["signType"] = base.Request["signType"];
            dictionary = (
                from p in dictionary
                orderby p.Key
                select p).ToDictionary<KeyValuePair<string, string>, string, string>((KeyValuePair<string, string> p) => p.Key, (KeyValuePair<string, string> o) => o.Value);
            string password = string.Concat(PayHelper.PrepareSign(dictionary), "&key=", str);
            dictionary["signData"] = base.Request["signData"];
            if (dictionary["orderStatus"] == "01")
            {
                string text = TextEncrypt.EncryptPassword(password);
                if (dictionary["signData"] == text)
                {
                    ShareDetialInfo shareDetialInfo = new ShareDetialInfo()
                    {
                        OrderID = dictionary["prdOrdNo"],
                        IPAddress = Utility.UserIP,
                        PayAmount = Convert.ToDecimal(dictionary["orderAmount"]) / new decimal(100)
                    };
                    Message message = FacadeManage.aideTreasureFacade.FilliedOnline(shareDetialInfo, 0);
                    if (!message.Success)
                    {
                        Log.Write(message.Content);
                    }
                    else
                    {
                        base.Response.Write("SUCCESS");
                    }
                }
                else
                {
                    Log.Write(string.Concat("签名错误，mySign：", text, "——Sign=", dictionary["signData"]));
                    base.Response.Write("签名错误");
                }
            }
            else
            {
                Log.Write("支付系统错误");
                base.Response.Write("支付系统错误");
            }
        }
    }
}