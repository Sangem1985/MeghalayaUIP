using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP
{
    public partial class SetNewPassword : System.Web.UI.Page
    {
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
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
        protected void btnRefresh_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}