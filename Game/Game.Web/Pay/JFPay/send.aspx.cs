using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Web.Security;
using System.Web.UI;

namespace Game.Web.Pay.JFPay
{
    public partial class send : System.Web.UI.Page
    {
        private string userCode = Config.userCode;
        private string compKey = Config.compKey;
        public string requestUrl = Config.requestUrl;
        public RequestBean requestBean;

        public string myAppID = Config.myappid;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            string formString = GameRequest.GetFormString("account");
            OnLineOrder onLineOrder = new OnLineOrder();
            if (formString == "")
            {
                base.Response.Write("充值账号错误");
                base.Response.End();
            }
            string formString2 = GameRequest.GetFormString("qudaoId");
            if (formString2 == "")
            {
                base.Response.Write("渠道错误");
                base.Response.End();
            }
            string p7_productcode = "";
            if (formString2 == "2")
            {
                p7_productcode = "ZFB";
                onLineOrder.ShareID = 2;
            }
            else if (formString2 == "3")
            {
                p7_productcode = "WX";
                onLineOrder.ShareID = 3;
            }
            else if (formString2 == "6")
            {
                p7_productcode = "QQ";
            }
            else
            {
                base.Response.Write("渠道错误");
                base.Response.End();
            }

            var formInt = GameRequest.GetFormFloat("amount", 0).ToDecimal(0);
            //if (formInt < 20)
            //{
            //    base.Response.Write("充值金额不能低于20");
            //    base.Response.End();
            //}
            string text = base.Request["type"];
           
            onLineOrder.OrderID = PayHelper.GetOrderIDByPrefix("jft");
            if (Fetch.GetUserCookie() == null)
            {
                onLineOrder.OperUserID = 0;
            }
            else
            {
                onLineOrder.OperUserID = Fetch.GetUserCookie().UserID;
            }
            onLineOrder.Accounts = formString;
            onLineOrder.OrderAmount = formInt;
            onLineOrder.IPAddress = GameRequest.GetUserIP();
            string p25_terminal = "";
            string p26_iswappay = "";
            //string a;
            //if ((a = text) != null)
            //{
            //    if (!(a == "alipay-wap"))
            //    {
            //        if (!(a == "weixin-wap"))
            //        {
            //            if (!(a == "alipay"))
            //            {
            //                if (a == "weixin")
            //                {
            //                    text = "3";
            //                    p25_terminal = "3";
            //                    p26_iswappay = "1";
            //                    onLineOrder.ShareID = 5;
            //                }
            //            }
            //            else
            //            {
            //                text = "4";
            //                p25_terminal = "3";
            //                p26_iswappay = "1";
            //                onLineOrder.ShareID = 4;
            //            }
            //        }
            //        else
            //        {
            //            text = "3";
            //            p25_terminal = "2";
            //            p26_iswappay = "3";
            //            onLineOrder.ShareID = 3;
            //        }
            //    }
            //    else
            //    {
            //        text = "4";
            //        p25_terminal = "2";
            //        p26_iswappay = "3";
            //        onLineOrder.ShareID = 2;
            //    }
            //}
            Message message = FacadeManage.aideTreasureFacade.RequestOrder(onLineOrder);
            if (!message.Success)
            {
                base.Response.Write(message.Content);
                base.Response.End();
            }
            Random rd = new Random();
            this.p1_yingyongnum.Value = Config.userCode;
            this.p2_ordernumber.Value = onLineOrder.OrderID;
            this.p3_money.Value = onLineOrder.OrderAmount.ToString("#0.00");
            this.p6_ordertime.Value = System.DateTime.Now.ToString("yyyyMMddHHmmss");
            this.p7_productcode.Value = text;
            this.p8_sign.Value = "";                                            //
            this.p9_signtype.Value = "1";                                       //MD5
            this.p10_bank_card_code.Value = Request.Form["p10_bank_card_code"]; //?
            this.p11_cardtype.Value = "";
            this.p12_channel.Value = "";
            this.p13_orderfailertime.Value = "";
            this.p14_customname.Value = Request.Form["p14_customname"];         //?
            this.p15_customcontact.Value = "";
            this.p16_customip.Value = "192_168_0_253";
            this.p17_product.Value = "product";
            this.p18_productcat.Value = "";
            this.p19_productnum.Value = "";
            this.p20_pdesc.Value = "";
            this.p21_version.Value = "";
            this.p22_sdkversion.Value = "";
            this.p23_charset.Value = "UTF-8";
            this.p24_remark.Value = "";
            this.p25_terminal.Value = Request.Form["p25_terminal"];             //?
            this.p26_ext1.Value = "";
            this.p27_ext2.Value = "";
            this.p28_ext3.Value = "";
            this.p29_ext4.Value = "";
            this.Card_Number.Value = Request.Form["Card_Number"];
            this.Card_Password.Value = Request.Form["Card_Password"];

            this.requestBean = new RequestBean
            {
                p1_yingyongnum = this.p1_yingyongnum.Value,
                p2_ordernumber = this.p2_ordernumber.Value,
                p3_money = this.p3_money.Value,
                p6_ordertime = this.p6_ordertime.Value,
                p7_productcode = this.p7_productcode.Value,
                p8_sign = ""
            };
            this.p8_sign.Value = GetSign(requestBean);
            ScriptManager.RegisterStartupScript(this.Page, GetType(), "post1", "Post();", true);
        }

        private string GetSign(RequestBean bean)
        {
            string rawString = bean.p1_yingyongnum + "&" + bean.p2_ordernumber + "&" + bean.p3_money + "&" + bean.p6_ordertime +
                               "&" + bean.p7_productcode + "&" + System.Configuration.ConfigurationManager.AppSettings["compKey"];

            return FormsAuthentication.HashPasswordForStoringInConfigFile(rawString, "MD5");
        }
    }
}