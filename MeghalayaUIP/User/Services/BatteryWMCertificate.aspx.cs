using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Services
{
    public partial class BatteryWMCertificate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblNo.Text = "MPCB / BMH - 3(2019) / 2019 - 2020 / (58) /";
            lblIssuePlace.Text = "Shilong";
            lblIssueDate.Text = "February 2022";
            lblCompanyName.Text = "SHREE LALIT AUTOMOBILES";
            lblLocation.Text = "DEMTHRING, SHILLONG";
            lblGSTNo.Text = "17BAOPS4205A1ZW";
            lblStartDate.Text = "1st January 2022";
            lblEndDate.Text = "31st December 2027";
        }
    }
}