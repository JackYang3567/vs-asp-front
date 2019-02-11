using System;
namespace Game.Entity.Record
{
	[Serializable]
	public class RecordAccountsExpend
	{
		public const string Tablename = "RecordAccountsExpend";
		public const string _RecordID = "RecordID";
		public const string _OperMasterID = "OperMasterID";
		public const string _UserID = "UserID";
		public const string _ReAccounts = "ReAccounts";
		public const string _ClientIP = "ClientIP";
		public const string _CollectDate = "CollectDate";
		private int m_recordID;
		private int m_operMasterID;
		private int m_userID;
		private string m_reAccounts;
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
		public int OperMasterID
		{
			get
			{
				return this.m_operMasterID;
			}
			set
			{
				this.m_operMasterID = value;
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
		public string ReAccounts
		{
			get
			{
				return this.m_reAccounts;
			}
			set
			{
				this.m_reAccounts = value;
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
		public RecordAccountsExpend()
		{
			this.m_recordID = 0;
			this.m_operMasterID = 0;
			this.m_userID = 0;
			this.m_reAccounts = "";
			this.m_clientIP = "";
			this.m_collectDate = DateTime.Now;
		}
	}
}
