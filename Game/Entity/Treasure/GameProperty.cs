using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class GameProperty
	{
		public const string Tablename = "GameProperty";
		public const string _ID = "ID";
		public const string _Name = "Name";
		public const string _Cash = "Cash";
		public const string _Gold = "Gold";
		public const string _Discount = "Discount";
		public const string _IssueArea = "IssueArea";
		public const string _ServiceArea = "ServiceArea";
		public const string _SendLoveLiness = "SendLoveLiness";
		public const string _RecvLoveLiness = "RecvLoveLiness";
		public const string _RegulationsInfo = "RegulationsInfo";
		public const string _Nullity = "Nullity";
		private int m_iD;
		private string m_name;
		private decimal m_cash;
		private long m_gold;
		private short m_discount;
		private short m_issueArea;
		private short m_serviceArea;
		private long m_sendLoveLiness;
		private long m_recvLoveLiness;
		private string m_regulationsInfo;
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
		public short Discount
		{
			get
			{
				return this.m_discount;
			}
			set
			{
				this.m_discount = value;
			}
		}
		public short IssueArea
		{
			get
			{
				return this.m_issueArea;
			}
			set
			{
				this.m_issueArea = value;
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
			this.m_cash = 0m;
			this.m_gold = 0L;
			this.m_discount = 0;
			this.m_issueArea = 0;
			this.m_serviceArea = 0;
			this.m_sendLoveLiness = 0L;
			this.m_recvLoveLiness = 0L;
			this.m_regulationsInfo = "";
			this.m_nullity = 0;
		}
	}
}
