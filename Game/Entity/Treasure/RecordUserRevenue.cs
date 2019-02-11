using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class RecordUserRevenue
	{
		public const string Tablename = "RecordUserRevenue";
		public const string _RecordID = "RecordID";
		public const string _DateID = "DateID";
		public const string _UserID = "UserID";
		public const string _Revenue = "Revenue";
		public const string _AgentUserID = "AgentUserID";
		public const string _AgentScale = "AgentScale";
		public const string _AgentRevenue = "AgentRevenue";
		public const string _CompanyScale = "CompanyScale";
		public const string _CompanyRevenue = "CompanyRevenue";
		public const string _CollectDate = "CollectDate";
		private int m_recordID;
		private int m_dateID;
		private int m_userID;
		private long m_revenue;
		private int m_agentUserID;
		private decimal m_agentScale;
		private long m_agentRevenue;
		private decimal m_companyScale;
		private long m_companyRevenue;
		private DateTime m_collectDate;
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
		public long Revenue
		{
			get
			{
				return this.m_revenue;
			}
			set
			{
				this.m_revenue = value;
			}
		}
		public int AgentUserID
		{
			get
			{
				return this.m_agentUserID;
			}
			set
			{
				this.m_agentUserID = value;
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
		public long AgentRevenue
		{
			get
			{
				return this.m_agentRevenue;
			}
			set
			{
				this.m_agentRevenue = value;
			}
		}
		public decimal CompanyScale
		{
			get
			{
				return this.m_companyScale;
			}
			set
			{
				this.m_companyScale = value;
			}
		}
		public long CompanyRevenue
		{
			get
			{
				return this.m_companyRevenue;
			}
			set
			{
				this.m_companyRevenue = value;
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
		public RecordUserRevenue()
		{
			this.m_recordID = 0;
			this.m_dateID = 0;
			this.m_userID = 0;
			this.m_revenue = 0L;
			this.m_agentUserID = 0;
			this.m_agentScale = 0m;
			this.m_agentRevenue = 0L;
			this.m_companyScale = 0m;
			this.m_companyRevenue = 0L;
			this.m_collectDate = DateTime.Now;
		}
	}
}
