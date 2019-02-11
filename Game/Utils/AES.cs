using System;
using System.Security.Cryptography;
using System.Text;
namespace Game.Utils
{
	public sealed class AES
	{
		private static byte[] Keys = new byte[]
		{
			65,
			114,
			101,
			121,
			111,
			117,
			109,
			121,
			83,
			110,
			111,
			119,
			109,
			97,
			110,
			63
		};
		private AES()
		{
		}
		public static string Decrypt(string cipherText, string cipherkey)
		{
			string result;
			try
			{
				cipherkey = TextUtility.CutLeft(cipherkey, 32);
				cipherkey = cipherkey.PadRight(32, ' ');
				ICryptoTransform cryptoTransform = new RijndaelManaged
				{
					Key = Encoding.UTF8.GetBytes(cipherkey),
					IV = AES.Keys
				}.CreateDecryptor();
				byte[] array = Convert.FromBase64String(cipherText);
				byte[] bytes = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
				result = Encoding.UTF8.GetString(bytes);
			}
			catch
			{
				result = "";
			}
			return result;
		}
		public static byte[] DecryptBuffer(byte[] cipherText, string cipherkey)
		{
			byte[] result;
			try
			{
				cipherkey = TextUtility.CutLeft(cipherkey, 32);
				cipherkey = cipherkey.PadRight(32, ' ');
				RijndaelManaged rijndaelManaged = new RijndaelManaged
				{
					Key = Encoding.UTF8.GetBytes(cipherkey),
					IV = AES.Keys
				};
				result = rijndaelManaged.CreateDecryptor().TransformFinalBlock(cipherText, 0, cipherText.Length);
			}
			catch
			{
				result = null;
			}
			return result;
		}
		public static string Encrypt(string plainText, string cipherkey)
		{
			cipherkey = TextUtility.CutLeft(cipherkey, 32);
			cipherkey = cipherkey.PadRight(32, ' ');
			ICryptoTransform cryptoTransform = new RijndaelManaged
			{
				Key = Encoding.UTF8.GetBytes(cipherkey.Substring(0, 32)),
				IV = AES.Keys
			}.CreateEncryptor();
			byte[] bytes = Encoding.UTF8.GetBytes(plainText);
			return Convert.ToBase64String(cryptoTransform.TransformFinalBlock(bytes, 0, bytes.Length));
		}
		public static byte[] EncryptBuffer(byte[] plainText, string cipherkey)
		{
			cipherkey = TextUtility.CutLeft(cipherkey, 32);
			cipherkey = cipherkey.PadRight(32, ' ');
			RijndaelManaged rijndaelManaged = new RijndaelManaged
			{
				Key = Encoding.UTF8.GetBytes(cipherkey.Substring(0, 32)),
				IV = AES.Keys
			};
			return rijndaelManaged.CreateEncryptor().TransformFinalBlock(plainText, 0, plainText.Length);
		}
	}
}
