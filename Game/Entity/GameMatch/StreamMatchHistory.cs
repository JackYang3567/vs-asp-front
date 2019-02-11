using System;
namespace Game.Entity.GameMatch
{
	[Serializable]
	public class StreamMatchHistory
	{
		public const string Tablename = "StreamMatchHistory";
		public const string _ID = "ID";
		public const string _UserID = "UserID";
		public const string _MatchID = "MatchID";
		public const string _MatchNo = "MatchNo";
		public const string _MatchType = "MatchType";
		public const string _ServerID = "ServerID";
		public const string _RankID = "RankID";
		public const string _MatchScore = "MatchScore";
		public const string _UserRight = "UserRight";
		public const string _RewardGold = "RewardGold";
		public const string _RewardIngot = "RewardIngot";
		public const string _RewardExperience = "RewardExperience";
		public const string _WinCount = "WinCount";
		public const string _LostCount = "LostCount";
		public const string _DrawCount = "DrawCount";
		public const string _FleeCount = "FleeCount";
		public const string _MatchStartTime = "MatchStartTime";
		public const string _MatchEndTime = "MatchEndTime";
		public const string _PlayTimeCount = "PlayTimeCount";
		public const string _OnlineTime = "OnlineTime";
		public const string _Machine = "Machine";
		public const string _ClientIP = "ClientIP";
		public const string _RecordDate = "RecordDate";
		private int m_iD;
		private int m_userID;
		private int m_matchID;
		private long m_matchNo;
		private byte m_matchType;
		private int m_serverID;
		private short m_rankID;
		private int m_matchScore;
		private int m_userRight;
		private long m_rewardGold;
		private long m_rewardIngot;
		private long m_rewardExperience;
		private int m_winCount;
		private int m_lostCount;
		private int m_drawCount;
		private int m_fleeCount;
		private DateTime m_matchStartTime;
		private DateTime m_matchEndTime;
		private int m_playTimeCount;
		private int m_onlineTime;
		private string m_machine;
		private string m_clientIP;
		private DateTime m_recordDate;
		public int ID
		{
			get
			{
				return this.m_iD;
			}
			set
			{
				this.m_iD = value;
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
		public long MatchNo
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
		public byte MatchType
		{
			get
			{
				return this.m_matchType;
			}
			set
			{
				this.m_matchType = value;
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
		public short RankID
		{
			get
			{
				return this.m_rankID;
			}
			set
			{
				this.m_rankID = value;
			}
		}
		public int MatchScore
		{
			get
			{
				return this.m_matchScore;
			}
			set
			{
				this.m_matchScore = value;
			}
		}
		public int UserRight
		{
			get
			{
				return this.m_userRight;
			}
			set
			{
				this.m_userRight = value;
			}
		}
		public long RewardGold
		{
			get
			{
				return this.m_rewardGold;
			}
			set
			{
				this.m_rewardGold = value;
			}
		}
		public long RewardIngot
		{
			get
			{
				return this.m_rewardIngot;
			}
			set
			{
				this.m_rewardIngot = value;
			}
		}
		public long RewardExperience
		{
			get
			{
				return this.m_rewardExperience;
			}
			set
			{
				this.m_rewardExperience = value;
			}
		}
		public int WinCount
		{
			get
			{
				return this.m_winCount;
			}
			set
			{
				this.m_winCount = value;
			}
		}
		public int LostCount
		{
			get
			{
				return this.m_lostCount;
			}
			set
			{
				this.m_lostCount = value;
			}
		}
		public int DrawCount
		{
			get
			{
				return this.m_drawCount;
			}
			set
			{
				this.m_drawCount = value;
			}
		}
		public int FleeCount
		{
			get
			{
				return this.m_fleeCount;
			}
			set
			{
				this.m_fleeCount = value;
			}
		}
		public DateTime MatchStartTime
		{
			get
			{
				return this.m_matchStartTime;
			}
			set
			{
				this.m_matchStartTime = value;
			}
		}
		public DateTime MatchEndTime
		{
			get
			{
				return this.m_matchEndTime;
			}
			set
			{
				this.m_matchEndTime = value;
			}
		}
		public int PlayTimeCount
		{
			get
			{
				return this.m_playTimeCount;
			}
			set
			{
				this.m_playTimeCount = value;
			}
		}
		public int OnlineTime
		{
			get
			{
				return this.m_onlineTime;
			}
			set
			{
				this.m_onlineTime = value;
			}
		}
		public string Machine
		{
			get
			{
				return this.m_machine;
			}
			set
			{
				this.m_machine = value;
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
		public DateTime RecordDate
		{
			get
			{
				return this.m_recordDate;
			}
			set
			{
				this.m_recordDate = value;
			}
		}
		public StreamMatchHistory()
		{
			this.m_iD = 0;
			this.m_userID = 0;
			this.m_matchID = 0;
			this.m_matchNo = 0L;
			this.m_matchType = 0;
			this.m_serverID = 0;
			this.m_rankID = 0;
			this.m_matchScore = 0;
			this.m_userRight = 0;
			this.m_rewardGold = 0L;
			this.m_rewardIngot = 0L;
			this.m_rewardExperience = 0L;
			this.m_winCount = 0;
			this.m_lostCount = 0;
			this.m_drawCount = 0;
			this.m_fleeCount = 0;
			this.m_matchStartTime = DateTime.Now;
			this.m_matchEndTime = DateTime.Now;
			this.m_playTimeCount = 0;
			this.m_onlineTime = 0;
			this.m_machine = "";
			this.m_clientIP = "";
			this.m_recordDate = DateTime.Now;
		}
	}
}
