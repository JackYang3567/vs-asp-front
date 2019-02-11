using System;
using System.Security.Cryptography;
using System.Text;
namespace Game.Facade
{
	public class Jiami
	{
		public static string MD5(string str)
		{
			return Jiami.MD5(str, "UTF-8");
		}
		public static string MD5(string str, string charset)
		{
			System.Security.Cryptography.MD5CryptoServiceProvider mD5CryptoServiceProvider = new System.Security.Cryptography.MD5CryptoServiceProvider();
			byte[] bytes = System.Text.Encoding.GetEncoding(charset).GetBytes(str);
			byte[] array = mD5CryptoServiceProvider.ComputeHash(bytes);
			string text = "";
			for (int i = 0; i < array.Length; i++)
			{
				text += array[i].ToString("x2");
			}
			return text;
		}
		public static string sign(string sourceData, string key)
		{
			System.Security.Cryptography.MD5 mD = System.Security.Cryptography.MD5.Create();
			byte[] bytes = System.Text.Encoding.UTF8.GetBytes(sourceData + key);
			byte[] data = mD.ComputeHash(bytes);
			return Jiami.GetbyteToString(data);
		}
		private static string GetbyteToString(byte[] data)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			for (int i = 0; i < data.Length; i++)
			{
				stringBuilder.Append(data[i].ToString("x2"));
			}
			return stringBuilder.ToString();
		}
	}
}
