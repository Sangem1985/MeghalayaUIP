using System;
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
                { UnitID = Convert.ToString(Session["UNITID"]); }
                else
                {
                    string newurl = "~/User/CFE/CFEUserDashboard.aspx";
                    Response.Redirect(newurl);
                }

                Page.MaintainScrollPositionOnPostBack = true;

                if (!IsPostBack)
                {
                    BindDistricts();
                    BindCaste();
                    BindRegistrationType();
                    TotalAmount();
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

                    ddlUnitDistrict.DataSource = objDistrictModel;
                    ddlUnitDistrict.DataValueField = "DistrictId";
                    ddlUnitDistrict.DataTextField = "DistrictName";
                    ddlUnitDistrict.DataBind();
                }
                else
                {
                    ddlDistric.DataSource = null;
                    ddlDistric.DataBind();
                    ddlUnitDistrict.DataSource = null;
                    ddlUnitDistrict.DataBind();
                }
                AddSelect(ddlDistric);
                AddSelect(ddlMandal);
                AddSelect(ddlVillage);
                AddSelect(ddlUnitDistrict);
                AddSelect(ddlUnitMandal);
                AddSelect(ddlUnitVillage);

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
        public void BindCaste()
        {
            try
            {
                ddlSocialStatus.Items.Clear();

                List<MasterCaste> objCasteModel = new List<MasterCaste>();
                objCasteModel = mstrBAL.GetCaste();
                if (objCasteModel != null)
                {
                    ddlSocialStatus.DataSource = objCasteModel;
                    ddlSocialStatus.DataValueField = "CASTEID";
                    ddlSocialStatus.DataTextField = "CASTNAME";
                    ddlSocialStatus.DataBind();
                }
                else
                {
                    ddlSocialStatus.DataSource = null;
                    ddlSocialStatus.DataBind();
                }
                AddSelect(ddlSocialStatus);
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
                ds = objcfebal.GetEntrepreneurDetails(hdnUserID.Value, UnitID);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtIndustryName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEED_COMPANYNAME"]);
                        txtPromoterName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEED_PROMOTERNAME"]);
                        txtSoWoDo.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEED_SOWODO"]);

                        ddlDistric.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEED_DISTID"]);
                        ddlDistric_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlMandal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEED_MANDALID"]);
                        ddlMandal_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlVillage.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEED_VILLAGEID"]);
                        txtLocality.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEED_STREET"]);
                        txtDoorNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEED_DOORNO"]);
                        txtpincode.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEED_PINCODE"]);
                        txtMobileno.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEED_ALTMOBILE"]);
                        txtAltMobile.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEED_ALTMOBILE"]);
                        txtEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEED_EMAIL"]);
                        ddlCompanyType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEED_COMPANYTYPE"]);
                        txtLandlineno.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEED_TELEPHONENO"]);

                        rblproposal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEED_PROPOSALFOR"]);
                        ddlSocialStatus.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEED_CASTE"]);
                        rblAbled.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEED_ISDIFFABLED"]);
                        rblWomen.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEED_ISWOMENENTR"]);
                        rblMinority.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEED_ISMINORITY"]);
                       
                        txtMale.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEED_DIRECTMALE"]);
                        txtFemale.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEED_DIRECTFEMALE"]);
                        lbltotalEmp.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEED_TOTALEMP"]);
                        txtIndirectMale.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEED_INDIRECTMALE"]);
                        txtIndirectFemale.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEED_INDIRECTFEMALE"]);
                        ddlRegType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEED_REGISTRATIONTYPE"]);
                        txtRegistrationNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEED_REGISTRATIONNO"]);
                        txtRegDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEED_REGISTRATIONDATE"]);
                        ddlFactories.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEED_FACTORYTYPE"]);
                    }
                    else
                    {
                        txtIndustryName.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEQD_COMPANYNAME"]);
                        txtPromoterName.Text = Convert.ToString(ds.Tables[1].Rows[0]["REP_NAME"]);

                        ddlDistric.SelectedValue = Convert.ToString(ds.Tables[1].Rows[0]["REP_DISTRICTID"]);
                        ddlDistric_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlMandal.SelectedValue = Convert.ToString(ds.Tables[1].Rows[0]["REP_MANDALID"]);
                        ddlMandal_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlVillage.SelectedValue = Convert.ToString(ds.Tables[1].Rows[0]["REP_VILLAGEID"]);
                        txtLocality.Text = Convert.ToString(ds.Tables[1].Rows[0]["REP_LOCALITY"]);
                        txtpincode.Text = Convert.ToString(ds.Tables[1].Rows[0]["REP_PINCODE"]);
                        txtMobileno.Text = Convert.ToString(ds.Tables[1].Rows[0]["REP_MOBILE"]);
                        txtEmail.Text = Convert.ToString(ds.Tables[1].Rows[0]["REP_EMAIL"]);
                        ddlCompanyType.SelectedValue = Convert.ToString(ds.Tables[1].Rows[0]["CFEQD_COMPANYTYPE"]);

                        rblproposal.SelectedValue = Convert.ToString(ds.Tables[1].Rows[0]["CFEQD_PROPOSALFOR"]);                       
                        lbltotalEmp.Text = Convert.ToString(ds.Tables[1].Rows[0]["CFEQD_PROPEMP"]);
                        txtRegDate.Text = Convert.ToString(ds.Tables[1].Rows[0]["REGISTRATIONDATE"]);
                        if (Convert.ToString(ds.Tables[1].Rows[0]["CFEQD_GENREQ"]) == "Y")
                            ddlFactories.SelectedValue = "1";
                        else if (Convert.ToString(ds.Tables[1].Rows[0]["CFEQD_GENREQ"]) == "N")
                            ddlFactories.SelectedValue = "2";
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
        protected void ddlUnitDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlUnitMandal.ClearSelection();
                ddlUnitVillage.ClearSelection();
                if (ddlUnitDistrict.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlUnitMandal, ddlUnitDistrict.SelectedValue);
                }
                else return;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }
        }

        protected void ddlUnitMandal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlUnitVillage.ClearSelection();
                if (ddlUnitMandal.SelectedItem.Text != "--Select--")
                {
                    BindVillages(ddlUnitVillage, ddlUnitMandal.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
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
        protected void txtIndirectMale_TextChanged(object sender, EventArgs e)
        {
            TotalAmount();
        }

        protected void txtIndirectFemale_TextChanged(object sender, EventArgs e)
        {
            TotalAmount();
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

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Quesstionriids = "1001";
            string UnitId = "1";
            try
            {
                string ErrorMsg = "", result = "";
                ErrorMsg = Validations();
                if (ErrorMsg == "")
                {
                    CFEEntrepreneur objCFEEntrepreneur = new CFEEntrepreneur();
                    if (Convert.ToString(ViewState["UnitID"]) != "")
                    {
                        objCFEEntrepreneur.UNITID = Convert.ToString(ViewState["UnitID"]);
                    }
                    objCFEEntrepreneur.CreatedBy = hdnUserID.Value;
                    objCFEEntrepreneur.IPAddress = getclientIP();
                    objCFEEntrepreneur.Questionnariid = Quesstionriids;
                    objCFEEntrepreneur.UNITID = UnitId;
                    objCFEEntrepreneur.CompanyName = txtIndustryName.Text;
                    objCFEEntrepreneur.PromoterName = txtPromoterName.Text;
                    objCFEEntrepreneur.SoWoDoName = txtSoWoDo.Text;

                    objCFEEntrepreneur.DistrictID = ddlDistric.SelectedValue;
                    objCFEEntrepreneur.DistrictName = ddlDistric.SelectedItem.Text;
                    objCFEEntrepreneur.MandalID = ddlMandal.SelectedValue;
                    objCFEEntrepreneur.MandalName = ddlMandal.SelectedItem.Text;
                    objCFEEntrepreneur.VillageID = ddlVillage.SelectedValue;
                    objCFEEntrepreneur.VillageName = ddlVillage.SelectedItem.Text;
                    objCFEEntrepreneur.StreetName = txtLocality.Text;
                    objCFEEntrepreneur.DoorNo = txtDoorNo.Text;
                    objCFEEntrepreneur.Pincode = txtpincode.Text;
                    objCFEEntrepreneur.MobileNo = txtMobileno.Text;
                    objCFEEntrepreneur.AltMobileNo = txtAltMobile.Text;
                    objCFEEntrepreneur.Email = txtEmail.Text;
                    objCFEEntrepreneur.Organization = ddlCompanyType.SelectedValue;
                    objCFEEntrepreneur.TelePhoneNo = txtLandlineno.Text;
                    objCFEEntrepreneur.ProposalFor = rblproposal.SelectedValue;
                    objCFEEntrepreneur.SocialStatus = ddlSocialStatus.SelectedValue;
                    objCFEEntrepreneur.IsDiffAbled = rblAbled.SelectedValue;
                    objCFEEntrepreneur.IsWomenEntr = rblWomen.SelectedValue;
                    objCFEEntrepreneur.IsMinority = rblMinority.SelectedValue;
                    //objCFEEntrepreneur.LandValue = txtLandValue.Text;
                    // objCFEEntrepreneur.BuildingValue = txtBuildingValue.Text;
                    //objCFEEntrepreneur.Plant_Machinary = txtPlant_Machinery.Text;
                    //objCFEEntrepreneur.TotalProjectValue = txtTotalProjValue.Text;
                    objCFEEntrepreneur.DirectMale = txtMale.Text;
                    objCFEEntrepreneur.DirectFemale = txtFemale.Text;
                    objCFEEntrepreneur.TotalEmp = lbltotalEmp.Text;
                    objCFEEntrepreneur.InDirectMale = txtIndirectMale.Text;
                    objCFEEntrepreneur.InDirectFemale = txtIndirectFemale.Text;
                    objCFEEntrepreneur.RegistrationType = ddlRegType.SelectedValue;
                    objCFEEntrepreneur.RegistrationNo = txtRegistrationNo.Text;
                    objCFEEntrepreneur.RegistrationDate = txtRegDate.Text;
                    objCFEEntrepreneur.FactoryType = ddlFactories.SelectedValue;

                    result = objcfebal.InsertEntrepreneurDet(objCFEEntrepreneur);
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

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/CFE/CFELandDetails.aspx");
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
                if (ddlSocialStatus.SelectedIndex == -1 || ddlSocialStatus.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Social Status \\n";
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
                if (rblMinority.SelectedIndex == -1 || rblMinority.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Minority \\n";
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