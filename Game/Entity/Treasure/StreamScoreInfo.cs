using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class StreamScoreInfo
	{
		public const string Tablename = "StreamScoreInfo";
		public const string _DateID = "DateID";
		public const string _UserID = "UserID";
		public const string _WinCount = "WinCount";
		public const string _LostCount = "LostCount";
		public const string _Revenue = "Revenue";
		public const string _PlayTimeCount = "PlayTimeCount";
		public const string _OnlineTimeCount = "OnlineTimeCount";
		public const string _FirstCollectDate = "FirstCollectDate";
		public const string _LastCollectDate = "LastCollectDate";
		private int m_dateID;
		private int m_userID;
		private int m_winCount;
		private int m_lostCount;
		private decimal m_revenue;
		private int m_playTimeCount;
		private int m_onlineTimeCount;
		private DateTime m_firstCollectDate;
		private DateTime m_lastCollectDate;
		public int DateID
		{
			get
			{
				return this.m_dateID;
			}
			set
			{
				this.m_dateID = value;
			}
		}
		public int UserID
		{
			get
			{
				return this.m_userID;
			}
			set
			{
				this.m_userID = value;
			}
		}
		public int WinCount
		{
			get
			{
				return this.m_winCount;
			}
			set
			{
				this.m_winCount = value;
			}
		}
		public int LostCount
		{
			get
			{
				return this.m_lostCount;
			}
			set
			{
				this.m_lostCount = value;
			}
		}
		public decimal Revenue
		{
			get
			{
				return this.m_revenue;
			}
			set
			{
				this.m_revenue = value;
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
		public int OnlineTimeCount
		{
			get
			{
				return this.m_onlineTimeCount;
			}
			set
			{
				this.m_onlineTimeCount = value;
			}
		}
		public DateTime FirstCollectDate
		{
			get
			{
				return this.m_firstCollectDate;
			}
			set
			{
				this.m_firstCollectDate = value;
			}
		}
		public DateTime LastCollectDate
		{
			get
			{
				return this.m_lastCollectDate;
			}
			set
			{
				this.m_lastCollectDate = value;
			}
		}
		public StreamScoreInfo()
		{
			this.m_dateID = 0;
			this.m_userID = 0;
			this.m_winCount = 0;
			this.m_lostCount = 0;
			this.m_revenue = 0m;
			this.m_playTimeCount = 0;
			this.m_onlineTimeCount = 0;
			this.m_firstCollectDate = DateTime.Now;
			this.m_lastCollectDate = DateTime.Now;
		}
	}
}
