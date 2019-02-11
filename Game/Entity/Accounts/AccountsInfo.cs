using System;
namespace Game.Entity.Accounts
{
	[Serializable]
	public class AccountsInfo
	{
		public const string Tablename = "AccountsInfo";
		public const string _UserID = "UserID";
		public const string _GameID = "GameID";
		public const string _ProtectID = "ProtectID";
		public const string _PasswordID = "PasswordID";
		public const string _SpreaderID = "SpreaderID";
		public const string _Accounts = "Accounts";
		public const string _NickName = "NickName";
		public const string _RegAccounts = "RegAccounts";
		public const string _UnderWrite = "UnderWrite";
		public const string _PassPortID = "PassPortID";
		public const string _Compellation = "Compellation";
		public const string _LogonPass = "LogonPass";
		public const string _InsurePass = "InsurePass";
		public const string _DynamicPass = "DynamicPass";
		public const string _DynamicPassTime = "DynamicPassTime";
		public const string _FaceID = "FaceID";
		public const string _CustomID = "CustomID";
		public const string _Present = "Present";
		public const string _UserMedal = "UserMedal";
		public const string _Experience = "Experience";
		public const string _GrowLevelID = "GrowLevelID";
		public const string _LoveLiness = "LoveLiness";
		public const string _UserRight = "UserRight";
		public const string _MasterRight = "MasterRight";
		public const string _ServiceRight = "ServiceRight";
		public const string _MasterOrder = "MasterOrder";
		public const string _MemberOrder = "MemberOrder";
		public const string _MemberOverDate = "MemberOverDate";
		public const string _MemberSwitchDate = "MemberSwitchDate";
		public const string _CustomFaceVer = "CustomFaceVer";
		public const string _Gender = "Gender";
		public const string _Nullity = "Nullity";
		public const string _NullityOverDate = "NullityOverDate";
		public const string _StunDown = "StunDown";
		public const string _MoorMachine = "MoorMachine";
		public const string _IsAndroid = "IsAndroid";
		public const string _WebLogonTimes = "WebLogonTimes";
		public const string _GameLogonTimes = "GameLogonTimes";
		public const string _PlayTimeCount = "PlayTimeCount";
		public const string _OnLineTimeCount = "OnLineTimeCount";
		public const string _LastLogonIP = "LastLogonIP";
		public const string _LastLogonDate = "LastLogonDate";
		public const string _LastLogonMobile = "LastLogonMobile";
		public const string _LastLogonMachine = "LastLogonMachine";
		public const string _RegisterIP = "RegisterIP";
		public const string _RegisterDate = "RegisterDate";
		public const string _RegisterMobile = "RegisterMobile";
		public const string _RegisterMachine = "RegisterMachine";
		public const string _UserUin = "UserUin";
		public const string _RankID = "RankID";
		public const string _AgentID = "AgentID";
		private int m_userID;
		private int m_gameID;
		private int m_protectID;
		private int m_passwordID;
		private int m_spreaderID;
		private string m_accounts;
		private string m_nickName;
		private string m_regAccounts;
		private string m_underWrite;
		private string m_passPortID;
		private string m_compellation;
		private string m_logonPass;
		private string m_insurePass;
		private string m_dynamicPass;
		private DateTime m_dynamicPassTime;
		private short m_faceID;
		private int m_customID;
		private int m_present;
		private int m_userMedal;
		private int m_experience;
		private int m_growLevelID;
		private int m_loveLiness;
		private int m_userRight;
		private int m_masterRight;
		private int m_serviceRight;
		private byte m_masterOrder;
		private byte m_memberOrder;
		private DateTime m_memberOverDate;
		private DateTime m_memberSwitchDate;
		private byte m_customFaceVer;
		private byte m_gender;
		private byte m_nullity;
		private DateTime m_nullityOverDate;
		private byte m_stunDown;
		private byte m_moorMachine;
		private byte m_isAndroid;
		private int m_webLogonTimes;
		private int m_gameLogonTimes;
		private int m_playTimeCount;
		private int m_onLineTimeCount;
		private string m_lastLogonIP;
		private DateTime m_lastLogonDate;
		private string m_lastLogonMobile;
		private string m_lastLogonMachine;
		private string m_registerIP;
		private DateTime m_registerDate;
		private string m_registerMobile;
		private string m_registerMachine;
		private long m_userUin;
		private int m_rankID;
		private int m_agentID;
		public int UserID
		{
			get
			{
				return this.m_userID;
			}
			set
			{
				this.m_userID = value;
			}
		}
		public int GameID
		{
			get
			{
				return this.m_gameID;
			}
			set
			{
				this.m_gameID = value;
			}
		}
		public int ProtectID
		{
			get
			{
				return this.m_protectID;
			}
			set
			{
				this.m_protectID = value;
			}
		}
		public int PasswordID
		{
			get
			{
				return this.m_passwordID;
			}
			set
			{
				this.m_passwordID = value;
			}
		}
		public int SpreaderID
		{
			get
			{
				return this.m_spreaderID;
			}
			set
			{
				this.m_spreaderID = value;
			}
		}
		public string Accounts
		{
			get
			{
				return this.m_accounts;
			}
			set
			{
				this.m_accounts = value;
			}
		}
		public string NickName
		{
			get
			{
				return this.m_nickName;
			}
			set
			{
				this.m_nickName = value;
			}
		}
		public string RegAccounts
		{
			get
			{
				return this.m_regAccounts;
			}
			set
			{
				this.m_regAccounts = value;
			}
		}
		public string UnderWrite
		{
			get
			{
				return this.m_underWrite;
			}
			set
			{
				this.m_underWrite = value;
			}
		}
		public string PassPortID
		{
			get
			{
				return this.m_passPortID;
			}
			set
			{
				this.m_passPortID = value;
			}
		}
		public string Compellation
		{
			get
			{
				return this.m_compellation;
			}
			set
			{
				this.m_compellation = value;
			}
		}
		public string LogonPass
		{
			get
			{
				return this.m_logonPass;
			}
			set
			{
				this.m_logonPass = value;
			}
		}
		public string InsurePass
		{
			get
			{
				return this.m_insurePass;
			}
			set
			{
				this.m_insurePass = value;
			}
		}
		public string DynamicPass
		{
			get
			{
				return this.m_dynamicPass;
			}
			set
			{
				this.m_dynamicPass = value;
			}
		}
		public DateTime DynamicPassTime
		{
			get
			{
				return this.m_dynamicPassTime;
			}
			set
			{
				this.m_dynamicPassTime = value;
			}
		}
		public short FaceID
		{
			get
			{
				return this.m_faceID;
			}
			set
			{
				this.m_faceID = value;
			}
		}
		public int CustomID
		{
			get
			{
				return this.m_customID;
			}
			set
			{
				this.m_customID = value;
			}
		}
		public int Present
		{
			get
			{
				return this.m_present;
			}
			set
			{
				this.m_present = value;
			}
		}
		public int UserMedal
		{
			get
			{
				return this.m_userMedal;
			}
			set
			{
				this.m_userMedal = value;
			}
		}
		public int Experience
		{
			get
			{
				return this.m_experience;
			}
			set
			{
				this.m_experience = value;
			}
		}
		public int GrowLevelID
		{
			get
			{
				return this.m_growLevelID;
			}
			set
			{
				this.m_growLevelID = value;
			}
		}
		public int LoveLiness
		{
			get
			{
				return this.m_loveLiness;
			}
			set
			{
				this.m_loveLiness = value;
			}
		}
		public int UserRight
		{
			get
			{
				return this.m_userRight;
			}
			set
			{
				this.m_userRight = value;
			}
		}
		public int MasterRight
		{
			get
			{
				return this.m_masterRight;
			}
			set
			{
				this.m_masterRight = value;
			}
		}
		public int ServiceRight
		{
			get
			{
				return this.m_serviceRight;
			}
			set
			{
				this.m_serviceRight = value;
			}
		}
		public byte MasterOrder
		{
			get
			{
				return this.m_masterOrder;
			}
			set
			{
				this.m_masterOrder = value;
			}
		}
		public byte MemberOrder
		{
			get
			{
				return this.m_memberOrder;
			}
			set
			{
				this.m_memberOrder = value;
			}
		}
		public DateTime MemberOverDate
		{
			get
			{
				return this.m_memberOverDate;
			}
			set
			{
				this.m_memberOverDate = value;
			}
		}
		public DateTime MemberSwitchDate
		{
			get
			{
				return this.m_memberSwitchDate;
			}
			set
			{
				this.m_memberSwitchDate = value;
			}
		}
		public byte CustomFaceVer
		{
			get
			{
				return this.m_customFaceVer;
			}
			set
			{
				this.m_customFaceVer = value;
			}
		}
		public byte Gender
		{
			get
			{
				return this.m_gender;
			}
			set
			{
				this.m_gender = value;
			}
		}
		public byte Nullity
		{
			get
			{
				return this.m_nullity;
			}
			set
			{
				this.m_nullity = value;
			}
		}
		public DateTime NullityOverDate
		{
			get
			{
				return this.m_nullityOverDate;
			}
			set
			{
				this.m_nullityOverDate = value;
			}
		}
		public byte StunDown
		{
			get
			{
				return this.m_stunDown;
			}
			set
			{
				this.m_stunDown = value;
			}
		}
		public byte MoorMachine
		{
			get
			{
				return this.m_moorMachine;
			}
			set
			{
				this.m_moorMachine = value;
			}
		}
		public byte IsAndroid
		{
			get
			{
				return this.m_isAndroid;
			}
			set
			{
				this.m_isAndroid = value;
			}
		}
		public int WebLogonTimes
		{
			get
			{
				return this.m_webLogonTimes;
			}
			set
			{
				this.m_webLogonTimes = value;
			}
		}
		public int GameLogonTimes
		{
			get
			{
				return this.m_gameLogonTimes;
			}
			set
			{
				this.m_gameLogonTimes = value;
			}
		}
		public int PlayTimeCount
		{
			get
			{
				return this.m_playTimeCount;
			}
			set
			{
				this.m_playTimeCount = value;
			}
		}
		public int OnLineTimeCount
		{
			get
			{
				return this.m_onLineTimeCount;
			}
			set
			{
				this.m_onLineTimeCount = value;
			}
		}
		public string LastLogonIP
		{
			get
			{
				return this.m_lastLogonIP;
			}
			set
			{
				this.m_lastLogonIP = value;
			}
		}
		public DateTime LastLogonDate
		{
			get
			{
				return this.m_lastLogonDate;
			}
			set
			{
				this.m_lastLogonDate = value;
			}
		}
		public string LastLogonMobile
		{
			get
			{
				return this.m_lastLogonMobile;
			}
			set
			{
				this.m_lastLogonMobile = value;
			}
		}
		public string LastLogonMachine
		{
			get
			{
				return this.m_lastLogonMachine;
			}
			set
			{
				this.m_lastLogonMachine = value;
			}
		}
		public string RegisterIP
		{
			get
			{
				return this.m_registerIP;
			}
			set
			{
				this.m_registerIP = value;
			}
		}
		public DateTime RegisterDate
		{
			get
			{
				return this.m_registerDate;
			}
			set
			{
				this.m_registerDate = value;
			}
		}
		public string RegisterMobile
		{
			get
			{
				return this.m_registerMobile;
			}
			set
			{
				this.m_registerMobile = value;
			}
		}
		public string RegisterMachine
		{
			get
			{
				return this.m_registerMachine;
			}
			set
			{
				this.m_registerMachine = value;
			}
		}
		public long UserUin
		{
			get
			{
				return this.m_userUin;
			}
			set
			{
				this.m_userUin = value;
			}
		}
		public int RankID
		{
			get
			{
				return this.m_rankID;
			}
			set
			{
				this.m_rankID = value;
			}
		}
		public int AgentID
		{
			get
			{
				return this.m_agentID;
			}
			set
			{
				this.m_agentID = value;
			}
		}
		public AccountsInfo()
		{
			this.m_userID = 0;
			this.m_gameID = 0;
			this.m_protectID = 0;
			this.m_passwordID = 0;
			this.m_spreaderID = 0;
			this.m_accounts = "";
			this.m_nickName = "";
			this.m_regAccounts = "";
			this.m_underWrite = "";
			this.m_passPortID = "";
			this.m_compellation = "";
			this.m_logonPass = "";
			this.m_insurePass = "";
			this.m_dynamicPass = "";
			this.m_dynamicPassTime = DateTime.Now;
			this.m_faceID = 0;
			this.m_customID = 0;
			this.m_present = 0;
			this.m_userMedal = 0;
			this.m_experience = 0;
			this.m_growLevelID = 0;
			this.m_loveLiness = 0;
			this.m_userRight = 0;
			this.m_masterRight = 0;
			this.m_serviceRight = 0;
			this.m_masterOrder = 0;
			this.m_memberOrder = 0;
			this.m_memberOverDate = DateTime.Now;
			this.m_memberSwitchDate = DateTime.Now;
			this.m_customFaceVer = 0;
			this.m_gender = 0;
			this.m_nullity = 0;
			this.m_nullityOverDate = DateTime.Now;
			this.m_stunDown = 0;
			this.m_moorMachine = 0;
			this.m_isAndroid = 0;
			this.m_webLogonTimes = 0;
			this.m_gameLogonTimes = 0;
			this.m_playTimeCount = 0;
			this.m_onLineTimeCount = 0;
			this.m_lastLogonIP = "";
			this.m_lastLogonDate = DateTime.Now;
			this.m_lastLogonMobile = "";
			this.m_lastLogonMachine = "";
			this.m_registerIP = "";
			this.m_registerDate = DateTime.Now;
			this.m_registerMobile = "";
			this.m_registerMachine = "";
			this.m_userUin = 0L;
			this.m_rankID = 0;
			this.m_agentID = 0;
		}
	}
}
