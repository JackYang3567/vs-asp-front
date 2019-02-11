using System;
namespace Game.Entity.Treasure
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
		private decimal m_sourceGold;
		private decimal m_sourceBank;
		private int m_targetUserID;
		private decimal m_targetGold;
		private decimal m_targetBank;
		private decimal m_swapScore;
		private decimal m_revenue;
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
		public decimal SourceGold
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
		public decimal SourceBank
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
		public decimal TargetGold
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
		public decimal TargetBank
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
		public decimal SwapScore
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
		public decimal Revenue
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
			this.m_sourceGold = 0m;
			this.m_sourceBank = 0m;
			this.m_targetUserID = 0;
			this.m_targetGold = 0m;
			this.m_targetBank = 0m;
			this.m_swapScore = 0m;
			this.m_revenue = 0m;
			this.m_isGamePlaza = 0;
			this.m_tradeType = 0;
			this.m_clientIP = "";
			this.m_collectDate = DateTime.Now;
			this.m_collectNote = "";
		}
	}
}
