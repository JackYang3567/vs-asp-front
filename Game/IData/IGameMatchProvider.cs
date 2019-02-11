using Game.Entity.GameMatch;
using Game.Kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
namespace Game.IData
{
	public interface IGameMatchProvider
	{
		PagerSet GetList(string tableName, int pageIndex, int pageSize, string pkey, string whereQuery, string[] fields, string[] fieldAlias);
		PagerSet GetList(string tableName, int pageIndex, int pageSize, string pkey, string whereQuery, string[] fields);
		PagerSet GetList(string tableName, int pageIndex, int pageSize, string pkey, string whereQuery);
		PagerSet GetList(string tableName, int pageIndex, int pageSize, string pkey);
		PagerSet GetList(string tableName, int pageIndex, int pageSize);
		PagerSet GetAllList(string tableName, string pkey, string whereQuery);
		PagerSet GetNumberList(string tableName, string whereQuery, string pkey, int number);
		DataSet GetDataSetByWhere(string sqlQuery);
		T GetEntity<T>(string commandText, List<DbParameter> parms);
		T GetEntity<T>(string commandText);
		PagerSet GetMatchList(int pageIndex, int pageSize);
		MatchPublic GetMatchPublic(int matchId);
		MatchInfo GetMatchInfo(int matchId);
		DataSet GetMatchPublicList();
		DataSet GetMatchRewardList(int matchId);
		DataSet GetRecentlyMatchRank(int matchId);
	}
}
