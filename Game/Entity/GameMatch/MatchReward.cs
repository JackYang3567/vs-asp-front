using System;
namespace Game.Entity.GameMatch
{
	[Serializable]
	public class MatchReward
	{
		public const string Tablename = "MatchReward";
		public const string _MatchID = "MatchID";
		public const string _MatchRank = "MatchRank";
		public const string _RewardGold = "RewardGold";
		public const string _RewardIngot = "RewardIngot";
		public const string _RewardExperience = "RewardExperience";
		public const string _RewardDescibe = "RewardDescibe";
		private int m_matchID;
		private short m_matchRank;
		private long m_rewardGold;
		private long m_rewardIngot;
		private long m_rewardExperience;
		private string m_rewardDescibe;
		public int MatchID
		{
			get
			{
				return this.m_matchID;
			}
			set
			{
				this.m_matchID = value;
			}
		}
		public short MatchRank
		{
			get
			{
				return this.m_matchRank;
			}
			set
			{
				this.m_matchRank = value;
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
		public long RewardIngot
		{
			get
			{
				return this.m_rewardIngot;
			}
			set
			{
				this.m_rewardIngot = value;
			}
		}
		public long RewardExperience
		{
			get
			{
				return this.m_rewardExperience;
			}
			set
			{
				this.m_rewardExperience = value;
			}
		}
		public string RewardDescibe
		{
			get
			{
				return this.m_rewardDescibe;
			}
			set
			{
				this.m_rewardDescibe = value;
			}
		}
		public MatchReward()
		{
			this.m_matchID = 0;
			this.m_matchRank = 0;
			this.m_rewardGold = 0L;
			this.m_rewardIngot = 0L;
			this.m_rewardExperience = 0L;
			this.m_rewardDescibe = "";
		}
	}
}
