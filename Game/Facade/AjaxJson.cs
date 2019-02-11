using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
namespace Game.Facade
{
	public class AjaxJson
	{
		private int _code;
		private string _msg;
		private System.Collections.Generic.Dictionary<string, object> _data = new System.Collections.Generic.Dictionary<string, object>();
		public int code
		{
			get
			{
				return this._code;
			}
			set
			{
				this._code = value;
			}
		}
		public string msg
		{
			get
			{
				return this._msg;
			}
			set
			{
				this._msg = value;
			}
		}
		public System.Collections.Generic.Dictionary<string, object> data
		{
			get
			{
				return this._data;
			}
			set
			{
				this._data = value;
			}
		}
		public AjaxJson()
		{
			this._code = 0;
		}
		public void AddDataItem(string key, object value)
		{
			this._data.Add(key, value);
		}
		public void SetDataItem(string key, object value)
		{
			this._data[key] = value;
		}
		public object GetDataItemValue(string key, object value)
		{
			return this._data[key];
		}
		public string SerializeToJson()
		{
			return new JavaScriptSerializer().Serialize(this);
		}
	}
}
