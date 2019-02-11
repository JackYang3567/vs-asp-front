using System;
namespace Game.Entity.Platform
{
	[Serializable]
	public class GamePropertyType
	{
		public const string Tablename = "GamePropertyType";
		public const string _TypeID = "TypeID";
		public const string _SortID = "SortID";
		public const string _TypeName = "TypeName";
		public const string _TagID = "TagID";
		public const string _Nullity = "Nullity";
		private int m_typeID;
		private int m_sortID;
		private string m_typeName;
		private int m_tagID;
		private byte m_nullity;
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
		public int TagID
		{
			get
			{
				return this.m_tagID;
			}
			set
			{
				this.m_tagID = value;
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
		public GamePropertyType()
		{
			this.m_typeID = 0;
			this.m_sortID = 0;
			this.m_typeName = "";
			this.m_tagID = 0;
			this.m_nullity = 0;
		}
	}
}
