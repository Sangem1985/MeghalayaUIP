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
using MeghalayaUIP.BAL.PreRegBAL;

namespace MeghalayaUIP.Dept
{
    public partial class IntenttoInvestDashboard : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        PreRegBAL indstregBAL = new PreRegBAL();
        DeptUserInfo ObjUserInfo = new DeptUserInfo();
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
                    // username = ObjUserInfo.UserName;

                    if (hdnUserID.Value == "")
                    {
                        hdnUserID.Value = ObjUserInfo.UserID;
                    }

                    Page.MaintainScrollPositionOnPostBack = true;
                    Failure.Visible = false;
                    success.Visible = false;
                    if (!IsPostBack)
                    {
                        BindData();

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
                throw ex;
            }
        }
        public void BindData()
        {

            try
            {
                DataTable dt = new DataTable();

                dt = indstregBAL.GetIntentInvestDashBoard();
                if (dt.Rows.Count > 0)
                {
                    gvPreRegDtls.DataSource = dt;
                    gvPreRegDtls.DataBind();
                }
                else
                {
                    gvPreRegDtls.DataSource = null;
                    gvPreRegDtls.DataBind();
                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }

        protected void btnDetails_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            Label lblID = (Label)row.FindControl("lblID");
            if (lblID != null)
            {
                string ID = lblID.Text;
                //Session["ID"] = lblID.Text;
                string newurl = "~/IntenttoInvestPrint.aspx?ID=" + ID;
                Response.Redirect(newurl);
            }


        }

        protected void gvPreRegDtls_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{

            //}
        }
        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Dept/Dashboard/DeptDashBoard.aspx");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void ExportToExcel()
        {
            try
            {
                gvPreRegDtls.Columns[4].Visible = true;
                gvPreRegDtls.Columns[5].Visible = true;
                gvPreRegDtls.Columns[6].Visible = true;
                gvPreRegDtls.Columns[9].Visible = true;
                gvPreRegDtls.Columns[10].Visible = true;
                gvPreRegDtls.Columns[11].Visible = true;
                gvPreRegDtls.Columns[12].Visible = true;
                gvPreRegDtls.Columns[13].Visible = true;
                gvPreRegDtls.Columns[14].Visible = true;
                gvPreRegDtls.Columns[15].Visible = true;
                gvPreRegDtls.Columns[16].Visible = true;
                gvPreRegDtls.Columns[17].Visible = true;
                gvPreRegDtls.Columns[18].Visible = true;
                gvPreRegDtls.Columns[19].Visible = true;
                gvPreRegDtls.Columns[20].Visible = true;
                gvPreRegDtls.Columns[21].Visible = true;
                gvPreRegDtls.Columns[23].Visible = false;

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=IntentToInvestApplications" + DateTime.Now.ToString("M/d/yyyy") + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                using (StringWriter sw = new StringWriter())
                {
                    string style = @"<style>
                        .gridTable { border-collapse: collapse; width: 100%; }
                        .gridTable th, .gridTable td { border: 1px solid black; padding: 5px; text-align: left; }
                     </style>";

                    gvPreRegDtls.Style["width"] = "680px";
                    gvPreRegDtls.CssClass = "gridTable"; 

                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    gvPreRegDtls.RenderControl(hw);

                    // Add a custom header and include styles
                    string headerTable = @"<table class='gridTable'>
                              <tr>
                                  <td align='center' colspan='13'><h4>" + lblHeading.Text + @"</h4></td>
                              </tr>
                          </table>";

                    Response.Write(style); // Write the CSS to the response
                    Response.Write(headerTable); // Write the custom header
                    Response.Write(sw.ToString()); // Write the GridView HTML with borders
                    Response.Flush();
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                foreach (DataControlField column in gvPreRegDtls.Columns)
                {
                    if (column.HeaderText == "Details")
                    {
                        column.Visible = false;
                    }
                }
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void btnExcel_Click(object sender, ImageClickEventArgs e)
        {
            ExportToExcel();
        }
    }
}