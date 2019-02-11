using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class GameScoreLocker
	{
		public const string Tablename = "GameScoreLocker";
		public const string _UserID = "UserID";
		public const string _KindID = "KindID";
		public const string _ServerID = "ServerID";
		public const string _EnterID = "EnterID";
		public const string _EnterIP = "EnterIP";
		public const string _EnterMachine = "EnterMachine";
		public const string _CollectDate = "CollectDate";
		private int m_userID;
		private int m_kindID;
		private int m_serverID;
		private int m_enterID;
		private string m_enterIP;
		private string m_enterMachine;
		private DateTime m_collectDate;
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
		public int EnterID
		{
			get
			{
				return this.m_enterID;
			}
			set
			{
				this.m_enterID = value;
			}
		}
		public string EnterIP
		{
			get
			{
				return this.m_enterIP;
			}
			set
			{
				this.m_enterIP = value;
			}
		}
		public string EnterMachine
		{
			get
			{
				return this.m_enterMachine;
			}
			set
			{
				this.m_enterMachine = value;
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
		public GameScoreLocker()
		{
			this.m_userID = 0;
			this.m_kindID = 0;
			this.m_serverID = 0;
			this.m_enterID = 0;
			this.m_enterIP = "";
			this.m_enterMachine = "";
			this.m_collectDate = DateTime.Now;
		}
	}
}
