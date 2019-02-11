using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
namespace Game.Facade
{
	public class WebApiHepler
	{
		private static string GetLastUrl(string baseUrl, System.Collections.Generic.Dictionary<string, string> dictParam, bool isurlencode = true)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(baseUrl);
			if (dictParam != null && dictParam.Count > 0)
			{
				stringBuilder.Append("?");
				int num = 0;
				foreach (System.Collections.Generic.KeyValuePair<string, string> current in dictParam)
				{
					stringBuilder.Append(string.Format("{0}={1}", current.Key, isurlencode ? HttpUtility.UrlEncode(current.Value, System.Text.Encoding.UTF8) : current.Value));
					if (num < dictParam.Count - 1)
					{
						stringBuilder.Append("&");
					}
					num++;
				}
			}
			return stringBuilder.ToString();
		}
		public static bool Get(string baseUrl, System.Collections.Generic.Dictionary<string, string> dictParam, out string result, out string errMsg, bool isurlencode = true, bool islog = true)
		{
			errMsg = string.Empty;
			result = string.Empty;
			bool result3;
			try
			{
				using (HttpClient httpClient = new HttpClient())
				{
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					string lastUrl = WebApiHepler.GetLastUrl(baseUrl, dictParam, isurlencode);
					HttpResponseMessage result2 = httpClient.GetAsync(lastUrl).Result;
					result2.EnsureSuccessStatusCode();
					result = result2.Content.ReadAsStringAsync().Result;
					if (islog)
					{
						NetLog.WriteError("Send:" + lastUrl + ";back:" + result);
					}
					result3 = true;
				}
			}
			catch (System.Exception ex)
			{
				errMsg = ex.Message;
				result3 = false;
			}
			return result3;
		}
		public static bool Post(string baseUrl, System.Collections.Generic.Dictionary<string, string> dictParam, string parseData, out string result, out string errMsg, bool isurlencode)
		{
			errMsg = string.Empty;
			result = string.Empty;
			bool result3;
			try
			{
				using (HttpClient httpClient = new HttpClient())
				{
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					string lastUrl = WebApiHepler.GetLastUrl(baseUrl, dictParam, isurlencode);
					HttpResponseMessage result2 = httpClient.PostAsync(lastUrl, new StringContent(parseData, System.Text.Encoding.UTF8)
					{
						Headers = 
						{
							ContentType = new MediaTypeHeaderValue("application/json")
						}
					}).Result;
					result2.EnsureSuccessStatusCode();
					result = result2.Content.ReadAsStringAsync().Result;
					result3 = true;
				}
			}
			catch (System.Exception ex)
			{
				errMsg = ex.Message;
				result3 = false;
			}
			return result3;
		}
	}
}
