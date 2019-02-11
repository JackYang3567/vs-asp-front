using Game.Utils.Cache;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.UI;
namespace Game.Web
{
    public partial class ValidateImage2 : System.Web.UI.Page
	{
		private const double PI = 3.1415926535897931;
		private const double PI2 = 6.2831853071795862;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			ValidateImage2.CreateCheckCodeImage(ValidateImage2.GenerateCheckCode());
		}
		public static string GenerateCheckCode()
		{
			string result = string.Empty;
			System.Random random = new System.Random();
			int num = random.Next(1, 10);
			int num2 = random.Next(1, 10);
			string a;
			string result2;
			if ((a = random.Next(1, 4).ToString()) != null)
			{
				if (a == "1")
				{
					result = string.Concat(new object[]
					{
						num,
						"+",
						num2,
						"="
					});
					WHCache.Default.Save<SessionCache>("VerifyCodeKey", num + num2);
					WHCache.Default.Save<CookiesCache>("VerifyCodeKey", num + num2);
					result2 = result;
					return result2;
				}
				if (a == "2")
				{
					if (num < num2)
					{
						int num3 = num;
						num = num2;
						num2 = num3;
					}
					result = string.Concat(new object[]
					{
						num,
						"-",
						num2,
						"="
					});
					WHCache.Default.Save<SessionCache>("VerifyCodeKey", num - num2);
					WHCache.Default.Save<CookiesCache>("VerifyCodeKey", num - num2);
					result2 = result;
					return result2;
				}
				if (a == "3")
				{
					result = string.Concat(new object[]
					{
						num,
						"*",
						num2,
						"="
					});
					WHCache.Default.Save<SessionCache>("VerifyCodeKey", num * num2);
					WHCache.Default.Save<CookiesCache>("VerifyCodeKey", num * num2);
					result2 = result;
					return result2;
				}
			}
			result = string.Concat(new object[]
			{
				num,
				"+",
				num2,
				"="
			});
			WHCache.Default.Save<SessionCache>("VerifyCodeKey", num + num2);
			WHCache.Default.Save<CookiesCache>("VerifyCodeKey", num + num2);
			result2 = result;
			return result2;
		}
		private Bitmap TwistImage(Bitmap srcBmp, bool bXDir, double dMultValue, double dPhase)
		{
			Bitmap bitmap = new Bitmap(srcBmp.Width, srcBmp.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, bitmap.Width, bitmap.Height);
			graphics.Dispose();
			double num = bXDir ? ((double)bitmap.Height) : ((double)bitmap.Width);
			for (int i = 0; i < bitmap.Width; i++)
			{
				for (int j = 0; j < bitmap.Height; j++)
				{
					double num2 = bXDir ? (6.2831853071795862 * (double)j / num) : (6.2831853071795862 * (double)i / num);
					num2 += dPhase;
					double num3 = System.Math.Sin(num2);
					int num4 = bXDir ? (i + (int)(num3 * dMultValue)) : i;
					int num5 = bXDir ? j : (j + (int)(num3 * dMultValue));
					Color pixel = srcBmp.GetPixel(i, j);
					if (num4 >= 0 && num4 < bitmap.Width && num5 >= 0 && num5 < bitmap.Height)
					{
						bitmap.SetPixel(num4, num5, pixel);
					}
				}
			}
			return bitmap;
		}
		public static void CreateCheckCodeImage(string checkCode)
		{
			if (checkCode != null && !(checkCode.Trim() == string.Empty))
			{
				Bitmap bitmap = new Bitmap((int)System.Math.Ceiling((double)checkCode.Length * 15.0), 25);
				Graphics graphics = Graphics.FromImage(bitmap);
				try
				{
					System.Random random = new System.Random();
					graphics.Clear(Color.White);
					for (int i = 0; i < 12; i++)
					{
						int x = random.Next(bitmap.Width);
						int x2 = random.Next(bitmap.Width);
						int y = random.Next(bitmap.Height);
						int y2 = random.Next(bitmap.Height);
						graphics.DrawLine(new Pen(Color.Silver), x, y, x2, y2);
					}
					Font font = new Font("Arial", 16f, FontStyle.Bold | FontStyle.Italic);
					LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, bitmap.Width, bitmap.Height), Color.Blue, Color.DarkRed, 1.2f, true);
					graphics.DrawString(checkCode, font, brush, 1f, 1f);
					for (int j = 0; j < 100; j++)
					{
						int x3 = random.Next(bitmap.Width);
						int y3 = random.Next(bitmap.Height);
						bitmap.SetPixel(x3, y3, Color.FromArgb(random.Next()));
					}
					graphics.DrawRectangle(new Pen(Color.Silver), 0, 0, bitmap.Width - 1, bitmap.Height - 1);
					System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
					bitmap.Save(memoryStream, ImageFormat.Gif);
					System.Web.HttpContext.Current.Response.ClearContent();
					System.Web.HttpContext.Current.Response.ContentType = "image/Gif";
					System.Web.HttpContext.Current.Response.BinaryWrite(memoryStream.ToArray());
				}
				finally
				{
					graphics.Dispose();
					bitmap.Dispose();
				}
			}
		}
	}
}
