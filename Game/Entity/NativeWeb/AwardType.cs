using System;
namespace Game.Entity.NativeWeb
{
	[Serializable]
	public class AwardType
	{
		public const string Tablename = "AwardType";
		public const string _TypeID = "TypeID";
		public const string _ParentID = "ParentID";
		public const string _TypeName = "TypeName";
		public const string _SortID = "SortID";
		public const string _Nullity = "Nullity";
		public const string _CollectDate = "CollectDate";
		private int m_typeID;
		private int m_parentID;
		private string m_typeName;
		private int m_sortID;
		private byte m_nullity;
		private DateTime m_collectDate;
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
		public int ParentID
		{
			get
			{
				return this.m_parentID;
			}
			set
			{
				this.m_parentID = value;
			}
		}
		public string TypeName
		{
			get
			{
				return this.m_typeName;
			}
			set
			{
				this.m_typeName = value;
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
		public AwardType()
		{
			this.m_typeID = 0;
			this.m_parentID = 0;
			this.m_typeName = "";
			this.m_sortID = 0;
			this.m_nullity = 0;
			this.m_collectDate = DateTime.Now;
		}
	}
}
