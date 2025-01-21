using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP
{
    public partial class SingleWindowPortalDashboardDrillDown : System.Web.UI.Page
    {
        MasterBAL masterBAL = new MasterBAL();
        string Deptid, FormDate, ToDate, ViewType, Department;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDepartment();
            }
        }
        protected void BindDepartment()
        {
            try
            {
                if (Request.QueryString.Count > 0)
                {
                    Deptid = Convert.ToString(Request.QueryString[0]);
                    FormDate = Convert.ToString(Request.QueryString[1]);
                    ToDate = Convert.ToString(Request.QueryString[2]);
                    ViewType = Convert.ToString(Request.QueryString[3]);
                    Department = Convert.ToString(Request.QueryString[4]);

                    DataSet ds = new DataSet();
                    ds = masterBAL.SWPDDrilldown(Deptid, FormDate, ToDate, ViewType);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        GVSWP.DataSource = ds.Tables[0];
                        GVSWP.DataBind();
                        lblStatus.Visible = true;
                        lblStatus.InnerText = Department + " " + " " + "&" + " " + " " + FormDate + " " + " " + "In" + " " + " " + ToDate;
                        if (Department == "%")
                        {
                            lblStatus.InnerText = "All Departments";
                        }
                    }
                    else
                    {
                        GVSWP.DataSource = null;
                        GVSWP.DataBind();
                    }

                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/SingleWindowPortalDashboard.aspx");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

    }

}