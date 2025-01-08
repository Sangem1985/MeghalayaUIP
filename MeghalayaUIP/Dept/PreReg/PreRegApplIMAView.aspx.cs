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

namespace MeghalayaUIP.Dept.PreReg
{
    public partial class PreRegApplIMAView : System.Web.UI.Page
    {
        PreRegBAL PreBAL = new PreRegBAL();
        PreRegDtls prd = new PreRegDtls();
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
                    hdnUserID.Value = ObjUserInfo.UserID;

                    Page.MaintainScrollPositionOnPostBack = true;
                    Failure.Visible = false;
                    success.Visible = false;
                    if (!IsPostBack)
                    {
                        Bind();
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public void Bind()
        {
            try
            {
                DataTable dt = new DataTable();
                lblHdng.Text = "";
                if (Request.QueryString.Count > 0)
                {
                    prd.ViewStatus = Request.QueryString["status"].ToString();

                    if (Request.QueryString["status"].ToString() == "IMATOTAL")
                    { lblHdng.Text = "Industry Registration - Total Applications"; }
                    else if (Request.QueryString["status"].ToString() == "IMATOBEPROCESSED")
                    { lblHdng.Text = "Industry Registration Applications - To be Processed"; }
                    else if (Request.QueryString["status"].ToString() == "IMAPPROVED")
                    { lblHdng.Text = "Industry Registration Applications - Forwarded to Committee"; }
                    else if (Request.QueryString["status"].ToString() == "IMATODEPTQUERY")
                    { lblHdng.Text = "Industry Registration Applications - Query Raised to Departments"; }
                    else if (Request.QueryString["status"].ToString() == "DEPTREPLIEDTOIMA")
                    { lblHdng.Text = "Industry Registration Applications - Queries Redressed by Departments"; }
                    else if (Request.QueryString["status"].ToString() == "IMAQUERYTOAPPLCNT")
                    { lblHdng.Text = "Industry Registration Applications - Query Raised to Investor"; }
                    else if (Request.QueryString["status"].ToString() == "APPLCNTREPLIEDTOIMA")
                    { lblHdng.Text = "Industry Registration Applications - Queries Redressed by Investor"; }
                    else if (Request.QueryString["status"].ToString() == "COMMQUERYTOIMA")
                    { lblHdng.Text = "Industry Registration Applications - Query Raised by Committee"; }
                    else if (Request.QueryString["status"].ToString() == "IMAREPLIEDTOCOMM")
                    { lblHdng.Text = "Industry Registration Applications - Committee Queries Redressed by IMA"; }
                    else if (Request.QueryString["status"].ToString() == "IMAFWDCOMMQRYTOAPPLCNT")
                    { lblHdng.Text = "Industry Registration Applications - Committe Query Forwarded to Investor"; }
                    else if (Request.QueryString["status"].ToString() == "APPLCNTREPLIEDTOCOMMQRY")
                    { lblHdng.Text = "Industry Registration Applications - Committe Query Redressed by Investor"; }
                    else if (Request.QueryString["status"].ToString() == "IMAFWDCOMMQRYTODEPT")
                    { lblHdng.Text = "Industry Registration Applications - Committe Query Forwarded to Departments"; }
                    else if (Request.QueryString["status"].ToString() == "DEPTREPLIEDTOCOMMQRY")
                    { lblHdng.Text = "Industry Registration Applications - Committe Query Redressed by Departments"; }
                }
                else
                {
                    prd.ViewStatus = "IMATOTAL";
                    lblHdng.Text = "Industry Registration Total Applications";
                }
                if (ObjUserInfo.Deptid != null && ObjUserInfo.Deptid != "")
                {
                    prd.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                }
                prd.Role = Convert.ToInt32(ObjUserInfo.Roleid);
                prd.UserID = ObjUserInfo.UserID;
                dt = PreBAL.GetPreRegDashBoardView(prd);
                gvPreRegDtls.DataSource = dt;
                gvPreRegDtls.DataBind();
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void gvPreRegDtls_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "VIEW")
                {
                    string[] Arguents = e.CommandArgument.ToString().Split('$');
                    string UNITID = Arguents[0];
                    string INVESTERID = Arguents[1];

                    int stage = 3;

                    prd.Unitid = UNITID;
                    prd.Investerid = INVESTERID;
                    prd.Stage = stage;
                    Session["UNITID"] = UNITID;
                    Session["INVESTERID"] = INVESTERID;
                    Session["stage"] = stage;
                    Response.Redirect("PreRegApplIMAProcess.aspx?status=" + Request.QueryString["status"].ToString());
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Dept/PreReg/PreRegApplIMADashBoard.aspx");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void gvPreRegDtls_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    Button button = e.Row.FindControl("ciw_id") as Button;
                    if (button != null)
                        if (Request.QueryString.Count > 0)
                        {
                            if (
                                Request.QueryString["status"].ToString() == "IMATOBEPROCESSED" ||
                                Request.QueryString["status"].ToString() == "DEPTREPLIEDTOIMA" ||
                                Request.QueryString["status"].ToString() == "APPLCNTREPLIEDTOIMA" ||
                                Request.QueryString["status"].ToString() == "COMMQUERYTOIMA" ||
                                Request.QueryString["status"].ToString() == "APPLCNTREPLIEDTOCOMMQRY" ||
                                Request.QueryString["status"].ToString() == "DEPTREPLIEDTOCOMMQRY")
                                button.Text = "Process";
                            else
                                button.Text = "View";


                        }
                        else { button.Text = "View"; }
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
                gvPreRegDtls.Columns[8].Visible = false;
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
                gvPreRegDtls.Columns[22].Visible = false;
              //  gvPreRegDtls.Columns[23].Visible = false;

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=Industry Registrations" + DateTime.Now.ToString("M/d/yyyy") + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                using (StringWriter sw = new StringWriter())
                {
                    string style = @"<style>
                        .gridTable { border-collapse: collapse; width: 100%; }
                        .gridTable th, .gridTable td { border: 1px solid black; padding: 5px; text-align: left; }
                     </style>";

                    gvPreRegDtls.Style["width"] = "680px";
                    gvPreRegDtls.CssClass = "gridTable"; // Apply the CSS class to the GridView

                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    gvPreRegDtls.RenderControl(hw);

                    // Add a custom header and include styles
                    string headerTable = @"<table class='gridTable'>
                              <tr>
                                  <td align='center' colspan='19'><h4>" + lblHeading.Text + @"</h4></td>
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
                    if (column.HeaderText == "Actions")
                    {
                        column.Visible = false;
                    }
                }
            }
        }
    }
}