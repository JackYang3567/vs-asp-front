using Game.Utils;
using System;
namespace Game.Facade
{
	public class AppConfig
	{
		public enum SiteConfigKey
		{
			ContactConfig,
			SiteConfig,
			GameFullPackageConfig,
			GameJanePackageConfig,
			GameAndroidConfig,
			GameIosConfig,
			GameWin32Config,
			MobilePlatformVersion,
			DayTaskConfig,
			ServerConfig
		}
		public enum SystemConfigKey
		{
			RateCurrency,
			RateGold,
			MedalExchangeRate,
			PresentExchangeRate,
			MobilePlatformVersion,
			PayConfig,
			SharePresent,
			WxLogon,
			OpenMobileWebsite,
			TransferStauts,
			IOSNotStorePaySwitch,
			AgentRoomCardExchRate,
			IsOpenRoomCard,
			TransferRebate
		}
		public enum AwardNeedInfoType
		{
			真实姓名 = 1,
			手机号码,
			QQ号码 = 4,
			收货地址及邮编 = 8
		}
		public enum AwardOrderStatus
		{
			处理中,
			已发货,
			已收货,
			申请退货,
			同意退货等待您发货,
			拒绝退货,
			退货成功且退款成功
		}
		public enum AdsGameType
		{
			大厅登录框广告位 = 1,
			大厅注册框广告位,
			大厅关闭框广告位,
			大厅右下角广告位,
			移动版网站广告位,
			游戏右上角广告位
		}
		public enum SinglePageKey
		{
			NewbieHelp,
			ServiceAgreement,
			AboutUs,
			ContactUs,
			Monitor,
			Dispute
		}
		public enum JFTPayCardType
		{
			骏网一卡通 = 101,
			盛大卡,
			神州行,
			征途卡,
			Q币卡,
			联通卡,
			久游卡,
			易宝e卡通,
			网易卡,
			完美卡,
			搜狐卡,
			电信卡,
			纵游一卡通,
			天下一卡通,
			天宏一卡通
		}
		public const string VerifyCodeKey = "VerifyCodeKey";
		public const string ImageSiteDomain = "RY_6603_Image_Domain";
		public const int userNameMinLength = 6;
		public const int userNameMaxLength = 32;
		public const int nickNameMinLength = 4;
		public const int nickNameMaxLength = 31;
		public const int passwordMinLength = 6;
		public const int passwordMaxLength = 32;
		public const int addressMaxLength = 128;
		public const int remarkMaxLength = 200;
		public const int professionMaxLength = 128;
		public const int underWriteMaxLength = 63;
		public const int realNameMaxLength = 16;
		public const int protectAnswerMinLength = 4;
		public const int protectAnswerMaxLength = 40;
		public const int qqMinLength = 4;
		public const int qqMaxLength = 20;
		public const string domainSuffixList = "com|cn|top|wang|net|org|hk|co|cc|me|pw|la|asia|biz|mobi|net|org|gov|name|info|hk|tm|tv|tel|us|website|host|press|tw|ren|中国|香港|公司|网络|商标|移动";
		public static string SyncLoginKey
		{
			get
			{
				string result;
				try
				{
					string text = ApplicationSettings.Get("SyncLoginKey");
					if (!string.IsNullOrEmpty(text))
					{
						result = text;
					}
					else
					{
						result = "RYSyncLoginKey";
					}
				}
				catch
				{
					result = "RYSyncLoginKey";
				}
				return result;
			}
		}
		public static int SyncUrlTimeOut
		{
			get
			{
				int result;
				try
				{
					string value = ApplicationSettings.Get("SyncUrlTimeOut");
					if (!string.IsNullOrEmpty(value))
					{
						result = System.Convert.ToInt32(value);
					}
					else
					{
						result = 30;
					}
				}
				catch
				{
					result = 30;
				}
				return result;
			}
		}
		public static string UserLoginCacheKey
		{
			get
			{
				string result;
				try
				{
					string text = ApplicationSettings.Get("UserLoginCacheKey");
					if (!string.IsNullOrEmpty(text))
					{
						result = text;
					}
					else
					{
						result = "RYLoginKey";
					}
				}
				catch
				{
					result = "RYLoginKey";
				}
				return result;
			}
		}
		public static int UserLoginTimeOut
		{
			get
			{
				int result;
				try
				{
					string value = ApplicationSettings.Get("UserLoginCacheTimeOut");
					if (!string.IsNullOrEmpty(value))
					{
						result = System.Convert.ToInt32(value);
					}
					else
					{
						result = 30;
					}
				}
				catch
				{
					result = 30;
				}
				return result;
			}
		}
		public static string UserLoginCacheEncryptKey
		{
			get
			{
				string result;
				try
				{
					string text = ApplicationSettings.Get("UserLoginCacheEncryptKey");
					if (!string.IsNullOrEmpty(text))
					{
						result = text;
					}
					else
					{
						result = "BSmxlKXoRrfUoT0CjNCS";
					}
				}
				catch
				{
					result = "BSmxlKXoRrfUoT0CjNCS";
				}
				return result;
			}
		}
		public static string ReportForgetPasswordKey
		{
			get
			{
				string result;
				try
				{
					string text = ApplicationSettings.Get("ReportForgetPasswordKey");
					if (!string.IsNullOrEmpty(text))
					{
						result = text;
					}
					else
					{
						result = "ReportForgetPasswordKeyValue";
					}
				}
				catch
				{
					result = "ReportForgetPasswordKeyValue";
				}
				return result;
			}
		}
		public static byte IsShowMoblieDownload
		{
			get
			{
				byte result;
				try
				{
					string value = ApplicationSettings.Get("IsShowMoblieDownload");
					if (!string.IsNullOrEmpty(value))
					{
						result = System.Convert.ToByte(value);
					}
					else
					{
						result = 0;
					}
				}
				catch
				{
					result = 0;
				}
				return result;
			}
		}
	}
}
