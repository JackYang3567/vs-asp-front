using System;
namespace Game.Entity.GameMatch
{
	[Serializable]
	public class RecordDrawScore
	{
		public const string Tablename = "RecordDrawScore";
		public const string _DrawID = "DrawID";
		public const string _UserID = "UserID";
		public const string _ChairID = "ChairID";
		public const string _Score = "Score";
		public const string _Grade = "Grade";
		public const string _Revenue = "Revenue";
		public const string _UserMedal = "UserMedal";
		public const string _PlayTimeCount = "PlayTimeCount";
		public const string _InsertTime = "InsertTime";
		private int m_drawID;
		private int m_userID;
		private int m_chairID;
		private long m_score;
		private long m_grade;
		private long m_revenue;
		private int m_userMedal;
		private int m_playTimeCount;
		private DateTime m_insertTime;
		public int DrawID
		{
			get
			{
				return this.m_drawID;
			}
			set
			{
				this.m_drawID = value;
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
		public int ChairID
		{
			get
			{
				return this.m_chairID;
			}
			set
			{
				this.m_chairID = value;
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
		public long Grade
		{
			get
			{
				return this.m_grade;
			}
			set
			{
				this.m_grade = value;
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
		public int UserMedal
		{
			get
			{
				return this.m_userMedal;
			}
			set
			{
				this.m_userMedal = value;
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
		public DateTime InsertTime
		{
			get
			{
				return this.m_insertTime;
			}
			set
			{
				this.m_insertTime = value;
			}
		}
		public RecordDrawScore()
		{
			this.m_drawID = 0;
			this.m_userID = 0;
			this.m_chairID = 0;
			this.m_score = 0L;
			this.m_grade = 0L;
			this.m_revenue = 0L;
			this.m_userMedal = 0;
			this.m_playTimeCount = 0;
			this.m_insertTime = DateTime.Now;
		}
	}
}
