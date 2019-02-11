using System;
namespace Game.Web.Pay.WX
{
	public class WxPayException : System.Exception
	{
		public WxPayException(string msg) : base(msg)
		{
		}
	}
}
