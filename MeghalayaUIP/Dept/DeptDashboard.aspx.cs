using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Dept
{
    public partial class DeptDashboard : System.Web.UI.Page
    {
        DeptUserInfo ObjUserInfo = new DeptUserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DeptUserInfo"] != null)
            {

                if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
                {
                    ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
                }
                if (ObjUserInfo.Roleid == "1")
                {
                    intenttoinvest.Visible = true;
                    prereg.Visible = true;
                    Preestablishment.Visible = false;
                    
                }
                else if (ObjUserInfo.Roleid == "4")
                {
                    intenttoinvest.Visible = false;
                    prereg.Visible = true;
                    Preestablishment.Visible = false;
                }
                else if (ObjUserInfo.Roleid == "5" || ObjUserInfo.Roleid == "6" || ObjUserInfo.Roleid == "7")
                {
                    intenttoinvest.Visible = false;
                    prereg.Visible = true;
                    Preestablishment.Visible = false;
                }
                else if (ObjUserInfo.Roleid == "8")
                {
                    intenttoinvest.Visible = false;
                    prereg.Visible = false;
                    Preestablishment.Visible = true;
                    PreOperational.Visible = true;
                }
                else
                {
                    intenttoinvest.Visible = false;
                }
            }
            else
            { Response.Redirect("~/DeptLogin.aspx"); }


        }

        protected void linkPreReg_Click(object sender, EventArgs e)
        {
            if (ObjUserInfo.Roleid == "4")
            {
                prereg.Visible = false;
                string url = "~/Dept/PreReg/PreRegApplDeptDashBoard.aspx";
                Response.Redirect(url);
            }
            else if (ObjUserInfo.Roleid == "1")
            {
                prereg.Visible = false;
                string url = "~/Dept/PreReg/PreRegApplIMADashBoard.aspx";
                Response.Redirect(url);
            }
            else if (ObjUserInfo.Roleid == "5" || ObjUserInfo.Roleid == "6" || ObjUserInfo.Roleid == "7")
            {
                prereg.Visible = false;
                string url = "~/Dept/PreReg/PreRegApplCommitteeDashBoard.aspx";
                Response.Redirect(url);
            }
        }

        protected void linkCFE_Click(object sender, EventArgs e)
        {
            if (ObjUserInfo.Roleid == "8")
            {
                Preestablishment.Visible = true;
                string url = "~/Dept/CFE/CFEDeptDashboard.aspx";
                Response.Redirect(url);
            }

        }

        protected void linkCFO_Click(object sender, EventArgs e)
        {

        }

        protected void linkGrievance_Click(object sender, EventArgs e)
        {
            //Dept.Grievance.GrievanceDeptDashbord
            string url = "~/Dept/Grievance/GrievanceDeptDashbord.aspx";
            Response.Redirect(url);

        }
    }
}