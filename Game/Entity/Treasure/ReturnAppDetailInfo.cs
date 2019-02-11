using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class ReturnAppDetailInfo
	{
		public const string Tablename = "ReturnAppDetailInfo";
		public const string _DetailID = "DetailID";
		public const string _UserID = "UserID";
		public const string _OrderID = "OrderID";
		public const string _PayAmount = "PayAmount";
		public const string _Status = "Status";
		public const string _Quantity = "quantity";
		public const string _Product_id = "product_id";
		public const string _Transaction_id = "transaction_id";
		public const string _Purchase_date = "purchase_date";
		public const string _Original_transaction_id = "original_transaction_id";
		public const string _Original_purchase_date = "original_purchase_date";
		public const string _App_item_id = "app_item_id";
		public const string _Version_external_identifier = "version_external_identifier";
		public const string _Bid = "bid";
		public const string _Bvrs = "bvrs";
		public const string _CollectDate = "CollectDate";
		private int m_detailID;
		private int m_userID;
		private string m_orderID;
		private decimal m_payAmount;
		private int m_status;
		private int m_quantity;
		private string m_product_id;
		private string m_transaction_id;
		private string m_purchase_date;
		private string m_original_transaction_id;
		private string m_original_purchase_date;
		private string m_app_item_id;
		private string m_version_external_identifier;
		private string m_bid;
		private string m_bvrs;
		private DateTime m_collectDate;
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
		public int Status
		{
			get
			{
				return this.m_status;
			}
			set
			{
				this.m_status = value;
			}
		}
		public int Quantity
		{
			get
			{
				return this.m_quantity;
			}
			set
			{
				this.m_quantity = value;
			}
		}
		public string Product_id
		{
			get
			{
				return this.m_product_id;
			}
			set
			{
				this.m_product_id = value;
			}
		}
		public string Transaction_id
		{
			get
			{
				return this.m_transaction_id;
			}
			set
			{
				this.m_transaction_id = value;
			}
		}
		public string Purchase_date
		{
			get
			{
				return this.m_purchase_date;
			}
			set
			{
				this.m_purchase_date = value;
			}
		}
		public string Original_transaction_id
		{
			get
			{
				return this.m_original_transaction_id;
			}
			set
			{
				this.m_original_transaction_id = value;
			}
		}
		public string Original_purchase_date
		{
			get
			{
				return this.m_original_purchase_date;
			}
			set
			{
				this.m_original_purchase_date = value;
			}
		}
		public string App_item_id
		{
			get
			{
				return this.m_app_item_id;
			}
			set
			{
				this.m_app_item_id = value;
			}
		}
		public string Version_external_identifier
		{
			get
			{
				return this.m_version_external_identifier;
			}
			set
			{
				this.m_version_external_identifier = value;
			}
		}
		public string Bid
		{
			get
			{
				return this.m_bid;
			}
			set
			{
				this.m_bid = value;
			}
		}
		public string Bvrs
		{
			get
			{
				return this.m_bvrs;
			}
			set
			{
				this.m_bvrs = value;
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
		public ReturnAppDetailInfo()
		{
			this.m_detailID = 0;
			this.m_userID = 0;
			this.m_orderID = "";
			this.m_payAmount = 0m;
			this.m_status = 0;
			this.m_quantity = 0;
			this.m_product_id = "";
			this.m_transaction_id = "";
			this.m_purchase_date = "";
			this.m_original_transaction_id = "";
			this.m_original_purchase_date = "";
			this.m_app_item_id = "";
			this.m_version_external_identifier = "";
			this.m_bid = "";
			this.m_bvrs = "";
			this.m_collectDate = DateTime.Now;
		}
	}
}
