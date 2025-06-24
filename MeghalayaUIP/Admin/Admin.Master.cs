using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        LoginBAL objloginBAL = new LoginBAL();
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        protected string strSessionexp = string.Empty;

        MasterBAL masterball = new MasterBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            string fullUrl = Request.Url.AbsoluteUri;
            string pageName = Path.GetFileName(fullUrl);


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
                    DataSet ds = objloginBAL.GetDeptUserPwdInfo(ObjUserInfo.Email, "I");
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToString(ds.Tables[0].Rows[0]["MODIFIEDDATE"]) != "")
                        {
                            string pswdresettime = Convert.ToString(ds.Tables[0].Rows[0]["MODIFIEDDATE"]);
                            int Hrsdiff, lasthr;
                            if (pswdresettime != "")
                            {
                                lasthr = Convert.ToDateTime(pswdresettime).Minute;
                                TimeSpan ts = (DateTime.Now - Convert.ToDateTime(pswdresettime));
                                Double minutesdiff = ts.TotalMinutes;
                                if (minutesdiff < 1)
                                {
                                    Response.Redirect("~/Login.aspx");
                                }

                            }


                        }
                    }

                    string Access = masterball.GetPageAuthorization(pageName, ObjUserInfo.RoleId);
                    /*if (Access == "N") 
                    {
                        fnSetNewControls_Click(sender, e);
                    }*/
                    if (!Request.Url.ToString().Contains("localhost"))
                        masterball.InsPageAccessed(ObjUserInfo.Userid, ObjUserInfo.Email, Request.Url.ToString(), getclientIP(), "");
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
            lblusername.InnerText = ObjUserInfo.Email;
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
        protected void linkUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/SearchUser.aspx");

        }

        protected void linkPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/PageDetails.aspx");
        }

        protected void linkHelpDesk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/HelpdeskReport.aspx");
        }

        protected void LinkReports_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/.aspx");
        }
        protected void linkuserdshbrd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User/Dashboard/MainDashboard.aspx");
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