using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP
{
    public partial class IntentInvest : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.MaintainScrollPositionOnPostBack = true;
                Failure.Visible = false;
                success.Visible = false;
                if (!IsPostBack)
                {
                    BindDate();
                    BindDatatype();
                    BindCountry();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            //String Quesstionriids = "1001";
            //string UnitId = "1";

            try
            {
                string ErrorMsg = "", result = "";
                ErrorMsg = Stepvalidations();
                if (ErrorMsg == "")
                {
                    InvtentInvest objInvest = new InvtentInvest();
                    //if (Convert.ToString(ViewState["UnitID"]) != "")
                    //{ objInvest.UNITID = Convert.ToString(ViewState["UnitID"]); }
                    //objInvest.CreatedBy = hdnUserID.Value;
                    objInvest.IPAddress = getclientIP();
                    objInvest.CompanyName = txtName.Text;
                    objInvest.PAN = txtPan.Text;
                    objInvest.Address = txtAddress.Text;
                    objInvest.Country = ddlcountry.SelectedValue;
                    objInvest.Phoneno = txtPhone.Text;
                    objInvest.Pincode = txtPinCode.Text;
                    objInvest.Emailid = txtEmailIds.Text;
                    objInvest.FaxNo = txtFax.Text;
                    objInvest.Website = txtwebsite.Text;
                    objInvest.Name = txtNames.Text;
                    objInvest.Designation = txtDesignation.Text;
                    objInvest.Email = txtEmail.Text;
                    objInvest.Mobile = txtMobilesNo.Text;
                    objInvest.ProjectProposal = rblproposal.SelectedValue;
                    objInvest.InvestmentPrevious = rblInvestments.SelectedValue;
                    objInvest.ProjectCategory = ddlPCB.SelectedValue;
                    objInvest.Sector = ddlsector.SelectedValue;
                    objInvest.Proposed_Investment = txtproposedInvest.Text;
                    objInvest.Proposed_Employment = txtEmployments.Text;
                    objInvest.Project_Location = txtProjectlocation.Text;
                    objInvest.Expected_Year = txtExpectedYear.Text;
                    objInvest.Expectationstate_Govt = txtExpectation.Text;


                    result = mstrBAL.InsertInvestment(objInvest);
                    ViewState["UnitID"] = result;
                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "IntentInvest Details Submitted Successfully";
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
        public void BindDate()
        {
            try
            {
                ddlsector.Items.Clear();

                List<MasterSECTORS> objSectorsModel = new List<MasterSECTORS>();

                objSectorsModel = mstrBAL.GetSector();
                if (objSectorsModel != null)
                {
                    ddlsector.DataSource = objSectorsModel;
                    ddlsector.DataValueField = "SECTORID";
                    ddlsector.DataTextField = "SECTORNAME";
                    ddlsector.DataBind();
                }
                else
                {
                    ddlsector.DataSource = null;
                    ddlsector.DataBind();
                }
                AddSelect(ddlsector);
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
        public void BindDatatype()
        {
            try
            {
                ddlPCB.Items.Clear();

                List<MasterENTERPRISETYPE> objPCBModel = new List<MasterENTERPRISETYPE>();

                objPCBModel = mstrBAL.GetENTERPRISETYPE();
                if (objPCBModel != null)
                {
                    ddlPCB.DataSource = objPCBModel;
                    ddlPCB.DataValueField = "ENTERPRISETYPECODE";
                    ddlPCB.DataTextField = "ENTERPRISETYPE";
                    ddlPCB.DataBind();
                }
                else
                {
                    ddlPCB.DataSource = null;
                    ddlPCB.DataBind();
                }
                AddSelect(ddlPCB);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void BindCountry()
        {
            try
            {
                ddlcountry.Items.Clear();

                List<MasterCountry> objCountryModel = new List<MasterCountry>();

                objCountryModel = mstrBAL.GetCountries();
                if (objCountryModel != null)
                {
                    ddlcountry.DataSource = objCountryModel;
                    ddlcountry.DataValueField = "CountryId";
                    ddlcountry.DataTextField = "CountryName";
                    ddlcountry.DataBind();
                }
                else
                {
                    ddlcountry.DataSource = null;
                    ddlcountry.DataBind();
                }
                AddSelect(ddlcountry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Stepvalidations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                if (string.IsNullOrEmpty(txtName.Text) || txtName.Text == "" || txtName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Company Name \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPan.Text) || txtPan.Text == "" || txtPan.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Pan \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAddress.Text) || txtAddress.Text == "" || txtAddress.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Address \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(ddlcountry.Text) || ddlcountry.Text == "" || ddlcountry.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Country \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPhone.Text) || txtPhone.Text == "" || txtPhone.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Phone No \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPinCode.Text) || txtPinCode.Text == "" || txtPinCode.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter pin \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEmailIds.Text) || txtEmailIds.Text == "" || txtEmailIds.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter EmailId \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtFax.Text) || txtFax.Text == "" || txtFax.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter FaxNo \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtwebsite.Text) || txtwebsite.Text == "" || txtwebsite.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Website \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNames.Text) || txtNames.Text == "" || txtNames.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDesignation.Text) || txtDesignation.Text == "" || txtDesignation.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Designation \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEmail.Text) || txtEmail.Text == "" || txtEmail.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Email \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtMobilesNo.Text) || txtMobilesNo.Text == "" || txtMobilesNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter MobileNo \\n";
                    slno = slno + 1;
                }
                if (rblproposal.SelectedIndex == -1 || rblproposal.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Proposal \\n";
                    slno = slno + 1;
                }
                if (rblInvestments.SelectedIndex == -1 || rblInvestments.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Investment \\n";
                    slno = slno + 1;
                }
                if (ddlPCB.SelectedIndex == -1 || ddlPCB.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Project Category \\n";
                    slno = slno + 1;
                }
                if (ddlsector.SelectedIndex == -1 || ddlsector.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Sector \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtproposedInvest.Text) || txtproposedInvest.Text == "" || txtproposedInvest.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Proposed Investment \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEmployments.Text) || txtEmployments.Text == "" || txtEmployments.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Proposed Employement \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtProjectlocation.Text) || txtProjectlocation.Text == "" || txtProjectlocation.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Proposed Location \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtExpectedYear.Text) || txtExpectedYear.Text == "" || txtExpectedYear.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Expected Year \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtExpectation.Text) || txtExpectation.Text == "" || txtExpectation.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Expectation State Govt \\n";
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