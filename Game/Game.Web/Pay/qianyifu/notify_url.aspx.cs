using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Web.UI;
namespace Game.Web.Pay.qianyifu
{
    public partial class notify_url : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			string text = ApplicationSettings.Get("partner_qianyifu");
			string text2 = ApplicationSettings.Get("key_qianyifu");
			string text3 = base.Request["returncode"];
			string text4 = base.Request["orderid"];
			string text5 = base.Request["money"];
			string text6 = base.Request["sign"];
			string arg_6C_0 = base.Request["ext"];
			string password = string.Format("returncode={0}&userid={1}&orderid={2}&money={3}&keyvalue={4}", new object[]
			{
				text3,
				text,
				text4,
				text5,
				text2
			});
			if (!(text6.ToLower() == TextEncrypt.EncryptPassword(password).ToLower()))
			{
				Log.Write("签名错误");
				base.Response.Write("签名错误");
			}
			else
			{
				if (!(text3 == "1"))
				{
					Log.Write("商户业务数据失败处理：" + text4);
					base.Response.Write("商户业务数据失败处理");
				}
				else
				{
					string url = "http://wangguan.qianyifu.com:8881/gateway/query.asp";
					System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
					dictionary["userid"] = text;
					dictionary["orderid"] = text4;
					password = string.Format("userid={0}&orderid={1}&keyvalue={2}", dictionary["userid"], dictionary["orderid"], text2);
					dictionary["sign"] = TextEncrypt.EncryptPassword(password).ToLower();
					string param = PayHelper.PrepareSign(dictionary);
					string text7 = HttpHelper.HttpRequest(url, param, "get", "GB2312");
					if (!text7.Contains("成功"))
					{
						Log.Write(text7 + "：" + text4);
						base.Response.Write(text7);
					}
					else
					{
						text5 = text7.Substring(text7.IndexOf("：") + 1).Replace("元", "");
						ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
						shareDetialInfo.OrderID = text4;
						shareDetialInfo.IPAddress = Utility.UserIP;
						shareDetialInfo.PayAmount = System.Convert.ToDecimal(text5);
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
}
