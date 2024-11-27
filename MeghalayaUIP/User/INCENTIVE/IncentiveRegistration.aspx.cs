using MeghalayaUIP.BAL.INCBAL;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.INCENTIVE
{
    public partial class IncentiveRegistration : System.Web.UI.Page
    {
        int index;
        INCBAL iNCBAL = new INCBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FixedCapital();
                SourceFinance();
                EmploymentType();
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
    }
}