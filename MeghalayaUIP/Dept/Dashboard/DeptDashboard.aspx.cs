using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Dept.Dashboard
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
                    Land.Visible = true;
                    Ammendments.Visible = true;
                    Report.Visible = true;

                    //Preestablishment.Visible = false;
                    //PreOperational.Visible = false;
                    //Renewal.Visible = false;
                    //Services.Visible = false;

                }
                else if (ObjUserInfo.Roleid == "3")
                {
                    prereg.Visible = true;

                    //intenttoinvest.Visible = false; Land.Visible = false;
                    //Ammendments.Visible = false; Report.Visible = false; Grievance.Visible = false;
                    //Preestablishment.Visible = false; PreOperational.Visible = false;
                    //Renewal.Visible = false; Services.Visible = false;
                }
                else if (ObjUserInfo.Roleid == "4")
                {
                    prereg.Visible = true;
                    //if (ObjUserInfo.UserID == "1030") 
                    //{
                    //    intenttoinvest.Visible = false;//DPRCELL                       
                    //    Land.Visible = false;
                    //    Preestablishment.Visible = false;
                    //    Ammendments.Visible = false;
                    //    Report.Visible = false;
                    //    Grievance.Visible = false;
                    //}
                    //else
                    //{
                    //    intenttoinvest.Visible = false;                       
                    //    Land.Visible = true;
                    //    Preestablishment.Visible = false;
                    //    Ammendments.Visible = true;
                    //    Report.Visible = true; Grievance.Visible = false;
                    //}
                }
                else if (ObjUserInfo.Roleid == "5" || ObjUserInfo.Roleid == "6" || ObjUserInfo.Roleid == "7")
                {
                    prereg.Visible = true;
                    //intenttoinvest.Visible = false;                
                    //Preestablishment.Visible = false;
                    //Land.Visible = false;
                    //Ammendments.Visible = false;
                    //Report.Visible = false;
                }
                else if (ObjUserInfo.Roleid == "8" || ObjUserInfo.Roleid == "9")
                {
                    Preestablishment.Visible = true; PreOperational.Visible = true; Renewal.Visible = true; Services.Visible = true;
                    Report.Visible = true; Grievance.Visible = true; Ammendments.Visible = true;
                    if (ObjUserInfo.PreRegRoleid == "4")
                        prereg.Visible = true;
                    if (ObjUserInfo.Roleid == "8")
                    {
                        Ammendments.Visible = true; Resources.Visible = true;
                    }
                    else if (ObjUserInfo.Roleid == "10" || ObjUserInfo.Roleid == "11")
                    {
                        Land.Visible = true;
                    }
                }
                else
                { Response.Redirect("~/DeptLogin.aspx"); }


            }
        }
        protected void linkPreReg_Click(object sender, EventArgs e)
        {
            if (ObjUserInfo.Roleid == "1")
            {
                string url = "~/Dept/PreReg/PreRegApplIMADashBoard.aspx";
                Response.Redirect(url);
            }
            else if (ObjUserInfo.Roleid == "3")
            {
                string url = "~/Dept/PreReg/PreRegDITDashBoard.aspx";
                Response.Redirect(url);
            }
            else if (ObjUserInfo.Roleid == "4" || ObjUserInfo.Roleid == "8" || ObjUserInfo.Roleid == "9")
            {
                string url = "~/Dept/PreReg/PreRegApplDeptDashBoard.aspx";
                Response.Redirect(url);
            }

            else if (ObjUserInfo.Roleid == "5" || ObjUserInfo.Roleid == "6" || ObjUserInfo.Roleid == "7")
            {
                string url = "~/Dept/PreReg/PreRegApplCommitteeDashBoard.aspx";
                Response.Redirect(url);
            }
            //else if (ObjUserInfo.Roleid == "8" || ObjUserInfo.Roleid == "9")
            //{
            //    string url = "~/Dept/PreReg/PreRegApplDeptDashBoard.aspx";
            //    Response.Redirect(url);
            //}
        }

        protected void linkCFE_Click(object sender, EventArgs e)
        {
            if (ObjUserInfo.Roleid == "8" || ObjUserInfo.Roleid == "9")
            {
                string url = "~/Dept/CFE/CFEDeptDashboard.aspx";
                Response.Redirect(url);
            }

        }

        protected void linkCFO_Click(object sender, EventArgs e)
        {
            if (ObjUserInfo.Roleid == "8" || ObjUserInfo.Roleid == "9")
            {
                string url = "~/Dept/CFO/CFODeptDashboard.aspx";
                Response.Redirect(url);
            }
        }

        protected void linkGrievance_Click(object sender, EventArgs e)
        {
            string url = "~/Dept/Grievance/GrievanceDeptDashbord.aspx";
            Response.Redirect(url);

        }

        protected void lnkIntent_Click(object sender, EventArgs e)
        {
            string url = "~/Dept/IntenttoInvestDashboard.aspx";
            Response.Redirect(url);
        }

        protected void lnkrenewal_Click(object sender, EventArgs e)
        {
            if (ObjUserInfo.Roleid == "8" || ObjUserInfo.Roleid == "9")
            {
                string url = "~/Dept/Renewal/RENDeptDashboard.aspx";
                Response.Redirect(url);
            }
        }

        protected void lnkLandAllotment_Click(object sender, EventArgs e)
        {

            string url = "~/Dept/LA/LADeptdashboard.aspx";
            Response.Redirect(url);

        }

        protected void lblAmmendment_Click(object sender, EventArgs e)
        {
            if (ObjUserInfo.Roleid == "1" || ObjUserInfo.Roleid == "4" || ObjUserInfo.Roleid == "8")
            {
                Ammendments.Visible = true;
                string url = "~/Dept/Ammendments.aspx";
                Response.Redirect(url);
            }
        }

        protected void lnkReport_Click(object sender, EventArgs e)
        {
            if (ObjUserInfo.Roleid == "4" || ObjUserInfo.Roleid == "1")
            {
                Report.Visible = true;
                string url = "~/Dept/Reports/ReportsAbstract.aspx";
                Response.Redirect(url);
            }
        }
        protected void lnkServices_Click(object sender, EventArgs e)
        {
            if (ObjUserInfo.Roleid == "8" || ObjUserInfo.Roleid == "9")
            {
                Report.Visible = true;
                string url = "~/Dept/Services/SrvcDeptDashboard.aspx";
                Response.Redirect(url);
            }
        }
        protected void lnkResources_Click(object sender, EventArgs e)
        {
            if (ObjUserInfo.Roleid == "8")
            {

                string url = "~/Dept/DeptWiseServices.aspx";
                Response.Redirect(url);
            }
        }
    }
}