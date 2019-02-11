using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class GlobalAppInfo
	{
		public const string Tablename = "GlobalAppInfo";
		public const string _AppID = "AppID";
		public const string _ProductID = "ProductID";
		public const string _ProductName = "ProductName";
		public const string _Description = "Description";
		public const string _Price = "Price";
		public const string _TagID = "TagID";
		public const string _CollectDate = "CollectDate";
		private int m_appID;
		private string m_productID;
		private string m_productName;
		private string m_description;
		private decimal m_price;
		private decimal m_attachCurrency;
		private int m_tagID;
		private DateTime m_collectDate;
		public int AppID
		{
			get
			{
				return this.m_appID;
			}
			set
			{
				this.m_appID = value;
			}
		}
		public string ProductID
		{
			get
			{
				return this.m_productID;
			}
			set
			{
				this.m_productID = value;
			}
		}
		public string ProductName
		{
			get
			{
				return this.m_productName;
			}
			set
			{
				this.m_productName = value;
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
		public decimal Price
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
		public decimal AttachCurrency
		{
			get
			{
				return this.m_attachCurrency;
			}
			set
			{
				this.m_attachCurrency = value;
			}
		}
		public int TagID
		{
			get
			{
				return this.m_tagID;
			}
			set
			{
				this.m_tagID = value;
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
		public int PresentCurrency
		{
			get;
			set;
		}
		public int SortID
		{
			get;
			set;
		}
		public GlobalAppInfo()
		{
			this.m_appID = 0;
			this.m_productID = "";
			this.m_productName = "";
			this.m_description = "";
			this.m_price = 0m;
			this.m_attachCurrency = 0m;
			this.m_tagID = 0;
			this.m_collectDate = DateTime.Now;
		}
	}
}
