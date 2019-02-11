using System;
using System.Security.Cryptography;
using System.Text;
namespace Game.Facade
{
	public class Encrypt
	{
		private class HmacMD5
		{
			private const uint S11 = 7u;
			private const uint S12 = 12u;
			private const uint S13 = 17u;
			private const uint S14 = 22u;
			private const uint S21 = 5u;
			private const uint S22 = 9u;
			private const uint S23 = 14u;
			private const uint S24 = 20u;
			private const uint S31 = 4u;
			private const uint S32 = 11u;
			private const uint S33 = 16u;
			private const uint S34 = 23u;
			private const uint S41 = 6u;
			private const uint S42 = 10u;
			private const uint S43 = 15u;
			private const uint S44 = 21u;
			private uint[] count;
			private uint[] state;
			private byte[] buffer;
			private byte[] Digest;
			private static byte[] pad;
			public HmacMD5()
			{
				this.count = new uint[2];
				this.state = new uint[4];
				this.buffer = new byte[64];
				this.Digest = new byte[16];
				this.init();
			}
			public void init()
			{
				this.count[0] = 0u;
				this.count[1] = 0u;
				this.state[0] = 1732584193u;
				this.state[1] = 4023233417u;
				this.state[2] = 2562383102u;
				this.state[3] = 271733878u;
			}
			public void update(byte[] data, uint length)
			{
				uint num = length;
				uint num2 = this.count[0] >> 3 & 63u;
				uint num3 = length << 3;
				uint num4 = 0u;
				if (length <= 0u)
				{
					return;
				}
				this.count[0] += num3;
				this.count[1] += length >> 29;
				if (this.count[0] < num3)
				{
					this.count[1] += 1u;
				}
				if (num2 > 0u)
				{
					uint num5 = (num2 + length > 64u) ? (64u - num2) : length;
					System.Buffer.BlockCopy(data, 0, this.buffer, (int)num2, (int)num5);
					if (num2 + num5 < 64u)
					{
						return;
					}
					this.transform(this.buffer);
					num4 += num5;
					num -= num5;
				}
				while (num >= 64u)
				{
					System.Buffer.BlockCopy(data, (int)num4, this.buffer, 0, 64);
					this.transform(this.buffer);
					num4 += 64u;
					num -= 64u;
				}
				if (num > 0u)
				{
					System.Buffer.BlockCopy(data, (int)num4, this.buffer, 0, (int)num);
				}
			}
			public byte[] finalize()
			{
				byte[] data = new byte[8];
				this.encode(ref data, this.count, 8u);
				uint num = this.count[0] >> 3 & 63u;
				uint length = (num < 56u) ? (56u - num) : (120u - num);
				this.update(Encrypt.HmacMD5.pad, length);
				this.update(data, 8u);
				this.encode(ref this.Digest, this.state, 16u);
				for (int i = 0; i < 64; i++)
				{
					this.buffer[i] = 0;
				}
				return this.Digest;
			}
			public string md5String()
			{
				string text = "";
				for (int i = 0; i < this.Digest.Length; i++)
				{
					text += this.Digest[i].ToString("x2");
				}
				return text;
			}
			private void transform(byte[] data)
			{
				uint num = this.state[0];
				uint num2 = this.state[1];
				uint num3 = this.state[2];
				uint num4 = this.state[3];
				uint[] array = new uint[16];
				this.decode(ref array, data, 64u);
				this.FF(ref num, num2, num3, num4, array[0], 7u, 3614090360u);
				this.FF(ref num4, num, num2, num3, array[1], 12u, 3905402710u);
				this.FF(ref num3, num4, num, num2, array[2], 17u, 606105819u);
				this.FF(ref num2, num3, num4, num, array[3], 22u, 3250441966u);
				this.FF(ref num, num2, num3, num4, array[4], 7u, 4118548399u);
				this.FF(ref num4, num, num2, num3, array[5], 12u, 1200080426u);
				this.FF(ref num3, num4, num, num2, array[6], 17u, 2821735955u);
				this.FF(ref num2, num3, num4, num, array[7], 22u, 4249261313u);
				this.FF(ref num, num2, num3, num4, array[8], 7u, 1770035416u);
				this.FF(ref num4, num, num2, num3, array[9], 12u, 2336552879u);
				this.FF(ref num3, num4, num, num2, array[10], 17u, 4294925233u);
				this.FF(ref num2, num3, num4, num, array[11], 22u, 2304563134u);
				this.FF(ref num, num2, num3, num4, array[12], 7u, 1804603682u);
				this.FF(ref num4, num, num2, num3, array[13], 12u, 4254626195u);
				this.FF(ref num3, num4, num, num2, array[14], 17u, 2792965006u);
				this.FF(ref num2, num3, num4, num, array[15], 22u, 1236535329u);
				this.GG(ref num, num2, num3, num4, array[1], 5u, 4129170786u);
				this.GG(ref num4, num, num2, num3, array[6], 9u, 3225465664u);
				this.GG(ref num3, num4, num, num2, array[11], 14u, 643717713u);
				this.GG(ref num2, num3, num4, num, array[0], 20u, 3921069994u);
				this.GG(ref num, num2, num3, num4, array[5], 5u, 3593408605u);
				this.GG(ref num4, num, num2, num3, array[10], 9u, 38016083u);
				this.GG(ref num3, num4, num, num2, array[15], 14u, 3634488961u);
				this.GG(ref num2, num3, num4, num, array[4], 20u, 3889429448u);
				this.GG(ref num, num2, num3, num4, array[9], 5u, 568446438u);
				this.GG(ref num4, num, num2, num3, array[14], 9u, 3275163606u);
				this.GG(ref num3, num4, num, num2, array[3], 14u, 4107603335u);
				this.GG(ref num2, num3, num4, num, array[8], 20u, 1163531501u);
				this.GG(ref num, num2, num3, num4, array[13], 5u, 2850285829u);
				this.GG(ref num4, num, num2, num3, array[2], 9u, 4243563512u);
				this.GG(ref num3, num4, num, num2, array[7], 14u, 1735328473u);
				this.GG(ref num2, num3, num4, num, array[12], 20u, 2368359562u);
				this.HH(ref num, num2, num3, num4, array[5], 4u, 4294588738u);
				this.HH(ref num4, num, num2, num3, array[8], 11u, 2272392833u);
				this.HH(ref num3, num4, num, num2, array[11], 16u, 1839030562u);
				this.HH(ref num2, num3, num4, num, array[14], 23u, 4259657740u);
				this.HH(ref num, num2, num3, num4, array[1], 4u, 2763975236u);
				this.HH(ref num4, num, num2, num3, array[4], 11u, 1272893353u);
				this.HH(ref num3, num4, num, num2, array[7], 16u, 4139469664u);
				this.HH(ref num2, num3, num4, num, array[10], 23u, 3200236656u);
				this.HH(ref num, num2, num3, num4, array[13], 4u, 681279174u);
				this.HH(ref num4, num, num2, num3, array[0], 11u, 3936430074u);
				this.HH(ref num3, num4, num, num2, array[3], 16u, 3572445317u);
				this.HH(ref num2, num3, num4, num, array[6], 23u, 76029189u);
				this.HH(ref num, num2, num3, num4, array[9], 4u, 3654602809u);
				this.HH(ref num4, num, num2, num3, array[12], 11u, 3873151461u);
				this.HH(ref num3, num4, num, num2, array[15], 16u, 530742520u);
				this.HH(ref num2, num3, num4, num, array[2], 23u, 3299628645u);
				this.II(ref num, num2, num3, num4, array[0], 6u, 4096336452u);
				this.II(ref num4, num, num2, num3, array[7], 10u, 1126891415u);
				this.II(ref num3, num4, num, num2, array[14], 15u, 2878612391u);
				this.II(ref num2, num3, num4, num, array[5], 21u, 4237533241u);
				this.II(ref num, num2, num3, num4, array[12], 6u, 1700485571u);
				this.II(ref num4, num, num2, num3, array[3], 10u, 2399980690u);
				this.II(ref num3, num4, num, num2, array[10], 15u, 4293915773u);
				this.II(ref num2, num3, num4, num, array[1], 21u, 2240044497u);
				this.II(ref num, num2, num3, num4, array[8], 6u, 1873313359u);
				this.II(ref num4, num, num2, num3, array[15], 10u, 4264355552u);
				this.II(ref num3, num4, num, num2, array[6], 15u, 2734768916u);
				this.II(ref num2, num3, num4, num, array[13], 21u, 1309151649u);
				this.II(ref num, num2, num3, num4, array[4], 6u, 4149444226u);
				this.II(ref num4, num, num2, num3, array[11], 10u, 3174756917u);
				this.II(ref num3, num4, num, num2, array[2], 15u, 718787259u);
				this.II(ref num2, num3, num4, num, array[9], 21u, 3951481745u);
				this.state[0] += num;
				this.state[1] += num2;
				this.state[2] += num3;
				this.state[3] += num4;
				for (int i = 0; i < 16; i++)
				{
					array[i] = 0u;
				}
			}
			private void encode(ref byte[] output, uint[] input, uint len)
			{
				uint num;
				if (System.BitConverter.IsLittleEndian)
				{
					num = 0u;
					for (uint num2 = 0u; num2 < len; num2 += 4u)
					{
						output[(int)((System.UIntPtr)num2)] = (byte)(input[(int)((System.UIntPtr)num)] & 255u);
						output[(int)((System.UIntPtr)(num2 + 1u))] = (byte)(input[(int)((System.UIntPtr)num)] >> 8 & 255u);
						output[(int)((System.UIntPtr)(num2 + 2u))] = (byte)(input[(int)((System.UIntPtr)num)] >> 16 & 255u);
						output[(int)((System.UIntPtr)(num2 + 3u))] = (byte)(input[(int)((System.UIntPtr)num)] >> 24 & 255u);
						num += 1u;
					}
					return;
				}
				num = 0u;
				for (uint num2 = 0u; num2 < len; num2 += 4u)
				{
					output[(int)((System.UIntPtr)(num2 + 3u))] = (byte)(input[(int)((System.UIntPtr)num)] & 255u);
					output[(int)((System.UIntPtr)(num2 + 2u))] = (byte)(input[(int)((System.UIntPtr)num)] >> 8 & 255u);
					output[(int)((System.UIntPtr)(num2 + 1u))] = (byte)(input[(int)((System.UIntPtr)num)] >> 16 & 255u);
					output[(int)((System.UIntPtr)num2)] = (byte)(input[(int)((System.UIntPtr)num)] >> 24 & 255u);
					num += 1u;
				}
			}
			private void decode(ref uint[] output, byte[] input, uint len)
			{
				uint num;
				if (System.BitConverter.IsLittleEndian)
				{
					num = 0u;
					for (uint num2 = 0u; num2 < len; num2 += 4u)
					{
						output[(int)((System.UIntPtr)num)] = (uint)((int)input[(int)((System.UIntPtr)num2)] | (int)input[(int)((System.UIntPtr)(num2 + 1u))] << 8 | (int)input[(int)((System.UIntPtr)(num2 + 2u))] << 16 | (int)input[(int)((System.UIntPtr)(num2 + 3u))] << 24);
						num += 1u;
					}
					return;
				}
				num = 0u;
				for (uint num2 = 0u; num2 < len; num2 += 4u)
				{
					output[(int)((System.UIntPtr)num)] = (uint)((int)input[(int)((System.UIntPtr)(num2 + 3u))] | (int)input[(int)((System.UIntPtr)(num2 + 2u))] << 8 | (int)input[(int)((System.UIntPtr)(num2 + 1u))] << 16 | (int)input[(int)((System.UIntPtr)num2)] << 24);
					num += 1u;
				}
			}
			private uint rotate_left(uint x, uint n)
			{
				return x << (int)n | x >> (int)(32u - n);
			}
			private uint F(uint x, uint y, uint z)
			{
				return (x & y) | (~x & z);
			}
			private uint G(uint x, uint y, uint z)
			{
				return (x & z) | (y & ~z);
			}
			private uint H(uint x, uint y, uint z)
			{
				return x ^ y ^ z;
			}
			private uint I(uint x, uint y, uint z)
			{
				return y ^ (x | ~z);
			}
			private void FF(ref uint a, uint b, uint c, uint d, uint x, uint s, uint ac)
			{
				a += this.F(b, c, d) + x + ac;
				a = this.rotate_left(a, s) + b;
			}
			private void GG(ref uint a, uint b, uint c, uint d, uint x, uint s, uint ac)
			{
				a += this.G(b, c, d) + x + ac;
				a = this.rotate_left(a, s) + b;
			}
			private void HH(ref uint a, uint b, uint c, uint d, uint x, uint s, uint ac)
			{
				a += this.H(b, c, d) + x + ac;
				a = this.rotate_left(a, s) + b;
			}
			private void II(ref uint a, uint b, uint c, uint d, uint x, uint s, uint ac)
			{
				a += this.I(b, c, d) + x + ac;
				a = this.rotate_left(a, s) + b;
			}
			static HmacMD5()
			{
				// Note: this type is marked as 'beforefieldinit'.
				byte[] array = new byte[64];
				array[0] = 128;
				Encrypt.HmacMD5.pad = array;
			}
		}
		public static string md5(string str)
		{
			byte[] array = System.Text.Encoding.Default.GetBytes(str);
			array = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(array);
			string text = "";
			for (int i = 0; i < array.Length; i++)
			{
				text += array[i].ToString("x").PadLeft(2, '0');
			}
			return text;
		}
		public static string SHA256(string str)
		{
			byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str);
			System.Security.Cryptography.SHA256Managed sHA256Managed = new System.Security.Cryptography.SHA256Managed();
			byte[] inArray = sHA256Managed.ComputeHash(bytes);
			return System.Convert.ToBase64String(inArray);
		}
		 
		private static string toHex(byte[] input)
		{
			if (input == null)
			{
				return null;
			}
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(input.Length * 2);
			for (int i = 0; i < input.Length; i++)
			{
				int num = (int)(input[i] & 255);
				if (num < 16)
				{
					stringBuilder.Append("0");
				}
				stringBuilder.Append(num.ToString("x"));
			}
			return stringBuilder.ToString();
		}
	}
}
