using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.UI;
namespace Game.Web.Pay.youmifu
{
    public partial class notify_url : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			string str = ApplicationSettings.Get("key_ymf");
			System.Collections.Generic.Dictionary<string, string> requestPost = this.GetRequestPost();
			string str2 = string.Format("apiName={0}&notifyTime={1}&tradeAmt={2}&merchNo={3}&merchParam={4}&orderNo={5}&tradeDate={6}&accNo={7}&accDate={8}&orderStatus={9}", new object[]
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
			string b = Jiami.MD5(str2 + str).ToLower();
			if (!(requestPost["signMsg"].ToLower() == b))
			{
				Log.Write("签名错误：" + JsonHelper.SerializeObject(requestPost));
				base.Response.Write("签名错误");
			}
			else
			{
				ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
				shareDetialInfo.OrderID = requestPost["orderNo"];
				shareDetialInfo.IPAddress = Utility.UserIP;
				shareDetialInfo.PayAmount = System.Convert.ToDecimal(requestPost["tradeAmt"]);
				Message message = FacadeManage.aideTreasureFacade.FilliedOnline(shareDetialInfo, 0);
				if (message.Success)
				{
					base.Response.Write("SUCCESS");
				}
				else
				{
					Log.Write(message.Content + "：" + JsonHelper.SerializeObject(requestPost));
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
