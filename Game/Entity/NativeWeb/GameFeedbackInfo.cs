using System;
namespace Game.Entity.NativeWeb
{
	[Serializable]
	public class GameFeedbackInfo
	{
		public const string Tablename = "GameFeedbackInfo";
		public const string _FeedbackID = "FeedbackID";
		public const string _FeedbackTitle = "FeedbackTitle";
		public const string _FeedbackContent = "FeedbackContent";
		public const string _FeedbackDate = "FeedbackDate";
		public const string _UserID = "UserID";
		public const string _ClientIP = "ClientIP";
		public const string _ViewCount = "ViewCount";
		public const string _RevertUserID = "RevertUserID";
		public const string _RevertContent = "RevertContent";
		public const string _RevertDate = "RevertDate";
		public const string _Nullity = "Nullity";
		public const string _IsProcessed = "IsProcessed";
		private int m_feedbackID;
		private string m_feedbackTitle;
		private string m_feedbackContent;
		private DateTime m_feedbackDate;
		private int m_userID;
		private string m_clientIP;
		private int m_viewCount;
		private int m_revertUserID;
		private string m_revertContent;
		private DateTime m_revertDate;
		private byte m_nullity;
		private byte m_isProcessed;
		public int FeedbackID
		{
			get
			{
				return this.m_feedbackID;
			}
			set
			{
				this.m_feedbackID = value;
			}
		}
		public string FeedbackTitle
		{
			get
			{
				return this.m_feedbackTitle;
			}
			set
			{
				this.m_feedbackTitle = value;
			}
		}
		public string FeedbackContent
		{
			get
			{
				return this.m_feedbackContent;
			}
			set
			{
				this.m_feedbackContent = value;
			}
		}
		public DateTime FeedbackDate
		{
			get
			{
				return this.m_feedbackDate;
			}
			set
			{
				this.m_feedbackDate = value;
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
		public string ClientIP
		{
			get
			{
				return this.m_clientIP;
			}
			set
			{
				this.m_clientIP = value;
			}
		}
		public int ViewCount
		{
			get
			{
				return this.m_viewCount;
			}
			set
			{
				this.m_viewCount = value;
			}
		}
		public int RevertUserID
		{
			get
			{
				return this.m_revertUserID;
			}
			set
			{
				this.m_revertUserID = value;
			}
		}
		public string RevertContent
		{
			get
			{
				return this.m_revertContent;
			}
			set
			{
				this.m_revertContent = value;
			}
		}
		public DateTime RevertDate
		{
			get
			{
				return this.m_revertDate;
			}
			set
			{
				this.m_revertDate = value;
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
		public byte IsProcessed
		{
			get
			{
				return this.m_isProcessed;
			}
			set
			{
				this.m_isProcessed = value;
			}
		}
		public GameFeedbackInfo()
		{
			this.m_feedbackID = 0;
			this.m_feedbackTitle = "";
			this.m_feedbackContent = "";
			this.m_feedbackDate = DateTime.Now;
			this.m_userID = 0;
			this.m_clientIP = "";
			this.m_viewCount = 0;
			this.m_revertUserID = 0;
			this.m_revertContent = "";
			this.m_revertDate = DateTime.Now;
			this.m_nullity = 0;
			this.m_isProcessed = 0;
		}
	}
}
