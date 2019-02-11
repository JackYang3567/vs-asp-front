using System;
namespace Game.Entity.Platform
{
	[Serializable]
	public class GameGameItem
	{
		public const string Tablename = "GameGameItem";
		public const string _GameID = "GameID";
		public const string _GameName = "GameName";
		public const string _SuporType = "SuporType";
		public const string _DataBaseAddr = "DataBaseAddr";
		public const string _DataBaseName = "DataBaseName";
		public const string _ServerVersion = "ServerVersion";
		public const string _ClientVersion = "ClientVersion";
		public const string _ServerDLLName = "ServerDLLName";
		public const string _ClientExeName = "ClientExeName";
		public const string _DataBaseNameT = "DataBaseNameT";
		private int m_gameID;
		private string m_gameName;
		private int m_suporType;
		private string m_dataBaseAddr;
		private string m_dataBaseName;
		private int m_serverVersion;
		private int m_clientVersion;
		private string m_serverDLLName;
		private string m_clientExeName;
		private string m_dataBaseNameT;
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
		public string GameName
		{
			get
			{
				return this.m_gameName;
			}
			set
			{
				this.m_gameName = value;
			}
		}
		public int SuporType
		{
			get
			{
				return this.m_suporType;
			}
			set
			{
				this.m_suporType = value;
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
		public int ServerVersion
		{
			get
			{
				return this.m_serverVersion;
			}
			set
			{
				this.m_serverVersion = value;
			}
		}
		public int ClientVersion
		{
			get
			{
				return this.m_clientVersion;
			}
			set
			{
				this.m_clientVersion = value;
			}
		}
		public string ServerDLLName
		{
			get
			{
				return this.m_serverDLLName;
			}
			set
			{
				this.m_serverDLLName = value;
			}
		}
		public string ClientExeName
		{
			get
			{
				return this.m_clientExeName;
			}
			set
			{
				this.m_clientExeName = value;
			}
		}
		public string DataBaseNameT
		{
			get
			{
				return this.m_dataBaseNameT;
			}
			set
			{
				this.m_dataBaseNameT = value;
			}
		}
		public GameGameItem()
		{
			this.m_gameID = 0;
			this.m_gameName = "";
			this.m_suporType = 0;
			this.m_dataBaseAddr = "";
			this.m_dataBaseName = "";
			this.m_serverVersion = 0;
			this.m_clientVersion = 0;
			this.m_serverDLLName = "";
			this.m_clientExeName = "";
			this.m_dataBaseNameT = "";
		}
	}
}
