using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class UserCurrencyInfo
	{
		public const string Tablename = "UserCurrencyInfo";
		public const string _UserID = "UserID";
		public const string _Currency = "Currency";
		private int m_userID;
		private decimal m_currency;
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
		public decimal Currency
		{
			get
			{
				return this.m_currency;
			}
			set
			{
				this.m_currency = value;
			}
		}
		public UserCurrencyInfo()
		{
			this.m_userID = 0;
			this.m_currency = 0m;
		}
	}
}
