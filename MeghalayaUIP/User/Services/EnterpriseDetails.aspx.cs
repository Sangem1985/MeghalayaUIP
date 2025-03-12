using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.RenewalBAL;
using MeghalayaUIP.BAL.SVRCBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Services
{
    public partial class EnterpriseDetails : System.Web.UI.Page
    {
        decimal LandValue;
        decimal Building;
        decimal PMCost;

        decimal sum;
        MasterBAL mstrBAL = new MasterBAL();
        SVRCBAL objSrvcbal = new SVRCBAL();
        string UnitID, Questionnaire, ErrorMsg = "", result = "", UID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString.Count > 0)
                {
                    Questionnaire = Convert.ToString(Request.QueryString[0]);                  
                }

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
                    if (Convert.ToString(Session["SRVCUNITID"]) != "")
                    {
                        UnitID = Convert.ToString(Session["SRVCUNITID"]);
                    }
                    if (Convert.ToString(Session["SRVCQID"]) != "" )
                    {
                        Questionnaire = Convert.ToString(Session["SRVCQID"]);
                    }
                   

                    Page.MaintainScrollPositionOnPostBack = true;

                    Page.MaintainScrollPositionOnPostBack = true;
                    Failure.Visible = false;
                    success.Visible = false;
                    if (!IsPostBack)
                    {
                        BindStates();
                        BindDistricts();
                        BindConstitutionType();
                        BindRegistrationType();
                        BindSectors();
                        BindData();
                        TotalAmount();
                        //GetCategory();
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            //lblTotProjCost.Text = Convert.ToString(Convert.ToString(string.IsNullOrEmpty(txtPropEmp.Text)) + Convert.ToDecimal(string.IsNullOrEmpty(txtLandValue.Text)) + Convert.ToDecimal(string.IsNullOrEmpty(txtBuildingValue.Text)) + Convert.ToDecimal(string.IsNullOrEmpty(txtPMCost.Text)) + Convert.ToString(string.IsNullOrEmpty(txtAnnualTurnOver.Text)));

        }
        public void BindData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objSrvcbal.GetSvrcApplicantDetails(hdnUserID.Value, UnitID);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {                       
                        txtUnitName.Text = ds.Tables[0].Rows[0]["SRVCED_NAMEOFUNIT"].ToString();
                        ddlCompanyType.SelectedValue = ds.Tables[0].Rows[0]["SRVCED_COMPANYTYPE"].ToString();
                        ddlSectorEnter.SelectedValue = ds.Tables[0].Rows[0]["SRVCED_SECTORENTERPRISE"].ToString();
                        ddlRegType.SelectedValue = ds.Tables[0].Rows[0]["SRVCED_CATEGORYREG"].ToString();
                        ddlRegType_SelectedIndexChanged(null, EventArgs.Empty);
                        txtRegNo.Text = ds.Tables[0].Rows[0]["SRVCED_REGNUMBER"].ToString();
                        txtRegDate.Text = ds.Tables[0].Rows[0]["SRVCED_REGDATE"].ToString();
                        ddlsector.SelectedValue = ds.Tables[0].Rows[0]["SRVCED_SECTOR"].ToString();
                        ddlsector_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlLineActivity.SelectedValue = ds.Tables[0].Rows[0]["SRVCED_LINEOFACTIVITY"].ToString();
                        ddlLineActivity_SelectedIndexChanged(null, EventArgs.Empty);
                        lblPCBCategory.Text = ds.Tables[0].Rows[0]["SRVCED_POLLUTIONCATG"].ToString();

                        txtDoors.Text = ds.Tables[0].Rows[0]["SRVCED_SURVEYDOOR"].ToString();
                        txtLocality.Text = ds.Tables[0].Rows[0]["SRVCED_LOCALITY"].ToString();
                        txtLANDMARK.Text = ds.Tables[0].Rows[0]["SRVCED_LANDMARK"].ToString();
                        ddlDistrict.SelectedValue = ds.Tables[0].Rows[0]["SRVCED_DISTRIC"].ToString();
                        ddlDistrict_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlMandal.SelectedValue = ds.Tables[0].Rows[0]["SRVCED_MANDAL"].ToString();
                        ddlMandal_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlVillage.SelectedValue = ds.Tables[0].Rows[0]["SRVCED_VILLAGE"].ToString();
                        txtEmailId.Text = ds.Tables[0].Rows[0]["SRVCED_EMAILID"].ToString();
                        txtMobileNo.Text = ds.Tables[0].Rows[0]["SRVCED_MOBILENO"].ToString();
                        txtpincode.Text = ds.Tables[0].Rows[0]["SRVCED_PINCODE"].ToString();
                        txtLandArea.Text = ds.Tables[0].Rows[0]["SRVCED_TOTALEXTENTLAND"].ToString();
                        txtBuiltArea.Text = ds.Tables[0].Rows[0]["SRVCED_BUILTUPAREA"].ToString();

                        txtName.Text = ds.Tables[0].Rows[0]["SRVCED_NAME"].ToString();
                        txtSoWoDo.Text = ds.Tables[0].Rows[0]["SRVCED_SONOF"].ToString();
                        txtEmail.Text = ds.Tables[0].Rows[0]["SRVCED_EMAIL"].ToString();
                        txtphoneno.Text = ds.Tables[0].Rows[0]["SRVCED_MOBILENUMBER"].ToString();
                        txtAltMobile.Text = ds.Tables[0].Rows[0]["SRVCED_ALTERNUMBER"].ToString();
                        txtLandlineno.Text = ds.Tables[0].Rows[0]["SRVCED_LANDLINENUMBER"].ToString();
                        txtDoorNo.Text = ds.Tables[0].Rows[0]["SRVCED_DOOR"].ToString();
                        txtLocal.Text = ds.Tables[0].Rows[0]["SRVCED_LOCALITYADD"].ToString();
                        ddlstate.SelectedValue = ds.Tables[0].Rows[0]["SRVCED_STATE"].ToString();
                        ddlstate_SelectedIndexChanged(null, EventArgs.Empty);

                        if (ddlstate.SelectedItem.Text == "Meghalaya")
                        {
                            otherDistric.Visible = true;
                            trotherstate.Visible = false;
                            ddldist.SelectedValue = ds.Tables[0].Rows[0]["SRVCED_DISTRICS"].ToString();
                            ddldist_SelectedIndexChanged(null, EventArgs.Empty);
                            ddlmand.SelectedValue = ds.Tables[0].Rows[0]["SRVCED_MANDALS"].ToString();
                            ddlmand_SelectedIndexChanged(null, EventArgs.Empty);
                            ddlvilla.SelectedValue = ds.Tables[0].Rows[0]["SRVCED_VILLAGES"].ToString();

                        }
                        else
                        {
                            trotherstate.Visible = true;
                            otherDistric.Visible = false;
                            txtApplDist.Text = ds.Tables[0].Rows[0]["SRVCED_DIST"].ToString();
                            txtApplTaluka.Text = ds.Tables[0].Rows[0]["SRVCED_MANDA"].ToString();
                            txtApplVillage.Text = ds.Tables[0].Rows[0]["SRVCED_VILLA"].ToString();
                        }

                        txtPin.Text = ds.Tables[0].Rows[0]["SRVCED_PIN"].ToString();
                        txtAge.Text = ds.Tables[0].Rows[0]["SRVCED_AGE"].ToString();
                        txtDesignation.Text = ds.Tables[0].Rows[0]["SRVCED_DESIGNATION"].ToString();
                        rblWomen.SelectedValue = ds.Tables[0].Rows[0]["SRVCED_WOMENENTREPRENEUR"].ToString();
                        rblAbled.SelectedValue = ds.Tables[0].Rows[0]["SRVCED_ABLED"].ToString();

                        txtMale.Text = ds.Tables[0].Rows[0]["SRVCED_DIRECTMALE"].ToString();
                        txtFemale.Text = ds.Tables[0].Rows[0]["SRVCED_DIRECTFEMALE"].ToString();
                        txtDirectOthers.Text = ds.Tables[0].Rows[0]["SRVCED_DIRECTEMP"].ToString();
                        txtIndirectMale.Text = ds.Tables[0].Rows[0]["SRVCED_INDIRECTMALE"].ToString();
                        txtIndirectFemale.Text = ds.Tables[0].Rows[0]["SRVCED_INDIRECTFEMALE"].ToString();
                        txtInDirectOthers.Text = ds.Tables[0].Rows[0]["SRVCED_INDIRECTEMP"].ToString();

                        txtPropEmp.Text = ds.Tables[0].Rows[0]["SRVCED_TOTALEMP"].ToString();
                        txtLandValue.Text = ds.Tables[0].Rows[0]["SRVCED_LANDSALEDEED"].ToString();
                        txtBuildingValue.Text = ds.Tables[0].Rows[0]["SRVCED_BUILDING"].ToString();
                        txtPMCost.Text = ds.Tables[0].Rows[0]["SRVCED_PLANTMACHINERY"].ToString();
                        lblTotProjCost.Text = ds.Tables[0].Rows[0]["SRVCED_PROJECTCOST"].ToString();
                        txtAnnualTurnOver.Text = ds.Tables[0].Rows[0]["SRVCED_ANNUALTURNOVER"].ToString();
                        txtAnnualTurnOver_TextChanged(null, EventArgs.Empty);
                        //lblEntCategory.Text = ds.Tables[0].Rows[0]["RENID_ENTERPRISECATEG"].ToString();
                    }
                    else if (ds.Tables[1].Rows.Count > 0)
                    {
                        ViewState["UnitID"] = Convert.ToString(ds.Tables[1].Rows[0]["UNITID"]);
                        txtUnitName.Text = ds.Tables[1].Rows[0]["COMPANYNAME"].ToString();
                        ddlCompanyType.SelectedValue = ds.Tables[1].Rows[0]["COMPANYTYPE"].ToString();
                        ddlSectorEnter.SelectedValue = ds.Tables[1].Rows[0]["PROJECT_NOA"].ToString();
                        ddlRegType.SelectedValue = ds.Tables[1].Rows[0]["COMPANYREGTYPE"].ToString();
                        ddlRegType_SelectedIndexChanged(null, EventArgs.Empty);
                        txtRegNo.Text = ds.Tables[1].Rows[0]["COMPANYREGNO"].ToString();
                        txtRegDate.Text = ds.Tables[1].Rows[0]["REGISTRATIONDATE"].ToString();
                        ddlsector.SelectedValue = ds.Tables[1].Rows[0]["PROJECT_SECTORNAME"].ToString();
                        ddlsector_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlLineActivity.SelectedValue = ds.Tables[1].Rows[0]["PROJECT_LOAID"].ToString();
                        ddlLineActivity_SelectedIndexChanged(null, EventArgs.Empty);
                        lblPCBCategory.Text = ds.Tables[1].Rows[0]["PROJECT_PCBCATEGORY"].ToString();


                        txtDoors.Text = ds.Tables[1].Rows[0]["UNIT_DOORNO"].ToString();
                        txtLocality.Text = ds.Tables[1].Rows[0]["UNIT_LOCALITY"].ToString();
                        // txtLANDMARK.Text = ds.Tables[1].Rows[0]["RENID_LANDMARK"].ToString();
                        if (Convert.ToString(ds.Tables[1].Rows[0]["UNIT_DISTRICTID"]) != "0" ||
                            Convert.ToString(ds.Tables[1].Rows[0]["UNIT_DISTRICTID"]) != "")
                        {
                            ddlstate.SelectedValue = "23";
                            ddlstate_SelectedIndexChanged(null, EventArgs.Empty);
                        }
                        ddlDistrict.SelectedValue = ds.Tables[1].Rows[0]["UNIT_DISTRICTID"].ToString();
                        ddlDistrict_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlMandal.SelectedValue = ds.Tables[1].Rows[0]["UNIT_MANDALID"].ToString();
                        ddlMandal_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlVillage.SelectedValue = ds.Tables[1].Rows[0]["UNIT_VILLAGEID"].ToString();
                        txtpincode.Text = ds.Tables[1].Rows[0]["UNIT_PINCODE"].ToString();
                        txtLandArea.Text = ds.Tables[1].Rows[0]["PROJECT_LANDAREA"].ToString();
                        txtBuiltArea.Text = ds.Tables[1].Rows[0]["PROJECT_BUILDINGAREA"].ToString();


                        txtName.Text = ds.Tables[1].Rows[0]["REP_NAME"].ToString();
                        txtphoneno.Text = ds.Tables[1].Rows[0]["REP_MOBILE"].ToString();
                        txtEmail.Text = ds.Tables[1].Rows[0]["REP_EMAIL"].ToString();
                        txtDoorNo.Text = ds.Tables[1].Rows[0]["REP_DOORNO"].ToString();
                        txtLocal.Text = ds.Tables[1].Rows[0]["REP_LOCALITY"].ToString();
                        ddldist.SelectedValue = ds.Tables[1].Rows[0]["REP_DISTRICTID"].ToString();
                        ddldist_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlmand.SelectedValue = ds.Tables[1].Rows[0]["REP_MANDALID"].ToString();
                        ddlmand_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlvilla.SelectedValue = ds.Tables[1].Rows[0]["REP_VILLAGEID"].ToString();
                        txtPin.Text = ds.Tables[1].Rows[0]["REP_PINCODE"].ToString();

                        txtLandValue.Text = ds.Tables[1].Rows[0]["PROJECT_LANDVALUE"].ToString();
                        txtBuildingValue.Text = ds.Tables[1].Rows[0]["PROJECT_BUILDINGVALUE"].ToString();
                        txtPMCost.Text = ds.Tables[1].Rows[0]["PROJECT_PMCOST"].ToString();                      

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

        protected void BindStates()
        {
            try
            {
                ddlstate.Items.Clear();

                List<MasterStates> objStatesModel = new List<MasterStates>();

                objStatesModel = mstrBAL.GetStates();
                if (objStatesModel != null)
                {
                    ddlstate.DataSource = objStatesModel;
                    ddlstate.DataValueField = "StateId";
                    ddlstate.DataTextField = "StateName";
                    ddlstate.DataBind();
                }
                else
                {
                    ddlstate.DataSource = null;
                    ddlstate.DataBind();
                }
                AddSelect(ddlstate);
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

                ddldist.Items.Clear();
                ddlmand.Items.Clear();
                ddlvilla.Items.Clear();

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

                    ddldist.DataSource = objDistrictModel;
                    ddldist.DataValueField = "DistrictId";
                    ddldist.DataTextField = "DistrictName";
                    ddldist.DataBind();

                }
                else
                {
                    ddlDistrict.DataSource = null;
                    ddlDistrict.DataBind();

                    ddldist.DataSource = null;
                    ddldist.DataBind();

                }
                AddSelect(ddlDistrict);
                AddSelect(ddlMandal);
                AddSelect(ddlVillage);

                AddSelect(ddldist);
                AddSelect(ddlmand);
                AddSelect(ddlvilla);


            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindConstitutionType()
        {
            try
            {
                ddlCompanyType.Items.Clear();

                List<MasterConstType> objConsttype = new List<MasterConstType>();

                objConsttype = mstrBAL.GetConstitutionType();
                if (objConsttype != null)
                {
                    ddlCompanyType.DataSource = objConsttype;
                    ddlCompanyType.DataValueField = "ConstId";
                    ddlCompanyType.DataTextField = "ConstName";
                    ddlCompanyType.DataBind();
                }
                else
                {
                    ddlCompanyType.DataSource = null;
                    ddlCompanyType.DataBind();
                }
                AddSelect(ddlCompanyType);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public void BindRegistrationType()
        {
            try
            {
                ddlRegType.Items.Clear();
               // AddOthers(ddlRegType);
                List<MasterRegistrationType> objRegistrationTypeModel = new List<MasterRegistrationType>();

                objRegistrationTypeModel = mstrBAL.GetRegistrationType();
               
                objRegistrationTypeModel.Add(new MasterRegistrationType
                {
                    REGISTRATIONTYPEID = "100", 
                    REGISTRATIONTYPENAME = "Others" 
                });


                if (objRegistrationTypeModel != null)
                {                    
                    
                    ddlRegType.DataSource = objRegistrationTypeModel;
                    ddlRegType.DataValueField = "REGISTRATIONTYPEID";
                    ddlRegType.DataTextField = "REGISTRATIONTYPENAME";

                    ddlRegType.DataBind();
                }
                else
                {
                    ddlRegType.DataSource = null;
                    ddlRegType.DataBind();
                }               
                AddSelect(ddlRegType);
               
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
        protected void BindSectors()
        {
            try
            {
                ddlsector.Items.Clear();

                List<MasterSector> objSectorModel = new List<MasterSector>();

                objSectorModel = mstrBAL.GetSectors();
                if (objSectorModel != null)
                {
                    ddlsector.DataSource = objSectorModel;
                    ddlsector.DataValueField = "SectorName";
                    ddlsector.DataTextField = "SectorName";
                    ddlsector.DataBind();
                }
                else
                {
                    ddlsector.DataSource = null;
                    ddlsector.DataBind();
                }
                AddSelect(ddlsector);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindLineOfActivity(string Sector)
        {
            try
            {
                List<MasterLineOfActivity> objLOA = mstrBAL.GetLineOfActivity(Sector);

                if (objLOA != null && objLOA.Count > 0)
                {
                    ddlLineActivity.DataSource = objLOA;
                    ddlLineActivity.DataValueField = "LOAId";
                    ddlLineActivity.DataTextField = "LOAName";
                    ddlLineActivity.DataBind();
                }
                else
                {

                    ddlLineActivity.DataSource = null;
                    ddlLineActivity.DataBind();
                }

                AddSelect(ddlLineActivity);
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
        public void AddOthers(DropDownList ddl)
        {
            try
            {
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem();
                li.Text = "Others";
                li.Value = "100";
                ddl.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void ddlRegType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlRegType.SelectedItem.Text.Trim() != "--Select--")
                {
                    txtRegNo.Enabled = true;
                    lblregntype.InnerText = ddlRegType.SelectedItem.Text.Trim() + " No *";
                   // txtRegNo.Text = ""; txtRegDate.Text = "";
                    if (ddlRegType.SelectedItem.Text.Trim() == "Others")
                    {
                        txtRegNo.Enabled = true;
                        lblregntype.InnerText = ddlRegType.SelectedItem.Text.Trim() + " Reference No *";
                        
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
        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlstate.SelectedItem.Text == "Meghalaya")
                {
                    otherDistric.Visible = true;
                    trotherstate.Visible = false;
                }
                else
                {
                    trotherstate.Visible = true;
                    otherDistric.Visible = false;
                }
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
                ddlVillage.ClearSelection();
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
        protected void ddldist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlmand.ClearSelection();
                ddlvilla.ClearSelection();
                if (ddldist.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlmand, ddldist.SelectedValue);
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
        protected void ddlmand_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlvilla.ClearSelection();
                if (ddlmand.SelectedItem.Text != "--Select--")
                {

                    BindVillages(ddlvilla, ddlmand.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void ddlsector_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlsector.SelectedValue.ToString() != "--Select--")
                {
                    BindLineOfActivity(ddlsector.SelectedItem.Text);

                }
            }
            catch (Exception ex)
            {

                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void ddlLineActivity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlLineActivity.SelectedItem.Text != "--Select--")
                {
                    lblPCBCategory.Text = mstrBAL.GetPCBCategory(ddlLineActivity.SelectedValue);

                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void txtLandValue_TextChanged(object sender, EventArgs e)
        {
            TotalAmount();
        }
        protected void txtBuildingValue_TextChanged(object sender, EventArgs e)
        {
            TotalAmount();
        }
        protected void txtPMCost_TextChanged(object sender, EventArgs e)
        {
            TotalAmount();
        }
        public void TotalAmount()
        {
            try
            {


                if (txtLandValue.Text == "0" || string.IsNullOrEmpty(txtLandValue.Text))
                {
                    LandValue = 0;
                }
                else
                {
                    LandValue = Convert.ToDecimal(txtLandValue.Text);

                }
                if (txtBuildingValue.Text == "0" || string.IsNullOrEmpty(txtBuildingValue.Text))
                {
                    Building = 0;
                }
                else
                {
                    Building = Convert.ToDecimal(txtBuildingValue.Text);
                }
                if (txtPMCost.Text == "0" || string.IsNullOrEmpty(txtPMCost.Text))
                {
                    PMCost = 0;
                }
                else
                {
                    PMCost = Convert.ToDecimal(txtPMCost.Text);
                }
                sum = LandValue + Building + PMCost;
                lblTotProjCost.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void txtAnnualTurnOver_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtAnnualTurnOver.Text != "")
                {
                    string Res = objSrvcbal.GETANNUALTURNOVER(txtPMCost.Text.ToString(), txtAnnualTurnOver.Text.ToString());
                    if (Res != "")
                    {
                        txtAnnualTurnOver.Text = "";
                        string message = "alert('" + Res + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;

                    }
                    else
                    {
                        string Result = objSrvcbal.CFEENTERPRISETYPE(txtAnnualTurnOver.Text.ToString());
                        if (Result != "")
                        {
                            lblEntCategory.Text = Result;

                        }
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

        protected void btnsave_Click(object sender, EventArgs e)
        {
            
            try
            {

                ErrorMsg = Validations();
                if (ErrorMsg == "")
                {
                    SvrcApplicationDetails ObjApplicationDetails = new SvrcApplicationDetails();

                    if (Convert.ToString(Session["SRVCQID"]) == "")
                        ObjApplicationDetails.Questionnariid = "";
                    else
                        ObjApplicationDetails.Questionnariid = Convert.ToString(Session["SRVCQID"]);


                    ObjApplicationDetails.CreatedBy = hdnUserID.Value;
                    ObjApplicationDetails.UnitId = Convert.ToString(Session["SRVCUNITID"]);
                    ObjApplicationDetails.IPAddress = getclientIP();
                   // ObjApplicationDetails.UidNo = UID;

                    ObjApplicationDetails.Nameofunit = txtUnitName.Text;
                    ObjApplicationDetails.companyType = ddlCompanyType.SelectedValue;
                    ObjApplicationDetails.INDUSTRY = ddlSectorEnter.SelectedValue;
                    ObjApplicationDetails.CATEGORYREG = ddlRegType.SelectedValue;
                    ObjApplicationDetails.RegNumber = txtRegNo.Text;
                    ObjApplicationDetails.RegDate = txtRegDate.Text;
                    ObjApplicationDetails.Sector = ddlsector.SelectedValue;
                    ObjApplicationDetails.LineofActivity = ddlLineActivity.SelectedValue;
                    ObjApplicationDetails.PCB = lblPCBCategory.Text;
                    ObjApplicationDetails.SURVEY = txtDoors.Text;
                    ObjApplicationDetails.LOCALITY = txtLocality.Text;
                    ObjApplicationDetails.LANMARK = txtLANDMARK.Text;
                    ObjApplicationDetails.DISTRICT = ddlDistrict.SelectedValue;
                    ObjApplicationDetails.MANDAL = ddlMandal.SelectedValue;
                    ObjApplicationDetails.VILLAGE = ddlVillage.SelectedValue;
                    ObjApplicationDetails.EMAILID = txtEmailId.Text;
                    ObjApplicationDetails.MOBILENO = txtMobileNo.Text;
                    ObjApplicationDetails.PINCODE = txtpincode.Text;
                    ObjApplicationDetails.TOTALEXTENT = txtLandArea.Text;
                    ObjApplicationDetails.BUILDUPAREA = txtBuiltArea.Text;
                    ObjApplicationDetails.NamePromoter = txtName.Text;
                    ObjApplicationDetails.SONOF = txtSoWoDo.Text;
                    ObjApplicationDetails.Email = txtEmail.Text;
                    ObjApplicationDetails.MobileNumber = txtphoneno.Text;
                    ObjApplicationDetails.ALTERNATIVAENO = txtAltMobile.Text;
                    ObjApplicationDetails.LANDLINENO = txtLandlineno.Text;
                    ObjApplicationDetails.DoorNo = txtDoorNo.Text;
                    ObjApplicationDetails.Local = txtLocal.Text;
                    ObjApplicationDetails.State = ddlstate.SelectedValue;
                    ObjApplicationDetails.Districts = ddldist.SelectedValue;
                    ObjApplicationDetails.Mandals = ddlmand.SelectedValue;
                    ObjApplicationDetails.Villages = ddlvilla.SelectedValue;
                    ObjApplicationDetails.AppDistrict = txtApplDist.Text;
                    ObjApplicationDetails.AppMandal = txtApplTaluka.Text;
                    ObjApplicationDetails.AppVillge = txtApplVillage.Text;
                    ObjApplicationDetails.Pin = txtPin.Text;
                    ObjApplicationDetails.Age = txtAge.Text;
                    ObjApplicationDetails.Designation = txtDesignation.Text;
                    ObjApplicationDetails.WOMEN = rblWomen.SelectedValue;
                    ObjApplicationDetails.ABLED = rblAbled.SelectedValue;
                    ObjApplicationDetails.DIRECTMALE = txtMale.Text;
                    ObjApplicationDetails.DIRECTFEMALE = txtFemale.Text;
                    ObjApplicationDetails.DIRECTEMP = txtDirectOthers.Text;
                    ObjApplicationDetails.INDIRECTMALE = txtIndirectMale.Text;
                    ObjApplicationDetails.INDIRECTFEMALE = txtIndirectFemale.Text;
                    ObjApplicationDetails.INDIRECTEMP = txtInDirectOthers.Text;
                    ObjApplicationDetails.TOTALEMP = txtPropEmp.Text;
                    ObjApplicationDetails.LandSaleDeed = txtLandValue.Text;
                    ObjApplicationDetails.Building = txtBuildingValue.Text;
                    ObjApplicationDetails.PlantMachinary = txtPMCost.Text;
                    ObjApplicationDetails.TotalProjectCost = lblTotProjCost.Text;
                    ObjApplicationDetails.AnnualTurnOver = txtAnnualTurnOver.Text;
                    ObjApplicationDetails.EnterpriseCategory = lblEntCategory.Text; 
                    ObjApplicationDetails.UidNo = "SRVC" + "/" + DateTime.Now.Year.ToString() + "/" + ObjApplicationDetails.Questionnariid;


                    result = objSrvcbal.InsertRenApplicationDetails(ObjApplicationDetails);

                    if (result != "")
                    {
                        Session["SRVCQID"] = result;
                        result = "SRVC" + "/" + DateTime.Now.Year.ToString() + "/" + result;
                        success.Visible = true;
                        lblmsg.Text = "Enterprise Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                        //  Response.Redirect("AckSlip.aspx?UID=" + result);
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public string Validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                List<TextBox> emptyTextboxes = FindEmptyTextboxes(divText);

                if (string.IsNullOrEmpty(txtUnitName.Text) || txtUnitName.Text == "" || txtUnitName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Unit Name \\n";
                    slno = slno + 1;
                }
                if (ddlCompanyType.SelectedValue == "0" || ddlCompanyType.SelectedValue == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Company Type\\n";
                    slno = slno + 1;
                }
                if (ddlSectorEnter.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Select Nature of Industry\\n";
                    slno = slno + 1;
                }
                if (ddlRegType.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Select Category of Registration\\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtRegNo.Text) || txtRegNo.Text == "" || txtRegNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Registration Number \\n";
                    slno = slno + 1;

                }
                /* if (string.IsNullOrEmpty(txtRegDate.Text) || txtRegDate.Text == "" || txtRegDate.Text == null)
                 {
                     errormsg = errormsg + slno + ". Please Enter Registration Date \\n";
                     slno = slno + 1;

                 }
                 if (ddlsector.SelectedIndex == 0)
                 {
                     errormsg = errormsg + slno + ". Please Select sector \\n";
                     slno = slno + 1;
                 }*/
                if (ddlLineActivity.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Select Line Of Activity \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDoors.Text) || txtDoors.Text == "" || txtDoors.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Survey/Door \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLocality.Text) || txtLocality.Text == "" || txtLocality.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter LOCALITY \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLANDMARK.Text) || txtLANDMARK.Text == "" || txtLANDMARK.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter LANDMARK \\n";
                    slno = slno + 1;
                }
                if (ddlDistrict.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Enter DISTRICT\\n";
                    slno = slno + 1;
                }
                if (ddlMandal.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Enter MANDAL \\n";
                    slno = slno + 1;
                }
                if (ddlVillage.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Enter VILLAGE \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEmailId.Text) || txtEmailId.Text == "" || txtEmailId.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter EMAILID \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtMobileNo.Text) || txtMobileNo.Text == "" || txtMobileNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter MOBILENO \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtpincode.Text) || txtpincode.Text == "" || txtpincode.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter PINCODE \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLandArea.Text) || txtLandArea.Text == "" || txtLandArea.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter TOTAL EXTENT LAND \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtBuiltArea.Text) || txtBuiltArea.Text == "" || txtBuiltArea.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter BUILTUPAREA \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtName.Text) || txtName.Text == "" || txtName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter NAME \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtSoWoDo.Text) || txtSoWoDo.Text == "" || txtSoWoDo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter S/O.D/O.W/O \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEmail.Text) || txtEmail.Text == "" || txtEmail.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter EmailId \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtphoneno.Text) || txtphoneno.Text == "" || txtphoneno.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter MobileNo....! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAltMobile.Text) || txtAltMobile.Text == "" || txtAltMobile.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter ALTERNATIVE MOBILE NUMBER....! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDoorNo.Text) || txtDoorNo.Text == "" || txtDoorNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Doors....! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLocal.Text) || txtLocal.Text == "" || txtLocal.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Locality....! \\n";
                    slno = slno + 1;
                }
                if (ddlstate.SelectedIndex == 0)
                {
                    if (ddlstate.SelectedItem.Text == "Meghalaya")
                    {
                        if (ddldist.SelectedIndex == 0)
                        {
                            errormsg = errormsg + slno + ". Please Select distric....! \\n";
                            slno = slno + 1;
                        }
                        if (ddlmand.SelectedIndex == 0)
                        {
                            errormsg = errormsg + slno + ". Please Select Mandal....! \\n";
                            slno = slno + 1;
                        }
                        if (ddlvilla.SelectedIndex == 0)
                        {
                            errormsg = errormsg + slno + ". Please Select village....! \\n";
                            slno = slno + 1;
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(txtApplDist.Text) || txtApplDist.Text == "" || txtApplDist.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter Distric....! \\n";
                            slno = slno + 1;
                        }
                        if (string.IsNullOrEmpty(txtApplTaluka.Text) || txtApplTaluka.Text == "" || txtApplTaluka.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter Mandal....! \\n";
                            slno = slno + 1;
                        }
                        if (string.IsNullOrEmpty(txtApplVillage.Text) || txtApplVillage.Text == "" || txtApplVillage.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter Village....! \\n";
                            slno = slno + 1;
                        }
                    }
                }

                if (string.IsNullOrEmpty(txtPin.Text) || txtPin.Text == "" || txtPin.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Pincode....! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAge.Text) || txtAge.Text == "" || txtAge.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Age....! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDesignation.Text) || txtDesignation.Text == "" || txtDesignation.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Designation....! \\n";
                    slno = slno + 1;
                }
                if (rblWomen.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Enter Women Entrepreneur....! \\n";
                    slno = slno + 1;
                }
                if (rblAbled.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Enter DIFFERENTLY ABLED....! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtMale.Text) || txtMale.Text == "" || txtMale.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter DIRECT MALE \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtFemale.Text) || txtFemale.Text == "" || txtFemale.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter DIRECT FEMALE \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDirectOthers.Text) || txtDirectOthers.Text == "" || txtDirectOthers.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter DIRECT OTHER EMPLOYEE  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtIndirectMale.Text) || txtIndirectMale.Text == "" || txtIndirectMale.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter INDIRECTMALE \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtIndirectFemale.Text) || txtIndirectFemale.Text == "" || txtIndirectFemale.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter INDIRECTFEMALE \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtInDirectOthers.Text) || txtInDirectOthers.Text == "" || txtInDirectOthers.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter INDIRECTOTHEREMPLOYEE \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtPropEmp.Text) || txtPropEmp.Text == "" || txtPropEmp.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter TOTAL EMPLOYEE \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLandValue.Text) || txtLandValue.Text == "" || txtLandValue.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Land Saledeed(INR) \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtBuildingValue.Text) || txtBuildingValue.Text == "" || txtBuildingValue.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Building(INR) \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPMCost.Text) || txtPMCost.Text == "" || txtPMCost.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Plant and Machinery(INR) \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAnnualTurnOver.Text) || txtAnnualTurnOver.Text == "" || txtAnnualTurnOver.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Expected Annual TurnOver \\n";
                    slno = slno + 1;
                }


                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                btnsave_Click(sender, e);
                if (ErrorMsg == "")
                    Response.Redirect("~/User/Services/OtherServices.aspx");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                if (ex.Message != "Thread was being aborted.")
                {
                    MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
                }
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

        protected List<TextBox> FindEmptyTextboxes(Control container)
        {

            List<TextBox> emptyTextboxes = new List<TextBox>();
            foreach (Control control in container.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textbox = (TextBox)control;
                    if (string.IsNullOrWhiteSpace(textbox.Text))
                    {
                        emptyTextboxes.Add(textbox);
                        textbox.BorderColor = System.Drawing.Color.Red;
                    }
                }

                if (control.HasControls())
                {
                    emptyTextboxes.AddRange(FindEmptyTextboxes(control));
                }
            }
            return emptyTextboxes;
        }
    }

}