using System;
namespace Game.Entity.Platform
{
	[Serializable]
	public class MobileKindItem
	{
		public const string Tablename = "MobileKindItem";
		public const string _KindID = "KindID";
		public const string _KindName = "KindName";
		public const string _TypeID = "TypeID";
		public const string _ModuleName = "ModuleName";
		public const string _ClientVersion = "ClientVersion";
		public const string _ResVersion = "ResVersion";
		public const string _SortID = "SortID";
		public const string _KindMark = "KindMark";
		public const string _Nullity = "Nullity";
		private int m_kindID;
		private string m_kindName;
		private int m_typeID;
		private string m_moduleName;
		private int m_clientVersion;
		private int m_resVersion;
		private int m_sortID;
		private int m_kindMark;
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
		public string ModuleName
		{
			get
			{
				return this.m_moduleName;
			}
			set
			{
				this.m_moduleName = value;
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
		public int ResVersion
		{
			get
			{
				return this.m_resVersion;
			}
			set
			{
				this.m_resVersion = value;
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
		public int KindMark
		{
			get
			{
				return this.m_kindMark;
			}
			set
			{
				this.m_kindMark = value;
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
		public MobileKindItem()
		{
			this.m_kindID = 0;
			this.m_kindName = "";
			this.m_typeID = 0;
			this.m_moduleName = "";
			this.m_clientVersion = 0;
			this.m_resVersion = 0;
			this.m_sortID = 0;
			this.m_kindMark = 0;
			this.m_nullity = 0;
		}
	}
}
