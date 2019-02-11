using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Security.Cryptography;
namespace Game.Utils.Verify
{
	public class VerifyImageVer2
	{
		private static byte[] randb = new byte[4];
		private static RNGCryptoServiceProvider rand = new RNGCryptoServiceProvider();
		private static Matrix m = new Matrix();
		private static Bitmap charbmp = new Bitmap(40, 40);
		private static Font[] fonts = new Font[]
		{
			new Font(new FontFamily("Times New Roman"), (float)(16 + VerifyImageVer2.Next(3)), FontStyle.Regular),
			new Font(new FontFamily("Georgia"), (float)(16 + VerifyImageVer2.Next(3)), FontStyle.Regular),
			new Font(new FontFamily("Arial"), (float)(16 + VerifyImageVer2.Next(3)), FontStyle.Regular),
			new Font(new FontFamily("Comic Sans MS"), (float)(16 + VerifyImageVer2.Next(3)), FontStyle.Regular),
			new Font(new FontFamily("Verdana"), (float)(16 + VerifyImageVer2.Next(3)), FontStyle.Regular)
		};
		private static int Next(int max)
		{
			VerifyImageVer2.rand.GetBytes(VerifyImageVer2.randb);
			int num = BitConverter.ToInt32(VerifyImageVer2.randb, 0);
			num %= max + 1;
			if (num < 0)
			{
				num = -num;
			}
			return num;
		}
		private static int Next(int min, int max)
		{
			return VerifyImageVer2.Next(max - min) + min;
		}
		public VerifyImageInfo GenerateImage(string code, int width, int height, Color bgcolor, int textcolor)
		{
			VerifyImageInfo verifyImageInfo = new VerifyImageInfo();
			verifyImageInfo.ImageFormat = ImageFormat.Jpeg;
			verifyImageInfo.ContentType = "image/pjpeg";
			width = 120;
			height = 37;
			Bitmap image = new Bitmap(width, height, PixelFormat.Format32bppArgb);
			Graphics graphics = Graphics.FromImage(image);
			graphics.SmoothingMode = SmoothingMode.HighSpeed;
			graphics.Clear(bgcolor);
			int num = (textcolor == 2) ? 60 : 0;
			Pen pen = new Pen(Color.FromArgb(VerifyImageVer2.Next(50) + num, VerifyImageVer2.Next(50) + num, VerifyImageVer2.Next(50) + num), 1f);
			SolidBrush solidBrush = new SolidBrush(Color.FromArgb(VerifyImageVer2.Next(100), VerifyImageVer2.Next(100), VerifyImageVer2.Next(100)));
			for (int i = 0; i < 3; i++)
			{
				graphics.DrawArc(pen, VerifyImageVer2.Next(20) - 10, VerifyImageVer2.Next(20) - 10, VerifyImageVer2.Next(width) + 10, VerifyImageVer2.Next(height) + 10, VerifyImageVer2.Next(-100, 100), VerifyImageVer2.Next(-200, 200));
			}
			Graphics graphics2 = Graphics.FromImage(VerifyImageVer2.charbmp);
			float num2 = -18f;
			for (int j = 0; j < code.Length; j++)
			{
				VerifyImageVer2.m.Reset();
				VerifyImageVer2.m.RotateAt((float)(VerifyImageVer2.Next(50) - 25), new PointF((float)(VerifyImageVer2.Next(3) + 7), (float)(VerifyImageVer2.Next(3) + 7)));
				graphics2.Clear(Color.Transparent);
				graphics2.Transform = VerifyImageVer2.m;
				solidBrush.Color = Color.Black;
				num2 = num2 + 18f + (float)VerifyImageVer2.Next(5);
				PointF point = new PointF(num2, 2f);
				graphics2.DrawString(code[j].ToString(), VerifyImageVer2.fonts[VerifyImageVer2.Next(VerifyImageVer2.fonts.Length - 1)], solidBrush, new PointF(0f, 0f));
				graphics2.ResetTransform();
				graphics.DrawImage(VerifyImageVer2.charbmp, point);
			}
			solidBrush.Dispose();
			graphics.Dispose();
			graphics2.Dispose();
			verifyImageInfo.Image = image;
			return verifyImageInfo;
		}
	}
}
