using Game.Data.Factory;
using Game.IData;
using Game.Kernel;
using System;
using System.Data;
namespace Game.Facade
{
	public class RecordFacade
	{
		private IRecordDataProvider recordData;
		public RecordFacade()
		{
			this.recordData = ClassFactory.GetIRecordDataProvider();
		}
		public PagerSet GetLovesRecord(string whereQuery, int pageIndex, int pageSize)
		{
			return this.recordData.GetLovesRecord(whereQuery, pageIndex, pageSize);
		}
		public PagerSet GetMedalConvertRecord(string whereQuery, int pageIndex, int pageSize)
		{
			return this.recordData.GetMedalConvertRecord(whereQuery, pageIndex, pageSize);
		}
		public DataTable GetAdvertInfo(string Advertiser, int IsWeek = 1)
		{
			return this.recordData.GetAdvertInfo(Advertiser, IsWeek);
		}
	}
}
