using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Services
{
    public partial class SWMCertificate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblFileNo.Text = "File Number";
            lblAuthorizationNo.Text = "Authorization Number";
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblApplicationNo.Text = "Application Number"; 
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MM/yyyy"); 

            lblPollutionBoard.Text = "Pollution Board"; 
            lblApplicantName.Text = "Applicant Name"; 
            lblOfficeAddress.Text = "Office Address"; 
            lblFacilityAddress.Text = "Facility Address"; 

            lblPollutionCommittee.Text = "UT Pollution Control Board"; 

            lblIssueDate.Text = DateTime.Now.ToString("dd/MM/yyyy"); 
            lblIssuePlace.Text = "Place Of Issue";


        }
    }
}