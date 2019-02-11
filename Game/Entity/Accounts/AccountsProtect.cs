using System;
namespace Game.Entity.Accounts
{
	[Serializable]
	public class AccountsProtect : UserInfo
	{
		public new const string Tablename = "AccountsProtect";
		public new const string _ProtectID = "ProtectID";
		public new const string _UserID = "UserID";
		public const string _Question1 = "Question1";
		public const string _Response1 = "Response1";
		public const string _Question2 = "Question2";
		public const string _Response2 = "Response2";
		public const string _Question3 = "Question3";
		public const string _Response3 = "Response3";
		public const string _PassportID = "PassportID";
		public const string _PassportType = "PassportType";
		public const string _SafeEmail = "SafeEmail";
		public const string _CreateIP = "CreateIP";
		public const string _ModifyIP = "ModifyIP";
		public const string _CreateDate = "CreateDate";
		public const string _ModifyDate = "ModifyDate";
		private int m_protectID;
		private int m_userID;
		private string m_question1;
		private string m_response1;
		private string m_question2;
		private string m_response2;
		private string m_question3;
		private string m_response3;
		private string m_passportID;
		private byte m_passportType;
		private string m_safeEmail;
		private string m_createIP;
		private string m_modifyIP;
		private DateTime m_createDate;
		private DateTime m_modifyDate;
		public new int ProtectID
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
		public new int UserID
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
		public string Question1
		{
			get
			{
				return this.m_question1;
			}
			set
			{
				this.m_question1 = value;
			}
		}
		public string Response1
		{
			get
			{
				return this.m_response1;
			}
			set
			{
				this.m_response1 = value;
			}
		}
		public string Question2
		{
			get
			{
				return this.m_question2;
			}
			set
			{
				this.m_question2 = value;
			}
		}
		public string Response2
		{
			get
			{
				return this.m_response2;
			}
			set
			{
				this.m_response2 = value;
			}
		}
		public string Question3
		{
			get
			{
				return this.m_question3;
			}
			set
			{
				this.m_question3 = value;
			}
		}
		public string Response3
		{
			get
			{
				return this.m_response3;
			}
			set
			{
				this.m_response3 = value;
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
		public byte PassportType
		{
			get
			{
				return this.m_passportType;
			}
			set
			{
				this.m_passportType = value;
			}
		}
		public string SafeEmail
		{
			get
			{
				return this.m_safeEmail;
			}
			set
			{
				this.m_safeEmail = value;
			}
		}
		public string CreateIP
		{
			get
			{
				return this.m_createIP;
			}
			set
			{
				this.m_createIP = value;
			}
		}
		public string ModifyIP
		{
			get
			{
				return this.m_modifyIP;
			}
			set
			{
				this.m_modifyIP = value;
			}
		}
		public DateTime CreateDate
		{
			get
			{
				return this.m_createDate;
			}
			set
			{
				this.m_createDate = value;
			}
		}
		public DateTime ModifyDate
		{
			get
			{
				return this.m_modifyDate;
			}
			set
			{
				this.m_modifyDate = value;
			}
		}
		public AccountsProtect()
		{
			this.m_protectID = 0;
			this.m_userID = 0;
			this.m_question1 = "";
			this.m_response1 = "";
			this.m_question2 = "";
			this.m_response2 = "";
			this.m_question3 = "";
			this.m_response3 = "";
			this.m_passportID = "";
			this.m_passportType = 0;
			this.m_safeEmail = "";
			this.m_createIP = "";
			this.m_modifyIP = "";
			this.m_createDate = DateTime.Now;
			this.m_modifyDate = DateTime.Now;
		}
	}
}
