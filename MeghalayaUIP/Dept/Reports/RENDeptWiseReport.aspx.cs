using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.ReportBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Dept.Reports
{
    public partial class RENDeptWiseReport : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        ReportBAL reportsBAL = new ReportBAL();
        int ApprovalsApplied, QueryRaised, BeforeDate, AfterDate, PreRejected, Paymentpending, ScrutinyCompleted, Before, After, DeptApproved, Rejected;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDepartments();
                btnsubmit_Click(sender, e);
            }
        }
        protected void BindDepartments()
        {
            try
            {
                ddldepartment.Items.Clear();
                List<MasterDepartment> objDepartmentModel = new List<MasterDepartment>();
                objDepartmentModel = mstrBAL.GetDepartment("2");
                if (objDepartmentModel != null)
                {
                    ddldepartment.DataSource = objDepartmentModel;
                    ddldepartment.DataValueField = "DepartmentId";
                    ddldepartment.DataTextField = "DepartmentName";
                    ddldepartment.DataBind();
                    ddldepartment.Enabled = true;
                }
                else
                {
                    ddldepartment.DataSource = null;
                    ddldepartment.DataBind();
                }
                AddSelect(ddldepartment);
            }
            catch (Exception ex)
            {
                throw ex;
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
        public void BindRENDeptReports()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = reportsBAL.RENDeptWiseReport(ddldepartment.SelectedValue, txtFormDate.Text, txtToDate.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GVRENReport.DataSource = ds.Tables[0];
                    GVRENReport.DataBind();
                }
                else
                {
                    GVRENReport.DataSource = null;
                    GVRENReport.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            BindRENDeptReports();
            divPrint1.Visible = true;
        }

        protected void GVRENReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int Approval = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "APPROVALIS_APPLIED"));
                ApprovalsApplied = Approval + ApprovalsApplied;

                int Query = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "QUERY_RAISED"));
                QueryRaised = Query + QueryRaised;

                int BeforeDue = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "SCRUTINY_BEFOREDUEDATE"));
                BeforeDate = BeforeDue + BeforeDate;

                int AfterDue = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "SCRUTINY_AFTERDUEDATE"));
                AfterDate = AfterDue + AfterDate;

                int ScrutinyReject = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PAYMENT_PENDING"));
                PreRejected = ScrutinyReject + PreRejected;

                int Payment = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PAYMENT_PENDING"));
                Paymentpending = Payment + Paymentpending;

                int Completed = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "SCRUTINY_COMPLETED"));
                ScrutinyCompleted = Completed + ScrutinyCompleted;

                int BeforeDueDate = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "APPROVALUNDER_PROCESSBEFOREDATE"));
                Before = BeforeDueDate + Before;

                int AfterDueDate = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "APPROVALUNDER_PROCESSAFTERDATE"));
                After = AfterDueDate + After;

                int Approved = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DEPARTMENT_APPROVED"));
                DeptApproved = Approved + DeptApproved;

                int Reject = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "REJECTED"));
                Rejected = Reject + Rejected;

                Label lblDept = (Label)e.Row.FindControl("lblDepartmentid");
                LinkButton lnkApplied = (LinkButton)e.Row.FindControl("lblApprovalApplied");
                LinkButton lnkQueryRaised = (LinkButton)e.Row.FindControl("lblQueryRaised");
                LinkButton lnkScBeforeDate = (LinkButton)e.Row.FindControl("lblScrutinyBeforeDate");
                LinkButton lnkScAfterDate = (LinkButton)e.Row.FindControl("lblScrutinyAfterDate");
                LinkButton lnkScrRejected = (LinkButton)e.Row.FindControl("lblPreRejected");
                LinkButton lnkPaymentPending = (LinkButton)e.Row.FindControl("lblPaymentPending");
                LinkButton lnkScCompleted = (LinkButton)e.Row.FindControl("lblScrutinyCompleted");
                LinkButton lnkBeforeApprovalDate = (LinkButton)e.Row.FindControl("lblApprovalBeforeDate");
                LinkButton lnkApprovalDate = (LinkButton)e.Row.FindControl("lblApprovalDate");
                LinkButton lnkDeptApproved = (LinkButton)e.Row.FindControl("lblDepatApproved");
                LinkButton lnkRejected = (LinkButton)e.Row.FindControl("lblRejected");

                string Department = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DEPARTMENT_NAME")).Trim();

                if (lnkApplied.Text != "0")
                    lnkApplied.PostBackUrl = "RENDeptWiseReportDrillDown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&Department=" + ddldepartment.SelectedItem.Text + "&ViewType=Approval";

                if (lnkQueryRaised.Text != "0")
                    lnkQueryRaised.PostBackUrl = "RENDeptWiseReportDrillDown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&Department=" + ddldepartment.SelectedItem.Text + "&ViewType=QueryRaised";

                if (lnkScBeforeDate.Text != "0")
                    lnkScBeforeDate.PostBackUrl = "RENDeptWiseReportDrillDown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&Department=" + ddldepartment.SelectedItem.Text + "&ViewType=BeforeDue";

                if (lnkScAfterDate.Text != "0")
                    lnkScAfterDate.PostBackUrl = "RENDeptWiseReportDrillDown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&Department=" + ddldepartment.SelectedItem.Text + "&ViewType=AfterDue";

                if (lnkScrRejected.Text != "0")
                    lnkScrRejected.PostBackUrl = "RENDeptWiseReportDrillDown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&Department=" + ddldepartment.SelectedItem.Text + "&ViewType=ScrutinyReject";

                if (lnkPaymentPending.Text != "0")
                    lnkPaymentPending.PostBackUrl = "RENDeptWiseReportDrillDown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&Department=" + ddldepartment.SelectedItem.Text + "&ViewType=PaymentPending";

                if (lnkScCompleted.Text != "0")
                    lnkScCompleted.PostBackUrl = "RENDeptWiseReportDrillDown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&Department=" + ddldepartment.SelectedItem.Text + "&ViewType=ScrutinyCompleted";

                if (lnkBeforeApprovalDate.Text != "0")
                    lnkBeforeApprovalDate.PostBackUrl = "RENDeptWiseReportDrillDown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&Department=" + ddldepartment.SelectedItem.Text + "&ViewType=BeforeDueDate";

                if (lnkApprovalDate.Text != "0")
                    lnkApprovalDate.PostBackUrl = "RENDeptWiseReportDrillDown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&Department=" + ddldepartment.SelectedItem.Text + "&ViewType=AfterDueDate";

                if (lnkDeptApproved.Text != "0")
                    lnkDeptApproved.PostBackUrl = "RENDeptWiseReportDrillDown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&Department=" + ddldepartment.SelectedItem.Text + "&ViewType=DeptApproved";

                if (lnkRejected.Text != "0")
                    lnkRejected.PostBackUrl = "RENDeptWiseReportDrillDown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&Department=" + ddldepartment.SelectedItem.Text + "&ViewType=Reject";

                lnkApplied.ForeColor = System.Drawing.Color.Black;
                lnkQueryRaised.ForeColor = System.Drawing.Color.Black;
                lnkScrRejected.ForeColor = System.Drawing.Color.Black;
                lnkScBeforeDate.ForeColor = System.Drawing.Color.Black;
                lnkScAfterDate.ForeColor = System.Drawing.Color.Black;
                lnkPaymentPending.ForeColor = System.Drawing.Color.Black;
                lnkScCompleted.ForeColor = System.Drawing.Color.Black;
                lnkBeforeApprovalDate.ForeColor = System.Drawing.Color.Black;
                lnkApprovalDate.ForeColor = System.Drawing.Color.Black;
                lnkDeptApproved.ForeColor = System.Drawing.Color.Black;
                lnkRejected.ForeColor = System.Drawing.Color.Black;
            }
        }
    }
}