using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFE
{
    public partial class CFEPcbCertificate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblFileNo.Text = "MPCB/TB-ONLINE-CTE(EKHD)/2021-2022/15";
            lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            // lblApplicationNo.Text = "CFO/1001/2025";
            lblPollutionBoard.Text = "CONSENT TO ESTABLISH";
            lblName.Text = "M/S RI KALENG LIMESTONE MINE";
            lbldistrict.Text = "2.05 Ha.Limestone Mineat at Ri Kaleng, Lynti Dkhar, Sohbar Sirdarship, East Khasi Hills District";
            lblTPA.Text = "2,01,150 TPA";
            lblAmount.Text = "Rs. 22,00,000/- (Rupees Twenty Two Lakhs) only";
            lblTerm.Text = "terms and conditions";
            lblMine.Text = "M/S RI KALENGLIMESTONE MINE";
            Date.Text = "30th September 2022 ";
            lblapril.Text = "ML/SEIAA/MIN/EKH/P-41/2020/8/102 Dt. 22nd April, 2021";
            lblshoba.Text = "M/S RI KALENG LIMESTONE MINE,";
        }
    }
}