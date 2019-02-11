using System;
namespace Game.Entity.GameMatch
{
	[Serializable]
	public class StreamMatchFeeInfo
	{
		public const string Tablename = "StreamMatchFeeInfo";
		public const string _RecordID = "RecordID";
		public const string _UserID = "UserID";
		public const string _ServerID = "ServerID";
		public const string _MatchID = "MatchID";
		public const string _MatchNo = "MatchNo";
		public const string _Fee = "Fee";
		public const string _CollectDate = "CollectDate";
		private int m_recordID;
		private int m_userID;
		private int m_serverID;
		private int m_matchID;
		private int m_matchNo;
		private int m_fee;
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
		public int ServerID
		{
			get
			{
				return this.m_serverID;
			}
			set
			{
				this.m_serverID = value;
			}
		}
		public int MatchID
		{
			get
			{
				return this.m_matchID;
			}
			set
			{
				this.m_matchID = value;
			}
		}
		public int MatchNo
		{
			get
			{
				return this.m_matchNo;
			}
			set
			{
				this.m_matchNo = value;
			}
		}
		public int Fee
		{
			get
			{
				return this.m_fee;
			}
			set
			{
				this.m_fee = value;
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
		public StreamMatchFeeInfo()
		{
			this.m_recordID = 0;
			this.m_userID = 0;
			this.m_serverID = 0;
			this.m_matchID = 0;
			this.m_matchNo = 0;
			this.m_fee = 0;
			this.m_collectDate = DateTime.Now;
		}
	}
}
