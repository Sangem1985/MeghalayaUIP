using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace MeghalayaUIP
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        readonly LoginBAL objloginBAL = new LoginBAL();
        MGCommonBAL objcomBal = new MGCommonBAL();
        MasterBAL mstrBAL = new MasterBAL();
        DateTime lastSentTime;
        private static int _emailsSent = 0;
        private static TimeSpan _timeWindow = TimeSpan.FromHours(1); // 1 hour window
        private static int _emailLimit = 100; // Max 100 emails per hour
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    FillCapctha();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnRefresh_Click(object sender, ImageClickEventArgs e)
        {
            FillCapctha();
        }
        void FillCapctha()
        {
            try
            {
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

        protected void btnForget_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
                {
                    lblmsg0.Text = "Please provide EmailId....!";
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
                else if (txtcaptcha.Text.Trim() != Convert.ToString(ViewState["captcha"]))
                {
                    lblmsg0.Text = "Invalid Captcha.....!";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "AnotherFunction();", true);
                    Failure.Visible = true;
                    FillCapctha(); txtcaptcha.Text = "";

                }
                else
                {
                    string Host = Convert.ToString(ConfigurationManager.AppSettings["expectedHost"]);
                    if (Host.Contains("localhost"))
                    {
                        Host = "https://localhost:44379/";
                    }
                    else if (Host.Contains("103.154.75.191"))
                    {
                        Host = "http://103.154.75.191/Investmeghalaya/";
                    }
                    else
                    {
                        Host = "https://invest.meghalaya.gov.in/";
                    }
                    string EmailId = "";
                    EmailId = txtEmail.Text;
                    DataSet ds = new DataSet();
                    ds = objloginBAL.GetDeptUserPwdInfo(txtEmail.Text.Trim().ToString(), "I");
                    if (ds.Tables[0].Rows.Count > 0 && Convert.ToInt16(Convert.ToString(ds.Tables[0].Rows[0]["WRNGPSWDCOUNT"])) <= 4)
                    {
                        string emailsenttime = Convert.ToString(ds.Tables[0].Rows[0]["LASTEMAILSENT"]);
                        if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0
                            && Convert.ToInt32(Convert.ToString(ds.Tables[1].Rows[0]["SENTRESETLINKS"])) < 2)
                        {
                            int Hrsdiff, lasthr;
                            if (emailsenttime != "")
                            {
                                lasthr = Convert.ToDateTime(emailsenttime).Hour;
                                Hrsdiff = (Convert.ToDateTime(emailsenttime).Hour - DateTime.Now.Hour);
                            }

                            if (emailsenttime == "" || (DateTime.Now.Hour - Convert.ToDateTime(emailsenttime).Hour) > 2)
                            {
                                Random random = new Random();
                                string combination = "ABCDEFGHJKLMNPQRSTUVWXYZabdfghjkmnpqrstuvwxyz123456789";
                                StringBuilder SecretKey = new StringBuilder();
                                for (int i = 0; i < 10; i++)
                                    SecretKey.Append(combination[random.Next(combination.Length)]);
                                ViewState["PswdSecretKey"] = SecretKey.ToString();
                                string passwordlink = Host + "SetNewPassword.aspx?link=" + mstrBAL.EncryptFilePath(txtEmail.Text.Trim()) + "&use=" + mstrBAL.EncryptFilePath(SecretKey.ToString());
                                string Username = ds.Tables[0].Rows[0]["Username"].ToString();
                                SMSandMail smsMail = new SMSandMail();
                                string EmailText = "Dear " + ds.Tables[0].Rows[0]["Fullname"].ToString() + ", Please find the below link to reset the password."
                                    + "</b><br/> Password Reset Link:  <a href='" + passwordlink + "' target='_blank' > Invest Meghalaya Authority - New Password Link </a>"
                                    + "</b><br/> Secret Key:" + SecretKey
                                    + " </b><br/> Please use this Secret Key while creating the new password."
                                    + " </b><br/><br/> Best Regards"
                                    + "</b><br/> Invest Meghalaya Authority";

                                try
                                {

                                    smsMail.SendEmailSingle(Username, "", "Password Reset Link", EmailText, "", "General",
                                     "", "", ds.Tables[0].Rows[0]["Userid"].ToString());
                                    //hdnLinkSent.Value = "Y";
                                    //if ((DateTime.Now - _lastSentTime) > _timeWindow)
                                    //{
                                    //    _emailsSent = 0; // Reset count after the time window expires
                                    //    _lastSentTime = DateTime.Now;
                                    //}

                                    //if (_emailsSent >= _emailLimit)
                                    //{
                                    //    lblmsg0.Text = "Email limit reached, please try later. ...!";
                                    //    Failure.Visible = true; 
                                    //    return;
                                    //}
                                    //else
                                    //{
                                    //    smsMail.SendEmailSingle(Username, "", "Password Reset Link", EmailText, "", "General",
                                    // "", "", ds.Tables[0].Rows[0]["Userid"].ToString());
                                    //}

                                    try
                                    {

                                        string result = objcomBal.InsertPswdResetKey(txtEmail.Text.Trim(), SecretKey.ToString(), getclientIP());
                                        txtcaptcha.Text = "";
                                        FillCapctha();
                                        if (result != "")
                                        {
                                            txtEmail.Text = "";
                                            txtcaptcha.Text = "";
                                            FillCapctha();
                                            lblmsg.Text = "Password Reset link is shared to your email... The link is valid for 10 min only";
                                            success.Visible = true;

                                        }
                                    }
                                    catch (SqlException ex)
                                    {
                                        lblmsg0.Text = "Error Occured ...!";
                                        Failure.Visible = true;

                                    }

                                }
                                catch (Exception ex)
                                {
                                    lblmsg0.Text = "Error Occured While sending the mail...!";
                                    Failure.Visible = true;

                                }
                                finally
                                { }
                            }
                        }
                        else
                        {
                            lblmsg0.Text = "Password reset email has already been sent twice today. No more emails will be sent..!";
                            Failure.Visible = true;
                            success.Visible = false;
                        }

                    }
                    else
                    {
                        lblmsg0.Text = txtEmail.Text = "Invalid Email Id...!";
                        Failure.Visible = true;
                        txtcaptcha.Text = "";
                        FillCapctha();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
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