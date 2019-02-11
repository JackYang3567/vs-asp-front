using System;
namespace Game.Entity.Treasure
{
	[Serializable]
	public class UserRoomCard
	{
		public const string Tablename = "UserRoomCard";
		private int p_roomcard;
		private int p_userid;
		public int RoomCard
		{
			get;
			set;
		}
		public int UserID
		{
			get;
			set;
		}
	}
}
