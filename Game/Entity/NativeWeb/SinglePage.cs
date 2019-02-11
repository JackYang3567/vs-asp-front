using System;
namespace Game.Entity.NativeWeb
{
	[Serializable]
	public class SinglePage
	{
		public const string Tablename = "SinglePage";
		public const string _PageID = "PageID";
		public const string _KeyValue = "KeyValue";
		public const string _PageName = "PageName";
		public const string _KeyWords = "KeyWords";
		public const string _Description = "Description";
		public const string _Contents = "Contents";
		private int m_pageID;
		private string m_keyValue;
		private string m_pageName;
		private string m_keyWords;
		private string m_description;
		private string m_contents;
		public int PageID
		{
			get
			{
				return this.m_pageID;
			}
			set
			{
				this.m_pageID = value;
			}
		}
		public string KeyValue
		{
			get
			{
				return this.m_keyValue;
			}
			set
			{
				this.m_keyValue = value;
			}
		}
		public string PageName
		{
			get
			{
				return this.m_pageName;
			}
			set
			{
				this.m_pageName = value;
			}
		}
		public string KeyWords
		{
			get
			{
				return this.m_keyWords;
			}
			set
			{
				this.m_keyWords = value;
			}
		}
		public string Description
		{
			get
			{
				return this.m_description;
			}
			set
			{
				this.m_description = value;
			}
		}
		public string Contents
		{
			get
			{
				return this.m_contents;
			}
			set
			{
				this.m_contents = value;
			}
		}
		public SinglePage()
		{
			this.m_pageID = 0;
			this.m_keyValue = "";
			this.m_pageName = "";
			this.m_keyWords = "";
			this.m_description = "";
			this.m_contents = "";
		}
	}
}
