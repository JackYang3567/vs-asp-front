using System;
namespace Game.Entity.Platform
{
	[Serializable]
	public class GameRoomInfo
	{
		public const string Tablename = "GameRoomInfo";
		public const string _ServerID = "ServerID";
		public const string _ServerName = "ServerName";
		public const string _KindID = "KindID";
		public const string _NodeID = "NodeID";
		public const string _SortID = "SortID";
		public const string _GameID = "GameID";
		public const string _TableCount = "TableCount";
		public const string _ServerType = "ServerType";
		public const string _ServerPort = "ServerPort";
		public const string _DataBaseName = "DataBaseName";
		public const string _DataBaseAddr = "DataBaseAddr";
		public const string _CellScore = "CellScore";
		public const string _RevenueRatio = "RevenueRatio";
		public const string _ServiceScore = "ServiceScore";
		public const string _RestrictScore = "RestrictScore";
		public const string _MinTableScore = "MinTableScore";
		public const string _MinEnterScore = "MinEnterScore";
		public const string _MaxEnterScore = "MaxEnterScore";
		public const string _MinEnterMember = "MinEnterMember";
		public const string _MaxEnterMember = "MaxEnterMember";
		public const string _MaxPlayer = "MaxPlayer";
		public const string _ServerRule = "ServerRule";
		public const string _DistributeRule = "DistributeRule";
		public const string _MinDistributeUser = "MinDistributeUser";
		public const string _MaxDistributeUser = "MaxDistributeUser";
		public const string _DistributeTimeSpace = "DistributeTimeSpace";
		public const string _DistributeDrawCount = "DistributeDrawCount";
		public const string _DistributeStartDelay = "DistributeStartDelay";
		public const string _AttachUserRight = "AttachUserRight";
		public const string _ServiceMachine = "ServiceMachine";
		public const string _CustomRule = "CustomRule";
		public const string _Nullity = "Nullity";
		public const string _ServerNote = "ServerNote";
		public const string _CreateDateTime = "CreateDateTime";
		public const string _ModifyDateTime = "ModifyDateTime";
		private int m_serverID;
		private string m_serverName;
		private int m_kindID;
		private int m_nodeID;
		private int m_sortID;
		private int m_gameID;
		private int m_tableCount;
		private int m_serverType;
		private int m_serverPort;
		private string m_dataBaseName;
		private string m_dataBaseAddr;
		private long m_cellScore;
		private byte m_revenueRatio;
		private long m_serviceScore;
		private long m_restrictScore;
		private long m_minTableScore;
		private long m_minEnterScore;
		private long m_maxEnterScore;
		private int m_minEnterMember;
		private int m_maxEnterMember;
		private int m_maxPlayer;
		private int m_serverRule;
		private int m_distributeRule;
		private int m_minDistributeUser;
		private int m_maxDistributeUser;
		private int m_distributeTimeSpace;
		private int m_distributeDrawCount;
		private int m_distributeStartDelay;
		private int m_attachUserRight;
		private string m_serviceMachine;
		private string m_customRule;
		private byte m_nullity;
		private string m_serverNote;
		private DateTime m_createDateTime;
		private DateTime m_modifyDateTime;
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
		public string ServerName
		{
			get
			{
				return this.m_serverName;
			}
			set
			{
				this.m_serverName = value;
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
		public int NodeID
		{
			get
			{
				return this.m_nodeID;
			}
			set
			{
				this.m_nodeID = value;
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
		public int GameID
		{
			get
			{
				return this.m_gameID;
			}
			set
			{
				this.m_gameID = value;
			}
		}
		public int TableCount
		{
			get
			{
				return this.m_tableCount;
			}
			set
			{
				this.m_tableCount = value;
			}
		}
		public int ServerType
		{
			get
			{
				return this.m_serverType;
			}
			set
			{
				this.m_serverType = value;
			}
		}
		public int ServerPort
		{
			get
			{
				return this.m_serverPort;
			}
			set
			{
				this.m_serverPort = value;
			}
		}
		public string DataBaseName
		{
			get
			{
				return this.m_dataBaseName;
			}
			set
			{
				this.m_dataBaseName = value;
			}
		}
		public string DataBaseAddr
		{
			get
			{
				return this.m_dataBaseAddr;
			}
			set
			{
				this.m_dataBaseAddr = value;
			}
		}
		public long CellScore
		{
			get
			{
				return this.m_cellScore;
			}
			set
			{
				this.m_cellScore = value;
			}
		}
		public byte RevenueRatio
		{
			get
			{
				return this.m_revenueRatio;
			}
			set
			{
				this.m_revenueRatio = value;
			}
		}
		public long ServiceScore
		{
			get
			{
				return this.m_serviceScore;
			}
			set
			{
				this.m_serviceScore = value;
			}
		}
		public long RestrictScore
		{
			get
			{
				return this.m_restrictScore;
			}
			set
			{
				this.m_restrictScore = value;
			}
		}
		public long MinTableScore
		{
			get
			{
				return this.m_minTableScore;
			}
			set
			{
				this.m_minTableScore = value;
			}
		}
		public long MinEnterScore
		{
			get
			{
				return this.m_minEnterScore;
			}
			set
			{
				this.m_minEnterScore = value;
			}
		}
		public long MaxEnterScore
		{
			get
			{
				return this.m_maxEnterScore;
			}
			set
			{
				this.m_maxEnterScore = value;
			}
		}
		public int MinEnterMember
		{
			get
			{
				return this.m_minEnterMember;
			}
			set
			{
				this.m_minEnterMember = value;
			}
		}
		public int MaxEnterMember
		{
			get
			{
				return this.m_maxEnterMember;
			}
			set
			{
				this.m_maxEnterMember = value;
			}
		}
		public int MaxPlayer
		{
			get
			{
				return this.m_maxPlayer;
			}
			set
			{
				this.m_maxPlayer = value;
			}
		}
		public int ServerRule
		{
			get
			{
				return this.m_serverRule;
			}
			set
			{
				this.m_serverRule = value;
			}
		}
		public int DistributeRule
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
		public int MinDistributeUser
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
		public int MaxDistributeUser
		{
			get
			{
				return this.m_maxDistributeUser;
			}
			set
			{
				this.m_maxDistributeUser = value;
			}
		}
		public int DistributeTimeSpace
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
		public int DistributeDrawCount
		{
			get
			{
				return this.m_distributeDrawCount;
			}
			set
			{
				this.m_distributeDrawCount = value;
			}
		}
		public int DistributeStartDelay
		{
			get
			{
				return this.m_distributeStartDelay;
			}
			set
			{
				this.m_distributeStartDelay = value;
			}
		}
		public int AttachUserRight
		{
			get
			{
				return this.m_attachUserRight;
			}
			set
			{
				this.m_attachUserRight = value;
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
		public string CustomRule
		{
			get
			{
				return this.m_customRule;
			}
			set
			{
				this.m_customRule = value;
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
		public string ServerNote
		{
			get
			{
				return this.m_serverNote;
			}
			set
			{
				this.m_serverNote = value;
			}
		}
		public DateTime CreateDateTime
		{
			get
			{
				return this.m_createDateTime;
			}
			set
			{
				this.m_createDateTime = value;
			}
		}
		public DateTime ModifyDateTime
		{
			get
			{
				return this.m_modifyDateTime;
			}
			set
			{
				this.m_modifyDateTime = value;
			}
		}
		public GameRoomInfo()
		{
			this.m_serverID = 0;
			this.m_serverName = "";
			this.m_kindID = 0;
			this.m_nodeID = 0;
			this.m_sortID = 0;
			this.m_gameID = 0;
			this.m_tableCount = 0;
			this.m_serverType = 0;
			this.m_serverPort = 0;
			this.m_dataBaseName = "";
			this.m_dataBaseAddr = "";
			this.m_cellScore = 0L;
			this.m_revenueRatio = 0;
			this.m_serviceScore = 0L;
			this.m_restrictScore = 0L;
			this.m_minTableScore = 0L;
			this.m_minEnterScore = 0L;
			this.m_maxEnterScore = 0L;
			this.m_minEnterMember = 0;
			this.m_maxEnterMember = 0;
			this.m_maxPlayer = 0;
			this.m_serverRule = 0;
			this.m_distributeRule = 0;
			this.m_minDistributeUser = 0;
			this.m_maxDistributeUser = 0;
			this.m_distributeTimeSpace = 0;
			this.m_distributeDrawCount = 0;
			this.m_distributeStartDelay = 0;
			this.m_attachUserRight = 0;
			this.m_serviceMachine = "";
			this.m_customRule = "";
			this.m_nullity = 0;
			this.m_serverNote = "";
			this.m_createDateTime = DateTime.Now;
			this.m_modifyDateTime = DateTime.Now;
		}
	}
}
