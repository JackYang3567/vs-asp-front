using System;
namespace Game.Entity.Record
{
	[Serializable]
	public class RecordGrantGameID
	{
		public const string Tablename = "RecordGrantGameID";
		public const string _RecordID = "RecordID";
		public const string _MasterID = "MasterID";
		public const string _UserID = "UserID";
		public const string _CurGameID = "CurGameID";
		public const string _ReGameID = "ReGameID";
		public const string _IDLevel = "IDLevel";
		public const string _ClientIP = "ClientIP";
		public const string _CollectDate = "CollectDate";
		public const string _Reason = "Reason";
		private int m_recordID;
		private int m_masterID;
		private int m_userID;
		private int m_curGameID;
		private int m_reGameID;
		private int m_iDLevel;
		private string m_clientIP;
		private DateTime m_collectDate;
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
		public int CurGameID
		{
			get
			{
				return this.m_curGameID;
			}
			set
			{
				this.m_curGameID = value;
			}
		}
		public int ReGameID
		{
			get
			{
				return this.m_reGameID;
			}
			set
			{
				this.m_reGameID = value;
			}
		}
		public int IDLevel
		{
			get
			{
				return this.m_iDLevel;
			}
			set
			{
				this.m_iDLevel = value;
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
		public RecordGrantGameID()
		{
			this.m_recordID = 0;
			this.m_masterID = 0;
			this.m_userID = 0;
			this.m_curGameID = 0;
			this.m_reGameID = 0;
			this.m_iDLevel = 0;
			this.m_clientIP = "";
			this.m_collectDate = DateTime.Now;
			this.m_reason = "";
		}
	}
}
