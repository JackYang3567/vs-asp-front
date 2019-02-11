using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Web.UI;
namespace Game.Web.Pay.ruyi
{
    public partial class notify_url : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			string text = ApplicationSettings.Get("key_ruyi");
			System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
			dictionary["P_UserId"] = base.Request["P_UserId"];
			dictionary["P_OrderId"] = base.Request["P_OrderId"];
			dictionary["P_CardId"] = base.Request["P_CardId"];
			dictionary["P_CardPass"] = base.Request["P_CardPass"];
			dictionary["P_FaceValue"] = base.Request["P_FaceValue"];
			dictionary["P_ChannelId"] = base.Request["P_ChannelId"];
			dictionary["P_PayMoney"] = base.Request["P_PayMoney"];
			dictionary["P_ErrCode"] = base.Request["P_ErrCode"];
			dictionary["P_PostKey"] = base.Request["P_PostKey"];
			string password = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}", new object[]
			{
				dictionary["P_UserId"],
				dictionary["P_OrderId"],
				dictionary["P_CardId"],
				dictionary["P_CardPass"],
				dictionary["P_FaceValue"],
				dictionary["P_ChannelId"],
				dictionary["P_PayMoney"],
				dictionary["P_ErrCode"],
				text
			});
			string b = TextEncrypt.EncryptPassword(password).ToLower();
			if (!(dictionary["P_PostKey"].ToLower() == b))
			{
				Log.Write("签名错误：" + JsonHelper.SerializeObject(dictionary));
				base.Response.Write("签名错误");
			}
			else
			{
				ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
				shareDetialInfo.OrderID = dictionary["P_OrderId"];
				shareDetialInfo.IPAddress = Utility.UserIP;
				shareDetialInfo.PayAmount = System.Convert.ToDecimal(dictionary["P_PayMoney"]);
				Message message = FacadeManage.aideTreasureFacade.FilliedOnline(shareDetialInfo, 0);
				if (message.Success)
				{
					base.Response.Write("ErrCode=0");
				}
				else
				{
					Log.Write(message.Content + "：" + JsonHelper.SerializeObject(dictionary));
				}
			}
		}
	}
}
