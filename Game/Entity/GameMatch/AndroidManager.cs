using System;
namespace Game.Entity.GameMatch
{
	[Serializable]
	public class AndroidManager
	{
		public const string Tablename = "AndroidManager";
		public const string _UserID = "UserID";
		public const string _ServerID = "ServerID";
		public const string _MinPlayDraw = "MinPlayDraw";
		public const string _MaxPlayDraw = "MaxPlayDraw";
		public const string _MinTakeScore = "MinTakeScore";
		public const string _MaxTakeScore = "MaxTakeScore";
		public const string _MinReposeTime = "MinReposeTime";
		public const string _MaxReposeTime = "MaxReposeTime";
		public const string _ServiceTime = "ServiceTime";
		public const string _ServiceGender = "ServiceGender";
		public const string _Nullity = "Nullity";
		public const string _CreateDate = "CreateDate";
		public const string _AndroidNote = "AndroidNote";
		private int m_userID;
		private int m_serverID;
		private int m_minPlayDraw;
		private int m_maxPlayDraw;
		private long m_minTakeScore;
		private long m_maxTakeScore;
		private int m_minReposeTime;
		private int m_maxReposeTime;
		private int m_serviceTime;
		private int m_serviceGender;
		private byte m_nullity;
		private DateTime m_createDate;
		private string m_androidNote;
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
		public int MinPlayDraw
		{
			get
			{
				return this.m_minPlayDraw;
			}
			set
			{
				this.m_minPlayDraw = value;
			}
		}
		public int MaxPlayDraw
		{
			get
			{
				return this.m_maxPlayDraw;
			}
			set
			{
				this.m_maxPlayDraw = value;
			}
		}
		public long MinTakeScore
		{
			get
			{
				return this.m_minTakeScore;
			}
			set
			{
				this.m_minTakeScore = value;
			}
		}
		public long MaxTakeScore
		{
			get
			{
				return this.m_maxTakeScore;
			}
			set
			{
				this.m_maxTakeScore = value;
			}
		}
		public int MinReposeTime
		{
			get
			{
				return this.m_minReposeTime;
			}
			set
			{
				this.m_minReposeTime = value;
			}
		}
		public int MaxReposeTime
		{
			get
			{
				return this.m_maxReposeTime;
			}
			set
			{
				this.m_maxReposeTime = value;
			}
		}
		public int ServiceTime
		{
			get
			{
				return this.m_serviceTime;
			}
			set
			{
				this.m_serviceTime = value;
			}
		}
		public int ServiceGender
		{
			get
			{
				return this.m_serviceGender;
			}
			set
			{
				this.m_serviceGender = value;
			}
		}
		public byte Nullity
		{
			get
			{
				return this.m_nullity;
			}
			set
			{
				this.m_nullity = value;
			}
		}
		public DateTime CreateDate
		{
			get
			{
				return this.m_createDate;
			}
			set
			{
				this.m_createDate = value;
			}
		}
		public string AndroidNote
		{
			get
			{
				return this.m_androidNote;
			}
			set
			{
				this.m_androidNote = value;
			}
		}
		public AndroidManager()
		{
			this.m_userID = 0;
			this.m_serverID = 0;
			this.m_minPlayDraw = 0;
			this.m_maxPlayDraw = 0;
			this.m_minTakeScore = 0L;
			this.m_maxTakeScore = 0L;
			this.m_minReposeTime = 0;
			this.m_maxReposeTime = 0;
			this.m_serviceTime = 0;
			this.m_serviceGender = 0;
			this.m_nullity = 0;
			this.m_createDate = DateTime.Now;
			this.m_androidNote = "";
		}
	}
}
