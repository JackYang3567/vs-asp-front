using Game.Entity.Accounts;
using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace Game.Web.UserService.JFT
{
    public partial  class Card : UCPageBase
	{
		protected int rateGameBean = 1;
		protected string formData = string.Empty;
		protected string iconClass = string.Empty;
		protected string infoClass = string.Empty;
		protected string msg = string.Empty;
		protected string btClass = "fn-hide";
		protected string js = string.Empty;
		protected string cardName = string.Empty;
		public int cardType = 101;
		protected string strFaceValueOption = string.Empty;
		protected System.Web.UI.HtmlControls.HtmlForm fmStep1;
		protected System.Web.UI.WebControls.TextBox txtPayAccounts;
		protected System.Web.UI.WebControls.TextBox txtPayReAccounts;
		protected System.Web.UI.WebControls.DropDownList ddlAmount;
		protected System.Web.UI.WebControls.TextBox txtCardNumber;
		protected System.Web.UI.WebControls.TextBox txtCardPassword;
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
			this.cardType = GameRequest.GetQueryInt("type", 101);
			if (this.cardType > 115 || this.cardType < 101)
			{
				this.cardType = 101;
			}
			this.cardName = System.Enum.GetName(typeof(AppConfig.JFTPayCardType), this.cardType);
			if (!base.IsPostBack)
			{
				this.SwitchStep(1);
				if (Fetch.GetUserCookie() != null)
				{
					this.txtPayAccounts.Text = Fetch.GetUserCookie().Accounts;
					this.txtPayReAccounts.Text = Fetch.GetUserCookie().Accounts;
				}
				string[] array = new System.Collections.Generic.Dictionary<int, string>
				{

					{
						System.Convert.ToInt32(AppConfig.JFTPayCardType.骏网一卡通),
						"5,6,10,15,20,30,50,100,120,200,300,500,1000"
					},

					{
						System.Convert.ToInt32(AppConfig.JFTPayCardType.盛大卡),
						"1,2,3,5,9,10,15,25,30,35,45,50,100,300,350,1000"
					},

					{
						System.Convert.ToInt32(AppConfig.JFTPayCardType.神州行),
						"10,20,30,50,100"
					},

					{
						System.Convert.ToInt32(AppConfig.JFTPayCardType.征途卡),
						"10,15,20,25,30,50,60,100,300,468,500,1000"
					},

					{
						System.Convert.ToInt32(AppConfig.JFTPayCardType.Q币卡),
						"5,10,15,30,60,100"
					},

					{
						System.Convert.ToInt32(AppConfig.JFTPayCardType.联通卡),
						"10,20,30,50,100"
					},

					{
						System.Convert.ToInt32(AppConfig.JFTPayCardType.久游卡),
						"5,10,20,25,30,50,100"
					},

					{
						System.Convert.ToInt32(AppConfig.JFTPayCardType.易宝e卡通),
						"1,2,3,5,9,10,15,25,30,35,45,50,100,300,350,1000"
					},

					{
						System.Convert.ToInt32(AppConfig.JFTPayCardType.网易卡),
						"5,10,15,20,30,50"
					},

					{
						System.Convert.ToInt32(AppConfig.JFTPayCardType.完美卡),
						"15,30,50,100"
					},

					{
						System.Convert.ToInt32(AppConfig.JFTPayCardType.搜狐卡),
						"5,10,15,30,40,100"
					},

					{
						System.Convert.ToInt32(AppConfig.JFTPayCardType.电信卡),
						"10,20,30,50,100,300"
					},

					{
						System.Convert.ToInt32(AppConfig.JFTPayCardType.纵游一卡通),
						"10,15,30,50,100"
					},

					{
						System.Convert.ToInt32(AppConfig.JFTPayCardType.天下一卡通),
						"5,6,10,15,30,50,100"
					},

					{
						System.Convert.ToInt32(AppConfig.JFTPayCardType.天宏一卡通),
						"5,10,15,30,50,100"
					}
				}[this.cardType].Split(new char[]
				{
					','
				});
				this.ddlAmount.Items.Clear();
				this.ddlAmount.Items.Add(new System.Web.UI.WebControls.ListItem("---请选择卡面值---", "0"));
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					string text = array2[i];
					this.ddlAmount.Items.Add(new System.Web.UI.WebControls.ListItem(text, text));
				}
			}
		}
		protected override void AddHeaderTitle()
		{
			this.AddMetaTitle("充值卡充值 - " + ApplicationSettings.Get("title"));
			this.AddMetaKeywords(ApplicationSettings.Get("keywords"));
			this.AddMetaDescription(ApplicationSettings.Get("description"));
		}
		public void btnPay_Click(object sender, System.EventArgs e)
		{
			string text = CtrlHelper.GetText(this.txtPayAccounts);
			string text2 = CtrlHelper.GetText(this.txtPayReAccounts);
			string text3 = CtrlHelper.GetText(this.txtCardNumber);
			string text4 = CtrlHelper.GetText(this.txtCardPassword);
			int num = System.Convert.ToInt32(this.ddlAmount.SelectedValue);
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
					if (num == 0)
					{
						this.RenderAlertInfo(true, "请选择卡面值。", 2);
					}
					else
					{
						if (string.IsNullOrEmpty(text3))
						{
							this.RenderAlertInfo(true, "抱歉，请输入卡号。", 2);
						}
						else
						{
							if (string.IsNullOrEmpty(text4))
							{
								this.RenderAlertInfo(true, "抱歉，请输入卡密码。", 2);
							}
							else
							{
								OnLineOrder onLineOrder = new OnLineOrder();
								onLineOrder.ShareID = this.cardType;
								onLineOrder.OrderID = PayHelper.GetOrderIDByPrefix("JFTCard");
								if (Fetch.GetUserCookie() == null)
								{
									onLineOrder.OperUserID = 0;
								}
								else
								{
									onLineOrder.OperUserID = Fetch.GetUserCookie().UserID;
								}
								onLineOrder.Accounts = text;
								onLineOrder.OrderAmount = num;
								onLineOrder.IPAddress = GameRequest.GetUserIP();
								Message message = FacadeManage.aideTreasureFacade.RequestOrder(onLineOrder);
								if (!message.Success)
								{
									this.RenderAlertInfo(true, message.Content, 2);
								}
								else
								{
									string text5 = ApplicationSettings.Get("jftBankID");
									string text6 = ApplicationSettings.Get("jftBankKey");
									string text7 = "http://" + System.Web.HttpContext.Current.Request.Url.Authority + "/UserService/JFT/CardReturn.aspx";
									string text8 = "http://" + System.Web.HttpContext.Current.Request.Url.Authority + "/UserService/JFT/PublicAdvice.aspx";
									string text9 = System.DateTime.Now.ToString("yyyyMMddHHmmss");
									string s = string.Format("{0}&{1}&{2}&{3}&{4}&{5}{6}", new object[]
									{
										text5,
										onLineOrder.OrderID,
										num,
										text7,
										text8,
										text9,
										text6
									});
									string value = Utility.MD5(s).ToUpper();
									string value2 = "";
									string value3 = "5";
									string fieldText = EnumDescription.GetFieldText(typeof(AppConfig.JFTPayCardType), this.cardType);
									string value4 = "";
									string value5 = "";
									string value6 = "";
									string value7 = "";
									string value8 = "";
									string value9 = "";
									string value10 = "";
									string value11 = "";
									string value12 = text4;
									string value13 = text3;
									string value14 = "";
									string value15 = "2.0";
									string value16 = "";
									string value17 = "";
									this.RenderAlertInfo(false, "页面正跳转到支付平台，请稍候。。。", 2);
									System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
									stringBuilder.AppendLine(this.CreateInputHidden("p1_usercode", text5));
									stringBuilder.AppendLine(this.CreateInputHidden("p2_order", onLineOrder.OrderID));
									stringBuilder.AppendLine(this.CreateInputHidden("p3_money", num.ToString()));
									stringBuilder.AppendLine(this.CreateInputHidden("p4_returnurl", text7));
									stringBuilder.AppendLine(this.CreateInputHidden("p5_notifyurl", text8));
									stringBuilder.AppendLine(this.CreateInputHidden("p6_ordertime", text9));
									stringBuilder.AppendLine(this.CreateInputHidden("p7_sign", value));
									stringBuilder.AppendLine(this.CreateInputHidden("p8_signtype", value2));
									stringBuilder.AppendLine(this.CreateInputHidden("p9_paymethod", value3));
									stringBuilder.AppendLine(this.CreateInputHidden("p10_paychannelnum", fieldText));
									stringBuilder.AppendLine(this.CreateInputHidden("p11_cardtype", value4));
									stringBuilder.AppendLine(this.CreateInputHidden("p12_channel", value5));
									stringBuilder.AppendLine(this.CreateInputHidden("p13_orderfailertime", value6));
									stringBuilder.AppendLine(this.CreateInputHidden("p14_customname", value7));
									stringBuilder.AppendLine(this.CreateInputHidden("p15_customcontacttype", value8));
									stringBuilder.AppendLine(this.CreateInputHidden("p16_customcontact", value9));
									stringBuilder.AppendLine(this.CreateInputHidden("p17_customip", value10));
									stringBuilder.AppendLine(this.CreateInputHidden("p18_product", value11));
									stringBuilder.AppendLine(this.CreateInputHidden("p19_productcat", value12));
									stringBuilder.AppendLine(this.CreateInputHidden("p20_productnum", value13));
									stringBuilder.AppendLine(this.CreateInputHidden("p21_pdesc", value14));
									stringBuilder.AppendLine(this.CreateInputHidden("p22_version", value15));
									stringBuilder.AppendLine(this.CreateInputHidden("p23_charset", value16));
									stringBuilder.AppendLine(this.CreateInputHidden("p24_remark", value17));
									this.formData = stringBuilder.ToString();
									this.js = "<script>window.onload = function() { document.forms[0].submit(); }</script>";
								}
							}
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
