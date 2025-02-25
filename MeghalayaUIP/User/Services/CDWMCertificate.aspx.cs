using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Services
{
    public partial class CDWMCertificate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblApplicationNumber.Text = "123456";
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblStatePolutnBoard.Text = "State";
            lblAuthorizedPerson.Text = "Authorized Person";
            lblOfficeAddress.Text = "Office Address";
            lblFacilityLocation.Text = "Factory Location";
            lblValidityDate.Text = "31/12/2025";
            lblStatePolutn2.Text = "State Board";
            lblIssueDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblIssuePlace.Text = "State Capital";
        }
    }
}