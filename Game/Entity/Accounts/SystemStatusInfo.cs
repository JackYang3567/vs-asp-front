using System;
namespace Game.Entity.Accounts
{
	[Serializable]
	public class SystemStatusInfo
	{
		public const string Tablename = "SystemStatusInfo";
		public const string _StatusName = "StatusName";
		public const string _StatusValue = "StatusValue";
		public const string _StatusString = "StatusString";
		public const string _StatusTip = "StatusTip";
		public const string _StatusDescription = "StatusDescription";
		public const string _SortID = "SortID";
		private string m_statusName;
		private int m_statusValue;
		private string m_statusString;
		private string m_statusTip;
		private string m_statusDescription;
		private int m_sortID;
		public string StatusName
		{
			get
			{
				return this.m_statusName;
			}
			set
			{
				this.m_statusName = value;
			}
		}
		public int StatusValue
		{
			get
			{
				return this.m_statusValue;
			}
			set
			{
				this.m_statusValue = value;
			}
		}
		public string StatusString
		{
			get
			{
				return this.m_statusString;
			}
			set
			{
				this.m_statusString = value;
			}
		}
		public string StatusTip
		{
			get
			{
				return this.m_statusTip;
			}
			set
			{
				this.m_statusTip = value;
			}
		}
		public string StatusDescription
		{
			get
			{
				return this.m_statusDescription;
			}
			set
			{
				this.m_statusDescription = value;
			}
		}
		public int SortID
		{
			get
			{
				return this.m_sortID;
			}
			set
			{
				this.m_sortID = value;
			}
		}
		public SystemStatusInfo()
		{
			this.m_statusName = "";
			this.m_statusValue = 0;
			this.m_statusString = "";
			this.m_statusTip = "";
			this.m_statusDescription = "";
			this.m_sortID = 0;
		}
	}
}
