using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Services
{
    public partial class SRVCLegalMeterology42 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rblState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblState.SelectedValue == "Y")
            {
                divLicNo.Visible = true;
                divWeight.Visible = true;
            }
        }

        protected void rblDealer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblDealer.SelectedValue == "Y")
            {
                divDealerLic.Visible = true;
            }
            else { divDealerLic.Visible = false; }
        }

        protected void rblpartnership_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblpartnership.SelectedValue=="Y")
            {
                divpartnership.Visible = true;
            }
            else { divpartnership.Visible = false; }
        }

        protected void rblcompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblcompany.SelectedValue == "Y")
            {
                divcompany.Visible = true;
            }
            else { divcompany.Visible = false; }
        }

        protected void rblLicADC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblLicADC.SelectedValue=="Y")
            {
                divDateReg.Visible = true;
                divCutRegNo.Visible = true;
            }
            else 
            { 
                divDateReg.Visible = false;
                divCutRegNo.Visible = false;
            }
        }

        protected void rblFactRegNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblFactRegNo.SelectedValue=="Y")
            {
                divRegistration.Visible = true;
            }
            else { divRegistration.Visible = false; }
        }
    }
}