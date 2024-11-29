using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.INCBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.INCENTIVE
{
    public partial class INCEligibility : System.Web.UI.Page
    {
        int index;
        INCBAL iNCBAL = new INCBAL();
        MasterBAL mstrBAL = new MasterBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FixedCapital();
                SourceFinance();
                EmploymentType();
                BindDistricts();
            }
        }

        protected void Link1_Click(object sender, EventArgs e)
        {
            MVprereg.ActiveViewIndex = 0;
            Link1.CssClass = "Underlined1";
        }

        protected void Link2_Click(object sender, EventArgs e)
        {
            MVprereg.ActiveViewIndex = 1;
            Link2.CssClass = "Underlined2";
        }

        protected void MVprereg_ActiveViewChanged(object sender, EventArgs e)
        {
            index = MVprereg.ActiveViewIndex;
            if (index == 0)
            { Link1.CssClass = "Underlined1"; }
            if (index == 1)
            { Link2.CssClass = "Underlined2"; }
            if (index == 2)
            { Link3.CssClass = "Underlined3"; }
        }

        protected void Link3_Click(object sender, EventArgs e)
        {
            MVprereg.ActiveViewIndex = 2;
            Link3.CssClass = "Underlined3";
        }
        protected void FixedCapital()
        {
            try
            {
                DataTable dt = new DataTable();

                dt = iNCBAL.GetFixedCaptial();
                if (dt.Rows.Count > 0)
                {
                    grdRevenueProj.DataSource = dt;
                    grdRevenueProj.DataBind();
                }
                else
                {
                    grdRevenueProj.DataSource = null;
                    grdRevenueProj.DataBind();
                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void SourceFinance()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = iNCBAL.GetSourceFinance();

                if (dt.Rows.Count > 0)
                {
                    GVSource.DataSource = dt;
                    GVSource.DataBind();
                }
                else
                {
                    GVSource.DataSource = null;
                    GVSource.DataBind();
                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void EmploymentType()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = iNCBAL.GetEmploymentGeneration();

                if (dt.Rows.Count > 0)
                {
                    GVGeneration.DataSource = dt;
                    GVGeneration.DataBind();
                }
                else
                {
                    GVGeneration.DataSource = null;
                    GVGeneration.DataBind();
                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindDistricts()
        {

            try
            {

                ddlDistrict.Items.Clear();
                ddlMandal.Items.Clear();
                ddlVillage.Items.Clear();
                ddlDistrictoffice.Items.Clear();
                ddlMandloffice.Items.Clear();
                ddlVillageoffice.Items.Clear();
                ddlDistrictReg.Items.Clear();
                ddlMandlReg.Items.Clear();
                ddlVillageReg.Items.Clear();
                List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();
                string strmode = string.Empty;
                //if (ObjUserInformation.User_Level == "2")
                //{
                strmode = "";
                //}
                objDistrictModel = mstrBAL.GetDistrcits();
                if (objDistrictModel != null)
                {
                    ddlDistrict.DataSource = objDistrictModel;
                    ddlDistrict.DataValueField = "DistrictId";
                    ddlDistrict.DataTextField = "DistrictName";
                    ddlDistrict.DataBind();

                    ddlDistrictoffice.DataSource = objDistrictModel;
                    ddlDistrictoffice.DataValueField = "DistrictId";
                    ddlDistrictoffice.DataTextField = "DistrictName";
                    ddlDistrictoffice.DataBind();


                    ddlDistrictReg.DataSource = objDistrictModel;
                    ddlDistrictReg.DataValueField = "DistrictId";
                    ddlDistrictReg.DataTextField = "DistrictName";
                    ddlDistrictReg.DataBind();
                }
                else
                {
                    ddlDistrict.DataSource = null;
                    ddlDistrict.DataBind();

                    ddlDistrictoffice.DataSource = null;
                    ddlDistrictoffice.DataBind();

                    ddlDistrictReg.DataSource = null;
                    ddlDistrictReg.DataBind();
                }
                AddSelect(ddlDistrict);
                AddSelect(ddlMandal);
                AddSelect(ddlVillage);

                AddSelect(ddlDistrictoffice);
                AddSelect(ddlMandloffice);
                AddSelect(ddlVillageoffice);

                AddSelect(ddlDistrictReg);
                AddSelect(ddlMandlReg);
                AddSelect(ddlVillageReg);

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindMandal(DropDownList ddlmndl, string DistrictID)
        {
            try
            {
                List<MasterMandals> objMandal = mstrBAL.GetMandals(DistrictID);

                if (objMandal != null && objMandal.Count > 0)
                {
                    //ddlApplTaluka.Enabled = true;
                    //ddlApplVillage.Enabled = false;

                    ddlmndl.DataSource = objMandal;
                    ddlmndl.DataValueField = "MandalId";
                    ddlmndl.DataTextField = "MandalName";
                    ddlmndl.DataBind();
                }
                else
                {

                    ddlmndl.DataSource = null;
                    ddlmndl.DataBind();
                }

                AddSelect(ddlmndl);
            }
            catch (Exception ex)
            {

                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }
        protected void BindVillages(DropDownList ddlvlg, string MandalID)
        {
            try
            {
                List<MasterVillages> objVillage = new List<MasterVillages>();
                string strmode = string.Empty;

                objVillage = mstrBAL.GetVillages(MandalID);

                if (objVillage != null)
                {
                    //ddlApplVillage.Enabled = true ;
                    ddlvlg.DataSource = objVillage;
                    ddlvlg.DataValueField = "VillageId";
                    ddlvlg.DataTextField = "VillageName";
                    ddlvlg.DataBind();
                }
                else
                {
                    ddlvlg.DataSource = null;
                    ddlvlg.DataBind();
                }
                AddSelect(ddlvlg);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public void AddSelect(DropDownList ddl)
        {
            try
            {
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem();
                li.Text = "--Select--";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlMandal.ClearSelection();
                ddlMandal.Items.Clear();
                AddSelect(ddlMandal);
                ddlVillage.ClearSelection();
                ddlVillage.Items.Clear();
                AddSelect(ddlVillage);
                if (ddlDistrict.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlMandal, ddlDistrict.SelectedValue);
                }
                else return;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlVillage.ClearSelection();
                ddlVillage.Items.Clear();
                AddSelect(ddlVillage);

                if (ddlMandal.SelectedItem.Text != "--Select--")
                {
                    BindVillages(ddlVillage, ddlMandal.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void ddlDistrictoffice_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlMandloffice.ClearSelection();
                ddlMandloffice.Items.Clear();
                AddSelect(ddlMandloffice);
                ddlVillageoffice.ClearSelection();
                ddlVillageoffice.Items.Clear();
                AddSelect(ddlVillageoffice);
                if (ddlDistrictoffice.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlMandloffice, ddlDistrictoffice.SelectedValue);
                }
                else return;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void ddlMandloffice_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlVillageoffice.ClearSelection();
                ddlVillageoffice.Items.Clear();
                AddSelect(ddlVillageoffice);

                if (ddlMandloffice.SelectedItem.Text != "--Select--")
                {
                    BindVillages(ddlVillageoffice, ddlMandloffice.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void ddlDistrictReg_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlMandlReg.ClearSelection();
                ddlMandlReg.Items.Clear();
                AddSelect(ddlMandlReg);
                ddlVillageReg.ClearSelection();
                ddlVillageReg.Items.Clear();
                AddSelect(ddlVillageReg);
                if (ddlDistrictReg.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlMandlReg, ddlDistrictReg.SelectedValue);
                }
                else return;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void ddlMandlReg_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlVillageReg.ClearSelection();
                ddlVillageReg.Items.Clear();
                AddSelect(ddlVillageReg);

                if (ddlMandlReg.SelectedItem.Text != "--Select--")
                {
                    BindVillages(ddlVillageReg, ddlMandlReg.SelectedValue);
                }
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