using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Specialized;
using System.Text;
using System.Web;
using System.Web.UI;
namespace Game.Web.Pay.slpay
{
    public partial class notify_url : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			string str = ApplicationSettings.Get("key_sl");
			byte[] array = new byte[base.Request.InputStream.Length];
			base.Request.InputStream.Read(array, 0, array.Length);
			string text = System.Text.Encoding.UTF8.GetString(array);
			text = System.Web.HttpUtility.UrlDecode(text);
			NameValueCollection nameValueCollection = System.Web.HttpUtility.ParseQueryString(text);
			string text2 = nameValueCollection.Get("orderid");
			string text3 = nameValueCollection.Get("opstate");
			string text4 = nameValueCollection.Get("ovalue");
			string text5 = nameValueCollection.Get("sign");
			nameValueCollection.Get("sysorderid");
			nameValueCollection.Get("systime");
			nameValueCollection.Get("attach");
			string text6 = nameValueCollection.Get("Sign2");
			if (!(text3 == "0"))
			{
				Log.Write("支付系统错误 opstate:" + text3 + " orderid:" + text2);
				base.Response.Write("支付系统错误");
			}
			else
			{
				string text7 = text2 + text4 + str;
				string text8 = TextEncrypt.EncryptPassword(text7);
				if (!(text6.ToLower() == text8.ToLower()))
				{
					Log.Write(string.Concat(new string[]
					{
						"签名错误，signSource=",
						text7,
						" mySign=",
						text8,
						" Sign=",
						text5,
						" Sign2=",
						text6
					}));
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
}
