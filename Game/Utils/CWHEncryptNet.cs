using System;
using System.Text;

namespace Game.Utils
{
    public sealed class CWHEncryptNet
    {
        private static ushort ENCRYPT_KEY_LEN;

        private static ushort MAX_ENCRYPT_LEN;

        private static ushort MAX_SOURCE_LEN;

        private static ushort XOR_TIMES;

        static CWHEncryptNet()
        {
            CWHEncryptNet.ENCRYPT_KEY_LEN = 8;
            CWHEncryptNet.MAX_ENCRYPT_LEN = (ushort)(CWHEncryptNet.MAX_SOURCE_LEN * CWHEncryptNet.XOR_TIMES);
            CWHEncryptNet.MAX_SOURCE_LEN = 64;
            CWHEncryptNet.XOR_TIMES = 8;
        }

        private CWHEncryptNet()
        {
        }

        public static string XorCrevasse(string encrypData)
        {
            StringBuilder stringBuilder = new StringBuilder();
            ushort length = (ushort)encrypData.Length;
            if (length < CWHEncryptNet.ENCRYPT_KEY_LEN * 8)
            {
                return "";
            }
            ushort num = Convert.ToUInt16(encrypData.Substring(0, 4), 16);
            if (length != (num + CWHEncryptNet.ENCRYPT_KEY_LEN - 1) / CWHEncryptNet.ENCRYPT_KEY_LEN * CWHEncryptNet.ENCRYPT_KEY_LEN * 8)
            {
                return "";
            }
            for (int i = 0; i < num; i++)
            {
                string str = "";
                string str1 = "";
                str = encrypData.Substring(i * 8, 4);
                str1 = encrypData.Substring(i * 8 + 4, 4);
                ushort num1 = Convert.ToUInt16(str, 16);
                ushort num2 = Convert.ToUInt16(str1, 16);
                stringBuilder.Append((char)(num1 ^ num2));
            }
            return stringBuilder.ToString();
        }

        public static string XorEncrypt(string sourceData)
        {
            StringBuilder stringBuilder = new StringBuilder();
            ushort[] length = new ushort[CWHEncryptNet.ENCRYPT_KEY_LEN];
            length[0] = (ushort)sourceData.Length;
            Random random = new Random();
            for (int i = 1; i < (int)length.Length; i++)
            {
                length[i] = (ushort)(random.Next(0, 65535) % 65535);
            }
            ushort num = 0;
            ushort eNCRYPTKEYLEN = (ushort)((length[0] + CWHEncryptNet.ENCRYPT_KEY_LEN - 1) / CWHEncryptNet.ENCRYPT_KEY_LEN * CWHEncryptNet.ENCRYPT_KEY_LEN);
            for (ushort j = 0; j < eNCRYPTKEYLEN; j = (ushort)(j + 1))
            {
                num = (j >= length[0] ? (ushort)(length[j % CWHEncryptNet.ENCRYPT_KEY_LEN] ^ (ushort)(random.Next(0, 65535) % 65535)) : (ushort)(sourceData[j] ^ (char)length[j % CWHEncryptNet.ENCRYPT_KEY_LEN]));
                stringBuilder.Append(length[j % CWHEncryptNet.ENCRYPT_KEY_LEN].ToString("X4")).Append(num.ToString("X4"));
            }
            return stringBuilder.ToString();
        }
    }
}