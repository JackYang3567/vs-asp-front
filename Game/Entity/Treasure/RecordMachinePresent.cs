using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class RecordMachinePresent
	{
		public const string Tablename = "RecordMachinePresent";
		public const string _DateID = "DateID";
		public const string _MachineID = "MachineID";
		public const string _PresentGold = "PresentGold";
		public const string _PresentCount = "PresentCount";
		public const string _UserIDString = "UserIDString";
		public const string _FirstGrantDate = "FirstGrantDate";
		public const string _LastGrantDate = "LastGrantDate";
		private int m_dateID;
		private string m_machineID;
		private long m_presentGold;
		private int m_presentCount;
		private string m_userIDString;
		private DateTime m_firstGrantDate;
		private DateTime m_lastGrantDate;
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
		public string MachineID
		{
			get
			{
				return this.m_machineID;
			}
			set
			{
				this.m_machineID = value;
			}
		}
		public long PresentGold
		{
			get
			{
				return this.m_presentGold;
			}
			set
			{
				this.m_presentGold = value;
			}
		}
		public int PresentCount
		{
			get
			{
				return this.m_presentCount;
			}
			set
			{
				this.m_presentCount = value;
			}
		}
		public string UserIDString
		{
			get
			{
				return this.m_userIDString;
			}
			set
			{
				this.m_userIDString = value;
			}
		}
		public DateTime FirstGrantDate
		{
			get
			{
				return this.m_firstGrantDate;
			}
			set
			{
				this.m_firstGrantDate = value;
			}
		}
		public DateTime LastGrantDate
		{
			get
			{
				return this.m_lastGrantDate;
			}
			set
			{
				this.m_lastGrantDate = value;
			}
		}
		public RecordMachinePresent()
		{
			this.m_dateID = 0;
			this.m_machineID = "";
			this.m_presentGold = 0L;
			this.m_presentCount = 0;
			this.m_userIDString = "";
			this.m_firstGrantDate = DateTime.Now;
			this.m_lastGrantDate = DateTime.Now;
		}
	}
}
