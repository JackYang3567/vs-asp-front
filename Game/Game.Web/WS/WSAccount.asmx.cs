using Game.Entity.Accounts;
using Game.Entity.NativeWeb;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
namespace Game.Web.WS
{
    [ToolboxItem(false), ScriptService, WebService(Namespace = "http://tempuri.org/"), WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class WSAccount : WebService
    {
        [WebMethod(EnableSession = true)]
        public string Logon(string userName, string userPass, string code)
        {
            string result;
            if (TextUtility.EmptyTrimOrNull(userName) || TextUtility.EmptyTrimOrNull(userPass))
            {
                string str = "抱歉！您输入的帐号或密码错误了。";
                result = "{success:'error',msg:'" + str + "'}";
            }
            else
            {
                if (!code.Equals(Fetch.GetVerifyCode(), System.StringComparison.InvariantCultureIgnoreCase))
                {
                    string str = "抱歉！您输入的验证码错误了。";
                    result = "{success:'error',msg:'" + str + "'}";
                }
                else
                {
                    Message message = FacadeManage.aideAccountsFacade.Logon(userName, userPass);
                    if (message.Success)
                    {
                        UserInfo userInfo = message.EntityList[0] as UserInfo;
                        Fetch.SetUserCookie(userInfo.ToUserTicketInfo());
                        var template = new Game.Utils.Template("/Template/UserInfo.html");
                        template.VariableDataScoureList = new System.Collections.Generic.Dictionary<string, object>
						{

							{
								"accounts",
								userInfo.Accounts
							},

							{
								"gameID",
								userInfo.GameID
							},

							{
								"userType",
								(userInfo.MemberOrder == 0) ? "普通会员" : ((userInfo.MemberOrder == 1) ? "蓝钻会员" : ((userInfo.MemberOrder == 2) ? "黄钻会员" : ((userInfo.MemberOrder == 3) ? "白钻会员" : ((userInfo.MemberOrder == 4) ? "红钻会员" : "VIP"))))
							},

							{
								"loveLiness",
								userInfo.LoveLiness
							},

							{
								"faceUrl",
								FacadeManage.aideAccountsFacade.GetUserFaceUrl((int)userInfo.FaceID, userInfo.CustomID)
							}
						};
                        System.Collections.Generic.Dictionary<string, object> dictionary = new System.Collections.Generic.Dictionary<string, object>();
                        dictionary.Add("success", "success");
                        dictionary.Add("html", template.OutputHTML());
                        result = new JavaScriptSerializer().Serialize(dictionary);
                    }
                    else
                    {
                        result = "{success:'error',msg:'" + message.Content + "'}";
                    }
                }
            }
            return result;
        }
        [WebMethod]
        public string GetHeadUserInfo()
        {
            AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
            Game.Utils.Template template;
            if (Fetch.IsUserOnline())
            {
                  template = new Game.Utils.Template("/Template/HeadUserInfo.html");
                template.VariableDataScoureList = new System.Collections.Generic.Dictionary<string, object>
				{

					{
						"accounts",
						Fetch.GetUserCookie().Accounts
					}
				};
            }
            else
            {
                template = new Game.Utils.Template("/Template/HeadNotLogon.html");
            }
            ajaxJsonValid.AddDataItem("html", template.OutputHTML());
            ajaxJsonValid.SetValidDataValue(true);
            return ajaxJsonValid.SerializeToJson();
        }
        [WebMethod]
        public string GetUserInfo()
        {
            UserTicketInfo userCookie = Fetch.GetUserCookie();
            string result;
            if (userCookie == null)
            {
                result = "{}";
            }
            else
            {
                Message userGlobalInfo = FacadeManage.aideAccountsFacade.GetUserGlobalInfo(userCookie.UserID, 0, "");
                if (userGlobalInfo.Success)
                {
                    UserInfo userInfo = userGlobalInfo.EntityList[0] as UserInfo;
                    string text = (userInfo.MemberOrder == 0) ? "普通会员" : ((userInfo.MemberOrder == 1) ? "蓝钻会员" : ((userInfo.MemberOrder == 2) ? "黄钻会员" : ((userInfo.MemberOrder == 3) ? "白钻会员" : ((userInfo.MemberOrder == 4) ? "红钻会员" : "VIP"))));
                    result = string.Concat(new object[]
					{
						"{success:'success',account:'",
						userInfo.Accounts,
						"',gid:'",
						userInfo.GameID,
						"',loves:'",
						userInfo.LoveLiness,
						"',morder:'",
						text,
						"',fid:'",
						userInfo.FaceID,
						"'}"
					});
                }
                else
                {
                    result = "{}";
                }
            }
            return result;
        }
        [WebMethod]
        public string CheckName(string userName)
        {
            Message message = FacadeManage.aideAccountsFacade.IsAccountsExist(userName);
            string result;
            if (message.Success)
            {
                result = "{success:'success'}";
            }
            else
            {
                result = "{success:'error',msg:'" + message.Content + "'}";
            }
            return result;
        }
        [WebMethod]
        public string CheckNickName(string nickName)
        {
            Message message = FacadeManage.aideAccountsFacade.IsNickNameExist(nickName);
            string result;
            if (message.Success)
            {
                result = "{success:'success'}";
            }
            else
            {
                result = "{success:'error',msg:'" + message.Content + "'}";
            }
            return result;
        }
        [WebMethod]
        public string GetUserLoves()
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            System.Collections.Generic.IList<UserInfo> userInfoOrderByLoves = FacadeManage.aideAccountsFacade.GetUserInfoOrderByLoves();
            string result;
            if (userInfoOrderByLoves == null)
            {
                result = "{}";
            }
            else
            {
                stringBuilder.Append("[");
                foreach (UserInfo current in userInfoOrderByLoves)
                {
                    stringBuilder.Append(string.Concat(new object[]
					{
						"{userName:'",
						current.NickName,
						"',loves:'",
						current.LoveLiness,
						"'},"
					}));
                }
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
                stringBuilder.Append("]");
                result = stringBuilder.ToString();
            }
            return result;
        }
        [WebMethod]
        public string AccountReport()
        {
            Message message = new Message();
            AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
            int num = 0;
            string formString = GameRequest.GetFormString("reportEmail");
            string formString2 = GameRequest.GetFormString("txtUser");
            string formString3 = GameRequest.GetFormString("regDate");
            string formString4 = GameRequest.GetFormString("realName");
            string formString5 = GameRequest.GetFormString("idCard");
            string formString6 = GameRequest.GetFormString("mobile");
            string formString7 = GameRequest.GetFormString("nicknameOne");
            string formString8 = GameRequest.GetFormString("nicknameTwo");
            string formString9 = GameRequest.GetFormString("nicknameThree");
            string formString10 = GameRequest.GetFormString("passwordOne");
            string formString11 = GameRequest.GetFormString("passwordTwo");
            string formString12 = GameRequest.GetFormString("passwordThree");
            string formString13 = GameRequest.GetFormString("questionOne");
            string formString14 = GameRequest.GetFormString("answerOne");
            string formString15 = GameRequest.GetFormString("questionTwo");
            string formString16 = GameRequest.GetFormString("answerTwo");
            string formString17 = GameRequest.GetFormString("questionThree");
            string formString18 = GameRequest.GetFormString("answerThree");
            string formString19 = GameRequest.GetFormString("suppInfo");
            message = InputDataValidate.CheckingEmail(formString);
            string result;
            if (!message.Success)
            {
                ajaxJsonValid.msg = "申诉结果接受邮箱输入有误";
                result = ajaxJsonValid.SerializeToJson();
            }
            else
            {
                message = InputDataValidate.CheckingUserNameFormat(formString2);
                if (!message.Success)
                {
                    ajaxJsonValid.msg = "申诉帐号输入有误";
                    result = ajaxJsonValid.SerializeToJson();
                }
                else
                {
                    if (!string.IsNullOrEmpty(formString3))
                    {
                        if (!Validate.IsShortDate(formString3))
                        {
                            ajaxJsonValid.msg = "注册日期输入有误";
                            result = ajaxJsonValid.SerializeToJson();
                            return result;
                        }
                        num++;
                    }
                    if (!string.IsNullOrEmpty(formString4))
                    {
                        message = InputDataValidate.CheckingRealNameFormat(formString4, true);
                        if (!message.Success)
                        {
                            ajaxJsonValid.msg = "真实姓名输入有误";
                            result = ajaxJsonValid.SerializeToJson();
                            return result;
                        }
                        num++;
                    }
                    if (!string.IsNullOrEmpty(formString5))
                    {
                        message = InputDataValidate.CheckingIDCardFormat(formString5, true);
                        if (!message.Success)
                        {
                            ajaxJsonValid.msg = "身份证号输入有误";
                            result = ajaxJsonValid.SerializeToJson();
                            return result;
                        }
                        num++;
                    }
                    if (!string.IsNullOrEmpty(formString6))
                    {
                        message = InputDataValidate.CheckingMobilePhoneNumFormat(formString6, true);
                        if (!message.Success)
                        {
                            ajaxJsonValid.msg = "移动电话输入有误";
                            result = ajaxJsonValid.SerializeToJson();
                            return result;
                        }
                        num++;
                    }
                    if (!string.IsNullOrEmpty(formString7))
                    {
                        message = InputDataValidate.CheckingNickNameFormat(formString7);
                        if (!message.Success)
                        {
                            ajaxJsonValid.msg = "历史昵称1输入有误";
                            result = ajaxJsonValid.SerializeToJson();
                            return result;
                        }
                        num++;
                    }
                    if (!string.IsNullOrEmpty(formString8))
                    {
                        message = InputDataValidate.CheckingNickNameFormat(formString8);
                        if (!message.Success)
                        {
                            ajaxJsonValid.msg = "历史昵称2输入有误";
                            result = ajaxJsonValid.SerializeToJson();
                            return result;
                        }
                        if (formString8 == formString7)
                        {
                            ajaxJsonValid.msg = "历史昵称不能相同";
                            result = ajaxJsonValid.SerializeToJson();
                            return result;
                        }
                        num++;
                    }
                    if (!string.IsNullOrEmpty(formString9))
                    {
                        message = InputDataValidate.CheckingNickNameFormat(formString9);
                        if (!message.Success)
                        {
                            ajaxJsonValid.msg = "历史昵称3输入有误";
                            result = ajaxJsonValid.SerializeToJson();
                            return result;
                        }
                        if (formString9 == formString7 || formString9 == formString8)
                        {
                            ajaxJsonValid.msg = "历史昵称不能相同";
                            result = ajaxJsonValid.SerializeToJson();
                            return result;
                        }
                        num++;
                    }
                    if (!string.IsNullOrEmpty(formString10))
                    {
                        num++;
                    }
                    if (!string.IsNullOrEmpty(formString11))
                    {
                        if (formString11 == formString10)
                        {
                            ajaxJsonValid.msg = "历史密码不能相同";
                            result = ajaxJsonValid.SerializeToJson();
                            return result;
                        }
                        num++;
                    }
                    if (!string.IsNullOrEmpty(formString12))
                    {
                        if (formString12 == formString11 || formString12 == formString10)
                        {
                            ajaxJsonValid.msg = "历史密码不能相同";
                            result = ajaxJsonValid.SerializeToJson();
                            return result;
                        }
                        num++;
                    }
                    if (formString13 != "0")
                    {
                        message = InputDataValidate.CheckingProtectAnswer(formString14, 1, false);
                        if (!message.Success)
                        {
                            ajaxJsonValid.msg = message.Content;
                            result = ajaxJsonValid.SerializeToJson();
                            return result;
                        }
                        num++;
                    }
                    if (formString15 != "0")
                    {
                        if (formString13 == formString15)
                        {
                            ajaxJsonValid.msg = "密保问题不能相同";
                            result = ajaxJsonValid.SerializeToJson();
                            return result;
                        }
                        message = InputDataValidate.CheckingProtectAnswer(formString14, 2, false);
                        if (!message.Success)
                        {
                            ajaxJsonValid.msg = message.Content;
                            result = ajaxJsonValid.SerializeToJson();
                            return result;
                        }
                        num++;
                    }
                    if (formString17 != "0")
                    {
                        if (formString17 == formString13 || formString17 == formString15)
                        {
                            ajaxJsonValid.msg = "密保问题不能相同";
                            result = ajaxJsonValid.SerializeToJson();
                            return result;
                        }
                        message = InputDataValidate.CheckingProtectAnswer(formString14, 3, false);
                        if (!message.Success)
                        {
                            ajaxJsonValid.msg = message.Content;
                            result = ajaxJsonValid.SerializeToJson();
                            return result;
                        }
                        num++;
                    }
                    message = InputDataValidate.CheckingProtectAnswer(formString19, true);
                    if (!message.Success)
                    {
                        ajaxJsonValid.msg = "补全资料太长，最长不能超过200个字符";
                        result = ajaxJsonValid.SerializeToJson();
                    }
                    else
                    {
                        if (num < 4)
                        {
                            ajaxJsonValid.msg = "为了保证您的申诉请求审核通过，请输入至少4项资料，不包括补充资料";
                            result = ajaxJsonValid.SerializeToJson();
                        }
                        else
                        {
                            Message userGlobalInfo = FacadeManage.aideAccountsFacade.GetUserGlobalInfo(0, 0, formString2);
                            if (!userGlobalInfo.Success)
                            {
                                ajaxJsonValid.msg = "您所申诉的帐号不存在";
                                result = ajaxJsonValid.SerializeToJson();
                            }
                            else
                            {
                                UserInfo userInfo = userGlobalInfo.EntityList[0] as UserInfo;
                                if (userInfo == null)
                                {
                                    ajaxJsonValid.msg = "您所申诉的帐号不存在";
                                    result = ajaxJsonValid.SerializeToJson();
                                }
                                else
                                {
                                    LossReport lossReport = new LossReport();
                                    lossReport.ReportNo = Fetch.GetForgetPwdNumber();
                                    lossReport.ReportEmail = formString;
                                    lossReport.Accounts = formString2;
                                    lossReport.RegisterDate = formString3;
                                    lossReport.Compellation = formString4;
                                    lossReport.PassportID = formString5;
                                    lossReport.MobilePhone = formString6;
                                    lossReport.OldNickName1 = formString7;
                                    lossReport.OldNickName2 = formString8;
                                    lossReport.OldNickName3 = formString9;
                                    if (!string.IsNullOrEmpty(formString10))
                                    {
                                        lossReport.OldLogonPass1 = Utility.MD5(formString10);
                                    }
                                    if (!string.IsNullOrEmpty(formString11))
                                    {
                                        lossReport.OldLogonPass2 = Utility.MD5(formString11);
                                    }
                                    if (!string.IsNullOrEmpty(formString12))
                                    {
                                        lossReport.OldLogonPass3 = Utility.MD5(formString12);
                                    }
                                    lossReport.ReportIP = GameRequest.GetUserIP();
                                    lossReport.Random = TextUtility.CreateRandom(4, 1, 0, 0, 0, "");
                                    lossReport.GameID = userInfo.GameID;
                                    lossReport.UserID = userInfo.UserID;
                                    lossReport.OldQuestion1 = formString13;
                                    lossReport.OldResponse1 = formString14;
                                    lossReport.OldQuestion2 = formString15;
                                    lossReport.OldResponse2 = formString16;
                                    lossReport.OldQuestion3 = formString17;
                                    lossReport.OldResponse3 = formString18;
                                    lossReport.SuppInfo = formString19;
                                    try
                                    {
                                        FacadeManage.aideNativeWebFacade.SaveLossReport(lossReport);
                                        ajaxJsonValid.SetValidDataValue(true);
                                        string value = string.Format("Complaint-Setp-2.aspx?number={0}&account={1}", lossReport.ReportNo, formString2);
                                        ajaxJsonValid.AddDataItem("uri", value);
                                        ajaxJsonValid.msg = "申诉成功，系统将在2个工作日内处理，申诉结果将会以邮件的形式通知您！请注意查收邮件";
                                    }
                                    catch (System.Exception ex)
                                    {
                                        ajaxJsonValid.msg = ex.ToString();
                                    }
                                    result = ajaxJsonValid.SerializeToJson();
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}
