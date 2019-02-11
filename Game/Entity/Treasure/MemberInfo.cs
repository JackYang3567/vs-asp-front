using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class MemberInfo
	{
		public const string Tablename = "MemberInfo";
		public const string _CardID = "CardID";
		public const string _CardName = "CardName";
		public const string _CardPrice = "CardPrice";
		public const string _PresentGold = "PresentGold";
		public const string _MemberOrder = "MemberOrder";
		public const string _MemberDays = "MemberDays";
		public const string _UserRight = "UserRight";
		public const string _ServiceRight = "ServiceRight";
		public const string _InputDate = "InputDate";
		private int m_cardID;
		private string m_cardName;
		private int m_cardPrice;
		private int m_presentGold;
		private byte m_memberOrder;
		private int m_memberDays;
		private int m_userRight;
		private int m_serviceRight;
		private DateTime m_inputDate;
		public int CardID
		{
			get
			{
				return this.m_cardID;
			}
			set
			{
				this.m_cardID = value;
			}
		}
		public string CardName
		{
			get
			{
				return this.m_cardName;
			}
			set
			{
				this.m_cardName = value;
			}
		}
		public int CardPrice
		{
			get
			{
				return this.m_cardPrice;
			}
			set
			{
				this.m_cardPrice = value;
			}
		}
		public int PresentGold
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
		public byte MemberOrder
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
		public int MemberDays
		{
			get
			{
				return this.m_memberDays;
			}
			set
			{
				this.m_memberDays = value;
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
		public int ServiceRight
		{
			get
			{
				return this.m_serviceRight;
			}
			set
			{
				this.m_serviceRight = value;
			}
		}
		public DateTime InputDate
		{
			get
			{
				return this.m_inputDate;
			}
			set
			{
				this.m_inputDate = value;
			}
		}
		public MemberInfo()
		{
			this.m_cardID = 0;
			this.m_cardName = "";
			this.m_cardPrice = 0;
			this.m_presentGold = 0;
			this.m_memberOrder = 0;
			this.m_memberDays = 0;
			this.m_userRight = 0;
			this.m_serviceRight = 0;
			this.m_inputDate = DateTime.Now;
		}
	}
}
