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
    public partial class PreRegApplIMADashBoard : System.Web.UI.Page
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
                    if(ObjUserInfo.Deptid !=null && ObjUserInfo.Deptid != "")
                    {
                        prd.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                    }
                    
                    dt = PreBAL.GetPreRegDashBoard(prd);

                    lblTotalApp.Text = dt.Rows[0]["TOTAL"].ToString();                    

                    lblIMATotal.Text = dt.Rows[0]["IMATOTAL"].ToString();
                    lblIMATOBEPROCESSED.Text = dt.Rows[0]["IMATOBEPROCESSED"].ToString();
                    //lblIMAPROCESSED.Text = dt.Rows[0]["IMAPROCESSED"].ToString();
                    lblIMAPPROVED.Text = dt.Rows[0]["IMAPPROVED"].ToString();
                    lblIMAQUERY.Text = dt.Rows[0]["IMAQUERY"].ToString();
                    lblIMAQUERYREPLIED.Text = dt.Rows[0]["IMAQUERYREPLIED"].ToString(); 
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}