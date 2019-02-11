using System;
namespace Game.Entity.NativeWeb
{
	[Serializable]
	public class AwardInfo
	{
		public const string Tablename = "AwardInfo";
		public const string _AwardID = "AwardID";
		public const string _AwardName = "AwardName";
		public const string _TypeID = "TypeID";
		public const string _Price = "Price";
		public const string _Inventory = "Inventory";
		public const string _BuyCount = "BuyCount";
		public const string _SmallImage = "SmallImage";
		public const string _BigImage = "BigImage";
		public const string _NeedInfo = "NeedInfo";
		public const string _IsMember = "IsMember";
		public const string _IsReturn = "IsReturn";
		public const string _SortID = "SortID";
		public const string _Nullity = "Nullity";
		public const string _Description = "Description";
		public const string _CollectDate = "CollectDate";
		private int m_awardID;
		private string m_awardName;
		private int m_typeID;
		private int m_price;
		private int m_inventory;
		private int m_buyCount;
		private string m_smallImage;
		private string m_bigImage;
		private int m_needInfo;
		private bool m_isMember;
		private bool m_isReturn;
		private int m_sortID;
		private byte m_nullity;
		private string m_description;
		private DateTime m_collectDate;
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
		public string AwardName
		{
			get
			{
				return this.m_awardName;
			}
			set
			{
				this.m_awardName = value;
			}
		}
		public int TypeID
		{
			get
			{
				return this.m_typeID;
			}
			set
			{
				this.m_typeID = value;
			}
		}
		public int Price
		{
			get
			{
				return this.m_price;
			}
			set
			{
				this.m_price = value;
			}
		}
		public int Inventory
		{
			get
			{
				return this.m_inventory;
			}
			set
			{
				this.m_inventory = value;
			}
		}
		public int BuyCount
		{
			get
			{
				return this.m_buyCount;
			}
			set
			{
				this.m_buyCount = value;
			}
		}
		public string SmallImage
		{
			get
			{
				return this.m_smallImage;
			}
			set
			{
				this.m_smallImage = value;
			}
		}
		public string BigImage
		{
			get
			{
				return this.m_bigImage;
			}
			set
			{
				this.m_bigImage = value;
			}
		}
		public int NeedInfo
		{
			get
			{
				return this.m_needInfo;
			}
			set
			{
				this.m_needInfo = value;
			}
		}
		public bool IsMember
		{
			get
			{
				return this.m_isMember;
			}
			set
			{
				this.m_isMember = value;
			}
		}
		public bool IsReturn
		{
			get
			{
				return this.m_isReturn;
			}
			set
			{
				this.m_isReturn = value;
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
		public string Description
		{
			get
			{
				return this.m_description;
			}
			set
			{
				this.m_description = value;
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
		public AwardInfo()
		{
			this.m_awardID = 0;
			this.m_awardName = "";
			this.m_typeID = 0;
			this.m_price = 0;
			this.m_inventory = 0;
			this.m_buyCount = 0;
			this.m_smallImage = "";
			this.m_bigImage = "";
			this.m_needInfo = 0;
			this.m_isMember = false;
			this.m_isReturn = false;
			this.m_sortID = 0;
			this.m_nullity = 0;
			this.m_description = "";
			this.m_collectDate = DateTime.Now;
		}
	}
}
