using Newtonsoft.Json;
using System;
namespace Game.Entity.Treasure
{
	public class AppReceiptInfo
	{
		private int m_status;
		private AppReceiptInfo2 m_receipt;
		public int Status
		{
			get
			{
				return this.m_status;
			}
			set
			{
				this.m_status = value;
			}
		}
		public AppReceiptInfo2 Receipt
		{
			get
			{
				return this.m_receipt;
			}
			set
			{
				this.m_receipt = value;
			}
		}
		public AppReceiptInfo()
		{
			this.m_status = 0;
			this.m_receipt = new AppReceiptInfo2();
		}
		public string SerializeText()
		{
			return JsonConvert.SerializeObject(this);
		}
		public static AppReceiptInfo DeserializeObject(string jsonText)
		{
			return JsonConvert.DeserializeObject<AppReceiptInfo>(jsonText);
		}
	}
}
