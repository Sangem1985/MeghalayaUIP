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

            string expectedHost = "http://103.154.75.191"; // Replace with your valid host
            //string expectedHost = "localhost";
            string actualHost = HttpContext.Current.Request.Headers["Host"];

            //if (!string.Equals(actualHost, expectedHost, StringComparison.OrdinalIgnoreCase))
            if (!(actualHost.Contains("http://103.154.75.191")))//http://218.185.250.36/IndustriesTest
                //if (!(actualHost.Contains("localhost")))//http://218.185.250.36/IndustriesTest
                {
                // Reject the request or return an error response
                Response.Headers.Remove("Server");
                //Response.StatusCode = 400; // Bad Request
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
            if (rawUrl.Contains("<") || rawUrl.Contains(">"))
            {
                //string encodedUrl = Server.UrlEncode(rawUrl);          
                Response.Redirect("http://103.154.75.191/InvestMeghalaya/Home.aspx", true);
            }

            
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }
        protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            // Define the expected Host header value
            //string expectedHost = "http://218.185.250.36"; // Replace with your expected Host header

            // Get the incoming Host header from the request
            string requestHost = HttpContext.Current.Request.Headers["Host"];

            // Check if the Host header matches the expected value
            //if (!string.Equals(requestHost, expectedHost, StringComparison.OrdinalIgnoreCase))
            if (!(requestHost.Contains("103.154.75.191")))
            //    if (!(requestHost.Contains("localhost")))
                {
                // Log the unauthorized request or take other appropriate action (e.g., return an error response)
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

            //string expectedHost = "http://103.154.75.191"; // Replace with your valid host
            string expectedHost = "http://103.154.75.191"; // Replace with your valid host
            string actualHost = HttpContext.Current.Request.Headers["Host"];
            Response.Headers.Remove("Server");

            if (!(actualHost.Contains("http://103.154.75.191")))
            //    if (!(actualHost.Contains("localhost")))
                {
                Response.Headers.Remove("Server");
                Response.StatusCode = 400; // Bad Request
                Response.Write("Invalid Host Header");
                Response.End();
            }
            HttpContext context = HttpContext.Current;
            if (context.Request.Url.OriginalString.ToLower().Contains("<") || context.Request.Url.OriginalString.ToLower().Contains(">")) 
            { Response.Redirect("http://103.154.75.191/InvestMeghalaya/Home.aspx"); }

             
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
            if (rawUrl.Contains("<") || rawUrl.Contains(">"))
            {
                //string encodedUrl = Server.UrlEncode(rawUrl);
                //Response.Redirect(encodedUrl, true);
                Response.Redirect("http://103.154.75.191/InvestMeghalaya/Home.aspx", true);
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