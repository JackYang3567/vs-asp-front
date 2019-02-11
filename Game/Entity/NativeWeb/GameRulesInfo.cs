using System;
namespace Game.Entity.NativeWeb
{
	[Serializable]
	public class GameRulesInfo
	{
		public const string Tablename = "GameRulesInfo";
		public const string _KindID = "KindID";
		public const string _KindName = "KindName";
		public const string _ThumbnailUrl = "ThumbnailUrl";
		public const string _ImgRuleUrl = "ImgRuleUrl";
		public const string _MobileImgUrl = "MobileImgUrl";
		public const string _MobileSize = "MobileSize";
		public const string _MobileDate = "MobileDate";
		public const string _MobileVersion = "MobileVersion";
		public const string _MobileGameType = "MobileGameType";
		public const string _AndroidDownloadUrl = "AndroidDownloadUrl";
		public const string _IOSDownloadUrl = "IOSDownloadUrl";
		public const string _HelpIntro = "HelpIntro";
		public const string _HelpRule = "HelpRule";
		public const string _HelpGrade = "HelpGrade";
		public const string _JoinIntro = "JoinIntro";
		public const string _Nullity = "Nullity";
		public const string _CollectDate = "CollectDate";
		public const string _ModifyDate = "ModifyDate";
		private int m_kindID;
		private string m_kindName;
		private string m_thumbnailUrl;
		private string m_imgRuleUrl;
		private string m_mobileImgUrl;
		private string m_mobileSize;
		private string m_mobileDate;
		private string m_mobileVersion;
		private byte m_mobileGameType;
		private string m_androidDownloadUrl;
		private string m_iOSDownloadUrl;
		private string m_helpIntro;
		private string m_helpRule;
		private string m_helpGrade;
		private byte m_joinIntro;
		private byte m_nullity;
		private DateTime m_collectDate;
		private DateTime m_modifyDate;
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
		public string ThumbnailUrl
		{
			get
			{
				return this.m_thumbnailUrl;
			}
			set
			{
				this.m_thumbnailUrl = value;
			}
		}
		public string ImgRuleUrl
		{
			get
			{
				return this.m_imgRuleUrl;
			}
			set
			{
				this.m_imgRuleUrl = value;
			}
		}
		public string MobileImgUrl
		{
			get
			{
				return this.m_mobileImgUrl;
			}
			set
			{
				this.m_mobileImgUrl = value;
			}
		}
		public string MobileSize
		{
			get
			{
				return this.m_mobileSize;
			}
			set
			{
				this.m_mobileSize = value;
			}
		}
		public string MobileDate
		{
			get
			{
				return this.m_mobileDate;
			}
			set
			{
				this.m_mobileDate = value;
			}
		}
		public string MobileVersion
		{
			get
			{
				return this.m_mobileVersion;
			}
			set
			{
				this.m_mobileVersion = value;
			}
		}
		public byte MobileGameType
		{
			get
			{
				return this.m_mobileGameType;
			}
			set
			{
				this.m_mobileGameType = value;
			}
		}
		public string AndroidDownloadUrl
		{
			get
			{
				return this.m_androidDownloadUrl;
			}
			set
			{
				this.m_androidDownloadUrl = value;
			}
		}
		public string IOSDownloadUrl
		{
			get
			{
				return this.m_iOSDownloadUrl;
			}
			set
			{
				this.m_iOSDownloadUrl = value;
			}
		}
		public string HelpIntro
		{
			get
			{
				return this.m_helpIntro;
			}
			set
			{
				this.m_helpIntro = value;
			}
		}
		public string HelpRule
		{
			get
			{
				return this.m_helpRule;
			}
			set
			{
				this.m_helpRule = value;
			}
		}
		public string HelpGrade
		{
			get
			{
				return this.m_helpGrade;
			}
			set
			{
				this.m_helpGrade = value;
			}
		}
		public byte JoinIntro
		{
			get
			{
				return this.m_joinIntro;
			}
			set
			{
				this.m_joinIntro = value;
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
		public DateTime ModifyDate
		{
			get
			{
				return this.m_modifyDate;
			}
			set
			{
				this.m_modifyDate = value;
			}
		}
		public GameRulesInfo()
		{
			this.m_kindID = 0;
			this.m_kindName = "";
			this.m_thumbnailUrl = "";
			this.m_imgRuleUrl = "";
			this.m_mobileImgUrl = "";
			this.m_mobileSize = "";
			this.m_mobileDate = "";
			this.m_mobileVersion = "";
			this.m_mobileGameType = 0;
			this.m_androidDownloadUrl = "";
			this.m_iOSDownloadUrl = "";
			this.m_helpIntro = "";
			this.m_helpRule = "";
			this.m_helpGrade = "";
			this.m_joinIntro = 0;
			this.m_nullity = 0;
			this.m_collectDate = DateTime.Now;
			this.m_modifyDate = DateTime.Now;
		}
	}
}
