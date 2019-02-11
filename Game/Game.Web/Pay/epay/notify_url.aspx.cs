using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Web.UI;
namespace Game.Web.Pay.epay
{
    public partial class notify_url : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			string str = ApplicationSettings.Get("key_e");
			SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>();
			sortedDictionary["dd"] = base.Request["dd"];
			sortedDictionary["total_fee"] = base.Request["total_fee"];
			sortedDictionary["out_trade_no"] = base.Request["out_trade_no"];
			sortedDictionary["partner"] = base.Request["partner"];
			sortedDictionary["sign_type"] = base.Request["sign_type"];
			sortedDictionary["charset"] = base.Request["charset"];
			sortedDictionary["sign"] = base.Request["sign"];
			sortedDictionary["msg"] = base.Request["msg"];
			Log.Write("通知参数：" + JsonHelper.SerializeObject(sortedDictionary));
			string str2 = PayHelper.PrepareSign(sortedDictionary);
			string b = TextEncrypt.EncryptPassword(str2 + str).ToLower();
			if (!(sortedDictionary["sign"].ToLower() == b))
			{
				Log.Write("签名错误：" + JsonHelper.SerializeObject(sortedDictionary));
				base.Response.Write("签名错误");
			}
			else
			{
				ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
				shareDetialInfo.OrderID = sortedDictionary["out_trade_no"];
				shareDetialInfo.IPAddress = Utility.UserIP;
				shareDetialInfo.PayAmount = System.Convert.ToDecimal(sortedDictionary["total_fee"]);
				Message message = FacadeManage.aideTreasureFacade.FilliedOnline(shareDetialInfo, 0);
				if (message.Success)
				{
					base.Response.Write("SUCCESS");
				}
				else
				{
					Log.Write(message.Content + "：" + JsonHelper.SerializeObject(sortedDictionary));
				}
			}
		}
	}
}
