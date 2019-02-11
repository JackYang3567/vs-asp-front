using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
namespace Game.Utils
{
	public class SymmetricMethod
	{
		private SymmetricAlgorithm mobjCryptoService;
		public SymmetricMethod()
		{
			this.mobjCryptoService = new RijndaelManaged();
		}
		private byte[] GetLegalKey()
		{
			string text = "A7Df09!325Bg6A5aB@40ahkFCklAuB4D#40Dqy0D7oD8$AvB8Dd6b%aDa8Ae8709*44D41d";
			this.mobjCryptoService.GenerateKey();
			byte[] key = this.mobjCryptoService.Key;
			int num = key.Length;
			if (text.Length > num)
			{
				text = text.Substring(0, num);
			}
			else
			{
				if (text.Length < num)
				{
					text = text.PadRight(num, ' ');
				}
			}
			return Encoding.ASCII.GetBytes(text);
		}
		private byte[] GetLegalIV()
		{
			string text = "GF46dD87%AgD2(3FjC467Bk%&B241A95Fk&7tD3452f*96b4465(e797fAa44A6be8Aa259";
			this.mobjCryptoService.GenerateIV();
			byte[] iV = this.mobjCryptoService.IV;
			int num = iV.Length;
			if (text.Length > num)
			{
				text = text.Substring(0, num);
			}
			else
			{
				if (text.Length < num)
				{
					text = text.PadRight(num, ' ');
				}
			}
			return Encoding.ASCII.GetBytes(text);
		}
		public string Encrypto(string Source)
		{
			if (string.IsNullOrEmpty(Source))
			{
				return "";
			}
			byte[] bytes = Encoding.UTF8.GetBytes(Source);
			MemoryStream memoryStream = new MemoryStream();
			this.mobjCryptoService.Key = this.GetLegalKey();
			this.mobjCryptoService.IV = this.GetLegalIV();
			ICryptoTransform transform = this.mobjCryptoService.CreateEncryptor();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			cryptoStream.Write(bytes, 0, bytes.Length);
			cryptoStream.FlushFinalBlock();
			memoryStream.Close();
			byte[] inArray = memoryStream.ToArray();
			return Convert.ToBase64String(inArray);
		}
		public string Decrypto(string Source)
		{
			if (string.IsNullOrEmpty(Source))
			{
				return "";
			}
			string result;
			try
			{
				byte[] array = Convert.FromBase64String(Source);
				MemoryStream stream = new MemoryStream(array, 0, array.Length);
				this.mobjCryptoService.Key = this.GetLegalKey();
				this.mobjCryptoService.IV = this.GetLegalIV();
				ICryptoTransform transform = this.mobjCryptoService.CreateDecryptor();
				CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
				StreamReader streamReader = new StreamReader(stream2);
				result = streamReader.ReadToEnd();
			}
			catch
			{
				result = "";
			}
			return result;
		}
	}
}
