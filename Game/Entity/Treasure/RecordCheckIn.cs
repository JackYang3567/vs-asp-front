using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class RecordCheckIn
	{
		public const string Tablename = "RecordCheckIn";
		public const string _RecordID = "RecordID";
		public const string _UserID = "UserID";
		public const string _PresentGold = "PresentGold";
		public const string _PresentCount = "PresentCount";
		public const string _LxCount = "LxCount";
		public const string _LxGold = "LxGold";
		public const string _CollectDate = "CollectDate";
		private int m_recordID;
		private int m_userID;
		private int m_presentGold;
		private int m_presentCount;
		private int m_lxCount;
		private int m_lxGold;
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
		public int PresentGold
		{
			get
			{
				return this.m_presentGold;
			}
			set
			{
				this.m_presentGold = value;
			}
		}
		public int PresentCount
		{
			get
			{
				return this.m_presentCount;
			}
			set
			{
				this.m_presentCount = value;
			}
		}
		public int LxCount
		{
			get
			{
				return this.m_lxCount;
			}
			set
			{
				this.m_lxCount = value;
			}
		}
		public int LxGold
		{
			get
			{
				return this.m_lxGold;
			}
			set
			{
				this.m_lxGold = value;
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
		public RecordCheckIn()
		{
			this.m_recordID = 0;
			this.m_userID = 0;
			this.m_presentGold = 0;
			this.m_presentCount = 0;
			this.m_lxCount = 0;
			this.m_lxGold = 0;
			this.m_collectDate = DateTime.Now;
		}
	}
}
