using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Services
{
    public partial class EWMManfctrRefCertificate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblAuthorizationNo.Text = "Authorization number"; 
            lblIssueDate.Text = DateTime.Now.ToString("dd-MM-yyyy");

            lblCompanyName.Text = "Comapany Name";
            lblCompanyLocation.Text = "Company Location";
            lblPremisesAddress.Text = "Premise address";

            lblEwasteQuantity.Text = "n kg per month";
            lblEwasteNature.Text = "E waste nature";

            lblValidFrom.Text = "01-01-2024";
            lblValidTo.Text = "31-12-2026";

            lblDisposalLocation.Text = "Disposal Address";

            lblSingature.Text = "Signature";
            lblDesignation.Text = "Desingation";
            lblSignatureDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }
    }
}