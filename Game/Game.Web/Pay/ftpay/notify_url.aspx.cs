using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Web.UI;
namespace Game.Web.Pay.ftpay
{
    public partial class notify_url : System.Web.UI.Page
	{
		private enum PayStatus
		{
			生成支付请求 = 1,
			支付中,
			支付完成,
			支付失败,
			支付结果获取失败,
			受理成功 = 7,
			扫码代付失败退回
		}
		protected void Page_Load(object sender, System.EventArgs e)
		{
			string key = ApplicationSettings.Get("key_ft");
			string orgCode = base.Request["orgCode"];
			string orgNo = base.Request["orgNo"];
			string arg_3D_0 = base.Request["bizId"];
			string a = base.Request["status"];
			string arg_5F_0 = base.Request["amt"];
			string arg_70_0 = base.Request["finalAmt"];
			if (a == "3" || a == "7")
			{
				this.QueryOrder(orgCode, orgNo, key);
			}
			else
			{
				Log.Write("充值失败");
			}
		}
		private void QueryOrder(string orgCode, string orgNo, string key)
		{
			string value = "2003";
			System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
			dictionary["oldOrgNo"] = orgNo;
			string password = string.Format("orgCode={0}&oldOrgNo={1}&md5={2}", orgCode, orgNo, key);
			string value2 = TextEncrypt.EncryptPassword(password).ToLower();
			System.Collections.Generic.Dictionary<string, string> dictionary2 = new System.Collections.Generic.Dictionary<string, string>();
			dictionary2["orgCode"] = orgCode;
			dictionary2["serviceCode"] = value;
			dictionary2["orgNo"] = PayHelper.GetOrderIDByPrefix("");
			dictionary2["jsonData"] = JsonHelper.SerializeObject(dictionary);
			dictionary2["sign"] = value2;
			string param = PayHelper.PrepareSign(dictionary2);
			string json = HttpHelper.HttpRequest(ApplicationSettings.Get("url_ft"), param);
			System.Collections.Generic.Dictionary<string, string> dictionary3 = JsonHelper.DeserializeJsonToObject<System.Collections.Generic.Dictionary<string, string>>(json);
			if (dictionary3.ContainsKey("respCode"))
			{
				if (!(dictionary3["respCode"] == "0000") && !(dictionary3["respCode"] == "0001"))
				{
					base.Response.Write(dictionary3["respDesc"]);
					Log.Write(dictionary3["respDesc"]);
				}
				else
				{
					string json2 = dictionary3["jsonData"];
					System.Collections.Generic.Dictionary<string, string> dictionary4 = JsonHelper.DeserializeJsonToObject<System.Collections.Generic.Dictionary<string, string>>(json2);
					if (dictionary4.ContainsKey("status"))
					{
						if (!(dictionary4["status"] == "3"))
						{
							base.Response.Write(((notify_url.PayStatus)System.Convert.ToInt32(dictionary4["status"])).ToString());
							Log.Write(((notify_url.PayStatus)System.Convert.ToInt32(dictionary4["status"])).ToString());
						}
						else
						{
							ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
							shareDetialInfo.OrderID = orgNo;
							shareDetialInfo.IPAddress = Utility.UserIP;
							shareDetialInfo.PayAmount = System.Convert.ToDecimal(dictionary4["amt"]);
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
			else
			{
				base.Response.Write("查询订单失败");
				Log.Write("查询订单失败");
			}
		}
	}
}
