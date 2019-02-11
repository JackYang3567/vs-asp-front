using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.UI;
namespace Game.Web.Pay.ruiyun
{
    public partial class notify_url : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			string text = ApplicationSettings.Get("key_ruiyun");
			string text2 = base.Request["orderid"];
			string text3 = base.Request["opstate"];
			string text4 = base.Request["ovalue"];
			string text5 = base.Request["sign"];
			string value = base.Request["sysorderid"];
			string value2 = base.Request["completiontime"];
			string value3 = base.Request["attach"];
			string value4 = base.Request["msg"];
			System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
			dictionary["orderid"] = text2;
			dictionary["opstate"] = text3;
			dictionary["ovalue"] = text4;
			dictionary["sign"] = text5;
			dictionary["sysorderid"] = value;
			dictionary["completiontime"] = value2;
			dictionary["attach"] = value3;
			dictionary["msg"] = value4;
			string password = string.Format("orderid={0}&opstate={1}&ovalue={2}{3}", new object[]
			{
				text2,
				text3,
				text4,
				text
			});
			if (text5.Equals(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5").ToLower()))
			{
				if (text3.Equals("0") || text3.Equals("-3"))
				{
					ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
					shareDetialInfo.OrderID = text2;
					shareDetialInfo.IPAddress = Utility.UserIP;
					shareDetialInfo.PayAmount = System.Convert.ToDecimal(text4);
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
				else
				{
					if (text3.Equals("-1"))
					{
						Log.Write("卡号密码错误：" + JsonHelper.SerializeObject(dictionary));
					}
					else
					{
						if (text3.Equals("-2"))
						{
							Log.Write("卡实际面值和提交时面值不符：" + JsonHelper.SerializeObject(dictionary));
						}
						else
						{
							if (text3.Equals("-4"))
							{
								Log.Write("卡在提交之前已经被使用：" + JsonHelper.SerializeObject(dictionary));
							}
							else
							{
								if (text3.Equals("-5"))
								{
									Log.Write("瑞云返回失败：" + JsonHelper.SerializeObject(dictionary));
								}
							}
						}
					}
				}
			}
			else
			{
				Log.Write("签名无效：" + JsonHelper.SerializeObject(dictionary));
				base.Response.Write("签名错误");
			}
		}
	}
}
