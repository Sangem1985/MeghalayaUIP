using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFO
{
    public partial class CFOHealthWelfare : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rblOwnership_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblOwnership.SelectedItem.Text == "Proprietary")
            {
                Proprietary.Visible = true;
                Partner.Visible = false;
            }
            else if (rblOwnership.SelectedItem.Text == "Partnership")
            {
                Partner.Visible = true;
                Proprietary.Visible = false;
            }

        }

        protected void rblinsection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblinsection.SelectedItem.Text == "Yes")
            {
                InspectionDate.Visible = true;
            }
            else
            {
                InspectionDate.Visible = false;
            }
        }
    }
}