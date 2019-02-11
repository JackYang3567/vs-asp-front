using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class ReturnDouwanDetailInfo
	{
		public const string Tablename = "ReturnDouwanDetailInfo";
		public const string _DetailID = "DetailID";
		public const string _OpenId = "OpenId";
		public const string _ServerId = "ServerId";
		public const string _ServerName = "ServerName";
		public const string _RoleId = "RoleId";
		public const string _RoleName = "RoleName";
		public const string _OrderId = "OrderId";
		public const string _OrderStatus = "OrderStatus";
		public const string _PayType = "PayType";
		public const string _Amount = "Amount";
		public const string _Remark = "Remark";
		public const string _CallBackInfo = "CallBackInfo";
		public const string _Sign = "Sign";
		public const string _MySign = "MySign";
		public const string _CollectDate = "CollectDate";
		private int m_detailID;
		private string m_openId;
		private string m_serverId;
		private string m_serverName;
		private string m_roleId;
		private string m_roleName;
		private string m_orderId;
		private int m_orderStatus;
		private string m_payType;
		private decimal m_amount;
		private string m_remark;
		private string m_callBackInfo;
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
		public string OpenId
		{
			get
			{
				return this.m_openId;
			}
			set
			{
				this.m_openId = value;
			}
		}
		public string ServerId
		{
			get
			{
				return this.m_serverId;
			}
			set
			{
				this.m_serverId = value;
			}
		}
		public string ServerName
		{
			get
			{
				return this.m_serverName;
			}
			set
			{
				this.m_serverName = value;
			}
		}
		public string RoleId
		{
			get
			{
				return this.m_roleId;
			}
			set
			{
				this.m_roleId = value;
			}
		}
		public string RoleName
		{
			get
			{
				return this.m_roleName;
			}
			set
			{
				this.m_roleName = value;
			}
		}
		public string OrderId
		{
			get
			{
				return this.m_orderId;
			}
			set
			{
				this.m_orderId = value;
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
		public decimal Amount
		{
			get
			{
				return this.m_amount;
			}
			set
			{
				this.m_amount = value;
			}
		}
		public string Remark
		{
			get
			{
				return this.m_remark;
			}
			set
			{
				this.m_remark = value;
			}
		}
		public string CallBackInfo
		{
			get
			{
				return this.m_callBackInfo;
			}
			set
			{
				this.m_callBackInfo = value;
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
		public ReturnDouwanDetailInfo()
		{
			this.m_detailID = 0;
			this.m_openId = "";
			this.m_serverId = "";
			this.m_serverName = "";
			this.m_roleId = "";
			this.m_roleName = "";
			this.m_orderId = "";
			this.m_orderStatus = 0;
			this.m_payType = "";
			this.m_amount = 0m;
			this.m_remark = "";
			this.m_callBackInfo = "";
			this.m_sign = "";
			this.m_mySign = "";
			this.m_collectDate = DateTime.Now;
		}
	}
}
