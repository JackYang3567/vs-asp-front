using Game.Entity.Accounts;
using Game.Entity.NativeWeb;
using Game.Kernel;
using Game.Utils;
using Game.Utils.Cache;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace Game.Facade
{
    public sealed class Fetch
    {
        private static List<string> m_protectionQuestiongs;

        public static List<string> ProtectionQuestiongs
        {
            get
            {
                return Fetch.m_protectionQuestiongs;
            }
        }

        static Fetch()
        {
        }

        private Fetch()
        {
        }

        public static void DeleteUserCookie()
        {
            WHCache.Default.Delete<CookiesCache>(AppConfig.UserLoginCacheKey);
        }

        public static string GetAccountsByUserID(int userID)
        {
            UserInfo userBaseInfoByUserID = FacadeManage.aideAccountsFacade.GetUserBaseInfoByUserID(userID);
            if (userBaseInfoByUserID == null)
            {
                return "";
            }
            return userBaseInfoByUserID.Accounts;
        }

        public static string GetCacheCurrentRunStatus()
        {
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder stringBuilder1 = new StringBuilder();
            IDictionaryEnumerator enumerator = HttpRuntime.Cache.GetEnumerator();
            enumerator.Reset();
            enumerator.MoveNext();
            for (int i = 0; i < HttpRuntime.Cache.Count; i++)
            {
                stringBuilder.Append(enumerator.Key);
                if (i < HttpRuntime.Cache.Count - 1)
                {
                    stringBuilder.Append("&#10;&#13;");
                }
                enumerator.MoveNext();
            }
            long totalMemory = GC.GetTotalMemory(false) / (long)1024;
            stringBuilder1.AppendFormat("内存使用量：{0}KB &nbsp; ", totalMemory.ToString("#,#"));
            stringBuilder1.AppendFormat("共使用 <span title=\"{1}\">{0}</span> 个系统缓存对象", HttpRuntime.Cache.Count, stringBuilder.ToString());
            return stringBuilder1.ToString();
        }

        public static int GetDateID(System.DateTime DateTime)
        {
            TimeSpan timeSpan = new TimeSpan(DateTime.Ticks);
            TimeSpan timeSpan1 = new TimeSpan(Convert.ToDateTime("1900-01-01").Ticks);
            return timeSpan.Subtract(timeSpan1).Duration().Days;
        }

        public static string GetForgetPwdNumber()
        {
            StringBuffer stringBuffer = new StringBuffer() + TextUtility.GetDateTimeLongString();
            stringBuffer += TextUtility.CreateRandom(8, 1, 0, 0, 0, "");
            return stringBuffer.ToString();
        }

        public static string GetGameID(int gameID)
        {
            if (gameID <= 0)
            {
                return "尚未分配";
            }
            return gameID.ToString();
        }

        public static int GetGameIDByUserID(int userID)
        {
            UserInfo userBaseInfoByUserID = FacadeManage.aideAccountsFacade.GetUserBaseInfoByUserID(userID);
            if (userBaseInfoByUserID == null)
            {
                return 0;
            }
            return userBaseInfoByUserID.GameID;
        }

        public static int GetGradeConfig(int experience)
        {
            DataSet growLevelConfigList = FacadeManage.aidePlatformFacade.GetGrowLevelConfigList();
            if (growLevelConfigList.Tables[0].Rows.Count <= 0)
            {
                return 0;
            }
            DataView dataViews = growLevelConfigList.Tables[0].AsEnumerable().Where<DataRow>((DataRow n) => n.Field<int>("Experience") < experience).OrderByDescending<DataRow, int>((DataRow n) => n.Field<int>("Experience")).AsDataView<DataRow>();
            if (dataViews.Count <= 0)
            {
                return 1;
            }
            return Convert.ToInt32(dataViews[0]["LevelID"]);
        }

        public static string GetNickNameByUserID(int userID)
        {
            UserInfo userBaseInfoByUserID = FacadeManage.aideAccountsFacade.GetUserBaseInfoByUserID(userID);
            if (userBaseInfoByUserID == null)
            {
                return "";
            }
            return userBaseInfoByUserID.NickName;
        }

        public static AccountsProtect GetOldProtectionInfo(int userID)
        {
            string str = string.Format("old_{0}", Fetch.GetSessionProtectionKey(userID));
            return WHCache.Default.Get<SessionCache>(str) as AccountsProtect;
        }

        private static void GetProtectionQuestions()
        {
            Fetch.m_protectionQuestiongs = new List<string>();
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(TextUtility.GetFullPath("/config/protection.xml"));
            DataRow[] dataRowArray = dataSet.Tables["Item"].Select("Questions_ID=0");
            for (int i = 0; i < (int)dataRowArray.Length; i++)
            {
                DataRow dataRow = dataRowArray[i];
                Fetch.m_protectionQuestiongs.Add(dataRow[0].ToString());
            }
        }

        public static string GetSessionProtectionKey(int userID)
        {
            return string.Format("question_userID_{0}", userID);
        }

        public static string GetSpreaderUrl(int userID)
        {
            string domain = "";
            domain = FacadeManage.aideAccountsFacade.GetAccountAgentByUserID(userID).Domain;
            if (domain == "")
            {
                int gameIDByUserID = FacadeManage.aideAccountsFacade.GetGameIDByUserID(userID);
                string str = HttpContext.Current.Request.Url.Authority.ToString();
                char[] chrArray = new char[] { '.' };
                string str1 = str.Split(chrArray)[1];
                char[] chrArray1 = new char[] { '|' };
                domain = (Array.IndexOf("com|cn|top|wang|net|org|hk|co|cc|me|pw|la|asia|biz|mobi|net|org|gov|name|info|hk|tm|tv|tel|us|website|host|press|tw|ren|中国|香港|公司|网络|商标|移动".Split(chrArray1), str1) == -1 ? string.Concat(gameIDByUserID, ".", HttpContext.Current.Request.Url.Authority.Substring(HttpContext.Current.Request.Url.Authority.IndexOf('.') + 1)) : string.Concat(gameIDByUserID, ".", HttpContext.Current.Request.Url.Authority));
            }
            return domain;
        }

        public static string GetStrUserID(int userID)
        {
            return CWHEncryptNet.XorEncrypt(userID.ToString());
        }

        public static int GetTerminalType(HttpRequest request)
        {
            string lower = request.Headers["User-Agent"].ToLower();
            if (lower.Contains("android"))
            {
                return 1;
            }
            if (!lower.Contains("ipad") && !lower.Contains("iphone"))
            {
                return 0;
            }
            return 2;
        }

        public static string GetUploadFileUrl(string fileUrl)
        {
            string empty = string.Empty;
            object obj = WHCache.Default.Get<AspNetCache>("RY_6603_Image_Domain");
            if (obj == null)
            {
                ConfigInfo configInfo = FacadeManage.aideNativeWebFacade.GetConfigInfo(AppConfig.SiteConfigKey.SiteConfig.ToString());
                if (configInfo != null)
                {
                    empty = configInfo.Field3;
                }
                WHCache.Default.Save<AspNetCache>("RY_6603_Image_Domain", empty, new int?(30));
            }
            else
            {
                empty = obj.ToString();
            }
            fileUrl = fileUrl.ToLower().Replace("upload/", "");
            return string.Concat(empty, fileUrl);
        }

        public static UserTicketInfo GetUserCookie()
        {
            object obj = WHCache.Default.Get<CookiesCache>(AppConfig.UserLoginCacheKey);
            string empty = string.Empty;
            if (obj == null)
            {
                return null;
            }
            empty = obj.ToString();
            string str = AES.Decrypt(empty, AppConfig.UserLoginCacheEncryptKey);
            if (TextUtility.EmptyTrimOrNull(str))
            {
                return null;
            }
            return UserTicketInfo.DeserializeObject(str);
        }

        public static UserInfo GetUserGlobalInfo(int userID)
        {
            UserInfo userInfo = new UserInfo();
            Message userGlobalInfo = FacadeManage.aideAccountsFacade.GetUserGlobalInfo(userID, 0, "");
            if (userGlobalInfo.Success)
            {
                userInfo = userGlobalInfo.EntityList[0] as UserInfo;
            }
            return userInfo;
        }

        public static int GetUserID(string strUserID)
        {
            return TypeParse.StrToInt(CWHEncryptNet.XorCrevasse(strUserID), 0);
        }

        public static string GetVerifyCode()
        {
            string empty = string.Empty;
            empty = WHCache.Default.Get<SessionCache>("VerifyCodeKey") as string;
            if (string.IsNullOrEmpty(empty))
            {
                empty = WHCache.Default.Get<CookiesCache>("VerifyCodeKey") as string;
            }
            return empty;
        }

        public static bool IsUserOnline()
        {
            UserTicketInfo userCookie = Fetch.GetUserCookie();
            if (userCookie != null && userCookie.UserID > 0)
            {
                return true;
            }
            return false;
        }

        public static string PalaformWriteCookie()
        {
            if (HttpContext.Current.Request.Cookies["Accounts"] != null && HttpContext.Current.Request.Cookies["Password"] != null)
            {
                string str = HttpContext.Current.Request.Cookies["Accounts"].Value.ToString();
                string str1 = HttpContext.Current.Request.Cookies["Password"].Value.ToString();
                str1 = str1.Trim();
                UserInfo userInfo = new UserInfo(0, str.Trim(), 0)
                {
                    LastLogonIP = GameRequest.GetUserIP()
                };
                Message message = FacadeManage.aideAccountsFacade.Logon(userInfo, true);
                if (message.Success)
                {
                    UserInfo item = message.EntityList[0] as UserInfo;
                    item.LogonPass = str1.Trim();
                    Fetch.SetUserCookie(item.ToUserTicketInfo());
                    object obj = WHCache.Default.Get<CookiesCache>(AppConfig.UserLoginCacheKey);
                    if (obj != null)
                    {
                        return obj.ToString();
                    }
                }
            }
            return "";
        }

        public static void ReWriteUserCookie()
        {
            if (Fetch.IsUserOnline())
            {
                UserTicketInfo userCookie = Fetch.GetUserCookie();
                Message message = FacadeManage.aideAccountsFacade.Logon(new UserInfo(userCookie), false);
                if (message.Success)
                {
                    UserInfo item = message.EntityList[0] as UserInfo;
                    Fetch.SetUserCookie(item.ToUserTicketInfo());
                }
            }
        }

        public static void SetOldProtectionInfo(AccountsProtect protection)
        {
            if (protection == null)
            {
                return;
            }
            string str = string.Format("old_{0}", Fetch.GetSessionProtectionKey(protection.UserID));
            WHCache.Default.Save<SessionCache>(str, protection, new int?(10));
        }

        public static void SetUserCookie(UserTicketInfo userTicket)
        {
            if (userTicket == null)
            {
                return;
            }
            string str = userTicket.SerializeText();
            string str1 = AES.Encrypt(str, AppConfig.UserLoginCacheEncryptKey);
            WHCache.Default.Save<CookiesCache>(AppConfig.UserLoginCacheKey, str1, new int?(AppConfig.UserLoginTimeOut));
        }

        public static string ShowDate(int dateID)
        {
            DateTime dateTime = Convert.ToDateTime("1900-01-01");
            return dateTime.AddDays((double)dateID).ToString("yyyy-MM-dd");
        }
    }
}