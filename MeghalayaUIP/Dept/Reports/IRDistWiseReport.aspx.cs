﻿using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.ReportBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.tool.xml;


namespace MeghalayaUIP.Dept.Reports
{
    public partial class IRDistWiseReport : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        ReportBAL reportsBAL = new ReportBAL();

        int TotalAppl, ImaPending, ImaQuery, CommPending, CommApproved, CommRejected, CommQuery;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {               
                BindDistricts();
            }
        }
        protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void BindDistricts()
        {
            try
            {

                ddldistrict.Items.Clear();
                List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();
                string strmode = string.Empty;
                strmode = "";
                objDistrictModel = mstrBAL.GetDistrcits();
                if (objDistrictModel != null)
                {
                    ddldistrict.DataSource = objDistrictModel;
                    ddldistrict.DataValueField = "DistrictId";
                    ddldistrict.DataTextField = "DistrictName";
                    ddldistrict.DataBind();

                }
                else
                {
                    ddldistrict.DataSource = null;
                    ddldistrict.DataBind();


                }
                AddSelect(ddldistrict);


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
                li.Text = "--Select--";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void FillGridData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = reportsBAL.DistrictWiseReports(ddldistrict.SelectedValue, ddlEnterPriseType.SelectedItem.Text, txtFormDate.Text, txtToDate.Text);
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
            FillGridData();
            divPrint1.Visible = true;
        }

        protected void GVDistrictWise_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int Application = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TOTALAPPL"));
                TotalAppl = Application + TotalAppl;

                int Pending = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IMAPENDING"));
                ImaPending = Pending + ImaPending;

                int Query = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IMAQUERYRAISED"));
                ImaQuery = Query + ImaQuery;

                int CommPendings = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "COMMPENDING"));
                CommPending = CommPendings + CommPending;

                int Approved = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "COMMAPPROVED"));
                CommApproved = Approved + CommApproved;

                int Rejected = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "COMMREJECTED"));
                CommRejected = Rejected + CommRejected;

                int CommonQuery = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "COMMQUERY"));
                CommQuery = CommonQuery + CommQuery;



                Label lblDist = (Label)e.Row.FindControl("lblDistrictid");
                LinkButton lnkTotal = (LinkButton)e.Row.FindControl("lblTotal");
                LinkButton lnkPending = (LinkButton)e.Row.FindControl("lblPending");
                LinkButton lnkQuery = (LinkButton)e.Row.FindControl("lblQueryRaised");
                LinkButton lnkcommpending = (LinkButton)e.Row.FindControl("lblCommPending");
                LinkButton lnkApproved = (LinkButton)e.Row.FindControl("lblCommApproved");
                LinkButton lnkRejected = (LinkButton)e.Row.FindControl("lblCommRejected");
                LinkButton lnkCommQuery = (LinkButton)e.Row.FindControl("lblCommQuery");

                if (lnkTotal.Text != "0")
                    lnkTotal.PostBackUrl = "IRDistWiseReportDrillDown.aspx?Distid=" + lblDist.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=TOTAL" + "&EntType=" + ddlEnterPriseType.SelectedItem.Text;

                if (lnkPending.Text != "0")
                    lnkPending.PostBackUrl = "~/IRDistWiseReportDrillDown.aspx?Distid=" + lblDist.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=Pending" + "&EntType=" + ddlEnterPriseType.SelectedItem.Text;

                if (lnkQuery.Text != "0")
                    lnkQuery.PostBackUrl = "~/IRDistWiseReportDrillDown.aspx?Distid=" + lblDist.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=Query" + "&EntType=" + ddlEnterPriseType.SelectedItem.Text;

                if (lnkcommpending.Text != "0")
                    lnkcommpending.PostBackUrl = "~/IRDistWiseReportDrillDown.aspx?Distid=" + lblDist.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=commpending" + "&EntType=" + ddlEnterPriseType.SelectedItem.Text;

                if (lnkApproved.Text != "0")
                    lnkApproved.PostBackUrl = "~/IRDistWiseReportDrillDown.aspx?Distid=" + lblDist.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=Approved" + "&EntType=" + ddlEnterPriseType.SelectedItem.Text;

                if (lnkRejected.Text != "0")
                    lnkRejected.PostBackUrl = "~/IRDistWiseReportDrillDown.aspx?Distid=" + lblDist.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=Rejected" + "&EntType=" + ddlEnterPriseType.SelectedItem.Text;

                if (lnkCommQuery.Text != "0")
                    lnkCommQuery.PostBackUrl = "~/IRDistWiseReportDrillDown.aspx?Distid=" + lblDist.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=CommQuery" + "&EntType=" + ddlEnterPriseType.SelectedItem.Text;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                string district;

                if (ddldistrict.SelectedItem.Text == "" || ddldistrict.SelectedItem.Text == null || ddldistrict.SelectedItem.Text == "--Select--" || ddldistrict.SelectedValue == "0")
                {
                    district = "%";
                }
                else
                {
                    district = ddldistrict.SelectedItem.Text;
                }

                e.Row.Font.Bold = true;
                e.Row.Cells[2].Text = "Total";
                LinkButton Total = new LinkButton();
                Total.ForeColor = System.Drawing.Color.Blue;
                Total.PostBackUrl = "~/IRDistWiseReportDrillDown.aspx?Distid=" + district + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType" + "&EntType=" + ddlEnterPriseType.SelectedItem.Text;
                Total.Text = TotalAppl.ToString();
                e.Row.Cells[3].Text = TotalAppl.ToString();
                e.Row.Cells[3].Controls.Add(Total);
                e.Row.Cells[4].Text = ImaPending.ToString();
                e.Row.Cells[5].Text = ImaQuery.ToString();
                e.Row.Cells[6].Text = CommPending.ToString();
                e.Row.Cells[7].Text = CommApproved.ToString();
                e.Row.Cells[8].Text = CommRejected.ToString();
                e.Row.Cells[9].Text = CommQuery.ToString();
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
        protected void ExportToExcel()
        {
            try
            {
                
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=District wise Report " + DateTime.Now.ToString("M/d/yyyy") + ".xls");
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

            }
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
                            GVDistrictWise.AllowPaging = false;
                            this.FillGridData();
                            GVDistrictWise.HeaderRow.ForeColor = System.Drawing.Color.Black;
                            GVDistrictWise.FooterRow.Visible = false;
                            GVDistrictWise.RenderControl(hw);

                            // Convert HTML to string
                            string htmlContent = sw.ToString();

                            // Create a PDF document
                            Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);

                            // Create a PdfWriter that writes to memory stream
                            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);

                            pdfDoc.Open();

                            // Use XMLWorkerHelper to parse the HTML content
                            using (StringReader sr = new StringReader(htmlContent))
                            {
                                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                            }

                            pdfDoc.Close();

                            // Send the generated PDF to the client browser
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-disposition", "attachment;filename=District Wise Report " + DateTime.Now.ToString("M/d/yyyy") + ".pdf");
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

        protected void btnPdf_Click(object sender, ImageClickEventArgs e)
        {
            ExportGridToPDF();
        }

        protected void btnExcel_Click(object sender, ImageClickEventArgs e)
        {
            ExportToExcel();

        }
       
    }
}