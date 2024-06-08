using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;

namespace MeghalayaUIP
{
    public partial class ViewCertifcateDetails : System.Web.UI.Page
    {
        MasterBAL masterBAL = new MasterBAL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (ddlTypeApplication.SelectedValue.ToString() == "0") 
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Application Type')", true);
                return;
            }
            string TypeOfApplication = ddlTypeApplication.SelectedValue.ToString();
            string UIDNo = txtUIDNo.Value.ToString();
            string UnitName = txtUnitName.Value.ToString();

            DataSet dsnew = new DataSet();
            dsnew = masterBAL.GetCertifcateDetails(TypeOfApplication, UIDNo, UnitName);
            if (dsnew.Tables.Count > 0)
            {
                if (dsnew.Tables[0].Rows.Count > 0)
                {
                    gvDetails.DataSource = dsnew.Tables[0];
                    gvDetails.DataBind();
                    divGrid.Visible = true;
                }
            }
            else 
            {
                gvDetails.DataSource = null;
                gvDetails.DataBind();
                divGrid.Visible = true;
            }
        }
    }
}