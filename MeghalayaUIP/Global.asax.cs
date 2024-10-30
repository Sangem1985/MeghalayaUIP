using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace MeghalayaUIP
{
    public class Global : System.Web.HttpApplication
    {
        string expectedHost = Convert.ToString(ConfigurationManager.AppSettings["expectedHost"]);
        string expectedHostPath = Convert.ToString(ConfigurationManager.AppSettings["expectedHostPath"]);
        string Redirectionurl = Convert.ToString(ConfigurationManager.AppSettings["Redirectionurl"]);
        protected void Application_Start(object sender, EventArgs e)
        {
            PreSendRequestHeaders += Application_PreSendRequestHeaders;
            // Code that runs on application startup 
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string requesturl = Request.Url.PathAndQuery;

            string santzurl = requesturl.Replace("<", "[").Replace(">", "]");
            if (!string.Equals(requesturl, santzurl, StringComparison.OrdinalIgnoreCase))
            {
                Response.RedirectPermanent(santzurl);
            }
            string actualHost = HttpContext.Current.Request.Headers["Host"];

            if (!string.Equals(actualHost, expectedHost, StringComparison.OrdinalIgnoreCase))
            //if (!(actualHost.Contains(expectedHost))) 
            {
                Response.Headers.Remove("Server");
                Response.StatusCode = 400; // Bad Request
                Response.Write("Invalid Host Header");
                Response.End();
            }
            if (Request.Headers["Cookie"] != null)
            {
                // Get the cookies from the request
                var cookies = Request.Headers["Cookie"];
                // Check if the SameSite attribute is already set in the cookies
                if (!cookies.Contains("SameSite="))
                {
                    // Set the SameSite attribute for the cookies
                    Response.AddHeader("Set-Cookie", "{cookies}; SameSite=Lax");
                }
            }
            Response.Headers.Remove("Server");
            //HttpContext.Current.Response.AddHeader("X-Frame-Options", "DENY");

            string rawUrl = Request.RawUrl;
            if (rawUrl.Contains("<") || rawUrl.Contains(">") || !Request.Url.ToString().Contains(expectedHostPath))
            {
                //Response.Redirect("http://103.154.75.191/InvestMeghalaya/Home.aspx", true);
                Response.Redirect(Redirectionurl, true);
            }

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }
        protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            string actualHost = HttpContext.Current.Request.Headers["Host"];

            //if (!(requestHost.Contains(expectedHost)))
            if (!string.Equals(actualHost, expectedHost, StringComparison.OrdinalIgnoreCase))
            {
                Response.Headers.Remove("Server");
                HttpContext.Current.Response.StatusCode = 403; // Forbidden
                HttpContext.Current.Response.StatusDescription = "Invalid Host Header";
                HttpContext.Current.Response.End();
                Response.Headers.Remove("Server");
            }
            string rawUrl = Request.RawUrl;
            if (rawUrl.Contains("<") || rawUrl.Contains(">"))
            {
                string encodedUrl = Server.UrlEncode(rawUrl);
                Response.Redirect(encodedUrl, true);
            }


        }
        protected void Application_PreSendRequestHeaders(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Headers.Remove("Server");
            HttpContext.Current.Response.Headers.Remove("X-Powered-By");
            HttpContext.Current.Response.Headers.Remove("X-AspNet-Version");
            HttpContext.Current.Response.Headers.Remove("X-Server");
            HttpContext.Current.Response.Headers.Add("Server", "My Web Server");

            string actualHost = HttpContext.Current.Request.Headers["Host"];
            Response.Headers.Remove("Server");

            //if (!(actualHost.Contains(expectedHost)))
            if (!string.Equals(actualHost, expectedHost, StringComparison.OrdinalIgnoreCase))
            {
                Response.Headers.Remove("Server");
                Response.StatusCode = 400; // Bad Request
                Response.Write("Invalid Host Header");
                Response.End();
            }
            HttpContext context = HttpContext.Current;
            if (context.Request.Url.OriginalString.ToLower().Contains("<") || context.Request.Url.OriginalString.ToLower().Contains(">"))
            {
                //    Response.Redirect("http://103.154.75.191/InvestMeghalaya/Home.aspx"); 
                Response.Redirect(Redirectionurl);
            }


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
            string rawUrl = Request.RawUrl;
            if (rawUrl.Contains("<") || rawUrl.Contains(">") || !Request.Url.ToString().Contains(expectedHostPath))
            {
                //Response.Redirect("http://103.154.75.191/InvestMeghalaya/Home.aspx", true);
                Response.Redirect(Redirectionurl, true);
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}