﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.BAL;
using MeghalayaUIP.BAL.CFEBLL;
using System.Drawing;
using MeghalayaUIP.CommonClass;

namespace MeghalayaUIP.User.CFE
{
    public partial class CFEQuestionnaire : System.Web.UI.Page
    {
        string UnitID, ErrorMsg = "", ErrorMsg1 = "", ErrorMsg2 = "";
        int index; Decimal TotalFee = 0;
        MasterBAL mstrBAL = new MasterBAL();
        CFEBAL objcfebal = new CFEBAL();

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
                    if (Convert.ToString(Session["CFEUNITID"]) != "")
                    { UnitID = Convert.ToString(Session["CFEUNITID"]); }
                    else
                    {
                        string newurl = "~/User/CFE/CFEUserDashboard.aspx";
                        Response.Redirect(newurl);
                    }
                    Page.MaintainScrollPositionOnPostBack = true;
                    if (!IsPostBack)
                    {
                        MVQues.ActiveViewIndex = index;
                        BindSectors();
                        BindDistricts();
                        BindConstitutionType();
                        BindIndustryType();
                        BindPowerReq();
                        GetElectricRegulations();
                        GetVoltageMaster();
                        GetPowerPlants();
                        GetMunicipalAreas();
                        BindData();
                    }
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void MVQues_ActiveViewChanged(object sender, EventArgs e)
        {
            index = MVQues.ActiveViewIndex;
            if (index == 0)
            { Link1.CssClass = "Underlined1"; }
            if (index == 1)
            { Link2.CssClass = "Underlined2"; }
            if (index == 2)
            { Link3.CssClass = "Underlined3"; }
        }
        public void BindData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfebal.RetrieveQuestionnaireDetails(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    hdnPreRegUID.Value = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_PREREGUIDNO"]);
                    txtUnitName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_COMPANYNAME"]);
                    rblProposal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_PROPOSALFOR"]);
                    ddlCompanyType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_COMPANYTYPE"]);
                    ddlDistrict.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_PROPDISTRICTID"]);
                    ddlDistrict_SelectedIndexChanged(null, EventArgs.Empty);
                    ddlMandal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_PROPMANDALID"]);
                    ddlMandal_SelectedIndexChanged(null, EventArgs.Empty);
                    ddlVillage.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_PROPVILLAGEID"]);
                    ddlVillage_SelectedIndexChanged(null, EventArgs.Empty);

                    txtLandArea.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_TOTALEXTENTLAND"]);

                    txtBuiltArea.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_BUILTUPAREA"]);
                    ddlSector.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_SECTOR"]);
                    ddlSector_SelectedIndexChanged(null, EventArgs.Empty);
                    ddlLine_Activity.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_LOAID"]);
                    ddlLine_Activity_SelectedIndexChanged(null, EventArgs.Empty);
                    lblPCBCategory.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_PCBCATEGORY"]);

                    if (Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_INDUSTRYTYPE"]) == "Manufacturing")
                        ddlIndustryType.SelectedValue = "1";
                    else
                        ddlIndustryType.SelectedValue = "2";
                    ddlIndustryType.Enabled = false;
                    txtUnitLocation.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_UNTLOCATION"]);
                    rblMIDCL.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_MIDCLLAND"]);

                    txtPropEmp.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_PROPEMP"]);

                    txtLandValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_LANDVALUE"]);
                    txtBuildingValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_BUILDINGVALUE"]);
                    txtPMCost.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_PMCOST"]);
                    txtAnnualTurnOver.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_EXPECTEDTURNOVER"]);
                    lblTotProjCost.Text = Convert.ToString(Convert.ToDecimal(txtLandValue.Text) + Convert.ToDecimal(txtBuildingValue.Text) + Convert.ToDecimal(txtPMCost.Text));
                    lblEntCategory.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_ENTERPRISETYPE"]);

                    ddlPowerReq.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_POWERREQKW"]);
                    rblGenerator.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_GENREQ"]);
                    txtBuildingHeight.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_BUILDINGHT"]);
                    // rblRSDSstore.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_STORINGRSDS"]);
                    rblexplosives.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_MANFEXPLOSIVES"]);
                    rblPetrlManf.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_MANFPETROL"]);
                    rblRoadCutting.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_RDCTNGREQ"]);
                    rblNonEncCert.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_NONENCMCERTREQ"]);
                    rblCommericalTax.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_COMMTAXREQ"]);
                    rblHighTension.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_USINGHTMETER"]);
                    rblHighTension_SelectedIndexChanged(null, EventArgs.Empty);
                    ddlRegulation.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_CEIGREGULATION"]);
                    ddlRegulation_SelectedIndexChanged(null, EventArgs.Empty);
                    ddlPowerPlant.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_POWERPLANT"]);
                    txtAggrCapacity.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_AGGRCAPACITY"]);
                    ddlVoltage.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_VOLTAGERATING"]);
                    rblfrstDistncLtr.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_FORSTDISTLTRREQ"]);
                    rblNonForstLandCert.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_NONFORSTLANDCERTREQ"]);
                    rblFelltrees.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_TREESFELLING"]);
                    txtNoofTrees.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_NOOFTREES"]);
                    //rblFelltrees_SelectedIndexChanged(null, EventArgs.Empty);
                    // rblwaterbody.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_WATERBODYVICINITY"]);
                    // rblborewell.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_BOREWELLEXISTS"]);

                    rblNocGroundWater.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_NOCGROUNDWATER"]);
                    rblwatersupply.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_NONAVAILABILITYCERT"]);
                    rblRiverTanks.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_PERRIVERPUBLICTANKERS"]);

                    if (ddlVillage.SelectedValue == "277282")
                    {
                        ddldivision.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_PROPSUBVILLAGE"]);
                        rblMunicipal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_MUNICIPALAREAWATERCON"]);

                        if (rblMunicipal.SelectedValue == "Y")
                        {
                            MunicipalArea.Visible = true;
                            ddlMunicipal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_WATERMUNICIPALAREA"]);
                        }
                        else { MunicipalArea.Visible = false; }

                    }
                    else
                    {
                        rblGrantwater.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_WATERCONNONMUNICIPALURBAN"]);
                        divsubVillage.Visible = false;
                    }


                    //rblDrawing.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_DRAWINGPLANAPPROVAL"]);


                    //CFEQD_BOREWELLREQ CFEQD_BOREWELLKLD   CFEQD_RIVERSnCANALS CFEQD_RIVERSnCANALSKLD

                    rblLbrAct1970.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_LABOURACT1970"]);
                    rblLbrAct1970_SelectedIndexChanged(null, EventArgs.Empty);
                    txt1970Workers.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_NOOFWORKERS1970"]);
                    rblLbrAct1979.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_LABOURACT1979"]);
                    rblLbrAct1979_SelectedIndexChanged(null, EventArgs.Empty);
                    txt1979Workers.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_NOOFWORKERS1979"]);
                    rblLbrAct1996.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_LABOURACT1996"]);
                    rblLbrAct1996_SelectedIndexChanged(null, EventArgs.Empty);
                    rblbuildingwork.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_BUILDINGWORKS1996"]);
                    rblbuildingwork_SelectedIndexChanged(null, EventArgs.Empty);
                    txt1996Workers.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_NOOFWORKERS1996"]);
                    rblLabourAct.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_CONTRLABOURACT"]);
                    rblLabourAct_SelectedIndexChanged(null, EventArgs.Empty);
                    txtContractWorkers.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_NOOFWORKERSCONTR"]);
                    rblForContr1970.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_CONTRLABOURACT1970"]);
                    rblForContr1970_SelectedIndexChanged(null, EventArgs.Empty);
                    txtContr1970wrkrs.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_NOOFWORKERSCONTR1970"]);

                    GetApprovals();
                }
                else
                {
                    ds.Clear();
                    ds = objcfebal.GetIndustryRegDetails(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //hdnPreRegUNITID.Value = Convert.ToString(ds.Tables[0].Rows[0]["UNITID"]);
                        hdnPreRegUID.Value = Convert.ToString(ds.Tables[0].Rows[0]["PREREGUIDNO"]);

                        txtUnitName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]);
                        rblProposal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["COMPANYPRAPOSAL"]);
                        ddlCompanyType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["COMPANYTYPE"]);
                        ddlDistrict.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["REP_DISTRICTID"]);
                        ddlDistrict_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlMandal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["REP_MANDALID"]);
                        ddlMandal_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlVillage.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["REP_VILLAGEID"]);
                        txtLandArea.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_LANDAREA"]);

                        txtBuiltArea.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_BUILDINGAREA"]);
                        ddlSector.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_SECTORNAME"]);
                        ddlSector_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlLine_Activity.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_LOAID"]);
                        ddlLine_Activity_SelectedIndexChanged(null, EventArgs.Empty);
                        lblPCBCategory.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_PCBCATEGORY"]);
                        if (Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_NOA"]) == "Manufacturing")
                            ddlIndustryType.SelectedValue = "1";
                        else
                            ddlIndustryType.SelectedValue = "2";

                        //   ddlSector.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_SECTORNAME"]);
                        // ddlSector_SelectedIndexChanged(null, EventArgs.Empty);
                        //txtPropEmp.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtLandValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_LANDVALUE"]);
                        txtBuildingValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_BUILDINGVALUE"]);
                        txtPMCost.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_PMCOST"]);
                        lblTotProjCost.Text = Convert.ToString(Convert.ToDecimal(txtLandValue.Text) + Convert.ToDecimal(txtBuildingValue.Text) + Convert.ToDecimal(txtPMCost.Text));
                        //lblEntCategory.Text = "MEGA PROJECT";
                    }
                }

            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindIndustryType()
        {
            try
            {
                ddlIndustryType.Items.Clear();

                List<MasterIndustryType> objIndtype = new List<MasterIndustryType>();

                objIndtype = mstrBAL.GetIndustryTypeMaster();
                if (objIndtype != null)
                {
                    ddlIndustryType.DataSource = objIndtype;
                    ddlIndustryType.DataValueField = "IndustryTypeID";
                    ddlIndustryType.DataTextField = "IndustryType";
                    ddlIndustryType.DataBind();
                }
                else
                {
                    ddlIndustryType.DataSource = null;
                    ddlIndustryType.DataBind();
                }
                AddSelect(ddlIndustryType);
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
                    ddlLine_Activity.DataSource = objLOA;
                    ddlLine_Activity.DataValueField = "LOAId";
                    ddlLine_Activity.DataTextField = "LOAName";
                    ddlLine_Activity.DataBind();
                }
                else
                {

                    ddlLine_Activity.DataSource = null;
                    ddlLine_Activity.DataBind();
                }

                AddSelect(ddlLine_Activity);
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
        protected void BindSubVillages(DropDownList ddlsubvlg, string VillageId)
        {
            try
            {
                List<MasterSubVillages> objSubVillage = new List<MasterSubVillages>();
                string strmode = string.Empty;

                objSubVillage = mstrBAL.GetSubVillages(VillageId);

                if (objSubVillage != null)
                {
                    ddlsubvlg.DataSource = objSubVillage;
                    ddlsubvlg.DataValueField = "SubVillageId";
                    ddlsubvlg.DataTextField = "SubVillageName";
                    ddlsubvlg.DataBind();
                }
                else
                {
                    ddlsubvlg.DataSource = null;
                    ddlsubvlg.DataBind();
                }
                AddSelect(ddlsubvlg);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindPowerReq()
        {
            try
            {
                ddlPowerReq.Items.Clear();

                List<MasterPowerReq> objPowerRange = new List<MasterPowerReq>();

                objPowerRange = mstrBAL.GetPowerKW();
                if (objPowerRange != null)
                {
                    ddlPowerReq.DataSource = objPowerRange;
                    ddlPowerReq.DataValueField = "PowerReqID";
                    ddlPowerReq.DataTextField = "PowerReqRange";
                    ddlPowerReq.DataBind();
                }
                else
                {
                    ddlPowerReq.DataSource = null;
                    ddlPowerReq.DataBind();
                }
                AddSelect(ddlPowerReq);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void GetElectricRegulations()
        {
            try
            {
                ddlRegulation.Items.Clear();

                List<MasterElecRegulations> objElReg = new List<MasterElecRegulations>();

                objElReg = mstrBAL.GetElectricRegulations();
                if (objElReg != null)
                {
                    ddlRegulation.DataSource = objElReg;
                    ddlRegulation.DataValueField = "ElRegID";
                    ddlRegulation.DataTextField = "ElRegNumber";
                    ddlRegulation.DataBind();
                }
                else
                {
                    ddlRegulation.DataSource = null;
                    ddlRegulation.DataBind();
                }
                AddSelect(ddlRegulation);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void GetVoltageMaster()
        {
            try
            {
                ddlVoltage.Items.Clear();

                List<MasterVoltages> objVolt = new List<MasterVoltages>();

                objVolt = mstrBAL.GetVoltages();
                if (objVolt != null)
                {
                    ddlVoltage.DataSource = objVolt;
                    ddlVoltage.DataValueField = "VoltageID";
                    ddlVoltage.DataTextField = "VoltageValue";
                    ddlVoltage.DataBind();
                }
                else
                {
                    ddlVoltage.DataSource = null;
                    ddlVoltage.DataBind();
                }
                AddSelect(ddlVoltage);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void GetPowerPlants()
        {
            try
            {
                ddlPowerPlant.Items.Clear();

                List<MasterPowerPlants> objplants = new List<MasterPowerPlants>();

                objplants = mstrBAL.GetPowerPlantsMaster();
                if (objplants != null)
                {
                    ddlPowerPlant.DataSource = objplants;
                    ddlPowerPlant.DataValueField = "PowerPlantID";
                    ddlPowerPlant.DataTextField = "PowerPlantName";
                    ddlPowerPlant.DataBind();
                }
                else
                {
                    ddlPowerPlant.DataSource = null;
                    ddlPowerPlant.DataBind();
                }
                AddSelect(ddlPowerPlant);
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
        protected void ddlSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlSector.SelectedValue.ToString() != "--Select--")
                {
                    ddlLine_Activity.Items.Clear();
                    AddSelect(ddlLine_Activity);
                    lblPCBCategory.Text = "";
                    BindLineOfActivity(ddlSector.SelectedItem.Text);

                }
            }
            catch (Exception ex)
            {

                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void ddlLine_Activity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlLine_Activity.SelectedItem.Text != "--Select--")
                {
                    lblPCBCategory.Text = mstrBAL.GetPCBCategory(ddlLine_Activity.SelectedValue);

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
        protected void rblFelltrees_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblFelltrees.SelectedIndex != -1)
                {
                    if (rblFelltrees.SelectedValue == "Y")
                        divtrees.Visible = true;
                    else
                    {
                        divtrees.Visible = false;
                        txtNoofTrees.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblFelltrees.BorderColor = System.Drawing.Color.White;
        }

        protected void rblHighTension_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblHighTension.SelectedIndex != -1)
                {
                    if (rblHighTension.SelectedValue == "Y")
                        divHTMeter.Visible = true;
                    else
                    {
                        divHTMeter.Visible = false;
                        ddlRegulation.ClearSelection();
                        ddlRegulation_SelectedIndexChanged(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblHighTension.BorderColor = System.Drawing.Color.White;
        }

        protected void ddlRegulation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlRegulation.SelectedValue == "1") //32
                {
                    divpowerplants1.Visible = true;
                    divpowerplants2.Visible = true;
                    divvoltages.Visible = false;
                }
                else if (ddlRegulation.SelectedValue == "2") //43(3)
                {
                    divpowerplants1.Visible = false;
                    ddlPowerPlant.ClearSelection();
                    txtAggrCapacity.Text = "";
                    divpowerplants2.Visible = false;
                    divvoltages.Visible = true;
                }
                else
                {
                    divvoltages.Visible = false;
                    divpowerplants1.Visible = false;
                    ddlPowerPlant.ClearSelection();
                    txtAggrCapacity.Text = "";
                    divpowerplants2.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void rblLbrAct1970_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblLbrAct1970.SelectedValue == "Y")
                {
                    trworkers1970.Visible = true;
                }
                else
                {
                    trworkers1970.Visible = false;
                    txt1970Workers.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblLbrAct1970.BorderColor = System.Drawing.Color.White;
        }

        protected void rblLbrAct1979_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblLbrAct1979.SelectedValue == "Y")
                {
                    trworkers1979.Visible = true;
                }
                else
                {
                    trworkers1979.Visible = false;
                    txt1979Workers.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblLbrAct1979.BorderColor = System.Drawing.Color.White;
        }

        protected void rblLbrAct1996_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblLbrAct1996.SelectedValue == "Y")
                {
                    tr1workers1996.Visible = true;
                }
                else
                {
                    tr1workers1996.Visible = false;
                    rblbuildingwork.ClearSelection();
                    rblbuildingwork_SelectedIndexChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblLbrAct1996.BorderColor = System.Drawing.Color.White;

        }

        protected void rblbuildingwork_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblbuildingwork.SelectedValue == "Y")
                {
                    tr2workers1996.Visible = true;
                }
                else
                {
                    tr2workers1996.Visible = false;
                    txt1996Workers.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblbuildingwork.BorderColor = System.Drawing.Color.White;
        }

        protected void rblLabourAct_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (rblLabourAct.SelectedValue == "Y")
                {
                    trContrctworkers.Visible = true;
                }
                else
                {
                    trContrctworkers.Visible = false;
                    txtContractWorkers.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblLabourAct.BorderColor = System.Drawing.Color.White;

        }
        protected void rblForContr1970_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblForContr1970.SelectedValue == "Y")
                {
                    trcontrworkers1970.Visible = true;
                }
                else
                {
                    trcontrworkers1970.Visible = false;
                    txtContr1970wrkrs.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblForContr1970.BorderColor = System.Drawing.Color.White;
        }
        protected void btnsave1_Click(object sender, EventArgs e)
        {

        }

        protected void btnNext1_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg1 = Validations1();
                if (ErrorMsg1 == "")
                {
                    Link2.Enabled = true;
                    MVQues.ActiveViewIndex = 1;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "disablePaste", "disablePasteForAll();", true);
                }
                else
                {
                    Failure.Visible = false;
                    lblmsg0.Text = ErrorMsg1;
                    string message = "alert('" + ErrorMsg1 + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
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
        protected void btnPreviuos2_Click(object sender, EventArgs e)
        {
            MVQues.ActiveViewIndex = 0;
        }
        protected void btnsave2_Click(object sender, EventArgs e)
        {

        }

        protected void btnNext2_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg2 = Validations2();
                if (ErrorMsg2 == "")
                {
                    Link3.Enabled = true;
                    MVQues.ActiveViewIndex = 2;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "disablePaste", "disablePasteForAll();", true);
                }
                else
                {
                    Failure.Visible = false;
                    lblmsg0.Text = ErrorMsg2;
                    string message = "alert('" + ErrorMsg2 + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

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

        protected void btnSave3_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                ErrorMsg = Validations();
                if (ErrorMsg == "")
                {
                    btnApprvlsReq_Click(sender, e);
                    CFEQuestionnaireDet objCFEQsnaire = new CFEQuestionnaireDet();

                    if (Convert.ToString(Session["CFEQID"]) == "")
                        objCFEQsnaire.CFEQDID = "";
                    else
                        objCFEQsnaire.CFEQDID = Convert.ToString(Session["CFEQID"]);

                    objCFEQsnaire.UNITID = Convert.ToString(Session["CFEUNITID"]);
                    objCFEQsnaire.PREREGUIDNO = hdnPreRegUID.Value;
                    objCFEQsnaire.IPAddress = getclientIP();
                    objCFEQsnaire.CompanyName = txtUnitName.Text.Trim();
                    objCFEQsnaire.CompanyType = ddlCompanyType.SelectedValue;
                    objCFEQsnaire.ProposalFor = rblProposal.SelectedValue.Trim();
                    objCFEQsnaire.LandFromMIDCL = rblMIDCL.SelectedValue;
                    objCFEQsnaire.PropLocDitrictID = ddlDistrict.SelectedValue;
                    objCFEQsnaire.PropLocMandalID = ddlMandal.SelectedValue;
                    objCFEQsnaire.PropLocVillageID = ddlVillage.SelectedValue;
                    objCFEQsnaire.ExtentofLand = txtLandArea.Text.Trim();

                    objCFEQsnaire.BuiltUpArea = txtBuiltArea.Text.Trim();
                    objCFEQsnaire.SectorName = ddlSector.SelectedItem.Text;
                    objCFEQsnaire.Lineofacitivityid = ddlLine_Activity.SelectedValue;
                    objCFEQsnaire.PCBCategory = lblPCBCategory.Text.Trim();
                    objCFEQsnaire.NatureofActivity = ddlIndustryType.SelectedValue;
                    objCFEQsnaire.UnitLocation = txtUnitLocation.Text.Trim();
                    objCFEQsnaire.PropEmployment = txtPropEmp.Text.Trim();
                    objCFEQsnaire.LandValue = txtLandValue.Text.Trim();
                    objCFEQsnaire.BuildingValue = txtBuildingValue.Text.Trim();
                    objCFEQsnaire.PlantnMachineryCost = txtPMCost.Text.Trim();
                    objCFEQsnaire.ExpectedTurnover = txtAnnualTurnOver.Text.Trim();
                    objCFEQsnaire.TotalProjCost = lblTotProjCost.Text.Trim();
                    objCFEQsnaire.EnterpriseCategory = lblEntCategory.Text.Trim();
                    objCFEQsnaire.PowerReqKW = ddlPowerReq.SelectedValue;
                    objCFEQsnaire.GeneratorReq = rblGenerator.SelectedValue;
                    objCFEQsnaire.BuildingHeight = txtBuildingHeight.Text.Trim();
                    objCFEQsnaire.StoringRSDS = rblRSDSstore.SelectedValue;
                    objCFEQsnaire.ManfExplosives = rblexplosives.SelectedValue;
                    objCFEQsnaire.ManfPetroleum = rblPetrlManf.SelectedValue;
                    objCFEQsnaire.RdCtngPermission = rblRoadCutting.SelectedValue;
                    objCFEQsnaire.NonEncmbrnceCert = rblNonEncCert.SelectedValue;
                    objCFEQsnaire.CommTaxApproval = rblCommericalTax.SelectedValue;
                    objCFEQsnaire.HTMeteruse = rblHighTension.SelectedValue;
                    objCFEQsnaire.CEARegulationID = ddlRegulation.SelectedValue;
                    objCFEQsnaire.PowerPlantID = ddlPowerPlant.SelectedValue;
                    objCFEQsnaire.AggCapacity = txtAggrCapacity.Text.Trim();
                    objCFEQsnaire.VoltageRating = ddlVoltage.SelectedValue;
                    objCFEQsnaire.TreesFelling = rblfrstDistncLtr.SelectedValue;
                    objCFEQsnaire.NoofTrees = txtNoofTrees.Text.Trim();
                    objCFEQsnaire.NonForstLandCert = rblNonForstLandCert.SelectedValue;
                    objCFEQsnaire.ForstDistLetr = rblFelltrees.SelectedValue;
                    objCFEQsnaire.NearWaterBodyLocation = rblwaterbody.SelectedValue;
                    objCFEQsnaire.ExistingBoreWell = rblborewell.SelectedValue;
                    objCFEQsnaire.LabourAct1970 = rblLbrAct1970.SelectedValue;
                    objCFEQsnaire.LabourAct1970_Workers = txt1970Workers.Text.Trim();
                    objCFEQsnaire.LabourAct1979 = rblLbrAct1979.SelectedValue;
                    objCFEQsnaire.LabourAct1979_Workers = txt1979Workers.Text.Trim();
                    objCFEQsnaire.LabourAct1996 = rblLbrAct1996.SelectedValue;
                    objCFEQsnaire.LabourAct1996_10Workers = rblbuildingwork.SelectedValue;
                    objCFEQsnaire.LabourAct1996_Workers = txt1996Workers.Text.Trim();
                    objCFEQsnaire.ContractLabourAct = rblLabourAct.SelectedValue;
                    objCFEQsnaire.ContractLabourAct_Workers = txtContractWorkers.Text.Trim();
                    objCFEQsnaire.ContractLabourAct1970 = rblForContr1970.SelectedValue;
                    objCFEQsnaire.ContractLabourAct1970_Workers = txtContr1970wrkrs.Text.Trim();
                    objCFEQsnaire.CreatedBy = hdnUserID.Value;

                    objCFEQsnaire.GrandWaterConnection = rblNocGroundWater.SelectedValue;
                    objCFEQsnaire.WaterSupplyAgency = rblwatersupply.SelectedValue;
                    objCFEQsnaire.RiverPublicTanker = rblRiverTanks.SelectedValue;
                    objCFEQsnaire.MuncipalAreawater = rblMunicipal.SelectedValue;
                    objCFEQsnaire.NonMuncipalAreaUrban = rblGrantwater.SelectedValue;
                    objCFEQsnaire.MunicipalArea = ddlMunicipal.SelectedValue;
                    objCFEQsnaire.DrawingPlan = rblDrawing.SelectedValue;
                    objCFEQsnaire.SubVillage = ddldivision.SelectedItem.Text;


                    int count = 0;
                    result = objcfebal.InsertQuestionnaireCFE(objCFEQsnaire);
                    if (result != "100")
                    {
                        CFEQuestionnaireDet objrm = new CFEQuestionnaireDet();
                        Session["CFEQID"] = result;
                        for (int i = 0; i < grdApprovals.Rows.Count; i++)
                        {
                            Label ApprovalID = grdApprovals.Rows[i].FindControl("lblApprID") as Label;
                            Label DeptID = grdApprovals.Rows[i].FindControl("lblDeptID") as Label;

                            objCFEQsnaire.CFEQDID = Convert.ToString(Session["CFEQID"]);
                            objCFEQsnaire.ApprovalID = ApprovalID.Text;
                            objCFEQsnaire.DeptID = DeptID.Text;
                            objCFEQsnaire.ApprovalFee = grdApprovals.Rows[i].Cells[3].Text;
                            objCFEQsnaire.CreatedBy = hdnUserID.Value;
                            objCFEQsnaire.IPAddress = getclientIP();
                            objCFEQsnaire.UNITID = Convert.ToString(Session["CFEUNITID"]);

                            string A = objcfebal.InsertCFEQuestionnaireApprovals(objCFEQsnaire);
                            if (A != "")
                            { count = count + 1; }
                        }
                        if (grdApprovals.Rows.Count == count)
                        {
                            objcfebal.DeleteDepartmentApprovals(objCFEQsnaire);

                            success.Visible = true;
                            lblmsg.Text = "Consent For Establishment - Questionnaire Details Submitted Successfully";
                            string message = "alert('" + lblmsg.Text + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }

                }
                else
                {
                    string message = "alert('" + ErrorMsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void btnNext3_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave3_Click(sender, e);
                if (ErrorMsg == "")
                    Response.Redirect("~/User/CFE/CFECommonApplication.aspx");
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
        public string Validations1()
        {
            try
            {

                int slno = 1;
                string errormsg = "";
                //List<TextBox> emptyTextboxes = FindEmptyTextboxes(divText);
                //List<DropDownList> emptyDropdowns = FindEmptyDropdowns(divText);
                //List<RadioButtonList> emptyRadioButtonLists = FindEmptyRadioButtonLists(divText);

                if (string.IsNullOrEmpty(txtUnitName.Text) || txtUnitName.Text == "" || txtUnitName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Company Registration /Incorporation Date \\n";
                    slno = slno + 1;
                }
                if (ddlCompanyType.SelectedIndex == -1 || ddlCompanyType.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Constitution of Unit \\n";
                    slno = slno + 1;
                }
                if (rblProposal.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Enter Proposal for \\n";
                    slno = slno + 1;
                }
                if (ddlDistrict.SelectedIndex == -1 || ddlDistrict.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Proposed Location District \\n";
                    slno = slno + 1;
                }
                if (ddlMandal.SelectedIndex == -1 || ddlMandal.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Proposed Location Mandal \\n";
                    slno = slno + 1;
                }
                if (ddlVillage.SelectedIndex == -1 || ddlVillage.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Proposed Location Village \\n";
                    slno = slno + 1;
                }
                if (ddlVillage.SelectedValue == "277282")
                {
                    if (ddldivision.SelectedIndex == -1 || ddldivision.SelectedItem.Text == "--Select--")
                    {
                        errormsg = errormsg + slno + ". Please Select Village Sub Division \\n";
                        slno = slno + 1;
                    }

                }
                if (string.IsNullOrEmpty(txtLandArea.Text) || txtLandArea.Text == "" || txtLandArea.Text == null || txtLandArea.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtLandArea.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Total Extend Land  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtBuiltArea.Text) || txtBuiltArea.Text == "" || txtBuiltArea.Text == null || txtBuiltArea.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtBuiltArea.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Built Up Area \\n";
                    slno = slno + 1;
                }
                if (ddlSector.SelectedIndex == -1 || ddlSector.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Sector \\n";
                    slno = slno + 1;
                }
                if (ddlLine_Activity.SelectedIndex == -1 || ddlLine_Activity.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Line of Activity \\n";
                    slno = slno + 1;
                }
                if (ddlIndustryType.SelectedIndex == -1 || ddlIndustryType.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Industry Type \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtUnitLocation.Text.Trim()) || txtUnitLocation.Text.Trim() == "" || txtUnitLocation.Text.Trim() == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Location Of The Unit \\n";
                    slno = slno + 1;
                }
                if (rblMIDCL.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether land purchased from MIDCL or not \\n";
                    slno = slno + 1;
                }
                return errormsg;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Validations2()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                //List<TextBox> emptyTextboxes = FindEmptyTextboxes(divText);
                //List<DropDownList> emptyDropdowns = FindEmptyDropdowns(divText);
                //List<RadioButtonList> emptyRadioButtonLists = FindEmptyRadioButtonLists(divText);

                if (string.IsNullOrEmpty(txtPropEmp.Text) || txtPropEmp.Text == "" || txtPropEmp.Text == null || txtPropEmp.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtPropEmp.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Proposed Employment \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLandValue.Text) || txtLandValue.Text == "" || txtLandValue.Text == null || txtLandValue.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtLandValue.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Value of Land as per sale Deed(In INR) \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtBuildingValue.Text) || txtBuildingValue.Text == "" || txtBuildingValue.Text == null || txtBuildingValue.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtBuildingValue.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Value of Building \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPMCost.Text) || txtPMCost.Text == "" || txtPMCost.Text == null || txtPMCost.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtPMCost.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Value of Plant & Machinery \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAnnualTurnOver.Text) || txtAnnualTurnOver.Text == "" || txtAnnualTurnOver.Text == null || txtAnnualTurnOver.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtAnnualTurnOver.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Expected Annual Turnover \\n";
                    slno = slno + 1;
                }
                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                //List<TextBox> emptyTextboxes = FindEmptyTextboxes(divText);
                //List<DropDownList> emptyDropdowns = FindEmptyDropdowns(divText);
                //List<RadioButtonList> emptyRadioButtonLists = FindEmptyRadioButtonLists(divText);

                if (ddlPowerReq.SelectedIndex == -1 || ddlPowerReq.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Power requirement \\n";
                    slno = slno + 1;
                }
                if (rblGenerator.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether Generator Required or not \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtBuildingHeight.Text) || txtBuildingHeight.Text == "" || txtBuildingHeight.Text == null || txtBuildingHeight.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtBuildingHeight.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Height of the building \\n";
                    slno = slno + 1;
                }
                //if (rblRSDSstore.SelectedIndex == -1)
                //{
                //    errormsg = errormsg + slno + ". Please Select Whether you store RS, DS or not \\n";
                //    slno = slno + 1;
                //}
                if (rblexplosives.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether you manufacture, store, sale, transport explosives \\n";
                    slno = slno + 1;
                }
                if (rblPetrlManf.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether you Manufacture, store, sale, Petroleum, Diesel, Kerosene or not \\n";
                    slno = slno + 1;
                }
                if (rblRoadCutting.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether you require Road Cutting Permission or not \\n";
                    slno = slno + 1;
                }
                if (rblNonEncCert.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether you require Non-Encumbrance Certificate or not \\n";
                    slno = slno + 1;
                }
                if (rblCommericalTax.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether you require approval from Commerical Tax or not \\n";
                    slno = slno + 1;
                }
                if (rblHighTension.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether you Use (High Tension)HT meter Above 70KVA or not \\n";
                    slno = slno + 1;
                }
                if (rblHighTension.SelectedValue == "Y")
                {
                    if (ddlRegulation.SelectedIndex == -1 || ddlRegulation.SelectedItem.Text == "--Select--")
                    {
                        errormsg = errormsg + slno + ". Please Select Regulation Type \\n";
                        slno = slno + 1;
                    }
                    if (ddlRegulation.SelectedValue == "1")
                    {
                        if (ddlPowerPlant.SelectedIndex == -1 || ddlPowerPlant.SelectedItem.Text == "--Select--")
                        {
                            errormsg = errormsg + slno + ". Please Select Power Plant Type \\n";
                            slno = slno + 1;
                        }
                        if (string.IsNullOrEmpty(txtAggrCapacity.Text) || txtAggrCapacity.Text == "" || txtAggrCapacity.Text == null || txtAggrCapacity.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtAggrCapacity.Text, @"^0+(\.0+)?$"))
                        {
                            errormsg = errormsg + slno + ". Please Enter Aggregate Capacity  \\n";
                            slno = slno + 1;
                        }
                    }
                    if (ddlRegulation.SelectedValue == "2")
                    {
                        if (ddlVoltage.SelectedIndex == -1 || ddlVoltage.SelectedItem.Text == "--Select--")
                        {
                            errormsg = errormsg + slno + ". Please Select Voltage Rating  \\n";
                            slno = slno + 1;
                        }
                    }

                }
                if (rblfrstDistncLtr.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether You require Letter for distance from Forest or not \\n";
                    slno = slno + 1;
                }
                if (rblNonForstLandCert.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether You require Non-Forest Land Certificate or not \\n";
                    slno = slno + 1;
                }
                if (rblFelltrees.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether any need to Fell trees in Proposed Site or not \\n";
                    slno = slno + 1;
                }
                //if (rblFelltrees.SelectedValue == "Y")
                //{
                //    if (string.IsNullOrEmpty(txtNoofTrees.Text) || txtNoofTrees.Text == "" || txtNoofTrees.Text == null || txtNoofTrees.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtNoofTrees.Text, @"^0+(\.0+)?$"))
                //    {
                //        errormsg = errormsg + slno + ". Please Enter Number of trees to be felled \\n";
                //        slno = slno + 1;
                //    }
                //}
                //if (rblwaterbody.SelectedIndex == -1)
                //{
                //    errormsg = errormsg + slno + ". Please Select Whether unit Location fall within 100mts vicinity of any water body or not \\n";
                //    slno = slno + 1;
                //}
                //if (rblborewell.SelectedIndex == -1)
                //{
                //    errormsg = errormsg + slno + ". Please Select Whether You have Existing borewell in proposed factory Location or not \\n";
                //    slno = slno + 1;
                //}
                if (rblNocGroundWater.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Require NoC for Ground  or not \\n";
                    slno = slno + 1;
                }
                if (rblwatersupply.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Require Certificate for non - availability of water supply from water supply agency or not \\n";
                    slno = slno + 1;
                }
                if (rblRiverTanks.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Require Permission to Draw Water from River/Public Tanks or not \\n";
                    slno = slno + 1;
                }
                if (ddlVillage.SelectedValue == "277282")
                {
                    if (rblMunicipal.SelectedIndex == -1)
                    {
                        errormsg = errormsg + slno + ". Please Select Require Water Connection for the Municipal Area or not \\n";
                        slno = slno + 1;
                    }
                    if (rblMunicipal.SelectedValue == "Y")
                    {
                        if (ddlMunicipal.SelectedValue =="0")
                        {
                            errormsg = errormsg + slno + ". Please Select Water Connection for the Municipal Area  \\n";
                            slno = slno + 1;
                        }
                    }
                }
                else
                {
                    if (rblGrantwater.SelectedIndex == -1)
                    {
                        errormsg = errormsg + slno + ". Please Select Required Grant of Water Connection to Non Municipal urban or not \\n";
                        slno = slno + 1;
                    }
                }
                //if (rblDrawing.SelectedIndex == -1)
                //{
                //    errormsg = errormsg + slno + ". Please Select Required Grant of Drawing Plan Approval or not \\n";
                //    slno = slno + 1;
                //}
                if (rblLbrAct1970.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Contract Labour(Regulation and Abolition)Act, 1970? \\n";
                    slno = slno + 1;
                }
                if (rblLbrAct1970.SelectedValue == "Y")
                {
                    if (string.IsNullOrEmpty(txt1970Workers.Text) || txt1970Workers.Text == "" || txt1970Workers.Text == null || txt1970Workers.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txt1970Workers.Text, @"^0+(\.0+)?$"))
                    {
                        errormsg = errormsg + slno + ". Please Enter No.of workers under Contract Labour(Regulation and Abolition)Act, 1970 \\n";
                        slno = slno + 1;
                    }
                }
                if (rblLbrAct1979.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Inter-state Migrant Workmen Act, 1979? \\n";
                    slno = slno + 1;
                }
                if (rblLbrAct1979.SelectedValue == "Y")
                {
                    if (string.IsNullOrEmpty(txt1979Workers.Text) || txt1979Workers.Text == "" || txt1979Workers.Text == null || txt1979Workers.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txt1979Workers.Text, @"^0+(\.0+)?$"))
                    {
                        errormsg = errormsg + slno + ". Please Enter No.of workers under Inter-state Migrant Workmen Act, 1979? \\n";
                        slno = slno + 1;
                    }
                }
                if (rblLbrAct1996.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Building and Other Constrution Worker(RE&COS) Act, 1996? \\n";
                    slno = slno + 1;
                }
                if (rblLbrAct1996.SelectedValue == "Y")
                {
                    if (rblbuildingwork.SelectedIndex == -1)
                    {
                        errormsg = errormsg + slno + ". Please Select  “Building & Other Construction Works” \\n";
                        slno = slno + 1;
                    }
                    if (rblbuildingwork.SelectedValue == "Y")
                    {
                        if (string.IsNullOrEmpty(txt1996Workers.Text) || txt1996Workers.Text == "" || txt1996Workers.Text == null || txt1996Workers.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txt1996Workers.Text, @"^0+(\.0+)?$"))
                        {
                            errormsg = errormsg + slno + ". Please Enter No.of workers Building and Other Constrution Worker(RE&COS) Act, 1996? \\n";
                            slno = slno + 1;
                        }
                    }
                }
                if (rblLabourAct.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether You require License under Contract Labour Act (For Contractor) or not \\n";
                    slno = slno + 1;
                }
                if (rblLabourAct.SelectedValue == "Y")
                {
                    if (string.IsNullOrEmpty(txtContractWorkers.Text) || txtContractWorkers.Text == "" || txtContractWorkers.Text == null || txtContractWorkers.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtContractWorkers.Text, @"^0+(\.0+)?$"))
                    {
                        errormsg = errormsg + slno + ". Please Enter No.of Workers under License under Contract Labour Act (For Contractor) \\n";
                        slno = slno + 1;
                    }
                }
                if (rblForContr1970.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select (License for Contractors) as defined in the contract labour\r\n(Regulation and Abolition) Act,1970? \\n";
                    slno = slno + 1;
                }
                if (rblForContr1970.SelectedValue == "Y")
                {
                    if (string.IsNullOrEmpty(txtContr1970wrkrs.Text) || txtContr1970wrkrs.Text == "" || txtContr1970wrkrs.Text == null || txtContr1970wrkrs.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtContr1970wrkrs.Text, @"^0+(\.0+)?$"))
                    {
                        errormsg = errormsg + slno + ". Please Enter No.of workers under License for Contractors) as defined in the contract labour\r\n(Regulation and Abolition) Act,1970? \\n";
                        slno = slno + 1;
                    }
                }
                return errormsg;


            }
            catch (Exception ex)
            {
                throw ex;
                //lblmsg0.Text = ex.Message; Failure.Visible = true;
            }
        }

        protected void btnPreviuos3_Click(object sender, EventArgs e)
        {
            MVQues.ActiveViewIndex = 1;

        }

        protected void btnShowEncl_Click(object sender, EventArgs e)
        {
            btnApprvlsReq_Click(sender, e);
        }

        protected void btnApprvlsReq_Click(object sender, EventArgs e)
        {
            try
            {
                string ErrorMsg;
                ErrorMsg = Validations();
                if (ErrorMsg == "")
                {
                    GetApprovals();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void GetApprovals()
        {
            try
            {
                CFEQuestionnaireDet objCFEQ = new CFEQuestionnaireDet();

                DataTable dtApprReq = new DataTable();
                DataTable dtPCB = new DataTable(); DataTable dtpower = new DataTable(); DataTable dtGenReq = new DataTable();
                DataTable dtfire = new DataTable(); DataTable dtFctry = new DataTable(); DataTable dtRSDS = new DataTable();

                DataTable dtExplosivs = new DataTable(); DataTable dtPtrlsale = new DataTable(); DataTable dtElectric = new DataTable();
                DataTable dtRdctng = new DataTable(); DataTable dtNonEncCert = new DataTable();

                DataTable dtCommTax = new DataTable(); DataTable dtfrstDist = new DataTable(); DataTable dtNonFrstLand = new DataTable(); DataTable dtTreeFelling = new DataTable();
                DataTable dtHitens = new DataTable(); DataTable dttreefellng = new DataTable(); DataTable dtWtrbody = new DataTable();

                DataTable dtAct1970 = new DataTable(); DataTable dtAct1979 = new DataTable(); DataTable dtAct1996 = new DataTable();
                DataTable dtContrLbrAct = new DataTable(); DataTable dtContAct1970 = new DataTable();

                DataTable dtGroundwater = new DataTable(); DataTable watersupply = new DataTable(); DataTable rivertanker = new DataTable();
                DataTable Municipal = new DataTable(); DataTable NonMunicipal = new DataTable();

                objCFEQ.EnterpriseCategory = lblEntCategory.Text;
                if (lblPCBCategory.Text.Trim() != "White")
                {
                    // decimal PMCost  = Convert.ToDecimal();
                    objCFEQ.Investment = txtPMCost.Text;
                    objCFEQ.PCBCategory = lblPCBCategory.Text;
                    objCFEQ.ApprovalID = "1";
                    dtPCB = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(dtPCB);

                }
                if (ddlPowerReq.SelectedValue != "")
                {
                    objCFEQ.PowerReqKW = ddlPowerReq.SelectedValue;
                    objCFEQ.PropEmployment = txtPropEmp.Text;
                    //objCFEQ.ApprovalID = "3";
                    //dtpower = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    //dtApprReq.Merge(dtpower);

                    objCFEQ.ApprovalID = "4";
                    dtElectric = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(dtElectric);

                    objCFEQ.ApprovalID = "5";
                    dtFctry = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(dtFctry);
                }
                if (rblGenerator.SelectedValue == "Y")
                {
                    objCFEQ.ApprovalID = "6";
                    dtGenReq = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(dtGenReq);
                }
                if (Convert.ToDecimal(txtBuildingHeight.Text) != 0 && Convert.ToDecimal(txtBuildingHeight.Text) > 14)
                {
                    objCFEQ.BuildingHeight = txtBuildingHeight.Text;
                    objCFEQ.ApprovalID = "7";
                    dtfire = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(dtfire);
                }
                if (rblHighTension.SelectedValue == "Y")
                {
                    objCFEQ.ApprovalID = "14";
                    dtHitens = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(dtHitens);
                }

                if (rblexplosives.SelectedValue == "Y")
                {
                    objCFEQ.ApprovalID = "9";
                    dtExplosivs = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(dtExplosivs);
                }
                if (rblPetrlManf.SelectedValue == "Y")
                {
                    objCFEQ.ApprovalID = "10";
                    dtPtrlsale = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(dtPtrlsale);
                }
                if (rblRoadCutting.SelectedValue == "Y")
                {
                    objCFEQ.ApprovalID = "11";
                    dtRdctng = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(dtRdctng);
                }
                if (rblNonEncCert.SelectedValue == "Y")
                {
                    objCFEQ.ApprovalID = "12";
                    dtNonEncCert = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(dtNonEncCert);
                }
                if (rblCommericalTax.SelectedValue == "Y")
                {
                    objCFEQ.ApprovalID = "13";
                    dtCommTax = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(dtCommTax);
                }

                if (rblfrstDistncLtr.SelectedValue == "Y")
                {
                    objCFEQ.ApprovalID = "15";
                    dtfrstDist = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(dtfrstDist);
                }
                if (rblNonForstLandCert.SelectedValue == "Y")
                {
                    objCFEQ.ApprovalID = "16";
                    dtNonFrstLand = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(dtNonFrstLand);
                }
                if (rblFelltrees.SelectedValue == "Y")
                {
                    objCFEQ.ApprovalID = "24";
                    dtTreeFelling = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(dtTreeFelling);
                }
                /*
               if (rblRSDSstore.SelectedValue == "Y")
               {
                   objCFEQ.ApprovalID = "8";
                   dtRSDS = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                   dtApprReq.Merge(dtRSDS);
               }
               if (rblwaterbody.SelectedValue == "Y")
               {
                   objCFEQ.ApprovalID = "17";
                   dtWtrbody = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                   dtApprReq.Merge(dtWtrbody);
                   dtWtrbody.Clear();
                   objCFEQ.ApprovalID = "18";
                   dtWtrbody = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                   dtApprReq.Merge(dtWtrbody);
               }
               if (rblDrawing.SelectedValue == "Y")
               {
                   objCFEQ.ApprovalID = "107";
                   NonMunicipal = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                   dtApprReq.Merge(NonMunicipal);
               } */



                if (rblNocGroundWater.SelectedValue == "Y")
                {
                    objCFEQ.ApprovalID = "19";
                    dtGroundwater = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(dtGroundwater);
                }
                if (rblwatersupply.SelectedValue == "Y")
                {
                    objCFEQ.ApprovalID = "20";
                    watersupply = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(watersupply);
                }
                if (rblRiverTanks.SelectedValue == "Y")//surface water abstraction
                {
                    objCFEQ.ApprovalID = "21";
                    rivertanker = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(rivertanker);
                }
                if (rblMunicipal.SelectedValue == "Y" && ddlVillage.SelectedValue == "277282")
                {
                    objCFEQ.ApprovalID = "22";
                    objCFEQ.MunicipalArea = ddlMunicipal.SelectedValue;
                    Municipal = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(Municipal);
                }
                if (rblGrantwater.SelectedValue == "Y" && ddlVillage.SelectedValue != "277282")
                {
                    objCFEQ.ApprovalID = "23";
                    NonMunicipal = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(NonMunicipal);
                }

                if (rblLbrAct1970.SelectedValue == "Y")
                {
                    objCFEQ.ApprovalID = "25";
                    objCFEQ.PropEmployment = txt1970Workers.Text;
                    dtAct1970 = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(dtAct1970);
                }
                if (rblLbrAct1979.SelectedValue == "Y")
                {
                    objCFEQ.ApprovalID = "26";
                    objCFEQ.PropEmployment = txt1979Workers.Text;
                    dtAct1979 = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(dtAct1979);
                }
                if (rblLbrAct1996.SelectedValue == "Y")
                {
                    objCFEQ.ApprovalID = "27";
                    objCFEQ.PropEmployment = txt1996Workers.Text;
                    dtAct1996 = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(dtAct1996);
                }
                if (rblLabourAct.SelectedValue == "Y")
                {
                    objCFEQ.ApprovalID = "28";
                    objCFEQ.PropEmployment = txtContractWorkers.Text;
                    dtContrLbrAct = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(dtContrLbrAct);
                }
                if (rblForContr1970.SelectedValue == "Y")
                {
                    objCFEQ.ApprovalID = "29";
                    dtContAct1970 = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(dtContAct1970);
                }

                if (dtApprReq.Rows.Count > 0)
                {
                    divApprovals.Visible = true;
                    grdApprovals.DataSource = dtApprReq;
                    grdApprovals.DataBind();
                }
                else
                {
                    grdApprovals.DataSource = null;
                    grdApprovals.DataBind();
                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void grdApprovals_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if ((e.Row.RowType == DataControlRowType.DataRow))
                {
                    decimal Fee = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fee"));
                    TotalFee = TotalFee + Fee;
                    e.Row.Cells[3].Text = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fee")).ToString();
                }
                if ((e.Row.RowType == DataControlRowType.Footer))
                {
                    e.Row.Cells[2].Text = "Total Fee";
                    e.Row.Cells[3].Text = TotalFee.ToString();
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }

        protected void Link1_Click(object sender, EventArgs e)
        {
            try
            {
                MVQues.ActiveViewIndex = 0;
                var cls = Link1.Attributes["class"];
                Link1.Attributes.Add("class", cls + " nav-tab");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }

        protected void Link2_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg1 = Validations1();
                if (ErrorMsg1 == "")
                {
                    MVQues.ActiveViewIndex = 1; Failure.Visible = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "disablePaste", "disablePasteForAll();", true);
                }
                else
                {
                    Failure.Visible = false;
                    lblmsg0.Text = ErrorMsg1;
                    string message = "alert('" + ErrorMsg1 + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }

        protected void Link3_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg2 = Validations2();
                if (ErrorMsg2 == "")
                {
                    MVQues.ActiveViewIndex = 2; Failure.Visible = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "disablePaste", "disablePasteForAll();", true);
                }
                else
                {
                    Failure.Visible = false;
                    lblmsg0.Text = ErrorMsg2;
                    string message = "alert('" + ErrorMsg2 + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }

        protected void rblMunicipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblMunicipal.SelectedValue == "Y")
            {
                MunicipalArea.Visible = true;
            }
            else
            {
                MunicipalArea.Visible = false; ddlMunicipal.ClearSelection();
            }
        }

        protected void txtAnnualTurnOver_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtAnnualTurnOver.Text != "" && txtPMCost.Text != "" && txtBuildingValue.Text != "" && txtLandValue.Text != "")
                {
                    lblTotProjCost.Text = Convert.ToString(Convert.ToDecimal(txtLandValue.Text) + Convert.ToDecimal(txtBuildingValue.Text) + Convert.ToDecimal(txtPMCost.Text));

                    string Res = objcfebal.GETANNUALTURNOVER(txtPMCost.Text.ToString(), txtAnnualTurnOver.Text.ToString());
                    if (Res != "")
                    {
                        lblEntCategory.Text = Res;
                        //txtAnnualTurnOver.Text = "";
                        //string message = "alert('" + Res + "')";
                        //ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        //return;

                    }
                    //else
                    //{
                    //    string Result = objcfebal.CFEENTERPRISETYPE(txtAnnualTurnOver.Text.ToString());
                    //    if (Result != "")
                    //    {
                    //        lblEntCategory.Text = Result;

                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void txtPMCost_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtAnnualTurnOver_TextChanged(sender, e);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }
        protected void GetMunicipalAreas()
        {
            try
            {
                ddlMunicipal.Items.Clear();

                List<MasterWATERMUNICIPAL> objMunicipal = new List<MasterWATERMUNICIPAL>();

                objMunicipal = mstrBAL.GetMunicipalareaMaster();
                if (objMunicipal != null)
                {
                    ddlMunicipal.DataSource = objMunicipal;
                    ddlMunicipal.DataValueField = "CONNECTION_TYPE_ID";
                    ddlMunicipal.DataTextField = "CONNECTION_TYPE_NAME";
                    ddlMunicipal.DataBind();
                }
                else
                {
                    ddlMunicipal.DataSource = null;
                    ddlMunicipal.DataBind();
                }
                AddSelect(ddlMunicipal);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }


        }

        protected void ddlVillage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddldivision.ClearSelection();
                ddldivision.Items.Clear();
                AddSelect(ddldivision);
                if (ddlVillage.SelectedItem.Text != "--Select--")
                {
                    if (ddlVillage.SelectedValue == "277282")
                    {
                        divsubVillage.Visible = true;
                        divMunicipalWater.Visible = true;

                        divNonMunicipalWater.Visible = false;
                        rblGrantwater.ClearSelection();
                        BindSubVillages(ddldivision, ddlVillage.SelectedValue);
                    }
                    else
                    {
                        divsubVillage.Visible = false;
                        divNonMunicipalWater.Visible = true;

                        divMunicipalWater.Visible = false;
                        rblMunicipal.ClearSelection();
                        rblMunicipal_SelectedIndexChanged(sender, e);
                    }
                }
                else
                {
                    divMunicipalWater.Visible = false; rblMunicipal_SelectedIndexChanged(sender, e);
                    divNonMunicipalWater.Visible = false;
                    divsubVillage.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public void SubVillages()
        {
            try
            {
                if (ddlVillage.SelectedValue == "277282")
                {
                    divsubVillage.Visible = true;
                }
                else { divsubVillage.Visible = false; }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
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
        protected List<DropDownList> FindEmptyDropdowns(Control container)
        {
            List<DropDownList> emptyDropdowns = new List<DropDownList>();

            foreach (Control control in container.Controls)
            {
                if (control is DropDownList)
                {
                    DropDownList dropdown = (DropDownList)control;
                    if (string.IsNullOrWhiteSpace(dropdown.SelectedValue) || dropdown.SelectedValue == "" || dropdown.SelectedItem.Text == "--Select--" || dropdown.SelectedIndex == -1)
                    {
                        emptyDropdowns.Add(dropdown);
                        dropdown.BorderColor = System.Drawing.Color.Red;
                    }
                }

                if (control.HasControls())
                {
                    emptyDropdowns.AddRange(FindEmptyDropdowns(control));
                }
            }

            return emptyDropdowns;
        }
        private List<RadioButtonList> FindEmptyRadioButtonLists(Control container)
        {
            List<RadioButtonList> emptyRadioButtonLists = new List<RadioButtonList>();

            foreach (Control control in container.Controls)
            {
                if (control is RadioButtonList radioButtonList)
                {
                    if (string.IsNullOrWhiteSpace(radioButtonList.SelectedValue) || radioButtonList.SelectedIndex == -1)
                    {
                        emptyRadioButtonLists.Add(radioButtonList);

                        //radioButtonList.BorderColor = System.Drawing.Color.Red;
                        //radioButtonList.BorderWidth = Unit.Pixel(2);
                        //radioButtonList.BorderStyle = BorderStyle.Solid;
                    }
                    else
                    {
                        radioButtonList.BorderColor = System.Drawing.Color.Empty;
                        radioButtonList.BorderWidth = Unit.Empty;
                        radioButtonList.BorderStyle = BorderStyle.NotSet;
                    }
                }

                if (control.HasControls())
                {
                    emptyRadioButtonLists.AddRange(FindEmptyRadioButtonLists(control));
                }
            }

            return emptyRadioButtonLists;
        }
    }
}