using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class RecordSpreadInfo
	{
		public const string Tablename = "RecordSpreadInfo";
		public const string _RecordID = "RecordID";
		public const string _UserID = "UserID";
		public const string _Score = "Score";
		public const string _TypeID = "TypeID";
		public const string _ChildrenID = "ChildrenID";
		public const string _InsureScore = "InsureScore";
		public const string _CollectDate = "CollectDate";
		public const string _CollectNote = "CollectNote";
		private int m_recordID;
		private int m_userID;
		private long m_score;
		private int m_typeID;
		private int m_childrenID;
		private long m_insureScore;
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
		public long InsureScore
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
		public RecordSpreadInfo()
		{
			this.m_recordID = 0;
			this.m_userID = 0;
			this.m_score = 0L;
			this.m_typeID = 0;
			this.m_childrenID = 0;
			this.m_insureScore = 0L;
			this.m_collectDate = DateTime.Now;
			this.m_collectNote = "";
		}
	}
}
