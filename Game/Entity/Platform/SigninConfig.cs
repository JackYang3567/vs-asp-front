using System;
namespace Game.Entity.Platform
{
	[Serializable]
	public class SigninConfig
	{
		public const string Tablename = "SigninConfig";
		public const string _DayID = "DayID";
		public const string _RewardGold = "RewardGold";
		private int m_dayID;
		private long m_rewardGold;
		public int DayID
		{
			get
			{
				return this.m_dayID;
			}
			set
			{
				this.m_dayID = value;
			}
		}
		public long RewardGold
		{
			get
			{
				return this.m_rewardGold;
			}
			set
			{
				this.m_rewardGold = value;
			}
		}
		public SigninConfig()
		{
			this.m_dayID = 0;
			this.m_rewardGold = 0L;
		}
	}
}
