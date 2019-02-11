using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class ReturnVBDetailInfo
	{
		public const string Tablename = "ReturnVBDetailInfo";
		public const string _DetailID = "DetailID";
		public const string _OperStationID = "OperStationID";
		public const string _Rtmd5 = "Rtmd5";
		public const string _Rtka = "Rtka";
		public const string _Rtmi = "Rtmi";
		public const string _Rtmz = "Rtmz";
		public const string _Rtlx = "Rtlx";
		public const string _Rtoid = "Rtoid";
		public const string _OrderID = "OrderID";
		public const string _Rtuserid = "Rtuserid";
		public const string _Rtcustom = "Rtcustom";
		public const string _Rtflag = "Rtflag";
		public const string _EcryptStr = "EcryptStr";
		public const string _SignMsg = "SignMsg";
		public const string _CollectDate = "CollectDate";
		private int m_detailID;
		private int m_operStationID;
		private string m_rtmd5;
		private string m_rtka;
		private string m_rtmi;
		private int m_rtmz;
		private int m_rtlx;
		private string m_rtoid;
		private string m_orderID;
		private string m_rtuserid;
		private string m_rtcustom;
		private int m_rtflag;
		private string m_ecryptStr;
		private string m_signMsg;
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
		public int OperStationID
		{
			get
			{
				return this.m_operStationID;
			}
			set
			{
				this.m_operStationID = value;
			}
		}
		public string Rtmd5
		{
			get
			{
				return this.m_rtmd5;
			}
			set
			{
				this.m_rtmd5 = value;
			}
		}
		public string Rtka
		{
			get
			{
				return this.m_rtka;
			}
			set
			{
				this.m_rtka = value;
			}
		}
		public string Rtmi
		{
			get
			{
				return this.m_rtmi;
			}
			set
			{
				this.m_rtmi = value;
			}
		}
		public int Rtmz
		{
			get
			{
				return this.m_rtmz;
			}
			set
			{
				this.m_rtmz = value;
			}
		}
		public int Rtlx
		{
			get
			{
				return this.m_rtlx;
			}
			set
			{
				this.m_rtlx = value;
			}
		}
		public string Rtoid
		{
			get
			{
				return this.m_rtoid;
			}
			set
			{
				this.m_rtoid = value;
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
		public string Rtuserid
		{
			get
			{
				return this.m_rtuserid;
			}
			set
			{
				this.m_rtuserid = value;
			}
		}
		public string Rtcustom
		{
			get
			{
				return this.m_rtcustom;
			}
			set
			{
				this.m_rtcustom = value;
			}
		}
		public int Rtflag
		{
			get
			{
				return this.m_rtflag;
			}
			set
			{
				this.m_rtflag = value;
			}
		}
		public string EcryptStr
		{
			get
			{
				return this.m_ecryptStr;
			}
			set
			{
				this.m_ecryptStr = value;
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
		public ReturnVBDetailInfo()
		{
			this.m_detailID = 0;
			this.m_operStationID = 0;
			this.m_rtmd5 = "";
			this.m_rtka = "";
			this.m_rtmi = "";
			this.m_rtmz = 0;
			this.m_rtlx = 0;
			this.m_rtoid = "";
			this.m_orderID = "";
			this.m_rtuserid = "";
			this.m_rtcustom = "";
			this.m_rtflag = 0;
			this.m_ecryptStr = "";
			this.m_signMsg = "";
			this.m_collectDate = DateTime.Now;
		}
	}
}
