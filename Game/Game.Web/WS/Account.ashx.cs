using Game.Entity.Accounts;
using Game.Entity.NativeWeb;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using Game.Utils.Cache;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Game.Web.WS
{
    public class Account : System.Web.IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        private Logger _logger;

        public Logger Logger
        {
            get
            {
                if (_logger == null)
                {
                    _logger = new Logger("File");
                }
                return _logger;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(System.Web.HttpContext context)
        {
            context.Response.ContentType = "application/json";
            string text = GameRequest.GetQueryString("action").ToLower();
            Logger.Info("action" + text);
            string text2 = text;
            switch (text2)
            {
                case "sendcode":
                    this.SendCode(context);
                    break;

                case "accountreport":
                    this.AccountReport(context);
                    break;

                case "reportstate":
                    this.ReportState(context);
                    break;

                case "resetpwdbyreport":
                    this.ResetPwdByReport(context);
                    break;

                case "uploadface":
                    this.UploadFace(context);
                    break;

                case "uploadtousuimg":
                    this.UploadTousuImg(context);
                    break;

                case "reguser":
                    this.RegUser(context);
                    break;

                case "gotolibocai":
                    this.gotolibocai(context);
                    break;

                case "lotterybetdrawsave":
                    this.LotteryBetDrawSave(context);
                    break;

                case "getchild":
                    this.getchild(context);
                    break;
            }
        }

        public void AccountReport(System.Web.HttpContext context)
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
            string text = GameRequest.GetFormString("questionOne");
            string formString13 = GameRequest.GetFormString("answerOne");
            string text2 = GameRequest.GetFormString("questionTwo");
            string formString14 = GameRequest.GetFormString("answerTwo");
            string text3 = GameRequest.GetFormString("questionThree");
            string formString15 = GameRequest.GetFormString("answerThree");
            string formString16 = GameRequest.GetFormString("suppInfo");
            message = InputDataValidate.CheckingEmail(formString);
            if (!message.Success)
            {
                ajaxJsonValid.msg = "申诉结果接受邮箱输入有误";
                context.Response.Write(ajaxJsonValid.SerializeToJson());
            }
            else
            {
                message = InputDataValidate.CheckingUserNameFormat(formString2);
                if (!message.Success)
                {
                    ajaxJsonValid.msg = "申诉帐号输入有误";
                    context.Response.Write(ajaxJsonValid.SerializeToJson());
                }
                else
                {
                    if (!string.IsNullOrEmpty(formString3))
                    {
                        if (!Validate.IsShortDate(formString3))
                        {
                            ajaxJsonValid.msg = "注册日期输入有误";
                            context.Response.Write(ajaxJsonValid.SerializeToJson());
                            return;
                        }
                        num++;
                    }
                    if (!string.IsNullOrEmpty(formString4))
                    {
                        message = InputDataValidate.CheckingRealNameFormat(formString4, true);
                        if (!message.Success)
                        {
                            ajaxJsonValid.msg = "真实姓名输入有误";
                            context.Response.Write(ajaxJsonValid.SerializeToJson());
                            return;
                        }
                        num++;
                    }
                    if (!string.IsNullOrEmpty(formString5))
                    {
                        message = InputDataValidate.CheckingIDCardFormat(formString5, true);
                        if (!message.Success)
                        {
                            ajaxJsonValid.msg = "身份证号输入有误";
                            context.Response.Write(ajaxJsonValid.SerializeToJson());
                            return;
                        }
                        num++;
                    }
                    if (!string.IsNullOrEmpty(formString6))
                    {
                        message = InputDataValidate.CheckingMobilePhoneNumFormat(formString6, true);
                        if (!message.Success)
                        {
                            ajaxJsonValid.msg = "移动电话输入有误";
                            context.Response.Write(ajaxJsonValid.SerializeToJson());
                            return;
                        }
                        num++;
                    }
                    if (!string.IsNullOrEmpty(formString7))
                    {
                        message = InputDataValidate.CheckingNickNameFormat(formString7);
                        if (!message.Success)
                        {
                            ajaxJsonValid.msg = "历史昵称1输入有误";
                            context.Response.Write(ajaxJsonValid.SerializeToJson());
                            return;
                        }
                        num++;
                    }
                    if (!string.IsNullOrEmpty(formString8))
                    {
                        message = InputDataValidate.CheckingNickNameFormat(formString8);
                        if (!message.Success)
                        {
                            ajaxJsonValid.msg = "历史昵称2输入有误";
                            context.Response.Write(ajaxJsonValid.SerializeToJson());
                            return;
                        }
                        if (formString8 == formString7)
                        {
                            ajaxJsonValid.msg = "历史昵称不能相同";
                            context.Response.Write(ajaxJsonValid.SerializeToJson());
                            return;
                        }
                        num++;
                    }
                    if (!string.IsNullOrEmpty(formString9))
                    {
                        message = InputDataValidate.CheckingNickNameFormat(formString9);
                        if (!message.Success)
                        {
                            ajaxJsonValid.msg = "历史昵称3输入有误";
                            context.Response.Write(ajaxJsonValid.SerializeToJson());
                            return;
                        }
                        if (formString9 == formString7 || formString9 == formString8)
                        {
                            ajaxJsonValid.msg = "历史昵称不能相同";
                            context.Response.Write(ajaxJsonValid.SerializeToJson());
                            return;
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
                            context.Response.Write(ajaxJsonValid.SerializeToJson());
                            return;
                        }
                        num++;
                    }
                    if (!string.IsNullOrEmpty(formString12))
                    {
                        if (formString12 == formString11 || formString12 == formString10)
                        {
                            ajaxJsonValid.msg = "历史密码不能相同";
                            context.Response.Write(ajaxJsonValid.SerializeToJson());
                            return;
                        }
                        num++;
                    }
                    if (text != "0")
                    {
                        message = InputDataValidate.CheckingProtectAnswer(formString13, 1, false);
                        if (!message.Success)
                        {
                            ajaxJsonValid.msg = message.Content;
                            context.Response.Write(ajaxJsonValid.SerializeToJson());
                            return;
                        }
                        num++;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(formString13))
                        {
                            ajaxJsonValid.msg = "你输入了密保答案1，必须选择密保问题1";
                            context.Response.Write(ajaxJsonValid.SerializeToJson());
                            return;
                        }
                        text = "";
                    }
                    if (text2 != "0")
                    {
                        if (text == text2)
                        {
                            ajaxJsonValid.msg = "密保问题不能相同";
                            context.Response.Write(ajaxJsonValid.SerializeToJson());
                            return;
                        }
                        message = InputDataValidate.CheckingProtectAnswer(formString14, 2, false);
                        if (!message.Success)
                        {
                            ajaxJsonValid.msg = message.Content;
                            context.Response.Write(ajaxJsonValid.SerializeToJson());
                            return;
                        }
                        num++;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(formString14))
                        {
                            ajaxJsonValid.msg = "你输入了密保答案2，必须选择密保问题2";
                            context.Response.Write(ajaxJsonValid.SerializeToJson());
                            return;
                        }
                        text2 = "";
                    }
                    if (text3 != "0")
                    {
                        if (text3 == text || text3 == text2)
                        {
                            ajaxJsonValid.msg = "密保问题不能相同";
                            context.Response.Write(ajaxJsonValid.SerializeToJson());
                            return;
                        }
                        message = InputDataValidate.CheckingProtectAnswer(formString15, 3, false);
                        if (!message.Success)
                        {
                            ajaxJsonValid.msg = message.Content;
                            context.Response.Write(ajaxJsonValid.SerializeToJson());
                            return;
                        }
                        num++;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(formString15))
                        {
                            ajaxJsonValid.msg = "你输入了密保答案3，必须选择密保问题3";
                            context.Response.Write(ajaxJsonValid.SerializeToJson());
                            return;
                        }
                        text3 = "";
                    }
                    message = InputDataValidate.CheckingProtectAnswer(formString16, true);
                    if (!message.Success)
                    {
                        ajaxJsonValid.msg = "补全资料太长，最长不能超过200个字符";
                        context.Response.Write(ajaxJsonValid.SerializeToJson());
                    }
                    else
                    {
                        if (num < 4)
                        {
                            ajaxJsonValid.msg = "为了保证您的申诉请求审核通过，请输入至少4项资料，不包括补充资料";
                            context.Response.Write(ajaxJsonValid.SerializeToJson());
                        }
                        else
                        {
                            Message userGlobalInfo = FacadeManage.aideAccountsFacade.GetUserGlobalInfo(0, 0, formString2);
                            if (!userGlobalInfo.Success)
                            {
                                ajaxJsonValid.msg = "您所申诉的帐号不存在";
                                context.Response.Write(ajaxJsonValid.SerializeToJson());
                            }
                            else
                            {
                                UserInfo userInfo = userGlobalInfo.EntityList[0] as UserInfo;
                                if (userInfo == null)
                                {
                                    ajaxJsonValid.msg = "您所申诉的帐号不存在";
                                    context.Response.Write(ajaxJsonValid.SerializeToJson());
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
                                    lossReport.OldQuestion1 = text;
                                    lossReport.OldResponse1 = formString13;
                                    lossReport.OldQuestion2 = text2;
                                    lossReport.OldResponse2 = formString14;
                                    lossReport.OldQuestion3 = text3;
                                    lossReport.OldResponse3 = formString15;
                                    lossReport.SuppInfo = formString16;
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
                                    context.Response.Write(ajaxJsonValid.SerializeToJson());
                                }
                            }
                        }
                    }
                }
            }
        }

        public void ReportState(System.Web.HttpContext context)
        {
            Message message = new Message();
            AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
            string formString = GameRequest.GetFormString("account");
            string formString2 = GameRequest.GetFormString("reportNo");
            string formString3 = GameRequest.GetFormString("code");
            if (!formString3.Equals(Fetch.GetVerifyCode(), System.StringComparison.InvariantCultureIgnoreCase))
            {
                ajaxJsonValid.msg = "验证码输入有误";
                context.Response.Write(ajaxJsonValid.SerializeToJson());
            }
            else
            {
                message = InputDataValidate.CheckingUserNameFormat(formString);
                if (!message.Success)
                {
                    ajaxJsonValid.msg = "申诉帐号输入有误";
                    context.Response.Write(ajaxJsonValid.SerializeToJson());
                }
                else
                {
                    message = InputDataValidate.CheckingReportNo(formString2, false);
                    if (!message.Success)
                    {
                        ajaxJsonValid.msg = message.Content;
                        context.Response.Write(ajaxJsonValid.SerializeToJson());
                    }
                    else
                    {
                        LossReport lossReport = FacadeManage.aideNativeWebFacade.GetLossReport(formString2, formString);
                        if (lossReport == null)
                        {
                            ajaxJsonValid.msg = "帐号的申诉号不存在";
                            context.Response.Write(ajaxJsonValid.SerializeToJson());
                        }
                        else
                        {
                            string value = string.Empty;
                            switch (lossReport.ProcessStatus)
                            {
                                case 0:
                                    value = "客服处理中";
                                    break;

                                case 1:
                                    value = "审核成功，注意查看邮件并重置密码";
                                    break;

                                case 2:
                                    value = "审核失败，您的资料填写不正确或者不够详细，请重新申诉";
                                    break;

                                case 3:
                                    value = "更新密码成功";
                                    break;
                            }
                            ajaxJsonValid.AddDataItem("acount", formString);
                            ajaxJsonValid.AddDataItem("reportNo", formString2);
                            ajaxJsonValid.AddDataItem("state", value);
                            ajaxJsonValid.SetValidDataValue(true);
                            context.Response.Write(ajaxJsonValid.SerializeToJson());
                        }
                    }
                }
            }
        }

        public void ResetPwdByReport(System.Web.HttpContext context)
        {
            Message message = new Message();
            AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
            string formString = GameRequest.GetFormString("txtCode");
            if (!formString.Equals(Fetch.GetVerifyCode(), System.StringComparison.InvariantCultureIgnoreCase))
            {
                ajaxJsonValid.msg = "验证码不正确";
                context.Response.Write(ajaxJsonValid.SerializeToJson());
            }
            else
            {
                string formString2 = GameRequest.GetFormString("number");
                string formString3 = GameRequest.GetFormString("sign");
                LossReport lossReport = FacadeManage.aideNativeWebFacade.GetLossReport(formString2);
                if (lossReport == null)
                {
                    ajaxJsonValid.msg = "重置失败，非法操作";
                    context.Response.Write(ajaxJsonValid.SerializeToJson());
                }
                else
                {
                    if (lossReport.ProcessStatus == 3)
                    {
                        ajaxJsonValid.msg = "重置失败，该申诉号已被处理，不能重复操作";
                        context.Response.Write(ajaxJsonValid.SerializeToJson());
                    }
                    else
                    {
                        string reportForgetPasswordKey = AppConfig.ReportForgetPasswordKey;
                        string b = Utility.MD5(string.Concat(new object[]
						{
							formString2,
							lossReport.UserID,
							lossReport.ReportDate.ToString(),
							lossReport.Random,
							reportForgetPasswordKey
						}));
                        if (formString3 != b)
                        {
                            ajaxJsonValid.msg = "重置失败，签名错误";
                            context.Response.Write(ajaxJsonValid.SerializeToJson());
                        }
                        else
                        {
                            if (System.DateTime.Now > lossReport.OverDate)
                            {
                                ajaxJsonValid.msg = "重置失败，该申诉链接已经过期，链接有效期为24个小时";
                                context.Response.Write(ajaxJsonValid.SerializeToJson());
                            }
                            else
                            {
                                int userID = lossReport.UserID;
                                string formString4 = GameRequest.GetFormString("txtPassword");
                                string formString5 = GameRequest.GetFormString("txtConfirmPassword");
                                if (formString4 != formString5)
                                {
                                    ajaxJsonValid.msg = "两次输入的密码不一直";
                                    context.Response.Write(ajaxJsonValid.SerializeToJson());
                                }
                                else
                                {
                                    message = InputDataValidate.CheckingPasswordFormat(formString4);
                                    if (!message.Success)
                                    {
                                        ajaxJsonValid.msg = message.Content;
                                        context.Response.Write(ajaxJsonValid.SerializeToJson());
                                    }
                                    else
                                    {
                                        UserInfo userBaseInfoByUserID = FacadeManage.aideAccountsFacade.GetUserBaseInfoByUserID(userID);
                                        if (!message.Success)
                                        {
                                            ajaxJsonValid.msg = message.Content;
                                            context.Response.Write(ajaxJsonValid.SerializeToJson());
                                        }
                                        else
                                        {
                                            string arg_218_0 = userBaseInfoByUserID.LogonPass;
                                            userBaseInfoByUserID.LogonPass = Utility.MD5(formString4);
                                            message = FacadeManage.aideAccountsFacade.ResetLoginPasswdByLossReport(userBaseInfoByUserID, formString2);
                                            ajaxJsonValid.msg = message.Content;
                                            ajaxJsonValid.SetValidDataValue(message.Success);
                                            context.Response.Write(ajaxJsonValid.SerializeToJson());
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void UploadFace(System.Web.HttpContext context)
        {
            Message message = new Message();
            AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
            int formInt = GameRequest.GetFormInt("userID", 0);
            GameRequest.GetFormString("signature");
            GameRequest.GetFormString("time");
            GameRequest.GetFormString("clientIP");
            GameRequest.GetFormString("machineID");
            int num = 1048576;
            if (context.Request.Files.Count == 0)
            {
                ajaxJsonValid.msg = "请选择一个头像！";
                context.Response.Write(ajaxJsonValid.SerializeToJson());
            }
            else
            {
                System.Web.HttpPostedFile httpPostedFile = context.Request.Files[0];
                if (httpPostedFile.InputStream == null || httpPostedFile.InputStream.Length == 0L)
                {
                    ajaxJsonValid.msg = "请上传有效的头像！";
                    context.Response.Write(ajaxJsonValid.SerializeToJson());
                }
                else
                {
                    if (httpPostedFile.InputStream.Length > (long)num)
                    {
                        message.Content = string.Format("头像不能超过 {0} M！", 1);
                        context.Response.Write(ajaxJsonValid.SerializeToJson());
                    }
                    else
                    {
                        Image image = null;
                        try
                        {
                            image = Image.FromStream(httpPostedFile.InputStream);
                        }
                        catch
                        {
                            image.Dispose();
                            message.Content = string.Format("非法文件，目前只支持图片格式文件,对您使用不便感到非常抱歉。", new object[0]);
                            context.Response.Write(ajaxJsonValid.SerializeToJson());
                            return;
                        }
                        Bitmap bitmap = new Bitmap(48, 48);
                        Graphics graphics = Graphics.FromImage(bitmap);
                        graphics.DrawImage(image, 0, 0, 48, 48);
                        int num2 = 0;
                        byte[] array = new byte[9216];
                        for (int i = 0; i < 48; i++)
                        {
                            for (int j = 0; j < 48; j++)
                            {
                                Color pixel = bitmap.GetPixel(j, i);
                                array[num2] = pixel.B;
                                array[num2 + 1] = pixel.G;
                                array[num2 + 2] = pixel.R;
                                array[num2 + 3] = 0;
                                num2 += 4;
                            }
                        }
                        AccountsFace accountsFace = new AccountsFace();
                        accountsFace.UserID = formInt;
                        accountsFace.CustomFace = array;
                        accountsFace.InsertAddr = GameRequest.GetUserIP();
                        accountsFace.InsertTime = System.DateTime.Now;
                        message = FacadeManage.aideAccountsFacade.InsertCustomFace(accountsFace);
                        if (message.Success)
                        {
                            AccountsInfo accountsInfo = message.EntityList[0] as AccountsInfo;
                            ajaxJsonValid.AddDataItem("CustomID", accountsInfo.CustomID);
                        }
                        ajaxJsonValid.msg = "上传成功！";
                        ajaxJsonValid.SetValidDataValue(true);
                        context.Response.Write(ajaxJsonValid.SerializeToJson());
                        image.Dispose();
                        bitmap.Dispose();
                        graphics.Dispose();
                    }
                }
            }
        }

        public void UploadTousuImg(System.Web.HttpContext context)
        {
            Message message = new Message();
            AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
            int num = 1048576;
            if (context.Request.Files.Count == 0)
            {
                ajaxJsonValid.msg = "请选择一个图片！";
                context.Response.Write(ajaxJsonValid.SerializeToJson());
            }
            else
            {
                System.Web.HttpPostedFile httpPostedFile = context.Request.Files[0];
                if (httpPostedFile.InputStream == null || httpPostedFile.InputStream.Length == 0L)
                {
                    ajaxJsonValid.msg = "请上传有效的图片！";
                    context.Response.Write(ajaxJsonValid.SerializeToJson());
                }
                else
                {
                    if (httpPostedFile.InputStream.Length > (long)num)
                    {
                        message.Content = string.Format("图片不能超过 {0} M！", 1);
                        context.Response.Write(ajaxJsonValid.SerializeToJson());
                    }
                    else
                    {
                        Image image = null;
                        try
                        {
                            image = Image.FromStream(httpPostedFile.InputStream);
                            string @string = GameRequest.GetString("filename");
                            string text = context.Server.MapPath("/Upload/Tousu/");
                            if (!System.IO.Directory.Exists(text))
                            {
                                System.IO.Directory.CreateDirectory(text);
                            }
                            image.Save(text + @string + ".png", ImageFormat.Png);
                        }
                        catch
                        {
                            image.Dispose();
                            message.Content = string.Format("非法文件，目前只支持图片格式文件,对您使用不便感到非常抱歉。", new object[0]);
                            context.Response.Write(ajaxJsonValid.SerializeToJson());
                            return;
                        }
                        ajaxJsonValid.msg = "上传成功！";
                        ajaxJsonValid.SetValidDataValue(true);
                        context.Response.Write(ajaxJsonValid.SerializeToJson());
                        image.Dispose();
                    }
                }
            }
        }

        public void SendCode(System.Web.HttpContext context)
        {
            try
            {
                AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
                new Message();
                ajaxJsonValid.code = 1;
                string formString = GameRequest.GetFormString("phone");
                if (formString.Length < 11)
                {
                    ajaxJsonValid.msg = "手机号格式错误";
                    context.Response.Write(ajaxJsonValid.SerializeToJson());
                }
                else
                {
                    System.Data.DataTable dt = FacadeManage.aideAccountsFacade.GetList("AccountsInfo", 1, 99, " where  RegisterMobile = '" + formString + "'", " ORDER BY userid ", new string[]
				{
					"UserID"
				}).PageSet.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        ajaxJsonValid.msg = "手机号已被注册";
                        context.Response.Write(ajaxJsonValid.SerializeToJson());
                    }
                    else
                    {
                        string content = ApplicationSettings.Get("phoneContent");
                        string text = TextUtility.CreateAuthStr(6, true);
                        string text2 = CodeHelper.SendCode(formString, text, content);
                        if (text2 == "提交成功")
                        {
                            System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
                            dictionary["phone"] = formString;
                            dictionary["code"] = text;
                            Logger.Info("手机验证码" + dictionary.ToJson());
                            string value = AES.Encrypt(JsonHelper.SerializeObject(dictionary), AppConfig.UserLoginCacheEncryptKey);
                            WHCache.Default.Save<CookiesCache>("regcode", value, new int?(3));
                            ajaxJsonValid.code = 0;
                        }
                        ajaxJsonValid.msg = text2;
                        context.Response.Write(ajaxJsonValid.SerializeToJson());
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Debug("SendCode" + ex.Message);
            }
        }

        public void RegUser(System.Web.HttpContext context)
        {
            AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
            new Message();
            ajaxJsonValid.code = 1;
            string formString = GameRequest.GetFormString("account");
            if (formString.Length < 6 || formString.Length > 12)
            {
                ajaxJsonValid.msg = "账号长度为6-12位";
                context.Response.Write(ajaxJsonValid.SerializeToJson());
            }
            else
            {
                string formString2 = GameRequest.GetFormString("pwd");
                string formString3 = GameRequest.GetFormString("vcode");
                if (formString2.Length < 6)
                {
                    ajaxJsonValid.msg = "密码长度不能低于6位";
                    context.Response.Write(ajaxJsonValid.SerializeToJson());
                }
                else
                {
                    string telnum = GameRequest.GetFormString("telnum");
                    string telcode = GameRequest.GetFormString("telcode");
                    object regcodeb = WHCache.Default.Get<CookiesCache>("regcode");
                    System.Collections.Generic.Dictionary<string, string> regcodedic = JsonHelper.DeserializeJsonToObject<System.Collections.Generic.Dictionary<string, string>>(AES.Decrypt(WHCache.Default.Get<CookiesCache>("regcode").ToString(), AppConfig.UserLoginCacheEncryptKey));
                    if (regcodedic["phone"] == telnum && regcodedic["code"] == telcode)
                    {
                        System.Random random = new System.Random();
                        UserInfo userInfo = new UserInfo();
                        userInfo.Accounts = formString;
                        userInfo.FaceID = (short)random.Next(9);
                        userInfo.Gender = 1;
                        userInfo.InsurePass = "";
                        userInfo.LastLogonDate = System.DateTime.Now;
                        userInfo.LastLogonIP = GameRequest.GetUserIP();
                        userInfo.LogonPass = TextEncrypt.EncryptPassword(formString2);
                        userInfo.NickName = formString;
                        userInfo.RegisterDate = System.DateTime.Now;
                        userInfo.RegisterIP = GameRequest.GetUserIP();
                        userInfo.DynamicPass = System.Guid.NewGuid().ToString().Replace("-", "").ToUpper();
                        userInfo.RegisterMobile = telnum;
                        string authority = context.Request.Url.Authority;
                        string[] array = authority.Split(new char[]
						{
							'.'
						});
                        string parentAccount;
                        if (array.Length == 3 && array[0] != "www")
                        {
                            parentAccount = array[0];
                        }
                        else
                        {
                            parentAccount = FacadeManage.aideAccountsFacade.GetAgentByDomain(authority);
                        }
                        string text = GameRequest.GetFormString("adid");
                        string formString4 = GameRequest.GetFormString("adname");
                        string errorMessage = "";
                        System.Data.DataTable dataTable = null;
                        string text2 = "";
                        if (!string.IsNullOrEmpty(formString4))
                        {
                            dataTable = FacadeManage.aideRecordFacade.GetAdvertInfo(formString4, 1);
                            if (dataTable != null && dataTable.Rows.Count > 0)
                            {
                                text2 = Game.Facade.Common.ObjToString(dataTable.Rows[0]["AdID"]);
                                string a;
                                if ((a = formString4) == null || (!(a == "蛋蛋") && !(a == "蹦蹦") && !(a == "聚聚玩")))
                                {
                                    text = "";
                                    errorMessage = "参数adname=" + formString4 + ",不在服务范围";
                                }
                            }
                            else
                            {
                                text = "";
                                errorMessage = "参数adname=" + formString4 + ",未配置活动信息或者活动已过期";
                            }
                        }
                        else
                        {
                            text = "";
                            errorMessage = "参数adname为空";
                        }
                        Message message = new Message();
                        var beeline = HttpContext.Current.Request["beeline"].ToStringOrEmpty();
                        if (beeline == "1")
                        {
                            Logger.Info("parentAccount" + parentAccount);
                            var dt = FacadeManage.aideAccountsFacade.GetDataTableBySql(@"with sql1 as
	(
	select a.gameid,a.userid,1 l  from  RYAccountsDB.dbo.AccountsInfo a where a.gameid = " + parentAccount + @"
	union all
	select  a.gameid,a.userid ,b.l+1  from RYAccountsDB.dbo.AccountsInfo a join sql1 b on a.SpreaderID = b.UserID
	)
	select top 1 gameid from sql1 order by l desc  OPTION (MAXRECURSION 0) ");
                            // Logger.Info("dt" + dt.ToJson());
                            if (dt.Rows.Count > 0)
                            {
                                parentAccount = dt.Rows[0]["gameid"].ToStringOrEmpty();
                            }
                            Logger.Info("parentAccount" + parentAccount);
                        }
                        try
                        {
                            message = FacadeManage.aideAccountsFacade.Register(userInfo, parentAccount, text2);
                        }
                        catch (Exception ex)
                        {
                            Logger.Debug("RegUser-" + ex.Message);
                            var dt = FacadeManage.aideAccountsFacade.GetDataTableBySql("select  UserID,  GameID,  Accounts,  Nickname, UnderWrite,  FaceID,  Gender,  Experience,  MemberOrder,   MemberOverDate,  Loveliness,   CustomFaceVer, Compellation, PassPortID from accountsinfo where Accounts = '" + userInfo.Accounts + "'");
                            if (dt.Rows.Count > 0)
                            {
                                message.AddEntity(DataHelper.ConvertRowToObject<UserInfo>(dt.Rows[0]));
                                message.Success = true;
                                message.Content = "注册成功";
                            }
                            else
                            {
                                message.Content = "注册失败";
                                message.Success = false;
                            }
                        }
                        Logger.Info("RegUser-message" + message.ToJson());
                        Logger.Info("1");
                        if (message.Success)
                        {
                            Logger.Info("2");
                            UserInfo userInfo2 = message.EntityList[0] as UserInfo;
                            if (string.IsNullOrEmpty(text))
                            {
                                Logger.Info("3");
                                NetLog.WriteError(errorMessage);
                            }
                            else
                            {
                                Logger.Info("4");
                                string text3 = "";
                                string str = "";
                                string text4 = Game.Facade.Common.ObjToString(dataTable.Rows[0]["AdKey"]);
                                string baseUrl = Game.Facade.Common.ObjToString(dataTable.Rows[0]["PcUrl"]);
                                System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
                                string a2;
                                if ((a2 = formString4) != null)
                                {
                                    if (!(a2 == "蛋蛋"))
                                    {
                                        if (!(a2 == "蹦蹦"))
                                        {
                                            if (a2 == "聚聚玩")
                                            {
                                                int userID = userInfo2.UserID;
                                                string accounts = userInfo2.Accounts;
                                                string value = Game.Facade.DES.md5_32(userID.ToString() + text.ToString() + text2);
                                                dictionary.Add("regid", text.ToString());
                                                dictionary.Add("uid", userID.ToString());
                                                dictionary.Add("uname", accounts);
                                                dictionary.Add("key", value);
                                                if (WebApiHepler.Get(baseUrl, dictionary, out text3, out str, false, true))
                                                {
                                                    System.Collections.Generic.Dictionary<string, string> dictionary2 = JsonHelper.DeserializeJsonToObject<System.Collections.Generic.Dictionary<string, string>>(text3);
                                                    if (dictionary2.ContainsKey("result") && dictionary2["result"] == "1")
                                                    {
                                                        NetLog.WriteError("聚聚玩注册玩家：" + accounts + ",注册成功，返回信息：" + text3);
                                                    }
                                                    else
                                                    {
                                                        FacadeManage.aideAccountsFacade.ClearAccountsAdvertiseroByUserID(userInfo2.UserID);
                                                        NetLog.WriteError("聚聚玩注册玩家：" + accounts + ",拒绝接受，返回信息：" + text3);
                                                    }
                                                }
                                                else
                                                {
                                                    FacadeManage.aideAccountsFacade.ClearAccountsAdvertiseroByUserID(userInfo2.UserID);
                                                    NetLog.WriteError("聚聚玩注册玩家：" + accounts + ",回调出错，返回信息：" + str);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            string text5 = userInfo2.UserID.ToString();
                                            string accounts2 = userInfo2.Accounts;
                                            string value2 = Game.Facade.DES.md5_32(text2 + text + text5 + text4);
                                            dictionary.Add("adID", text2);
                                            dictionary.Add("annalID", text);
                                            dictionary.Add("idCode", text5);
                                            dictionary.Add("doukey", value2);
                                            dictionary.Add("idName", accounts2);
                                            if (WebApiHepler.Get(baseUrl, dictionary, out text3, out str, false, true))
                                            {
                                                System.Collections.Generic.Dictionary<string, string> dictionary3 = JsonHelper.DeserializeJsonToObject<System.Collections.Generic.Dictionary<string, string>>(text3);
                                                if (dictionary3.ContainsKey("result") && dictionary3["result"] == "1")
                                                {
                                                    NetLog.WriteError("蹦蹦注册玩家：" + accounts2 + ",注册成功，返回信息：" + text3);
                                                }
                                                else
                                                {
                                                    FacadeManage.aideAccountsFacade.ClearAccountsAdvertiseroByUserID(userInfo2.UserID);
                                                    NetLog.WriteError("蹦蹦注册玩家：" + accounts2 + ",拒绝接受，返回信息：" + text3);
                                                }
                                            }
                                            else
                                            {
                                                FacadeManage.aideAccountsFacade.ClearAccountsAdvertiseroByUserID(userInfo2.UserID);
                                                NetLog.WriteError("蹦蹦注册玩家：" + accounts2 + ",回调出错，返回信息：" + str);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        GameRequest.GetFormString("pcid");
                                        int userID2 = userInfo2.UserID;
                                        string accounts3 = userInfo2.Accounts;
                                        string value3 = Game.Facade.DES.md5_32(string.Concat(new object[]
										{
											text,
											userID2,
											accounts3,
											text4
										}));
                                        dictionary.Add("pcid", text);
                                        dictionary.Add("adid", text2);
                                        dictionary.Add("merid", userID2.ToString());
                                        dictionary.Add("mername", accounts3);
                                        dictionary.Add("keycode", value3);
                                        if (WebApiHepler.Get(baseUrl, dictionary, out text3, out str, false, true))
                                        {
                                            if (text3 == "-1")
                                            {
                                                FacadeManage.aideAccountsFacade.ClearAccountsAdvertiseroByUserID(userID2);
                                                NetLog.WriteError("蛋蛋注册玩家：" + accounts3 + ",已经注册过了，返回信息：" + text3);
                                            }
                                            else
                                            {
                                                NetLog.WriteError("蛋蛋注册玩家：" + accounts3 + ",注册成功，返回信息：" + text3);
                                            }
                                        }
                                        else
                                        {
                                            FacadeManage.aideAccountsFacade.ClearAccountsAdvertiseroByUserID(userID2);
                                            NetLog.WriteError("蛋蛋注册玩家：" + accounts3 + ",回调出错，返回信息：" + str);
                                        }
                                    }
                                }
                            }
                            Logger.Info("6");
                            ajaxJsonValid.code = 0;
                            Logger.Info("7");
                            WHCache.Default.Delete<SessionCache>("VerifyCodeKey");
                            Logger.Info("8");
                            WHCache.Default.Delete<CookiesCache>("VerifyCodeKey");
                            Logger.Info("9");
                            WHCache.Default.Delete<SessionCache>("error");
                            Logger.Info("10");
                        }
                        ajaxJsonValid.msg = message.Content;
                        Logger.Info("ajaxJsonValid.SerializeToJson()" + ajaxJsonValid.SerializeToJson());
                        context.Response.Write(ajaxJsonValid.SerializeToJson());
                    }
                    else
                    {
                        Logger.Info("5");
                        ajaxJsonValid.msg = "手机验证码错误";
                        ajaxJsonValid.code = 2;
                        context.Response.Write(ajaxJsonValid.SerializeToJson());
                    }
                }
            }
        }

        public void getchild(System.Web.HttpContext context)
        {
            var gameid = GameRequest.GetQueryString("gameid");
            var dt = FacadeManage.aideTreasureFacade.GetDataSetBySql("select  gameid from RYAccountsDB.dbo.AccountsInfo where spreaderid =(select top 1 userid from   RYAccountsDB.dbo.AccountsInfo  where gameid = " + gameid + ")").Tables[0];

            dynamic dy = new System.Dynamic.ExpandoObject();
            dy.code = 1;
            dy.msg = dt;
            context.Response.Write(JsonHelper.SerializeObject(dy));
        }

        public void LotteryBetDrawSave(System.Web.HttpContext context)
        {
            Message message = new Message();
            AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();

            HttpRequest request = HttpContext.Current.Request;
            var betscore = request["betscore"];
            Logger.Info("betscore" + betscore);
            var ctype = request["ctype"];
            Logger.Info("ctype" + ctype);
            var id = request["id"];
            Logger.Info("id" + id);
            var flag = request["flag"];
            Logger.Info("flag" + flag);
            var number = request["number"];
            Logger.Info("number" + number);
            var username = request["username"];
            Logger.Info("username" + username);
            var winscore = request["winscore"];
            Logger.Info("winscore" + winscore);
            var expect = request["expect"];
            Logger.Info("expect" + expect);
            var betnumber = request["betnumber"];
            Logger.Info("betnumber" + betnumber);
            string sign = request["sign"];
            Logger.Info("sign" + sign);
            var today = DateTime.Now.ToString("yyyyMMdd");
            string key = ApplicationSettings.Get("libocaikey").ToStringOrEmpty();

            var str = "betscore=" + betscore + "&ctype=" + ctype + "&flag=" + flag + "&id=" + id + "&number=" + number + "&today=" + today + "&username=" + username + "&winscore=" + winscore;
            Logger.Info("str" + str);
            MD5 md = new MD5CryptoServiceProvider();
            byte[] ss = md.ComputeHash(UnicodeEncoding.UTF8.GetBytes(str + "&key=" + key));
            string sign1 = byteArrayToHexString(ss).ToUpper();
            var code = "";
            var msg = "";
            Logger.Info("sign" + sign);
            Logger.Info("sign1" + sign1);
            if (sign == sign1)
            {
                var dts = "exec WriteLotteryBetDraw '" + username + "'," + betscore + ",'" + ctype + "'," + id + ",'" + number + "'," + winscore + "," + flag + ",'" + expect + "','" + betnumber + "'";
                Logger.Info(dts);
                var dt = FacadeManage.aideTreasureFacade.GetDataSetBySql(dts).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    code = dt.Rows[0]["code"].ToStringOrEmpty();
                    msg = dt.Rows[0]["msg"].ToStringOrEmpty();
                }
            }
            else
            {
                code = "-1";
                msg = "sign验证失败";
            }
            dynamic dy = new System.Dynamic.ExpandoObject();
            dy.code = code;
            dy.msg = msg;
            context.Response.Write(JsonHelper.SerializeObject(dy));
        }

        public void gotolibocai(System.Web.HttpContext context)
        {
            Logger.Default.Info("开始gotolibocai");
            Message message = new Message();
            AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
            int num = 0;
            string userid = GameRequest.GetQueryString("userid");
            string ip = GameRequest.GetQueryString("ip");
            var dt = FacadeManage.aideAccountsFacade.GetDataTableBySql("select a.*,isnull(b.score,0) score from accountsinfo a left join RYTreasureDB.dbo.GameScoreInfo b on a.userid = b.userid  where a.userid = " + userid);
            if (dt.Rows.Count > 0)
            {
                var username = dt.Rows[0]["Accounts"];
                var nickname = dt.Rows[0]["NickName"];
                var password = dt.Rows[0]["LogonPass"];

                string libocaiurl = ApplicationSettings.Get("libocaiurl").ToStringOrEmpty();
                string key = ApplicationSettings.Get("libocaikey").ToStringOrEmpty();
                var today = DateTime.Now.ToString("yyyyMMdd");
                var score = dt.Rows[0]["score"];
                var postData = "nickname=" + nickname + "&password=" + password + "&score=" + score + "&today=" + today + "&username=" + username;

                MD5 md = new MD5CryptoServiceProvider();
                byte[] ss = md.ComputeHash(UnicodeEncoding.UTF8.GetBytes(postData + "&key=" + key));
                string sign = byteArrayToHexString(ss).ToUpper();

                var ret = HttpHelper.PostWebRequest(libocaiurl, "nickname=" + nickname + "&password=" + password + "&score=" + score + "&username=" + username + "&sign=" + sign + "&ip=" + ip);
                Logger.Default.Info("ret:" + ret);
                try
                {
                    var retObj = JsonHelper.DeserializeJsonToObject<dynamic>(ret);
                    Logger.Default.Info("retObj.code.Value:" + retObj.code.Value);
                    if (retObj.code.Value == 200)
                    {
                        Logger.Default.Info("retObj.data.Value:" + retObj.data.Value);
                        context.Response.Redirect(retObj.data.Value);
                    }
                    else
                    {
                        ajaxJsonValid.msg = retObj.message.Value;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Default.Info("ex.Message:" + ex.Message);
                    ajaxJsonValid.msg = ex.Message;
                }
                context.Response.Write(ret);
            }
            else
            {
                ajaxJsonValid.msg = "用户不存在";
                context.Response.Write(ajaxJsonValid.SerializeToJson());
            }
            Logger.Default.Info("结束gotolibocai");
        }

        private string[] HexCode = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };

        public string byteToHexString(byte b)
        {
            int n = b;
            if (n < 0)
            {
                n = 256 + n;
            }
            int d1 = n / 16;
            int d2 = n % 16;
            return HexCode[d1] + HexCode[d2];
        }

        public string byteArrayToHexString(byte[] b)
        {
            String result = "";
            for (int i = 0; i < b.Length; i++)
            {
                result = result + byteToHexString(b[i]);
            }
            return result;
        }
    }
}