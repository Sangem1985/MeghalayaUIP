using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace MeghalayaUIP
{
    public partial class IntentInvest : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        string DPR_FilePath = "", DPR_FileType = "", DPR_FileName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.MaintainScrollPositionOnPostBack = true;
                Failure.Visible = false;
                success.Visible = false;
                if (!IsPostBack)
                {
                    BindCountry();
                    BindStates();
                    BindDistricts();
                    BindSectors();
                    BindEnterpriseType();
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }

        public void BindSectors()
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
        public void BindEnterpriseType()
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindStates()
        {
            try
            {
                ddlstate.Items.Clear();

                List<MasterStates> objStatesModel = new List<MasterStates>();

                objStatesModel = mstrBAL.GetStates();
                if (objStatesModel != null)
                {
                    ddlstate.DataSource = objStatesModel;
                    ddlstate.DataValueField = "StateId";
                    ddlstate.DataTextField = "StateName";
                    ddlstate.DataBind();
                }
                else
                {
                    ddlstate.DataSource = null;
                    ddlstate.DataBind();
                }
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

                ddldistrict.Items.Clear();
                ddlMandal.Items.Clear();
                ddlVillage.Items.Clear();

                List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();

                objDistrictModel = mstrBAL.GetDistrcits();
                if (objDistrictModel != null)
                {
                    ddldistrict.DataSource = objDistrictModel;
                    ddldistrict.DataValueField = "DistrictId";
                    ddldistrict.DataTextField = "DistrictName";
                    ddldistrict.DataBind();
                }
                else
                {
                    ddldistrict.DataSource = null;
                    ddldistrict.DataBind();


                }
                AddSelect(ddldistrict);
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
        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlcountry.SelectedItem.Text == "--Select--")
                {
                    State.Visible = false; txtstate.Text = "";
                    IndState.Visible = false; ddlstate.ClearSelection();
                    trotherstate.Visible = false; txtApplDist.Text = ""; txtApplTaluka.Text = ""; txtApplVillage.Text = "";
                    trMeghastate.Visible = false; ddldistrict.ClearSelection(); ddlMandal.ClearSelection(); ddlVillage.ClearSelection();
                }
                else if (ddlcountry.SelectedItem.Text == "India")
                {
                    State.Visible = false; txtstate.Text = "";
                    IndState.Visible = true;
                    trotherstate.Visible = false; txtApplDist.Text = ""; txtApplTaluka.Text = ""; txtApplVillage.Text = "";
                    trMeghastate.Visible = false; ddldistrict.ClearSelection(); ddlMandal.ClearSelection(); ddlVillage.ClearSelection();
                }
                else if (ddlcountry.SelectedItem.Text != "India")
                {
                    IndState.Visible = false; ddlstate.ClearSelection();
                    State.Visible = true;
                    trotherstate.Visible = true; txtApplDist.Text = ""; txtApplTaluka.Text = ""; txtApplVillage.Text = "";
                    trMeghastate.Visible = false; ddldistrict.ClearSelection(); ddlMandal.ClearSelection(); ddlVillage.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlstate.SelectedItem.Text == "--Select--")
                {
                    trotherstate.Visible = false; txtApplDist.Text = ""; txtApplTaluka.Text = ""; txtApplVillage.Text = "";
                    trMeghastate.Visible = false; ddldistrict.ClearSelection(); ddlMandal.ClearSelection(); ddlVillage.ClearSelection();
                }
                else if (ddlstate.SelectedItem.Text == "Meghalaya")
                {
                    trMeghastate.Visible = true;
                    trotherstate.Visible = false; txtApplDist.Text = ""; txtApplTaluka.Text = ""; txtApplVillage.Text = "";
                }
                else if (ddlstate.SelectedItem.Text != "Meghalaya")
                {
                    trotherstate.Visible = true;
                    trMeghastate.Visible = false; ddldistrict.ClearSelection(); ddlMandal.ClearSelection(); ddlVillage.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                ddlMandal.ClearSelection();
                AddSelect(ddlMandal);
                ddlVillage.ClearSelection();
                AddSelect(ddlVillage);
                if (ddldistrict.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlMandal, ddldistrict.SelectedValue);
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


        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string ErrorMsg = "", result = "";
                ErrorMsg = Stepvalidations();
                if (ErrorMsg == "")
                {                  
                    string sFileDir = ConfigurationManager.AppSettings["IntentAttachments"];
                    string newPath = System.IO.Path.Combine(sFileDir, System.DateTime.Now.ToString("ddMMyyyy"));
                    if (fupDPR.HasFile)
                    {
                        if ((fupDPR.PostedFile != null) && (fupDPR.PostedFile.ContentLength > 0))
                        { 
                            try
                            {                               
                                DPR_FilePath = newPath + System.DateTime.Now.ToString("ddMMyyyyhhmmss");
                                DPR_FileType = fupDPR.PostedFile.ContentType;
                                DPR_FileName = fupDPR.PostedFile.FileName;

                                if (!Directory.Exists(DPR_FilePath))
                                    System.IO.Directory.CreateDirectory(DPR_FilePath);
                                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(DPR_FilePath);
                                int count = dir.GetFiles().Length;
                                if (count == 0)
                                    fupDPR.PostedFile.SaveAs(DPR_FilePath + "\\" + DPR_FileName);
                                else
                                {
                                    if (count == 1)
                                    {
                                        string[] Files = Directory.GetFiles(DPR_FilePath);

                                        foreach (string file in Files)
                                        {
                                            File.Delete(file);
                                        }
                                        fupDPR.PostedFile.SaveAs(DPR_FilePath + "\\" + DPR_FileName);
                                    }
                                }
                            }
                            catch (Exception)//in case of an error
                            {
                                DeleteFile(newPath + "\\" + fupDPR.PostedFile.FileName);
                            }
                        }

                    }
                    InvtentInvest objInvest = new InvtentInvest();
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
                    objInvest.STATEID = ddlstate.SelectedValue;
                    objInvest.DISTRICTID = ddldistrict.SelectedValue;
                    objInvest.MANDALID = ddlMandal.SelectedValue;
                    objInvest.VILLAGEID = ddlVillage.SelectedValue;
                    objInvest.DPRFilePath = DPR_FilePath + "\\" + DPR_FileName;
                    objInvest.DPRFileName= DPR_FileName;
                    objInvest.DPRFileType= DPR_FileType;
                    if (ddlcountry.SelectedValue == "78")
                    {
                        objInvest.STATEID = ddlstate.SelectedValue;
                        objInvest.STATENAME = ddlstate.SelectedItem.Text;
                        if (ddlstate.SelectedValue == "23")
                        {
                            objInvest.DISTRICTNAME = ddldistrict.SelectedItem.Text;
                            objInvest.MANDALNAME = ddlMandal.SelectedItem.Text;
                            objInvest.VILLAGENAME = ddlVillage.SelectedItem.Text;

                            objInvest.DISTRICTID = ddldistrict.SelectedValue;
                            objInvest.MANDALID = ddlMandal.SelectedValue;
                            objInvest.VILLAGEID = ddlVillage.SelectedValue;
                        }
                        else if (ddlstate.SelectedValue != "23")
                        {
                            objInvest.DISTRICTNAME = txtApplDist.Text.Trim();
                            objInvest.MANDALNAME = txtApplTaluka.Text.Trim();
                            objInvest.VILLAGENAME = txtApplVillage.Text.Trim();

                            objInvest.DISTRICTID = "0";
                            objInvest.MANDALID = "0";
                            objInvest.VILLAGEID = "0";
                        }
                    }
                    else if (ddlcountry.SelectedValue != "78")
                    {
                        objInvest.STATEID = "0";
                        objInvest.STATENAME = txtstate.Text.Trim();
                        objInvest.DISTRICTNAME = txtApplDist.Text.Trim();
                        objInvest.MANDALNAME = txtApplTaluka.Text.Trim();
                        objInvest.VILLAGENAME = txtApplVillage.Text.Trim();
                        objInvest.DISTRICTID = "0";
                        objInvest.MANDALID = "0";
                        objInvest.VILLAGEID = "0";
                    }

                    result = mstrBAL.InsertInvestment(objInvest);
                    ViewState["UnitID"] = result;
                    if (result != "")
                    {
                        result = "ITV" + "/" + DateTime.Now.Year.ToString() + "/" + result;
                        success.Visible = true;
                        lblmsg.Text = "IntentInvest Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                        Response.Redirect("AckSlip.aspx?UID=" + result);

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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
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
                if (ddlstate.SelectedValue == "0" || ddlstate.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select State \\n";
                    slno = slno + 1;
                }
                if (ddlstate.SelectedValue == "23")
                {
                    if (ddldistrict.SelectedIndex == -1 || ddldistrict.SelectedItem.Text == "--Select--")
                    {
                        errormsg = errormsg + slno + ". Please Select District \\n";
                        slno = slno + 1;
                    }
                    if (ddlMandal.SelectedIndex == -1 || ddlMandal.SelectedItem.Text == "--Select--")
                    {
                        errormsg = errormsg + slno + ". Please Select Mandal or Taluka \\n";
                        slno = slno + 1;
                    }
                    if (ddlVillage.SelectedIndex == -1 || ddlVillage.SelectedItem.Text == "--Select--")
                    {
                        errormsg = errormsg + slno + ". Please Select Village \\n";
                        slno = slno + 1;
                    }
                }
                else if (ddlstate.SelectedValue != "23" && ddlstate.SelectedValue != "0")
                {
                    if (string.IsNullOrEmpty(txtApplDist.Text) || txtApplDist.Text == "" || txtApplDist.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter District...! \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtApplTaluka.Text) || txtApplTaluka.Text == "" || txtApplTaluka.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Mandal...! \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtApplVillage.Text) || txtApplVillage.Text == "" || txtApplVillage.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Village...! \\n";
                        slno = slno + 1;
                    }
                }
                if (!fupDPR.HasFile)
                {
                    errormsg = errormsg + slno + ". Please Upload Project Document (DPR) \\n";
                    slno = slno + 1;
                }
                else if (fupDPR.HasFile)
                {
                    string filesize = Convert.ToString(ConfigurationManager.AppSettings["FileSize"].ToString());
                  
                    if (fupDPR.PostedFile.ContentType != "application/pdf")
                    {
                        errormsg = errormsg + slno + ". Please Upload PDF Documents only \\n";
                        slno = slno + 1;
                    }
                    if (fupDPR.PostedFile.ContentLength >= Convert.ToInt32(filesize))
                    {
                        errormsg = errormsg + slno + ". Please Upload file size less than " + Convert.ToInt32(filesize) / 1000000 + "MB \\n";
                        slno = slno + 1;
                    }
                    if (!ValidateFileName(fupDPR.PostedFile.FileName))
                    {
                        errormsg = errormsg + slno + ". Document name should not contain symbols like  <, >, %, $, @, &,=, / \\n";
                        slno = slno + 1;
                    }
                    if (!ValidateFileExtension(fupDPR))
                    {
                        errormsg = errormsg + slno + ". Invalid File Extension \\n";
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
        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtName.Text = "";
                txtPan.Text = "";
                txtAddress.Text = "";
                ddlcountry.ClearSelection();
                ddlstate.ClearSelection();
                ddldistrict.ClearSelection();
                ddlMandal.ClearSelection();
                ddlVillage.ClearSelection();
                txtApplDist.Text = "";
                txtApplTaluka.Text = "";
                txtApplVillage.Text = "";
                txtPhone.Text = "";
                txtPinCode.Text = "";
                txtEmailIds.Text = "";
                txtFax.Text = "";
                txtwebsite.Text = "";
                txtNames.Text = "";
                txtDesignation.Text = "";
                txtEmail.Text = "";
                txtMobilesNo.Text = "";
                rblproposal.ClearSelection();
                rblInvestments.ClearSelection();
                ddlPCB.ClearSelection();
                ddlsector.ClearSelection();
                txtproposedInvest.Text = "";
                txtEmployments.Text = "";
                txtProjectlocation.Text = "";
                txtExpectedYear.Text = "";
                txtExpectation.Text = "";

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