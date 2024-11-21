using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MeghalayaUIP.BAL;
using MeghalayaUIP.BAL.CommonBAL;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using AjaxControlToolkit.HtmlEditor.ToolbarButtons;
using System.Configuration;
using System.Net.PeerToPeer;
using System.Web.Mail;

namespace MeghalayaUIP
{
    public partial class Registration : System.Web.UI.Page
    {
        UserRegBAL useregBAL = new UserRegBAL();
        MasterBAL mstrBAL = new MasterBAL();
        string Password;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                success.Visible = false;
                Failure.Visible = false;
                if (!IsPostBack)
                {
                    FillCapctha();
                    txtEmail.Text = "";
                    txtPswd.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
        public void AddSelect(DropDownList ddl)
        {
            try
            {
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem();
                li.Text = "--Select--";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtName.Text = "";
                txtPAN.Text = "";
                txtcompanyname.Text = "";
                txtEmail.Text = "";
                txtPswd.Text = "";
                txtMobileNo.Text = "";
                txtCaptcha.Text = "";
                lblmsg.Text = "";
                lblmsg0.Text = "";
                success.Visible = false;
                Failure.Visible = false;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string Errormsg = "";
                string valid = "0";
                Errormsg = validations();

                if (string.IsNullOrEmpty(Errormsg))
                {
                    UserRegDetails Userregdtls = new UserRegDetails();
                    Userregdtls.Fullname = txtName.Text.Trim(); ;
                    Userregdtls.CompanyName = txtcompanyname.Text.Trim();
                    Userregdtls.PANno = txtPAN.Text.Trim();
                    Userregdtls.Email = txtEmail.Text.Trim();
                    Userregdtls.Password = PasswordDescription(txtPswd.Text);
                    Userregdtls.MobileNo = txtMobileNo.Text.Trim();
                    Userregdtls.State = "STATE";
                    Userregdtls.DateofBirth = "1988-04-10";
                    Userregdtls.IPAddress = GetIPAddress();
                    valid = useregBAL.InsertUserRegDetails(Userregdtls);
                    if (Convert.ToInt32(valid) != 0)
                    {
                        string loginlink = "https://invest.meghalaya.gov.in/Login.aspx";
                        string EmailText = "Dear " + txtName.Text.Trim() + "," +
                        "</b><br/><br/> Welcome to Invest Meghalaya Portal. Thank you for registering."
                        + "</b><br/><br/> Please Login with Registered E-mail by using the link  <a href='" + "https://invest.meghalaya.gov.in/Login.aspx" + "' target='_blank' > Invest Meghalaya Authority - Login Link </a>"
                               + " </b><br/><br/> Best Regards"
                                + "</b><br/> Invest Meghalaya Authority";
                        SMSandMail smsMail = new SMSandMail();

                        smsMail.SendEmailSingle(txtEmail.Text.Trim(), "", "Welcome to Our Web Portal", EmailText, "", "User Registration",
                                 "", "", valid);

                        lblmsg.Text = "Registered Successfully!";
                        success.Visible = true;
                        btnClear_Click(sender, e);

                    }


                    

                }
                else
                {
                    FillCapctha();
                    txtPswd.Text = ""; txtCaptcha.Text = "";
                    string message = "alert('" + Errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (SqlException ex)
            {
                FillCapctha(); txtPswd.Text = ""; txtCaptcha.Text = "";
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
            catch (Exception ex)
            {
                FillCapctha(); txtPswd.Text = ""; txtCaptcha.Text = "";
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }

        }
        public string validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                if (string.IsNullOrEmpty(txtPAN.Text) || txtPAN.Text == "" || txtPAN.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter PAN number \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtcompanyname.Text.Trim()) || txtcompanyname.Text.Trim() == "" || txtcompanyname.Text.Trim() == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Company Name as per PAN number \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtName.Text.Trim()) || txtName.Text.Trim() == "" || txtName.Text.Trim() == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Fullname \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtMobileNo.Text) || txtMobileNo.Text == "" || txtMobileNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Mobile Number \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEmail.Text) || txtEmail.Text == "" || txtEmail.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Email \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPswd.Text) || txtPswd.Text == "" || txtPswd.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Password \\n";
                    slno = slno + 1;
                }
                if (!string.IsNullOrEmpty(txtPswd.Text) || txtPswd.Text != "")
                {
                    Password = PasswordDescription(txtPswd.Text);

                    if (Password.Trim() == txtEmail.Text.Trim())
                    {
                        errormsg = errormsg + slno + ". User Email and Password should not be same \\n";
                        slno = slno + 1;
                    }
                    if (Password.Trim().Length < 8)
                    {
                        errormsg = errormsg + slno + ". Password must have 8 characters Minimum \\n";
                        slno = slno + 1;
                    }
                    if (!(Password.Any(char.IsLower) && Password.Any(char.IsUpper) &&
                               Password.Any(char.IsDigit) && ValidatePassword(Password.Trim())))
                    {
                        errormsg = errormsg + slno + ". Password must have atleast one upper case letter, one lower case letter, one numer and one special character \\n";
                        slno = slno + 1;
                    }
                }

