using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
namespace Game.Facade
{
	public class Common
	{
		public static string SubStr(string soureStr, string targetStr)
		{
			if (soureStr.Contains(targetStr))
			{
				return soureStr.Replace(targetStr, "");
			}
			return soureStr;
		}
		public static string ObjToString(object o)
		{
			if (o == null)
			{
				return "";
			}
			return o.ToString();
		}
		public static int ObjToInt(object o, int defval)
		{
			int result = defval;
			int.TryParse(o.ToString(), out result);
			return result;
		}
		public static long ObjToLong(object o, int defval)
		{
			long result = (long)defval;
			long.TryParse(o.ToString(), out result);
			return result;
		}
		public static decimal ObjToDecimal(object o)
		{
			decimal result = 0m;
			decimal.TryParse(o.ToString(), out result);
			return result;
		}
		public static int ObjToInt(object o)
		{
			return Common.ObjToInt(o, 0);
		}
		public static long ObjToLong(object o)
		{
			return Common.ObjToLong(o, 0);
		}
		public static int StringToInt(string o)
		{
			return Common.ObjToInt(o);
		}
		public static System.DateTime ObjToDateTime(object o)
		{
			System.DateTime now = System.DateTime.Now;
			System.DateTime.TryParse(Common.ObjToString(o), out now);
			return now;
		}
		public static string ToUnicode(string str)
		{
			string result = "";
			if (!string.IsNullOrEmpty(str))
			{
				System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
				byte[] bytes = System.Text.Encoding.Unicode.GetBytes(str);
				for (int i = 0; i < bytes.Length; i += 2)
				{
					stringBuilder.AppendFormat("\\u{0}", bytes[i + 1].ToString("x").PadLeft(2, '0') + bytes[i].ToString("x").PadLeft(2, '0'));
				}
				result = stringBuilder.ToString();
			}
			return result;
		}
		public static string ToGB2312(string str)
		{
			string text = "";
			if (!string.IsNullOrEmpty(str))
			{
				MatchCollection matchCollection = Regex.Matches(str, "\\\\u([\\w]{2})([\\w]{2})", RegexOptions.IgnoreCase | RegexOptions.Compiled);
				byte[] array = new byte[2];
				foreach (Match match in matchCollection)
				{
					array[0] = (byte)int.Parse(match.Groups[2].Value, System.Globalization.NumberStyles.HexNumber);
					array[1] = (byte)int.Parse(match.Groups[1].Value, System.Globalization.NumberStyles.HexNumber);
					text += System.Text.Encoding.Unicode.GetString(array);
				}
			}
			return text;
		}
		public static string StringToUnicode(string s)
		{
			if (string.IsNullOrEmpty(s))
			{
				return "";
			}
			char[] array = s.ToCharArray();
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			for (int i = 0; i < array.Length; i++)
			{
				byte[] bytes = System.Text.Encoding.Unicode.GetBytes(array[i].ToString());
				stringBuilder.Append(string.Format("//u{0:X2}{1:X2}", bytes[1], bytes[0]));
			}
			return stringBuilder.ToString();
		}
		public static string UnicodeToString(string srcText)
		{
			if (string.IsNullOrEmpty(srcText))
			{
				return "";
			}
			string text = "";
			string text2 = srcText;
			int num = srcText.Length / 6;
			for (int i = 0; i <= num - 1; i++)
			{
				string text3 = text2.Substring(0, 6).Substring(2);
				text2 = text2.Substring(6);
				byte[] array = new byte[]
				{
					0,
					byte.Parse(int.Parse(text3.Substring(0, 2), System.Globalization.NumberStyles.HexNumber).ToString())
				};
				array[0] = byte.Parse(int.Parse(text3.Substring(2, 2), System.Globalization.NumberStyles.HexNumber).ToString());
				text += System.Text.Encoding.Unicode.GetString(array);
			}
			return text;
		}
	}
}
