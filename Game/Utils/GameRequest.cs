using System;
using System.Text.RegularExpressions;
using System.Web;
namespace Game.Utils
{
	public class GameRequest
	{
		private static readonly string[] _WebSearchList = new string[]
		{
			"google",
			"isaac",
			"surveybot",
			"baiduspider",
			"yahoo",
			"yisou",
			"3721",
			"qihoo",
			"daqi",
			"ia_archiver",
			"p.arthur",
			"fast-webcrawler",
			"java",
			"microsoft-atl-native",
			"turnitinbot",
			"webgather",
			"sleipnir",
			"msn",
			"sogou",
			"lycos",
			"tom",
			"iask",
			"soso",
			"sina",
			"baidu",
			"gougou",
			"zhongsou"
		};
		public static HttpRequest Request
		{
			get
			{
				HttpContext current = HttpContext.Current;
				if (current == null || current.Request == null)
				{
					return null;
				}
				return current.Request;
			}
		}
		public static bool IsPostFromAnotherDomain
		{
			get
			{
				return !(HttpContext.Current.Request.HttpMethod == "GET") && GameRequest.GetUrlReferrer().IndexOf(GameRequest.GetServerDomain()) == -1;
			}
		}
		private GameRequest()
		{
		}
		public static string GetCurrentFullHost()
		{
			HttpRequest request = HttpContext.Current.Request;
			if (!request.Url.IsDefaultPort)
			{
				return string.Format("{0}:{1}", request.Url.Host, request.Url.Port.ToString());
			}
			return request.Url.Host;
		}
		public static string GetHost()
		{
			if (HttpContext.Current == null)
			{
				return string.Empty;
			}
			return HttpContext.Current.Request.Url.Host;
		}
		public static float GetFloat(string strName, float defValue)
		{
			if (GameRequest.GetQueryFloat(strName, defValue) == defValue)
			{
				return GameRequest.GetFormFloat(strName, defValue);
			}
			return GameRequest.GetQueryFloat(strName, defValue);
		}
		public static float GetFormFloat(string strName, float defValue)
		{
			return TypeParse.StrToFloat(HttpContext.Current.Request.Form[strName], defValue);
		}
		public static int GetFormInt(string strName, int defValue)
		{
			return GameRequest.GetFormInt(GameRequest.Request, strName, defValue);
		}
		public static int GetFormInt(HttpRequest request, string strName, int defValue)
		{
			return TypeParse.StrToInt(request.Form[strName], defValue);
		}
		public static string GetFormString(string strName)
		{
			return GameRequest.GetFormString(GameRequest.Request, strName);
		}
		public static string GetFormString(HttpRequest request, string strName)
		{
			if (request == null || request.Form[strName] == null)
			{
				return string.Empty;
			}
			return request.Form[strName];
		}
		public static int GetInt(string strName, int defValue)
		{
			if (GameRequest.GetQueryInt(strName, defValue) == defValue)
			{
				return GameRequest.GetFormInt(strName, defValue);
			}
			return GameRequest.GetQueryInt(strName, defValue);
		}
		public static string GetPageName()
		{
			string[] array = HttpContext.Current.Request.Url.AbsolutePath.Split(new char[]
			{
				'/'
			});
			return array[array.Length - 1].ToLower();
		}
		public static int GetParamCount()
		{
			return HttpContext.Current.Request.Form.Count + HttpContext.Current.Request.QueryString.Count;
		}
		public static float GetQueryFloat(string strName, float defValue)
		{
			return TypeParse.StrToFloat(HttpContext.Current.Request.QueryString[strName], defValue);
		}
		public static int GetQueryInt(string strName, int defValue)
		{
			return GameRequest.GetQueryInt(GameRequest.Request, strName, defValue);
		}
		public static int GetQueryInt(HttpRequest request, string strName, int defValue)
		{
			return TypeParse.StrToInt(request.QueryString[strName], defValue);
		}
		public static string GetQueryString(string strName)
		{
			return GameRequest.GetQueryString(GameRequest.Request, strName);
		}
		public static string GetQueryString(HttpRequest request, string strName)
		{
			if (request == null || request.QueryString[strName] == null)
			{
				return string.Empty;
			}
			return request.QueryString[strName];
		}
		public static string GetRawUrl()
		{
			return HttpContext.Current.Request.RawUrl;
		}
		public static string GetServerDomain()
		{
			string text = HttpContext.Current.Request.Url.Host.ToLower();
			if (text.Split(new char[]
			{
				'.'
			}).Length < 3 || Validate.IsIP(text))
			{
				return text;
			}
			string text2 = text.Remove(0, text.IndexOf(".") + 1);
			if (text2.StartsWith("com.") || text2.StartsWith("net.") || text2.StartsWith("org.") || text2.StartsWith("gov."))
			{
				return text;
			}
			return text2;
		}
		public static string GetServerString(string strName)
		{
			if (HttpContext.Current.Request.ServerVariables[strName] == null)
			{
				return "";
			}
			return HttpContext.Current.Request.ServerVariables[strName].ToString();
		}
		public static string GetString(string strName)
		{
			if ("".Equals(GameRequest.GetQueryString(strName)))
			{
				return GameRequest.GetFormString(strName);
			}
			return GameRequest.GetQueryString(strName);
		}
		public static string GetString(HttpRequest request, string strName)
		{
			if ("".Equals(GameRequest.GetQueryString(request, strName)))
			{
				return GameRequest.GetFormString(request, strName);
			}
			return GameRequest.GetQueryString(request, strName);
		}
		public static string GetUrl()
		{
			return HttpContext.Current.Request.Url.ToString();
		}
		public static string GetUrlReferrer()
		{
			Uri urlReferrer = HttpContext.Current.Request.UrlReferrer;
			if (urlReferrer == null)
			{
				return string.Empty;
			}
			return Convert.ToString(urlReferrer);
		}
		public static string GetUserBrowser()
		{
			string result = "Unknown";
			if (GameRequest.Request == null)
			{
				return result;
			}
			string text = GameRequest.Request.UserAgent;
			string a;
			if ((a = text) == null || a == "")
			{
				return result;
			}
			text = text.ToLower();
			HttpBrowserCapabilities browser = HttpContext.Current.Request.Browser;
			if (text.IndexOf("firefox") >= 0 || text.IndexOf("firebird") >= 0 || text.IndexOf("myie") >= 0 || text.IndexOf("opera") >= 0 || text.IndexOf("netscape") >= 0 || text.IndexOf("msie") >= 0)
			{
				return browser.Browser + browser.Version;
			}
			return "Unknown";
		}
		public static string GetUserIP()
		{
			if (HttpContext.Current == null)
			{
				return string.Empty;
			}
			string text = string.Empty;
			text = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
			string a;
			if ((a = text) == null || a == "")
			{
				text = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
			}
			if (text == null || text == string.Empty)
			{
				text = HttpContext.Current.Request.UserHostAddress;
			}
			if (text == null || !(text != string.Empty) || !Validate.IsIP(text))
			{
				return "0.0.0.0";
			}
			return text;
		}
		public static string GetUserOsname()
		{
			string result = "Unknown";
			if (GameRequest.Request != null)
			{
				string userAgent = GameRequest.Request.UserAgent;
				string a;
				if ((a = userAgent) == null || a == "")
				{
					return result;
				}
				if (userAgent.Contains("NT 6.1"))
				{
					result = "Windows 7";
				}
				else
				{
					if (userAgent.Contains("NT 6.0"))
					{
						return "Windows Vista/Server 2008";
					}
					if (userAgent.Contains("NT 5.2"))
					{
						return "Windows Server 2003";
					}
					if (userAgent.Contains("NT 5.1"))
					{
						return "Windows XP";
					}
					if (userAgent.Contains("NT 5"))
					{
						return "Windows 2000";
					}
					if (userAgent.Contains("NT 4"))
					{
						return "Windows NT4";
					}
					if (userAgent.Contains("Me"))
					{
						return "Windows Me";
					}
					if (userAgent.Contains("98"))
					{
						return "Windows 98";
					}
					if (userAgent.Contains("95"))
					{
						return "Windows 95";
					}
					if (userAgent.Contains("Mac"))
					{
						return "Mac";
					}
					if (userAgent.Contains("Unix"))
					{
						return "UNIX";
					}
					if (userAgent.Contains("Linux"))
					{
						result = "Linux";
					}
					else
					{
						if (userAgent.Contains("SunOS"))
						{
							result = "SunOS";
						}
					}
				}
			}
			return result;
		}
		public static bool IsBrowserGet()
		{
			string[] array = new string[]
			{
				"ie",
				"opera",
				"netscape",
				"mozilla",
				"konqueror",
				"firefox"
			};
			string text = HttpContext.Current.Request.Browser.Type.ToLower();
			for (int i = 0; i < array.Length; i++)
			{
				if (text.IndexOf(array[i]) >= 0)
				{
					return true;
				}
			}
			return false;
		}
		public static bool IsCrossSitePost()
		{
			return !HttpContext.Current.Request.HttpMethod.Equals("POST") || GameRequest.IsCrossSitePost(GameRequest.GetUrlReferrer(), HttpContext.Current.Request.Url.Host);
		}
		public static bool IsCrossSitePost(string urlReferrer, string host)
		{
			if (urlReferrer.Length < 7)
			{
				return true;
			}
			string text = urlReferrer.Remove(0, 7);
			if (text.IndexOf(":") > -1)
			{
				text = text.Substring(0, text.IndexOf(":"));
			}
			else
			{
				text = text.Substring(0, text.IndexOf('/'));
			}
			return text != host;
		}
		public static bool IsGet()
		{
			return HttpContext.Current.Request.HttpMethod.Equals("GET");
		}
		public static bool IsPost()
		{
			return HttpContext.Current.Request.HttpMethod.Equals("POST");
		}
		public static bool IsRobots()
		{
			return GameRequest.IsSearchEnginesGet();
		}
		public static bool IsSearchEnginesGet()
		{
			string text = HttpContext.Current.Request.UserAgent;
			if (text == null || string.Empty == text)
			{
				return true;
			}
			text = text.ToLower();
			for (int i = 0; i < GameRequest._WebSearchList.Length; i++)
			{
				if (-1 != text.IndexOf(GameRequest._WebSearchList[i]))
				{
					return true;
				}
			}
			return GameRequest.GetUserBrowser().Equals("Unknown");
		}
		public static void SaveRequestFile(string path)
		{
			if (HttpContext.Current.Request.Files.Count > 0)
			{
				HttpContext.Current.Request.Files[0].SaveAs(path);
			}
		}
		public static string GetSubDomain()
		{
			string result = null;
			Regex regex = new Regex("http://((\\.|\\w)+)(/?)", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline);
			string input = HttpContext.Current.Request.Url.AbsoluteUri.ToLower();
			Match match = regex.Match(input);
			if (match.Success)
			{
				result = match.Groups[1].Value.Split(new char[]
				{
					'.'
				})[0];
			}
			return result;
		}
	}
}
