using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class LivcardBuildStream
	{
		public const string Tablename = "LivcardBuildStream";
		public const string _BuildID = "BuildID";
		public const string _AdminName = "AdminName";
		public const string _CardTypeID = "CardTypeID";
		public const string _CardPrice = "CardPrice";
		public const string _Currrency = "Currrency";
		public const string _BuildCount = "BuildCount";
		public const string _BuildAddr = "BuildAddr";
		public const string _BuildDate = "BuildDate";
		public const string _DownLoadCount = "DownLoadCount";
		public const string _NoteInfo = "NoteInfo";
		public const string _BuildCardPacket = "BuildCardPacket";
		private int m_buildID;
		private string m_adminName;
		private int m_cardTypeID;
		private decimal m_cardPrice;
		private long m_currrency;
		private int m_buildCount;
		private string m_buildAddr;
		private DateTime m_buildDate;
		private int m_downLoadCount;
		private string m_noteInfo;
		private byte[] m_buildCardPacket;
		public int BuildID
		{
			get
			{
				return this.m_buildID;
			}
			set
			{
				this.m_buildID = value;
			}
		}
		public string AdminName
		{
			get
			{
				return this.m_adminName;
			}
			set
			{
				this.m_adminName = value;
			}
		}
		public int CardTypeID
		{
			get
			{
				return this.m_cardTypeID;
			}
			set
			{
				this.m_cardTypeID = value;
			}
		}
		public decimal CardPrice
		{
			get
			{
				return this.m_cardPrice;
			}
			set
			{
				this.m_cardPrice = value;
			}
		}
		public long Currrency
		{
			get
			{
				return this.m_currrency;
			}
			set
			{
				this.m_currrency = value;
			}
		}
		public int BuildCount
		{
			get
			{
				return this.m_buildCount;
			}
			set
			{
				this.m_buildCount = value;
			}
		}
		public string BuildAddr
		{
			get
			{
				return this.m_buildAddr;
			}
			set
			{
				this.m_buildAddr = value;
			}
		}
		public DateTime BuildDate
		{
			get
			{
				return this.m_buildDate;
			}
			set
			{
				this.m_buildDate = value;
			}
		}
		public int DownLoadCount
		{
			get
			{
				return this.m_downLoadCount;
			}
			set
			{
				this.m_downLoadCount = value;
			}
		}
		public string NoteInfo
		{
			get
			{
				return this.m_noteInfo;
			}
			set
			{
				this.m_noteInfo = value;
			}
		}
		public byte[] BuildCardPacket
		{
			get
			{
				return this.m_buildCardPacket;
			}
			set
			{
				this.m_buildCardPacket = value;
			}
		}
		public LivcardBuildStream()
		{
			this.m_buildID = 0;
			this.m_adminName = "";
			this.m_cardTypeID = 0;
			this.m_cardPrice = 0m;
			this.m_currrency = 0L;
			this.m_buildCount = 0;
			this.m_buildAddr = "";
			this.m_buildDate = DateTime.Now;
			this.m_downLoadCount = 0;
			this.m_noteInfo = "";
			this.m_buildCardPacket = null;
		}
	}
}
