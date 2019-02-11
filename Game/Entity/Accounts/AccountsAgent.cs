using System;
namespace Game.Entity.Accounts
{
	[Serializable]
	public class AccountsAgent
	{
		public const string Tablename = "AccountsAgent";
		public const string _AgentID = "AgentID";
		public const string _UserID = "UserID";
		public const string _Compellation = "Compellation";
		public const string _Domain = "Domain";
		public const string _AgentType = "AgentType";
		public const string _AgentScale = "AgentScale";
		public const string _PayBackScore = "PayBackScore";
		public const string _PayBackScale = "PayBackScale";
		public const string _MobilePhone = "MobilePhone";
		public const string _EMail = "EMail";
		public const string _DwellingPlace = "DwellingPlace";
		public const string _Nullity = "Nullity";
		public const string _AgentNote = "AgentNote";
		public const string _CollectDate = "CollectDate";
		private int m_agentID;
		private int m_userID;
		private string m_compellation;
		private string m_domain;
		private int m_agentType;
		private decimal m_agentScale;
		private long m_payBackScore;
		private decimal m_payBackScale;
		private string m_mobilePhone;
		private string m_eMail;
		private string m_dwellingPlace;
		private byte m_nullity;
		private string m_agentNote;
		private DateTime m_collectDate;
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
		public string Domain
		{
			get
			{
				return this.m_domain;
			}
			set
			{
				this.m_domain = value;
			}
		}
		public int AgentType
		{
			get
			{
				return this.m_agentType;
			}
			set
			{
				this.m_agentType = value;
			}
		}
		public decimal AgentScale
		{
			get
			{
				return this.m_agentScale;
			}
			set
			{
				this.m_agentScale = value;
			}
		}
		public long PayBackScore
		{
			get
			{
				return this.m_payBackScore;
			}
			set
			{
				this.m_payBackScore = value;
			}
		}
		public decimal PayBackScale
		{
			get
			{
				return this.m_payBackScale;
			}
			set
			{
				this.m_payBackScale = value;
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
		public string AgentNote
		{
			get
			{
				return this.m_agentNote;
			}
			set
			{
				this.m_agentNote = value;
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
		public AccountsAgent()
		{
			this.m_agentID = 0;
			this.m_userID = 0;
			this.m_compellation = "";
			this.m_domain = "";
			this.m_agentType = 0;
			this.m_agentScale = 0m;
			this.m_payBackScore = 0L;
			this.m_payBackScale = 0m;
			this.m_mobilePhone = "";
			this.m_eMail = "";
			this.m_dwellingPlace = "";
			this.m_nullity = 0;
			this.m_agentNote = "";
			this.m_collectDate = DateTime.Now;
		}
	}
}
