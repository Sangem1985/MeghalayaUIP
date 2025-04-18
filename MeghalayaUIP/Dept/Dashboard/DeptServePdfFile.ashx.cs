﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using MeghalayaUIP.BAL.CommonBAL;

namespace MeghalayaUIP.Dept.Dashboard
{
    /// <summary>
    /// Summary description for DeptServePdfFile
    /// </summary>
    public class DeptServePdfFile : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        MasterBAL objmbal = new MasterBAL();

        public void ProcessRequest(HttpContext context)
        {
            var session = context.Session["DeptUserInfo"];
            if (session != null && context.Request.QueryString.Count > 0)
            {

                string filePath = context.Request.QueryString["filePath"];
                // filePath = CleanBase64String(filePath);
                filePath = objmbal.DecryptFilePath(filePath);

                if (!string.IsNullOrEmpty(filePath))
                {
                    //string physicalPath = HttpContext.Current.Server.MapPath(filePath);
                    if (File.Exists(filePath))
                    // if (File.Exists(physicalPath))
                    {
                        context.Response.ContentType = "application/pdf";
                        context.Response.AppendHeader("Content-Disposition", "inline; filename=" + Path.GetFileName(filePath));
                        context.Response.TransmitFile(filePath);
                        context.Response.End();
                    }
                    else
                    {
                        //context.Response.Write("File not found.");
                        context.Response.Write(@"<div style='display: flex; justify-content: center; align-items: center; height: 100vh;'>
                                                     <span style='color: red; font-weight: bold;  font-size: 60px;'>File not found...!</span></div>");
                    }
                }
                else
                {
                    context.Response.Write(@"<div style='display: flex; justify-content: center; align-items: center; height: 100vh;'>
                                                     <span style='color: red; font-weight: bold;  font-size: 60px;'>No file path provided...!</span></div>");
                }
            }
            else
            {
                context.Response.Write(@"<div style='display: flex; justify-content: center; align-items: center; height: 100vh;'>
                                                     <span style='color: red; font-weight: bold;  font-size: 60px;'>No file path provided...!</span></div>");
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public string CleanBase64String(string base64String)
        {
            // Remove whitespace (spaces, newlines, etc.) that are not valid in a Base64 string
            return base64String.Replace(" ", "").Replace("\n", "").Replace("\r", "");
        }
    }

}