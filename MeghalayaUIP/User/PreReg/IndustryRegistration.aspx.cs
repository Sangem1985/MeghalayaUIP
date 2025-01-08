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
using System.IO;
using System.Text.RegularExpressions;
using MeghalayaUIP.CommonClass;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web.Services.Description;
using System.Configuration;
using static AjaxControlToolkit.AsyncFileUpload.Constants;
using System.Web.Mail;

namespace MeghalayaUIP.User.PreReg
{
    public partial class IndustryRegistration : System.Web.UI.Page
    {
        int index; string ErrorMsg1 = "", ErrorMsg2 = "", ErrorMsg3 = "", ErrorMsg4 = "";
        protected string Aadhar;
        readonly LoginBAL objloginBAL = new LoginBAL();
        MasterBAL mstrBAL = new MasterBAL();
        PreRegBAL indstregBAL = new PreRegBAL();
        SMSandMail smsMail = new SMSandMail();
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
                        txtPANno.Text = ObjUserInfo.PANno;
                        txtPANno.Enabled = false;
                        txtUnitName.Text = ObjUserInfo.EntityName;
                        txtAuthReprEmail.Text = ObjUserInfo.Email;
                        //txtUnitName.Enabled = false;
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

                        CalendarExtender1.EndDate = DateTime.Now;

