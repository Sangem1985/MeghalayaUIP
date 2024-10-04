using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using MeghalayaUIP.Common;
using System.IO;
using MeghalayaUIP.BAL.CommonBAL;

namespace MeghalayaUIP.Dept
{
    public partial class dept : System.Web.UI.MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        //private string _antiXsrfTokenValue;
        protected string strSessionexp = string.Empty;
        MasterBAL masterball = new MasterBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            aLogout.ServerClick += new EventHandler(fnSetNewControls_Click);
            aLogout.HRef = "";
            string fullUrl = Request.Url.AbsoluteUri;
            string pageName = Path.GetFileName(fullUrl);

            if (Session["DeptUserInfo"] == null)
            {
                fnSetNewControls_Click(this, EventArgs.Empty);
            }
            var ObjUserInfo = new DeptUserInfo();
            if (Session["DeptUserInfo"] != null)
            {

                if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
                {
                    ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
                    string Access = masterball.GetPageAuthorization(pageName, ObjUserInfo.Roleid);
                    /*if (Access == "N") 
                    {
                        fnSetNewControls_Click(sender, e);
                    }*/
                    masterball.InsPageAccessed(ObjUserInfo.UserID, ObjUserInfo.UserName, Request.Url.ToString(), getclientIP(), ObjUserInfo.Roleid);
                }
                // username = ObjUserInfo.UserName;
            }
            if (!IsPostBack)
            {
                string guid = Guid.NewGuid().ToString("N");
                Session[AntiXsrfTokenKey] = guid;
                hdnUToken.Value = guid;
                if (Session["DeptUserInfo"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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
            if (Session["DeptUserInfo"] == null)
            {
                fnSetNewControls_Click(sender, e);
            }

            lblUser.InnerText = ObjUserInfo.UserName;
            if (ObjUserInfo.Roleid == "1")
                lblrole.InnerText = "Invest Meghalaya Authority";
            if (ObjUserInfo.Roleid == "4" || ObjUserInfo.Roleid == "8")
                lblrole.InnerText = "Department";
            if (ObjUserInfo.Roleid == "5" || ObjUserInfo.Roleid == "6" || ObjUserInfo.Roleid == "7")
                lblrole.InnerText = "Committee Officer";



        }

        protected void fnSetNewControls_Click(object sender, EventArgs e)
        {
            Killsession();
            Session["DeptUserInfo"] = null;
            Session.Abandon();
            Response.Redirect("~/Deptlogin.aspx");
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

        protected void linkDeptdshbrd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Dept/Dashboard/DeptDashBoard.aspx");
        }
        public static string getclientIP()
        {
            string result = string.Empty;
            string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ip))
            {
                string[] ipRange = ip.Split(',');
                int le = ipRange.Length - 1;
                result = ipRange[0];
            }
            else
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            return result;
        }
    }
}