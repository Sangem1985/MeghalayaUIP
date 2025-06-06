﻿using MeghalayaUIP.BAL.CFOBAL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFO
{
    public partial class CFOExcise : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFOBAL bal = new CFOBAL();
        UserInfo ObjUserInfo;
        int UnitID; string Errormsg = "", result = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
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
                            UnitID = Convert.ToInt32(Session["CFOUNITID"]);
                        }
                        else
                        {
                            string newurl = "~/User/CFO/CFOUserDashboard.aspx";
                            Response.Redirect(newurl);
                        }

                        Page.MaintainScrollPositionOnPostBack = true;
                        Failure.Visible = false;
                        success.Visible = false;
                        if (!IsPostBack)
                        {
                            GetAppliedorNot();
                            BindCountry();
                            BindDetails();
                            AttachmentBind();
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
        protected void GetAppliedorNot()
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = bal.GetApprovalDataByDeptId(hdnUserID.Value, Convert.ToString(Session["CFOUNITID"]), Convert.ToString(Session["CFOQID"]), "7", "");
                if (dsnew.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsnew.Tables[0].Rows.Count; i++)
                    {
                        if (Convert.ToString(dsnew.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "45")
                        {
                            div_45_AplicntDtls.Visible = true;
                        }
                        if (Convert.ToString(dsnew.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "47")
                        {
                            div_47_BLR.Visible = true;
                        }


                    }
                }
                else
                {
                    if (Request.QueryString[0].ToString() == "N")
                    {
                        Response.Redirect("~/User/CFO/CFOForestTransit.aspx?next=N");
                    }
                    else
                    {
                        Response.Redirect("~/User/CFO/CFOBusinessLicenseDetails.aspx?Previous=P");
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
        public void BindDetails()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = bal.GetCFOExciseDet(UnitID, hdnUserID.Value);
                if (ds.Tables.Count > 0)
                {
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        rblArtical5.SelectedValue= Convert.ToString(ds.Tables[0].Rows[0]["Artical5Selection"]);
                        rblapplicant.SelectedValue= Convert.ToString(ds.Tables[0].Rows[0]["ApplicantSelection"]);
                        rblMember.SelectedValue= Convert.ToString(ds.Tables[0].Rows[0]["MemberSelection"]);
                        rblTax.SelectedValue= Convert.ToString(ds.Tables[0].Rows[0]["TaxSelection"]);
                        rblsaletax.SelectedValue= Convert.ToString(ds.Tables[0].Rows[0]["SaleTaxSelection"]);
                        rblprofession.SelectedValue= Convert.ToString(ds.Tables[0].Rows[0]["ProfessionSelection"]);
                        rblgoverment.SelectedValue= Convert.ToString(ds.Tables[0].Rows[0]["GovernmentSelection"]);
                        if (rblgoverment.SelectedValue=="Y")
                        {
                            Excisedept.Visible = true;
                            txttradeLic.Text= Convert.ToString(ds.Tables[0].Rows[0]["GovernmentDetails"]);
                        }
                        else { Excisedept.Visible = true; }

                        rblviolation.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ViolationSelection"]);
                        if (rblviolation.SelectedValue == "Y")
                        {
                            txtlaw.Visible = true;
                            txtexciselaw.Text = Convert.ToString(ds.Tables[0].Rows[0]["ViolationDetails"]);
                        }
                        else { txtlaw.Visible = true; }

                        rblConvicted.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ConvictedSelection"]);
                        if (rblConvicted.SelectedValue == "Y")
                        {
                            convictedlaw.Visible = true;
                            txtDetails.Text = Convert.ToString(ds.Tables[0].Rows[0]["ConvictedDetails"]);
                        }
                        else { convictedlaw.Visible = true; }

                        rblBrand.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["RenewBrand"]);
                        if (rblBrand.SelectedValue == "Y")
                        {
                            TodateReg.Visible = true; Brands.Visible = true;
                            txtFromDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["RegFromDate"]);
                            txtTodate.Text = Convert.ToString(ds.Tables[0].Rows[0]["RegToDate"]);
                            txtAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["FirmAddress"]);
                        }
                        else { convictedlaw.Visible = true; }

                    }
                    if (ds != null && ds.Tables[1].Rows.Count > 0)
                    {
                        gvBrandDetails.DataSource = ds.Tables[1];
                        gvBrandDetails.DataBind();
                    }
                    if (ds != null && ds.Tables[2].Rows.Count > 0)
                    {
                        GvLiquor.DataSource = ds.Tables[2];
                        GvLiquor.DataBind();
                    }
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
                        {
                            if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 83)//
                            {
                                hypTribal.Visible = true;
                                hypTribal.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                                hypTribal.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 84) //
                            {
                                hypQualification.Visible = true;
                                hypQualification.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                                hypQualification.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 85) //
                            {
                                hypSpecimen.Visible = true;
                                hypSpecimen.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                                hypSpecimen.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 86)//
                            {
                                hypHeadman.Visible = true;
                                hypHeadman.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                                hypHeadman.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 87) //
                            {
                                hypTenancy.Visible = true;
                                hypTenancy.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                                hypTenancy.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 88) //
                            {
                                hypRegistration.Visible = true;
                                hypRegistration.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                                hypRegistration.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 89) //
                            {
                                hypPharmacist.Visible = true;
                                hypPharmacist.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                                hypPharmacist.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 90) //
                            {
                                hypQualificationcertificate.Visible = true;
                                hypQualificationcertificate.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                                hypQualificationcertificate.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 91) //
                            {
                                hypsiteplan.Visible = true;
                                hypsiteplan.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                                hypsiteplan.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 92) //
                            {
                                hypCompetentperson.Visible = true;
                                hypCompetentperson.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                                hypCompetentperson.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 93) //
                            {
                                hyppharmacistlist.Visible = true;
                                hyppharmacistlist.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                                hyppharmacistlist.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 94) //
                            {
                                hypundertaking1.Visible = true;
                                hypundertaking1.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                                hypundertaking1.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 95) //
                            {
                                hypundertaking2.Visible = true;
                                hypundertaking2.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                                hypundertaking2.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 96) //
                            {
                                hypstaff.Visible = true;
                                hypstaff.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                                hypstaff.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 97) //
                            {
                                hypagencyClearance.Visible = true;
                                hypagencyClearance.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                                hypagencyClearance.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                            }
                            if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 98) //
                            {
                                hypProjectReport.Visible = true;
                                hypProjectReport.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                                hypProjectReport.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                            }
                        }
                    }

                }


                /* CFOExciseDetails cFOExciseDetails = bal.GetCFOExciseData(UnitID, hdnUserID.Value);
                 if (cFOExciseDetails != null)
                 {
                     // Bind values to RadioButtonList controls
                     if (div_45_AplicntDtls.Visible == true)
                     {

                         rblArtical5.SelectedValue = cFOExciseDetails.Artical5Selection;
                         rblapplicant.SelectedValue = cFOExciseDetails.ApplicantSelection;
                         rblMember.SelectedValue = cFOExciseDetails.MemberSelection;
                         rblTax.SelectedValue = cFOExciseDetails.TaxSelection;
                         rblsaletax.SelectedValue = cFOExciseDetails.SaleTaxSelection;
                         rblprofession.SelectedValue = cFOExciseDetails.ProfessionSelection;
                         rblgoverment.SelectedValue = cFOExciseDetails.GovernmentSelection;
                         if (cFOExciseDetails.GovernmentSelection == "Y") { Excisedept.Visible = true; txttradeLic.Text = cFOExciseDetails.GovernmentDetails; }
                         rblviolation.SelectedValue = cFOExciseDetails.ViolationSelection;
                         if (cFOExciseDetails.ViolationSelection == "Y") { txtlaw.Visible = true; txtexciselaw.Text = cFOExciseDetails.ViolationDetails; }
                         rblConvicted.SelectedValue = cFOExciseDetails.ConvictedSelection;
                         if (cFOExciseDetails.ConvictedSelection == "Y") { convictedlaw.Visible = true; txtDetails.Text = cFOExciseDetails.ConvictedDetails; }
                     }
                     else { div_45_AplicntDtls.Visible = false; }

                     if (div_47_BLR.Visible == true)
                     {


                         List<CFOExciseBrandDetails> brandDetailsList = cFOExciseDetails.brandgridlist;
                         List<CFOExciseLiquorDetails> liquorDetailsList = cFOExciseDetails.liquorgridlist;
                         // List<CFOAttachments> objAadharlist = cFOExciseDetails.CFOAttachment;             

                         ViewState["BrandDetails"] = brandDetailsList;
                         ViewState["LiquorDetails"] = liquorDetailsList;
                         // Bind brand details list to gvBrandDetails
                         gvBrandDetails.DataSource = brandDetailsList;
                         gvBrandDetails.DataBind();

                         // Bind liquor details list to GvLiquor
                         GvLiquor.DataSource = liquorDetailsList;
                         GvLiquor.DataBind();

                         rblBrand.SelectedValue = cFOExciseDetails.RenewBrand;
                         if (rblBrand.SelectedValue == "Y")
                         {
                             TodateReg.Visible = true; Brands.Visible = true;
                             txtFromDate.Text = Convert.ToDateTime(cFOExciseDetails.RegToDate).ToString("yyyy-MM-dd");// Convert.ToDateTime( cFOExciseDetails.RegFromDate).ToString("dd-MM-yyyy");
                             txtTodate.Text = Convert.ToDateTime(cFOExciseDetails.RegToDate).ToString("yyyy-MM-dd");
                             txtAddress.Text = cFOExciseDetails.FirmAddress;
                         }
                         if (brandDetailsList.Count > 0)
                         {
                             gvBrandDetails.Visible = true;
                             gvBrandDetails.DataSource = brandDetailsList;
                             gvBrandDetails.DataBind();
                         }
                         if (liquorDetailsList.Count > 0)
                         {
                             GvLiquor.Visible = true;
                             GvLiquor.DataSource = liquorDetailsList;
                             GvLiquor.DataBind();
                         }
                     }
                     else { div_47_BLR.Visible = false; }
                 } */
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public void AttachmentBind()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = bal.GetCFOExcise(UnitID, hdnUserID.Value);
                if (ds.Tables[3].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
                    {
                        if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 83)
                        {
                            hypTribal.Visible = true;
                            hypTribal.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                            hypTribal.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 84)
                        {
                            hypQualification.Visible = true;
                            hypQualification.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                            hypQualification.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 85)
                        {
                            hypSpecimen.Visible = true;
                            hypSpecimen.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                            hypSpecimen.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 86)
                        {
                            hypHeadman.Visible = true;
                            hypHeadman.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                            hypHeadman.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 87)
                        {
                            hypTenancy.Visible = true;
                            hypTenancy.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                            hypTenancy.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 88)
                        {
                            hypRegistration.Visible = true;
                            hypRegistration.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                            hypRegistration.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 89)
                        {
                            hypPharmacist.Visible = true;
                            hypPharmacist.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                            hypPharmacist.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 90)
                        {
                            hypQualificationcertificate.Visible = true;
                            hypQualificationcertificate.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                            hypQualificationcertificate.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 91)
                        {
                            hypsiteplan.Visible = true;
                            hypsiteplan.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                            hypsiteplan.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 92)
                        {
                            hypCompetentperson.Visible = true;
                            hypCompetentperson.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                            hypCompetentperson.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 93)
                        {
                            hyppharmacistlist.Visible = true;
                            hyppharmacistlist.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                            hyppharmacistlist.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 94)
                        {
                            hypundertaking1.Visible = true;
                            hypundertaking1.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                            hypundertaking1.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 95)
                        {
                            hypundertaking2.Visible = true;
                            hypundertaking2.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                            hypundertaking2.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 96)
                        {
                            hypstaff.Visible = true;
                            hypstaff.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                            hypstaff.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 97)
                        {
                            hypagencyClearance.Visible = true;
                            hypagencyClearance.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                            hypagencyClearance.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 98)
                        {
                            hypProjectReport.Visible = true;
                            hypProjectReport.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                            hypProjectReport.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
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
        protected void rblConvicted_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblConvicted.SelectedItem.Text == "Yes")
                {
                    convictedlaw.Visible = true;
                }
                else
                {
                    convictedlaw.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblConvicted.BorderColor = System.Drawing.Color.White;
        }

        protected void rblviolation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblviolation.SelectedItem.Text == "Yes")
                {
                    txtlaw.Visible = true;
                }
                else
                {
                    txtlaw.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblviolation.BorderColor = System.Drawing.Color.White;
        }

        protected void rblgoverment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblgoverment.SelectedItem.Text == "Yes")
                {
                    Excisedept.Visible = true;
                }
                else
                {
                    Excisedept.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblgoverment.BorderColor = System.Drawing.Color.White;
        }

        protected void rblMRPRS_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblMRPRS.SelectedItem.Text == "Yes")
                {
                    MRPGRID.Visible = true;
                }
                else
                {
                    MRPGRID.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblMRPRS.BorderColor = System.Drawing.Color.White;
        }

        protected void rblBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblBrand.SelectedItem.Text == "Yes")
                {
                    Brands.Visible = true;
                    TodateReg.Visible = true;
                }
                else
                {
                    Brands.Visible = false;
                    TodateReg.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblBrand.BorderColor = System.Drawing.Color.White;
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                Errormsg = Validations();
                if (Errormsg == "")
                {
                    SaveData();
                }
                else
                {
                    string message = "alert('" + Errormsg + "')";
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

        public void SaveData()
        {
            try
            {


                if (Session["UserInfo"] != null)
                {
                    ObjUserInfo = (UserInfo)Session["UserInfo"];
                }


                CFOExciseDetails objcfo = new CFOExciseDetails();
                objcfo.CFOQID = Convert.ToInt32(Convert.ToString(Session["CFOQID"]));
                objcfo.CFOunitid = Convert.ToInt32(Convert.ToString(Session["CFOUNITID"]));
                objcfo.Artical5Selection = rblArtical5.SelectedValue;
                objcfo.ApplicantSelection = rblapplicant.SelectedValue;
                objcfo.MemberSelection = rblMember.SelectedValue;
                objcfo.TaxSelection = rblTax.SelectedValue;
                objcfo.SaleTaxSelection = rblsaletax.SelectedValue;
                objcfo.ProfessionSelection = rblprofession.SelectedValue;
                objcfo.GovernmentSelection = rblgoverment.SelectedValue;
                objcfo.GovernmentDetails = rblgoverment.SelectedValue == "Y" ? txttradeLic.Text : "";
                objcfo.ViolationSelection = rblviolation.SelectedValue;
                objcfo.ViolationDetails = rblviolation.SelectedValue == "Y" ? txtexciselaw.Text : "";
                objcfo.ConvictedSelection = rblConvicted.SelectedValue;
                objcfo.ConvictedDetails = rblConvicted.SelectedValue == "Y" ? txtDetails.Text : "";
                objcfo.RenewBrand = rblBrand.SelectedValue;
                if (rblBrand.SelectedValue == "Y")
                    objcfo.RegFromDate =( txtFromDate.Text); //DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                if (rblBrand.SelectedValue == "Y")
                    objcfo.RegToDate = (txtTodate.Text);//DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                objcfo.FirmAddress = txtAddress.Text;
                objcfo.CreatedIp = getclientIP();
                objcfo.CreatedBy = hdnUserID.Value;
                objcfo.Flag = "S";
                List<CFOExciseBrandDetails> brandDetails = ViewState["BrandDetails"] as List<CFOExciseBrandDetails>;
                List<CFOExciseLiquorDetails> liquorDetails = ViewState["LiquorDetails"] as List<CFOExciseLiquorDetails>;

                string res = bal.InsertCFOExciseData(objcfo, brandDetails, liquorDetails);
                if (res == "Success")
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'success', title: 'Success',text: 'Submitted', allowOutsideClick:false})", true);
                    return;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'oops..',text: 'Submission failed', allowOutsideClick:false})", true);
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



        public string Validations()
        {
            try
            {
                int slno = 1;
                List<TextBox> emptyTextboxes = FindEmptyTextboxes(divText);
                List<DropDownList> emptyDropdowns = FindEmptyDropdowns(divText);
                List<RadioButtonList> emptyRadioButtonLists = FindEmptyRadioButtonLists(divText);
                string errormsg = "";

                if (div_45_AplicntDtls.Visible == true)
                {


                    if (rblArtical5.SelectedIndex == -1)
                    {
                        //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: '1.Please select Are you citizen of India', allowOutsideClick:false})", true);
                        //rblArtical5.Focus();

                        errormsg = errormsg + slno + ". Please Enter 1.Please select Are you citizen of India\\n";
                        slno = slno + 1;
                    }

                    // Add similar checks for other RadioButtonLists
                    if (rblapplicant.SelectedIndex == -1)
                    {
                        //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: '2.Please select Has the applicant', allowOutsideClick:false})", true);
                        //rblapplicant.Focus();
                        errormsg = errormsg + slno + ". Please Enter 2.Please select Has the applicant\\n";
                        slno = slno + 1;
                    }
                    if (rblMember.SelectedIndex == -1)
                    {
                        //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: '3.Please select Whether applicant’s direct family member', allowOutsideClick:false})", true);
                        //rblMember.Focus();
                        errormsg = errormsg + slno + ". Please Enter 2.Please select Has the applicant\\n";
                        slno = slno + 1;
                    }
                    if (rblTax.SelectedIndex == -1)
                    {
                        //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: '4.Please select Are you/applicant an Income Tax Payer', allowOutsideClick:false})", true);
                        //rblTax.Focus();
                        errormsg = errormsg + slno + ". Please Enter 4.Please select Are you/applicant an Income Tax Payer\\n";
                        slno = slno + 1;
                    }
                    if (rblsaletax.SelectedIndex == -1)
                    {
                        //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: '5.Please select Do you/Applicant pay Sales Tax', allowOutsideClick:false})", true);
                        //rblsaletax.Focus();
                        errormsg = errormsg + slno + ". Please Enter 5.Please select Do you/Applicant pay Sales Tax\\n";
                        slno = slno + 1;
                    }
                    if (rblprofession.SelectedIndex == -1)
                    {
                        //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: '6.Please select Do you/Applicant pay Professional Tax', allowOutsideClick:false})", true);
                        //rblprofession.Focus();
                        errormsg = errormsg + slno + ". Please Enter 6.Please select Do you/Applicant pay Professional Tax\\n";
                        slno = slno + 1;
                    }
                    if (rblgoverment.SelectedIndex == -1) // Assuming this triggers more fields, handle accordingly
                    {
                        //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: '7.Please select applicant in any way related to a Government', allowOutsideClick:false})", true);
                        //rblgoverment.Focus();
                        errormsg = errormsg + slno + ". Please Enter 7.Please select applicant in any way related to a Government\\n";
                        slno = slno + 1;
                    }
                    else if (rblgoverment.SelectedValue == "Y")
                    {
                        if (string.IsNullOrEmpty(txttradeLic.Text) || txttradeLic.Text == "" || txttradeLic.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter 7.Please select applicant in any way related to a Government\\n";
                            slno = slno + 1;

                        }
                    }
                    if (rblviolation.SelectedIndex == -1)
                    {
                        //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: '8.Please select applicant been punished or penalized for Violation', allowOutsideClick:false})", true);
                        //rblviolation.Focus();

                        errormsg = errormsg + slno + ". Please Enter 8.Please select applicant been punished or penalized for Violation\\n";
                        slno = slno + 1;
                    }
                    else if (rblviolation.SelectedValue == "Y")
                    {
                        if (string.IsNullOrEmpty(txtexciselaw.Text) || txtexciselaw.Text == "" || txtexciselaw.Text == null)
                        {
                            //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: 'Please enter Violation Details', allowOutsideClick:false})", true);
                            //txtexciselaw.Focus();
                            errormsg = errormsg + slno + ". Please Enter Please enter Violation Details\\n";
                            slno = slno + 1;
                        }
                    }
                    if (rblConvicted.SelectedIndex == -1)
                    {
                        //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: '9.Please select applicant has ever been convicted by Court of Law', allowOutsideClick:false})", true);
                        //rblConvicted.Focus();
                        errormsg = errormsg + slno + ". 9.Please select applicant has ever been convicted by Court of Law\\n";
                        slno = slno + 1;
                    }
                    else if (rblConvicted.SelectedValue == "Y")
                    {
                        if (string.IsNullOrEmpty(txtDetails.Text) || txtDetails.Text == "" || txtDetails.Text == null)
                        {
                            //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: 'Please enter convicted by Court of Law Details', allowOutsideClick:false})", true);
                            //txtDetails.Focus();
                            errormsg = errormsg + slno + ". Please enter convicted by Court of Law Details\\n";
                            slno = slno + 1;
                        }
                    }
                }
                else { div_45_AplicntDtls.Visible = false; }

                if (div_47_BLR.Visible == true)
                {

                    if (rblBrand.SelectedIndex == -1)
                    {
                        //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: 'Please select Renewal of BIO Brands', allowOutsideClick:false})", true);
                        //rblBrand.Focus();
                        errormsg = errormsg + slno + ". Please select Renewal of BIO Brands\\n";
                        slno = slno + 1;
                    }
                    if (rblBrand.SelectedValue == "Y")
                    {
                        if (string.IsNullOrWhiteSpace(txtFromDate.Text) || txtFromDate.Text == "" || txtFromDate.Text == null) // Assuming this triggers more fields, handle accordingly
                        {
                            //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: 'Please enter Registration-From Date', allowOutsideClick:false})", true);
                            //txtFromDate.Focus();
                            errormsg = errormsg + slno + ". Please enter Registration-From Date\\n";
                            slno = slno + 1;
                        }
                        if (string.IsNullOrWhiteSpace(txtTodate.Text) || txtTodate.Text == "" || txtTodate.Text == null) // Assuming this triggers more fields, handle accordingly
                        {
                            //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: 'Please enter Registration-To Date', allowOutsideClick:false})", true);
                            //txtTodate.Focus();
                            errormsg = errormsg + slno + ". Please enter Registration-To Date\\n";
                            slno = slno + 1;
                        }
                        if (string.IsNullOrWhiteSpace(txtAddress.Text) || txtAddress.Text == "" || txtAddress.Text == null) // Assuming this triggers more fields, handle accordingly
                        {
                            //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: 'Please enter Name and address of the Firm', allowOutsideClick:false})", true);
                            //txtAddress.Focus();
                            errormsg = errormsg + slno + ". Please enter Name and address of the Firm\\n";
                            slno = slno + 1;
                        }
                    }
                    if (gvBrandDetails.Rows.Count <= 0)
                    {
                        errormsg = errormsg + slno + ". Please enter Brand Details \\n";
                        slno = slno + 1;
                    }
                    if (GvLiquor.Rows.Count <= 0)
                    {
                        errormsg = errormsg + slno + ". Please enter Brand Details \\n";
                        slno = slno + 1;
                    }
                }
                else { div_47_BLR.Visible = false; }
                if (string.IsNullOrEmpty(hypTribal.Text) || hypTribal.Text == "" || hypTribal.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Noc From Local Area Authority Provisional Recognition \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypQualification.Text) || hypQualification.Text == "" || hypQualification.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload NoC from: a. Municipal Board (if within municipal area)  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypSpecimen.Text) || hypSpecimen.Text == "" || hypSpecimen.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Professional tax clearance certificate  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypHeadman.Text) || hypHeadman.Text == "" || hypHeadman.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Sales tax clearance Certificate \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypTenancy.Text) || hypTenancy.Text == "" || hypTenancy.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Income tax return for last three year  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypRegistration.Text) || hypRegistration.Text == "" || hypRegistration.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Financial Capacity Certificate \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypPharmacist.Text) || hypPharmacist.Text == "" || hypPharmacist.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Age Proof (Birth Certificate/ School leaving Certificate) \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypQualificationcertificate.Text) || hypQualificationcertificate.Text == "" || hypQualificationcertificate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Educational Qualification Certificates  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypsiteplan.Text) || hypsiteplan.Text == "" || hypsiteplan.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Marriage Certificate (If Married)  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypCompetentperson.Text) || hypCompetentperson.Text == "" || hypCompetentperson.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Scheduled Tribe/ Caste Certificate \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hyppharmacistlist.Text) || hyppharmacistlist.Text == "" || hyppharmacistlist.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Trade Licence/ Factories Licence \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypundertaking1.Text) || hypundertaking1.Text == "" || hypundertaking1.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Non-Encumbrance Certificate    \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypundertaking2.Text) || hypundertaking2.Text == "" || hypundertaking2.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Excise licence held individually/jointly for one/multiple shop  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypstaff.Text) || hypstaff.Text == "" || hypstaff.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Excise licence held by direct family member  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypagencyClearance.Text) || hypagencyClearance.Text == "" || hypagencyClearance.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Single Window Agency Clearance   \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypProjectReport.Text) || hypProjectReport.Text == "" || hypProjectReport.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Detailed Project Report   \\n";
                    slno = slno + 1;
                }

                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
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
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            // Check TextBoxes for required values
            if (string.IsNullOrWhiteSpace(txtName.Text.Trim()))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: 'Please enter Name of Brand', allowOutsideClick:false})", true);
                txtName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtStrength.Text)) // Assuming strength should be a number
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: 'Please enter Strength(Alcohol Content)', allowOutsideClick:false})", true);
                txtStrength.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSize.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: 'Please enter Size', allowOutsideClick:false})", true);
                txtSize.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtBottle.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: 'Please enter No. of bottles (in one case)', allowOutsideClick:false})", true);
                txtBottle.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMRP.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: 'Please enter MRP', allowOutsideClick:false})", true);
                txtMRP.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtBulkLiter.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: 'Please enter Bulk liter', allowOutsideClick:false})", true);
                txtBulkLiter.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtLandonProof.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: 'Please enter London Proof liter', allowOutsideClick:false})", true);
                txtLandonProof.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtBottlePlant.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: 'Please enter Name & address of Plant', allowOutsideClick:false})", true);
                txtBottlePlant.Focus();
                return;
            }
            List<CFOExciseBrandDetails> brandDetails;
            if (ViewState["BrandDetails"] != null)
            {
                brandDetails = ViewState["BrandDetails"] as List<CFOExciseBrandDetails>;
            }
            else
            {
                brandDetails = new List<CFOExciseBrandDetails>();
            }
            CFOExciseBrandDetails newDetail = new CFOExciseBrandDetails();

            newDetail.NameOfBrand = txtName.Text.Trim();
            newDetail.Strength = txtStrength.Text;
            newDetail.Size = txtSize.Text;
            newDetail.NumberOfBottles = txtBottle.Text;
            newDetail.MRPRs = txtMRP.Text;
            newDetail.BulkLiter = txtBulkLiter.Text;
            newDetail.LandOnProof = txtLandonProof.Text;
            newDetail.BottlePlant = txtBottlePlant.Text;
            newDetail.CreatedBy = hdnUserID.Value;
            newDetail.CreatedDate = DateTime.Now;
            newDetail.CreatedIp = Request.UserHostAddress;
            newDetail.UpdatedBy = hdnUserID.Value;
            newDetail.UpdatedDate = DateTime.Now;
            newDetail.UpdatedIp = Request.UserHostAddress;
            newDetail.Flag = "A";


            brandDetails.Add(newDetail);
            gvBrandDetails.Visible = true;
            ViewState["BrandDetails"] = brandDetails;
            BindBrandGrid();

            // Clear the textboxes after adding the details
            txtName.Text = "";
            txtStrength.Text = "";
            txtSize.Text = "";
            txtBottle.Text = "";
            txtMRP.Text = "";
            txtBulkLiter.Text = "";
            txtLandonProof.Text = "";
            txtBottlePlant.Text = "";
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            if (ddlCountry.SelectedIndex == 0) // Assuming index 0 is "--Select--", so anything else is invalid
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: 'Please select The Country of Origin of the Liquor', allowOutsideClick:false})", true);
                ddlCountry.Focus();
                return;
            }
            if (string.IsNullOrEmpty(rblMRPRS.SelectedValue)) // Assuming this triggers more fields, handle accordingly
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: 'Please select MRP', allowOutsideClick:false})", true);
                rblMRPRS.Focus();
                return;
            }
            else if (rblMRPRS.SelectedValue == "Y")
            {
                if (string.IsNullOrWhiteSpace(txtBrandName.Text.Trim())) // Assuming this triggers more fields, handle accordingly
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Alert", "Swal.fire({icon: 'error', title: 'Oops...',text: 'Please enter Name of Brand', allowOutsideClick:false})", true);
                    txtBrandName.Focus();
                    return;
                }
            }

            List<CFOExciseLiquorDetails> liquorDetails;
            if (ViewState["LiquorDetails"] != null)
                liquorDetails = ViewState["LiquorDetails"] as List<CFOExciseLiquorDetails>;
            else
                liquorDetails = new List<CFOExciseLiquorDetails>();

            CFOExciseLiquorDetails newDetail = new CFOExciseLiquorDetails
            {
                CountryID = ddlCountry.SelectedValue,
                CountryName = ddlCountry.SelectedItem.Text,
                MRPSSelection = rblMRPRS.SelectedValue,
                BrandName = txtBrandName.Text.Trim(),
                CreatedBy = hdnUserID.Value,
                CreatedDate = DateTime.Now,
                CreatedIp = Request.UserHostAddress,
                UpdatedBy = hdnUserID.Value,
                UpdatedDate = DateTime.Now,
                UpdatedIp = Request.UserHostAddress,
                Flag = "A"
            };

            liquorDetails.Add(newDetail);
            ViewState["LiquorDetails"] = liquorDetails;
            GvLiquor.Visible = true;
            BindLiquorGrid();

            // Clear the textboxes after adding the details
            ddlCountry.SelectedIndex = 0;
            rblMRPRS.ClearSelection();
            txtBrandName.Text = "";
            MRPGRID.Visible = false;
        }

        protected void gvBrandDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            List<CFOExciseBrandDetails> brandDetails = ViewState["BrandDetails"] as List<CFOExciseBrandDetails>;
            brandDetails.RemoveAt(e.RowIndex);
            ViewState["BrandDetails"] = brandDetails;
            BindBrandGrid();

        }
        protected void GvLiquor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<CFOExciseLiquorDetails> liquorDetails = ViewState["LiquorDetails"] as List<CFOExciseLiquorDetails>;
            liquorDetails.RemoveAt(e.RowIndex);
            ViewState["LiquorDetails"] = liquorDetails;
            BindLiquorGrid();
        }
        public void BindCountry()
        {
            try
            {
                ddlCountry.Items.Clear();

                List<MasterCountry> objCountryModel = new List<MasterCountry>();

                objCountryModel = mstrBAL.GetCountries();
                if (objCountryModel != null)
                {
                    ddlCountry.DataSource = objCountryModel;
                    ddlCountry.DataValueField = "CountryId";
                    ddlCountry.DataTextField = "CountryName";
                    ddlCountry.DataBind();
                }
                else
                {
                    ddlCountry.DataSource = null;
                    ddlCountry.DataBind();
                }
                ddlCountry.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        private void BindBrandGrid()
        {
            List<CFOExciseBrandDetails> brandDetails = ViewState["BrandDetails"] as List<CFOExciseBrandDetails>;
            gvBrandDetails.DataSource = brandDetails;
            gvBrandDetails.DataBind();
        }
        public void BindLiquorGrid()
        {
            List<CFOExciseLiquorDetails> liquorDetails = ViewState["LiquorDetails"] as List<CFOExciseLiquorDetails>;
            GvLiquor.DataSource = liquorDetails;
            GvLiquor.DataBind();
        }
        protected void btnTribal_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupTribal.HasFile)
                {
                    Error = validations(fupTribal);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Noc From Local Area Authority Provisional Recognition" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupTribal.PostedFile.SaveAs(serverpath + "\\" + fupTribal.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "83";
                        objAadhar.FilePath = serverpath + fupTribal.PostedFile.FileName;
                        objAadhar.FileName = fupTribal.PostedFile.FileName;
                        objAadhar.FileType = fupTribal.PostedFile.ContentType;
                        objAadhar.FileDescription = "Noc From Local Area Authority Provisional Recognition";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = bal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypTribal.Text = fupTribal.PostedFile.FileName;
                            hypTribal.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupTribal.PostedFile.FileName);
                            hypTribal.Target = "blank";
                            message = "alert('" + "Noc From Local Area Authority Provisional Recognition Uploaded successfully" + "')";
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
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnQualification_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupQualification.HasFile)
                {
                    Error = validations(fupQualification);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Municipal Board if within municipal area" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupQualification.PostedFile.SaveAs(serverpath + "\\" + fupQualification.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "84";
                        objAadhar.FilePath = serverpath + fupQualification.PostedFile.FileName;
                        objAadhar.FileName = fupQualification.PostedFile.FileName;
                        objAadhar.FileType = fupQualification.PostedFile.ContentType;
                        objAadhar.FileDescription = "NoC from: a. Municipal Board (if within municipal area)";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = bal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypQualification.Text = fupQualification.PostedFile.FileName;
                            hypQualification.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupTribal.PostedFile.FileName);
                            hypQualification.Target = "blank";
                            message = "alert('" + "NoC from: a. Municipal Board (if within municipal area) Uploaded successfully" + "')";
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
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }


        }

        protected void btnSpecimen_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupSpecimen.HasFile)
                {
                    Error = validations(fupSpecimen);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Professional tax clearance certificate" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupSpecimen.PostedFile.SaveAs(serverpath + "\\" + fupSpecimen.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "85";
                        objAadhar.FilePath = serverpath + fupSpecimen.PostedFile.FileName;
                        objAadhar.FileName = fupSpecimen.PostedFile.FileName;
                        objAadhar.FileType = fupSpecimen.PostedFile.ContentType;
                        objAadhar.FileDescription = "Professional tax clearance certificate (From Autonomous District Council)";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = bal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypSpecimen.Text = fupSpecimen.PostedFile.FileName;
                            hypSpecimen.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupSpecimen.PostedFile.FileName);
                            hypSpecimen.Target = "blank";
                            message = "alert('" + "Professional tax clearance certificate (From Autonomous District Council) Uploaded successfully" + "')";
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
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnHeadman_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupHeadman.HasFile)
                {
                    Error = validations(fupHeadman);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Sales tax clearance Certificate (From Meghalaya Taxation Department)" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupHeadman.PostedFile.SaveAs(serverpath + "\\" + fupHeadman.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "86";
                        objAadhar.FilePath = serverpath + fupHeadman.PostedFile.FileName;
                        objAadhar.FileName = fupHeadman.PostedFile.FileName;
                        objAadhar.FileType = fupHeadman.PostedFile.ContentType;
                        objAadhar.FileDescription = "Sales tax clearance Certificate (From Meghalaya Taxation Department)";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = bal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypHeadman.Text = fupHeadman.PostedFile.FileName;
                            hypHeadman.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupHeadman.PostedFile.FileName);
                            hypHeadman.Target = "blank";
                            message = "alert('" + "Sales tax clearance Certificate (From Meghalaya Taxation Department) Uploaded successfully" + "')";
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
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnTenancy_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupTenancy.HasFile)
                {
                    Error = validations(fupTenancy);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Income tax return for last three year" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupTenancy.PostedFile.SaveAs(serverpath + "\\" + fupTenancy.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "87";
                        objAadhar.FilePath = serverpath + fupTenancy.PostedFile.FileName;
                        objAadhar.FileName = fupTenancy.PostedFile.FileName;
                        objAadhar.FileType = fupTenancy.PostedFile.ContentType;
                        objAadhar.FileDescription = "Income tax return for last three year";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = bal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypTenancy.Text = fupTenancy.PostedFile.FileName;
                            hypTenancy.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupTenancy.PostedFile.FileName);
                            hypTenancy.Target = "blank";
                            message = "alert('" + "Income tax return for last three year Uploaded successfully" + "')";
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
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnRegistration_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupRegistration.HasFile)
                {
                    Error = validations(fupRegistration);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Financial Capacity Certificate (From any bank or financial institution)" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupRegistration.PostedFile.SaveAs(serverpath + "\\" + fupRegistration.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "88";
                        objAadhar.FilePath = serverpath + fupRegistration.PostedFile.FileName;
                        objAadhar.FileName = fupRegistration.PostedFile.FileName;
                        objAadhar.FileType = fupRegistration.PostedFile.ContentType;
                        objAadhar.FileDescription = "Financial Capacity Certificate (From any bank or financial institution)";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = bal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypRegistration.Text = fupRegistration.PostedFile.FileName;
                            hypRegistration.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupRegistration.PostedFile.FileName);
                            hypRegistration.Target = "blank";
                            message = "alert('" + "Financial Capacity Certificate (From any bank or financial institution) Uploaded successfully" + "')";
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
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnPharmacist_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupPharmacist.HasFile)
                {
                    Error = validations(fupPharmacist);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Age Proof (Birth Certificate/ School leaving Certificate)" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupPharmacist.PostedFile.SaveAs(serverpath + "\\" + fupPharmacist.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "89";
                        objAadhar.FilePath = serverpath + fupPharmacist.PostedFile.FileName;
                        objAadhar.FileName = fupPharmacist.PostedFile.FileName;
                        objAadhar.FileType = fupPharmacist.PostedFile.ContentType;
                        objAadhar.FileDescription = "Age Proof (Birth Certificate/ School leaving Certificate)";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = bal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypPharmacist.Text = fupPharmacist.PostedFile.FileName;
                            hypPharmacist.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupPharmacist.PostedFile.FileName);
                            hypPharmacist.Target = "blank";
                            message = "alert('" + "Age Proof (Birth Certificate/ School leaving Certificate) Uploaded successfully" + "')";
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
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnQualificationcertificate_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupQualificationcertificate.HasFile)
                {
                    Error = validations(fupQualificationcertificate);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Educational Qualification Certificates" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupQualificationcertificate.PostedFile.SaveAs(serverpath + "\\" + fupQualificationcertificate.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "90";
                        objAadhar.FilePath = serverpath + fupQualificationcertificate.PostedFile.FileName;
                        objAadhar.FileName = fupQualificationcertificate.PostedFile.FileName;
                        objAadhar.FileType = fupQualificationcertificate.PostedFile.ContentType;
                        objAadhar.FileDescription = "Educational Qualification Certificates";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = bal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypQualificationcertificate.Text = fupQualificationcertificate.PostedFile.FileName;
                            hypQualificationcertificate.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupQualificationcertificate.PostedFile.FileName);
                            hypQualificationcertificate.Target = "blank";
                            message = "alert('" + "Educational Qualification Certificates Uploaded successfully" + "')";
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
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnsiteplan_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupsiteplan.HasFile)
                {
                    Error = validations(fupsiteplan);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Marriage Certificate (If Married)" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupsiteplan.PostedFile.SaveAs(serverpath + "\\" + fupsiteplan.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "91";
                        objAadhar.FilePath = serverpath + fupsiteplan.PostedFile.FileName;
                        objAadhar.FileName = fupsiteplan.PostedFile.FileName;
                        objAadhar.FileType = fupsiteplan.PostedFile.ContentType;
                        objAadhar.FileDescription = "Marriage Certificate (If Married)";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = bal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypsiteplan.Text = fupsiteplan.PostedFile.FileName;
                            hypsiteplan.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupsiteplan.PostedFile.FileName);
                            hypsiteplan.Target = "blank";
                            message = "alert('" + "Marriage Certificate (If Married) Uploaded successfully" + "')";
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
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnCompetentperson_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupCompetentperson.HasFile)
                {
                    Error = validations(fupCompetentperson);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Scheduled Tribe/ Caste Certificate" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupCompetentperson.PostedFile.SaveAs(serverpath + "\\" + fupCompetentperson.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "92";
                        objAadhar.FilePath = serverpath + fupCompetentperson.PostedFile.FileName;
                        objAadhar.FileName = fupCompetentperson.PostedFile.FileName;
                        objAadhar.FileType = fupCompetentperson.PostedFile.ContentType;
                        objAadhar.FileDescription = "Scheduled Tribe/ Caste Certificate";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = bal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypCompetentperson.Text = fupCompetentperson.PostedFile.FileName;
                            hypCompetentperson.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupCompetentperson.PostedFile.FileName);
                            hypCompetentperson.Target = "blank";
                            message = "alert('" + "Scheduled Tribe/ Caste Certificate Uploaded successfully" + "')";
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
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnpharmacistlist_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fuppharmacistlist.HasFile)
                {
                    Error = validations(fuppharmacistlist);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Trade Licence/ Factories Licence" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fuppharmacistlist.PostedFile.SaveAs(serverpath + "\\" + fuppharmacistlist.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "93";
                        objAadhar.FilePath = serverpath + fuppharmacistlist.PostedFile.FileName;
                        objAadhar.FileName = fuppharmacistlist.PostedFile.FileName;
                        objAadhar.FileType = fuppharmacistlist.PostedFile.ContentType;
                        objAadhar.FileDescription = "Trade Licence/ Factories Licence";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = bal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hyppharmacistlist.Text = fuppharmacistlist.PostedFile.FileName;
                            hyppharmacistlist.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fuppharmacistlist.PostedFile.FileName); hyppharmacistlist.Target = "blank";
                            message = "alert('" + "Trade Licence/ Factories Licence Uploaded successfully" + "')";
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
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnundertaking1_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupundertaking1.HasFile)
                {
                    Error = validations(fupundertaking1);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Non-Encumbrance Certificate" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupundertaking1.PostedFile.SaveAs(serverpath + "\\" + fupundertaking1.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "94";
                        objAadhar.FilePath = serverpath + fupundertaking1.PostedFile.FileName;
                        objAadhar.FileName = fupundertaking1.PostedFile.FileName;
                        objAadhar.FileType = fupundertaking1.PostedFile.ContentType;
                        objAadhar.FileDescription = "Non-Encumbrance Certificate";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = bal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypundertaking1.Text = fupundertaking1.PostedFile.FileName;
                            hypundertaking1.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupundertaking1.PostedFile.FileName);
                            hypundertaking1.Target = "blank";
                            message = "alert('" + "Non-Encumbrance Certificate Uploaded successfully" + "')";
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
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnundertaking2_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupundertaking2.HasFile)
                {
                    Error = validations(fupundertaking2);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Excise licence held individually/jointly for one" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupundertaking2.PostedFile.SaveAs(serverpath + "\\" + fupundertaking2.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "95";
                        objAadhar.FilePath = serverpath + fupundertaking2.PostedFile.FileName;
                        objAadhar.FileName = fupundertaking2.PostedFile.FileName;
                        objAadhar.FileType = fupundertaking2.PostedFile.ContentType;
                        objAadhar.FileDescription = "Excise licence held individually/jointly for one";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = bal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypundertaking2.Text = fupundertaking2.PostedFile.FileName;
                            hypundertaking2.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupundertaking2.PostedFile.FileName);
                            hypundertaking2.Target = "blank";
                            message = "alert('" + "Excise licence held individually/jointly for one Uploaded successfully" + "')";
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
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnstaff_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupstaff.HasFile)
                {
                    Error = validations(fupstaff);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Excise licence held by direct family member" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupstaff.PostedFile.SaveAs(serverpath + "\\" + fupstaff.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "96";
                        objAadhar.FilePath = serverpath + fupstaff.PostedFile.FileName;
                        objAadhar.FileName = fupstaff.PostedFile.FileName;
                        objAadhar.FileType = fupstaff.PostedFile.ContentType;
                        objAadhar.FileDescription = "Excise licence held by direct family member";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = bal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypstaff.Text = fupstaff.PostedFile.FileName;
                            hypstaff.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupstaff.PostedFile.FileName);
                            hypstaff.Target = "blank";
                            message = "alert('" + "Excise licence held by direct family member Uploaded successfully" + "')";
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
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
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
                else if (!ValidateFileExtension(Attachment))
                {
                    Error = Error + slno + ". Document should not contain double extension (double . ) \\n";
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
            try
            {
                string Attachmentname = Attachment.PostedFile.FileName;
                string[] fileType = Attachmentname.Split('.');
                int i = fileType.Length;

                if (i == 2 && fileType[i - 1].ToUpper().Trim() == "PDF")
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            { throw ex; }
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

        protected void btnagencyClearance_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupagencyClearance.HasFile)
                {
                    Error = validations(fupagencyClearance);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Single Window Agency Clearance" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupagencyClearance.PostedFile.SaveAs(serverpath + "\\" + fupagencyClearance.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "97";
                        objAadhar.FilePath = serverpath + fupagencyClearance.PostedFile.FileName;
                        objAadhar.FileName = fupagencyClearance.PostedFile.FileName;
                        objAadhar.FileType = fupagencyClearance.PostedFile.ContentType;
                        objAadhar.FileDescription = "Single Window Agency Clearance";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = bal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypagencyClearance.Text = fupagencyClearance.PostedFile.FileName;
                            hypagencyClearance.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupagencyClearance.PostedFile.FileName);
                            hypagencyClearance.Target = "blank";
                            message = "alert('" + "Single Window Agency Clearance Uploaded successfully" + "')";
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
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnProjectReport_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupProjectReport.HasFile)
                {
                    Error = validations(fupProjectReport);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Detailed Project Report" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupProjectReport.PostedFile.SaveAs(serverpath + "\\" + fupProjectReport.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "98";
                        objAadhar.FilePath = serverpath + fupProjectReport.PostedFile.FileName;
                        objAadhar.FileName = fupProjectReport.PostedFile.FileName;
                        objAadhar.FileType = fupProjectReport.PostedFile.ContentType;
                        objAadhar.FileDescription = "Detailed Project Report";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = bal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypProjectReport.Text = fupProjectReport.PostedFile.FileName;
                            hypProjectReport.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupProjectReport.PostedFile.FileName);
                            hypProjectReport.Target = "blank";
                            message = "alert('" + "Detailed Project Report Uploaded successfully" + "')";
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
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnPreviuos_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/CFO/CFOBusinessLicenseDetails.aspx?Previous=P");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            //  Response.Redirect("~/User/CFO/CFOBusinessLicenseDetails.aspx?Previous=P");
        }

        protected void rblArtical5_SelectedIndexChanged(object sender, EventArgs e)
        {
            rblArtical5.BorderColor = System.Drawing.Color.White;
        }

        protected void rblapplicant_SelectedIndexChanged(object sender, EventArgs e)
        {
            rblapplicant.BorderColor = System.Drawing.Color.White;
        }

        protected void rblMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            rblMember.BorderColor = System.Drawing.Color.White;
        }

        protected void rblTax_SelectedIndexChanged(object sender, EventArgs e)
        {
            rblTax.BorderColor = System.Drawing.Color.White;
        }

        protected void rblsaletax_SelectedIndexChanged(object sender, EventArgs e)
        {
            rblsaletax.BorderColor = System.Drawing.Color.White;
        }

        protected void rblprofession_SelectedIndexChanged(object sender, EventArgs e)
        {
            rblprofession.BorderColor = System.Drawing.Color.White;
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                btnsave_Click(sender, e);
                if (Errormsg == "")
                    Response.Redirect("~/User/CFO/CFOForestTransit.aspx?next=N");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            //  Response.Redirect("~/User/CFO/CFOUploadEnclosures.aspx?next=N");
        }
    }
}