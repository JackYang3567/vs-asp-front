using Game.Entity.Accounts;
using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Text;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace Game.Web.UserService.JFT
{
    public partial class Main : UCPageBase
	{
		protected int rateGameBean = 1;
		protected string formData = string.Empty;
		protected string iconClass = string.Empty;
		protected string infoClass = string.Empty;
		protected string msg = string.Empty;
		protected string btClass = "fn-hide";
		protected string js = string.Empty;
		public string payType = string.Empty;
		public string payName = string.Empty;
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
		protected void Page_Load(object sender, System.EventArgs e)
		{
			SystemStatusInfo systemStatusInfo = FacadeManage.aideAccountsFacade.GetSystemStatusInfo(AppConfig.SystemConfigKey.RateCurrency.ToString());
			if (systemStatusInfo != null)
			{
				this.rateGameBean = systemStatusInfo.StatusValue;
			}
			this.payType = GameRequest.GetString("paytype").ToLower();
			string a;
			if ((a = this.payType) != null)
			{
				if (a == "alipay")
				{
					this.payName = "支付宝充值";
					goto IL_AF;
				}
				if (a == "wechat")
				{
					this.payName = "微信支付";
					goto IL_AF;
				}
				if (!(a == "bank"))
				{
				}
			}
			this.payName = "网上银行";
			IL_AF:
			if (!base.IsPostBack)
			{
				this.SwitchStep(1);
				if (Fetch.GetUserCookie() != null)
				{
					this.txtPayAccounts.Text = Fetch.GetUserCookie().Accounts;
					this.txtPayReAccounts.Text = Fetch.GetUserCookie().Accounts;
					this.txtPayAccounts.Focus();
				}
			}
		}
		protected override void AddHeaderTitle()
		{
			this.AddMetaTitle(this.payName + "充值 - " + ApplicationSettings.Get("title"));
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
						string prefix = string.Empty;
						string a;
						int shareID;
						string value;
						if ((a = this.payType) != null)
						{
							if (a == "alipay")
							{
								prefix = "JFTZFB";
								shareID = 14;
								value = "4";
								goto IL_121;
							}
							if (a == "wechat")
							{
								prefix = "JFTWX";
								shareID = 15;
								value = "3";
								goto IL_121;
							}
							if (!(a == "bank"))
							{
							}
						}
						prefix = "JFTBank";
						shareID = 13;
						value = "1";
						IL_121:
						OnLineOrder onLineOrder = new OnLineOrder();
						onLineOrder.ShareID = shareID;
						onLineOrder.OrderID = PayHelper.GetOrderIDByPrefix(prefix);
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
							string text3 = ApplicationSettings.Get("jftBankID");
							string text4 = ApplicationSettings.Get("jftBankKey");
							string text5 = "http://" + System.Web.HttpContext.Current.Request.Url.Authority + "/UserService/JFT/PublicReturn.aspx";
							string text6 = "http://" + System.Web.HttpContext.Current.Request.Url.Authority + "/UserService/JFT/PublicAdvice.aspx";
							string text7 = System.DateTime.Now.ToString("yyyyMMddHHmmss");
							string s = string.Format("{0}&{1}&{2}&{3}&{4}&{5}{6}", new object[]
							{
								text3,
								onLineOrder.OrderID,
								@int,
								text5,
								text6,
								text7,
								text4
							});
							string value2 = Utility.MD5(s).ToUpper();
							string value3 = "";
							string value4 = "";
							string value5 = "";
							string value6 = "";
							string value7 = "";
							string value8 = "";
							string value9 = "";
							string value10 = "";
							string value11 = "";
							string value12 = "";
							string value13 = "";
							string value14 = "";
							string value15 = "";
							string value16 = "2.0";
							string value17 = "";
							string value18 = "";
							this.pnlContinue.Visible = false;
							this.RenderAlertInfo(false, "页面正跳转到支付平台，请稍候。。。", 2);
							System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
							stringBuilder.AppendLine(this.CreateInputHidden("p1_usercode", text3));
							stringBuilder.AppendLine(this.CreateInputHidden("p2_order", onLineOrder.OrderID));
							stringBuilder.AppendLine(this.CreateInputHidden("p3_money", @int.ToString()));
							stringBuilder.AppendLine(this.CreateInputHidden("p4_returnurl", text5));
							stringBuilder.AppendLine(this.CreateInputHidden("p5_notifyurl", text6));
							stringBuilder.AppendLine(this.CreateInputHidden("p6_ordertime", text7));
							stringBuilder.AppendLine(this.CreateInputHidden("p7_sign", value2));
							stringBuilder.AppendLine(this.CreateInputHidden("p8_signtype", value3));
							stringBuilder.AppendLine(this.CreateInputHidden("p9_paymethod", value));
							stringBuilder.AppendLine(this.CreateInputHidden("p10_paychannelnum", value4));
							stringBuilder.AppendLine(this.CreateInputHidden("p11_cardtype", value5));
							stringBuilder.AppendLine(this.CreateInputHidden("p12_channel", value6));
							stringBuilder.AppendLine(this.CreateInputHidden("p13_orderfailertime", value7));
							stringBuilder.AppendLine(this.CreateInputHidden("p14_customname", value8));
							stringBuilder.AppendLine(this.CreateInputHidden("p15_customcontacttype", value9));
							stringBuilder.AppendLine(this.CreateInputHidden("p16_customcontact", value10));
							stringBuilder.AppendLine(this.CreateInputHidden("p17_customip", value11));
							stringBuilder.AppendLine(this.CreateInputHidden("p18_product", value12));
							stringBuilder.AppendLine(this.CreateInputHidden("p19_productcat", value13));
							stringBuilder.AppendLine(this.CreateInputHidden("p20_productnum", value14));
							stringBuilder.AppendLine(this.CreateInputHidden("p21_pdesc", value15));
							stringBuilder.AppendLine(this.CreateInputHidden("p22_version", value16));
							stringBuilder.AppendLine(this.CreateInputHidden("p23_charset", value17));
							stringBuilder.AppendLine(this.CreateInputHidden("p24_remark", value18));
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
