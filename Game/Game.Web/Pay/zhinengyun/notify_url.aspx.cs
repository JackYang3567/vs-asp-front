using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Game.Web.Pay.zhinengyun
{
    public partial class notify_url : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlForm form1;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
			dictionary["uid"] = base.Request.Form["uid"];
			dictionary["orderid"] = base.Request.Form["orderid"];
			dictionary["ordno"] = base.Request.Form["ordno"];
			dictionary["price"] = base.Request.Form["price"];
			dictionary["realprice"] = base.Request.Form["realprice"];
			dictionary["orderuid"] = base.Request.Form["orderuid"];
			dictionary["key"] = base.Request.Form["key"];
			string text = ApplicationSettings.Get("key_zny");
			string password = string.Concat(new string[]
			{
				dictionary["orderid"],
				dictionary["orderuid"],
				dictionary["ordno"],
				dictionary["price"],
				dictionary["realprice"],
				text
			});
			string b = TextEncrypt.EncryptPassword(password).ToLower();
			if (!(dictionary["key"] == b))
			{
				Log.Write("签名失败：" + JsonHelper.SerializeObject(dictionary));
				base.Response.Write("签名失败，订单号：" + dictionary["orderid"]);
			}
			else
			{
				ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
				shareDetialInfo.OrderID = dictionary["orderid"];
				shareDetialInfo.IPAddress = Utility.UserIP;
				shareDetialInfo.PayAmount = System.Convert.ToDecimal(dictionary["realprice"]);
				Message message = FacadeManage.aideTreasureFacade.FilliedOnline(shareDetialInfo, 0);
				if (message.Success)
				{
					base.Response.Write("success");
				}
				else
				{
					base.Response.Write(message.Content + "，订单号：" + dictionary["orderid"]);
				}
			}
		}
	}
}
