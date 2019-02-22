using Game.Entity.Treasure;
using Game.Facade;
using Game.Kernel;
using Game.Utils;
using System;
using System.Reflection;
using System.Text.RegularExpressions;
//using Newtonsoft.Json;
using System.Data;
using System.Web;
using System.Web.SessionState;

using System.Text;

namespace Game.Web.ashx
{
    /// <summary>
    /// Summary description for PayQrCodeIcon
    /// </summary>
    public class PayQrCodeIcon : System.Web.IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            TreasureFacade treasureFacade = new TreasureFacade();
            DataTable offPayQrCodeList = treasureFacade.GetOffPayQrCodeInfo();
            string json = DataTableToJson(offPayQrCodeList);
            context.Response.Write(json);
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


        public static string DataTableToJson(DataTable dt)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{\"Name\":\"" + dt.TableName + "\",\"Rows");
            jsonBuilder.Append("\":[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Columns[j].ColumnName);
                    jsonBuilder.Append("\":\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString().Replace("\"", "\\\""));
                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]");
            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }
    }
}