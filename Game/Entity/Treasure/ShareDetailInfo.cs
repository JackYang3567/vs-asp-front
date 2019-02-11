using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class ShareDetailInfo
	{
		public const string Tablename = "ShareDetailInfo";
		public const string _DetailID = "DetailID";
		public const string _OperUserID = "OperUserID";
		public const string _ShareID = "ShareID";
		public const string _UserID = "UserID";
		public const string _GameID = "GameID";
		public const string _Accounts = "Accounts";
		public const string _CardTypeID = "CardTypeID";
		public const string _SerialID = "SerialID";
		public const string _OrderID = "OrderID";
		public const string _OrderAmount = "OrderAmount";
		public const string _DiscountScale = "DiscountScale";
		public const string _PayAmount = "PayAmount";
		public const string _Currency = "Currency";
		public const string _BeforeCurrency = "BeforeCurrency";
		public const string _IPAddress = "IPAddress";
		public const string _ApplyDate = "ApplyDate";
		private int m_detailID;
		private int m_operUserID;
		private int m_shareID;
		private int m_userID;
		private int m_gameID;
		private string m_accounts;
		private int m_cardTypeID;
		private string m_serialID;
		private string m_orderID;
		private decimal m_orderAmount;
		private decimal m_discountScale;
		private decimal m_payAmount;
		private decimal m_currency;
		private decimal m_beforeCurrency;
		private string m_iPAddress;
		private DateTime m_applyDate;
		public int DetailID
		{
			get
			{
				return this.m_detailID;
			}
			set
			{
				this.m_detailID = value;
			}
		}
		public int OperUserID
		{
			get
			{
				return this.m_operUserID;
			}
			set
			{
				this.m_operUserID = value;
			}
		}
		public int ShareID
		{
			get
			{
				return this.m_shareID;
			}
			set
			{
				this.m_shareID = value;
			}
		}
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
		public int GameID
		{
			get
			{
				return this.m_gameID;
			}
			set
			{
				this.m_gameID = value;
			}
		}
		public string Accounts
		{
			get
			{
				return this.m_accounts;
			}
			set
			{
				this.m_accounts = value;
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
		public string OrderID
		{
			get
			{
				return this.m_orderID;
			}
			set
			{
				this.m_orderID = value;
			}
		}
		public decimal OrderAmount
		{
			get
			{
				return this.m_orderAmount;
			}
			set
			{
				this.m_orderAmount = value;
			}
		}
		public decimal DiscountScale
		{
			get
			{
				return this.m_discountScale;
			}
			set
			{
				this.m_discountScale = value;
			}
		}
		public decimal PayAmount
		{
			get
			{
				return this.m_payAmount;
			}
			set
			{
				this.m_payAmount = value;
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
		public decimal BeforeCurrency
		{
			get
			{
				return this.m_beforeCurrency;
			}
			set
			{
				this.m_beforeCurrency = value;
			}
		}
		public string IPAddress
		{
			get
			{
				return this.m_iPAddress;
			}
			set
			{
				this.m_iPAddress = value;
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
		public ShareDetailInfo()
		{
			this.m_detailID = 0;
			this.m_operUserID = 0;
			this.m_shareID = 0;
			this.m_userID = 0;
			this.m_gameID = 0;
			this.m_accounts = "";
			this.m_cardTypeID = 0;
			this.m_serialID = "";
			this.m_orderID = "";
			this.m_orderAmount = 0m;
			this.m_discountScale = 0m;
			this.m_payAmount = 0m;
			this.m_currency = 0m;
			this.m_beforeCurrency = 0m;
			this.m_iPAddress = "";
			this.m_applyDate = DateTime.Now;
		}
	}
}
