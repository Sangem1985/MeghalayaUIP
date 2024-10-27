using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Dept.Dashboard
{
    public partial class DeptChangePassword : System.Web.UI.Page
    {
        readonly LoginBAL objloginBAL = new LoginBAL();
        MGCommonBAL objcomBal = new MGCommonBAL();
        DeptUserInfo ObjUserInfo = new DeptUserInfo();
        string Password;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["DeptUserInfo"] != null)
                {

                    if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
                    {
                        ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];

                    }
                    if (hdnUserID.Value == "")
                    {
                        hdnUserID.Value = ObjUserInfo.UserID;
                    }

                    if (!IsPostBack)
                    {
                        FillCapctha();
                    }

                    txtusername.Text = ObjUserInfo.UserName;
                    txtusername.Enabled = false;
                    txtoldpassword.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnRefresh_Click(object sender, ImageClickEventArgs e)
        {
            txtcaptcha.Text = "";
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
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void BtnSave3_Click(object sender, EventArgs e)
        {
            try
            {
                String UserID = "", result = "", ErrorMsg = "";
                ErrorMsg = Validations();
                if (ErrorMsg == "")
                {
                    if (BtnSave3.Text == "Submit")
                    {
                        if (txtoldpassword.Text.Trim() == txtnewpassword.Text)
                        {

                            lblmsg.Text = "Old Password and New Password should not be same";
                            success.Visible = false;
                            Failure.Visible = true;
                            FillCapctha();
                            return;
                        }
                        if (txtnewpassword.Text.Trim() != txtconfirmpassword.Text.Trim())
                        {
                            lblmsg.Text = "New Password & Confirm Password Doesn't Matched....!";
                            success.Visible = false;
                            Failure.Visible = true;
                            FillCapctha();
                            return;
                        }

                        UserID = txtusername.Text;
                        txtnewpassword.Text = PasswordDescription(txtnewpassword.Text.Trim());
                        txtconfirmpassword.Text = PasswordDescription(txtconfirmpassword.Text.Trim());
                        DeptUserInfo ObjUserInfo;
                        ObjUserInfo = objloginBAL.GetDeptUserInfo(UserID, txtoldpassword.Text.Trim(), getclientIP());//,Dept  
                        if (ObjUserInfo != null && ObjUserInfo.UserID != null)
                        {
                            result = objcomBal.ChangeDeptUserPassword(hdnUserID.Value, UserID, txtoldpassword.Text.Trim(), txtnewpassword.Text.Trim(), getclientIP());
                            if (result != "")
                            {
                                lblmsg.Text = "Password Successfully Changed And Login With New Password..!";
                                success.Visible = true;
                                Failure.Visible = false;
                                trsubmittion.Visible = false;
                                string message = "alert('" + lblmsg.Text + "')";
                                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                                Response.Redirect("~/Deptlogin.aspx");
                            }
                        }
                        else
                        {
                            lblmsg.Text = "Invalid User And Password";
                            FillCapctha();
                            success.Visible = false;
                            Failure.Visible = true;
                            BTNcLEAR_Click(sender, e);
                            string message = "alert('" + lblmsg.Text + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                        }
                    }
                }
                else
                {
                    Failure.Visible = true;
                    FillCapctha();
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
            try
            {
               // int slno = 1;
                string errormsg = "";


                if (string.IsNullOrEmpty(txtcaptcha.Text) || txtcaptcha.Text == "" || txtcaptcha.Text == null)
                {
                    errormsg = errormsg + "Please Enter Captcha...! \\n";
                }
                if (string.IsNullOrEmpty(txtusername.Text) || txtusername.Text == "" || txtusername.Text == null)
                {
                    errormsg = errormsg + "Please Enter Username ...! \\n";

                }
                if (string.IsNullOrEmpty(txtoldpassword.Text) || txtoldpassword.Text == "" || txtoldpassword.Text == null)
                {
                    errormsg = errormsg + "Please Enter Old Password...! \\n";
                    //slno = slno + 1;

                }
                if (string.IsNullOrEmpty(txtnewpassword.Text) || txtnewpassword.Text == "" || txtnewpassword.Text == null)
                {
                    Password = PasswordDescription(txtnewpassword.Text.Trim());

                    if (Password.Trim() == txtnewpassword.Text.Trim())
                    {
                        errormsg = errormsg + ". Please Enter New Password  \\n";
                    }
                    if (!(Password.Any(char.IsLower) && Password.Any(char.IsUpper) &&
                            Password.Any(char.IsDigit) && ValidatePassword(Password.Trim())))
                    {
                        errormsg = errormsg + ". Password must have atleast one upper case letter, one lower case letter, one numer and one special character \\n";

                    }
                    if (Password.Trim().Length < 8)
                    {
                        errormsg = errormsg + ". Password must have 8 characters Minimum \\n";

                    }

                }
                if (string.IsNullOrEmpty(txtconfirmpassword.Text) || txtconfirmpassword.Text == "" || txtconfirmpassword.Text == null)
                {
                    Password = PasswordDescription(txtconfirmpassword.Text.Trim());

                    if (Password.Trim() == txtconfirmpassword.Text.Trim())
                    {
                        errormsg = errormsg + ". Please Enter Confirm Password \\n";
                    }

                }

                if (txtnewpassword.Text.Trim() == txtusername.Text.Trim())
                {
                    errormsg = errormsg + "Please Enter User Email and Password should not be same...! \\n";
                }


                return errormsg;
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

        protected void BTNcLEAR_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Dept/Dashboard/DeptChangePassword");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }      
        public bool ValidatePassword(string strpass)
        {
            bool bValid = false;         
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
        public string PasswordDescription(string encrPswd)
        {
            var key = hdnUserID.Value;//asp_hidden.Value;
            string encrpted = encrPswd.Trim(), DecrPswd = "";
            for (int j = 0; j < encrpted.Length; j++)
            {
                var charCode = (char)(encrpted[j] ^ key[j % key.Length]);
                DecrPswd += charCode;
            }
            return DecrPswd;
        }

    }
}