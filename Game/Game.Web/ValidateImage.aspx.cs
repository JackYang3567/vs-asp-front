using Game.Utils;
using Game.Utils.Cache;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Game.Web
{
    public partial class ValidateImage : System.Web.UI.Page, System.Web.SessionState.IRequiresSessionState
    {
        private static Bitmap charbmp = new Bitmap(40, 40);
        private static Matrix m = new Matrix();
        private static byte[] randb = new byte[4];
        private static System.Security.Cryptography.RNGCryptoServiceProvider rand = new System.Security.Cryptography.RNGCryptoServiceProvider();
        private static Font[] fonts = new Font[]
		{
			new Font(new FontFamily("Times New Roman"), (float)(16 + ValidateImage.Next(3)), FontStyle.Regular),
			new Font(new FontFamily("Georgia"), (float)(16 + ValidateImage.Next(3)), FontStyle.Regular),
			new Font(new FontFamily("Arial"), (float)(16 + ValidateImage.Next(3)), FontStyle.Regular),
			new Font(new FontFamily("Comic Sans MS"), (float)(16 + ValidateImage.Next(3)), FontStyle.Regular),
			new Font(new FontFamily("Verdana"), (float)(16 + ValidateImage.Next(3)), FontStyle.Regular)
		};
        protected System.Web.UI.HtmlControls.HtmlForm form1;
        private void Page_Load(object sender, System.EventArgs e)
        {
            string text = TextUtility.CreateAuthStr(4, true);
            WHCache.Default.Save<SessionCache>("VerifyCodeKey", text);
            WHCache.Default.Save<CookiesCache>("VerifyCodeKey", text);
            this.CreateImage(text);
        }
        private static int Next(int max)
        {
            ValidateImage.rand.GetBytes(ValidateImage.randb);
            int num = System.BitConverter.ToInt32(ValidateImage.randb, 0);
            num %= max + 1;
            if (num < 0)
            {
                num = -num;
            }
            return num;
        }
        private static int Next(int min, int max)
        {
            return ValidateImage.Next(max - min) + min;
        }
        private void CreateImage(string randomcode)
        {
            int num = 90;
            int num2 = 28;
            Bitmap bitmap = new Bitmap(num, num2, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = SmoothingMode.HighSpeed;
            graphics.Clear(Color.White);
            graphics.DrawRectangle(new Pen(Color.Black, 0f), 0, 0, bitmap.Width - 1, bitmap.Height - 1);
            int num3 = 60;
            Pen pen = new Pen(Color.FromArgb(ValidateImage.Next(50) + num3, ValidateImage.Next(50) + num3, ValidateImage.Next(50) + num3), 1f);
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(ValidateImage.Next(100), ValidateImage.Next(100), ValidateImage.Next(100)));
            for (int i = 0; i < 2; i++)
            {
                graphics.DrawArc(pen, ValidateImage.Next(20) - 10, ValidateImage.Next(20) - 10, ValidateImage.Next(num) + 10, ValidateImage.Next(num2) + 10, ValidateImage.Next(-100, 100), ValidateImage.Next(-200, 200));
            }
            Graphics graphics2 = Graphics.FromImage(ValidateImage.charbmp);
            float num4 = -18f;
            for (int j = 0; j < randomcode.Length; j++)
            {
                ValidateImage.m.Reset();
                ValidateImage.m.RotateAt((float)(ValidateImage.Next(50) - 25), new PointF((float)(ValidateImage.Next(3) + 7), (float)(ValidateImage.Next(3) + 7)));
                graphics2.Clear(Color.Transparent);
                graphics2.Transform = ValidateImage.m;
                solidBrush.Color = Color.Black;
                num4 = num4 + 18f + (float)ValidateImage.Next(5);
                PointF point = new PointF(num4, 2f);
                graphics2.DrawString(randomcode[j].ToString(), ValidateImage.fonts[ValidateImage.Next(ValidateImage.fonts.Length - 1)], solidBrush, new PointF(0f, 0f));
                graphics2.ResetTransform();
                graphics.DrawImage(ValidateImage.charbmp, point);
            }
            solidBrush.Dispose();
            graphics.Dispose();
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            bitmap.Save(memoryStream, ImageFormat.Gif);
            base.Response.ClearContent();
            base.Response.ContentType = "image/gif";
            base.Response.BinaryWrite(memoryStream.ToArray());
            bitmap.Dispose();
        }
    }
}
