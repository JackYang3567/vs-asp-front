using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class LotteryConfig
	{
		public const string Tablename = "LotteryConfig";
		public const string _ID = "ID";
		public const string _FreeCount = "FreeCount";
		public const string _ChargeFee = "ChargeFee";
		public const string _IsCharge = "IsCharge";
		private int m_iD;
		private int m_freeCount;
		private int m_chargeFee;
		private byte m_isCharge;
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
		public int FreeCount
		{
			get
			{
				return this.m_freeCount;
			}
			set
			{
				this.m_freeCount = value;
			}
		}
		public int ChargeFee
		{
			get
			{
				return this.m_chargeFee;
			}
			set
			{
				this.m_chargeFee = value;
			}
		}
		public byte IsCharge
		{
			get
			{
				return this.m_isCharge;
			}
			set
			{
				this.m_isCharge = value;
			}
		}
		public LotteryConfig()
		{
			this.m_iD = 0;
			this.m_freeCount = 0;
			this.m_chargeFee = 0;
			this.m_isCharge = 0;
		}
	}
}
