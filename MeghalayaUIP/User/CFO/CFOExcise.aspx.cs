using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFO
{
    public partial class CFOExcise : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rblConvicted_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblConvicted.SelectedItem.Text == "Yes")
            {
                convictedlaw.Visible = true;
            }
            else
            {
                convictedlaw.Visible = false;
            }
        }

        protected void rblviolation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblviolation.SelectedItem.Text == "Yes")
            {
                txtlaw.Visible = true;
            }
            else
            {
                txtlaw.Visible = false;
            }
        }

        protected void rblgoverment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblgoverment.SelectedItem.Text == "Yes")
            {
                Excisedept.Visible = true;
            }
            else
            {
                Excisedept.Visible = false;
            }
        }

        protected void rblMRPRS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblMRPRS.SelectedItem.Text == "Yes")
            {
                MRPGRID.Visible = true;
            }
            else
            {
                MRPGRID.Visible = false;
            }
        }

        protected void rblBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblBrand.SelectedItem.Text == "Yes")
            {
                Brands.Visible = true;
                TodateReg.Visible = true;
            }
            else
            {
                Brands.Visible = false;
                TodateReg.Visible = false;
            }
        }
    }
}