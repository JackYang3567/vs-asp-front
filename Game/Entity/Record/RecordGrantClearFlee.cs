using System;
namespace Game.Entity.Record
{
	[Serializable]
	public class RecordGrantClearFlee
	{
		public const string Tablename = "RecordGrantClearFlee";
		public const string _RecordID = "RecordID";
		public const string _MasterID = "MasterID";
		public const string _ClientIP = "ClientIP";
		public const string _CollectDate = "CollectDate";
		public const string _UserID = "UserID";
		public const string _KindID = "KindID";
		public const string _CurFlee = "CurFlee";
		public const string _Reason = "Reason";
		private int m_recordID;
		private int m_masterID;
		private string m_clientIP;
		private DateTime m_collectDate;
		private int m_userID;
		private int m_kindID;
		private int m_curFlee;
		private string m_reason;
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
		public int MasterID
		{
			get
			{
				return this.m_masterID;
			}
			set
			{
				this.m_masterID = value;
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
		public int CurFlee
		{
			get
			{
				return this.m_curFlee;
			}
			set
			{
				this.m_curFlee = value;
			}
		}
		public string Reason
		{
			get
			{
				return this.m_reason;
			}
			set
			{
				this.m_reason = value;
			}
		}
		public RecordGrantClearFlee()
		{
			this.m_recordID = 0;
			this.m_masterID = 0;
			this.m_clientIP = "";
			this.m_collectDate = DateTime.Now;
			this.m_userID = 0;
			this.m_kindID = 0;
			this.m_curFlee = 0;
			this.m_reason = "";
		}
	}
}
