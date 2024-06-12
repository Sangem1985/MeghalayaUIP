using MeghalayaUIP.BAL.PreRegBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
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
    }
}