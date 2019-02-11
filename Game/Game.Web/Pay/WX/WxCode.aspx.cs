using Game.Facade;
using Game.Utils;
using Game.Web.Themes.Standard;
using Qr.Net.Imaging;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.UI.HtmlControls;
namespace Game.Web.Pay.WX
{
    public partial class WxCode : UCPageBase
	{
		public string imagecode = string.Empty;
		public string orderid = string.Empty;
		public string amountcode = string.Empty;
		protected Common_Header sHeader;
		protected Pay_Sidebar sPaySidebar;
		protected System.Web.UI.HtmlControls.HtmlForm fmStep1;
		protected Common_Footer sFooter;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			string a = base.Request.Form["return_code"];
			string arg_2B_0 = base.Request.Form["return_msg"];
			string text = base.Request.Form["code_url"];
			string text2 = base.Request.Form["orderID"];
			string text3 = base.Request.Form["amount"];
			if (a == "SUCCESS" && text != null && text != "")
			{
				Bitmap bitmap = new QrImage
				{
					Mode = "byte",
					Version = -1,
					Size = 200,
					Padding = 10,
					Level = "Q",
					Background = Color.White,
					Foreground = Color.Black
				}.CreateImage(text);
				System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
				bitmap.Save(memoryStream, ImageFormat.Png);
				byte[] buffer = memoryStream.GetBuffer();
				this.imagecode = System.Convert.ToBase64String(buffer, 0, buffer.Length);
				this.amountcode = text3;
				this.orderid = text2;
			}
		}
		protected override void AddHeaderTitle()
		{
			this.AddMetaTitle("微信扫码 - " + ApplicationSettings.Get("title"));
			this.AddMetaKeywords(ApplicationSettings.Get("keywords"));
			this.AddMetaDescription(ApplicationSettings.Get("description"));
		}
	}
}
