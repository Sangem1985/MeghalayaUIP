using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Payments
{
    public partial class PaymentFailurePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["error"] != null)
            {
                string code = Request.QueryString["error"].ToString();
                string description = Request.QueryString["errordesc"].ToString();
                string source = Request.QueryString["errorsource"].ToString();
                string step = Request.QueryString["errorstep"].ToString();
                string reason = Request.QueryString["errorreason"].ToString();
            }
        }
    }
}