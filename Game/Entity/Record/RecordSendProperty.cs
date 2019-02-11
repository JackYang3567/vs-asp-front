using System;
namespace Game.Entity.Record
{
	[Serializable]
	public class RecordSendProperty
	{
		public const string Tablename = "RecordSendProperty";
		public const string _PropID = "PropID";
		public const string _SourceUserID = "SourceUserID";
		public const string _TargetUserID = "TargetUserID";
		public const string _PropPrice = "PropPrice";
		public const string _PropCount = "PropCount";
		public const string _KindID = "KindID";
		public const string _ServerID = "ServerID";
		public const string _SendTime = "SendTime";
		public const string _ClientIP = "ClientIP";
		private byte m_propID;
		private int m_sourceUserID;
		private int m_targetUserID;
		private int m_propPrice;
		private int m_propCount;
		private int m_kindID;
		private int m_serverID;
		private DateTime m_sendTime;
		private string m_clientIP;
		public byte PropID
		{
			get
			{
				return this.m_propID;
			}
			set
			{
				this.m_propID = value;
			}
		}
		public int SourceUserID
		{
			get
			{
				return this.m_sourceUserID;
			}
			set
			{
				this.m_sourceUserID = value;
			}
		}
		public int TargetUserID
		{
			get
			{
				return this.m_targetUserID;
			}
			set
			{
				this.m_targetUserID = value;
			}
		}
		public int PropPrice
		{
			get
			{
				return this.m_propPrice;
			}
			set
			{
				this.m_propPrice = value;
			}
		}
		public int PropCount
		{
			get
			{
				return this.m_propCount;
			}
			set
			{
				this.m_propCount = value;
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
		public RecordSendProperty()
		{
			this.m_propID = 0;
			this.m_sourceUserID = 0;
			this.m_targetUserID = 0;
			this.m_propPrice = 0;
			this.m_propCount = 0;
			this.m_kindID = 0;
			this.m_serverID = 0;
			this.m_sendTime = DateTime.Now;
			this.m_clientIP = "";
		}
	}
}
