﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Game.Web.ashx
{
    /// <summary>
    /// Shop 的摘要说明
    /// </summary>
    public class Shop : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}