using System;
namespace Game.Entity.GameMatch
{
	[Serializable]
	public class ConfineAddress
	{
		public const string Tablename = "ConfineAddress";
		public const string _AddrString = "AddrString";
		public const string _EnjoinLogon = "EnjoinLogon";
		public const string _EnjoinOverDate = "EnjoinOverDate";
		public const string _CollectDate = "CollectDate";
		public const string _CollectNote = "CollectNote";
		private string m_addrString;
		private bool m_enjoinLogon;
		private DateTime m_enjoinOverDate;
		private DateTime m_collectDate;
		private string m_collectNote;
		public string AddrString
		{
			get
			{
				return this.m_addrString;
			}
			set
			{
				this.m_addrString = value;
			}
		}
		public bool EnjoinLogon
		{
			get
			{
				return this.m_enjoinLogon;
			}
			set
			{
				this.m_enjoinLogon = value;
			}
		}
		public DateTime EnjoinOverDate
		{
			get
			{
				return this.m_enjoinOverDate;
			}
			set
			{
				this.m_enjoinOverDate = value;
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
		public ConfineAddress()
		{
			this.m_addrString = "";
			this.m_enjoinLogon = false;
			this.m_enjoinOverDate = DateTime.Now;
			this.m_collectDate = DateTime.Now;
			this.m_collectNote = "";
		}
	}
}
