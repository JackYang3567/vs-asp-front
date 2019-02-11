using System;
namespace Game.Entity.Platform
{
	[Serializable]
	public class GameNodeItem
	{
		public const string Tablename = "GameNodeItem";
		public const string _NodeID = "NodeID";
		public const string _KindID = "KindID";
		public const string _JoinID = "JoinID";
		public const string _SortID = "SortID";
		public const string _NodeName = "NodeName";
		public const string _Nullity = "Nullity";
		private int m_nodeID;
		private int m_kindID;
		private int m_joinID;
		private int m_sortID;
		private string m_nodeName;
		private byte m_nullity;
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
		public string NodeName
		{
			get
			{
				return this.m_nodeName;
			}
			set
			{
				this.m_nodeName = value;
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
		public GameNodeItem()
		{
			this.m_nodeID = 0;
			this.m_kindID = 0;
			this.m_joinID = 0;
			this.m_sortID = 0;
			this.m_nodeName = "";
			this.m_nullity = 0;
		}
	}
}
