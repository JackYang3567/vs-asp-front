using System;
namespace Game.Entity.Accounts
{
	[Serializable]
	public class MemberProperty
	{
		public const string Tablename = "MemberProperty";
		public const string _MemberOrder = "MemberOrder";
		public const string _MemberName = "MemberName";
		public const string _UserRight = "UserRight";
		public const string _TaskRate = "TaskRate";
		public const string _ShopRate = "ShopRate";
		public const string _InsureRate = "InsureRate";
		public const string _DayPresent = "DayPresent";
		public const string _DayGiftID = "DayGiftID";
		public const string _CollectDate = "CollectDate";
		public const string _CollectNote = "CollectNote";
		private int m_memberOrder;
		private string m_memberName;
		private int m_userRight;
		private int m_taskRate;
		private int m_shopRate;
		private int m_insureRate;
		private int m_dayPresent;
		private int m_dayGiftID;
		private DateTime m_collectDate;
		private string m_collectNote;
		public int MemberOrder
		{
			get
			{
				return this.m_memberOrder;
			}
			set
			{
				this.m_memberOrder = value;
			}
		}
		public string MemberName
		{
			get
			{
				return this.m_memberName;
			}
			set
			{
				this.m_memberName = value;
			}
		}
		public int UserRight
		{
			get
			{
				return this.m_userRight;
			}
			set
			{
				this.m_userRight = value;
			}
		}
		public int TaskRate
		{
			get
			{
				return this.m_taskRate;
			}
			set
			{
				this.m_taskRate = value;
			}
		}
		public int ShopRate
		{
			get
			{
				return this.m_shopRate;
			}
			set
			{
				this.m_shopRate = value;
			}
		}
		public int InsureRate
		{
			get
			{
				return this.m_insureRate;
			}
			set
			{
				this.m_insureRate = value;
			}
		}
		public int DayPresent
		{
			get
			{
				return this.m_dayPresent;
			}
			set
			{
				this.m_dayPresent = value;
			}
		}
		public int DayGiftID
		{
			get
			{
				return this.m_dayGiftID;
			}
			set
			{
				this.m_dayGiftID = value;
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
		public string CollectNote
		{
			get
			{
				return this.m_collectNote;
			}
			set
			{
				this.m_collectNote = value;
			}
		}
		public MemberProperty()
		{
			this.m_memberOrder = 0;
			this.m_memberName = "";
			this.m_userRight = 0;
			this.m_taskRate = 0;
			this.m_shopRate = 0;
			this.m_insureRate = 0;
			this.m_dayPresent = 0;
			this.m_dayGiftID = 0;
			this.m_collectDate = DateTime.Now;
			this.m_collectNote = "";
		}
	}
}
