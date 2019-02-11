using Newtonsoft.Json;
using System;
namespace Game.Entity.Accounts
{
	[Serializable]
	public class UserTicketInfo
	{
		private int m_userID;
		private int m_gameID;
		private int m_protectID;
		private string m_accounts;
		private string m_logonPass;
		public int GameID
		{
			get
			{
				return this.m_gameID;
			}
			set
			{
				this.m_gameID = value;
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
		public virtual string Accounts
		{
			get
			{
				return this.m_accounts;
			}
			set
			{
				this.m_accounts = value;
			}
		}
		public UserTicketInfo()
		{
			this.m_userID = 0;
			this.m_gameID = 0;
			this.m_accounts = "";
		}
		public UserTicketInfo(int userID, int gameID, string accounts)
		{
			this.m_gameID = gameID;
			this.m_userID = userID;
			this.m_accounts = accounts;
		}
		public string SerializeText()
		{
			return JsonConvert.SerializeObject(this);
		}
		public static UserTicketInfo DeserializeObject(string jsonText)
		{
			return JsonConvert.DeserializeObject<UserTicketInfo>(jsonText);
		}
	}
}
