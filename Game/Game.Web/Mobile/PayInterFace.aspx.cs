using Game.Facade;
using Game.Utils;

namespace Game.Web.Mobile
{
    public partial class PayInterFace : System.Web.UI.Page
    {
        protected System.Web.UI.HtmlControls.HtmlForm form1;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            string @string = GameRequest.GetString("account");
            var @int = GameRequest.GetFloat("amount", 0);
            int num = GameRequest.GetInt("qudaoId", 0);
            if (@int <= 0 || num <= 0 || @string == "")
            {
                base.Response.Write("参数错误");
                base.Response.End();
            }
            string text = ApplicationSettings.Get("pay_url");
            if (text == "")
            {
                text = "http://" + base.Request.Url.Host;
            }
            System.Data.DataTable payInfo = FacadeManage.aideTreasureFacade.GetPayInfo(num);
            System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
            dictionary["account"] = @string;
            dictionary["amount"] = @int.ToString();
            if (payInfo.Rows.Count > 0)
            {
                dictionary["type"] = payInfo.Rows[0]["QudaoCode"].ToString();
                dictionary["qudaoId"] = payInfo.Rows[0]["qudaoId"].ToString();
                base.Response.Write(PayHelper.BuildForm(dictionary, string.Concat(new object[]
				{
					text,
					"/pay/",
					payInfo.Rows[0]["PlatformCode"],
					"/send.aspx"
				})));
                base.Response.End();
            }
            else
            {
                if (num == 9)
                {
                    num = 13;
                    payInfo = FacadeManage.aideTreasureFacade.GetPayInfo(num);
                    if (payInfo.Rows.Count > 0)
                    {
                        dictionary["type"] = payInfo.Rows[0]["QudaoCode"].ToString();
                        base.Response.Write(PayHelper.BuildForm(dictionary, string.Concat(new object[]
						{
							text,
							"/pay/",
							payInfo.Rows[0]["PlatformCode"],
							"/send.aspx"
						})));
                        base.Response.End();
                    }
                    else
                    {
                        base.Response.Write("该通道维护中1");
                        base.Response.End();
                    }
                }
                base.Response.Write("该通道维护中2");
                base.Response.End();
            }
        }
    }
}