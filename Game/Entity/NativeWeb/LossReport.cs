using System;
namespace Game.Entity.NativeWeb
{
	[Serializable]
	public class LossReport
	{
		public const string Tablename = "LossReport";
		public const string _ReportID = "ReportID";
		public const string _ReportNo = "ReportNo";
		public const string _UserID = "UserID";
		public const string _GameID = "GameID";
		public const string _Accounts = "Accounts";
		public const string _ReportEmail = "ReportEmail";
		public const string _Compellation = "Compellation";
		public const string _PassportID = "PassportID";
		public const string _MobilePhone = "MobilePhone";
		public const string _FixedPhone = "FixedPhone";
		public const string _RegisterDate = "RegisterDate";
		public const string _OldNickName1 = "OldNickName1";
		public const string _OldNickName2 = "OldNickName2";
		public const string _OldNickName3 = "OldNickName3";
		public const string _OldLogonPass1 = "OldLogonPass1";
		public const string _OldLogonPass2 = "OldLogonPass2";
		public const string _OldLogonPass3 = "OldLogonPass3";
		public const string _OldQuestion1 = "OldQuestion1";
		public const string _OldResponse1 = "OldResponse1";
		public const string _OldQuestion2 = "OldQuestion2";
		public const string _OldResponse2 = "OldResponse2";
		public const string _OldQuestion3 = "OldQuestion3";
		public const string _OldResponse3 = "OldResponse3";
		public const string _SuppInfo = "SuppInfo";
		public const string _ProcessStatus = "ProcessStatus";
		public const string _SendCount = "SendCount";
		public const string _Random = "Random";
		public const string _SolveDate = "SolveDate";
		public const string _OverDate = "OverDate";
		public const string _ReportIP = "ReportIP";
		public const string _ReportDate = "ReportDate";
		private int m_reportID;
		private string m_reportNo;
		private int m_userID;
		private int m_gameID;
		private string m_accounts;
		private string m_reportEmail;
		private string m_compellation;
		private string m_passportID;
		private string m_mobilePhone;
		private string m_fixedPhone;
		private string m_registerDate;
		private string m_oldNickName1;
		private string m_oldNickName2;
		private string m_oldNickName3;
		private string m_oldLogonPass1;
		private string m_oldLogonPass2;
		private string m_oldLogonPass3;
		private string m_oldQuestion1;
		private string m_oldResponse1;
		private string m_oldQuestion2;
		private string m_oldResponse2;
		private string m_oldQuestion3;
		private string m_oldResponse3;
		private string m_suppInfo;
		private byte m_processStatus;
		private int m_sendCount;
		private string m_random;
		private DateTime m_solveDate;
		private DateTime m_overDate;
		private string m_reportIP;
		private DateTime m_reportDate;
		public int ReportID
		{
			get
			{
				return this.m_reportID;
			}
			set
			{
				this.m_reportID = value;
			}
		}
		public string ReportNo
		{
			get
			{
				return this.m_reportNo;
			}
			set
			{
				this.m_reportNo = value;
			}
		}
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
		public string ReportEmail
		{
			get
			{
				return this.m_reportEmail;
			}
			set
			{
				this.m_reportEmail = value;
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
		public string PassportID
		{
			get
			{
				return this.m_passportID;
			}
			set
			{
				this.m_passportID = value;
			}
		}
		public string MobilePhone
		{
			get
			{
				return this.m_mobilePhone;
			}
			set
			{
				this.m_mobilePhone = value;
			}
		}
		public string FixedPhone
		{
			get
			{
				return this.m_fixedPhone;
			}
			set
			{
				this.m_fixedPhone = value;
			}
		}
		public string RegisterDate
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
		public string OldNickName1
		{
			get
			{
				return this.m_oldNickName1;
			}
			set
			{
				this.m_oldNickName1 = value;
			}
		}
		public string OldNickName2
		{
			get
			{
				return this.m_oldNickName2;
			}
			set
			{
				this.m_oldNickName2 = value;
			}
		}
		public string OldNickName3
		{
			get
			{
				return this.m_oldNickName3;
			}
			set
			{
				this.m_oldNickName3 = value;
			}
		}
		public string OldLogonPass1
		{
			get
			{
				return this.m_oldLogonPass1;
			}
			set
			{
				this.m_oldLogonPass1 = value;
			}
		}
		public string OldLogonPass2
		{
			get
			{
				return this.m_oldLogonPass2;
			}
			set
			{
				this.m_oldLogonPass2 = value;
			}
		}
		public string OldLogonPass3
		{
			get
			{
				return this.m_oldLogonPass3;
			}
			set
			{
				this.m_oldLogonPass3 = value;
			}
		}
		public string OldQuestion1
		{
			get
			{
				return this.m_oldQuestion1;
			}
			set
			{
				this.m_oldQuestion1 = value;
			}
		}
		public string OldResponse1
		{
			get
			{
				return this.m_oldResponse1;
			}
			set
			{
				this.m_oldResponse1 = value;
			}
		}
		public string OldQuestion2
		{
			get
			{
				return this.m_oldQuestion2;
			}
			set
			{
				this.m_oldQuestion2 = value;
			}
		}
		public string OldResponse2
		{
			get
			{
				return this.m_oldResponse2;
			}
			set
			{
				this.m_oldResponse2 = value;
			}
		}
		public string OldQuestion3
		{
			get
			{
				return this.m_oldQuestion3;
			}
			set
			{
				this.m_oldQuestion3 = value;
			}
		}
		public string OldResponse3
		{
			get
			{
				return this.m_oldResponse3;
			}
			set
			{
				this.m_oldResponse3 = value;
			}
		}
		public string SuppInfo
		{
			get
			{
				return this.m_suppInfo;
			}
			set
			{
				this.m_suppInfo = value;
			}
		}
		public byte ProcessStatus
		{
			get
			{
				return this.m_processStatus;
			}
			set
			{
				this.m_processStatus = value;
			}
		}
		public int SendCount
		{
			get
			{
				return this.m_sendCount;
			}
			set
			{
				this.m_sendCount = value;
			}
		}
		public string Random
		{
			get
			{
				return this.m_random;
			}
			set
			{
				this.m_random = value;
			}
		}
		public DateTime SolveDate
		{
			get
			{
				return this.m_solveDate;
			}
			set
			{
				this.m_solveDate = value;
			}
		}
		public DateTime OverDate
		{
			get
			{
				return this.m_overDate;
			}
			set
			{
				this.m_overDate = value;
			}
		}
		public string ReportIP
		{
			get
			{
				return this.m_reportIP;
			}
			set
			{
				this.m_reportIP = value;
			}
		}
		public DateTime ReportDate
		{
			get
			{
				return this.m_reportDate;
			}
			set
			{
				this.m_reportDate = value;
			}
		}
		public LossReport()
		{
			this.m_reportID = 0;
			this.m_reportNo = "";
			this.m_userID = 0;
			this.m_gameID = 0;
			this.m_accounts = "";
			this.m_reportEmail = "";
			this.m_compellation = "";
			this.m_passportID = "";
			this.m_mobilePhone = "";
			this.m_fixedPhone = "";
			this.m_registerDate = "";
			this.m_oldNickName1 = "";
			this.m_oldNickName2 = "";
			this.m_oldNickName3 = "";
			this.m_oldLogonPass1 = "";
			this.m_oldLogonPass2 = "";
			this.m_oldLogonPass3 = "";
			this.m_oldQuestion1 = "";
			this.m_oldResponse1 = "";
			this.m_oldQuestion2 = "";
			this.m_oldResponse2 = "";
			this.m_oldQuestion3 = "";
			this.m_oldResponse3 = "";
			this.m_suppInfo = "";
			this.m_processStatus = 0;
			this.m_sendCount = 0;
			this.m_random = "";
			this.m_solveDate = DateTime.Now;
			this.m_overDate = DateTime.Now;
			this.m_reportIP = "";
			this.m_reportDate = DateTime.Now;
		}
	}
}
