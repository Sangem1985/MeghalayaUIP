using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using MeghalayaUIP.DAL.LADAL;
using MeghalayaUIP.BAL.LABAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.LA
{
    public partial class LAQuestionnaire : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        LABAL Objland = new LABAL();
        string UnitID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserInfo"] != null)
            {
                var ObjUserInfo = new UserInfo();
                if (Session["UserInfo"] != null && Session["UserInfo"].ToString() != "")
                {
                    ObjUserInfo = (UserInfo)Session["UserInfo"];
                }
                if (hdnUserID.Value == "")
                {
                    hdnUserID.Value = ObjUserInfo.Userid;
                }

                UnitID = Convert.ToString(Session["LANDUNITID"]);

                Page.MaintainScrollPositionOnPostBack = true;
                if (!IsPostBack)
                {
                    BindDistricts();
                    BindIndustryPark();
                    BindENERGYLOAD();
                    BindWaterSource();
                    BindDatatype();
                    BindData();
                }
            }
        }
        public void BindData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = Objland.GETIndustrialShedDetails(hdnUserID.Value, Convert.ToString(Session["LANDUNITID"]));
                if (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0 || ds.Tables[2].Rows.Count > 0 || ds.Tables[3].Rows.Count > 0 || ds.Tables[4].Rows.Count > 0 || ds.Tables[5].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["UnitID"] = Convert.ToString(ds.Tables[0].Rows[0]["ISD_UNITID"]);
                        txtUnitName.Text = ds.Tables[0].Rows[0]["ISD_NAMEOFCOMPANY"].ToString();
                        ddlDistrict.SelectedValue = ds.Tables[0].Rows[0]["ISD_DISTRIC"].ToString();
                        ddlDistrict_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlMandal.SelectedValue = ds.Tables[0].Rows[0]["ISD_MANDAL"].ToString();
                        ddlMandal_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlVillage.SelectedValue = ds.Tables[0].Rows[0]["ISD_VILLAGE"].ToString();
                        ddlname.SelectedValue= ds.Tables[0].Rows[0]["ISD_NAMEOFINUSTRIALPARK"].ToString();
                        txtQuantum.Text= ds.Tables[0].Rows[0]["ISD_LANDREQ"].ToString();
                        txtSheds.Text= ds.Tables[0].Rows[0]["ISD_SHEDSNO"].ToString();
                        txtEquity.Text = ds.Tables[0].Rows[0]["ISD_EQUITY"].ToString();
                        txtTermLoan.Text = ds.Tables[0].Rows[0]["ISD_LOANBANK"].ToString();
                        txtUnsecured.Text = ds.Tables[0].Rows[0]["ISD_UNSECUREDLOAN"].ToString();
                        txtInternal.Text = ds.Tables[0].Rows[0]["ISD_INTERNALRESOURCES"].ToString();
                        txtothersource.Text = ds.Tables[0].Rows[0]["ISD_OTHERSOURCE"].ToString();
                        txtTotal.Text = ds.Tables[0].Rows[0]["ISD_TOTAL"].ToString();
                        ddlEnterprise.SelectedValue = ds.Tables[0].Rows[0]["ISD_CATEGORYENTERPRISE"].ToString();
                        txtPMLakh.Text = ds.Tables[0].Rows[0]["ISD_PMLAKH"].ToString();
                        txtprojectCost.Text = ds.Tables[0].Rows[0]["ISD_PROJECTCOSTLAKH"].ToString();
                        txtGenerated.Text = ds.Tables[0].Rows[0]["ISD_WASTEGENERATED"].ToString();

                    }

                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        GVManu.DataSource = ds.Tables[2];
                        GVManu.DataBind();
                        GVManu.Visible = true;
                    }
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        GVRawMaterial.DataSource = ds.Tables[3];
                        GVRawMaterial.DataBind();
                        GVRawMaterial.Visible = true;
                    }
                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        GVPOWER.DataSource = ds.Tables[4];
                        GVPOWER.DataBind();
                        GVPOWER.Visible = true;
                    }
                    if (ds.Tables[5].Rows.Count > 0)
                    {
                        GVWATER.DataSource = ds.Tables[5];
                        GVWATER.DataBind();
                        GVWATER.Visible = true;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void BindDistricts()
        {
            try
            {

                ddlDistrict.Items.Clear();
                ddlMandal.Items.Clear();
                ddlVillage.Items.Clear();

                List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();

                objDistrictModel = mstrBAL.GetDistrcits();
                if (objDistrictModel != null)
                {
                    ddlDistrict.DataSource = objDistrictModel;
                    ddlDistrict.DataValueField = "DistrictId";
                    ddlDistrict.DataTextField = "DistrictName";
                    ddlDistrict.DataBind();
                }
                else
                {
                    ddlDistrict.DataSource = null;
                    ddlDistrict.DataBind();
                }
                AddSelect(ddlDistrict);
                AddSelect(ddlMandal);
                AddSelect(ddlVillage);

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
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

                lblmsg0.Text = ex.Message; Failure.Visible = true;
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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }
        }
        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlMandal.ClearSelection();
                AddSelect(ddlMandal);
                ddlVillage.ClearSelection();
                AddSelect(ddlVillage);
                if (ddlDistrict.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlMandal, ddlDistrict.SelectedValue);
                }
                else return;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }
        }
        protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlVillage.ClearSelection();
                AddSelect(ddlVillage);
                if (ddlMandal.SelectedItem.Text != "--Select--")
                {

                    BindVillages(ddlVillage, ddlMandal.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }
        }
        protected void BindIndustryPark()
        {
            try
            {
                ddlname.Items.Clear();

                List<MasterINDUSTRIALPARKS> objIndtype = new List<MasterINDUSTRIALPARKS>();

                objIndtype = mstrBAL.GetIndustryParks();
                if (objIndtype != null)
                {
                    ddlname.DataSource = objIndtype;
                    ddlname.DataValueField = "INDUSTRIALPARK_ID";
                    ddlname.DataTextField = "INDUSTRIALPARK_NAME";
                    ddlname.DataBind();
                }
                else
                {
                    ddlname.DataSource = null;
                    ddlname.DataBind();
                }
                AddSelect(ddlname);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindENERGYLOAD()
        {
            try
            {
                ddlSourceLoad.Items.Clear();

                List<MasterENERGYLOAD> objCategoryModel = new List<MasterENERGYLOAD>();

                objCategoryModel = mstrBAL.GetPowerEnergyLoad();
                if (objCategoryModel != null)
                {
                    ddlSourceLoad.DataSource = objCategoryModel;
                    ddlSourceLoad.DataValueField = "ENERGYLOAD_ID";
                    ddlSourceLoad.DataTextField = "ENERGYLOAD_NAME";
                    ddlSourceLoad.DataBind();
                }
                else
                {
                    ddlSourceLoad.DataSource = null;
                    ddlSourceLoad.DataBind();
                }
                AddSelect(ddlSourceLoad);
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public void BindDatatype()
        {
            try
            {
                ddlEnterprise.Items.Clear();

                List<MasterENTERPRISETYPE> objPCBModel = new List<MasterENTERPRISETYPE>();

                objPCBModel = mstrBAL.GetENTERPRISETYPE();
                if (objPCBModel != null)
                {
                    ddlEnterprise.DataSource = objPCBModel;
                    ddlEnterprise.DataValueField = "ENTERPRISETYPECODE";
                    ddlEnterprise.DataTextField = "ENTERPRISETYPE";
                    ddlEnterprise.DataBind();
                }
                else
                {
                    ddlEnterprise.DataSource = null;
                    ddlEnterprise.DataBind();
                }
                AddSelect(ddlEnterprise);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void BindWaterSource()
        {
            try
            {
                ddlSourcewater.Items.Clear();

                List<MasterWaterSource> objWaterSourceModel = new List<MasterWaterSource>();

                objWaterSourceModel = mstrBAL.GetWaterSource();
                if (objWaterSourceModel != null)
                {
                    ddlSourcewater.DataSource = objWaterSourceModel;
                    ddlSourcewater.DataValueField = "WATERSOURCE_ID";
                    ddlSourcewater.DataTextField = "WATERSOURCE_NAME";
                    ddlSourcewater.DataBind();
                }
                else
                {
                    ddlSourcewater.DataSource = null;
                    ddlSourcewater.DataBind();
                }
                AddSelect(ddlSourcewater);
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void btnAddManu_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNameProduct.Text) || string.IsNullOrEmpty(txtAnnualManu.Text) || string.IsNullOrEmpty(txtAppox.Text))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("MD_UNITID", typeof(string));
                    dt.Columns.Add("MD_CREATEDBY", typeof(string));
                    dt.Columns.Add("MD_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("MD_NAMEOFPRODUCT", typeof(string));
                    dt.Columns.Add("MD_ANNUALCAPACITY", typeof(string));
                    dt.Columns.Add("MD_APPROXVALUE", typeof(string));



                    if (ViewState["MANUFACTURE"] != null)
                    {
                        dt = (DataTable)ViewState["MANUFACTURE"];
                    }

                    DataRow dr = dt.NewRow();
                    dr["MD_UNITID"] = Convert.ToString(ViewState["UnitID"]);
                    dr["MD_CREATEDBY"] = hdnUserID.Value;
                    dr["MD_CREATEDBYIP"] = getclientIP();
                    dr["MD_NAMEOFPRODUCT"] = txtNameProduct.Text;
                    dr["MD_ANNUALCAPACITY"] = txtAnnualManu.Text;
                    dr["MD_APPROXVALUE"] = txtAppox.Text;


                    dt.Rows.Add(dr);
                    GVManu.Visible = true;
                    GVManu.DataSource = dt;
                    GVManu.DataBind();
                    ViewState["MANUFACTURE"] = dt;
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void btnAddraw_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtannual.Text) || string.IsNullOrEmpty(txtCapacity.Text) || string.IsNullOrEmpty(txtValue.Text))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("RD_UNITID", typeof(string));
                    dt.Columns.Add("RD_CREATEDBY", typeof(string));
                    dt.Columns.Add("RD_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("RD_NAMEOFRAWMATERIAL", typeof(string));
                    dt.Columns.Add("RD_ANNUALCONSUMPTIONCAPACITY", typeof(string));
                    dt.Columns.Add("RD_APPOX", typeof(string));



                    if (ViewState["RAWMATERIAL"] != null)
                    {
                        dt = (DataTable)ViewState["RAWMATERIAL"];
                    }

                    DataRow dr = dt.NewRow();
                    dr["RD_UNITID"] = Convert.ToString(ViewState["UnitID"]);
                    dr["RD_CREATEDBY"] = hdnUserID.Value;
                    dr["RD_CREATEDBYIP"] = getclientIP();
                    dr["RD_NAMEOFRAWMATERIAL"] = txtannual.Text;
                    dr["RD_ANNUALCONSUMPTIONCAPACITY"] = txtCapacity.Text;
                    dr["RD_APPOX"] = txtValue.Text;


                    dt.Rows.Add(dr);
                    GVRawMaterial.Visible = true;
                    GVRawMaterial.DataSource = dt;
                    GVRawMaterial.DataBind();
                    ViewState["RAWMATERIAL"] = dt;
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void btnAddPower_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtEnergyLoad.Text) || string.IsNullOrEmpty(ddlSourceLoad.SelectedValue))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("PD_UNITID", typeof(string));
                    dt.Columns.Add("PD_CREATEDBY", typeof(string));
                    dt.Columns.Add("PD_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("PD_QUANTUMENERGYLOAD", typeof(string));
                    dt.Columns.Add("PD_ENERGYLOAD", typeof(string));



                    if (ViewState["ENERGY"] != null)
                    {
                        dt = (DataTable)ViewState["ENERGY"];
                    }

                    DataRow dr = dt.NewRow();
                    dr["PD_UNITID"] = Convert.ToString(ViewState["UnitID"]);
                    dr["PD_CREATEDBY"] = hdnUserID.Value;
                    dr["PD_CREATEDBYIP"] = getclientIP();
                    dr["PD_QUANTUMENERGYLOAD"] = txtEnergyLoad.Text;
                    dr["PD_ENERGYLOAD"] = ddlSourceLoad.SelectedValue;



                    dt.Rows.Add(dr);
                    GVPOWER.Visible = true;
                    GVPOWER.DataSource = dt;
                    GVPOWER.DataBind();
                    ViewState["ENERGY"] = dt;
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void btnAdded_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtWaterManu.Text) || string.IsNullOrEmpty(ddlSourcewater.SelectedValue))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("WD_UNITID", typeof(string));
                    dt.Columns.Add("WD_CREATEDBY", typeof(string));
                    dt.Columns.Add("WD_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("WD_REQWATER", typeof(string));
                    dt.Columns.Add("WD_SOURCEOFWATER", typeof(string));



                    if (ViewState["WATER"] != null)
                    {
                        dt = (DataTable)ViewState["WATER"];
                    }

                    DataRow dr = dt.NewRow();
                    dr["WD_UNITID"] = Convert.ToString(ViewState["UnitID"]);
                    dr["WD_CREATEDBY"] = hdnUserID.Value;
                    dr["WD_CREATEDBYIP"] = getclientIP();
                    dr["WD_REQWATER"] = txtWaterManu.Text;
                    dr["WD_SOURCEOFWATER"] = ddlSourcewater.SelectedValue;



                    dt.Rows.Add(dr);
                    GVWATER.Visible = true;
                    GVWATER.DataSource = dt;
                    GVWATER.DataBind();
                    ViewState["WATER"] = dt;
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void GVManu_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVManu.Rows.Count > 0)
                {
                    ((DataTable)ViewState["MANUFACTURE"]).Rows.RemoveAt(e.RowIndex);
                    this.GVManu.DataSource = ((DataTable)ViewState["MANUFACTURE"]).DefaultView;
                    this.GVManu.DataBind();
                    GVManu.Visible = true;
                    GVManu.Focus();

                }
                else
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "";
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void GVRawMaterial_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVRawMaterial.Rows.Count > 0)
                {
                    ((DataTable)ViewState["RAWMATERIAL"]).Rows.RemoveAt(e.RowIndex);
                    this.GVRawMaterial.DataSource = ((DataTable)ViewState["RAWMATERIAL"]).DefaultView;
                    this.GVRawMaterial.DataBind();
                    GVRawMaterial.Visible = true;
                    GVRawMaterial.Focus();

                }
                else
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "";
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void GVPOWER_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVPOWER.Rows.Count > 0)
                {
                    ((DataTable)ViewState["ENERGY"]).Rows.RemoveAt(e.RowIndex);
                    this.GVPOWER.DataSource = ((DataTable)ViewState["ENERGY"]).DefaultView;
                    this.GVPOWER.DataBind();
                    GVPOWER.Visible = true;
                    GVPOWER.Focus();

                }
                else
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "";
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void GVWATER_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVWATER.Rows.Count > 0)
                {
                    ((DataTable)ViewState["WATER"]).Rows.RemoveAt(e.RowIndex);
                    this.GVWATER.DataSource = ((DataTable)ViewState["WATER"]).DefaultView;
                    this.GVWATER.DataBind();
                    GVWATER.Visible = true;
                    GVWATER.Focus();

                }
                else
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "";

                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Quesstionriids = Convert.ToString(Session["LANDQDID"]);
            try
            {
                string ErrorMsg = "", result = "";
                ErrorMsg = validations();
                if (ErrorMsg == "")
                {
                    LANDQUESTIONNAIRE Objindustry = new LANDQUESTIONNAIRE();

                    int count = 0, count1 = 0, count2 = 0, count3 = 0, count4 = 0;
                    Objindustry.Questionnariid = Quesstionriids;
                    Objindustry.CreatedBy = hdnUserID.Value;
                    Objindustry.UnitId = Convert.ToString(Session["LANDUNITID"]);
                    Objindustry.IPAddress = getclientIP();
                    Objindustry.NAMEINDUSTRYPARK = ddlname.SelectedValue;
                    Objindustry.QUANTUMLAND=txtQuantum.Text;
                    Objindustry.SHEDSNO = txtSheds.Text;
                    Objindustry.COMPANYNAME = txtUnitName.Text;
                    Objindustry.DISTRIC = ddlDistrict.SelectedValue;
                    Objindustry.MANDAL = ddlMandal.SelectedValue;
                    Objindustry.VILLAGE = ddlVillage.SelectedValue;
                    Objindustry.EQUITY = txtEquity.Text;
                    Objindustry.LOANBANK = txtTermLoan.Text;
                    Objindustry.UnsecuredLOAN = txtUnsecured.Text;
                    Objindustry.INTERNALRESOURCE = txtInternal.Text;
                    Objindustry.OTHERSOURCE = txtothersource.Text;
                    Objindustry.TOTAL = txtTotal.Text;
                    Objindustry.ENTERPRISE = ddlEnterprise.SelectedValue;
                    Objindustry.PMLAKH = txtPMLakh.Text;
                    Objindustry.TOTALPROJECTCOST = txtprojectCost.Text;
                    Objindustry.WASTEGENERATOR = txtGenerated.Text;

                    result = Objland.InsertIndustrialShedDetails(Objindustry);
                    Session["LANDQDID"] = result;
                    Quesstionriids = Convert.ToString(Session["LANDQDID"]);

                    if (result != "")
                    {
                        for (int i = 0; i < GVManu.Rows.Count; i++)
                        {
                            Objindustry.Questionnariid = Quesstionriids;
                            Objindustry.CreatedBy = hdnUserID.Value;
                            Objindustry.UnitId = Convert.ToString(Session["LANDUNITID"]);
                            Objindustry.IPAddress = getclientIP();
                            Objindustry.NAMEPRODUCT = GVManu.Rows[i].Cells[1].Text;
                            Objindustry.MUNUCAPACITY = GVManu.Rows[i].Cells[2].Text;
                            Objindustry.APPROXVALUE = GVManu.Rows[i].Cells[3].Text;
                            string A = Objland.InsertManufactureDetails(Objindustry);
                            if (A != "")
                            { count1 = count1 + 1; }
                        }
                        for (int i = 0; i < GVRawMaterial.Rows.Count; i++)
                        {
                            Objindustry.Questionnariid = Quesstionriids;
                            Objindustry.CreatedBy = hdnUserID.Value;
                            Objindustry.UnitId = Convert.ToString(Session["LANDUNITID"]);
                            Objindustry.IPAddress = getclientIP();
                            Objindustry.RAWMATERIALNAME = GVRawMaterial.Rows[i].Cells[1].Text;
                            Objindustry.ANNUALCONSUMPTION = GVRawMaterial.Rows[i].Cells[2].Text;
                            Objindustry.APPROXVALUELAKH = GVRawMaterial.Rows[i].Cells[3].Text;

                            string A = Objland.InsertRawMaterial(Objindustry);
                            if (A != "")
                            { count2 = count2 + 1; }
                        }
                        for (int i = 0; i < GVPOWER.Rows.Count; i++)
                        {
                            Objindustry.Questionnariid = Quesstionriids;
                            Objindustry.CreatedBy = hdnUserID.Value;
                            Objindustry.UnitId = Convert.ToString(Session["LANDUNITID"]);
                            Objindustry.IPAddress = getclientIP();
                            Objindustry.QUANTUMENERGYLOAD = GVPOWER.Rows[i].Cells[1].Text;
                            Objindustry.SOURCEENERGYLOAD = GVPOWER.Rows[i].Cells[2].Text;

                            string A = Objland.InsertPowerdetails(Objindustry);
                            if (A != "")
                            { count3 = count3 + 1; }
                        }
                        for (int i = 0; i < GVWATER.Rows.Count; i++)
                        {
                            Objindustry.Questionnariid = Quesstionriids;
                            Objindustry.CreatedBy = hdnUserID.Value;
                            Objindustry.UnitId = Convert.ToString(Session["LANDUNITID"]);
                            Objindustry.IPAddress = getclientIP();
                            Objindustry.WATERMANU = GVWATER.Rows[i].Cells[1].Text;
                            Objindustry.SOURCEWATER = GVWATER.Rows[i].Cells[2].Text;

                            string A = Objland.InsertWaterDetails(Objindustry);
                            if (A != "")
                            { count4 = count4 + 1; }
                        }


                        if (GVManu.Rows.Count == count1 && GVRawMaterial.Rows.Count == count2 && GVPOWER.Rows.Count == count3 && GVWATER.Rows.Count == count4)
                        {
                            Objindustry.UnitId = Convert.ToString(Session["LANDUNITID"]);
                            Objindustry.CreatedBy = hdnUserID.Value;
                            Objindustry.Questionnariid = result;
                            Objindustry.IPAddress= getclientIP();
                            string Finalresult = Objland.SubmitLandApplication(Objindustry);
                            success.Visible = true;
                            lblmsg.Text = "Industrial shed Details Submitted Successfully";
                            string message = "alert('" + lblmsg.Text + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        string message = "alert('" + "Some Internal Error Occured, Please try later" + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    string message = "alert('" + ErrorMsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public string validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";

                if (string.IsNullOrEmpty(txtUnitName.Text) || txtUnitName.Text == "" || txtUnitName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter UnitName\\n";
                    slno = slno + 1;
                }
                if (ddlDistrict.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Enter distric\\n";
                    slno = slno + 1;
                }
                if (ddlMandal.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Enter Mandal\\n";
                    slno = slno + 1;
                }
                if (ddlVillage.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Enter village\\n";
                    slno = slno + 1;
                }
                if (ddlname.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Select Industrial Shed\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtQuantum.Text) || txtQuantum.Text == "" || txtQuantum.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Quantum of land required (in square metres)\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEquity.Text) || txtEquity.Text == "" || txtEquity.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Equity\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtTermLoan.Text) || txtTermLoan.Text == "" || txtTermLoan.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter TermLoan\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtUnsecured.Text) || txtUnsecured.Text == "" || txtUnsecured.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter UnSecured\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtInternal.Text) || txtInternal.Text == "" || txtInternal.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter InternalResource\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtothersource.Text) || txtothersource.Text == "" || txtothersource.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Any Other Service\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtTotal.Text) || txtTotal.Text == "" || txtTotal.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Total\\n";
                    slno = slno + 1;
                }
                if (ddlEnterprise.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Enter Enterprise\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPMLakh.Text) || txtPMLakh.Text == "" || txtPMLakh.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Plant & Machinary\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtprojectCost.Text) || txtprojectCost.Text == "" || txtprojectCost.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Project Cost\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtGenerated.Text) || txtGenerated.Text == "" || txtGenerated.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Details of waste/effluent to be generated\\n";
                    slno = slno + 1;
                }
                if(GVManu.Rows.Count==0)
                {
                    errormsg = errormsg + slno + ". Please Enter Details of Proposed items for manufacturing and click on Add\\n";
                    slno = slno + 1;
                }
                if (GVRawMaterial.Rows.Count == 0)
                {
                    errormsg = errormsg + slno + ". Please Enter Details of Proposed annual consumption of major raw material and click on Add\\n";
                    slno = slno + 1;
                }
                if (GVPOWER.Rows.Count == 0)
                {
                    errormsg = errormsg + slno + ". Please Enter Details of Power requirement and click on Add\\n";
                    slno = slno + 1;
                }
                if (GVWATER.Rows.Count == 0)
                {
                    errormsg = errormsg + slno + ". Please Enter Details of Proposed requirement of water for manufacturing and click on Add\\n";
                    slno = slno + 1;
                }

                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string getclientIP()
        {
            string result = string.Empty;
            string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ip))
            {
                string[] ipRange = ip.Split(',');
                int le = ipRange.Length - 1;
                result = ipRange[0];
            }
            else
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            return result;
        }
    }
}