using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using MeghalayaUIP.Common;
using System.Globalization;

namespace MeghalayaUIP.User
{
    public partial class User : System.Web.UI.MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        //private string _antiXsrfTokenValue;
        protected string strSessionexp = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            aLogout.ServerClick += new EventHandler(fnSetNewControls_Click);
            aLogout.HRef = "";

            if (Session["UserInfo"] == null)
            {
                fnSetNewControls_Click(this, EventArgs.Empty);
            }
            var ObjUserInfo = new UserInfo();
            if (Session["UserInfo"] != null)
            {
                if (Session["UserInfo"] != null && Session["UserInfo"].ToString() != "")
                {
                    ObjUserInfo = (UserInfo)Session["UserInfo"];
                }
            }
            if (!IsPostBack)
            {
                string guid = Guid.NewGuid().ToString("N");
                Session[AntiXsrfTokenKey] = guid;
                hdnUToken.Value = guid;
                if (Session["UserInfo"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
                {
                    if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
                    {
                        Killsession();
                    }
                    else
                    {
                        strSessionexp = (Session.Timeout * 60 * 1000).ToString();
                        Page.Header.DataBind();
                    }
                }
                else
                {
                    //  lblMessage.Text = "You are not logged in.";
                    // lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                if (Session[AntiXsrfTokenKey] != null && hdnUToken != null)
                {

                    if (!Session[AntiXsrfTokenKey].ToString().Equals(hdnUToken.Value))
                    {
                        //fnSetNewControls_Click(sender, e);
                        //throw new InvalidOperationException("Validation of  Anti-XSRF token failed.");
                    }
                }
            }

            //CheckMultiUsers(ObjLoginvo.uid);
            if (Session["UserInfo"] == null)
            {
                fnSetNewControls_Click(sender, e);
            }

            lblUser.Text = ObjUserInfo.Fullname;
            DateTime now = DateTime.Now;
            string timestamp = now.ToString("dd MMMM yyyy, hh:mm tt", CultureInfo.InvariantCulture);//("yyyy-MM-dd hh:mm:ss tt");
            lbltime.InnerText = timestamp;
            lblusername.InnerText= ObjUserInfo.Email;
        }

        protected void fnSetNewControls_Click(object sender, EventArgs e)
        {
            Killsession();
            Session["UserInfo"] = null;
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }
        public void Killsession()
        {
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Session.RemoveAll();
            Session.Clear();
            Session.Abandon();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now);
            Response.Cache.SetNoStore();
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.Private);
            Response.AppendHeader("Cache-Control", "no-cache; private; no-store; must-revalidate; max-stale=0; post-check=0; pre-check=0; max-age=0"); // HTTP 1.1
            Response.AppendHeader("Pragma", "no-cache");
            Response.AppendHeader("Expires", "Mon, 26 Jul 1997 05:00:00 GMT");
            Response.ClearHeaders();
            Response.Buffer = false;
            Response.Cookies.Clear();
            Request.Cookies.Clear();
        }
        protected void linkuserdshbrd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User/Dashboard/MainDashboard.aspx");
        }
        protected void linkIndReg_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User/PreReg/IndustryRegistration.aspx");
        }

        protected void linkCFEDashbrd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User/CFE/CFEUserDashboard.aspx");

        }
        protected void LinkCFODashBoard_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User/CFO/CFOUserDashboard.aspx");
        }

        protected void lnkGrievance_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User/Grievance/Grievance.aspx");
        }

        protected void lnkGrvStatus_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User/Grievance/GrievanceUserView.aspx");
        }

        protected void linkland_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User/LA/LAUserDashBoard.aspx");
        }

        protected void lnkCentralrepository_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User/Dashboard/CentralRepository.aspx");
        }

        protected void lnkCentralRep_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User/Dashboard/CentralRepository.aspx");
        }

        protected void LinkRENDashBoard_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User/Renewal/RENUserDashboard.aspx");
        }
    }
}