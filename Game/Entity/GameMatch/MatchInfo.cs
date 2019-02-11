using System;
namespace Game.Entity.GameMatch
{
	[Serializable]
	public class MatchInfo
	{
		public const string Tablename = "MatchInfo";
		public const string _MatchID = "MatchID";
		public const string _MatchName = "MatchName";
		public const string _MatchDate = "MatchDate";
		public const string _MatchSummary = "MatchSummary";
		public const string _MatchImage = "MatchImage";
		public const string _MatchContent = "MatchContent";
		public const string _SortID = "SortID";
		public const string _Nullity = "Nullity";
		public const string _CollectDate = "CollectDate";
		private int m_matchID;
		private string m_matchName;
		private string m_matchDate;
		private string m_matchSummary;
		private string m_matchImage;
		private string m_matchContent;
		private int m_sortID;
		private bool m_nullity;
		private DateTime m_collectDate;
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
		public string MatchName
		{
			get
			{
				return this.m_matchName;
			}
			set
			{
				this.m_matchName = value;
			}
		}
		public string MatchDate
		{
			get
			{
				return this.m_matchDate;
			}
			set
			{
				this.m_matchDate = value;
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
		public string MatchImage
		{
			get
			{
				return this.m_matchImage;
			}
			set
			{
				this.m_matchImage = value;
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
		public int SortID
		{
			get
			{
				return this.m_sortID;
			}
			set
			{
				this.m_sortID = value;
			}
		}
		public bool Nullity
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
		public MatchInfo()
		{
			this.m_matchID = 0;
			this.m_matchName = "";
			this.m_matchDate = "";
			this.m_matchSummary = "";
			this.m_matchImage = "";
			this.m_matchContent = "";
			this.m_sortID = 0;
			this.m_nullity = false;
			this.m_collectDate = DateTime.Now;
		}
	}
}
