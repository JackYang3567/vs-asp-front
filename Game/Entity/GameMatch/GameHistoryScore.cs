using System;
namespace Game.Entity.GameMatch
{
	[Serializable]
	public class GameHistoryScore
	{
		public const string Tablename = "GameHistoryScore";
		public const string _MatchID = "MatchID";
		public const string _MatchNo = "MatchNo";
		public const string _UserID = "UserID";
		public const string _HScore = "HScore";
		public const string _HWinCount = "HWinCount";
		public const string _HLostCount = "HLostCount";
		public const string _HDrawCount = "HDrawCount";
		public const string _HFleeCount = "HFleeCount";
		public const string _HBackupTime = "HBackupTime";
		public const string _NScore = "NScore";
		public const string _NWinCount = "NWinCount";
		public const string _NLostCount = "NLostCount";
		public const string _NDrawCount = "NDrawCount";
		public const string _NFleeCount = "NFleeCount";
		public const string _NBackupTime = "NBackupTime";
		private int m_matchID;
		private int m_matchNo;
		private int m_userID;
		private long m_hScore;
		private int m_hWinCount;
		private int m_hLostCount;
		private int m_hDrawCount;
		private int m_hFleeCount;
		private DateTime m_hBackupTime;
		private long m_nScore;
		private int m_nWinCount;
		private int m_nLostCount;
		private int m_nDrawCount;
		private int m_nFleeCount;
		private DateTime m_nBackupTime;
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
		public int MatchNo
		{
			get
			{
				return this.m_matchNo;
			}
			set
			{
				this.m_matchNo = value;
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
		public long HScore
		{
			get
			{
				return this.m_hScore;
			}
			set
			{
				this.m_hScore = value;
			}
		}
		public int HWinCount
		{
			get
			{
				return this.m_hWinCount;
			}
			set
			{
				this.m_hWinCount = value;
			}
		}
		public int HLostCount
		{
			get
			{
				return this.m_hLostCount;
			}
			set
			{
				this.m_hLostCount = value;
			}
		}
		public int HDrawCount
		{
			get
			{
				return this.m_hDrawCount;
			}
			set
			{
				this.m_hDrawCount = value;
			}
		}
		public int HFleeCount
		{
			get
			{
				return this.m_hFleeCount;
			}
			set
			{
				this.m_hFleeCount = value;
			}
		}
		public DateTime HBackupTime
		{
			get
			{
				return this.m_hBackupTime;
			}
			set
			{
				this.m_hBackupTime = value;
			}
		}
		public long NScore
		{
			get
			{
				return this.m_nScore;
			}
			set
			{
				this.m_nScore = value;
			}
		}
		public int NWinCount
		{
			get
			{
				return this.m_nWinCount;
			}
			set
			{
				this.m_nWinCount = value;
			}
		}
		public int NLostCount
		{
			get
			{
				return this.m_nLostCount;
			}
			set
			{
				this.m_nLostCount = value;
			}
		}
		public int NDrawCount
		{
			get
			{
				return this.m_nDrawCount;
			}
			set
			{
				this.m_nDrawCount = value;
			}
		}
		public int NFleeCount
		{
			get
			{
				return this.m_nFleeCount;
			}
			set
			{
				this.m_nFleeCount = value;
			}
		}
		public DateTime NBackupTime
		{
			get
			{
				return this.m_nBackupTime;
			}
			set
			{
				this.m_nBackupTime = value;
			}
		}
		public GameHistoryScore()
		{
			this.m_matchID = 0;
			this.m_matchNo = 0;
			this.m_userID = 0;
			this.m_hScore = 0L;
			this.m_hWinCount = 0;
			this.m_hLostCount = 0;
			this.m_hDrawCount = 0;
			this.m_hFleeCount = 0;
			this.m_hBackupTime = DateTime.Now;
			this.m_nScore = 0L;
			this.m_nWinCount = 0;
			this.m_nLostCount = 0;
			this.m_nDrawCount = 0;
			this.m_nFleeCount = 0;
			this.m_nBackupTime = DateTime.Now;
		}
	}
}
