using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
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
                String UserID = "", result = "";
                if (ViewState["captcha"].ToString() != txtcaptcha.Text.Trim().TrimStart())
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid Captcha Code !!.');", true);
                    FillCapctha();
                    lblmsg.Text = "Invalid Captcha Code....!!";
                    success.Visible = false;
                    Failure.Visible = true;
                    txtcaptcha.Text = "";
                    return;
                }
                if (string.IsNullOrEmpty(txtusername.Text) || string.IsNullOrEmpty(txtoldpassword.Text))
                {
                    lblmsg0.Text = "Please Enter Username And Old Password...!";
                    string message = "alert('" + lblmsg0.Text + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    FillCapctha();
                    success.Visible = false;
                    Failure.Visible = true;
                }
                if (string.IsNullOrEmpty(txtnewpassword.Text) || string.IsNullOrEmpty(txtconfirmpassword.Text))
                {
                    lblmsg0.Text = "Please Enter New Password And Confirm Password...!";                   
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "AnotherFunction();", true);
                    Failure.Visible = true;
                    success.Visible = false;                  
                    FillCapctha();
                }
                if (txtnewpassword.Text.Trim() != txtconfirmpassword.Text.Trim())
                {
                    lblmsg.Text = "New Password & Confirm Password Sholud be same....!";
                    FillCapctha();
                    string message = "alert('" + lblmsg.Text + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    success.Visible = false;
                    Failure.Visible = true;
                }
                //else
                //{
                //    lblmsg.Text = "New Password & Confirm Password Matched....!";                   
                //    string message = "alert('" + lblmsg.Text + "')";
                //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                //    success.Visible = true;
                //    Failure.Visible = false;
                //}


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


                    UserInfo ObjUserInfo;
                    ObjUserInfo = objloginBAL.GetUserInfo(UserID, txtoldpassword.Text.Trim(), getclientIP());
                    // ds = objcomBal.GetUserPass(UserID, Password.ToString(), txtoldpassword.Text.Trim());
                    if (ObjUserInfo != null && ObjUserInfo.Userid != null)
                    {
                        result = objcomBal.ChangeUserPassword(hdnUserID.Value, UserID, txtoldpassword.Text.Trim(), txtnewpassword.Text.Trim(), getclientIP());
                        if (result != "")
                        {
                            lblmsg.Text = "Password Successfully Changed And Login With New Password..!";
                            success.Visible = true;
                            Failure.Visible = false;
                            trsubmittion.Visible = false;
                            string message = "alert('" + lblmsg.Text + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                            Response.Redirect("~/login.aspx");
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
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
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

        protected void txtnewpassword_TextChanged(object sender, EventArgs e)
        {
            if (txtnewpassword.Text.Trim() == txtusername.Text.Trim())
            {
                lblmsg0.Text = "User Email and Password should not be same";
                success.Visible = false;
                Failure.Visible = true;
                txtnewpassword.Text = "";
                txtcaptcha.Text = "";
                FillCapctha();
                return;
            }
            if (txtnewpassword.Text.Trim().Length < 8)
            {
                lblmsg0.Text = "Password must have 8 characters Minimum";
                success.Visible = false;
                Failure.Visible = true;
                txtnewpassword.Text = "";
                txtcaptcha.Text = "";
                FillCapctha();
                return;
            }
            if (!(txtnewpassword.Text.Any(char.IsLower) && txtnewpassword.Text.Any(char.IsUpper) &&
                       txtnewpassword.Text.Any(char.IsDigit) && ValidatePassword(txtnewpassword.Text.Trim())))
            {

                lblmsg0.Text = "Password must have atleast one upper case letter, one lower case letter, one numer and one special character";
                success.Visible = false;
                Failure.Visible = true;
                txtnewpassword.Text = "";
                txtcaptcha.Text = "";
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
    }
}