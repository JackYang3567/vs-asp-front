using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class GlobalCheckIn
	{
		public const string Tablename = "GlobalCheckIn";
		public const string _ID = "ID";
		public const string _PresentGold = "PresentGold";
		public const string _CollectNote = "CollectNote";
		private int m_iD;
		private int m_presentGold;
		private string m_collectNote;
		public int ID
		{
			get
			{
				return this.m_iD;
			}
			set
			{
				this.m_iD = value;
			}
		}
		public int PresentGold
		{
			get
			{
				return this.m_presentGold;
			}
			set
			{
				this.m_presentGold = value;
			}
		}
		public string CollectNote
		{
			get
			{
				return this.m_collectNote;
			}
			set
			{
				this.m_collectNote = value;
			}
		}
		public GlobalCheckIn()
		{
			this.m_iD = 0;
			this.m_presentGold = 0;
			this.m_collectNote = "";
		}
	}
}
