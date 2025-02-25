using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Services
{
    public partial class NHAZWMCertificate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            lblRecipientName.Text = "Recipient Name";
            lblRecipientAddress.Text = "Recipient Address";
            lblCompanyName.Text = "Company Name";
            lblApplicationNumber.Text = "Application Number";
            lblApplicationDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            lblStartDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            lblEndDate.Text = DateTime.Now.AddYears(5).ToString("dd-MM-yyyy");
            lblGMInfo.Text = "GM infor";
            lblDirector.Text = "Director desgn";
            lblFrstPrsn.Text = "First Person";

        }
    }
}