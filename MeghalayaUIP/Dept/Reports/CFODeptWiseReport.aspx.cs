using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.ReportBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.tool.xml;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Text.RegularExpressions;
using MeghalayaUIP.CommonClass;

namespace MeghalayaUIP.Dept.Reports
{
    public partial class CFODeptWiseReport : System.Web.UI.Page
    {
        DeptUserInfo ObjUserInfo = new DeptUserInfo();
        MasterBAL mstrBAL = new MasterBAL();
        ReportBAL reportsBAL = new ReportBAL();

        int ApprovalsApplied, QueryRaised, BeforeDate, AfterDate, PreRejected, Paymentpending, ScrutinyCompleted, Before, After, DeptApproved, Rejected;

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

        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Dept/Reports/ReportsAbstract.aspx");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
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
        public void BindCFoDeptReports()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = reportsBAL.CFODeptWiseReport(ddldepartment.SelectedValue, txtFormDate.Text, txtToDate.Text);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    GVCFOReport.DataSource = ds.Tables[0];
                    GVCFOReport.DataBind();
                }
                else
                {
                    GVCFOReport.DataSource = null;
                    GVCFOReport.DataBind();
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
            try
            {
                BindCFoDeptReports();
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

            // divPrint1.Visible = true;
        }

        protected void GVCFOReport_RowCreated(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow gvHeaderRow = e.Row;
                GridViewRow gvHeaderRowCopy = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                this.GVCFOReport.Controls[0].Controls.AddAt(0, gvHeaderRowCopy);

                int headerCellCount = gvHeaderRow.Cells.Count;
                int cellIndex = 0;

                for (int i = 0; i < headerCellCount; i++)
                {
                    if (i == 5 || i == 6 || i == 10 || i == 11)
                    {
                        cellIndex++;
                    }
                    else
                    {
                        TableCell tcHeader = gvHeaderRow.Cells[cellIndex];
                        tcHeader.RowSpan = 2;
                        gvHeaderRowCopy.Cells.Add(tcHeader);
                    }
                }

                TableCell tcMergePackage = new TableCell();
                tcMergePackage.Text = "Pre-Scrutiny-Under Process";
                tcMergePackage.CssClass = "GridviewScrollC1Headerwrap";
                tcMergePackage.ColumnSpan = 2;
                gvHeaderRowCopy.Cells.AddAt(5, tcMergePackage);

                TableCell tcMergePackage1 = new TableCell();
                tcMergePackage1.Text = "Department Approval - Under Process";
                tcMergePackage1.CssClass = "GridviewScrollC1Headerwrap";
                tcMergePackage1.ColumnSpan = 2;
                gvHeaderRowCopy.Cells.AddAt(9, tcMergePackage1);
            }
        }

        protected void GVCFOReport_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    lnkApplied.PostBackUrl = "CFODeptWiseReportDrillDown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=APPROVALIS_APPLIED" + "&Department=" + ddldepartment.SelectedItem.Text;

                if (lnkQueryRaised.Text != "0")
                    lnkQueryRaised.PostBackUrl = "CFODeptWiseReportDrillDown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=QUERY_RAISED" + "&Department=" + ddldepartment.SelectedItem.Text;

                if (lnkScBeforeDate.Text != "0")
                    lnkScBeforeDate.PostBackUrl = "CFODeptWiseReportDrillDown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=SCRUTINY_BEFOREDUEDATE" + "&Department=" + ddldepartment.SelectedItem.Text;

                if (lnkScAfterDate.Text != "0")
                    lnkScAfterDate.PostBackUrl = "CFODeptWiseReportDrillDown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=SCRUTINY_AFTERDUEDATE" + "&Department=" + ddldepartment.SelectedItem.Text;

                if (lnkScrRejected.Text != "0")
                    lnkScrRejected.PostBackUrl = "CFODeptWiseReportDrillDown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=PRESCRUTINY_REJECTED" + "&Department=" + ddldepartment.SelectedItem.Text;

                if (lnkPaymentPending.Text != "0")
                    lnkPaymentPending.PostBackUrl = "CFODeptWiseReportDrillDown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=PAYMENT_PENDING" + "&Department=" + ddldepartment.SelectedItem.Text;

                if (lnkScCompleted.Text != "0")
                    lnkScCompleted.PostBackUrl = "CFODeptWiseReportDrillDown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=SCRUTINY_COMPLETED" + "&Department=" + ddldepartment.SelectedItem.Text;

                if (lnkBeforeApprovalDate.Text != "0")
                    lnkBeforeApprovalDate.PostBackUrl = "CFODeptWiseReportDrillDown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=APPROVALUNDER_PROCESSBEFOREDATE" + "&Department=" + ddldepartment.SelectedItem.Text;

