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
    public partial class CFEDeptDashboard : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        CFEBAL CfeBAL = new CFEBAL();
        CFEDtls objCFE = new CFEDtls();
        DeptUserInfo ObjUserInfo = new DeptUserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
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
                    objCFE.UserID = ObjUserInfo.UserID;
                    objCFE.UserName = ObjUserInfo.UserName;
                    objCFE.Role = Convert.ToInt32(ObjUserInfo.Roleid);
                    objCFE.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                    dt = CfeBAL.GetCFEDashBoard(objCFE);

                    lblTOTALAPPLICATIONS.Text = dt.Rows[0]["TOTALAPPLICATIONS"].ToString();
                    lblPRESCRUTINYCOMPLETED.Text = dt.Rows[0]["PRESCRUTINYCOMPLETED"].ToString();
                    lblQUERYPENDING.Text = dt.Rows[0]["QUERYPENDING"].ToString();
                    lblPRESCRUTINYPENDING.Text = dt.Rows[0]["PRESCRUTINYPENDING"].ToString();
                    lblADDITIONALPAYMENTRAISED.Text = dt.Rows[0]["ADDITIONALPAYMENTRAISED"].ToString();
                    lblTOTALAPPROVALISSUED.Text = dt.Rows[0]["TOTALAPPROVALISSUED"].ToString();

                    lblAPPROVALPENDING.Text = dt.Rows[0]["APPROVALPENDING"].ToString();
                    lblREJECTED.Text = dt.Rows[0]["REJECTED"].ToString();
                    lblPREREJECTED.Text = dt.Rows[0]["PREREJECTED"].ToString(); 
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}