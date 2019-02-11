using Game.Kernel;
using Game.Utils;
using System;
using System.Text;
namespace Game.Facade
{
	public class InputDataValidate
	{
		public static Message CheckingUserNameFormat(string userName)
		{
			Message message = new Message();
			if (string.IsNullOrEmpty(userName))
			{
				message.Success = false;
				message.Content = "游戏账号不能为空";
				return message;
			}
			int num = System.Text.Encoding.Default.GetBytes(userName).Length;
			if (num > 32 || num < 6)
			{
				message.Success = false;
				message.Content = "游戏账号长度有误";
				return message;
			}
			if (!Validate.IsUserName(userName))
			{
				message.Content = "游戏账号只能有字母、数字、下划线、中文组成";
				return message;
			}
			return message;
		}
		public static Message CheckingNickNameFormat(string nickName)
		{
			Message message = new Message();
			if (string.IsNullOrEmpty(nickName))
			{
				message.Success = false;
				message.Content = "昵称不能为空";
				return message;
			}
			int num = System.Text.Encoding.Default.GetBytes(nickName).Length;
			if (num > 31 || num < 4)
			{
				message.Success = false;
				message.Content = "昵称长度有误";
				return message;
			}
			return message;
		}
		public static Message CheckingPasswordFormat(string password)
		{
			Message message = new Message();
			if (string.IsNullOrEmpty(password))
			{
				message.Success = false;
				message.Content = "密码不能为空";
				return message;
			}
			int length = password.Length;
			if (length > 32 || length < 6)
			{
				message.Success = false;
				message.Content = "密码长度有误";
				return message;
			}
			return message;
		}
		public static Message CheckingMobilePhoneNumFormat(string mobilePhoneNum, bool isAllowNull)
		{
			Message message = new Message();
			if (isAllowNull && string.IsNullOrEmpty(mobilePhoneNum))
			{
				return message;
			}
			if (!isAllowNull && string.IsNullOrEmpty(mobilePhoneNum))
			{
				message.Success = false;
				message.Content = "电话号码不能为空";
				return message;
			}
			if (!Validate.IsPhoneCode(mobilePhoneNum))
			{
				message.Success = false;
				message.Content = "移动电话格式不正确";
				return message;
			}
			return message;
		}
		public static Message CheckingRealNameFormat(string realName, bool isAllowNull)
		{
			Message message = new Message();
			if (isAllowNull && string.IsNullOrEmpty(realName))
			{
				return message;
			}
			if (!isAllowNull && string.IsNullOrEmpty(realName))
			{
				message.Success = false;
				message.Content = "真实姓名不能为空";
				return message;
			}
			if (realName.Length > 16)
			{
				message.Success = false;
				message.Content = "真实姓名太长";
				return message;
			}
			return message;
		}
		public static Message CheckingIDCardFormat(string IDCard, bool isAllowNull)
		{
			Message message = new Message();
			if (isAllowNull && string.IsNullOrEmpty(IDCard))
			{
				return message;
			}
			if (!Validate.IsIDCard(IDCard))
			{
				message.Success = false;
				message.Content = "身份证号码格式不正确";
				return message;
			}
			return message;
		}
		public static Message CheckingGameIDFormat(string gameID, bool isAllowNull)
		{
			Message message = new Message();
			if (isAllowNull && string.IsNullOrEmpty(gameID))
			{
				return message;
			}
			if (!Validate.IsNumeric(gameID))
			{
				message.Success = false;
				message.Content = "游戏ID格式不正确";
				return message;
			}
			return message;
		}
		public static Message ChenckingPayParam(string userName, string reUserName, int amount)
		{
			Message message = new Message();
			message = InputDataValidate.CheckingUserNameFormat(userName);
			if (!message.Success)
			{
				message.Content = "请输入正确的游戏账号";
				return message;
			}
			if (userName != reUserName)
			{
				message.Success = false;
				message.Content = "两次输入的账户不一致";
				return message;
			}
			if (amount == 0)
			{
				message.Success = false;
				message.Content = "请输入正确的充值金额";
				return message;
			}
			return message;
		}
		public static Message CheckingProtectAnswer(string answer, bool isAllowNull)
		{
			Message message = new Message();
			if (isAllowNull && string.IsNullOrEmpty(answer))
			{
				return message;
			}
			int num = 4;
			int num2 = 40;
			int num3 = System.Text.Encoding.Default.GetBytes(answer).Length;
			if (string.IsNullOrEmpty(answer))
			{
				message.Success = false;
				message.Content = "很抱歉！请输入密保答案";
				return message;
			}
			if (num3 > num2)
			{
				message.Success = false;
				message.Content = "很抱歉！密保答案长度太长";
				return message;
			}
			if (num3 < num)
			{
				message.Success = false;
				message.Content = "很抱歉！密保答案长度太短，至少是4个英文字符或者2个中文字";
				return message;
			}
			return message;
		}
		public static Message CheckingProtectAnswer(string answer, int number, bool isAllowNull)
		{
			Message message = new Message();
			if (isAllowNull && string.IsNullOrEmpty(answer))
			{
				return message;
			}
			int num = 4;
			int num2 = 40;
			int num3 = System.Text.Encoding.Default.GetBytes(answer).Length;
			if (string.IsNullOrEmpty(answer))
			{
				message.Success = false;
				message.Content = string.Format("很抱歉！请输入密保答案{0}", number);
				return message;
			}
			if (num3 > num2)
			{
				message.Success = false;
				message.Content = string.Format("很抱歉！密保答案{0}长度太长", number);
				return message;
			}
			if (num3 < num)
			{
				message.Success = false;
				message.Content = string.Format("很抱歉！密保答案{0}长度太短，至少是4个英文字符或者2个中文字", number);
				return message;
			}
			return message;
		}
		public static Message CheckingProtectQuestion(string question1, string question2, string question3)
		{
			Message message = new Message();
			if (question1 == "0")
			{
				message.Success = false;
				message.Content = "请选择密保问题1";
				return message;
			}
			if (question2 == "0")
			{
				message.Success = false;
				message.Content = "请选择密保问题2";
				return message;
			}
			if (question3 == "0")
			{
				message.Success = false;
				message.Content = "请选择密保问题3";
				return message;
			}
			if (question1.Equals(question2) || question1.Equals(question3) || question2.Equals(question3))
			{
				message.Success = false;
				message.Content = "很抱歉，密保问题不能相同";
				return message;
			}
			return message;
		}
		public static Message CheckingQQFormat(string qq, bool isAllowNull)
		{
			Message message = new Message();
			if (isAllowNull && string.IsNullOrEmpty(qq))
			{
				return message;
			}
			if (!isAllowNull && string.IsNullOrEmpty(qq))
			{
				message.Success = false;
				message.Content = "QQ号码不能为空";
				return message;
			}
			if (!string.IsNullOrEmpty(qq) && !Validate.IsNumeric(qq))
			{
				message.Success = false;
				message.Content = "QQ号码格式不对";
				return message;
			}
			if (qq.Length > 20)
			{
				message.Success = false;
				message.Content = "QQ号码太长";
				return message;
			}
			if (qq.Length < 4)
			{
				message.Success = false;
				message.Content = "QQ号码太短";
				return message;
			}
			return message;
		}
		public static Message CheckingEmail(string email)
		{
			Message message = new Message();
			if (string.IsNullOrEmpty(email))
			{
				message.Success = false;
				message.Content = "邮箱不能为空";
				return message;
			}
			if (email.Length > 128)
			{
				message.Success = false;
				message.Content = "邮箱太长";
				return message;
			}
			if (!Validate.IsEmail(email))
			{
				message.Success = false;
				message.Content = "邮箱格式不正确";
			}
			return message;
		}
		public static Message CheckingRemark(string remark, bool isAllowNull)
		{
			Message message = new Message();
			if (isAllowNull && string.IsNullOrEmpty(remark))
			{
				message.Success = true;
				return message;
			}
			if (!isAllowNull && string.IsNullOrEmpty(remark))
			{
				message.Success = false;
				message.Content = "请输入备注信息";
				return message;
			}
			if (remark.Length > 200)
			{
				message.Success = false;
				message.Content = "备注太长，备注最长不能超过" + 200 + "个字符";
				return message;
			}
			return message;
		}
		public static Message CheckingReportNo(string reportNo, bool isAllowNull)
		{
			Message message = new Message();
			if (isAllowNull && string.IsNullOrEmpty(reportNo))
			{
				message.Success = true;
				return message;
			}
			if (!isAllowNull && string.IsNullOrEmpty(reportNo))
			{
				message.Success = false;
				message.Content = "请输入申诉号";
				return message;
			}
			return message;
		}
	}
}
