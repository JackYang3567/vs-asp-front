using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Web.UI;
namespace Game.Web.Pay.wsfpay
{
    public partial class notify_url : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			string str = ApplicationSettings.Get("key_wsf");
			System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
			dictionary["p1_usercode"] = base.Request["p1_usercode"];
			dictionary["p2_order"] = base.Request["p2_order"];
			dictionary["p3_money"] = base.Request["p3_money"];
			dictionary["p4_status"] = base.Request["p4_status"];
			dictionary["p5_payorder"] = base.Request["p5_payorder"];
			dictionary["p6_paymethod"] = base.Request["p6_paymethod"];
			dictionary["p7_paychannelnum"] = base.Request["p7_paychannelnum"];
			dictionary["p8_charset"] = base.Request["p8_charset"];
			dictionary["p9_signtype"] = base.Request["p9_signtype"];
			string str2 = "";
			foreach (System.Collections.Generic.KeyValuePair<string, string> current in dictionary)
			{
				str2 = str2 + current.Value + "&";
			}
			string text = TextEncrypt.EncryptPassword(str2 + str);
			dictionary["p10_sign"] = base.Request["p10_sign"];
			dictionary["p11_remark"] = base.Request["p11_remark"];
			if (!(text.ToLower() == dictionary["p10_sign"].ToLower()))
			{
				Log.Write("签名错误" + dictionary["p2_order"]);
				base.Response.Write("签名错误");
			}
			else
			{
				ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
				shareDetialInfo.OrderID = dictionary["p2_order"];
				shareDetialInfo.IPAddress = Utility.UserIP;
				shareDetialInfo.PayAmount = System.Convert.ToDecimal(dictionary["p3_money"]);
				Message message = FacadeManage.aideTreasureFacade.FilliedOnline(shareDetialInfo, 0);
				if (message.Success)
				{
					base.Response.Write("success");
				}
				else
				{
					Log.Write(message.Content + dictionary["p2_order"]);
				}
			}
		}
	}
}
