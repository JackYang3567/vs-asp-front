using Game.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
namespace Game.Facade
{
	public class PayHelper
	{
		public static string GetOrderID()
		{
			StringBuffer stringBuffer = new StringBuffer();
			stringBuffer += TextUtility.GetDateTimeLongString();
			stringBuffer += TextUtility.CreateRandom(8, 1, 0, 0, 0, "");
			return stringBuffer.ToString();
		}
		public static string GetOrderIDByPrefix(string prefix)
		{
			int num = 32;
			int num2 = 6;
			StringBuffer stringBuffer = new StringBuffer();
			stringBuffer += prefix;
			stringBuffer += TextUtility.GetDateTimeLongString();
			if (stringBuffer.Length + num2 > num)
			{
				num2 = num - stringBuffer.Length;
			}
			stringBuffer += TextUtility.CreateRandom(num2, 1, 0, 0, 0, "");
			return stringBuffer.ToString();
		}
		public static string PrepareSign(System.Collections.Generic.Dictionary<string, string> dic)
		{
			string text = "";
			foreach (System.Collections.Generic.KeyValuePair<string, string> current in dic)
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					current.Key,
					"=",
					current.Value,
					"&"
				});
			}
			text = text.Remove(text.Length - 1);
			return text;
		}
		public static string PrepareSign(SortedDictionary<string, string> dic)
		{
			string text = "";
			foreach (System.Collections.Generic.KeyValuePair<string, string> current in dic)
			{
				if (!string.IsNullOrEmpty(current.Value))
				{
					string text2 = text;
					text = string.Concat(new string[]
					{
						text2,
						current.Key,
						"=",
						current.Value,
						"&"
					});
				}
			}
			text = text.Remove(text.Length - 1);
			return text;
		}
		public static string GetSignSource(System.Collections.Generic.Dictionary<string, string> dic)
		{
			string text = "";
			foreach (System.Collections.Generic.KeyValuePair<string, string> current in dic)
			{
				text += current.Value;
			}
			return text;
		}
		public static string BuildForm(System.Collections.Generic.Dictionary<string, string> dicPara, string gateway)
		{
			string text = "<form id='paysubmit' name='bankPaySubmit' action='" + gateway + "' method='post'>";
			foreach (System.Collections.Generic.KeyValuePair<string, string> current in dicPara)
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					"<input type='hidden' name='",
					current.Key,
					"' value='",
					current.Value,
					"'/>"
				});
			}
			text += "</form>";
			text += "<script>document.forms['bankPaySubmit'].submit();</script>";
			return text;
		}
		public static string ToXml(System.Collections.Generic.Dictionary<string, string> dic)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder("<xml>");
			foreach (System.Collections.Generic.KeyValuePair<string, string> current in dic)
			{
				string key = current.Key;
				stringBuilder.Append("<").Append(key).Append("><![CDATA[").Append(current.Value.ToString()).Append("]]></").Append(key).Append(">");
			}
			return stringBuilder.Append("</xml>").ToString();
		}
		public static System.Collections.Generic.Dictionary<string, string> XmlToDic(string content)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(content);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("xml");
			XmlNodeList childNodes = xmlNode.ChildNodes;
			System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
			foreach (XmlNode xmlNode2 in childNodes)
			{
				dictionary[xmlNode2.Name] = xmlNode2.InnerText;
			}
			return dictionary;
		}
	}
}
