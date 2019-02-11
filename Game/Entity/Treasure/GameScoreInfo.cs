using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class GameScoreInfo
	{
		public const string Tablename = "GameScoreInfo";
		public const string _UserID = "UserID";
		public const string _Score = "Score";
		public const string _Revenue = "Revenue";
		public const string _InsureScore = "InsureScore";
		public const string _WinCount = "WinCount";
		public const string _LostCount = "LostCount";
		public const string _DrawCount = "DrawCount";
		public const string _FleeCount = "FleeCount";
		public const string _UserRight = "UserRight";
		public const string _MasterRight = "MasterRight";
		public const string _MasterOrder = "MasterOrder";
		public const string _AllLogonTimes = "AllLogonTimes";
		public const string _PlayTimeCount = "PlayTimeCount";
		public const string _OnLineTimeCount = "OnLineTimeCount";
		public const string _LastLogonIP = "LastLogonIP";
		public const string _LastLogonDate = "LastLogonDate";
		public const string _LastLogonMachine = "LastLogonMachine";
		public const string _RegisterIP = "RegisterIP";
		public const string _RegisterDate = "RegisterDate";
		public const string _RegisterMachine = "RegisterMachine";
		private int m_userID;
		private decimal m_score;
		private decimal m_revenue;
		private decimal m_insureScore;
		private int m_winCount;
		private int m_lostCount;
		private int m_drawCount;
		private int m_fleeCount;
		private int m_userRight;
		private int m_masterRight;
		private byte m_masterOrder;
		private int m_allLogonTimes;
		private int m_playTimeCount;
		private int m_onLineTimeCount;
		private string m_lastLogonIP;
		private DateTime m_lastLogonDate;
		private string m_lastLogonMachine;
		private string m_registerIP;
		private DateTime m_registerDate;
		private string m_registerMachine;
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
		public decimal Score
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
		public decimal InsureScore
		{
			get
			{
				return this.m_insureScore;
			}
			set
			{
				this.m_insureScore = value;
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
		public int UserRight
		{
			get
			{
				return this.m_userRight;
			}
			set
			{
				this.m_userRight = value;
			}
		}
		public int MasterRight
		{
			get
			{
				return this.m_masterRight;
			}
			set
			{
				this.m_masterRight = value;
			}
		}
		public byte MasterOrder
		{
			get
			{
				return this.m_masterOrder;
			}
			set
			{
				this.m_masterOrder = value;
			}
		}
		public int AllLogonTimes
		{
			get
			{
				return this.m_allLogonTimes;
			}
			set
			{
				this.m_allLogonTimes = value;
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
		public string LastLogonIP
		{
			get
			{
				return this.m_lastLogonIP;
			}
			set
			{
				this.m_lastLogonIP = value;
			}
		}
		public DateTime LastLogonDate
		{
			get
			{
				return this.m_lastLogonDate;
			}
			set
			{
				this.m_lastLogonDate = value;
			}
		}
		public string LastLogonMachine
		{
			get
			{
				return this.m_lastLogonMachine;
			}
			set
			{
				this.m_lastLogonMachine = value;
			}
		}
		public string RegisterIP
		{
			get
			{
				return this.m_registerIP;
			}
			set
			{
				this.m_registerIP = value;
			}
		}
		public DateTime RegisterDate
		{
			get
			{
				return this.m_registerDate;
			}
			set
			{
				this.m_registerDate = value;
			}
		}
		public string RegisterMachine
		{
			get
			{
				return this.m_registerMachine;
			}
			set
			{
				this.m_registerMachine = value;
			}
		}
		public GameScoreInfo()
		{
			this.m_userID = 0;
			this.m_score = 0m;
			this.m_revenue = 0m;
			this.m_insureScore = 0m;
			this.m_winCount = 0;
			this.m_lostCount = 0;
			this.m_drawCount = 0;
			this.m_fleeCount = 0;
			this.m_userRight = 0;
			this.m_masterRight = 0;
			this.m_masterOrder = 0;
			this.m_allLogonTimes = 0;
			this.m_playTimeCount = 0;
			this.m_onLineTimeCount = 0;
			this.m_lastLogonIP = "";
			this.m_lastLogonDate = DateTime.Now;
			this.m_lastLogonMachine = "";
			this.m_registerIP = "";
			this.m_registerDate = DateTime.Now;
			this.m_registerMachine = "";
		}
	}
}
