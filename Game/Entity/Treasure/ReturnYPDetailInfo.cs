using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class ReturnYPDetailInfo
	{
		public const string Tablename = "ReturnYPDetailInfo";
		public const string _DetailID = "DetailID";
		public const string _P1_MerId = "p1_MerId";
		public const string _R0_Cmd = "r0_Cmd";
		public const string _R1_Code = "r1_Code";
		public const string _R2_TrxId = "r2_TrxId";
		public const string _R3_Amt = "r3_Amt";
		public const string _R4_Cur = "r4_Cur";
		public const string _R5_Pid = "r5_Pid";
		public const string _R6_Order = "r6_Order";
		public const string _R7_Uid = "r7_Uid";
		public const string _R8_MP = "r8_MP";
		public const string _R9_BType = "r9_BType";
		public const string _Rb_BankId = "rb_BankId";
		public const string _Ro_BankOrderId = "ro_BankOrderId";
		public const string _Rp_PayDate = "rp_PayDate";
		public const string _Rq_CardNo = "rq_CardNo";
		public const string _Ru_Trxtime = "ru_Trxtime";
		public const string _Hmac = "hmac";
		public const string _CollectDate = "CollectDate";
		private int m_detailID;
		private string m_p1_MerId;
		private string m_r0_Cmd;
		private string m_r1_Code;
		private string m_r2_TrxId;
		private decimal m_r3_Amt;
		private string m_r4_Cur;
		private string m_r5_Pid;
		private string m_r6_Order;
		private string m_r7_Uid;
		private string m_r8_MP;
		private string m_r9_BType;
		private string m_rb_BankId;
		private string m_ro_BankOrderId;
		private string m_rp_PayDate;
		private string m_rq_CardNo;
		private string m_ru_Trxtime;
		private string m_hmac;
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
		public string P1_MerId
		{
			get
			{
				return this.m_p1_MerId;
			}
			set
			{
				this.m_p1_MerId = value;
			}
		}
		public string R0_Cmd
		{
			get
			{
				return this.m_r0_Cmd;
			}
			set
			{
				this.m_r0_Cmd = value;
			}
		}
		public string R1_Code
		{
			get
			{
				return this.m_r1_Code;
			}
			set
			{
				this.m_r1_Code = value;
			}
		}
		public string R2_TrxId
		{
			get
			{
				return this.m_r2_TrxId;
			}
			set
			{
				this.m_r2_TrxId = value;
			}
		}
		public decimal R3_Amt
		{
			get
			{
				return this.m_r3_Amt;
			}
			set
			{
				this.m_r3_Amt = value;
			}
		}
		public string R4_Cur
		{
			get
			{
				return this.m_r4_Cur;
			}
			set
			{
				this.m_r4_Cur = value;
			}
		}
		public string R5_Pid
		{
			get
			{
				return this.m_r5_Pid;
			}
			set
			{
				this.m_r5_Pid = value;
			}
		}
		public string R6_Order
		{
			get
			{
				return this.m_r6_Order;
			}
			set
			{
				this.m_r6_Order = value;
			}
		}
		public string R7_Uid
		{
			get
			{
				return this.m_r7_Uid;
			}
			set
			{
				this.m_r7_Uid = value;
			}
		}
		public string R8_MP
		{
			get
			{
				return this.m_r8_MP;
			}
			set
			{
				this.m_r8_MP = value;
			}
		}
		public string R9_BType
		{
			get
			{
				return this.m_r9_BType;
			}
			set
			{
				this.m_r9_BType = value;
			}
		}
		public string Rb_BankId
		{
			get
			{
				return this.m_rb_BankId;
			}
			set
			{
				this.m_rb_BankId = value;
			}
		}
		public string Ro_BankOrderId
		{
			get
			{
				return this.m_ro_BankOrderId;
			}
			set
			{
				this.m_ro_BankOrderId = value;
			}
		}
		public string Rp_PayDate
		{
			get
			{
				return this.m_rp_PayDate;
			}
			set
			{
				this.m_rp_PayDate = value;
			}
		}
		public string Rq_CardNo
		{
			get
			{
				return this.m_rq_CardNo;
			}
			set
			{
				this.m_rq_CardNo = value;
			}
		}
		public string Ru_Trxtime
		{
			get
			{
				return this.m_ru_Trxtime;
			}
			set
			{
				this.m_ru_Trxtime = value;
			}
		}
		public string Hmac
		{
			get
			{
				return this.m_hmac;
			}
			set
			{
				this.m_hmac = value;
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
		public ReturnYPDetailInfo()
		{
			this.m_detailID = 0;
			this.m_p1_MerId = "";
			this.m_r0_Cmd = "";
			this.m_r1_Code = "";
			this.m_r2_TrxId = "";
			this.m_r3_Amt = 0m;
			this.m_r4_Cur = "";
			this.m_r5_Pid = "";
			this.m_r6_Order = "";
			this.m_r7_Uid = "";
			this.m_r8_MP = "";
			this.m_r9_BType = "";
			this.m_rb_BankId = "";
			this.m_ro_BankOrderId = "";
			this.m_rp_PayDate = "";
			this.m_rq_CardNo = "";
			this.m_ru_Trxtime = "";
			this.m_hmac = "";
			this.m_collectDate = DateTime.Now;
		}
	}
}
