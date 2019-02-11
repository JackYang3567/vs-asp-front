using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml;
namespace Game.Web.Pay.WX
{
	public class WxPayData
	{
		private SortedDictionary<string, object> m_values = new SortedDictionary<string, object>();
		public void SetValue(string key, object value)
		{
			this.m_values[key] = value;
		}
		public object GetValue(string key)
		{
			object result = null;
			this.m_values.TryGetValue(key, out result);
			return result;
		}
		public bool IsSet(string key)
		{
			object result = null;
			this.m_values.TryGetValue(key, out result);
			return result != null;
		}
		public string ToXml()
		{
			if (this.m_values.Count == 0)
			{
				Log.Error(base.GetType().ToString(), "WxPayData数据为空!");
				throw new WxPayException("WxPayData数据为空!");
			}
			string text = "<xml>";
			foreach (System.Collections.Generic.KeyValuePair<string, object> current in this.m_values)
			{
				if (current.Value == null)
				{
					Log.Error(base.GetType().ToString(), "WxPayData内部含有值为null的字段!");
					throw new WxPayException("WxPayData内部含有值为null的字段!");
				}
				if (current.Value.GetType() == typeof(int))
				{
					object obj = text;
					text = string.Concat(new object[]
					{
						obj,
						"<",
						current.Key,
						">",
						current.Value,
						"</",
						current.Key,
						">"
					});
				}
				else
				{
					if (!(current.Value.GetType() == typeof(string)))
					{
						Log.Error(base.GetType().ToString(), "WxPayData字段数据类型错误!");
						throw new WxPayException("WxPayData字段数据类型错误!");
					}
					object obj2 = text;
					text = string.Concat(new object[]
					{
						obj2,
						"<",
						current.Key,
						"><![CDATA[",
						current.Value,
						"]]></",
						current.Key,
						">"
					});
				}
			}
			text += "</xml>";
			return text;
		}
		public SortedDictionary<string, object> FromXml(string xml)
		{
			if (string.IsNullOrEmpty(xml))
			{
				Log.Error(base.GetType().ToString(), "将空的xml串转换为WxPayData不合法!");
				throw new WxPayException("将空的xml串转换为WxPayData不合法!");
			}
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(xml);
			XmlNode firstChild = xmlDocument.FirstChild;
			XmlNodeList childNodes = firstChild.ChildNodes;
			foreach (XmlNode xmlNode in childNodes)
			{
				XmlElement xmlElement = (XmlElement)xmlNode;
				this.m_values[xmlElement.Name] = xmlElement.InnerText;
			}
			SortedDictionary<string, object> values;
			try
			{
				if (this.m_values["return_code"] != "SUCCESS")
				{
					values = this.m_values;
					return values;
				}
				this.CheckSign();
			}
			catch (WxPayException ex)
			{
				throw new WxPayException(ex.Message);
			}
			values = this.m_values;
			return values;
		}
		public string ToUrl()
		{
			string text = "";
			foreach (System.Collections.Generic.KeyValuePair<string, object> current in this.m_values)
			{
				if (current.Value == null)
				{
					Log.Error(base.GetType().ToString(), "WxPayData内部含有值为null的字段!");
					throw new WxPayException("WxPayData内部含有值为null的字段!");
				}
				if (current.Key != "sign" && current.Value.ToString() != "")
				{
					object obj = text;
					text = string.Concat(new object[]
					{
						obj,
						current.Key,
						"=",
						current.Value,
						"&"
					});
				}
			}
			text = text.Trim(new char[]
			{
				'&'
			});
			return text;
		}
		public string ToJson()
		{
			return new JavaScriptSerializer().Serialize(this.m_values);
		}
		public string ToPrintStr()
		{
			string text = "";
			foreach (System.Collections.Generic.KeyValuePair<string, object> current in this.m_values)
			{
				if (current.Value == null)
				{
					Log.Error(base.GetType().ToString(), "WxPayData内部含有值为null的字段!");
					throw new WxPayException("WxPayData内部含有值为null的字段!");
				}
				text += string.Format("{0}={1}<br>", current.Key, current.Value.ToString());
			}
			Log.Debug(base.GetType().ToString(), "Print in Web Page : " + text);
			return text;
		}
		public string MakeSign()
		{
			string text = this.ToUrl();
			text = text + "&key=" + WxPayConfig.KEY;
			System.Security.Cryptography.MD5 mD = System.Security.Cryptography.MD5.Create();
			byte[] array = mD.ComputeHash(System.Text.Encoding.UTF8.GetBytes(text));
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			byte[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				byte b = array2[i];
				stringBuilder.Append(b.ToString("x2"));
			}
			return stringBuilder.ToString().ToUpper();
		}
		public bool CheckSign()
		{
			if (!this.IsSet("sign"))
			{
				Log.Error(base.GetType().ToString(), "WxPayData签名存在但不合法!");
				throw new WxPayException("WxPayData签名存在但不合法!");
			}
			if (this.GetValue("sign") == null || this.GetValue("sign").ToString() == "")
			{
				Log.Error(base.GetType().ToString(), "WxPayData签名存在但不合法!");
				throw new WxPayException("WxPayData签名存在但不合法!");
			}
			string b = this.GetValue("sign").ToString();
			string a = this.MakeSign();
			if (a == b)
			{
				return true;
			}
			Log.Error(base.GetType().ToString(), "WxPayData签名验证错误!");
			throw new WxPayException("WxPayData签名验证错误!");
		}
		public SortedDictionary<string, object> GetValues()
		{
			return this.m_values;
		}
	}
}
