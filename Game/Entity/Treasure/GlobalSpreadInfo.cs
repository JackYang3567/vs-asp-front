using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class GlobalSpreadInfo
	{
		public const string Tablename = "GlobalSpreadInfo";
		public const string _ID = "ID";
		public const string _RegisterGrantScore = "RegisterGrantScore";
		public const string _PlayTimeCount = "PlayTimeCount";
		public const string _PlayTimeGrantScore = "PlayTimeGrantScore";
		public const string _FillGrantRate = "FillGrantRate";
		public const string _BalanceRate = "BalanceRate";
		public const string _MinBalanceScore = "MinBalanceScore";
		private int m_iD;
		private int m_registerGrantScore;
		private int m_playTimeCount;
		private int m_playTimeGrantScore;
		private decimal m_fillGrantRate;
		private decimal m_balanceRate;
		private int m_minBalanceScore;
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
		public int RegisterGrantScore
		{
			get
			{
				return this.m_registerGrantScore;
			}
			set
			{
				this.m_registerGrantScore = value;
			}
		}
		public int PlayTimeCount
		{
			get
			{
				return this.m_playTimeCount;
			}
			set
			{
				this.m_playTimeCount = value;
			}
		}
		public int PlayTimeGrantScore
		{
			get
			{
				return this.m_playTimeGrantScore;
			}
			set
			{
				this.m_playTimeGrantScore = value;
			}
		}
		public decimal FillGrantRate
		{
			get
			{
				return this.m_fillGrantRate;
			}
			set
			{
				this.m_fillGrantRate = value;
			}
		}
		public decimal BalanceRate
		{
			get
			{
				return this.m_balanceRate;
			}
			set
			{
				this.m_balanceRate = value;
			}
		}
		public int MinBalanceScore
		{
			get
			{
				return this.m_minBalanceScore;
			}
			set
			{
				this.m_minBalanceScore = value;
			}
		}
		public GlobalSpreadInfo()
		{
			this.m_iD = 0;
			this.m_registerGrantScore = 0;
			this.m_playTimeCount = 0;
			this.m_playTimeGrantScore = 0;
			this.m_fillGrantRate = 0m;
			this.m_balanceRate = 0m;
			this.m_minBalanceScore = 0;
		}
	}
}
