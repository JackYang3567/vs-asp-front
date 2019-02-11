using Game.Entity.Treasure;
using Game.Facade;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.UI;
namespace Game.Web.AppPay
{
	public partial class ProductList : System.Web.UI.Page
	{
		private TreasureFacade treasureFacade = new TreasureFacade();
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!base.IsPostBack)
			{
				base.Response.Write(this.PayApp());
				base.Response.End();
			}
		}
		private string PayApp()
		{
			System.Data.DataSet appList = this.treasureFacade.GetAppList();
			System.Collections.Generic.IList<GlobalAppInfo> obj = DataHelper.ConvertDataTableToObjects<GlobalAppInfo>(appList.Tables[0]);
			JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
			return javaScriptSerializer.Serialize(obj);
		}
	}
}
