using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class LotteryReturn
	{
		private int m_wined;
		private int m_itemIndex;
		private int m_itemType;
		private int m_itemQuota;
		private long m_score;
		private decimal m_currency;
		public int Wined
		{
			get
			{
				return this.m_wined;
			}
			set
			{
				this.m_wined = value;
			}
		}
		public int ItemIndex
		{
			get
			{
				return this.m_itemIndex;
			}
			set
			{
				this.m_itemIndex = value;
			}
		}
		public int ItemType
		{
			get
			{
				return this.m_itemType;
			}
			set
			{
				this.m_itemType = value;
			}
		}
		public int ItemQuota
		{
			get
			{
				return this.m_itemQuota;
			}
			set
			{
				this.m_itemQuota = value;
			}
		}
		public long Score
		{
			get
			{
				return this.m_score;
			}
			set
			{
				this.m_score = value;
			}
		}
		public decimal Currency
		{
			get
			{
				return this.m_currency;
			}
			set
			{
				this.m_currency = value;
			}
		}
		public LotteryReturn()
		{
			this.m_wined = 0;
			this.m_itemIndex = 0;
			this.m_itemType = 0;
			this.m_itemQuota = 0;
			this.m_score = 0L;
			this.m_currency = 0m;
		}
	}
}
