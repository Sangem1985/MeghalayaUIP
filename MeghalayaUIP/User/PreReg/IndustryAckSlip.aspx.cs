using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.BAL.PreRegBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;

using iTextSharp.tool.xml; // For parsing HTML to PDF


namespace MeghalayaUIP.User.PreReg
{
    public partial class IndustryAckSlip : System.Web.UI.Page
    {
        PreRegBAL preBAL = new PreRegBAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["UserInfo"] != null)
                {
                    var ObjUserInfo = new UserInfo();
                    if (Session["UserInfo"] != null && Session["UserInfo"].ToString() != "")
                    {
                        ObjUserInfo = (UserInfo)Session["UserInfo"];
                        hdnUserID.Value = ObjUserInfo.Userid;
                    }

                    if (!IsPostBack)
                    {
                        BindaApplicatinDetails();

                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }

        public void BindaApplicatinDetails()
        {
            try
            {

                if (Request.QueryString.Count > 0)
                {
                    string UnitID = Request.QueryString[0].ToString();
                    string InvesterID = hdnUserID.Value;
                    if (UnitID != null && InvesterID != null)
                    {
                        DataSet ds = new DataSet();
                        ds = preBAL.GetIndRegUserApplDetails(UnitID, InvesterID);

                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                lblUIDNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["PREREGUIDNO"]);
                                lblApplicant.InnerText= Convert.ToString(ds.Tables[0].Rows[0]["COMPANYNAME"]); 
 

                            }
                            if (ds.Tables[3].Rows.Count > 0)
                            {
                                lblApplDate.Text = lblApplDate1.Text = Convert.ToString(ds.Tables[3].Rows[0]["APPLICATIONDATE"]);

                            }

                        }

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
        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {

                Response.Redirect("~/User/Dashboard/MainDashboard.aspx");

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }



        protected void btndownload_Click(object sender, EventArgs e)
        {
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (StringWriter sw = new StringWriter())
                    {
                        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                        {

                            //GVCFOReport.AllowPaging = false;
                            //this.BindaApplicatinDetails();
                            //ackcontent.HeaderRow.ForeColor = System.Drawing.Color.Black;
                            //GVCFOReport.FooterRow.Visible = false;
                            Page.RenderControl(hw);

                            string htmlContent = sw.ToString();

                            Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);


                            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);

                            pdfDoc.Open();

                            using (StringReader sr = new StringReader(htmlContent))
                            {
                                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                            }

                            pdfDoc.Close();

                            // Send the generated PDF to the client browser
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-disposition", "attachment;filename=IndustryAck_ " + DateTime.Now.ToString("M/d/yyyy") + ".pdf");
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