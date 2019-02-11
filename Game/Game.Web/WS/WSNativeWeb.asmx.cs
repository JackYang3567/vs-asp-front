using Game.Entity.NativeWeb;
using Game.Facade;
using System;
using System.ComponentModel;
using System.Web.Script.Services;
using System.Web.Services;
namespace Game.Web.WS
{
    [ToolboxItem(false), ScriptService, WebService(Namespace = "http://tempuri.org/"), WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class WSNativeWeb : WebService
    {
        [WebMethod]
        public string GetFeedBack(int feedID)
        {
            GameFeedbackInfo gameFeedBackInfo = FacadeManage.aideNativeWebFacade.GetGameFeedBackInfo(feedID, 0);
            string result;
            if (gameFeedBackInfo != null)
            {
                FacadeManage.aideNativeWebFacade.UpdateFeedbackViewCount(feedID);
                result = string.Concat(new object[]
				{
					"{success:'success',userName:'",
					(gameFeedBackInfo.UserID == 0) ? "匿名用户" : gameFeedBackInfo.UserID.ToString(),
					"',fcon:'",
					gameFeedBackInfo.FeedbackContent,
					"',rcon:'",
					gameFeedBackInfo.RevertContent,
					"',count:'",
					gameFeedBackInfo.ViewCount + 1,
					"'}"
				});
            }
            else
            {
                result = "{success:'error'}";
            }
            return result;
        }
    }
}
