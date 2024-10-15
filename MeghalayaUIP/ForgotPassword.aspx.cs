using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        readonly LoginBAL objloginBAL = new LoginBAL();

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
                    string EmailId = "";
                    EmailId = txtEmail.Text;
                    DataSet ds = new DataSet();
                    ds = objloginBAL.GetDeptUserPwdInfo(txtEmail.Text.Trim().ToString(), "I");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string Username = ds.Tables[0].Rows[0]["Username"].ToString();
                        SMSandMail smsMail = new SMSandMail();
                        string EmailText = "Dear " + ds.Tables[0].Rows[0]["Fullname"].ToString() + ", Please find the below link to reset the password." + "\r\n" +"";
                        try
                        {
                            smsMail.SendEmailSingle(Username, "", "Password Reset Link", EmailText, "", "General",
                                "", "", ds.Tables[0].Rows[0]["Userid"].ToString());
                        }
                        catch (Exception ex)
                        {

                        }
                        finally
                        { }

                    }
                    else
                    {
                        lblmsg0.Text = txtEmail.Text = "Invalid Email Id...!";
                        lblmsg0.ForeColor = System.Drawing.Color.Green;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}