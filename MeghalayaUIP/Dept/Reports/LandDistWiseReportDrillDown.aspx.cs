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
using MeghalayaUIP.CommonClass;

namespace MeghalayaUIP.Dept.Reports
{
    public partial class LandDistWiseReportDrillDown : System.Web.UI.Page
    {
        DeptUserInfo ObjUserInfo = new DeptUserInfo();
        ReportBAL Objreport = new ReportBAL();
        string Distid, FromDate, ToDate, District, ViewType;

        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Dept/Reports/LandDistWiseReport.aspx");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
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
                        BindDistrictWiseReport();
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
        protected void BindDistrictWiseReport()
        {
            try
            {
                if (Request.QueryString.Count > 0)
                {
                    Distid = Convert.ToString(Request.QueryString[0]);
                    FromDate = Convert.ToString(Request.QueryString[1]);
                    ToDate = Convert.ToString(Request.QueryString[2]);
                    ViewType = Convert.ToString(Request.QueryString[3]);
                    District = Convert.ToString(Request.QueryString[4]);

                    DataSet ds = new DataSet();

                    ds = Objreport.LandDistrictReportDrilldown(Distid, FromDate, ToDate, ViewType);
                    if (ds != null && ds.Tables.Count > 0 &&  ds.Tables[0].Rows.Count > 0)
                    {
                        GVLADistWise.DataSource = ds.Tables[0];
                        GVLADistWise.DataBind();
                        lblStatus.Visible = true;
                        lblStatus.InnerText = District + " " + " " + "&" + " " + " " + FromDate + " " + " " + "In" + " " + " " + ToDate;
                        if (District == "%")
                        {
                            lblStatus.InnerText = "All Districts";
                        }
                    }
                    else
                    {
                        GVLADistWise.DataSource = null;
                        GVLADistWise.DataBind();
                    }
                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void btnExcel_Click(object sender, ImageClickEventArgs e)
        {
            ExportToExcel();
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
                Response.AddHeader("content-disposition", "attachment;filename=Land District wise Report " + DateTime.Now.ToString("M/d/yyyy") + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                using (StringWriter sw = new StringWriter())
                {
                    //GVDistWise.Style["width"] = "680px";
                    //HtmlTextWriter hw = new HtmlTextWriter(sw);
                    //GVDistWise.RenderControl(hw);
                    //string headerTable = @"<table width='100%'  class='table-bordered mb-0 GRD'><tr><td align='center' colspan='13'><h4>" + lblHeading.Text + "</h4></td></tr></table>";
                    //HttpContext.Current.Response.Write(headerTable);
                    //Response.Output.Write(sw.ToString());
                    //Response.Flush();
                    //Response.End();

                    string style = @"<style>
                        .gridTable { border-collapse: collapse; width: 100%; }
                        .gridTable th, .gridTable td { border: 1px solid black; padding: 5px; text-align: left; }
                     </style>";

                    GVLADistWise.Style["width"] = "680px";
                    GVLADistWise.CssClass = "gridTable";

                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    GVLADistWise.RenderControl(hw);


                    string headerTable = @"<table class='gridTable'>
                              <tr>
                                  <td align='center' colspan='13'><h4>" + lblHeading.Text + @"</h4></td>
                              </tr>
                          </table>";

                    Response.Write(style);
                    Response.Write(headerTable);
                    Response.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        protected void btnPdf_Click(object sender, ImageClickEventArgs e)
        {
            ExportGridToPDF();
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
                            GVLADistWise.AllowPaging = false;
                            this.BindDistrictWiseReport();
                            GVLADistWise.HeaderStyle.ForeColor = System.Drawing.Color.White;
                            //GVDistrictWise.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                            GVLADistWise.RowStyle.BorderColor = System.Drawing.Color.Black;
                            GVLADistWise.RowStyle.BorderStyle = BorderStyle.Solid;
                            GVLADistWise.RowStyle.BorderWidth = Unit.Pixel(1);
                            GVLADistWise.FooterStyle.ForeColor = System.Drawing.Color.White;

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
                            GVLADistWise.RenderControl(hw);

                            // Convert HTML to string
                            string htmlContent = sw.ToString();

                            // Create a PDF document
                            Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);

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
                            Response.AddHeader("content-disposition", "attachment;filename=Land District wise Report " + DateTime.Now.ToString("M/d/yyyy") + ".pdf");
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
                Console.WriteLine(ex.Message);
            }
        }

    }
}