using System;
namespace Game.Facade.DataStruct
{
	public class UserScoreRank
	{
		private int _ranking;
		private int _userID;
		private long _score;
		private string _nickname = string.Empty;
		private int _faceID;
		private int _customID;
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
		public long Score
		{
			get
			{
				return this._score;
			}
			set
			{
				this._score = value;
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
	}
}
