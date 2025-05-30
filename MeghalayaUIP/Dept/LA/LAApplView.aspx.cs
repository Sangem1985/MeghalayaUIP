using MeghalayaUIP.BAL.LABAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Dept.LA
{
    public partial class LAApplView : System.Web.UI.Page
    {

        LABAL Objland = new LABAL();
        LADeptDtls objDtls = new LADeptDtls();
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
                    objDtls.ViewStatus = Request.QueryString["status"].ToString();

                    if (Request.QueryString["status"].ToString() == "TOTAL")
                    { lblHdng.Text = "Land Registration - Total Applications"; }
                    else if (Request.QueryString["status"].ToString() == "TOBEPROCESSED")
                    { lblHdng.Text = "Land Registration Applications - To be Processed"; }
                    else if (Request.QueryString["status"].ToString() == "APPROVED")
                    { lblHdng.Text = "Land Registration Applications - Forwarded to Committee"; }
                    else if(Request.QueryString["status"].ToString()== "REJECTED")
                    { lblHdng.Text = "Land Registration Applications - Reject"; }
                    else if (Request.QueryString["status"].ToString() == "TODEPTQUERY")
                    { lblHdng.Text = "Land Registration Applications - Query Raised to Departments"; }
                    else if (Request.QueryString["status"].ToString() == "DEPTREPLIEDTOLAND")
                    { lblHdng.Text = "Land Registration Applications - Queries Redressed by Departments"; }
                    else if (Request.QueryString["status"].ToString() == "LANDQUERYTOAPPLCNT")
                    { lblHdng.Text = "Land Registration Applications - Query Raised to Investor"; }
                    else if (Request.QueryString["status"].ToString() == "APPLCNTREPLIEDTOLAND")
                    { lblHdng.Text = "Land Registration Applications - Queries Redressed by Investor"; }
                    else if (Request.QueryString["status"].ToString() == "COMMQUERYTOLAND")
                    { lblHdng.Text = "Land Registration Applications - Query Raised by Committee"; }
                    else if (Request.QueryString["status"].ToString() == "LANDREPLIEDTOCOMM")
                    { lblHdng.Text = "Land Registration Applications - Committee Queries Redressed by IMA"; }
                    else if (Request.QueryString["status"].ToString() == "LANDFWDCOMMQRYTOAPPLCNT")
                    { lblHdng.Text = "Land Registration Applications - Committe Query Forwarded to Investor"; }
                    //else if (Request.QueryString["status"].ToString() == "APPLCNTREPLIEDTOCOMMQRY")
                    //{ lblHdng.Text = "Industry Registration Applications - Committe Query Redressed by Investor"; }
                    else if (Request.QueryString["status"].ToString() == "LANDFWDCOMMQRYTODEPT")
                    { lblHdng.Text = "Land Registration Applications - Committe Query Forwarded to Departments"; }
                    else if (Request.QueryString["status"].ToString() == "DEPTREPLIEDTOCOMMQRY")
                    { lblHdng.Text = "Land Registration Applications - Committe Query Redressed by Departments"; }
                }
                else
                {
                    objDtls.ViewStatus = "LANDTOTAL";
                    lblHdng.Text = "Land Application Total Applications";
                }
                if (ObjUserInfo.Deptid != null && ObjUserInfo.Deptid != "")
                {
                    objDtls.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                }
                objDtls.Role = Convert.ToInt32(ObjUserInfo.Roleid);
                objDtls.UserID = ObjUserInfo.UserID;
                dt = Objland.GetLandAllottmentDashBoardView(objDtls);
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

                    objDtls.Unitid = UNITID;
                    objDtls.Investerid = INVESTERID;
                    objDtls.Stage = stage;
                    Session["UNITID"] = UNITID;
                    Session["INVESTERID"] = INVESTERID;
                    Session["stage"] = stage;
                    Response.Redirect("LAApplDeptProcess.aspx?status=" + Request.QueryString["status"].ToString());
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void gvPreRegDtls_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Button button = e.Row.FindControl("ciw_id") as Button;
                if (button != null)
                {
                    if (Request.QueryString["status"].ToString() == "TOBEPROCESSED" ||
                        Request.QueryString["status"].ToString() == "DEPTREPLIEDTOLAND" ||
                        Request.QueryString["status"].ToString() == "APPLCNTREPLIEDTOLAND" ||
                        //  Request.QueryString["status"].ToString() == "COMMQUERYTOLAND" ||
                        Request.QueryString["status"].ToString() == "APPLCNTREPLIEDTOCOMMQRY" ||
                        Request.QueryString["status"].ToString() == "DEPTREPLIEDTOCOMMQRY")
                        button.Text = "Process";
                    else
                        button.Text = "View";

                }
            }
        }

        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Dept/LA/LADeptdashboard.aspx");
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
    }
}