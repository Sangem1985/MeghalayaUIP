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
    public partial class IRDistWiseReport : System.Web.UI.Page
    {
        DeptUserInfo ObjUserInfo = new DeptUserInfo();
        MasterBAL mstrBAL = new MasterBAL();
        ReportBAL reportsBAL = new ReportBAL();

        int TotalAppl, ImaPending, ImaQuery, QueryRedressedima, CommPending, CommApproved, CommRejected, CommQuery;
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
                        //txtFormDate.Text = "01-06-2024";
                        //txtToDate.Text = Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy"));
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
        public void FillGridData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = reportsBAL.DistrictWiseReports(ddldistrict.SelectedValue, ddlEnterPriseType.SelectedItem.Text, txtFormDate.Text, txtToDate.Text);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
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

                int Redressed = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "QUERYREDRESSEDTOIMA"));
                QueryRedressedima = Redressed + QueryRedressedima;

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
                LinkButton lnkRedressed = (LinkButton)e.Row.FindControl("lblQueryRedressed");
                LinkButton lnkcommpending = (LinkButton)e.Row.FindControl("lblCommPending");
                LinkButton lnkApproved = (LinkButton)e.Row.FindControl("lblCommApproved");
                LinkButton lnkRejected = (LinkButton)e.Row.FindControl("lblCommRejected");
                LinkButton lnkCommQuery = (LinkButton)e.Row.FindControl("lblCommQuery");

                string districtname = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTNAME")).Trim();

                if (lnkTotal.Text != "0")
                {
                    lnkTotal.PostBackUrl = ResolveUrl("IRDistWiseReportDrillDown.aspx?Distid=" + lblDist.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=TOTAL" + "&District=" + districtname + "&EntType=" + ddlEnterPriseType.SelectedItem.Text);
                    lnkTotal.Attributes.Add("formtarget", "_blank");
                }
                if (lnkPending.Text != "0")
                    lnkPending.PostBackUrl = "IRDistWiseReportDrillDown.aspx?Distid=" + lblDist.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=IMAPENDING" + "&District=" + districtname + "&EntType=" + ddlEnterPriseType.SelectedItem.Text;

                if (lnkQuery.Text != "0")
                    lnkQuery.PostBackUrl = "IRDistWiseReportDrillDown.aspx?Distid=" + lblDist.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=IMAQUERYRAISED" + "&District=" + districtname + "&EntType=" + ddlEnterPriseType.SelectedItem.Text;

                if (lnkRedressed.Text != "0")
                    lnkRedressed.PostBackUrl = "IRDistWiseReportDrillDown.aspx?Distid=" + lblDist.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=QUERYREDRESSEDTOIMA" + "&District=" + districtname + "&EntType=" + ddlEnterPriseType.SelectedItem.Text;

                if (lnkcommpending.Text != "0")
                    lnkcommpending.PostBackUrl = "IRDistWiseReportDrillDown.aspx?Distid=" + lblDist.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=COMMPENDING" + "&District=" + districtname + "&EntType=" + ddlEnterPriseType.SelectedItem.Text;

                if (lnkApproved.Text != "0")
                    lnkApproved.PostBackUrl = "IRDistWiseReportDrillDown.aspx?Distid=" + lblDist.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=COMMAPPROVED" + "&District=" + districtname + "&EntType=" + ddlEnterPriseType.SelectedItem.Text;

                if (lnkRejected.Text != "0")
                    lnkRejected.PostBackUrl = "IRDistWiseReportDrillDown.aspx?Distid=" + lblDist.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=COMMREJECTED" + "&District=" + districtname + "&EntType=" + ddlEnterPriseType.SelectedItem.Text;

                if (lnkCommQuery.Text != "0")
                    lnkCommQuery.PostBackUrl = "IRDistWiseReportDrillDown.aspx?Distid=" + lblDist.Text + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=COMMQUERY" + "&District=" + districtname + "&EntType=" + ddlEnterPriseType.SelectedItem.Text;

                lnkTotal.ForeColor = System.Drawing.Color.Black;
                lnkPending.ForeColor = System.Drawing.Color.Black;
                lnkQuery.ForeColor = System.Drawing.Color.Black;
                lnkRedressed.ForeColor = System.Drawing.Color.Black;
                lnkcommpending.ForeColor = System.Drawing.Color.Black;
                lnkApproved.ForeColor = System.Drawing.Color.Black;
                lnkRejected.ForeColor = System.Drawing.Color.Black;
                lnkCommQuery.ForeColor = System.Drawing.Color.Black;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                string districtname = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTNAME")).Trim();

                if (ddldistrict.SelectedItem.Text == "" || ddldistrict.SelectedItem.Text == null || ddldistrict.SelectedItem.Text == "--ALL--" || ddldistrict.SelectedValue == "0")
                {
                    districtname = "%";
                }
                else
                {
                    districtname = ddldistrict.SelectedItem.Text;
                }

                e.Row.Font.Bold = true;
                e.Row.Cells[2].Text = "Total";

                LinkButton Total = new LinkButton();
                Total.ForeColor = System.Drawing.Color.White;
                Total.Text = TotalAppl.ToString();
                if (Total.Text != "0")
                {
                    Total.PostBackUrl = "IRDistWiseReportDrillDown.aspx?Distid=" + districtname + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=TOTAL" + "&District=" + districtname + "&EntType=" + ddlEnterPriseType.SelectedItem.Text;
                    Total.Attributes.Add("formtarget", "_blank");
                }
                e.Row.Cells[3].Text = TotalAppl.ToString();
                e.Row.Cells[3].Controls.Add(Total);

                LinkButton Pending = new LinkButton();
                Pending.ForeColor = System.Drawing.Color.White;
                Pending.Text = ImaPending.ToString();
                if (Pending.Text != "0")
                    Pending.PostBackUrl = "IRDistWiseReportDrillDown.aspx?Distid=" + districtname + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=IMAPENDING" + "&District=" + districtname + "&EntType=" + ddlEnterPriseType.SelectedItem.Text;
                e.Row.Cells[4].Text = ImaPending.ToString();
                e.Row.Cells[4].Controls.Add(Pending);

                LinkButton Query = new LinkButton();
                Query.ForeColor = System.Drawing.Color.White;
                Query.Text = ImaQuery.ToString();
                if (Query.Text != "0")
                    Query.PostBackUrl = "IRDistWiseReportDrillDown.aspx?Distid=" + districtname + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=IMAQUERYRAISED" + "&District=" + districtname + "&EntType=" + ddlEnterPriseType.SelectedItem.Text;
                e.Row.Cells[5].Text = ImaQuery.ToString();
                e.Row.Cells[5].Controls.Add(Query);

                LinkButton QueryRedressed = new LinkButton();
                QueryRedressed.ForeColor = System.Drawing.Color.White;
                QueryRedressed.Text = QueryRedressedima.ToString();
                if (QueryRedressed.Text != "0")
                    QueryRedressed.PostBackUrl = "IRDistWiseReportDrillDown.aspx?Distid=" + districtname + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=QUERYREDRESSEDTOIMA" + "&District=" + districtname + "&EntType=" + ddlEnterPriseType.SelectedItem.Text;
                e.Row.Cells[6].Text = QueryRedressedima.ToString();
                e.Row.Cells[6].Controls.Add(QueryRedressed);


                LinkButton CommonPending = new LinkButton();
                CommonPending.ForeColor = System.Drawing.Color.White;
                CommonPending.Text = CommPending.ToString();
                if (CommonPending.Text != "0")
                    CommonPending.PostBackUrl = "IRDistWiseReportDrillDown.aspx?Distid=" + districtname + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=COMMPENDING" + "&District=" + districtname + "&EntType=" + ddlEnterPriseType.SelectedItem.Text;
                e.Row.Cells[7].Text = CommPending.ToString();
                e.Row.Cells[7].Controls.Add(CommonPending);

                LinkButton CommonApproved = new LinkButton();
                CommonApproved.ForeColor = System.Drawing.Color.White;
                CommonApproved.Text = CommApproved.ToString();
                if (CommonApproved.Text != "0")
                    CommonApproved.PostBackUrl = "IRDistWiseReportDrillDown.aspx?Distid=" + districtname + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=COMMAPPROVED" + "&District=" + districtname + "&EntType=" + ddlEnterPriseType.SelectedItem.Text;
                e.Row.Cells[8].Text = CommApproved.ToString();
                e.Row.Cells[8].Controls.Add(CommonApproved);

                LinkButton CommonRejected = new LinkButton();
                CommonRejected.ForeColor = System.Drawing.Color.White;
                CommonRejected.Text = CommRejected.ToString();
                if (CommonRejected.Text != "0")
                    CommonRejected.PostBackUrl = "IRDistWiseReportDrillDown.aspx?Distid=" + districtname + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=COMMREJECTED" + "&District=" + districtname + "&EntType=" + ddlEnterPriseType.SelectedItem.Text;
                e.Row.Cells[9].Text = CommRejected.ToString();
                e.Row.Cells[9].Controls.Add(CommonRejected);

                LinkButton CommonQuery = new LinkButton();
                CommonQuery.ForeColor = System.Drawing.Color.White;
                CommonQuery.Text = CommQuery.ToString();
                if (CommonQuery.Text != "0")
                    CommonQuery.PostBackUrl = "IRDistWiseReportDrillDown.aspx?Distid=" + districtname + "&FromDate=" + txtFormDate.Text + "&ToDate=" + txtToDate.Text + "&ViewType=COMMQUERY" + "&District=" + districtname + "&EntType=" + ddlEnterPriseType.SelectedItem.Text;
                e.Row.Cells[10].Text = CommQuery.ToString();
                e.Row.Cells[10].Controls.Add(CommonQuery);

                //e.Row.Cells[4].Text = ImaPending.ToString();
                // e.Row.Cells[5].Text = ImaQuery.ToString();
                // e.Row.Cells[6].Text = QueryRedressedima.ToString();
                // e.Row.Cells[7].Text = CommPending.ToString();
                // e.Row.Cells[8].Text = CommApproved.ToString();
                // e.Row.Cells[9].Text = CommRejected.ToString();
                // e.Row.Cells[10].Text = CommQuery.ToString();
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
                            GVDistrictWise.HeaderStyle.ForeColor = System.Drawing.Color.White;
                            //GVDistrictWise.HeaderStyle.BackColor = System.Drawing.Color.Blue;
                            GVDistrictWise.RowStyle.BorderColor = System.Drawing.Color.Black;
                            GVDistrictWise.RowStyle.BorderStyle = BorderStyle.Solid;
                            GVDistrictWise.RowStyle.BorderWidth = Unit.Pixel(1);
                            GVDistrictWise.FooterStyle.ForeColor = System.Drawing.Color.White;

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
                            GVDistrictWise.RenderControl(hw);

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