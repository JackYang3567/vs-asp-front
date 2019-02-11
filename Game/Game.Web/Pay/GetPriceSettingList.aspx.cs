using Game.Facade;
using Game.Utils.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Game.Web.Pay
{
    public partial class GetPriceSettingList : System.Web.UI.Page
    {
        protected internal PlatformFacade aidePlatformFacade = new PlatformFacade();
        protected void Page_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            try
            {
                string pricetype = Request["pricetype"].ToString();
                string sql = "select cast(Price as float) Price,cast(Amount as int)  Amount,cast(GiveAmount as int)  GiveAmount,pricetype,id from  PriceSetting where (pricetype = " + pricetype + " or 0= " + pricetype + ") order by Price";
                dt = aidePlatformFacade.GetDataSetBySql(sql);
            }
            catch (Exception ex)
            {

            }
            Response.Clear();
            Response.Write(Serializer.SerializeToJson(dt));
            Response.End();
        }
    }
}