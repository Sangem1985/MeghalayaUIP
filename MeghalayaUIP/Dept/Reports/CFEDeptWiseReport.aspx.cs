using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iTextSharp.tool.xml;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.ReportBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text;
using PageSize = iTextSharp.text.PageSize;
using Document = iTextSharp.text.Document;


namespace MeghalayaUIP.Dept.Reports
{
    public partial class CFEDeptWiseReport : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        ReportBAL reportsBAL = new ReportBAL();

        int ApprovalsApplied, QueryRaised, BeforeDate, AfterDate,PreRejected, Paymentpending, ScrutinyCompleted, Before, After, DeptApproved, Rejected;
             
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
        public void BindGridData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = reportsBAL.CFEDeptWiseReport(ddldepartment.SelectedValue, txtFormDate.Text, txtToDate.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GVDistrictWise.DataSource = ds.Tables[0];
                    GVDistrictWise.DataBind();
                }
                else
                {
                    GVDistrictWise.DataSource = null;
                    GVDistrictWise.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            BindGridData();
            divPrint1.Visible = true;
        }

        protected void GVDistrictWise_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow gvHeaderRow = e.Row;
                GridViewRow gvHeaderRowCopy = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                this.GVDistrictWise.Controls[0].Controls.AddAt(0, gvHeaderRowCopy);

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

        protected void GVDistrictWise_RowDataBound(object sender, GridViewRowEventArgs e)
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
                LinkButton lnkScCompleted= (LinkButton)e.Row.FindControl("lblScrutinyCompleted");
                LinkButton lnkBeforeApprovalDate = (LinkButton)e.Row.FindControl("lblApprovalBeforeDate");
                LinkButton lnkApprovalDate = (LinkButton)e.Row.FindControl("lblApprovalDate");
                LinkButton lnkDeptApproved = (LinkButton)e.Row.FindControl("lblDepatApproved");
                LinkButton lnkRejected = (LinkButton)e.Row.FindControl("lblRejected");

                string Department = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DEPARTMENT_NAME")).Trim();

                if (lnkApplied.Text != "0")
                    lnkApplied.PostBackUrl = "CFEDeptWiseReportDrilldown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&Department=" + ddldepartment.SelectedItem.Text;

                if (lnkQueryRaised.Text != "0")
                    lnkQueryRaised.PostBackUrl = "CFEDeptWiseReportDrilldown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&Department=" + ddldepartment.SelectedItem.Text;

                if (lnkScBeforeDate.Text != "0")
                    lnkScBeforeDate.PostBackUrl = "CFEDeptWiseReportDrilldown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&Department=" + ddldepartment.SelectedItem.Text;

                if (lnkScAfterDate.Text != "0")
                    lnkScAfterDate.PostBackUrl = "CFEDeptWiseReportDrilldown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&Department=" + ddldepartment.SelectedItem.Text;

                if (lnkScrRejected.Text != "0")
                    lnkScrRejected.PostBackUrl = "CFEDeptWiseReportDrilldown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&Department=" + ddldepartment.SelectedItem.Text;


                if (lnkPaymentPending.Text != "0")
                    lnkPaymentPending.PostBackUrl = "CFEDeptWiseReportDrilldown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&Department=" + ddldepartment.SelectedItem.Text;

                if (lnkScCompleted.Text != "0")
                    lnkScCompleted.PostBackUrl = "CFEDeptWiseReportDrilldown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&Department=" + ddldepartment.SelectedItem.Text;

                if (lnkBeforeApprovalDate.Text != "0")
                    lnkBeforeApprovalDate.PostBackUrl = "CFEDeptWiseReportDrilldown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&Department=" + ddldepartment.SelectedItem.Text;

                if (lnkApprovalDate.Text != "0")
                    lnkApprovalDate.PostBackUrl = "CFEDeptWiseReportDrilldown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&Department=" + ddldepartment.SelectedItem.Text;

                if (lnkDeptApproved.Text != "0")
                    lnkDeptApproved.PostBackUrl = "CFEDeptWiseReportDrilldown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&Department=" + ddldepartment.SelectedItem.Text;

                if (lnkRejected.Text != "0")
                    lnkRejected.PostBackUrl = "CFEDeptWiseReportDrilldown.aspx?Deptid=" + lblDept.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&Department=" + ddldepartment.SelectedItem.Text;


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

                if (ddldepartment.SelectedItem.Text == "" || ddldepartment.SelectedItem.Text == null || ddldepartment.SelectedItem.Text == "--ALL--" || ddldepartment.SelectedValue == "0")
                {
                    Department = "%";
                }
                else
                {
                    Department = ddldepartment.SelectedItem.Text;
                }

                e.Row.Font.Bold = true;
                e.Row.Cells[2].Text = "Total";
                LinkButton Total = new LinkButton();
                Total.ForeColor = System.Drawing.Color.Black;
                if (Total.Text != "0")
                {
                    Total.PostBackUrl = "CFEDeptWiseReportDrilldown.aspx?Deptid=" + Department + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&Department=" + ddldepartment.SelectedItem.Text;
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
                    GVDistrictWise.Style["width"] = "680px";
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    GVDistrictWise.RenderControl(hw);
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
        private void ExportGridToPDF()
        {

            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (StringWriter sw = new StringWriter())
                    {
                        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                        {
                           
                            GVDistrictWise.AllowPaging = false;
                            this.BindGridData(); 
                            GVDistrictWise.HeaderRow.ForeColor = System.Drawing.Color.Black;
                            GVDistrictWise.FooterRow.Visible = false;
                            GVDistrictWise.RenderControl(hw);

                            string htmlContent = sw.ToString();
                                                       
                            Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);

                          
                          //  PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);

                            pdfDoc.Open();
                                                       
                            using (StringReader sr = new StringReader(htmlContent))
                            {
                               // XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                            }

                            pdfDoc.Close();

                            // Send the generated PDF to the client browser
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-disposition", "attachment;filename=CFEDeptWiseReport " + DateTime.Now.ToString("M/d/yyyy") + ".pdf");
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
                // Log the exception
                // Handle the error and provide feedback
            }
        }
        protected void btnExcel_Click(object sender, ImageClickEventArgs e)
        {
            ExportToExcel();
        }

        protected void btnPdf_Click(object sender, ImageClickEventArgs e)
        {
            ExportGridToPDF();
        }

    }
}