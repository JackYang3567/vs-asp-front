using System;
namespace Game.Entity.Platform
{
	[Serializable]
	public class OnLineStatusInfo
	{
		public const string Tablename = "OnLineStatusInfo";
		public const string _KindID = "KindID";
		public const string _ServerID = "ServerID";
		public const string _OnLineCount = "OnLineCount";
		public const string _InsertDateTime = "InsertDateTime";
		public const string _ModifyDateTime = "ModifyDateTime";
		private int m_kindID;
		private int m_serverID;
		private int m_onLineCount;
		private DateTime m_insertDateTime;
		private DateTime m_modifyDateTime;
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
		public int OnLineCount
		{
			get
			{
				return this.m_onLineCount;
			}
			set
			{
				this.m_onLineCount = value;
			}
		}
		public DateTime InsertDateTime
		{
			get
			{
				return this.m_insertDateTime;
			}
			set
			{
				this.m_insertDateTime = value;
			}
		}
		public DateTime ModifyDateTime
		{
			get
			{
				return this.m_modifyDateTime;
			}
			set
			{
				this.m_modifyDateTime = value;
			}
		}
		public OnLineStatusInfo()
		{
			this.m_kindID = 0;
			this.m_serverID = 0;
			this.m_onLineCount = 0;
			this.m_insertDateTime = DateTime.Now;
			this.m_modifyDateTime = DateTime.Now;
		}
	}
}
