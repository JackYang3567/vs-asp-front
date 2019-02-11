using Game.Entity.Accounts;
using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using Game.Web.Themes.Standard;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace Game.Web.Pay.WX
{
    public partial class Wxpay : UCPageBase
	{
		protected int rateGameBean = 1;
		protected string formData = string.Empty;
		protected string iconClass = string.Empty;
		protected string infoClass = string.Empty;
		protected string msg = string.Empty;
		protected string btClass = "fn-hide";
		protected string js = string.Empty;
		protected Common_Header sHeader;
		protected Pay_Sidebar sPaySidebar;
		protected System.Web.UI.HtmlControls.HtmlForm fmStep1;
		protected System.Web.UI.WebControls.TextBox txtPayAccounts;
		protected System.Web.UI.WebControls.TextBox txtPayReAccounts;
		protected System.Web.UI.WebControls.TextBox txtPayAmount;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hdfSalePrice;
		protected System.Web.UI.WebControls.Button btnPay;
		protected System.Web.UI.HtmlControls.HtmlForm fmStep2;
		protected System.Web.UI.WebControls.Label lblAlertIcon;
		protected System.Web.UI.WebControls.Label lblAlertInfo;
		protected System.Web.UI.HtmlControls.HtmlGenericControl pnlContinue;
		protected Common_Footer sFooter;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			SystemStatusInfo systemStatusInfo = FacadeManage.aideAccountsFacade.GetSystemStatusInfo(AppConfig.SystemConfigKey.RateCurrency.ToString());
			if (systemStatusInfo != null)
			{
				this.rateGameBean = systemStatusInfo.StatusValue;
			}
			if (!base.IsPostBack)
			{
				this.SwitchStep(1);
				if (Fetch.GetUserCookie() != null)
				{
					this.txtPayAccounts.Text = Fetch.GetUserCookie().Accounts;
					this.txtPayReAccounts.Text = Fetch.GetUserCookie().Accounts;
				}
			}
		}
		protected override void AddHeaderTitle()
		{
			this.AddMetaTitle("微信充值 - " + ApplicationSettings.Get("title"));
			this.AddMetaKeywords(ApplicationSettings.Get("keywords"));
			this.AddMetaDescription(ApplicationSettings.Get("description"));
		}
		public void btnPay_Click(object sender, System.EventArgs e)
		{
			string text = CtrlHelper.GetText(this.txtPayAccounts);
			string text2 = CtrlHelper.GetText(this.txtPayReAccounts);
			int @int = CtrlHelper.GetInt(this.txtPayAmount, 0);
			if (text == "")
			{
				this.RenderAlertInfo(true, "抱歉，请输入充值帐号。", 2);
			}
			else
			{
				if (text2 != text)
				{
					this.RenderAlertInfo(true, "抱歉，两次输入的帐号不一致。", 2);
				}
				else
				{
					if (@int <= 0)
					{
						this.RenderAlertInfo(true, "请输入正确的充值金额", 2);
					}
					else
					{
						string orderIDByPrefix = PayHelper.GetOrderIDByPrefix("WX");
						OnLineOrder onLineOrder = new OnLineOrder();
						onLineOrder.ShareID = 401;
						onLineOrder.OrderID = orderIDByPrefix;
						if (Fetch.GetUserCookie() == null)
						{
							onLineOrder.OperUserID = 0;
						}
						else
						{
							onLineOrder.OperUserID = Fetch.GetUserCookie().UserID;
						}
						onLineOrder.Accounts = text;
						onLineOrder.OrderAmount = @int;
						onLineOrder.IPAddress = GameRequest.GetUserIP();
						Message message = FacadeManage.aideTreasureFacade.RequestOrder(onLineOrder);
						if (!message.Success)
						{
							this.RenderAlertInfo(true, message.Content, 2);
						}
						else
						{
							string nonce_str = WeiXinHelper.GetNonce_str();
							string value = "充值游戏豆";
							string value2 = orderIDByPrefix;
							int num = System.Convert.ToInt32(@int * 100);
							string userIP = Utility.UserIP;
							string value3 = "http://" + base.Request.Url.Authority + "/Pay/WX/WxpayNotify.aspx";
							string value4 = orderIDByPrefix.Substring(2, orderIDByPrefix.Length - 2);
							SortedDictionary<string, object> sortedDictionary = new SortedDictionary<string, object>();
							sortedDictionary.Add("nonce_str", nonce_str);
							sortedDictionary.Add("body", value);
							sortedDictionary.Add("trade_type", "NATIVE");
							sortedDictionary.Add("out_trade_no", value2);
							sortedDictionary.Add("total_fee", num);
							sortedDictionary.Add("spbill_create_ip", userIP);
							sortedDictionary.Add("notify_url", value3);
							sortedDictionary.Add("product_id", value4);
							this.pnlContinue.Visible = false;
							this.RenderAlertInfo(false, "页面正跳转到支付平台，请稍候。。。", 2);
							SortedDictionary<string, object> sortedDictionary2 = WeiXinHelper.UnifiedOrder(sortedDictionary, 10);
							string text3 = sortedDictionary2["return_code"].ToString();
							System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
							stringBuilder.AppendLine(this.CreateInputHidden("return_code", text3));
							stringBuilder.AppendLine(this.CreateInputHidden("return_msg", sortedDictionary2["return_msg"].ToString()));
							if (text3 == "SUCCESS")
							{
								stringBuilder.AppendLine(this.CreateInputHidden("code_url", sortedDictionary2["code_url"].ToString()));
								stringBuilder.AppendLine(this.CreateInputHidden("orderID", orderIDByPrefix));
								stringBuilder.AppendLine(this.CreateInputHidden("amount", @int.ToString()));
							}
							this.formData = stringBuilder.ToString();
							this.js = "<script>window.onload = function() { document.forms[0].submit(); }</script>";
						}
					}
				}
			}
		}
		private string AppendParam(string returnStr, string paramId, string paramValue)
		{
			if (returnStr != "")
			{
				if (paramValue != "")
				{
					string text = returnStr;
					returnStr = string.Concat(new string[]
					{
						text,
						"&",
						paramId,
						"=",
						paramValue
					});
				}
			}
			else
			{
				if (paramValue != "")
				{
					returnStr = paramId + "=" + paramValue;
				}
			}
			return returnStr;
		}
		private string CreateInputHidden(string idName, string value)
		{
			return string.Format("<input type=\"hidden\" id=\"{0}\" value=\"{1}\" name=\"{0}\" />", idName, value);
		}
	}
}
