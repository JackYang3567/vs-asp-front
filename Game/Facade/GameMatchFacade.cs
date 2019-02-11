using Game.Data.Factory;
using Game.Entity.GameMatch;
using Game.IData;
using Game.Kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
namespace Game.Facade
{
	public class GameMatchFacade
	{
		private IGameMatchProvider gameMatchData;
		public GameMatchFacade()
		{
			this.gameMatchData = ClassFactory.GetIGameMatchProvider();
		}
		public PagerSet GetList(string tableName, int pageIndex, int pageSize, string pkey, string whereQuery, string[] fields, string[] fieldAlias)
		{
			return this.gameMatchData.GetList(tableName, pageIndex, pageSize, pkey, whereQuery, fields, fieldAlias);
		}
		public PagerSet GetList(string tableName, int pageIndex, int pageSize, string pkey, string whereQuery, string[] fields)
		{
			return this.gameMatchData.GetList(tableName, pageIndex, pageSize, pkey, whereQuery, fields);
		}
		public PagerSet GetList(string tableName, int pageIndex, int pageSize, string pkey, string whereQuery)
		{
			return this.gameMatchData.GetList(tableName, pageIndex, pageSize, pkey, whereQuery);
		}
		public PagerSet GetList(string tableName, int pageIndex, int pageSize, string pkey)
		{
			return this.gameMatchData.GetList(tableName, pageIndex, pageSize, pkey);
		}
		public PagerSet GetList(string tableName, int pageIndex, int pageSize)
		{
			return this.gameMatchData.GetList(tableName, pageIndex, pageSize);
		}
		public PagerSet GetAllList(string tableName, string pkey, string whereQuery)
		{
			return this.gameMatchData.GetAllList(tableName, pkey, whereQuery);
		}
		public PagerSet GetNumberList(string tableName, string whereQuery, string pkey, int number)
		{
			return this.gameMatchData.GetNumberList(tableName, whereQuery, pkey, number);
		}
		public DataSet GetDataSetByWhere(string sqlQuery)
		{
			return this.gameMatchData.GetDataSetByWhere(sqlQuery);
		}
		public T GetEntity<T>(string commandText, System.Collections.Generic.List<DbParameter> parms)
		{
			return this.gameMatchData.GetEntity<T>(commandText, parms);
		}
		public T GetEntity<T>(string commandText)
		{
			return this.gameMatchData.GetEntity<T>(commandText);
		}
		public PagerSet GetMatchList(int pageIndex, int pageSize)
		{
			return this.gameMatchData.GetMatchList(pageIndex, pageSize);
		}
		public MatchPublic GetMatchPublic(int matchId)
		{
			return this.gameMatchData.GetMatchPublic(matchId);
		}
		public MatchInfo GetMatchInfo(int matchId)
		{
			return this.gameMatchData.GetMatchInfo(matchId);
		}
		public DataSet GetMatchPublicList()
		{
			return this.gameMatchData.GetMatchPublicList();
		}
		public DataSet GetMatchRewardList(int matchId)
		{
			return this.gameMatchData.GetMatchRewardList(matchId);
		}
		public DataSet GetRecentlyMatchRank(int matchId)
		{
			return this.gameMatchData.GetRecentlyMatchRank(matchId);
		}
	}
}
