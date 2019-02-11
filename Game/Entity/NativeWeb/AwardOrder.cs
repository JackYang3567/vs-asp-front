using System;
namespace Game.Entity.NativeWeb
{
	[Serializable]
	public class AwardOrder
	{
		public const string Tablename = "AwardOrder";
		public const string _OrderID = "OrderID";
		public const string _UserID = "UserID";
		public const string _AwardID = "AwardID";
		public const string _AwardPrice = "AwardPrice";
		public const string _AwardCount = "AwardCount";
		public const string _TotalAmount = "TotalAmount";
		public const string _Compellation = "Compellation";
		public const string _MobilePhone = "MobilePhone";
		public const string _QQ = "QQ";
		public const string _Province = "Province";
		public const string _City = "City";
		public const string _Area = "Area";
		public const string _DwellingPlace = "DwellingPlace";
		public const string _PostalCode = "PostalCode";
		public const string _OrderStatus = "OrderStatus";
		public const string _BuyIP = "BuyIP";
		public const string _BuyDate = "BuyDate";
		public const string _SolveNote = "SolveNote";
		public const string _SolveDate = "SolveDate";
		private int m_orderID;
		private int m_userID;
		private int m_awardID;
		private int m_awardPrice;
		private int m_awardCount;
		private int m_totalAmount;
		private string m_compellation;
		private string m_mobilePhone;
		private string m_qQ;
		private int m_province;
		private int m_city;
		private int m_area;
		private string m_dwellingPlace;
		private string m_postalCode;
		private int m_orderStatus;
		private string m_buyIP;
		private DateTime m_buyDate;
		private string m_solveNote;
		private DateTime m_solveDate;
		public int OrderID
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
		public int AwardID
		{
			get
			{
				return this.m_awardID;
			}
			set
			{
				this.m_awardID = value;
			}
		}
		public int AwardPrice
		{
			get
			{
				return this.m_awardPrice;
			}
			set
			{
				this.m_awardPrice = value;
			}
		}
		public int AwardCount
		{
			get
			{
				return this.m_awardCount;
			}
			set
			{
				this.m_awardCount = value;
			}
		}
		public int TotalAmount
		{
			get
			{
				return this.m_totalAmount;
			}
			set
			{
				this.m_totalAmount = value;
			}
		}
		public string Compellation
		{
			get
			{
				return this.m_compellation;
			}
			set
			{
				this.m_compellation = value;
			}
		}
		public string MobilePhone
		{
			get
			{
				return this.m_mobilePhone;
			}
			set
			{
				this.m_mobilePhone = value;
			}
		}
		public string QQ
		{
			get
			{
				return this.m_qQ;
			}
			set
			{
				this.m_qQ = value;
			}
		}
		public int Province
		{
			get
			{
				return this.m_province;
			}
			set
			{
				this.m_province = value;
			}
		}
		public int City
		{
			get
			{
				return this.m_city;
			}
			set
			{
				this.m_city = value;
			}
		}
		public int Area
		{
			get
			{
				return this.m_area;
			}
			set
			{
				this.m_area = value;
			}
		}
		public string DwellingPlace
		{
			get
			{
				return this.m_dwellingPlace;
			}
			set
			{
				this.m_dwellingPlace = value;
			}
		}
		public string PostalCode
		{
			get
			{
				return this.m_postalCode;
			}
			set
			{
				this.m_postalCode = value;
			}
		}
		public int OrderStatus
		{
			get
			{
				return this.m_orderStatus;
			}
			set
			{
				this.m_orderStatus = value;
			}
		}
		public string BuyIP
		{
			get
			{
				return this.m_buyIP;
			}
			set
			{
				this.m_buyIP = value;
			}
		}
		public DateTime BuyDate
		{
			get
			{
				return this.m_buyDate;
			}
			set
			{
				this.m_buyDate = value;
			}
		}
		public string SolveNote
		{
			get
			{
				return this.m_solveNote;
			}
			set
			{
				this.m_solveNote = value;
			}
		}
		public DateTime SolveDate
		{
			get
			{
				return this.m_solveDate;
			}
			set
			{
				this.m_solveDate = value;
			}
		}
		public AwardOrder()
		{
			this.m_orderID = 0;
			this.m_userID = 0;
			this.m_awardID = 0;
			this.m_awardPrice = 0;
			this.m_awardCount = 0;
			this.m_totalAmount = 0;
			this.m_compellation = "";
			this.m_mobilePhone = "";
			this.m_qQ = "";
			this.m_province = 0;
			this.m_city = 0;
			this.m_area = 0;
			this.m_dwellingPlace = "";
			this.m_postalCode = "";
			this.m_orderStatus = 0;
			this.m_buyIP = "";
			this.m_buyDate = DateTime.Now;
			this.m_solveNote = "";
			this.m_solveDate = DateTime.Now;
		}
	}
}
