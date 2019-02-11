using System;
namespace Game.Entity.Accounts
{
	[Serializable]
	public class AccountsMember
	{
		public const string Tablename = "AccountsMember";
		public const string _UserID = "UserID";
		public const string _MemberOrder = "MemberOrder";
		public const string _UserRight = "UserRight";
		public const string _MemberOverDate = "MemberOverDate";
		private int m_userID;
		private byte m_memberOrder;
		private int m_userRight;
		private DateTime m_memberOverDate;
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
		public byte MemberOrder
		{
			get
			{
				return this.m_memberOrder;
			}
			set
			{
				this.m_memberOrder = value;
			}
		}
		public int UserRight
		{
			get
			{
				return this.m_userRight;
			}
			set
			{
				this.m_userRight = value;
			}
		}
		public DateTime MemberOverDate
		{
			get
			{
				return this.m_memberOverDate;
			}
			set
			{
				this.m_memberOverDate = value;
			}
		}
		public AccountsMember()
		{
			this.m_userID = 0;
			this.m_memberOrder = 0;
			this.m_userRight = 0;
			this.m_memberOverDate = DateTime.Now;
		}
	}
}
