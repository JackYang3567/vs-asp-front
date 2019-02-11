using System;
namespace Game.Entity.NativeWeb
{
	[Serializable]
	public class Notice
	{
		public const string Tablename = "Notice";
		public const string _NoticeID = "NoticeID";
		public const string _Subject = "Subject";
		public const string _IsLink = "IsLink";
		public const string _LinkUrl = "LinkUrl";
		public const string _Body = "Body";
		public const string _Location = "Location";
		public const string _Width = "Width";
		public const string _Height = "Height";
		public const string _StartDate = "StartDate";
		public const string _OverDate = "OverDate";
		public const string _Nullity = "Nullity";
		private int m_noticeID;
		private string m_subject;
		private byte m_isLink;
		private string m_linkUrl;
		private string m_body;
		private string m_location;
		private int m_width;
		private int m_height;
		private DateTime m_startDate;
		private DateTime m_overDate;
		private byte m_nullity;
		public int NoticeID
		{
			get
			{
				return this.m_noticeID;
			}
			set
			{
				this.m_noticeID = value;
			}
		}
		public string Subject
		{
			get
			{
				return this.m_subject;
			}
			set
			{
				this.m_subject = value;
			}
		}
		public byte IsLink
		{
			get
			{
				return this.m_isLink;
			}
			set
			{
				this.m_isLink = value;
			}
		}
		public string LinkUrl
		{
			get
			{
				return this.m_linkUrl;
			}
			set
			{
				this.m_linkUrl = value;
			}
		}
		public string Body
		{
			get
			{
				return this.m_body;
			}
			set
			{
				this.m_body = value;
			}
		}
		public string Location
		{
			get
			{
				return this.m_location;
			}
			set
			{
				this.m_location = value;
			}
		}
		public int Width
		{
			get
			{
				return this.m_width;
			}
			set
			{
				this.m_width = value;
			}
		}
		public int Height
		{
			get
			{
				return this.m_height;
			}
			set
			{
				this.m_height = value;
			}
		}
		public DateTime StartDate
		{
			get
			{
				return this.m_startDate;
			}
			set
			{
				this.m_startDate = value;
			}
		}
		public DateTime OverDate
		{
			get
			{
				return this.m_overDate;
			}
			set
			{
				this.m_overDate = value;
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
		public Notice()
		{
			this.m_noticeID = 0;
			this.m_subject = "";
			this.m_isLink = 0;
			this.m_linkUrl = "";
			this.m_body = "";
			this.m_location = "";
			this.m_width = 0;
			this.m_height = 0;
			this.m_startDate = DateTime.Now;
			this.m_overDate = DateTime.Now;
			this.m_nullity = 0;
		}
	}
}
