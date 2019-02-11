using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.UI;
namespace Game.Web.Pay.heyifu
{
    public partial class notify_url : System.Web.UI.Page
	{
		public string apiName;
		public string notifyTime;
		public string tradeAmt;
		public string merchNo;
		public string merchParam;
		public string orderNo;
		public string tradeDate;
		public string accNo;
		public string accDate;
		public string orderStatus;
		public string veryfyDesc;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!base.IsPostBack)
			{
				System.Collections.Generic.Dictionary<string, string> requestPost = this.GetRequestPost();
				if (requestPost.Count > 0)
				{
					string str = string.Format("apiName={0}&notifyTime={1}&tradeAmt={2}&merchNo={3}&merchParam={4}&orderNo={5}&tradeDate={6}&accNo={7}&accDate={8}&orderStatus={9}", new object[]
					{
						requestPost["apiName"],
						requestPost["notifyTime"],
						requestPost["tradeAmt"],
						requestPost["merchNo"],
						requestPost["merchParam"],
						requestPost["orderNo"],
						requestPost["tradeDate"],
						requestPost["accNo"],
						requestPost["accDate"],
						requestPost["orderStatus"]
					});
					string text = requestPost["signMsg"];
					string s = requestPost["notifyType"];
					text = text.Replace("\r", "").Replace("\n", "");
					string str2 = ApplicationSettings.Get("key_heyifu");
					string a = TextEncrypt.EncryptPassword(str + str2).ToLower();
					bool flag = a == text.ToLower();
					this.veryfyDesc = (flag ? "签名验证通过" : "签名验证失败");
					this.apiName = requestPost["apiName"];
					this.notifyTime = requestPost["notifyTime"];
					this.tradeAmt = requestPost["tradeAmt"];
					this.merchNo = requestPost["merchNo"];
					this.merchParam = requestPost["merchParam"];
					this.orderNo = requestPost["orderNo"];
					this.tradeDate = requestPost["tradeDate"];
					this.accNo = requestPost["accNo"];
					this.accDate = requestPost["accDate"];
					this.orderStatus = requestPost["orderStatus"];
					if (flag)
					{
						ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
						shareDetialInfo.OrderID = this.orderNo;
						shareDetialInfo.IPAddress = Utility.UserIP;
						shareDetialInfo.PayAmount = System.Convert.ToDecimal(this.tradeAmt);
						Message message = FacadeManage.aideTreasureFacade.FilliedOnline(shareDetialInfo, 0);
						if (!message.Success)
						{
							Log.Write(message.Content + this.orderNo);
							this.orderStatus = message.Content;
						}
						else
						{
							Log.Write("充值成功" + this.orderNo);
							this.orderStatus = "充值成功";
							if (int.Parse(s) != 0)
							{
								base.Response.Write("SUCCESS");
							}
						}
					}
				}
				else
				{
					base.Response.Write("无通知参数");
				}
			}
		}
		private System.Collections.Generic.Dictionary<string, string> GetRequestPost()
		{
			System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
			NameValueCollection form = base.Request.Form;
			string[] allKeys = form.AllKeys;
			for (int i = 0; i < allKeys.Length; i++)
			{
				string text = allKeys[i];
				dictionary.Add(text, form.Get(text));
			}
			return dictionary;
		}
	}
}
