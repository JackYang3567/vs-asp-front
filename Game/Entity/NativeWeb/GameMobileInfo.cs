using System;
namespace Game.Entity.NativeWeb
{
	[Serializable]
	public class GameMobileInfo
	{
		public const string Tablename = "GameMobileInfo";
		public const string _KindID = "KindID";
		public const string _MobileID = "MobileID";
		public const string _DownloadUrl = "DownloadUrl";
		private int m_kindID;
		private int m_mobileID;
		private string m_downloadUrl;
		public int KindID
		{
			get
			{
				return this.m_kindID;
			}
			set
			{
				this.m_kindID = value;
			}
		}
		public int MobileID
		{
			get
			{
				return this.m_mobileID;
			}
			set
			{
				this.m_mobileID = value;
			}
		}
		public string DownloadUrl
		{
			get
			{
				return this.m_downloadUrl;
			}
			set
			{
				this.m_downloadUrl = value;
			}
		}
		public GameMobileInfo()
		{
			this.m_kindID = 0;
			this.m_mobileID = 0;
			this.m_downloadUrl = "";
		}
	}
}
