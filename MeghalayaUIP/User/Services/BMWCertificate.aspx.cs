using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Services
{
    public partial class BMWCertificate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            lblFileNo.Text = "MPCB/BMW-414/2020/2022-2023/82";
            lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            lblPollutionBoard.Text = "Atharva Primary Health Centre, East Jaintia Hills District ";
            lblBMW.Text = " 10 (Thirty) beds";
            lblwaste.Text = " 31 January, 2026";

            lblAutheration.Text = "The Authorised person / institution shall submit an Annual Report in prescribed Form-IV on or before 30th June every year for the period from January to December of the preceding year, and shall report any accident in Form - I immediately.";
            lblrenewal.Text = " The Authorised person / institution shall apply for renewal of the Authorisation in prescribed Form-II three months before its expiry date.";

            lblPCB.Text = " The unit shall have to apply for Consent to Establish and Consent to Operate from the prescribed authority i.e., Meghalaya State Pollution Control Board.";
        }
    }
}