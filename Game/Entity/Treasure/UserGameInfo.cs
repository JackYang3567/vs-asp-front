using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class UserGameInfo
	{
		public const string Tablename = "UserGameData";
		public const string _UserID = "UserID";
		public const string _KindID = "KindID";
		public const string _UserGameData = "UserGameData";
		public const string _LineGrandTotal = "LineGrandTotal";
		public const string _LineWinMax = "LineWinMax";
		public const string _LastModifyDate = "LastModifyDate";
		private int m_userID;
		private int m_kindID;
		private string m_userGameData;
		private int m_lineGrandTotal;
		private int m_lineWinMax;
		private DateTime m_lastModifyDate;
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
		public string UserGameData
		{
			get
			{
				return this.m_userGameData;
			}
			set
			{
				this.m_userGameData = value;
			}
		}
		public int LineGrandTotal
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
		public int LineWinMax
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
		public UserGameInfo()
		{
			this.m_userID = 0;
			this.m_kindID = 0;
			this.m_userGameData = "";
			this.m_lineGrandTotal = 0;
			this.m_lineWinMax = 0;
			this.m_lastModifyDate = DateTime.Now;
		}
	}
}
