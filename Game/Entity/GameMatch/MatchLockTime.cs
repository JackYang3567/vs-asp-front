using System;
namespace Game.Entity.GameMatch
{
	[Serializable]
	public class MatchLockTime
	{
		public const string Tablename = "MatchLockTime";
		public const string _MatchID = "MatchID";
		public const string _MatchNo = "MatchNo";
		public const string _StartTime = "StartTime";
		public const string _EndTime = "EndTime";
		public const string _InitScore = "InitScore";
		public const string _CullScore = "CullScore";
		public const string _MinPlayCount = "MinPlayCount";
		private int m_matchID;
		private short m_matchNo;
		private DateTime m_startTime;
		private DateTime m_endTime;
		private long m_initScore;
		private long m_cullScore;
		private int m_minPlayCount;
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
		public DateTime StartTime
		{
			get
			{
				return this.m_startTime;
			}
			set
			{
				this.m_startTime = value;
			}
		}
		public DateTime EndTime
		{
			get
			{
				return this.m_endTime;
			}
			set
			{
				this.m_endTime = value;
			}
		}
		public long InitScore
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
		public long CullScore
		{
			get
			{
				return this.m_cullScore;
			}
			set
			{
				this.m_cullScore = value;
			}
		}
		public int MinPlayCount
		{
			get
			{
				return this.m_minPlayCount;
			}
			set
			{
				this.m_minPlayCount = value;
			}
		}
		public MatchLockTime()
		{
			this.m_matchID = 0;
			this.m_matchNo = 0;
			this.m_startTime = DateTime.Now;
			this.m_endTime = DateTime.Now;
			this.m_initScore = 0L;
			this.m_cullScore = 0L;
			this.m_minPlayCount = 0;
		}
	}
}
