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
using iTextSharp.tool.xml;

namespace MeghalayaUIP.User.Services
{
    public partial class SrvcAckSlip : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblApplDate.Text = "07-03-2025";
            lblUIDNo.Text = "SRVC/2025/102";
            lblApproval.Text = "Authorization under the Hazardous and Other Waste (Management and Transboundary Movement) Rules 2016";
            lblApplDate1.Text = "09-03-2025";//DateTime.Now.ToString("dd-MM-yyyy");
            lblApplicant.InnerText = "TEST";
            lblEnterPrise.InnerText = "Manufacturing";
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

        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {

                //Response.Redirect("~/User/Dashboard/MainDashboard.aspx");

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
    }
}