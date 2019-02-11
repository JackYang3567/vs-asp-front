using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace Game.Facade
{
    public class HttpHelper
    {
        public static string CreatFormHtml(string actionUrl, SortedDictionary<string, string> sParaTemp, string strMethod)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append(string.Concat(new string[]
			{
				"<form id='paysubmit' name='paysubmit' action='",
				actionUrl,
				"' method='",
				strMethod.ToLower().Trim(),
				"'>"
			}));
            foreach (System.Collections.Generic.KeyValuePair<string, string> current in sParaTemp)
            {
                stringBuilder.Append(string.Concat(new string[]
				{
					"<input type='hidden' name='",
					current.Key,
					"' value='",
					current.Value,
					"'/>"
				}));
            }
            stringBuilder.Append("</form>");
            stringBuilder.Append("<script>document.forms['paysubmit'].submit();</script>");
            return stringBuilder.ToString();
        }

        public static string HttpRequest(string url, string param)
        {
            return HttpHelper.HttpRequest(url, param, "post");
        }

        public static string HttpRequest(string url, string param, string method)
        {
            return HttpHelper.HttpRequest(url, param, method, "UTF-8");
        }

        public static string HttpRequest(string url, string param, string method, string charset)
        {
            return HttpHelper.HttpRequest(url, param, method, charset, "application/x-www-form-urlencoded");
        }

        public static string HttpRequest(string url, string param, string method, string charset, string contentType)
        {
            if (method.ToLower() == "get")
            {
                url = url + "?" + param;
            }
            string result;
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                if (method.ToLower() == "post")
                {
                    byte[] bytes = System.Text.Encoding.GetEncoding(charset).GetBytes(param);
                    httpWebRequest.Method = "POST";
                    httpWebRequest.ContentType = contentType;
                    httpWebRequest.ContentLength = (long)bytes.Length;
                    using (System.IO.Stream requestStream = httpWebRequest.GetRequestStream())
                    {
                        requestStream.Write(bytes, 0, bytes.Length);
                    }
                }
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string text = new System.IO.StreamReader(httpWebResponse.GetResponseStream(), System.Text.Encoding.GetEncoding(charset)).ReadToEnd();
                result = text;
            }
            catch (System.Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        public static string SendPost(string url, string data)
        {
            return Send(url, "POST", data, null);
        }

        public static string Send(string url, string method, string data, HttpConfig config)
        {
            if (config == null) config = new HttpConfig();
            string result;
            using (HttpWebResponse response = GetResponse(url, method, data, config))
            {
                Stream stream = response.GetResponseStream();

                if (!String.IsNullOrEmpty(response.ContentEncoding))
                {
                    if (response.ContentEncoding.Contains("gzip"))
                    {
                        stream = new GZipStream(stream, CompressionMode.Decompress);
                    }
                    else if (response.ContentEncoding.Contains("deflate"))
                    {
                        stream = new DeflateStream(stream, CompressionMode.Decompress);
                    }
                }

                byte[] bytes = null;
                using (MemoryStream ms = new MemoryStream())
                {
                    int count;
                    byte[] buffer = new byte[4096];
                    while ((count = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, count);
                    }
                    bytes = ms.ToArray();
                }

                #region ���������

                Encoding encoding;

                //�����Ӧͷ�Ƿ񷵻��˱�������,�������˱���������ʹ�÷��صı���
                //ע����ʱ��Ӧͷû�б������ͣ�CharacterSet��������ΪISO-8859-1
                if (!string.IsNullOrEmpty(response.CharacterSet) && response.CharacterSet.ToUpper() != "ISO-8859-1")
                {
                    encoding = Encoding.GetEncoding(response.CharacterSet == "utf8" ? "utf-8" : response.CharacterSet);
                }
                else
                {
                    //��û������Ӧͷ�ҵ����룬��ȥhtml��metaͷ��charset
                    result = Encoding.Default.GetString(bytes);
                    //�ڷ��ص�html��ʹ������ƥ��ҳ�����
                    Match match = Regex.Match(result, @"<meta.*charset=""?([\w-]+)""?.*>", RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        encoding = Encoding.GetEncoding(match.Groups[1].Value);
                    }
                    else
                    {
                        //��html����Ҳ�Ҳ������룬Ĭ��ʹ��utf-8
                        encoding = Encoding.GetEncoding(config.CharacterSet);
                    }
                }

                #endregion ���������

                result = encoding.GetString(bytes);
            }
            return result;
        }

        public static HttpWebResponse GetResponse(string url, string method, string data, HttpConfig config)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;
            request.Referer = config.Referer;
            //��Щҳ�治�����û�������Ϣ���ץȡ��������
            request.UserAgent = config.UserAgent;
            request.Timeout = config.Timeout;
            request.Accept = config.Accept;
            request.Headers.Set("Accept-Encoding", config.AcceptEncoding);
            request.ContentType = config.ContentType;
            request.KeepAlive = config.KeepAlive;
            if (url.ToLower().StartsWith("https"))
            {
                //���������������������https������--Could not establish trust relationship for the SSL/TLS secure channel
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(RemoteCertificateValidate);
            }
            if (method.ToUpper() == "POST")
            {
                if (!string.IsNullOrEmpty(data))
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(data);

                    if (config.GZipCompress)
                    {
                        Console.WriteLine("ѹ��ǰ:" + bytes.Length);
                        using (MemoryStream stream = new MemoryStream())
                        {
                            using (GZipStream gZipStream = new GZipStream(stream, CompressionMode.Compress))
                            {
                                gZipStream.Write(bytes, 0, bytes.Length);
                            }
                            bytes = stream.ToArray();
                        }
                        Console.WriteLine("ѹ����:" + bytes.Length);
                    }

                    request.ContentLength = bytes.Length;
                    request.GetRequestStream().Write(bytes, 0, bytes.Length);
                }
                else
                {
                    request.ContentLength = 0;
                }
            }

            return (HttpWebResponse)request.GetResponse();
        }

        /// <summary>
        /// ���ô���
        /// </summary>
        /// <param name="myproxy">WebProxy����</param>
        //public   void SetWebProxy(WebProxy myproxy) { this.m_myproxy = myproxy; }
        private static bool RemoteCertificateValidate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            //�û�https����
            return true; //���ǽ���
        }

        public static string PostWebRequest(string postUrl, string paramData)
        {
            string ret = string.Empty;

            try
            {
               

                byte[] byteArray = Encoding.Default.GetBytes(paramData); //ת��

                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(postUrl));

                webReq.Method = "POST";

                webReq.ContentType = "application/x-www-form-urlencoded;charset=utf-8";

                webReq.ContentLength = byteArray.Length; 

                Stream newStream = webReq.GetRequestStream();

                newStream.Write(byteArray, 0, byteArray.Length);//д�����

                newStream.Close();

                HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();

                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);

                ret = sr.ReadToEnd();

                sr.Close();

                response.Close();

                newStream.Close();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return ret;
        }
    }

    public class HttpConfig
    {
        public string Referer { get; set; }

        /// <summary>
        /// Ĭ��(text/html)
        /// </summary>
        public string ContentType { get; set; }

        public string Accept { get; set; }

        public string AcceptEncoding { get; set; }

        /// <summary>
        /// ��ʱʱ��(����)Ĭ��100000
        /// </summary>
        public int Timeout { get; set; }

        public string UserAgent { get; set; }

        /// <summary>
        /// POST����ʱ�������Ƿ����gzipѹ��
        /// </summary>
        public bool GZipCompress { get; set; }

        public bool KeepAlive { get; set; }

        public string CharacterSet { get; set; }

        public HttpConfig()
        {
            this.Timeout = 100000;
            this.ContentType = "text/html; charset=" + Encoding.UTF8.WebName;
            this.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.117 Safari/537.36";
            this.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            this.AcceptEncoding = "gzip,deflate";
            this.GZipCompress = false;
            this.KeepAlive = true;
            this.CharacterSet = "UTF-8";
        }
    }
}