using System;
namespace Game.Entity.Accounts
{
	public class ApplyOrder
	{
		public string OrderID
		{
			get;
			set;
		}
		public double SellMoney
		{
			get;
			set;
		}
		public string RejectReason
		{
			get;
			set;
		}
		public int Status
		{
			get;
			set;
		}
		public DateTime ApplyDate
		{
			get;
			set;
		}
	}
}
