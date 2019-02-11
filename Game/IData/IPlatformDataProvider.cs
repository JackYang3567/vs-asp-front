using Game.Entity.Platform;
using System;
using System.Collections.Generic;
using System.Data;
namespace Game.IData
{
	public interface IPlatformDataProvider
	{
		DataBaseInfo GetDatabaseInfo(string addrString);
		GameGameItem GetDBAddString(int kindID);
		IList<GameTypeItem> GetGameTypes();
		IList<GameKindItem> GetGameKindsByTypeID(int typeID);
		IList<GameKindItem> GetRecommendGame();
		IList<GameKindItem> GetAllKinds();
		IList<GameKindItem> GetIntegralKinds();
		IList<GameGameItem> GetGameList();
		DataSet GetSigninConfigList();
		DataSet GetMobileKindList(int typeID);
		DataSet GetGrowLevelConfigList();
		IList<GamePropertyType> GetMobilePropertyType(int tagID);
		IList<GameProperty> GetMobileProperty();
		IList<GameProperty> GetMobileProperty(int typeID);
		object GetObjectBySql(string sqlQuery);
		T GetEntity<T>(string commandText);
		DataSet GetDataSetBySql(string sql);
	}
}
