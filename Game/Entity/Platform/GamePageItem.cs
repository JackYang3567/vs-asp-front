using System;
namespace Game.Entity.Platform
{
	[Serializable]
	public class GamePageItem
	{
		public const string Tablename = "GamePageItem";
		public const string _PageID = "PageID";
		public const string _KindID = "KindID";
		public const string _NodeID = "NodeID";
		public const string _SortID = "SortID";
		public const string _OperateType = "OperateType";
		public const string _DisplayName = "DisplayName";
		public const string _ResponseUrl = "ResponseUrl";
		public const string _Nullity = "Nullity";
		private int m_pageID;
		private int m_kindID;
		private int m_nodeID;
		private int m_sortID;
		private int m_operateType;
		private string m_displayName;
		private string m_responseUrl;
		private byte m_nullity;
		public int PageID
		{
			get
			{
				return this.m_pageID;
			}
			set
			{
				this.m_pageID = value;
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
		public int OperateType
		{
			get
			{
				return this.m_operateType;
			}
			set
			{
				this.m_operateType = value;
			}
		}
		public string DisplayName
		{
			get
			{
				return this.m_displayName;
			}
			set
			{
				this.m_displayName = value;
			}
		}
		public string ResponseUrl
		{
			get
			{
				return this.m_responseUrl;
			}
			set
			{
				this.m_responseUrl = value;
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
		public GamePageItem()
		{
			this.m_pageID = 0;
			this.m_kindID = 0;
			this.m_nodeID = 0;
			this.m_sortID = 0;
			this.m_operateType = 0;
			this.m_displayName = "";
			this.m_responseUrl = "";
			this.m_nullity = 0;
		}
	}
}
