using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace Game.Utils
{
    public static class Extensions
    {
        /// <summary>
        /// 判断对象是否为null, string.Empty 或者空白字符
        /// </summary>
        /// <param name="value">object</param>
        /// <returns>bool</returns>
        public static bool IsNullOrEmpty(this object value)
        {
            return value == null || string.IsNullOrWhiteSpace(value.ToString());
        }

        /// <summary>
        /// 将对象转换成字符串类型，如果对象是null则转换为string.Empty
        /// </summary>
        /// <param name="value">object</param>
        /// <returns>string</returns>
        public static string ToStringOrEmpty(this object value)
        {
            return value == null ? string.Empty : value.ToString();
        }

        public static string ToJson(this object value)
        {
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            //settings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            string json = JsonConvert.SerializeObject(value, Newtonsoft.Json.Formatting.Indented, settings).Replace("\r\n", ""); ;
            return json;
        }

        /// <summary>
        /// 将对象转换成布尔类型，转换失败返回默认值
        /// </summary>
        /// <param name="value">object</param>
        /// <param name="defaultValue">转换失败后的默认值</param>
        /// <returns>bool</returns>
        public static bool? ToBoolean(this object value, bool? defaultValue = null)
        {
            if (value == null) return defaultValue;
            bool ret;
            return bool.TryParse(value.ToString(), out ret) ? ret : defaultValue;
        }

        public static bool ToBoolean(this object value, bool defaultValue)
        {
            if (value == null) return defaultValue;
            bool ret;
            return bool.TryParse(value.ToString(), out ret) ? ret : defaultValue;
        }

        /// <summary>
        /// 将对象转换成日期类型
        /// </summary>
        /// <param name="value"> object</param>
        /// <param name="defaultValue">转换失败后的默认值</param>
        /// <param name="format">日期格式</param>
        /// <param name="dts">枚举类型，定义一些格式设置选项，这些选项可自定义许多日期和时间分析方法的字符串分析方法</param>
        /// <returns></returns>
        public static DateTime? ToDateTime(this object value, DateTime? defaultValue = null, string format = null, DateTimeStyles dts = DateTimeStyles.None)
        {
            if (value == null) return defaultValue;
            DateTime dt;
            if (string.IsNullOrEmpty(format))
            {
                return DateTime.TryParse(value.ToString(), out dt) ? dt : defaultValue;
            }
            else
            {
                return DateTime.TryParseExact(value.ToString(), format, CultureInfo.CurrentCulture, dts, out dt) ? dt : defaultValue;
            }
        }

        public static DateTime ToDateTime(this object value, DateTime defaultValue, string format = null, DateTimeStyles dts = DateTimeStyles.None)
        {
            if (value == null) return defaultValue;
            DateTime dt;
            if (string.IsNullOrEmpty(format))
            {
                return DateTime.TryParse(value.ToString(), out dt) ? dt : defaultValue;
            }
            else
            {
                return DateTime.TryParseExact(value.ToString(), format, CultureInfo.CurrentCulture, dts, out dt) ? dt : defaultValue;
            }
        }

        public static DateTime ToDateTime(this object value)
        {
            return DateTime.Parse(value.ToString());
        }

        /// <summary>
        /// 将对象转换成Int16
        /// </summary>
        /// <param name="value">object</param>
        /// <param name="defaultValue">转换失败后的默认值</param>
        /// <returns>short?</returns>
        public static short? ToShort(this object value, short? defaultValue = null)
        {
            if (value == null) return defaultValue;
            if (value.GetType().IsNumberType()) return Convert.ToInt16(value);
            short ret;
            return short.TryParse(value.ToString(), out ret) ? ret : defaultValue;
        }

        /// <summary>
        /// 转成32位有符号整形（Int32）
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue">转换失败后的默认值</param>
        /// <returns></returns>
        public static int? ToInt(this object value, int? defaultValue = null)
        {
            if (value == null) return defaultValue;
            if (value.GetType().IsNumberType()) return Convert.ToInt32(value);
            int ret;
            return int.TryParse(value.ToString(), out ret) ? ret : defaultValue;
        }

        public static int ToInt(this object value, int defaultValue = 0)
        {
            if (value == null) return defaultValue;
            if (value.GetType().IsNumberType()) return Convert.ToInt32(value);
            int ret;
            return int.TryParse(value.ToString(), out ret) ? ret : defaultValue;
        }

        /// <summary>
        /// 转成64位有符号整形（Int64）
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue">转换失败后的默认值</param>
        /// <returns></returns>
        public static long? ToLong(this object value, long? defaultValue = null)
        {
            if (value == null) return defaultValue;
            if (value.GetType().IsNumberType()) return Convert.ToInt64(value);
            long ret;
            return long.TryParse(value.ToString(), out ret) ? ret : defaultValue;
        }

        public static long ToLong(this object value, long defaultValue)
        {
            if (value == null) return defaultValue;
            if (value.GetType().IsNumberType()) return Convert.ToInt64(value);
            long ret;
            return long.TryParse(value.ToString(), out ret) ? ret : defaultValue;
        }

        /// <summary>
        /// 转成单精度浮点数字类型（float）
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue">转换失败后的默认值</param>
        /// <returns></returns>
        public static float? ToSingle(this object value, float? defaultValue = null)
        {
            if (value == null) return defaultValue;
            if (value.GetType().IsNumberType()) return Convert.ToSingle(value);
            float ret;
            return float.TryParse(value.ToString(), out ret) ? ret : defaultValue;
        }

        public static float ToSingle(this object value, float defaultValue)
        {
            if (value == null) return defaultValue;
            if (value.GetType().IsNumberType()) return Convert.ToSingle(value);
            float ret;
            return float.TryParse(value.ToString(), out ret) ? ret : defaultValue;
        }

        /// <summary>
        /// 转成双精度浮点数字类型（double）
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue">转换失败后的默认值</param>
        /// <returns></returns>
        public static double? ToDouble(this object value, double? defaultValue = null)
        {
            if (value == null) return defaultValue;
            if (value.GetType().IsNumberType()) return Convert.ToDouble(value);
            double ret;
            return double.TryParse(value.ToString(), out ret) ? ret : defaultValue;
        }

        /// <summary>
        ///  将数字的字符串表示形式转换为它的等效 System.Decimal 表示形式。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue">转换失败后的默认值</param>
        /// <returns></returns>
        public static decimal? ToDecimal(this object value, decimal? defaultValue = null)
        {
            if (value == null) return defaultValue;
            if (value.GetType().IsNumberType()) return Convert.ToDecimal(value);
            decimal ret;
            return decimal.TryParse(value.ToString(), out ret) ? ret : defaultValue;
        }

        public static decimal ToDecimal(this object value, decimal defaultValue = 0)
        {
            if (value == null) return defaultValue;
            if (value.GetType().IsNumberType()) return Convert.ToDecimal(value);
            decimal ret;
            return decimal.TryParse(value.ToString(), out ret) ? ret : defaultValue;
        }

        #region DateTime? 扩展方法

        /// <summary>
        /// 将日期转换为指定格式的字符串,如果日期为 null, 则返回string.Empty
        /// </summary>
        /// <param name="dt">日期</param>
        /// <param name="format">格式化字符串</param>
        /// <returns></returns>
        public static string ToString(this DateTime? dt, string format)
        {
            if (dt.HasValue) return dt.Value.ToString(format);
            else return string.Empty;
        }

        /// <summary>
        /// 将日期转换为 yyyy-MM-dd 格式的字符串
        /// </summary>
        /// <param name="dt">日期</param>
        /// <returns></returns>
        public static string ToDateString(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 将日期转换为 yyyy-MM-dd HH:mm:ss 格式的字符串
        /// </summary>
        /// <param name="dt">日期</param>
        /// <returns></returns>
        public static string ToDateTimeString(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 将日期转换为 yyyy-MM-dd 格式的字符串
        /// </summary>
        /// <param name="dt">日期</param>
        /// <returns></returns>
        public static string ToDateString(this DateTime? dt)
        {
            return dt.HasValue ? dt.Value.ToString("yyyy-MM-dd") : null;
        }

        /// <summary>
        /// 将日期转换为 yyyy-MM-dd  HH:mm:ss格式的字符串
        /// </summary>
        /// <param name="dt">日期</param>
        /// <returns></returns>
        public static string ToDateTimeString(this DateTime? dt)
        {
            return dt.HasValue ? dt.Value.ToString("yyyy-MM-dd HH:mm:ss") : null;
        }

        public static DataTable ToUpperColumns(this DataTable dt)
        {
            if (dt != null)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    dc.ColumnName = dc.ColumnName.ToUpper();
                }
            }
            else
            {
                dt = new DataTable();
            }
            return dt;
        }

        #endregion DateTime? 扩展方法

        #region string 扩展方法

        /// <summary>
        /// 清除字符串中的空白字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ClearWhiteSpace(this string str)
        {
            return Regex.Replace(str, @"\s*", string.Empty);
        }

        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="beginTag">开始位置</param>
        /// <param name="endTag">结束位置</param>
        /// <param name="beginOffset">截取结果的检索位置</param>
        /// <returns></returns>
        public static string GetBetweenString(this string str, string beginTag, string endTag, int beginOffset = 1)
        {
            int startIndex = string.IsNullOrEmpty(beginTag) ? -1 : str.IndexOf(beginTag);
            int endIndex = str.LastIndexOf(endTag);
            int length = endIndex - (startIndex);
            return !string.IsNullOrEmpty(beginTag) && startIndex < 0 || length <= 0
                ? string.Empty : str.Substring(startIndex + beginOffset, length - beginOffset);
        }

        #region 校验字符串

        /// <summary>
        /// 验证字符串是否是电话号码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsPhone(this string str)
        {
            return Regex.IsMatch(str, @"^(?:\d{3,4}-?)?\d{7,8}$");
        }

        /// <summary>
        /// 验证字符串是否是手机号码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsMobile(this string str)
        {
            return Regex.IsMatch(str, @"^(13[0-9]|14[5|7]|15[0|1|2|3|5|6|7|8|9]|18[0|1|2|3|5|6|7|8|9])\d{8}$");
        }

        /// <summary>
        /// 验证字符串EMAIL地址
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEmail(this string str)
        {
            return Regex.IsMatch(str, @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        }

        public static bool IsDateTime(this Type t)
        {
            var tc = Type.GetTypeCode(t);
            return tc == TypeCode.DateTime;
        }

        /// <summary>
        /// 验证字符串URL地址
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsUrl(this string str)
        {
            return Regex.IsMatch(str, @"[a-zA-z]+://[^\s]*"); //^http://([\w-]+\.)+[\w-]+(/[\w-./?%&=]*)?$
        }

        public static bool IsDateTime(this string str)
        {
            DateTime dt = DateTime.Now;
            return DateTime.TryParse(str, out dt);
        }

        public static bool IsFloat(this string str)
        {
            float f = 0;
            return float.TryParse(str, out f);
        }

        public static bool IsDecimal(this string str)
        {
            decimal d = 0;
            return decimal.TryParse(str, out d);
        }

        public static bool IsInt(this string str)
        {
            int i = 0;
            return int.TryParse(str, out i);
        }

        /// <summary>
        /// 验证是否是身份证号码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsIDCard(this string value)
        {
            if (value.Length == 18)
            {
                bool check = CheckIDCard18(value);
                return check;
            }
            else if (value.Length == 15)
            {
                bool check = CheckIDCard15(value);
                return check;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 18位身份证号码验证
        /// </summary>
        private static bool CheckIDCard18(string idNumber)
        {
            long n = 0;
            if (long.TryParse(idNumber.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(idNumber.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(idNumber.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = idNumber.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = idNumber.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != idNumber.Substring(17, 1).ToLower())
            {
                return false;//校验码验证
            }
            return true;//符合GB11643-1999标准
        }

        /// <summary>
        /// 16位身份证号码验证
        /// </summary>
        private static bool CheckIDCard15(string idNumber)
        {
            long n = 0;
            if (long.TryParse(idNumber, out n) == false || n < Math.Pow(10, 14))
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(idNumber.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = idNumber.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            return true;
        }

        /// <summary>
        /// 是否是邮编格式字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsZipCode(this string value)
        {
            return Regex.IsMatch(value, @"^[1-9]\d{5}$");
        }

        /// <summary>
        /// 是否是数字字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNumber(this string value)
        {
            return Regex.IsMatch(value, @"^[0-9]+$");
        }

        /// <summary>
        /// 是否是汉字字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsChinese(this string value)
        {
            return Regex.IsMatch(value, @"^[\u4e00-\u9fa5]+$");
        }

        /// <summary>
        /// 验证是否为ip地址
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsIPAddress(this string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length < 7 || value.Length > 15) return false;

            string regformat = @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$";

            Regex regex = new Regex(regformat, RegexOptions.IgnoreCase);

            return regex.IsMatch(value);
        }

        /// <summary>
        /// 验证是否为端口地址
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsIPPort(this string value)
        {
            bool isPort = false;

            int portNum;

            isPort = Int32.TryParse(value, out portNum);

            if (isPort && portNum >= 0 && portNum <= 65535)
                isPort = true;
            else
                isPort = false;
            return isPort;
        }

        /// <summary>
        /// 指示所指定的正则表达式是否使用指定的匹配选项在指定的输入字符串中找到了匹配项。
        /// </summary>
        /// <param name="str">输入字符串</param>
        /// <param name="regex">正则表达式</param>
        /// <param name="options">匹配选项</param>
        /// <returns></returns>
        public static bool IsMatch(this string str, string regex, RegexOptions options = RegexOptions.Singleline)
        {
            return Regex.IsMatch(str, regex, options);
        }

        #endregion 校验字符串

        #region 单词转换

        /// <summary>
        /// 将单词转换为单数形式
        /// </summary>
        /// <param name="word">单词</param>
        /// <returns>单数形式的单词</returns>
        public static string Singular(this string word)
        {
            var result = ApplyRules(_singulars, word);
            return result;
        }

        /// <summary>
        /// 将单词转换为复数形式
        /// </summary>
        /// <param name="word">单词</param>
        /// <returns>复数形式的单词</returns>
        public static string Plural(this string word)
        {
            var result = ApplyRules(_plurals, word);
            return result;
        }

        /// <summary>
        /// 每个单词首字母大写
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static string ToTitleCase(this string word)
        {
            return Regex.Replace(ToHumanCase(AddUnderscores(word)), @"\b([a-z])",
                delegate(Match match) { return match.Captures[0].Value.ToUpper(); });
        }

        /// <summary>
        /// 将单词转换首字母大写并替换下划线‘_’为空格
        /// </summary>
        /// <param name="lowercaseAndUnderscoredWord"></param>
        /// <returns></returns>
        public static string ToHumanCase(this string lowercaseAndUnderscoredWord)
        {
            return MakeInitialCaps(Regex.Replace(lowercaseAndUnderscoredWord, @"_", " "));
        }

        /// <summary>
        /// 下划线分割单词，同时空白和－替换为下划线
        /// </summary>
        /// <param name="pascalCasedWord"></param>
        /// <returns></returns>
        public static string AddUnderscores(this string pascalCasedWord)
        {
            return Regex.Replace(Regex.Replace(Regex.Replace(pascalCasedWord, @"([A-Z]+)([A-Z][a-z])", "$1_$2"), @"([a-z\d])([A-Z])", "$1_$2"), @"[-\s]", "_").ToLower();
        }

        /// <summary>
        /// 将单个单词转换为首字母大写形式
        /// </summary>
        /// <param name="word">单词</param>
        /// <returns></returns>
        public static string MakeInitialCaps(this string word)
        {
            return String.Concat(word.Substring(0, 1).ToUpper(), word.Substring(1).ToLower());
        }

        /// <summary>
        /// 将单个单词转换为首字母小写形式
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static string MakeInitialLowerCase(this string word)
        {
            return String.Concat(word.Substring(0, 1).ToLower(), word.Substring(1));
        }

        /// <summary>
        /// 验证字符串是否是数值类型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsStringNumeric(string str)
        {
            double result;
            return (double.TryParse(str, NumberStyles.Float, NumberFormatInfo.CurrentInfo, out result));
        }

        #region Rules

        private static string ApplyRules(IList<InflectorRule> rules, string word)
        {
            string result = word;
            if (!_uncountables.Contains(word.ToLower()))
            {
                for (int i = rules.Count - 1; i >= 0; i--)
                {
                    string currentPass = rules[i].Apply(word);
                    if (currentPass != null)
                    {
                        result = currentPass;
                        break;
                    }
                }
            }
            return result;
        }

        private static readonly List<InflectorRule> _plurals = new List<InflectorRule>();
        private static readonly List<InflectorRule> _singulars = new List<InflectorRule>();
        private static readonly List<string> _uncountables = new List<string>();

        private static void AddRule()
        {
            AddPluralRule("$", "s");
            AddPluralRule("s$", "s");
            AddPluralRule("(ax|test)is$", "$1es");
            AddPluralRule("(octop|vir)us$", "$1i");
            AddPluralRule("(alias|status)$", "$1es");
            AddPluralRule("(bu)s$", "$1ses");
            AddPluralRule("(buffal|tomat)o$", "$1oes");
            AddPluralRule("([ti])um$", "$1a");
            AddPluralRule("sis$", "ses");
            AddPluralRule("(?:([^f])fe|([lr])f)$", "$1$2ves");
            AddPluralRule("(hive)$", "$1s");
            AddPluralRule("([^aeiouy]|qu)y$", "$1ies");
            AddPluralRule("(x|ch|ss|sh)$", "$1es");
            AddPluralRule("(matr|vert|ind)ix|ex$", "$1ices");
            AddPluralRule("([m|l])ouse$", "$1ice");
            AddPluralRule("^(ox)$", "$1en");
            AddPluralRule("(quiz)$", "$1zes");

            AddSingularRule("s$", String.Empty);
            AddSingularRule("ss$", "ss");
            AddSingularRule("(n)ews$", "$1ews");
            AddSingularRule("([ti])a$", "$1um");
            AddSingularRule("((a)naly|(b)a|(d)iagno|(p)arenthe|(p)rogno|(s)ynop|(t)he)ses$", "$1$2sis");
            AddSingularRule("(^analy)ses$", "$1sis");
            AddSingularRule("([^f])ves$", "$1fe");
            AddSingularRule("(hive)s$", "$1");
            AddSingularRule("(tive)s$", "$1");
            AddSingularRule("([lr])ves$", "$1f");
            AddSingularRule("([^aeiouy]|qu)ies$", "$1y");
            AddSingularRule("(s)eries$", "$1eries");
            AddSingularRule("(m)ovies$", "$1ovie");
            AddSingularRule("(x|ch|ss|sh)es$", "$1");
            AddSingularRule("([m|l])ice$", "$1ouse");
            AddSingularRule("(bus)es$", "$1");
            AddSingularRule("(o)es$", "$1");
            AddSingularRule("(shoe)s$", "$1");
            AddSingularRule("(cris|ax|test)es$", "$1is");
            AddSingularRule("(octop|vir)i$", "$1us");
            AddSingularRule("(alias|status)$", "$1");
            AddSingularRule("(alias|status)es$", "$1");
            AddSingularRule("^(ox)en", "$1");
            AddSingularRule("(vert|ind)ices$", "$1ex");
            AddSingularRule("(matr)ices$", "$1ix");
            AddSingularRule("(quiz)zes$", "$1");

            AddIrregularRule("person", "people");
            AddIrregularRule("man", "men");
            AddIrregularRule("child", "children");
            AddIrregularRule("sex", "sexes");
            AddIrregularRule("tax", "taxes");
            AddIrregularRule("move", "moves");

            AddUnknownCountRule("equipment");
            AddUnknownCountRule("information");
            AddUnknownCountRule("rice");
            AddUnknownCountRule("money");
            AddUnknownCountRule("species");
            AddUnknownCountRule("series");
            AddUnknownCountRule("fish");
            AddUnknownCountRule("sheep");
        }

        private static void AddIrregularRule(string singular, string plural)
        {
            AddPluralRule(String.Concat("(", singular[0], ")", singular.Substring(1), "$"), String.Concat("$1", plural.Substring(1)));
            AddSingularRule(String.Concat("(", plural[0], ")", plural.Substring(1), "$"), String.Concat("$1", singular.Substring(1)));
        }

        private static void AddUnknownCountRule(string word)
        {
            _uncountables.Add(word.ToLower());
        }

        private static void AddPluralRule(string rule, string replacement)
        {
            _plurals.Add(new InflectorRule(rule, replacement));
        }

        private static void AddSingularRule(string rule, string replacement)
        {
            _singulars.Add(new InflectorRule(rule, replacement));
        }

        private class InflectorRule
        {
            public readonly Regex regex;
            public readonly string replacement;

            public InflectorRule(string regexPattern, string replacementText)
            {
                regex = new Regex(regexPattern, RegexOptions.IgnoreCase);
                replacement = replacementText;
            }

            public string Apply(string word)
            {
                if (!regex.IsMatch(word))
                    return null;

                string replace = regex.Replace(word, replacement);
                if (word == word.ToUpper())
                    replace = replace.ToUpper();

                return replace;
            }
        }

        #endregion Rules

        #endregion 单词转换

        #endregion string 扩展方法

        #region StringBuilder 扩展方法

        private const int TrimHead = 0; // TrimStart
        private const int TrimTail = 1;    // TrimEnd
        private const int TrimBoth = 2;  // Trim

        /// <summary>
        /// 从当前 System.StringBuilder 对象移除数组中指定的一组字符的所有前导匹配项和尾部匹配项。
        /// </summary>
        /// <param name="stringBuilder"></param>
        /// <param name="trimChars">要删除的 Unicode 字符的数组，或 null。</param>
        /// <returns>从当前字符串的开头和结尾删除所出现的所有 trimChars 参数中的字符后剩余的字符串。
        /// 如果 trimChars 为 null 或空数组，则改为移除空白字符。</returns>
        public static StringBuilder Trim(this StringBuilder stringBuilder, params char[] trimChars)
        {
            return stringBuilder.TrimHelper(TrimBoth, trimChars);
        }

        /// <summary>
        /// 从当前 System.StringBuilder 对象移除数组中指定的一组字符的所有前导匹配项。
        /// </summary>
        /// <param name="stringBuilder"></param>
        /// <param name="trimChars">要删除的 Unicode 字符的数组，或 null。</param>
        /// <returns>从当前字符串的开头移除所出现的所有 trimChars 参数中的字符后剩余的字符串。
        /// 如果 trimChars 为 null 或空数组，则改为移除空白字符。</returns>
        public static StringBuilder TrimStart(this StringBuilder stringBuilder, params char[] trimChars)
        {
            return stringBuilder.TrimHelper(TrimHead, trimChars);
        }

        /// <summary>
        /// 从当前 System.StringBuilder 对象移除数组中指定的字符串的所有前导匹配项。
        /// </summary>
        /// <param name="stringBuilder"></param>
        /// <param name="trimString">要删除的字符串</param>
        /// <returns>从当前字符串的开头移除所出现的所有 trimChars 参数字符串后剩余的字符串。</returns>
        public static StringBuilder TrimStart(this StringBuilder stringBuilder, string trimString)
        {
            if (trimString != null && trimString.Length > 0 && stringBuilder.ToString().StartsWith(trimString))
            {
                return TrimStart(stringBuilder.Remove(0, trimString.Length), trimString);
            }
            else
            {
                return stringBuilder;
            }
        }

        /// <summary>
        /// 从当前 System.StringBuilder 对象移除数组中指定的一组字符的所有尾部匹配项。
        /// </summary>
        /// <param name="stringBuilder"></param>
        /// <param name="trimChars">要删除的 Unicode 字符的数组，或 null。</param>
        /// <returns>从当前字符串的结尾移除所出现的所有 trimChars 参数中的字符后剩余的字符串。
        /// 如果 trimChars 为 null 或空数组，则改为删除 Unicode 空白字符。</returns>
        public static StringBuilder TrimEnd(this StringBuilder stringBuilder, params char[] trimChars)
        {
            return stringBuilder.TrimHelper(TrimTail, trimChars);
        }

        /// <summary>
        /// 从当前 System.StringBuilder 对象移除数组中指定的字符串的所有尾部匹配项。
        /// </summary>
        /// <param name="stringBuilder"></param>
        /// <param name="trimString">要删除的字符串</param>
        /// <returns>从当前字符串的结尾移除所出现的所有 trimString 参数字符串后剩余的字符串。</returns>
        public static StringBuilder TrimEnd(this StringBuilder stringBuilder, string trimString)
        {
            if (trimString != null && trimString.Length > 0 && stringBuilder.ToString().EndsWith(trimString))
            {
                return TrimEnd(stringBuilder.Remove(stringBuilder.Length - trimString.Length, trimString.Length), trimString);
            }
            else
            {
                return stringBuilder;
            }
        }

        /// <summary>
        /// 从当前 System.StringBuilder 对象移除所有尾部的 "," 号。
        /// </summary>
        /// <param name="stringBuilder"></param>
        /// <returns>从当前字符串的结尾移除所出现的所有 "," 后剩余的字符串。</returns>
        public static StringBuilder TrimEndComma(this StringBuilder stringBuilder)
        {
            return stringBuilder.TrimHelper(TrimTail, ',');
        }

        private static StringBuilder TrimHelper(this StringBuilder stringBuilder, int trimType, params  char[] trimChars)
        {
            if (stringBuilder == null || stringBuilder.Length == 0) return stringBuilder;
            if (trimChars == null || trimChars.Length == 0) trimChars = new char[] { ' ' };

            int start = 0;
            int end = stringBuilder.Length - 1;

            if (trimType != TrimTail)
            {
                for (start = 0; start < stringBuilder.Length; start++)
                {
                    int i = 0;
                    char ch = stringBuilder[start];
                    for (i = 0; i < trimChars.Length; i++)
                    {
                        if (trimChars[i] == ch) break;
                    }
                    if (i == trimChars.Length) break;
                }
            }
            if (trimType != TrimHead)
            {
                for (end = stringBuilder.Length; end > start; end--)
                {
                    int i = 0;
                    char ch = stringBuilder[end - 1];
                    for (i = 0; i < trimChars.Length; i++)
                    {
                        if (trimChars[i] == ch) break;
                    }
                    if (i == trimChars.Length) break;
                }
            }
            return stringBuilder.CreateTrimmedStringBuilder(start, end);
        }

        private static StringBuilder CreateTrimmedStringBuilder(this StringBuilder stringBuilder, int start, int end)
        {
            int len = end - start;
            if (len == stringBuilder.Length) return stringBuilder;
            if (len == 0) return stringBuilder.Clear();

            return stringBuilder.Remove(end, stringBuilder.Length - end).Remove(0, start);
        }

        #endregion StringBuilder 扩展方法

        #region Type 扩展方法

        /// <summary>
        /// 验证类型是否是整数类型
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsIntegralType(this Type t)
        {
            var tc = Type.GetTypeCode(t);
            return tc >= TypeCode.SByte && tc <= TypeCode.UInt64;
        }

        /// <summary>
        /// 验证类型是否是数字类型，包括整型和浮点型
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsNumberType(this Type t)
        {
            var tc = Type.GetTypeCode(t);
            return
                tc >= TypeCode.SByte && tc <= TypeCode.Decimal;
        }

        #endregion Type 扩展方法

        #region Page  扩展方法

        public static void RegisterJS(this Page page, string key, string script, params object[] args)
        {
            if (args != null && args.Length > 0)
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), key, string.Format(script, args), true);
            }
            else
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), key, script, true);
            }
        }

        #endregion Page  扩展方法

        #region Array 扩展方法

        /// <summary>
        /// 用字符串分隔数组
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static string JoinToSql(this Array arr)
        {
            var isnumber = arr.GetType().GetElementType().IsNumberType();
            var str = new StringBuilder();
            foreach (var item in arr)
            {
                if (item != null)
                {
                    if (isnumber)
                    {
                        str.AppendFormat("{0},", item);
                    }
                    else
                    {
                        str.AppendFormat("'{0}',", item.ToString().Replace("'", "''"));
                    }
                }
            }
            return str.TrimEndComma().ToString();
        }

        public static string JoinToSql(this List<string> list)
        {
            return list.ToArray().JoinToSql();
        }

        #endregion Array 扩展方法

        #region List<T> 扩展方法

        /// <summary>
        /// 用字符串分隔LIST
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="separator">要用作分隔符的字符串。</param>
        /// <returns></returns>
        public static string Join<T>(this List<T> arr, string separator = ",")
        {
            return string.Join(separator, arr);
        }

        /// <summary>
        /// 通过 TKey , TValue 增加  KeyValuePair 到列表
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="list"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Add<TKey, TValue>(this IList<KeyValuePair<TKey, TValue>> list, TKey key, TValue value)
        {
            list.Add(new KeyValuePair<TKey, TValue>(key, value));
        }

        #endregion List<T> 扩展方法

        #region DataTable 扩展方法

        public static IEnumerable<T> ToEntities<T>(this DataTable @this) where T : new()
        {
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

            var list = new List<T>();

            foreach (DataRow dr in @this.Rows)
            {
                var entity = new T();

                foreach (PropertyInfo property in properties)
                {
                    if (@this.Columns.Contains(property.Name))
                    {
                        Type valueType = property.PropertyType;
                        property.SetValue(entity, dr[property.Name].To(valueType), null);
                    }
                }

                foreach (FieldInfo field in fields)
                {
                    if (@this.Columns.Contains(field.Name))
                    {
                        Type valueType = field.FieldType;
                        field.SetValue(entity, dr[field.Name].To(valueType));
                    }
                }

                list.Add(entity);
            }

            return list;
        }

        public static List<T> ToList<T>(this DataTable @this) where T : new()
        {
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

            var list = new List<T>();

            foreach (DataRow dr in @this.Rows)
            {
                var entity = new T();

                foreach (PropertyInfo property in properties)
                {
                    if (@this.Columns.Contains(property.Name))
                    {
                        Type valueType = property.PropertyType;
                        property.SetValue(entity, dr[property.Name].To(valueType), null);
                    }
                }

                foreach (FieldInfo field in fields)
                {
                    if (@this.Columns.Contains(field.Name))
                    {
                        Type valueType = field.FieldType;
                        field.SetValue(entity, dr[field.Name].To(valueType));
                    }
                }

                list.Add(entity);
            }

            return list;
        }

        #endregion DataTable 扩展方法

        #region Object 扩展方法

        public static object To(this Object @this, Type type)
        {
            if (@this != null)
            {
                Type targetType = type;

                if (@this.GetType() == targetType)
                {
                    return @this;
                }

                TypeConverter converter = TypeDescriptor.GetConverter(@this);
                if (converter != null)
                {
                    if (converter.CanConvertTo(targetType))
                    {
                        return converter.ConvertTo(@this, targetType);
                    }
                }

                converter = TypeDescriptor.GetConverter(targetType);
                if (converter != null)
                {
                    if (converter.CanConvertFrom(@this.GetType()))
                    {
                        return converter.ConvertFrom(@this);
                    }
                }

                if (@this == DBNull.Value)
                {
                    return null;
                }
            }

            return @this;
        }

        #endregion Object 扩展方法

        public static string ToBase64(this object value)
        {
            if (value.ToStringOrEmpty() == "")
            {
                return "";
            }
            else
            {
                byte[] b = System.Text.Encoding.Default.GetBytes(value.ToStringOrEmpty());
                return Convert.ToBase64String(b);
            }
        }
    }
}