using System;
using System.IO;
using System.Net;
using System.Text;

namespace Game.Utils
{
    public class CodeHelper
    {
        public CodeHelper()
        {
        }

        private static string PushToWeb(string weburl, string data, Encoding encode)
        {
            byte[] bytes = encode.GetBytes(data);
            HttpWebRequest length = (HttpWebRequest)WebRequest.Create(new Uri(weburl));
            length.Method = "POST";
            length.ContentType = "application/x-www-form-urlencoded";
            length.ContentLength = (long)((int)bytes.Length);
            Stream requestStream = length.GetRequestStream();
            requestStream.Write(bytes, 0, (int)bytes.Length);
            requestStream.Close();
            return (new StreamReader(((HttpWebResponse)length.GetResponse()).GetResponseStream(), encode)).ReadToEnd();
        }

        public static string SendCode(string phone, string code1, string content1)
        {
            string str = ApplicationSettings.Get("phonePostUrl").ToString();
            string str1 = ApplicationSettings.Get("phoneName").ToString();
            string str2 = ApplicationSettings.Get("phonePwd").ToString();
            string str3 = string.Concat("您的验证码是：", code1, " 。请不要把验证码泄露给其他人。");
            string str4 = "account={0}&password={1}&mobile={2}&content={3}";
            byte[] bytes = (new UTF8Encoding()).GetBytes(string.Format(str4, new object[] { str1, str2, phone, str3 }));
            HttpWebRequest length = (HttpWebRequest)WebRequest.Create(str);
            length.Method = "POST";
            length.ContentType = "application/x-www-form-urlencoded";
            length.ContentLength = (long)((int)bytes.Length);
            Stream requestStream = length.GetRequestStream();
            requestStream.Write(bytes, 0, (int)bytes.Length);
            requestStream.Flush();
            requestStream.Close();
            HttpWebResponse response = (HttpWebResponse)length.GetResponse();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return "发送失败，请稍后再试";
            }
            string end = (new StreamReader(response.GetResponseStream(), Encoding.UTF8)).ReadToEnd();
            int num = end.IndexOf("</code>");
            int num1 = end.IndexOf("<code>");
            end.Substring(num1 + 6, num - num1 - 6);
            int num2 = end.IndexOf("</msg>");
            int num3 = end.IndexOf("<msg>");
            return end.Substring(num3 + 5, num2 - num3 - 5);
        }
    }
}