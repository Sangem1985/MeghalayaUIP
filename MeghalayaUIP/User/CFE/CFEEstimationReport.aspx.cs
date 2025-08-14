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
        string CFEQID;
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
                    }
                    if (hdnUserID.Value == "")
                    {
                        hdnUserID.Value = ObjUserInfo.Userid;
                    }

                    // Page.MaintainScrollPositionOnPostBack = true;

                    //success.Visible = false;
                    if (!IsPostBack)
                    {
                        BindComponentsDetails();
                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void BindComponentsDetails()
        {
            try
            {
                if (Request.QueryString.Count > 0)
                {
                    CFEQID = Convert.ToString(Request.QueryString[0]);

                    DataSet ds = new DataSet();
                    ds = objcfebal.GetComponentsDetails(CFEQID, hdnUserID.Value);

                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            lblconnid.Text = ds.Tables[0].Rows[0]["CONNECTIONID"].ToString();
                            lbldate.Text = ds.Tables[0].Rows[0]["connectiondate"].ToString();
                            // lblVan.Text = "123";
                            lblRupees.Text = ds.Tables[0].Rows[0]["ESTIMATION"].ToString();

                        }
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            lblAccountNo.Text = ds.Tables[1].Rows[0]["DEPT_ACCOUNTNO"].ToString();
                            lblBankname.Text = ds.Tables[1].Rows[0]["DEPT_ACCOUNTNAME"].ToString();
                            lblIFSCCode.Text = ds.Tables[1].Rows[0]["DEPT_IFSCCODE"].ToString();

                            lblaplicationdate.Text = ds.Tables[1].Rows[0]["DEPT_CREATED_DATE"].ToString();
                        }
                        if (ds.Tables[2].Rows.Count > 0)
                        {
                            grdcomponents.DataSource = ds.Tables[2];
                            grdcomponents.DataBind();
                        }
                        if (ds.Tables[3].Rows.Count > 0)
                        {
                            lblLoad.Text = ds.Tables[3].Rows[0]["CFE_LOAD_KW"].ToString();
                            lblCategory.Text = ds.Tables[3].Rows[0]["CATEGORY"].ToString();
                            lblName.Text = ds.Tables[3].Rows[0]["CompandName"].ToString();
                            lblAddress.Text = ds.Tables[3].Rows[0]["ADDRESS"].ToString();
                            lblApplicationNo.Text = ds.Tables[3].Rows[0]["ApplicationNo"].ToString();
                            lblPhoneNo.Text = ds.Tables[3].Rows[0]["Mobile"].ToString();
                            lblDistrict.Text = ds.Tables[3].Rows[0]["DISTRICT"].ToString();
                            lblMandal.Text = ds.Tables[3].Rows[0]["MANDAL"].ToString();
                        }



                        if (ds.Tables[4].Rows.Count > 0)
                        {
                            lblBankname.Text = ds.Tables[4].Rows[0]["DEPT_ACCOUNTNAME"].ToString();
                            lblAccountNo.Text = ds.Tables[4].Rows[0]["DEPT_ACCOUNTNO"].ToString();
                            lblIFSCCode.Text = ds.Tables[4].Rows[0]["DEPT_IFSCCODE"].ToString();
                        }
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