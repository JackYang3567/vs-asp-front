using System;
namespace Game.Entity.Accounts
{
	[Serializable]
	public class TaskInfo
	{
		public const string Tablename = "TaskInfo";
		public const string _TaskID = "TaskID";
		public const string _TaskName = "TaskName";
		public const string _TaskDescription = "TaskDescription";
		public const string _TaskType = "TaskType";
		public const string _UserType = "UserType";
		public const string _KindID = "KindID";
		public const string _MatchID = "MatchID";
		public const string _Innings = "Innings";
		public const string _StandardAwardGold = "StandardAwardGold";
		public const string _StandardAwardMedal = "StandardAwardMedal";
		public const string _MemberAwardGold = "MemberAwardGold";
		public const string _MemberAwardMedal = "MemberAwardMedal";
		public const string _TimeLimit = "TimeLimit";
		public const string _InputDate = "InputDate";
		private int m_taskID;
		private string m_taskName;
		private string m_taskDescription;
		private int m_taskType;
		private byte m_userType;
		private int m_kindID;
		private int m_matchID;
		private int m_innings;
		private int m_standardAwardGold;
		private int m_standardAwardMedal;
		private int m_memberAwardGold;
		private int m_memberAwardMedal;
		private int m_timeLimit;
		private DateTime m_inputDate;
		public int TaskID
		{
			get
			{
				return this.m_taskID;
			}
			set
			{
				this.m_taskID = value;
			}
		}
		public string TaskName
		{
			get
			{
				return this.m_taskName;
			}
			set
			{
				this.m_taskName = value;
			}
		}
		public string TaskDescription
		{
			get
			{
				return this.m_taskDescription;
			}
			set
			{
				this.m_taskDescription = value;
			}
		}
		public int TaskType
		{
			get
			{
				return this.m_taskType;
			}
			set
			{
				this.m_taskType = value;
			}
		}
		public byte UserType
		{
			get
			{
				return this.m_userType;
			}
			set
			{
				this.m_userType = value;
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
		public int Innings
		{
			get
			{
				return this.m_innings;
			}
			set
			{
				this.m_innings = value;
			}
		}
		public int StandardAwardGold
		{
			get
			{
				return this.m_standardAwardGold;
			}
			set
			{
				this.m_standardAwardGold = value;
			}
		}
		public int StandardAwardMedal
		{
			get
			{
				return this.m_standardAwardMedal;
			}
			set
			{
				this.m_standardAwardMedal = value;
			}
		}
		public int MemberAwardGold
		{
			get
			{
				return this.m_memberAwardGold;
			}
			set
			{
				this.m_memberAwardGold = value;
			}
		}
		public int MemberAwardMedal
		{
			get
			{
				return this.m_memberAwardMedal;
			}
			set
			{
				this.m_memberAwardMedal = value;
			}
		}
		public int TimeLimit
		{
			get
			{
				return this.m_timeLimit;
			}
			set
			{
				this.m_timeLimit = value;
			}
		}
		public DateTime InputDate
		{
			get
			{
				return this.m_inputDate;
			}
			set
			{
				this.m_inputDate = value;
			}
		}
		public TaskInfo()
		{
			this.m_taskID = 0;
			this.m_taskName = "";
			this.m_taskDescription = "";
			this.m_taskType = 0;
			this.m_userType = 0;
			this.m_kindID = 0;
			this.m_matchID = 0;
			this.m_innings = 0;
			this.m_standardAwardGold = 0;
			this.m_standardAwardMedal = 0;
			this.m_memberAwardGold = 0;
			this.m_memberAwardMedal = 0;
			this.m_timeLimit = 0;
			this.m_inputDate = DateTime.Now;
		}
	}
}
