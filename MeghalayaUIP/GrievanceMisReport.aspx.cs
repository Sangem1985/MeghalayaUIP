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
    public partial class GrievanceMisReport : System.Web.UI.Page
    {
        MasterBAL masterBAL = new MasterBAL();

        int Total;
        int Pending;
        int Redress;
        int Reject;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Binddata();
            }
        }
        public void Binddata()
        {
            try
            {
                DataSet dsnew = new DataSet();
                string fdate = txtFDate.Value.ToString();
                string tdate = txtTDate.Value.ToString();
                string Type = ddlType.SelectedValue.ToString();
                dsnew = masterBAL.GetGrievanceMisReport(fdate, tdate, Type);
                if (dsnew.Tables.Count > 0)
                {
                    if (dsnew.Tables[0].Rows.Count > 0)
                    {
                        gvDetails.DataSource = dsnew.Tables[0];
                        gvDetails.DataBind();
                    }
                }
                else
                {
                    gvDetails.DataSource = null;
                    gvDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Binddata();
        }

        protected void gvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (DataBinder.Eval(e.Row.DataItem, "DEPT_ID").ToString() != "")
                {
                    
                    int Total1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TOTALAPPLICATIONSRCVD"));
                    Total = Total1 + Total;

                    int Pending1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PENDING"));
                    Pending = Pending1 + Pending;

                    int Redress1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "REDRESS"));
                    Redress = Redress1 + Redress;

                    int Reject1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "REJECT"));
                    Reject = Reject1 + Reject;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Font.Bold = true;
                e.Row.Cells[1].Text = "Total";
                e.Row.Cells[2].Text = Total.ToString();
                e.Row.Cells[3].Text = Pending.ToString();
                e.Row.Cells[4].Text = Redress.ToString();
                e.Row.Cells[5].Text = Reject.ToString();
            }
        }
    }
}