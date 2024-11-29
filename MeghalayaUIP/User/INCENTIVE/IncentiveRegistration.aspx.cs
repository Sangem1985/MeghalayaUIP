using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.INCBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.INCENTIVE
{
    public partial class IncentiveRegistration : System.Web.UI.Page
    {
        int index; string ErrorMsg1 = "";
        INCBAL iNCBAL = new INCBAL();
        MasterBAL mstrBAL = new MasterBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FixedCapital();
                SourceFinance();
                EmploymentType();
                BindConstitutionType();
                BindDistricts();
            }

        }

        protected void Link1_Click(object sender, EventArgs e)
        {
            MVprereg.ActiveViewIndex = 0;
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

        protected void Link2_Click(object sender, EventArgs e)
        {
            MVprereg.ActiveViewIndex = 1;
        }

        protected void Link3_Click(object sender, EventArgs e)
        {
            MVprereg.ActiveViewIndex = 2;
        }
        protected void FixedCapital()
        {
            try
            {
                DataTable dt = new DataTable();

                dt = iNCBAL.GetFixedCaptial();
                if (dt.Rows.Count > 0)
                {
                    GVFiexed.DataSource = dt;
                    GVFiexed.DataBind();
                }
                else
                {
                    GVFiexed.DataSource = null;
                    GVFiexed.DataBind();
                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void SourceFinance()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = iNCBAL.GetSourceFinance();

                if (dt.Rows.Count > 0)
                {
                    GVSource.DataSource = dt;
                    GVSource.DataBind();
                }
                else
                {
                    GVSource.DataSource = null;
                    GVSource.DataBind();
                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void EmploymentType()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = iNCBAL.GetEmploymentGeneration();

                if (dt.Rows.Count > 0)
                {
                    GVGeneration.DataSource = dt;
                    GVGeneration.DataBind();
                }
                else
                {
                    GVGeneration.DataSource = null;
                    GVGeneration.DataBind();
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
        protected void BindDistricts()
        {

            try
            {

                ddlDistrict.Items.Clear();
                ddlMandal.Items.Clear();
                ddlVillage.Items.Clear();
                ddlDistrictoffice.Items.Clear();
                ddlMandloffice.Items.Clear();
                ddlVillageoffice.Items.Clear();
                ddlDistrictReg.Items.Clear();
                ddlMandlReg.Items.Clear();
                ddlVillageReg.Items.Clear();
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

                    ddlDistrictoffice.DataSource = objDistrictModel;
                    ddlDistrictoffice.DataValueField = "DistrictId";
                    ddlDistrictoffice.DataTextField = "DistrictName";
                    ddlDistrictoffice.DataBind();


                    ddlDistrictReg.DataSource = objDistrictModel;
                    ddlDistrictReg.DataValueField = "DistrictId";
                    ddlDistrictReg.DataTextField = "DistrictName";
                    ddlDistrictReg.DataBind();
                }
                else
                {
                    ddlDistrict.DataSource = null;
                    ddlDistrict.DataBind();

                    ddlDistrictoffice.DataSource = null;
                    ddlDistrictoffice.DataBind();

                    ddlDistrictReg.DataSource = null;
                    ddlDistrictReg.DataBind();
                }
                AddSelect(ddlDistrict);
                AddSelect(ddlMandal);
                AddSelect(ddlVillage);

                AddSelect(ddlDistrictoffice);
                AddSelect(ddlMandloffice);
                AddSelect(ddlVillageoffice);

                AddSelect(ddlDistrictReg);
                AddSelect(ddlMandlReg);
                AddSelect(ddlVillageReg);

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
        public string Step1validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                if (ddlcompanytype.SelectedIndex == -1 || ddlcompanytype.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Unit Address District...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtUnitName.Text) || txtUnitName.Text == "" || txtUnitName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Unit Address Name of Unit...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLocality.Text) || txtLocality.Text == "" || txtLocality.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Factory/Unit Address Area/Locality...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtBlock.Text) || txtBlock.Text == "" || txtBlock.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Factory/Unit Address C&RD Block...! \\n";
                    slno = slno + 1;
                }
                if (ddlDistrict.SelectedIndex == -1 || ddlDistrict.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Factory/Unit Address District...! \\n";
                    slno = slno + 1;
                }
                if (ddlMandal.SelectedIndex == -1 || ddlMandal.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Factory/Unit Address Mandal...! \\n";
                    slno = slno + 1;
                }
                if (ddlVillage.SelectedIndex == -1 || ddlVillage.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Factory/Unit Address Village...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPost.Text) || txtPost.Text == "" || txtPost.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Factory/Unit Address Post Office...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEmail.Text) || txtEmail.Text == "" || txtEmail.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Factory/Unit Address Email...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtMobileNo.Text) || txtMobileNo.Text == "" || txtMobileNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Factory/Unit Address Landline/Mobile NO...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtpincode.Text) || txtpincode.Text == "" || txtpincode.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Factory/Unit Address Pincode...! \\n";
                    slno = slno + 1;
                }


                if (string.IsNullOrEmpty(txtAreaoffice.Text) || txtAreaoffice.Text == "" || txtAreaoffice.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Office Address Area/Locality...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtCDBlockoffice.Text) || txtCDBlockoffice.Text == "" || txtCDBlockoffice.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Office Address C&RD Block...! \\n";
                    slno = slno + 1;
                }
                if (ddlDistrictoffice.SelectedIndex == -1 || ddlDistrictoffice.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Office Address District...! \\n";
                    slno = slno + 1;
                }
                if (ddlMandloffice.SelectedIndex == -1 || ddlMandloffice.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Office Address Mandal...! \\n";
                    slno = slno + 1;
                }
                if (ddlVillageoffice.SelectedIndex == -1 || ddlVillageoffice.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Office Address Village...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPostoffice.Text) || txtPostoffice.Text == "" || txtPostoffice.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Office Address Post Office...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEmailoffice.Text) || txtEmailoffice.Text == "" || txtEmailoffice.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Office Address Email...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLandoffice.Text) || txtLandoffice.Text == "" || txtLandoffice.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Office Address Landline/Mobile NO...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPincodeoffice.Text) || txtPincodeoffice.Text == "" || txtPincodeoffice.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Office Address Pincode...! \\n";
                    slno = slno + 1;
                }


                if (string.IsNullOrEmpty(txtAreaReg.Text) || txtAreaReg.Text == "" || txtAreaReg.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Registered Office's Address Area/Locality...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtCDReg.Text) || txtCDReg.Text == "" || txtCDReg.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Registered Office's Address C&RD Block...! \\n";
                    slno = slno + 1;
                }
                if (ddlDistrictReg.SelectedIndex == -1 || ddlDistrictReg.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Registered Office's Address District...! \\n";
                    slno = slno + 1;
                }
                if (ddlMandlReg.SelectedIndex == -1 || ddlMandlReg.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Registered Office's Address Mandal...! \\n";
                    slno = slno + 1;
                }
                if (ddlVillageReg.SelectedIndex == -1 || ddlVillageReg.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Registered Office's Address Village...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPostReg.Text) || txtPostReg.Text == "" || txtPostReg.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Registered Office's Address Post Office...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEmailReg.Text) || txtEmailReg.Text == "" || txtEmailReg.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Registered Office's Address Email...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLandReg.Text) || txtLandReg.Text == "" || txtLandReg.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Registered Office's Address Landline/Mobile NO...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPicReg.Text) || txtPicReg.Text == "" || txtPicReg.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Registered Office's Address Pincode...! \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtNewUnit.Text) || txtNewUnit.Text == "" || txtNewUnit.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter In case of New unit...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtCompnyRegDt.Text) || txtCompnyRegDt.Text == "" || txtCompnyRegDt.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Date of commencement of commercial production...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtUndergoing.Text) || txtUndergoing.Text == "" || txtUndergoing.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter existing unit undergoing expansion...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtProduction.Text) || txtProduction.Text == "" || txtProduction.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Date of commencing commercial production...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtcommercial.Text) || txtcommercial.Text == "" || txtcommercial.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Date of commencing commercial production...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtUnitNew1.Text) || txtUnitNew1.Text == "" || txtUnitNew1.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter case of New unit...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEMPart.Text) || txtEMPart.Text == "" || txtEMPart.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter case of New unit...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEMPartDate.Text) || txtEMPartDate.Text == "" || txtEMPartDate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter EM Part date...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtIEMDate.Text) || txtIEMDate.Text == "" || txtIEMDate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter IEM No...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(IEMdate.Text) || IEMdate.Text == "" || IEMdate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter IEM date...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtCaseunder.Text) || txtCaseunder.Text == "" || txtCaseunder.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter existing unit undergoing expansion...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtIEM.Text) || txtIEM.Text == "" || txtIEM.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Permanent (PMT) Registration/IEM/EM Part II No...! \\n";
                    slno = slno + 1;
                }


                return errormsg;
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

        protected void ddlDistrictoffice_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlMandloffice.ClearSelection();
                ddlMandloffice.Items.Clear();
                AddSelect(ddlMandloffice);
                ddlVillageoffice.ClearSelection();
                ddlVillageoffice.Items.Clear();
                AddSelect(ddlVillageoffice);
                if (ddlDistrictoffice.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlMandloffice, ddlDistrictoffice.SelectedValue);
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

        protected void ddlMandloffice_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlVillageoffice.ClearSelection();
                ddlVillageoffice.Items.Clear();
                AddSelect(ddlVillageoffice);

                if (ddlMandloffice.SelectedItem.Text != "--Select--")
                {
                    BindVillages(ddlVillageoffice, ddlMandloffice.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void ddlDistrictReg_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlMandlReg.ClearSelection();
                ddlMandlReg.Items.Clear();
                AddSelect(ddlMandlReg);
                ddlVillageReg.ClearSelection();
                ddlVillageReg.Items.Clear();
                AddSelect(ddlVillageReg);
                if (ddlDistrictReg.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlMandlReg, ddlDistrictReg.SelectedValue);
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

        protected void ddlMandlReg_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlVillageReg.ClearSelection();
                ddlVillageReg.Items.Clear();
                AddSelect(ddlVillageReg);

                if (ddlMandlReg.SelectedItem.Text != "--Select--")
                {
                    BindVillages(ddlVillageReg, ddlMandlReg.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnAddLOM_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtexpansion.Text.Trim()) || string.IsNullOrEmpty(txtAfter.Text) || string.IsNullOrEmpty(txtPrior.Text) || string.IsNullOrEmpty(txtdiversification.Text))
                {
                    lblmsg0.Text = "Please Enter All Details of Manufacture Items";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("MemberName", typeof(string));
                    dt.Columns.Add("Designation", typeof(string));
                    dt.Columns.Add("MemberName", typeof(string));
                    dt.Columns.Add("Designation", typeof(string));

                    if (ViewState["IncentiveReg"] != null)
                    {
                        dt = (DataTable)ViewState["IncentiveReg"];
                    }
                    DataRow dr = dt.NewRow();
                    dr["MemberName"] = txtexpansion.Text.Trim();
                    dr["Designation"] = txtAfter.Text;
                    dr["MemberName"] = txtPrior.Text;
                    dr["Designation"] = txtdiversification.Text;

                    dt.Rows.Add(dr);
                    gvTeamMembers.Visible = true;
                    gvTeamMembers.DataSource = dt;
                    gvTeamMembers.DataBind();
                    ViewState["IncentiveReg"] = dt;

                    txtexpansion.Text = "";
                    txtAfter.Text = "";
                    txtPrior.Text = "";
                    txtdiversification.Text = "";

                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnbuttons_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFinancial.Text.Trim()) || string.IsNullOrEmpty(txtloanterm.Text) || string.IsNullOrEmpty(txtletterno.Text) || string.IsNullOrEmpty(txtCapitalAmount.Text))
                {
                    lblmsg0.Text = "Please Enter All Details of Manufacture Items";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("MemberName", typeof(string));
                    dt.Columns.Add("Designation", typeof(string));
                    dt.Columns.Add("MemberName", typeof(string));
                    dt.Columns.Add("Designation", typeof(string));

                    if (ViewState["IncentiveLoan"] != null)
                    {
                        dt = (DataTable)ViewState["IncentiveLoan"];
                    }
                    DataRow dr = dt.NewRow();
                    dr["MemberName"] = txtFinancial.Text.Trim();
                    dr["Designation"] = txtloanterm.Text;
                    dr["MemberName"] = txtletterno.Text;
                    dr["Designation"] = txtCapitalAmount.Text;

                    dt.Rows.Add(dr);
                    GVLoan.Visible = true;
                    GVLoan.DataSource = dt;
                    GVLoan.DataBind();
                    ViewState["IncentiveLoan"] = dt;

                    txtFinancial.Text = "";
                    txtloanterm.Text = "";
                    txtletterno.Text = "";
                    txtCapitalAmount.Text = "";
                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtName21.Text.Trim()) || string.IsNullOrEmpty(txtamounnt22.Text) || string.IsNullOrEmpty(txtPan23.Text) || string.IsNullOrEmpty(txtPayment24.Text))
                {
                    lblmsg0.Text = "Please Enter All Details of Manufacture Items";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("MemberName", typeof(string));
                    dt.Columns.Add("Designation", typeof(string));
                    dt.Columns.Add("MemberName", typeof(string));
                    dt.Columns.Add("Designation", typeof(string));

                    if (ViewState["IncentiveEquity"] != null)
                    {
                        dt = (DataTable)ViewState["IncentiveEquity"];
                    }
                    DataRow dr = dt.NewRow();
                    dr["MemberName"] = txtName21.Text.Trim();
                    dr["Designation"] = txtamounnt22.Text;
                    dr["MemberName"] = txtPan23.Text;
                    dr["Designation"] = txtPayment24.Text;

                    dt.Rows.Add(dr);
                    GVequity.Visible = true;
                    GVequity.DataSource = dt;
                    GVequity.DataBind();
                    ViewState["IncentiveEquity"] = dt;

                    txtName21.Text = "";
                    txtamounnt22.Text = "";
                    txtPan23.Text = "";
                    txtPayment24.Text = "";
                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtName25.Text.Trim()) || string.IsNullOrEmpty(txtAmount26.Text) || string.IsNullOrEmpty(txtpan27.Text) || string.IsNullOrEmpty(txtPayment28.Text))
                {
                    lblmsg0.Text = "Please Enter All Details of Manufacture Items";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("MemberName", typeof(string));
                    dt.Columns.Add("Designation", typeof(string));
                    dt.Columns.Add("MemberName", typeof(string));
                    dt.Columns.Add("Designation", typeof(string));

                    if (ViewState["IncentiveUnsecuredLoan"] != null)
                    {
                        dt = (DataTable)ViewState["IncentiveUnsecuredLoan"];
                    }
                    DataRow dr = dt.NewRow();
                    dr["MemberName"] = txtName25.Text.Trim();
                    dr["Designation"] = txtAmount26.Text;
                    dr["MemberName"] = txtpan27.Text;
                    dr["Designation"] = txtPayment28.Text;

                    dt.Rows.Add(dr);
                    GVUnsecuredloan.Visible = true;
                    GVUnsecuredloan.DataSource = dt;
                    GVUnsecuredloan.DataBind();
                    ViewState["IncentiveUnsecuredLoan"] = dt;

                    txtName25.Text = "";
                    txtAmount26.Text = "";
                    txtpan27.Text = "";
                    txtPayment28.Text = "";
                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                int result = 0;
                ErrorMsg1 = Step1validations();
                if (ErrorMsg1 == "")
                {
                    result = SaveBasicDetails();
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
        public int SaveBasicDetails()
        {
            IncentiveReg1 IncentiveReg = new IncentiveReg1();


            IncentiveReg.UnitName = txtUnitName.Text;
            IncentiveReg.CompanyType = ddlcompanytype.SelectedValue;
            IncentiveReg.AreaLocality = txtLocality.Text;
            IncentiveReg.CRDBlock = txtBlock.Text;
            IncentiveReg.PostOffice = txtPost.Text;
            IncentiveReg.District = ddlDistrict.SelectedValue;
            IncentiveReg.Mandal = ddlMandal.SelectedValue;
            IncentiveReg.Village = ddlVillage.SelectedValue;
            IncentiveReg.Emailid = txtEmail.Text;
            IncentiveReg.MobileNo = txtMobileNo.Text;
            IncentiveReg.Pincode = txtpincode.Text;
            IncentiveReg.OfficeAddAreaLocality = txtAreaoffice.Text;
            IncentiveReg.OfficeAddCRDBlock = txtCDBlockoffice.Text;
            IncentiveReg.OfficeAddPostOffice = txtPostoffice.Text;
            IncentiveReg.OfficeAddDistrict = ddlDistrictoffice.SelectedValue;
            IncentiveReg.OfficeAddMandal = ddlMandloffice.SelectedValue;
            IncentiveReg.OfficeAddVillage = ddlVillageoffice.SelectedValue;
            IncentiveReg.OfficeAddEmailid = txtEmailoffice.Text;
            IncentiveReg.OfficeAddMobileNo = txtLandoffice.Text;
            IncentiveReg.OfficeAddPincode = txtPincodeoffice.Text;
            IncentiveReg.RegOfficeAreaLocality = txtAreaReg.Text;
            IncentiveReg.RegOfficeCRDBlock = txtCDReg.Text;
            IncentiveReg.RegOfficePostOffice = txtPostReg.Text;
            IncentiveReg.RegOfficeDistrict = ddlDistrictReg.SelectedValue;
            IncentiveReg.RegOfficeMandal = ddlMandlReg.SelectedValue;
            IncentiveReg.RegOfficeVillage = ddlVillageReg.SelectedValue;
            IncentiveReg.RegOfficeEmailid = txtEmailReg.Text;
            IncentiveReg.RegOfficeMobileNo = txtLandReg.Text;
            IncentiveReg.RegOfficePincode = txtPicReg.Text;
            IncentiveReg.NewUnit = txtNewUnit.Text;
            IncentiveReg.DateofProduction = txtCompnyRegDt.Text;
            IncentiveReg.UnderExpansion = txtUndergoing.Text;
            IncentiveReg.DateExpansion = txtProduction.Text;
            IncentiveReg.DatebeforeExpansion = txtcommercial.Text;
            IncentiveReg.RegNewUnit = txtUnitNew1.Text;
            IncentiveReg.EMPARTNO = txtEMPart.Text;
            IncentiveReg.EmpartDate = txtEMPartDate.Text;
            IncentiveReg.IEMNO = txtIEMDate.Text;
            IncentiveReg.IEMDATE = IEMdate.Text;
            IncentiveReg.IEMExpansion = txtCaseunder.Text;
            IncentiveReg.PMTIEMPART = txtIEM.Text;
            IncentiveReg.PMTIEMPARTDate = txtRegPartNo2.Text;
            IncentiveReg.EligibilityNo = txtEligibilityNo.Text;
            IncentiveReg.EligibilityDate = txtEligibility.Text;

            return 1;
        }

        protected void GVFiexed_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataTable dt = (DataTable)ViewState["FixedInvestment"];

                    if (dt != null)
                    {
                        if (e.Row.RowIndex < 13)
                        {
                            GridViewRow Gvr = e.Row;
                            TextBox NewUnit = (TextBox)Gvr.FindControl("txtunit1");
                            TextBox Expansion = (TextBox)Gvr.FindControl("txtExpansion");
                            TextBox DurationEx = (TextBox)Gvr.FindControl("txtDurExpansion");
                            TextBox AfterExpansion = (TextBox)Gvr.FindControl("txtAfterExpansion");

                            NewUnit.Text = dt.Rows[e.Row.RowIndex]["NewUnit"].ToString();
                            Expansion.Text = dt.Rows[e.Row.RowIndex]["Expansion"].ToString();
                            DurationEx.Text = dt.Rows[e.Row.RowIndex]["DurationEx"].ToString();
                            AfterExpansion.Text = dt.Rows[e.Row.RowIndex]["AfterExpansion"].ToString();
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
    }
}