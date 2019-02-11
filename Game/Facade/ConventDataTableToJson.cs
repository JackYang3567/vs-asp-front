using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Script.Serialization;
namespace Game.Facade
{
	public class ConventDataTableToJson
	{
		public static string Serialize(DataTable dt)
		{
			System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> list = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>>();
			foreach (DataRow dataRow in dt.Rows)
			{
				System.Collections.Generic.Dictionary<string, object> dictionary = new System.Collections.Generic.Dictionary<string, object>();
				foreach (DataColumn dataColumn in dt.Columns)
				{
					dictionary.Add(dataColumn.ColumnName, dataRow[dataColumn].ToString());
				}
				list.Add(dictionary);
			}
			int count = dt.Rows.Count;
			string result;
			if (count == 0)
			{
				result = "{\"totalCount\":0,\"data\":[]}";
			}
			else
			{
				result = ConventDataTableToJson.ConventToJson<System.Collections.Generic.Dictionary<string, object>>(list, count);
			}
			return result;
		}
		public static string ConventToJson<T>(System.Collections.Generic.List<T> list, int count)
		{
			JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
			string text = javaScriptSerializer.Serialize(list);
			text = text.Substring(1);
			text = text.Insert(0, "{totalCount:" + count + ",data:[");
			return text + "}";
		}
		public static string Serialize(DataTable dt, bool flag)
		{
			JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
			System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> list = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>>();
			foreach (DataRow dataRow in dt.Rows)
			{
				System.Collections.Generic.Dictionary<string, object> dictionary = new System.Collections.Generic.Dictionary<string, object>();
				foreach (DataColumn dataColumn in dt.Columns)
				{
					dictionary.Add(dataColumn.ColumnName, dataRow[dataColumn].ToString());
				}
				list.Add(dictionary);
			}
			return javaScriptSerializer.Serialize(list);
		}
		public static System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> ConventDataTableToList(DataTable dt)
		{
			System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> list = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>>();
			foreach (DataRow dataRow in dt.Rows)
			{
				System.Collections.Generic.Dictionary<string, object> dictionary = new System.Collections.Generic.Dictionary<string, object>();
				foreach (DataColumn dataColumn in dt.Columns)
				{
					dictionary.Add(dataColumn.ColumnName, dataRow[dataColumn].ToString());
				}
				list.Add(dictionary);
			}
			return list;
		}
	}
}
