using Game.Data.Factory;
using Game.Entity.Platform;
using Game.IData;
using System;
using System.Collections.Generic;
using System.Data;
namespace Game.Facade
{
	public class PlatformFacade
	{
		private IPlatformDataProvider platformData;
		public PlatformFacade()
		{
			this.platformData = ClassFactory.GetIPlatformDataProvider();
		}
		public DataBaseInfo GetDatabaseInfo(string addrString)
		{
			return this.platformData.GetDatabaseInfo(addrString);
		}
		public GameGameItem GetDBAddString(int kindID)
		{
			return this.platformData.GetDBAddString(kindID);
		}
		public System.Collections.Generic.IList<GameTypeItem> GetGameTypes()
		{
			return this.platformData.GetGameTypes();
		}
		public System.Collections.Generic.IList<GameKindItem> GetGameKindsByTypeID(int typeID)
		{
			return this.platformData.GetGameKindsByTypeID(typeID);
		}
		public System.Collections.Generic.IList<GameKindItem> GetRecommendGame()
		{
			return this.platformData.GetRecommendGame();
		}
		public System.Collections.Generic.IList<GameKindItem> GetAllKinds()
		{
			return this.platformData.GetAllKinds();
		}
		public System.Collections.Generic.IList<GameKindItem> GetIntegralKinds()
		{
			return this.platformData.GetIntegralKinds();
		}
		public System.Collections.Generic.IList<GameGameItem> GetGameList()
		{
			return this.platformData.GetGameList();
		}
		public DataSet GetSigninConfigList()
		{
			return this.platformData.GetSigninConfigList();
		}
		public DataSet GetMobileKindList(int typeID)
		{
			return this.platformData.GetMobileKindList(typeID);
		}
		public DataSet GetGrowLevelConfigList()
		{
			return this.platformData.GetGrowLevelConfigList();
		}
		public System.Collections.Generic.IList<GamePropertyType> GetMobilePropertyType(int tagID)
		{
			return this.platformData.GetMobilePropertyType(tagID);
		}
		public System.Collections.Generic.IList<GameProperty> GetMobileProperty()
		{
			return this.platformData.GetMobileProperty();
		}
		public System.Collections.Generic.IList<GameProperty> GetMobileProperty(int typeID)
		{
			return this.platformData.GetMobileProperty(typeID);
		}
		public object GetObjectBySql(string sqlQuery)
		{
			return this.platformData.GetObjectBySql(sqlQuery);
		}
		public T GetEntity<T>(string commandText)
		{
			return this.platformData.GetEntity<T>(commandText);
		}
		public DataTable GetOnlineCount()
		{
			string sql = "SELECT * FROM OnlineCount";
			return this.platformData.GetDataSetBySql(sql).Tables[0];
		}
        public DataTable GetDataSetBySql(string sql)
        {
            return this.platformData.GetDataSetBySql(sql).Tables[0];
        }
	}
}
