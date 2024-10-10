using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace MeghalayaUIP
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //HttpContext.Current.Response.Headers.Remove("X-AspNet-Version");
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

            Response.Headers.Remove("Server");
            Response.Headers.Remove("X-Aspnet-Version");
            HttpContext.Current.Response.AddHeader("X-Aspnet-Version", " ");

            string requestedUrl = Request.Url.ToString();
            if (requestedUrl.Contains("<") || requestedUrl.Contains(">"))
            {
                Response.Redirect("http://103.154.75.191/InvestMeghalaya/Home.aspx");
            }


            //string expectedHost = "http://103.154.75.191/"; // Replace with your valid host        
            //string actualHost = HttpContext.Current.Request.Headers["Host"];
            //if (!string.Equals(actualHost, expectedHost, StringComparison.OrdinalIgnoreCase))
            //if (!actualHost.Contains("103.154.75.191"))
            //{
            //    // Reject the request or return an error response
            //    Response.StatusCode = 400; // Bad Request
            //    Response.Write("Invalid Host Header");
            //    Response.End();
            //}
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }
        protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            //string requestHost = HttpContext.Current.Request.Headers["Host"];
            //if (!(requestHost.Contains("103.154.75.191")))
            //{
            //    // Log the unauthorized request or take other appropriate action (e.g., return an error response)
            //    Response.Headers.Remove("Server");
            //    Response.Headers.Remove("X-Aspnet-Version");
            //    HttpContext.Current.Response.StatusCode = 403; // Forbidden
            //    HttpContext.Current.Response.StatusDescription = "Invalid Host Header";
            //    HttpContext.Current.Response.End();
                
            //}


        }
        protected void Application_PreSendRequestHeaders(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Headers.Remove("Server");
            HttpContext.Current.Response.Headers.Remove("X-Powered-By");
            HttpContext.Current.Response.Headers.Remove("X-AspNet-Version");
            HttpContext.Current.Response.Headers.Remove("X-Server");
            HttpContext.Current.Response.Headers.Add("Server", "My Web Server");

            //string expectedHost = "103.154.75.191"; // Replace with your valid host
            //string actualHost = HttpContext.Current.Request.Headers["Host"];
            //Response.Headers.Remove("Server");

            //if (!(actualHost.Contains("103.154.75.191")))
            //{
            //    Response.Headers.Remove("Server");
            //    Response.StatusCode = 400; // Bad Request
            //    Response.Write("Invalid Host Header");
            //    Response.End();
            //}
           
            var app = sender as HttpApplication;
            if (app != null && app.Context != null)
            {
                app.Context.Response.Headers.Remove("Server");
            }

            string rawUrl = Request.RawUrl;
            if (rawUrl.Contains("<") || rawUrl.Contains(">"))
            {
                string encodedUrl = Server.UrlEncode(rawUrl);
                Response.Redirect(encodedUrl, true);
            }

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}