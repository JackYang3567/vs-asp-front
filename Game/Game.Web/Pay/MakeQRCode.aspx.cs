using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ThoughtWorks.QRCode.Codec;
namespace Game.Web.Pay
{
    public partial class MakeQRCode : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlForm form1;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["data"]))
			{
				string content = base.Request.QueryString["data"];
				bool[][] array = new QRCodeEncoder
				{
					QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE,
					QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M,
					QRCodeVersion = 0
				}.Encode(content, System.Text.Encoding.UTF8);
				int num = 250;
				Color white = Color.White;
				Color black = Color.Black;
				int num2 = array.Length;
				double num3 = System.Convert.ToDouble(num) / (double)num2;
				SolidBrush solidBrush = new SolidBrush(white);
				SolidBrush solidBrush2 = new SolidBrush(black);
				Bitmap bitmap = new Bitmap(num, num);
				Graphics graphics = Graphics.FromImage(bitmap);
				graphics.FillRectangle(solidBrush, 0, 0, num, num);
				for (int i = 0; i < num2; i++)
				{
					for (int j = 0; j < num2; j++)
					{
						int x = System.Convert.ToInt32(System.Math.Round((double)j * num3));
						int y = System.Convert.ToInt32(System.Math.Round((double)i * num3));
						int width = System.Convert.ToInt32(System.Math.Ceiling((double)(j + 1) * num3) - System.Math.Floor((double)j * num3));
						int height = System.Convert.ToInt32(System.Math.Ceiling((double)(i + 1) * num3) - System.Math.Floor((double)i * num3));
						graphics.FillRectangle(array[j][i] ? solidBrush2 : solidBrush, x, y, width, height);
					}
				}
				System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
				bitmap.Save(memoryStream, ImageFormat.Png);
				base.Response.BinaryWrite(memoryStream.GetBuffer());
				base.Response.End();
			}
		}
	}
}
