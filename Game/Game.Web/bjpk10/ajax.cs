using System;
using System.Web.UI;
namespace Game.Web.bjpk10
{
	public class ajax : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			string s;
			if (base.Request["gameCode"] == "bjpk10")
			{
				long num = ajax.ConvertDateTimeToInt(System.DateTime.Now);
				long num2 = 1515403350000L;
				long num3 = 1515403650000L;
				s = string.Concat(new object[]
				{
					"{ \"gameCode\": \"bjpk10\", \"preIssue\": \"660574\", \"openNum\": [1,4,3,6,9,10,8,7,5,2], \"dragonTigerArr\": [1, 1, 2, 2, 2], \"sumArr\": [15, 1, 1, 0], \"issue\": \"660575\", \"currentOpenDateTime\": ",
					num2,
					", \"openDateTime\": ",
					num3,
					", \"serverTime\": ",
					num,
					", \"openedCount\": 92, \"dailyTotal\": 179, \"formArr\": [], \"mimcryArr\": [], \"zodiacArr\": [], \"compareArr\": [1, 2, 1, 2, 1, 2, 1, 2, 2, 1], \"sumType\": null, \"wuxing\": null }"
				});
			}
			else
			{
				s = "{\"serverTime\":" + ajax.ConvertDateTimeToInt(System.DateTime.Now) + "}";
			}
			base.Response.Write(s);
			base.Response.End();
		}
		public static long ConvertDateTimeToInt(System.DateTime time)
		{
			System.DateTime dateTime = System.TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
			return (time.Ticks - dateTime.Ticks) / 10000L;
		}
	}
}