                        MVprereg.ActiveViewIndex = index;
                        BindCountries();
                        BindStates();
                        BindDistricts();
                        BindConstitutionType();
                        BindRevenueProjectionsMaster();
                        BindSectors();
                        BindRegistrationType();
                        BindData();
                    }
                    if (IsPostBack)
                    {
                        if (txtApplAadhar.Text.Trim() != "")
                            txtApplAadhar.Attributes["value"] = txtApplAadhar.Text;
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
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
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
                            ddlcompanytype.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["COMPANYTYPE"]);
                            ddlproposal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["COMPANYPRAPOSAL"]);
                            txtCompnyRegDt.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["REGISTRATIONDATE"]).ToString("dd-MM-yyyy");
                            txtGSTNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["GSTNNO"]);
                            ddlRegType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["COMPANYREGTYPE"]);
                            ddlRegType_SelectedIndexChanged(null, EventArgs.Empty);
                            txtUdyamorIEMNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["UDYAMNO"]);
                            //txtCompnyRegDt.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["REGISTRATIONDATE"]).ToString("dd-MM-yyyy");
                            txtAuthReprName.Text = Convert.ToString(ds.Tables[0].Rows[0]["REP_NAME"]);
                            txtAuthReprMobile.Text = Convert.ToString(ds.Tables[0].Rows[0]["REP_MOBILE"]);
                            txtAuthReprEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["REP_EMAIL"]);
                            txtAuthReprLocality.Text = Convert.ToString(ds.Tables[0].Rows[0]["REP_LOCALITY"]);
                            txtAuthReprDoorNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["REP_DOORNO"]);
                            ddlstate.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["STATEID"]);
                            ddlstate_SelectedIndexChanged(null, EventArgs.Empty);

                            if (ddlstate.SelectedItem.Text == "Meghalaya")
                            {
                                Dist1.Visible = true;
                                Mandal1.Visible = true;
                                villages1.Visible = true;
                                District.Visible = false;
                                Div1.Visible = false;
                                Div2.Visible = false;

                                ddlAuthReprDist.SelectedValue = ds.Tables[0].Rows[0]["REP_DISTRICTID"].ToString();
                                ddlAuthReprDist_SelectedIndexChanged(null, EventArgs.Empty);
                                ddlAuthReprTaluka.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["REP_MANDALID"]);
                                ddlAuthReprTaluka_SelectedIndexChanged(null, EventArgs.Empty);
                                ddlAuthReprVillage.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["REP_VILLAGEID"]);

                            }
                            else
                            {
                                District.Visible = true;
                                Div1.Visible = true;
                                Div2.Visible = true;
                                Dist1.Visible = false;
                                Mandal1.Visible = false;
                                villages1.Visible = false;
                                //trotherstate.Visible = true;
                                //otherDistric.Visible = false;
                                txtDistricted.Text = ds.Tables[0].Rows[0]["REP_DISTRICTNAME"].ToString();
                                txtMandaled.Text = ds.Tables[0].Rows[0]["REP_MANDALNAME"].ToString();
                                txtVillagede.Text = ds.Tables[0].Rows[0]["REP_VILLAGENAME"].ToString();
                            }

                            txtAuthReprPincode.Text = Convert.ToString(ds.Tables[0].Rows[0]["REP_PINCODE"]);

                            rblLandType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["UNIT_LANDTYPE"]);
                            rblLandType_SelectedIndexChanged(null, EventArgs.Empty);

                            txtPropLocDoorno.Text = Convert.ToString(ds.Tables[0].Rows[0]["UNIT_DOORNO"]);
                            txtPropLocLocality.Text = Convert.ToString(ds.Tables[0].Rows[0]["UNIT_LOCALITY"]);
                            ddlPropLocDist.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["UNIT_DISTRICTID"]);
                            ddlPropLocDist_SelectedIndexChanged(this, EventArgs.Empty);
                            ddlPropLocTaluka.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["UNIT_MANDALID"]);
                            ddlPropLocTaluka_SelectedIndexChanged(this, EventArgs.Empty);
                            ddlPropLocVillage.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["UNIT_VILLAGEID"]);
                            txtPropLocPincode.Text = Convert.ToString(ds.Tables[0].Rows[0]["UNIT_PINCODE"]);
                            txtDCPorOperation.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["PROJECT_DCP"]).ToString("dd-MM-yyyy");
                            ddlSector.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_SECTORNAME"]);
                            ddlSector_SelectedIndexChanged(null, EventArgs.Empty);
                            ddlLineOfActivity.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_LOAID"]);
                            lblPCBCategory.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_PCBCATEGORY"]);
                            rblNatureofActvty.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_NOA"]);
                            rblNatureofActvty_SelectedIndexChanged(null, EventArgs.Empty);

                            txtMainManf.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_MANFACTIVITY"]);
                            txtManfprodct.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_MANFPRODUCT"]);
                            txtProductionNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_MANFPRODNO"]);
                            txtAnnualCapacity.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_ANNUALCAPACITY"]);
                            txtRawmaterial.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_MAINRM"]);
                            txtMeasurementUnits.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_UNITOFMEASURE"]);

                            txtServcActvty.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_SRVCACTIVITY"]);
                            txtServctobeprovded.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_SRVCNAME"]);
                            txtSrviceno.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_SRVCNO"]);

                            txtWasteDetails.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_WASTEDETAILS"]);
                            txtHazWasteDetails.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_HAZWASTEDETAILS"]);

                            txtCivilConstr.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_CIVILCONSTR"]);
                            txtLandAreainSqft.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_LANDAREA"]);
                            txtBuildingAreaSqm.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_BUILDINGAREA"]);
                            txtPowerReqKV.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_POWERRREQ"]);
                            txtWaterReqKLD.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROJECT_WATERREQ"]);
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
                            txtEquityAmount.Text = Convert.ToString(ds.Tables[0].Rows[0]["FRD_EQUITY"]);
                            txtInternalResources.Text = Convert.ToString(ds.Tables[0].Rows[0]["FRD_INTERNALRESOURCE"]);
                            txtUnsecuredLoan.Text = Convert.ToString(ds.Tables[0].Rows[0]["FRD_UNSECUREDLOAN"]);
                            txtUNNATI.Text = Convert.ToString(ds.Tables[0].Rows[0]["FRD_UNNATI"]);
                            txtstatescheme.Text = Convert.ToString(ds.Tables[0].Rows[0]["FRD_STATE"]);
                            txtcentral.Text = Convert.ToString(ds.Tables[0].Rows[0]["FRD_CENTRAL"]);
                        }
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            DataTable dt = ds.Tables[1];
                            ViewState["RevProj"] = dt;

                            grdRevenueProj.Visible = true;
                            grdRevenueProj.DataSource = dt;
                            grdRevenueProj.DataBind();
                            hdnResultTab2.Value = "1";

                        }
                        if (ds.Tables[2].Rows.Count > 0)
                        {
                            DataTable dt = ds.Tables[2];
                            ViewState["PromtrsTable"] = dt;
                            hdnResultTab3.Value = "1";

                            gvPromoters.Visible = true;
                            gvPromoters.DataSource = dt;
                            gvPromoters.DataBind();
                            btnPreview.Enabled = true;

                        }
                        if (ds.Tables[3].Rows.Count > 0)
                        {
                            int c = ds.Tables[3].Rows.Count;
                            string sen, sen1, sen2;
                            int i = 0;

                            DataTable dt1 = new DataTable();
                            dt1.Columns.Add("link");
                            dt1.Columns.Add("FileName");

                            DataTable dt2 = new DataTable();
                            dt2.Columns.Add("link");
                            dt2.Columns.Add("FileName");

                            while (i < c)
                            {
                                sen2 = ds.Tables[3].Rows[i][0].ToString();
                                sen1 = sen2.Replace(@"\", @"/");
                                sen = sen1.Replace(@"D:/Meghalaya/", "~/");

                                if (sen.Contains("DPR"))
                                {
                                    hypdpr.Visible = true;
                                    hypdpr.Text = ds.Tables[3].Rows[i][1].ToString();
                                    lbldpr.Text = ds.Tables[3].Rows[i][1].ToString();
                                    hypdpr.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(sen);
                                }
                                if (sen.Contains("CompanyRegistration"))
                                {
                                    hplcompanyregistration.Visible = true;
                                    hplcompanyregistration.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(sen);
                                    hplcompanyregistration.Text = ds.Tables[3].Rows[i][1].ToString();

                                }
                                if (sen.Contains("UdyamRegistration"))
                                {
                                    hplUdyam.Visible = true;
                                    hplUdyam.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(sen);
                                    hplUdyam.Text = ds.Tables[3].Rows[i][1].ToString();

                                }
                                if (sen.Contains("PAN"))
                                {
                                    hplPAN.Visible = true;
                                    hplPAN.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(sen);
                                    hplPAN.Text = ds.Tables[3].Rows[i][1].ToString();
                                    hplPAN.Text = ds.Tables[3].Rows[i][1].ToString();

                                }
                                if (sen.Contains("GSTIN"))
                                {
                                    hplGSTIN.Visible = true;
                                    hplGSTIN.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(sen);
                                    hplGSTIN.Text = ds.Tables[3].Rows[i][1].ToString();
                                    hplGSTIN.Text = ds.Tables[3].Rows[i][1].ToString();

                                }
                                if (sen.Contains("CIN"))
                                {
                                    hplCIN.Visible = true;
                                    hplCIN.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(sen);
                                    hplCIN.Text = ds.Tables[3].Rows[i][1].ToString();
                                    hplCIN.Text = ds.Tables[3].Rows[i][1].ToString();
                                }
                                if (sen.Contains("BankAppraisal"))
                                {
                                    hplBankAppraisal.Visible = true;
                                    hplBankAppraisal.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(sen);
                                    hplBankAppraisal.Text = ds.Tables[3].Rows[i][1].ToString();
                                    hplBankAppraisal.Text = ds.Tables[3].Rows[i][1].ToString();
                                }

                                i++;
                            }


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
        protected void BindConstitutionType()
        {
            try
            {
                ddlcompanytype.Items.Clear();

                List<MasterConstType> objConsttype = new List<MasterConstType>();

                objConsttype = mstrBAL.GetConstitutionType();
                if (objConsttype != null)
                {
                    ddlcompanytype.DataSource = objConsttype;
                    ddlcompanytype.DataValueField = "ConstId";
                    ddlcompanytype.DataTextField = "ConstName";
                    ddlcompanytype.DataBind();
                }
                else
                {
                    ddlcompanytype.DataSource = null;
                    ddlcompanytype.DataBind();
                }
                AddSelect(ddlcompanytype);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindStates()
        {
            try
            {
                ddlApplState.Items.Clear();
                ddlstate.Items.Clear();

                List<MasterStates> objStatesModel = new List<MasterStates>();

                objStatesModel = mstrBAL.GetStates();
                if (objStatesModel != null)
                {
                    ddlApplState.DataSource = objStatesModel;
                    ddlApplState.DataValueField = "StateId";
                    ddlApplState.DataTextField = "StateName";
                    ddlApplState.DataBind();

                    ddlstate.DataSource = objStatesModel;
                    ddlstate.DataValueField = "StateId";
                    ddlstate.DataTextField = "StateName";
                    ddlstate.DataBind();
                }
                else
                {
                    ddlApplState.DataSource = null;
                    ddlApplState.DataBind();

                    ddlstate.DataSource = null;
                    ddlstate.DataBind();
                }
                AddSelect(ddlApplState);
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
        protected void BindSectors()
        {
            try
            {
                ddlSector.Items.Clear();
                lblPCBCategory.Text = "";
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
                lblPCBCategory.Text = "";
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
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
        protected void ddlRegType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlRegType.SelectedItem.Text.Trim() != "--Select--")
                {
                    txtUdyamorIEMNo.Enabled = true;
                    lblregntype.InnerText = ddlRegType.SelectedItem.Text.Trim() + " No ";
                    txtUdyamorIEMNo.Text = "";
                    ddlRegType.BorderColor = System.Drawing.Color.Black;

                }
                else
                {
                    txtUdyamorIEMNo.Enabled = false;
                    lblregntype.InnerText = " Registration No *";
                    txtUdyamorIEMNo.Text = "";
                    ddlRegType.BorderColor = System.Drawing.Color.Red;
                }

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
                    ddlLineOfActivity.Items.Clear();
                    AddSelect(ddlLineOfActivity);
                    lblPCBCategory.Text = "";
                    BindLineOfActivity(ddlSector.SelectedItem.Text);
                    if (ddlSector.SelectedItem.Text.Trim() == "Cement, Cement & Concrete Products, Fly Ash Bricks")
                    {
                        eligible.Visible = true;
                    }
                    else
                    {
                        eligible.Visible = false;
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
        protected void ddlLineOfActivity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlLineOfActivity.SelectedItem.Text != "--Select--")
                {
                    lblPCBCategory.Text = mstrBAL.GetPCBCategory(ddlLineOfActivity.SelectedValue);
                    ddlLineOfActivity.BorderColor = System.Drawing.Color.Black;

                }
                else
                {
                    ddlLineOfActivity.BorderColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {

                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }
        protected void ddlAuthReprDist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlAuthReprTaluka.ClearSelection();
                ddlAuthReprTaluka.Items.Clear();
                AddSelect(ddlAuthReprTaluka);
                ddlAuthReprVillage.ClearSelection();
                ddlAuthReprVillage.Items.Clear();
                AddSelect(ddlAuthReprVillage);
                if (ddlAuthReprDist.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlAuthReprTaluka, ddlAuthReprDist.SelectedValue);
                    ddlAuthReprDist.BorderColor = System.Drawing.Color.Black;
                }
                else ddlAuthReprDist.BorderColor = System.Drawing.Color.Red; return;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }
        protected void ddlAuthReprTaluka_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlAuthReprVillage.ClearSelection();
                ddlAuthReprVillage.Items.Clear();
                AddSelect(ddlAuthReprVillage);

                if (ddlAuthReprTaluka.SelectedItem.Text != "--Select--")
                {
                    BindVillages(ddlAuthReprVillage, ddlAuthReprTaluka.SelectedValue);
                    ddlAuthReprTaluka.BorderColor = System.Drawing.Color.Black;
                }
                else
                {
                    ddlAuthReprTaluka.BorderColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }
        protected void ddlPropLocDist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlPropLocTaluka.ClearSelection();
                ddlPropLocTaluka.Items.Clear();
                AddSelect(ddlPropLocTaluka);

                ddlPropLocVillage.ClearSelection();
                ddlPropLocVillage.Items.Clear();
                AddSelect(ddlPropLocVillage);

                if (ddlPropLocDist.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlPropLocTaluka, ddlPropLocDist.SelectedValue);
                    ddlPropLocDist.BorderColor = System.Drawing.Color.Black;
                }
                else ddlPropLocDist.BorderColor = System.Drawing.Color.Red; return;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void ddlPropLocTaluka_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlPropLocVillage.ClearSelection();
                ddlPropLocVillage.Items.Clear();
                AddSelect(ddlPropLocVillage);

                if (ddlPropLocTaluka.SelectedItem.Text != "--Select--")
                {
                    BindVillages(ddlPropLocVillage, ddlPropLocTaluka.SelectedValue);
                    ddlPropLocTaluka.BorderColor = System.Drawing.Color.Black;
                }
                else
                {
                    ddlPropLocTaluka.BorderColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void rblNatureofActvty_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblNatureofActvty.SelectedItem.Text == "Manufacturing")
                {
                    divManf.Visible = true;
                    divManf1.Visible = true;
                    divservc.Visible = false;
                    txtServcActvty.Text = "";
                    txtServctobeprovded.Text = "";
                    txtSrviceno.Text = "";
                }
                else if (rblNatureofActvty.SelectedItem.Text == "Service")
                {
                    divservc.Visible = true;
                    divManf.Visible = false;
                    divManf1.Visible = false;
                    txtMainManf.Text = "";
                    txtManfprodct.Text = "";
                    txtRawmaterial.Text = "";
                    txtAnnualCapacity.Text = "";
                    txtMeasurementUnits.Text = "";
                    txtProductionNo.Text = "";
                }



            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblNatureofActvty.BorderColor = System.Drawing.Color.White;
        }
        protected void rblLandType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblLandType.SelectedValue == "Own")
                { txtPropLocDoorno.Enabled = true; }
                else if (rblLandType.SelectedValue == "Required")
                {
                    txtPropLocDoorno.Enabled = false;
                    txtPropLocDoorno.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblLandType.BorderColor = System.Drawing.Color.White;
        }
        protected void txtCompnyRegDt_TextChanged(object sender, EventArgs e)
        {
            CheckDates(txtCompnyRegDt);
        }
        protected void txtDCPorOperation_TextChanged(object sender, EventArgs e)
        {
            CheckDates(txtDCPorOperation);
        }
        public void CheckDates(TextBox TextDate)
        {
            try
            {
                if (txtCompnyRegDt.Text != "" && txtDCPorOperation.Text != "")
                {
                    DateTime RegDate, DCPDate;
                    //bool RegDate1 = DateTime.TryParseExact(txtCompnyRegDt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out RegDate);
                    //bool DCPDate1 = DateTime.TryParseExact(txtDCPorOperation.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DCPDate);

                    RegDate = DateTime.ParseExact(txtCompnyRegDt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    DCPDate = DateTime.ParseExact(txtDCPorOperation.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    if (RegDate > DCPDate)
                    {
                        TextDate.Text = "";
                        string msg = "alert('" + "Company Registration Date should be before the Date of Commencement of Production /Operation" + "')";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", msg, true);
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

        //---------------------------------Step 1 Code ---------------------------//
        protected void btnsave1_Click(object sender, EventArgs e)
        {
            try
            {

                int result = 0;
                ErrorMsg1 = Step1validations();
                if (ErrorMsg1 == "")
                {
                    result = SaveBasicDetails();
                    if (result != 100)
                    {
                        ViewState["UnitID"] = result;
                        lblmsg.Text = "Basic Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                    else
                    {
                        success.Visible = true;
                        lblmsg.Text = "Error Occured while saving please try again";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                    }
                }
                else
                {
                    string message = "alert('" + ErrorMsg1 + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
            }
            catch (SqlException ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }
        public string Step1validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                List<TextBox> emptyTextboxes = FindEmptyTextboxes(divText);
                List<DropDownList> emptyDropdowns = FindEmptyDropdowns(divText);
                List<RadioButtonList> emptyRadioButtonLists = FindEmptyRadioButtonLists(divText);
                //CheckRadio(divText);


                if (ddlcompanytype.SelectedValue == "0" || ddlcompanytype.SelectedValue == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Company Type\\n";
                    slno = slno + 1;
                }
                if (ddlproposal.SelectedValue == "0" || ddlproposal.SelectedValue == "--Select--" || ddlproposal.SelectedValue == "")
                {
                    errormsg = errormsg + slno + ". Please Select Company Proposal\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtGSTNo.Text) || txtGSTNo.Text == "" || txtGSTNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter GST Number \\n";
                    slno = slno + 1;
                }

                if (ddlRegType.SelectedValue == "0" || ddlRegType.SelectedValue == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Category of Registration\\n";
                    slno = slno + 1;
                }
                if (ddlRegType.SelectedValue == "1" && string.IsNullOrEmpty(txtUdyamorIEMNo.Text))
                {
                    errormsg = errormsg + slno + ". Please Enter Prov.SSI No\\n";
                    slno = slno + 1;
                }
                if (ddlRegType.SelectedValue == "2" && string.IsNullOrEmpty(txtUdyamorIEMNo.Text))
                {
                    errormsg = errormsg + slno + ". Please Enter IME No\\n";
                    slno = slno + 1;
                }
                if (ddlRegType.SelectedValue == "3" && string.IsNullOrEmpty(txtUdyamorIEMNo.Text))
                {
                    errormsg = errormsg + slno + ". Please Enter EOU No\\n";
                    slno = slno + 1;
                }
                if (ddlRegType.SelectedValue == "4" && string.IsNullOrEmpty(txtUdyamorIEMNo.Text))
                {
                    errormsg = errormsg + slno + ". Please Enter LOI No\\n";
                    slno = slno + 1;
                }
                if (ddlRegType.SelectedValue == "5" && string.IsNullOrEmpty(txtUdyamorIEMNo.Text))
                {
                    errormsg = errormsg + slno + ". Please Enter EM Part-II No\\n";
                    slno = slno + 1;
                }
                if (ddlRegType.SelectedValue == "6" && string.IsNullOrEmpty(txtUdyamorIEMNo.Text))
                {
                    errormsg = errormsg + slno + ". Please Enter Udyog Aadhar No\\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtCompnyRegDt.Text) || txtCompnyRegDt.Text == "" || txtCompnyRegDt.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Select Company Registration /Incorporation Date \\n";
                    slno = slno + 1;
                }


                if (string.IsNullOrEmpty(txtAuthReprName.Text) || txtAuthReprName.Text == "" || txtAuthReprName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enteror Authorised Representative Name \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAuthReprMobile.Text) || txtAuthReprMobile.Text == "" || txtAuthReprMobile.Text == null || txtAuthReprMobile.Text.Length != 10 || txtAuthReprMobile.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtAuthReprMobile.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Authorised Representative Mobile Number \\n";
                    slno = slno + 1;
                }


                if (string.IsNullOrEmpty(txtAuthReprEmail.Text) || txtAuthReprEmail.Text == "" || txtAuthReprEmail.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Authorised Representative Email \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAuthReprLocality.Text.Trim()) || txtAuthReprLocality.Text.Trim() == "" || txtAuthReprLocality.Text.Trim() == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Authorised Representative Locality \\n";
                    slno = slno + 1;
                }
                if (ddlstate.SelectedValue == "0" || ddlstate.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select State \\n";
                    slno = slno + 1;
                }
                if (ddlstate.SelectedValue == "23")
                {
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
                }
                else if (ddlstate.SelectedValue != "23" && ddlstate.SelectedValue != "0")
                {
                    if (string.IsNullOrEmpty(txtDistricted.Text) || txtDistricted.Text == "" || txtDistricted.Text == null || txtDistricted.Text.Length != 6 || txtDistricted.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtDistricted.Text, @"^0+(\.0+)?$"))
                    {
                        errormsg = errormsg + slno + ". Please Enter Authorised Representative District...! \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtMandaled.Text) || txtMandaled.Text == "" || txtMandaled.Text == null || txtMandaled.Text.Length != 6 || txtMandaled.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtMandaled.Text, @"^0+(\.0+)?$"))
                    {
                        errormsg = errormsg + slno + ". Please Enter Authorised Representative Mandal...! \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtVillagede.Text) || txtVillagede.Text == "" || txtVillagede.Text == null || txtVillagede.Text.Length != 6 || txtVillagede.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtVillagede.Text, @"^0+(\.0+)?$"))
                    {
                        errormsg = errormsg + slno + ". Please Enter Authorised Representative Village...! \\n";
                        slno = slno + 1;
                    }
                }

                if (string.IsNullOrEmpty(txtAuthReprDoorNo.Text.Trim()) || txtAuthReprDoorNo.Text.Trim() == "" || txtAuthReprDoorNo.Text.Trim() == null || txtAuthReprDoorNo.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtAuthReprDoorNo.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Authorised Representative Door No \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtAuthReprPincode.Text) || txtAuthReprPincode.Text == "" || txtAuthReprPincode.Text == null || txtAuthReprPincode.Text.Length != 6 || txtAuthReprPincode.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtAuthReprPincode.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Authorised Representative PinCode \\n";
                    slno = slno + 1;
                }

                if (rblLandType.SelectedValue == "0" || rblLandType.SelectedValue == "--Select--" || rblLandType.SelectedValue == "")
                {
                    errormsg = errormsg + slno + ". Please Select Land Required Type \\n";
                    slno = slno + 1;
                }
                if (rblLandType.SelectedValue == "Own")
                {
                    if (string.IsNullOrEmpty(txtPropLocDoorno.Text.Trim()) || txtPropLocDoorno.Text.Trim() == "" || txtPropLocDoorno.Text.Trim() == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Unit Door number \\n";
                        slno = slno + 1;
                    }
                }
                if (string.IsNullOrEmpty(txtPropLocLocality.Text.Trim()) || txtPropLocLocality.Text.Trim() == "" || txtPropLocLocality.Text.Trim() == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Unit Locality \\n";
                    slno = slno + 1;
                }
                if (ddlPropLocDist.SelectedIndex == -1 || ddlPropLocDist.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Unit District \\n";
                    slno = slno + 1;
                }
                if (ddlPropLocTaluka.SelectedIndex == -1 || ddlPropLocTaluka.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Unit Mandal/Taluka \\n";
                    slno = slno + 1;
                }
                if (ddlPropLocVillage.SelectedIndex == -1 || ddlPropLocVillage.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Unit Village \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPropLocPincode.Text) || txtPropLocPincode.Text == "" || txtPropLocPincode.Text == null || txtPropLocPincode.Text.Length != 6 || txtPropLocPincode.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtPropLocPincode.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Unit PinCode \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtDCPorOperation.Text) || txtDCPorOperation.Text == "" || txtDCPorOperation.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Select Date of Commencement of Production /Operation \\n";
                    slno = slno + 1;
                }
                if (txtDCPorOperation.Text != "" && txtCompnyRegDt.Text != "")
                {
                    if (DateTime.ParseExact(txtCompnyRegDt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(txtDCPorOperation.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                    {
                        errormsg = errormsg + slno + ". Company Registration Date should be before the Date of Commencement of Production /Operation \\n";
                        slno = slno + 1;
                    }
                }
                if (rblNatureofActvty.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Nature of Activity \\n";
                    slno = slno + 1;
                }
                if (rblNatureofActvty.SelectedValue == "Manufacturing")
                {
                    if (string.IsNullOrEmpty(txtMainManf.Text.Trim()) || txtMainManf.Text.Trim() == "" || txtMainManf.Text.Trim() == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Main Manufacturing Activity \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtManfprodct.Text.Trim()) || txtManfprodct.Text.Trim() == "" || txtManfprodct.Text.Trim() == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Product to be Manufactured \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtRawmaterial.Text.Trim()) || txtRawmaterial.Text.Trim() == "" || txtRawmaterial.Text.Trim() == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Main Raw Materials details \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtAnnualCapacity.Text) || txtAnnualCapacity.Text == "" || txtAnnualCapacity.Text == null || txtAnnualCapacity.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtAnnualCapacity.Text, @"^0+(\.0+)?$"))
                    {
                        errormsg = errormsg + slno + ". Please Enter Annual Capacity \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtMeasurementUnits.Text.Trim()) || txtMeasurementUnits.Text.Trim() == "" || txtMeasurementUnits.Text.Trim() == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Unit of measurement \\n";
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
                if (string.IsNullOrEmpty(txtWasteDetails.Text.Trim()) || txtWasteDetails.Text.Trim() == "" || txtWasteDetails.Text.Trim() == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Details of waste / effluent to be generated \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtHazWasteDetails.Text.Trim()) || txtHazWasteDetails.Text.Trim() == "" || txtHazWasteDetails.Text.Trim() == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Details of hazardous waste to be generated \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtCivilConstr.Text) || txtCivilConstr.Text == "" || txtCivilConstr.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Civil Construction details \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEstimatedProjCost.Text) || txtEstimatedProjCost.Text == "" || txtEstimatedProjCost.Text == null || txtEstimatedProjCost.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtEstimatedProjCost.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Estimated Project Cost  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLandAreainSqft.Text) || txtLandAreainSqft.Text == "" || txtLandAreainSqft.Text == null || txtLandAreainSqft.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtLandAreainSqft.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Land area in (in Sq.ft) \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLandValue.Text) || txtLandValue.Text == "" || txtLandValue.Text == null || txtLandValue.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtLandValue.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Value of LAND \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtWaterReqKLD.Text) || txtWaterReqKLD.Text == "" || txtWaterReqKLD.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Water required (KL/D) \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtWaterValue.Text) || txtWaterValue.Text == "" || txtWaterValue.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Water Value \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPlantnMachineryCost.Text) || txtPlantnMachineryCost.Text == "" || txtPlantnMachineryCost.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Plant & Machinery Cost \\n";
                    slno = slno + 1;
                }


                if (string.IsNullOrEmpty(txtBuildingAreaSqm.Text) || txtBuildingAreaSqm.Text == "" || txtBuildingAreaSqm.Text == null || txtBuildingAreaSqm.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtBuildingAreaSqm.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Area of Building / Shed \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtBuildingValue.Text) || txtBuildingValue.Text == "" || txtBuildingValue.Text == null || txtBuildingValue.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtBuildingValue.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Value of Building / Shed \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPowerReqKV.Text) || txtPowerReqKV.Text == "" || txtPowerReqKV.Text == null || txtPowerReqKV.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtPowerReqKV.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Power Required (KV) \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtElectricityValue.Text) || txtElectricityValue.Text == "" || txtElectricityValue.Text == null || txtElectricityValue.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtElectricityValue.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Value of Power  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtCapitalInvestment.Text) || txtCapitalInvestment.Text == "" || txtCapitalInvestment.Text == null || txtCapitalInvestment.Text.All(c => c == '0' || System.Text.RegularExpressions.Regex.IsMatch(txtCapitalInvestment.Text, @"^0+(\.0+)?$")))
                {
                    errormsg = errormsg + slno + ". Please Enter Investment in Fixed Capital \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtFixedAssets.Text) || txtFixedAssets.Text == "" || txtFixedAssets.Text == null || txtFixedAssets.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtFixedAssets.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Durable Fixed Assets \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtWorkingCapital.Text) || txtWorkingCapital.Text == "" || txtWorkingCapital.Text == null || txtWorkingCapital.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtWorkingCapital.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Working Capital \\n";
                    slno = slno + 1;
                }


                //if (string.IsNullOrEmpty(txtPromoterEquity.Text) || txtPromoterEquity.Text == "" || txtPromoterEquity.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Promoter’s and Contributors (INR) \\n";
                //    slno = slno + 1;
                //}
                if (string.IsNullOrEmpty(txtEquityAmount.Text) || txtEquityAmount.Text == "" || txtEquityAmount.Text == null || txtEquityAmount.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtEquityAmount.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Equity Amount (INR) \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLoanAmount.Text) || txtLoanAmount.Text == "" || txtLoanAmount.Text == null || txtLoanAmount.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtLoanAmount.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Term/ Working loan (INR) \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtUnsecuredLoan.Text) || txtUnsecuredLoan.Text == "" || txtUnsecuredLoan.Text == null || txtUnsecuredLoan.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtUnsecuredLoan.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Unsecured Loan (INR)\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtInternalResources.Text) || txtInternalResources.Text == "" || txtInternalResources.Text == null || txtInternalResources.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtInternalResources.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Internal Resources (INR)\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtstatescheme.Text) || txtstatescheme.Text == "" || txtstatescheme.Text == null || txtstatescheme.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtstatescheme.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter State Scheme (INR)\\n";
                    slno = slno + 1;
                }
                //if (string.IsNullOrEmpty(txtCapitalSubsidy.Text) || txtCapitalSubsidy.Text == "" || txtCapitalSubsidy.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Capital Subsidy (INR)\\n";
                //    slno = slno + 1;
                //}
                if (string.IsNullOrEmpty(txtUNNATI.Text) || txtUNNATI.Text == "" || txtUNNATI.Text == null || txtUNNATI.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtUNNATI.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Benefits from UNNATI (INR)\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtcentral.Text) || txtcentral.Text == "" || txtcentral.Text == null || txtcentral.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtcentral.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Central Scheme (INR)\\n";
                    slno = slno + 1;
                }

                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int SaveBasicDetails()
        {
            IndustryDetails ID = new IndustryDetails();
            if (Convert.ToString(ViewState["UnitID"]) != "")
            { ID.UnitID = Convert.ToString(ViewState["UnitID"]); }
            ID.UserID = hdnUserID.Value;
            ID.IPAddress = getclientIP();

            ID.CompanyName = txtUnitName.Text.Trim();
            ID.CompanyPAN = txtPANno.Text.Trim();
            ID.CompnyRegDt = txtCompnyRegDt.Text.Trim();
            ID.CompnyType = ddlcompanytype.SelectedValue;
            ID.CompnyProposal = ddlproposal.SelectedItem.Text.Trim();
            ID.UdyamorIEMNo = txtUdyamorIEMNo.Text.Trim();
            ID.GSTNo = txtGSTNo.Text.Trim();

            ID.AuthReprName = txtAuthReprName.Text.Trim();
            ID.AuthReprMobile = txtAuthReprMobile.Text.Trim();
            ID.AuthReprEmail = txtAuthReprEmail.Text.Trim();
            ID.AuthReprLocality = txtAuthReprLocality.Text.Trim();
            ID.REP_STATEID = ddlstate.SelectedValue;
            ID.AuthReprDistID = ddlAuthReprDist.SelectedValue.Trim();
            ID.AuthReprTalukaID = ddlAuthReprTaluka.SelectedValue;
            ID.AuthReprVillageID = ddlAuthReprVillage.SelectedValue;
            ID.AuthReprPincode = txtAuthReprPincode.Text.Trim();
            ID.REP_DISTRICNAME = txtDistricted.Text.Trim();
            ID.REP_MANDALNAME = txtMandaled.Text.Trim();
            ID.REP_VILLAGENAME = txtVillagede.Text.Trim();



            ID.LandType = rblLandType.SelectedValue;
            ID.PropLocDoorno = txtPropLocDoorno.Text.Trim();
            ID.PropLocLocality = txtPropLocLocality.Text.Trim();
            ID.PropLocDistID = ddlPropLocDist.SelectedValue;
            ID.PropLocTalukaID = ddlPropLocTaluka.SelectedValue;
            ID.PropLocVillageID = ddlPropLocVillage.SelectedValue;
            ID.PropLocPincode = txtPropLocPincode.Text.Trim();

            ID.DCPorOperation = txtDCPorOperation.Text.Trim();
            ID.SectorName = ddlSector.SelectedItem.Text;
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
            ID.EquityAmount = txtEquityAmount.Text.Trim();
            ID.UnsecuredLoan = txtUnsecuredLoan.Text.Trim();
            ID.InternalResources = txtInternalResources.Text.Trim();
            ID.CetralSchemeAmount = txtcentral.Text.Trim();
            ID.UnnatiSchemeAmount = txtUNNATI.Text.Trim();
            ID.StateSchemeAmount = txtstatescheme.Text.Trim();
            ID.DoorNo = txtAuthReprDoorNo.Text.Trim();
            ID.RegistrationNo = txtUdyamorIEMNo.Text.Trim();
            ID.RegistrationType = ddlRegType.SelectedValue;
            if (eligible.Visible == false)
            {
                ID.EligibleFlag = "Y";
            }
            else
            {
                ID.EligibleFlag = "N";
            }
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            int result = indstregBAL.InsertIndRegBasicDetails(ID);
            return result;

        }

        //---------------------------------Step 2 Code ---------------------------//
        protected void grdRevenueProj_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataTable dt = (DataTable)ViewState["RevProj"];

                    if (dt != null)
                    {
                        if (e.Row.RowIndex < 13)
                        {
                            GridViewRow gvr = e.Row;
                            TextBox Year1 = (TextBox)gvr.FindControl("txtYear1");
                            TextBox Year2 = (TextBox)gvr.FindControl("txtYear2");
                            TextBox Year3 = (TextBox)gvr.FindControl("txtYear3");
                            TextBox Year4 = (TextBox)gvr.FindControl("txtYear4");
                            TextBox Year5 = (TextBox)gvr.FindControl("txtYear5");

                            Year1.Text = dt.Rows[e.Row.RowIndex]["YEAR1"].ToString();
                            Year2.Text = dt.Rows[e.Row.RowIndex]["YEAR2"].ToString();
                            Year3.Text = dt.Rows[e.Row.RowIndex]["YEAR3"].ToString();
                            Year4.Text = dt.Rows[e.Row.RowIndex]["YEAR4"].ToString();
                            Year5.Text = dt.Rows[e.Row.RowIndex]["YEAR5"].ToString();
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
        protected void btnsave2_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";

                if (Convert.ToString(ViewState["UnitID"]) != "")
                {
                    ErrorMsg2 = Step2validations();
                    if (ErrorMsg2 == "")
                    {
                        result = SaveRevenueProjections();
                        if (result != "")
                        {
                            hdnResultTab2.Value = result;
                            string message = "alert('" + "Basic Revenue Projections saved Successfully" + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        //Failure.Visible = true;
                        //lblmsg0.Text = ErrorMsg2;
                        string message = "alert('" + ErrorMsg2 + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;
                    }
                }
                else
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "Please Fill Basic Details";
                    string message = "alert('" + "Please Fill Basic Details and then Fill Basic Revenue Projections" + "')";
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

                        if (string.IsNullOrEmpty(txtYear1.Text) || txtYear1.Text == "" || txtYear1.Text == null || txtYear1.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtYear1.Text, @"^0+(\.0+)?$") ||
                            string.IsNullOrEmpty(txtYear2.Text) || txtYear2.Text == "" || txtYear2.Text == null || txtYear2.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtYear2.Text, @"^0+(\.0+)?$") ||
                            string.IsNullOrEmpty(txtYear3.Text) || txtYear3.Text == "" || txtYear3.Text == null || txtYear3.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtYear3.Text, @"^0+(\.0+)?$") ||
                            string.IsNullOrEmpty(txtYear4.Text) || txtYear4.Text == "" || txtYear4.Text == null || txtYear4.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtYear4.Text, @"^0+(\.0+)?$") ||
                            string.IsNullOrEmpty(txtYear5.Text) || txtYear5.Text == "" || txtYear5.Text == null || txtYear5.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtYear5.Text, @"^0+(\.0+)?$"))
                        {
                            errormsg = errormsg + lblIBPID.Text + " .Please Enter all details of " + lblItem.Text + "\\n";
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
        public string SaveRevenueProjections()
        {
            string result = "";

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
                result = indstregBAL.InsertIndRegRevenueDetails(dt, ViewState["UnitID"].ToString(), hdnUserID.Value);
            }
            return result;
        }
        //---------------------------------Step 3 Code ---------------------------//
        protected void ddlApplCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlApplCountry.SelectedValue != "78") // --india
                {

                    trothercountry.Visible = true;
                    traddredddropdowns.Visible = false;
                    ddlApplState.Visible = false;
                    txtApplState.Visible = true;
                    txtApplState.Text = "";
                    txtApplDist.Text = "";
                    txtApplTaluka.Text = "";
                    txtApplVillage.Text = "";

                    ValidateDropdown(ddlApplCountry);
                }
                else if (ddlApplCountry.SelectedValue == "78")
                {
                    //ddlApplState.Visible = true;
                    //ddlApplDist.Visible = true;
                    //ddlApplTaluka.Visible = true;
                    //ddlApplVillage.Visible = true;
                    ddlApplState.Enabled = true;
                    ddlApplDist.Enabled = false;
                    ddlApplTaluka.Enabled = false;
                    ddlApplVillage.Enabled = false;

                    trothercountry.Visible = false;
                    traddredddropdowns.Visible = true;
                    ddlApplState.Visible = true;
                    txtApplState.Visible = false;
                    ddlApplState.ClearSelection();
                    ddlApplDist.ClearSelection();
                    ddlApplTaluka.ClearSelection();
                    ddlApplVillage.ClearSelection();

                    ValidateDropdown(ddlApplCountry);
                }
                ValidateDropdown(ddlApplState);
                ValidateDropdown(ddlApplDist);
                ValidateDropdown(ddlApplTaluka);
                ValidateDropdown(ddlApplVillage);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void ddlApplState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlApplState.SelectedValue != "23")
                {
                    trothercountry.Visible = true;
                    traddredddropdowns.Visible = false;
                    txtApplDist.Text = "";
                    txtApplTaluka.Text = "";
                    txtApplVillage.Text = "";

                    ValidateDropdown(ddlApplState);
                }
                else if (ddlApplState.SelectedValue == "23")
                {
                    trothercountry.Visible = false;
                    traddredddropdowns.Visible = true;
                    ddlApplDist.Enabled = true;
                    ddlApplDist.ClearSelection();
                    //ddlApplDist.Items.Clear();
                    //AddSelect(ddlApplDist);
                    ddlApplTaluka.ClearSelection();
                    ddlApplTaluka.Items.Clear();
                    AddSelect(ddlApplTaluka);
                    ddlApplVillage.ClearSelection();
                    ddlApplVillage.Items.Clear();
                    AddSelect(ddlApplVillage);

                    ValidateDropdown(ddlApplState);
                    ValidateDropdown(ddlApplDist);
                    ValidateDropdown(ddlApplTaluka);
                    ValidateDropdown(ddlApplVillage);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }
        private void ValidateDropdown(DropDownList dropdown)
        {
            if (string.IsNullOrWhiteSpace(dropdown.SelectedValue) || dropdown.SelectedIndex == -1 || dropdown.SelectedItem.Text == "--Select--")
            {
                dropdown.BorderColor = System.Drawing.Color.Red;
            }
            else
            {
                dropdown.BorderColor = System.Drawing.Color.Black;
            }
        }
        protected void ddlApplDist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlApplTaluka.ClearSelection();
                ddlApplTaluka.Items.Clear();
                AddSelect(ddlApplTaluka);
                ddlApplVillage.ClearSelection();
                ddlApplVillage.Items.Clear();
                AddSelect(ddlApplVillage);

                if (ddlApplDist.SelectedItem.Text != "--Select--")
                {
                    ddlApplTaluka.Enabled = true;
                    BindMandal(ddlApplTaluka, ddlApplDist.SelectedValue);
                    ddlApplDist.BorderColor = System.Drawing.Color.Black;

                }
                else ddlApplDist.BorderColor = System.Drawing.Color.Red; return;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void ddlApplTaluka_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlApplVillage.ClearSelection();
                ddlApplVillage.Items.Clear();
                AddSelect(ddlApplVillage);

                if (ddlApplTaluka.SelectedItem.Text != "--Select--")
                {
                    ddlApplVillage.Enabled = true;

                    BindVillages(ddlApplVillage, ddlApplTaluka.SelectedValue);
                    ddlApplTaluka.BorderColor = System.Drawing.Color.Black;
                }
                else { ddlApplTaluka.BorderColor = System.Drawing.Color.Red; }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }
        protected void btnAddPromtr_Click(object sender, EventArgs e)
        {
            try
            {

                string ErrorMsg = "";

                if (Convert.ToString(ViewState["UnitID"]) != "")
                {
                    ErrorMsg = Step3validations();
                    if (ErrorMsg == "")
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
                        dr["IDD_DIRECTOR_NO"] = gvPromoters.Rows.Count + 1;
                        dr["IDD_UNITID"] = Convert.ToString(ViewState["UnitID"]);
                        dr["IDD_INVESTERID"] = hdnUserID.Value;
                        dr["IDD_FIRSTNAME"] = txtApplFrstName.Text.Trim();
                        dr["IDD_LASTNAME"] = txtApplLstName.Text.Trim();
                        dr["IDD_ADNO"] = txtApplAadhar.Text.Trim();
                        dr["IDD_PAN"] = txtApplPAN.Text;
                        dr["IDD_DINNO"] = txtApplDIN.Text;
                        dr["IDD_NATIONALITY"] = ddlApplNationality.SelectedItem.Text;
                        dr["IDD_DOORNO"] = txtApplDoorNo.Text.Trim();
                        dr["IDD_STREET"] = txtApplStreet.Text.Trim();
                        dr["IDD_CITY"] = ddlApplVillage.SelectedValue;
                        dr["IDD_DISTRICT"] = ddlApplDist.SelectedValue;
                        dr["IDD_MANDAL"] = ddlApplTaluka.SelectedValue;

                        dr["IDD_COUNTRY"] = ddlApplCountry.SelectedValue;
                        dr["IDD_PINCODE"] = txtApplPincode.Text;
                        dr["IDD_EMAIL"] = txtApplEmail.Text;
                        dr["IDD_PHONE"] = txtApplMobile.Text;

                        if (ddlApplCountry.SelectedValue == "78")
                        {
                            dr["IDD_STATEName"] = ddlApplState.SelectedItem.Text;
                            dr["IDD_STATE"] = ddlApplState.SelectedValue;
                            if (ddlApplState.SelectedValue == "23")
                            {
                                dr["IDD_DISTRICTName"] = ddlApplDist.SelectedItem.Text;
                                dr["IDD_MANDALName"] = ddlApplTaluka.SelectedItem.Text;
                                dr["IDD_CITYName"] = ddlApplVillage.SelectedItem.Text;
                            }
                            else if (ddlApplState.SelectedValue != "23")
                            {
                                dr["IDD_DISTRICTName"] = txtApplDist.Text.Trim();
                                dr["IDD_MANDALName"] = txtApplTaluka.Text.Trim();
                                dr["IDD_CITYName"] = txtApplVillage.Text.Trim();
                            }

                        }
                        else if (ddlApplCountry.SelectedValue != "78")
                        {
                            dr["IDD_STATE"] = "0";
                            dr["IDD_STATEName"] = txtApplState.Text.Trim();

                            dr["IDD_DISTRICTName"] = txtApplDist.Text.Trim();
                            dr["IDD_MANDALName"] = txtApplTaluka.Text.Trim();
                            dr["IDD_CITYName"] = txtApplVillage.Text.Trim();
                        }


                        dr["IDD_COUNTRYName"] = ddlApplCountry.SelectedItem.Text;

                        dt.Rows.Add(dr);
                        gvPromoters.Visible = true;
                        gvPromoters.DataSource = dt;
                        gvPromoters.DataBind();
                        ViewState["PromtrsTable"] = dt;

                        txtApplFrstName.Text = "";
                        txtApplLstName.Text = "";
                        txtApplAadhar.Attributes["value"] = "";
                        txtApplAadhar.Text = "";
                        txtApplPAN.Text = "";
                        txtApplDIN.Text = "";
                        ddlApplNationality.ClearSelection();
                        txtApplDoorNo.Text = "";
                        txtApplStreet.Text = "";
                        ddlApplCountry.ClearSelection();
                        ddlApplState.ClearSelection();
                        ddlApplState.Enabled = false;
                        ddlApplDist.ClearSelection();
                        ddlApplDist.Enabled = false;

                        ddlApplTaluka.ClearSelection();
                        ddlApplTaluka.Enabled = false;

                        ddlApplVillage.ClearSelection();
                        ddlApplVillage.Enabled = false;

                        txtApplState.Text = "";
                        txtApplDist.Text = "";
                        txtApplTaluka.Text = "";
                        txtApplVillage.Text = "";
                        txtApplPincode.Text = "";
                        txtApplEmail.Text = "";
                        txtApplMobile.Text = "";

                        btnPreview.Enabled = true;

                    }
                    else
                    {
                        txtApplAadhar.Text = "";
                        string message = "alert('" + ErrorMsg + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    string message = "alert('" + "Please Fill Basic Details & Basic Revenue Projections" + "')";
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
        public string PasswordDescription(string encrPswd)
        {
            var key = asp_hidden.Value;
            string encrpted = encrPswd.Trim(), DecrPswd = "";
            for (int j = 0; j < encrpted.Length; j++)
            {
                var charCode = (char)(encrpted[j] ^ key[j % key.Length]);
                DecrPswd += charCode;
            }
            return DecrPswd;
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
                    Failure.Visible = true;
                    lblmsg0.Text = "Please Fill Basic Details";
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }
        protected void btnSave3_Click(object sender, EventArgs e)
        {

            try
            {

                string result = "";
                if (gvPromoters.Rows.Count > 0 && Convert.ToString(ViewState["UnitID"]) != "" && hdnResultTab2.Value != "")
                {
                    DataTable dtnew = (DataTable)ViewState["PromtrsTable"];
                    result = indstregBAL.InsertIndPromotersDetails(dtnew, ViewState["UnitID"].ToString(), hdnUserID.Value);
                    if (result != "")
                    {
                        hdnResultTab3.Value = result;
                        string message = "alert('" + "Promoter/Director Details Submitted Successfully" + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }

                }
                else
                {

                    if (Convert.ToString(ViewState["UnitID"]) == "")
                    {
                        ErrorMsg3 = ErrorMsg3 + "Please Fill Basic Details & Basic Revenue Projections \\n";

                    }
                    if (hdnResultTab2.Value == "")
                    {
                        ErrorMsg3 = ErrorMsg3 + "Please Enter Details of Revenue Projections and click on Save button \\n";

                    }
                    if (gvPromoters.Rows.Count <= 0)
                    {
                        ErrorMsg3 = ErrorMsg3 + "Please Enter Details of the Applicant / Promoter(s) / Partner(s) / Directors(s) / Members and click on Add Details button \\n";

                    }
                    if (ErrorMsg3 != "")
                    {
                        string msg = "alert('" + ErrorMsg3 + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", msg, true);
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

                int slno = 1;
                string errormsg = ""; string ApplAadhar = "";
                List<TextBox> emptyTextboxes = FindEmptyTextboxes(divText);
                List<DropDownList> emptyDropdowns = FindEmptyDropdowns(divText);
                List<RadioButtonList> emptyRadioButtonLists = FindEmptyRadioButtonLists(divText);

                if (string.IsNullOrEmpty(txtApplFrstName.Text.Trim()) || txtApplFrstName.Text.Trim() == "" || txtApplFrstName.Text.Trim() == null)
                {
                    errormsg = errormsg + slno + ". Please Enter First Name \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtApplLstName.Text.Trim()) || txtApplLstName.Text.Trim() == "" || txtApplLstName.Text.Trim() == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Last Name \\n";
                    slno = slno + 1;
                }
                //if (txtApplAadhar.Text != "")
                //{ ApplAadhar = PasswordDescription(txtApplAadhar.Text); }

                if (string.IsNullOrEmpty(txtApplAadhar.Text) || txtApplAadhar.Text == "" || txtApplAadhar.Text == null || txtApplAadhar.Text.Length != 12 || txtApplAadhar.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtApplAadhar.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Valid Aadhar Number \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtApplPAN.Text) || txtApplPAN.Text == "" || txtApplPAN.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter PAN Number \\n";
                    slno = slno + 1;
                }
                if (ddlApplNationality.SelectedValue == "0" || ddlApplNationality.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Natonality \\n";
                    slno = slno + 1;
                }
                if (txtApplDIN.Text != "")
                {
                    if (txtApplDIN.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtApplDIN.Text, @"^0+(\.0+)?$"))
                    {
                        errormsg = errormsg + slno + ". Please Enter Din no's \\n";
                        slno = slno + 1;
                    }
                }
                if (string.IsNullOrEmpty(txtApplDoorNo.Text.Trim()) || txtApplDoorNo.Text.Trim() == "" || txtApplDoorNo.Text.Trim() == null || txtApplDoorNo.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtApplDoorNo.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Door Number \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtApplStreet.Text.Trim()) || txtApplStreet.Text.Trim() == "" || txtApplStreet.Text.Trim() == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Street Name \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtApplEmail.Text) || txtApplEmail.Text == "" || txtApplEmail.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Email \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtApplMobile.Text) || txtApplMobile.Text == "" || txtApplMobile.Text == null || txtApplMobile.Text.Length != 10 || txtApplMobile.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtApplMobile.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Valid Mobile Number \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtApplPincode.Text) || txtApplPincode.Text == "" || txtApplPincode.Text == null || txtApplPincode.Text.Length != 6 || txtApplPincode.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtApplPincode.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter valid Pincode Number \\n";
                    slno = slno + 1;
                }
                if (ddlApplCountry.SelectedValue == "0" || ddlApplCountry.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Country \\n";
                    slno = slno + 1;
                }
                if (ddlApplCountry.SelectedValue == "78") //India
                {
                    if (ddlApplState.SelectedValue == "0" || ddlApplState.SelectedItem.Text == "--Select--")
                    {
                        errormsg = errormsg + slno + ". Please Select State\\n";
                        slno = slno + 1;
                    }
                    else if (ddlApplState.SelectedValue == "23")
                    {
                        if (ddlApplDist.SelectedValue == "0" || ddlApplDist.SelectedItem.Text == "--Select--")
                        {
                            errormsg = errormsg + slno + ". Please Select District\\n";
                            slno = slno + 1;
                        }
                        if (ddlApplTaluka.SelectedValue == "0" || ddlApplTaluka.SelectedItem.Text == "--Select--")
                        {
                            errormsg = errormsg + slno + ". Please Select Taluka or Mandal\\n";
                            slno = slno + 1;
                        }
                        if (ddlApplVillage.SelectedValue == "0" || ddlApplVillage.SelectedItem.Text == "--Select--")
                        {
                            errormsg = errormsg + slno + ". Please Select Village\\n";
                            slno = slno + 1;
                        }
                    }
                    else if (ddlApplState.SelectedValue != "23" && ddlApplState.SelectedValue != "0")
                    {
                        if (string.IsNullOrEmpty(txtApplDist.Text) || txtApplDist.Text == "" || txtApplDist.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter District Name  \\n";
                            slno = slno + 1;
                        }
                        if (string.IsNullOrEmpty(txtApplTaluka.Text) || txtApplTaluka.Text == "" || txtApplTaluka.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter Mandal Name \\n";
                            slno = slno + 1;
                        }
                        if (string.IsNullOrEmpty(txtApplVillage.Text) || txtApplVillage.Text == "" || txtApplVillage.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter Village Name \\n";
                            slno = slno + 1;
                        }
                    }
                }
                else if (ddlApplCountry.SelectedValue != "78" || ddlApplCountry.SelectedValue != "0")
                {
                    if (string.IsNullOrEmpty(txtApplState.Text.Trim()) || txtApplState.Text.Trim() == "" || txtApplState.Text.Trim() == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter State Name \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtApplDist.Text.Trim()) || txtApplDist.Text.Trim() == "" || txtApplDist.Text.Trim() == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter District Name  \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtApplTaluka.Text.Trim()) || txtApplTaluka.Text.Trim() == "" || txtApplTaluka.Text.Trim() == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Mandal Name \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtApplVillage.Text.Trim()) || txtApplVillage.Text.Trim() == "" || txtApplVillage.Text.Trim() == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Village Name \\n";
                        slno = slno + 1;
                    }
                }
                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //---------------------------------Step 4 Code ---------------------------//
        protected void btnregistration_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(ViewState["UnitID"]) != "")
                {
                    string Error = ""; string message = "";
                    if (fupcompanyregistration.HasFile)
                    {
                        Error = validations(fupcompanyregistration);
                        if (Error == "")
                        {
                            string sFileDir = ConfigurationManager.AppSettings["PreRegAttachments"];
                            string serverpath = sFileDir + hdnUserID.Value + "\\"
                             + ViewState["UnitID"].ToString() + "\\" + "CompanyRegistration" + "\\";
                            if (!Directory.Exists(serverpath))
                            {
                                Directory.CreateDirectory(serverpath);

                            }
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupcompanyregistration.PostedFile.SaveAs(serverpath + "\\" + fupcompanyregistration.PostedFile.FileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(serverpath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupcompanyregistration.PostedFile.SaveAs(serverpath + "\\" + fupcompanyregistration.PostedFile.FileName);
                                }
                            }

                            IndustryDetails objattachments = new IndustryDetails();

                            objattachments.UnitID = ViewState["UnitID"].ToString();
                            objattachments.UserID = hdnUserID.Value;
                            objattachments.FileType = fupcompanyregistration.PostedFile.ContentType;
                            objattachments.FileName = fupcompanyregistration.PostedFile.FileName;
                            objattachments.Filepath = serverpath + fupcompanyregistration.PostedFile.FileName;
                            objattachments.FileDescription = "CompanyRegistration";
                            objattachments.Deptid = "0";
                            objattachments.ApprovalId = "0";

                            int result = 0;
                            result = indstregBAL.InsertAttachments_PREREG(objattachments);

                            if (result != 0)
                            {
                                hplcompanyregistration.Text = fupcompanyregistration.PostedFile.FileName;
                                hplcompanyregistration.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupcompanyregistration.PostedFile.FileName);
                                hplcompanyregistration.Target = "blank";
                                message = "alert('" + "Company Registration Document Uploaded successfully" + "')";
                                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                            }
                        }
                        else
                        {

                            message = "alert('" + Error + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                        }
                    }
                    else
                    {
                        message = "alert('" + "Please Upload Document" + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                {
                    string message = "alert('" + "Please Fill Basic Details and then Upload" + "')";
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
        protected void btnUdyam_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(ViewState["UnitID"]) != "")
                {
                    string Error = ""; string message = "";
                    if (fupUdyam.HasFile)
                    {
                        Error = validations(fupUdyam);
                        if (Error == "")
                        {
                            string sFileDir = ConfigurationManager.AppSettings["PreRegAttachments"];
                            string serverpath = sFileDir + hdnUserID.Value + "\\"
                             + ViewState["UnitID"].ToString() + "\\" + "UdyamRegistration" + "\\";
                            if (!Directory.Exists(serverpath))
                            {
                                Directory.CreateDirectory(serverpath);

                            }

                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupUdyam.PostedFile.SaveAs(serverpath + "\\" + fupUdyam.PostedFile.FileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(serverpath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupUdyam.PostedFile.SaveAs(serverpath + "\\" + fupUdyam.PostedFile.FileName);
                                }
                            }


                            IndustryDetails objattachments = new IndustryDetails();

                            objattachments.UnitID = ViewState["UnitID"].ToString();
                            objattachments.UserID = hdnUserID.Value;
                            objattachments.FileType = fupUdyam.PostedFile.ContentType;
                            objattachments.FileName = fupUdyam.PostedFile.FileName;
                            objattachments.Filepath = serverpath + fupUdyam.PostedFile.FileName;
                            objattachments.FileDescription = "UdyamRegistration";
                            objattachments.Deptid = "0";
                            objattachments.ApprovalId = "0";

                            int result = 0;
                            result = indstregBAL.InsertAttachments_PREREG(objattachments);

                            if (result != 0)
                            {
                                hplUdyam.Text = fupUdyam.PostedFile.FileName;
                                hplUdyam.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupUdyam.PostedFile.FileName);
                                hplUdyam.Target = "blank";
                                message = "alert('" + "Udyam Registration Document Uploaded successfully" + "')";
                                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                            }
                        }
                        else
                        {
                            message = "alert('" + Error + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                        }
                    }
                    else
                    {
                        message = "alert('" + "Please Upload Document" + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                {
                    string message = "alert('" + "Please Fill Basic Details and then Upload" + "')";
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
        protected void btnCIN_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(ViewState["UnitID"]) != "")
                {
                    string Error = ""; string message = "";
                    if (fupCIN.HasFile)
                    {
                        Error = validations(fupCIN);
                        if (Error == "")
                        {
                            string sFileDir = ConfigurationManager.AppSettings["PreRegAttachments"];
                            string serverpath = sFileDir + hdnUserID.Value + "\\"
                             + ViewState["UnitID"].ToString() + "\\" + "CIN" + "\\";
                            if (!Directory.Exists(serverpath))
                            {
                                Directory.CreateDirectory(serverpath);

                            }
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupCIN.PostedFile.SaveAs(serverpath + "\\" + fupCIN.PostedFile.FileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(serverpath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupCIN.PostedFile.SaveAs(serverpath + "\\" + fupCIN.PostedFile.FileName);
                                }
                            }


                            IndustryDetails objattachments = new IndustryDetails();

                            objattachments.UnitID = ViewState["UnitID"].ToString();
                            objattachments.UserID = hdnUserID.Value;
                            objattachments.FileType = fupCIN.PostedFile.ContentType;
                            objattachments.FileName = fupCIN.PostedFile.FileName;
                            objattachments.Filepath = serverpath + fupCIN.PostedFile.FileName;
                            objattachments.FileDescription = "CIN";
                            objattachments.Deptid = "0";
                            objattachments.ApprovalId = "0";

                            int result = 0;
                            result = indstregBAL.InsertAttachments_PREREG(objattachments);

                            if (result != 0)
                            {
                                hplCIN.Text = fupCIN.PostedFile.FileName;
                                hplCIN.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupCIN.PostedFile.FileName);
                                hplCIN.Target = "blank";
                                message = "alert('" + "CIN Document Uploaded successfully" + "')";
                                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                            }
                        }
                        else
                        {
                            message = "alert('" + Error + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                        }
                    }
                    else
                    {
                        message = "alert('" + "Please Upload Document" + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                {
                    string message = "alert('" + "Please Fill Basic Details and then Upload" + "')";
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
        protected void btnGSTIN_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(ViewState["UnitID"]) != "")
                {
                    string Error = ""; string message = "";
                    if (fupGSTIN.HasFile)
                    {
                        Error = validations(fupGSTIN);
                        if (Error == "")
                        {
                            string sFileDir = ConfigurationManager.AppSettings["PreRegAttachments"];
                            string serverpath = sFileDir + hdnUserID.Value + "\\"
                             + ViewState["UnitID"].ToString() + "\\" + "GSTIN" + "\\";
                            if (!Directory.Exists(serverpath))
                            {
                                Directory.CreateDirectory(serverpath);

                            }
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupGSTIN.PostedFile.SaveAs(serverpath + "\\" + fupGSTIN.PostedFile.FileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(serverpath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupGSTIN.PostedFile.SaveAs(serverpath + "\\" + fupGSTIN.PostedFile.FileName);
                                }
                            }


                            IndustryDetails objattachments = new IndustryDetails();

                            objattachments.UnitID = ViewState["UnitID"].ToString();
                            objattachments.UserID = hdnUserID.Value;
                            objattachments.FileType = fupGSTIN.PostedFile.ContentType;
                            objattachments.FileName = fupGSTIN.PostedFile.FileName;
                            objattachments.Filepath = serverpath + fupGSTIN.PostedFile.FileName;
                            objattachments.FileDescription = "GSTIN";
                            objattachments.Deptid = "0";
                            objattachments.ApprovalId = "0";

                            int result = 0;
                            result = indstregBAL.InsertAttachments_PREREG(objattachments);

                            if (result != 0)
                            {
                                hplGSTIN.Text = fupGSTIN.PostedFile.FileName;
                                hplGSTIN.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupGSTIN.PostedFile.FileName);
                                hplGSTIN.Target = "blank";
                                message = "alert('" + "GSTIN Document Uploaded successfully" + "')";
                                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                            }
                        }
                        else
                        {
                            message = "alert('" + Error + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                        }
                    }
                    else
                    {
                        message = "alert('" + "Please Upload Document" + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                {
                    string message = "alert('" + "Please Fill Basic Details and then Upload" + "')";
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
        protected void btnPAN_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(ViewState["UnitID"]) != "")
                {
                    string Error = ""; string message = "";

                    if (fupPAN.HasFile)
                    {
                        Error = validations(fupPAN);
                        if (Error == "")
                        {
                            string sFileDir = ConfigurationManager.AppSettings["PreRegAttachments"];
                            string serverpath = sFileDir + hdnUserID.Value + "\\"
                             + ViewState["UnitID"].ToString() + "\\" + "PAN" + "\\";


                            if (!Directory.Exists(serverpath))
                            {
                                Directory.CreateDirectory(serverpath);

                            }
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupPAN.PostedFile.SaveAs(serverpath + "\\" + fupPAN.PostedFile.FileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(serverpath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupPAN.PostedFile.SaveAs(serverpath + "\\" + fupPAN.PostedFile.FileName);
                                }
                            }


                            IndustryDetails objattachments = new IndustryDetails();

                            objattachments.UnitID = ViewState["UnitID"].ToString();
                            objattachments.UserID = hdnUserID.Value;
                            objattachments.FileType = fupPAN.PostedFile.ContentType;
                            objattachments.FileName = fupPAN.PostedFile.FileName;
                            objattachments.Filepath = serverpath + fupPAN.PostedFile.FileName;
                            objattachments.FileDescription = "PAN";
                            objattachments.Deptid = "0";
                            objattachments.ApprovalId = "0";

                            int result = 0;
                            result = indstregBAL.InsertAttachments_PREREG(objattachments);

                            if (result != 0)
                            {
                                hplPAN.Text = fupPAN.PostedFile.FileName;
                                hplPAN.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupPAN.PostedFile.FileName);
                                hplPAN.Target = "blank";
                                message = "alert('" + "PAN Document Uploaded successfully" + "')";
                                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                            }
                        }
                        else
                        {
                            message = "alert('" + Error + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                        }
                    }
                    else
                    {
                        message = "alert('" + "Please Upload Document" + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                {
                    string message = "alert('" + "Please Fill Basic Details and then Upload" + "')";
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
        protected void btndpr_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(ViewState["UnitID"]) != "")
                {
                    string Error = ""; string message = "";
                    string newPath = "";
                    string sFileDir = ConfigurationManager.AppSettings["PreRegAttachments"];
                    //Server.MapPath("~\\PreRegAttachments");
                    if (fupDPR.HasFile)
                    {
                        Error = validations(fupDPR);
                        if (Error == "")
                        {
                            if ((fupDPR.PostedFile != null) && (fupDPR.PostedFile.ContentLength > 0))
                            {

                                newPath = System.IO.Path.Combine(sFileDir, hdnUserID.Value, ViewState["UnitID"].ToString() + "\\DPR\\");

                                if (!Directory.Exists(newPath))
                                    System.IO.Directory.CreateDirectory(newPath);

                                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                                int count = dir.GetFiles().Length;
                                if (count == 0)
                                {
                                    fupDPR.PostedFile.SaveAs(newPath + "\\" + fupDPR.PostedFile.FileName);
                                }
                                else
                                {
                                    if (count == 1)
                                    {
                                        string[] Files = Directory.GetFiles(newPath);

                                        foreach (string file in Files)
                                        {
                                            File.Delete(file);
                                        }
                                        fupDPR.PostedFile.SaveAs(newPath + "\\" + fupDPR.PostedFile.FileName);
                                    }
                                }
                                IndustryDetails objattachments = new IndustryDetails();

                                objattachments.UnitID = ViewState["UnitID"].ToString();
                                objattachments.UserID = hdnUserID.Value;
                                objattachments.FileType = fupDPR.PostedFile.ContentType; ;
                                objattachments.FileName = fupDPR.PostedFile.FileName;
                                objattachments.Filepath = newPath.ToString() + fupDPR.PostedFile.FileName; ;
                                objattachments.FileDescription = "DPR";
                                objattachments.Deptid = "0";
                                objattachments.ApprovalId = "0";

                                int result = 0;
                                result = indstregBAL.InsertAttachments_PREREG(objattachments);

                                if (result > 0)
                                {
                                    lbldpr.Text = fupDPR.FileName;
                                    hypdpr.Text = fupDPR.FileName;
                                    hypdpr.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(newPath + fupDPR.PostedFile.FileName);
                                    message = "alert('" + "DPR Document Uploaded successfully" + "')";
                                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                                }
                                else
                                {
                                    lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                                    success.Visible = false;
                                    Failure.Visible = true;
                                }
                            }
                        }
                        else
                        {
                            message = "alert('" + Error + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                        }
                    }
                }
                else
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "Please Fill Basic Details";
                    string message = "alert('" + "Please Fill Basic Details First and then Upload DPR " + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
        protected void btnBankAppraisal_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(ViewState["UnitID"]) != "")
                {
                    string Error = ""; string message = "";
                    if (fupBankAppraisal.HasFile)
                    {
                        Error = validations(fupBankAppraisal);
                        if (Error == "")
                        {
                            string sFileDir = ConfigurationManager.AppSettings["PreRegAttachments"];
                            string serverpath = sFileDir + hdnUserID.Value + "\\"
                             + ViewState["UnitID"].ToString() + "\\" + "BankAppraisal" + "\\";
                            if (!Directory.Exists(serverpath))
                            {
                                Directory.CreateDirectory(serverpath);

                            }
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupBankAppraisal.PostedFile.SaveAs(serverpath + "\\" + fupBankAppraisal.PostedFile.FileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(serverpath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupBankAppraisal.PostedFile.SaveAs(serverpath + "\\" + fupBankAppraisal.PostedFile.FileName);
                                }
                            }


                            IndustryDetails objattachments = new IndustryDetails();

                            objattachments.UnitID = ViewState["UnitID"].ToString();
                            objattachments.UserID = hdnUserID.Value;
                            objattachments.FileType = fupBankAppraisal.PostedFile.ContentType;
                            objattachments.FileName = fupBankAppraisal.PostedFile.FileName;
                            objattachments.Filepath = serverpath + fupBankAppraisal.PostedFile.FileName;
                            objattachments.FileDescription = "BankAppraisal";
                            objattachments.Deptid = "0";
                            objattachments.ApprovalId = "0";

                            int result = 0;
                            result = indstregBAL.InsertAttachments_PREREG(objattachments);

                            if (result != 0)
                            {
                                hplBankAppraisal.Text = fupBankAppraisal.PostedFile.FileName;
                                hplBankAppraisal.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath);
                                hplBankAppraisal.Target = "blank";
                                message = "alert('" + "Bank Appraisal Document Uploaded successfully" + "')";
                                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                            }
                        }
                        else
                        {
                            message = "alert('" + Error + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                        }
                    }
                    else
                    {
                        message = "alert('" + "Please Upload Document" + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                {
                    string message = "alert('" + "Please Fill Basic Details and then Upload" + "')";
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
        public void DeleteFile(string strFileName)
        {
            if (strFileName.Trim().Length > 0)
            {
                FileInfo fi = new FileInfo(strFileName);
                if (fi.Exists)//if file exists delete it
                {
                    fi.Delete();
                }
            }
        }
        public string validations(FileUpload Attachment)
        {
            try
            {
                string filesize = Convert.ToString(ConfigurationManager.AppSettings["FileSize"].ToString());
                int slno = 1; string Error = "";
                //if (Attachment.PostedFile.ContentType != "application/pdf"
                //     || !ValidateFileName(Attachment.PostedFile.FileName) || !ValidateFileExtension(Attachment))
                //{

                if (Attachment.PostedFile.ContentType != "application/pdf")
                {
                    Error = Error + slno + ". Please Upload PDF Documents only \\n";
                    slno = slno + 1;
                }
                if (Attachment.PostedFile.ContentLength >= Convert.ToInt32(filesize))
                {
                    Error = Error + slno + ". Please Upload file size less than " + Convert.ToInt32(filesize) / 1000000 + "MB \\n";
                    slno = slno + 1;
                }
                if (!ValidateFileName(Attachment.PostedFile.FileName))
                {
                    Error = Error + slno + ". Document name should not contain symbols like  <, >, %, $, @, &,=, / \\n";
                    slno = slno + 1;
                }
                if (!ValidateFileExtension(Attachment))
                {
                    Error = Error + slno + ". Invalid File Extension \\n";
                    slno = slno + 1;
                }

                // }
                return Error;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public static bool ValidateFileName(string fileName)
        {
            try
            {
                string pattern = @"[<>%$@&=!:*?|]";

                if (Regex.IsMatch(fileName, pattern))
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public static bool ValidateFileExtension(FileUpload Attachment)
        {

            string Attachmentname = Attachment.PostedFile.FileName;
            string[] fileType = Attachmentname.Split('.');
            int i = fileType.Length;

            if (i == 2 && fileType[i - 1].ToUpper().Trim() == "PDF")
                return true;
            else
                return false;

        }
        protected void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                //Response.Redirect("IndustryPrintPage.aspx?UnitID="+ Convert.ToString(ViewState["UnitID"]));

                string result = "", errormsg = "";
                errormsg = Step4validations();

                if (Convert.ToString(ViewState["UnitID"]) != "" && hdnResultTab2.Value != "" && hdnResultTab3.Value != "" && errormsg == "")
                {

                    Response.Redirect("IndustryPrintPage.aspx?UnitID=" + Convert.ToString(ViewState["UnitID"]));
                }
                else
                {
                    string message1 = "";
                    if (Convert.ToString(ViewState["UnitID"]) == "")
                    {
                        message1 = message1 + "Please Fill Basic Details \\n";
                    }
                    if (hdnResultTab2.Value == "")
                    {
                        message1 = message1 + "Please Enter Details of Revenue Projections and click on Save button \\n";
                    }
                    if (gvPromoters.Rows.Count <= 0)
                    {
                        message1 = message1 + "Please Enter Details of the Applicant / Promoter(s) / Partner(s) / Directors(s) / Members and click on ADD button \\n";
                    }
                    if (errormsg != "")
                    {
                        message1 = message1 + errormsg;
                    }
                    string message = "alert('" + message1 + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnSave4_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                ErrorMsg1 = Step1validations();
                ErrorMsg2 = Step2validations();
                ErrorMsg4 = Step4validations();

                if ((Convert.ToString(ViewState["UnitID"]) != "" && ErrorMsg1 == "") &&
                    (hdnResultTab2.Value != "" && ErrorMsg2 == "") &&
                    (hdnResultTab3.Value != "" && gvPromoters.Rows.Count > 0) && ErrorMsg4 == "")
                {
                    DataTable dt = (DataTable)ViewState["PromtrsTable"];
                    // dt.Columns.Remove("IDD_COUNTRYName");
                    result = indstregBAL.InsertIndustryRegDetails(dt, ViewState["UnitID"].ToString(), hdnUserID.Value);
                    if (result != "")
                    {
                        string unitid = Convert.ToString(ViewState["UnitID"]);
                        smsMail.SendSms(unitid, hdnUserID.Value.ToString(), "1407172584852269031", "REG", "INDUSTRY REGISTRATION");
                        smsMail.SendEmail(unitid, hdnUserID.Value.ToString(), "REG", "INDUSTRY REGISTRATION");
                        success.Visible = true;
                        btnSave3.Enabled = false;
                        lblmsg.Text = "Application Submitted Successfully";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", $"alert('Application Submitted Successfully!');  window.location.href='IndustryAckSlip.aspx?UnitID={unitid} '", true);

                        // string message = "alert('" + "Application Submitted Successfully" + "')";
                        //ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    string message1 = "";
                    if (Convert.ToString(ViewState["UnitID"]) == "" || ErrorMsg1 != "")
                    {
                        message1 = message1 + "Please Fill All Basic Details \\n";
                    }
                    if (hdnResultTab2.Value == "" || ErrorMsg2 != "")
                    {
                        message1 = message1 + "Please Enter Details of Revenue Projections and click on Save button \\n";
                    }
                    if (gvPromoters.Rows.Count <= 0 || hdnResultTab3.Value == "")
                    {
                        message1 = message1 + "Please Add Details of the Applicant / Promoter(s) / Partner(s) / Directors(s) / Members and click on Save as Draft button \\n";
                    }
                    if (ErrorMsg4 != "")
                    {
                        message1 = message1 + ErrorMsg4;
                    }
                    string message = "alert('" + message1 + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public string Step4validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                if (string.IsNullOrEmpty(hplcompanyregistration.Text) || hplcompanyregistration.Text == "" || hplcompanyregistration.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Upload CompanyRegistration Document \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hplUdyam.Text) || hplUdyam.Text == "" || hplUdyam.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Upload Udyam Document \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hplPAN.Text) || hplPAN.Text == "" || hplPAN.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Upload PAN Document \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hplGSTIN.Text) || hplGSTIN.Text == "" || hplGSTIN.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Upload GST Document \\n";
                    slno = slno + 1;
                }
                if (ddlproposal.SelectedValue == "Existing")
                {
                    if (string.IsNullOrEmpty(lbldpr.Text) || lbldpr.Text == "" || lbldpr.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Upload Detailed Project Report (DPR) " + "\\n";
                        slno = slno + 1;
                    }
                }
                if (string.IsNullOrEmpty(hplBankAppraisal.Text) || hplBankAppraisal.Text == "" || hplBankAppraisal.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Upload Bank Appraisal " + "\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hplCIN.Text) || hplCIN.Text == "" || hplCIN.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Upload CIN Document " + "\\n";
                    slno = slno + 1;
                }



                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //-------------------------Next, Previous and Tab buttons -------------------------------//
        protected void btnNext1_Click(object sender, EventArgs e)
        {
            try
            {

                int result = 0;
                ErrorMsg1 = Step1validations();
                if (ErrorMsg1 == "")
                {
                    result = SaveBasicDetails();
                    if (result != 100)
                    {
                        ViewState["UnitID"] = result;
                        MVprereg.ActiveViewIndex = 1;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "disablePaste", "disablePasteForAll();", true);
                    }
                }
                else
                {
                    string message = "alert('" + ErrorMsg1 + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
            }
            catch (SqlException ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void btnNext2_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";

                if (Convert.ToString(ViewState["UnitID"]) != "")
                {
                    ErrorMsg2 = Step2validations();
                    if (ErrorMsg2 == "")
                    {
                        result = SaveRevenueProjections();
                        if (result != "")
                        {
                            hdnResultTab2.Value = result;
                            MVprereg.ActiveViewIndex = 2;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "disablePaste", "disablePasteForAll();", true);
                        }
                    }
                    else
                    {
                        string message = "alert('" + ErrorMsg2 + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;
                    }
                }
                else
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "Please Fill Basic Details";
                    string message = "alert('" + "Please Fill Basic Details and then Fill Basic Revenue Projections" + "')";
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

                string result = "";
                if (gvPromoters.Rows.Count > 0 && Convert.ToString(ViewState["UnitID"]) != "" && hdnResultTab2.Value != "")
                {
                    DataTable dtnew = (DataTable)ViewState["PromtrsTable"];
                    result = indstregBAL.InsertIndPromotersDetails(dtnew, ViewState["UnitID"].ToString(), hdnUserID.Value);
                    if (result != "")
                    {
                        hdnResultTab3.Value = result;
                        MVprereg.ActiveViewIndex = 3;
                    }

                }
                else
                {

                    if (Convert.ToString(ViewState["UnitID"]) == "")
                    {
                        ErrorMsg3 = ErrorMsg3 + "Please Fill Basic Details & Basic Revenue Projections \\n";

                    }
                    if (hdnResultTab2.Value == "")
                    {
                        ErrorMsg3 = ErrorMsg3 + "Please Enter Details of Revenue Projections and click on Save button \\n";

                    }
                    if (gvPromoters.Rows.Count <= 0 || hdnResultTab3.Value == "")
                    {
                        ErrorMsg3 = ErrorMsg3 + "Please Enter Details of the Applicant / Promoter(s) / Partner(s) / Directors(s) / Members and click on Add Details button and Save \\n";

                    }
                    if (ErrorMsg3 != "")
                    {
                        string msg = "alert('" + ErrorMsg3 + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", ErrorMsg3, true);
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
        protected void btnPreviuos2_Click(object sender, EventArgs e)
        {
            MVprereg.ActiveViewIndex = 0;

        }
        protected void btnPreviuos3_Click(object sender, EventArgs e)
        {
            MVprereg.ActiveViewIndex = 1;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "disablePaste", "disablePasteForAll();", true);
        }
        protected void BtnPrevious4_Click(object sender, EventArgs e)
        {
            MVprereg.ActiveViewIndex = 2;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "disablePaste", "disablePasteForAll();", true);
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
        protected void Link1_Click(object sender, EventArgs e)
        {
            MVprereg.ActiveViewIndex = 0;
        }

        protected void gvPromoters_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblAadharNO = (Label)e.Row.FindControl("lblAadhar");
                    string AadharNo = lblAadharNO.Text;
                    if (!string.IsNullOrEmpty(AadharNo))
                    {
                        lblAadharNO.Text = new string('*', AadharNo.Length - 4) + AadharNo.Substring(AadharNo.Length - 4);
                        //new string('*', AadharNo.Length);
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

        protected void Link2_Click(object sender, EventArgs e)
        {
            ErrorMsg1 = Step1validations();
            if (Convert.ToString(ViewState["UnitID"]) != "" && ErrorMsg1 == "")
            {
                MVprereg.ActiveViewIndex = 1;
            }
            else
            {
                string message = "alert('" + "Please Fill all Basic Details and click on Save As Draft" + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }

        }

        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlstate.SelectedValue != "23")
                {
                    District.Visible = true;
                    Div1.Visible = true;
                    Div2.Visible = true;
                    Dist1.Visible = false;
                    Mandal1.Visible = false;
                    villages1.Visible = false;
                }
                else if (ddlstate.SelectedValue == "23")
                {
                    Dist1.Visible = true;
                    Mandal1.Visible = true;
                    villages1.Visible = true;
                    District.Visible = false;
                    Div1.Visible = false;
                    Div2.Visible = false;
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
            ErrorMsg1 = Step1validations();
            ErrorMsg2 = Step2validations();
            if (ErrorMsg1 == "" && Convert.ToString(ViewState["UnitID"]) != "" && hdnResultTab2.Value != "" && ErrorMsg2 == "")
            {
                MVprereg.ActiveViewIndex = 2;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "disablePaste", "disablePasteForAll();", true);
            }
            else
            {
                string message = "";
                if (Convert.ToString(ViewState["UnitID"]) == "" || ErrorMsg1 != "")
                {
                    message = "Please Fill all Basic Details and click on Save As Draft \\n";
                }
                if (hdnResultTab2.Value == "" || ErrorMsg2 != "")
                {
                    message = message + "Please Fill all Revenue Projections Details and click on Save As Draft";
                }
                string msg = "alert('" + message + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", msg, true);
                return;
            }
        }
        protected void Link4_Click(object sender, EventArgs e)
        {
            ErrorMsg1 = Step1validations();
            ErrorMsg2 = Step2validations();

            if (ErrorMsg1 == "" && Convert.ToString(ViewState["UnitID"]) != "" && ErrorMsg2 == "" && hdnResultTab3.Value != "" && gvPromoters.Rows.Count > 0)
            {
                MVprereg.ActiveViewIndex = 3;
            }
            else
            {
                string message = "";
                if (Convert.ToString(ViewState["UnitID"]) == "" || ErrorMsg1 != "")
                {
                    message = "Please Fill all Basic Details and click on Save As Draft \\n";
                }
                if (hdnResultTab2.Value == "" || ErrorMsg2 != "")
                {
                    message = message + "Please Fill all Revenue Projections Details and click on Save As Draft \\n ";
                }
                if (hdnResultTab3.Value == "" || gvPromoters.Rows.Count <= 0)
                {
                    message = message + "Please Add Promoter(s) Details and click on Save As Draft  ";
                }
                string msg = "alert('" + message + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", msg, true);
                return;
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

                        radioButtonList.BorderColor = System.Drawing.Color.Red;
                        radioButtonList.BorderWidth = Unit.Pixel(2);
                        radioButtonList.BorderStyle = BorderStyle.Solid;
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