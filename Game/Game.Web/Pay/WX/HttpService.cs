using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Web;
namespace Game.Web.Pay.WX
{
	public class HttpService
	{
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
					ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(HttpService.CheckValidationResult);
				}
				httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
				httpWebRequest.Method = "POST";
				httpWebRequest.Timeout = timeout * 1000;
				httpWebRequest.ContentType = "text/xml";
				byte[] bytes = System.Text.Encoding.UTF8.GetBytes(xml);
				httpWebRequest.ContentLength = (long)bytes.Length;
				if (isUseCert)
				{
					string physicalApplicationPath = System.Web.HttpContext.Current.Request.PhysicalApplicationPath;
					X509Certificate2 value = new X509Certificate2(physicalApplicationPath + "cert/apiclient_cert.p12", "1233410002");
					httpWebRequest.ClientCertificates.Add(value);
					Log.Debug("WxPayApi", "PostXml used cert");
				}
				System.IO.Stream requestStream = httpWebRequest.GetRequestStream();
				requestStream.Write(bytes, 0, bytes.Length);
				requestStream.Close();
				httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				System.IO.StreamReader streamReader = new System.IO.StreamReader(httpWebResponse.GetResponseStream(), System.Text.Encoding.UTF8);
				result = streamReader.ReadToEnd().Trim();
				streamReader.Close();
			}
			catch (System.Threading.ThreadAbortException ex)
			{
				Log.Error("HttpService", "Thread - caught ThreadAbortException - resetting.");
				Log.Error("Exception message: {0}", ex.Message);
				System.Threading.Thread.ResetAbort();
			}
			catch (WebException ex2)
			{
				Log.Error("HttpService", ex2.ToString());
				if (ex2.Status == WebExceptionStatus.ProtocolError)
				{
					Log.Error("HttpService", "StatusCode : " + ((HttpWebResponse)ex2.Response).StatusCode);
					Log.Error("HttpService", "StatusDescription : " + ((HttpWebResponse)ex2.Response).StatusDescription);
				}
				throw new WxPayException(ex2.ToString());
			}
			catch (System.Exception ex3)
			{
				Log.Error("HttpService", ex3.ToString());
				throw new WxPayException(ex3.ToString());
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
		public static string Get(string url)
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
					ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(HttpService.CheckValidationResult);
				}
				httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
				httpWebRequest.Method = "GET";
				httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				System.IO.StreamReader streamReader = new System.IO.StreamReader(httpWebResponse.GetResponseStream(), System.Text.Encoding.UTF8);
				result = streamReader.ReadToEnd().Trim();
				streamReader.Close();
			}
			catch (System.Threading.ThreadAbortException ex)
			{
				Log.Error("HttpService", "Thread - caught ThreadAbortException - resetting.");
				Log.Error("Exception message: {0}", ex.Message);
				System.Threading.Thread.ResetAbort();
			}
			catch (WebException ex2)
			{
				Log.Error("HttpService", ex2.ToString());
				if (ex2.Status == WebExceptionStatus.ProtocolError)
				{
					Log.Error("HttpService", "StatusCode : " + ((HttpWebResponse)ex2.Response).StatusCode);
					Log.Error("HttpService", "StatusDescription : " + ((HttpWebResponse)ex2.Response).StatusDescription);
				}
				throw new WxPayException(ex2.ToString());
			}
			catch (System.Exception ex3)
			{
				Log.Error("HttpService", ex3.ToString());
				throw new WxPayException(ex3.ToString());
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
	}
}
