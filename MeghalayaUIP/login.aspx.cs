using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MeghalayaUIP.BAL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;

namespace MeghalayaUIP
{
    public partial class login : System.Web.UI.Page
    {
        readonly LoginBAL objloginBAL = new LoginBAL();
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;
        string url;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //DataSet ds = new DataSet();
                //string status = Request.QueryString[0].ToString().Trim();

              

                if (!IsPostBack)
                {
                    Killsession();
                    txtUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
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
                if (Request.RequestType.ToUpper() != "POST")
                {
                    Killsession();
                }

                Session["UserInfo"] = null;
                if (String.IsNullOrEmpty(txtUsername.Text) || String.IsNullOrEmpty(txtPswrd.Text))
                {
                    lblmsg0.Text = "Please provide User Name and Password";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "AnotherFunction();", true);
                    Failure.Visible = true;
                }
                else
                {
                    success.Visible = false;
                    Failure.Visible = false;
                    string UserID = "", Password = "";
                    UserID = txtUsername.Text;
                    // Password = txtPswrd.Text;
                    Password = DecryptAES(txtPswrd.Text, "1234567890123456", "1234567890123456");
                    bool CaptchaResult = false;
                    string CErrormsg = "";
                    //CaptchaResult = ValidateCaptcha(out CErrormsg);
                    // string encpassword1 = ExtensionMethods.Decrypt("1D+sRnJbMDxcvfwJF8zPrQ==", "SYSTIME");
                    CaptchaResult = true;
                    if (CaptchaResult)
                    {
                        UserInfo ObjUserInfo;
                        //string encpassword = ExtensionMethods.Encrypt(Password, "SYSTIME");
                        ObjUserInfo = objloginBAL.GetUserInfo(UserID, Password, getclientIP());//,Dept
                        if (ObjUserInfo != null && ObjUserInfo.Userid != null)
                        {
                            Session["UserInfo"] = ObjUserInfo;
                            //objloginBAL.LogUserLoginHistory(ObjUserInfo.Userid, getclientIP());
                            Response.Redirect("~/User/Dashboard/MainDashboard.aspx", false);
                        }
                        else
                        {
                            lblmsg0.Text = "Invalid Credentials..";
                            txtPswrd.Text = "";
                            Failure.Visible = true;
                        }
                    }
                    else
                    {
                        lblmsg0.Text = CErrormsg;
                        Failure.Visible = true;
                    }
                }
                if (Request.QueryString.Count > 0)
                {
                    string status = Request.QueryString["status"];
                    if (!string.IsNullOrEmpty(status))
                    {
                        url = "~/User/CFO/CFOQuestionnaire.aspx?status=" + status;
                        Response.Redirect(url);

                    }
                }
            }
            catch (SqlException ex)
            {
                string errorMsg = ex.Message;
                lblmsg0.Text = "Invalid Credentials.. " ;
                Failure.Visible = true;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
        public static string DecryptAES(string encryptedText, string keyString, string ivString)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = Encoding.UTF8.GetBytes(keyString);
            byte[] ivBytes = Encoding.UTF8.GetBytes(ivString);

            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.IV = ivBytes;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (var memoryStream = new MemoryStream(cipherTextBytes))
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (var reader = new StreamReader(cryptoStream))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
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
      
    }
}