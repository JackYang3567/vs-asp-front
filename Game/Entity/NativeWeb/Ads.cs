using System;
namespace Game.Entity.NativeWeb
{
	[Serializable]
	public class Ads
	{
		public const string Tablename = "Ads";
		public const string _ID = "ID";
		public const string _Title = "Title";
		public const string _ResourceURL = "ResourceURL";
		public const string _LinkURL = "LinkURL";
		public const string _Type = "Type";
		public const string _SortID = "SortID";
		public const string _Remark = "Remark";
		private int m_iD;
		private string m_title;
		private string m_resourceURL;
		private string m_linkURL;
		private byte m_type;
		private int m_sortID;
		private string m_remark;
		public int ID
		{
			get
			{
				return this.m_iD;
			}
			set
			{
				this.m_iD = value;
			}
		}
		public string Title
		{
			get
			{
				return this.m_title;
			}
			set
			{
				this.m_title = value;
			}
		}
		public string ResourceURL
		{
			get
			{
				return this.m_resourceURL;
			}
			set
			{
				this.m_resourceURL = value;
			}
		}
		public string LinkURL
		{
			get
			{
				return this.m_linkURL;
			}
			set
			{
				this.m_linkURL = value;
			}
		}
		public byte Type
		{
			get
			{
				return this.m_type;
			}
			set
			{
				this.m_type = value;
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
		public string Remark
		{
			get
			{
				return this.m_remark;
			}
			set
			{
				this.m_remark = value;
			}
		}
		public Ads()
		{
			this.m_iD = 0;
			this.m_title = "";
			this.m_resourceURL = "";
			this.m_linkURL = "";
			this.m_type = 0;
			this.m_sortID = 0;
			this.m_remark = "";
		}
	}
}
