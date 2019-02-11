using Game.Utils;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Web;
using ThoughtWorks.QRCode.Codec;
namespace Game.Web.WS
{
	public class QRCode : System.Web.IHttpHandler
	{
		public bool IsReusable
		{
			get
			{
				return false;
			}
		}
		public void ProcessRequest(System.Web.HttpContext context)
		{
			this.GetQRCode(context);
		}
		private void GetQRCode(System.Web.HttpContext context)
		{
			string queryString = GameRequest.GetQueryString("qt");
			string queryString2 = GameRequest.GetQueryString("qm");
			int queryInt = GameRequest.GetQueryInt("qs", 0);
			if (queryString != string.Empty)
			{
				this.calQrcode(queryString, queryString2, queryInt, context);
			}
		}
		private void calQrcode(string sData, string icoURL, int size, System.Web.HttpContext context)
		{
			Color white = Color.White;
			Color black = Color.Black;
			System.Text.Encoding.UTF8.GetBytes(sData);
			bool[][] array = new QRCodeEncoder
			{
				QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE,
				QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M,
				QRCodeVersion = 0
			}.Encode(sData, System.Text.Encoding.UTF8);
			int num = array.Length;
			double num2 = System.Convert.ToDouble(size) / (double)num;
			SolidBrush solidBrush = new SolidBrush(white);
			SolidBrush solidBrush2 = new SolidBrush(black);
			Bitmap bitmap = new Bitmap(size, size);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.FillRectangle(solidBrush, 0, 0, size, size);
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num; j++)
				{
					int x = System.Convert.ToInt32(System.Math.Round((double)j * num2));
					int y = System.Convert.ToInt32(System.Math.Round((double)i * num2));
					int width = System.Convert.ToInt32(System.Math.Ceiling((double)(j + 1) * num2) - System.Math.Floor((double)j * num2));
					int height = System.Convert.ToInt32(System.Math.Ceiling((double)(i + 1) * num2) - System.Math.Floor((double)i * num2));
					graphics.FillRectangle(array[j][i] ? solidBrush2 : solidBrush, x, y, width, height);
				}
			}
			System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
			bitmap.Save(memoryStream, ImageFormat.Png);
			context.Response.ClearContent();
			context.Response.ContentType = "image/png";
			context.Response.BinaryWrite(memoryStream.ToArray());
			bitmap.Dispose();
		}
		private Bitmap CoverImage(Bitmap original, Bitmap image, Graphics graph = null)
		{
			int width = original.Width;
			int num = width / 4;
			image = this.ResizeImage(image, num, num);
			graph = ((graph == null) ? Graphics.FromImage(original) : graph);
			graph.DrawImage(image, (original.Width - num) / 2, (original.Height - num) / 2, num, num);
			graph.Dispose();
			return original;
		}
		private Bitmap ResizeImage(Bitmap original, int width, int height)
		{
			Bitmap result;
			try
			{
				Bitmap bitmap = new Bitmap(width, height);
				Graphics graphics = Graphics.FromImage(bitmap);
				graphics.CompositingQuality = CompositingQuality.HighQuality;
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphics.DrawImage(original, new Rectangle(0, 0, width, height), new Rectangle(0, 0, original.Width, original.Height), GraphicsUnit.Pixel);
				graphics.Dispose();
				result = bitmap;
			}
			catch
			{
				result = null;
			}
			return result;
		}
	}
}
