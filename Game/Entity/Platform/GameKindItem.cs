using System;
namespace Game.Entity.Platform
{
	[Serializable]
	public class GameKindItem
	{
		public const string Tablename = "GameKindItem";
		public const string _KindID = "KindID";
		public const string _GameID = "GameID";
		public const string _TypeID = "TypeID";
		public const string _JoinID = "JoinID";
		public const string _SortID = "SortID";
		public const string _KindName = "KindName";
		public const string _ProcessName = "ProcessName";
		public const string _GameRuleUrl = "GameRuleUrl";
		public const string _DownLoadUrl = "DownLoadUrl";
		public const string _Nullity = "Nullity";
		private int m_kindID;
		private int m_gameID;
		private int m_typeID;
		private int m_joinID;
		private int m_sortID;
		private string m_kindName;
		private string m_processName;
		private string m_gameRuleUrl;
		private string m_downLoadUrl;
		private byte m_nullity;
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
		public int TypeID
		{
			get
			{
				return this.m_typeID;
			}
			set
			{
				this.m_typeID = value;
			}
		}
		public int JoinID
		{
			get
			{
				return this.m_joinID;
			}
			set
			{
				this.m_joinID = value;
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
		public string KindName
		{
			get
			{
				return this.m_kindName;
			}
			set
			{
				this.m_kindName = value;
			}
		}
		public string ProcessName
		{
			get
			{
				return this.m_processName;
			}
			set
			{
				this.m_processName = value;
			}
		}
		public string GameRuleUrl
		{
			get
			{
				return this.m_gameRuleUrl;
			}
			set
			{
				this.m_gameRuleUrl = value;
			}
		}
		public string DownLoadUrl
		{
			get
			{
				return this.m_downLoadUrl;
			}
			set
			{
				this.m_downLoadUrl = value;
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
		public GameKindItem()
		{
			this.m_kindID = 0;
			this.m_gameID = 0;
			this.m_typeID = 0;
			this.m_joinID = 0;
			this.m_sortID = 0;
			this.m_kindName = "";
			this.m_processName = "";
			this.m_gameRuleUrl = "";
			this.m_downLoadUrl = "";
			this.m_nullity = 0;
		}
	}
}
