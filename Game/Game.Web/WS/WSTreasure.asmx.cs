using Game.Facade;
using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Protocols;
namespace Game.Web.WS
{
    [ToolboxItem(false), ScriptService, WebService(Namespace = "http://tempuri.org/"), WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class WSTreasure : WebService
    {
        [SoapHeader("Credentials"), WebMethod]
        public string GetUserScoroInfo()
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            System.Data.DataSet scoreRanking = FacadeManage.aideTreasureFacade.GetScoreRanking(10);
            if (scoreRanking.Tables[0].Rows.Count > 0)
            {
                stringBuilder.Append("[");
                foreach (System.Data.DataRow dataRow in scoreRanking.Tables[0].Rows)
                {
                    stringBuilder.Append(string.Concat(new object[]
					{
						"{userName:'",
						dataRow["NickName"],
						"',s:'",
						dataRow["Score"],
						"'},"
					}));
                }
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
                stringBuilder.Append("]");
            }
            else
            {
                stringBuilder.Append("{}");
            }
            return stringBuilder.ToString();
        }
    }
}
