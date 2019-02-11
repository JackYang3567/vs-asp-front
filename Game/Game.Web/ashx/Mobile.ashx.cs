using Game.Entity.Accounts;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;
namespace Game.Web.ashx
{
    public class Mobile : System.Web.IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            string s = string.Empty;
            try
            {
                string name = context.Request["action"];
                object obj = base.GetType().InvokeMember(name, System.Reflection.BindingFlags.InvokeMethod, null, this, new object[]
				{
					context
				});
                if (obj != null)
                {
                    s = obj.ToString();
                }
            }
            catch (System.Exception ex)
            {
                s = ex.Message;
            }
            context.Response.Clear();
            context.Response.Write(s);
            context.Response.End();
        }
        public string PLayerBindBank(System.Web.HttpContext context)
        {
            UserTicketInfo userCookie = Fetch.GetUserCookie();
            string result;
            if (userCookie == null)
            {
                result = "{\"code\":0,\"msg\":\"由于长时间未操作，请重新从大厅操作\"}";
            }
            else
            {
                string text = context.Request["uname"];
                if (string.IsNullOrEmpty(text))
                {
                    result = "{\"error\":0,\"msg\":\"真实姓名不能为空！\"}";
                }
                else
                {
                    string text2 = context.Request["card"];
                    if (string.IsNullOrEmpty(text2))
                    {
                        result = "{\"error\":0,\"msg\":\"银行卡号不能为空！\"}";
                    }
                    else
                    {
                        if (!Regex.IsMatch(text2, "^[+-]?\\d*[.]?\\d*$"))
                        {
                            result = "{\"error\":0,\"msg\":\"银行卡号为数字！\"}";
                        }
                        else
                        {
                            if (text2.Length < 16)
                            {
                                result = "{\"error\":0,\"msg\":\"银行卡号的长度不正确！\"}";
                            }
                            else
                            {
                                string text3 = context.Request["bankName"];
                                if (string.IsNullOrEmpty(text3))
                                {
                                    result = "{\"error\":0,\"msg\":\"请选择银行！\"}";
                                }
                                else
                                {
                                    string text4 = context.Request["bankAddress"];
                                    if (string.IsNullOrEmpty(text4))
                                    {
                                        result = "{\"error\":0,\"msg\":\"请输入开户行地址！\"}";
                                    }
                                    else
                                    {
                                        Message message = FacadeManage.aideAccountsFacade.PLayerBindBank(userCookie.UserID, text, text2, text3, text4);
                                        if (message.Success)
                                        {
                                            result = "{\"error\":1,\"msg\":\"操作成功！\"}";
                                        }
                                        else
                                        {
                                            result = "{\"error\":0,\"msg\":\"" + message.Content + "\"}";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }
        public string PlayerDraw(System.Web.HttpContext context)
        {
            UserTicketInfo userCookie = Fetch.GetUserCookie();
            string result;
            if (userCookie == null)
            {
                result = "{\"code\":0,\"msg\":\"由于长时间未操作，请重新从大厅操作\"}";
            }
            else
            {
                decimal dwScore = 0m;
                if (!decimal.TryParse(context.Request["score"].ToString(), out dwScore))
                {
                    result = "{\"error\":0,\"msg\":\"兑换金额的格式有误！\"}";
                }
                else
                {
                    Message message = FacadeManage.aideAccountsFacade.PlayerDraw(userCookie.UserID, dwScore, "", PayHelper.GetOrderIDByPrefix(""), GameRequest.GetUserIP());
                    if (message.Success)
                    {
                        result = "{\"error\":1,\"msg\":\"操作成功！\"}";
                    }
                    else
                    {
                        result = "{\"error\":0,\"msg\":\"" + message.Content + "\"}";
                    }
                }
            }
            return result;
        }
    }
}
