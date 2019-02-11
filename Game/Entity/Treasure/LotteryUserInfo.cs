using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class LotteryUserInfo
	{
		private int m_freeCount;
		private int m_chargeFee;
		private int m_alreadyCount;
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
		public int AlreadyCount
		{
			get
			{
				return this.m_alreadyCount;
			}
			set
			{
				this.m_alreadyCount = value;
			}
		}
		public LotteryUserInfo()
		{
			this.m_freeCount = 0;
			this.m_chargeFee = 0;
			this.m_alreadyCount = 0;
		}
	}
}
