using System;
namespace Game.Entity.GameMatch
{
	[Serializable]
	public class RecordUserInout
	{
		public const string Tablename = "RecordUserInout";
		public const string _ID = "ID";
		public const string _UserID = "UserID";
		public const string _KindID = "KindID";
		public const string _ServerID = "ServerID";
		public const string _EnterTime = "EnterTime";
		public const string _EnterScore = "EnterScore";
		public const string _EnterInsure = "EnterInsure";
		public const string _EnterUserMedal = "EnterUserMedal";
		public const string _EnterLoveliness = "EnterLoveliness";
		public const string _EnterMachine = "EnterMachine";
		public const string _EnterClientIP = "EnterClientIP";
		public const string _LeaveTime = "LeaveTime";
		public const string _LeaveReason = "LeaveReason";
		public const string _LeaveMachine = "LeaveMachine";
		public const string _LeaveClientIP = "LeaveClientIP";
		public const string _Score = "Score";
		public const string _Insure = "Insure";
		public const string _Revenue = "Revenue";
		public const string _WinCount = "WinCount";
		public const string _LostCount = "LostCount";
		public const string _DrawCount = "DrawCount";
		public const string _FleeCount = "FleeCount";
		public const string _UserMedal = "UserMedal";
		public const string _LoveLiness = "LoveLiness";
		public const string _Experience = "Experience";
		public const string _PlayTimeCount = "PlayTimeCount";
		public const string _OnLineTimeCount = "OnLineTimeCount";
		private int m_iD;
		private int m_userID;
		private int m_kindID;
		private int m_serverID;
		private DateTime m_enterTime;
		private long m_enterScore;
		private long m_enterInsure;
		private int m_enterUserMedal;
		private int m_enterLoveliness;
		private string m_enterMachine;
		private string m_enterClientIP;
		private DateTime m_leaveTime;
		private int m_leaveReason;
		private string m_leaveMachine;
		private string m_leaveClientIP;
		private long m_score;
		private long m_insure;
		private long m_revenue;
		private int m_winCount;
		private int m_lostCount;
		private int m_drawCount;
		private int m_fleeCount;
		private int m_userMedal;
		private int m_loveLiness;
		private int m_experience;
		private int m_playTimeCount;
		private int m_onLineTimeCount;
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
		public int ServerID
		{
			get
			{
				return this.m_serverID;
			}
			set
			{
				this.m_serverID = value;
			}
		}
		public DateTime EnterTime
		{
			get
			{
				return this.m_enterTime;
			}
			set
			{
				this.m_enterTime = value;
			}
		}
		public long EnterScore
		{
			get
			{
				return this.m_enterScore;
			}
			set
			{
				this.m_enterScore = value;
			}
		}
		public long EnterInsure
		{
			get
			{
				return this.m_enterInsure;
			}
			set
			{
				this.m_enterInsure = value;
			}
		}
		public int EnterUserMedal
		{
			get
			{
				return this.m_enterUserMedal;
			}
			set
			{
				this.m_enterUserMedal = value;
			}
		}
		public int EnterLoveliness
		{
			get
			{
				return this.m_enterLoveliness;
			}
			set
			{
				this.m_enterLoveliness = value;
			}
		}
		public string EnterMachine
		{
			get
			{
				return this.m_enterMachine;
			}
			set
			{
				this.m_enterMachine = value;
			}
		}
		public string EnterClientIP
		{
			get
			{
				return this.m_enterClientIP;
			}
			set
			{
				this.m_enterClientIP = value;
			}
		}
		public DateTime LeaveTime
		{
			get
			{
				return this.m_leaveTime;
			}
			set
			{
				this.m_leaveTime = value;
			}
		}
		public int LeaveReason
		{
			get
			{
				return this.m_leaveReason;
			}
			set
			{
				this.m_leaveReason = value;
			}
		}
		public string LeaveMachine
		{
			get
			{
				return this.m_leaveMachine;
			}
			set
			{
				this.m_leaveMachine = value;
			}
		}
		public string LeaveClientIP
		{
			get
			{
				return this.m_leaveClientIP;
			}
			set
			{
				this.m_leaveClientIP = value;
			}
		}
		public long Score
		{
			get
			{
				return this.m_score;
			}
			set
			{
				this.m_score = value;
			}
		}
		public long Insure
		{
			get
			{
				return this.m_insure;
			}
			set
			{
				this.m_insure = value;
			}
		}
		public long Revenue
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
		public int DrawCount
		{
			get
			{
				return this.m_drawCount;
			}
			set
			{
				this.m_drawCount = value;
			}
		}
		public int FleeCount
		{
			get
			{
				return this.m_fleeCount;
			}
			set
			{
				this.m_fleeCount = value;
			}
		}
		public int UserMedal
		{
			get
			{
				return this.m_userMedal;
			}
			set
			{
				this.m_userMedal = value;
			}
		}
		public int LoveLiness
		{
			get
			{
				return this.m_loveLiness;
			}
			set
			{
				this.m_loveLiness = value;
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
		public RecordUserInout()
		{
			this.m_iD = 0;
			this.m_userID = 0;
			this.m_kindID = 0;
			this.m_serverID = 0;
			this.m_enterTime = DateTime.Now;
			this.m_enterScore = 0L;
			this.m_enterInsure = 0L;
			this.m_enterUserMedal = 0;
			this.m_enterLoveliness = 0;
			this.m_enterMachine = "";
			this.m_enterClientIP = "";
			this.m_leaveTime = DateTime.Now;
			this.m_leaveReason = 0;
			this.m_leaveMachine = "";
			this.m_leaveClientIP = "";
			this.m_score = 0L;
			this.m_insure = 0L;
			this.m_revenue = 0L;
			this.m_winCount = 0;
			this.m_lostCount = 0;
			this.m_drawCount = 0;
			this.m_fleeCount = 0;
			this.m_userMedal = 0;
			this.m_loveLiness = 0;
			this.m_experience = 0;
			this.m_playTimeCount = 0;
			this.m_onLineTimeCount = 0;
		}
	}
}
