using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Web.UI;
namespace Game.Web.Pay._45
{
    public partial class notify_url : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
			dictionary["orderid"] = base.Request["orderid"];
			dictionary["result"] = base.Request["result"];
			dictionary["cardtype"] = base.Request["cardtype"];
			dictionary["realamount"] = base.Request["realamount"];
			dictionary["dealtime"] = base.Request["dealtime"];
			dictionary["userpara"] = base.Request["userpara"];
			dictionary["sign"] = base.Request["sign"];
			string text = ApplicationSettings.Get("key_45");
			string password = string.Concat(new string[]
			{
				dictionary["orderid"],
				dictionary["result"],
				dictionary["realamount"],
				dictionary["dealtime"],
				dictionary["cardtype"],
				text
			});
			string b = TextEncrypt.EncryptPassword(password).ToLower();
			if (!(dictionary["result"] == "1"))
			{
				Log.Write("充值失败：" + JsonHelper.SerializeObject(dictionary));
				base.Response.Write("充值失败，订单号：" + dictionary["orderid"]);
			}
			else
			{
				if (!(dictionary["sign"] == b))
				{
					Log.Write("签名失败：" + JsonHelper.SerializeObject(dictionary));
					base.Response.Write("签名失败，订单号：" + dictionary["orderid"]);
				}
				else
				{
					ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
					shareDetialInfo.OrderID = dictionary["orderid"];
					shareDetialInfo.IPAddress = Utility.UserIP;
					shareDetialInfo.PayAmount = System.Convert.ToDecimal(dictionary["realamount"]);
					Message message = FacadeManage.aideTreasureFacade.FilliedOnline(shareDetialInfo, 0);
					if (message.Success)
					{
						base.Response.Write("OK");
					}
					else
					{
						Log.Write(message.Content + "：" + JsonHelper.SerializeObject(dictionary));
						base.Response.Write(message.Content + "，订单号：" + dictionary["orderid"]);
					}
				}
			}
		}
	}
}
