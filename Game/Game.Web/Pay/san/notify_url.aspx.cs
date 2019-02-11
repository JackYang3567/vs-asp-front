using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Game.Web.Pay.san
{
    public partial class notify_url : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlForm form1;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
			dictionary["app_id"] = base.Request.Form["app_id"];
			dictionary["order_id"] = base.Request.Form["order_id"];
			dictionary["pay_seq"] = base.Request.Form["pay_seq"];
			dictionary["pay_amt"] = base.Request.Form["pay_amt"];
			dictionary["pay_result"] = base.Request.Form["pay_result"];
			string text = "";
			foreach (System.Collections.Generic.KeyValuePair<string, string> current in dictionary)
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					current.Key,
					"=",
					current.Value,
					"&"
				});
			}
			string text3 = ApplicationSettings.Get("key_san");
			text3 = TextEncrypt.EncryptPassword(text3).ToLower();
			string a = TextEncrypt.EncryptPassword(text + "key=" + text3).ToLower();
			string b = base.Request.Form["sign"];
			if (!(a == b))
			{
				base.Response.Write("签名失败，订单号：" + dictionary["order_id"]);
			}
			else
			{
				if (!(dictionary["pay_result"] == "20"))
				{
					base.Response.Write("充值失败，订单号：" + dictionary["order_id"]);
				}
				else
				{
					ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
					shareDetialInfo.OrderID = dictionary["order_id"];
					shareDetialInfo.IPAddress = Utility.UserIP;
					shareDetialInfo.PayAmount = System.Convert.ToDecimal(dictionary["pay_amt"]);
					Message message = FacadeManage.aideTreasureFacade.FilliedOnline(shareDetialInfo, 0);
					if (message.Success)
					{
						base.Response.Write("ok");
					}
					else
					{
						base.Response.Write(message.Content + "，订单号：" + dictionary["order_id"]);
					}
				}
			}
		}
	}
}
