using System;
namespace Game.Entity.Accounts
{
	[Serializable]
	public class IndividualDatum
	{
		public const string Tablename = "IndividualDatum";
		public const string _UserID = "UserID";
		public const string _QQ = "QQ";
		public const string _EMail = "EMail";
		public const string _SeatPhone = "SeatPhone";
		public const string _MobilePhone = "MobilePhone";
		public const string _DwellingPlace = "DwellingPlace";
		public const string _PostalCode = "PostalCode";
		public const string _CollectDate = "CollectDate";
		public const string _UserNote = "UserNote";
		private int m_userID;
		private string m_qQ;
		private string m_eMail;
		private string m_seatPhone;
		private string m_mobilePhone;
		private string m_dwellingPlace;
		private string m_postalCode;
		private DateTime m_collectDate;
		private string m_userNote;
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
		public string QQ
		{
			get
			{
				return this.m_qQ;
			}
			set
			{
				this.m_qQ = value;
			}
		}
		public string EMail
		{
			get
			{
				return this.m_eMail;
			}
			set
			{
				this.m_eMail = value;
			}
		}
		public string SeatPhone
		{
			get
			{
				return this.m_seatPhone;
			}
			set
			{
				this.m_seatPhone = value;
			}
		}
		public string MobilePhone
		{
			get
			{
				return this.m_mobilePhone;
			}
			set
			{
				this.m_mobilePhone = value;
			}
		}
		public string DwellingPlace
		{
			get
			{
				return this.m_dwellingPlace;
			}
			set
			{
				this.m_dwellingPlace = value;
			}
		}
		public string PostalCode
		{
			get
			{
				return this.m_postalCode;
			}
			set
			{
				this.m_postalCode = value;
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
		public string UserNote
		{
			get
			{
				return this.m_userNote;
			}
			set
			{
				this.m_userNote = value;
			}
		}
		public IndividualDatum()
		{
			this.m_userID = 0;
			this.m_qQ = "";
			this.m_eMail = "";
			this.m_seatPhone = "";
			this.m_mobilePhone = "";
			this.m_dwellingPlace = "";
			this.m_postalCode = "";
			this.m_collectDate = DateTime.Now;
			this.m_userNote = "";
		}
	}
}
