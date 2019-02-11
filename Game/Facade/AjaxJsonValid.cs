using System;
namespace Game.Facade
{
	public class AjaxJsonValid : AjaxJson
	{
		public AjaxJsonValid()
		{
			base.AddDataItem("valid", false);
		}
		public AjaxJsonValid(bool result)
		{
			base.AddDataItem("valid", result);
		}
		public void SetValidDataValue(bool result)
		{
			base.SetDataItem("valid", result);
		}
	}
}
