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
    public partial class CFODeptDashboard : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        CFOBAL CfoBAL = new CFOBAL();
        CFODtls objCFO = new CFODtls();
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
                        if (ObjUserInfo.Roleid == "8")
                        {
                            divScrutiny.Visible = true;
                            divApproval.Visible = false;
                        }
                        else if (ObjUserInfo.Roleid == "9")
                        {
                            divScrutiny.Visible = false;
                            divApproval.Visible = true;
                        }
                        // username = ObjUserInfo.UserName;
                    }
                    objCFO.UserID = ObjUserInfo.UserID;
                    objCFO.UserName = ObjUserInfo.UserName;
                    objCFO.Role = Convert.ToInt32(ObjUserInfo.Roleid);
                    objCFO.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                    dt = CfoBAL.GetCFODashBoard(objCFO);

                    lblTOTALAPPLICATIONS.Text = dt.Rows[0]["TOTALAPPLICATIONS"].ToString();
                    lblPRESCRUTINYCOMPLETED.Text = dt.Rows[0]["PRESCRUTINYCOMPLETED"].ToString();                 
                    lblPRESCRUTINYPENDING.Text = dt.Rows[0]["PRESCRUTINYPENDING"].ToString();
                    lblPREREJECTED.Text = dt.Rows[0]["PRESCRUTINYREJECTED"].ToString();
                    lblADDITIONALPAYMENTRAISED.Text = dt.Rows[0]["ADDITIONALPAYMENTRAISED"].ToString();
                    lblQUERYPENDING.Text = dt.Rows[0]["QUERYPENDING"].ToString();
                
                    lblTOTALAPPROVALISSUED.Text = dt.Rows[0]["TOTALAPPROVALISSUED"].ToString();
                    lblAPPROVALPENDING.Text = dt.Rows[0]["APPROVALPENDING"].ToString();
                    lblREJECTED.Text = dt.Rows[0]["REJECTED"].ToString();
               
                    
                    if (lblTOTALAPPLICATIONS.Text == "0")
                        anchrTotal.HRef = "#";
                    if (lblPRESCRUTINYCOMPLETED.Text == "0")
                        anchrScrtnyCmpld.HRef = "#";
                    if (lblPRESCRUTINYPENDING.Text == "0")
                        anchrScrtnyPndng.HRef = "#";
                    if (lblPREREJECTED.Text == "0")
                        anchrScrtnyRjctd.HRef = "#";
                    if (lblADDITIONALPAYMENTRAISED.Text == "0")
                        anchrAddlPaymnt.HRef = "#";
                    if (lblQUERYPENDING.Text == "0")
                        anchrQryRaised.HRef = "#";
                    if (lblTOTALAPPROVALISSUED.Text == "0")
                        anchrApproved.HRef = "#";
                    if (lblAPPROVALPENDING.Text == "0")
                        anchrAprvlPndng.HRef = "#";
                    if (lblREJECTED.Text == "0")
                        anchrAprvlRjctd.HRef = "#";
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Dept/DeptDashboard.aspx");
            }
            catch (Exception ex)
            {

            }
        }

    }
}