using System;
namespace Game.Entity.Record
{
	[Serializable]
	public class RecordPasswdExpend
	{
		public const string Tablename = "RecordPasswdExpend";
		public const string _RecordID = "RecordID";
		public const string _OperMasterID = "OperMasterID";
		public const string _UserID = "UserID";
		public const string _ReLogonPasswd = "ReLogonPasswd";
		public const string _ReInsurePasswd = "ReInsurePasswd";
		public const string _ClientIP = "ClientIP";
		public const string _CollectDate = "CollectDate";
		private int m_recordID;
		private int m_operMasterID;
		private int m_userID;
		private string m_reLogonPasswd;
		private string m_reInsurePasswd;
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
		public string ReLogonPasswd
		{
			get
			{
				return this.m_reLogonPasswd;
			}
			set
			{
				this.m_reLogonPasswd = value;
			}
		}
		public string ReInsurePasswd
		{
			get
			{
				return this.m_reInsurePasswd;
			}
			set
			{
				this.m_reInsurePasswd = value;
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
		public RecordPasswdExpend()
		{
			this.m_recordID = 0;
			this.m_operMasterID = 0;
			this.m_userID = 0;
			this.m_reLogonPasswd = "";
			this.m_reInsurePasswd = "";
			this.m_clientIP = "";
			this.m_collectDate = DateTime.Now;
		}
	}
}