                if (lnkApprovalDate.Text != "0")
                    lnkApprovalDate.PostBackUrl = "CFODeptWiseReportDrillDown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=APPROVALUNDER_PROCESSAFTERDATE" + "&Department=" + ddldepartment.SelectedItem.Text;

                if (lnkDeptApproved.Text != "0")
                    lnkDeptApproved.PostBackUrl = "CFODeptWiseReportDrillDown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=DEPARTMENT_APPROVED" + "&Department=" + ddldepartment.SelectedItem.Text;

                if (lnkRejected.Text != "0")
                    lnkRejected.PostBackUrl = "CFODeptWiseReportDrillDown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=REJECTED" + "&Department=" + ddldepartment.SelectedItem.Text;

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
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                string Department = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DEPARTMENT_NAME")).Trim();
                string DeptId = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DEPT_ID")).Trim();

                if (ddldepartment.SelectedItem.Text == "" || ddldepartment.SelectedItem.Text == null || ddldepartment.SelectedValue == "%" || ddldepartment.SelectedValue == "0")
                {
                    Department = "%";
                    DeptId = "%";
                }
                else
                {
                    Department = ddldepartment.SelectedItem.Text;
                    DeptId = ddldepartment.SelectedValue;
                }

                e.Row.Font.Bold = true;
                e.Row.Cells[2].Text = "Total";
                LinkButton Total = new LinkButton();
                Total.ForeColor = System.Drawing.Color.Black;
                if (Total.Text != "0")
                {
                    Total.PostBackUrl = "CFODeptWiseReportDrillDown.aspx?Deptid=" + DeptId + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=APPROVALIS_APPLIED" + "&Department=" + ddldepartment.SelectedItem.Text;
                }
                Total.Text = ApprovalsApplied.ToString();
                e.Row.Cells[3].Text = ApprovalsApplied.ToString();
                e.Row.Cells[3].Controls.Add(Total);

                e.Row.Cells[4].Text = QueryRaised.ToString();
                e.Row.Cells[5].Text = BeforeDate.ToString();
                e.Row.Cells[6].Text = AfterDate.ToString();
                e.Row.Cells[7].Text = PreRejected.ToString();
                e.Row.Cells[8].Text = Paymentpending.ToString();
                e.Row.Cells[9].Text = ScrutinyCompleted.ToString();
                e.Row.Cells[10].Text = Before.ToString();
                e.Row.Cells[11].Text = After.ToString();
                e.Row.Cells[12].Text = DeptApproved.ToString();
                e.Row.Cells[13].Text = Rejected.ToString();
            }
        }
        protected void ExportToExcel()
        {
            try
            {

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=CFE Dept wise Report " + DateTime.Now.ToString("M/d/yyyy") + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                using (StringWriter sw = new StringWriter())
                {
                    GVCFOReport.Style["width"] = "680px";
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    GVCFOReport.RenderControl(hw);
                    string headerTable = @"<table width='100%'  class='table-bordered mb-0 GRD'><tr><td align='center' colspan='5'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='5'><h4>" + label + "</h4></td></td></tr></table>";
                    HttpContext.Current.Response.Write(headerTable);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
            catch (Exception e)
            {
                //throw e;
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        protected void btnExcel_Click(object sender, ImageClickEventArgs e)
        {
            ExportToExcel();
        }
        protected void btnPdf_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (StringWriter sw = new StringWriter())
                    {
                        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                        {

                            GVCFOReport.AllowPaging = false;
                            this.BindDepartments();
                            GVCFOReport.HeaderRow.ForeColor = System.Drawing.Color.White;
                            GVCFOReport.FooterRow.Visible = true;
                            GVCFOReport.FooterRow.ForeColor = System.Drawing.Color.White;
                            GVCFOReport.RenderControl(hw);

                            string htmlContent = sw.ToString();

                            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);


                            //  PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);

                            pdfDoc.Open();

                            using (StringReader sr = new StringReader(htmlContent))
                            {
                                // XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                            }

                            pdfDoc.Close();

                            // Send the generated PDF to the client browser
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-disposition", "attachment;filename=CFODeptWiseReport " + DateTime.Now.ToString("M/d/yyyy") + ".pdf");
                            Response.Cache.SetCacheability(HttpCacheability.NoCache);

                            // Write the PDF from memory stream to the Response OutputStream
                            Response.OutputStream.Write(memoryStream.GetBuffer(), 0, memoryStream.GetBuffer().Length);
                            Response.Flush();
                            Response.End();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}