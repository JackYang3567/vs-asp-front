using Game.Facade;
using Game.Utils;
using Game.Utils.Utils;
using System;
using System.Collections.Generic;

namespace Game.Web.Pay.wangmao
{
    public partial class send : PageBase
    {
        protected internal TreasureFacade aideTreasureFacade = new TreasureFacade();

        protected void Page_Load(object sender, EventArgs e)
        {
            var tradeno = Serializer.DeserializeJsonToObject<EntityAddOrder>(AddOrder());

            if (tradeno.errorcode.ToInt(0) > 0)
            {
                string tradeno1 = tradeno.errormsg;
                if (tradeno1.IndexOf("YB") > -1)
                {
                    GetPrepayID(tradeno1);
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
                ret = dal.AddOrder(requestParams["userid"].ToInt(0), price, ip, priceType, 200);
            }
            catch (Exception ex)
            {
                ret = ex.Message;
            }

            return ret;
        }

        public string ToBase64(string value)
        {
            if (value.ToStringOrEmpty() == "")
            {
                return "";
            }
            else
            {
                byte[] b = System.Text.Encoding.Default.GetBytes(value.ToStringOrEmpty());
                return Convert.ToBase64String(b);
            }
        }

        private void GetPrepayID(string tradeno)
        {
            string version = "1.0";
            string charset = "UTF-8";
            string merchant_id = System.Configuration.ConfigurationManager.AppSettings["wm_merchant_id"].ToStringOrEmpty();
            string out_trade_no = tradeno;
            string trade_type = Request.QueryString["trade_type"].ToStringOrEmpty();
            string user_ip = Request.QueryString["ip"].ToStringOrEmpty();
            string subject = "在线支付";
            double cardtotal = 0;
            var dt = aideTreasureFacade.GetDataSetBySql(" select currency from  OnLineOrder where OrderID = '" + tradeno + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                cardtotal = dt.Rows[0][0].ToDouble(0).Value;
            }
            string body = (cardtotal) + "金币";
            string user_id = Request.QueryString["userid"].ToStringOrEmpty();
            string total_fee = (Request.QueryString["money"].ToStringOrEmpty().ToDouble(0)).ToStringOrEmpty();
            string nonce_str = Game.Utils.Common.GetRandomChar(32);
            string notify_url = System.Configuration.ConfigurationManager.AppSettings["url"].ToStringOrEmpty() + "Pay/wangmao/notify_url.aspx";
            string return_url = System.Configuration.ConfigurationManager.AppSettings["url"].ToStringOrEmpty() + "Pay/wangmao/return_url.aspx";
            string biz_content = ToBase64(Server.UrlEncode("{\"datetime\":\"" + DateTime.Now.ToString("yyyyMMddHHssmm") + "\",\"timeout\":\"120\",\"reply_format\":\"xml\",\"tongle_cashier_desk\":\"1\"}"));
            string key = System.Configuration.ConfigurationManager.AppSettings["wm_pay_key"].ToStringOrEmpty();

            string signTemp = "biz_content=" + biz_content + "body=" + body + "&charset=" + charset + "&merchant_id=" + merchant_id + "&nonce_str=" + nonce_str + "&notify_url=" + notify_url + "&out_trade_no=" + out_trade_no + "&return_url=" + return_url + "&subject=" + subject + "&total_fee=" + total_fee + "&trade_type=" + trade_type + "&user_id=" + user_id + "&user_ip=" + user_ip + "&version=" + version + "&key=" + key;
            string sign = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(signTemp, "MD5").ToUpper();
            var packageRequest = new Dictionary<string, string>();

            packageRequest.Add("biz_content", biz_content);
            packageRequest.Add("body", body);
            packageRequest.Add("charset", charset);
            packageRequest.Add("merchant_id", merchant_id);
            packageRequest.Add("nonce_str", nonce_str);
            packageRequest.Add("notify_url", notify_url);
            packageRequest.Add("out_trade_no", out_trade_no);
            packageRequest.Add("return_url", return_url);
            packageRequest.Add("subject", subject);
            packageRequest.Add("total_fee", total_fee);
            packageRequest.Add("trade_type", trade_type);
            packageRequest.Add("user_id", user_id);
            packageRequest.Add("user_ip", user_ip);
            packageRequest.Add("version", version);
            packageRequest.Add("sign", sign);

            var data = Serializer.DictionaryToXml(packageRequest);

            //Encoding iso = Encoding.GetEncoding("ISO-8859-1");
            //Encoding utf8 = Encoding.UTF8;
            //byte[] utfBytes = utf8.GetBytes(data);
            //byte[] isoBytes = Encoding.Convert(utf8, iso, utfBytes);
            //  data = iso.GetString(isoBytes);

            Logger.Debug("data:" + data);
            string prepayXml = HttpHelper.HttpRequest("http://api.mxc88.com/gateway/soa", data);
            Logger.Debug("prepayXml:" + prepayXml);
            var a = Serializer.XmlDeserialize<xml>(prepayXml);

            //a.nonce_str = nonce_str;
            //a.partner_id = mch_id;
            //a.key = key;
            var b = new {   nonce_str = nonce_str, merchant_id = merchant_id, key = key, errorcode = "1", errormsg = tradeno, secretstr = "", sign = sign };
            Logger.Debug(Serializer.SerializeToJson(b));
            ResponseToEnd(Serializer.SerializeToJson(b));

            //Prepay b = new Prepay();
            //b.return_code = "123";
            //Serializer.XmlSerialize(b);
            //var xdoc = new XmlDocument();
            //xdoc.LoadXml(prepayXml);
        }
    }

    public class EntityAddOrder
    {
        public string errormsg { get; set; }
        public string errorcode { get; set; }
    }

    public class xml
    {
        public string version { get; set; }
        public string charset { get; set; }

        public string sign_type { get; set; }
        public string status { get; set; }
        public string total_fee { get; set; }

        public string subject { get; set; }
        public string body { get; set; }
        public string out_trade_no { get; set; }

        public string trade_no { get; set; }
        public string result_code { get; set; }
        public string message { get; set; }
        public string sign { get; set; }
    }
}