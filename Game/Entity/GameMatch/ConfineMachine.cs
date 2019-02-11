using System;
namespace Game.Entity.GameMatch
{
	[Serializable]
	public class ConfineMachine
	{
		public const string Tablename = "ConfineMachine";
		public const string _MachineSerial = "MachineSerial";
		public const string _EnjoinLogon = "EnjoinLogon";
		public const string _EnjoinRegister = "EnjoinRegister";
		public const string _EnjoinOverDate = "EnjoinOverDate";
		public const string _CollectDate = "CollectDate";
		public const string _CollectNote = "CollectNote";
		private string m_machineSerial;
		private bool m_enjoinLogon;
		private bool m_enjoinRegister;
		private DateTime m_enjoinOverDate;
		private DateTime m_collectDate;
		private string m_collectNote;
		public string MachineSerial
		{
			get
			{
				return this.m_machineSerial;
			}
			set
			{
				this.m_machineSerial = value;
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
		public bool EnjoinRegister
		{
			get
			{
				return this.m_enjoinRegister;
			}
			set
			{
				this.m_enjoinRegister = value;
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
		public ConfineMachine()
		{
			this.m_machineSerial = "";
			this.m_enjoinLogon = false;
			this.m_enjoinRegister = false;
			this.m_enjoinOverDate = DateTime.Now;
			this.m_collectDate = DateTime.Now;
			this.m_collectNote = "";
		}
	}
}
