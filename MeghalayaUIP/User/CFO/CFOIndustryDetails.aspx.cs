using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MeghalayaUIP.BAL.CFOBAL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;


namespace MeghalayaUIP.User.CFO
{
    public partial class CFOIndustryDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFOBAL objcfobal = new CFOBAL();
        string UnitID, ErrorMsg = "";

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
                    if (Convert.ToString(Session["CFOUNITID"]) != "")
                    {
                        UnitID = Convert.ToString(Session["CFOUNITID"]);
                    }
                    else
                    {
                        string newurl = "~/User/CFO/CFOUserDashboard.aspx";
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
        public void BindData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfobal.GetCFOIndustryDetails(hdnUserID.Value, Convert.ToString(Session["CFOUNITID"]));
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        hdnPreRegUID.Value = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_PREREGUIDNO"]);
                        txtIndustryName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_COMPANYNAME"]);
                        ddlCompanyType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_COMPANYTYPE"]);
                        rblproposal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_PROPOSALFOR"]);
                        ddlRegType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_REGTYPE"]);
                        txtUdyamorIEMNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_REGNO"]);
                        txtRegDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["REGDATE"]);
                        ddlFactories.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_FACTORYTYPE"]);
                        txtPromoterName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_REPNAME"]);
                        txtSoWoDo.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_REPSoWoDo"]);
                        txtEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_REPEMAIL"]);
                        txtMobileno.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_REPMOBILE"]);
                        txtAltMobile.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_REPALTMOBILE"]);
                        txtLandlineno.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_REPTELPHNO"]);
                        txtDoorNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_REPDOORNO"]);
                        txtLocality.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_REPLOCALITY"]);
                        ddlDistric.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_REPDISTRICTID"]);
                        ddlDistric_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlMandal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_REPMANDALID"]);
                        ddlMandal_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlVillage.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_REPVILLAGEID"]);
                        txtpincode.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_REPPINCODE"]);

                        rblAbled.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_REPISDIFFABLED"]);
                        rblWomen.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_REPISWOMANENTR"]);
                        txtDevelopmentArea.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_DEVELOPAREA"]);

                        txtArchitectName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_ARCHTCTNAME"]);
                        txtArchitectLicNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_ARCHTCTLICNO"]);
                        txtArchitectMobileno.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_ARCHTCTMOBILE"]);
                        txtStrEngnrName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_SRTCTENGNRNAME"]);
                        txtStrLicNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_SRTCTENGNRLICNO"]);
                        txtStrEngnrMobileno.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_SRTCTENGNRMOBILE"]);
                        ddlApproachRoad.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_APPROACHROADTYPE"]);
                        txtExstngWidth.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_APPROACHROADWIDTH"]);
                        rblAffectedroad.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_AFFECTEDRDWDNG"]);
                        rblAffectedroad_SelectedIndexChanged(null, EventArgs.Empty);

                        txtAffectedArea.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_AFFECTEDRDAREA"]);
                        lbltotalEmp.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_TOTALEMP"]);
                        txtMale.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_DIRECTMALE"]);
                        txtFemale.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_DIRECTFEMALE"]);
                        txtDirectOthers.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_DIRECTOTHERS"]);

                        txtIndirectMale.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_INDIRECTMALE"]);
                        txtIndirectFemale.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_INDIRECTFEMALE"]);
                        txtInDirectOthers.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_INDIRECTOTHERS"]);
                        txtRdCutlenght.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_RDCUTLENGTH"]);
                        txtRdCutLocations.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFOID_RDCUTLOCATIONS"]);

