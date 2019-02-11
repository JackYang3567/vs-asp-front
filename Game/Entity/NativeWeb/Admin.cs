using System;
namespace Game.Entity.NativeWeb
{
	[Serializable]
	public class Admin
	{
		public const string Tablename = "admin";
		public const string _UserID = "UserID";
		public const string _UserName = "UserName";
		public const string _Password = "Password";
		public const string _Classcode = "classcode";
		public const string _Classname = "classname";
		private int m_userID;
		private string m_userName;
		private string m_password;
		private string m_classcode;
		private string m_classname;
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
		public string UserName
		{
			get
			{
				return this.m_userName;
			}
			set
			{
				this.m_userName = value;
			}
		}
		public string Password
		{
			get
			{
				return this.m_password;
			}
			set
			{
				this.m_password = value;
			}
		}
		public string Classcode
		{
			get
			{
				return this.m_classcode;
			}
			set
			{
				this.m_classcode = value;
			}
		}
		public string Classname
		{
			get
			{
				return this.m_classname;
			}
			set
			{
				this.m_classname = value;
			}
		}
		public Admin()
		{
			this.m_userID = 0;
			this.m_userName = "";
			this.m_password = "";
			this.m_classcode = "";
			this.m_classname = "";
		}
	}
}
