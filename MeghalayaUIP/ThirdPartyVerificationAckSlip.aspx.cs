using MeghalayaUIP.BAL.CommonBAL;
using System;
using System.Collections.Generic;
using System.Data;
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
                string UIDNo = Request.QueryString[0].ToString();
                string TypeOfApplication = Request.QueryString[1].ToString();
                DataSet dsnew = new DataSet();
                dsnew = masterBAL.GetAcknowlegementDetails(UIDNo, TypeOfApplication);
                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    lblPrime.InnerText = Convert.ToString(dsnew.Tables[0].Rows[0]["APPROVALCOUNT"]);
                    lblUIDNo.InnerText = Convert.ToString(dsnew.Tables[0].Rows[0]["UIDNO"]);
                    lblUnitName.InnerText = Convert.ToString(dsnew.Tables[0].Rows[0]["NAMEOFUNIT"]);
                    lblDate.InnerText = Convert.ToString(dsnew.Tables[0].Rows[0]["APPLIEDDATE"]);
                }
                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[1].Rows.Count > 0)
                {
                    grdApprovals.DataSource = dsnew.Tables[1];
                    grdApprovals.DataBind();
                }
            }
            else Response.Redirect("~/ViewCertifcateDetails.aspx");
        }
    }
}