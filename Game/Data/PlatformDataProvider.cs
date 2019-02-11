using Game.Entity.Platform;
using Game.IData;
using Game.Kernel;
using Game.Utils;

namespace Game.Data
{
    public class PlatformDataProvider : BaseDataProvider, IPlatformDataProvider
    {
        public PlatformDataProvider(string connString)
            : base(connString)
        {
        }

        public string GetConn(int kindID)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            GameGameItem dBAddString = this.GetDBAddString(kindID);
            string result;
            if (dBAddString == null)
            {
                result = "";
            }
            else
            {
                DataBaseInfo databaseInfo = this.GetDatabaseInfo(dBAddString.DataBaseAddr);
                if (databaseInfo == null)
                {
                    result = "";
                }
                else
                {
                    string text = CWHEncryptNet.XorCrevasse(databaseInfo.DBUser);
                    string text2 = CWHEncryptNet.XorCrevasse(databaseInfo.DBPassword);
                    stringBuilder.AppendFormat("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}; Pooling=true", new object[]
					{
						dBAddString.DataBaseAddr + (string.IsNullOrEmpty(databaseInfo.DBPort.ToString()) ? "" : ("," + databaseInfo.DBPort.ToString())),
						dBAddString.DataBaseName,
						text,
						text2
					});
                    result = stringBuilder.ToString();
                }
            }
            return result;
        }

        public DataBaseInfo GetDatabaseInfo(string addrString)
        {
            string commandText = string.Format("SELECT * FROM DataBaseInfo(NOLOCK) WHERE DBAddr=@DBAddr", new object[0]);
            System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
            list.Add(base.Database.MakeInParam("DBAddr", addrString));
            return base.Database.ExecuteObject<DataBaseInfo>(commandText, list);
        }

        public GameGameItem GetDBAddString(int kindID)
        {
            string commandText = string.Format("SELECT GameName, DataBaseAddr, DataBaseName, ServerVersion, ClientVersion, ServerDLLName, ClientExeName FROM GameGameItem g,GameKindItem k WHERE KindID={0} AND g.GameID=k.GameID", kindID);
            return base.Database.ExecuteObject<GameGameItem>(commandText);
        }

