using Newtonsoft.Json;
using System;
namespace Game.Entity.Treasure
{
	public class AppReceiptInfo2
	{
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
		public int quantity
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
		public string product_id
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
		public string transaction_id
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
		public string purchase_date
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
		public string original_transaction_id
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
		public string original_purchase_date
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
		public string app_item_id
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
		public string version_external_identifier
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
		public string bid
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
		public string bvrs
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
		public AppReceiptInfo2()
		{
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
		}
		public string SerializeText()
		{
			return JsonConvert.SerializeObject(this);
		}
		public static AppReceiptInfo2 DeserializeObject(string jsonText)
		{
			return JsonConvert.DeserializeObject<AppReceiptInfo2>(jsonText);
		}
	}
}
