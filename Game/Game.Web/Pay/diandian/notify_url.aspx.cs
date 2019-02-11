using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Game.Web.Pay.diandian
{
    public partial  class notify_url : System.Web.UI.Page
	{
		private System.Collections.Generic.Dictionary<string, string> dic = new System.Collections.Generic.Dictionary<string, string>();
		public string merchant_id = ConfigurationManager.AppSettings["parter_dd"].ToString();
		public string key = ConfigurationManager.AppSettings["key_dd"].ToString();
		protected System.Web.UI.HtmlControls.HtmlForm form1;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!base.IsPostBack)
			{
				NameValueCollection form = System.Web.HttpContext.Current.Request.Form;
				foreach (string text in form)
				{
					if (text != "sign")
					{
						this.dic.Add(text, form[text]);
					}
				}
				string str = PayHelper.PrepareSign(this.dic) + "&key=" + this.key;
				string text2 = Jiami.MD5(str).ToUpper();
				if (text2.Equals(form["sign"]))
				{
					ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
					shareDetialInfo.OrderID = form["out_trade_no"];
					shareDetialInfo.IPAddress = Utility.UserIP;
					shareDetialInfo.PayAmount = System.Convert.ToDecimal(form["total_fee"]);
					Message message = FacadeManage.aideTreasureFacade.FilliedOnline(shareDetialInfo, 0);
					if (message.Success)
					{
						base.Response.Write("success");
					}
					else
					{
						Log.Write(message.Content);
					}
				}
				else
				{
					Log.Write(JsonHelper.SerializeObject(this.dic));
					base.Response.Write("Signature verification failed");
				}
			}
		}
	}
}
