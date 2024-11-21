using AjaxControlToolkit.HtmlEditor.ToolbarButtons;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.CommonClass;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static AjaxControlToolkit.AsyncFileUpload.Constants;

namespace MeghalayaUIP
{
    public partial class SetNewPassword : System.Web.UI.Page
    {
        MGCommonBAL objcomBal = new MGCommonBAL();
        MasterBAL mstrBAL = new MasterBAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    FillCapctha();
                    if (Request.QueryString.Count > 0)
                    {
                        BindSecretKey();

                    }
                    else
                    {
                        Response.Redirect("~/Login.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
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
        public void BindSecretKey()
        {
            try
            {
                if (Request.QueryString.Count > 0)
                {
                    string email = mstrBAL.DecryptFilePath(Convert.ToString(Request.QueryString[0]));
                    string SecretKey = mstrBAL.DecryptFilePath(Convert.ToString(Request.QueryString[1]));
                    DataSet ds = new DataSet();
                    ds = objcomBal.GetPswdResetKey(email, SecretKey);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        divnewpswd.Visible = true;
                        lblusername.Text = Convert.ToString(ds.Tables[0].Rows[0]["EMAILID"]);
                        lblusername.Enabled = false;
                        ViewState["Username"] = Convert.ToString(ds.Tables[0].Rows[0]["EMAILID"]);
                        ViewState["SecretKey"] = Convert.ToString(ds.Tables[0].Rows[0]["SECRETKEY"]);
                    }
                    else
                    {
                        divnewpswd.Visible = false;
                        lblmsg0.Text = "Invalid reset link or link expired....!";
                        Failure.Visible = true;
                    }

                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = "Invalid reset link or link expired....!";
                Failure.Visible = true;
            }
        }
        protected void btnRefresh_Click(object sender, ImageClickEventArgs e)
        {
            FillCapctha();

        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dss = new DataSet();
                string result = "", ErrorMsg = "";
                ErrorMsg = Validations();
                if (ErrorMsg == "")
                {
                    string email = mstrBAL.DecryptFilePath(Convert.ToString(Request.QueryString[0]));
                    string SecretKey = mstrBAL.DecryptFilePath(Convert.ToString(Request.QueryString[1]));
                    dss = objcomBal.GetPswdResetKey(email, SecretKey);
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        string Password = PasswordDescription(txtnewpassword.Text.Trim());
                        if (lblusername.Text == Convert.ToString(dss.Tables[0].Rows[0]["EMAILID"]) &&
                           txtSecretKey.Text.Trim() == Convert.ToString(dss.Tables[0].Rows[0]["SECRETKEY"]))
                        {
                            result = objcomBal.ChangeUserPassword("1", Convert.ToString(ViewState["Username"]), Password.Trim(), Password.Trim(), getclientIP());
                            if (result != "")
                            {
                                lblmsg.Text = "Your Login Password Successfully Updated And Login With New Password..!";
                                success.Visible = true;
                                Failure.Visible = false;
                                txtSecretKey.Text = "";
                                txtcaptcha.Text = "";
                                FillCapctha();
                                BtnUpdate.Enabled = false;
                            }
                        }
                        else
                        {
                            divnewpswd.Visible = false;
                            lblmsg0.Text = "Invalid reset link or link expired....!";
                            Failure.Visible = true;
                        }
                    }
                }
                else
                {
                    Failure.Visible = true;
                    lblmsg0.Text = ErrorMsg.Replace(@"\n", "");
                    string message = "alert('" + ErrorMsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public string Validations()
        {
            string Errormsg = "";

            if (string.IsNullOrEmpty(txtnewpassword.Text.Trim()))
            {
                Errormsg = Errormsg + "Please Enter New Password \\n";
            }
            if (string.IsNullOrEmpty(txtconfirmpassword.Text.Trim()))
            {
                Errormsg = Errormsg + "Please Enter Confirm Password \\n";
            }
            if (txtnewpassword.Text.Trim() != txtconfirmpassword.Text.Trim())
            {
                Errormsg = Errormsg + "Password and Confirm Password shoul be same \\n";
            }
            if (!string.IsNullOrEmpty(txtnewpassword.Text) || txtnewpassword.Text != "")
            {
                string Password = PasswordDescription(txtnewpassword.Text.Trim());
                if (Password.Trim() == lblusername.Text.Trim())
                {
                    Errormsg = Errormsg + ". User Email and Password should not be same \\n";

                }
                if (Password.Trim().Length < 8)
                {
                    Errormsg = Errormsg + "Password must have 8 characters Minimum \\n";

                }
                if (!(Password.Any(char.IsLower) && Password.Any(char.IsUpper) &&
                           Password.Any(char.IsDigit) && ValidatePassword(Password.Trim())))
                {
                    Errormsg = Errormsg + "Password must have atleast one upper case letter, one lower case letter, one numer and one special character \\n";

                }
            }
            if (string.IsNullOrEmpty(txtSecretKey.Text))
            {
                Errormsg = Errormsg + "Please Enter Secret Key Shared to you mail...!";
            }
            if (ViewState["captcha"].ToString() != txtcaptcha.Text.Trim())
            {
                Errormsg = "Invalid Captcha Code....!!";
            }
            if (string.IsNullOrEmpty(txtcaptcha.Text.Trim()))
            {
                Errormsg = "Please Enter Captcha";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "AnotherFunction();", true);
                Failure.Visible = true;
                FillCapctha();                
            }



                return Errormsg;

        }
        public string PasswordDescription(string encrPswd)
        {
            var key = asp_hidden.Value;
            string encrpted = encrPswd.Trim(), DecrPswd = "";
            for (int j = 0; j < encrpted.Length; j++)
            {
                var charCode = (char)(encrpted[j] ^ key[j % key.Length]);
                DecrPswd += charCode;
            }
            return DecrPswd;
        }
        public bool ValidatePassword(string strpass)
        {
            bool bValid = false;
            // string strnumeric = "0123456789";
            //string strchar = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string strSpl = "!@$*#&";
            int i;

            for (i = 0; i < strpass.Length; i++)
            {
                if (strSpl.IndexOf((strpass.Substring(i, 1))) > -1)
                {
                    bValid = true;
                    break;
                }
            }
            if (bValid == false)
            {
                return bValid;
            }
            return bValid;
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