using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class MemberCard
	{
		public const string Tablename = "MemberCard";
		public const string _CardID = "CardID";
		public const string _CardName = "CardName";
		public const string _CardPrice = "CardPrice";
		public const string _PresentScore = "PresentScore";
		public const string _MemberOrder = "MemberOrder";
		public const string _MemberDays = "MemberDays";
		public const string _UserRight = "UserRight";
		public const string _ServiceRight = "ServiceRight";
		public const string _SmallImageUrl = "SmallImageUrl";
		public const string _BigImageUrl = "BigImageUrl";
		public const string _Describe = "Describe";
		public const string _InputDate = "InputDate";
		private int m_cardID;
		private string m_cardName;
		private int m_cardPrice;
		private int m_presentScore;
		private byte m_memberOrder;
		private int m_memberDays;
		private int m_userRight;
		private int m_serviceRight;
		private string m_smallImageUrl;
		private string m_bigImageUrl;
		private string m_describe;
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
		public int PresentScore
		{
			get
			{
				return this.m_presentScore;
			}
			set
			{
				this.m_presentScore = value;
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
		public string SmallImageUrl
		{
			get
			{
				return this.m_smallImageUrl;
			}
			set
			{
				this.m_smallImageUrl = value;
			}
		}
		public string BigImageUrl
		{
			get
			{
				return this.m_bigImageUrl;
			}
			set
			{
				this.m_bigImageUrl = value;
			}
		}
		public string Describe
		{
			get
			{
				return this.m_describe;
			}
			set
			{
				this.m_describe = value;
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
		public MemberCard()
		{
			this.m_cardID = 0;
			this.m_cardName = "";
			this.m_cardPrice = 0;
			this.m_presentScore = 0;
			this.m_memberOrder = 0;
			this.m_memberDays = 0;
			this.m_userRight = 0;
			this.m_serviceRight = 0;
			this.m_smallImageUrl = "";
			this.m_bigImageUrl = "";
			this.m_describe = "";
			this.m_inputDate = DateTime.Now;
		}
	}
}
