using System;
namespace Game.Entity.Record
{
	[Serializable]
	public class RecordConvertUserMedal
	{
		public const string Tablename = "RecordConvertUserMedal";
		public const string _RecordID = "RecordID";
		public const string _UserID = "UserID";
		public const string _CurInsureScore = "CurInsureScore";
		public const string _CurUserMedal = "CurUserMedal";
		public const string _ConvertUserMedal = "ConvertUserMedal";
		public const string _ConvertRate = "ConvertRate";
		public const string _IsGamePlaza = "IsGamePlaza";
		public const string _ClientIP = "ClientIP";
		public const string _CollectDate = "CollectDate";
		private int m_recordID;
		private int m_userID;
		private long m_curInsureScore;
		private int m_curUserMedal;
		private int m_convertUserMedal;
		private decimal m_convertRate;
		private byte m_isGamePlaza;
		private string m_clientIP;
		private DateTime m_collectDate;
		public int RecordID
		{
			get
			{
				return this.m_recordID;
			}
			set
			{
				this.m_recordID = value;
			}
		}
		public int UserID
		{
			get
			{
				return this.m_userID;
			}
			set
			{
				this.m_userID = value;
			}
		}
		public long CurInsureScore
		{
			get
			{
				return this.m_curInsureScore;
			}
			set
			{
				this.m_curInsureScore = value;
			}
		}
		public int CurUserMedal
		{
			get
			{
				return this.m_curUserMedal;
			}
			set
			{
				this.m_curUserMedal = value;
			}
		}
		public int ConvertUserMedal
		{
			get
			{
				return this.m_convertUserMedal;
			}
			set
			{
				this.m_convertUserMedal = value;
			}
		}
		public decimal ConvertRate
		{
			get
			{
				return this.m_convertRate;
			}
			set
			{
				this.m_convertRate = value;
			}
		}
		public byte IsGamePlaza
		{
			get
			{
				return this.m_isGamePlaza;
			}
			set
			{
				this.m_isGamePlaza = value;
			}
		}
		public string ClientIP
		{
			get
			{
				return this.m_clientIP;
			}
			set
			{
				this.m_clientIP = value;
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
		public RecordConvertUserMedal()
		{
			this.m_recordID = 0;
			this.m_userID = 0;
			this.m_curInsureScore = 0L;
			this.m_curUserMedal = 0;
			this.m_convertUserMedal = 0;
			this.m_convertRate = 0m;
			this.m_isGamePlaza = 0;
			this.m_clientIP = "";
			this.m_collectDate = DateTime.Now;
		}
	}
}
