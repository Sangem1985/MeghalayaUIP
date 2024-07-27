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
namespace MeghalayaUIP
{
    public partial class Registration : System.Web.UI.Page
    {
        UserRegBAL useregBAL = new UserRegBAL();
        MasterBAL mstrBAL = new MasterBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                success.Visible = false;
                Failure.Visible = false;
                if (!IsPostBack)
                {
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
                    Userregdtls.Password = txtPswd.Text.Trim();
                    Userregdtls.MobileNo = txtMobileNo.Text.Trim();
                    Userregdtls.State = "STATE";
                    Userregdtls.DateofBirth = "1988-04-10";
                    Userregdtls.IPAddress = GetIPAddress();
                    valid = useregBAL.InsertUserRegDetails(Userregdtls);
                    if (Convert.ToInt32(valid) != 0)
                    {
                        lblmsg.Text = "Registered Successfully!";
                        success.Visible = true;
                    }
                }
                else
                {
                    string message = "alert('" + Errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (SqlException ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
            catch (Exception ex)
            {
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
                    if (txtPswd.Text.Trim() == txtEmail.Text.Trim())
                    {
                        errormsg = errormsg + slno + ". User Email and Password should not be same \\n";
                        slno = slno + 1;
                    }
                    if (txtPswd.Text.Trim().Length < 8)
                    {
                        errormsg = errormsg + slno + ". Password must have 8 characters Minimum \\n";
                        slno = slno + 1;
                    }
                    if (!(txtPswd.Text.Any(char.IsLower) && txtPswd.Text.Any(char.IsUpper) &&
                               txtPswd.Text.Any(char.IsDigit) && ValidatePassword(txtPswd.Text.Trim())))
                    {
                        errormsg = errormsg + slno + ". Password must have atleast one upper case letter, one lower case letter, one numer and one special character \\n";
                        slno = slno + 1;
                    }
                }

                //if (string.IsNullOrEmpty(txtCaptcha.Text) || txtCaptcha.Text == "" || txtCaptcha.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Cpatcha \\n";
                //    slno = slno + 1;
                //}

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

        protected void txtPswd_TextChanged(object sender, EventArgs e)
        {
            if (txtPswd.Text.Trim() == txtEmail.Text.Trim())
            {
                lblmsg0.Text = "User Email and Password should not be same";
                success.Visible = false;
                Failure.Visible = true;
                txtPswd.Text = "";
                txtCaptcha.Text = "";
                // FillCapctha();
                return;
            }
            if (txtPswd.Text.Trim().Length < 8)
            {
                lblmsg0.Text = "Password must have 8 characters Minimum";
                success.Visible = false;
                Failure.Visible = true;
                txtPswd.Text = "";
                txtCaptcha.Text = "";
                //  FillCapctha();
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
                //  FillCapctha();
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

    }
}