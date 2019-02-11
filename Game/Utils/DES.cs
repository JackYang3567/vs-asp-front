using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
namespace Game.Utils
{
	public class DES
	{
		private static byte[] Keys = new byte[]
		{
			18,
			52,
			86,
			120,
			144,
			171,
			205,
			239
		};
		public static string Decrypt(string decryptString, string decryptKey)
		{
			string result;
			try
			{
				decryptKey = TextUtility.CutLeft(decryptKey, 8);
				decryptKey = decryptKey.PadRight(8, ' ');
				byte[] bytes = Encoding.UTF8.GetBytes(decryptKey);
				byte[] keys = DES.Keys;
				byte[] array = Convert.FromBase64String(decryptString);
				DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
				MemoryStream memoryStream = new MemoryStream();
				CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(bytes, keys), CryptoStreamMode.Write);
				cryptoStream.Write(array, 0, array.Length);
				cryptoStream.FlushFinalBlock();
				result = Encoding.UTF8.GetString(memoryStream.ToArray());
			}
			catch
			{
				result = "";
			}
			return result;
		}
		public static string Encrypt(string encryptString, string encryptKey)
		{
			encryptKey = TextUtility.CutLeft(encryptKey, 8);
			encryptKey = encryptKey.PadRight(8, ' ');
			byte[] bytes = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
			byte[] keys = DES.Keys;
			byte[] bytes2 = Encoding.UTF8.GetBytes(encryptString);
			DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(bytes, keys), CryptoStreamMode.Write);
			cryptoStream.Write(bytes2, 0, bytes2.Length);
			cryptoStream.FlushFinalBlock();
			return Convert.ToBase64String(memoryStream.ToArray());
		}
	}
}
