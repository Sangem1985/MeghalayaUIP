using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MeghalayaUIP.BAL.PreRegBAL;
using MeghalayaUIP.Common;

namespace MeghalayaUIP.Dept.PreReg
{
    public partial class PreRegApplCommitteeDashBoard : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        PreRegBAL PreBAL = new PreRegBAL();
        PreRegDtls prd = new PreRegDtls();
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
                    prd.UserID = ObjUserInfo.UserID;
                    prd.UserName = ObjUserInfo.UserName;
                    prd.Role = Convert.ToInt32(ObjUserInfo.Roleid);
                    if (ObjUserInfo.Deptid != null && ObjUserInfo.Deptid != "")
                    {
                        prd.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                    }
                    dt = PreBAL.GetPreRegDashBoard(prd);

                    lblTotalApp.Text = dt.Rows[0]["COMMTOTAL"].ToString();
                    lblToBeProcessed.Text = dt.Rows[0]["COMMTOBEPROCESSED"].ToString();
                    //lblprocessed.Text = dt.Rows[0]["COMMPROCESSED"].ToString();
                    lblApproved.Text = dt.Rows[0]["COMMAPPROVED"].ToString();
                    lblQuery.Text = dt.Rows[0]["COMMQUERY"].ToString();
                    lblQueryReplied.Text = dt.Rows[0]["COMMQUERYREPLIED"].ToString();
                    //lblQueryNotRepld.Text = dt.Rows[0]["COMMQUERYREPLIED"].ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}