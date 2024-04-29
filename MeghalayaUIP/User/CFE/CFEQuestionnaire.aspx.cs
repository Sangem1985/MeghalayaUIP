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
        int index;
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
                    // MVQues.ActiveViewIndex = index;
                    BindSectors();
                    BindDistricts();
                    BindConstitutionType();
                    BindIndustryType();
                    BindPowerReq();
                    GetElectricRegulations();
                    GetVoltageMaster();
                    GetPowerPlants();
                    //BINDDATA();
                }

            }
        }
        //protected void MVQues_ActiveViewChanged(object sender, EventArgs e)
        //{
        //    index = MVQues.ActiveViewIndex;


        //}
        public void BINDDATA()
        {
            try
            {

                DataSet ds = new DataSet();
                ds = objcfebal.GetIndustryRegDetails(hdnUserID.Value);
                if (ds != null)
                {
                    hdnPreRegUNITID.Value = Convert.ToString(ds.Tables[0].Rows[0]["UNITID"]);
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
                    txtPolCategory.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_PCBCATEGORY"]);
                    ddlLine_Activity.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_LOAID"]);
                    ddlIndustryType.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_NOA"]);
                    ddlSector.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_SECTORNAME"]);
                    ddlSector_SelectedIndexChanged(null, EventArgs.Empty);
                    //txtPropEmp.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                    txtEstProjCost.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_EPCOST"]);
                    txtLandValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_LANDVALUE"]);
                    txtBuildingValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_BUILDINGVALUE"]);
                    txtPMCost.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_PMCOST"]);
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
                    txtPolCategory.Text = mstrBAL.GetPCBCategory(ddlLine_Activity.SelectedValue);

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
        protected void btnsave1_Click(object sender, EventArgs e)
        {

        }

        protected void btnNext1_Click(object sender, EventArgs e)
        {
            //MVQues.ActiveViewIndex = 1;
        }
        protected void btnPreviuos2_Click(object sender, EventArgs e)
        {
            //MVQues.ActiveViewIndex = 0;
        }
        protected void btnsave2_Click(object sender, EventArgs e)
        {

        }

        protected void btnNext2_Click(object sender, EventArgs e)
        {
            //MVQues.ActiveViewIndex = 2;

        }

        protected void btnSave3_Click(object sender, EventArgs e)
        {

        }

        protected void btnPreviuos3_Click(object sender, EventArgs e)
        {
            //MVQues.ActiveViewIndex = 2;

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


                    DataTable dtApprReq = new DataTable();
                    DataTable dtPCB = new DataTable(); DataTable dtpower = new DataTable(); DataTable dtGenReq = new DataTable();
                    DataTable dtfire = new DataTable(); DataTable dtFctry = new DataTable(); DataTable dtRSDS = new DataTable();

                    DataTable dtExplosivs = new DataTable(); DataTable dtPtrlsale = new DataTable();
                    DataTable dtRdctng = new DataTable(); DataTable dtNonEncCert = new DataTable();

                    DataTable dtCommTax = new DataTable(); DataTable dtfrstDist = new DataTable();
                    DataTable dtNonFrstLand = new DataTable(); DataTable dtHitens = new DataTable(); DataTable dttreefellng = new DataTable();

                    DataTable dtAct1970 = new DataTable(); DataTable dtAct1979 = new DataTable();
                    DataTable dtAct1996 = new DataTable(); DataTable dtContrLbrAct = new DataTable();


                    objCFEQ.EnterpriseCategory = lblEntCategory.Text;
                    if (txtPolCategory.Text.Trim() != "White")
                    {
                        objCFEQ.PCBCategory = txtPolCategory.Text;
                        objCFEQ.ApprovalID = "32";
                        dtPCB = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                        dtApprReq.Merge(dtPCB);
                    }
                    if (ddlPowerReq.SelectedValue != "")
                    {
                        objCFEQ.PowerReqKW = ddlPowerReq.SelectedValue;
                        objCFEQ.PropEmployment = txtPropEmp.Text;
                        objCFEQ.ApprovalID = "19";
                        dtpower = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                        dtApprReq.Merge(dtpower);
                        objCFEQ.ApprovalID = "25";
                        dtFctry = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                        dtApprReq.Merge(dtFctry);
                    }
                    if (rblGenerator.SelectedValue == "Y")
                    {
                        objCFEQ.ApprovalID = "17";
                        dtGenReq = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                        dtApprReq.Merge(dtGenReq);
                    }
                    if (Convert.ToDecimal(txtBuildingHeight.Text) != 0)
                    {
                        objCFEQ.BuildingHeight = txtBuildingHeight.Text;
                        objCFEQ.ApprovalID = "8";
                        dtfire = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                        dtApprReq.Merge(dtfire);
                    }
                    if (rblRSDSstore.SelectedValue == "Y")
                    {
                        objCFEQ.ApprovalID = "7";
                        dtRSDS = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                        dtApprReq.Merge(dtRSDS);
                    }
                    if (rblexplosives.SelectedValue == "Y")
                    {
                        objCFEQ.ApprovalID = "16";
                        dtExplosivs = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                        dtApprReq.Merge(dtExplosivs);
                    }
                    if (rblPetrlManf.SelectedValue == "Y")
                    {
                        objCFEQ.ApprovalID = "15";
                        dtPtrlsale = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                        dtApprReq.Merge(dtPtrlsale);
                    }
                    if (rblRoadCutting.SelectedValue == "Y")
                    {
                        objCFEQ.ApprovalID = "23";
                        dtRdctng = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                        dtApprReq.Merge(dtRdctng);
                    }
                    if (rblNonEncCert.SelectedValue == "Y")
                    {
                        objCFEQ.ApprovalID = "14";
                        dtNonEncCert = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                        dtApprReq.Merge(dtNonEncCert);
                    }
                    if (rblCommericalTax.SelectedValue == "Y")
                    {
                        objCFEQ.ApprovalID = "6";
                        dtCommTax = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                        dtApprReq.Merge(dtCommTax);
                    }
                    if (rblHighTension.SelectedValue == "Y")
                    {
                        objCFEQ.ApprovalID = "24";
                        dtHitens = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                        dtApprReq.Merge(dtHitens);
                    }
                    if (rblfrstDistncLtr.SelectedValue == "Y")
                    {
                        objCFEQ.ApprovalID = "3";
                        dtfrstDist = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                        dtApprReq.Merge(dtfrstDist);
                    }
                    if (rblNonForstLandCert.SelectedValue == "Y")
                    {
                        objCFEQ.ApprovalID = "4";
                        dtNonFrstLand = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                        dtApprReq.Merge(dtNonFrstLand);
                    }
                    if (rblLbrAct1970.SelectedValue == "Y")
                    {
                        objCFEQ.ApprovalID = "12";
                        dtAct1970 = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                        dtApprReq.Merge(dtAct1970);
                    }
                    if (rblLbrAct1979.SelectedValue == "Y")
                    {
                        objCFEQ.ApprovalID = "10";
                        dtAct1979 = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                        dtApprReq.Merge(dtAct1979);
                    }
                    if (rblLbrAct1996.SelectedValue == "Y")
                    {
                        objCFEQ.ApprovalID = "9";
                        dtAct1996 = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                        dtApprReq.Merge(dtAct1996);
                    }
                    if (rblLabourAct.SelectedValue == "Y")
                    {
                        objCFEQ.ApprovalID = "11";
                        dtContrLbrAct = objcfebal.GetApprovalsReqWithFee(objCFEQ);
                        dtApprReq.Merge(dtContrLbrAct);
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


    }
}