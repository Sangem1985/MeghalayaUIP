using iTextSharp.text.html.simpleparser;
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
    public partial class LandDistWiseReport : System.Web.UI.Page
    {
        DeptUserInfo ObjUserInfo = new DeptUserInfo();
        MasterBAL mstrBAL = new MasterBAL();
        ReportBAL reportsBAL = new ReportBAL();
        int TotalAppl, ImaPending, ImaQuery, CommPending, CommApproved, CommRejected, CommQuery;

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
                        BindDistricts();

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

        protected void btnPdf_Click(object sender, ImageClickEventArgs e)
        {
            ExportGridToPDF();
        }

        protected void btnExcel_Click(object sender, ImageClickEventArgs e)
        {
            ExportToExcel();
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
                li.Text = "--ALL--";
                li.Value = "%";
                ddl.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                throw ex;
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

        public void FillGridData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = reportsBAL.LandDistrictWiseReports(ddldistrict.SelectedValue, txtFormDate.Text, txtToDate.Text, ddlEnterPriseType.SelectedItem.Text);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    GVLADistrictWise.DataSource = ds.Tables[0];
                    GVLADistrictWise.DataBind();

                }
                else
                {
                    GVLADistrictWise.DataSource = null;
                    GVLADistrictWise.DataBind();

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
                FillGridData();
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void GVLADistrictWise_RowDataBound(object sender, GridViewRowEventArgs e)
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

                // string districtname = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTNAME")).Trim();

                if (lnkTotal.Text != "0")
                    lnkTotal.PostBackUrl = "IRDistWiseReportDrillDown.aspx?Distid=" + lblDist.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=TOTAL" + "&District=" + ddldistrict.SelectedItem.Text + "&EntType=" + ddlEnterPriseType.SelectedItem.Text;

                if (lnkPending.Text != "0")
                    lnkPending.PostBackUrl = "IRDistWiseReportDrillDown.aspx?Distid=" + lblDist.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=Pending" + "&District=" + ddldistrict.SelectedItem.Text + "&EntType=" + ddlEnterPriseType.SelectedItem.Text;

                if (lnkQuery.Text != "0")
                    lnkQuery.PostBackUrl = "IRDistWiseReportDrillDown.aspx?Distid=" + lblDist.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=Query" + "&District=" + ddldistrict.SelectedItem.Text + "&EntType=" + ddlEnterPriseType.SelectedItem.Text;

                if (lnkcommpending.Text != "0")
                    lnkcommpending.PostBackUrl = "IRDistWiseReportDrillDown.aspx?Distid=" + lblDist.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=commpending" + "&District=" + ddldistrict.SelectedItem.Text + "&EntType=" + ddlEnterPriseType.SelectedItem.Text;

                if (lnkApproved.Text != "0")
                    lnkApproved.PostBackUrl = "IRDistWiseReportDrillDown.aspx?Distid=" + lblDist.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=Approved" + "&District=" + ddldistrict.SelectedItem.Text + "&EntType=" + ddlEnterPriseType.SelectedItem.Text;

                if (lnkRejected.Text != "0")
                    lnkRejected.PostBackUrl = "IRDistWiseReportDrillDown.aspx?Distid=" + lblDist.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=Rejected" + "&District=" + ddldistrict.SelectedItem.Text + "&EntType=" + ddlEnterPriseType.SelectedItem.Text;

                if (lnkCommQuery.Text != "0")
                    lnkCommQuery.PostBackUrl = "IRDistWiseReportDrillDown.aspx?Distid=" + lblDist.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=CommQuery" + "&District=" + ddldistrict.SelectedItem.Text + "&EntType=" + ddlEnterPriseType.SelectedItem.Text;

                lnkTotal.ForeColor = System.Drawing.Color.Black;
                lnkPending.ForeColor = System.Drawing.Color.Black;
                lnkQuery.ForeColor = System.Drawing.Color.Black;
                lnkcommpending.ForeColor = System.Drawing.Color.Black;
                lnkApproved.ForeColor = System.Drawing.Color.Black;
                lnkRejected.ForeColor = System.Drawing.Color.Black;
                lnkCommQuery.ForeColor = System.Drawing.Color.Black;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                string districtname = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTNAME")).Trim();
                string Districtid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICID")).Trim();

                if (ddldistrict.SelectedItem.Text == "" || ddldistrict.SelectedItem.Text == null || ddldistrict.SelectedItem.Text == "--ALL--" || ddldistrict.SelectedValue == "0")
                {
                    districtname = "%";
                    Districtid = "%";
                }
                else
                {
                    districtname = ddldistrict.SelectedItem.Text;
                    Districtid = ddldistrict.SelectedValue;
                }

                e.Row.Font.Bold = true;
                e.Row.Cells[2].Text = "Total";

                LinkButton Total = new LinkButton();
                Total.ForeColor = System.Drawing.Color.Black;
                if (Total.Text != "0")
                {
                    Total.PostBackUrl = ".aspx?Distid=" + Districtid + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=TOTAL" + "&District=" + districtname + "&EntType=" + ddlEnterPriseType.SelectedItem.Text;
                }
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
                Response.AddHeader("content-disposition", "attachment;filename=Land District wise Report " + DateTime.Now.ToString("M/d/yyyy") + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                using (StringWriter sw = new StringWriter())
                {
                    GVLADistrictWise.Style["width"] = "680px";
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    GVLADistrictWise.RenderControl(hw);
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
                            GVLADistrictWise.AllowPaging = false;
                            this.FillGridData();
                            GVLADistrictWise.HeaderStyle.ForeColor = System.Drawing.Color.White;
                            //GVDistrictWise.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                            GVLADistrictWise.RowStyle.BorderColor = System.Drawing.Color.Black;
                            GVLADistrictWise.RowStyle.BorderStyle = BorderStyle.Solid;
                            GVLADistrictWise.RowStyle.BorderWidth = Unit.Pixel(1);
                            GVLADistrictWise.FooterStyle.ForeColor = System.Drawing.Color.White;

                            hw.AddStyleAttribute(HtmlTextWriterStyle.BorderCollapse, "collapse");
                            hw.AddStyleAttribute(HtmlTextWriterStyle.Width, "100%");
                            hw.RenderBeginTag(HtmlTextWriterTag.Style);
                            GVLADistrictWise.RenderControl(hw);

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
                            Response.AddHeader("content-disposition", "attachment;filename=Land District Wise Report " + DateTime.Now.ToString("M/d/yyyy") + ".pdf");
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
    }
}