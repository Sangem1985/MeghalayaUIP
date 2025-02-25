using Org.BouncyCastle.Crypto.Tls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Services
{
    public partial class PWMCertificate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblCertificateNo.Text = "Certificate Number";  
            lblDate.Text = DateTime.Now.ToString("dd MMMM yyyy");
            lblRecipientName.Text = "Recipeint Name";
            lblRecipientAddress1.Text = "Address 1";
            lblRecipientAddress2.Text = "Address 2";
            lblRecipientAddress3.Text = "Address 3";
            lblReference.Text = "Reference No.";
            lblCompanyName.Text = "Company Name";
            lblCompanyAddress.Text = "Company Address";
            lblManufacturedProduct.Text = "Manufactured Products";
            lblValidityYears.Text = "Validity Years";
            lblDeputyCommissionerDistrict.Text = "Deputy Commissoner District";
            lblGeneralInfo.Text = "General Information";
        }
    }
}