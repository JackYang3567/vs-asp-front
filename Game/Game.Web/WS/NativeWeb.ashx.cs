using Game.Entity.NativeWeb;
using Game.Facade;
using Game.Utils;
using Qr.Net.Imaging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Web;
namespace Game.Web.WS
{
	public class NativeWeb : System.Web.IHttpHandler
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
			context.Response.ContentType = "application/json";
			string text = GameRequest.GetQueryString("action").ToLower();
			string a;
			if ((a = text) != null)
			{
				if (a == "getqrcodeimage")
				{
					this.GetQRCodeImage(context);
				}
				else
				{
					if (a == "getclientip")
					{
						this.GetClientIP(context);
					}
					else
					{
						if (a == "getnoticelist")
						{
							this.GetNoticeList(context);
						}
						else
						{
							if (a == "getmobilenotice")
							{
								this.GetMobileNotice(context);
							}
							else
							{
								if (a == "getawardorder")
								{
									this.GetAwardOrder(context);
								}
							}
						}
					}
				}
			}
		}
		private void GetQRCodeImage(System.Web.HttpContext context)
		{
			string queryString = GameRequest.GetQueryString("url");
			if (!string.IsNullOrEmpty(queryString))
			{
				QrImage qrImage = new QrImage();
				qrImage.Mode = "byte";
				qrImage.Version = -1;
				qrImage.Size = 100;
				qrImage.Padding = 10;
				qrImage.Level = "Q";
				qrImage.Background = Color.White;
				qrImage.Foreground = Color.Black;
				try
				{
					System.IO.FileStream fileStream = new System.IO.FileStream(TextUtility.GetFullPath("/favicon.ico"), System.IO.FileMode.Open);
					Icon icon = new Icon(fileStream, 256, 256);
					qrImage.Logo = icon.ToBitmap();
					fileStream.Close();
				}
				catch
				{
				}
				try
				{
					Bitmap bitmap = qrImage.CreateImage(queryString);
					System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
					bitmap.Save(memoryStream, ImageFormat.Bmp);
					context.Response.ClearContent();
					context.Response.ContentType = "image/png";
					context.Response.BinaryWrite(memoryStream.ToArray());
					bitmap.Dispose();
				}
				catch
				{
				}
			}
		}
		private void GetClientIP(System.Web.HttpContext context)
		{
			context.Response.ContentType = "text/plain";
			context.Response.Write(GameRequest.GetUserIP());
		}
		private void GetNoticeList(System.Web.HttpContext context)
		{
            System.Collections.Generic.IList<Game.Entity.NativeWeb.News> topNewsList = FacadeManage.aideNativeWebFacade.GetTopNewsList(0, 0, 0, 5);
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			if (topNewsList != null)
			{
                foreach (Game.Entity.NativeWeb.News current in topNewsList)
				{
					stringBuilder.AppendFormat("<a href='/News/NewsView.aspx?param={0}' target=\"_blank\">{1}</a>&nbsp;&nbsp;&nbsp;&nbsp;", current.NewsID, current.Subject.ToString());
				}
			}
			context.Response.Write(stringBuilder.ToString());
		}
		private void GetMobileNotice(System.Web.HttpContext context)
		{
			int queryInt = GameRequest.GetQueryInt("kindid", 0);
		}
		private void GetAwardOrder(System.Web.HttpContext context)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("<ul>");
			AjaxJsonValid ajaxJsonValid = new AjaxJsonValid();
			try
			{
				System.Data.DataSet topOrder = FacadeManage.aideNativeWebFacade.GetTopOrder(10);
				if (topOrder != null)
				{
					foreach (System.Data.DataRow dataRow in topOrder.Tables[0].Rows)
					{
						stringBuilder.Append("<li class=\"f12\">");
						stringBuilder.AppendFormat("<p>恭喜玩家：{0}</p>", FacadeManage.aideAccountsFacade.GetNickNameByUserID(System.Convert.ToInt32(dataRow["UserID"])));
						stringBuilder.AppendFormat("<p>成功兑换：{0}</p>", dataRow["AwardName"]);
						stringBuilder.AppendFormat("<p>兑换时间：{0}</p>", dataRow["BuyDate"]);
						stringBuilder.Append("</li>");
					}
				}
				ajaxJsonValid.SetValidDataValue(true);
				stringBuilder.Append("</ul>");
				ajaxJsonValid.AddDataItem("html", stringBuilder.ToString());
				ajaxJsonValid.AddDataItem("count", topOrder.Tables[0].Rows.Count);
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
			catch (System.Exception ex)
			{
				ajaxJsonValid.msg = ex.ToString();
				context.Response.Write(ajaxJsonValid.SerializeToJson());
			}
		}
	}
}
