﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;

namespace MeghalayaUIP.User.CFE
{
    public partial class CFEIndustryDetails : System.Web.UI.Page
    {

        MasterBAL mstrBAL = new MasterBAL();
        CFEBAL objcfebal = new CFEBAL();
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
                if (Convert.ToString(Session["UNITID"]) != "")
                {
                    UnitID = Convert.ToString(Session["UNITID"]);
                }
                else
                {
                    string newurl = "~/User/CFE/CFEUserDashboard.aspx";
                    Response.Redirect(newurl);
                }

                Page.MaintainScrollPositionOnPostBack = true;

                if (!IsPostBack)
                {
                    BindDistricts();
                    BindRegistrationType();
                    BindConstitutionType();
                    BindData();
                }
            }
        }

        protected void BindDistricts()
        {
            try
            {
                ddlDistric.Items.Clear();
                ddlMandal.Items.Clear();
                ddlVillage.Items.Clear();

                List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();

                objDistrictModel = mstrBAL.GetDistrcits();
                if (objDistrictModel != null)
                {
                    ddlDistric.DataSource = objDistrictModel;
                    ddlDistric.DataValueField = "DistrictId";
                    ddlDistric.DataTextField = "DistrictName";
                    ddlDistric.DataBind();
                }
                else
                {
                    ddlDistric.DataSource = null;
                    ddlDistric.DataBind();

                }
                AddSelect(ddlDistric);
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
                throw ex;
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
                throw ex;
            }


        }
        public void BindData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfebal.GetCFEIndustryDetails(hdnUserID.Value, UnitID);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        hdnPreRegUID.Value = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_PREREGUIDNO"]);
                        txtIndustryName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_COMPANYNAME"]);
                        ddlCompanyType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_COMPANYTYPE"]);
                        rblproposal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_PROPOSALFOR"]);
                        ddlRegType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_REGTYPE"]);
                        txtRegistrationNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_REGNO"]);
                        string date = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_REGDATE"]);
                        date = "2024 - 01 - 01 00:00:00.000";
                        DateTime FnlDt = Convert.ToDateTime(date);
                        txtRegDate.Text = Convert.ToString(FnlDt);

                        ddlFactories.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_FACTORYTYPE"]);

                        txtPromoterName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_REPNAME"]);
                        txtSoWoDo.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_REPSoWoDo"]);
                        txtEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_REPEMAIL"]);
                        txtMobileno.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_REPMOBILE"]);
                        txtAltMobile.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_REPALTMOBILE"]);
                        txtLandlineno.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_REPTELPHNO"]);
                        txtDoorNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_REPDOORNO"]);
                        txtLocality.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_REPLOCALITY"]);
                        ddlDistric.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_REPDISTRICTID"]);
                        ddlDistric_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlMandal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_REPMANDALID"]);
                        ddlMandal_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlVillage.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_REPVILLAGEID"]);
                        txtpincode.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_REPPINCODE"]);

                        rblAbled.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_REPISDIFFABLED"]);
                        rblWomen.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_REPISWOMANENTR"]);
                        txtDevelopmentArea.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_DEVELOPAREA"]);

                        txtArchitectName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_ARCHTCTNAME"]);
                        txtArchitectLicNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_ARCHTCTLICNO"]);
                        txtArchitectMobileno.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_ARCHTCTMOBILE"]);
                        txtStrEngnrName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_SRTCTENGNRNAME"]);
                        txtStrLicNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_SRTCTENGNRLICNO"]);
                        txtStrEngnrMobileno.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_SRTCTENGNRMOBILE"]);
                        ddlApproachRoad.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_APPROACHROADTYPE"]);
                        txtExstngWidth.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_APPROACHROADWIDTH"]);
                        rblAffectedroad.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_AFFECTEDRDWDNG"]);
                        rblAffectedroad_SelectedIndexChanged(null, EventArgs.Empty);

                        txtAffectedArea.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_AFFECTEDRDAREA"]);
                        lbltotalEmp.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_TOTALEMP"]);
                        txtMale.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_DIRECTMALE"]);
                        txtFemale.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_DIRECTFEMALE"]);
                        txtDirectOthers.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_DIRECTOTHERS"]);

                        txtIndirectMale.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_INDIRECTMALE"]);
                        txtIndirectFemale.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_INDIRECTFEMALE"]);
                        txtInDirectOthers.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_INDIRECTOTHERS"]);
                        txtRdCutlenght.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_RDCUTLENGTH"]);
                        txtRdCutLocations.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_RDCUTLOCATIONS"]);

                        if (txtRdCutlenght.Text != "")
                        { divRDctng.Visible = true; hdngRdCtng.Visible = true; }

                    }
                    else
                    {
                        hdnPreRegUID.Value = Convert.ToString(ds.Tables[1].Rows[0]["CFEQD_PREREGUIDNO"]);
                        txtIndustryName.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEQD_COMPANYNAME"]);
                        ddlCompanyType.SelectedValue = Convert.ToString(ds.Tables[1].Rows[0]["CFEQD_COMPANYTYPE"]);
                        rblproposal.SelectedValue = Convert.ToString(ds.Tables[1].Rows[0]["CFEQD_PROPOSALFOR"]);
                        ddlRegType.SelectedValue = Convert.ToString(ds.Tables[1].Rows[0]["COMPANYREGTYPE"]);
                        txtRegistrationNo.Text = Convert.ToString(ds.Tables[1].Rows[0]["COMPANYREGNO"]);
                        string date = Convert.ToString(ds.Tables[1].Rows[0]["REGISTRATIONDATE"]);
                        date = "2024 - 01 - 01 00:00:00.000";
                        DateTime FnlDt = Convert.ToDateTime(date);
                        txtRegDate.Text = Convert.ToString(FnlDt);
                        //txtRegDate.Text = Convert.ToString(ds.Tables[1].Rows[0]["REGISTRATIONDATE"]);                      

                        txtPromoterName.Text = Convert.ToString(ds.Tables[1].Rows[0]["REP_NAME"]);
                        txtEmail.Text = Convert.ToString(ds.Tables[1].Rows[0]["REP_EMAIL"]);
                        txtMobileno.Text = Convert.ToString(ds.Tables[1].Rows[0]["REP_MOBILE"]);
                        txtDoorNo.Text = Convert.ToString(ds.Tables[1].Rows[0]["REP_DOORNO"]);
                        txtLocality.Text = Convert.ToString(ds.Tables[1].Rows[0]["REP_LOCALITY"]);
                        ddlDistric.SelectedValue = Convert.ToString(ds.Tables[1].Rows[0]["REP_DISTRICTID"]);
                        ddlDistric_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlMandal.SelectedValue = Convert.ToString(ds.Tables[1].Rows[0]["REP_MANDALID"]);
                        ddlMandal_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlVillage.SelectedValue = Convert.ToString(ds.Tables[1].Rows[0]["REP_VILLAGEID"]);
                        txtpincode.Text = Convert.ToString(ds.Tables[1].Rows[0]["REP_PINCODE"]);
                        lbltotalEmp.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEQD_PROPEMP"]);

                        if (Convert.ToString(ds.Tables[1].Rows[0]["CFEQD_GENREQ"]) == "Y")
                            ddlFactories.SelectedValue = "1";
                        else if (Convert.ToString(ds.Tables[1].Rows[0]["CFEQD_GENREQ"]) == "N")
                            ddlFactories.SelectedValue = "2";
                        if (Convert.ToString(ds.Tables[1].Rows[0]["CFEQD_RDCTNGREQ"]) == "Y")
                        { divRDctng.Visible = true; hdngRdCtng.Visible = true; }
                    }
                    //txtIndustryName.Enabled = false;
                    //txtPromoterName.Enabled = false;
                    //ddlState.Enabled = false;
                    //ddlDistric.Enabled = false;
                    //ddlMandal.Enabled = false;
                    //ddlVillage.Enabled = false;
                    //txtLocality.Enabled = false;
                    //txtpincode.Enabled = false;
                    //txtMobileno.Enabled = false;
                    //txtEmail.Enabled = false;
                    //ddlCompanyType.Enabled = false;
                    //rblproposal.Enabled = false;                    
                    //lbltotalEmp.Enabled = false;
                    //txtRegDate.Enabled = false;
                    //ddlFactories.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlDistric_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlMandal.ClearSelection();
                ddlVillage.ClearSelection();
                if (ddlDistric.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlMandal, ddlDistric.SelectedValue);
                }
                else return;
            }
            catch (Exception ex)
            {

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
        protected void rblAffectedroad_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblAffectedroad.SelectedValue == "Y")
                { divAffectArea.Visible = true; }
                else
                {
                    divAffectArea.Visible = false;
                    txtAffectedArea.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }
        }



        public void TotalAmount()
        {
            if (int.TryParse(txtMale.Text, out int maleCount) && int.TryParse(txtFemale.Text, out int femaleCount))
            {
                int total = maleCount + femaleCount;
                lbltotalEmp.Text = total.ToString();
            }
            else
            {
                lbltotalEmp.Text = "Invalid input";
            }
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/CFE/CFECommonApplication.aspx");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {


            try
            {
                string ErrorMsg = "", result = "";


                ErrorMsg = Validations();

                if (ErrorMsg == "")
                {
                    int TotEmp = Convert.ToInt32(txtMale.Text) + Convert.ToInt32(txtFemale.Text) + Convert.ToInt32(txtDirectOthers.Text) +
                        Convert.ToInt32(txtIndirectMale.Text) + Convert.ToInt32(txtIndirectFemale.Text) + Convert.ToInt32(txtInDirectOthers.Text);

                    if (TotEmp != Convert.ToInt32(lbltotalEmp.Text))
                    {
                        Failure.Visible = true;
                        lblmsg0.Text = "Entered Eployee count should match with total Employee count";
                        return;
                    }
                    CFECommonDet objCFEComn = new CFECommonDet();
                    if (Convert.ToString(ViewState["UnitID"]) != "")
                    {
                        objCFEComn.UNITID = Convert.ToString(ViewState["UnitID"]);
                    }
                    objCFEComn.CreatedBy = hdnUserID.Value;
                    objCFEComn.PreRegUID = hdnPreRegUID.Value;
                    objCFEComn.IPAddress = getclientIP();
                    objCFEComn.UNITID = UnitID;
                    objCFEComn.CompanyName = txtIndustryName.Text;
                    objCFEComn.CompanyType = ddlCompanyType.SelectedValue;
                    objCFEComn.CompanyPraposal = rblproposal.SelectedValue;

                    objCFEComn.CompanyRegType = ddlRegType.SelectedValue;
                    objCFEComn.CompanyRegNo = txtRegistrationNo.Text;
                    objCFEComn.CompanyRegDate = txtRegDate.Text;
                    objCFEComn.FactoryType = ddlFactories.SelectedItem.Text;

                    objCFEComn.AuthRep_Name = txtPromoterName.Text;
                    objCFEComn.AuthRep_SoWoDo = txtSoWoDo.Text;
                    objCFEComn.AuthRep_DistrictID = ddlDistric.SelectedValue;
                    objCFEComn.AuthRep_MandalID = ddlMandal.SelectedValue;
                    objCFEComn.AuthRep_VillageID = ddlVillage.SelectedValue;
                    objCFEComn.AuthRep_Locality = txtLocality.Text;
                    objCFEComn.AuthRep_DoorNo = txtDoorNo.Text;
                    objCFEComn.AuthRep_Pincode = txtpincode.Text;
                    objCFEComn.AuthRep_Mobile = txtMobileno.Text;
                    objCFEComn.AuthRep_AltMobile = txtAltMobile.Text;
                    objCFEComn.AuthRep_Email = txtEmail.Text;
                    objCFEComn.AuthRep_TelNo = txtLandlineno.Text;
                    objCFEComn.AuthRep_DiffAbled = rblAbled.SelectedValue;
                    objCFEComn.AuthRep_Woman = rblWomen.SelectedValue;
                    objCFEComn.TotalEmp = lbltotalEmp.Text;
                    objCFEComn.DirectMale = txtMale.Text;
                    objCFEComn.DirectFemale = txtFemale.Text;
                    objCFEComn.DirectOthers = txtDirectOthers.Text;
                    objCFEComn.InDirectMale = txtIndirectMale.Text;
                    objCFEComn.InDirectFemale = txtIndirectFemale.Text;
                    objCFEComn.InDirectOthers = txtInDirectOthers.Text;


                    objCFEComn.RoadCutLocation = txtRdCutLocations.Text;
                    objCFEComn.ApprchRdWidth = txtExstngWidth.Text;
                    objCFEComn.AffectedExtended = txtAffectedArea.Text;
                    objCFEComn.AffectedRdWdng = rblAffectedroad.SelectedValue;
                    objCFEComn.ApprchRdType = ddlApproachRoad.SelectedValue;
                    objCFEComn.strctralLicNo = txtStrLicNo.Text;
                    objCFEComn.strctralMobileNo = txtStrEngnrMobileno.Text;
                    objCFEComn.strctralName = txtStrEngnrName.Text;
                    objCFEComn.ArchitechtureMobileNo = txtArchitectMobileno.Text;
                    objCFEComn.ArchitechtureName = txtArchitectName.Text;
                    objCFEComn.ArchitechtureLICNo = txtArchitectLicNo.Text;
                    objCFEComn.DevelopmentArea = txtDevelopmentArea.Text;

                    objCFEComn.RoadCut = txtRdCutlenght.Text;
                    objCFEComn.RoadCutLocation = txtRdCutLocations.Text;

                    result = objcfebal.InsertCFEIndustryDetails(objCFEComn);
                    ViewState["UnitID"] = result;
                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "All Details Submitted Successfully";
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

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/CFE/CFELineOfManufactureDetails.aspx");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }

        }

        public string Validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                if (string.IsNullOrEmpty(txtIndustryName.Text) || txtIndustryName.Text == "" || txtIndustryName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Company Registration  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPromoterName.Text) || txtPromoterName.Text == "" || txtPromoterName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name Promoter  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtSoWoDo.Text) || txtSoWoDo.Text == "" || txtSoWoDo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter S/O  \\n";
                    slno = slno + 1;
                }
                if (ddlDistric.SelectedIndex == -1 || ddlDistric.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Distric \\n";
                    slno = slno + 1;
                }
                if (ddlMandal.SelectedIndex == -1 || ddlMandal.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Mandal \\n";
                    slno = slno + 1;
                }
                if (ddlVillage.SelectedIndex == -1 || ddlVillage.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Village \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLocality.Text) || txtLocality.Text == "" || txtLocality.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Street Name  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDoorNo.Text) || txtDoorNo.Text == "" || txtDoorNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Door No\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtpincode.Text) || txtpincode.Text == "" || txtpincode.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Pincode No\\n";
                    slno = slno + 1;

                }
                if (string.IsNullOrEmpty(txtMobileno.Text) || txtMobileno.Text == "" || txtMobileno.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Mobile No\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAltMobile.Text) || txtAltMobile.Text == "" || txtAltMobile.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter AlterNative Mobile No\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEmail.Text) || txtEmail.Text == "" || txtEmail.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter EmailId No\\n";
                    slno = slno + 1;
                }
                if (ddlCompanyType.SelectedIndex == -1 || ddlCompanyType.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Organization \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLandlineno.Text) || txtLandlineno.Text == "" || txtLandlineno.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Landline No\\n";
                    slno = slno + 1;
                }
                if (rblproposal.SelectedIndex == -1 || rblproposal.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Proposal For \\n";
                    slno = slno + 1;
                }

                if (rblAbled.SelectedIndex == -1 || rblAbled.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Differently Abled \\n";
                    slno = slno + 1;
                }
                if (rblWomen.SelectedIndex == -1 || rblWomen.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select WOMEN \\n";
                    slno = slno + 1;
                }

                //if (string.IsNullOrEmpty(txtLandValue.Text) || txtLandValue.Text == "" || txtLandValue.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Land Value in Lakh\\n";
                //    slno = slno + 1;
                //}
                //if (string.IsNullOrEmpty(txtBuildingValue.Text) || txtBuildingValue.Text == "" || txtBuildingValue.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Building Value In Lakh\\n";
                //    slno = slno + 1;
                //}
                //if (string.IsNullOrEmpty(txtPlant_Machinery.Text) || txtPlant_Machinery.Text == "" || txtPlant_Machinery.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Plant & Machinary\\n";
                //    slno = slno + 1;
                //}
                //if (string.IsNullOrEmpty(txtTotalProjValue.Text) || txtTotalProjValue.Text == "" || txtTotalProjValue.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Total Value In Lakh\\n";
                //    slno = slno + 1;
                //}
                if (string.IsNullOrEmpty(txtMale.Text) || txtMale.Text == "" || txtMale.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Male\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtFemale.Text) || txtFemale.Text == "" || txtFemale.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Female\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtIndirectMale.Text) || txtIndirectMale.Text == "" || txtIndirectMale.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Direct Male\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtIndirectFemale.Text) || txtIndirectFemale.Text == "" || txtIndirectFemale.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Direct Female\\n";
                    slno = slno + 1;
                }
                if (ddlRegType.SelectedIndex == -1 || ddlRegType.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Category Registration  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtRegistrationNo.Text) || txtRegistrationNo.Text == "" || txtRegistrationNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Registration No\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtRegDate.Text) || txtRegDate.Text == "" || txtRegDate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Registration Date\\n";
                    slno = slno + 1;
                }
                if (ddlFactories.SelectedIndex == -1 || ddlFactories.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Factory \\n";
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