        public System.Collections.Generic.IList<GameTypeItem> GetGameTypes()
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append("SELECT TypeID,TypeName ").Append("FROM GameTypeItem ").Append("WHERE Nullity=0 ").Append("ORDER By SortID ASC,TypeID ASC");
            return base.Database.ExecuteObjectList<GameTypeItem>(stringBuilder.ToString());
        }

        public System.Collections.Generic.IList<GameKindItem> GetGameKindsByTypeID(int typeID)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append("SELECT KindID, GameID, TypeID, SortID, KindName, ProcessName, GameRuleUrl, DownLoadUrl, Nullity ").Append("FROM GameKindItem ").AppendFormat("WHERE Nullity=0 AND TypeID={0} ", typeID).Append(" ORDER By SortID ASC,KindID ASC");
            return base.Database.ExecuteObjectList<GameKindItem>(stringBuilder.ToString());
        }

        public System.Collections.Generic.IList<GameKindItem> GetRecommendGame()
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append("SELECT KindID, GameID, TypeID, SortID, KindName, ProcessName, GameRuleUrl, DownLoadUrl, Nullity ").Append("FROM GameKindItem ").Append("WHERE Nullity=0 AND JoinID=2").Append(" ORDER By SortID ASC,KindID ASC");
            return base.Database.ExecuteObjectList<GameKindItem>(stringBuilder.ToString());
        }

        public System.Collections.Generic.IList<GameKindItem> GetAllKinds()
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append("SELECT KindID, GameID, TypeID, SortID, KindName, ProcessName, GameRuleUrl, DownLoadUrl, Nullity ").Append("FROM GameKindItem ").AppendFormat("WHERE Nullity=0 ", new object[0]).Append(" ORDER By SortID ASC,KindID ASC ");
            return base.Database.ExecuteObjectList<GameKindItem>(stringBuilder.ToString());
        }

        public System.Collections.Generic.IList<GameKindItem> GetIntegralKinds()
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append("SELECT KindID, GameID, TypeID, SortID, KindName, ProcessName, GameRuleUrl, DownLoadUrl, Nullity ").Append("FROM GameKindItem ").AppendFormat("WHERE Nullity=0 AND GameID NOT IN( SELECT GameID FROM GameGameItem WHERE DataBaseName = 'THTreasureDB' )", new object[0]).Append(" ORDER By SortID ASC,KindID ASC ");
            return base.Database.ExecuteObjectList<GameKindItem>(stringBuilder.ToString());
        }

        public System.Collections.Generic.IList<GameGameItem> GetGameList()
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append("SELECT a.KindID,a.KindName,b.DataBaseAddr,b.DataBaseName ").Append(" FROM GameKindItem a,GameGameItem b ").Append("WHERE a.GameID = b.GameID ORDER BY SortID");
            return base.Database.ExecuteObjectList<GameGameItem>(stringBuilder.ToString());
        }

        public System.Data.DataSet GetMobileKindList(int typeID)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.AppendFormat("SELECT KindID,KindName,TypeID,ModuleName,ClientVersion,ResVersion,SortID,KindMark,KindType FROM MobileKindItem WHERE Nullity=0 AND KindMark&{0}>0 Order By SortID DESC", typeID);
            return base.Database.ExecuteDataset(stringBuilder.ToString());
        }

        public System.Data.DataSet GetSigninConfigList()
        {
            string commandText = "SELECT * FROM SigninConfig ORDER BY DayID ASC";
            return base.Database.ExecuteDataset(commandText);
        }

        public System.Data.DataSet GetGrowLevelConfigList()
        {
            string commandText = "SELECT * FROM GrowLevelConfig ORDER BY LevelID DESC";
            return base.Database.ExecuteDataset(commandText);
        }

        public System.Collections.Generic.IList<GamePropertyType> GetMobilePropertyType(int tagID)
        {
            string commandText = string.Format("SELECT * FROM GamePropertyType(NOLOCK) WHERE TagID=@TagID AND Nullity=0", new object[0]);
            System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
            list.Add(base.Database.MakeInParam("TagID", tagID));
            return base.Database.ExecuteObjectList<GamePropertyType>(commandText, list);
        }

        public System.Collections.Generic.IList<GameProperty> GetMobileProperty()
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append("SELECT * FROM GameProperty(NOLOCK) WHERE SuportMobile=1 ORDER BY ID ASC ");
            return base.Database.ExecuteObjectList<GameProperty>(stringBuilder.ToString());
        }

        public System.Collections.Generic.IList<GameProperty> GetMobileProperty(int typeID)
        {
            string commandText = string.Format("SELECT G.* FROM (SELECT PropertyID,TypeID FROM GamePropertyRelat WHERE TagID=1 AND TypeID = {0}) AS R LEFT JOIN GameProperty AS G ON R.PropertyID = G.ID AND G.Nullity=0 ORDER BY G.SortID ASC", typeID);
            System.Collections.Generic.List<System.Data.Common.DbParameter> prams = new System.Collections.Generic.List<System.Data.Common.DbParameter>
			{
				base.Database.MakeInParam("TypeID", typeID)
			};
            return base.Database.ExecuteObjectList<GameProperty>(commandText, prams);
        }

        public object GetObjectBySql(string sqlQuery)
        {
            return base.Database.ExecuteScalar(System.Data.CommandType.Text, sqlQuery);
        }

        public T GetEntity<T>(string commandText)
        {
            return base.Database.ExecuteObject<T>(commandText);
        }

        public System.Data.DataSet GetDataSetBySql(string sql)
        {
            return base.Database.ExecuteDataset(sql);
        }

        public int ExecuteNonQuery(string sql)
        {
            return base.Database.ExecuteNonQuery(sql);
        }
    }
}