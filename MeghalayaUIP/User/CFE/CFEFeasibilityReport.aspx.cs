using MeghalayaUIP.BAL.CFEBLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.tool.xml;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace MeghalayaUIP.User.CFE
{
    public partial class CFEFeasibilityReport : System.Web.UI.Page
    {
        CFEBAL objcfebal = new CFEBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindFeasibilityReport();
            }
            // CFEQID=Convert.ToInt32()

            //  ViewState["CFEQID"] = "114";
            //Convert.ToString(["UNITID"]);

        }

        public void BindFeasibilityReport()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfebal.GetFeasibilityReport(114);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow row = ds.Tables[0].Rows[0];
                        lblFeederid.Text = Convert.ToString(row["CFE_FR_ID"]);
                        lblQdid.Text = Convert.ToString(row["CFE_QDID"]);
                        lblApplicationregno.Text = Convert.ToString(row["CFE_APPLICATION_REG_NO"]);
                        lblNearestconsumerid.Text = Convert.ToString(row["CFE_NEAREST_CONSUMER_ID"]);
                        lblSubstationname.Text = Convert.ToString(row["CFE_SUBSTATION"]);
                        lblfeedername.Text = Convert.ToString(row["CFE_FEEDER_NAME"]);
                        lblDtc.Text = Convert.ToString(row["CFE_DTC"]);
                        lblPolenumber.Text = Convert.ToString(row["CFE_POLE_NO"]);
                        lblProductname.Text = Convert.ToString(row["CFE_PRODUCT"]);
                        lblConnectionType.Text = Convert.ToString(row["CFE_CONNECTION_TYPE"]);
                        lblLoadKw.Text = Convert.ToString(row["CFE_LOAD_KW"]);
                        lblNoofpremises.Text = Convert.ToString(row["CFE_NO_OF_PREMISES"]);
                        lblSitedemension.Text = Convert.ToString(row["CFE_SITE_DIMENSION_SFT"]);
                        lblBuiltuparea.Text = Convert.ToString(row["CFE_BUILTUP_AREA"]);
                        lblNoofloors.Text = Convert.ToString(row["CFE_NO_OF_FLOORS"]);
                        lblConnectionphase.Text = Convert.ToString(row["CFE_CONNECTION_PHASE"]);
                        lblBuildingtype.Text = Convert.ToString(row["CFE_BUILDING"]);
                        lblRequestedgroundsize.Text = Convert.ToString(row["CFE_REQUESTED_UG_CABLE_SIZE"]);
                        lblRequestedoverheadsize.Text = Convert.ToString(row["CFE_REQUESTED_OH_CABLE_SIZE"]);
                        lblLatitude.Text = Convert.ToString(row["CFE_LATITUDE"]);
                        lblLongitude.Text = Convert.ToString(row["CFE_LONGITUDE"]);
                        lblServicetype.Text = Convert.ToString(row["CFE_SERVICE_TYPE"]);
                        lblBillingtype.Text = Convert.ToString(row["CFE_BILLING_TYPE"]);
                        lblAreatype.Text = Convert.ToString(row["CFE_AREA_TYPE"]);
                        lblRemarks.Text = Convert.ToString(row["CFE_REMARKS"]);
                        lblDocumentid.Text = Convert.ToString(row["CFE_DOCUMENT_ID"]);
                        lblDocumentname.Text = Convert.ToString(row["CFE_DOCUMENT_NAME"]);
                        lblDocumentpath.Text = Convert.ToString(row["CFE_DOCUMENT_PATH"]);
                        lblMetertype.Text = Convert.ToString(row["CFE_METER_TYPE"]);
                        lblMeteredside.Text = Convert.ToString(row["CFE_METERED_SIDE"]);
                        lblLoadKva.Text = Convert.ToString(row["CFE_LOAD_KVA"]);

                    }

                }

            }
            catch
            {

            }




        }

        protected void btnDownload_Click(object sender, EventArgs e)
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
            catch
            {

            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
    }
}