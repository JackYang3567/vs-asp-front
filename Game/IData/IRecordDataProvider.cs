using Game.Kernel;
using System;
using System.Data;
namespace Game.IData
{
	public interface IRecordDataProvider
	{
		PagerSet GetLovesRecord(string whereQuery, int pageIndex, int pageSize);
		PagerSet GetMedalConvertRecord(string whereQuery, int pageIndex, int pageSize);
		DataTable GetAdvertInfo(string Advertiser, int IsWeek = 1);
	}
}
