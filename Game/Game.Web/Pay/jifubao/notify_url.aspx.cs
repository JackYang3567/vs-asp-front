using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Web.UI;
namespace Game.Web.Pay.jifubao
{
    public partial class notify_url : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			string str = ApplicationSettings.Get("key_jifubao");
			System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
			dictionary["service"] = "TRADE.NOTIFY";
			dictionary["merId"] = base.Request["merId"];
			dictionary["tradeNo"] = base.Request["tradeNo"];
			dictionary["tradeDate"] = base.Request["tradeDate"];
			dictionary["opeNo"] = base.Request["opeNo"];
			dictionary["opeDate"] = base.Request["opeDate"];
			dictionary["amount"] = base.Request["amount"];
			dictionary["status"] = base.Request["status"];
			dictionary["extra"] = "";
			dictionary["payTime"] = base.Request["payTime"];
			string str2 = PayHelper.PrepareSign(dictionary);
			string text = TextEncrypt.EncryptPassword(str2 + str).ToLower();
			dictionary["sign"] = base.Request["sign"];
			dictionary["notifyType"] = base.Request["notifyType"];
			if (!(text.ToLower() == dictionary["sign"].ToLower()))
			{
				Log.Write("签名错误" + dictionary["tradeNo"]);
				base.Response.Write("签名错误");
			}
			else
			{
				ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
				shareDetialInfo.OrderID = dictionary["tradeNo"];
				shareDetialInfo.IPAddress = Utility.UserIP;
				shareDetialInfo.PayAmount = System.Convert.ToDecimal(dictionary["amount"]);
				Message message = FacadeManage.aideTreasureFacade.FilliedOnline(shareDetialInfo, 0);
				if (message.Success)
				{
					Log.Write("充值成功" + dictionary["tradeNo"]);
					base.Response.Write("success");
				}
				else
				{
					Log.Write(message.Content + dictionary["tradeNo"]);
				}
			}
		}
	}
}
