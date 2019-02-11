using Game.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace Game.Kernel
{
	public class TableProvider : BaseDataProvider, ITableProvider
	{
		private string m_tableName;
		public string TableName
		{
			get
			{
				return this.m_tableName;
			}
		}
		public TableProvider(DbHelper database, string tableName) : base(database)
		{
			this.m_tableName = "";
			this.m_tableName = tableName;
		}
		public TableProvider(string connectionString, string tableName) : base(connectionString)
		{
			this.m_tableName = "";
			this.m_tableName = tableName;
		}
		public void BatchCommitData(DataSet dataSet, string[][] columnMapArray)
		{
			this.BatchCommitData(dataSet.Tables[0], columnMapArray);
		}
		public void BatchCommitData(DataTable table, string[][] columnMapArray)
		{
			using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(base.Database.ConnectionString))
			{
				sqlBulkCopy.DestinationTableName = this.TableName;
				for (int i = 0; i < columnMapArray.Length; i++)
				{
					string[] array = columnMapArray[i];
					sqlBulkCopy.ColumnMappings.Add(array[0], array[1]);
				}
				sqlBulkCopy.WriteToServer(table);
				sqlBulkCopy.Close();
			}
		}
		public void CommitData(DataTable dt)
		{
			DataSet dataSet = this.ConstructDataSet(dt);
			base.Database.UpdateDataSet(dataSet, this.TableName);
		}
		private DataSet ConstructDataSet(DataTable dt)
		{
			if (dt.DataSet != null)
			{
				return dt.DataSet;
			}
			return new DataSet
			{
				Tables = 
				{
					dt
				}
			};
		}
		public void Delete(string where)
		{
			string commandText = string.Format("DELETE FROM {0} {1}", this.TableName, where);
			base.Database.ExecuteNonQuery(commandText);
		}
		public DataSet Get(string where)
		{
			string commandText = string.Format("SELECT * FROM {0} {1}", this.TableName, where);
			return base.Database.ExecuteDataset(commandText);
		}
		public DataTable GetEmptyTable()
		{
			DataTable emptyTable = base.Database.GetEmptyTable(this.TableName);
			emptyTable.TableName = this.TableName;
			return emptyTable;
		}
		public DataRow NewRow()
		{
			DataTable emptyTable = this.GetEmptyTable();
			DataRow dataRow = emptyTable.NewRow();
			for (int i = 0; i < emptyTable.Columns.Count; i++)
			{
				dataRow[i] = DBNull.Value;
			}
			return dataRow;
		}
		public T GetObject<T>(string where)
		{
			DataRow one = this.GetOne(where);
			if (one == null)
			{
				return default(T);
			}
			return DataHelper.ConvertRowToObject<T>(one);
		}
		public IList<T> GetObjectList<T>(string where)
		{
			DataSet dataSet = this.Get(where);
			if (Validate.CheckedDataSet(dataSet))
			{
				return DataHelper.ConvertDataTableToObjects<T>(dataSet.Tables[0]);
			}
			return null;
		}
		public DataRow GetOne(string where)
		{
			DataSet dataSet = this.Get(where);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				return dataSet.Tables[0].Rows[0];
			}
			return null;
		}
		public int GetRecordsCount(string where)
		{
			if (where == null)
			{
				where = "";
			}
			string commandText = string.Format("SELECT COUNT(*) FROM {0} {1}", this.TableName, where);
			return int.Parse(base.Database.ExecuteScalarToStr(CommandType.Text, commandText));
		}
		public void Insert(DataRow row)
		{
			DataTable emptyTable = this.GetEmptyTable();
			try
			{
				DataRow dataRow = emptyTable.NewRow();
				for (int i = 0; i < emptyTable.Columns.Count; i++)
				{
					dataRow[i] = row[i];
				}
				emptyTable.Rows.Add(dataRow);
				this.CommitData(emptyTable);
			}
			catch
			{
				throw;
			}
			finally
			{
				emptyTable.Rows.Clear();
				emptyTable.AcceptChanges();
			}
		}
	}
}
