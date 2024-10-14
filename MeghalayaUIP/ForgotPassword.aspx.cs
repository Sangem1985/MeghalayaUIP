using MeghalayaUIP.BAL.CommonBAL;
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
                if (string.IsNullOrEmpty(txtEmail.Text))
                {
                    lblmsg0.Text = "Please provide EmailId....!";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "AnotherFunction();", true);
                    Failure.Visible = true;
                    FillCapctha();
                }
                else if (string.IsNullOrEmpty(txtcaptcha.Text))
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
                    Failure.Visible = true;
                    FillCapctha(); txtcaptcha.Text = "";

                }
                else
                {
                    string EmailId = "";
                    EmailId = txtEmail.Text;
                    DataSet ds = new DataSet();
                    ds = objloginBAL.ForgetPassword(txtEmail.Text);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string Userpassword = ds.Tables[0].Rows[0]["EMAILID"].ToString();
                        String password = ds.Tables[0].Rows[0]["pwd"].ToString();
                        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                        mail.To.Add(Userpassword);

                        mail.From = new MailAddress(Userpassword, ":: MiPASS ::", System.Text.Encoding.UTF8);
                        mail.Subject = "Enterprenuer -Forgot Password Login Credentials -";
                        mail.SubjectEncoding = System.Text.Encoding.UTF8;  //ds.Tables[0].Rows[0]["Password"].ToString()
                        mail.Body = "Dear " + ds.Tables[0].Rows[0]["Fullname"].ToString() + " " + ds.Tables[0].Rows[0]["EntityName"].ToString() + "<br><br>  <H2>MiPASS MIS  - Login Credentials</H2><br> Welcome to MiPASS. <br/> Dear <b> " + ds.Tables[0].Rows[0]["Fullname"].ToString() + " " + ds.Tables[0].Rows[0]["EntityName"].ToString() + "</b>,<br/> Please use the following credentials to Login. <br><br> USER ID: " + ds.Tables[0].Rows[0]["InvesterId"].ToString() + "<br> <br> Password : " + password + "<br> <br> URL:  <a href='https://invest.meghalaya.gov.in' target='_blank' > MiPASS </a> <br> <br> Please Login by clicking the above link.<br><br>Regards<br>MiPASS";
                        mail.BodyEncoding = System.Text.Encoding.UTF8;

                        mail.IsBodyHtml = true;
                        mail.Priority = MailPriority.High;

                        SmtpClient client = new SmtpClient();
                        //Add the Creddentials- use your own email id and password

                        client.Credentials = new System.Net.NetworkCredential(Userpassword, "MiPass");

                        client.Port = 587; // Gmail works on this port
                        client.Host = "smtp.gmail.com";
                        client.EnableSsl = true;
                        client.Send(mail);
                        //MailMessage Mail = new MailMessage("AKHILAKKI058@GMAIL.COM", txtEmail.Text);
                        //Mail.Subject = "Your Password...!";
                        //Mail.Body = string.Format("Hello : <h1>{0}</h1> is your Email id <br/> Your Password is <h1>{1}</h1>", Userpassword, password);
                        //Mail.IsBodyHtml = true;
                        //SmtpClient smtp = new SmtpClient();
                        //smtp.Host = "smtp.gmail.com";
                        //smtp.EnableSsl = true;
                        //NetworkCredential Nc = new NetworkCredential();
                        //Nc.UserName = "AKHILAKKI058@GMAIL.COM";
                        //Nc.Password = "Yadi@12";
                        //smtp.UseDefaultCredentials = true;
                        //smtp.Credentials = Nc;
                        //smtp.Port = 578;
                        //smtp.Send(Mail);
                        //lblmsg.Text = "Your Password has been sent to" + txtEmail.Text;
                        //lblmsg.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblmsg0.Text = txtEmail.Text = "-This Email id not exist in the database";
                        lblmsg0.ForeColor = System.Drawing.Color.Green;
                    }
                    //   string from = "";
                    //  string to = ds.Tables[0].Rows[0]["emailid"].ToString();
                    //  System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                    //  mail.To.Add(to);
                    ////  mail.From = new (from, ":: Meghalaya ::", System.Text.Encoding.UTF8);

                    //  mail.Subject = "Enterprenuer -Forgot Password Login Credentials -";


                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}