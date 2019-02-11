using Game.Data.Factory;
using Game.Entity.Accounts;
using Game.IData;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
namespace Game.Facade
{
	public class AccountsFacade
	{
		private IAccountsDataProvider accountsData;
		private ITreasureDataProvider treasureData;
		public AccountsFacade()
		{
			this.accountsData = ClassFactory.GetIAccountsDataProvider();
			this.treasureData = ClassFactory.GetITreasureDataProvider();
		}
		public Message PlayerDraw(int userID, decimal dwScore, string strSafePwd, string strOrderID, string strClientIP)
		{
			return this.accountsData.PlayerDraw(userID, dwScore, strSafePwd, strOrderID, strClientIP);
		}
		public DataSet GetIndividualDatum(int userID)
		{
			return this.accountsData.GetIndividualDatum(userID);
		}
		public Message PLayerBindBank(int userID, string UserName, string CardNO, string BankName, string bankAddress)
		{
			return this.accountsData.PLayerBindBank(userID, UserName, CardNO, BankName, bankAddress);
		}
		public Message GetBankBindInfo(int userID)
		{
			return this.accountsData.GetBankBindInfo(userID);
		}
		public Message Logon(UserInfo user, bool isEncryptPasswd)
		{
			if (!isEncryptPasswd)
			{
				user.LogonPass = TextEncrypt.EncryptPassword(user.LogonPass);
			}
			return this.accountsData.Login(user);
		}
		public Message Logon(string accounts, string logonPasswd)
		{
			return this.Logon(new UserInfo
			{
				Accounts = accounts,
				LogonPass = logonPasswd,
				LastLogonIP = GameRequest.GetUserIP()
			}, false);
		}
		public Message Register(UserInfo user, string parentAccount, string adid)
		{
			return this.accountsData.Register(user, parentAccount, adid);
		}
		public Message IsAccountsExist(string accounts)
		{
			return this.accountsData.IsAccountsExist(accounts);
		}
		public void ClearAccountsAdvertiseroByUserID(int userID)
		{
			this.accountsData.ClearAccountsAdvertiseroByUserID(userID);
		}
		public Message IsNickNameExist(string nickName)
		{
			return this.accountsData.IsNickNameExist(nickName);
		}
		public int GetUserIDByNickName(string nickName)
		{
			return this.accountsData.GetUserIDByNickName(nickName);
		}
		public int GetUserIDByAccounts(string accounts)
		{
			return this.accountsData.GetUserIDByAccounts(accounts);
		}
		public string GetAccountsByUserID(int userID)
		{
			return this.accountsData.GetAccountsByUserID(userID);
		}
		public string GetNickNameByUserID(int userID)
		{
			return this.accountsData.GetNickNameByUserID(userID);
		}
		public int GetGameIDByUserID(int userID)
		{
			return this.accountsData.GetGameIDByUserID(userID);
		}
		public UserInfo GetUserBaseInfoByUserID(int userID)
		{
			return this.accountsData.GetUserBaseInfoByUserID(userID);
		}
		public string GetAccountsBySubDomain(string subDomain)
		{
			return this.accountsData.GetAccountsBySubDomain(subDomain);
		}
		public IndividualDatum GetUserContactInfoByUserID(int userID)
		{
			return this.accountsData.GetUserContactInfoByUserID(userID);
		}
		public Message GetUserGlobalInfo(int userID, int gameID, string Accounts)
		{
			return this.accountsData.GetUserGlobalInfo(userID, gameID, Accounts);
		}
		public string GetPasswordCardByUserID(int userId)
		{
			return this.accountsData.GetPasswordCardByUserID(userId);
		}
		public AccountsFace GetAccountsFace(int customId)
		{
			return this.accountsData.GetAccountsFace(customId);
		}
		public AccountsFace GetAccountsFace(int customId, int userId)
		{
			return this.accountsData.GetAccountsFace(customId, userId);
		}
		public string GetUserFaceUrl(int userID)
		{
			string result = string.Empty;
			Message userGlobalInfo = this.GetUserGlobalInfo(userID, 0, "");
			if (userGlobalInfo.Success)
			{
				UserInfo userInfo = userGlobalInfo.EntityList[0] as UserInfo;
				result = this.GetUserFaceUrl((int)userInfo.FaceID, userInfo.CustomID);
			}
			return result;
		}
		public string GetUserFaceUrl(int faceID, int customID)
		{
			string result = string.Empty;
			if (customID == 0)
			{
				result = string.Format("/gamepic/Avatar{0}.png", faceID);
			}
			else
			{
				if (this.GetAccountsFace(customID) == null)
				{
					result = string.Format("/gamepic/Avatar{0}.png", faceID);
				}
				else
				{
					System.Random random = new System.Random();
					double num = random.NextDouble();
					result = string.Format("/WS/UserFace.ashx?customid={0}&x={1}", customID, num);
				}
			}
			return result;
		}
		public bool ExistCustomFace(int customID)
		{
			return customID != 0 && this.GetAccountsFace(customID) != null;
		}
		public System.Collections.Generic.IList<AccountsInfo> GetAccountsInfoList(System.Collections.ArrayList arrID)
		{
			return this.accountsData.GetAccountsInfoList(arrID);
		}
		public DataSet GetExperienceRank(int count)
		{
			return this.accountsData.GetExperienceRank(count);
		}
		public Message CheckUserSignature(int userID, object time, string signature)
		{
			Message message = new Message();
			message.Success = false;
			if (userID == 0 || time == null || string.IsNullOrEmpty(signature) || !Validate.IsDouble(time))
			{
				message.Content = "参数错误！";
				return message;
			}
			message = this.accountsData.GetUserGlobalInfo(userID, 0, "");
			if (!message.Success)
			{
				message.Content = "不存在的用户！";
				return message;
			}
			UserInfo userInfo = message.EntityList[0] as UserInfo;
			if (userInfo == null)
			{
				message.Content = "不存在的用户！";
				return message;
			}
			message.Success = false;
			if (string.IsNullOrEmpty(userInfo.DynamicPass.Trim()))
			{
				message.Content = "用户数据错误！";
				return message;
			}
			string s = userID.ToString() + userInfo.DynamicPass + time.ToString() + AppConfig.SyncLoginKey;
			string b = Utility.MD5(s);
			if (signature != b)
			{
				message.Content = "签名错误！";
				return message;
			}
			System.DateTime t = userInfo.DynamicPassTime.AddMilliseconds(System.Convert.ToDouble(time) + System.Convert.ToDouble(AppConfig.SyncUrlTimeOut));
			if (t < System.DateTime.Now)
			{
				message.Content = "请求超时！";
				return message;
			}
			message.AddEntity(userInfo);
			message.Success = true;
			return message;
		}
		public Message CheckUserSignature2(int userID, object time, string signature, ref System.DateTime? dtTest)
		{
			Message message = new Message();
			message.Success = false;
			if (userID == 0 || time == null || string.IsNullOrEmpty(signature) || !Validate.IsDouble(time))
			{
				message.Content = "参数错误！";
				return message;
			}
			message = this.accountsData.GetUserGlobalInfo(userID, 0, "");
			if (!message.Success)
			{
				message.Content = "不存在的用户！";
				return message;
			}
			UserInfo userInfo = message.EntityList[0] as UserInfo;
			if (userInfo == null)
			{
				message.Content = "不存在的用户！";
				return message;
			}
			message.Success = false;
			if (string.IsNullOrEmpty(userInfo.DynamicPass.Trim()))
			{
				message.Content = "用户数据错误！";
				return message;
			}
			string s = userID.ToString() + userInfo.DynamicPass + time.ToString() + AppConfig.SyncLoginKey;
			string b = Utility.MD5(s);
			if (signature != b)
			{
				message.Content = "签名错误！";
				return message;
			}
			System.DateTime dateTime = userInfo.DynamicPassTime.AddMilliseconds(System.Convert.ToDouble(time) + System.Convert.ToDouble(AppConfig.SyncUrlTimeOut));
			dtTest = new System.DateTime?(dateTime);
			if (dateTime < System.DateTime.Now)
			{
				message.Content = "请求超时！";
				return message;
			}
			message.Success = true;
			return message;
		}
		public Message ResetLogonPasswd(AccountsProtect sInfo)
		{
			return this.accountsData.ResetLogonPasswd(sInfo);
		}
		public Message ResetLoginPasswdByLossReport(UserInfo userInfo, string reportNo)
		{
			return this.accountsData.ResetLoginPasswdByLossReport(userInfo, reportNo);
		}
		public Message ResetInsurePasswd(AccountsProtect sInfo)
		{
			return this.accountsData.ResetInsurePasswd(sInfo);
		}
		public Message ModifyLogonPasswd(int userID, string srcPassword, string dstPassword, string ip)
		{
			return this.accountsData.ModifyLogonPasswd(userID, srcPassword, dstPassword, ip);
		}
		public Message ModifyInsurePasswd(int userID, string srcPassword, string dstPassword, string ip)
		{
			return this.accountsData.ModifyInsurePasswd(userID, srcPassword, dstPassword, ip);
		}
		public Message ApplyUserSecurity(AccountsProtect sInfo)
		{
			return this.accountsData.ApplyUserSecurity(sInfo);
		}
		public Message ModifyUserSecurity(AccountsProtect newInfo)
		{
			return this.accountsData.ModifyUserSecurity(newInfo);
		}
		public Message GetUserSecurityByUserID(int userID)
		{
			return this.accountsData.GetUserSecurityByUserID(userID);
		}
		public Message GetUserSecurityByGameID(int gameID)
		{
			return this.accountsData.GetUserSecurityByGameID(gameID);
		}
		public Message GetUserSecurityByAccounts(string accounts)
		{
			return this.accountsData.GetUserSecurityByAccounts(accounts);
		}
		public Message ConfirmUserSecurity(AccountsProtect info)
		{
			return this.accountsData.ConfirmUserSecurity(info);
		}
		public Message ApplyUserMoorMachine(AccountsProtect sInfo)
		{
			return this.accountsData.ApplyUserMoorMachine(sInfo);
		}
		public Message RescindUserMoorMachine(AccountsProtect sInfo)
		{
			return this.accountsData.RescindUserMoorMachine(sInfo);
		}
		public Message ModifyUserIndividual(IndividualDatum user, AccountsInfo info)
		{
			return this.accountsData.ModifyUserIndividual(user, info);
		}
		public Message ModifyUserFace(int userID, int faceID)
		{
			return this.accountsData.ModifyUserFace(userID, faceID);
		}
		public Message ModifyUserNickname(int userID, string nickName, string ip)
		{
			return this.accountsData.ModifyUserNickname(userID, nickName, ip);
		}
		public Message UserConvertPresent(int userID, int present, string ip)
		{
			return this.accountsData.UserConvertPresent(userID, present, ip);
		}
		public System.Collections.Generic.IList<UserInfo> GetUserInfoOrderByLoves()
		{
			return this.accountsData.GetUserInfoOrderByLoves();
		}
		public DataSet GetLovesRanking(int num)
		{
			return this.accountsData.GetLovesRanking(num);
		}
		public Message UserConvertMedal(int userID, int medals, string ip)
		{
			return this.accountsData.UserConvertMedal(userID, medals, ip);
		}
		public bool PasswordIDIsEnable(string serialNumber)
		{
			return this.accountsData.PasswordIDIsEnable(serialNumber);
		}
		public bool userIsBindPasswordCard(int userId)
		{
			return this.accountsData.userIsBindPasswordCard(userId);
		}
		public bool UpdateUserPasswordCardID(int userId, int serialNumber)
		{
			return this.accountsData.UpdateUserPasswordCardID(userId, serialNumber);
		}
		public bool ClearUserPasswordCardID(int userId)
		{
			return this.accountsData.ClearUserPasswordCardID(userId);
		}
		public SystemStatusInfo GetSystemStatusInfo(string key)
		{
			return this.accountsData.GetSystemStatusInfo(key);
		}
		public MemberProperty GetMemberProperty(int memberOrder)
		{
			return this.accountsData.GetMemberProperty(memberOrder);
		}
		public AccountsSignin GetAccountsSignin(int userId)
		{
			return this.accountsData.GetAccountsSignin(userId);
		}
		public Message Signin(int userId, string ip)
		{
			return this.accountsData.Signin(userId, ip);
		}
		public string GetAgentByDomain(string domain)
		{
			return this.accountsData.GetAgentByDomain(domain);
		}
		public AccountsAgent GetAccountAgentByUserID(int userID)
		{
			return this.accountsData.GetAccountAgentByUserID(userID);
		}
		public AccountsAgent GetAccountAgentByDomain(string domain)
		{
			return this.accountsData.GetAccountAgentByDomain(domain);
		}
		public int GetAgentChildCount(int userID)
		{
			return this.accountsData.GetAgentChildCount(userID);
		}
		public Message InsertCustomFace(AccountsFace accountsFace)
		{
			return this.accountsData.InsertCustomFace(accountsFace);
		}
		public PagerSet GetList(string tableName, int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.accountsData.GetList(tableName, pageIndex, pageSize, condition, orderby);
		}
		public PagerSet GetList(string tableName, int pageIndex, int pageSize, string condition, string orderby, string[] fields)
		{
			return this.accountsData.GetList(tableName, pageIndex, pageSize, condition, orderby, fields);
		}
		public object GetObjectBySql(string sqlQuery)
		{
			return this.accountsData.GetObjectBySql(sqlQuery);
		}
		public Message ExcuteByProce(string proceName, System.Collections.Generic.Dictionary<string, object> dir)
		{
			return this.accountsData.ExcuteByProce(proceName, dir);
		}
		public Message ExcuteByProceDataSet(string proceName, System.Collections.Generic.Dictionary<string, object> dir)
		{
			return this.accountsData.ExcuteByProceDataSet(proceName, dir);
		}
		public DataTable MySpreadInfo(int uid, int dateType)
		{
			return this.accountsData.MySpreadInfo(uid, dateType);
		}
		public DataTable MyOwnSpreadCount(int uid)
		{
			return this.accountsData.MyOwnSpreadCount(uid);
		}
		public Message SpreadBalance(int uid, double balance, string ip)
		{
			return this.accountsData.SpreadBalance(uid, balance, ip);
		}
		public DataTable MySpreadCntInfo(int uid, int type = 0)
		{
			return this.accountsData.MySpreadCntInfo(uid, type);
		}
		public PagerSet QuerySpreadScore(int uid, int type, int recordType, System.DateTime bTime, System.DateTime eTime, int pageIndex, int pageSize)
		{
			return this.accountsData.QuerySpreadScore(uid, type, recordType, bTime, eTime, pageIndex, pageSize);
		}
		public PagerSet QuerySpreadDailyRpt(int uid, string account, int lev, System.DateTime bTime, System.DateTime eTime, int pageIndex, int pageSize)
		{
			return this.accountsData.QuerySpreadDailyRpt(uid, account, lev, bTime, eTime, pageIndex, pageSize);
		}
		public Message MySpreadCheck(int gameid)
		{
			return this.accountsData.MySpreadCheck(gameid);
		}
		public int GetZhiJie(int spreaderId)
		{
			string sqlQuery = "SELECT COUNT(1) FROM AccountsInfo WITH(NOLOCK)WHERE SpreaderID=" + spreaderId;
			return System.Convert.ToInt32(this.accountsData.GetObjectBySql(sqlQuery));
		}
		public int GetJianJie(int spreaderId)
		{
			string sqlQuery = "SELECT COUNT(1)FROM RYAgentDB.dbo.Fn_GetSpreadNodes('down'," + spreaderId + ")WHERE lev>1";
			return System.Convert.ToInt32(this.accountsData.GetObjectBySql(sqlQuery));
		}
		public DataTable AgentCashInfo()
		{
			return this.accountsData.AgentCashInfo();
		}
		public DataSet GetAgentList()
		{
			string sql = "SELECT ShowName,WeChat,QQ FROM RYAgentDB..T_Acc_Agent WHERE IsClient=2 AND AgentStatus=0 ORDER BY ShowSort";
			return this.accountsData.GetDataSetBySql(sql);
		}
		public CashSetting PlayerCashInfo()
		{
			return this.accountsData.PlayerCashInfo();
		}
        public DataSet GetDataSetBySql(string sql)
        { 
            return this.accountsData.GetDataSetBySql(sql);
        }
        public DataTable GetDataTableBySql(string sql)
        {
            return this.accountsData.GetDataSetBySql(sql).Tables[0];
        }
	}
}
