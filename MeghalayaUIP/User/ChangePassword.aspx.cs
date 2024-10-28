using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
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

namespace MeghalayaUIP.User
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        readonly LoginBAL objloginBAL = new LoginBAL();
        MGCommonBAL objcomBal = new MGCommonBAL();
        string Userid, OldPassword, NewPassword, CnfrmPassword;
        DataSet dsUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserInfo"] != null)
                {
                    var ObjUserInfo = new UserInfo();
                    if (Session["UserInfo"] != null && Session["UserInfo"].ToString() != "")
                    {
                        ObjUserInfo = (UserInfo)Session["UserInfo"];
                        Userid = ObjUserInfo.Email;
                        txtusername.Text = ObjUserInfo.Email;
                        txtusername.Enabled = false;
                    }
                    if (hdnUserID.Value == "")
                    {
                        hdnUserID.Value = ObjUserInfo.Userid;
                    }
                    else
                    {
                        //string newurl = "~/login.aspx";
                        //Response.Redirect(newurl);
                    }

                    Page.MaintainScrollPositionOnPostBack = true;
                    Failure.Visible = false;
                    success.Visible = false;
                    if (!IsPostBack)
                    {
                        dsUser = objloginBAL.GetDeptUserPwdInfo(ObjUserInfo.Email, "I");
                        if (dsUser != null && dsUser.Tables.Count > 0 && dsUser.Tables[0].Rows.Count > 0)
                        {
                            ViewState["OldPassword"] = Convert.ToString(dsUser.Tables[0].Rows[0]["Password"]);
                        }
                        FillCapctha();
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
            catch
            {
                throw;
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


                        UserID = txtusername.Text;
                        NewPassword = PasswordDescription(txtnewpassword.Text.Trim());
                        CnfrmPassword = PasswordDescription(txtconfirmpassword.Text.Trim());
                        OldPassword = PasswordDescription(txtoldpassword.Text.Trim());
                        try
                        {
                            DataSet ds = objloginBAL.GetDeptUserPwdInfo(UserID, "I");
                            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                if (OldPassword == Convert.ToString(ds.Tables[0].Rows[0]["Password"]))
                                {
                                    result = objcomBal.ChangeUserPassword(hdnUserID.Value, UserID, OldPassword, NewPassword, getclientIP());
                                    if (result != "")
                                    {
                                        lblmsg.Text = "Password Successfully Changed And Login With New Password..!";
                                        success.Visible = true;
                                        Failure.Visible = false;
                                        trsubmittion.Visible = false;
                                        //string message = "alert('" + lblmsg.Text + "')";
                                        //ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", $"alert('Password Changed Successfully...! Please login with New Password');  window.location.href='../login.aspx';", true);

                                        //Response.Redirect("~/login.aspx");
                                    }
                                    else
                                    {
                                        lblmsg0.Text = "Error Occured while saving.....!";
                                        txtoldpassword.Attributes["value"] = ""; txtnewpassword.Attributes["value"] = ""; txtconfirmpassword.Attributes["value"] = ""; txtcaptcha.Text = "";
                                        Failure.Visible = true;
                                        success.Visible = false;
                                        FillCapctha(); txtcaptcha.Text = "";


                                    }
                                }
                                else
                                {
                                    lblmsg0.Text = "Invalid Credentials (User name and Old Password).....!";
                                    txtoldpassword.Attributes["value"] = ""; txtnewpassword.Attributes["value"] = ""; txtconfirmpassword.Attributes["value"] = ""; txtcaptcha.Text = "";
                                    Failure.Visible = true;
                                    success.Visible = false;
                                    FillCapctha();
                                }
                            }
                        }
                        catch (SqlException ex)
                        {
                            FillCapctha();
                            txtoldpassword.Attributes["value"] = ""; txtnewpassword.Attributes["value"] = ""; txtconfirmpassword.Attributes["value"] = ""; txtcaptcha.Text = "";
                            success.Visible = false;
                            Failure.Visible = true;
                            string message = "alert('" + lblmsg.Text + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                            lblmsg.Text = "Invalid Credentials (User name and Old Password)";
                        }
                    }
                }
                else
                {
                    Failure.Visible = true;
                    FillCapctha();
                    txtoldpassword.Attributes["value"] = ""; txtnewpassword.Attributes["value"] = ""; txtconfirmpassword.Attributes["value"] = ""; txtcaptcha.Text = "";
                    lblmsg0.Text = ErrorMsg.Replace(@"\n", "");
                    string message = "alert('" + ErrorMsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

            }
            catch (Exception ex)
            {
                txtoldpassword.Attributes["value"] = ""; txtnewpassword.Attributes["value"] = ""; txtconfirmpassword.Attributes["value"] = ""; txtcaptcha.Text = "";
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public string Validations()
        {
            try
            {
                string errormsg = "";
                if (string.IsNullOrEmpty(txtcaptcha.Text) || txtcaptcha.Text == "" || txtcaptcha.Text == null)
                {
                    errormsg = errormsg + "Please Enter Captcha...! \\n";
                }
                if (txtcaptcha.Text != "" && txtcaptcha.Text.Trim() != Convert.ToString(ViewState["captcha"]))
                {
                    errormsg = errormsg + ". Please Enter Correct Captcha...!  \\n";
                }
                if (string.IsNullOrEmpty(txtusername.Text) || txtusername.Text == "" || txtusername.Text == null)
                {
                    errormsg = errormsg + "Please Enter Username ...! \\n";
                }
                if (txtnewpassword.Text.Trim() == txtusername.Text.Trim())
                {
                    errormsg = errormsg + "Please Enter User Email and Password should not be same...! \\n";
                }
                if (string.IsNullOrEmpty(txtoldpassword.Text) || txtoldpassword.Text == "" || txtoldpassword.Text == null)
                {
                    errormsg = errormsg + "Please Enter Old Password...! \\n";

                }
                if (string.IsNullOrEmpty(txtnewpassword.Text) || txtnewpassword.Text == "" || txtnewpassword.Text == null)
                {
                    errormsg = errormsg + ". Please Enter New Password...!  \\n";
                }
                if (string.IsNullOrEmpty(txtconfirmpassword.Text) || txtconfirmpassword.Text == "" || txtconfirmpassword.Text == null)
                {
                    errormsg = errormsg + ". Please Enter Confirm Password...! \\n";
                }
                if (txtoldpassword.Text != "")
                    OldPassword = PasswordDescription(txtoldpassword.Text.Trim());
                if (txtnewpassword.Text != "")
                    NewPassword = PasswordDescription(txtnewpassword.Text.Trim());
                if (txtconfirmpassword.Text != "")
                    CnfrmPassword = PasswordDescription(txtconfirmpassword.Text.Trim());
                if (Convert.ToString(ViewState["OldPassword"]) != "" && txtoldpassword.Text != "")
                {
                    if (Convert.ToString(ViewState["OldPassword"]) != OldPassword)
                    { 
                        errormsg = errormsg + "Invalid Credentials (User name and Old Password)...! \\n ";
                    }
                    if (Convert.ToString(ViewState["OldPassword"]) == OldPassword)
                    {
                        if (NewPassword == OldPassword)
                        {
                            errormsg = errormsg + "New Password and old Password should not be same...! \\n";
                        }
                    }
                }

                if (txtnewpassword.Text != "" && txtconfirmpassword.Text != "")
                {
                    if (NewPassword != CnfrmPassword)
                    {
                        errormsg = errormsg + "New Password and Confirm New Password should be same...! \\n";
                    }
                    if (NewPassword == CnfrmPassword)
                    {
                        if (!(NewPassword.Any(char.IsLower) && NewPassword.Any(char.IsUpper) &&
                               NewPassword.Any(char.IsDigit) && ValidatePassword(NewPassword.Trim())))
                        {
                            errormsg = errormsg + ". Password must have atleast one upper case letter, one lower case letter, one numer and one special character \\n";

                        }
                        if (NewPassword.Trim().Length < 8)
                        {
                            errormsg = errormsg + ". Password must have 8 characters Minimum \\n";
                        }

                    }
                }
                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
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

        protected void BTNcLEAR_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/ChangePassword.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
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
            var key = asp_hidden.Value;
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