using System;
namespace Game.Entity.GameMatch
{
	[Serializable]
	public class SystemStreamInfo
	{
		public const string Tablename = "SystemStreamInfo";
		public const string _DateID = "DateID";
		public const string _KindID = "KindID";
		public const string _ServerID = "ServerID";
		public const string _LogonCount = "LogonCount";
		public const string _RegisterCount = "RegisterCount";
		public const string _CollectDate = "CollectDate";
		private int m_dateID;
		private int m_kindID;
		private int m_serverID;
		private int m_logonCount;
		private int m_registerCount;
		private DateTime m_collectDate;
		public int DateID
		{
			get
			{
				return this.m_dateID;
			}
			set
			{
				this.m_dateID = value;
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
		public int LogonCount
		{
			get
			{
				return this.m_logonCount;
			}
			set
			{
				this.m_logonCount = value;
			}
		}
		public int RegisterCount
		{
			get
			{
				return this.m_registerCount;
			}
			set
			{
				this.m_registerCount = value;
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
		public SystemStreamInfo()
		{
			this.m_dateID = 0;
			this.m_kindID = 0;
			this.m_serverID = 0;
			this.m_logonCount = 0;
			this.m_registerCount = 0;
			this.m_collectDate = DateTime.Now;
		}
	}
}
