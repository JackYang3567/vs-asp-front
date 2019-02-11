using Game.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading;
namespace Game.Kernel
{
	public class DbHelper
	{
		private enum DbConnectionOwnership
		{
			Internal,
			External
		}
		private object lockHelper = new object();
		protected string m_connectionstring;
		private DbProviderFactory m_factory;
		private Hashtable m_paramcache = Hashtable.Synchronized(new Hashtable());
		private IDbProvider m_provider;
		private int m_querycount;
		private static string m_querydetail = "";
		protected internal string ConnectionString
		{
			get
			{
				return this.m_connectionstring;
			}
			set
			{
				this.m_connectionstring = value;
			}
		}
		public DbProviderFactory Factory
		{
			get
			{
				if (this.m_factory == null)
				{
					this.m_factory = this.Provider.Instance();
				}
				return this.m_factory;
			}
		}
		public IDbProvider Provider
		{
			get
			{
				if (this.m_provider == null)
				{
					object obj;
					Monitor.Enter(obj = this.lockHelper);
					try
					{
						if (this.m_provider == null)
						{
							try
							{
								this.m_provider = (IDbProvider)Activator.CreateInstance(Type.GetType("Game.Kernel.SqlServerProvider, Game.Kernel", false, true));
							}
							catch
							{
								new Terminator().Throw("SqlServerProvider 数据库访问器创建失败！");
							}
						}
					}
					finally
					{
						Monitor.Exit(obj);
					}
				}
				return this.m_provider;
			}
		}
		public int QueryCount
		{
			get
			{
				return this.m_querycount;
			}
			set
			{
				this.m_querycount = value;
			}
		}
		public static string QueryDetail
		{
			get
			{
				return DbHelper.m_querydetail;
			}
			set
			{
				DbHelper.m_querydetail = value;
			}
		}
		public DbHelper(string connString)
		{
			this.BuildConnection(connString);
		}
		public void BuildConnection(string connectionString)
		{
			if (string.IsNullOrEmpty(connectionString))
			{
				new Terminator().Throw("请检查数据库连接信息，当前数据库连接信息为空。");
			}
			this.m_connectionstring = connectionString;
			this.m_querycount = 0;
		}
		private void AssignParameterValues(DbParameter[] commandParameters, DataRow dataRow)
		{
			if (commandParameters != null && dataRow != null)
			{
				int num = 0;
				for (int i = 0; i < commandParameters.Length; i++)
				{
					DbParameter dbParameter = commandParameters[i];
					if (dbParameter.ParameterName == null || dbParameter.ParameterName.Length <= 1)
					{
						new Terminator().Throw(string.Format("请提供参数{0}一个有效的名称{1}.", num, dbParameter.ParameterName));
					}
					if (dataRow.Table.Columns.IndexOf(dbParameter.ParameterName.Substring(1)) != -1)
					{
						dbParameter.Value = dataRow[dbParameter.ParameterName.Substring(1)];
					}
					num++;
				}
			}
		}
		private void AssignParameterValues(DbParameter[] commandParameters, object[] parameterValues)
		{
			if (commandParameters != null && parameterValues != null)
			{
				if (commandParameters.Length != parameterValues.Length)
				{
					new Terminator().Throw("参数值个数与参数不匹配。");
				}
				int i = 0;
				int num = commandParameters.Length;
				while (i < num)
				{
					if (parameterValues[i] is IDbDataParameter)
					{
						IDbDataParameter dbDataParameter = (IDbDataParameter)parameterValues[i];
						if (dbDataParameter.Value == null)
						{
							commandParameters[i].Value = DBNull.Value;
						}
						else
						{
							commandParameters[i].Value = dbDataParameter.Value;
						}
					}
					else
					{
						if (parameterValues[i] == null)
						{
							commandParameters[i].Value = DBNull.Value;
						}
						else
						{
							commandParameters[i].Value = parameterValues[i];
						}
					}
					i++;
				}
			}
		}
		private void AttachParameters(DbCommand command, DbParameter[] commandParameters)
		{
			if (command == null)
			{
				throw new ArgumentNullException("command");
			}
			if (commandParameters != null)
			{
				for (int i = 0; i < commandParameters.Length; i++)
				{
					DbParameter dbParameter = commandParameters[i];
					if (dbParameter != null)
					{
						if ((dbParameter.Direction == ParameterDirection.InputOutput || dbParameter.Direction == ParameterDirection.Input) && dbParameter.Value == null)
						{
							dbParameter.Value = DBNull.Value;
						}
						command.Parameters.Add(dbParameter);
					}
				}
			}
		}
		public void CacheParameterSet(string commandText, params DbParameter[] commandParameters)
		{
			if (this.ConnectionString == null || this.ConnectionString.Length == 0)
			{
				throw new ArgumentNullException("ConnectionString");
			}
			if (commandText == null || commandText.Length == 0)
			{
				throw new ArgumentNullException("commandText");
			}
			string key = this.ConnectionString + ":" + commandText;
			this.m_paramcache[key] = commandParameters;
		}
		private DbParameter[] CloneParameters(DbParameter[] originalParameters)
		{
			DbParameter[] array = new DbParameter[originalParameters.Length];
			int i = 0;
			int num = originalParameters.Length;
			while (i < num)
			{
				array[i] = (DbParameter)((ICloneable)originalParameters[i]).Clone();
				i++;
			}
			return array;
		}
		public DbCommand CreateCommand(DbConnection connection, string spName, params string[] sourceColumns)
		{
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			if (spName == null || spName.Length == 0)
			{
				throw new ArgumentNullException("spName");
			}
			DbCommand dbCommand = this.Factory.CreateCommand();
			dbCommand.CommandText = spName;
			dbCommand.Connection = connection;
			dbCommand.CommandType = CommandType.StoredProcedure;
			if (sourceColumns != null && sourceColumns.Length > 0)
			{
				DbParameter[] spParameterSet = this.GetSpParameterSet(connection, spName);
				for (int i = 0; i < sourceColumns.Length; i++)
				{
					spParameterSet[i].SourceColumn = sourceColumns[i];
				}
				this.AttachParameters(dbCommand, spParameterSet);
			}
			return dbCommand;
		}
		private DbParameter[] DiscoverSpParameterSet(DbConnection connection, string spName, bool includeReturnValueParameter)
		{
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			if (spName == null || spName.Length == 0)
			{
				throw new ArgumentNullException("spName");
			}
			DbCommand dbCommand = connection.CreateCommand();
			dbCommand.CommandText = spName;
			dbCommand.CommandType = CommandType.StoredProcedure;
			connection.Open();
			this.Provider.DeriveParameters(dbCommand);
			connection.Close();
			if (!includeReturnValueParameter)
			{
				dbCommand.Parameters.RemoveAt(0);
			}
			DbParameter[] array = new DbParameter[dbCommand.Parameters.Count];
			dbCommand.Parameters.CopyTo(array, 0);
			DbParameter[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				DbParameter dbParameter = array2[i];
				dbParameter.Value = DBNull.Value;
			}
			return array;
		}
		public void ExecuteCommandWithSplitter(string commandText)
		{
			this.ExecuteCommandWithSplitter(commandText, "\r\nGO\r\n");
		}
		public void ExecuteCommandWithSplitter(string commandText, string splitter)
		{
			int num = 0;
			do
			{
				int num2 = commandText.IndexOf(splitter, num);
				int length = ((num2 > num) ? num2 : commandText.Length) - num;
				string text = commandText.Substring(num, length);
				if (text.Trim().Length > 0)
				{
					this.ExecuteNonQuery(CommandType.Text, text);
				}
				if (num2 == -1)
				{
					break;
				}
				num = num2 + splitter.Length;
			}
			while (num < commandText.Length);
		}
		public DataSet ExecuteDataset(string commandText)
		{
			return this.ExecuteDataset(CommandType.Text, commandText, null);
		}
		public DataSet ExecuteDataset(CommandType commandType, string commandText)
		{
			return this.ExecuteDataset(commandType, commandText, null);
		}
		public DataSet ExecuteDataset(CommandType commandType, string commandText, params DbParameter[] commandParameters)
		{
			if (this.ConnectionString == null || this.ConnectionString.Length == 0)
			{
				throw new ArgumentNullException("ConnectionString");
			}
			DataSet result;
			using (DbConnection dbConnection = this.Factory.CreateConnection())
			{
				dbConnection.ConnectionString = this.ConnectionString;
				dbConnection.Open();
				result = this.ExecuteDataset(dbConnection, commandType, commandText, commandParameters);
			}
			return result;
		}
		public DataSet ExecuteDataset(DbConnection connection, CommandType commandType, string commandText)
		{
			return this.ExecuteDataset(connection, commandType, commandText, null);
		}
		public DataSet ExecuteDataset(DbConnection connection, string spName, params object[] parameterValues)
		{
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			if (spName == null || spName.Length == 0)
			{
				throw new ArgumentNullException("spName");
			}
			if (parameterValues != null && parameterValues.Length > 0)
			{
				DbParameter[] spParameterSet = this.GetSpParameterSet(connection, spName);
				this.AssignParameterValues(spParameterSet, parameterValues);
				return this.ExecuteDataset(connection, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return this.ExecuteDataset(connection, CommandType.StoredProcedure, spName);
		}
		public DataSet ExecuteDataset(DbConnection connection, CommandType commandType, string commandText, params DbParameter[] commandParameters)
		{
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			DbCommand dbCommand = this.Factory.CreateCommand();
			bool flag = false;
			this.PrepareCommand(dbCommand, connection, null, commandType, commandText, commandParameters, out flag);
			DataSet result;
			using (DbDataAdapter dbDataAdapter = this.Factory.CreateDataAdapter())
			{
				dbDataAdapter.SelectCommand = dbCommand;
				DataSet dataSet = new DataSet();
				DateTime now = DateTime.Now;
				dbDataAdapter.Fill(dataSet);
				DateTime now2 = DateTime.Now;
				DbHelper.m_querydetail += DbHelper.GetQueryDetail(dbCommand.CommandText, now, now2, commandParameters);
				this.m_querycount++;
				dbCommand.Parameters.Clear();
				if (flag)
				{
					connection.Close();
				}
				result = dataSet;
			}
			return result;
		}
		public DataSet ExecuteDataset(DbTransaction transaction, CommandType commandType, string commandText)
		{
			return this.ExecuteDataset(transaction, commandType, commandText, null);
		}
		public DataSet ExecuteDataset(DbTransaction transaction, string spName, params object[] parameterValues)
		{
			if (transaction == null)
			{
				throw new ArgumentNullException("transaction");
			}
			if (transaction != null && transaction.Connection == null)
			{
				throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			}
			if (spName == null || spName.Length == 0)
			{
				throw new ArgumentNullException("spName");
			}
			if (parameterValues != null && parameterValues.Length > 0)
			{
				DbParameter[] spParameterSet = this.GetSpParameterSet(transaction.Connection, spName);
				this.AssignParameterValues(spParameterSet, parameterValues);
				return this.ExecuteDataset(transaction, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return this.ExecuteDataset(transaction, CommandType.StoredProcedure, spName);
		}
		public DataSet ExecuteDataset(DbTransaction transaction, CommandType commandType, string commandText, params DbParameter[] commandParameters)
		{
			if (transaction == null)
			{
				throw new ArgumentNullException("transaction");
			}
			if (transaction != null && transaction.Connection == null)
			{
				throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			}
			DbCommand dbCommand = this.Factory.CreateCommand();
			bool flag = false;
			this.PrepareCommand(dbCommand, transaction.Connection, transaction, commandType, commandText, commandParameters, out flag);
			DataSet result;
			using (DbDataAdapter dbDataAdapter = this.Factory.CreateDataAdapter())
			{
				dbDataAdapter.SelectCommand = dbCommand;
				DataSet dataSet = new DataSet();
				dbDataAdapter.Fill(dataSet);
				dbCommand.Parameters.Clear();
				result = dataSet;
			}
			return result;
		}
		public DataSet ExecuteDatasetTypedParams(string spName, DataRow dataRow)
		{
			if (this.ConnectionString == null || this.ConnectionString.Length == 0)
			{
				throw new ArgumentNullException("ConnectionString");
			}
			if (spName == null || spName.Length == 0)
			{
				throw new ArgumentNullException("spName");
			}
			if (dataRow != null && dataRow.ItemArray.Length > 0)
			{
				DbParameter[] spParameterSet = this.GetSpParameterSet(spName);
				this.AssignParameterValues(spParameterSet, dataRow);
				return this.ExecuteDataset(CommandType.StoredProcedure, spName, spParameterSet);
			}
			return this.ExecuteDataset(CommandType.StoredProcedure, spName);
		}
		public DataSet ExecuteDatasetTypedParams(DbConnection connection, string spName, DataRow dataRow)
		{
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			if (spName == null || spName.Length == 0)
			{
				throw new ArgumentNullException("spName");
			}
			if (dataRow != null && dataRow.ItemArray.Length > 0)
			{
				DbParameter[] spParameterSet = this.GetSpParameterSet(connection, spName);
				this.AssignParameterValues(spParameterSet, dataRow);
				return this.ExecuteDataset(connection, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return this.ExecuteDataset(connection, CommandType.StoredProcedure, spName);
		}
		public DataSet ExecuteDatasetTypedParams(DbTransaction transaction, string spName, DataRow dataRow)
		{
			if (transaction == null)
			{
				throw new ArgumentNullException("transaction");
			}
			if (transaction != null && transaction.Connection == null)
			{
				throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			}
			if (spName == null || spName.Length == 0)
			{
				throw new ArgumentNullException("spName");
			}
			if (dataRow != null && dataRow.ItemArray.Length > 0)
			{
				DbParameter[] spParameterSet = this.GetSpParameterSet(transaction.Connection, spName);
				this.AssignParameterValues(spParameterSet, dataRow);
				return this.ExecuteDataset(transaction, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return this.ExecuteDataset(transaction, CommandType.StoredProcedure, spName);
		}
		public int ExecuteNonQuery(string commandText)
		{
			return this.ExecuteNonQuery(CommandType.Text, commandText, null);
		}
		public int ExecuteNonQuery(CommandType commandType, string commandText)
		{
			return this.ExecuteNonQuery(commandType, commandText, null);
		}
		public int ExecuteNonQuery(CommandType commandType, string commandText, params DbParameter[] commandParameters)
		{
			if (this.ConnectionString == null || this.ConnectionString.Length == 0)
			{
				throw new ArgumentNullException("ConnectionString");
			}
			int result;
			using (DbConnection dbConnection = this.Factory.CreateConnection())
			{
				dbConnection.ConnectionString = this.ConnectionString;
				dbConnection.Open();
				result = this.ExecuteNonQuery(dbConnection, commandType, commandText, commandParameters);
			}
			return result;
		}
		public int ExecuteNonQuery(DbConnection connection, string spName, params object[] parameterValues)
		{
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			if (spName == null || spName.Length == 0)
			{
				throw new ArgumentNullException("spName");
			}
			if (parameterValues != null && parameterValues.Length > 0)
			{
				DbParameter[] spParameterSet = this.GetSpParameterSet(connection, spName);
				this.AssignParameterValues(spParameterSet, parameterValues);
				return this.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return this.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName);
		}
		public int ExecuteNonQuery(DbConnection connection, CommandType commandType, string commandText)
		{
			return this.ExecuteNonQuery(connection, commandType, commandText, null);
		}
		public int ExecuteNonQuery(DbConnection connection, CommandType commandType, string commandText, params DbParameter[] commandParameters)
		{
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			DbCommand dbCommand = this.Factory.CreateCommand();
			bool flag = false;
			this.PrepareCommand(dbCommand, connection, null, commandType, commandText, commandParameters, out flag);
			DateTime now = DateTime.Now;
			int result = dbCommand.ExecuteNonQuery();
			DateTime now2 = DateTime.Now;
			DbHelper.m_querydetail += DbHelper.GetQueryDetail(dbCommand.CommandText, now, now2, commandParameters);
			this.m_querycount++;
			dbCommand.Parameters.Clear();
			if (flag)
			{
				connection.Close();
			}
			return result;
		}
		public int ExecuteNonQuery(DbTransaction transaction, CommandType commandType, string commandText)
		{
			return this.ExecuteNonQuery(transaction, commandType, commandText, null);
		}
		public int ExecuteNonQuery(DbTransaction transaction, string spName, params object[] parameterValues)
		{
			if (transaction == null)
			{
				throw new ArgumentNullException("transaction");
			}
			if (transaction != null && transaction.Connection == null)
			{
				throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			}
			if (spName == null || spName.Length == 0)
			{
				throw new ArgumentNullException("spName");
			}
			if (parameterValues != null && parameterValues.Length > 0)
			{
				DbParameter[] spParameterSet = this.GetSpParameterSet(transaction.Connection, spName);
				this.AssignParameterValues(spParameterSet, parameterValues);
				return this.ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return this.ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName);
		}
		public int ExecuteNonQuery(DbTransaction transaction, CommandType commandType, string commandText, params DbParameter[] commandParameters)
		{
			if (transaction == null)
			{
				throw new ArgumentNullException("transaction");
			}
			if (transaction != null && transaction.Connection == null)
			{
				throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			}
			DbCommand dbCommand = this.Factory.CreateCommand();
			bool flag = false;
			this.PrepareCommand(dbCommand, transaction.Connection, transaction, commandType, commandText, commandParameters, out flag);
			int result = dbCommand.ExecuteNonQuery();
			dbCommand.Parameters.Clear();
			return result;
		}
		public int ExecuteNonQuery(out int id, CommandType commandType, string commandText)
		{
			return this.ExecuteNonQuery(out id, commandType, commandText, null);
		}
		public int ExecuteNonQuery(out int id, CommandType commandType, string commandText, params DbParameter[] commandParameters)
		{
			if (this.ConnectionString == null || this.ConnectionString.Length == 0)
			{
				throw new ArgumentNullException("ConnectionString");
			}
			int result;
			using (DbConnection dbConnection = this.Factory.CreateConnection())
			{
				dbConnection.ConnectionString = this.ConnectionString;
				dbConnection.Open();
				result = this.ExecuteNonQuery(out id, dbConnection, commandType, commandText, commandParameters);
			}
			return result;
		}
		public int ExecuteNonQuery(out int id, string commandText)
		{
			return this.ExecuteNonQuery(out id, CommandType.Text, commandText, null);
		}
		public int ExecuteNonQuery(out int id, DbConnection connection, CommandType commandType, string commandText)
		{
			return this.ExecuteNonQuery(out id, connection, commandType, commandText, null);
		}
		public int ExecuteNonQuery(out int id, DbTransaction transaction, CommandType commandType, string commandText)
		{
			return this.ExecuteNonQuery(out id, transaction, commandType, commandText, null);
		}
		public int ExecuteNonQuery(out int id, DbConnection connection, CommandType commandType, string commandText, params DbParameter[] commandParameters)
		{
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			if (this.Provider.GetLastIdSql().Trim() == "")
			{
				throw new ArgumentNullException("GetLastIdSql is \"\"");
			}
			DbCommand dbCommand = this.Factory.CreateCommand();
			bool flag = false;
			this.PrepareCommand(dbCommand, connection, null, commandType, commandText, commandParameters, out flag);
			int result = dbCommand.ExecuteNonQuery();
			dbCommand.Parameters.Clear();
			dbCommand.CommandType = CommandType.Text;
			dbCommand.CommandText = this.Provider.GetLastIdSql();
			id = int.Parse(dbCommand.ExecuteScalar().ToString());
			DateTime now = DateTime.Now;
			id = int.Parse(dbCommand.ExecuteScalar().ToString());
			DateTime now2 = DateTime.Now;
			DbHelper.m_querydetail += DbHelper.GetQueryDetail(dbCommand.CommandText, now, now2, commandParameters);
			this.m_querycount++;
			if (flag)
			{
				connection.Close();
			}
			return result;
		}
		public int ExecuteNonQuery(out int id, DbTransaction transaction, CommandType commandType, string commandText, params DbParameter[] commandParameters)
		{
			if (transaction == null)
			{
				throw new ArgumentNullException("transaction");
			}
			if (transaction != null && transaction.Connection == null)
			{
				throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			}
			DbCommand dbCommand = this.Factory.CreateCommand();
			bool flag = false;
			this.PrepareCommand(dbCommand, transaction.Connection, transaction, commandType, commandText, commandParameters, out flag);
			int result = dbCommand.ExecuteNonQuery();
			dbCommand.Parameters.Clear();
			dbCommand.CommandType = CommandType.Text;
			dbCommand.CommandText = this.Provider.GetLastIdSql();
			id = int.Parse(dbCommand.ExecuteScalar().ToString());
			return result;
		}
		public int ExecuteNonQueryTypedParams(string spName, DataRow dataRow)
		{
			if (this.ConnectionString == null || this.ConnectionString.Length == 0)
			{
				throw new ArgumentNullException("ConnectionString");
			}
			if (spName == null || spName.Length == 0)
			{
				throw new ArgumentNullException("spName");
			}
			if (dataRow != null && dataRow.ItemArray.Length > 0)
			{
				DbParameter[] spParameterSet = this.GetSpParameterSet(spName);
				this.AssignParameterValues(spParameterSet, dataRow);
				return this.ExecuteNonQuery(CommandType.StoredProcedure, spName, spParameterSet);
			}
			return this.ExecuteNonQuery(CommandType.StoredProcedure, spName);
		}
		public int ExecuteNonQueryTypedParams(DbConnection connection, string spName, DataRow dataRow)
		{
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			if (spName == null || spName.Length == 0)
			{
				throw new ArgumentNullException("spName");
			}
			if (dataRow != null && dataRow.ItemArray.Length > 0)
			{
				DbParameter[] spParameterSet = this.GetSpParameterSet(connection, spName);
				this.AssignParameterValues(spParameterSet, dataRow);
				return this.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return this.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName);
		}
		public int ExecuteNonQueryTypedParams(DbTransaction transaction, string spName, DataRow dataRow)
		{
			if (transaction == null)
			{
				throw new ArgumentNullException("transaction");
			}
			if (transaction != null && transaction.Connection == null)
			{
				throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			}
			if (spName == null || spName.Length == 0)
			{
				throw new ArgumentNullException("spName");
			}
			if (dataRow != null && dataRow.ItemArray.Length > 0)
			{
				DbParameter[] spParameterSet = this.GetSpParameterSet(transaction.Connection, spName);
				this.AssignParameterValues(spParameterSet, dataRow);
				return this.ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return this.ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName);
		}
		public T ExecuteObject<T>(string commandText)
		{
			DataSet dataSet = this.ExecuteDataset(commandText);
			if (Validate.CheckedDataSet(dataSet))
			{
				return DataHelper.ConvertRowToObject<T>(dataSet.Tables[0].Rows[0]);
			}
			return default(T);
		}
		public T ExecuteObject<T>(string commandText, List<DbParameter> prams)
		{
			DataSet dataSet = this.ExecuteDataset(CommandType.Text, commandText, prams.ToArray());
			if (Validate.CheckedDataSet(dataSet))
			{
				return DataHelper.ConvertRowToObject<T>(dataSet.Tables[0].Rows[0]);
			}
			return default(T);
		}
		public IList<T> ExecuteObjectList<T>(string commandText)
		{
			DataSet dataSet = this.ExecuteDataset(commandText);
			if (Validate.CheckedDataSet(dataSet))
			{
				return DataHelper.ConvertDataTableToObjects<T>(dataSet.Tables[0]);
			}
			return null;
		}
		public IList<T> ExecuteObjectList<T>(string commandText, List<DbParameter> prams)
		{
			DataSet dataSet = this.ExecuteDataset(CommandType.Text, commandText, prams.ToArray());
			if (Validate.CheckedDataSet(dataSet))
			{
				return DataHelper.ConvertDataTableToObjects<T>(dataSet.Tables[0]);
			}
			return null;
		}
		public DbDataReader ExecuteReader(CommandType commandType, string commandText)
		{
			return this.ExecuteReader(commandType, commandText, null);
		}
		public DbDataReader ExecuteReader(string spName, params object[] parameterValues)
		{
			if (this.ConnectionString == null || this.ConnectionString.Length == 0)
			{
				throw new ArgumentNullException("ConnectionString");
			}
			if (spName == null || spName.Length == 0)
			{
				throw new ArgumentNullException("spName");
			}
			if (parameterValues != null && parameterValues.Length > 0)
			{
				DbParameter[] spParameterSet = this.GetSpParameterSet(spName);
				this.AssignParameterValues(spParameterSet, parameterValues);
				return this.ExecuteReader(this.ConnectionString, new object[]
				{
					CommandType.StoredProcedure,
					spName,
					spParameterSet
				});
			}
			return this.ExecuteReader(this.ConnectionString, new object[]
			{
				CommandType.StoredProcedure,
				spName
			});
		}
		public DbDataReader ExecuteReader(CommandType commandType, string commandText, params DbParameter[] commandParameters)
		{
			if (this.ConnectionString == null || this.ConnectionString.Length == 0)
			{
				throw new ArgumentNullException("ConnectionString");
			}
			DbConnection dbConnection = null;
			DbDataReader result;
			try
			{
				dbConnection = this.Factory.CreateConnection();
				dbConnection.ConnectionString = this.ConnectionString;
				dbConnection.Open();
				result = this.ExecuteReader(dbConnection, null, commandType, commandText, commandParameters, DbHelper.DbConnectionOwnership.Internal);
			}
			catch
			{
				if (dbConnection != null)
				{
					dbConnection.Close();
				}
				throw;
			}
			return result;
		}
		public DbDataReader ExecuteReader(DbConnection connection, CommandType commandType, string commandText)
		{
			return this.ExecuteReader(connection, commandType, commandText, null);
		}
		public DbDataReader ExecuteReader(DbConnection connection, string spName, params object[] parameterValues)
		{
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			if (spName == null || spName.Length == 0)
			{
				throw new ArgumentNullException("spName");
			}
			if (parameterValues != null && parameterValues.Length > 0)
			{
				DbParameter[] spParameterSet = this.GetSpParameterSet(connection, spName);
				this.AssignParameterValues(spParameterSet, parameterValues);
				return this.ExecuteReader(connection, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return this.ExecuteReader(connection, CommandType.StoredProcedure, spName);
		}
		public DbDataReader ExecuteReader(DbTransaction transaction, CommandType commandType, string commandText)
		{
			return this.ExecuteReader(transaction, commandType, commandText, null);
		}
		public DbDataReader ExecuteReader(DbTransaction transaction, string spName, params object[] parameterValues)
		{
			if (transaction == null)
			{
				throw new ArgumentNullException("transaction");
			}
			if (transaction != null && transaction.Connection == null)
			{
				throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			}
			if (spName == null || spName.Length == 0)
			{
				throw new ArgumentNullException("spName");
			}
			if (parameterValues != null && parameterValues.Length > 0)
			{
				DbParameter[] spParameterSet = this.GetSpParameterSet(transaction.Connection, spName);
				this.AssignParameterValues(spParameterSet, parameterValues);
				return this.ExecuteReader(transaction, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return this.ExecuteReader(transaction, CommandType.StoredProcedure, spName);
		}
		public DbDataReader ExecuteReader(DbConnection connection, CommandType commandType, string commandText, params DbParameter[] commandParameters)
		{
			return this.ExecuteReader(connection, null, commandType, commandText, commandParameters, DbHelper.DbConnectionOwnership.External);
		}
		public DbDataReader ExecuteReader(DbTransaction transaction, CommandType commandType, string commandText, params DbParameter[] commandParameters)
		{
			if (transaction == null)
			{
				throw new ArgumentNullException("transaction");
			}
			if (transaction != null && transaction.Connection == null)
			{
				throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			}
			return this.ExecuteReader(transaction.Connection, transaction, commandType, commandText, commandParameters, DbHelper.DbConnectionOwnership.External);
		}
		private DbDataReader ExecuteReader(DbConnection connection, DbTransaction transaction, CommandType commandType, string commandText, DbParameter[] commandParameters, DbHelper.DbConnectionOwnership connectionOwnership)
		{
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			bool flag = false;
			DbCommand dbCommand = this.Factory.CreateCommand();
			DbDataReader result;
			try
			{
				this.PrepareCommand(dbCommand, connection, transaction, commandType, commandText, commandParameters, out flag);
				DateTime now = DateTime.Now;
				DbDataReader dbDataReader;
				if (connectionOwnership == DbHelper.DbConnectionOwnership.External)
				{
					dbDataReader = dbCommand.ExecuteReader();
				}
				else
				{
					dbDataReader = dbCommand.ExecuteReader(CommandBehavior.CloseConnection);
				}
				DateTime now2 = DateTime.Now;
				DbHelper.m_querydetail += DbHelper.GetQueryDetail(dbCommand.CommandText, now, now2, commandParameters);
				this.m_querycount++;
				bool flag2 = true;
				foreach (DbParameter dbParameter in dbCommand.Parameters)
				{
					if (dbParameter.Direction != ParameterDirection.Input)
					{
						flag2 = false;
					}
				}
				if (flag2)
				{
					dbCommand.Parameters.Clear();
				}
				result = dbDataReader;
			}
			catch
			{
				if (flag)
				{
					connection.Close();
				}
				throw;
			}
			return result;
		}
		public DbDataReader ExecuteReaderTypedParams(string spName, DataRow dataRow)
		{
			if (this.ConnectionString == null || this.ConnectionString.Length == 0)
			{
				throw new ArgumentNullException("ConnectionString");
			}
			if (spName == null || spName.Length == 0)
			{
				throw new ArgumentNullException("spName");
			}
			if (dataRow != null && dataRow.ItemArray.Length > 0)
			{
				DbParameter[] spParameterSet = this.GetSpParameterSet(spName);
				this.AssignParameterValues(spParameterSet, dataRow);
				return this.ExecuteReader(this.ConnectionString, new object[]
				{
					CommandType.StoredProcedure,
					spName,
					spParameterSet
				});
			}
			return this.ExecuteReader(this.ConnectionString, new object[]
			{
				CommandType.StoredProcedure,
				spName
			});
		}
		public DbDataReader ExecuteReaderTypedParams(DbConnection connection, string spName, DataRow dataRow)
		{
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			if (spName == null || spName.Length == 0)
			{
				throw new ArgumentNullException("spName");
			}
			if (dataRow != null && dataRow.ItemArray.Length > 0)
			{
				DbParameter[] spParameterSet = this.GetSpParameterSet(connection, spName);
				this.AssignParameterValues(spParameterSet, dataRow);
				return this.ExecuteReader(connection, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return this.ExecuteReader(connection, CommandType.StoredProcedure, spName);
		}
		public DbDataReader ExecuteReaderTypedParams(DbTransaction transaction, string spName, DataRow dataRow)
		{
			if (transaction == null)
			{
				throw new ArgumentNullException("transaction");
			}
			if (transaction != null && transaction.Connection == null)
			{
				throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			}
			if (spName == null || spName.Length == 0)
			{
				throw new ArgumentNullException("spName");
			}
			if (dataRow != null && dataRow.ItemArray.Length > 0)
			{
				DbParameter[] spParameterSet = this.GetSpParameterSet(transaction.Connection, spName);
				this.AssignParameterValues(spParameterSet, dataRow);
				return this.ExecuteReader(transaction, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return this.ExecuteReader(transaction, CommandType.StoredProcedure, spName);
		}
		public object ExecuteScalar(CommandType commandType, string commandText)
		{
			return this.ExecuteScalar(commandType, commandText, null);
		}
		public object ExecuteScalar(CommandType commandType, string commandText, params DbParameter[] commandParameters)
		{
			if (this.ConnectionString == null || this.ConnectionString.Length == 0)
			{
				throw new ArgumentNullException("ConnectionString");
			}
			object result;
			using (DbConnection dbConnection = this.Factory.CreateConnection())
			{
				dbConnection.ConnectionString = this.ConnectionString;
				dbConnection.Open();
				result = this.ExecuteScalar(dbConnection, commandType, commandText, commandParameters);
			}
			return result;
		}
		public object ExecuteScalar(DbConnection connection, CommandType commandType, string commandText)
		{
			return this.ExecuteScalar(connection, commandType, commandText, null);
		}
		public object ExecuteScalar(DbConnection connection, string spName, params object[] parameterValues)
		{
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			if (spName == null || spName.Length == 0)
			{
				throw new ArgumentNullException("spName");
			}
			if (parameterValues != null && parameterValues.Length > 0)
			{
				DbParameter[] spParameterSet = this.GetSpParameterSet(connection, spName);
				this.AssignParameterValues(spParameterSet, parameterValues);
				return this.ExecuteScalar(connection, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return this.ExecuteScalar(connection, CommandType.StoredProcedure, spName);
		}
		public object ExecuteScalar(DbTransaction transaction, CommandType commandType, string commandText)
		{
			return this.ExecuteScalar(transaction, commandType, commandText, null);
		}
		public object ExecuteScalar(DbTransaction transaction, string spName, params object[] parameterValues)
		{
			if (transaction == null)
			{
				throw new ArgumentNullException("transaction");
			}
			if (transaction != null && transaction.Connection == null)
			{
				throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			}
			if (spName == null || spName.Length == 0)
			{
				throw new ArgumentNullException("spName");
			}
			if (parameterValues != null && parameterValues.Length > 0)
			{
				DbParameter[] spParameterSet = this.GetSpParameterSet(transaction.Connection, spName);
				this.AssignParameterValues(spParameterSet, parameterValues);
				return this.ExecuteScalar(transaction, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return this.ExecuteScalar(transaction, CommandType.StoredProcedure, spName);
		}
		public object ExecuteScalar(DbConnection connection, CommandType commandType, string commandText, params DbParameter[] commandParameters)
		{
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			DbCommand dbCommand = this.Factory.CreateCommand();
			bool flag = false;
			this.PrepareCommand(dbCommand, connection, null, commandType, commandText, commandParameters, out flag);
			object result = dbCommand.ExecuteScalar();
			dbCommand.Parameters.Clear();
			if (flag)
			{
				connection.Close();
			}
			return result;
		}
		public object ExecuteScalar(DbTransaction transaction, CommandType commandType, string commandText, params DbParameter[] commandParameters)
		{
			if (transaction == null)
			{
				throw new ArgumentNullException("transaction");
			}
			if (transaction != null && transaction.Connection == null)
			{
				throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			}
			DbCommand dbCommand = this.Factory.CreateCommand();
			bool flag = false;
			this.PrepareCommand(dbCommand, transaction.Connection, transaction, commandType, commandText, commandParameters, out flag);
			DateTime now = DateTime.Now;
			object result = dbCommand.ExecuteScalar();
			DateTime now2 = DateTime.Now;
			DbHelper.m_querydetail += DbHelper.GetQueryDetail(dbCommand.CommandText, now, now2, commandParameters);
			this.m_querycount++;
			dbCommand.Parameters.Clear();
			return result;
		}
		public string ExecuteScalarToStr(CommandType commandType, string commandText)
		{
			object obj = this.ExecuteScalar(commandType, commandText);
			if (obj == null)
			{
				return "";
			}
			return obj.ToString();
		}
		public string ExecuteScalarToStr(CommandType commandType, string commandText, params DbParameter[] commandParameters)
		{
			object obj = this.ExecuteScalar(commandType, commandText, commandParameters);
			if (obj == null)
			{
				return "";
			}
			return obj.ToString();
		}
		public object ExecuteScalarTypedParams(string spName, DataRow dataRow)
		{
			if (this.ConnectionString == null || this.ConnectionString.Length == 0)
			{
				throw new ArgumentNullException("ConnectionString");
			}
			if (spName == null || spName.Length == 0)
			{
				throw new ArgumentNullException("spName");
			}
			if (dataRow != null && dataRow.ItemArray.Length > 0)
			{
				DbParameter[] spParameterSet = this.GetSpParameterSet(spName);
				this.AssignParameterValues(spParameterSet, dataRow);
				return this.ExecuteScalar(CommandType.StoredProcedure, spName, spParameterSet);
			}
			return this.ExecuteScalar(CommandType.StoredProcedure, spName);
		}
		public object ExecuteScalarTypedParams(DbConnection connection, string spName, DataRow dataRow)
		{
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			if (spName == null || spName.Length == 0)
			{
				throw new ArgumentNullException("spName");
			}
			if (dataRow != null && dataRow.ItemArray.Length > 0)
			{
				DbParameter[] spParameterSet = this.GetSpParameterSet(connection, spName);
				this.AssignParameterValues(spParameterSet, dataRow);
				return this.ExecuteScalar(connection, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return this.ExecuteScalar(connection, CommandType.StoredProcedure, spName);
		}
		public object ExecuteScalarTypedParams(DbTransaction transaction, string spName, DataRow dataRow)
		{
			if (transaction == null)
			{
				throw new ArgumentNullException("transaction");
			}
			if (transaction != null && transaction.Connection == null)
			{
				throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			}
			if (spName == null || spName.Length == 0)
			{
				throw new ArgumentNullException("spName");
			}
			if (dataRow != null && dataRow.ItemArray.Length > 0)
			{
				DbParameter[] spParameterSet = this.GetSpParameterSet(transaction.Connection, spName);
				this.AssignParameterValues(spParameterSet, dataRow);
				return this.ExecuteScalar(transaction, CommandType.StoredProcedure, spName, spParameterSet);
			}
			return this.ExecuteScalar(transaction, CommandType.StoredProcedure, spName);
		}
		public void FillDataset(CommandType commandType, string commandText, DataSet dataSet, string[] tableNames)
		{
			if (this.ConnectionString == null || this.ConnectionString.Length == 0)
			{
				throw new ArgumentNullException("ConnectionString");
			}
			if (dataSet == null)
			{
				throw new ArgumentNullException("dataSet");
			}
			using (DbConnection dbConnection = this.Factory.CreateConnection())
			{
				dbConnection.ConnectionString = this.ConnectionString;
				dbConnection.Open();
				this.FillDataset(dbConnection, commandType, commandText, dataSet, tableNames);
			}
		}
		public void FillDataset(string spName, DataSet dataSet, string[] tableNames, params object[] parameterValues)
		{
			if (this.ConnectionString == null || this.ConnectionString.Length == 0)
			{
				throw new ArgumentNullException("ConnectionString");
			}
			if (dataSet == null)
			{
				throw new ArgumentNullException("dataSet");
			}
			using (DbConnection dbConnection = this.Factory.CreateConnection())
			{
				dbConnection.ConnectionString = this.ConnectionString;
				dbConnection.Open();
				this.FillDataset(dbConnection, spName, dataSet, tableNames, parameterValues);
			}
		}
		public void FillDataset(CommandType commandType, string commandText, DataSet dataSet, string[] tableNames, params DbParameter[] commandParameters)
		{
			if (this.ConnectionString == null || this.ConnectionString.Length == 0)
			{
				throw new ArgumentNullException("ConnectionString");
			}
			if (dataSet == null)
			{
				throw new ArgumentNullException("dataSet");
			}
			using (DbConnection dbConnection = this.Factory.CreateConnection())
			{
				dbConnection.ConnectionString = this.ConnectionString;
				dbConnection.Open();
				this.FillDataset(dbConnection, commandType, commandText, dataSet, tableNames, commandParameters);
			}
		}
		public void FillDataset(DbConnection connection, CommandType commandType, string commandText, DataSet dataSet, string[] tableNames)
		{
			this.FillDataset(connection, commandType, commandText, dataSet, tableNames, null);
		}
		public void FillDataset(DbConnection connection, string spName, DataSet dataSet, string[] tableNames, params object[] parameterValues)
		{
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			if (dataSet == null)
			{
				throw new ArgumentNullException("dataSet");
			}
			if (spName == null || spName.Length == 0)
			{
				throw new ArgumentNullException("spName");
			}
			if (parameterValues != null && parameterValues.Length > 0)
			{
				DbParameter[] spParameterSet = this.GetSpParameterSet(connection, spName);
				this.AssignParameterValues(spParameterSet, parameterValues);
				this.FillDataset(connection, CommandType.StoredProcedure, spName, dataSet, tableNames, spParameterSet);
				return;
			}
			this.FillDataset(connection, CommandType.StoredProcedure, spName, dataSet, tableNames);
		}
		public void FillDataset(DbTransaction transaction, CommandType commandType, string commandText, DataSet dataSet, string[] tableNames)
		{
			this.FillDataset(transaction, commandType, commandText, dataSet, tableNames, null);
		}
		public void FillDataset(DbTransaction transaction, string spName, DataSet dataSet, string[] tableNames, params object[] parameterValues)
		{
			if (transaction == null)
			{
				throw new ArgumentNullException("transaction");
			}
			if (transaction != null && transaction.Connection == null)
			{
				throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
			}
			if (dataSet == null)
			{
				throw new ArgumentNullException("dataSet");
			}
			if (spName == null || spName.Length == 0)
			{
				throw new ArgumentNullException("spName");
			}
			if (parameterValues != null && parameterValues.Length > 0)
			{
				DbParameter[] spParameterSet = this.GetSpParameterSet(transaction.Connection, spName);
				this.AssignParameterValues(spParameterSet, parameterValues);
				this.FillDataset(transaction, CommandType.StoredProcedure, spName, dataSet, tableNames, spParameterSet);
				return;
			}
			this.FillDataset(transaction, CommandType.StoredProcedure, spName, dataSet, tableNames);
		}
		public void FillDataset(DbConnection connection, CommandType commandType, string commandText, DataSet dataSet, string[] tableNames, params DbParameter[] commandParameters)
		{
			this.FillDataset(connection, null, commandType, commandText, dataSet, tableNames, commandParameters);
		}
		public void FillDataset(DbTransaction transaction, CommandType commandType, string commandText, DataSet dataSet, string[] tableNames, params DbParameter[] commandParameters)
		{
			this.FillDataset(transaction.Connection, transaction, commandType, commandText, dataSet, tableNames, commandParameters);
		}
		private void FillDataset(DbConnection connection, DbTransaction transaction, CommandType commandType, string commandText, DataSet dataSet, string[] tableNames, params DbParameter[] commandParameters)
		{
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			if (dataSet == null)
			{
				throw new ArgumentNullException("dataSet");
			}
			DbCommand dbCommand = this.Factory.CreateCommand();
			bool flag = false;
			this.PrepareCommand(dbCommand, connection, transaction, commandType, commandText, commandParameters, out flag);
			using (DbDataAdapter dbDataAdapter = this.Factory.CreateDataAdapter())
			{
				dbDataAdapter.SelectCommand = dbCommand;
				if (tableNames != null && tableNames.Length > 0)
				{
					string text = "Table";
					for (int i = 0; i < tableNames.Length; i++)
					{
						if (tableNames[i] == null || tableNames[i].Length == 0)
						{
							throw new ArgumentException("The tableNames parameter must contain a list of tables, a value was provided as null or empty string.", "tableNames");
						}
						dbDataAdapter.TableMappings.Add(text, tableNames[i]);
						text += (i + 1).ToString();
					}
				}
				dbDataAdapter.Fill(dataSet);
				dbCommand.Parameters.Clear();
			}
			if (flag)
			{
				connection.Close();
			}
		}
		public DbParameter[] GetCachedParameterSet(string commandText)
		{
			if (this.ConnectionString == null || this.ConnectionString.Length == 0)
			{
				throw new ArgumentNullException("ConnectionString");
			}
			if (commandText == null || commandText.Length == 0)
			{
				throw new ArgumentNullException("commandText");
			}
			string key = this.ConnectionString + ":" + commandText;
			DbParameter[] array = this.m_paramcache[key] as DbParameter[];
			if (array == null)
			{
				return null;
			}
			return this.CloneParameters(array);
		}
		public DataTable GetEmptyTable(string tableName)
		{
			string commandText = string.Format("SELECT * FROM {0} WHERE 1=0", tableName);
			return this.ExecuteDataset(commandText).Tables[0];
		}
		private static string GetQueryDetail(string commandText, DateTime dtStart, DateTime dtEnd, DbParameter[] cmdParams)
		{
			string text = "<tr style=\"background: rgb(255, 255, 255) none repeat scroll 0%; -moz-background-clip: -moz-initial; -moz-background-origin: -moz-initial; -moz-background-inline-policy: -moz-initial;\">";
			string text2 = "";
			string text3 = "";
			string text4 = "";
			string arg = "";
			if (cmdParams != null && cmdParams.Length > 0)
			{
				for (int i = 0; i < cmdParams.Length; i++)
				{
					DbParameter dbParameter = cmdParams[i];
					if (dbParameter != null)
					{
						text2 = text2 + "<td>" + dbParameter.ParameterName + "</td>";
						text3 = text3 + "<td>" + dbParameter.DbType.ToString() + "</td>";
						text4 = text4 + "<td>" + dbParameter.Value.ToString() + "</td>";
					}
				}
				arg = string.Format("<table width=\"100%\" cellspacing=\"1\" cellpadding=\"0\" style=\"background: rgb(255, 255, 255) none repeat scroll 0%; margin-top: 5px; font-size: 12px; display: block; -moz-background-clip: -moz-initial; -moz-background-origin: -moz-initial; -moz-background-inline-policy: -moz-initial;\">{0}{1}</tr>{0}{2}</tr>{0}{3}</tr></table>", new object[]
				{
					text,
					text2,
					text3,
					text4
				});
			}
			return string.Format("<center><div style=\"border: 1px solid black; margin: 2px; padding: 1em; text-align: left; width: 96%; clear: both;\"><div style=\"font-size: 12px; float: right; width: 100px; margin-bottom: 5px;\"><b>TIME:</b> {0}</div><span style=\"font-size: 12px;\">{1}{2}</span></div><br /></center>", dtEnd.Subtract(dtStart).TotalMilliseconds / 1000.0, commandText, arg);
		}
		public DbParameter[] GetSpParameterSet(string spName)
		{
			return this.GetSpParameterSet(spName, false);
		}
		public DbParameter[] GetSpParameterSet(string spName, bool includeReturnValueParameter)
		{
			if (this.ConnectionString == null || this.ConnectionString.Length == 0)
			{
				throw new ArgumentNullException("ConnectionString");
			}
			if (spName == null || spName.Length == 0)
			{
				throw new ArgumentNullException("spName");
			}
			DbParameter[] spParameterSetInternal;
			using (DbConnection dbConnection = this.Factory.CreateConnection())
			{
				dbConnection.ConnectionString = this.ConnectionString;
				spParameterSetInternal = this.GetSpParameterSetInternal(dbConnection, spName, includeReturnValueParameter);
			}
			return spParameterSetInternal;
		}
		internal DbParameter[] GetSpParameterSet(DbConnection connection, string spName)
		{
			return this.GetSpParameterSet(connection, spName, false);
		}
		internal DbParameter[] GetSpParameterSet(DbConnection connection, string spName, bool includeReturnValueParameter)
		{
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			DbParameter[] spParameterSetInternal;
			using (DbConnection dbConnection = (DbConnection)((ICloneable)connection).Clone())
			{
				spParameterSetInternal = this.GetSpParameterSetInternal(dbConnection, spName, includeReturnValueParameter);
			}
			return spParameterSetInternal;
		}
		private DbParameter[] GetSpParameterSetInternal(DbConnection connection, string spName, bool includeReturnValueParameter)
		{
			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}
			if (spName == null || spName.Length == 0)
			{
				throw new ArgumentNullException("spName");
			}
			string key = connection.ConnectionString + ":" + spName + (includeReturnValueParameter ? ":include ReturnValue Parameter" : "");
			DbParameter[] array = this.m_paramcache[key] as DbParameter[];
			if (array == null)
			{
				DbParameter[] array2 = this.DiscoverSpParameterSet(connection, spName, includeReturnValueParameter);
				this.m_paramcache[key] = array2;
				array = array2;
			}
			return this.CloneParameters(array);
		}
		public DbParameter MakeInParam(string paraName, object paraValue)
		{
			return this.MakeParam(paraName, paraValue, ParameterDirection.Input);
		}
		public DbParameter MakeOutParam(string paraName, Type paraType)
		{
			return this.MakeParam(paraName, null, ParameterDirection.Output, paraType, "");
		}
		public DbParameter MakeOutParam(string paraName, Type paraType, int size)
		{
			return this.MakeParam(paraName, null, ParameterDirection.Output, paraType, "", size);
		}
		public DbParameter MakeOutParam(string paraName, object paraValue, Type paraType, int size)
		{
			return this.MakeParam(paraName, paraValue, ParameterDirection.Output, paraType, "", size);
		}
		public DbParameter MakeParam(string paraName, object paraValue, ParameterDirection direction)
		{
			return this.Provider.MakeParam(paraName, paraValue, direction);
		}
		public DbParameter MakeParam(string paraName, object paraValue, ParameterDirection direction, Type paraType, string sourceColumn)
		{
			return this.Provider.MakeParam(paraName, paraValue, direction, paraType, sourceColumn);
		}
		public DbParameter MakeParam(string paraName, object paraValue, ParameterDirection direction, Type paraType, string sourceColumn, int size)
		{
			return this.Provider.MakeParam(paraName, paraValue, direction, paraType, sourceColumn, size);
		}
		public DbParameter MakeReturnParam()
		{
			return this.MakeReturnParam("ReturnValue");
		}
		public DbParameter MakeReturnParam(string paraName)
		{
			return this.MakeParam(paraName, 0, ParameterDirection.ReturnValue);
		}
		private void PrepareCommand(DbCommand command, DbConnection connection, DbTransaction transaction, CommandType commandType, string commandText, DbParameter[] commandParameters, out bool mustCloseConnection)
		{
			if (command == null)
			{
				throw new ArgumentNullException("command");
			}
			if (commandText == null || commandText.Length == 0)
			{
				throw new ArgumentNullException("commandText");
			}
			if (connection.State != ConnectionState.Open)
			{
				mustCloseConnection = true;
				connection.Open();
			}
			else
			{
				mustCloseConnection = false;
			}
			command.Connection = connection;
			command.CommandText = commandText;
			if (transaction != null)
			{
				if (transaction.Connection == null)
				{
					throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
				}
				command.Transaction = transaction;
			}
			command.CommandType = commandType;
			if (commandParameters != null)
			{
				this.AttachParameters(command, commandParameters);
			}
		}
		public void ResetDbProvider()
		{
			this.m_connectionstring = null;
			this.m_factory = null;
			this.m_provider = null;
		}
		public int RunProc(string procName)
		{
			return this.ExecuteNonQuery(CommandType.StoredProcedure, procName, null);
		}
		public void RunProc(string procName, out DbDataReader reader)
		{
			reader = this.ExecuteReader(CommandType.StoredProcedure, procName, null);
		}
		public void RunProc(string procName, out DataSet ds)
		{
			ds = this.ExecuteDataset(CommandType.StoredProcedure, procName, null);
		}
		public void RunProc(string procName, out object obj)
		{
			obj = this.ExecuteScalar(CommandType.StoredProcedure, procName, null);
		}
		public int RunProc(string procName, List<DbParameter> prams)
		{
			prams.Add(this.MakeReturnParam());
			return this.ExecuteNonQuery(CommandType.StoredProcedure, procName, prams.ToArray());
		}
		public void RunProc(string procName, List<DbParameter> prams, out DbDataReader reader)
		{
			prams.Add(this.MakeReturnParam());
			reader = this.ExecuteReader(CommandType.StoredProcedure, procName, prams.ToArray());
		}
		public void RunProc(string procName, List<DbParameter> prams, out DataSet ds)
		{
			prams.Add(this.MakeReturnParam());
			ds = this.ExecuteDataset(CommandType.StoredProcedure, procName, prams.ToArray());
		}
		public void RunProc(string procName, List<DbParameter> prams, out object obj)
		{
			prams.Add(this.MakeReturnParam());
			obj = this.ExecuteScalar(CommandType.StoredProcedure, procName, prams.ToArray());
		}
		public T RunProcObject<T>(string procName)
		{
			DataSet dataSet = null;
			this.RunProc(procName, out dataSet);
			if (Validate.CheckedDataSet(dataSet))
			{
				return DataHelper.ConvertRowToObject<T>(dataSet.Tables[0].Rows[0]);
			}
			return default(T);
		}
		public T RunProcObject<T>(string procName, List<DbParameter> prams)
		{
			DataSet dataSet = null;
			this.RunProc(procName, prams, out dataSet);
			if (Validate.CheckedDataSet(dataSet))
			{
				return DataHelper.ConvertRowToObject<T>(dataSet.Tables[0].Rows[0]);
			}
			return default(T);
		}
		public IList<T> RunProcObjectList<T>(string procName)
		{
			DataSet dataSet = null;
			this.RunProc(procName, out dataSet);
			if (Validate.CheckedDataSet(dataSet))
			{
				return DataHelper.ConvertDataTableToObjects<T>(dataSet.Tables[0]);
			}
			return null;
		}
		public IList<T> RunProcObjectList<T>(string procName, List<DbParameter> prams)
		{
			DataSet dataSet = null;
			this.RunProc(procName, prams, out dataSet);
			if (Validate.CheckedDataSet(dataSet))
			{
				return DataHelper.ConvertDataTableToObjects<T>(dataSet.Tables[0]);
			}
			return null;
		}
		public void UpdateByDataSet(DataSet dataSet, string tableName)
		{
			DbDataAdapter dbDataAdapter = this.Factory.CreateDataAdapter();
			dbDataAdapter.SelectCommand.CommandText = string.Format("Select * from {0} ORDER BY DayID DESC", tableName);
			DbCommandBuilder dbCommandBuilder = this.Factory.CreateCommandBuilder();
			dbCommandBuilder.DataAdapter.SelectCommand.Connection = this.Factory.CreateConnection();
			DataSet dataSet2 = new DataSet();
			dbDataAdapter.Fill(dataSet2);
			dataSet2.Tables[0].Rows[0][1] = "107";
			dbDataAdapter.Update(dataSet2);
		}
		public void UpdateDataSet(DataSet dataSet, string tableName)
		{
			string commandText = string.Format("Select * from {0} where 1=0", tableName);
			DbCommandBuilder dbCommandBuilder = this.Factory.CreateCommandBuilder();
			dbCommandBuilder.DataAdapter = this.Factory.CreateDataAdapter();
			dbCommandBuilder.DataAdapter.SelectCommand = this.Factory.CreateCommand();
			dbCommandBuilder.DataAdapter.DeleteCommand = this.Factory.CreateCommand();
			dbCommandBuilder.DataAdapter.InsertCommand = this.Factory.CreateCommand();
			dbCommandBuilder.DataAdapter.UpdateCommand = this.Factory.CreateCommand();
			dbCommandBuilder.DataAdapter.SelectCommand.CommandText = commandText;
			dbCommandBuilder.DataAdapter.SelectCommand.Connection = this.Factory.CreateConnection();
			dbCommandBuilder.DataAdapter.DeleteCommand.Connection = this.Factory.CreateConnection();
			dbCommandBuilder.DataAdapter.InsertCommand.Connection = this.Factory.CreateConnection();
			dbCommandBuilder.DataAdapter.UpdateCommand.Connection = this.Factory.CreateConnection();
			dbCommandBuilder.DataAdapter.SelectCommand.Connection.ConnectionString = this.ConnectionString;
			dbCommandBuilder.DataAdapter.DeleteCommand.Connection.ConnectionString = this.ConnectionString;
			dbCommandBuilder.DataAdapter.InsertCommand.Connection.ConnectionString = this.ConnectionString;
			dbCommandBuilder.DataAdapter.UpdateCommand.Connection.ConnectionString = this.ConnectionString;
			this.UpdateDataSet(dbCommandBuilder.GetInsertCommand(), dbCommandBuilder.GetDeleteCommand(), dbCommandBuilder.GetUpdateCommand(), dataSet, tableName);
		}
		public void UpdateDataSet(DbCommand insertCommand, DbCommand deleteCommand, DbCommand updateCommand, DataSet dataSet, string tableName)
		{
			if (insertCommand == null)
			{
				throw new ArgumentNullException("insertCommand");
			}
			if (deleteCommand == null)
			{
				throw new ArgumentNullException("deleteCommand");
			}
			if (updateCommand == null)
			{
				throw new ArgumentNullException("updateCommand");
			}
			if (tableName == null || tableName.Length == 0)
			{
				throw new ArgumentNullException("tableName");
			}
			using (DbDataAdapter dbDataAdapter = this.Factory.CreateDataAdapter())
			{
				dbDataAdapter.UpdateCommand = updateCommand;
				dbDataAdapter.InsertCommand = insertCommand;
				dbDataAdapter.DeleteCommand = deleteCommand;
				dbDataAdapter.Update(dataSet, tableName);
				dataSet.AcceptChanges();
			}
		}
	}
}
