using Game.Entity.Treasure;
using Game.Facade;
using Game.Utils;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Services;
namespace Game.Web.WS
{
	[WebService(Namespace = "http://tempuri.org/"), WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	public class PhoneRank : System.Web.IHttpHandler
	{
		public bool IsReusable
		{
			get
			{
				return false;
			}
		}
		public void ProcessRequest(System.Web.HttpContext context)
		{
			context.Response.ContentType = "text/plain";
			string queryString = GameRequest.GetQueryString("action");
			string a;
			if ((a = queryString) != null)
			{
				if (a == "getscorerank")
				{
					this.GetScoreRank(context);
				}
			}
		}
		protected void GetScoreRank(System.Web.HttpContext context)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			int num = GameRequest.GetInt("pageindex", 1);
			int num2 = GameRequest.GetInt("pagesize", 10);
			int @int = GameRequest.GetInt("UserID", 0);
			if (num <= 0)
			{
				num = 1;
			}
			if (num2 <= 0)
			{
				num2 = 10;
			}
			if (num2 > 50)
			{
				num2 = 50;
			}
			string sqlQuery = string.Format("SELECT a.*,b.FaceID,b.Experience,b.MemberOrder,b.GameID,b.UserMedal,b.UnderWrite FROM (SELECT ROW_NUMBER() OVER (ORDER BY Score DESC) as ChartID,UserID,Score FROM GameScoreInfo) a,RYAccountsDB.dbo.AccountsInfo b WHERE a.UserID=b.UserID AND a.UserID={0}", @int);
			System.Data.DataSet dataSetByWhere = FacadeManage.aideTreasureFacade.GetDataSetByWhere(sqlQuery);
			int num3 = 0;
			long num4 = 0L;
			int num5 = 0;
			int experience = 0;
			int num6 = 0;
			int num7 = 0;
			int num8 = 0;
			string text = "";
			decimal num9 = 0m;
			decimal num10 = 0m;
			if (dataSetByWhere.Tables[0].Rows.Count != 0)
			{
				num3 = System.Convert.ToInt32(dataSetByWhere.Tables[0].Rows[0]["ChartID"]);
				num4 = System.Convert.ToInt64(dataSetByWhere.Tables[0].Rows[0]["Score"]);
				num5 = System.Convert.ToInt32(dataSetByWhere.Tables[0].Rows[0]["FaceID"]);
				experience = System.Convert.ToInt32(dataSetByWhere.Tables[0].Rows[0]["Experience"]);
				num6 = System.Convert.ToInt32(dataSetByWhere.Tables[0].Rows[0]["MemberOrder"]);
				num7 = System.Convert.ToInt32(dataSetByWhere.Tables[0].Rows[0]["GameID"]);
				num8 = System.Convert.ToInt32(dataSetByWhere.Tables[0].Rows[0]["UserMedal"]);
				text = dataSetByWhere.Tables[0].Rows[0]["UnderWrite"].ToString();
				num9 = this.GetUserScore(System.Convert.ToInt32(dataSetByWhere.Tables[0].Rows[0]["UserID"]));
				num10 = this.GetUserCurrency(System.Convert.ToInt32(dataSetByWhere.Tables[0].Rows[0]["UserID"]));
			}
			System.Data.DataSet pageSet = FacadeManage.aideTreasureFacade.GetList("GameScoreInfo", num, num2, " ORDER BY Score DESC", " ", "UserID,Score").PageSet;
			if (pageSet.Tables[0].Rows.Count > 0)
			{
				stringBuilder.Append("[");
				stringBuilder.Append(string.Concat(new object[]
				{
					"{\"NickName\":\"",
					Fetch.GetNickNameByUserID(@int),
					"\",\"Score\":",
					num4,
					",\"UserID\":",
					@int,
					",\"Rank\":",
					num3,
					",\"FaceID\":",
					num5,
					",\"Experience\":",
					Fetch.GetGradeConfig(experience),
					",\"MemberOrder\":",
					num6,
					",\"GameID\":",
					num7,
					",\"UserMedal\":",
					num8,
					",\"szSign\":\"",
					text,
					"\",\"Score\":",
					num9,
					",\"Currency\":",
					num10,
					"},"
				}));
				foreach (System.Data.DataRow dataRow in pageSet.Tables[0].Rows)
				{
					stringBuilder.Append(string.Concat(new object[]
					{
						"{\"NickName\":\"",
						Fetch.GetNickNameByUserID(System.Convert.ToInt32(dataRow["UserID"])),
						"\",\"Score\":",
						dataRow["Score"],
						",\"UserID\":",
						dataRow["UserID"],
						",\"FaceID\":",
						Fetch.GetUserGlobalInfo(System.Convert.ToInt32(dataRow["UserID"])).FaceID,
						",\"Experience\":",
						Fetch.GetGradeConfig(Fetch.GetUserGlobalInfo(System.Convert.ToInt32(dataRow["UserID"])).Experience),
						",\"MemberOrder\":",
						Fetch.GetUserGlobalInfo(System.Convert.ToInt32(dataRow["UserID"])).MemberOrder,
						",\"GameID\":",
						Fetch.GetUserGlobalInfo(System.Convert.ToInt32(dataRow["UserID"])).GameID,
						",\"UserMedal\":",
						Fetch.GetUserGlobalInfo(System.Convert.ToInt32(dataRow["UserID"])).UserMedal,
						",\"szSign\":\"",
						Fetch.GetUserGlobalInfo(System.Convert.ToInt32(dataRow["UserID"])).UnderWrite,
						"\",\"Score\":",
						this.GetUserScore(System.Convert.ToInt32(dataRow["UserID"])),
						",\"Currency\":",
						this.GetUserCurrency(System.Convert.ToInt32(dataRow["UserID"])),
						"},"
					}));
				}
				stringBuilder.Remove(stringBuilder.Length - 1, 1);
				stringBuilder.Append("]");
			}
			else
			{
				stringBuilder.Append("{}");
			}
			context.Response.Write(stringBuilder.ToString());
		}
		public decimal GetUserScore(int userID)
		{
			GameScoreInfo treasureInfo = FacadeManage.aideTreasureFacade.GetTreasureInfo2(userID);
			decimal result;
			if (treasureInfo != null)
			{
				result = treasureInfo.Score;
			}
			else
			{
				result = 0m;
			}
			return result;
		}
		public decimal GetUserCurrency(int userID)
		{
			UserCurrencyInfo userCurrencyInfo = FacadeManage.aideTreasureFacade.GetUserCurrencyInfo(userID);
			decimal result;
			if (userCurrencyInfo != null)
			{
				result = userCurrencyInfo.Currency;
			}
			else
			{
				result = 0m;
			}
			return result;
		}
	}
}
