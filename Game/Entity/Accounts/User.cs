using System;
namespace Game.Entity.Accounts
{
	public class User : UserInfo
	{
		private AccountsProtect protect;
		private IndividualDatum contact;
		private long goldScore;
		public AccountsProtect Protect
		{
			get
			{
				return this.protect;
			}
			set
			{
				this.protect = value;
			}
		}
		public IndividualDatum Contact
		{
			get
			{
				return this.contact;
			}
			set
			{
				this.contact = value;
			}
		}
		public long GoldScore
		{
			get
			{
				return this.goldScore;
			}
			set
			{
				this.goldScore = value;
			}
		}
		public User()
		{
			this.protect = new AccountsProtect();
			this.contact = new IndividualDatum();
		}
	}
}
