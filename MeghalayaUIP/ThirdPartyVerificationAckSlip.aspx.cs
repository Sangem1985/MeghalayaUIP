using MeghalayaUIP.BAL.CommonBAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP
{
    public partial class ThirdPartyVerificationAckSlip : System.Web.UI.Page
    {
        MasterBAL masterBAL = new MasterBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count > 0)
            {
                lblPrime.InnerText = "6"; //Convert.ToString(Request.QueryString[0]);
                lblUIDNo.InnerText = "SRVC/2025/102"; //Convert.ToString(Request.QueryString[0]);
                lblDear.InnerText = "TEST";//Convert.ToString(Request.QueryString[1]);
                lblDate.InnerText = "07/03/2025";
                //lblDate.InnerText = Convert.ToString(Request.QueryString[2]);
                //DateTime dateTime = DateTime.UtcNow.Date;
                //lblDate.InnerHtml = dateTime.ToString("dd/MM/yyyy");



            }
        }
    }
}