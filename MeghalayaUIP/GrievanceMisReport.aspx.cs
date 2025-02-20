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
        int DepAvg, DepMax, DepMin, DepMed;
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
                LBLDATETIME.Text = System.DateTime.Now.ToString();
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

                    if (DataBinder.Eval(e.Row.DataItem, "AVG_TIME_TO_RESPOND") != DBNull.Value)
                    {
                        int AvgTtlTime = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "AVG_TIME_TO_RESPOND"));
                        DepAvg += AvgTtlTime;
                    }

                    if (DataBinder.Eval(e.Row.DataItem, "MED_TIME_TO_RESPOND") != DBNull.Value)
                    {
                        int MedTtlTime = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "MED_TIME_TO_RESPOND"));
                        DepMed += MedTtlTime;
                    }

                    if (DataBinder.Eval(e.Row.DataItem, "MIN_TIME_TO_RESPOND") != DBNull.Value)
                    {
                        int MinTtlTime = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "MIN_TIME_TO_RESPOND"));
                        DepMin += MinTtlTime;
                    }

                    if (DataBinder.Eval(e.Row.DataItem, "MAX_TIME_TO_RESPOND") != DBNull.Value)
                    {
                        int MaxTtlTime = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "MAX_TIME_TO_RESPOND"));
                        DepMax += MaxTtlTime;
                    }



                    Label lblDeptid = (Label)e.Row.FindControl("lblDeptid");
                    LinkButton lnkTotal = (LinkButton)e.Row.FindControl("lblTotal");
                    LinkButton lnkPending = (LinkButton)e.Row.FindControl("lblPending");
                    LinkButton lnkRedressed = (LinkButton)e.Row.FindControl("lblRedressed");
                    LinkButton lnkRejected = (LinkButton)e.Row.FindControl("lblRejected");

                    string Departmentname = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DEPT_NAME")).Trim();
                    string txtFDate = "01-06-2024";
                    string txtTDate = Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy"));

                    if (lnkTotal.Text != "0")
                        lnkTotal.PostBackUrl = "GrievanceMisReportDrilldown.aspx?Depatid=" + lblDeptid.Text + "&FromDate=" + txtFDate + "&ToDate=" + txtTDate + "&ViewType=" + ddlType.SelectedItem.Text + "&Status=%" + "&Departmentname=" + Departmentname;

                    if (lnkPending.Text != "0")
                        lnkPending.PostBackUrl = "GrievanceMisReportDrilldown.aspx?Depatid=" + lblDeptid.Text + "&FromDate=" + txtFDate + "&ToDate=" + txtTDate + "&ViewType=" + ddlType.SelectedItem.Text + "&Status=Pending" + "&Departmentname=" + Departmentname;

                    if (lnkRedressed.Text != "0")
                        lnkRedressed.PostBackUrl = "GrievanceMisReportDrilldown.aspx?Depatid=" + lblDeptid.Text + "&FromDate=" + txtFDate + "&ToDate=" + txtTDate + "&ViewType=" + ddlType.SelectedItem.Text + "&Status=Redressed" + "&Departmentname=" + Departmentname;

                    if (lnkRejected.Text != "0")
                        lnkRejected.PostBackUrl = "GrievanceMisReportDrilldown.aspx?Depatid=" + lblDeptid.Text + "&FromDate=" + txtFDate + "&ToDate=" + txtTDate + "&ViewType=" + ddlType.SelectedItem.Text + "&Status=Rejected" + "&Departmentname=" + Departmentname;

                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {

                string Departmentname = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DEPT_NAME")).Trim();
                string txtFDate = "01-06-2024";
                string txtTDate = Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy"));
                //  if(Departmentname)

                e.Row.Font.Bold = true;
                e.Row.Cells[2].Text = "Total";
                LinkButton Totals = new LinkButton();
                //Totals.ForeColor = System.Drawing.Color.Blue;
                //if (Totals.Text != "0")
                //{
                //    Totals.PostBackUrl = "GrievanceMisReportDrilldown.aspx?Depatid=" + Departmentname + "&FromDate=" + txtFDate + "&ToDate=" + txtTDate + "&ViewType=" + ddlType.SelectedItem.Text + "&Status=%" + "&Departmentname=" + Departmentname;
                //}
                //Totals.Text = Total.ToString();
                //e.Row.Cells[3].Text = Total.ToString();
                //e.Row.Cells[3].Controls.Add(Totals);
                e.Row.Cells[3].Text = Total.ToString();
                e.Row.Cells[4].Text = Pending.ToString();
                e.Row.Cells[5].Text = Redress.ToString();
                e.Row.Cells[6].Text = Reject.ToString();

                DepAvg = DepAvg / 17;
                DepMax = DepMax / 17;
                DepMed = DepMed / 17;
                DepMin = DepMin / 17;

                e.Row.Cells[7].Text = DepAvg.ToString();
                e.Row.Cells[8].Text = DepMed.ToString();
                e.Row.Cells[9].Text = DepMin.ToString();
                e.Row.Cells[10].Text = DepMax.ToString();


            }
        }
    }
}