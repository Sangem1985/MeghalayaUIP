using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.ReportBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Dept.Reports
{
    public partial class RENDeptWiseReport : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        ReportBAL reportsBAL = new ReportBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDepartments();
                btnsubmit_Click(sender, e);
            }
        }
        protected void BindDepartments()
        {
            try
            {
                ddldepartment.Items.Clear();
                List<MasterDepartment> objDepartmentModel = new List<MasterDepartment>();
                objDepartmentModel = mstrBAL.GetDepartment("2");
                if (objDepartmentModel != null)
                {
                    ddldepartment.DataSource = objDepartmentModel;
                    ddldepartment.DataValueField = "DepartmentId";
                    ddldepartment.DataTextField = "DepartmentName";
                    ddldepartment.DataBind();
                    ddldepartment.Enabled = true;
                }
                else
                {
                    ddldepartment.DataSource = null;
                    ddldepartment.DataBind();
                }
                AddSelect(ddldepartment);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AddSelect(DropDownList ddl)
        {
            try
            {
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem();
                li.Text = "All";
                li.Value = "%";
                ddl.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void BindRENDeptReports()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = reportsBAL.RENDeptWiseReport(ddldepartment.SelectedValue, txtFormDate.Text, txtToDate.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GVRENReport.DataSource = ds.Tables[0];
                    GVRENReport.DataBind();
                }
                else
                {
                    GVRENReport.DataSource = null;
                    GVRENReport.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            BindRENDeptReports();
            divPrint1.Visible = true;
        }
    }
}