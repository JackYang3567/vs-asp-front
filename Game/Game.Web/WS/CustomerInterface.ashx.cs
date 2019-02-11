using Game.Entity.NativeWeb;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
namespace Game.Web.WS
{
	public class CustomerInterface : System.Web.IHttpHandler
	{
		public bool IsReusable
		{
			get
			{
				return false;
			}
		}
		public void ProcessRequest(System.Web.HttpContext context)
		{
			context.Response.ContentType = "text/plain";
			string text = GameRequest.GetQueryString("action").ToLower();
			string text2 = text;
			switch (text2)
			{
			case "getquestiontype":
				this.GetQuestionType(context);
				break;
			case "getquestionlist":
				this.GetQuestionList(context);
				break;
			case "report":
				this.Report(context);
				break;
			case "getreport":
				this.GetReport(context);
				break;
			case "leavingmessage":
				this.LeavingMessage(context);
				break;
			case "getmessage":
				this.GetMessage(context);
				break;
			case "getkefu":
				this.GetKefu(context);
				break;
			}
		}
		public void GetQuestionType(System.Web.HttpContext context)
		{
			int @int = GameRequest.GetInt("typeId", 0);
			string tabName = "GameIssueInfo";
			if (@int == 1)
			{
				tabName = "GameIssueInfo";
			}
			if (@int == 2)
			{
				tabName = "GameFeedbackInfo";
			}
			if (@int == 3)
			{
				tabName = "GameAccuseInfo";
			}
			System.Data.DataTable type = FacadeManage.aideTreasureFacade.GetType(tabName);
			context.Response.Write(JsonHelper.SerializeObject(type));
		}
		public void GetQuestionList(System.Web.HttpContext context)
		{
			int @int = GameRequest.GetInt("hot", 0);
			string @string = GameRequest.GetString("title");
			int int2 = GameRequest.GetInt("typeId", 0);
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder("WHERE Nullity=0");
			if (@int > 0)
			{
				stringBuilder.Append(" AND Hot=1");
			}
			if (@string != "")
			{
				stringBuilder.Append(" AND IssueTitle like '%'+@title+'%'");
			}
			if (int2 > 0)
			{
				stringBuilder.AppendFormat(" AND TypeID={0}", int2);
			}
			System.Data.DataTable questionList = FacadeManage.aideNativeWebFacade.GetQuestionList(stringBuilder.ToString(), @string);
			context.Response.Write(JsonHelper.SerializeObject(questionList));
		}
		public void Report(System.Web.HttpContext context)
		{
			int queryInt = GameRequest.GetQueryInt("userid", 0);
			GameRequest.GetQueryString("signature");
			GameRequest.GetQueryString("time");
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			ajaxJsonValid.code = 1;
			int queryInt2 = GameRequest.GetQueryInt("gameid", 0);
			if (queryInt2 <= 0)
			{
				ajaxJsonValid.msg = "举报ID错误";
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
			else
			{
				int queryInt3 = GameRequest.GetQueryInt("typeid", 0);
				string queryString = GameRequest.GetQueryString("content");
				if (queryString == "")
				{
					ajaxJsonValid.msg = "举报内容不能为空";
					context.Response.Write(ajaxJsonValid.SerializeToJson());
				}
				else
				{
					System.Collections.Generic.Dictionary<string, object> dictionary = new System.Collections.Generic.Dictionary<string, object>();
					dictionary["dwUserID"] = queryInt;
					dictionary["dwTarGameID"] = queryInt2;
					dictionary["dwTypeID"] = queryInt3;
					dictionary["strCnt"] = queryString;
					dictionary["strImg"] = "";
					dictionary["strClientIp"] = GameRequest.GetUserIP();
					dictionary["strErr"] = "";
					Message message = FacadeManage.aideNativeWebFacade.ExcuteByProce("P_Accuse", dictionary);
					if (message.Success)
					{
						ajaxJsonValid.code = 0;
					}
					ajaxJsonValid.msg = message.Content;
					context.Response.Write(ajaxJsonValid.SerializeToJson());
				}
			}
		}
		public void GetReport(System.Web.HttpContext context)
		{
			int queryInt = GameRequest.GetQueryInt("userid", 0);
			GameRequest.GetQueryString("signature");
			GameRequest.GetQueryString("time");
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			ajaxJsonValid.code = 1;
			ajaxJsonValid.code = 0;
			System.Data.DataTable report = FacadeManage.aideNativeWebFacade.GetReport(queryInt);
			context.Response.Write(JsonHelper.SerializeObject(report));
		}
		public void LeavingMessage(System.Web.HttpContext context)
		{
			int queryInt = GameRequest.GetQueryInt("userid", 0);
			GameRequest.GetQueryString("signature");
			GameRequest.GetQueryString("time");
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			ajaxJsonValid.code = 1;
			string @string = GameRequest.GetString("contact");
			if (@string == "")
			{
				ajaxJsonValid.msg = "请输入联系方式";
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
			else
			{
				int queryInt2 = GameRequest.GetQueryInt("typeid", 0);
				string queryString = GameRequest.GetQueryString("content");
				if (queryString == "")
				{
					ajaxJsonValid.msg = "留言内容不能为空";
					context.Response.Write(ajaxJsonValid.SerializeToJson());
				}
				else
				{
					System.Collections.Generic.Dictionary<string, object> dictionary = new System.Collections.Generic.Dictionary<string, object>();
					dictionary["dwUserID"] = queryInt;
					dictionary["strTitle"] = @string;
					dictionary["dwTypeID"] = queryInt2;
					dictionary["strContent"] = queryString;
					dictionary["strImageUrl"] = "";
					dictionary["strClientIp"] = GameRequest.GetUserIP();
					dictionary["strErr"] = "";
					Message message = FacadeManage.aideNativeWebFacade.ExcuteByProce("NET_PW_AddGameFeedbackNew", dictionary);
					if (message.Success)
					{
						ajaxJsonValid.code = 0;
					}
					ajaxJsonValid.msg = message.Content;
					context.Response.Write(ajaxJsonValid.SerializeToJson());
				}
			}
		}
		public void GetMessage(System.Web.HttpContext context)
		{
			int queryInt = GameRequest.GetQueryInt("userid", 0);
			GameRequest.GetQueryString("signature");
			GameRequest.GetQueryString("time");
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			ajaxJsonValid.code = 1;
			ajaxJsonValid.code = 0;
			System.Data.DataTable message = FacadeManage.aideNativeWebFacade.GetMessage(queryInt);
			context.Response.Write(JsonHelper.SerializeObject(message));
		}
		public void GetKefu(System.Web.HttpContext context)
		{
			System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
			if (System.Web.HttpRuntime.Cache["kefu"] == null)
			{
				ConfigInfo configInfo = FacadeManage.aideNativeWebFacade.GetConfigInfo(AppConfig.SiteConfigKey.ContactConfig.ToString());
				if (configInfo != null)
				{
					dictionary["kefu53"] = configInfo.Field4;
					dictionary["kefuinfo"] = configInfo.Field5;
					dictionary["kefudesc"] = configInfo.Field6;
					dictionary["qq"] = configInfo.Field7;
					CacheHelper.AddCache("kefu", dictionary);
				}
			}
			else
			{
				dictionary = (System.Web.HttpRuntime.Cache["kefu"] as System.Collections.Generic.Dictionary<string, string>);
			}
			string text = dictionary["kefu53"];
			string value = dictionary["kefuinfo"];
			string value2 = dictionary["kefudesc"];
			string value3 = dictionary["qq"];
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			ajaxJsonValid.AddDataItem("kefu53", text);
			if (text == "")
			{
				ajaxJsonValid.AddDataItem("kefuinfo", value);
			}
			ajaxJsonValid.AddDataItem("kefudesc", value2);
			ajaxJsonValid.AddDataItem("qq", value3);
			ajaxJsonValid.SetValidDataValue(true);
			context.Response.Write(ajaxJsonValid.SerializeToJson());
		}
	}
}
