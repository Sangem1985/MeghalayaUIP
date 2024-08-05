using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP
{
    public partial class InformationWizard : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                BindDepartments();
                BindSectors();
                BindInformationWizard();
            }
            catch (Exception ex)
            { }

        }
        protected void BindDepartments()
        {
            try
            {
                ddldept.Items.Clear();
                List<MasterDepartment> objDepartmentModel = new List<MasterDepartment>();
                objDepartmentModel = mstrBAL.GetDepartment("2");
                if (objDepartmentModel != null)
                {
                    ddldept.DataSource = objDepartmentModel;
                    ddldept.DataValueField = "DepartmentId";
                    ddldept.DataTextField = "DepartmentName";
                    ddldept.DataBind();
                    ddldept.Enabled = true;
                }
                else
                {
                    ddldept.DataSource = null;
                    ddldept.DataBind();
                }
                AddSelect(ddldept);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void BindSectors()
        {
            try
            {
                ddlSector.Items.Clear();

                List<MasterSector> objSectorModel = new List<MasterSector>();

                objSectorModel = mstrBAL.GetSectors();
                if (objSectorModel != null)
                {
                    ddlSector.DataSource = objSectorModel;
                    ddlSector.DataValueField = "SectorName";
                    ddlSector.DataTextField = "SectorName";
                    ddlSector.DataBind();
                }
                else
                {
                    ddlSector.DataSource = null;
                    ddlSector.DataBind();
                }
                AddSelect(ddlSector);
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
        protected void BindInformationWizard()
        {
            try
            {
                string Module = "%";
                if (ddlModule.SelectedValue == "2")
                    Module = "CFE";
                if (ddlModule.SelectedValue == "3")
                    Module = "CFO";
                if (ddlModule.SelectedValue == "4")
                    Module = "REN";
                DataSet dsInfo = new DataSet();
                dsInfo = mstrBAL.GetInformationWizard(Module, ddldept.SelectedValue, ddlSector.SelectedValue);
                if (dsInfo != null && dsInfo.Tables.Count > 0 && dsInfo.Tables[0].Rows.Count > 0)
                {
                    gvInfoWiz.DataSource = dsInfo.Tables[0];
                    gvInfoWiz.DataBind();
                }



            }
            catch (Exception ex)
            { }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void gvInfoWiz_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HyperLink hplSOP = (HyperLink)e.Row.FindControl("hplViewSOP");
                    if (hplSOP != null)
                    {
                        if (hplSOP.NavigateUrl == null || hplSOP.NavigateUrl == "")
                        { hplSOP.Text = ""; }
                    }
                    HyperLink hplRules = (HyperLink)e.Row.FindControl("hplRulesandReg");
                    if (hplRules != null)
                    {
                        if (hplRules.NavigateUrl == null || hplRules.NavigateUrl == "")
                        { hplRules.Text = ""; }
                    }
                    HyperLink hpPreReqs = (HyperLink)e.Row.FindControl("hplPrerequisites");
                    if (hpPreReqs != null)
                    {
                        if (hpPreReqs.NavigateUrl == null || hpPreReqs.NavigateUrl == "")
                        { hpPreReqs.Text = ""; }
                    }
                    HyperLink hplAppl = (HyperLink)e.Row.FindControl("hplApplForm");
                    if (hplAppl != null)
                    {
                        if (hplAppl.NavigateUrl == null || hplAppl.NavigateUrl == "")
                        { hplAppl.Text = ""; }
                    }
                }
            }
            catch (Exception ex) { }
        }
    }
}