using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using MeghalayaUIP.BAL.CommonBAL;
namespace MeghalayaUIP
{
    /// <summary>
    /// Summary description for PdfFile
    /// </summary>
    public class PdfFile : IHttpHandler
    {
        MasterBAL objmbal = new MasterBAL();
        public void ProcessRequest(HttpContext context)
        {

            string filePath = context.Request.QueryString["filePath"];
            filePath = objmbal.DecryptFilePath(filePath);
            if (!string.IsNullOrEmpty(filePath) &&
                !(filePath.Contains("PreRegAttachments") || filePath.Contains("CFEAttachments")
                  || filePath.Contains("CFOAttachments") || filePath.Contains("RENAttachments")
                   || filePath.Contains("GrievanceAttachments") || filePath.Contains("HelpDeskAttachments")))
            {
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