using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class StreamShareInfo
	{
		public const string Tablename = "StreamShareInfo";
		public const string _DateID = "DateID";
		public const string _ShareID = "ShareID";
		public const string _ShareTotals = "ShareTotals";
		public const string _CollectDate = "CollectDate";
		private int m_dateID;
		private int m_shareID;
		private int m_shareTotals;
		private DateTime m_collectDate;
		public int DateID
		{
			get
			{
				return this.m_dateID;
			}
			set
			{
				this.m_dateID = value;
			}
		}
		public int ShareID
		{
			get
			{
				return this.m_shareID;
			}
			set
			{
				this.m_shareID = value;
			}
		}
		public int ShareTotals
		{
			get
			{
				return this.m_shareTotals;
			}
			set
			{
				this.m_shareTotals = value;
			}
		}
		public DateTime CollectDate
		{
			get
			{
				return this.m_collectDate;
			}
			set
			{
				this.m_collectDate = value;
			}
		}
		public StreamShareInfo()
		{
			this.m_dateID = 0;
			this.m_shareID = 0;
			this.m_shareTotals = 0;
			this.m_collectDate = DateTime.Now;
		}
	}
}
