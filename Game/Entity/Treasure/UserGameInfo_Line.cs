using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class UserGameInfo_Line
	{
		public const string Tablename = "UserGameInfo_Line";
		public const string _DateID = "DateID";
		public const string _KindID = "KindID";
		public const string _UserID = "UserID";
		public const string _LineGrandTotal = "LineGrandTotal";
		public const string _LineWinMax = "LineWinMax";
		public const string _LastModifyDate = "LastModifyDate";
		private int m_dateID;
		private int m_kindID;
		private int m_userID;
		private long m_lineGrandTotal;
		private long m_lineWinMax;
		private DateTime m_lastModifyDate;
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
		public int KindID
		{
			get
			{
				return this.m_kindID;
			}
			set
			{
				this.m_kindID = value;
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
		public long LineGrandTotal
		{
			get
			{
				return this.m_lineGrandTotal;
			}
			set
			{
				this.m_lineGrandTotal = value;
			}
		}
		public long LineWinMax
		{
			get
			{
				return this.m_lineWinMax;
			}
			set
			{
				this.m_lineWinMax = value;
			}
		}
		public DateTime LastModifyDate
		{
			get
			{
				return this.m_lastModifyDate;
			}
			set
			{
				this.m_lastModifyDate = value;
			}
		}
		public UserGameInfo_Line()
		{
			this.m_dateID = 0;
			this.m_kindID = 0;
			this.m_userID = 0;
			this.m_lineGrandTotal = 0L;
			this.m_lineWinMax = 0L;
			this.m_lastModifyDate = DateTime.Now;
		}
	}
}
