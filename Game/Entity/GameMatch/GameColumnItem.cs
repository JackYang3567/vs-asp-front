using System;
namespace Game.Entity.GameMatch
{
	[Serializable]
	public class GameColumnItem
	{
		public const string Tablename = "GameColumnItem";
		public const string _SortID = "SortID";
		public const string _ColumnName = "ColumnName";
		public const string _ColumnWidth = "ColumnWidth";
		public const string _DataDescribe = "DataDescribe";
		private int m_sortID;
		private string m_columnName;
		private byte m_columnWidth;
		private byte m_dataDescribe;
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
		public string ColumnName
		{
			get
			{
				return this.m_columnName;
			}
			set
			{
				this.m_columnName = value;
			}
		}
		public byte ColumnWidth
		{
			get
			{
				return this.m_columnWidth;
			}
			set
			{
				this.m_columnWidth = value;
			}
		}
		public byte DataDescribe
		{
			get
			{
				return this.m_dataDescribe;
			}
			set
			{
				this.m_dataDescribe = value;
			}
		}
		public GameColumnItem()
		{
			this.m_sortID = 0;
			this.m_columnName = "";
			this.m_columnWidth = 0;
			this.m_dataDescribe = 0;
		}
	}
}
