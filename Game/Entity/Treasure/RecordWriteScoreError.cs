using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class RecordWriteScoreError
	{
		public const string Tablename = "RecordWriteScoreError";
		public const string _RecordID = "RecordID";
		public const string _UserID = "UserID";
		public const string _KindID = "KindID";
		public const string _ServerID = "ServerID";
		public const string _UserScore = "UserScore";
		public const string _Score = "Score";
		public const string _CollectDate = "CollectDate";
		private int m_recordID;
		private int m_userID;
		private int m_kindID;
		private int m_serverID;
		private long m_userScore;
		private long m_score;
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
		public long UserScore
		{
			get
			{
				return this.m_userScore;
			}
			set
			{
				this.m_userScore = value;
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
		public RecordWriteScoreError()
		{
			this.m_recordID = 0;
			this.m_userID = 0;
			this.m_kindID = 0;
			this.m_serverID = 0;
			this.m_userScore = 0L;
			this.m_score = 0L;
			this.m_collectDate = DateTime.Now;
		}
	}
}
