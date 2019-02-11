using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class Return91DetailInfo
	{
		public const string Tablename = "Return91DetailInfo";
		public const string _DetailID = "DetailID";
		public const string _ProductId = "ProductId";
		public const string _ProductName = "ProductName";
		public const string _ConsumeStreamId = "ConsumeStreamId";
		public const string _OrderID = "OrderID";
		public const string _Uin = "Uin";
		public const string _GoodsID = "GoodsID";
		public const string _GoodsInfo = "GoodsInfo";
		public const string _GoodsCount = "GoodsCount";
		public const string _OriginalMoney = "OriginalMoney";
		public const string _OrderMoney = "OrderMoney";
		public const string _Note = "Note";
		public const string _PayStatus = "PayStatus";
		public const string _CreateTime = "CreateTime";
		public const string _Sign = "Sign";
		public const string _MySign = "MySign";
		public const string _CollectDate = "CollectDate";
		private int m_detailID;
		private int m_productId;
		private string m_productName;
		private string m_consumeStreamId;
		private string m_orderID;
		private int m_uin;
		private string m_goodsID;
		private string m_goodsInfo;
		private int m_goodsCount;
		private decimal m_originalMoney;
		private decimal m_orderMoney;
		private string m_note;
		private int m_payStatus;
		private DateTime m_createTime;
		private string m_sign;
		private string m_mySign;
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
		public int ProductId
		{
			get
			{
				return this.m_productId;
			}
			set
			{
				this.m_productId = value;
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
		public string ConsumeStreamId
		{
			get
			{
				return this.m_consumeStreamId;
			}
			set
			{
				this.m_consumeStreamId = value;
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
		public int Uin
		{
			get
			{
				return this.m_uin;
			}
			set
			{
				this.m_uin = value;
			}
		}
		public string GoodsID
		{
			get
			{
				return this.m_goodsID;
			}
			set
			{
				this.m_goodsID = value;
			}
		}
		public string GoodsInfo
		{
			get
			{
				return this.m_goodsInfo;
			}
			set
			{
				this.m_goodsInfo = value;
			}
		}
		public int GoodsCount
		{
			get
			{
				return this.m_goodsCount;
			}
			set
			{
				this.m_goodsCount = value;
			}
		}
		public decimal OriginalMoney
		{
			get
			{
				return this.m_originalMoney;
			}
			set
			{
				this.m_originalMoney = value;
			}
		}
		public decimal OrderMoney
		{
			get
			{
				return this.m_orderMoney;
			}
			set
			{
				this.m_orderMoney = value;
			}
		}
		public string Note
		{
			get
			{
				return this.m_note;
			}
			set
			{
				this.m_note = value;
			}
		}
		public int PayStatus
		{
			get
			{
				return this.m_payStatus;
			}
			set
			{
				this.m_payStatus = value;
			}
		}
		public DateTime CreateTime
		{
			get
			{
				return this.m_createTime;
			}
			set
			{
				this.m_createTime = value;
			}
		}
		public string Sign
		{
			get
			{
				return this.m_sign;
			}
			set
			{
				this.m_sign = value;
			}
		}
		public string MySign
		{
			get
			{
				return this.m_mySign;
			}
			set
			{
				this.m_mySign = value;
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
		public Return91DetailInfo()
		{
			this.m_detailID = 0;
			this.m_productId = 0;
			this.m_productName = "";
			this.m_consumeStreamId = "";
			this.m_orderID = "";
			this.m_uin = 0;
			this.m_goodsID = "";
			this.m_goodsInfo = "";
			this.m_goodsCount = 0;
			this.m_originalMoney = 0m;
			this.m_orderMoney = 0m;
			this.m_note = "";
			this.m_payStatus = 0;
			this.m_createTime = DateTime.Now;
			this.m_sign = "";
			this.m_mySign = "";
			this.m_collectDate = DateTime.Now;
		}
	}
}
