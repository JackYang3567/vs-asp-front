using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class LivcardAssociator
	{
		public const string Tablename = "LivcardAssociator";
		public const string _CardID = "CardID";
		public const string _SerialID = "SerialID";
		public const string _Password = "Password";
		public const string _BuildID = "BuildID";
		public const string _CardTypeID = "CardTypeID";
		public const string _CardPrice = "CardPrice";
		public const string _Currency = "Currency";
		public const string _ValidDate = "ValidDate";
		public const string _BuildDate = "BuildDate";
		public const string _ApplyDate = "ApplyDate";
		public const string _UseRange = "UseRange";
		public const string _SalesPerson = "SalesPerson";
		public const string _Nullity = "Nullity";
		private int m_cardID;
		private string m_serialID;
		private string m_password;
		private int m_buildID;
		private int m_cardTypeID;
		private decimal m_cardPrice;
		private long m_currency;
		private DateTime m_validDate;
		private DateTime m_buildDate;
		private DateTime m_applyDate;
		private int m_useRange;
		private string m_salesPerson;
		private byte m_nullity;
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
		public string SerialID
		{
			get
			{
				return this.m_serialID;
			}
			set
			{
				this.m_serialID = value;
			}
		}
		public string Password
		{
			get
			{
				return this.m_password;
			}
			set
			{
				this.m_password = value;
			}
		}
		public int BuildID
		{
			get
			{
				return this.m_buildID;
			}
			set
			{
				this.m_buildID = value;
			}
		}
		public int CardTypeID
		{
			get
			{
				return this.m_cardTypeID;
			}
			set
			{
				this.m_cardTypeID = value;
			}
		}
		public decimal CardPrice
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
		public long Currency
		{
			get
			{
				return this.m_currency;
			}
			set
			{
				this.m_currency = value;
			}
		}
		public DateTime ValidDate
		{
			get
			{
				return this.m_validDate;
			}
			set
			{
				this.m_validDate = value;
			}
		}
		public DateTime BuildDate
		{
			get
			{
				return this.m_buildDate;
			}
			set
			{
				this.m_buildDate = value;
			}
		}
		public DateTime ApplyDate
		{
			get
			{
				return this.m_applyDate;
			}
			set
			{
				this.m_applyDate = value;
			}
		}
		public int UseRange
		{
			get
			{
				return this.m_useRange;
			}
			set
			{
				this.m_useRange = value;
			}
		}
		public string SalesPerson
		{
			get
			{
				return this.m_salesPerson;
			}
			set
			{
				this.m_salesPerson = value;
			}
		}
		public byte Nullity
		{
			get
			{
				return this.m_nullity;
			}
			set
			{
				this.m_nullity = value;
			}
		}
		public LivcardAssociator()
		{
			this.m_cardID = 0;
			this.m_serialID = "";
			this.m_password = "";
			this.m_buildID = 0;
			this.m_cardTypeID = 0;
			this.m_cardPrice = 0m;
			this.m_currency = 0L;
			this.m_validDate = DateTime.Now;
			this.m_buildDate = DateTime.Now;
			this.m_applyDate = DateTime.Now;
			this.m_useRange = 0;
			this.m_salesPerson = "";
			this.m_nullity = 0;
		}
	}
}
