using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MeghalayaUIP.BAL.CommonBAL;

namespace MeghalayaUIP
{
    public partial class Home : System.Web.UI.Page
    {
        MasterBAL objmgbal = new MasterBAL();
        protected string IncentivePackageDemo027082024 { get; set; }
        protected string unnati2024 { get; set; }
        protected string mipp2024 { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            IncentivePackageDemo027082024 = objmgbal.EncryptFilePath("D:/Meghalaya/Documents/Incentive Package Demo 027082024.pdf");
            unnati2024= objmgbal.EncryptFilePath("D:/Meghalaya/Documents/unnati2024.pdf");
            mipp2024 = objmgbal.EncryptFilePath("D:/Meghalaya/Documents/mipp2024.pdf");
            if (Session.Count != 0)
            {
                Session.Clear();
                Session.Abandon();
                Session.RemoveAll();

                if (!Page.IsPostBack)
                    Session.Abandon();
            }
        }
        public void Killsession()
        {

            if (Request.Cookies["ASP.NET_SessionId"] != null)
            {

                Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;

                Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);

            }
            if (Request.Cookies["ASP.NET_SessionIdTemp"] != null)
            {
                Response.Cookies["ASP.NET_SessionIdTemp"].Value = string.Empty;

                Response.Cookies["ASP.NET_SessionIdTemp"].Expires = DateTime.Now.AddMonths(-20);
            }

            if (Request.Cookies["AuthToken"] != null)
            {

                Response.Cookies["AuthToken"].Value = string.Empty;

                Response.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);

            }
            if (Request.Cookies["__AntiXsrfToken"] != null)
            {

                Response.Cookies["__AntiXsrfToken"].Value = string.Empty;

                Response.Cookies["__AntiXsrfToken"].Expires = DateTime.Now.AddMonths(-20);

            }
            Session.Abandon();
            Session.Clear();

            var manager = new System.Web.SessionState.SessionIDManager();
            string newSessionId = manager.CreateSessionID(HttpContext.Current);
            bool isRedirected = false;
            bool isAdded = false;
            manager.SaveSessionID(HttpContext.Current, newSessionId, out isRedirected, out isAdded);

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now);
            Response.Cache.SetNoStore();
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.Private);

            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.Cache.SetExpires(DateTime.Now);
            //Response.Cache.SetNoStore();
            //HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.Private);

        }
    }
}