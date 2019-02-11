using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
namespace testOrder
{
	public static class HttpHelp
	{
		public static string RSASign(string signStr, string privateKey)
		{
			string result;
			try
			{
				System.Security.Cryptography.RSACryptoServiceProvider rSACryptoServiceProvider = new System.Security.Cryptography.RSACryptoServiceProvider();
				rSACryptoServiceProvider.FromXmlString(privateKey);
				byte[] inArray = rSACryptoServiceProvider.SignData(System.Text.Encoding.UTF8.GetBytes(signStr), "md5");
				result = System.Convert.ToBase64String(inArray);
			}
			catch (System.Exception ex)
			{
				throw ex;
			}
			return result;
		}
		public static string RSAPrivateKeyJava2DotNet(string privateKey)
		{
			RsaPrivateCrtKeyParameters rsaPrivateCrtKeyParameters = (RsaPrivateCrtKeyParameters)PrivateKeyFactory.CreateKey(System.Convert.FromBase64String(privateKey));
			return string.Format("<RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent><P>{2}</P><Q>{3}</Q><DP>{4}</DP><DQ>{5}</DQ><InverseQ>{6}</InverseQ><D>{7}</D></RSAKeyValue>", new object[]
			{
				System.Convert.ToBase64String(rsaPrivateCrtKeyParameters.Modulus.ToByteArrayUnsigned()),
				System.Convert.ToBase64String(rsaPrivateCrtKeyParameters.PublicExponent.ToByteArrayUnsigned()),
				System.Convert.ToBase64String(rsaPrivateCrtKeyParameters.P.ToByteArrayUnsigned()),
				System.Convert.ToBase64String(rsaPrivateCrtKeyParameters.Q.ToByteArrayUnsigned()),
				System.Convert.ToBase64String(rsaPrivateCrtKeyParameters.DP.ToByteArrayUnsigned()),
				System.Convert.ToBase64String(rsaPrivateCrtKeyParameters.DQ.ToByteArrayUnsigned()),
				System.Convert.ToBase64String(rsaPrivateCrtKeyParameters.QInv.ToByteArrayUnsigned()),
				System.Convert.ToBase64String(rsaPrivateCrtKeyParameters.Exponent.ToByteArrayUnsigned())
			});
		}
		public static bool ValidateRsaSign(string plainText, string publicKey, string signedData)
		{
			bool result;
			try
			{
				System.Security.Cryptography.RSACryptoServiceProvider rSACryptoServiceProvider = new System.Security.Cryptography.RSACryptoServiceProvider();
				rSACryptoServiceProvider.FromXmlString(publicKey);
				result = rSACryptoServiceProvider.VerifyData(System.Text.Encoding.UTF8.GetBytes(plainText), "md5", System.Convert.FromBase64String(signedData));
			}
			catch (System.Exception ex)
			{
				throw ex;
			}
			return result;
		}
		public static string RSAPublicKeyJava2DotNet(string publicKey)
		{
			RsaKeyParameters rsaKeyParameters = (RsaKeyParameters)PublicKeyFactory.CreateKey(System.Convert.FromBase64String(publicKey));
			return string.Format("<RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent></RSAKeyValue>", System.Convert.ToBase64String(rsaKeyParameters.Modulus.ToByteArrayUnsigned()), System.Convert.ToBase64String(rsaKeyParameters.Exponent.ToByteArrayUnsigned()));
		}
		public static string HttpPost(string POSTURL, string PostData)
		{
			WebRequest webRequest = WebRequest.Create(POSTURL);
			webRequest.Method = "POST";
			System.Text.UTF8Encoding uTF8Encoding = new System.Text.UTF8Encoding();
			byte[] bytes = uTF8Encoding.GetBytes(PostData);
			webRequest.ContentType = "application/x-www-form-urlencoded";
			webRequest.ContentLength = (long)bytes.Length;
			System.IO.Stream requestStream = webRequest.GetRequestStream();
			requestStream.Write(bytes, 0, bytes.Length);
			requestStream.Close();
			HttpWebResponse httpWebResponse = (HttpWebResponse)webRequest.GetResponse();
			string empty = string.Empty;
			System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("UTF-8");
			System.IO.Stream responseStream = httpWebResponse.GetResponseStream();
			System.IO.StreamReader streamReader = new System.IO.StreamReader(responseStream, encoding);
			return streamReader.ReadToEnd();
		}
		public static string Get_Http(string url)
		{
			string result;
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
				httpWebRequest.Timeout = 19600;
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				System.IO.Stream responseStream = httpWebResponse.GetResponseStream();
				System.IO.StreamReader streamReader = new System.IO.StreamReader(responseStream, System.Text.Encoding.UTF8);
				System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
				while (-1 != streamReader.Peek())
				{
					stringBuilder.Append(streamReader.ReadLine() + "\r\n");
				}
				result = stringBuilder.ToString();
				httpWebResponse.Close();
			}
			catch (System.Exception ex)
			{
				result = ex.Message;
			}
			return result;
		}
	}
}
