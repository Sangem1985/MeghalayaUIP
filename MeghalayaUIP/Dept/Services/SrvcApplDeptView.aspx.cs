using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.BAL.SVRCBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Dept.Services
{
    public partial class SrvcApplDeptView2 : System.Web.UI.Page
    {
        DeptUserInfo ObjUserInfo = new DeptUserInfo();
        SVRCBAL objSRVCBAL = new SVRCBAL();
        SVRCBAL svrcDtls = new SVRCBAL();
        //  SRVCBAL SrvcBAL = new SRVCBAL();
        //SVRCDAL objSRVCDAL = new SVRCDAL();
        SVRCDtls SRVCDET = new SVRCDtls();
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
                SRVCDET.ViewStatus = Request.QueryString["status"].ToString();
                if (ObjUserInfo.Deptid != null && ObjUserInfo.Deptid != "")
                {
                    SRVCDET.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                }
                SRVCDET.Role = Convert.ToInt32(ObjUserInfo.Roleid);
                SRVCDET.UserID = ObjUserInfo.UserID;
                dt = objSRVCBAL.GetSRVCDashBoardView(SRVCDET);
                gvSrvcDtls.DataSource = dt;
                gvSrvcDtls.DataBind();
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }

        protected void gvSrvcDtls_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VIEW")
            {
                //GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                //int RowIndex = gvr.RowIndex;

                string[] Arguents = e.CommandArgument.ToString().Split('$');
                string CFEQDID = Arguents[0];
                string INVESTERID = Arguents[1];
                string UNITID = Arguents[2];
                string ApprovalID = Arguents[3];
                string DEPTID = Arguents[4];
                int stage = 3;

                SRVCDET.Questionnaireid = CFEQDID;
                SRVCDET.Investerid = INVESTERID;
                SRVCDET.Stage = stage;
                Session["Questionnaireid"] = CFEQDID;
                Session["INVESTERID"] = INVESTERID;
                Session["stage"] = stage;
                Session["UNITID"] = UNITID;
                Session["ApprovalID"] = ApprovalID;
                Session["DEPTID"] = DEPTID;
                Response.Redirect("SrvcApplDeptProcess.aspx?status=" + Request.QueryString["status"].ToString());
            }
        }

        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Dept/Services/SrvcDeptDashboard.aspx");
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