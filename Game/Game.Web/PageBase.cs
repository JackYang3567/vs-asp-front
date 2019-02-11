using Game.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Game.Web
{
    public class PageBase: System.Web.UI.Page
    {
        private Logger _logger;

        public string WebDomain
        {
            get { return Common.GetAppSetting("WebDomain"); }
        }

        public Logger Logger
        {
            get
            {
                if (_logger == null)
                {
                    _logger = new Logger("File");
                }
                return _logger;
            }
        }

        public void ResponseToEnd(string @this)
        {
            Response.Clear();
            Response.Write(@this);
            Response.End();
        }
    }
     
}