                if (string.IsNullOrEmpty(txtCaptcha.Text) || txtCaptcha.Text == "" || txtCaptcha.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Captcha \\n";
                    slno = slno + 1;
                }
                if (txtCaptcha.Text.Trim() != Convert.ToString(ViewState["captcha"]))
                {
                    errormsg = errormsg + slno + ". Please Enter Correct Captcha \\n";
                    slno = slno + 1;
                }

                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string GetIPAddress()
        {
            var visitorsIpAddr = string.Empty;

            if (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                visitorsIpAddr = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }
            else if (!string.IsNullOrEmpty(Request.UserHostAddress))
            {
                visitorsIpAddr = Request.UserHostAddress;
            }

            return visitorsIpAddr;
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

        protected void txtPswd_TextChanged(object sender, EventArgs e)
        {
            if (txtPswd.Text.Trim() == txtEmail.Text.Trim())
            {
                lblmsg0.Text = "User Email and Password should not be same";
                success.Visible = false;
                Failure.Visible = true;
                txtPswd.Text = "";
                txtCaptcha.Text = "";
                FillCapctha();
                return;
            }
            if (txtPswd.Text.Trim().Length < 8)
            {
                lblmsg0.Text = "Password must have 8 characters Minimum";
                success.Visible = false;
                Failure.Visible = true;
                txtPswd.Text = "";
                txtCaptcha.Text = "";
                FillCapctha();
                return;
            }
            if (!(txtPswd.Text.Any(char.IsLower) && txtPswd.Text.Any(char.IsUpper) &&
                       txtPswd.Text.Any(char.IsDigit) && ValidatePassword(txtPswd.Text.Trim())))
            {

                lblmsg0.Text = "Password must have atleast one upper case letter, one lower case letter, one numer and one special character";
                success.Visible = false;
                Failure.Visible = true;
                txtPswd.Text = "";
                txtCaptcha.Text = "";
                FillCapctha();
                return;
            }
        }
        public bool ValidatePassword(string strpass)
        {
            bool bValid = false;
            // string strnumeric = "0123456789";
            //string strchar = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string strSpl = "!@$*#&";
            int i;
            //for (i = 0; i < strpass.Length; i++)
            //{
            //    if (strchar.IndexOf((strpass.Substring(i, 1))) > -1)
            //    {
            //        bValid = true;
            //        break;
            //    }
            //}
            //if (bValid == false)
            //{
            //    return bValid;
            //}
            //bValid = false;
            //for (i = 0; i < strpass.Length; i++)
            //{
            //    if (strnumeric.IndexOf((strpass.Substring(i, 1))) > -1)
            //    {
            //        bValid = true;
            //        break;
            //    }
            //}
            //if (bValid == false)
            //{
            //    return bValid;
            //}
            //bValid = false;
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
                imgCaptcha.Enabled = false;
            }
            catch
            {
                throw;
            }
        }

        protected void btnRefresh_Click(object sender, ImageClickEventArgs e)
        {
            FillCapctha();
        }
    }
}