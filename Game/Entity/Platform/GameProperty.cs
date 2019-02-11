using System;
namespace Game.Entity.Platform
{
	[Serializable]
	public class GameProperty
	{
		public const string Tablename = "GameProperty";
		public const string _ID = "ID";
		public const string _Name = "Name";
		public const string _Kind = "Kind";
		public const string _PTypeID = "PTypeID";
		public const string _MTypeID = "MTypeID";
		public const string _Cash = "Cash";
		public const string _Gold = "Gold";
		public const string _UserMedal = "UserMedal";
		public const string _LoveLiness = "LoveLiness";
		public const string _UseArea = "UseArea";
		public const string _ServiceArea = "ServiceArea";
		public const string _SuportMobile = "SuportMobile";
		public const string _RegulationsInfo = "RegulationsInfo";
		public const string _SendLoveLiness = "SendLoveLiness";
		public const string _RecvLoveLiness = "RecvLoveLiness";
		public const string _UseResultsGold = "UseResultsGold";
		public const string _UseResultsValidTime = "UseResultsValidTime";
		public const string _UseResultsValidTimeScoreMultiple = "UseResultsValidTimeScoreMultiple";
		public const string _UseResultsGiftPackage = "UseResultsGiftPackage";
		public const string _Recommend = "Recommend";
		public const string _Nullity = "Nullity";
		private int m_iD;
		private string m_name;
		private int m_kind;
		private int m_pTypeID;
		private int m_mTypeID;
		private decimal m_cash;
		private long m_gold;
		private int m_userMedal;
		private int m_loveLiness;
		private short m_useArea;
		private short m_serviceArea;
		private byte m_suportMobile;
		private string m_regulationsInfo;
		private long m_sendLoveLiness;
		private long m_recvLoveLiness;
		private long m_useResultsGold;
		private long m_useResultsValidTime;
		private int m_useResultsValidTimeScoreMultiple;
		private int m_useResultsGiftPackage;
		private int m_recommend;
		private byte m_nullity;
		public int ID
		{
			get
			{
				return this.m_iD;
			}
			set
			{
				this.m_iD = value;
			}
		}
		public string Name
		{
			get
			{
				return this.m_name;
			}
			set
			{
				this.m_name = value;
			}
		}
		public int Kind
		{
			get
			{
				return this.m_kind;
			}
			set
			{
				this.m_kind = value;
			}
		}
		public int PTypeID
		{
			get
			{
				return this.m_pTypeID;
			}
			set
			{
				this.m_pTypeID = value;
			}
		}
		public int MTypeID
		{
			get
			{
				return this.m_mTypeID;
			}
			set
			{
				this.m_mTypeID = value;
			}
		}
		public decimal Cash
		{
			get
			{
				return this.m_cash;
			}
			set
			{
				this.m_cash = value;
			}
		}
		public long Gold
		{
			get
			{
				return this.m_gold;
			}
			set
			{
				this.m_gold = value;
			}
		}
		public int UserMedal
		{
			get
			{
				return this.m_userMedal;
			}
			set
			{
				this.m_userMedal = value;
			}
		}
		public int LoveLiness
		{
			get
			{
				return this.m_loveLiness;
			}
			set
			{
				this.m_loveLiness = value;
			}
		}
		public short UseArea
		{
			get
			{
				return this.m_useArea;
			}
			set
			{
				this.m_useArea = value;
			}
		}
		public short ServiceArea
		{
			get
			{
				return this.m_serviceArea;
			}
			set
			{
				this.m_serviceArea = value;
			}
		}
		public byte SuportMobile
		{
			get
			{
				return this.m_suportMobile;
			}
			set
			{
				this.m_suportMobile = value;
			}
		}
		public string RegulationsInfo
		{
			get
			{
				return this.m_regulationsInfo;
			}
			set
			{
				this.m_regulationsInfo = value;
			}
		}
		public long SendLoveLiness
		{
			get
			{
				return this.m_sendLoveLiness;
			}
			set
			{
				this.m_sendLoveLiness = value;
			}
		}
		public long RecvLoveLiness
		{
			get
			{
				return this.m_recvLoveLiness;
			}
			set
			{
				this.m_recvLoveLiness = value;
			}
		}
		public long UseResultsGold
		{
			get
			{
				return this.m_useResultsGold;
			}
			set
			{
				this.m_useResultsGold = value;
			}
		}
		public long UseResultsValidTime
		{
			get
			{
				return this.m_useResultsValidTime;
			}
			set
			{
				this.m_useResultsValidTime = value;
			}
		}
		public int UseResultsValidTimeScoreMultiple
		{
			get
			{
				return this.m_useResultsValidTimeScoreMultiple;
			}
			set
			{
				this.m_useResultsValidTimeScoreMultiple = value;
			}
		}
		public int UseResultsGiftPackage
		{
			get
			{
				return this.m_useResultsGiftPackage;
			}
			set
			{
				this.m_useResultsGiftPackage = value;
			}
		}
		public int Recommend
		{
			get
			{
				return this.m_recommend;
			}
			set
			{
				this.m_recommend = value;
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
		public GameProperty()
		{
			this.m_iD = 0;
			this.m_name = "";
			this.m_kind = 0;
			this.m_pTypeID = 0;
			this.m_mTypeID = 0;
			this.m_cash = 0m;
			this.m_gold = 0L;
			this.m_userMedal = 0;
			this.m_loveLiness = 0;
			this.m_useArea = 0;
			this.m_serviceArea = 0;
			this.m_suportMobile = 0;
			this.m_regulationsInfo = "";
			this.m_sendLoveLiness = 0L;
			this.m_recvLoveLiness = 0L;
			this.m_useResultsGold = 0L;
			this.m_useResultsValidTime = 0L;
			this.m_useResultsValidTimeScoreMultiple = 0;
			this.m_useResultsGiftPackage = 0;
			this.m_recommend = 0;
			this.m_nullity = 0;
		}
	}
}
