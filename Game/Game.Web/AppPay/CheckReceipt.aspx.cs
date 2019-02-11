using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.UI;
namespace Game.Web.AppPay
{
    public partial class CheckReceipt : System.Web.UI.Page
	{
		private string receiptData = "";
		private int userID = GameRequest.GetQueryInt("UserID", 0);
		private string orderID = GameRequest.GetQueryString("OrderID");
		private int payAmount = GameRequest.GetQueryInt("PayAmount", 0);
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!base.IsPostBack)
			{
				System.IO.StreamReader streamReader = new System.IO.StreamReader(base.Request.InputStream);
				this.receiptData = streamReader.ReadToEnd();
				string jsonText = this.AppInfo(this.receiptData);
				AppReceiptInfo appReceiptInfo = AppReceiptInfo.DeserializeObject(jsonText);
				ShareDetialInfo shareDetialInfo = new ShareDetialInfo();
				shareDetialInfo.UserID = this.userID;
				shareDetialInfo.OrderID = this.orderID;
				shareDetialInfo.PayAmount = this.payAmount;
				shareDetialInfo.ShareID = 100;
				TreasureFacade treasureFacade = new TreasureFacade();
				treasureFacade.WriteReturnAppDetail(shareDetialInfo, appReceiptInfo);
				if (appReceiptInfo.Status == 0)
				{
					try
					{
						Message message = treasureFacade.FilliedApp(shareDetialInfo, appReceiptInfo.Receipt.product_id);
						if (message.Success)
						{
							base.Response.Write("0");
						}
						else
						{
							base.Response.Write(message.Content);
						}
						return;
					}
					catch (System.Exception ex)
					{
						base.Response.Write(ex.Message);
						return;
					}
				}
				base.Response.Write("失败");
			}
		}
		public string AppInfo(string receiptData)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("{\"receipt-data\":\"" + receiptData + "\"}");
			return this.Send_(ApplicationSettings.Get("appUrl"), stringBuilder.ToString());
		}
		public string Send_(string url, string message)
		{
			System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("utf-8");
			byte[] bytes = encoding.GetBytes(message);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
			httpWebRequest.Method = "POST";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			httpWebRequest.ContentLength = (long)bytes.Length;
			System.IO.Stream requestStream = httpWebRequest.GetRequestStream();
			requestStream.Write(bytes, 0, bytes.Length);
			requestStream.Close();
			HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			System.IO.Stream responseStream = httpWebResponse.GetResponseStream();
			System.IO.StreamReader streamReader = new System.IO.StreamReader(responseStream, encoding);
			string result = streamReader.ReadToEnd();
			streamReader.Close();
			httpWebResponse.Close();
			return result;
		}
	}
}
