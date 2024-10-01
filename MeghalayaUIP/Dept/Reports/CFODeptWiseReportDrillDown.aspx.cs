using MeghalayaUIP.BAL.ReportBAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Dept.Reports
{
    public partial class CFODeptWiseReportDrillDown : System.Web.UI.Page
    {
        ReportBAL Objreport = new ReportBAL();
        string Deptid, FormDate, ToDate, Department,view;
              
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDepartmentReport();
            }
        }
        protected void BindDepartmentReport()
        {
            try
            {
                if (Request.QueryString.Count > 0)
                {
                    Deptid = Convert.ToString(Request.QueryString[0]);
                    FormDate = Convert.ToString(Request.QueryString[1]);
                    ToDate = Convert.ToString(Request.QueryString[2]);
                    Department = Convert.ToString(Request.QueryString[3]);
                    view = Convert.ToString(Request.QueryString[4]);

                    DataSet ds = new DataSet();
                    ds = Objreport.CFODeptwiseReportDrilldown(Deptid, FormDate, ToDate);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GVDepartment.DataSource = ds.Tables[0];
                        GVDepartment.DataBind();
                        lblStatus.Visible = true;
                        lblStatus.InnerText = Department + " " + " " + "&" + " " + " " + FormDate + " " + " " + "In" + " " + " " + ToDate;
                        if (Department == "%")
                        {
                            lblStatus.InnerText = "All Departments";
                        }
                    }
                    else
                    {
                        GVDepartment.DataSource = null;
                        GVDepartment.DataBind();
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Dept/Reports/CFODeptWiseReport.aspx");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

    }
}