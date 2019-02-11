using System;
namespace Game.Entity.NativeWeb
{
	[Serializable]
	public class GameMatchInfo
	{
		public const string Tablename = "GameMatchInfo";
		public const string _MatchID = "MatchID";
		public const string _MatchTitle = "MatchTitle";
		public const string _ImageUrl = "ImageUrl";
		public const string _MatchSummary = "MatchSummary";
		public const string _MatchContent = "MatchContent";
		public const string _ApplyBeginDate = "ApplyBeginDate";
		public const string _ApplyEndDate = "ApplyEndDate";
		public const string _MatchStatus = "MatchStatus";
		public const string _Nullity = "Nullity";
		public const string _CollectDate = "CollectDate";
		public const string _ModifyDate = "ModifyDate";
		private int m_matchID;
		private string m_matchTitle;
		private string m_imageUrl;
		private string m_matchSummary;
		private string m_matchContent;
		private DateTime m_applyBeginDate;
		private DateTime m_applyEndDate;
		private int m_matchStatus;
		private byte m_nullity;
		private DateTime m_collectDate;
		private DateTime m_modifyDate;
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
		public string MatchTitle
		{
			get
			{
				return this.m_matchTitle;
			}
			set
			{
				this.m_matchTitle = value;
			}
		}
		public string ImageUrl
		{
			get
			{
				return this.m_imageUrl;
			}
			set
			{
				this.m_imageUrl = value;
			}
		}
		public string MatchSummary
		{
			get
			{
				return this.m_matchSummary;
			}
			set
			{
				this.m_matchSummary = value;
			}
		}
		public string MatchContent
		{
			get
			{
				return this.m_matchContent;
			}
			set
			{
				this.m_matchContent = value;
			}
		}
		public DateTime ApplyBeginDate
		{
			get
			{
				return this.m_applyBeginDate;
			}
			set
			{
				this.m_applyBeginDate = value;
			}
		}
		public DateTime ApplyEndDate
		{
			get
			{
				return this.m_applyEndDate;
			}
			set
			{
				this.m_applyEndDate = value;
			}
		}
		public int MatchStatus
		{
			get
			{
				return this.m_matchStatus;
			}
			set
			{
				this.m_matchStatus = value;
			}
		}
		public byte Nullity
		{
			get
			{
				return this.m_nullity;
			}
			set
			{
				this.m_nullity = value;
			}
		}
		public DateTime CollectDate
		{
			get
			{
				return this.m_collectDate;
			}
			set
			{
				this.m_collectDate = value;
			}
		}
		public DateTime ModifyDate
		{
			get
			{
				return this.m_modifyDate;
			}
			set
			{
				this.m_modifyDate = value;
			}
		}
		public GameMatchInfo()
		{
			this.m_matchID = 0;
			this.m_matchTitle = "";
			this.m_imageUrl = "";
			this.m_matchSummary = "";
			this.m_matchContent = "";
			this.m_applyBeginDate = DateTime.Now;
			this.m_applyEndDate = DateTime.Now;
			this.m_matchStatus = 0;
			this.m_nullity = 0;
			this.m_collectDate = DateTime.Now;
			this.m_modifyDate = DateTime.Now;
		}
	}
}
