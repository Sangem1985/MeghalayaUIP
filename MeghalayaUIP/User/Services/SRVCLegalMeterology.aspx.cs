using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Services
{
    public partial class SRVCLegalMeterology : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rblRegNoFactEst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblRegNoFactEst.SelectedValue == "Y")
            {
                divRegistration.Visible = true;
            }
            
        }

        protected void rblMunicipalADC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblMunicipalADC.SelectedValue == "Y")
            {
                divADCLicense.Visible = true;
            }
        }

        protected void rblpartnership_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblpartnership.SelectedValue=="Y")
            {
                divpartnership.Visible = true;
            }
        }

        protected void rblcompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblcompany.SelectedValue == "Y")
            {
                divcompany.Visible = true;
            }
        }

        protected void rblFinance_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblFinance.SelectedValue == "Y")
            {
                divFinanceBank.Visible = true;
                divGiveInstitute.Visible = true;
            }
        }

        protected void rblLicdealer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblLicdealer.SelectedValue == "Y")
            {
                divapplieddealer.Visible = true;
            }
        }
    }
}