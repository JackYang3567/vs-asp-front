using System;
namespace Game.Entity.GameMatch
{
	[Serializable]
	public class MatchPublic
	{
		public const string Tablename = "MatchPublic";
		public const string _MatchID = "MatchID";
		public const string _MatchStatus = "MatchStatus";
		public const string _KindID = "KindID";
		public const string _MatchName = "MatchName";
		public const string _MatchType = "MatchType";
		public const string _SignupMode = "SignupMode";
		public const string _FeeType = "FeeType";
		public const string _SignupFee = "SignupFee";
		public const string _DeductArea = "DeductArea";
		public const string _JoinCondition = "JoinCondition";
		public const string _MemberOrder = "MemberOrder";
		public const string _Experience = "Experience";
		public const string _FromMatchID = "FromMatchID";
		public const string _FilterType = "FilterType";
		public const string _MaxRankID = "MaxRankID";
		public const string _MatchEndDate = "MatchEndDate";
		public const string _MatchStartDate = "MatchStartDate";
		public const string _RankingMode = "RankingMode";
		public const string _CountInnings = "CountInnings";
		public const string _FilterGradesMode = "FilterGradesMode";
		public const string _DistributeRule = "DistributeRule";
		public const string _MinDistributeUser = "MinDistributeUser";
		public const string _DistributeTimeSpace = "DistributeTimeSpace";
		public const string _MinPartakeGameUser = "MinPartakeGameUser";
		public const string _MaxPartakeGameUser = "MaxPartakeGameUser";
		public const string _MatchRule = "MatchRule";
		public const string _ServiceMachine = "ServiceMachine";
		public const string _Nullity = "Nullity";
		public const string _CollectDate = "CollectDate";
		private int m_matchID;
		private byte m_matchStatus;
		private int m_kindID;
		private string m_matchName;
		private byte m_matchType;
		private byte m_signupMode;
		private byte m_feeType;
		private long m_signupFee;
		private byte m_deductArea;
		private byte m_joinCondition;
		private byte m_memberOrder;
		private int m_experience;
		private int m_fromMatchID;
		private byte m_filterType;
		private short m_maxRankID;
		private DateTime m_matchEndDate;
		private DateTime m_matchStartDate;
		private byte m_rankingMode;
		private short m_countInnings;
		private byte m_filterGradesMode;
		private byte m_distributeRule;
		private short m_minDistributeUser;
		private short m_distributeTimeSpace;
		private short m_minPartakeGameUser;
		private short m_maxPartakeGameUser;
		private string m_matchRule;
		private string m_serviceMachine;
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
		public byte MatchStatus
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
		public byte MatchType
		{
			get
			{
				return this.m_matchType;
			}
			set
			{
				this.m_matchType = value;
			}
		}
		public byte SignupMode
		{
			get
			{
				return this.m_signupMode;
			}
			set
			{
				this.m_signupMode = value;
			}
		}
		public byte FeeType
		{
			get
			{
				return this.m_feeType;
			}
			set
			{
				this.m_feeType = value;
			}
		}
		public long SignupFee
		{
			get
			{
				return this.m_signupFee;
			}
			set
			{
				this.m_signupFee = value;
			}
		}
		public byte DeductArea
		{
			get
			{
				return this.m_deductArea;
			}
			set
			{
				this.m_deductArea = value;
			}
		}
		public byte JoinCondition
		{
			get
			{
				return this.m_joinCondition;
			}
			set
			{
				this.m_joinCondition = value;
			}
		}
		public byte MemberOrder
		{
			get
			{
				return this.m_memberOrder;
			}
			set
			{
				this.m_memberOrder = value;
			}
		}
		public int Experience
		{
			get
			{
				return this.m_experience;
			}
			set
			{
				this.m_experience = value;
			}
		}
		public int FromMatchID
		{
			get
			{
				return this.m_fromMatchID;
			}
			set
			{
				this.m_fromMatchID = value;
			}
		}
		public byte FilterType
		{
			get
			{
				return this.m_filterType;
			}
			set
			{
				this.m_filterType = value;
			}
		}
		public short MaxRankID
		{
			get
			{
				return this.m_maxRankID;
			}
			set
			{
				this.m_maxRankID = value;
			}
		}
		public DateTime MatchEndDate
		{
			get
			{
				return this.m_matchEndDate;
			}
			set
			{
				this.m_matchEndDate = value;
			}
		}
		public DateTime MatchStartDate
		{
			get
			{
				return this.m_matchStartDate;
			}
			set
			{
				this.m_matchStartDate = value;
			}
		}
		public byte RankingMode
		{
			get
			{
				return this.m_rankingMode;
			}
			set
			{
				this.m_rankingMode = value;
			}
		}
		public short CountInnings
		{
			get
			{
				return this.m_countInnings;
			}
			set
			{
				this.m_countInnings = value;
			}
		}
		public byte FilterGradesMode
		{
			get
			{
				return this.m_filterGradesMode;
			}
			set
			{
				this.m_filterGradesMode = value;
			}
		}
		public byte DistributeRule
		{
			get
			{
				return this.m_distributeRule;
			}
			set
			{
				this.m_distributeRule = value;
			}
		}
		public short MinDistributeUser
		{
			get
			{
				return this.m_minDistributeUser;
			}
			set
			{
				this.m_minDistributeUser = value;
			}
		}
		public short DistributeTimeSpace
		{
			get
			{
				return this.m_distributeTimeSpace;
			}
			set
			{
				this.m_distributeTimeSpace = value;
			}
		}
		public short MinPartakeGameUser
		{
			get
			{
				return this.m_minPartakeGameUser;
			}
			set
			{
				this.m_minPartakeGameUser = value;
			}
		}
		public short MaxPartakeGameUser
		{
			get
			{
				return this.m_maxPartakeGameUser;
			}
			set
			{
				this.m_maxPartakeGameUser = value;
			}
		}
		public string MatchRule
		{
			get
			{
				return this.m_matchRule;
			}
			set
			{
				this.m_matchRule = value;
			}
		}
		public string ServiceMachine
		{
			get
			{
				return this.m_serviceMachine;
			}
			set
			{
				this.m_serviceMachine = value;
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
		public MatchPublic()
		{
			this.m_matchID = 0;
			this.m_matchStatus = 0;
			this.m_kindID = 0;
			this.m_matchName = "";
			this.m_matchType = 0;
			this.m_signupMode = 0;
			this.m_feeType = 0;
			this.m_signupFee = 0L;
			this.m_deductArea = 0;
			this.m_joinCondition = 0;
			this.m_memberOrder = 0;
			this.m_experience = 0;
			this.m_fromMatchID = 0;
			this.m_filterType = 0;
			this.m_maxRankID = 0;
			this.m_matchEndDate = DateTime.Now;
			this.m_matchStartDate = DateTime.Now;
			this.m_rankingMode = 0;
			this.m_countInnings = 0;
			this.m_filterGradesMode = 0;
			this.m_distributeRule = 0;
			this.m_minDistributeUser = 0;
			this.m_distributeTimeSpace = 0;
			this.m_minPartakeGameUser = 0;
			this.m_maxPartakeGameUser = 0;
			this.m_matchRule = "";
			this.m_serviceMachine = "";
			this.m_nullity = false;
			this.m_collectDate = DateTime.Now;
		}
	}
}
