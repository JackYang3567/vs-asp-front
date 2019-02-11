using System;
namespace Game.Entity.Record
{
	[Serializable]
	public class RecordInsure
	{
		public const string Tablename = "RecordInsure";
		public const string _RecordID = "RecordID";
		public const string _KindID = "KindID";
		public const string _ServerID = "ServerID";
		public const string _SourceUserID = "SourceUserID";
		public const string _SourceGold = "SourceGold";
		public const string _SourceBank = "SourceBank";
		public const string _TargetUserID = "TargetUserID";
		public const string _TargetGold = "TargetGold";
		public const string _TargetBank = "TargetBank";
		public const string _SwapScore = "SwapScore";
		public const string _Revenue = "Revenue";
		public const string _IsGamePlaza = "IsGamePlaza";
		public const string _TradeType = "TradeType";
		public const string _ClientIP = "ClientIP";
		public const string _CollectDate = "CollectDate";
		public const string _CollectNote = "CollectNote";
		private int m_recordID;
		private int m_kindID;
		private int m_serverID;
		private int m_sourceUserID;
		private long m_sourceGold;
		private long m_sourceBank;
		private int m_targetUserID;
		private long m_targetGold;
		private long m_targetBank;
		private long m_swapScore;
		private long m_revenue;
		private byte m_isGamePlaza;
		private byte m_tradeType;
		private string m_clientIP;
		private DateTime m_collectDate;
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
		public int KindID
		{
			get
			{
				return this.m_kindID;
			}
			set
			{
				this.m_kindID = value;
			}
		}
		public int ServerID
		{
			get
			{
				return this.m_serverID;
			}
			set
			{
				this.m_serverID = value;
			}
		}
		public int SourceUserID
		{
			get
			{
				return this.m_sourceUserID;
			}
			set
			{
				this.m_sourceUserID = value;
			}
		}
		public long SourceGold
		{
			get
			{
				return this.m_sourceGold;
			}
			set
			{
				this.m_sourceGold = value;
			}
		}
		public long SourceBank
		{
			get
			{
				return this.m_sourceBank;
			}
			set
			{
				this.m_sourceBank = value;
			}
		}
		public int TargetUserID
		{
			get
			{
				return this.m_targetUserID;
			}
			set
			{
				this.m_targetUserID = value;
			}
		}
		public long TargetGold
		{
			get
			{
				return this.m_targetGold;
			}
			set
			{
				this.m_targetGold = value;
			}
		}
		public long TargetBank
		{
			get
			{
				return this.m_targetBank;
			}
			set
			{
				this.m_targetBank = value;
			}
		}
		public long SwapScore
		{
			get
			{
				return this.m_swapScore;
			}
			set
			{
				this.m_swapScore = value;
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
		public byte IsGamePlaza
		{
			get
			{
				return this.m_isGamePlaza;
			}
			set
			{
				this.m_isGamePlaza = value;
			}
		}
		public byte TradeType
		{
			get
			{
				return this.m_tradeType;
			}
			set
			{
				this.m_tradeType = value;
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
		public RecordInsure()
		{
			this.m_recordID = 0;
			this.m_kindID = 0;
			this.m_serverID = 0;
			this.m_sourceUserID = 0;
			this.m_sourceGold = 0L;
			this.m_sourceBank = 0L;
			this.m_targetUserID = 0;
			this.m_targetGold = 0L;
			this.m_targetBank = 0L;
			this.m_swapScore = 0L;
			this.m_revenue = 0L;
			this.m_isGamePlaza = 0;
			this.m_tradeType = 0;
			this.m_clientIP = "";
			this.m_collectDate = DateTime.Now;
			this.m_collectNote = "";
		}
	}
}
