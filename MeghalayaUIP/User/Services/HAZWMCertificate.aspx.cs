using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Services
{
    public partial class HAZWMCertificate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            lblRecipientName.Text = "Atharva";
            lblRecipientAddress.Text = "Door.No:1-34-29, Danal Dasilk,Songsak, EastGaroHills";
            lblCompanyName.Text = "Digalpara, Rerapara, South west Garo Hills";
            lblApplicationNumber.Text = "IMA1001273197320241001";
            lblApplicationDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            lblValidityYears.Text = "1";
            lblStartDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            lblEndDate.Text = DateTime.Now.AddYears(1).AddDays(-1).ToString("dd-MM-yyyy");
            lblGMInfo.Text = "South west Garo Hills";
            //lblDirector.Text = "Director desgn";
            //lblFrstPrsn.Text = "First Person";
            //lblScndPrsn.Text = "Second Person";
        }
    }
}