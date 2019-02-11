using Game.Entity.GameMatch;
using Game.IData;
using Game.Kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
namespace Game.Data
{
	public class GameMatchDataProvider : BaseDataProvider, IGameMatchProvider
	{
		public GameMatchDataProvider(string connString) : base(connString)
		{
		}
		public PagerSet GetList(string tableName, int pageIndex, int pageSize, string pkey, string whereQuery, string[] fields, string[] fieldAlias)
		{
			return this.GetPagerSet2(new PagerParameters(tableName, pkey, whereQuery, pageIndex, pageSize, fields, fieldAlias)
			{
				CacherSize = 2
			});
		}
		public PagerSet GetList(string tableName, int pageIndex, int pageSize, string pkey, string whereQuery, string[] fields)
		{
			return this.GetPagerSet2(new PagerParameters(tableName, pkey, whereQuery, pageIndex, pageSize, fields)
			{
				CacherSize = 2
			});
		}
		public PagerSet GetList(string tableName, int pageIndex, int pageSize, string pkey, string whereQuery)
		{
			return this.GetPagerSet2(new PagerParameters(tableName, pkey, whereQuery, pageIndex, pageSize)
			{
				CacherSize = 2
			});
		}
		public PagerSet GetList(string tableName, int pageIndex, int pageSize, string pkey)
		{
			return this.GetPagerSet2(new PagerParameters(tableName, pkey, pageIndex, pageSize)
			{
				CacherSize = 2
			});
		}
		public PagerSet GetList(string tableName, int pageIndex, int pageSize)
		{
			return this.GetPagerSet2(new PagerParameters(tableName, "", pageIndex, pageSize)
			{
				CacherSize = 2
			});
		}
		public PagerSet GetAllList(string tableName, string pkey, string whereQuery)
		{
			return this.GetPagerSet2(new PagerParameters(tableName, pkey, whereQuery, 1, 2147483647)
			{
				CacherSize = 2
			});
		}
		public PagerSet GetNumberList(string tableName, string whereQuery, string pkey, int number)
		{
			return this.GetPagerSet2(new PagerParameters(tableName, pkey, whereQuery, 1, number)
			{
				CacherSize = 2
			});
		}
		public System.Data.DataSet GetDataSetByWhere(string sqlQuery)
		{
			return base.Database.ExecuteDataset(sqlQuery);
		}
		public T GetEntity<T>(string commandText, System.Collections.Generic.List<System.Data.Common.DbParameter> parms)
		{
			return base.Database.ExecuteObject<T>(commandText, parms);
		}
		public T GetEntity<T>(string commandText)
		{
			return base.Database.ExecuteObject<T>(commandText);
		}
		public PagerSet GetMatchList(int pageIndex, int pageSize)
		{
			string table = "( SELECT A.*,B.MatchType,B.MatchStatus FROM MatchInfo AS A INNER JOIN MatchPublic AS B ON A.MatchID=B.MatchID) AS C";
			string empty = string.Empty;
			return this.GetPagerSet2(new PagerParameters(table, "ORDER BY MatchID DESC", empty, pageIndex, pageSize)
			{
				CacherSize = 2
			});
		}
		public MatchPublic GetMatchPublic(int matchId)
		{
			string commandText = "SELECT * FROM MatchPublic WHERE MatchID=@MatchID";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("MatchID", matchId));
			return base.Database.ExecuteObject<MatchPublic>(commandText, list);
		}
		public MatchInfo GetMatchInfo(int matchId)
		{
			string commandText = "SELECT * FROM MatchInfo WHERE MatchID=@MatchID";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("MatchID", matchId));
			return base.Database.ExecuteObject<MatchInfo>(commandText, list);
		}
		public System.Data.DataSet GetMatchPublicList()
		{
			string commandText = "SELECT * FROM MatchPublic";
			return base.Database.ExecuteDataset(commandText);
		}
		public System.Data.DataSet GetMatchRewardList(int matchId)
		{
			string commandText = "SELECT * FROM MatchReward WHERE MatchID=@MatchID";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("MatchID", matchId));
			return base.Database.ExecuteDataset(System.Data.CommandType.Text, commandText, list.ToArray());
		}
		public System.Data.DataSet GetRecentlyMatchRank(int matchId)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("MatchID", matchId));
			return base.Database.ExecuteDataset(System.Data.CommandType.StoredProcedure, "NET_PW_GetRecentlyMatchRank", list.ToArray());
		}
	}
}
