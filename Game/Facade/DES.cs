using Game.Utils;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
namespace Game.Facade
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
				byte[] bytes = System.Text.Encoding.UTF8.GetBytes(decryptKey);
				byte[] keys = DES.Keys;
				byte[] array = System.Convert.FromBase64String(decryptString);
				System.Security.Cryptography.DESCryptoServiceProvider dESCryptoServiceProvider = new System.Security.Cryptography.DESCryptoServiceProvider();
				System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
				System.Security.Cryptography.CryptoStream cryptoStream = new System.Security.Cryptography.CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(bytes, keys), System.Security.Cryptography.CryptoStreamMode.Write);
				cryptoStream.Write(array, 0, array.Length);
				cryptoStream.FlushFinalBlock();
				result = System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());
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
			byte[] bytes = System.Text.Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
			byte[] keys = DES.Keys;
			byte[] bytes2 = System.Text.Encoding.UTF8.GetBytes(encryptString);
			System.Security.Cryptography.DESCryptoServiceProvider dESCryptoServiceProvider = new System.Security.Cryptography.DESCryptoServiceProvider();
			System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
			System.Security.Cryptography.CryptoStream cryptoStream = new System.Security.Cryptography.CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(bytes, keys), System.Security.Cryptography.CryptoStreamMode.Write);
			cryptoStream.Write(bytes2, 0, bytes2.Length);
			cryptoStream.FlushFinalBlock();
			return System.Convert.ToBase64String(memoryStream.ToArray());
		}
		public static string md5_32(string s)
		{
			System.Security.Cryptography.MD5 mD = new System.Security.Cryptography.MD5CryptoServiceProvider();
			byte[] array = System.Text.Encoding.UTF8.GetBytes(s);
			array = mD.ComputeHash(array);
			mD.Clear();
			string text = "";
			for (int i = 0; i < array.Length; i++)
			{
				text += System.Convert.ToString(array[i], 16).PadLeft(2, '0');
			}
			return text.PadLeft(32, '0');
		}
	}
}
