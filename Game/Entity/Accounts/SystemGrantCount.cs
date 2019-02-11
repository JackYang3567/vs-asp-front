using System;
namespace Game.Entity.Accounts
{
	[Serializable]
	public class SystemGrantCount
	{
		public const string Tablename = "SystemGrantCount";
		public const string _DateID = "DateID";
		public const string _RegisterIP = "RegisterIP";
		public const string _RegisterMachine = "RegisterMachine";
		public const string _GrantScore = "GrantScore";
		public const string _GrantCount = "GrantCount";
		public const string _CollectDate = "CollectDate";
		private int m_dateID;
		private string m_registerIP;
		private string m_registerMachine;
		private long m_grantScore;
		private long m_grantCount;
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
		public string RegisterIP
		{
			get
			{
				return this.m_registerIP;
			}
			set
			{
				this.m_registerIP = value;
			}
		}
		public string RegisterMachine
		{
			get
			{
				return this.m_registerMachine;
			}
			set
			{
				this.m_registerMachine = value;
			}
		}
		public long GrantScore
		{
			get
			{
				return this.m_grantScore;
			}
			set
			{
				this.m_grantScore = value;
			}
		}
		public long GrantCount
		{
			get
			{
				return this.m_grantCount;
			}
			set
			{
				this.m_grantCount = value;
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
		public SystemGrantCount()
		{
			this.m_dateID = 0;
			this.m_registerIP = "";
			this.m_registerMachine = "";
			this.m_grantScore = 0L;
			this.m_grantCount = 0L;
			this.m_collectDate = DateTime.Now;
		}
	}
}
