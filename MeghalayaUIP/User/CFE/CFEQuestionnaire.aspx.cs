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

namespace MeghalayaUIP.User.CFE
{
    public partial class CFEQuestionnaire : System.Web.UI.Page
    {
        int index; Decimal TotalFee = 0;
        MasterBAL mstrBAL = new MasterBAL();
        CFEBAL objcfebal = new CFEBAL();
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
                    BINDDATA();
                }

            }
        }
        protected void MVQues_ActiveViewChanged(object sender, EventArgs e)
        {
            index = MVQues.ActiveViewIndex;
            if (index == 0)
            { Link1.CssClass = "Underlined"; }
            if (index == 1)
            { Link2.CssClass = "Underlined"; }
            if (index == 2)
            { Link3.CssClass = "Underlined"; }


        }
        public void BINDDATA()
        {
            try
            {

                DataSet ds = new DataSet();
                ds = objcfebal.GetIndustryRegDetails(hdnUserID.Value);
                if (ds != null)
                {
                    hdnPreRegUNITID.Value = Convert.ToString(ds.Tables[0].Rows[0]["UNITID"]);
                    hdnPreRegUID.Value = Convert.ToString(ds.Tables[0].Rows[0]["PREREGUIDNO"]);
                    txtUnitName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]);
                    txtProposalfor.Text = Convert.ToString(ds.Tables[0].Rows[0]["COMPANYTYPE"]);
                    ddlDistrict.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["REP_DISTRICTID"]);
                    ddlDistrict_SelectedIndexChanged(null, EventArgs.Empty);
                    ddlMandal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["REP_MANDALID"]);
                    ddlMandal_SelectedIndexChanged(null, EventArgs.Empty);
                    ddlVillage.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["REP_VILLAGEID"]);
                    txtLandArea.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_LANDAREA"]);
                    txtAcres.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_LANDAREA"]);
                    txtSquareMeters.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_LANDAREA"]);

                    txtBuiltArea.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_BUILDINGAREA"]);
                    lblPCBCategory.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_PCBCATEGORY"]);
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
                    lblTotProjCost.Text =Convert.ToString( Convert.ToDecimal(txtLandValue.Text) + Convert.ToDecimal(txtBuildingValue.Text) + Convert.ToDecimal(txtPMCost.Text));
                    lblEntCategory.Text = "MEGA PROJECT";
                }


            }
            catch (Exception ex)
            {
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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

                throw ex;
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
                //lblmsg0.Text = ex.Message;
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                ErrorMsg = Step5validations();
                if (ErrorMsg == "")
                {
                    CFEQuestionnaireDet objCFEQsnaire = new CFEQuestionnaireDet();
                    objCFEQsnaire.CFEQDID = "";
                    objCFEQsnaire.UNITID = hdnPreRegUNITID.Value;
                    objCFEQsnaire.PREREGUIDNO = hdnPreRegUID.Value;
                    objCFEQsnaire.IPAddress = getclientIP();
                    objCFEQsnaire.CompanyName = txtUnitName.Text.Trim();
                    objCFEQsnaire.ConstofUnit = ddlConstType.SelectedValue;
                    objCFEQsnaire.ProposalFor = txtProposalfor.Text.Trim();
                    objCFEQsnaire.LandFromMIDCL = rblMIDCL.SelectedValue;
                    objCFEQsnaire.PropLocDitrictID = ddlDistrict.SelectedValue;
                    objCFEQsnaire.PropLocMandalID = ddlMandal.SelectedValue;
                    objCFEQsnaire.PropLocVillageID = ddlVillage.SelectedValue;
                    objCFEQsnaire.ExtentofLand = txtLandArea.Text.Trim();
                    objCFEQsnaire.Acres = txtAcres.Text.Trim();
                    // objCFEQsnaire.Gunthas =
                    objCFEQsnaire.Square_Meters = txtSquareMeters.Text.Trim();
                    objCFEQsnaire.BuiltUpArea = txtBuiltArea.Text.Trim();
                    objCFEQsnaire.SectorName = ddlSector.SelectedValue;
                    objCFEQsnaire.Lineofacitivityid = ddlLine_Activity.SelectedValue;
                    objCFEQsnaire.PCBCategory = lblPCBCategory.Text.Trim();
                    objCFEQsnaire.NatureofActivity = ddlIndustryType.SelectedValue;
                    objCFEQsnaire.UnitLocation = txtUnitLocation.Text.Trim();
                    objCFEQsnaire.PropEmployment = txtPropEmp.Text.Trim();
                    //  objCFEQsnaire.ProjectCost = txtEstProjCost.Text.Trim();
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
                    objCFEQsnaire.AggCapacity = txtCapacity.Text.Trim();
                    objCFEQsnaire.VoltageRating = ddlVoltage.SelectedValue;
                    objCFEQsnaire.TreesFelling = rblfrstDistncLtr.SelectedValue;
                    objCFEQsnaire.NoofTrees = txttree.Text.Trim();
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

                    try
                    {
                        DataTable dt = new DataTable();
                        dt = objcfebal.GetsectorDep(ddlSector.SelectedValue);
                        if (dt.Rows.Count > 0)
                        {
                            objCFEQsnaire.DeptID = dt.Rows[0].Table.Columns["MD_DEPTID"].ToString();
                        }
                    }
                    catch (Exception EX)
                    {
                        throw EX;
                    }
                    result = objcfebal.InsertQuestionnaireCFE(objCFEQsnaire, out string IDno);
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
        public string Step5validations()
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
                if (ddlConstType.SelectedIndex == -1 || ddlConstType.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Constitution of Unit \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtProposalfor.Text) || txtProposalfor.Text == "" || txtProposalfor.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Proposal \\n";
                    slno = slno + 1;
                }
                if (ddlDistrict.SelectedIndex == -1 || ddlDistrict.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Authorised Representative District \\n";
                    slno = slno + 1;
                }
                if (ddlMandal.SelectedIndex == -1 || ddlMandal.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Authorised Representative Mandal \\n";
                    slno = slno + 1;
                }
                if (ddlVillage.SelectedIndex == -1 || ddlVillage.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Authorised Representative Village \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLandArea.Text) || txtLandArea.Text == "" || txtLandArea.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Total Extend Land  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtSquareMeters.Text) || txtSquareMeters.Text == "" || txtSquareMeters.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Square Meter \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAcres.Text) || txtAcres.Text == "" || txtAcres.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Acrs \\n";
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
                if (string.IsNullOrEmpty(lblPCBCategory.Text) || lblPCBCategory.Text == "" || lblPCBCategory.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Pollution Category of Enterprise \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtUnitLocation.Text) || txtUnitLocation.Text == "" || txtUnitLocation.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Location Of The Unit \\n";
                    slno = slno + 1;
                }
                return errormsg;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnPreviuos3_Click(object sender, EventArgs e)
        {
            MVQues.ActiveViewIndex = 2;

        }

        protected void btnShowEncl_Click(object sender, EventArgs e)
        {

        }

        protected void btnApprvlsReq_Click(object sender, EventArgs e)
        {
            try
            {
                CFEQuestionnaireDet objCFEQ = new CFEQuestionnaireDet();

                string ErrorMsg = "1";
                //ErrorMsg = Step3Validations();
                if (ErrorMsg != "")
                {
                    GetApprovals();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GetApprovals()
        {
            try
            {
                CFEQuestionnaireDet objCFEQ = new CFEQuestionnaireDet();

                string ErrorMsg = "1";
                //ErrorMsg = Step3Validations();
                if (ErrorMsg != "")
                {
                    DataTable dtApprReq = new DataTable();
                    DataTable dtPCB = new DataTable(); DataTable dtpower = new DataTable(); DataTable dtGenReq = new DataTable();
                    DataTable dtfire = new DataTable(); DataTable dtFctry = new DataTable(); DataTable dtRSDS = new DataTable();

                    DataTable dtExplosivs = new DataTable(); DataTable dtPtrlsale = new DataTable();
                    DataTable dtRdctng = new DataTable(); DataTable dtNonEncCert = new DataTable();

                    DataTable dtCommTax = new DataTable(); DataTable dtfrstDist = new DataTable(); DataTable dtNonFrstLand = new DataTable();
                    DataTable dtHitens = new DataTable(); DataTable dttreefellng = new DataTable(); DataTable dtWtrbody = new DataTable();

                    DataTable dtAct1970 = new DataTable(); DataTable dtAct1979 = new DataTable(); DataTable dtAct1996 = new DataTable();
                    DataTable dtContrLbrAct = new DataTable(); DataTable dtContAct1970 = new DataTable();


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
            }
            catch (Exception ex)
            {
                throw ex;
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
                throw ex;
            }

        }

        protected void Link1_Click(object sender, EventArgs e)
        {
            MVQues.ActiveViewIndex = 0;

        }

        protected void Link2_Click(object sender, EventArgs e)
        {
            MVQues.ActiveViewIndex = 1;
        }

        protected void Link3_Click(object sender, EventArgs e)
        {
            MVQues.ActiveViewIndex = 2;
        }
    }
}