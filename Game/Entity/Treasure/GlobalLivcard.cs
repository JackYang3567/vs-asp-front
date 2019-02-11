using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class GlobalLivcard
	{
		public const string Tablename = "GlobalLivcard";
		public const string _CardTypeID = "CardTypeID";
		public const string _CardName = "CardName";
		public const string _CardPrice = "CardPrice";
		public const string _Currency = "Currency";
		public const string _InputDate = "InputDate";
		private int m_cardTypeID;
		private string m_cardName;
		private decimal m_cardPrice;
		private decimal m_currency;
		private DateTime m_inputDate;
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
		public decimal Currency
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
		public GlobalLivcard()
		{
			this.m_cardTypeID = 0;
			this.m_cardName = "";
			this.m_cardPrice = 0m;
			this.m_currency = 0m;
			this.m_inputDate = DateTime.Now;
		}
	}
}
