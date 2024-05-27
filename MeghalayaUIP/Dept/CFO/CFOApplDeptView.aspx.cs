using MeghalayaUIP.BAL.CFOBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Dept.CFO
{
    public partial class CFOApplDeptView : System.Web.UI.Page
    {

        DeptUserInfo ObjUserInfo = new DeptUserInfo();
        CFODtls objcfodtls = new CFODtls();
        CFOBAL CfoBAL = new CFOBAL();
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
                }
                Bind();
            }
        }
        public void Bind()
        {
            DataTable dt = new DataTable();
            objcfodtls.ViewStatus = Request.QueryString["status"].ToString();
            if (ObjUserInfo.Deptid != null && ObjUserInfo.Deptid != "")
            {
                objcfodtls.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
            }
            objcfodtls.Role = Convert.ToInt32(ObjUserInfo.Roleid);
            objcfodtls.UserID = ObjUserInfo.UserID;
            dt = CfoBAL.GetCFODashBoardView(objcfodtls);
            gvCFODtls.DataSource = dt;
            gvCFODtls.DataBind();
        }
        protected void gvCFODtls_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VIEW")
            {
                string[] Arguents = e.CommandArgument.ToString().Split('$');
                string CFOQDID = Arguents[0];
                string INVESTERID = Arguents[1];
                string UNITID = Arguents[2];
                string ApprovalID = Arguents[3];
                int stage = 3;

                objcfodtls.Questionnaireid = CFOQDID;
                objcfodtls.Investerid = INVESTERID;
                objcfodtls.Stage = stage;
                Session["Questionnaireid"] = CFOQDID;
                Session["INVESTERID"] = INVESTERID;
                Session["stage"] = stage;
                Session["UNITID"] = UNITID;
                Session["ApprovalID"] = ApprovalID;
                Response.Redirect("CFOApplDeptProcess.aspx?status=" + Request.QueryString["status"].ToString());
            }
        }

    }
}