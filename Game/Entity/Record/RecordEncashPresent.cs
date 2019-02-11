using System;
namespace Game.Entity.Record
{
	[Serializable]
	public class RecordEncashPresent
	{
		public const string Tablename = "RecordEncashPresent";
		public const string _UserID = "UserID";
		public const string _CurGold = "CurGold";
		public const string _CurPresent = "CurPresent";
		public const string _EncashGold = "EncashGold";
		public const string _EncashPresent = "EncashPresent";
		public const string _KindID = "KindID";
		public const string _ServerID = "ServerID";
		public const string _ClientIP = "ClientIP";
		public const string _EncashTime = "EncashTime";
		private int m_userID;
		private long m_curGold;
		private int m_curPresent;
		private int m_encashGold;
		private int m_encashPresent;
		private int m_kindID;
		private int m_serverID;
		private string m_clientIP;
		private DateTime m_encashTime;
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
		public long CurGold
		{
			get
			{
				return this.m_curGold;
			}
			set
			{
				this.m_curGold = value;
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
		public int EncashGold
		{
			get
			{
				return this.m_encashGold;
			}
			set
			{
				this.m_encashGold = value;
			}
		}
		public int EncashPresent
		{
			get
			{
				return this.m_encashPresent;
			}
			set
			{
				this.m_encashPresent = value;
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
		public DateTime EncashTime
		{
			get
			{
				return this.m_encashTime;
			}
			set
			{
				this.m_encashTime = value;
			}
		}
		public RecordEncashPresent()
		{
			this.m_userID = 0;
			this.m_curGold = 0L;
			this.m_curPresent = 0;
			this.m_encashGold = 0;
			this.m_encashPresent = 0;
			this.m_kindID = 0;
			this.m_serverID = 0;
			this.m_clientIP = "";
			this.m_encashTime = DateTime.Now;
		}
	}
}
