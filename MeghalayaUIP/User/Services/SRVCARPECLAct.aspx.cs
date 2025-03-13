using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Services
{
    public partial class SRVCARPECLAct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnaddlog_Click(object sender, EventArgs e)
        {
            // Check if ViewState contains existing data
            DataTable dt = ViewState["ContractorLogs"] as DataTable;

            if (dt == null)
            {
                // Create a new DataTable with required columns
                dt = new DataTable();
                dt.Columns.Add("SlNo", typeof(int));
                dt.Columns.Add("NameOfContractor", typeof(string));
                dt.Columns.Add("AddressOfContractor", typeof(string));
                dt.Columns.Add("ContractPeriodFrom", typeof(string));
                dt.Columns.Add("ContractPeriodTo", typeof(string));
                dt.Columns.Add("NatureOfWork", typeof(string));
                dt.Columns.Add("MaxWorkersEmployed", typeof(string));
                dt.Columns.Add("NumberOfDaysWorked", typeof(string));
                dt.Columns.Add("NumberOfMandaysWorked", typeof(string));
            }

            // Add new row with values from input fields
            DataRow dr = dt.NewRow();
            dr["SlNo"] = dt.Rows.Count + 1;
            dr["NameOfContractor"] = txtnameofcntrtr.Text.Trim();
            dr["AddressOfContractor"] = txtaddrsscntrtr.Text.Trim();
            dr["ContractPeriodFrom"] = txtcntrtprdfrm.Text.Trim();
            dr["ContractPeriodTo"] = txtcntrtprdto.Text.Trim();
            dr["NatureOfWork"] = txtntrofwrk.Text.Trim();
            dr["MaxWorkersEmployed"] = txtmxmwrkrsemplydbyechctnrtr.Text.Trim();
            dr["NumberOfDaysWorked"] = txtnofdyswrkd.Text.Trim();
            dr["NumberOfMandaysWorked"] = txtnofmandyswrkd.Text.Trim();

            dt.Rows.Add(dr);

            // Store updated DataTable in ViewState
            ViewState["ContractorLogs"] = dt;

            // Bind data to GridView
            gvContractorLogs.DataSource = dt;
            gvContractorLogs.DataBind();

            // Clear input fields after adding
            ClearFields();
        }

        // Method to clear input fields
        private void ClearFields()
        {
            txtnameofcntrtr.Text = "";
            txtaddrsscntrtr.Text = "";
            txtcntrtprdfrm.Text = "";
            txtcntrtprdto.Text = "";
            txtntrofwrk.Text = "";
            txtmxmwrkrsemplydbyechctnrtr.Text = "";
            txtnofdyswrkd.Text = "";
            txtnofmandyswrkd.Text = "";
        }

        // Row Deleting event for GridView
        protected void gvContractorLogs_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = ViewState["ContractorLogs"] as DataTable;
            if (dt != null && dt.Rows.Count > e.RowIndex)
            {
                dt.Rows.RemoveAt(e.RowIndex);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["SlNo"] = i + 1;  // Reassign serial numbers sequentially
                }
                ViewState["ContractorLogs"] = dt;
                gvContractorLogs.DataSource = dt;
                gvContractorLogs.DataBind();
            }
        }

    }
}