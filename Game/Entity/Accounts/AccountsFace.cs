using System;
namespace Game.Entity.Accounts
{
	[Serializable]
	public class AccountsFace
	{
		public const string Tablename = "AccountsFace";
		public const string _ID = "ID";
		public const string _UserID = "UserID";
		public const string _CustomFace = "CustomFace";
		public const string _InsertTime = "InsertTime";
		public const string _InsertAddr = "InsertAddr";
		public const string _InsertMachine = "InsertMachine";
		private int m_iD;
		private int m_userID;
		private byte[] m_customFace;
		private DateTime m_insertTime;
		private string m_insertAddr;
		private string m_insertMachine;
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
		public byte[] CustomFace
		{
			get
			{
				return this.m_customFace;
			}
			set
			{
				this.m_customFace = value;
			}
		}
		public DateTime InsertTime
		{
			get
			{
				return this.m_insertTime;
			}
			set
			{
				this.m_insertTime = value;
			}
		}
		public string InsertAddr
		{
			get
			{
				return this.m_insertAddr;
			}
			set
			{
				this.m_insertAddr = value;
			}
		}
		public string InsertMachine
		{
			get
			{
				return this.m_insertMachine;
			}
			set
			{
				this.m_insertMachine = value;
			}
		}
		public AccountsFace()
		{
			this.m_iD = 0;
			this.m_userID = 0;
			this.m_customFace = null;
			this.m_insertTime = DateTime.Now;
			this.m_insertAddr = "";
			this.m_insertMachine = "";
		}
	}
}
