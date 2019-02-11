using Game.Facade;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ThoughtWorks.QRCode.Codec;
namespace Game.Web
{
	public class GameDownloads : System.Web.UI.Page
	{
		protected string qrcode = "";
		protected System.Web.UI.HtmlControls.HtmlForm form1;
		protected new Head Header;
		protected Notice Notice;
		protected System.Web.UI.WebControls.Repeater rptData;
		protected Foot Foot;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.rptData.DataSource = FacadeManage.aideNativeWebFacade.GetGameRulesList(10);
				this.rptData.DataBind();
				string host = base.Request.Url.Host;
				this.qrcode = "/images/" + host + ".png";
				string text = base.Server.MapPath(this.qrcode);
				if (!System.IO.File.Exists(text))
				{
					string content = "http://" + base.Request.Url.Host;
					bool[][] array = new QRCodeEncoder
					{
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
					bitmap.Save(text);
				}
			}
		}
	}
}
