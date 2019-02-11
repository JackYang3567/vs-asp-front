using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class LotteryItem
	{
		public const string Tablename = "LotteryItem";
		public const string _ItemIndex = "ItemIndex";
		public const string _ItemType = "ItemType";
		public const string _ItemQuota = "ItemQuota";
		private int m_itemIndex;
		private int m_itemType;
		private int m_itemQuota;
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
		public LotteryItem()
		{
			this.m_itemIndex = 0;
			this.m_itemType = 0;
			this.m_itemQuota = 0;
		}
	}
}
