using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Web;
using System.Web.Security;
namespace Game.Utils.Cache
{
	public class CookiesCache : ICache
	{
		private string _cookiespath = "";
		protected string ValidateKey = "{D20BA3E5-47C9-471f-94E3-5E810B518EB3}";
		protected string ValidateName = "VS";
		public string CookiesPath
		{
			get
			{
				if (!string.IsNullOrEmpty(this._cookiespath))
				{
					return this._cookiespath;
				}
				return "/";
			}
			set
			{
				this._cookiespath = value;
			}
		}
		public DateTime CookiesExpire
		{
			get
			{
				int num;
				if (!int.TryParse(ConfigurationManager.AppSettings["CookiesExpireHours"], out num))
				{
					num = 30;
				}
				return DateTime.Now.AddMinutes((double)num);
			}
		}
		protected string CookiesName
		{
			get
			{
				string text = ConfigurationManager.AppSettings["CookiesName"];
				if (!string.IsNullOrEmpty(text))
				{
					return text;
				}
				return "Default";
			}
		}
		public string ExpireTimeStr
		{
			get
			{
				return "_ETS";
			}
		}
		public object this[string key]
		{
			get
			{
				return this.GetValue(key);
			}
		}
		public void Add(Dictionary<string, object> dic)
		{
			this.Add(dic, null);
		}
		public void Add(Dictionary<string, object> dic, int? timeout)
		{
			HttpCookie httpCookie = HttpContext.Current.Request.Cookies[this.CookiesName];
			if (httpCookie == null)
			{
				httpCookie = new HttpCookie(this.CookiesName);
			}
			httpCookie.Expires = DateTime.Now.AddYears(50);
			httpCookie.Domain = this._cookiespath;
			foreach (KeyValuePair<string, object> current in dic)
			{
				httpCookie.Values[current.Key] = HttpUtility.UrlEncode(current.Value.ToString());
				httpCookie.Values[current.Key + this.ExpireTimeStr] = ((!timeout.HasValue) ? HttpUtility.UrlEncode(this.CookiesExpire.ToString("yyyy-MM-dd HH:mm:ss")) : HttpUtility.UrlEncode(DateTime.Now.AddMinutes((double)timeout.Value).ToString("yyyy-MM-dd HH:mm:ss")));
			}
			httpCookie.Values[this.ValidateName] = this.GetValidateStr(httpCookie);
			HttpContext.Current.Response.Cookies.Add(httpCookie);
		}
		public void Add(string key, object value)
		{
			this.Add(key, value, null);
		}
		public void Add(string key, object value, int? timeout)
		{
			HttpCookie httpCookie = HttpContext.Current.Request.Cookies[this.CookiesName];
			if (httpCookie == null)
			{
				httpCookie = new HttpCookie(this.CookiesName);
			}
			httpCookie.Expires = DateTime.Now.AddYears(50);
			httpCookie.Domain = this._cookiespath;
			httpCookie.Values[key] = HttpUtility.UrlEncode(value.ToString());
			httpCookie.Values[key + this.ExpireTimeStr] = ((!timeout.HasValue) ? HttpUtility.UrlEncode(this.CookiesExpire.ToString("yyyy-MM-dd HH:mm:ss")) : HttpUtility.UrlEncode(DateTime.Now.AddMinutes((double)timeout.Value).ToString("yyyy-MM-dd HH:mm:ss")));
			httpCookie.Values[this.ValidateName] = this.GetValidateStr(httpCookie);
			HttpContext.Current.Response.Cookies.Add(httpCookie);
		}
		public void Delete()
		{
			HttpCookie httpCookie = HttpContext.Current.Request.Cookies[this.CookiesName];
			httpCookie.Expires = DateTime.Now.AddYears(-1);
			HttpContext.Current.Response.Cookies.Add(httpCookie);
		}
		public void Delete(string key)
		{
			HttpCookie httpCookie = HttpContext.Current.Request.Cookies[this.CookiesName];
			httpCookie.Expires = DateTime.Now.AddYears(50);
			httpCookie.Domain = this._cookiespath;
			httpCookie.Values[key] = "";
			httpCookie.Values[key + this.ExpireTimeStr] = "";
			httpCookie.Values[this.ValidateName] = this.GetValidateStr(httpCookie);
			HttpContext.Current.Response.Cookies.Add(httpCookie);
		}
		public void Update(Dictionary<string, object> dic)
		{
			HttpCookie httpCookie = HttpContext.Current.Request.Cookies[this.CookiesName];
			if (httpCookie == null)
			{
				httpCookie = new HttpCookie(this.CookiesName);
			}
			httpCookie.Expires = DateTime.Now.AddYears(50);
			httpCookie.Domain = this._cookiespath;
			foreach (KeyValuePair<string, object> current in dic)
			{
				httpCookie.Values[current.Key] = HttpUtility.UrlEncode(current.Value.ToString());
			}
			httpCookie.Values[this.ValidateName] = this.GetValidateStr(httpCookie);
			HttpContext.Current.Response.Cookies.Add(httpCookie);
		}
		public void Update(string key, object value)
		{
			HttpCookie httpCookie = HttpContext.Current.Request.Cookies[this.CookiesName];
			if (httpCookie == null)
			{
				httpCookie = new HttpCookie(this.CookiesName);
			}
			httpCookie.Expires = DateTime.Now.AddYears(50);
			httpCookie.Domain = this._cookiespath;
			httpCookie.Values[key] = HttpUtility.UrlEncode(value.ToString());
			httpCookie.Values[this.ValidateName] = this.GetValidateStr(httpCookie);
			HttpContext.Current.Response.Cookies.Add(httpCookie);
		}
		public object GetValue(string key)
		{
			if (key == null || key == "")
			{
				return null;
			}
			HttpCookie httpCookie = HttpContext.Current.Request.Cookies[this.CookiesName];
			if (httpCookie == null)
			{
				return null;
			}
			httpCookie.Expires = DateTime.Now.AddYears(50);
			httpCookie.Domain = this._cookiespath;
			if (!this.ValidateCookies(httpCookie))
			{
				httpCookie.Expires = DateTime.Now.AddYears(-1);
				HttpContext.Current.Response.Cookies.Add(httpCookie);
				return null;
			}
			string text = httpCookie.Values[key + this.ExpireTimeStr];
			DateTime t;
			if (string.IsNullOrEmpty(text) || !DateTime.TryParse(HttpUtility.UrlDecode(text), out t))
			{
				httpCookie.Values[key] = "";
				httpCookie.Values[key + this.ExpireTimeStr] = "";
				httpCookie.Values[this.ValidateName] = this.GetValidateStr(httpCookie);
				HttpContext.Current.Response.Cookies.Add(httpCookie);
				return null;
			}
			DateTime now = DateTime.Now;
			if (t > now)
			{
				return HttpUtility.UrlDecode(httpCookie.Values[key]);
			}
			httpCookie.Values[key] = "";
			httpCookie.Values[key + this.ExpireTimeStr] = "";
			httpCookie.Values[this.ValidateName] = this.GetValidateStr(httpCookie);
			HttpContext.Current.Response.Cookies.Add(httpCookie);
			return null;
		}
		private string GetValidateStr(HttpCookie ck)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string[] allKeys = ck.Values.AllKeys;
			for (int i = 0; i < allKeys.Length; i++)
			{
				string text = allKeys[i];
				if (text != this.ValidateName)
				{
					stringBuilder.Append(ck.Values[text]);
				}
			}
			stringBuilder.Append(this.ValidateKey);
			stringBuilder.Append(HttpContext.Current.Request.ServerVariables["LOCAL_ADDR"]);
			stringBuilder.Append(HttpContext.Current.Request.ServerVariables["INSTANCE_ID"]);
			stringBuilder.Append(HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"]);
			return FormsAuthentication.HashPasswordForStoringInConfigFile(stringBuilder.ToString(), "md5").ToLower().Substring(8, 16);
		}
		private bool ValidateCookies(HttpCookie ck)
		{
			string text = ck.Values[this.ValidateName];
			StringBuilder stringBuilder = new StringBuilder();
			string[] allKeys = ck.Values.AllKeys;
			for (int i = 0; i < allKeys.Length; i++)
			{
				string text2 = allKeys[i];
				if (text2 != this.ValidateName)
				{
					stringBuilder.Append(ck.Values[text2]);
				}
			}
			stringBuilder.Append(this.ValidateKey);
			stringBuilder.Append(HttpContext.Current.Request.ServerVariables["LOCAL_ADDR"]);
			stringBuilder.Append(HttpContext.Current.Request.ServerVariables["INSTANCE_ID"]);
			stringBuilder.Append(HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"]);
			string value = FormsAuthentication.HashPasswordForStoringInConfigFile(stringBuilder.ToString(), "md5").ToLower().Substring(8, 16);
			return text.Equals(value);
		}
	}
}
