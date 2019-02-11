using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class RecordLogonError
	{
		public const string Tablename = "RecordLogonError";
		public const string _RecordID = "RecordID";
		public const string _UserID = "UserID";
		public const string _KindID = "KindID";
		public const string _ServerID = "ServerID";
		public const string _Score = "Score";
		public const string _InsureScore = "InsureScore";
		public const string _LogonIP = "LogonIP";
		public const string _LogonMachine = "LogonMachine";
		public const string _CollectDate = "CollectDate";
		private int m_recordID;
		private int m_userID;
		private int m_kindID;
		private int m_serverID;
		private long m_score;
		private long m_insureScore;
		private string m_logonIP;
		private string m_logonMachine;
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
		public long Score
		{
			get
			{
				return this.m_score;
			}
			set
			{
				this.m_score = value;
			}
		}
		public long InsureScore
		{
			get
			{
				return this.m_insureScore;
			}
			set
			{
				this.m_insureScore = value;
			}
		}
		public string LogonIP
		{
			get
			{
				return this.m_logonIP;
			}
			set
			{
				this.m_logonIP = value;
			}
		}
		public string LogonMachine
		{
			get
			{
				return this.m_logonMachine;
			}
			set
			{
				this.m_logonMachine = value;
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
		public RecordLogonError()
		{
			this.m_recordID = 0;
			this.m_userID = 0;
			this.m_kindID = 0;
			this.m_serverID = 0;
			this.m_score = 0L;
			this.m_insureScore = 0L;
			this.m_logonIP = "";
			this.m_logonMachine = "";
			this.m_collectDate = DateTime.Now;
		}
	}
}
