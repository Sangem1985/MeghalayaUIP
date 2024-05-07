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
    public partial class PreRegApplDeptDashBoard : System.Web.UI.Page
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
                    prd.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                    dt = PreBAL.GetPreRegDashBoard(prd);

                    lblTotalApp.Text = dt.Rows[0]["TOTAL"].ToString();
                    lblToBeProcessed.Text = dt.Rows[0]["TOBEPROCESSED"].ToString();
                    lblprocessed.Text = dt.Rows[0]["PROCESSED"].ToString();
                    lblApproved.Text = dt.Rows[0]["Approved"].ToString(); 
                    lblQuery.Text = dt.Rows[0]["QUERYRIASED"].ToString(); 
                    lblQueryReplied.Text = dt.Rows[0]["QUERYREPLIED"].ToString(); 

                    lblIMAQuery.Text= dt.Rows[0]["IMATODEPTQUERY"].ToString();
                    lblDeptrepliedtoIMA.Text = dt.Rows[0]["DEPTREPLIEDTOIMA"].ToString();
                    lblIMAQueryforwardedtoAppl.Text = dt.Rows[0]["DEPTFWDIMAQUERYTOAPPL"].ToString();
                    lblAPPLREPLIEDTOIMAQUERY.Text = dt.Rows[0]["APPLREPLIEDTOIMAQUERY"].ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}