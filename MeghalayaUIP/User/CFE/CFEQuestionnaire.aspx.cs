using System;
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
        string UnitID;
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
                    txtLandArea.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_TOTALEXTENTLAND"]);

                    txtBuiltArea.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_BUILTUPAREA"]);
                    ddlSector.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_SECTOR"]);
                    ddlSector_SelectedIndexChanged(null, EventArgs.Empty);
                    ddlLine_Activity.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_LOAID"]);
                    lblPCBCategory.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_PCBCATEGORY"]);

                    if (Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_INDUSTRYTYPE"]) == "Manufacturing")
                        ddlIndustryType.SelectedValue = "1";
                    else
                        ddlIndustryType.SelectedValue = "2";
                    txtUnitLocation.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_UNTLOCATION"]);
                    rblMIDCL.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_MIDCLLAND"]);

                    txtPropEmp.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_PROPEMP"]);
                    txtLandValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_LANDVALUE"]);
                    txtBuildingValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_BUILDINGVALUE"]);
                    txtPMCost.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_PMCOST"]);
                    txtAnnualTurnOver.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_EXPECTEDTURNOVER"]);
                    lblTotProjCost.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_TOTALPROJCOST"]);
                    lblEntCategory.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_ENTERPRISETYPE"]);

                    ddlPowerReq.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_POWERREQKW"]);
                    rblGenerator.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_GENREQ"]);
                    txtBuildingHeight.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_BUILDINGHT"]);
                    rblRSDSstore.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_STORINGRSDS"]);
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
                    rblFelltrees_SelectedIndexChanged(null, EventArgs.Empty);
                    txtNoofTrees.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_NOOFTREES"]);
                    rblwaterbody.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_WATERBODYVICINITY"]);
                    rblborewell.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_BOREWELLEXISTS"]);
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

                    GetApprovals(); ;
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
                        lblPCBCategory.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_PCBCATEGORY"]);
                        ddlSector.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_SECTORNAME"]);
                        ddlSector_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlLine_Activity.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_LOAID"]);
                        if (Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_NOA"]) == "Manufacturing")
                            ddlIndustryType.SelectedValue = "1";
                        else
                            ddlIndustryType.SelectedValue = "2";

                        ddlSector.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_SECTORNAME"]);
                        ddlSector_SelectedIndexChanged(null, EventArgs.Empty);
                        //txtPropEmp.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtLandValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_LANDVALUE"]);
                        txtBuildingValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_BUILDINGVALUE"]);
                        txtPMCost.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_PMCOST"]);
                        lblTotProjCost.Text = Convert.ToString(Convert.ToDecimal(txtLandValue.Text) + Convert.ToDecimal(txtBuildingValue.Text) + Convert.ToDecimal(txtPMCost.Text));
                        lblEntCategory.Text = "MEGA PROJECT";
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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
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

                lblmsg0.Text = ex.Message; Failure.Visible = true;
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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
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

                lblmsg0.Text = ex.Message; Failure.Visible = true;
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

                lblmsg0.Text = ex.Message; Failure.Visible = true;
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
                //Failure.Visible = true;
                //lblmsg0.Text = ex.Message; Failure.Visible = true;
                lblmsg0.Text = ex.Message; Failure.Visible = true;
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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
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
                    else divtrees.Visible = false;
                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }
        }

        protected void rblHighTension_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblHighTension.SelectedIndex != -1)
                {
                    if (rblHighTension.SelectedValue == "Y")
                        divHTMeter.Visible = true;
                    else divHTMeter.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }
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
                    divpowerplants2.Visible = false;
                    divvoltages.Visible = true;
                }
                else
                {
                    divvoltages.Visible = false;
                    divpowerplants1.Visible = false;
                    divpowerplants2.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
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
                else trworkers1970.Visible = false;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }
        }

        protected void rblLbrAct1979_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblLbrAct1979.SelectedValue == "Y")
                {
                    trworkers1979.Visible = true;
                }
                else trworkers1979.Visible = false;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }

        }

        protected void rblLbrAct1996_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblLbrAct1996.SelectedValue == "Y")
                {
                    tr1workers1996.Visible = true;
                }
                else tr1workers1996.Visible = false;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }

        }

        protected void rblbuildingwork_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblbuildingwork.SelectedValue == "Y")
                {
                    tr2workers1996.Visible = true;
                }
                else tr2workers1996.Visible = false;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }

        }

        protected void rblLabourAct_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (rblLabourAct.SelectedValue == "Y")
                {
                    trContrctworkers.Visible = true;
                }
                else trContrctworkers.Visible = false;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }

        }
        protected void rblForContr1970_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblForContr1970.SelectedValue == "Y")
                {
                    trcontrworkers1970.Visible = true;
                }
                else trcontrworkers1970.Visible = false;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }

        }
        protected void btnsave1_Click(object sender, EventArgs e)
        {

        }

        protected void btnNext1_Click(object sender, EventArgs e)
        {
            MVQues.ActiveViewIndex = 1;
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
            MVQues.ActiveViewIndex = 2;

        }

        protected void btnSave3_Click(object sender, EventArgs e)
        {
            try
            {
                string ErrorMsg = "", result = "";
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
                Response.Redirect("~/User/CFE/CFECommonApplication.aspx");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
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
        public string Validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
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
                    errormsg = errormsg + slno + ". Please Select AProposed Location Mandal \\n";
                    slno = slno + 1;
                }
                if (ddlVillage.SelectedIndex == -1 || ddlVillage.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Proposed Location Village \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLandArea.Text) || txtLandArea.Text == "" || txtLandArea.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Total Extend Land  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtBuiltArea.Text) || txtBuiltArea.Text == "" || txtBuiltArea.Text == null)
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
                if (string.IsNullOrEmpty(txtUnitLocation.Text) || txtUnitLocation.Text == "" || txtUnitLocation.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Location Of The Unit \\n";
                    slno = slno + 1;
                }
                if (rblMIDCL.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether land purchased from MIDCL or not \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPropEmp.Text) || txtPropEmp.Text == "" || txtPropEmp.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Proposed Employment \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLandValue.Text) || txtLandValue.Text == "" || txtLandValue.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Value of Land as per sale Deed(In INR) \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtBuildingValue.Text) || txtBuildingValue.Text == "" || txtBuildingValue.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Value of Building \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPMCost.Text) || txtPMCost.Text == "" || txtPMCost.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Value of Plant & Machinery \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAnnualTurnOver.Text) || txtAnnualTurnOver.Text == "" || txtAnnualTurnOver.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Expected Annual Turnover( \\n";
                    slno = slno + 1;
                }
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
                if (string.IsNullOrEmpty(txtBuildingHeight.Text) || txtBuildingHeight.Text == "" || txtBuildingHeight.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Height of the building \\n";
                    slno = slno + 1;
                }
                if (rblRSDSstore.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether you store RS, DS or not \\n";
                    slno = slno + 1;
                }
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
                        if (string.IsNullOrEmpty(txtAggrCapacity.Text) || txtAggrCapacity.Text == "" || txtAggrCapacity.Text == null)
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
                if (rblFelltrees.SelectedValue == "Y")
                {
                    if (string.IsNullOrEmpty(txtNoofTrees.Text) || txtNoofTrees.Text == "" || txtNoofTrees.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Number of trees to be felled \\n";
                        slno = slno + 1;
                    }
                }
                if (rblwaterbody.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether unit Location fall within 100mts vicinity of any water body or not \\n";
                    slno = slno + 1;
                }
                if (rblborewell.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether You have Existing borewell in proposed factory Location or not \\n";
                    slno = slno + 1;
                }
                if (rblLbrAct1970.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Contract Labour(Regulation and Abolition)Act, 1970? \\n";
                    slno = slno + 1;
                }
                if (rblLbrAct1970.SelectedValue == "Y")
                {
                    if (string.IsNullOrEmpty(txt1970Workers.Text) || txt1970Workers.Text == "" || txt1970Workers.Text == null)
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
                    if (string.IsNullOrEmpty(txt1979Workers.Text) || txt1979Workers.Text == "" || txt1979Workers.Text == null)
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
                        if (string.IsNullOrEmpty(txt1996Workers.Text) || txt1996Workers.Text == "" || txt1996Workers.Text == null)
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
                    if (string.IsNullOrEmpty(txtContractWorkers.Text) || txtContractWorkers.Text == "" || txtContractWorkers.Text == null)
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
                    if (string.IsNullOrEmpty(txtContr1970wrkrs.Text) || txtContr1970wrkrs.Text == "" || txtContr1970wrkrs.Text == null)
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
            MVQues.ActiveViewIndex = 2;

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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
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

                DataTable dtExplosivs = new DataTable(); DataTable dtPtrlsale = new DataTable();
                DataTable dtRdctng = new DataTable(); DataTable dtNonEncCert = new DataTable();

                DataTable dtCommTax = new DataTable(); DataTable dtfrstDist = new DataTable(); DataTable dtNonFrstLand = new DataTable();
                DataTable dtHitens = new DataTable(); DataTable dttreefellng = new DataTable(); DataTable dtWtrbody = new DataTable();

                DataTable dtAct1970 = new DataTable(); DataTable dtAct1979 = new DataTable(); DataTable dtAct1996 = new DataTable();
                DataTable dtContrLbrAct = new DataTable(); DataTable dtContAct1970 = new DataTable();

                DataTable dtGroundwater = new DataTable(); DataTable watersupply = new DataTable(); DataTable rivertanker = new DataTable();
                DataTable Municipal = new DataTable(); DataTable NonMunicipal = new DataTable();

                objCFEQ.EnterpriseCategory = lblEntCategory.Text;
                if (lblPCBCategory.Text.Trim() != "White")
                {
                    objCFEQ.PCBCategory = lblPCBCategory.Text;
                    objCFEQ.ApprovalID = "1";
                    dtPCB = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(dtPCB);
                }
                if (ddlPowerReq.SelectedValue != "")
                {
                    objCFEQ.PowerReqKW = ddlPowerReq.SelectedValue;
                    objCFEQ.PropEmployment = txtPropEmp.Text;
                    objCFEQ.ApprovalID = "3";
                    dtpower = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(dtpower);
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
                if (Convert.ToDecimal(txtBuildingHeight.Text) != 0)
                {
                    objCFEQ.BuildingHeight = txtBuildingHeight.Text;
                    objCFEQ.ApprovalID = "7";
                    dtfire = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(dtfire);
                }
                if (rblRSDSstore.SelectedValue == "Y")
                {
                    objCFEQ.ApprovalID = "8";
                    dtRSDS = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(dtRSDS);
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
                if (rblHighTension.SelectedValue == "Y")
                {
                    objCFEQ.ApprovalID = "14";
                    dtHitens = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(dtHitens);
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
                if (rblLbrAct1970.SelectedValue == "Y")
                {
                    objCFEQ.ApprovalID = "25";
                    dtAct1970 = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(dtAct1970);
                }
                if (rblLbrAct1979.SelectedValue == "Y")
                {
                    objCFEQ.ApprovalID = "26";
                    dtAct1979 = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(dtAct1979);
                }
                if (rblLbrAct1996.SelectedValue == "Y")
                {
                    objCFEQ.ApprovalID = "27";
                    dtAct1996 = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(dtAct1996);
                }
                if (rblLabourAct.SelectedValue == "Y")
                {
                    objCFEQ.ApprovalID = "28";
                    dtContrLbrAct = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(dtContrLbrAct);
                }
                if (rblForContr1970.SelectedValue == "Y")
                {
                    objCFEQ.ApprovalID = "29";
                    dtContAct1970 = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(dtContAct1970);
                }
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
                if (rblRiverTanks.SelectedValue == "Y")
                {
                    objCFEQ.ApprovalID = "21";
                    rivertanker = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(rivertanker);
                }
                if (rblMunicipal.SelectedValue == "Y")
                {
                    objCFEQ.ApprovalID = "22";
                    Municipal = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(Municipal);
                }
                if (rblGrantwater.SelectedValue == "Y")
                {
                    objCFEQ.ApprovalID = "23";
                    NonMunicipal = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                    dtApprReq.Merge(NonMunicipal);
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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
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
                    e.Row.Cells[3].Text = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fee")).ToString("#,##0");
                }
                if ((e.Row.RowType == DataControlRowType.Footer))
                {
                    e.Row.Cells[2].Text = "Total Fee";
                    e.Row.Cells[3].Text = TotalFee.ToString("#,##0");
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }

        }

        protected void Link1_Click(object sender, EventArgs e)
        {
            MVQues.ActiveViewIndex = 0;
            var cls = Link1.Attributes["class"];
            Link1.Attributes.Add("class", cls + " nav-tab");
        }

        protected void Link2_Click(object sender, EventArgs e)
        {
            MVQues.ActiveViewIndex = 1;
        }

        protected void Link3_Click(object sender, EventArgs e)
        {
            MVQues.ActiveViewIndex = 2;
        }

        protected void txtAnnualTurnOver_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtAnnualTurnOver.Text != "")
                {
                    string Res = objcfebal.GETANNUALTURNOVER(txtPMCost.Text.ToString(), txtAnnualTurnOver.Text.ToString());
                    if (Res != "")
                    {
                        txtAnnualTurnOver.Text = "";
                        string message = "alert('" + Res + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;

                    }
                    else
                    {
                        string Result = objcfebal.CFEENTERPRISETYPE(txtAnnualTurnOver.Text.ToString());
                        if (Result != "")
                        {
                            lblEntCategory.Text = Result;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}