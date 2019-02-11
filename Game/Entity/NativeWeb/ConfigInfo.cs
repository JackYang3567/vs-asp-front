using System;
namespace Game.Entity.NativeWeb
{
	[Serializable]
	public class ConfigInfo
	{
		public const string Tablename = "ConfigInfo";
		public const string _ConfigID = "ConfigID";
		public const string _ConfigKey = "ConfigKey";
		public const string _ConfigName = "ConfigName";
		public const string _ConfigString = "ConfigString";
		public const string _Field1 = "Field1";
		public const string _Field2 = "Field2";
		public const string _Field3 = "Field3";
		public const string _Field4 = "Field4";
		public const string _Field5 = "Field5";
		public const string _Field6 = "Field6";
		public const string _Field7 = "Field7";
		public const string _Field8 = "Field8";
		public const string _SortID = "SortID";
		private int m_configID;
		private string m_configKey;
		private string m_configName;
		private string m_configString;
		private string m_field1;
		private string m_field2;
		private string m_field3;
		private string m_field4;
		private string m_field5;
		private string m_field6;
		private string m_field7;
		private string m_field8;
		private int m_sortID;
		public int ConfigID
		{
			get
			{
				return this.m_configID;
			}
			set
			{
				this.m_configID = value;
			}
		}
		public string ConfigKey
		{
			get
			{
				return this.m_configKey;
			}
			set
			{
				this.m_configKey = value;
			}
		}
		public string ConfigName
		{
			get
			{
				return this.m_configName;
			}
			set
			{
				this.m_configName = value;
			}
		}
		public string ConfigString
		{
			get
			{
				return this.m_configString;
			}
			set
			{
				this.m_configString = value;
			}
		}
		public string Field1
		{
			get
			{
				return this.m_field1;
			}
			set
			{
				this.m_field1 = value;
			}
		}
		public string Field2
		{
			get
			{
				return this.m_field2;
			}
			set
			{
				this.m_field2 = value;
			}
		}
		public string Field3
		{
			get
			{
				return this.m_field3;
			}
			set
			{
				this.m_field3 = value;
			}
		}
		public string Field4
		{
			get
			{
				return this.m_field4;
			}
			set
			{
				this.m_field4 = value;
			}
		}
		public string Field5
		{
			get
			{
				return this.m_field5;
			}
			set
			{
				this.m_field5 = value;
			}
		}
		public string Field6
		{
			get
			{
				return this.m_field6;
			}
			set
			{
				this.m_field6 = value;
			}
		}
		public string Field7
		{
			get
			{
				return this.m_field7;
			}
			set
			{
				this.m_field7 = value;
			}
		}
		public string Field8
		{
			get
			{
				return this.m_field8;
			}
			set
			{
				this.m_field8 = value;
			}
		}
		public int SortID
		{
			get
			{
				return this.m_sortID;
			}
			set
			{
				this.m_sortID = value;
			}
		}
		public ConfigInfo()
		{
			this.m_configID = 0;
			this.m_configKey = "";
			this.m_configName = "";
			this.m_configString = "";
			this.m_field1 = "";
			this.m_field2 = "";
			this.m_field3 = "";
			this.m_field4 = "";
			this.m_field5 = "";
			this.m_field6 = "";
			this.m_field7 = "";
			this.m_field8 = "";
			this.m_sortID = 0;
		}
	}
}
