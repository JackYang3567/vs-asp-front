using System;
using System.Drawing;
using System.Drawing.Imaging;
namespace Game.Utils.Verify
{
	public class VerifyImageInfo
	{
		private Bitmap m_image;
		private string m_contentType = "image/pjpeg";
		private ImageFormat m_imageFormat = ImageFormat.Jpeg;
		public Bitmap Image
		{
			get
			{
				return this.m_image;
			}
			set
			{
				this.m_image = value;
			}
		}
		public string ContentType
		{
			get
			{
				return this.m_contentType;
			}
			set
			{
				this.m_contentType = value;
			}
		}
		public ImageFormat ImageFormat
		{
			get
			{
				return this.m_imageFormat;
			}
			set
			{
				this.m_imageFormat = value;
			}
		}
		public VerifyImageInfo()
		{
		}
		public VerifyImageInfo(string contentType, ImageFormat imageFormat)
		{
			this.m_contentType = contentType;
			this.m_imageFormat = imageFormat;
		}
	}
}
