using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MeghalayaUIP.User.Dashboard
{
    
    public class ServePdfFile : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string filePath = context.Request.QueryString["filePath"];
            if (!string.IsNullOrEmpty(filePath))
            {
               // string physicalPath = HttpContext.Current.Server.MapPath(filePath);
                if (File.Exists(filePath))
                {
                    context.Response.ContentType = "application/pdf";
                    context.Response.AppendHeader("Content-Disposition", "inline; filename=" + Path.GetFileName(filePath));
                    context.Response.TransmitFile(filePath);
                    context.Response.End();
                }
                else
                {
                    context.Response.Write("File not found.");
                }
            }
            else
            {
                context.Response.Write("No file path provided.");
            }
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