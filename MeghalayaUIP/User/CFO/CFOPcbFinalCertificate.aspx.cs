using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFO
{
    public partial class CFOPcbFinalCertificate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblFileNo.Text = "MPCB/TB-CON ONLINE-61/2021/2021-2022/2";
            lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy"); 
            // lblApplicationNo.Text = "CFO/1001/2025";
            lblPollutionBoard.Text = "CONSENT TO OPERATE";
            lblName.Text = "M/S RI KALENG LIMESTONE MINE";
            lbldistrict.Text = "Limestone Mineat at Ri Kaleng, Lynti Dkhar, Sohbar Sirdarship, East Khasi Hills";
            lblMine.Text = "M/S RI KALENGLIMESTONE MINE";
            Date.Text = "31 August 2022";
            lblapril.Text = "ML/SEIAA/MIN/EKH/P-41/2020/8/102 Dt. 22ndApril, 2021";
            lblshoba.Text = "M/S RI KALENG LIMESTONE MINE,";
        }
        
    }
}