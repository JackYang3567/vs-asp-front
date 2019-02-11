using System;
namespace Game.Entity.NativeWeb
{
	[Serializable]
	public class GameMatchUserInfo
	{
		public const string Tablename = "GameMatchUserInfo";
		public const string _MatchID = "MatchID";
		public const string _UserID = "UserID";
		public const string _Accounts = "Accounts";
		public const string _GameID = "GameID";
		public const string _Compellation = "Compellation";
		public const string _Gender = "Gender";
		public const string _PassportID = "PassportID";
		public const string _MobilePhone = "MobilePhone";
		public const string _EMail = "EMail";
		public const string _QQ = "QQ";
		public const string _DwellingPlace = "DwellingPlace";
		public const string _PostalCode = "PostalCode";
		public const string _Nullity = "Nullity";
		public const string _ClientIP = "ClientIP";
		public const string _CollectDate = "CollectDate";
		private int m_matchID;
		private int m_userID;
		private string m_accounts;
		private int m_gameID;
		private string m_compellation;
		private byte m_gender;
		private string m_passportID;
		private string m_mobilePhone;
		private string m_eMail;
		private string m_qQ;
		private string m_dwellingPlace;
		private string m_postalCode;
		private byte m_nullity;
		private string m_clientIP;
		private DateTime m_collectDate;
		public int MatchID
		{
			get
			{
				return this.m_matchID;
			}
			set
			{
				this.m_matchID = value;
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
		public string EMail
		{
			get
			{
				return this.m_eMail;
			}
			set
			{
				this.m_eMail = value;
			}
		}
		public string QQ
		{
			get
			{
				return this.m_qQ;
			}
			set
			{
				this.m_qQ = value;
			}
		}
		public string DwellingPlace
		{
			get
			{
				return this.m_dwellingPlace;
			}
			set
			{
				this.m_dwellingPlace = value;
			}
		}
		public string PostalCode
		{
			get
			{
				return this.m_postalCode;
			}
			set
			{
				this.m_postalCode = value;
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
		public string ClientIP
		{
			get
			{
				return this.m_clientIP;
			}
			set
			{
				this.m_clientIP = value;
			}
		}
		public DateTime CollectDate
		{
			get
			{
				return this.m_collectDate;
			}
			set
			{
				this.m_collectDate = value;
			}
		}
		public GameMatchUserInfo()
		{
			this.m_matchID = 0;
			this.m_userID = 0;
			this.m_accounts = "";
			this.m_gameID = 0;
			this.m_compellation = "";
			this.m_gender = 0;
			this.m_passportID = "";
			this.m_mobilePhone = "";
			this.m_eMail = "";
			this.m_qQ = "";
			this.m_dwellingPlace = "";
			this.m_postalCode = "";
			this.m_nullity = 0;
			this.m_clientIP = "";
			this.m_collectDate = DateTime.Now;
		}
	}
}
