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
    public partial class IncEligibilty : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void showincentive_Click(object sender, EventArgs e)
        {
            string category = ddlCategory.SelectedItem.Text;
            string sector = ddlSector.SelectedItem.Text;
            string expansionType = rblenterprenrtype.SelectedItem.Text;
            string pwd = cbphysicalHandicapped.Checked ? "Yes" : "No";
            string area = ddlSelectArea.SelectedItem.Text;

            ds = mstrBAL.GetEligibleInc(category,sector, expansionType,pwd,area);
            if (ds != null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
            {
                grdDetails.Visible = true;
                fail.Visible = false;
                Failure.Visible = false;
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
            }
            else
            {
                Failure.Visible = true;
                lblmsg0.Text = "No Eligible Incentives Available";
                grdDetails.Visible = false;
                fail.Visible = true;
            }

        }
    }
}