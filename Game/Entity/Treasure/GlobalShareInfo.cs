using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class GlobalShareInfo
	{
		public const string Tablename = "GlobalShareInfo";
		public const string _ShareID = "ShareID";
		public const string _ShareName = "ShareName";
		public const string _ShareAlias = "ShareAlias";
		public const string _ShareNote = "ShareNote";
		public const string _CollectDate = "CollectDate";
		private int m_shareID;
		private string m_shareName;
		private string m_shareAlias;
		private string m_shareNote;
		private DateTime m_collectDate;
		public int ShareID
		{
			get
			{
				return this.m_shareID;
			}
			set
			{
				this.m_shareID = value;
			}
		}
		public string ShareName
		{
			get
			{
				return this.m_shareName;
			}
			set
			{
				this.m_shareName = value;
			}
		}
		public string ShareAlias
		{
			get
			{
				return this.m_shareAlias;
			}
			set
			{
				this.m_shareAlias = value;
			}
		}
		public string ShareNote
		{
			get
			{
				return this.m_shareNote;
			}
			set
			{
				this.m_shareNote = value;
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
		public GlobalShareInfo()
		{
			this.m_shareID = 0;
			this.m_shareName = "";
			this.m_shareAlias = "";
			this.m_shareNote = "";
			this.m_collectDate = DateTime.Now;
		}
	}
}
