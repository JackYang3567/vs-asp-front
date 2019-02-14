using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;
using System.Text;

namespace Game.Web.ashx
{
    /// <summary>
    /// Summary description for PayQrCodeIcon
    /// </summary>
    public class PayQrCodeIcon : System.Web.IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
          //context.Response.Write("Hello World");

            string json = "[{\"ID\":4,\"IconPath\":\"Ali_QrCode.png\",\"QudaoName\":\"支付宝扫码\",\"QudaoCode\":\"ZFBSM\",\"maxLimit\":3000.0,\"minLimit\":100.0},";
            json += "{\"ID\":5,\"IconPath\":\"Weixin_QrCode.png\",\"QudaoName\":\"微信扫码\",\"QudaoCode\":\"WXSM\",\"maxLimit\":1888.0,\"minLimit\":20.0}";
            json += "]";
      
           
            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}