using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using MeghalayaUIP.BAL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;

namespace MeghalayaUIP
{
    public partial class Deptlogin : System.Web.UI.Page
    {
        readonly LoginBAL objloginBAL = new LoginBAL();
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        //private string _antiXsrfTokenValue;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    ComputeSha256Hash("Chanikya");
                    Killsession();
                    txtUsername.Focus();
                    FillCapctha();
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
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

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now);
            Response.Cache.SetNoStore();
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.Private);

        }
        protected void AbandonSession()
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            if (Request.Cookies["ASP.NET_SessionId"] != null)
            {
                Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
            }
            if (Request.Cookies["__AntiXsrfToken"] != null)
            {
                Response.Cookies["__AntiXsrfToken"].Value = string.Empty;
                Response.Cookies["__AntiXsrfToken"].Expires = DateTime.Now.AddMonths(-20);
            }

        }

        protected void btnLogint_Click(object sender, EventArgs e)
        {
            try
            {
                string DPassword = string.Empty;

                if (Request.RequestType.ToUpper() != "POST")
                {
                    Killsession();
                }

                Session["DeptInfo"] = null;
                if (String.IsNullOrEmpty(txtUsername.Text) || String.IsNullOrEmpty(txtPswrd.Text))
                {
                    lblmsg0.Text = "Please provide User Name and Password";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "AnotherFunction();", true);
                    Failure.Visible = true;
                    FillCapctha();
                }
                else if (string.IsNullOrEmpty(txtcaptcha.Text.Trim()))
                {
                    lblmsg0.Text = "Please Enter Captcha";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "AnotherFunction();", true);
                    Failure.Visible = true;
                    FillCapctha();
                }
                else if (txtcaptcha.Text != Convert.ToString(ViewState["captcha"]))
                {
                    lblmsg0.Text = "Invalid Captcha.....!";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "AnotherFunction();", true);
                    Failure.Visible = true; txtcaptcha.Text = "";
                    FillCapctha();
                }
                else
                {
                    success.Visible = false;
                    Failure.Visible = false;
                    string UserID = "", Password = "";
                    UserID = txtUsername.Text;
                    Password = txtPswrd.Text;

                    DataSet ds1 = objloginBAL.GetDeptUserPwdInfo(txtUsername.Text.ToString(), "D");
                    if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToInt32(Convert.ToString(ds1.Tables[0].Rows[0]["WrngPswdCount"])) < 5)
                        {
                            DPassword = ds1.Tables[0].Rows[0]["Password"].ToString();
                            string actPwd1 = FormsAuthentication.HashPasswordForStoringInConfigFile(DPassword + asp_hidden.Value.ToString(), "MD5");
                            if (actPwd1.ToUpper().ToString() != txtPswrd.Text.ToUpper().ToString())
                            {
                                try
                                {
                                    lblmsg0.Text = "Invalid Credentials...!";
                                    Failure.Visible = true;
                                    //objloginBAL.GetDeptUserInfo(UserID, Password, getclientIP());
                                }
                                catch (SqlException ex)
                                {
                                    Killsession();
                                    lblmsg0.Text = "Invalid Credentials...!" + " You have " +
                                                    Convert.ToString(4 - Convert.ToInt32(Convert.ToString(ds1.Tables[0].Rows[0]["WrngPswdCount"])))
                                                    + " Attempts remaining for today";
                                    txtPswrd.Text = "";
                                    Failure.Visible = true;
                                    FillCapctha(); txtcaptcha.Text = "";
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "AnotherFunction();", true); return;
                                }
                            }
                            else
                            {
                                DeptUserInfo ObjUserInfo;
                                ObjUserInfo = objloginBAL.GetDeptUserInfo(UserID, DPassword, getclientIP());//,Dept
                                if (ObjUserInfo != null && ObjUserInfo.UserID != null)
                                {
                                    Session["DeptUserInfo"] = ObjUserInfo;
                                    Response.Redirect("~/Dept/Dashboard/DeptDashBoard.aspx", false);
                                }
                                else
                                {
                                    Killsession();
                                    lblmsg0.Text = "Invalid Credentials...!";
                                    txtPswrd.Text = "";
                                    Failure.Visible = true;
                                    FillCapctha(); txtcaptcha.Text = "";
                                }
                            }
                        }
                        else
                        {
                            Killsession();
                            lblmsg0.Text = "You have made 5 failed login attemps...! Your account has been locked for today...!";
                            txtPswrd.Text = "";
                            Failure.Visible = true;
                            FillCapctha(); txtcaptcha.Text = "";
                        }
                    }
                    else
                    {
                        try
                        {
                            objloginBAL.GetDeptUserInfo(UserID, Password, getclientIP());
                        }
                        catch (SqlException ex)
                        {
                            Killsession();
                            lblmsg0.Text = "Invalid Credentials...!";
                            Failure.Visible = true;
                            txtPswrd.Text = ""; FillCapctha(); txtcaptcha.Text = "";
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                string errorMsg = ex.Message;
                lblmsg0.Text = "Invalid Credentials..";
                Failure.Visible = true;
                FillCapctha(); txtcaptcha.Text = ""; txtPswrd.Text = "";
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
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
        void FillCapctha()
        {
            try
            {
                Killsession();
                AbandonSession();
                ViewState["captcha"] = "";

                Random random = new Random();
                string combination = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabdfghjkmnpqrstuvwxyz";
                StringBuilder captcha = new StringBuilder();

                for (int i = 0; i < 6; i++)
                    captcha.Append(combination[random.Next(combination.Length)]);
                ViewState["captcha"] = captcha.ToString();
                imgCaptcha.ImageUrl = "~/CaptchaHandler.ashx?query=" + captcha.ToString();
            }
            catch
            {
                throw;
            }
        }

        protected void btnRefresh_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                FillCapctha();
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }
        static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}