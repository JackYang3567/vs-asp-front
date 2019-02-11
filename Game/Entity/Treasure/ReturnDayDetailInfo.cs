using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class ReturnDayDetailInfo
	{
		public const string Tablename = "ReturnDayDetailInfo";
		public const string _DetailID = "DetailID";
		public const string _OrderID = "OrderID";
		public const string _MerID = "MerID";
		public const string _PayMoney = "PayMoney";
		public const string _UserName = "UserName";
		public const string _PayType = "PayType";
		public const string _Status = "Status";
		public const string _Sign = "Sign";
		public const string _InputDate = "InputDate";
		private int m_detailID;
		private string m_orderID;
		private string m_merID;
		private decimal m_payMoney;
		private string m_userName;
		private int m_payType;
		private string m_status;
		private string m_sign;
		private DateTime m_inputDate;
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
		public string MerID
		{
			get
			{
				return this.m_merID;
			}
			set
			{
				this.m_merID = value;
			}
		}
		public decimal PayMoney
		{
			get
			{
				return this.m_payMoney;
			}
			set
			{
				this.m_payMoney = value;
			}
		}
		public string UserName
		{
			get
			{
				return this.m_userName;
			}
			set
			{
				this.m_userName = value;
			}
		}
		public int PayType
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
		public string Status
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
		public ReturnDayDetailInfo()
		{
			this.m_detailID = 0;
			this.m_orderID = "";
			this.m_merID = "";
			this.m_payMoney = 0m;
			this.m_userName = "";
			this.m_payType = 0;
			this.m_status = "";
			this.m_sign = "";
			this.m_inputDate = DateTime.Now;
		}
	}
}
