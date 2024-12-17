using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.ReportBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
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
                if (ds != null && ds.Tables.Count > 0 &&  ds.Tables[0].Rows.Count > 0)
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

        protected void btnPdf_Click(object sender, ImageClickEventArgs e)
        {
            ExportGridToPDF();
        }

        protected void btnExcel_Click(object sender, ImageClickEventArgs e)
        {
            ExportToExcel();
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
                            // To Export all pages
                            GVGrievance.AllowPaging = false;
                            this.FillGridBind();
                            GVGrievance.HeaderStyle.ForeColor = System.Drawing.Color.White;
                            //GVDistrictWise.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                            GVGrievance.RowStyle.BorderColor = System.Drawing.Color.Black;
                            GVGrievance.RowStyle.BorderStyle = BorderStyle.Solid;
                            GVGrievance.RowStyle.BorderWidth = Unit.Pixel(1);
                            GVGrievance.FooterStyle.ForeColor = System.Drawing.Color.White;

                            hw.AddStyleAttribute(HtmlTextWriterStyle.BorderCollapse, "collapse");
                            hw.AddStyleAttribute(HtmlTextWriterStyle.Width, "100%");
                            hw.RenderBeginTag(HtmlTextWriterTag.Style);
                            hw.Write(@"
                                     table { border-collapse: collapse; width: 100%; }
                                     th, td { border: 1px solid black; padding: 5px; text-decoration: none;}
                                     th { background-color: #013161; text-decoration: none;}
                                     td a { text-decoration: none; color: inherit; }
                                     table tr th:nth-child(1), table tr td:nth-child(1) { width: 20%; }
                                     table tr th:nth-child(3), table tr td:nth-child(3) { width: 50%; }
                                     ");
                            hw.RenderEndTag();
                            GVGrievance.RenderControl(hw);

                            // Convert HTML to string
                            string htmlContent = sw.ToString();

                            // Create a PDF document
                         /*   Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);

                            // Create a PdfWriter that writes to memory stream
                            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);

                            pdfDoc.Open();

                            // Use XMLWorkerHelper to parse the HTML content
                            using (StringReader sr = new StringReader(htmlContent))
                            {
                                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                            }

                            pdfDoc.Close();
                         */
                            // Send the generated PDF to the client browser
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-disposition", "attachment;filename=Pre-Operational Department Wise Report " + DateTime.Now.ToString("M/d/yyyy") + ".pdf");
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
                  //  GVCFOReport.Style["width"] = "680px";
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                   // GVCFOReport.RenderControl(hw);
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

    }
}