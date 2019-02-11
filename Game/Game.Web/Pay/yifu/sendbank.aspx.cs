using Game.Facade;
using Game.Utils;
using Game.Utils.Utils;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Game.Web.Pay.yifu
{
    public partial class sendbank : PageBase
    {
        protected internal TreasureFacade aideTreasureFacade = new TreasureFacade();

        protected void Page_Load(object sender, EventArgs e)
        {
            var tradeno = Serializer.DeserializeJsonToObject<EntityAddOrder>(AddOrder());
            Logger.Info(JsonHelper.SerializeObject(tradeno));

            if (tradeno.errorcode.ToInt(0) > 0)
            {
                Logger.Info("2");
                string tradeno1 = tradeno.errormsg;
                if (tradeno1.IndexOf("YB") > -1)
                {
                    string apiurl = ApplicationSettings.Get("bankurl_yifu").ToStringOrEmpty();
                    string payKey = ApplicationSettings.Get("payKey_yifu").ToStringOrEmpty();
                    string paySecret = ApplicationSettings.Get("paySecret_yifu").ToStringOrEmpty();
                    string orderPrice = Request["money"].ToStringOrEmpty();
                    string outTradeNo = tradeno1;
                    string productType = Request["banktype"].ToStringOrEmpty();
                    string orderTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string productName = "1";
                    string orderIp = Request["ip"].ToStringOrEmpty();
                    string bankCode = Request["bankcode"].ToStringOrEmpty();
                    string bankAccountType = Request["bankAccountType"].ToStringOrEmpty();
                    string returnUrl = ApplicationSettings.Get("url").ToStringOrEmpty() + "Pay/yifu/return_urlbank.aspx";
                    string notifyUrl = ApplicationSettings.Get("url").ToStringOrEmpty() + "Pay/yifu/notify_urlbank.aspx";
                    string remark = "1";

                    SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>();
                    sortedDictionary.Add("payKey", payKey);
                    sortedDictionary.Add("orderPrice", orderPrice);
                    sortedDictionary.Add("outTradeNo", outTradeNo);
                    sortedDictionary.Add("productType", productType);
                    sortedDictionary.Add("orderTime", orderTime);
                    sortedDictionary.Add("productName", productName);
                    sortedDictionary.Add("orderIp", orderIp);
                    sortedDictionary.Add("bankCode", bankCode);
                    sortedDictionary.Add("bankAccountType", bankAccountType);
                    sortedDictionary.Add("returnUrl", returnUrl);
                    sortedDictionary.Add("notifyUrl", notifyUrl);
                    sortedDictionary.Add("remark", remark);

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
                    str = str + "paySecret=" + paySecret;

                    //byte[] result = Encoding.Default.GetBytes(str);
                    //MD5 md5 = new MD5CryptoServiceProvider();
                    //byte[] output = md5.ComputeHash(result);
                    //string sign = BitConverter.ToString(output).Replace("-", "");
                    //string md5sign = sign.ToUpper();

                    MD5 md = new MD5CryptoServiceProvider();
                    byte[] ss = md.ComputeHash(UnicodeEncoding.UTF8.GetBytes(str));
                    string sign = byteArrayToHexString(ss).ToUpper();

                    sortedDictionary.Add("sign", sign);

                    str = "";

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
                    str = str.TrimEnd('&');
                    var ret = HttpHelper.PostWebRequest(apiurl, str);
                    ResponseToEnd(ret);
                    //var retObj = JsonHelper.DeserializeJsonToObject<dynamic>(ret);
                    //if (retObj.resultCode.Value == "0000")
                    //{
                    //    Response.Redirect(retObj.payMessage.Value, true);
                    //}
                    //else
                    //{
                    //    ResponseToEnd(JsonHelper.SerializeObject(ret));

                    //}
                }
                else
                {
                    ResponseToEnd(tradeno1);
                }
            }
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

        private string[] HexCode = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };

        public string byteToHexString(byte b)
        {
            int n = b;
            if (n < 0)
            {
                n = 256 + n;
            }
            int d1 = n / 16;
            int d2 = n % 16;
            return HexCode[d1] + HexCode[d2];
        }

        public string byteArrayToHexString(byte[] b)
        {
            String result = "";
            for (int i = 0; i < b.Length; i++)
            {
                result = result + byteToHexString(b[i]);
            }
            return result;
        }
    }
}