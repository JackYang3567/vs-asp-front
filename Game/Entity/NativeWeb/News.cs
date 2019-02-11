using System;
namespace Game.Entity.NativeWeb
{
	[Serializable]
	public class News
	{
		public const string Tablename = "News";
		public const string _NewsID = "NewsID";
		public const string _PopID = "PopID";
		public const string _Subject = "Subject";
		public const string _Subject1 = "Subject1";
		public const string _OnTop = "OnTop";
		public const string _OnTopAll = "OnTopAll";
		public const string _IsElite = "IsElite";
		public const string _IsHot = "IsHot";
		public const string _IsLock = "IsLock";
		public const string _IsDelete = "IsDelete";
		public const string _IsLinks = "IsLinks";
		public const string _LinkUrl = "LinkUrl";
		public const string _Body = "Body";
		public const string _FormattedBody = "FormattedBody";
		public const string _HighLight = "HighLight";
		public const string _ClassID = "ClassID";
		public const string _GameRange = "GameRange";
		public const string _ImageUrl = "ImageUrl";
		public const string _UserID = "UserID";
		public const string _IssueIP = "IssueIP";
		public const string _LastModifyIP = "LastModifyIP";
		public const string _IssueDate = "IssueDate";
		public const string _LastModifyDate = "LastModifyDate";
		private int m_newsID;
		private int m_popID;
		private string m_subject;
		private string m_subject1;
		private byte m_onTop;
		private byte m_onTopAll;
		private byte m_isElite;
		private byte m_isHot;
		private byte m_isLock;
		private byte m_isDelete;
		private byte m_isLinks;
		private string m_linkUrl;
		private string m_body;
		private string m_formattedBody;
		private string m_highLight;
		private byte m_classID;
		private string m_gameRange;
		private string m_imageUrl;
		private int m_userID;
		private string m_issueIP;
		private string m_lastModifyIP;
		private DateTime m_issueDate;
		private DateTime m_lastModifyDate;
		public int NewsID
		{
			get
			{
				return this.m_newsID;
			}
			set
			{
				this.m_newsID = value;
			}
		}
		public int PopID
		{
			get
			{
				return this.m_popID;
			}
			set
			{
				this.m_popID = value;
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
		public string Subject1
		{
			get
			{
				return this.m_subject1;
			}
			set
			{
				this.m_subject1 = value;
			}
		}
		public byte OnTop
		{
			get
			{
				return this.m_onTop;
			}
			set
			{
				this.m_onTop = value;
			}
		}
		public byte OnTopAll
		{
			get
			{
				return this.m_onTopAll;
			}
			set
			{
				this.m_onTopAll = value;
			}
		}
		public byte IsElite
		{
			get
			{
				return this.m_isElite;
			}
			set
			{
				this.m_isElite = value;
			}
		}
		public byte IsHot
		{
			get
			{
				return this.m_isHot;
			}
			set
			{
				this.m_isHot = value;
			}
		}
		public byte IsLock
		{
			get
			{
				return this.m_isLock;
			}
			set
			{
				this.m_isLock = value;
			}
		}
		public byte IsDelete
		{
			get
			{
				return this.m_isDelete;
			}
			set
			{
				this.m_isDelete = value;
			}
		}
		public byte IsLinks
		{
			get
			{
				return this.m_isLinks;
			}
			set
			{
				this.m_isLinks = value;
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
		public string FormattedBody
		{
			get
			{
				return this.m_formattedBody;
			}
			set
			{
				this.m_formattedBody = value;
			}
		}
		public string HighLight
		{
			get
			{
				return this.m_highLight;
			}
			set
			{
				this.m_highLight = value;
			}
		}
		public byte ClassID
		{
			get
			{
				return this.m_classID;
			}
			set
			{
				this.m_classID = value;
			}
		}
		public string GameRange
		{
			get
			{
				return this.m_gameRange;
			}
			set
			{
				this.m_gameRange = value;
			}
		}
		public string ImageUrl
		{
			get
			{
				return this.m_imageUrl;
			}
			set
			{
				this.m_imageUrl = value;
			}
		}
		public int UserID
		{
			get
			{
				return this.m_userID;
			}
			set
			{
				this.m_userID = value;
			}
		}
		public string IssueIP
		{
			get
			{
				return this.m_issueIP;
			}
			set
			{
				this.m_issueIP = value;
			}
		}
		public string LastModifyIP
		{
			get
			{
				return this.m_lastModifyIP;
			}
			set
			{
				this.m_lastModifyIP = value;
			}
		}
		public DateTime IssueDate
		{
			get
			{
				return this.m_issueDate;
			}
			set
			{
				this.m_issueDate = value;
			}
		}
		public DateTime LastModifyDate
		{
			get
			{
				return this.m_lastModifyDate;
			}
			set
			{
				this.m_lastModifyDate = value;
			}
		}
		public News()
		{
			this.m_newsID = 0;
			this.m_popID = 0;
			this.m_subject = "";
			this.m_subject1 = "";
			this.m_onTop = 0;
			this.m_onTopAll = 0;
			this.m_isElite = 0;
			this.m_isHot = 0;
			this.m_isLock = 0;
			this.m_isDelete = 0;
			this.m_isLinks = 0;
			this.m_linkUrl = "";
			this.m_body = "";
			this.m_formattedBody = "";
			this.m_highLight = "";
			this.m_classID = 0;
			this.m_gameRange = "";
			this.m_imageUrl = "";
			this.m_userID = 0;
			this.m_issueIP = "";
			this.m_lastModifyIP = "";
			this.m_issueDate = DateTime.Now;
			this.m_lastModifyDate = DateTime.Now;
		}
	}
}
