using System;
using System.Data;
using System.Text.RegularExpressions;
namespace Game.Utils
{
	public sealed class Validate
	{
		private static readonly Regex regex_FileNameFilter = new Regex("[<>/\";#$*%]+", RegexOptions.IgnoreCase | RegexOptions.Compiled);
		private static readonly Regex regex_ImgFormat = new Regex("\\.(gif|jpg|bmp|png|jpeg)$", RegexOptions.IgnoreCase | RegexOptions.Compiled);
		private static readonly Regex regex_IsDate = new Regex("^((((1[6-9]|[2-9]\\d)\\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\\d|3[01]))|(((1[6-9]|[2-9]\\d)\\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\\d|30))|(((1[6-9]|[2-9]\\d)\\d{2})-0?2-(0?[1-9]|1\\d|2[0-8]))|(((1[6-9]|[2-9]\\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$", RegexOptions.Compiled);
		private static readonly Regex regex_IsDecimalFraction = new Regex("^([0-9]{1,10})\\.([0-9]{1,10})$", RegexOptions.Compiled);
		private static readonly Regex regex_IsDouble = new Regex("^([0-9])[0-9]*(\\.\\w*)?$", RegexOptions.IgnoreCase | RegexOptions.Compiled);
		private static readonly Regex regex_IsLongDate = new Regex("^((((1[6-9]|[2-9]\\d)\\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\\d|3[01]))|(((1[6-9]|[2-9]\\d)\\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\\d|30))|(((1[6-9]|[2-9]\\d)\\d{2})-0?2-(0?[1-9]|1\\d|2[0-8]))|(((1[6-9]|[2-9]\\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-)) (20|21|22|23|[0-1]?\\d):[0-5]?\\d:[0-5]?\\d$", RegexOptions.Compiled);
		private static readonly Regex regex_IsNegativeInt = new Regex("^-\\d+$", RegexOptions.Compiled);
		private static readonly Regex regex_IsNickName = new Regex("^[a-zA-Z\\u4e00-\\u9fa5\\d_]+$", RegexOptions.Compiled);
		private static readonly Regex regex_IsNumeric = new Regex("^[-]?[0-9]*[.]?[0-9]*$", RegexOptions.Compiled);
		private static readonly Regex regex_IsPositiveInt = new Regex("^\\d+$", RegexOptions.Compiled);
		private static readonly Regex regex_IsShortDate = new Regex("^((((1[6-9]|[2-9]\\d)\\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\\d|3[01]))|(((1[6-9]|[2-9]\\d)\\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\\d|30))|(((1[6-9]|[2-9]\\d)\\d{2})-0?2-(0?[1-9]|1\\d|2[0-8]))|(((1[6-9]|[2-9]\\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$", RegexOptions.Compiled);
		private static readonly Regex regex_IsUserName = new Regex("^[a-zA-Z\\d_]+$", RegexOptions.Compiled);
		private static readonly Regex regex_SqlFormat = new Regex("\\?|select%20|select\\s+|insert%20|insert\\s+|delete%20|delete\\s+|count\\(|drop%20|drop\\s+|update%20|update\\s+", RegexOptions.IgnoreCase | RegexOptions.Compiled);
		private Validate()
		{
		}
		public static bool CheckedDataSet(DataSet ds)
		{
			return ds != null && ds.Tables != null && (ds.Tables == null || (ds.Tables.Count != 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count != 0));
		}
		public static bool CheckedDataTable(DataTable dt)
		{
			return !object.Equals(dt, null) && !object.Equals(dt.Rows, null) && dt.Rows.Count != 0;
		}
		public static bool CheckedObjcetArray(object[] obj)
		{
			return !object.Equals(obj, null) && obj.Length != 0 && !object.Equals(obj[0], null);
		}
		public static bool IsBase64String(string expression)
		{
			return Regex.IsMatch(expression, "[A-Za-z0-9\\+\\/\\=]");
		}
		public static bool IsCnChar(string expression)
		{
			return Regex.IsMatch(expression, "^(?:[一-龥])+$");
		}
		public static bool IsCnCharAndWordAndNum(string expression)
		{
			return Regex.IsMatch(expression, "^[0-9a-zA-Z一-龥]+$");
		}
		public static bool IsDate(string dateval)
		{
			return Validate.regex_IsDate.IsMatch(dateval);
		}
		public static bool IsDecimalFraction(string expression)
		{
			return Validate.regex_IsDecimalFraction.IsMatch(expression);
		}
		public static bool IsDoEmail(string strEmail)
		{
			return Regex.IsMatch(strEmail, "^@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([\\w-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$");
		}
		public static bool IsDomain(string strHost)
		{
			Regex regex = new Regex("^\\d+$");
			return strHost.IndexOf(".") != -1 && !regex.IsMatch(strHost.Replace(".", string.Empty));
		}
		public static bool IsDouble(object expression)
		{
			return expression != null && Validate.regex_IsDouble.IsMatch(expression.ToString());
		}
		public static bool IsEmail(string strEmail)
		{
			return Regex.IsMatch(strEmail, "^([\\w-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([\\w-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$");
		}
		public static bool IsFileName(string filename)
		{
			return !Validate.regex_FileNameFilter.IsMatch(filename);
		}
		public static bool IsIDCard(string strIDCard)
		{
			if (string.IsNullOrEmpty(strIDCard))
			{
				return false;
			}
			if (strIDCard.Length != 15 && strIDCard.Length != 18)
			{
				return false;
			}
			Regex regex;
			string[] array;
			bool result;
			if (strIDCard.Length == 15)
			{
				regex = new Regex("^(\\d{6})(\\d{2})(\\d{2})(\\d{2})(\\d{3})$");
				if (!regex.Match(strIDCard).Success)
				{
					return false;
				}
				array = regex.Split(strIDCard);
				try
				{
					new DateTime(int.Parse("19" + array[2]), int.Parse(array[3]), int.Parse(array[4]));
					result = true;
					return result;
				}
				catch
				{
					result = false;
					return result;
				}
			}
			regex = new Regex("^(\\d{6})(\\d{4})(\\d{2})(\\d{2})(\\d{3})([0-9Xx])$");
			if (!regex.Match(strIDCard).Success)
			{
				return false;
			}
			array = regex.Split(strIDCard);
			try
			{
				new DateTime(int.Parse(array[2]), int.Parse(array[3]), int.Parse(array[4]));
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}
		public static bool IsImage(string filename)
		{
			return Validate.regex_ImgFormat.Match(filename).Success;
		}
		public static bool IsIP(string ipval)
		{
			return Regex.IsMatch(ipval, "^((2[0-4]\\d|25[0-5]|[01]?\\d\\d?)\\.){3}(2[0-4]\\d|25[0-5]|[01]?\\d\\d?)$");
		}
		public static bool IsIPAndPort(string ipval)
		{
			return Regex.IsMatch(ipval, "^(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9]),\\d{1,5}?$");
		}
		public static bool IsIPSect(string ipval)
		{
			return Regex.IsMatch(ipval, "^((2[0-4]\\d|25[0-5]|[01]?\\d\\d?)\\.){2}((2[0-4]\\d|25[0-5]|[01]?\\d\\d?|\\*)\\.)(2[0-4]\\d|25[0-5]|[01]?\\d\\d?|\\*)$");
		}
		public static bool IsLongDate(string dateval)
		{
			return Validate.regex_IsLongDate.IsMatch(dateval);
		}
		public static bool IsMobileCode(string strMobile)
		{
			return Regex.IsMatch(strMobile, "^13|15|18\\d{9}$", RegexOptions.IgnoreCase);
		}
		public static bool IsNegativeInt(string expression)
		{
			return Validate.regex_IsNegativeInt.Match(expression).Success && long.Parse(expression) >= -2147483648L;
		}
		public static bool IsNickName(string strVal)
		{
			return Validate.regex_IsNickName.IsMatch(strVal);
		}
		public static bool IsNotNull(object expVal)
		{
			return !Validate.IsNull(expVal);
		}
		public static bool IsNull(object expVal)
		{
			if (expVal == null)
			{
				return true;
			}
			string name = expVal.GetType().Name;
			if (name != null && name == "String[]")
			{
				string[] array = (string[])expVal;
				return array.Length == 0;
			}
			string text = expVal.ToString();
			return text == null || text == "";
		}
		public static bool IsNumeric(object expression)
		{
			if (expression != null)
			{
				string text = expression.ToString();
				if (text.Length > 0 && text.Length <= 11 && Validate.regex_IsNumeric.IsMatch(text) && (text.Length < 10 || (text.Length == 10 && text[0] == '1') || (text.Length == 11 && text[0] == '-' && text[1] == '1')))
				{
					return true;
				}
			}
			return false;
		}
		public static bool IsNumericArray(string[] strNumber)
		{
			if (strNumber == null)
			{
				return false;
			}
			if (strNumber.Length < 1)
			{
				return false;
			}
			for (int i = 0; i < strNumber.Length; i++)
			{
				string expression = strNumber[i];
				if (!Validate.IsNumeric(expression))
				{
					return false;
				}
			}
			return true;
		}
		public static bool IsPhoneCode(string strPhone)
		{
			return Regex.IsMatch(strPhone, "^(86)?(-)?(0\\d{2,3})?(-)?(\\d{7,8})(-)?(\\d{3,5})?$", RegexOptions.IgnoreCase);
		}
		public static bool IsPhysicalPath(string s)
		{
			string pattern = "^\\s*[a-zA-Z]:.*$";
			return Regex.IsMatch(s, pattern);
		}
		public static bool IsPositiveInt(string expression)
		{
			return Validate.regex_IsPositiveInt.Match(expression).Success && long.Parse(expression) <= 2147483647L;
		}
		public static bool IsPositiveInt64(string expression)
		{
			return Validate.regex_IsPositiveInt.Match(expression).Success && long.Parse(expression) <= 9223372036854775807L;
		}
		public static bool IsPostalCode(string strPostalCode)
		{
			return Regex.IsMatch(strPostalCode, "^\\d{6}$", RegexOptions.IgnoreCase);
		}
		public static bool IsRelativePath(string s)
		{
			return s != null && !(s == string.Empty) && !s.StartsWith("/") && !s.StartsWith("?") && !Regex.IsMatch(s, "^\\s*[a-zA-Z]{1,10}:.*$");
		}
		public static bool IsSafeInputWords(string expression)
		{
			return Regex.IsMatch(expression, "/^\\s*$|^c:\\\\con\\\\con$|[%,\\*\"\\s\\t\\<\\>\\&]|$guestexp/is");
		}
		public static bool IsSafeSqlString(string expression)
		{
			return !Regex.IsMatch(expression, "[-|;|,|\\/|\\(|\\)|\\[|\\]|\\}|\\{|%|@|\\*|!|\\']");
		}
		public static bool IsSafety(string s)
		{
			string input = Regex.Replace(s.Replace("%20", " "), "\\s", " ");
			string pattern = "select |insert |delete from |count\\(|drop table|update |truncate |asc\\(|mid\\(|char\\(|xp_cmdshell|exec master|net localgroup administrators|:|net user|\"|\\'| or ";
			return !Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase);
		}
		public static bool IsShortDate(string dateval)
		{
			return Validate.regex_IsShortDate.IsMatch(dateval);
		}
		public static bool IsSpecifyWordAndNum(string expression, int start, int end)
		{
			return !string.IsNullOrEmpty(expression) && start <= end && Regex.IsMatch(expression, string.Format("^[0-9a-zA-Z]{{0},{1}}$", start, end));
		}
		public static bool IsSQL(string sqlExpression)
		{
			return Validate.regex_SqlFormat.IsMatch(sqlExpression);
		}
		public static bool IsTime(string timeval)
		{
			return Regex.IsMatch(timeval, "^((([0-1]?[0-9])|(2[0-3])):([0-5]?[0-9])(:[0-5]?[0-9])?)$");
		}
		public static bool IsUnicode(string s)
		{
			string pattern = "^[\\u4E00-\\u9FA5\\uE815-\\uFA29]+$";
			return Regex.IsMatch(s, pattern);
		}
		public static bool IsURL(string strUrl)
		{
			return Regex.IsMatch(strUrl, "^(http|https)\\://([a-zA-Z0-9\\.\\-]+(\\:[a-zA-Z0-9\\.&%\\$\\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\\-]+\\.)*[a-zA-Z0-9\\-]+\\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{1,10}))(\\:[0-9]+)*(/($|[a-zA-Z0-9\\.\\,\\?\\'\\\\\\+&%\\$#\\=~_\\-]+))*$");
		}
		public static bool IsUserName(string strVal)
		{
			return Validate.regex_IsUserName.IsMatch(strVal);
		}
		public static bool IsWordAndNum(string expression)
		{
			return Regex.IsMatch(expression, "[0-9a-zA-Z]?");
		}
	}
}
