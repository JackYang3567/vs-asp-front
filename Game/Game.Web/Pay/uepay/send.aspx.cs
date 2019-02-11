using Game.Facade;
using Game.Utils;
using Game.Utils.Utils;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Game.Web.Pay.uepay
{
    public partial class send : PageBase
    {
        protected internal TreasureFacade aideTreasureFacade = new TreasureFacade();

        protected void Page_Load(object sender, EventArgs e)
        {
            var tradeno = Serializer.DeserializeJsonToObject<EntityAddOrder>(AddOrder());
            Logger.Info(JsonHelper.SerializeObject( tradeno));

            if (tradeno.errorcode.ToInt(0) > 0)
            {
                Logger.Info("2");
                string tradeno1 = tradeno.errormsg;
                if (tradeno1.IndexOf("YB") > -1)
                {
                    string apiurl = ApplicationSettings.Get("url_ue").ToStringOrEmpty();
                    string key = ApplicationSettings.Get("key_ue").ToStringOrEmpty();
                    string pay_amount = Request["money"].ToStringOrEmpty();
                    string pay_applydate = getNowDateTime();
                    string pay_bankcode = Request["banktype"].ToStringOrEmpty();
                    string pay_callbackurl = ApplicationSettings.Get("url").ToStringOrEmpty() + "Pay/uepay/return_url.aspx";
                    string pay_memberid = ApplicationSettings.Get("parter_ue").ToStringOrEmpty();
                    string pay_notifyurl = ApplicationSettings.Get("url").ToStringOrEmpty() + "Pay/uepay/notify_url.aspx";
                    string pay_orderid = tradeno1;
                    SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>();
                    sortedDictionary.Add("pay_amount", pay_amount);
                    sortedDictionary.Add("pay_applydate", pay_applydate);
                    sortedDictionary.Add("pay_bankcode", pay_bankcode);
                    sortedDictionary.Add("pay_callbackurl", pay_callbackurl);
                    sortedDictionary.Add("pay_memberid", pay_memberid);
                    sortedDictionary.Add("pay_notifyurl", pay_notifyurl);
                    sortedDictionary.Add("pay_orderid", pay_orderid);
                    

                    string str = "";
                    foreach (System.Collections.Generic.KeyValuePair<string, string> current in sortedDictionary)
                    {
                        if (current.Value != "")
                        {
                            string text3 = str;
                            str = string.Concat(new string[]
					{
						text3,
						current.Key,
						"=",
						current.Value,
						"&"
					});
                        }
                    }
                    str = str + "key=" + key;

                    byte[] result = Encoding.Default.GetBytes(str);
                    MD5 md5 = new MD5CryptoServiceProvider();
                    byte[] output = md5.ComputeHash(result);
                    string sign = BitConverter.ToString(output).Replace("-", "");
                    string pay_md5sign = sign.ToUpper();

                    sortedDictionary.Add("pay_md5sign", pay_md5sign);
                    sortedDictionary.Add("pay_productname", "购买商品");
                    base.Response.Write(HttpHelper.CreatFormHtml(apiurl, sortedDictionary, "post"));
                }
                else
                {
                    ResponseToEnd(tradeno1);
                }
            }
        }

        /// <summary>
        /// 取当前日期时间，如：2010-09-30 23:05:09
        /// </summary>
        /// <param name="sString"></param>
        /// <returns>处理后的日期时间字符串。</returns>
        public string getNowDateTime()
        {
            string sYear = Convert.ToString(DateTime.Now.Year);
            string sMonth = Convert.ToString(DateTime.Now.Month);
            if (sMonth.Length <= 1)
            {
                sMonth = "0" + sMonth;
            }
            string sDay = Convert.ToString(DateTime.Now.Day);
            if (sDay.Length <= 1)
            {
                sDay = "0" + sDay;
            }
            string sHour = Convert.ToString(DateTime.Now.Hour);
            if (sHour.Length <= 1)
            {
                sHour = "0" + sHour;
            }
            string sMinute = Convert.ToString(DateTime.Now.Minute);
            if (sMinute.Length <= 1)
            {
                sMinute = "0" + sMinute;
            }
            string sSecond = Convert.ToString(DateTime.Now.Second);
            if (sSecond.Length <= 1)
            {
                sSecond = "0" + sSecond;
            }

            return sYear + "-" + sMonth + "-" + sDay + " " + sHour + ":" + sMinute + ":" + sSecond;
        }

        private string AddOrder()
        {
            /////返回值
            //0 系统错误
            //-1 用户不存在
            //-2 充值金额错误
            //-3 IP获取错误
            //正确返回 YB201606282227599167
            ///

            var requestParams = Request.QueryString;
            decimal price = requestParams["money"].ToDecimal(0);
            string ip = requestParams["ip"].ToStringOrEmpty();
            int priceType = requestParams["pricetype"].ToInt(0);
            string ret = "";
            try
            {
                AddPayOrder dal = new AddPayOrder();
                ret = dal.AddOrder(requestParams["userid"].ToInt(0), price, ip, priceType, 202);
            }
            catch (Exception ex)
            {
                ret = ex.Message;
            }

            return ret;
        }
    }

    public class EntityAddOrder
    {
        public string errormsg { get; set; }
        public string errorcode { get; set; }
    }
}