using MeghalayaUIP.BAL.PreRegBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Dept.PreReg
{
    public partial class PreRegApplCommitteeView : System.Web.UI.Page
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

                    if (IsPostBack == false)
                    {
                        if (Request.QueryString.Count > 0)
                            Bind();
                        else
                            Response.Redirect("PreRegApplCommitteeDashBoard.aspx");
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
                if (Request.QueryString["status"].ToString() == "COMMTOTAL")
                    lblHdng.Text = "Industry Registration - Total Applications";
                else if (Request.QueryString["status"].ToString() == "COMMTOBEPROCESSED")
                    lblHdng.Text = "Industry Registration Applications - To be Processed";
                else if (Request.QueryString["status"].ToString() == "COMMAPPROVED")
                    lblHdng.Text = "Industry Registration Applications - Approved";
                else if (Request.QueryString["status"].ToString() == "COMMREJECTED")
                    lblHdng.Text = "Industry Registration Applications - Rejected";
                else if (Request.QueryString["status"].ToString() == "COMMQUERY")
                    lblHdng.Text = "Industry Registration Applications - Query Raised  ";
                else if (Request.QueryString["status"].ToString() == "COMMQUERYREPLIED")
                    lblHdng.Text = "Industry Registration Applications - Queries Redressed ";

                DataTable dt = new DataTable();
                prd.ViewStatus = Request.QueryString["status"].ToString();
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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void gvPreRegDtls_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "VIEW")
                {
                    //GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    //int RowIndex = gvr.RowIndex;

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
                    Response.Redirect("PreRegApplCommitteeProcess.aspx?status=" + Request.QueryString["status"].ToString());
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Dept/PreReg/PreRegApplCommitteeDashBoard.aspx?status=" + Convert.ToString(Request.QueryString["status"]));
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
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
                    {
                        if (Request.QueryString["status"].ToString() == "COMMTOBEPROCESSED" ||
                            Request.QueryString["status"].ToString() == "COMMQUERYREPLIED")
                            button.Text = "Process";
                        else
                            button.Text = "View";

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
    }
}