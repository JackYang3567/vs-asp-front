using System;
namespace Game.Entity.Accounts
{
	[Serializable]
	public class ReserveIdentifier
	{
		public const string Tablename = "ReserveIdentifier";
		public const string _GameID = "GameID";
		public const string _IDLevel = "IDLevel";
		public const string _Distribute = "Distribute";
		private int m_gameID;
		private int m_iDLevel;
		private bool m_distribute;
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
		public bool Distribute
		{
			get
			{
				return this.m_distribute;
			}
			set
			{
				this.m_distribute = value;
			}
		}
		public ReserveIdentifier()
		{
			this.m_gameID = 0;
			this.m_iDLevel = 0;
			this.m_distribute = false;
		}
	}
}
