using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.PreRegBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace MeghalayaUIP.User.PreReg
{
    public partial class IndustryRegistration : System.Web.UI.Page
    {
        int index;

        readonly LoginBAL objloginBAL = new LoginBAL();
        MasterBAL mstrBAL = new MasterBAL();
        PreRegBAL indstregBAL = new PreRegBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
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

                    Page.MaintainScrollPositionOnPostBack = true;
                    Failure.Visible = false;
                    success.Visible = false;
                    if (!IsPostBack)
                    {
                        MVprereg.ActiveViewIndex = index;
                        BindDistricts();

                        BindCountries();
                        BindStates();
                        BindConstitutionType();
                        BindRevenueProjectionsMaster();
                        BindSectors();
                        BindRegistrationType();
                        BindData();
                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = "Oops, You've have encountered an error!! please contact administrator.";
                Failure.Visible = true;
                throw ex;
            }
        }

        public void BindData()
        {

            try
            {
                DataSet ds = new DataSet();
                ds = indstregBAL.GetIndustryRegData(hdnUserID.Value);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ViewState["UnitID"] = Convert.ToString(ds.Tables[0].Rows[0]["UNITID"]);
                            txtUnitName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]);
                            txtPANno.Text = Convert.ToString(ds.Tables[0].Rows[0]["COMPANYPANNO"]);
                            rblproposal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["COMPANYTYPE"]);
                            // txtCompnyRegDt.TextMode = TextBoxMode.Date;

                            txtCompnyRegDt.Text = Convert.ToString(ds.Tables[0].Rows[0]["REGISTRATIONDATEnew"]);

                            txtUdyamorIEMNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["UDYAMNO"]);
                            txtGSTNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["GSTNNO"]);
                            txtAuthReprName.Text = Convert.ToString(ds.Tables[0].Rows[0]["REP_NAME"]);
                            txtAuthReprMobile.Text = Convert.ToString(ds.Tables[0].Rows[0]["REP_MOBILE"]);
                            txtAuthReprEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["REP_EMAIL"]);
                            txtAuthReprLocality.Text = Convert.ToString(ds.Tables[0].Rows[0]["REP_LOCALITY"]);
                            ddlAuthReprDist.SelectedValue = ds.Tables[0].Rows[0]["REP_DISTRICTID"].ToString();
                            ddlAuthReprDist_SelectedIndexChanged(null, EventArgs.Empty);
                            ddlAuthReprTaluka.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["REP_MANDALID"]);
                            ddlAuthReprTaluka_SelectedIndexChanged(null, EventArgs.Empty);
                            ddlAuthReprVillage.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["REP_VILLAGEID"]);

                            txtAuthReprPincode.Text = Convert.ToString(ds.Tables[0].Rows[0]["REP_PINCODE"]);

                            rblLandType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["UNIT_LANDTYPE"]);
                            txtPropLocDoorno.Text = Convert.ToString(ds.Tables[0].Rows[0]["UNIT_DOORNO"]);
                            txtPropLocLocality.Text = Convert.ToString(ds.Tables[0].Rows[0]["UNIT_LOCALITY"]);
                            ddlPropLocDist.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["UNIT_DISTRICTID"]);
                            ddlPropLocDist_SelectedIndexChanged(this, EventArgs.Empty);
                            ddlPropLocTaluka.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["UNIT_MANDALID"]);
                            ddlPropLocTaluka_SelectedIndexChanged(this, EventArgs.Empty);
                            ddlPropLocVillage.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["UNIT_VILLAGEID"]);
                            txtPropLocPincode.Text = Convert.ToString(ds.Tables[0].Rows[0]["UNIT_PINCODE"]);
                            txtDCPorOperation.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_DCP"]);
                            ddlSector.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_SECTORNAME"]);
                            ddlSector_SelectedIndexChanged(null, EventArgs.Empty);
                            ddlLineOfActivity.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_LOAID"]);
                            lblPCBCategory.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_PCBCATEGORY"]);
                            rblNatureofActvty.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_NOA"]);
                            txtMainManf.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_MANFACTIVITY"]);
                            txtManfprodct.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_MANFPRODUCT"]);
                            txtProductionNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_MANFPRODNO"]);
                            txtServcActvty.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_SRVCACTIVITY"]);
                            txtServctobeprovded.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_SRVCNAME"]);
                            txtSrviceno.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_SRVCNO"]);
                            txtWasteDetails.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_WASTEDETAILS"]);
                            txtHazWasteDetails.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_HAZWASTEDETAILS"]);
                            txtRawmaterial.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_MAINRM"]);

                            txtCivilConstr.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_CIVILCONSTR"]);
                            txtLandAreainSqft.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_LANDAREA"]);
                            txtBuildingAreaSqm.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_BUILDINGAREA"]);
                            txtPowerReqKV.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_POWERRREQ"]);
                            txtWaterReqKLD.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_WATERREQ"]);
                            txtMeasurementUnits.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_UNITOFMEASURE"]);
                            txtAnnualCapacity.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_ANNUALCAPACITY"]);
                            txtEstimatedProjCost.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_EPCOST"]);
                            txtPlantnMachineryCost.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_PMCOST"]);
                            txtCapitalInvestment.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_IFC"]);
                            txtFixedAssets.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_DFA"]);
                            txtLandValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_LANDVALUE"]);
                            txtBuildingValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_BUILDINGVALUE"]);
                            txtWaterValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_WATERVALUE"]);
                            txtElectricityValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_ELECTRICITYVALUE"]);
                            txtWorkingCapital.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_WORKINGCAPITAL"]);
                            txtCapitalSubsidy.Text = Convert.ToString(ds.Tables[0].Rows[0]["FRD_CAPITALSUBSIDY"]);
                            txtPromoterEquity.Text = Convert.ToString(ds.Tables[0].Rows[0]["FRD_PROMOTEREQUITY"]);
                            txtLoanAmount.Text = Convert.ToString(ds.Tables[0].Rows[0]["FRD_LOAN"]);
                        }
                    }
                    //if (ds.Tables.Count > 1)
                    //{
                    //    //ViewState["MRPID"].ToString();
                    //    //DataTable dt = jrresult                       

                    //    grdRevenueProj.Visible = true;
                    //    grdRevenueProj.DataSource = ds.Tables[0];
                    //    grdRevenueProj.DataBind();
                    //}
                }


            }

            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }

        }
        protected void BindConstitutionType()
        {
            try
            {
                ddlConstType.Items.Clear();

                List<MasterConstType> objConsttype = new List<MasterConstType>();

                objConsttype = mstrBAL.GetConstitutionType();
                if (objConsttype != null)
                {
                    ddlConstType.DataSource = objConsttype;
                    ddlConstType.DataValueField = "ConstId";
                    ddlConstType.DataTextField = "ConstName";
                    ddlConstType.DataBind();
                }
                else
                {
                    ddlConstType.DataSource = null;
                    ddlConstType.DataBind();
                }
                AddSelect(ddlConstType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void BindCountries()
        {
            try
            {
                ddlApplCountry.Items.Clear();

                List<MasterCountry> objCoutryModel = new List<MasterCountry>();

                objCoutryModel = mstrBAL.GetCountries();
                if (objCoutryModel != null)
                {
                    ddlApplCountry.DataSource = objCoutryModel;
                    ddlApplCountry.DataValueField = "CountryId";
                    ddlApplCountry.DataTextField = "CountryName";
                    ddlApplCountry.DataBind();
                }
                else
                {
                    ddlApplCountry.DataSource = null;
                    ddlApplCountry.DataBind();
                }
                AddSelect(ddlApplCountry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void BindStates()
        {
            try
            {
                ddlApplState.Items.Clear();

                List<MasterStates> objStatesModel = new List<MasterStates>();

                objStatesModel = mstrBAL.GetStates();
                if (objStatesModel != null)
                {
                    ddlApplState.DataSource = objStatesModel;
                    ddlApplState.DataValueField = "StateId";
                    ddlApplState.DataTextField = "StateName";
                    ddlApplState.DataBind();
                }
                else
                {
                    ddlApplState.DataSource = null;
                    ddlApplState.DataBind();
                }
                AddSelect(ddlApplState);
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

                ddlAuthReprDist.Items.Clear();
                ddlAuthReprTaluka.Items.Clear();
                ddlAuthReprVillage.Items.Clear();
                ddlPropLocDist.Items.Clear();
                ddlPropLocTaluka.Items.Clear();
                ddlPropLocVillage.Items.Clear();
                ddlApplDist.Items.Clear();
                ddlApplTaluka.Items.Clear();
                ddlApplVillage.Items.Clear();
                List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();
                string strmode = string.Empty;
                //if (ObjUserInformation.User_Level == "2")
                //{
                strmode = "";
                //}
                objDistrictModel = mstrBAL.GetDistrcits();
                if (objDistrictModel != null)
                {
                    ddlAuthReprDist.DataSource = objDistrictModel;
                    ddlAuthReprDist.DataValueField = "DistrictId";
                    ddlAuthReprDist.DataTextField = "DistrictName";
                    ddlAuthReprDist.DataBind();

                    ddlPropLocDist.DataSource = objDistrictModel;
                    ddlPropLocDist.DataValueField = "DistrictId";
                    ddlPropLocDist.DataTextField = "DistrictName";
                    ddlPropLocDist.DataBind();


                    ddlApplDist.DataSource = objDistrictModel;
                    ddlApplDist.DataValueField = "DistrictId";
                    ddlApplDist.DataTextField = "DistrictName";
                    ddlApplDist.DataBind();
                }
                else
                {
                    ddlAuthReprDist.DataSource = null;
                    ddlAuthReprDist.DataBind();

                    ddlPropLocDist.DataSource = null;
                    ddlPropLocDist.DataBind();

                    ddlApplDist.DataSource = null;
                    ddlApplDist.DataBind();
                }
                AddSelect(ddlAuthReprDist);
                AddSelect(ddlAuthReprTaluka);
                AddSelect(ddlAuthReprVillage);

                AddSelect(ddlPropLocDist);
                AddSelect(ddlPropLocTaluka);
                AddSelect(ddlPropLocVillage);

                AddSelect(ddlApplDist);
                AddSelect(ddlApplTaluka);
                AddSelect(ddlApplVillage);

            }
            catch (Exception ex)
            {
                throw ex;
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

                throw ex;
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

        protected void BindLineOfActivity(string Sector)
        {
            try
            {
                List<MasterLineOfActivity> objLOA = mstrBAL.GetLineOfActivity(Sector);

                if (objLOA != null && objLOA.Count > 0)
                {
                    ddlLineOfActivity.DataSource = objLOA;
                    ddlLineOfActivity.DataValueField = "LOAId";
                    ddlLineOfActivity.DataTextField = "LOAName";
                    ddlLineOfActivity.DataBind();
                }
                else
                {

                    ddlLineOfActivity.DataSource = null;
                    ddlLineOfActivity.DataBind();
                }

                AddSelect(ddlLineOfActivity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        protected void ddlSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlSector.SelectedValue.ToString() != "--Select--")
                {
                    BindLineOfActivity(ddlSector.SelectedItem.Text);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void ddlLineOfActivity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlLineOfActivity.SelectedItem.Text != "--Select--")
                {
                    lblPCBCategory.Text = mstrBAL.GetPCBCategory(ddlLineOfActivity.SelectedValue);

                }
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
                li.Text = "--Select--";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void BindRevenueProjectionsMaster()
        {

            try
            {
                DataTable dt = new DataTable();

                dt = indstregBAL.GetRevenueProjectionsMaster();
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
                throw ex;
            }
        }
        protected void ddlAuthReprDist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlAuthReprTaluka.ClearSelection();
                ddlAuthReprVillage.ClearSelection();
                if (ddlAuthReprDist.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlAuthReprTaluka, ddlAuthReprDist.SelectedValue);
                }
                else return;
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }
        protected void ddlAuthReprTaluka_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlAuthReprVillage.ClearSelection();
                if (ddlAuthReprTaluka.SelectedItem.Text != "--Select--")
                {

                    BindVillages(ddlAuthReprVillage, ddlAuthReprTaluka.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }

        }

        protected void ddlPropLocDist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlPropLocTaluka.ClearSelection();
                ddlPropLocVillage.ClearSelection();
                if (ddlPropLocDist.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlPropLocTaluka, ddlPropLocDist.SelectedValue);
                }
                else return;
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }

        protected void ddlPropLocTaluka_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlPropLocVillage.ClearSelection();
                if (ddlPropLocTaluka.SelectedItem.Text != "--Select--")
                {

                    BindVillages(ddlPropLocVillage, ddlPropLocTaluka.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }
        protected void ddlApplDist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlApplTaluka.ClearSelection();
                ddlApplVillage.ClearSelection();
                if (ddlApplDist.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlApplTaluka, ddlApplDist.SelectedValue);
                }
                else return;
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }
        protected void ddlApplTaluka_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlApplVillage.ClearSelection();
                if (ddlApplTaluka.SelectedItem.Text != "--Select--")
                {

                    BindVillages(ddlApplVillage, ddlApplTaluka.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }

        }

        protected void rblNatureofActvty_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblNatureofActvty.SelectedItem.Text == "Manufacturing")
                {
                    divManf.Visible = true;
                    divservc.Visible = false;
                    txtServcActvty.Text = "";
                    txtServctobeprovded.Text = "";
                }
                else if (rblNatureofActvty.SelectedItem.Text == "Service")
                {
                    divservc.Visible = true;
                    divManf.Visible = false;
                    txtMainManf.Text = "";
                    txtManfprodct.Text = "";
                }



            }
            catch (Exception ex) { }
        }
        protected void btnsave1_Click(object sender, EventArgs e)
        {
            try
            {
                string ErrorMsg = "", result = "";
                ErrorMsg = Step1validations();
                if (ErrorMsg == "")
                {
                    IndustryDetails ID = new IndustryDetails();
                    if (Convert.ToString(ViewState["UnitID"]) != "")
                    { ID.UnitID = Convert.ToString(ViewState["UnitID"]); }
                    ID.UserID = hdnUserID.Value;
                    ID.IPAddress = getclientIP();

                    ID.CompanyName = txtUnitName.Text.Trim();
                    ID.CompanyPAN = txtPANno.Text.Trim();
                    ID.CompnyRegDt = txtCompnyRegDt.Text.Trim();
                    ID.CompnyType = ddlConstType.SelectedValue;
                    ID.CompnyProposal= rblproposal.SelectedItem.Text.Trim();
                    ID.UdyamorIEMNo = txtUdyamorIEMNo.Text.Trim();
                    ID.GSTNo = txtGSTNo.Text.Trim();

                    ID.AuthReprName = txtAuthReprName.Text.Trim();
                    ID.AuthReprMobile = txtAuthReprMobile.Text.Trim();
                    ID.AuthReprEmail = txtAuthReprEmail.Text.Trim();
                    ID.AuthReprLocality = txtAuthReprLocality.Text.Trim();
                    ID.AuthReprDistID = ddlAuthReprDist.SelectedValue.Trim();
                    ID.AuthReprTalukaID = ddlAuthReprTaluka.SelectedValue;
                    ID.AuthReprVillageID = ddlAuthReprVillage.SelectedValue;
                    ID.AuthReprPincode = txtAuthReprPincode.Text.Trim();

                    ID.LandType = rblLandType.SelectedValue;
                    ID.PropLocDoorno = txtPropLocDoorno.Text.Trim();
                    ID.PropLocLocality = txtPropLocLocality.Text.Trim();
                    ID.PropLocDistID = ddlPropLocDist.SelectedValue;
                    ID.PropLocTalukaID = ddlPropLocTaluka.SelectedValue;
                    ID.PropLocVillageID = ddlPropLocVillage.SelectedValue;
                    ID.PropLocPincode = txtPropLocPincode.Text.Trim();

                    ID.DCPorOperation = txtDCPorOperation.Text.Trim();
                    ID.SectorName = ddlSector.SelectedValue;
                    ID.Lineofacitivityid = ddlLineOfActivity.SelectedValue;
                    ID.Category = lblPCBCategory.Text.Trim();
                    ID.NatureofActivity = rblNatureofActvty.SelectedValue;

                    ID.ManfActivity = txtMainManf.Text.Trim();
                    ID.Manfproduct = txtManfprodct.Text.Trim();
                    ID.ProductionNO = txtProductionNo.Text.Trim();
                    ID.ServiceActivity = txtServcActvty.Text.Trim();
                    ID.ServiceTobeProviding = txtServctobeprovded.Text.Trim();
                    ID.ServiceNo = txtSrviceno.Text.Trim();

                    ID.Rawmaterial = txtRawmaterial.Text.Trim();
                    ID.WasteDetails = txtWasteDetails.Text.Trim();
                    ID.HazWasteDetails = txtHazWasteDetails.Text.Trim();
                    ID.CivilConstr = txtCivilConstr.Text.Trim();
                    ID.LandAreainSqft = txtLandAreainSqft.Text.Trim();
                    ID.BuildingAreaSqm = txtBuildingAreaSqm.Text.Trim();
                    ID.WaterReqKLD = txtWaterReqKLD.Text.Trim();
                    ID.PowerReqKV = txtPowerReqKV.Text.Trim();
                    ID.MeasurementUnits = txtMeasurementUnits.Text.Trim();

                    ID.AnnualCapacity = txtAnnualCapacity.Text.Trim();
                    ID.EstimatedProjCost = txtEstimatedProjCost.Text.Trim();
                    ID.PlantnMachineryCost = txtPlantnMachineryCost.Text.Trim();
                    ID.CapitalInvestment = txtCapitalInvestment.Text.Trim();
                    ID.FixedAssets = txtFixedAssets.Text.Trim();

                    ID.LandValue = txtLandValue.Text.Trim();
                    ID.BuildingValue = txtBuildingValue.Text.Trim();
                    ID.WaterValue = txtWaterValue.Text.Trim();
                    ID.ElectricityValue = txtElectricityValue.Text.Trim();
                    ID.WorkingCapital = txtWorkingCapital.Text.Trim();

                    ID.CapitalSubsidy = txtCapitalSubsidy.Text.Trim();
                    ID.PromoterEquity = txtPromoterEquity.Text.Trim();
                    ID.LoanAmount = txtLoanAmount.Text.Trim();
                    ID.BankName = txtBankName.Text.Trim();
                    ID.CetralSchemeAmount = txtcentral.Text.Trim();
                    ID.UnnatiSchemeAmount = txtUNNATI.Text.Trim();
                    ID.StateSchemeAmount = txtstatescheme.Text.Trim();
                    ID.DoorNo = txtAuthReprDoorNo.Text.Trim();
                    ID.RegistrationNo = txtLoanAmount.Text.Trim();
                    try
                    {
                        DataTable dt = new DataTable();

                        dt = indstregBAL.GetSectorDepartments(ddlSector.SelectedValue);
                        if (dt.Rows.Count > 0)
                        {
                            ID.Deptid = dt.Rows[0].Table.Columns["MD_DEPTID"].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    result = indstregBAL.InsertIndRegBasicDetails(ID, out string IDno);
                    ViewState["UnitID"] = result;
                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "Basic Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    string message = "alert('" + ErrorMsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (SqlException ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }

        }
        public string Step1validations()
        {
            try
            {

                int slno = 1;
                string errormsg = "";
                //if (string.IsNullOrEmpty(txtPANno.Text) || txtPANno.Text == "" || txtPANno.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Company PAN \\n";
                //    slno = slno + 1;
                //}
                if (string.IsNullOrEmpty(txtUnitName.Text) || txtUnitName.Text == "" || txtUnitName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Company Registration /Incorporation Date \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtCompnyRegDt.Text) || txtCompnyRegDt.Text == "" || txtCompnyRegDt.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Company Registration /Incorporation Date \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtUdyamorIEMNo.Text) || txtUdyamorIEMNo.Text == "" || txtUdyamorIEMNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Udyam/IEM Number \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtGSTNo.Text) || txtGSTNo.Text == "" || txtGSTNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter GST Number \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAuthReprName.Text) || txtAuthReprName.Text == "" || txtAuthReprName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enteror Authorised Representative Name \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAuthReprMobile.Text) || txtAuthReprMobile.Text == "" || txtAuthReprMobile.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Authorised Representative Mobile Number \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAuthReprEmail.Text) || txtAuthReprEmail.Text == "" || txtAuthReprEmail.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Authorised Representative Email \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAuthReprLocality.Text) || txtAuthReprLocality.Text == "" || txtAuthReprLocality.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Authorised Representative Locality \\n";
                    slno = slno + 1;
                }
                if (ddlAuthReprDist.SelectedIndex == -1 || ddlAuthReprDist.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Authorised Representative District \\n";
                    slno = slno + 1;
                }
                if (ddlAuthReprTaluka.SelectedIndex == -1 || ddlAuthReprTaluka.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Authorised Representative Mandal or Taluka \\n";
                    slno = slno + 1;
                }
                if (ddlAuthReprVillage.SelectedIndex == -1 || ddlAuthReprVillage.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Authorised Representative Village \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAuthReprPincode.Text) || txtAuthReprPincode.Text == "" || txtAuthReprPincode.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Authorised Representative PinCode \\n";
                    slno = slno + 1;
                }


                if (string.IsNullOrEmpty(txtPropLocDoorno.Text) || txtPropLocDoorno.Text == "" || txtPropLocDoorno.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Proposed Unit Door number \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPropLocLocality.Text) || txtPropLocLocality.Text == "" || txtPropLocLocality.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Proposed Unit Locality \\n";
                    slno = slno + 1;
                }
                if (ddlPropLocDist.SelectedIndex == -1 || ddlPropLocDist.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Proposed Unit District \\n";
                    slno = slno + 1;
                }
                if (ddlPropLocTaluka.SelectedIndex == -1 || ddlPropLocTaluka.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Proposed Unit Mandal/Taluka \\n";
                    slno = slno + 1;
                }
                if (ddlPropLocVillage.SelectedIndex == -1 || ddlPropLocVillage.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Proposed Unit Village \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPropLocPincode.Text) || txtPropLocPincode.Text == "" || txtPropLocPincode.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Proposed Unit PinCode \\n";
                    slno = slno + 1;
                }
                if (rblNatureofActvty.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Nature of Activity \\n";
                    slno = slno + 1;
                }
                if (rblNatureofActvty.SelectedValue == "Manufacturing")
                {
                    if (string.IsNullOrEmpty(txtMainManf.Text) || txtMainManf.Text == "" || txtMainManf.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Main Manufacturing Activity \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtManfprodct.Text) || txtManfprodct.Text == "" || txtManfprodct.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Product to be Manufactured \\n";
                        slno = slno + 1;
                    }
                }
                if (rblNatureofActvty.SelectedValue == "Service")
                {
                    if (string.IsNullOrEmpty(txtServcActvty.Text) || txtServcActvty.Text == "" || txtServcActvty.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Main Service Activity \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtServctobeprovded.Text) || txtServctobeprovded.Text == "" || txtServctobeprovded.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Service to be Provided \\n";
                        slno = slno + 1;
                    }
                }
                if (ddlSector.SelectedIndex == -1 || ddlSector.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Sector \\n";
                    slno = slno + 1;
                }
                if (ddlLineOfActivity.SelectedIndex == -1 || ddlLineOfActivity.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Line of Activity \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAnnualCapacity.Text) || txtAnnualCapacity.Text == "" || txtAnnualCapacity.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Annual Capacity \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEstimatedProjCost.Text) || txtEstimatedProjCost.Text == "" || txtEstimatedProjCost.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Estimated Project Cost  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLandAreainSqft.Text) || txtLandAreainSqft.Text == "" || txtLandAreainSqft.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Land area in (in Sq.ft) \\n";
                    slno = slno + 1;
                }


                if (string.IsNullOrEmpty(txtCivilConstr.Text) || txtCivilConstr.Text == "" || txtCivilConstr.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Civil Construction details \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPlantnMachineryCost.Text) || txtPlantnMachineryCost.Text == "" || txtPlantnMachineryCost.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Plant & Machinery Cost \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtRawmaterial.Text) || txtRawmaterial.Text == "" || txtRawmaterial.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Main Raw Materials details \\n";
                    slno = slno + 1;
                }
                //if (string.IsNullOrEmpty(txtEstimatedProjCost.Text) || txtEstimatedProjCost.Text == "" || txtEstimatedProjCost.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Cpatcha \\n";
                //    slno = slno + 1;
                //}
                //if (string.IsNullOrEmpty(txtLandAreainSqft.Text) || txtLandAreainSqft.Text == "" || txtLandAreainSqft.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Cpatcha \\n";
                //    slno = slno + 1;
                //}

                if (string.IsNullOrEmpty(txtBuildingAreaSqm.Text) || txtBuildingAreaSqm.Text == "" || txtBuildingAreaSqm.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Area of Building / Shed \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtWaterReqKLD.Text) || txtWaterReqKLD.Text == "" || txtWaterReqKLD.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Water required (KL/D) \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPowerReqKV.Text) || txtPowerReqKV.Text == "" || txtPowerReqKV.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Power Required (KV) \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtWasteDetails.Text) || txtWasteDetails.Text == "" || txtWasteDetails.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Details of waste / effluent \\n";
                    slno = slno + 1;
                }


                if (string.IsNullOrEmpty(txtHazWasteDetails.Text) || txtHazWasteDetails.Text == "" || txtHazWasteDetails.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Details of hazardous waste \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtCapitalInvestment.Text) || txtCapitalInvestment.Text == "" || txtCapitalInvestment.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Investment in Fixed Capital \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtFixedAssets.Text) || txtFixedAssets.Text == "" || txtFixedAssets.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Durable Fixed Assets \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtMeasurementUnits.Text) || txtMeasurementUnits.Text == "" || txtMeasurementUnits.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Unit of measurement \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLandValue.Text) || txtLandValue.Text == "" || txtLandValue.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Value of Building / Shed \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtBuildingValue.Text) || txtBuildingValue.Text == "" || txtBuildingValue.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Value of Building / Shed \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtWaterValue.Text) || txtWaterValue.Text == "" || txtWaterValue.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Water Value \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtElectricityValue.Text) || txtElectricityValue.Text == "" || txtElectricityValue.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Electricity  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtWorkingCapital.Text) || txtWorkingCapital.Text == "" || txtWorkingCapital.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Working Capital \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtCapitalSubsidy.Text) || txtCapitalSubsidy.Text == "" || txtCapitalSubsidy.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Capital Subsidy/ Benefit from UNNATI/ other Central / State Scheme (INR) \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPromoterEquity.Text) || txtPromoterEquity.Text == "" || txtPromoterEquity.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Promoter’s Equity \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLoanAmount.Text) || txtLoanAmount.Text == "" || txtLoanAmount.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Loan Amount \\n";
                    slno = slno + 1;
                }

                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnsave2_Click(object sender, EventArgs e)
        {
            try
            {
                // ViewState["UnitID"] = 1002;
                string ErrorMsg = "", result = "";
                if (Convert.ToString(ViewState["UnitID"]) != "")
                {
                    ErrorMsg = Step2validations();
                    if (ErrorMsg == "")
                    {
                        DataTable dt = new DataTable();
                        DataRow dr;
                        dt.Columns.Add("IBP_UNITID");
                        dt.Columns.Add("IBP_INVESTERID");
                        dt.Columns.Add("YEAR1");
                        dt.Columns.Add("YEAR2");
                        dt.Columns.Add("YEAR3");
                        dt.Columns.Add("YEAR4");
                        dt.Columns.Add("YEAR5");
                        dt.Columns.Add("MRPID");
                        if (grdRevenueProj.Rows.Count > 0)
                        {
                            for (int j = 0; j < grdRevenueProj.Rows.Count; j++)
                            {
                                Label lblIBPID = grdRevenueProj.Rows[j].FindControl("lblMRPID") as Label;
                                TextBox txtYear1 = grdRevenueProj.Rows[j].FindControl("txtYear1") as TextBox;
                                TextBox txtYear2 = grdRevenueProj.Rows[j].FindControl("txtYear2") as TextBox;
                                TextBox txtYear3 = grdRevenueProj.Rows[j].FindControl("txtYear3") as TextBox;
                                TextBox txtYear4 = grdRevenueProj.Rows[j].FindControl("txtYear4") as TextBox;
                                TextBox txtYear5 = grdRevenueProj.Rows[j].FindControl("txtYear5") as TextBox;

                                try
                                {
                                    dr = dt.NewRow();
                                    dr["IBP_UNITID"] = Convert.ToString(ViewState["UnitID"]);
                                    dr["IBP_INVESTERID"] = hdnUserID.Value;
                                    dr["YEAR1"] = txtYear1.Text;
                                    dr["YEAR2"] = txtYear2.Text;
                                    dr["YEAR3"] = txtYear3.Text;
                                    dr["YEAR4"] = txtYear4.Text;
                                    dr["YEAR5"] = txtYear5.Text;
                                    dr["MRPID"] = lblIBPID.Text;
                                    dt.Rows.Add(dr);
                                }
                                catch (Exception ex)
                                {
                                    throw ex;
                                }
                            }
                            DataTable dt1 = dt;
                            result = indstregBAL.InsertIndRegRevenueDetails(dt);
                            if (result != "")
                            {
                                string message = "alert('" + "Step 2 saved Successfully" + "')";
                                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        Failure.Visible = true;
                        lblmsg0.Text = ErrorMsg;
                        string message = "alert('" + ErrorMsg + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;
                    }
                }
                else
                {
                    //tab1.Focus();
                    Failure.Visible = true;
                    lblmsg0.Text = "Please Fill Basic Details";
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }
        public string Step2validations()
        {
            try
            {
                int slno = 0; string errormsg = "";
                if (grdRevenueProj.Rows.Count > 0)
                {
                    for (int j = 0; j < grdRevenueProj.Rows.Count; j++)
                    {
                        Label lblIBPID = grdRevenueProj.Rows[j].FindControl("lblMRPID") as Label;
                        Label lblItem = grdRevenueProj.Rows[j].FindControl("lblItemName") as Label;

                        TextBox txtYear1 = grdRevenueProj.Rows[j].FindControl("txtYear1") as TextBox;
                        TextBox txtYear2 = grdRevenueProj.Rows[j].FindControl("txtYear2") as TextBox;
                        TextBox txtYear3 = grdRevenueProj.Rows[j].FindControl("txtYear3") as TextBox;
                        TextBox txtYear4 = grdRevenueProj.Rows[j].FindControl("txtYear4") as TextBox;
                        TextBox txtYear5 = grdRevenueProj.Rows[j].FindControl("txtYear5") as TextBox;

                        if (string.IsNullOrEmpty(txtYear1.Text) || txtYear1.Text == "" || txtYear1.Text == null)
                        {
                            errormsg = errormsg + lblIBPID.Text + ".Please Enter all details of " + lblItem.Text + "\\n";
                            slno = slno + 1;
                        }

                    }
                }

                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAddPromtr_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtApplFrstName.Text) || string.IsNullOrEmpty(txtApplLstName.Text) ||
                    string.IsNullOrEmpty(txtApplAadhar.Text) || string.IsNullOrEmpty(txtApplPAN.Text) ||
                    string.IsNullOrEmpty(txtApplDIN.Text) || string.IsNullOrEmpty(txtApplNationality.Text) ||
                    string.IsNullOrEmpty(txtApplDoorNo.Text) || string.IsNullOrEmpty(txtApplStreet.Text) ||
                    string.IsNullOrEmpty(txtApplEmail.Text) || string.IsNullOrEmpty(txtApplMobile.Text)
                    // (ddlApplCountry.SelectedItem.Text == "--Select--") || (ddlApplState.SelectedItem.Text == "--Select--") ||
                    // (ddlApplDist.SelectedItem.Text == "--Select--") || (ddlApplTaluka.SelectedItem.Text == "--Select--") ||
                    // (ddlApplVillage.SelectedItem.Text == "--Select--")
                    )
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {

                    DataTable dt = new DataTable();
                    dt.Columns.Add("IDD_DIRECTOR_NO", typeof(string));
                    dt.Columns.Add("IDD_UNITID", typeof(string));
                    dt.Columns.Add("IDD_INVESTERID", typeof(string));
                    dt.Columns.Add("IDD_FIRSTNAME", typeof(string));
                    dt.Columns.Add("IDD_LASTNAME", typeof(string));
                    dt.Columns.Add("IDD_ADNO", typeof(string));
                    dt.Columns.Add("IDD_PAN", typeof(string));
                    dt.Columns.Add("IDD_DINNO", typeof(string));
                    dt.Columns.Add("IDD_NATIONALITY", typeof(string));
                    dt.Columns.Add("IDD_DOORNO", typeof(string));
                    dt.Columns.Add("IDD_STREET", typeof(string));
                    dt.Columns.Add("IDD_CITY", typeof(string));
                    dt.Columns.Add("IDD_DISTRICT", typeof(string));
                    dt.Columns.Add("IDD_MANDAL", typeof(string));
                    dt.Columns.Add("IDD_STATE", typeof(string));
                    dt.Columns.Add("IDD_COUNTRY", typeof(string));
                    dt.Columns.Add("IDD_PINCODE", typeof(string));
                    dt.Columns.Add("IDD_EMAIL", typeof(string));
                    dt.Columns.Add("IDD_PHONE", typeof(string));
                    dt.Columns.Add("IDD_CITYName", typeof(string));
                    dt.Columns.Add("IDD_MANDALName", typeof(string));
                    dt.Columns.Add("IDD_DISTRICTName", typeof(string));
                    dt.Columns.Add("IDD_STATEName", typeof(string));
                    dt.Columns.Add("IDD_COUNTRYName", typeof(string));


                    if (ViewState["PromtrsTable"] != null)
                    {
                        dt = (DataTable)ViewState["PromtrsTable"];
                    }
                    DataRow dr = dt.NewRow();
                    dr["IDD_DIRECTOR_NO"] = "1";
                    dr["IDD_UNITID"] = Convert.ToString(ViewState["UnitID"]);
                    dr["IDD_INVESTERID"] = hdnUserID.Value;
                    dr["IDD_FIRSTNAME"] = txtApplFrstName.Text;
                    dr["IDD_LASTNAME"] = txtApplLstName.Text;
                    dr["IDD_ADNO"] = txtApplAadhar.Text;
                    dr["IDD_PAN"] = txtApplPAN.Text;
                    dr["IDD_DINNO"] = txtApplDIN.Text;
                    dr["IDD_NATIONALITY"] = txtApplNationality.Text;
                    dr["IDD_DOORNO"] = txtApplDoorNo.Text;
                    dr["IDD_STREET"] = txtApplStreet.Text;
                    dr["IDD_CITY"] = ddlApplVillage.SelectedValue;
                    dr["IDD_DISTRICT"] = ddlApplDist.SelectedValue;
                    dr["IDD_MANDAL"] = ddlApplTaluka.SelectedValue;
                    dr["IDD_STATE"] = ddlApplState.SelectedValue;
                    dr["IDD_COUNTRY"] = ddlApplCountry.SelectedValue;
                    dr["IDD_PINCODE"] = txtApplPincode.Text;
                    dr["IDD_EMAIL"] = txtApplEmail.Text;
                    dr["IDD_PHONE"] = txtApplMobile.Text;
                    dr["IDD_CITYName"] = ddlApplVillage.SelectedItem.Text;
                    dr["IDD_DISTRICTName"] = ddlApplDist.SelectedItem.Text;
                    dr["IDD_MANDALName"] = ddlApplTaluka.SelectedItem.Text;
                    dr["IDD_STATEName"] = ddlApplState.SelectedItem.Text;
                    dr["IDD_COUNTRYName"] = ddlApplCountry.SelectedItem.Text;

                    dt.Rows.Add(dr);
                    gvPromoters.Visible = true;
                    gvPromoters.DataSource = dt;
                    gvPromoters.DataBind();
                    ViewState["PromtrsTable"] = dt;
                }
            }
            catch (Exception ex) { }

        }

        protected void gvPromoters_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (Convert.ToString(ViewState["UnitID"]) != "")
                {
                    if (gvPromoters.Rows.Count > 0)
                    {
                        ((DataTable)ViewState["PromtrsTable"]).Rows.RemoveAt(e.RowIndex);
                        this.gvPromoters.DataSource = ((DataTable)ViewState["PromtrsTable"]).DefaultView;
                        this.gvPromoters.DataBind();
                        gvPromoters.Visible = true;
                        gvPromoters.Focus();

                    }
                }
                else
                {
                    //tab1.Focus();
                    Failure.Visible = true;
                    lblmsg0.Text = "Please Fill Basic Details";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void ddlApplCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlApplCountry.SelectedValue != "78")
                {
                    txtApplState.Visible = true;
                    txtApplDist.Visible = true;
                    txtApplTaluka.Visible = true;
                    txtApplVillage.Visible = true;

                    ddlApplState.Visible = false;
                    ddlApplDist.Visible = false;
                    ddlApplTaluka.Visible = false;
                    ddlApplVillage.Visible = false;
                }
                else if (ddlApplCountry.SelectedValue == "78")
                {
                    ddlApplState.Visible = true;
                    ddlApplDist.Visible = true;
                    ddlApplTaluka.Visible = true;
                    ddlApplVillage.Visible = true;

                    txtApplState.Visible = false;
                    txtApplDist.Visible = false;
                    txtApplTaluka.Visible = false;
                    txtApplVillage.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlApplState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlApplState.SelectedValue != "23")
                {
                    txtApplDist.Visible = true;
                    txtApplTaluka.Visible = true;
                    txtApplVillage.Visible = true;

                    ddlApplDist.Visible = false;
                    ddlApplTaluka.Visible = false;
                    ddlApplVillage.Visible = false;
                }
                else if (ddlApplState.SelectedValue == "23")
                {
                    ddlApplDist.Visible = true;
                    ddlApplTaluka.Visible = true;
                    ddlApplVillage.Visible = true;

                    txtApplDist.Visible = false;
                    txtApplTaluka.Visible = false;
                    txtApplVillage.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnSave3_Click(object sender, EventArgs e)
        {

            try
            {
                //ViewState["UnitID"] = 1002;
                string result = "";
                if (gvPromoters.Rows.Count > 0)
                {
                    DataTable dt = (DataTable)ViewState["PromtrsTable"];
                    dt.Columns.Remove("IDD_COUNTRYName");
                    result = indstregBAL.InsertIndPromotersDetails(dt);
                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "Application Submitted Successfully";
                        string message = "alert('" + "Application Submitted Successfully" + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Step3validations()
        {
            try
            {

                string erromsg = "";

                return erromsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnNext1_Click(object sender, EventArgs e)
        {
            MVprereg.ActiveViewIndex = 1;
        }

        protected void btnNext2_Click(object sender, EventArgs e)
        {
            MVprereg.ActiveViewIndex = 2;

        }

        protected void btnPreviuos2_Click(object sender, EventArgs e)
        {
            MVprereg.ActiveViewIndex = 0;

        }

        protected void btnPreviuos3_Click(object sender, EventArgs e)
        {
            MVprereg.ActiveViewIndex = 1;
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
        public void BindRegistrationType()
        {
            try
            {
                ddlRegType.Items.Clear();
                List<MasterRegistrationType> objRegistrationTypeModel = new List<MasterRegistrationType>();
                objRegistrationTypeModel = mstrBAL.GetRegistrationType();
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
                throw ex;
            }


        }

        protected void ddlRegType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(ddlRegType.SelectedItem.Text.Trim() != "--Select--")
                {
                    lblregntype.InnerText = ddlRegType.SelectedItem.Text.Trim()+ " No *";
                }
                
            }
            catch(Exception ex)
            { }
        }

        protected void Link1_Click(object sender, EventArgs e)
        {
            MVprereg.ActiveViewIndex = 0;
            var cls = Link1.Attributes["class"];
            Link1.Attributes.Add("class", cls + " nav-tab");

        }

        protected void Link2_Click(object sender, EventArgs e)
        {
            MVprereg.ActiveViewIndex = 1;

        }

        protected void Link3_Click(object sender, EventArgs e)
        {
            MVprereg.ActiveViewIndex = 2;
        }
    }
}