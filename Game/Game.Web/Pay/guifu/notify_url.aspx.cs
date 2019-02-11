using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Web.UI;
namespace Game.Web.Pay.guifu
{
    public partial  class notify_url : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			string text = ApplicationSettings.Get("key_gf");
			System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
			dictionary["orderid"] = base.Request["orderid"];
			dictionary["opstate"] = base.Request["opstate"];
			dictionary["ovalue"] = base.Request["ovalue"];
			dictionary["sysorderid"] = base.Request["sysorderid"];
			dictionary["sign"] = base.Request["sign"];
			if (!(dictionary["opstate"] == "0"))
			{
				Log.Write("充值失败：" + JsonHelper.SerializeObject(dictionary));
				base.Response.Write("opstate=" + dictionary["opstate"]);
			}
			else
			{
				string password = string.Format("orderid={0}&opstate={1}&ovalue={2}{3}", new object[]
				{
					dictionary["orderid"],
					dictionary["opstate"],
					dictionary["ovalue"],
					text
				});
				string b = TextEncrypt.EncryptPassword(password).ToLower();
				if (!(dictionary["sign"].ToLower() == b))
				{
					Log.Write("签名错误：" + JsonHelper.SerializeObject(dictionary));
					base.Response.Write("签名错误");
				}
				else
				{
					ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
					shareDetialInfo.OrderID = dictionary["orderid"];
					shareDetialInfo.IPAddress = Utility.UserIP;
					shareDetialInfo.PayAmount = System.Convert.ToDecimal(dictionary["ovalue"]);
					Message message = FacadeManage.aideTreasureFacade.FilliedOnline(shareDetialInfo, 0);
					if (message.Success)
					{
						base.Response.Write("opstate=0");
					}
					else
					{
						Log.Write(message.Content + "：" + JsonHelper.SerializeObject(dictionary));
					}
				}
			}
		}
	}
}
