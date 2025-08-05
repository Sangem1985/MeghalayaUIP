using MeghalayaUIP.BAL.CFEBLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;



namespace MeghalayaUIP.User.CFE
{
    public partial class CFECRCertificate : System.Web.UI.Page
    {
        CFEBAL objcfebal = new CFEBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMPDCLReport();
            }

        }
        public void BindMPDCLReport()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfebal.GetMPDCLReport(114);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblConsumerName.Text = ds.Tables[0].Rows[0]["CFEID_REPNAME"].ToString();
                        lblAdress.Text = ds.Tables[0].Rows[0]["ADDRESS"].ToString();
                        lblestimation.Text = ds.Tables[0].Rows[0]["ESTIMATION"].ToString();
                        lblSecurityDeposit.Text = ds.Tables[0].Rows[0]["SECURITYDEPOSIT"].ToString();
                        lblconsumerid.Text = ds.Tables[0].Rows[0]["CONSUMERID"].ToString();
                        lblDateofService.Text = ds.Tables[0].Rows[0]["DATEOFSERVICE"].ToString();
                        lblSanctionedload.Text = ds.Tables[0].Rows[0]["SANCTIONEDLOAD"].ToString();
                        lblMeterMake.Text = ds.Tables[0].Rows[0]["METERMAKE"].ToString();
                        lblMeterSlNo.Text = ds.Tables[0].Rows[0]["METERSERIALNUMBER"].ToString();
                        lblMeterType.Text = ds.Tables[0].Rows[0]["METERTYPE"].ToString();
                        lblCtRatio.Text = ds.Tables[0].Rows[0]["CTBYPTRATIO"].ToString();
                        lblRefApplicationNo.Text = ds.Tables[0].Rows[0]["REFERENCE_NO"].ToString();
                        lblRefDate.Text = ds.Tables[0].Rows[0]["CREATED_DATE"].ToString();
                        //lblApplicable.Text = ds.Tables[0].Rows[0]["CATEGORYAPPLICABLE"].ToString();
                        lblEstimationReceiptNo.Text = ds.Tables[0].Rows[0]["REFERENCE_NO"].ToString();
                        lblSecurityReceiptNo.Text = ds.Tables[0].Rows[0]["REFERENCE_NO"].ToString();
                        lblReferenceNo.Text = ds.Tables[0].Rows[0]["REFERENCE_NO"].ToString();
                        lblMpdclDate.Text = ds.Tables[0].Rows[0]["CREATED_DATE"].ToString();
                        lblMpdcldated.Text = ds.Tables[0].Rows[0]["CREATED_DATE"].ToString();
                        lblSecurityDate.Text = ds.Tables[0].Rows[0]["CREATED_DATE"].ToString();
                        lblEstimationDate.Text = ds.Tables[0].Rows[0]["CREATED_DATE"].ToString();
                        lblApplicationDate.Text = ds.Tables[0].Rows[0]["CREATED_DATE"].ToString();
                        lblApplicantName.Text = ds.Tables[0].Rows[0]["CFEID_REPNAME"].ToString();

                    }

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        protected void btnDownload_Click1(object sender, EventArgs e)
        {

            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (StringWriter sw = new StringWriter())
                    {
                        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                        {
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
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-disposition", "attachment;filename=IndustryAck_ " + DateTime.Now.ToString("M/d/yyyy") + ".pdf");
                            Response.Cache.SetCacheability(HttpCacheability.NoCache);
                            Response.OutputStream.Write(memoryStream.GetBuffer(), 0, memoryStream.GetBuffer().Length);
                            Response.Flush();
                            Response.End();

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
    }
}