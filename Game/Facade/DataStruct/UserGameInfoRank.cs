using System;
namespace Game.Facade.DataStruct
{
	public class UserGameInfoRank
	{
		private int _ranking;
		private int _userID;
		private string _nickname = string.Empty;
		private int _lineGrandTotal;
		private int _lineWinMax = 1;
		private int _faceID;
		private int _customID;
		private int _gender;
		private byte _trend;
		public int Ranking
		{
			get
			{
				return this._ranking;
			}
			set
			{
				this._ranking = value;
			}
		}
		public int UserID
		{
			get
			{
				return this._userID;
			}
			set
			{
				this._userID = value;
			}
		}
		public string NickName
		{
			get
			{
				return this._nickname;
			}
			set
			{
				this._nickname = value;
			}
		}
		public int LineGrandTotal
		{
			get
			{
				return this._lineGrandTotal;
			}
			set
			{
				this._lineGrandTotal = value;
			}
		}
		public int LineWinMax
		{
			get
			{
				return this._lineWinMax;
			}
			set
			{
				this._lineWinMax = value;
			}
		}
		public int FaceID
		{
			get
			{
				return this._faceID;
			}
			set
			{
				this._faceID = value;
			}
		}
		public int CustomID
		{
			get
			{
				return this._customID;
			}
			set
			{
				this._customID = value;
			}
		}
		public int Gender
		{
			get
			{
				return this._gender;
			}
			set
			{
				this._gender = value;
			}
		}
		public byte Trend
		{
			get
			{
				return this._trend;
			}
			set
			{
				this._trend = value;
			}
		}
	}
}
