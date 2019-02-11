using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class StreamPlayPresent
	{
		public const string Tablename = "StreamPlayPresent";
		public const string _DateID = "DateID";
		public const string _UserID = "UserID";
		public const string _PresentCount = "PresentCount";
		public const string _PresentScore = "PresentScore";
		public const string _PlayTimeCount = "PlayTimeCount";
		public const string _OnLineTimeCount = "OnLineTimeCount";
		public const string _FirstDate = "FirstDate";
		public const string _LastDate = "LastDate";
		private int m_dateID;
		private int m_userID;
		private int m_presentCount;
		private int m_presentScore;
		private int m_playTimeCount;
		private int m_onLineTimeCount;
		private DateTime m_firstDate;
		private DateTime m_lastDate;
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
		public int PresentCount
		{
			get
			{
				return this.m_presentCount;
			}
			set
			{
				this.m_presentCount = value;
			}
		}
		public int PresentScore
		{
			get
			{
				return this.m_presentScore;
			}
			set
			{
				this.m_presentScore = value;
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
		public int OnLineTimeCount
		{
			get
			{
				return this.m_onLineTimeCount;
			}
			set
			{
				this.m_onLineTimeCount = value;
			}
		}
		public DateTime FirstDate
		{
			get
			{
				return this.m_firstDate;
			}
			set
			{
				this.m_firstDate = value;
			}
		}
		public DateTime LastDate
		{
			get
			{
				return this.m_lastDate;
			}
			set
			{
				this.m_lastDate = value;
			}
		}
		public StreamPlayPresent()
		{
			this.m_dateID = 0;
			this.m_userID = 0;
			this.m_presentCount = 0;
			this.m_presentScore = 0;
			this.m_playTimeCount = 0;
			this.m_onLineTimeCount = 0;
			this.m_firstDate = DateTime.Now;
			this.m_lastDate = DateTime.Now;
		}
	}
}
