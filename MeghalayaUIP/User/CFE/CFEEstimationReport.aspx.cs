using MeghalayaUIP.BAL.CFEBLL;
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


namespace MeghalayaUIP.User.CFE
{
    public partial class CFEEstimationReport : System.Web.UI.Page
    {
        CFEBAL objcfebal = new CFEBAL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindComponentsDetails();
            }

        }
        public void BindComponentsDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfebal.GetComponentsDetails(126, 1038);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblconnid.Text = "1234"; //ds.Tables[0].Rows[0]["CONNECTIONID"].ToString();
                        lbldate.Text = "02-08-2025"; //ds.Tables[0].Rows[0]["connectiondate"].ToString();
                        lblVan.Text = "123";
                        lblRupees.Text = ds.Tables[0].Rows[0]["ESTIMATION"].ToString();

                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        lblAccountNo.Text = ds.Tables[1].Rows[0]["DEPT_ACCOUNTNO"].ToString();
                        lblBankname.Text = ds.Tables[1].Rows[0]["DEPT_ACCOUNTNAME"].ToString();
                        lblCode.Text = ds.Tables[1].Rows[0]["DEPT_IFSCCODE"].ToString();

                        lblaplicationdate.Text = "30-07-2025"; //ds.Tables[1].Rows[0]["DEPT_CREATED_DATE"].ToString();
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        grdcomponents.DataSource = ds.Tables[2];
                        grdcomponents.DataBind();
                    }
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        lblLoad.Text = "10KW"; //ds.Tables[3].Rows[0]["CFE_LOAD_KW"].ToString();
                        lblCategory.Text = ds.Tables[3].Rows[0]["CATEGORY"].ToString();
                        lblName.Text = "Test"; //ds.Tables[3].Rows[0]["CompandName"].ToString();
                        lblAddress.Text = "DANALDASILK, Danal Apal, SONGSAK, EAST GARO HILLS, 794001"; //ds.Tables[3].Rows[0]["ADDRESS"].ToString();
                        lblApplicationNo.Text = ds.Tables[3].Rows[0]["ApplicationNo"].ToString();
                        lblPhoneNo.Text = ds.Tables[3].Rows[0]["Mobile"].ToString();


                    }
                }
            }
            catch (Exception ex)
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
                            Response.AddHeader("content-disposition", "attachment;filename=" + DateTime.Now.ToString("MM-dd-yyyy") + ".pdf");

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