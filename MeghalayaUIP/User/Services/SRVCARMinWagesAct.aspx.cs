using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Services
{
    public partial class SRVCARMinWagesAct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["ActsSelected"]) != "")
            {
                if (Convert.ToString(Session["ActsSelected"]).Contains("5"))
                {

                }
                else
                {
                    if (Convert.ToString(Request.QueryString[0]) == "N")
                        Response.Redirect("~/User/Services/SRVCARBonusPaymentAct.aspx?Next=N");
                    else
                        Response.Redirect("~/User/Services/SRVCARMBAct.aspx?Previous=P");
                }

            }

        }
        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User/Services/SRVCARMBAct.aspx?Previous=P");

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User/Services/SRVCARBonusPaymentAct.aspx?Next=N");
        }
    }
}