using System;
namespace Game.Facade
{
	public class MobileNotice
	{
		private int _id;
		private string _title;
		private string _date;
		private string _content;
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				this._id = value;
			}
		}
		public string title
		{
			get
			{
				return this._title;
			}
			set
			{
				this._title = value;
			}
		}
		public string date
		{
			get
			{
				return this._date;
			}
			set
			{
				this._date = value;
			}
		}
		public string content
		{
			get
			{
				return this._content;
			}
			set
			{
				this._content = value;
			}
		}
		public MobileNotice(int newsid, string startTitle, System.DateTime startDate, string startContent)
		{
			this._id = newsid;
			this._title = startTitle;
			this._date = startDate.ToString();
			this._content = startContent;
		}
	}
}
