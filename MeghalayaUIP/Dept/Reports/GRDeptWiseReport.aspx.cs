using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.ReportBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Dept.Reports
{
    public partial class GRDeptWiseReport : System.Web.UI.Page
    {
        DeptUserInfo ObjUserInfo = new DeptUserInfo();
        MasterBAL mstrBAL = new MasterBAL();
        ReportBAL reportsBAL = new ReportBAL();
        int TotalApplications, Pending, Redress, Reject;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["DeptUserInfo"] != null)
                {
                    if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
                    {
                        ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
                    }
                    if (hdnUserID.Value == "")
                    {
                        hdnUserID.Value = ObjUserInfo.UserID;
                    }

                    Page.MaintainScrollPositionOnPostBack = true;
                    Failure.Visible = false;
                    success.Visible = false;
                    if (!IsPostBack)
                    {
                        BindDepartments();
                        btnsubmit_Click(sender, e);
                    }
                }
                else
                {
                    Response.Redirect("~/DeptLogin.aspx");
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = "Oops, You've have encountered an error!! please contact administrator.";
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindDepartments()
        {
            try
            {
                ddlDepartment.Items.Clear();
                List<MasterDepartment> objDepartmentModel = new List<MasterDepartment>();
                objDepartmentModel = mstrBAL.GetDepartment("2");
                if (objDepartmentModel != null)
                {
                    ddlDepartment.DataSource = objDepartmentModel;
                    ddlDepartment.DataValueField = "DepartmentId";
                    ddlDepartment.DataTextField = "DepartmentName";
                    ddlDepartment.DataBind();
                    ddlDepartment.Enabled = true;
                }
                else
                {
                    ddlDepartment.DataSource = null;
                    ddlDepartment.DataBind();
                }
                AddSelect(ddlDepartment);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void GVGrievance_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int TotalApplied = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TOTALAPPLICATIONSRCVD"));
                TotalApplications = TotalApplied + TotalApplications;

                int PendingApplications = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PENDING"));
                Pending = PendingApplications + Pending;

                int RedressApplications = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "REDRESS"));
                Redress = RedressApplications + Redress;

                int RejectApplications = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "REJECT"));
                Reject = RejectApplications + Reject;


                Label lblDept = (Label)e.Row.FindControl("lblDeptid");
                LinkButton lnkTotal = (LinkButton)e.Row.FindControl("lblTotal");
                LinkButton lnkPending = (LinkButton)e.Row.FindControl("lblPending");
                LinkButton lnkRedress = (LinkButton)e.Row.FindControl("lblRedressed");
                LinkButton lnkReject = (LinkButton)e.Row.FindControl("lblReject");

              //  string Department = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DEPARTMENT_NAME")).Trim();

                if (lnkTotal.Text != "0")
                    lnkTotal.PostBackUrl = "GRDeptWiseReportDrilldown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&Department=" + ddlDepartment.SelectedItem.Text;

                if (lnkPending.Text != "0")
                    lnkPending.PostBackUrl = "GRDeptWiseReportDrilldown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&Department=" + ddlDepartment.SelectedItem.Text;

                if (lnkRedress.Text != "0")
                    lnkRedress.PostBackUrl = "GRDeptWiseReportDrilldown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&Department=" + ddlDepartment.SelectedItem.Text;

                if (lnkReject.Text != "0")
                    lnkReject.PostBackUrl = "GRDeptWiseReportDrilldown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&Department=" + ddlDepartment.SelectedItem.Text;

                lnkTotal.ForeColor = System.Drawing.Color.Black;
                lnkPending.ForeColor = System.Drawing.Color.Black;
                lnkRedress.ForeColor = System.Drawing.Color.Black;
                lnkReject.ForeColor = System.Drawing.Color.Black;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                string Department = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DEPARTMENT_NAME")).Trim();
                string Deptid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DEPT_ID")).Trim();

                if (ddlDepartment.SelectedItem.Text == "" || ddlDepartment.SelectedItem.Text == null || ddlDepartment.SelectedItem.Text == "--ALL--" || ddlDepartment.SelectedValue == "0")
                {
                    Department = "%";
                    Deptid = "%";
                }
                else
                {
                    Department = ddlDepartment.SelectedItem.Text;
                    Deptid = ddlDepartment.SelectedValue;
                }
                e.Row.Font.Bold = true;
                e.Row.Cells[2].Text = "Total";
                LinkButton Total = new LinkButton();
              //  Total.ForeColor = System.Drawing.Color.Black;
                if (Total.Text != "0")
                {
                    Total.PostBackUrl = "GRDeptWiseReportDrilldown.aspx?Deptid=" + Deptid + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&Department=" + ddlDepartment.SelectedItem.Text;
                }
                Total.Text = TotalApplications.ToString();
                e.Row.Cells[3].Text = TotalApplications.ToString();
                e.Row.Cells[3].Controls.Add(Total);

                e.Row.Cells[4].Text = Pending.ToString();
                e.Row.Cells[5].Text = Redress.ToString();
                e.Row.Cells[6].Text = Reject.ToString();
              
            }
        }

        public void AddSelect(DropDownList ddl)
        {
            try
            {
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem();
                li.Text = "All";
                li.Value = "%";
                ddl.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void FillGridBind()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = reportsBAL.GrievanceDeptReport(ddlDepartment.SelectedValue, txtFormDate.Text, txtToDate.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GVGrievance.DataSource = ds.Tables[0];
                    GVGrievance.DataBind();

                }
                else
                {
                    GVGrievance.DataSource = null;
                    GVGrievance.DataBind();

                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            FillGridBind();
        }
    }
}