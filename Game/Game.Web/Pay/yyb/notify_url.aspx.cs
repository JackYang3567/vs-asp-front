using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Web.UI;
namespace Game.Web.Pay.yyb
{
    public partial class notify_url : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			string text = ApplicationSettings.Get("key_yyb");
			string arg_1B_0 = base.Request["ddh"];
			string value = base.Request["money"];
			string arg_3D_0 = base.Request["lb"];
			string text2 = base.Request["name"];
			string text3 = base.Request["key"];
			string arg_70_0 = base.Request["paytime"];
			if (!(text3 == text))
			{
				Log.Write(string.Concat(new string[]
				{
					"签名错误，key=",
					text3,
					" myKey=",
					text,
					" orderid=",
					text2
				}));
				base.Response.Write("签名错误");
			}
			else
			{
				ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
				shareDetialInfo.OrderID = text2;
				shareDetialInfo.IPAddress = Utility.UserIP;
				shareDetialInfo.PayAmount = System.Convert.ToDecimal(value);
				Message message = FacadeManage.aideTreasureFacade.FilliedOnline(shareDetialInfo, 0);
				if (message.Success)
				{
					base.Response.Write("success");
				}
				else
				{
					Log.Write(message.Content);
				}
			}
		}
	}
}
