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
            else { divRegistration.Visible = false; }

        }

        protected void rblMunicipalADC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblMunicipalADC.SelectedValue == "Y")
            {
                divADCLicense.Visible = true;
            }
            else { divADCLicense.Visible = false; }
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

        protected void rblFinance_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblFinance.SelectedValue == "Y")
            {
                divFinanceBank.Visible = true;
                divGiveInstitute.Visible = true;
            }
            else 
            { 
                divFinanceBank.Visible = false;
                divGiveInstitute.Visible = false;
            }
        }

        protected void rblLicdealer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblLicdealer.SelectedValue == "Y")
            {
                divapplieddealer.Visible = true;
            }
            else { divapplieddealer.Visible = false; }
        }
    }
}