using System;
namespace Game.Entity.Record
{
	[Serializable]
	public class RecordSendPresent
	{
		public const string Tablename = "RecordSendPresent";
		public const string _PresentID = "PresentID";
		public const string _RcvUserID = "RcvUserID";
		public const string _SendUserID = "SendUserID";
		public const string _LovelinessRcv = "LovelinessRcv";
		public const string _LovelinessSend = "LovelinessSend";
		public const string _PresentPrice = "PresentPrice";
		public const string _PresentCount = "PresentCount";
		public const string _KindID = "KindID";
		public const string _ServerID = "ServerID";
		public const string _SendTime = "SendTime";
		public const string _ClientIP = "ClientIP";
		private byte m_presentID;
		private int m_rcvUserID;
		private int m_sendUserID;
		private int m_lovelinessRcv;
		private int m_lovelinessSend;
		private int m_presentPrice;
		private int m_presentCount;
		private int m_kindID;
		private int m_serverID;
		private DateTime m_sendTime;
		private string m_clientIP;
		public byte PresentID
		{
			get
			{
				return this.m_presentID;
			}
			set
			{
				this.m_presentID = value;
			}
		}
		public int RcvUserID
		{
			get
			{
				return this.m_rcvUserID;
			}
			set
			{
				this.m_rcvUserID = value;
			}
		}
		public int SendUserID
		{
			get
			{
				return this.m_sendUserID;
			}
			set
			{
				this.m_sendUserID = value;
			}
		}
		public int LovelinessRcv
		{
			get
			{
				return this.m_lovelinessRcv;
			}
			set
			{
				this.m_lovelinessRcv = value;
			}
		}
		public int LovelinessSend
		{
			get
			{
				return this.m_lovelinessSend;
			}
			set
			{
				this.m_lovelinessSend = value;
			}
		}
		public int PresentPrice
		{
			get
			{
				return this.m_presentPrice;
			}
			set
			{
				this.m_presentPrice = value;
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
		public DateTime SendTime
		{
			get
			{
				return this.m_sendTime;
			}
			set
			{
				this.m_sendTime = value;
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
		public RecordSendPresent()
		{
			this.m_presentID = 0;
			this.m_rcvUserID = 0;
			this.m_sendUserID = 0;
			this.m_lovelinessRcv = 0;
			this.m_lovelinessSend = 0;
			this.m_presentPrice = 0;
			this.m_presentCount = 0;
			this.m_kindID = 0;
			this.m_serverID = 0;
			this.m_sendTime = DateTime.Now;
			this.m_clientIP = "";
		}
	}
}
