using System;
namespace Game.Entity.Record
{
	[Serializable]
	public class RecordConvertPresent
	{
		public const string Tablename = "RecordConvertPresent";
		public const string _RecordID = "RecordID";
		public const string _UserID = "UserID";
		public const string _KindID = "KindID";
		public const string _ServerID = "ServerID";
		public const string _CurInsureScore = "CurInsureScore";
		public const string _CurPresent = "CurPresent";
		public const string _ConvertPresent = "ConvertPresent";
		public const string _ConvertRate = "ConvertRate";
		public const string _IsGamePlaza = "IsGamePlaza";
		public const string _ClientIP = "ClientIP";
		public const string _CollectDate = "CollectDate";
		private int m_recordID;
		private int m_userID;
		private int m_kindID;
		private int m_serverID;
		private long m_curInsureScore;
		private int m_curPresent;
		private int m_convertPresent;
		private int m_convertRate;
		private byte m_isGamePlaza;
		private string m_clientIP;
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
		public long CurInsureScore
		{
			get
			{
				return this.m_curInsureScore;
			}
			set
			{
				this.m_curInsureScore = value;
			}
		}
		public int CurPresent
		{
			get
			{
				return this.m_curPresent;
			}
			set
			{
				this.m_curPresent = value;
			}
		}
		public int ConvertPresent
		{
			get
			{
				return this.m_convertPresent;
			}
			set
			{
				this.m_convertPresent = value;
			}
		}
		public int ConvertRate
		{
			get
			{
				return this.m_convertRate;
			}
			set
			{
				this.m_convertRate = value;
			}
		}
		public byte IsGamePlaza
		{
			get
			{
				return this.m_isGamePlaza;
			}
			set
			{
				this.m_isGamePlaza = value;
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
		public RecordConvertPresent()
		{
			this.m_recordID = 0;
			this.m_userID = 0;
			this.m_kindID = 0;
			this.m_serverID = 0;
			this.m_curInsureScore = 0L;
			this.m_curPresent = 0;
			this.m_convertPresent = 0;
			this.m_convertRate = 0;
			this.m_isGamePlaza = 0;
			this.m_clientIP = "";
			this.m_collectDate = DateTime.Now;
		}
	}
}
