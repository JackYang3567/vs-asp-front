using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class RecordAgentInfo
	{
		public const string Tablename = "RecordAgentInfo";
		public const string _RecordID = "RecordID";
		public const string _DateID = "DateID";
		public const string _UserID = "UserID";
		public const string _AgentScale = "AgentScale";
		public const string _PayBackScale = "PayBackScale";
		public const string _TypeID = "TypeID";
		public const string _PayScore = "PayScore";
		public const string _Score = "Score";
		public const string _ChildrenID = "ChildrenID";
		public const string _InsureScore = "InsureScore";
		public const string _CollectDate = "CollectDate";
		public const string _CollectIP = "CollectIP";
		public const string _CollectNote = "CollectNote";
		private int m_recordID;
		private int m_userID;
		private int m_dateID;
		private decimal m_agentScale;
		private decimal m_payBackScale;
		private int m_typeID;
		private long m_payScore;
		private long m_score;
		private int m_childrenID;
		private string m_insureScore;
		private DateTime m_collectDate;
		private string m_collectIP;
		private string m_collectNote;
		public int RecordID
		{
			get
			{
				return this.m_recordID;
			}
			set
			{
				this.m_recordID = value;
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
		public int DateID
		{
			get
			{
				return this.m_dateID;
			}
			set
			{
				this.m_dateID = value;
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
		public int TypeID
		{
			get
			{
				return this.m_typeID;
			}
			set
			{
				this.m_typeID = value;
			}
		}
		public long PayScore
		{
			get
			{
				return this.m_payScore;
			}
			set
			{
				this.m_payScore = value;
			}
		}
		public long Score
		{
			get
			{
				return this.m_score;
			}
			set
			{
				this.m_score = value;
			}
		}
		public int ChildrenID
		{
			get
			{
				return this.m_childrenID;
			}
			set
			{
				this.m_childrenID = value;
			}
		}
		public string InsureScore
		{
			get
			{
				return this.m_insureScore;
			}
			set
			{
				this.m_insureScore = value;
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
		public string CollectIP
		{
			get
			{
				return this.m_collectIP;
			}
			set
			{
				this.m_collectIP = value;
			}
		}
		public string CollectNote
		{
			get
			{
				return this.m_collectNote;
			}
			set
			{
				this.m_collectNote = value;
			}
		}
		public RecordAgentInfo()
		{
			this.m_recordID = 0;
			this.m_userID = 0;
			this.m_dateID = 0;
			this.m_agentScale = 0m;
			this.m_payBackScale = 0m;
			this.m_typeID = 0;
			this.m_payScore = 0L;
			this.m_score = 0L;
			this.m_childrenID = 0;
			this.m_insureScore = "";
			this.m_collectDate = DateTime.Now;
			this.m_collectIP = "";
			this.m_collectNote = "";
		}
	}
}
