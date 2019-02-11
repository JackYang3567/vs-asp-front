using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
namespace Game.Kernel
{
	public class PagerManager
	{
		private DbHelper m_dbHelper;
		private IDictionary<int, PagerSet> m_fixedCacher;
		private PagerParameters m_prams;
		public PagerManager(DbHelper dbHelper)
		{
			this.m_dbHelper = dbHelper;
		}
		public PagerManager(string connectionString)
		{
			this.m_dbHelper = new DbHelper(connectionString);
		}
		public PagerManager(PagerParameters prams, DbHelper dbHelper)
		{
			this.m_prams = prams;
			this.m_dbHelper = dbHelper;
		}
		public PagerManager(PagerParameters prams, string connectionString)
		{
			this.m_prams = prams;
			this.m_dbHelper = new DbHelper(connectionString);
			if (prams.CacherSize > 0)
			{
				this.m_fixedCacher = new Dictionary<int, PagerSet>(prams.CacherSize);
			}
		}
		private void CacheObject(int index, PagerSet pagerSet)
		{
			if (this.m_fixedCacher != null)
			{
				this.m_fixedCacher.Add(index, pagerSet);
				return;
			}
			if (this.m_prams.CacherSize > 0)
			{
				this.m_fixedCacher = new Dictionary<int, PagerSet>(this.m_prams.CacherSize);
				this.m_fixedCacher.Add(index, pagerSet);
			}
		}
		private PagerSet GetCachedObject(int index)
		{
			if (this.m_fixedCacher == null)
			{
				return null;
			}
			if (!this.m_fixedCacher.ContainsKey(index))
			{
				return null;
			}
			return this.m_fixedCacher[index];
		}
		protected string GetFieldString(string[] fields, string[] fieldAlias)
		{
			if (fields == null)
			{
				fields = new string[]
				{
					"*"
				};
			}
			string text = "";
			if (fieldAlias == null)
			{
				for (int i = 0; i < fields.Length; i++)
				{
					text = text + " " + fields[i];
					if (i != fields.Length - 1)
					{
						text += " , ";
					}
					else
					{
						text += " ";
					}
				}
				return text;
			}
			for (int i = 0; i < fields.Length; i++)
			{
				text = text + " " + fields[i];
				if (fieldAlias[i] != null)
				{
					text = text + " as " + fieldAlias[i];
				}
				if (i != fields.Length - 1)
				{
					text += " , ";
				}
				else
				{
					text += " ";
				}
			}
			return text;
		}
		public PagerSet GetPagerSet()
		{
			return this.GetPagerSet(this.m_prams);
		}
		public PagerSet GetPagerSet(PagerParameters pramsPager)
		{
			if (this.m_prams == null)
			{
				this.m_prams = pramsPager;
			}
			if (pramsPager.PageIndex < 0)
			{
				return null;
			}
			List<DbParameter> list = new List<DbParameter>
			{
				this.m_dbHelper.MakeInParam("TableName", pramsPager.Table),
				this.m_dbHelper.MakeInParam("ReturnFields", this.GetFieldString(pramsPager.Fields, pramsPager.FieldAlias)),
				this.m_dbHelper.MakeInParam("PageSize", pramsPager.PageSize),
				this.m_dbHelper.MakeInParam("PageIndex", pramsPager.PageIndex),
				this.m_dbHelper.MakeInParam("Where", pramsPager.WhereStr),
				this.m_dbHelper.MakeInParam("Orderfld", pramsPager.PKey),
				this.m_dbHelper.MakeInParam("OrderType", pramsPager.Ascending ? 0 : 1),
				this.m_dbHelper.MakeOutParam("PageCount", typeof(int)),
				this.m_dbHelper.MakeOutParam("RecordCount", typeof(int))
			};
			DataSet pageSet = new DataSet();
			return new PagerSet(pramsPager.PageIndex, pramsPager.PageSize, Convert.ToInt32(list[list.Count - 3].Value), Convert.ToInt32(list[list.Count - 2].Value), pageSet)
			{
				PageSet = 
				{
					DataSetName = "PagerSet_" + pramsPager.Table
				}
			};
		}
		public PagerSet GetPagerSet2(PagerParameters pramsPager)
		{
			if (this.m_prams == null)
			{
				this.m_prams = pramsPager;
			}
			if (pramsPager.PageIndex < 0)
			{
				return null;
			}
			List<DbParameter> list = new List<DbParameter>
			{
				this.m_dbHelper.MakeInParam("TableName", pramsPager.Table),
				this.m_dbHelper.MakeInParam("ReturnFields", this.GetFieldString(pramsPager.Fields, pramsPager.FieldAlias)),
				this.m_dbHelper.MakeInParam("PageSize", pramsPager.PageSize),
				this.m_dbHelper.MakeInParam("PageIndex", pramsPager.PageIndex),
				this.m_dbHelper.MakeInParam("Where", pramsPager.WhereStr),
				this.m_dbHelper.MakeInParam("Orderby", pramsPager.PKey),
				this.m_dbHelper.MakeOutParam("PageCount", typeof(int)),
				this.m_dbHelper.MakeOutParam("RecordCount", typeof(int))
			};
			DataSet pageSet;
			this.m_dbHelper.RunProc("WEB_PageView", list, out pageSet);
			return new PagerSet(pramsPager.PageIndex, pramsPager.PageSize, Convert.ToInt32(list[list.Count - 3].Value), Convert.ToInt32(list[list.Count - 2].Value), pageSet)
			{
				PageSet = 
				{
					DataSetName = "PagerSet_" + pramsPager.Table
				}
			};
		}
	}
}
