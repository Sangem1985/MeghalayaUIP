using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Dashboard
{
    public partial class OpenDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlistcler_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainDashboard.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("DashboardDrill.aspx");
        }
    }
}