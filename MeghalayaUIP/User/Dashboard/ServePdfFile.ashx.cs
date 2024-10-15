using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;
using MeghalayaUIP.BAL.CommonBAL;

namespace MeghalayaUIP.User.Dashboard
{

    public class ServePdfFile : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        MasterBAL objmbal = new MasterBAL();


        public void ProcessRequest(HttpContext context)
        {
            string userid = "";
            var ObjUserInfo = new UserInfo();
            ObjUserInfo = (UserInfo)context.Session["UserInfo"];
            var session = context.Session["UserInfo"];

            if (session != null && context.Request.QueryString.Count > 0)
            {

                string filePath = context.Request.QueryString["filePath"];
                filePath = objmbal.DecryptFilePath(filePath);
                string[] parts = filePath.Split('/');

                if (parts.Length > 4)
                {
                     userid = parts[3];                    
                }
                
                if (userid==ObjUserInfo.Userid)
                {
                    if (!string.IsNullOrEmpty(filePath))
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
                else
                {
                    context.Response.Redirect("~/Login.aspx");
                }
            }
            else
            {
                context.Response.Redirect("~/Login.aspx");
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