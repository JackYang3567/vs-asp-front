using Game.Entity.Accounts;
using Game.IData;
using Game.Kernel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
namespace Game.Data
{
	public class AccountsDataProvider : BaseDataProvider, IAccountsDataProvider
	{
		public AccountsDataProvider(string connString) : base(connString)
		{
		}
		public Message PlayerDraw(int userID, decimal dwScore, string strSafePwd, string strOrderID, string strClientIP)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", userID));
			list.Add(base.Database.MakeInParam("dwScore", dwScore));
			list.Add(base.Database.MakeInParam("strSafePwd", strSafePwd));
			list.Add(base.Database.MakeInParam("strOrderID", strOrderID));
			list.Add(base.Database.MakeInParam("strClientIP", strClientIP));
			list.Add(base.Database.MakeOutParam("StrErr", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "P_Acc_PlayerDraw", list);
		}
		public System.Data.DataSet GetIndividualDatum(int userID)
		{
			string commandText = string.Format("SELECT Compellation,BankNo FROM IndividualDatum WHERE UserID=@UserID", new object[0]);
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("UserID", userID));
			return base.Database.ExecuteDataset(System.Data.CommandType.Text, commandText, list.ToArray());
		}
		public Message PLayerBindBank(int userID, string UserName, string CardNO, string BankName, string bankAddress)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", userID));
			list.Add(base.Database.MakeInParam("Compellation", UserName));
			list.Add(base.Database.MakeInParam("BankNO", CardNO));
			list.Add(base.Database.MakeInParam("BankName", BankName));
			list.Add(base.Database.MakeInParam("BankAddress", bankAddress));
			list.Add(base.Database.MakeOutParam("StrErr", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "P_Acc_PLayerBindBank", list);
		}
		public Message GetBankBindInfo(int userID)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", userID));
			list.Add(base.Database.MakeOutParam("StrErr", typeof(string), 127));
			return MessageHelper.GetMessageForDataSet(base.Database, "P_Acc_IsBankBinded", list);
		}
		public Message Login(UserInfo user)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("strAccounts", user.Accounts));
			list.Add(base.Database.MakeInParam("strPassword", user.LogonPass));
			list.Add(base.Database.MakeInParam("strClientIP", user.LastLogonIP));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessageForObject<UserInfo>(base.Database, "NET_PW_EfficacyAccounts", list);
		}
		public Message Register(UserInfo user, string parentAccount, string adid)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("strSpreader", parentAccount));
			list.Add(base.Database.MakeInParam("strAccounts", user.Accounts));
			list.Add(base.Database.MakeInParam("strNickname", user.NickName));
			list.Add(base.Database.MakeInParam("strLogonPass", user.LogonPass));
			list.Add(base.Database.MakeInParam("strInsurePass", user.InsurePass));
			list.Add(base.Database.MakeInParam("strDynamicPass", user.DynamicPass));
			list.Add(base.Database.MakeInParam("strCompellation", user.Compellation));
			list.Add(base.Database.MakeInParam("strPassPortID", user.PassPortID));
			list.Add(base.Database.MakeInParam("dwFaceID", user.FaceID));
			list.Add(base.Database.MakeInParam("dwGender", user.Gender));
			list.Add(base.Database.MakeInParam("strClientIP", user.RegisterIP));
			list.Add(base.Database.MakeInParam("AdID", adid));
			list.Add(base.Database.MakeInParam("strRegisterMobile", user.RegisterMobile));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessageForObject<UserInfo>(base.Database, "NET_PW_RegisterAccounts", list);
		}
		public Message IsAccountsExist(string accounts)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("strAccounts", accounts));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "NET_PW_IsAccountsExists", list);
		}
		public Message IsNickNameExist(string nickName)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("strNickName", nickName));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "NET_PW_IsNickNameExist", list);
		}
		public void ClearAccountsAdvertiseroByUserID(int userID)
		{
			string commandText = string.Format("update AccountsInfo set Advertiser='' WHERE UserID=@UserID", new object[0]);
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("UserID", userID));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, commandText, list.ToArray());
		}
		public int GetUserIDByNickName(string nickName)
		{
			string commandText = string.Format("SELECT NickName,UserID FROM AccountsInfo(NOLOCK) WHERE NickName=@NickName", new object[0]);
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("NickName", nickName));
			UserInfo userInfo = base.Database.ExecuteObject<UserInfo>(commandText, list);
			int result;
			if (userInfo != null)
			{
				result = userInfo.UserID;
			}
			else
			{
				result = 0;
			}
			return result;
		}
		public int GetUserIDByAccounts(string accounts)
		{
			string commandText = string.Format("SELECT UserID FROM AccountsInfo(NOLOCK) WHERE Accounts=@Accounts", new object[0]);
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("Accounts", accounts));
			object obj = base.Database.ExecuteScalar(System.Data.CommandType.Text, commandText, list.ToArray());
			int result;
			if (obj != null)
			{
				result = System.Convert.ToInt32(obj);
			}
			else
			{
				result = 0;
			}
			return result;
		}
		public string GetAccountsByUserID(int userID)
		{
			string commandText = string.Format("SELECT Accounts FROM AccountsInfo(NOLOCK) WHERE UserID=@UserID", new object[0]);
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("UserID", userID));
			object obj = base.Database.ExecuteScalar(System.Data.CommandType.Text, commandText, list.ToArray());
			string result;
			if (obj != null)
			{
				result = obj.ToString();
			}
			else
			{
				result = "";
			}
			return result;
		}
		public string GetNickNameByUserID(int userID)
		{
			string commandText = string.Format("SELECT NickName FROM AccountsInfo(NOLOCK) WHERE UserID=@UserID", new object[0]);
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("UserID", userID));
			object obj = base.Database.ExecuteScalar(System.Data.CommandType.Text, commandText, list.ToArray());
			string result;
			if (obj != null)
			{
				result = obj.ToString();
			}
			else
			{
				result = "";
			}
			return result;
		}
		public int GetGameIDByUserID(int userID)
		{
			string commandText = string.Format("SELECT GameID FROM AccountsInfo(NOLOCK) WHERE UserID=@UserID", new object[0]);
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("UserID", userID));
			object obj = base.Database.ExecuteScalar(System.Data.CommandType.Text, commandText, list.ToArray());
			int result;
			if (obj != null)
			{
				result = System.Convert.ToInt32(obj);
			}
			else
			{
				result = 0;
			}
			return result;
		}
		public UserInfo GetUserBaseInfoByUserID(int userID)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", userID));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return base.Database.RunProcObject<UserInfo>("NET_PW_GetUserBaseInfo", list);
		}
		public string GetAccountsBySubDomain(string subDomain)
		{
			string commandText = "SELECT Accounts FROM AccountsInfo WHERE GameID=@SubDomain";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("SubDomain", subDomain));
			AccountsInfo accountsInfo = base.Database.ExecuteObject<AccountsInfo>(commandText, list);
			string result;
			if (accountsInfo != null)
			{
				result = accountsInfo.Accounts;
			}
			else
			{
				result = "";
			}
			return result;
		}
		public IndividualDatum GetUserContactInfoByUserID(int userID)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", userID));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return base.Database.RunProcObject<IndividualDatum>("NET_PW_GetUserContactInfo", list);
		}
		public Message GetUserGlobalInfo(int userID, int gameID, string Accounts)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", userID));
			list.Add(base.Database.MakeInParam("dwGameID", gameID));
			list.Add(base.Database.MakeInParam("strAccounts", Accounts));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessageForObject<UserInfo>(base.Database, "NET_PW_GetUserGlobalsInfo", list);
		}
		public string GetPasswordCardByUserID(int userId)
		{
			string commandText = string.Format("SELECT PasswordID FROM AccountsInfo(NOLOCK) WHERE UserID=@UserID", new object[0]);
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("UserID", userId));
			return base.Database.ExecuteScalarToStr(System.Data.CommandType.Text, commandText, list.ToArray());
		}
		public AccountsFace GetAccountsFace(int customId)
		{
			string commandText = "SELECT * FROM AccountsFace WHERE ID=@ID";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("ID", customId));
			return base.Database.ExecuteObject<AccountsFace>(commandText, list);
		}
		public AccountsFace GetAccountsFace(int customId, int userId)
		{
			string commandText = "SELECT * FROM AccountsFace WHERE ID=@ID AND UserID=@UserID";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("ID", customId));
			list.Add(base.Database.MakeInParam("UserID", userId));
			return base.Database.ExecuteObject<AccountsFace>(commandText, list);
		}
		public System.Collections.Generic.IList<AccountsInfo> GetAccountsInfoList(System.Collections.ArrayList arrID)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.AppendFormat("SELECT UserID,Accounts,NickName,GameID,FaceID,CustomID,Gender FROM AccountsInfo WHERE UserID IN(", new object[0]);
			for (int i = 0; i < arrID.Count; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append(",");
				}
				stringBuilder.AppendFormat("{0}", arrID[i]);
			}
			stringBuilder.Append(")");
			return base.Database.ExecuteObjectList<AccountsInfo>(stringBuilder.ToString());
		}
		public System.Data.DataSet GetExperienceRank(int count)
		{
			string commandText = string.Format("SELECT TOP {0} UserID,GameID,Accounts,NickName,Experience FROM AccountsInfo WHERE Nullity=0 AND Experience>0 AND IsAndroid=0 ORDER BY Experience DESC", count);
			return base.Database.ExecuteDataset(commandText);
		}
		public Message ResetLogonPasswd(AccountsProtect sInfo)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", sInfo.UserID));
			list.Add(base.Database.MakeInParam("strPassword", sInfo.LogonPass));
			list.Add(base.Database.MakeInParam("strResponse1", sInfo.Response1));
			list.Add(base.Database.MakeInParam("strResponse2", sInfo.Response2));
			list.Add(base.Database.MakeInParam("strResponse3", sInfo.Response3));
			list.Add(base.Database.MakeInParam("strClientIP", sInfo.LastLogonIP));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "NET_PW_ResetLogonPasswd", list);
		}
		public Message ResetLoginPasswdByLossReport(UserInfo userInfo, string reportNo)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", userInfo.UserID));
			list.Add(base.Database.MakeInParam("strLogonPass", userInfo.LogonPass));
			list.Add(base.Database.MakeInParam("strReportNo", reportNo));
			list.Add(base.Database.MakeInParam("strClientIP", userInfo.LastLogonIP));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "NET_PW_ResetLoginPasswdByLossReport", list);
		}
		public Message ResetInsurePasswd(AccountsProtect sInfo)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", sInfo.UserID));
			list.Add(base.Database.MakeInParam("strInsurePass", sInfo.InsurePass));
			list.Add(base.Database.MakeInParam("strResponse1", sInfo.Response1));
			list.Add(base.Database.MakeInParam("strResponse2", sInfo.Response2));
			list.Add(base.Database.MakeInParam("strResponse3", sInfo.Response3));
			list.Add(base.Database.MakeInParam("strClientIP", sInfo.LastLogonIP));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "NET_PW_ResetInsurePasswd", list);
		}
		public Message ModifyLogonPasswd(int userID, string srcPassword, string dstPassword, string ip)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", userID));
			list.Add(base.Database.MakeInParam("strSrcPassword", srcPassword));
			list.Add(base.Database.MakeInParam("strDesPassword", dstPassword));
			list.Add(base.Database.MakeInParam("strClientIP", ip));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "NET_PW_ModifyLogonPass", list);
		}
		public Message ModifyInsurePasswd(int userID, string srcPassword, string dstPassword, string ip)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", userID));
			list.Add(base.Database.MakeInParam("strSrcPassword", srcPassword));
			list.Add(base.Database.MakeInParam("strDesPassword", dstPassword));
			list.Add(base.Database.MakeInParam("strClientIP", ip));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "NET_PW_ModifyInsurePass", list);
		}
		public Message ApplyUserSecurity(AccountsProtect sInfo)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", sInfo.UserID));
			list.Add(base.Database.MakeInParam("strQuestion1", sInfo.Question1));
			list.Add(base.Database.MakeInParam("strResponse1", sInfo.Response1));
			list.Add(base.Database.MakeInParam("strQuestion2", sInfo.Question2));
			list.Add(base.Database.MakeInParam("strResponse2", sInfo.Response2));
			list.Add(base.Database.MakeInParam("strQuestion3", sInfo.Question3));
			list.Add(base.Database.MakeInParam("strResponse3", sInfo.Response3));
			list.Add(base.Database.MakeInParam("dwPassportType", sInfo.PassportType));
			list.Add(base.Database.MakeInParam("strPassportID", sInfo.PassportID));
			list.Add(base.Database.MakeInParam("strSafeEmail", sInfo.SafeEmail));
			list.Add(base.Database.MakeInParam("strClientIP", sInfo.CreateIP));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "NET_PW_AddAccountProtect", list);
		}
		public Message ModifyUserSecurity(AccountsProtect newInfo)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", newInfo.UserID));
			list.Add(base.Database.MakeInParam("strQuestion1", newInfo.Question1));
			list.Add(base.Database.MakeInParam("strResponse1", newInfo.Response1));
			list.Add(base.Database.MakeInParam("strQuestion2", newInfo.Question2));
			list.Add(base.Database.MakeInParam("strResponse2", newInfo.Response2));
			list.Add(base.Database.MakeInParam("strQuestion3", newInfo.Question3));
			list.Add(base.Database.MakeInParam("strResponse3", newInfo.Response3));
			list.Add(base.Database.MakeInParam("strSafeEmail", newInfo.SafeEmail));
			list.Add(base.Database.MakeInParam("strClientIP", newInfo.ModifyIP));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "NET_PW_ModifyAccountProtect", list);
		}
		public Message GetUserSecurityByUserID(int userID)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", userID));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessageForObject<AccountsProtect>(base.Database, "NET_PW_GetAccountProtectByUserID", list);
		}
		public Message GetUserSecurityByGameID(int gameID)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwGameID", gameID));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessageForObject<AccountsProtect>(base.Database, "NET_PW_GetAccountProtectByGameID", list);
		}
		public Message GetUserSecurityByAccounts(string accounts)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("strAccounts", accounts));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessageForObject<AccountsProtect>(base.Database, "NET_PW_GetAccountProtectByAccounts", list);
		}
		public Message ConfirmUserSecurity(AccountsProtect info)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", info.UserID));
			list.Add(base.Database.MakeInParam("strResponse1", info.Response1));
			list.Add(base.Database.MakeInParam("strResponse2", info.Response2));
			list.Add(base.Database.MakeInParam("strResponse3", info.Response3));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "NET_PW_ConfirmAccountProtect", list);
		}
		public Message ApplyUserMoorMachine(AccountsProtect sInfo)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", sInfo.UserID));
			list.Add(base.Database.MakeInParam("strResponse1", sInfo.Response1));
			list.Add(base.Database.MakeInParam("strResponse2", sInfo.Response2));
			list.Add(base.Database.MakeInParam("strResponse3", sInfo.Response3));
			list.Add(base.Database.MakeInParam("strClientIP", sInfo.LastLogonIP));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "NET_PW_ApplyMoorMachine", list);
		}
		public Message RescindUserMoorMachine(AccountsProtect sInfo)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", sInfo.UserID));
			list.Add(base.Database.MakeInParam("strResponse1", sInfo.Response1));
			list.Add(base.Database.MakeInParam("strResponse2", sInfo.Response2));
			list.Add(base.Database.MakeInParam("strResponse3", sInfo.Response3));
			list.Add(base.Database.MakeInParam("strClientIP", sInfo.LastLogonIP));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "NET_PW_CancelMoorMachine", list);
		}
		public Message ModifyUserIndividual(IndividualDatum user, AccountsInfo info)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", user.UserID));
			list.Add(base.Database.MakeInParam("dwGender", info.Gender));
			list.Add(base.Database.MakeInParam("strUnderWrite", info.UnderWrite));
			list.Add(base.Database.MakeInParam("strQQ", user.QQ));
			list.Add(base.Database.MakeInParam("strEmail", user.EMail));
			list.Add(base.Database.MakeInParam("strSeatPhone", user.SeatPhone));
			list.Add(base.Database.MakeInParam("strMobilePhone", user.MobilePhone));
			list.Add(base.Database.MakeInParam("strDwellingPlace", user.DwellingPlace));
			list.Add(base.Database.MakeInParam("strUserNote", user.UserNote));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "NET_PW_ModifyUserInfo", list);
		}
		public Message ModifyUserFace(int userID, int faceID)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", userID));
			list.Add(base.Database.MakeInParam("dwFaceID", faceID));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "NET_PW_ModifyUserFace", list);
		}
		public Message ModifyUserNickname(int userID, string nickName, string ip)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", userID));
			list.Add(base.Database.MakeInParam("strNickName", nickName));
			list.Add(base.Database.MakeInParam("clientIP", ip));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "NET_PW_ModifyUserNickName", list);
		}
		public Message UserConvertPresent(int userID, int present, string ip)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", userID));
			list.Add(base.Database.MakeInParam("dwPresent", present));
			list.Add(base.Database.MakeInParam("strClientIP", ip));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "NET_PW_ConvertPresent", list);
		}
		public System.Collections.Generic.IList<UserInfo> GetUserInfoOrderByLoves()
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("SELECT TOP 10 Accounts, NickName,GameID, LoveLiness, Present ").Append("FROM AccountsInfo ").Append("WHERE Nullity=0 ").Append(" ORDER By LoveLiness DESC,UserID ASC");
			return base.Database.ExecuteObjectList<UserInfo>(stringBuilder.ToString());
		}
		public System.Data.DataSet GetLovesRanking(int num)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.AppendFormat("SELECT TOP {0} Accounts,NickName,GameID,LoveLiness,Present ", num).Append("FROM AccountsInfo").Append(" WHERE Nullity=0 AND LoveLiness>0").Append(" ORDER By LoveLiness DESC,UserID ASC");
			return base.Database.ExecuteDataset(stringBuilder.ToString());
		}
		public Message UserConvertMedal(int userID, int medals, string ip)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", userID));
			list.Add(base.Database.MakeInParam("dwMedals", medals));
			list.Add(base.Database.MakeInParam("strClientIP", ip));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "NET_PW_ConvertMedal", list);
		}
		public bool PasswordIDIsEnable(string serialNumber)
		{
			string commandText = string.Format("SELECT UserID FROM AccountsInfo(NOLOCK) WHERE PasswordID=@PasswordID", new object[0]);
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("PasswordID", serialNumber));
			return base.Database.ExecuteObject<AccountsInfo>(commandText, list) != null;
		}
		public bool userIsBindPasswordCard(int userId)
		{
			string commandText = string.Format("SELECT UserID FROM AccountsInfo(NOLOCK) WHERE PasswordID<>0 and userID=@UserID", userId);
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("UserID", userId));
			return base.Database.ExecuteObject<AccountsInfo>(commandText, list) != null;
		}
		public bool UpdateUserPasswordCardID(int userId, int serialNumber)
		{
			string commandText = string.Format("UPDATE AccountsInfo SET PasswordID=@PasswordID WHERE UserID=@UserID", new object[0]);
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("PasswordID", serialNumber));
			list.Add(base.Database.MakeInParam("UserID", userId));
			int num = base.Database.ExecuteNonQuery(System.Data.CommandType.Text, commandText, list.ToArray());
			return num > 0;
		}
		public bool ClearUserPasswordCardID(int userId)
		{
			string commandText = string.Format("UPDATE AccountsInfo SET PasswordID=0 WHERE UserID={0}", userId);
			int num = base.Database.ExecuteNonQuery(commandText);
			return num > 0;
		}
		public SystemStatusInfo GetSystemStatusInfo(string key)
		{
			string commandText = "SELECT * FROM SystemStatusInfo WHERE StatusName=@StatusName";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("StatusName", key));
			return base.Database.ExecuteObject<SystemStatusInfo>(commandText, list);
		}
		public MemberProperty GetMemberProperty(int memberOrder)
		{
			string commandText = "SELECT * FROM MemberProperty WHERE MemberOrder=@MemberOrder";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("MemberOrder", memberOrder));
			return base.Database.ExecuteObject<MemberProperty>(commandText, list);
		}
		public AccountsSignin GetAccountsSignin(int userId)
		{
			string commandText = "SELECT * FROM AccountsSignin WHERE UserID=@UserID";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("UserID", userId));
			return base.Database.ExecuteObject<AccountsSignin>(commandText, list);
		}
		public Message Signin(int userId, string ip)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", userId));
			list.Add(base.Database.MakeInParam("strClientIP", ip));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "NET_PW_Signin", list);
		}
		public string GetAgentByDomain(string domain)
		{
			string commandText = "select AgentAcc FROM RYAgentDB..T_Acc_Agent WHERE AgentDomain=@AgentDomain";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("AgentDomain", domain));
			object obj = base.Database.ExecuteScalar(System.Data.CommandType.Text, commandText, list.ToArray());
			string result;
			if (obj == null)
			{
				result = "";
			}
			else
			{
				result = obj.ToString();
			}
			return result;
		}
		public AccountsAgent GetAccountAgentByUserID(int userID)
		{
			string commandText = string.Format("SELECT * FROM AccountsAgent(NOLOCK) WHERE UserID= {0}", userID);
			AccountsAgent accountsAgent = base.Database.ExecuteObject<AccountsAgent>(commandText);
			AccountsAgent result;
			if (accountsAgent != null)
			{
				result = accountsAgent;
			}
			else
			{
				result = new AccountsAgent();
			}
			return result;
		}
		public AccountsAgent GetAccountAgentByDomain(string domain)
		{
			string commandText = string.Format("SELECT * FROM AccountsAgent(NOLOCK) WHERE Domain= @Domain", domain);
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("Domain", domain));
			AccountsAgent accountsAgent = base.Database.ExecuteObject<AccountsAgent>(commandText, list);
			AccountsAgent result;
			if (accountsAgent != null)
			{
				result = accountsAgent;
			}
			else
			{
				result = new AccountsAgent();
			}
			return result;
		}
		public int GetAgentChildCount(int userID)
		{
			string commandText = string.Format("SELECT COUNT(UserID) FROM AccountsInfo WHERE SpreaderID= {0}", userID);
			object obj = base.Database.ExecuteScalar(System.Data.CommandType.Text, commandText);
			int result;
			if (obj == null || obj.ToString().Length <= 0)
			{
				result = 0;
			}
			else
			{
				result = System.Convert.ToInt32(obj);
			}
			return result;
		}
		public Message InsertCustomFace(AccountsFace accountsFace)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", accountsFace.UserID));
			list.Add(base.Database.MakeInParam("imgCustomFace", accountsFace.CustomFace));
			list.Add(base.Database.MakeInParam("strClientIP", accountsFace.InsertAddr));
			list.Add(base.Database.MakeInParam("strMachineID", accountsFace.InsertMachine));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessageForObject<AccountsInfo>(base.Database, "NET_PW_InsertCustomFace", list);
		}
		public PagerSet GetList(string tableName, int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters(tableName, orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public PagerSet GetList(string tableName, int pageIndex, int pageSize, string condition, string orderby, string[] fields)
		{
			PagerParameters prams = new PagerParameters(tableName, orderby, condition, pageIndex, pageSize, fields);
			return this.GetPagerSet2(prams);
		}
		public object GetObjectBySql(string sqlQuery)
		{
			return base.Database.ExecuteScalar(System.Data.CommandType.Text, sqlQuery);
		}
		public Message ExcuteByProce(string proceName, System.Collections.Generic.Dictionary<string, object> dir)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			if (dir != null)
			{
				int num = 0;
				foreach (System.Collections.Generic.KeyValuePair<string, object> current in dir)
				{
					if (num == dir.Count - 1)
					{
						list.Add(base.Database.MakeOutParam(current.Key, typeof(string), 127));
					}
					else
					{
						list.Add(base.Database.MakeInParam(current.Key, current.Value));
					}
					num++;
				}
			}
			return MessageHelper.GetMessage(base.Database, proceName, list);
		}
		public Message ExcuteByProceDataSet(string proceName, System.Collections.Generic.Dictionary<string, object> dir)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			if (dir != null)
			{
				int num = 0;
				foreach (System.Collections.Generic.KeyValuePair<string, object> current in dir)
				{
					if (num == dir.Count - 1)
					{
						list.Add(base.Database.MakeOutParam(current.Key, typeof(string), 127));
					}
					else
					{
						list.Add(base.Database.MakeInParam(current.Key, current.Value));
					}
					num++;
				}
			}
			return MessageHelper.GetMessageForDataSet(base.Database, proceName, list);
		}
		public System.Data.DataSet GetDataSetBySql(string sql)
		{
			return base.Database.ExecuteDataset(sql);
		}
		public System.Data.DataTable MySpreadInfo(int uid, int dateType)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", uid));
			list.Add(base.Database.MakeInParam("dateType", dateType));
			return base.Database.ExecuteDataset(System.Data.CommandType.StoredProcedure, "RYAgentDB..P_Acc_MySpreadInfo", list.ToArray()).Tables[0];
		}
		public System.Data.DataTable MyOwnSpreadCount(int uid)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", uid));
			return base.Database.ExecuteDataset(System.Data.CommandType.StoredProcedure, "RYAgentDB..P_Acc_MyOwnSpreadCount", list.ToArray()).Tables[0];
		}
		public Message SpreadBalance(int uid, double balance, string ip)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", uid));
			list.Add(base.Database.MakeInParam("dwBalance", balance));
			list.Add(base.Database.MakeInParam("strClientIP", ip));
			list.Add(base.Database.MakeOutParam("strErr", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "RYAgentDB..P_Acc_SpreadBalance", list);
		}
		public System.Data.DataTable MySpreadCntInfo(int uid, int type)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", uid));
			list.Add(base.Database.MakeInParam("type", type));
			return base.Database.ExecuteDataset(System.Data.CommandType.StoredProcedure, "RYAgentDB..P_Acc_MySpreadCntInfo", list.ToArray()).Tables[0];
		}
		public PagerSet QuerySpreadScore(int uid, int type, int recordType, System.DateTime bTime, System.DateTime eTime, int pageIndex, int pageSize)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", uid));
			list.Add(base.Database.MakeInParam("type", type));
			list.Add(base.Database.MakeInParam("recordType", recordType));
			list.Add(base.Database.MakeInParam("bTime", bTime));
			list.Add(base.Database.MakeInParam("eTime", eTime));
			list.Add(base.Database.MakeInParam("PageIndex", pageIndex));
			list.Add(base.Database.MakeInParam("PageSize", pageSize));
			list.Add(base.Database.MakeOutParam("PageCount", typeof(int)));
			list.Add(base.Database.MakeOutParam("RecordCount", typeof(int)));
			list.Add(base.Database.MakeOutParam("StrErr", typeof(string), 127));
			string commandText = "RYAgentDB..P_Acc_QuerySpreadScore";
			System.Data.DataSet pageSet = base.Database.ExecuteDataset(System.Data.CommandType.StoredProcedure, commandText, list.ToArray());
			return new PagerSet(1, 1, 1, System.Convert.ToInt32(list[list.Count - 3].Value), pageSet);
		}
		public PagerSet QuerySpreadDailyRpt(int uid, string account, int lev, System.DateTime bTime, System.DateTime eTime, int pageIndex, int pageSize)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", uid));
			list.Add(base.Database.MakeInParam("gxAcc", account));
			list.Add(base.Database.MakeInParam("lev", lev));
			list.Add(base.Database.MakeInParam("bTime", bTime));
			list.Add(base.Database.MakeInParam("eTime", eTime));
			list.Add(base.Database.MakeInParam("PageIndex", pageIndex));
			list.Add(base.Database.MakeInParam("PageSize", pageSize));
			list.Add(base.Database.MakeOutParam("PageCount", typeof(int)));
			list.Add(base.Database.MakeOutParam("RecordCount", typeof(int)));
			string commandText = "RYAgentDB..P_Acc_QuerySpreadDailyRpt";
			System.Data.DataSet pageSet = base.Database.ExecuteDataset(System.Data.CommandType.StoredProcedure, commandText, list.ToArray());
			return new PagerSet(1, 1, 1, System.Convert.ToInt32(list[list.Count - 3].Value), pageSet);
		}
		public Message MySpreadCheck(int gameid)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwGameID", gameid));
			list.Add(base.Database.MakeOutParam("strErr", typeof(string), 127));
			return MessageHelper.GetMessageForDataSet(base.Database, "P_QuerySpreadCntInfo", list);
		}
		public System.Data.DataTable AgentCashInfo()
		{
			string commandText = "SELECT TOP 1 IsOpen,WeekOpenDay,SOpenTime,EOpenTime, DailyApplyTimes, BalancePrice,MinBalance,CounterFee,MinCounterFee,DiffAgentRate,MaxAgentRate FROM RYAgentDB..T_Acc_AgentStatusInfo";
			return base.Database.ExecuteDataset(commandText).Tables[0];
		}
		public CashSetting PlayerCashInfo()
		{
			string commandText = "SELECT TOP 1 IsOpen,IsSale,GameCnt,WeekOpenDay,Shour,Ehour,DailyApplyTimes,BalancePrice,MinBalance,CounterFee,MinCounterFee,MinPlayerScore FROM T_Acc_DealSet";
			return base.Database.ExecuteObject<CashSetting>(commandText);
		}
	}
}
