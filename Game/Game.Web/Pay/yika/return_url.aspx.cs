using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Web.UI;
namespace Game.Web.Pay.yika
{
    public partial class return_url : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			string text = ApplicationSettings.Get("key_yika");
			string text2 = base.Request["orderid"];
			string text3 = base.Request["opstate"];
			string text4 = base.Request["ovalue"];
			string text5 = base.Request["sign"];
			string arg_60_0 = base.Request["ekaorderid"];
			string arg_71_0 = base.Request["ekatime"];
			string arg_82_0 = base.Request["attach"];
			string arg_93_0 = base.Request["msg"];
			string password = string.Format("orderid={0}&opstate={1}&ovalue={2}{3}", new object[]
			{
				text2,
				text3,
				text4,
				text
			});
			if (!(text3 == "0"))
			{
				Log.Write("充值失败");
			}
			else
			{
				if (!(text5.ToLower() == TextEncrypt.EncryptPassword(password).ToLower()))
				{
					Log.Write("签名错误");
					base.Response.Write("签名错误");
				}
				else
				{
					ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
					shareDetialInfo.OrderID = text2;
					shareDetialInfo.IPAddress = Utility.UserIP;
					shareDetialInfo.PayAmount = System.Convert.ToDecimal(text4);
					Message message = FacadeManage.aideTreasureFacade.FilliedOnline(shareDetialInfo, 0);
					if (message.Success)
					{
						Log.Write("充值成功");
						base.Response.Write("充值成功");
					}
					else
					{
						Log.Write(message.Content);
						base.Response.Write(message.Content);
					}
				}
			}
		}
	}
}
