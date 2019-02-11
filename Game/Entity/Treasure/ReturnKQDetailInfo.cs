using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class ReturnKQDetailInfo
	{
		public const string Tablename = "ReturnKQDetailInfo";
		public const string _DetailID = "DetailID";
		public const string _MerchantAcctID = "MerchantAcctID";
		public const string _Version = "Version";
		public const string _Language = "Language";
		public const string _SignType = "SignType";
		public const string _PayType = "PayType";
		public const string _BankID = "BankID";
		public const string _OrderID = "OrderID";
		public const string _OrderTime = "OrderTime";
		public const string _OrderAmount = "OrderAmount";
		public const string _DealID = "DealID";
		public const string _BankDealID = "BankDealID";
		public const string _DealTime = "DealTime";
		public const string _PayAmount = "PayAmount";
		public const string _Fee = "Fee";
		public const string _PayResult = "PayResult";
		public const string _ErrCode = "ErrCode";
		public const string _SignMsg = "SignMsg";
		public const string _Ext1 = "Ext1";
		public const string _Ext2 = "Ext2";
		public const string _CardNumber = "CardNumber";
		public const string _CardPwd = "CardPwd";
		public const string _BossType = "BossType";
		public const string _ReceiveBossType = "ReceiveBossType";
		public const string _ReceiverAcctId = "ReceiverAcctId";
		public const string _PayDate = "PayDate";
		private int m_detailID;
		private string m_merchantAcctID;
		private string m_version;
		private int m_language;
		private int m_signType;
		private string m_payType;
		private string m_bankID;
		private string m_orderID;
		private DateTime m_orderTime;
		private decimal m_orderAmount;
		private string m_dealID;
		private string m_bankDealID;
		private DateTime m_dealTime;
		private decimal m_payAmount;
		private decimal m_fee;
		private string m_payResult;
		private string m_errCode;
		private string m_signMsg;
		private string m_ext1;
		private string m_ext2;
		private string m_cardNumber;
		private string m_cardPwd;
		private string m_bossType;
		private string m_receiveBossType;
		private string m_receiverAcctId;
		private DateTime m_payDate;
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
		public string MerchantAcctID
		{
			get
			{
				return this.m_merchantAcctID;
			}
			set
			{
				this.m_merchantAcctID = value;
			}
		}
		public string Version
		{
			get
			{
				return this.m_version;
			}
			set
			{
				this.m_version = value;
			}
		}
		public int Language
		{
			get
			{
				return this.m_language;
			}
			set
			{
				this.m_language = value;
			}
		}
		public int SignType
		{
			get
			{
				return this.m_signType;
			}
			set
			{
				this.m_signType = value;
			}
		}
		public string PayType
		{
			get
			{
				return this.m_payType;
			}
			set
			{
				this.m_payType = value;
			}
		}
		public string BankID
		{
			get
			{
				return this.m_bankID;
			}
			set
			{
				this.m_bankID = value;
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
		public DateTime OrderTime
		{
			get
			{
				return this.m_orderTime;
			}
			set
			{
				this.m_orderTime = value;
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
		public string DealID
		{
			get
			{
				return this.m_dealID;
			}
			set
			{
				this.m_dealID = value;
			}
		}
		public string BankDealID
		{
			get
			{
				return this.m_bankDealID;
			}
			set
			{
				this.m_bankDealID = value;
			}
		}
		public DateTime DealTime
		{
			get
			{
				return this.m_dealTime;
			}
			set
			{
				this.m_dealTime = value;
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
		public decimal Fee
		{
			get
			{
				return this.m_fee;
			}
			set
			{
				this.m_fee = value;
			}
		}
		public string PayResult
		{
			get
			{
				return this.m_payResult;
			}
			set
			{
				this.m_payResult = value;
			}
		}
		public string ErrCode
		{
			get
			{
				return this.m_errCode;
			}
			set
			{
				this.m_errCode = value;
			}
		}
		public string SignMsg
		{
			get
			{
				return this.m_signMsg;
			}
			set
			{
				this.m_signMsg = value;
			}
		}
		public string Ext1
		{
			get
			{
				return this.m_ext1;
			}
			set
			{
				this.m_ext1 = value;
			}
		}
		public string Ext2
		{
			get
			{
				return this.m_ext2;
			}
			set
			{
				this.m_ext2 = value;
			}
		}
		public string CardNumber
		{
			get
			{
				return this.m_cardNumber;
			}
			set
			{
				this.m_cardNumber = value;
			}
		}
		public string CardPwd
		{
			get
			{
				return this.m_cardPwd;
			}
			set
			{
				this.m_cardPwd = value;
			}
		}
		public string BossType
		{
			get
			{
				return this.m_bossType;
			}
			set
			{
				this.m_bossType = value;
			}
		}
		public string ReceiveBossType
		{
			get
			{
				return this.m_receiveBossType;
			}
			set
			{
				this.m_receiveBossType = value;
			}
		}
		public string ReceiverAcctId
		{
			get
			{
				return this.m_receiverAcctId;
			}
			set
			{
				this.m_receiverAcctId = value;
			}
		}
		public DateTime PayDate
		{
			get
			{
				return this.m_payDate;
			}
			set
			{
				this.m_payDate = value;
			}
		}
		public ReturnKQDetailInfo()
		{
			this.m_detailID = 0;
			this.m_merchantAcctID = "";
			this.m_version = "";
			this.m_language = 0;
			this.m_signType = 0;
			this.m_payType = "";
			this.m_bankID = "";
			this.m_orderID = "";
			this.m_orderTime = DateTime.Now;
			this.m_orderAmount = 0m;
			this.m_dealID = "";
			this.m_bankDealID = "";
			this.m_dealTime = DateTime.Now;
			this.m_payAmount = 0m;
			this.m_fee = 0m;
			this.m_payResult = "";
			this.m_errCode = "";
			this.m_signMsg = "";
			this.m_ext1 = "";
			this.m_ext2 = "";
			this.m_cardNumber = "";
			this.m_cardPwd = "";
			this.m_bossType = "";
			this.m_receiveBossType = "";
			this.m_receiverAcctId = "";
			this.m_payDate = DateTime.Now;
		}
	}
}
