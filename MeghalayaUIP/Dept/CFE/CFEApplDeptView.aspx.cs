using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.Common;

namespace MeghalayaUIP.Dept.CFE
{
    public partial class CFEApplDeptView : System.Web.UI.Page
    {
        DeptUserInfo ObjUserInfo = new DeptUserInfo();
        CFEDtls objcfedtls = new CFEDtls();
        CFEBAL CfeBAL = new CFEBAL();
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
            DataTable dt = new DataTable();
            objcfedtls.ViewStatus = Request.QueryString["status"].ToString();
            if (ObjUserInfo.Deptid != null && ObjUserInfo.Deptid != "")
            {
                objcfedtls.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
            }
            objcfedtls.Role = Convert.ToInt32(ObjUserInfo.Roleid);
            objcfedtls.UserID = ObjUserInfo.UserID;
            dt = CfeBAL.GetCFEDashBoardView(objcfedtls);
            gvCFEDtls.DataSource = dt;
            gvCFEDtls.DataBind();
        }

        protected void gvCFEDtls_RowCommand(object sender, GridViewCommandEventArgs e)
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

                objcfedtls.Questionnaireid = CFEQDID;
                objcfedtls.Investerid = INVESTERID;
                objcfedtls.Stage = stage;
                Session["Questionnaireid"] = CFEQDID;
                Session["INVESTERID"] = INVESTERID;
                Session["stage"] = stage;
                Session["UNITID"] = UNITID;
                Session["ApprovalID"] = ApprovalID;
                Session["DEPTID"] = DEPTID;
                Response.Redirect("CFEApplDeptProcess.aspx?status=" + Request.QueryString["status"].ToString());
            }
        }

        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Dept/CFE/CFEDeptDashboard.aspx");
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}