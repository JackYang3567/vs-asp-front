using System;
namespace Game.Entity.NativeWeb
{
	[Serializable]
	public class Activity
	{
		public const string Tablename = "Activity";
		public const string _ActivityID = "ActivityID";
		public const string _Title = "Title";
		public const string _SortID = "SortID";
		public const string _ImageUrl = "ImageUrl";
		public const string _Time = "Time";
		public const string _Describe = "Describe";
		public const string _IsRecommend = "IsRecommend";
		public const string _InputDate = "InputDate";
		private int m_activityID;
		private string m_title;
		private int m_sortID;
		private string m_imageUrl;
		private string m_time;
		private string m_describe;
		private bool m_isRecommend;
		private DateTime m_inputDate;
		public int ActivityID
		{
			get
			{
				return this.m_activityID;
			}
			set
			{
				this.m_activityID = value;
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
		public string Time
		{
			get
			{
				return this.m_time;
			}
			set
			{
				this.m_time = value;
			}
		}
		public string Describe
		{
			get
			{
				return this.m_describe;
			}
			set
			{
				this.m_describe = value;
			}
		}
		public bool IsRecommend
		{
			get
			{
				return this.m_isRecommend;
			}
			set
			{
				this.m_isRecommend = value;
			}
		}
		public DateTime InputDate
		{
			get
			{
				return this.m_inputDate;
			}
			set
			{
				this.m_inputDate = value;
			}
		}
		public Activity()
		{
			this.m_activityID = 0;
			this.m_title = "";
			this.m_sortID = 0;
			this.m_imageUrl = "";
			this.m_time = "";
			this.m_describe = "";
			this.m_isRecommend = false;
			this.m_inputDate = DateTime.Now;
		}
	}
}
