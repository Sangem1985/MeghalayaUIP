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
using MeghalayaUIP.BAL.CFOBAL;

namespace MeghalayaUIP.User.CFO
{
    public partial class CFOQuestionnaire : System.Web.UI.Page
    {
        string UnitID, ErrorMsg = "", ErrorMsg1 = "", ErrorMsg2 = "";
        int index; Decimal TotalFee = 0;
        MasterBAL mstrBAL = new MasterBAL();
        CFOBAL objcfobal = new CFOBAL();
        string status = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count > 0)
            {
                status = Request.QueryString["status"];
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
                if (status == null || status == "")
                {

                    if (Convert.ToString(Session["CFOUNITID"]) != "")
                    { UnitID = Convert.ToString(Session["CFOUNITID"]); }
                    else
                    {
                        string newurl = "~/User/CFO/CFOUserDashboard.aspx";
                        Response.Redirect(newurl);
                    }
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
                    BindData();
                }

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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
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
                    ddlLine_Activity.Items.Clear();
                    AddSelect(ddlLine_Activity);
                    lblPCBCategory.Text = "";
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
                ddlVillage.Items.Clear();
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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }

        }

        protected void Link2_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg1 = Validations1();
                if (ErrorMsg1 == "")
                {
                    MVQues.ActiveViewIndex = 1;
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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }

        }
        protected void Link3_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg2 = Validations2();
                if (ErrorMsg2 == "")
                {
                    MVQues.ActiveViewIndex = 2;
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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }

        }
        protected void btnsave1_Click(object sender, EventArgs e)
        { }
        protected void btnNext1_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg1 = Validations1();
                if (ErrorMsg1 == "")
                {
                    Link2.Enabled = true;
                    MVQues.ActiveViewIndex = 1;
                }
                else
                {
                    string message = "alert('" + ErrorMsg1 + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
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
                }
                else
                {
                    string message = "alert('" + ErrorMsg2 + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
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
                    CFOQuestionnaireDet objCFOQsnaire = new CFOQuestionnaireDet();

                    if (Convert.ToString(Session["CFOQID"]) == "")
                        objCFOQsnaire.CFEQDID = "";
                    else
                        objCFOQsnaire.CFEQDID = Convert.ToString(Session["CFOQID"]);
                    objCFOQsnaire.CFOQDID = "";
                    objCFOQsnaire.UNITID = Convert.ToString(Session["CFOUNITID"]);
                    objCFOQsnaire.PREREGUIDNO = hdnPreRegUID.Value;
                    objCFOQsnaire.IPAddress = getclientIP();
                    objCFOQsnaire.CompanyName = txtUnitName.Text.Trim();
                    objCFOQsnaire.CompanyType = ddlCompanyType.SelectedValue;
                    objCFOQsnaire.ProposalFor = rblProposal.SelectedValue.Trim();
                    objCFOQsnaire.LandFromMIDCL = rblMIDCL.SelectedValue;
                    objCFOQsnaire.PropLocDitrictID = ddlDistrict.SelectedValue;
                    objCFOQsnaire.PropLocMandalID = ddlMandal.SelectedValue;
                    objCFOQsnaire.PropLocVillageID = ddlVillage.SelectedValue;
                    objCFOQsnaire.ExtentofLand = txtLandArea.Text.Trim();

                    objCFOQsnaire.BuiltUpArea = txtBuiltArea.Text.Trim();
                    objCFOQsnaire.SectorName = ddlSector.SelectedItem.Text;
                    objCFOQsnaire.Lineofacitivityid = ddlLine_Activity.SelectedValue;
                    objCFOQsnaire.PCBCategory = lblPCBCategory.Text.Trim();
                    objCFOQsnaire.NatureofActivity = ddlIndustryType.SelectedValue;
                    objCFOQsnaire.UnitLocation = txtUnitLocation.Text.Trim();
                    objCFOQsnaire.PropEmployment = txtPropEmp.Text.Trim();
                    objCFOQsnaire.LandValue = txtLandValue.Text.Trim();
                    objCFOQsnaire.BuildingValue = txtBuildingValue.Text.Trim();
                    objCFOQsnaire.PlantnMachineryCost = txtPMCost.Text.Trim();
                    objCFOQsnaire.ExpectedTurnover = txtAnnualTurnOver.Text.Trim();
                    objCFOQsnaire.TotalProjCost = lblTotProjCost.Text.Trim();
                    objCFOQsnaire.EnterpriseCategory = lblEntCategory.Text.Trim();

                    objCFOQsnaire.LabourAct2020 = rblRegMigrantWorkers.SelectedValue;
                    objCFOQsnaire.BoilerManfreg = rblRegManfRepairs.SelectedValue;
                    objCFOQsnaire.WorkContractorsReg = rblServicesRenewal.SelectedValue;
                    objCFOQsnaire.BoilerReg = rblBoilers.SelectedValue;
                    objCFOQsnaire.FactoryLicence = rblLicensetoWorkFac.SelectedValue;
                    objCFOQsnaire.Labouract1979 = rblInterstateMigrantWorkmen.SelectedValue;
                    objCFOQsnaire.Labouract1970 = rblContractLabourAct1970.SelectedValue;
                    objCFOQsnaire.DrugLic = rblWDruglicence.SelectedValue;
                    objCFOQsnaire.Wandmreparerlic = rblRPLicenceWeights.SelectedValue;
                    objCFOQsnaire.Wandmmanflic = rblMFLicenceWeights.SelectedValue;
                    objCFOQsnaire.Wandmdealerlic = rblLicenceDealers.SelectedValue;
                    objCFOQsnaire.Wandmverification = rblVerificationInstrument.SelectedValue;
                    objCFOQsnaire.Firesaftycert = rblFireSafety.SelectedValue;
                    objCFOQsnaire.Exciselic = rblExciseLicenseDistillery.SelectedValue;
                    objCFOQsnaire.Druglicconstchange = rblConstitutionLicenceRWD.SelectedValue;
                    objCFOQsnaire.Brandlabelreg = rblBrandLabelReg.SelectedValue;
                    objCFOQsnaire.Druglicmanffortest = rblPurposeofExamination.SelectedValue;
                    objCFOQsnaire.Drugloanlicmanfshedulec = rblScheduleX.SelectedValue;
                    objCFOQsnaire.Drugloanlicmanfnotshedulec = rblDrugloanlicmanfnotshedulec.SelectedValue;
                    objCFOQsnaire.Druglicrepacksale = rblDruglicrepacksale.SelectedValue;
                    objCFOQsnaire.Druglicmanfsalevaccnotshedulex = rblDruglicmanfsalevaccnotshedulex.SelectedValue;
                    objCFOQsnaire.Proftaxcert = rblProftaxcert.SelectedValue;
                    objCFOQsnaire.Cfopcb = rblCFOPCB.SelectedValue;
                    objCFOQsnaire.Occupancycert = rblOccupancyCertificate.SelectedValue;
                    objCFOQsnaire.Boilerstmpipelineerection = rblErectionPermission.SelectedValue;
                    objCFOQsnaire.Boilerstmpipelineregistration = rblPipelineCertificate.SelectedValue;
                    objCFOQsnaire.Shpsestbreg_forma = rblShpsestbregformA.SelectedValue;
                    objCFOQsnaire.Businessslic = rblBusinesssLic.SelectedValue;
                    objCFOQsnaire.Liquorlic = rblLiquorLic.SelectedValue;
                    objCFOQsnaire.Stateexciseverfcert = rblExciseVerification.SelectedValue;
                    objCFOQsnaire.PowerReqKW = ddlPowerReq.SelectedValue;
                    objCFOQsnaire.CreatedBy = hdnUserID.Value;
                    int count = 0;
                    result = objcfobal.InsertQuestionnaireCFO(objCFOQsnaire);
                    if (result != "100")
                    {
                        // Session["CFOIUNITID"] = hdnPreRegUNITID.Value;
                        Session["CFOQID"] = result;
                        for (int i = 0; i < grdApprovals.Rows.Count; i++)
                        {

                            Label ApprovalID = grdApprovals.Rows[i].FindControl("lblApprID") as Label;
                            Label DeptID = grdApprovals.Rows[i].FindControl("lblDeptID") as Label;

                            objCFOQsnaire.CFOQDID = result;
                            objCFOQsnaire.ApprovalID = ApprovalID.Text;
                            objCFOQsnaire.DeptID = DeptID.Text;
                            objCFOQsnaire.ApprovalFee = grdApprovals.Rows[i].Cells[3].Text;
                            objCFOQsnaire.CreatedBy = hdnUserID.Value;
                            objCFOQsnaire.IPAddress = getclientIP();
                            objCFOQsnaire.UNITID = Convert.ToString(Session["CFOUNITID"]);

                            string A = objcfobal.InsertCFOQuestionnaireApprovals(objCFOQsnaire);
                            if (A != "")
                            { count = count + 1; }
                        }
                        if (grdApprovals.Rows.Count == count)
                        {
                            success.Visible = true;
                            lblmsg.Text = "Pre Operational - Questionnaire Details Submitted Successfully";
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
                else
                {
                    string message = "alert('" + ErrorMsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }
        }
        protected void btnNext3_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave3_Click(sender, e);
                if (ErrorMsg == "")
                    Response.Redirect("~/User/CFO/CFOCombinedApplication.aspx");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
        protected void MVQues_ActiveViewChanged(object sender, EventArgs e)
        {

        }

        protected void grdApprovals_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnPreviuos3_Click(object sender, EventArgs e)
        {
            MVQues.ActiveViewIndex = 1;
        }


        protected void btnApprvlsReq_Click(object sender, EventArgs e)
        {
            try
            {
                CFOQuestionnaireDet objCFOQ = new CFOQuestionnaireDet();

                string ErrorMsg;
                /*ErrorMsg = Validations();
                if (ErrorMsg == "")
                {
                    GetApprovals();
                }
                else
                {

                }*/
                GetApprovals();
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
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
        protected void GetApprovals()
        {
            try
            {
                CFOQuestionnaireDet objCFOQ = new CFOQuestionnaireDet();

                DataTable dtApprReq = new DataTable();

                string ApprovalIds = "";

                if (rblRegMigrantWorkers.SelectedValue == "Y")
                {
                    objCFOQ.Investment = txtPMCost.Text;
                    ApprovalIds = ApprovalIds + "32";

                }
                if (rblRegManfRepairs.SelectedValue == "Y")
                {
                    ApprovalIds = ApprovalIds + ",33";
                }
                if (rblServicesRenewal.SelectedValue == "Y")
                {
                    ApprovalIds = ApprovalIds + ",34";
                }
                if (rblBoilers.SelectedValue == "Y")
                {
                    ApprovalIds = ApprovalIds + ",35";
                }
                if (rblLicensetoWorkFac.SelectedValue == "Y")
                {
                    objCFOQ.Power = ddlPowerReq.SelectedItem.Text;
                    objCFOQ.PropEmployment = txtPropEmp.Text;
                    ApprovalIds = ApprovalIds + ",36";
                }
                if (rblInterstateMigrantWorkmen.SelectedValue == "Y")
                {
                    ApprovalIds = ApprovalIds + ",37";
                }
                if (rblContractLabourAct1970.SelectedValue == "Y")
                {
                    ApprovalIds = ApprovalIds + ",38";
                }
                if (rblWDruglicence.SelectedValue == "Y")
                {
                    ApprovalIds = ApprovalIds + ",39";
                }
                if (rblRPLicenceWeights.SelectedValue == "Y")
                {
                    ApprovalIds = ApprovalIds + ",40";
                }
                if (rblMFLicenceWeights.SelectedValue == "Y")
                {
                    ApprovalIds = ApprovalIds + ",41";
                }
                if (rblLicenceDealers.SelectedValue == "Y")
                {
                    ApprovalIds = ApprovalIds + ",42";
                }
                if (rblVerificationInstrument.SelectedValue == "Y")
                {
                    ApprovalIds = ApprovalIds + ",43";
                }
                if (rblFireSafety.SelectedValue == "Y")
                {
                    ApprovalIds = ApprovalIds + ",44";
                }
                if (rblExciseLicenseDistillery.SelectedValue == "Y")
                {
                    ApprovalIds = ApprovalIds + ",45";
                }
                if (rblConstitutionLicenceRWD.SelectedValue == "Y")
                {
                    ApprovalIds = ApprovalIds + ",46";
                }
                if (rblBrandLabelReg.SelectedValue == "Y")
                {
                    ApprovalIds = ApprovalIds + ",47";
                }
                if (rblPurposeofExamination.SelectedValue == "Y")
                {
                    ApprovalIds = ApprovalIds + ",48";
                }
                if (rblScheduleX.SelectedValue == "Y")
                {
                    ApprovalIds = ApprovalIds + ",49";
                }
                if (rblDrugloanlicmanfnotshedulec.SelectedValue == "Y")
                {
                    ApprovalIds = ApprovalIds + ",50";
                }
                if (rblDruglicrepacksale.SelectedValue == "Y")
                {
                    ApprovalIds = ApprovalIds + ",51";
                }
                if (rblDruglicmanfsalevaccnotshedulex.SelectedValue == "Y")
                {
                    ApprovalIds = ApprovalIds + ",52";
                }
                if (rblProftaxcert.SelectedValue == "Y")
                {
                    ApprovalIds = ApprovalIds + ",53";
                }
                if (rblCFOPCB.SelectedValue == "Y")
                {
                    ApprovalIds = ApprovalIds + ",54";
                }
                if (rblOccupancyCertificate.SelectedValue == "Y")
                {
                    ApprovalIds = ApprovalIds + ",55";
                }
                if (rblErectionPermission.SelectedValue == "Y")
                {
                    ApprovalIds = ApprovalIds + ",56";
                }
                if (rblPipelineCertificate.SelectedValue == "Y")
                {
                    ApprovalIds = ApprovalIds + ",57";
                }
                if (rblShpsestbregformA.SelectedValue == "Y")
                {
                    objCFOQ.PropEmployment = txtPropEmp.Text;
                    ApprovalIds = ApprovalIds + ",58";
                }
                if (rblBusinesssLic.SelectedValue == "Y")
                {
                    ApprovalIds = ApprovalIds + ",59";
                }
                if (rblLiquorLic.SelectedValue == "Y")
                {
                    ApprovalIds = ApprovalIds + ",60";
                }
                if (rblExciseVerification.SelectedValue == "Y")
                {
                    ApprovalIds = ApprovalIds + ",61";
                }
                objCFOQ.ApprovalID = ApprovalIds;
                DataSet dsApprovals = new DataSet();
                dsApprovals = objcfobal.GetApprovalsReqWithFee(objCFOQ);


                if (dsApprovals.Tables[0].Rows.Count > 0)
                {
                    divApprovals.Visible = true;
                    grdApprovals.DataSource = dsApprovals;
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
        public void BindData()
        {
            try
            {

                DataSet ds = new DataSet();
                ds = objcfobal.RetrieveQuestionnaireDetails(hdnUserID.Value, UnitID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["CFOQID"] = ds.Tables[0].Rows[0]["CFOQDID"].ToString();
                    hdnPreRegUNITID.Value = Convert.ToString(ds.Tables[0].Rows[0]["CFOQD_UNITID"]);
                    hdnPreRegUID.Value = Convert.ToString(ds.Tables[0].Rows[0]["CFOQD_PREREGUIDNO"]);
                    txtUnitName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOQD_COMPANYNAME"]);
                    rblProposal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFOQD_PROPOSALFOR"]);
                    ddlCompanyType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFOQD_COMPANYTYPE"]);
                    ddlDistrict.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFOQD_PROPDISTRICTID"]);
                    ddlDistrict_SelectedIndexChanged(null, EventArgs.Empty);
                    ddlMandal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFOQD_PROPMANDALID"]);
                    ddlMandal_SelectedIndexChanged(null, EventArgs.Empty);
                    ddlVillage.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFOQD_PROPVILLAGEID"]);
                    txtLandArea.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOQD_TOTALEXTENTLAND"]);

                    txtBuiltArea.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOQD_BUILTUPAREA"]);
                    ddlSector.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOQD_SECTOR"]);
                    ddlSector_SelectedIndexChanged(null, EventArgs.Empty);
                    ddlLine_Activity.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFOQD_LOAID"]);
                    lblPCBCategory.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOQD_PCBCATEGORY"]);

                    if (Convert.ToString(ds.Tables[0].Rows[0]["CFOQD_INDUSTRYTYPE"]) == "Manufacturing")
                        ddlIndustryType.SelectedValue = "1";
                    else
                        ddlIndustryType.SelectedValue = "2";
                    txtUnitLocation.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOQD_UNTLOCATION"]);
                    rblMIDCL.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFOQD_MIDCLLAND"]);

                    txtPropEmp.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOQD_PROPEMP"]);
                    txtLandValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOQD_LANDVALUE"]);
                    txtBuildingValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOQD_BUILDINGVALUE"]);
                    txtPMCost.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOQD_PMCOST"]);
                    txtAnnualTurnOver.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOQD_EXPECTEDTURNOVER"]);
                    lblTotProjCost.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOQD_TOTALPROJCOST"]);
                    lblEntCategory.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOQD_ENTERPRISETYPE"]);

                    rblRegMigrantWorkers.SelectedValue = ds.Tables[0].Rows[0]["CFOQD_LABOURACT2020"].ToString();
                    rblRegManfRepairs.SelectedValue = ds.Tables[0].Rows[0]["CFOQD_BOILERMANFREG"].ToString();
                    rblServicesRenewal.SelectedValue = ds.Tables[0].Rows[0]["CFOQD_WORKCONTRACTORSREG"].ToString();
                    rblBoilers.SelectedValue = ds.Tables[0].Rows[0]["CFOQD_BOILERREG"].ToString();
                    rblLicensetoWorkFac.SelectedValue = ds.Tables[0].Rows[0]["CFOQD_FACTORYLICENCE"].ToString();
                    if (rblLicensetoWorkFac.SelectedValue == "Y")
                    {
                        txtPower.Visible = true;
                        ddlPowerReq.SelectedValue= ds.Tables[0].Rows[0]["CFEQD_POWERREQKW"].ToString();
                    }
                    else { txtPower.Visible = false; }
                    rblInterstateMigrantWorkmen.SelectedValue = ds.Tables[0].Rows[0]["CFOQD_LABOURACT1979"].ToString();
                    rblContractLabourAct1970.SelectedValue = ds.Tables[0].Rows[0]["CFOQD_LABOURACT1970"].ToString();
                    rblWDruglicence.SelectedValue = ds.Tables[0].Rows[0]["CFOQD_DRUGLIC"].ToString();
                    rblRPLicenceWeights.SelectedValue = ds.Tables[0].Rows[0]["CFOQD_WANDMREPARERLIC"].ToString();
                    rblMFLicenceWeights.SelectedValue = ds.Tables[0].Rows[0]["CFOQD_WANDMMANFLIC"].ToString();
                    rblLicenceDealers.SelectedValue = ds.Tables[0].Rows[0]["CFOQD_WANDMDEALERLIC"].ToString();
                    rblVerificationInstrument.SelectedValue = ds.Tables[0].Rows[0]["CFOQD_WANDMVERIFICATION"].ToString();
                    rblFireSafety.SelectedValue = ds.Tables[0].Rows[0]["CFOQD_FIRESAFTYCERT"].ToString();
                    rblExciseLicenseDistillery.SelectedValue = ds.Tables[0].Rows[0]["CFOQD_EXCISELIC"].ToString();
                    rblConstitutionLicenceRWD.SelectedValue = ds.Tables[0].Rows[0]["CFOQD_DRUGLICCONSTCHANGE"].ToString();
                    rblBrandLabelReg.SelectedValue = ds.Tables[0].Rows[0]["CFOQD_BRANDLABELREG"].ToString();
                    rblPurposeofExamination.SelectedValue = ds.Tables[0].Rows[0]["CFOQD_DRUGLICMANFFORTEST"].ToString();
                    rblScheduleX.SelectedValue = ds.Tables[0].Rows[0]["CFOQD_DRUGLOANLICMANFSHEDULEC"].ToString();
                    rblDrugloanlicmanfnotshedulec.SelectedValue = ds.Tables[0].Rows[0]["CFOQD_DRUGLOANLICMANFNOTSHEDULEC"].ToString();
                    rblDruglicrepacksale.SelectedValue = ds.Tables[0].Rows[0]["CFOQD_DRUGLICREPACKSALE"].ToString();
                    rblDruglicmanfsalevaccnotshedulex.SelectedValue = ds.Tables[0].Rows[0]["CFOQD_DRUGLICMANFSALEVACCNOTSHEDULEX"].ToString();
                    rblProftaxcert.SelectedValue = ds.Tables[0].Rows[0]["CFOQD_PROFTAXCERT"].ToString();
                    rblCFOPCB.SelectedValue = ds.Tables[0].Rows[0]["CFOQD_CFOPCB"].ToString();
                    rblOccupancyCertificate.SelectedValue = ds.Tables[0].Rows[0]["CFOQD_OCCUPANCYCERT"].ToString();
                    rblErectionPermission.SelectedValue = ds.Tables[0].Rows[0]["CFOQD_BOILERSTMPIPELINEERECTION"].ToString();
                    rblPipelineCertificate.SelectedValue = ds.Tables[0].Rows[0]["CFOQD_BOILERSTMPIPELINEREGISTRATION"].ToString();
                    rblShpsestbregformA.SelectedValue = ds.Tables[0].Rows[0]["CFOQD_SHPSESTBREG_FORMA"].ToString();
                    rblBusinesssLic.SelectedValue = ds.Tables[0].Rows[0]["CFOQD_BUSINESSSLIC"].ToString();
                    rblLiquorLic.SelectedValue = ds.Tables[0].Rows[0]["CFOQD_LIQUORLIC"].ToString();
                    rblExciseVerification.SelectedValue = ds.Tables[0].Rows[0]["CFOQD_STATEEXCISEVERFCERT"].ToString();

                    GetApprovals(); 
                }
                else
                {
                    ds.Clear();
                    ds = objcfobal.GetIndustryRegDetails(hdnUserID.Value, UnitID);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        // hdnPreRegUNITID.Value = Convert.ToString(ds.Tables[0].Rows[0]["UNITID"]);
                        hdnPreRegUID.Value = Convert.ToString(ds.Tables[0].Rows[0]["PREREGUIDNO"]);
                        //Session["UNITID"] = hdnPreRegUNITID.Value;
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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }
        }

        protected void rblLicensetoWorkFac_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblLicensetoWorkFac.SelectedValue == "Y")
                {
                    txtPower.Visible = true;
                }
                else { txtPower.Visible = false; }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string Validations1()
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
                //if (string.IsNullOrEmpty(txtSquareMeters.Text) || txtSquareMeters.Text == "" || txtSquareMeters.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Square Meter \\n";
                //    slno = slno + 1;
                //}
                //if (string.IsNullOrEmpty(txtAcres.Text) || txtAcres.Text == "" || txtAcres.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Acrs \\n";
                //    slno = slno + 1;
                //}
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


                if (rblRegMigrantWorkers.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether Registration of Migrant Workers under The Meghalaya Identification, Registration of Migrant Workers Act, 2020 Required or not \\n";
                    slno = slno + 1;
                }
                if (rblRegManfRepairs.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether Registration of Manufacturers / Repairers/Erectors of Boilers Required or not \\n";
                    slno = slno + 1;
                }
                if (rblServicesRenewal.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether Registration of Contractors for Works and services and Renewal Required or not \\n";
                    slno = slno + 1;
                }
                if (rblBoilers.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether Registration of Boiler Required or not \\n";
                    slno = slno + 1;
                }
                if (rblLicensetoWorkFac.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether License to Work as a Factory Required or not \\n";
                    slno = slno + 1;                 
                }
                if (rblLicensetoWorkFac.SelectedValue == "Y")
                {
                    if (ddlPowerReq.SelectedIndex == -1 || ddlPowerReq.SelectedItem.Text == "--Select--")
                    {
                        errormsg = errormsg + slno + ". Please Enter Power Required \\n";
                        slno = slno + 1;
                    }
                }
                if (rblInterstateMigrantWorkmen.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether License for contractors under the Interstate Migrant Workmen Act 1979 Required or not \\n";
                    slno = slno + 1;
                }
                if (rblContractLabourAct1970.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether License for Contractors under the Contract Labour Act 1970 Required or not \\n";
                    slno = slno + 1;
                }
                if (rblWDruglicence.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether Licence for Retail and Wholesale Drug licence Required or not \\n";
                    slno = slno + 1;
                }
                if (rblRPLicenceWeights.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether Licence as Repairers of Weights & Measures Required or not \\n";
                    slno = slno + 1;
                }
                if (rblMFLicenceWeights.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether Licence as Manufacturer of Weights & Measures Required or not \\n";
                    slno = slno + 1;
                }
                if (rblLicenceDealers.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether Licence as Dealers in Weights & Measures Required or not \\n";
                    slno = slno + 1;
                }
                if (rblVerificationInstrument.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether Initial Verification And Stamping of Weighing and Measuring Instrument Required or not \\n";
                    slno = slno + 1;
                }
                if (rblFireSafety.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether Fire Safety Certificate Required or not \\n";
                    slno = slno + 1;
                }
                if (rblExciseLicenseDistillery.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether Excise License for Wholesale, Retail, Bottling, Distillery Plant Required or not \\n";
                    slno = slno + 1;
                }
                if (rblConstitutionLicenceRWD.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether Change of Constitution of Licence for Retail and Wholesale Drug licence Required or not \\n";
                    slno = slno + 1;
                }
                if (rblBrandLabelReg.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether Brand and Label Registration Required or not \\n";
                    slno = slno + 1;
                }
                if (rblPurposeofExamination.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether Application For The Grant/Renewal Of License To Manufacture Drugs For Purpose Of Examination, Test Or Analysis Required or not \\n";
                    slno = slno + 1;
                }
                if (rblScheduleX.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether Application For The Grant Of Loan License To Manufacture For Sale Or For Distribution Of Drugs Specified In Schedule C, C (1) Excluding Those Specified In Part Xb & Schedule X Required or not \\n";
                    slno = slno + 1;
                }
                if (rblDrugloanlicmanfnotshedulec.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether Application For The Grant Of A Loan License To Manufacture For Sale Or For Distribution Of Drugs Other Than That Specified In Schedule C, C(1), X Required or not \\n";
                    slno = slno + 1;
                }
                if (rblDruglicrepacksale.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether Application For The Grant /Renewal Of License To Repack For Sale Or For Distribution Of Drugs Other Than That Specified In Schedule C, C(1) Excluding Those Specified In Schedule X Required or not \\n";
                    slno = slno + 1;
                }
                if (rblDruglicmanfsalevaccnotshedulex.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether Application For The Grant /Renewal Of License To Manufacture For Sale Or For Distribution Of Large Volume Parenterals/Sera And Vaccines Excluding Those Specified In Schedule X Required or not \\n";
                    slno = slno + 1;
                }
                if (rblProftaxcert.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether Application for Certificate of Enrollment of Professional Tax under the Meghalaya Professions Trades Callings and Employment Taxation Rules Required or not \\n";
                    slno = slno + 1;
                }
                if (rblCFOPCB.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether CFO from Pollution Contorl Board Required or not \\n";
                    slno = slno + 1;
                }
                if (rblOccupancyCertificate.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether Occupancy Certificate Required or not \\n";
                    slno = slno + 1;
                }
                if (rblErectionPermission.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether Boilers Steam Pipeline Erection Permission Certificate from Boilers Department Required or not \\n";
                    slno = slno + 1;
                }
                if (rblPipelineCertificate.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether Boilers Steam Pipeline Registration Number Certificate Required or not \\n";
                    slno = slno + 1;
                }
                if (rblShpsestbregformA.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether Registration of Shops and Establishment - FORM - A Required or not \\n";
                    slno = slno + 1;
                }
                if (rblBusinesssLic.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether Application for grant of Business License Required or not \\n";
                    slno = slno + 1;
                }
                if (rblLiquorLic.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether License for Local Sale, Import and Export Permit of Spirit and Indian-made foreign liquor (IMFL) Required or not \\n";
                    slno = slno + 1;
                }
                if (rblExciseVerification.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Whether State Excise - Excise Verification Certificate Required or not \\n";
                    slno = slno + 1;
                }

                return errormsg;


            }
            catch (Exception ex)
            {
                throw ex;
                //lblmsg0.Text = ex.Message; Failure.Visible = true;
            }
        }
    }
}