                        if (txtRdCutlenght.Text != "")
                        { divRDctng.Visible = true; hdngRdCtng.Visible = true; }
                     
                    }
                    else
                    {
                        hdnPreRegUID.Value = Convert.ToString(ds.Tables[1].Rows[0]["CFOQD_PREREGUIDNO"]);
                        txtIndustryName.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOQD_COMPANYNAME"]);
                        ddlCompanyType.SelectedValue = Convert.ToString(ds.Tables[1].Rows[0]["CFOQD_COMPANYTYPE"]);
                        rblproposal.SelectedValue = Convert.ToString(ds.Tables[1].Rows[0]["CFOQD_PROPOSALFOR"]);
                        ddlRegType.SelectedValue = Convert.ToString(ds.Tables[1].Rows[0]["COMPANYREGTYPE"]);
                        txtUdyamorIEMNo.Text = Convert.ToString(ds.Tables[1].Rows[0]["COMPANYREGNO"]);
                        txtRegDate.Text = Convert.ToString(ds.Tables[1].Rows[0]["REGDATE"]);

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
                        lbltotalEmp.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFOQD_PROPEMP"]);
                        //if (ds.Tables[1].Rows.Count > 0)
                        //{
                        //    if (Convert.ToString(ds.Tables[1].Rows[0]["CFOQD_GENREQ"]) == "Y")
                        //        ddlFactories.SelectedValue = "Hazardous";
                        //    else if (Convert.ToString(ds.Tables[1].Rows[0]["CFOQD_GENREQ"]) == "N")
                        //        ddlFactories.SelectedValue = "Non Hazardous";
                        //    if (Convert.ToString(ds.Tables[1].Rows[0]["CFOQD_RDCTNGREQ"]) == "Y")
                        //    { divRDctng.Visible = true; hdngRdCtng.Visible = true; }
                        //}

                    }

                    txtIndustryName.Enabled = false;
                    txtPromoterName.Enabled = false;
                    ddlDistric.Enabled = false;
                    ddlMandal.Enabled = false;
                    ddlVillage.Enabled = false;
                    txtLocality.Enabled = false;
                    txtpincode.Enabled = false;
                    txtMobileno.Enabled = false;
                    txtEmail.Enabled = false;
                    //ddlCompanyType.Enabled = false;
                    //rblproposal.Enabled = false;
                    //lbltotalEmp.Enabled = false;
                    txtRegDate.Enabled = false;
                 //   ddlFactories.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void ddlDistric_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlMandal.ClearSelection();
                ddlMandal.Items.Clear();
                AddSelect(ddlMandal);
                ddlVillage.ClearSelection();
                ddlVillage.Items.Clear();
                AddSelect(ddlVillage);
                if (ddlDistric.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlMandal, ddlDistric.SelectedValue);
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
        protected void rblAffectedroad_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblAffectedroad.SelectedValue == "Y")
                {
                    divAffectArea.Visible = true;
                }
                else
                {
                    divAffectArea.Visible = false;
                    txtAffectedArea.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg = ""; string result = "";

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
                    CFOCommonDet objCFOComn = new CFOCommonDet();

                    objCFOComn.UNITID = Convert.ToString(Session["CFOUNITID"]);
                    objCFOComn.CreatedBy = hdnUserID.Value;
                    objCFOComn.PreRegUID = hdnPreRegUID.Value;
                    objCFOComn.IPAddress = getclientIP();
                    objCFOComn.UNITID = Convert.ToString(Session["CFOUNITID"]);
                    objCFOComn.CompanyName = txtIndustryName.Text;
                    objCFOComn.CompanyType = ddlCompanyType.SelectedValue;
                    objCFOComn.CompanyPraposal = rblproposal.SelectedValue;

                    objCFOComn.CompanyRegType = ddlRegType.SelectedValue;
                    objCFOComn.CompanyRegNo = txtUdyamorIEMNo.Text;
                    objCFOComn.CompanyRegDate = txtRegDate.Text;
                    objCFOComn.FactoryType = ddlFactories.SelectedValue;

                    objCFOComn.AuthRep_Name = txtPromoterName.Text.Trim();
                    objCFOComn.AuthRep_SoWoDo = txtSoWoDo.Text;
                    objCFOComn.AuthRep_DistrictID = ddlDistric.SelectedValue;
                    objCFOComn.AuthRep_MandalID = ddlMandal.SelectedValue;
                    objCFOComn.AuthRep_VillageID = ddlVillage.SelectedValue;
                    objCFOComn.AuthRep_Locality = txtLocality.Text;
                    objCFOComn.AuthRep_DoorNo = txtDoorNo.Text;
                    objCFOComn.AuthRep_Pincode = txtpincode.Text;
                    objCFOComn.AuthRep_Mobile = txtMobileno.Text;
                    objCFOComn.AuthRep_AltMobile = txtAltMobile.Text;
                    objCFOComn.AuthRep_Email = txtEmail.Text;
                    objCFOComn.AuthRep_TelNo = txtLandlineno.Text;
                    objCFOComn.AuthRep_DiffAbled = rblAbled.SelectedValue;
                    objCFOComn.AuthRep_Woman = rblWomen.SelectedValue;
                    objCFOComn.TotalEmp = lbltotalEmp.Text;
                    objCFOComn.DirectMale = txtMale.Text;
                    objCFOComn.DirectFemale = txtFemale.Text;
                    objCFOComn.DirectOthers = txtDirectOthers.Text;
                    objCFOComn.InDirectMale = txtIndirectMale.Text;
                    objCFOComn.InDirectFemale = txtIndirectFemale.Text;
                    objCFOComn.InDirectOthers = txtInDirectOthers.Text;


                    objCFOComn.RoadCutLocation = txtRdCutLocations.Text;
                    objCFOComn.ApprchRdWidth = txtExstngWidth.Text;
                    objCFOComn.AffectedExtended = txtAffectedArea.Text;
                    objCFOComn.AffectedRdWdng = rblAffectedroad.SelectedValue;
                    objCFOComn.ApprchRdType = ddlApproachRoad.SelectedValue;
                    objCFOComn.strctralLicNo = txtStrLicNo.Text;
                    objCFOComn.strctralMobileNo = txtStrEngnrMobileno.Text;
                    objCFOComn.strctralName = txtStrEngnrName.Text.Trim();
                    objCFOComn.ArchitechtureMobileNo = txtArchitectMobileno.Text;
                    objCFOComn.ArchitechtureName = txtArchitectName.Text.Trim();
                    objCFOComn.ArchitechtureLICNo = txtArchitectLicNo.Text;
                    objCFOComn.DevelopmentArea = txtDevelopmentArea.Text;

                    objCFOComn.RoadCut = txtRdCutlenght.Text;
                    objCFOComn.RoadCutLocation = txtRdCutLocations.Text;

                    result = objcfobal.InsertCFOIndustryDetails(objCFOComn);
                    // ViewState["UnitID"] = result;
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
        public string Validations()
        {
            try
            {
                int slno = 1;
                List<TextBox> emptyTextboxes = FindEmptyTextboxes(divText);

                string errormsg = "";
                if (string.IsNullOrEmpty(txtIndustryName.Text) || txtIndustryName.Text == "" || txtIndustryName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Company Registration  \\n";
                    slno = slno + 1;
                }
                if (ddlCompanyType.SelectedIndex == -1 || ddlCompanyType.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Type of Company \\n";
                    slno = slno + 1;
                }
                if (rblproposal.SelectedIndex == -1 || rblproposal.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Proposal For \\n";
                    slno = slno + 1;
                }
                if (ddlRegType.SelectedIndex == -1 || ddlRegType.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Category Registration  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtUdyamorIEMNo.Text) || txtUdyamorIEMNo.Text == "" || txtUdyamorIEMNo.Text == null)
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
                    errormsg = errormsg + slno + ". Please Select Factory Type \\n";
                    slno = slno + 1;
                }


                if (string.IsNullOrEmpty(txtPromoterName.Text.Trim()) || txtPromoterName.Text.Trim() == "" || txtPromoterName.Text.Trim() == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name Promoter  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtSoWoDo.Text) || txtSoWoDo.Text == "" || txtSoWoDo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter S/O.  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEmail.Text) || txtEmail.Text == "" || txtEmail.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter EmailId No\\n";
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
                //if (string.IsNullOrEmpty(txtLandlineno.Text) || txtLandlineno.Text == "" || txtLandlineno.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Landline No\\n";
                //    slno = slno + 1;
                //}
                if (string.IsNullOrEmpty(txtDoorNo.Text) || txtDoorNo.Text == "" || txtDoorNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Door No\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLocality.Text) || txtLocality.Text == "" || txtLocality.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Street Name  \\n";
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
                if (string.IsNullOrEmpty(txtpincode.Text) || txtpincode.Text == "" || txtpincode.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Pincode No\\n";
                    slno = slno + 1;

                }
                if (rblWomen.SelectedIndex == -1 || rblWomen.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Women Entrepreneur or not \\n";
                    slno = slno + 1;
                }
                if (rblAbled.SelectedIndex == -1 || rblAbled.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Differently Abled or not \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtArchitectName.Text.Trim()) || txtArchitectName.Text.Trim() == "" || txtArchitectName.Text.Trim() == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Architect Name\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtArchitectLicNo.Text) || txtArchitectLicNo.Text == "" || txtArchitectLicNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Architect LIC No\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtArchitectMobileno.Text) || txtArchitectMobileno.Text == "" || txtArchitectMobileno.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Architect Mobile No\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtStrEngnrName.Text.Trim()) || txtStrEngnrName.Text.Trim() == "" || txtStrEngnrName.Text.Trim() == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Structural Engineer Name\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtStrLicNo.Text) || txtStrLicNo.Text == "" || txtStrLicNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Structural Engineer LIC No\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtStrEngnrMobileno.Text) || txtStrEngnrMobileno.Text == "" || txtStrEngnrMobileno.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Structural Engineer Mobile No\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDevelopmentArea.Text) || txtDevelopmentArea.Text == "" || txtDevelopmentArea.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Proposed Area for Development(in Sq. mts) \\n";
                    slno = slno + 1;
                }
                if (ddlApproachRoad.SelectedIndex == -1 || ddlApproachRoad.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Type of Approach Road \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtExstngWidth.Text) || txtExstngWidth.Text == "" || txtExstngWidth.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Existing Width of Approach Road(in feet) \\n";
                    slno = slno + 1;
                }
                if (rblAffectedroad.SelectedIndex == -1 || rblAffectedroad.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Affected in Road Widening or not \\n";
                    slno = slno + 1;
                }
                if (rblAffectedroad.SelectedValue == "Y")
                {

                    if (string.IsNullOrEmpty(txtAffectedArea.Text) || txtAffectedArea.Text == "" || txtAffectedArea.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Extent of affected area in sq.mts* \\n";
                        slno = slno + 1;
                    }
                }

                if (string.IsNullOrEmpty(txtMale.Text) || txtMale.Text == "" || txtMale.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Male Employee \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtFemale.Text) || txtFemale.Text == "" || txtFemale.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Female Employee \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDirectOthers.Text) || txtDirectOthers.Text == "" || txtDirectOthers.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Direct Other Employee\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtIndirectMale.Text) || txtIndirectMale.Text == "" || txtIndirectMale.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Direct Male Employee\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtIndirectFemale.Text) || txtIndirectFemale.Text == "" || txtIndirectFemale.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Direct Female Employee\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtInDirectOthers.Text) || txtInDirectOthers.Text == "" || txtInDirectOthers.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Indirect Other Employee\\n";
                    slno = slno + 1;
                }
                if (divRDctng.Visible == true)
                {
                    if (string.IsNullOrEmpty(txtRdCutlenght.Text) || txtRdCutlenght.Text == "" || txtRdCutlenght.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Indirect Other Employee\\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtRdCutLocations.Text) || txtRdCutLocations.Text == "" || txtRdCutLocations.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Indirect Other Employee\\n";
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
        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/CFO/CFOCombinedApplication.aspx");
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
                }
                else
                {
                    txtUdyamorIEMNo.Enabled = false;
                    lblregntype.InnerText = " Registration No *";
                    txtUdyamorIEMNo.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave_Click(sender, e);
                if (ErrorMsg == "")
                    Response.Redirect("~/User/CFO/CFOLineOfManufactureDetails.aspx");
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
    }
}