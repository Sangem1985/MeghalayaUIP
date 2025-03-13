using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Services
{
    public partial class SRVCARBonusPaymentAct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnaddlog_Click(object sender, EventArgs e)
        {
            // Check if ViewState contains existing data
            DataTable dt = ViewState["BonusLogs"] as DataTable;

            if (dt == null)
            {
                // Create new DataTable with the required columns
                dt = new DataTable();
                dt.Columns.Add("SlNo", typeof(int));
                dt.Columns.Add("TotalAmountBonus", typeof(string));
                dt.Columns.Add("SettlementDetails", typeof(string));
                dt.Columns.Add("BonusPercentage", typeof(string));
                dt.Columns.Add("TotalBonusPaid", typeof(string));
                dt.Columns.Add("PaymentDate", typeof(string));
                dt.Columns.Add("BonusPaidToAll", typeof(string));
                dt.Columns.Add("Remarks", typeof(string));
            }

            // Add new row with values from text fields
            DataRow dr = dt.NewRow();
            dr["SlNo"] = dt.Rows.Count + 1;
            dr["TotalAmountBonus"] = txtamntbns1965.Text.Trim();
            dr["SettlementDetails"] = txtsettlemnt1947.Text.Trim();
            dr["BonusPercentage"] = txtpercentagebnstopaid.Text.Trim();
            dr["TotalBonusPaid"] = txtttlbnspaid.Text.Trim();
            dr["PaymentDate"] = txtpmntdate.Text.Trim();
            dr["BonusPaidToAll"] = txtbnspaidtoall.Text.Trim();
            dr["Remarks"] = txtremarks.Text.Trim();

            dt.Rows.Add(dr);


            // Store updated DataTable in ViewState
            ViewState["BonusLogs"] = dt;

            // Bind data to GridView
            gvLogs.DataSource = dt;
            gvLogs.DataBind();

            // Clear input fields after adding
            ClearFields();
        }

        // Method to clear input fields
        private void ClearFields()
        {
            txtamntbns1965.Text = "";
            txtsettlemnt1947.Text = "";
            txtpercentagebnstopaid.Text = "";
            txtttlbnspaid.Text = "";
            txtpmntdate.Text = "";
            txtbnspaidtoall.Text = "";
            txtremarks.Text = "";
        }

        protected void GvLogs_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = ViewState["BonusLogs"] as DataTable;
            if (dt != null && dt.Rows.Count > e.RowIndex)
            {
                dt.Rows.RemoveAt(e.RowIndex);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["SlNo"] = i + 1;  // Reassign serial numbers sequentially
                }
                ViewState["BonusLogs"] = dt;
                gvLogs.DataSource = dt;
                gvLogs.DataBind();
            }
        }

    }
}