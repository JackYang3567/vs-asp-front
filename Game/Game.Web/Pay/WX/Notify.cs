using System;
using System.IO;
using System.Text;
using System.Web.UI;
namespace Game.Web.Pay.WX
{
	public class Notify
	{
		public System.Web.UI.Page page
		{
			get;
			set;
		}
		public Notify(System.Web.UI.Page page)
		{
			this.page = page;
		}
		public WxPayData GetNotifyData()
		{
			System.IO.Stream inputStream = this.page.Request.InputStream;
			byte[] array = new byte[1024];
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			int count;
			while ((count = inputStream.Read(array, 0, 1024)) > 0)
			{
				stringBuilder.Append(System.Text.Encoding.UTF8.GetString(array, 0, count));
			}
			inputStream.Flush();
			inputStream.Close();
			inputStream.Dispose();
			Log.Info(base.GetType().ToString(), "Receive data from WeChat : " + stringBuilder.ToString());
			WxPayData wxPayData = new WxPayData();
			try
			{
				wxPayData.FromXml(stringBuilder.ToString());
			}
			catch (WxPayException ex)
			{
				WxPayData wxPayData2 = new WxPayData();
				wxPayData2.SetValue("return_code", "FAIL");
				wxPayData2.SetValue("return_msg", ex.Message);
				Log.Error(base.GetType().ToString(), "Sign check error : " + wxPayData2.ToXml());
				this.page.Response.Write(wxPayData2.ToXml());
				this.page.Response.End();
			}
			Log.Info(base.GetType().ToString(), "Check sign success");
			return wxPayData;
		}
		public virtual void ProcessNotify()
		{
		}
	}
}
