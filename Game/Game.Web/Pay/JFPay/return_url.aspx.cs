using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Game.Web.Pay.JFPay
{
    public partial class return_url : System.Web.UI.Page
    {
        public class ResponseBean
        {
            private HttpRequest Request { get; set; }

            /// <summary>
            /// 应用号
            /// </summary>
            public string p1_yingyongnum { get { return Request.Params["p1_yingyongnum"]; } }

            /// <summary>
            /// 订单号
            /// </summary>
            public string p2_ordernumber { get { return Request.Params["p2_ordernumber"]; } }

            /// <summary>
            /// 订单金额
            /// </summary>
            public string p3_money { get { return Request.Params["p3_money"]; } }

            /// <summary>
            /// 支付结果
            /// </summary>
            public string p4_zfstate { get { return Request.Params["p4_zfstate"]; } }

            /// <summary>
            /// 竣付通订单号
            /// </summary>
            public string p5_orderid { get { return Request.Params["p5_orderid"]; } }

            /// <summary>
            /// 产品
            /// </summary>
            public string p6_productcode { get { return Request.Params["p6_productcode"]; } }

            /// <summary>
            /// 支付通道编码(银行,卡类编码)
            /// </summary>
            public string p7_bank_card_code { get { return Request.Params["p7_bank_card_code"]; } }

            /// <summary>
            /// 编码方式
            /// </summary>
            public string p8_charset { get { return Request.Params["p8_charset"]; } }

            /// <summary>
            /// 签名验证方式
            /// </summary>
            public string p9_signtype { get { return Request.Params["p9_signtype"]; } }

            /// <summary>
            /// 签名
            /// </summary>
            public string p10_sign { get { return Request.Params["p10_sign"]; } }

            /// <summary>
            /// 备注
            /// </summary>
            public string p11_pdesc { get { return Request.Params["p11_pdesc"]; } }

            public ResponseBean(HttpRequest request)
            {
                this.Request = request;
            }
        }

        private string userCode = Config.userCode;
        private string compKey = Config.compKey;
        protected System.Web.UI.HtmlControls.HtmlForm form1;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            return_url.ResponseBean responseBean = new return_url.ResponseBean(base.Request);
            string sign = this.GetSign(responseBean);
            if (!sign.Equals(responseBean.p10_sign))
            {
                Log.Write("签名错误");
                base.Response.Write("签名错误<br/>订单号：" + responseBean.p2_ordernumber);
            }
            else
            {
                ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
                shareDetialInfo.OrderID = responseBean.p2_ordernumber;
                shareDetialInfo.IPAddress = Utility.UserIP;
                shareDetialInfo.PayAmount = System.Convert.ToDecimal(responseBean.p3_money);
                //Message message = FacadeManage.aideTreasureFacade.FilliedOnline(shareDetialInfo, 0);
                //if (message.Success)
                //{
                //    Log.Write("充值成功");
                //    base.Response.Write("充值成功");
                //}
                //else
                //{
                //    Log.Write(message.Content);
                //    base.Response.Write("充值失败：" + message.Content + "<br/>订单号：" + responseBean.p2_ordernumber);
                //}
                Response.Write("ok");
                Response.End();
            }
        }

        private string GetSign(return_url.ResponseBean bean)
        {
            string rawString = bean.p1_yingyongnum + "&" + bean.p2_ordernumber + "&" + bean.p3_money + "&" + bean.p4_zfstate + "&" + bean.p5_orderid + "&" + bean.p6_productcode + "&" + bean.p7_bank_card_code + "&" + bean.p8_charset + "&" + bean.p9_signtype + "&" + bean.p11_pdesc + "&" + compKey;
            return FormsAuthentication.HashPasswordForStoringInConfigFile(rawString, "MD5");
        }
    }
}