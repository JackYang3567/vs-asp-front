using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Game.Utils
{
    public partial class Common
    {
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        /// <summary>
        /// 毫秒级别的时间戳
        /// </summary>
        public static string GetMSTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString() + ts.Milliseconds.ToString();
        }

        public static long GetTicks()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return ts.Ticks;
        }

        public static string DataTableToJson(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("{");
                foreach (DataColumn dc in dt.Columns)
                {
                    sb.Append("\"" + dc.ColumnName.ToUpper() + "\":\"" + dr[dc.ColumnName].ToString().Replace("\r", "").Replace("\r", "").Replace("\"", "\\\\\\\"") + "\",");
                }
                if (sb.ToString().EndsWith(","))
                {
                    sb.Remove(sb.Length - 1, 1);
                }
                sb.Append("},");
            }
            if (sb.ToString().EndsWith(","))
            {
                sb.Remove(sb.Length - 1, 1);
            }
            sb.Append("]");
            return sb.ToString();
        }

        public static string DataTableToJson(DataTable dt, params string[] colnames)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("{");
                for (int i = 0; i < colnames.Length; i++)
                {
                    if (dr[colnames[i]] != null)
                    {
                        sb.Append("\"" + colnames[i] + "\":\"" + dr[colnames[i]].ToString() + "\",");
                    }
                }
                if (sb.ToString().EndsWith(","))
                {
                    sb.Remove(sb.Length - 1, 1);
                }

                sb.Append("},");
            }
            if (sb.ToString().EndsWith(","))
            {
                sb.Remove(sb.Length - 1, 1);
            }
            sb.Append("]");
            return sb.ToString();
        }

        public static string DataSetToJQXML(DataSet ds, int pageindex, int pagesize, int recordCount)
        {
            int pagecount = 0;
            if (pagesize <= 0)
            {
                pagesize = 1;
            }
            if (recordCount % pagesize == 0)
                pagecount = recordCount / pagesize;
            else
                pagecount = (recordCount / pagesize) + 1;

            DataTable dt = ds.Tables[0].ToUpperColumns();

            StringBuilder sbxml = new StringBuilder();
            System.IO.StringWriter writer = new System.IO.StringWriter();
            dt.WriteXml(writer);
            sbxml.Append("<Items>");
            sbxml.Append("<page>" + pageindex + "</page>");
            sbxml.Append("<total>" + pagecount + "</total>");
            sbxml.Append("<records>" + recordCount + "</records>");
            sbxml.Append(writer.ToString().Replace("<ds>", "<Item>").Replace("</ds>", "</Item>").Replace("<NewDataSet>", "").Replace("</NewDataSet>", ""));
            sbxml.Append("</Items>");
            return sbxml.ToString();
        }

        public static string DataTableToJQXML(DataTable dt, int pageindex, int pagesize, int recordCount)
        {
            int pagecount = 0;
            if (pagesize <= 0)
            {
                pagesize = 1;
            }
            if (recordCount % pagesize == 0)
                pagecount = recordCount / pagesize;
            else
                pagecount = (recordCount / pagesize) + 1;

            dt = dt.ToUpperColumns();
            StringBuilder sbxml = new StringBuilder();
            System.IO.StringWriter writer = new System.IO.StringWriter();
            dt.TableName = "dt";
            dt.WriteXml(writer);
            sbxml.Append("<Items>");
            sbxml.Append("<page>" + pageindex + "</page>");
            sbxml.Append("<total>" + pagecount + "</total>");
            sbxml.Append("<records>" + recordCount + "</records>");
            sbxml.Append(writer.ToString().Replace("<dt>", "<Item>").Replace("</dt>", "</Item>").Replace("<NewDataSet>", "").Replace("</NewDataSet>", ""));
            sbxml.Append("</Items>");
            return sbxml.ToString();
        }

        public static string DataTableToJQXML(DataTable dt)
        {
            dt = dt.ToUpperColumns();
            StringBuilder sbxml = new StringBuilder();
            System.IO.StringWriter writer = new System.IO.StringWriter();
            dt.TableName = "dt";
            dt.WriteXml(writer);
            sbxml.Append("<Items>");
            sbxml.Append(writer.ToString().Replace("<dt>", "<Item>").Replace("</dt>", "</Item>").Replace("<NewDataSet>", "").Replace("</NewDataSet>", "").Replace("<DocumentElement>", "").Replace("</DocumentElement>", ""));
            sbxml.Append("</Items>");
            return sbxml.ToString();
        }

        public static string RemoveHTMLTag(string str)
        {
            Regex r = new Regex(@"<\/?[^>]*>");     //去除HTML tag
            str = r.Replace(str, "");
            r = new Regex(@"[ | ]*\n");     //去除行尾空白
            str = r.Replace(str, "\n");
            r = new Regex(@" ");     //去除HTML tag
            str = r.Replace(str, "");
            r = new Regex(@"\n");     //去除HTML tag
            str = r.Replace(str, "");
            r = new Regex(@"&nbsp;");     //去除HTML tag
            str = r.Replace(str, "");
            return str;
        }

        /// <summary>
        /// 获取随机数（全为数字）
        /// </summary>
        /// <param name="length">随机数长度</param>
        /// <returns></returns>
        public static string GetRandomNumber(int length)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            string ret = "";
            for (int i = 0; i < length; i++)
            {
                ret += random.Next(0, 9);
            }
            return ret;
            //if (length <= 9)
            //{
            //    return random.Next(1 * Math.Pow(10, length - 1).ToInt(0), 1 * Math.Pow(10, length).ToInt(0));
            //}
            //else
            //{
            //    return 0;
            //}
        }

        /// <summary>
        /// 获取随机字符（全为字母）
        /// </summary>
        /// <param name="length">随机数长度</param>
        /// <returns></returns>
        public static string GetRandomChar(int length)
        {
            char[] chars = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            Random random = new Random(Guid.NewGuid().GetHashCode());
            StringBuilder randomChars = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                randomChars.Append(chars[random.Next(0, chars.Length - 1)]);
            }
            return randomChars.ToStringOrEmpty();
        }

        /// <summary>
        /// 获取随机字符（字母和数字）
        /// </summary>
        /// <param name="length">随机数长度</param>
        /// <returns></returns>
        public static string GetRandomCode(int length)
        {
            char[] chars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            Random random = new Random(Guid.NewGuid().GetHashCode());
            StringBuilder randomChars = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                randomChars.Append(chars[random.Next(0, chars.Length - 1)]);
            }
            return randomChars.ToStringOrEmpty();
        }

        public static void WriteLog(string strMemo)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string filename = path + "logs/log" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            if (!Directory.Exists(path + "logs/"))
            {
                Directory.CreateDirectory(path + "logs/");
            }
            StreamWriter sr = null;

            try
            {
                if (!File.Exists(filename))
                {
                    sr = File.CreateText(filename);
                }
                else
                {
                    sr = File.AppendText(filename);
                }
                sr.WriteLine(DateTime.Now.ToString() + "---" + strMemo);
                sr.WriteLine();
            }
            catch (Exception ex)
            {
                //DbHelperSQL.ExecuteSql("insert into logs(logstr) values('" + ex.Message + "'");
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }
        }

        //默认密钥向量

        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        private static string _encryptKey = "zhongbao";
        /**/
        /**/
        /**/

        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        public static string EncryptDES(string encryptString, string encryptKey = "")
        {
            try
            {
                if (encryptKey == string.Empty)
                {
                    encryptKey = _encryptKey;
                }
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey);
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }

        /**/
        /**/
        /**/

        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public static string DecryptDES(string decryptString, string encryptKey = "")
        {
            try
            {
                if (encryptKey == string.Empty)
                {
                    encryptKey = _encryptKey;
                }
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey);
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return decryptString;
            }
        }

        public static string MD5(string str, int code = 16)
        {
            if (code == 16)
            {
                return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").Substring(8, 16);
            }
            else//32位加密
            {
                return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
            }
        }

        /// <summary>
        /// 前端js用 unescape解码
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Escape(string s)
        {
            StringBuilder sb = new StringBuilder();
            byte[] ba = System.Text.Encoding.Unicode.GetBytes(s);
            for (int i = 0; i < ba.Length; i += 2)
            {
                if (ba[i + 1] == 0)
                {
                    //数字,大小写字母,以及"+-*/._"不变
                    if (
                          (ba[i] >= 48 && ba[i] <= 57)
                        || (ba[i] >= 64 && ba[i] <= 90)
                        || (ba[i] >= 97 && ba[i] <= 122)
                        || (ba[i] == 42 || ba[i] == 43 || ba[i] == 45 || ba[i] == 46 || ba[i] == 47 || ba[i] == 95)
                        )//保持不变
                    {
                        sb.Append(Encoding.Unicode.GetString(ba, i, 2));
                    }
                    else//%xx形式
                    {
                        sb.Append("%");
                        sb.Append(ba[i].ToString("X2"));
                    }
                }
                else
                {
                    sb.Append("%u");
                    sb.Append(ba[i + 1].ToString("X2"));
                    sb.Append(ba[i].ToString("X2"));
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// If you are looking for ResolveUrl outside of Page/Control, and even if you are not, this is for you. it's very fast
        /// </summary>
        /// <param name="relativeUrl"></param>
        /// <returns></returns>
        public static string ResolveUrl(string relativeUrl)
        {
            if (relativeUrl == null) throw new ArgumentNullException("relativeUrl");

            if (relativeUrl.Length == 0 || relativeUrl[0] == '/' || relativeUrl[0] == '\\')
                return relativeUrl;

            int idxOfScheme = relativeUrl.IndexOf(@"://", StringComparison.Ordinal);
            if (idxOfScheme != -1)
            {
                int idxOfQM = relativeUrl.IndexOf('?');
                if (idxOfQM == -1 || idxOfQM > idxOfScheme) return relativeUrl;
            }

            StringBuilder sbUrl = new StringBuilder();
            sbUrl.Append(HttpRuntime.AppDomainAppVirtualPath);
            if (sbUrl.Length == 0 || sbUrl[sbUrl.Length - 1] != '/') sbUrl.Append('/');

            // found question mark already? query string, do not touch!
            bool foundQM = false;
            bool foundSlash; // the latest char was a slash?
            if (relativeUrl.Length > 1
                && relativeUrl[0] == '~'
                && (relativeUrl[1] == '/' || relativeUrl[1] == '\\'))
            {
                relativeUrl = relativeUrl.Substring(2);
                foundSlash = true;
            }
            else foundSlash = false;
            foreach (char c in relativeUrl)
            {
                if (!foundQM)
                {
                    if (c == '?') foundQM = true;
                    else
                    {
                        if (c == '/' || c == '\\')
                        {
                            if (foundSlash) continue;
                            else
                            {
                                sbUrl.Append('/');
                                foundSlash = true;
                                continue;
                            }
                        }
                        else if (foundSlash) foundSlash = false;
                    }
                }
                sbUrl.Append(c);
            }

            return sbUrl.ToString();
        }

        public static string GetAppSetting(string key)
        {
            var _logger = new Logger("File");

            if (string.IsNullOrEmpty(key))
            {
                return string.Empty;
            }
            string str = ConfigurationManager.AppSettings[key];
            if (str == null)
            {
                _logger.Debug("WebConfigHasNotAddKey:" + key);
            }
            return str.ToStringOrEmpty();
        }
    }
}