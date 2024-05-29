using MeghalayaUIP.User.CFE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace MeghalayaUIP.User
{
    public partial class UserDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void linkPreReg_Click(object sender, EventArgs e)
        {
            string url = "~/User/PreReg/IndustryRegistrationUserDashboard.aspx";
            Response.Redirect(url);
        }

        protected void linkCFE_Click(object sender, EventArgs e)
        {
            string url = "~/User/CFE/CFEUserDashboard.aspx";
            Response.Redirect(url);
        }
    }
}