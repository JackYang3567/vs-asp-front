using System;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
namespace Game.Facade
{
	public class PasswordCard
	{
		private int _serialNumber;
		public int SerialNumber
		{
			get
			{
				return this._serialNumber;
			}
			set
			{
				this._serialNumber = value;
			}
		}
		public void CreateSerialNumber()
		{
			bool flag = true;
			while (flag)
			{
				string text = string.Empty;
				System.Random random = new System.Random();
				for (int i = 0; i < 9; i++)
				{
					text += random.Next(1, 9).ToString();
				}
				if (!FacadeManage.aideAccountsFacade.PasswordIDIsEnable(text))
				{
					this.SerialNumber = System.Convert.ToInt32(text);
					flag = false;
				}
			}
		}
		public string AddSpace()
		{
			string text = this.SerialNumber.ToString();
			return string.Concat(new string[]
			{
				text.Substring(0, 3),
				" ",
				text.Substring(3, 3),
				" ",
				text.Substring(6, 3)
			});
		}
		public string GetNumberByCoordinate(string coordinate)
		{
			int num = System.Convert.ToInt32(ConfigurationSettings.AppSettings[coordinate]);
			string text = (this.SerialNumber / num % 1000).ToString();
			switch (text.Length)
			{
			case 1:
				text += "00";
				break;
			case 2:
				text += "0";
				break;
			}
			return text;
		}
		public string[] RandomString()
		{
			string[] array = new string[3];
			string[] array2 = new string[]
			{
				"1",
				"2",
				"3",
				"4"
			};
			string[] array3 = new string[]
			{
				"A",
				"B",
				"C",
				"D",
				"E",
				"F"
			};
			System.Random random = new System.Random();
			bool flag = true;
			while (flag)
			{
				for (int i = 0; i < 3; i++)
				{
					string str = array2[random.Next(0, 3)];
					string str2 = array3[random.Next(0, 5)];
					array[i] = str2 + str;
				}
				flag = false;
				if (array[0] == array[1] || array[0] == array[2] || array[1] == array[2])
				{
					flag = true;
				}
			}
			return array;
		}
		public byte[] WritePasswordCardImg(string bgPath)
		{
			Image image = Image.FromFile(bgPath, false);
			Graphics graphics = Graphics.FromImage(image);
			Color color = Color.FromArgb(255, 224, 189);
			Color color2 = Color.FromArgb(112, 51, 0);
			Brush brush = new SolidBrush(color);
			Brush brush2 = new SolidBrush(color2);
			Font font = new Font("Arial", 10f);
			Font font2 = new Font("Arial", 10f, FontStyle.Bold);
			graphics.DrawString(this.AddSpace(), font2, brush2, 65f, 8f, StringFormat.GenericTypographic);
			string[] array = new string[]
			{
				"A1",
				"A2",
				"A3",
				"A4",
				"B1",
				"B2",
				"B3",
				"B4",
				"C1",
				"C2",
				"C3",
				"C4",
				"D1",
				"D2",
				"D3",
				"D4",
				"E1",
				"E2",
				"E3",
				"E4",
				"F1",
				"F2",
				"F3",
				"F4"
			};
			int num = 85;
			int num2 = 72;
			int num3 = 0;
			string s = string.Empty;
			for (int i = 0; i < 6; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					s = this.GetNumberByCoordinate(array[num3]);
					graphics.DrawString(s, font, brush, (float)num, (float)num2);
					num3++;
					num += 90;
				}
				num = 85;
				num2 += 32;
			}
			System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
			image.Save(memoryStream, ImageFormat.Bmp);
			image.Dispose();
			return memoryStream.ToArray();
		}
	}
}
