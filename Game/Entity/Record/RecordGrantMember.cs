using System;
namespace Game.Entity.Record
{
	[Serializable]
	public class RecordGrantMember
	{
		public const string Tablename = "RecordGrantMember";
		public const string _RecordID = "RecordID";
		public const string _MasterID = "MasterID";
		public const string _ClientIP = "ClientIP";
		public const string _CollectDate = "CollectDate";
		public const string _UserID = "UserID";
		public const string _GrantCardType = "GrantCardType";
		public const string _Reason = "Reason";
		public const string _MemberDays = "MemberDays";
		private int m_recordID;
		private int m_masterID;
		private string m_clientIP;
		private DateTime m_collectDate;
		private int m_userID;
		private int m_grantCardType;
		private string m_reason;
		private int m_memberDays;
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
		public int GrantCardType
		{
			get
			{
				return this.m_grantCardType;
			}
			set
			{
				this.m_grantCardType = value;
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
		public int MemberDays
		{
			get
			{
				return this.m_memberDays;
			}
			set
			{
				this.m_memberDays = value;
			}
		}
		public RecordGrantMember()
		{
			this.m_recordID = 0;
			this.m_masterID = 0;
			this.m_clientIP = "";
			this.m_collectDate = DateTime.Now;
			this.m_userID = 0;
			this.m_grantCardType = 0;
			this.m_reason = "";
			this.m_memberDays = 0;
		}
	}
}
