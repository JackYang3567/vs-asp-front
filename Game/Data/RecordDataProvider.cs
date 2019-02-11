using Game.IData;
using Game.Kernel;
using System;
using System.Data;
using System.Text;
namespace Game.Data
{
	public class RecordDataProvider : BaseDataProvider, IRecordDataProvider
	{
		public RecordDataProvider(string connString) : base(connString)
		{
		}
		public PagerSet GetLovesRecord(string whereQuery, int pageIndex, int pageSize)
		{
			string pkey = "ORDER By CollectDate DESC";
			string[] fields = new string[]
			{
				"RecordID",
				"UserID",
				"KindID",
				"ServerID",
				"CurInsureScore",
				"CurPresent",
				"ConvertPresent",
				"ConvertRate",
				"IsGamePlaza",
				"ClientIP",
				"CollectDate"
			};
			return this.GetPagerSet2(new PagerParameters("RecordConvertPresent", pkey, whereQuery, pageIndex, pageSize)
			{
				Fields = fields,
				CacherSize = 2
			});
		}
		public PagerSet GetMedalConvertRecord(string whereQuery, int pageIndex, int pageSize)
		{
			string pkey = "ORDER By CollectDate DESC";
			string[] fields = new string[]
			{
				"RecordID",
				"UserID",
				"CurInsureScore",
				"CurUserMedal",
				"ConvertUserMedal",
				"ConvertRate",
				"IsGamePlaza",
				"ClientIP",
				"CollectDate"
			};
			return this.GetPagerSet2(new PagerParameters("RecordConvertUserMedal", pkey, whereQuery, pageIndex, pageSize)
			{
				Fields = fields,
				CacherSize = 2
			});
		}
		public System.Data.DataTable GetAdvertInfo(string Advertiser, int IsWeek = 1)
		{
			System.Data.DataTable dataTable = new System.Data.DataTable();
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.AppendFormat("select adv.TaskID,adv.BeginTime,adv.EndTime,adv.AdKey,adv.AdID,adv.PcUrl,k.KindID,k.IsWeek,k.CountType from (select top 1 t.BeginTime,t.EndTime,t.ID as TaskID,a.AdKey,a.PcUrl,t.AdID from dbo.T_Rec_Advertiser a join dbo.T_Rec_AdvertTask t on a.ID=t.AdvertiserID and a.StatusT=1 and t.StatusT=1 where a.Advertiser='{0}' order by t.AddTime desc) as adv inner join T_Rec_AdvertTaskKinds k on adv.TaskID=k.TaskID", Advertiser);
			if (IsWeek == 1)
			{
				stringBuilder.Append("  and k.IsWeek=1 ");
			}
			return base.Database.ExecuteDataset(stringBuilder.ToString()).Tables[0];
		}
	}
}
