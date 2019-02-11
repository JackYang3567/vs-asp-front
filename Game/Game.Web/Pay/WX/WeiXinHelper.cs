using Game.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Xml;
namespace Game.Web.Pay.WX
{
	public class WeiXinHelper
	{
		private static string device_info = "WEB";
		private static string trade_type = "NATIVE";
		private static string orderurl = "https://api.mch.weixin.qq.com/pay/unifiedorder";
		private static string orderquery = "https://api.mch.weixin.qq.com/pay/orderquery";
		private static string appid
		{
			get
			{
				return ApplicationSettings.Get("WXNATIVEAPPID");
			}
		}
		private static string mch_id
		{
			get
			{
				return ApplicationSettings.Get("WXNATIVEMCHID");
			}
		}
		private static string key
		{
			get
			{
				return ApplicationSettings.Get("WXNATIVEKEY");
			}
		}
		public static string WxPayDataToXml(SortedDictionary<string, object> m_values)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder("<xml>");
			if (m_values.Count > 0)
			{
				foreach (System.Collections.Generic.KeyValuePair<string, object> current in m_values)
				{
					if (current.Value != null && current.Value.GetType() == typeof(int))
					{
						stringBuilder.AppendFormat("<{0}>{1}</{2}>", current.Key, current.Value, current.Key);
					}
					else
					{
						if (current.Value != null && current.Value.GetType() == typeof(string))
						{
							stringBuilder.AppendFormat("<{0}><![CDATA[{1}]]></{2}>", current.Key, current.Value, current.Key);
						}
					}
				}
			}
			stringBuilder.Append("</xml>");
			return stringBuilder.ToString();
		}
		public static SortedDictionary<string, object> WxPayDataFromXml(string xml)
		{
			SortedDictionary<string, object> sortedDictionary = new SortedDictionary<string, object>();
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(xml);
			XmlNode firstChild = xmlDocument.FirstChild;
			XmlNodeList childNodes = firstChild.ChildNodes;
			foreach (XmlNode xmlNode in childNodes)
			{
				XmlElement xmlElement = (XmlElement)xmlNode;
				sortedDictionary[xmlElement.Name] = xmlElement.InnerText;
			}
			return sortedDictionary;
		}
		public static SortedDictionary<string, object> UnifiedOrder(SortedDictionary<string, object> dic, int timeOut = 6)
		{
			dic.Add("appid", WeiXinHelper.appid);
			dic.Add("mch_id", WeiXinHelper.mch_id);
			dic.Add("device_info", WeiXinHelper.device_info);
			dic.Add("sign", WeiXinHelper.GetMakeSign(dic));
			string xml = WeiXinHelper.WxPayDataToXml(dic);
			string xml2 = WeiXinHelper.Post(xml, WeiXinHelper.orderurl, false, timeOut);
			return WeiXinHelper.WxPayDataFromXml(xml2);
		}
		public static SortedDictionary<string, object> UnifiedOrderAPP(SortedDictionary<string, object> dic, string appkey, int timeOut = 6)
		{
			dic.Add("device_info", WeiXinHelper.device_info);
			dic.Add("nonce_str", WeiXinHelper.GetNonce_str());
			dic.Add("sign", WeiXinHelper.GetMakeSignAPP(dic, appkey));
			string xml = WeiXinHelper.WxPayDataToXml(dic);
			string xml2 = WeiXinHelper.Post(xml, WeiXinHelper.orderurl, false, timeOut);
			return WeiXinHelper.WxPayDataFromXml(xml2);
		}
		public static string GetMakeSign(SortedDictionary<string, object> dic)
		{
			string text = WeiXinHelper.ToUrl(dic);
			text = text + "&key=" + WeiXinHelper.key;
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
		public static string GetMakeSignAPP(SortedDictionary<string, object> dic, string appkey)
		{
			string text = WeiXinHelper.ToUrl(dic);
			text = text + "&key=" + appkey;
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
		public static string ToUrl(SortedDictionary<string, object> m_values)
		{
			string text = "";
			foreach (System.Collections.Generic.KeyValuePair<string, object> current in m_values)
			{
				if (current.Value != null && current.Key != "sign" && current.Value.ToString() != "")
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
		public static bool CheckValidationResult(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
		{
			return true;
		}
		public static string Post(string xml, string url, bool isUseCert, int timeout)
		{
			System.GC.Collect();
			string result = "";
			HttpWebRequest httpWebRequest = null;
			HttpWebResponse httpWebResponse = null;
			try
			{
				ServicePointManager.DefaultConnectionLimit = 200;
				if (url.StartsWith("https", System.StringComparison.OrdinalIgnoreCase))
				{
					ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(WeiXinHelper.CheckValidationResult);
				}
				httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
				httpWebRequest.Method = "POST";
				httpWebRequest.Timeout = timeout * 1000;
				httpWebRequest.ContentType = "text/xml";
				byte[] bytes = System.Text.Encoding.UTF8.GetBytes(xml);
				httpWebRequest.ContentLength = (long)bytes.Length;
				System.IO.Stream requestStream = httpWebRequest.GetRequestStream();
				requestStream.Write(bytes, 0, bytes.Length);
				requestStream.Close();
				httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				System.IO.StreamReader streamReader = new System.IO.StreamReader(httpWebResponse.GetResponseStream(), System.Text.Encoding.UTF8);
				result = streamReader.ReadToEnd().Trim();
				streamReader.Close();
			}
			catch (System.Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (httpWebResponse != null)
				{
					httpWebResponse.Close();
				}
				if (httpWebRequest != null)
				{
					httpWebRequest.Abort();
				}
			}
			return result;
		}
		public static string GetNonce_str()
		{
			return System.Guid.NewGuid().ToString().Replace("-", "");
		}
		public static SortedDictionary<string, object> GetReturnData()
		{
			SortedDictionary<string, object> sortedDictionary = new SortedDictionary<string, object>();
			System.IO.StreamReader streamReader = new System.IO.StreamReader(System.Web.HttpContext.Current.Request.InputStream);
			string xml = streamReader.ReadToEnd();
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(xml);
			XmlNode documentElement = xmlDocument.DocumentElement;
			XmlNodeList childNodes = documentElement.ChildNodes;
			foreach (XmlNode xmlNode in childNodes)
			{
				sortedDictionary.Add(xmlNode.Name, xmlNode.InnerText);
			}
			return sortedDictionary;
		}
		public static SortedDictionary<string, object> OrderQuery(SortedDictionary<string, object> dic, int timeOut = 6)
		{
			dic.Add("appid", WeiXinHelper.appid);
			dic.Add("mch_id", WeiXinHelper.mch_id);
			dic.Add("nonce_str", WeiXinHelper.GetNonce_str());
			dic.Add("sign", WeiXinHelper.GetMakeSign(dic));
			string xml = WeiXinHelper.WxPayDataToXml(dic);
			string xml2 = WeiXinHelper.Post(xml, WeiXinHelper.orderquery, false, timeOut);
			return WeiXinHelper.WxPayDataFromXml(xml2);
		}
	}
}
