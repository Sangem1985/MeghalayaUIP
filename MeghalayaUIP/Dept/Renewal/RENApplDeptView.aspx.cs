using MeghalayaUIP.BAL.RenewalBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Dept.Renewal
{
    public partial class RENApplDeptView : System.Web.UI.Page
    {
        RenewalBAL objRenbal = new RenewalBAL();
        RENDtls ObjREN = new RENDtls();
        DeptUserInfo ObjUserInfo = new DeptUserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                if (Session["DeptUserInfo"] != null)
                {

                    if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
                    {
                        ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
                    }
                    // username = ObjUserInfo.UserName;
                }
                Bind();
            }
        }
        public void Bind()
        {
            try
            {
                DataTable dt = new DataTable();
                ObjREN.ViewStatus = Request.QueryString["status"].ToString();
                if (ObjUserInfo.Deptid != null && ObjUserInfo.Deptid != "")
                {
                    ObjREN.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                }
                ObjREN.Role = Convert.ToInt32(ObjUserInfo.Roleid);
                ObjREN.UserID = ObjUserInfo.UserID;
                dt = objRenbal.GetRENDashBoardView(ObjREN);
                gvCFEDtls.DataSource = dt;
                gvCFEDtls.DataBind();
            }
            catch(Exception ex)
            {

                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
          
        }
        protected void gvCFEDtls_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VIEW")
            {
                //GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                //int RowIndex = gvr.RowIndex;

                string[] Arguents = e.CommandArgument.ToString().Split('$');
                string RENID_RENQDID = Arguents[0];
                string INVESTERID = Arguents[1];
                string UNITID = Arguents[2];
                string ApprovalID = Arguents[3];
                string DEPTID = Arguents[4];
                int stage = 3;

                ObjREN.Questionnaireid = RENID_RENQDID;
                ObjREN.Investerid = INVESTERID;
                ObjREN.Stage = stage;
                Session["Questionnaireid"] = RENID_RENQDID;
                Session["INVESTERID"] = INVESTERID;
                Session["stage"] = stage;
                Session["UNITID"] = UNITID;
                Session["ApprovalID"] = ApprovalID;
                Session["DEPTID"] = DEPTID;
                Response.Redirect("RENApplDeptProcess.aspx?status=" + Request.QueryString["status"].ToString());
            }
        }
        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Dept/Renewal/RENDeptDashboard.aspx");
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