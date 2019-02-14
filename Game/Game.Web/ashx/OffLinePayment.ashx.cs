using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;

namespace Game.Web.ashx
{
    /// <summary>
    /// Summary description for OffLinePayment
    /// </summary>
    public class OffLinePayment : System.Web.IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        /*
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
       */
        private string username = "";
        private decimal payAmount = 0m;
        private string orderID = "";
        private DateTime applyDate = DateTime.Now;
        private int paymentType = 1;
        private string bankName = "BankName";

        public void ProcessRequest(HttpContext context)
        {

           
          this.AddOffLinePaymentInfo(context);
           context.Response.ContentType = "text/plain";
           context.Response.Write("订单提交成功！");
           /*
           string s = string.Empty;
           try
           {
               string name =  //context.Request["action"];
               object obj = base.GetType().InvokeMember(name, System.Reflection.BindingFlags.InvokeMethod, null, this, new object[]
				{
					context
				});
               if (obj != null)
               {
                   s = obj.ToString();
               }
           }
           catch (System.Exception ex)
           {
               s = ex.Message;
           }
           context.Response.Clear();
           context.Response.Write(s);
           context.Response.End();
            */
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public string AddOffLinePaymentInfo(System.Web.HttpContext context)
        {
            this.username = context.Request["username"];
            this.payAmount = decimal.Parse(context.Request["coin"]);
            this.orderID = context.Request["orderid"];
            this.applyDate = DateTime.Parse(context.Request["P_Time"]);
            this.paymentType = int.Parse(context.Request["PaymentType"]); ;
            this.bankName = "BankName";



           //  ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
            OffLinePayOrders OffLinePayOrdersInfo = new OffLinePayOrders();
            OffLinePayOrdersInfo.Accounts = this.username;
            OffLinePayOrdersInfo.OrderID = this.orderID;
            OffLinePayOrdersInfo.PayAmount = this.payAmount;
            OffLinePayOrdersInfo.ApplyDate = this.applyDate;
            OffLinePayOrdersInfo.PaymentType = this.paymentType;
            OffLinePayOrdersInfo.BankName = this.bankName;

            context.Response.ContentType = "text/plain";
            //context.Response.Write("OffLinePayOrdersInfo.Accounts: " + OffLinePayOrdersInfo.Accounts + "\r\n");
            //context.Response.Write("OffLinePayOrdersInfo.PayAmount: " + OffLinePayOrdersInfo.PayAmount + "\r\n");
            //context.Response.Write("OffLinePayOrdersInfo.OrderID: " + OffLinePayOrdersInfo.OrderID + "\r\n");
            //context.Response.Write("OffLinePayOrdersInfo.ApplyDate: " + OffLinePayOrdersInfo.ApplyDate + "\r\n");
            //context.Response.Write("OffLinePayOrdersInfo.PaymentType: " + OffLinePayOrdersInfo.PaymentType + "\r\n");

          //  shareDetialInfo.ShareID = 100;
            TreasureFacade treasureFacade = new TreasureFacade();
            treasureFacade.WriteOffLinePayment(OffLinePayOrdersInfo );

            return "1";
        } 
    }
}