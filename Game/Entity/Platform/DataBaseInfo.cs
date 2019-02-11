using System;
namespace Game.Entity.Platform
{
	[Serializable]
	public class DataBaseInfo
	{
		public const string Tablename = "DataBaseInfo";
		public const string _DBInfoID = "DBInfoID";
		public const string _DBAddr = "DBAddr";
		public const string _DBPort = "DBPort";
		public const string _DBUser = "DBUser";
		public const string _DBPassword = "DBPassword";
		public const string _MachineID = "MachineID";
		public const string _Information = "Information";
		private int m_dBInfoID;
		private string m_dBAddr;
		private int m_dBPort;
		private string m_dBUser;
		private string m_dBPassword;
		private string m_machineID;
		private string m_information;
		public int DBInfoID
		{
			get
			{
				return this.m_dBInfoID;
			}
			set
			{
				this.m_dBInfoID = value;
			}
		}
		public string DBAddr
		{
			get
			{
				return this.m_dBAddr;
			}
			set
			{
				this.m_dBAddr = value;
			}
		}
		public int DBPort
		{
			get
			{
				return this.m_dBPort;
			}
			set
			{
				this.m_dBPort = value;
			}
		}
		public string DBUser
		{
			get
			{
				return this.m_dBUser;
			}
			set
			{
				this.m_dBUser = value;
			}
		}
		public string DBPassword
		{
			get
			{
				return this.m_dBPassword;
			}
			set
			{
				this.m_dBPassword = value;
			}
		}
		public string MachineID
		{
			get
			{
				return this.m_machineID;
			}
			set
			{
				this.m_machineID = value;
			}
		}
		public string Information
		{
			get
			{
				return this.m_information;
			}
			set
			{
				this.m_information = value;
			}
		}
		public DataBaseInfo()
		{
			this.m_dBInfoID = 0;
			this.m_dBAddr = "";
			this.m_dBPort = 0;
			this.m_dBUser = "";
			this.m_dBPassword = "";
			this.m_machineID = "";
			this.m_information = "";
		}
	}
}
