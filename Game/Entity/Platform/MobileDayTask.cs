using System;
namespace Game.Entity.Platform
{
	public class MobileDayTask
	{
		private string _f1;
		private string _f2;
		private string _f3;
		private string _f4;
		private string _f5;
		private string _f6;
		public string Field1
		{
			get
			{
				return this._f1;
			}
			set
			{
				this._f1 = value;
			}
		}
		public string Field2
		{
			get
			{
				return this._f2;
			}
			set
			{
				this._f2 = value;
			}
		}
		public string Field3
		{
			get
			{
				return this._f3;
			}
			set
			{
				this._f3 = value;
			}
		}
		public string Field4
		{
			get
			{
				return this._f4;
			}
			set
			{
				this._f4 = value;
			}
		}
		public string Field5
		{
			get
			{
				return this._f5;
			}
			set
			{
				this._f5 = value;
			}
		}
		public string Field6
		{
			get
			{
				return this._f6;
			}
			set
			{
				this._f6 = value;
			}
		}
		public MobileDayTask(string p_f1, string p_f2, string p_f3, string p_f4, string p_f5, string p_f6)
		{
			this._f1 = p_f1;
			this._f2 = p_f2;
			this._f3 = p_f3;
			this._f4 = p_f4;
			this._f5 = p_f5;
			this._f6 = p_f6;
		}
	}
}
