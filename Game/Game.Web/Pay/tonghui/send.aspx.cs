using Game.Entity.Accounts;
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

namespace Game.Web.Pay.tonghui
{
    public partial class send : Page
    {
        protected string qrcode = "";

        protected string order_no = "";

        protected string order_amount = "";

        protected string paytype = "";

        public send()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string formString = GameRequest.GetFormString("account");
            if (formString == "")
            {
                base.Response.Write("充值账号错误");
                base.Response.End();
            }
            int formInt = GameRequest.GetFormInt("amount", 0);
            if (formInt < 6)
            {
                base.Response.Write("充值金额不能低于6元");
                base.Response.End();
            }
            string formString2 = GameRequest.GetFormString("type");
            OnLineOrder onLineOrder = new OnLineOrder()
            {
                OrderID = PayHelper.GetOrderIDByPrefix("th")
            };
            if (Fetch.GetUserCookie() != null)
            {
                onLineOrder.OperUserID = Fetch.GetUserCookie().UserID;
            }
            else
            {
                onLineOrder.OperUserID = 0;
            }
            onLineOrder.Accounts = formString;
            onLineOrder.OrderAmount = formInt;
            onLineOrder.IPAddress = GameRequest.GetUserIP();
            string str1 = formString2;
            string str2 = str1;
            if (str2 != null)
            {
                switch (str2)
                {
                    case "alipay":
                        {
                            onLineOrder.ShareID = 2;
                            break;
                        }
                    case "weixin":
                        {
                            onLineOrder.ShareID = 3;
                            break;
                        }
                    case "alipay-scan":
                        {
                            this.paytype = "支付宝";
                            onLineOrder.ShareID = 4;
                            break;
                        }
                    case "weixin-scan":
                        {
                            this.paytype = "微信";
                            onLineOrder.ShareID = 5;
                            break;
                        }
                    case "qq":
                        {
                            onLineOrder.ShareID = 6;
                            break;
                        }
                    case "kuaijie":
                        {
                            onLineOrder.ShareID = 7;
                            break;
                        }
                    case "qq-scan":
                        {
                            this.paytype = "QQ";
                            onLineOrder.ShareID = 8;
                            break;
                        }
                    case "jd":
                        {
                            onLineOrder.ShareID = 9;
                            break;
                        }
                    case "baidu":
                        {
                            onLineOrder.ShareID = 10;
                            break;
                        }
                    default:
                        {
                            goto Label0;
                        }
                }
            }
            else
            {
                goto Label0;
            }
        Label1:
            Message message = FacadeManage.aideTreasureFacade.RequestOrder(onLineOrder);
            if (!message.Success)
            {
                base.Response.Write(message.Content);
                base.Response.End();
            }
            string gateway = ApplicationSettings.Get("url_th");
            string value = ApplicationSettings.Get("parter_th");
            string str = ApplicationSettings.Get("key_th");
            string text = ApplicationSettings.Get("pay_url");
            if (text == "")
            {
                text = string.Concat("http://", base.Request.Url.Host);
            }
            string orderID = onLineOrder.OrderID;
            string value2 = string.Concat(text, "/pay/tonghui/notify_url.aspx");
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary["versionId"] = "1";
            dictionary["orderAmount"] = (formInt * 100).ToString();
            dictionary["orderDate"] = DateTime.Now.ToString("yyyyMMddHHmmss");
            dictionary["currency"] = "RMB";
            dictionary["accountType"] = "0";
            dictionary["transType"] = "008";
            dictionary["asynNotifyUrl"] = value2;
            dictionary["synNotifyUrl"] = value2;
            dictionary["signType"] = "MD5";
            dictionary["merId"] = value;
            dictionary["prdOrdNo"] = orderID;
            dictionary["payMode"] = "0";
            dictionary["prdName"] = "shop";
            dictionary["prdDesc"] = "shop";
            dictionary["pnum"] = "1";
            dictionary = (
                from p in dictionary
                orderby p.Key
                select p).ToDictionary<KeyValuePair<string, string>, string, string>((KeyValuePair<string, string> p) => p.Key, (KeyValuePair<string, string> o) => o.Value);
            string password = string.Concat(PayHelper.PrepareSign(dictionary), "&key=", str);
            dictionary["signData"] = TextEncrypt.EncryptPassword(password);
            base.Response.Write(PayHelper.BuildForm(dictionary, gateway));
            return;
        Label0:
            onLineOrder.ShareID = 1;
            goto Label1;
        }
    }
}