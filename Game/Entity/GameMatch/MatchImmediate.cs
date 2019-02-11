using System;
namespace Game.Entity.GameMatch
{
	[Serializable]
	public class MatchImmediate
	{
		public const string Tablename = "MatchImmediate";
		public const string _MatchID = "MatchID";
		public const string _MatchNo = "MatchNo";
		public const string _StartUserCount = "StartUserCount";
		public const string _AndroidUserCount = "AndroidUserCount";
		public const string _InitBase = "InitBase";
		public const string _InitScore = "InitScore";
		public const string _MinEnterGold = "MinEnterGold";
		public const string _PlayCount = "PlayCount";
		public const string _SwitchTableCount = "SwitchTableCount";
		public const string _PrecedeTimer = "PrecedeTimer";
		private int m_matchID;
		private short m_matchNo;
		private int m_startUserCount;
		private int m_androidUserCount;
		private int m_initBase;
		private int m_initScore;
		private int m_minEnterGold;
		private byte m_playCount;
		private byte m_switchTableCount;
		private int m_precedeTimer;
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
		public short MatchNo
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
		public int StartUserCount
		{
			get
			{
				return this.m_startUserCount;
			}
			set
			{
				this.m_startUserCount = value;
			}
		}
		public int AndroidUserCount
		{
			get
			{
				return this.m_androidUserCount;
			}
			set
			{
				this.m_androidUserCount = value;
			}
		}
		public int InitBase
		{
			get
			{
				return this.m_initBase;
			}
			set
			{
				this.m_initBase = value;
			}
		}
		public int InitScore
		{
			get
			{
				return this.m_initScore;
			}
			set
			{
				this.m_initScore = value;
			}
		}
		public int MinEnterGold
		{
			get
			{
				return this.m_minEnterGold;
			}
			set
			{
				this.m_minEnterGold = value;
			}
		}
		public byte PlayCount
		{
			get
			{
				return this.m_playCount;
			}
			set
			{
				this.m_playCount = value;
			}
		}
		public byte SwitchTableCount
		{
			get
			{
				return this.m_switchTableCount;
			}
			set
			{
				this.m_switchTableCount = value;
			}
		}
		public int PrecedeTimer
		{
			get
			{
				return this.m_precedeTimer;
			}
			set
			{
				this.m_precedeTimer = value;
			}
		}
		public MatchImmediate()
		{
			this.m_matchID = 0;
			this.m_matchNo = 0;
			this.m_startUserCount = 0;
			this.m_androidUserCount = 0;
			this.m_initBase = 0;
			this.m_initScore = 0;
			this.m_minEnterGold = 0;
			this.m_playCount = 0;
			this.m_switchTableCount = 0;
			this.m_precedeTimer = 0;
		}
	}
}
