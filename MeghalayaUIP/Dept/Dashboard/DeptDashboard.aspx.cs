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
                    Preestablishment.Visible = false;
                    Ammendments.Visible = true;
                    Report.Visible = true;

                }
                else if (ObjUserInfo.Roleid == "3")
                {
                    Land.Visible = false;
                    intenttoinvest.Visible = false;
                    prereg.Visible = true;
                    Preestablishment.Visible = false;
                    Ammendments.Visible = false;
                    Report.Visible = false;
                    Grievance.Visible = false;
                }
                else if (ObjUserInfo.Roleid == "4")
                {
                    if (ObjUserInfo.UserID == "1030")
                    {
                        intenttoinvest.Visible = false;
                        prereg.Visible = true;
                        Land.Visible = false;
                        Preestablishment.Visible = false;
                        Ammendments.Visible = false;
                        Report.Visible = false;
                        Grievance.Visible = false;
                    }
                    else
                    {
                        intenttoinvest.Visible = false;
                        prereg.Visible = true;
                        Land.Visible = true;
                        Preestablishment.Visible = false;
                        Ammendments.Visible = true;
                        Report.Visible = true;
                    }
                   
                }
                else if (ObjUserInfo.Roleid == "5" || ObjUserInfo.Roleid == "6" || ObjUserInfo.Roleid == "7")
                {
                    intenttoinvest.Visible = false;
                    prereg.Visible = true;
                    Preestablishment.Visible = false;
                    Land.Visible = false;
                    Ammendments.Visible = false;
                    Report.Visible = false;
                }
                else if (ObjUserInfo.Roleid == "8"|| ObjUserInfo.Roleid == "9")
                {
                    intenttoinvest.Visible = false;
                    prereg.Visible = false;
                    Preestablishment.Visible = true;
                    PreOperational.Visible = true;
                    Renewal.Visible = true;
                    Land.Visible = false;
                    Report.Visible = false;
                    if (ObjUserInfo.Roleid == "8")
                    {
                        Ammendments.Visible = true;
                    }
                    
                    
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
            else if (ObjUserInfo.Roleid == "3")
            {
                prereg.Visible = false;
                string url = "~/Dept/PreReg/PreRegDITDashBoard.aspx";
                Response.Redirect(url);
            }
        }

        protected void linkCFE_Click(object sender, EventArgs e)
        {
            if (ObjUserInfo.Roleid == "8"|| ObjUserInfo.Roleid == "9")
            {
                Preestablishment.Visible = true;
                string url = "~/Dept/CFE/CFEDeptDashboard.aspx";
                Response.Redirect(url);
            }

        }

        protected void linkCFO_Click(object sender, EventArgs e)
        {
            if (ObjUserInfo.Roleid == "8" || ObjUserInfo.Roleid == "9")
            {
                PreOperational.Visible = true;
                string url = "~/Dept/CFO/CFODeptDashboard.aspx";
                Response.Redirect(url);
            }
        }

        protected void linkGrievance_Click(object sender, EventArgs e)
        {
            //Dept.Grievance.GrievanceDeptDashbord
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
                Renewal.Visible = true;
                string url = "~/Dept/Renewal/RENDeptDashboard.aspx";
                Response.Redirect(url);
            }
        }

        protected void lnkLandAllotment_Click(object sender, EventArgs e)
        {
            if (ObjUserInfo.Roleid == "1" || ObjUserInfo.Roleid == "4")
            {
                Land.Visible = true;
                string url = "~/Dept/LA/LADeptdashboard.aspx";
                Response.Redirect(url);
            }
        }

        protected void lblAmmendment_Click(object sender, EventArgs e)
        {
            if(ObjUserInfo.Roleid=="1" || ObjUserInfo.Roleid == "4" ||  ObjUserInfo.Roleid == "8")
            {
                Ammendments.Visible = true;
                string url = "~/Dept/Ammendments.aspx";
                Response.Redirect(url);
            }
        }

        protected void lnkReport_Click(object sender, EventArgs e)
        {
            if (ObjUserInfo.Roleid=="4" || ObjUserInfo.Roleid=="1")
            {
                Report.Visible = true;
                string url = "~/Dept/Reports/ReportsAbstract.aspx";
                Response.Redirect(url);
            }
        }
    }
}