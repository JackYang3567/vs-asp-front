using System;
namespace Game.Entity.Accounts
{
	[Serializable]
	public class GameIdentifier
	{
		public const string Tablename = "GameIdentifier";
		public const string _UserID = "UserID";
		public const string _GameID = "GameID";
		public const string _IDLevel = "IDLevel";
		private int m_userID;
		private int m_gameID;
		private int m_iDLevel;
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
		public int IDLevel
		{
			get
			{
				return this.m_iDLevel;
			}
			set
			{
				this.m_iDLevel = value;
			}
		}
		public GameIdentifier()
		{
			this.m_userID = 0;
			this.m_gameID = 0;
			this.m_iDLevel = 0;
		}
	}
}
