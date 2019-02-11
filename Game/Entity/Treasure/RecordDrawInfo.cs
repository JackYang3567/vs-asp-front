using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class RecordDrawInfo
	{
		public const string Tablename = "RecordDrawInfo";
		public const string _DrawID = "DrawID";
		public const string _KindID = "KindID";
		public const string _ServerID = "ServerID";
		public const string _TableID = "TableID";
		public const string _UserCount = "UserCount";
		public const string _AndroidCount = "AndroidCount";
		public const string _Waste = "Waste";
		public const string _Revenue = "Revenue";
		public const string _UserMedal = "UserMedal";
		public const string _StartTime = "StartTime";
		public const string _ConcludeTime = "ConcludeTime";
		public const string _InsertTime = "InsertTime";
		public const string _DrawCourse = "DrawCourse";
		private int m_drawID;
		private int m_kindID;
		private int m_serverID;
		private int m_tableID;
		private int m_userCount;
		private int m_androidCount;
		private long m_waste;
		private long m_revenue;
		private int m_userMedal;
		private DateTime m_startTime;
		private DateTime m_concludeTime;
		private DateTime m_insertTime;
		private byte[] m_drawCourse;
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
		public int TableID
		{
			get
			{
				return this.m_tableID;
			}
			set
			{
				this.m_tableID = value;
			}
		}
		public int UserCount
		{
			get
			{
				return this.m_userCount;
			}
			set
			{
				this.m_userCount = value;
			}
		}
		public int AndroidCount
		{
			get
			{
				return this.m_androidCount;
			}
			set
			{
				this.m_androidCount = value;
			}
		}
		public long Waste
		{
			get
			{
				return this.m_waste;
			}
			set
			{
				this.m_waste = value;
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
		public DateTime ConcludeTime
		{
			get
			{
				return this.m_concludeTime;
			}
			set
			{
				this.m_concludeTime = value;
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
		public byte[] DrawCourse
		{
			get
			{
				return this.m_drawCourse;
			}
			set
			{
				this.m_drawCourse = value;
			}
		}
		public RecordDrawInfo()
		{
			this.m_drawID = 0;
			this.m_kindID = 0;
			this.m_serverID = 0;
			this.m_tableID = 0;
			this.m_userCount = 0;
			this.m_androidCount = 0;
			this.m_waste = 0L;
			this.m_revenue = 0L;
			this.m_userMedal = 0;
			this.m_startTime = DateTime.Now;
			this.m_concludeTime = DateTime.Now;
			this.m_insertTime = DateTime.Now;
			this.m_drawCourse = null;
		}
	}
}
