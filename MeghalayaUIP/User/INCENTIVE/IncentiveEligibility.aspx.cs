using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.INCENTIVE
{
    public partial class IncentiveEligibility : System.Web.UI.Page
    {
        int index;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Link1_Click(object sender, EventArgs e)
        {
            MVprereg.ActiveViewIndex = 0;
        }

        protected void Link2_Click(object sender, EventArgs e)
        {
            MVprereg.ActiveViewIndex = 1;
        }

        protected void MVprereg_ActiveViewChanged(object sender, EventArgs e)
        {
            index = MVprereg.ActiveViewIndex;
            if (index == 0)
            { Link1.CssClass = "Underlined1"; }
            if (index == 1)
            { Link2.CssClass = "Underlined2"; }
            //if (index == 2)
            //{ Link3.CssClass = "Underlined3"; }
        }
    }
}