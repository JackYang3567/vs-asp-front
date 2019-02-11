using System;
namespace Game.Entity.Accounts
{
	[Serializable]
	public class AccountsSignin
	{
		public const string Tablename = "AccountsSignin";
		public const string _UserID = "UserID";
		public const string _StartDateTime = "StartDateTime";
		public const string _LastDateTime = "LastDateTime";
		public const string _SeriesDate = "SeriesDate";
		private int m_userID;
		private DateTime m_startDateTime;
		private DateTime m_lastDateTime;
		private short m_seriesDate;
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
		public DateTime StartDateTime
		{
			get
			{
				return this.m_startDateTime;
			}
			set
			{
				this.m_startDateTime = value;
			}
		}
		public DateTime LastDateTime
		{
			get
			{
				return this.m_lastDateTime;
			}
			set
			{
				this.m_lastDateTime = value;
			}
		}
		public short SeriesDate
		{
			get
			{
				return this.m_seriesDate;
			}
			set
			{
				this.m_seriesDate = value;
			}
		}
		public AccountsSignin()
		{
			this.m_userID = 0;
			this.m_startDateTime = DateTime.Now;
			this.m_lastDateTime = DateTime.Now;
			this.m_seriesDate = 0;
		}
	}
}
