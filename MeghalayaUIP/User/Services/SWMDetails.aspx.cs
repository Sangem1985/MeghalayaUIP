using System;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.SVRCBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static AjaxControlToolkit.AsyncFileUpload.Constants;
using System.Text.RegularExpressions;
using System.IO;
using System.Data;

namespace MeghalayaUIP.User.Services
{
    public partial class SWMDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        SVRCBAL objSrvcbal = new SVRCBAL();

        string  ErrorMsg = "", result, Questionnaire;
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
                //if (Convert.ToString(Session["SRVCUNITID"]) != "")
                //{
                //    UnitID = Convert.ToString(Session["SRVCUNITID"]);
                //}
                if (Convert.ToString(Session["SRVCQID"]) != "" && Convert.ToString(Session["SRVCQID"]) == null)
                {
                    Questionnaire = Convert.ToString(Session["SRVCQID"]);
                }
                //else
                //{
                //    string newurl = "~/User/Services/SRVCUserDashboard.aspx";
                //    Response.Redirect(newurl);
                //}


                if (!IsPostBack)
                {
                    GetAppliedorNot();
                }
            }

        }
        protected void GetAppliedorNot()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = objSrvcbal.GetsrvcapprovalID(hdnUserID.Value, Convert.ToString(Session["SRVCQID"]), "12", "82");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(ds.Tables[0].Rows[0]["SRVCDA_APPROVALID"]) == "82")
                    {
                        BindAuthYearsDropdown();
                        BindData();
                        
                    }
                }
                else
                {
                    if (Request.QueryString.Count > 0)
                    {
                        if (Convert.ToString(Request.QueryString[0]) == "N")
                            Response.Redirect("~/User/Services/BMWDetails.aspx?Next=" + "N");
                        else if (Convert.ToString(Request.QueryString[0]) == "P")
                            Response.Redirect("~/User/Services/OtherServices.aspx?Previous=" + "P");
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

        private void BindAuthYearsDropdown()
        {
            try
            {
                ddlAuthYears.Items.Clear();

                AddSelect(ddlAuthYears);

                ddlAuthYears.Items.Add(new ListItem("1 Year", "1"));
                ddlAuthYears.Items.Add(new ListItem("5 Years", "5"));

                ddlAuthYears.SelectedIndex = 0;
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
        public void BindData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objSrvcbal.GetSrvcSWMDetails(hdnUserID.Value, Convert.ToString(Session["SRVCQID"]));

                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["SRVCSWD_AUTHORIZATIONOPEARTION"].ToString().Contains("Waste Processing"))
                            CHKAuthorization.Items[0].Selected = true;
                        if (ds.Tables[0].Rows[0]["SRVCSWD_AUTHORIZATIONOPEARTION"].ToString().Contains("Recycling"))
                            CHKAuthorization.Items[1].Selected = true;
                        if (ds.Tables[0].Rows[0]["SRVCSWD_AUTHORIZATIONOPEARTION"].ToString().Contains("Treatment"))
                            CHKAuthorization.Items[2].Selected = true;
                        if (ds.Tables[0].Rows[0]["SRVCSWD_AUTHORIZATIONOPEARTION"].ToString().Contains("Dispersal at Landfill"))
                            CHKAuthorization.Items[3].Selected = true;

                        txtNameLocalBody.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCSWD_NAMELOCALOPERATOR"]);
                        txtDesignation.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCSWD_NODALAUTHORISEDAGENCY"]);
                        // CHKAuthorization.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCSWD_AUTHORIZATIONOPEARTION"]);
                        ddlAuthYears.SelectedValue= Convert.ToString(ds.Tables[0].Rows[0]["SRVCSOLIDWASTENO"]);

                        txtWasteProduced.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCSWD_TOTALQUANTITYWASTE"]);
                        txtWasteRecycled.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCSWD_TOTALQUANTITYWASTE"]);
                        txtWasteTreated.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCSWD_QUANTITYWASTERECYCLE"]);
                        txtWasteDisposed.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCSWD_QUANTITYWASTETREATED"]);
                        txtUtilisation.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCSWD_QUANTITYWASTEDISPOSED"]);
                        txtQuanLeachate.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCSWD_QUANTITYLEACHATE"]);
                        txtTreatmentLeachate.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCSWD_TREATMENTTECHLEACHATE"]);
                        txtMeasuresForPrevention.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCSWD_MEASURESCEP"]);
                        txtMeasuresForSafety.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCSWD_MEASURESSAFTEYPLANT"]);
                        txtSiteIdentified.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCSWD_NOSITES"]);
                        txtQantityWasteDisposed.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCSWD_QUANTITYWASTEPERDAY"]);
                        txtExistingSiteUnderOperation.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCSWD_DETAILSEXISTINGSITE"]);
                        txtLandfillingDetails.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCSWD_METHODOLOGYDETAILS"]);
                        txtMeasureToChkEnvPoltn.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCSWD_CHECKENVIRONMENTPOLLUTION"]);
                        txtAuthFee.Text = Convert.ToString(ds.Tables[0].Rows[0]["SRVCSWD_AUTHFEE"]);

                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            if (Convert.ToInt32(ds.Tables[1].Rows[i]["SRVCA_MASTERID"]) == 4)
                            {
                                hypSolidwaste.Visible = true;
                                hypSolidwaste.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILEPATH"]));
                                hypSolidwaste.Text = Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILENAME"]);
                                txtCBWTFSWM.Text = Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILLREFNO"]);
                            }
                            if (Convert.ToInt32(ds.Tables[1].Rows[i]["SRVCA_MASTERID"]) == 5)
                            {
                                hypSWPRTD.Visible = true;
                                hypSWPRTD.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILEPATH"]));
                                hypSWPRTD.Text = Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILENAME"]);
                                txtSWPRTD.Text = Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILLREFNO"]);
                            }
                            if (Convert.ToInt32(ds.Tables[1].Rows[i]["SRVCA_MASTERID"]) == 6)
                            {
                                hypDetailSiteSel.Visible = true;
                                hypDetailSiteSel.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILEPATH"]));
                                hypDetailSiteSel.Text = Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILENAME"]);
                                txtDetailSiteSel.Text = Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILLREFNO"]);
                            }
                            if (Convert.ToInt32(ds.Tables[1].Rows[i]["SRVCA_MASTERID"]) == 7)
                            {
                                hypSiteClr.Visible = true;
                                hypSiteClr.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILEPATH"]));
                                hypSiteClr.Text = Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILENAME"]);
                                txtSiteClr.Text = Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILLREFNO"]);
                            }
                            if (Convert.ToInt32(ds.Tables[1].Rows[i]["SRVCA_MASTERID"]) == 8)
                            {
                                hypEnvClearance.Visible = true;
                                hypEnvClearance.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILEPATH"]));
                                hypEnvClearance.Text = Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILENAME"]);
                                txtEnvClearance.Text = Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILLREFNO"]);
                            }
                            if (Convert.ToInt32(ds.Tables[1].Rows[i]["SRVCA_MASTERID"]) == 9)
                            {
                                hypAgreement.Visible = true;
                                hypAgreement.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILEPATH"]));
                                hypAgreement.Text = Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILENAME"]);
                                txtAgreement.Text = Convert.ToString(ds.Tables[1].Rows[i]["SRVCA_FILLREFNO"]);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg = stepValidations();
                if (ErrorMsg == "")
                {


                    SWMdetails ObjSWMDet = new SWMdetails();

                    var selectedItems = CHKAuthorization.Items.Cast<ListItem>()
                            .Where(li => li.Selected)
                            .Select(li => li.Text);

                    string selectedActivities = string.Join(", ", selectedItems);

                   // ObjSWMDet.unitid = Convert.ToString(Session["SRVCUNITID"]);
                    ObjSWMDet.Questionnariid = Convert.ToString(Session["SRVCQID"]);
                    ObjSWMDet.createdby = hdnUserID.Value;
                    ObjSWMDet.createdbyip = getclientIP();
                    ObjSWMDet.authorizationopeartion = selectedActivities;
                    ObjSWMDet.namelocaloperator = txtNameLocalBody.Text;
                    ObjSWMDet.nodalauthorisedagency = txtDesignation.Text;
                    ObjSWMDet.totalquantitywaste = txtWasteProduced.Text;
                    ObjSWMDet.quantitywasterecycle = txtWasteRecycled.Text;
                    ObjSWMDet.quantitywastetreated = txtWasteTreated.Text;
                    ObjSWMDet.quantitywastedisposed = txtWasteDisposed.Text;
                    ObjSWMDet.quantityleachate = txtQuanLeachate.Text;
                    ObjSWMDet.treatmenttechleachate = txtTreatmentLeachate.Text;
                    ObjSWMDet.measurescep = txtMeasuresForPrevention.Text;
                    ObjSWMDet.measuressafteyplant = txtMeasuresForSafety.Text;
                    ObjSWMDet.nosites = txtSiteIdentified.Text;
                    ObjSWMDet.quantitywasteperday = txtQantityWasteDisposed.Text;
                    ObjSWMDet.detailsexistingsite = txtExistingSiteUnderOperation.Text;
                    ObjSWMDet.methodologydetails = txtLandfillingDetails.Text;
                    ObjSWMDet.checkenvironmentpollution = txtMeasureToChkEnvPoltn.Text;
                    ObjSWMDet.authfee = txtAuthFee.Text;
                    ObjSWMDet.Totalsolid = ddlAuthYears.SelectedValue;
                    //authorizationopeartion = string.Join(",", CHKAuthorization.Items.Cast<ListItem>()
                    //               .Where(item => item.Selected)
                    //               .Select(item => item.Value)),






                    result = objSrvcbal.INSSRVCSOLIDDDetails(ObjSWMDet);
                    if (result != "")
                    {
                        string message = "alert('" + "SWMD Details Saved Successfully" + "')";
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
                throw ex;
            }
        }
        //textbox validations
        public string stepValidations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                List<TextBox> emptyTextboxes = FindEmptyTextboxes(divText);

                if (string.IsNullOrEmpty(txtNameLocalBody.Text) || txtNameLocalBody.Text == "" || txtNameLocalBody.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Local Body Name or Agency appointed or Operator of facility \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDesignation.Text) || txtDesignation.Text == "" || txtDesignation.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Nodal Officer Designation authorized by local body or agency \\n";
                    slno = slno + 1;
                }
                if (CHKAuthorization.SelectedItem == null)
                {
                    errormsg = errormsg + slno + ". Please select at least one option for setting up and operation of the facility \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtWasteProduced.Text) || txtWasteProduced.Text == "" || txtWasteProduced.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter total waste to be produced per day \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtWasteRecycled.Text) || txtWasteRecycled.Text == "" || txtWasteRecycled.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter total waste to be recycled per day \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtWasteTreated.Text) || txtWasteTreated.Text == "" || txtWasteTreated.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter total waste to be treated per day \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtWasteDisposed.Text) || txtWasteDisposed.Text == "" || txtWasteDisposed.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter total waste to be disposed per day \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtUtilisation.Text) || txtUtilisation.Text == "" || txtUtilisation.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter Utitlization programme for waste processed \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtQuanLeachate.Text) || txtQuanLeachate.Text == "" || txtQuanLeachate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter quantity of leachate \\n";
                    slno = slno + 1;
                }
                //if (!fupDisposal.HasFile)
                //{
                //    errormsg += slno + ". Please upload the methodology for disposal \\n";
                //    slno++;
                //}
                if (string.IsNullOrEmpty(txtTreatmentLeachate.Text) || txtTreatmentLeachate.Text == "" || txtTreatmentLeachate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter  treatment technology for leachate \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtMeasuresForPrevention.Text) || txtMeasuresForPrevention.Text == "" || txtMeasuresForPrevention.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter measures to be taken for prevention and control of environmental pollution \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtMeasuresForSafety.Text) || txtMeasuresForSafety.Text == "" || txtMeasuresForSafety.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter measures to be taken for safety of workers working in the plant \\n";
                    slno = slno + 1;
                }
                //if (!fupDetailsSolidWaste.HasFile)
                //{
                //    errormsg += slno + ". Please upload the details on solid waste processing/recycling/treatment/disposal facility \\n";
                //    slno++;
                //}
                if (string.IsNullOrEmpty(txtSiteIdentified.Text) || txtSiteIdentified.Text == "" || txtSiteIdentified.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter number Of sites identified \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtSiteIdentified.Text) || txtSiteIdentified.Text == "" || txtSiteIdentified.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter number Of sites identified \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtQantityWasteDisposed.Text) || txtQantityWasteDisposed.Text == "" || txtQantityWasteDisposed.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter quantity of waste to be disposed per day \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtExistingSiteUnderOperation.Text) || txtExistingSiteUnderOperation.Text == "" || txtExistingSiteUnderOperation.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter details Of Existing Site under operation \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLandfillingDetails.Text) || txtLandfillingDetails.Text == "" || txtLandfillingDetails.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter methodology and operational details of landfilling \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtMeasureToChkEnvPoltn.Text) || txtMeasureToChkEnvPoltn.Text == "" || txtMeasureToChkEnvPoltn.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter measures taken to check environmental pollution \\n";
                    slno = slno + 1;
                }
                //if (!fupDetailSiteSelection.HasFile)
                //{
                //    errormsg += slno + ". Please upload details of methodology or criteria followed for site selection \\n";
                //    slno++;
                //}
                //if (!fupSiteClearance.HasFile)
                //{
                //    errormsg += slno + ". Please upload the site clearance document \\n";
                //    slno++;
                //}
                //if (!fupEnvironmentalClearance.HasFile)
                //{
                //    errormsg += slno + ". Please upload the environmental Clearance Consent for eshtablishment \\n";
                //    slno++;
                //}
                //if (!fupAgreement.HasFile)
                //{
                //    errormsg += slno + ". Please upload the agreement between municipal authority and opearting agency \\n";
                //    slno++;
                //}
                //if (!fupInvestment.HasFile)
                //{
                //    errormsg += slno + ". Please upload the investment on Project and Expected Return \\n";
                //    slno++;
                //}
                if (string.IsNullOrEmpty(txtAuthFee.Text) || txtAuthFee.Text == "" || txtAuthFee.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Select number of years for all kind of Solid Waste Management Authorization  \\n";
                    slno = slno + 1;
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
                //  }
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

        protected void btnDetailsSolidWaste_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupDetailsSolidWaste.HasFile)
                {
                    Error = validations(fupDetailsSolidWaste);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["SRVCAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                        + Convert.ToString(Session["SRVCQID"]) + "\\" + "solid waste processing/recycling/treatment/disposal facility" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupDetailsSolidWaste.PostedFile.SaveAs(serverpath + "\\" + fupDetailsSolidWaste.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupDetailsSolidWaste.PostedFile.SaveAs(serverpath + "\\" + fupDetailsSolidWaste.PostedFile.FileName);
                            }
                        }


                        SRVCAttachments objSWPRTD = new SRVCAttachments();
                        objSWPRTD.UNITID = Convert.ToString(Session["SRVCUNITID"]);//Convert.ToString(Session["CFEUNITID"]);
                        objSWPRTD.Questionnareid = Convert.ToString(Session["SRVCQID"]); //Convert.ToString(Session["CFEQID"]);
                        objSWPRTD.MasterID = "9";
                        objSWPRTD.FilePath = serverpath + fupDetailsSolidWaste.PostedFile.FileName;
                        objSWPRTD.FileName = fupDetailsSolidWaste.PostedFile.FileName;
                        objSWPRTD.FileType = fupDetailsSolidWaste.PostedFile.ContentType;
                        objSWPRTD.FileDescription = "solid waste processing/recycling/treatment/disposal facility";
                        objSWPRTD.CreatedBy = hdnUserID.Value;
                        objSWPRTD.IPAddress = getclientIP();
                        objSWPRTD.ReferenceNo = txtSWPRTD.Text;
                        result = objSrvcbal.InsertSRVCAttachments(objSWPRTD);
                        if (result != "")
                        {
                            hypSWPRTD.Text = fupDetailsSolidWaste.PostedFile.FileName;
                            hypSWPRTD.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupDetailsSolidWaste.PostedFile.FileName);
                            hypSWPRTD.Target = "blank";
                            message = "alert('" + "Details on solid waste processing/recycling/treatment/disposal facility Document Uploaded successfully" + "')";
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }

        protected void btnDetailSiteSelection_Click(object sender, EventArgs e)
        {

            try
            {
                string Error = ""; string message = "";
                if (fupDetailSiteSelection.HasFile)
                {
                    Error = validations(fupDetailSiteSelection);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["SRVCAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                        + Convert.ToString(Session["SRVCQID"]) + "\\" + "methodology or criteria followed for site selection" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupDetailSiteSelection.PostedFile.SaveAs(serverpath + "\\" + fupDetailSiteSelection.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupDetailSiteSelection.PostedFile.SaveAs(serverpath + "\\" + fupDetailSiteSelection.PostedFile.FileName);
                            }
                        }


                        SRVCAttachments objSiteSelection = new SRVCAttachments();
                        objSiteSelection.UNITID = Convert.ToString(Session["SRVCUNITID"]); //Convert.ToString(Session["CFEUNITID"]);
                        objSiteSelection.Questionnareid = Convert.ToString(Session["SRVCQID"]); //Convert.ToString(Session["CFEQID"]);
                        objSiteSelection.MasterID = "8";
                        objSiteSelection.FilePath = serverpath + fupDetailSiteSelection.PostedFile.FileName;
                        objSiteSelection.FileName = fupDetailSiteSelection.PostedFile.FileName;
                        objSiteSelection.FileType = fupDetailSiteSelection.PostedFile.ContentType;
                        objSiteSelection.FileDescription = "methodology or criteria followed for site selection";
                        objSiteSelection.CreatedBy = hdnUserID.Value;
                        objSiteSelection.IPAddress = getclientIP();
                        objSiteSelection.ReferenceNo = txtDetailSiteSel.Text;
                        result = objSrvcbal.InsertSRVCAttachments(objSiteSelection);
                        if (result != "")
                        {
                            hypDetailSiteSel.Text = fupDetailSiteSelection.PostedFile.FileName;
                            hypDetailSiteSel.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupDetailSiteSelection.PostedFile.FileName);
                            hypDetailSiteSel.Target = "blank";
                            message = "alert('" + "Details of methodology or criteria followed for site selection Document Uploaded successfully" + "')";
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnSiteClearance_Click(object sender, EventArgs e)
        {

            try
            {
                string Error = ""; string message = "";
                if (fupSiteClearance.HasFile)
                {
                    Error = validations(fupSiteClearance);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["SRVCAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                        + Convert.ToString(Session["SRVCQID"]) + "\\" + "Site Clearance" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupSiteClearance.PostedFile.SaveAs(serverpath + "\\" + fupSiteClearance.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupSiteClearance.PostedFile.SaveAs(serverpath + "\\" + fupSiteClearance.PostedFile.FileName);
                            }
                        }


                        SRVCAttachments objSiteClr = new SRVCAttachments();
                        objSiteClr.UNITID = Convert.ToString(Session["SRVCUNITID"]);//Convert.ToString(Session["CFEUNITID"]);
                        objSiteClr.Questionnareid = Convert.ToString(Session["SRVCQID"]); //Convert.ToString(Session["CFEQID"]);
                        objSiteClr.MasterID = "7";
                        objSiteClr.FilePath = serverpath + fupSiteClearance.PostedFile.FileName;
                        objSiteClr.FileName = fupSiteClearance.PostedFile.FileName;
                        objSiteClr.FileType = fupSiteClearance.PostedFile.ContentType;
                        objSiteClr.FileDescription = "Site Clearance";
                        objSiteClr.CreatedBy = hdnUserID.Value;
                        objSiteClr.IPAddress = getclientIP();
                        objSiteClr.ReferenceNo = txtSiteClr.Text;
                        result = objSrvcbal.InsertSRVCAttachments(objSiteClr);
                        if (result != "")
                        {
                            hypSiteClr.Text = fupSiteClearance.PostedFile.FileName;
                            hypSiteClr.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupSiteClearance.PostedFile.FileName);
                            hypSiteClr.Target = "blank";
                            message = "alert('" + "Site Clearance Document Uploaded successfully" + "')";
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnEnvironmentalClearance_Click(object sender, EventArgs e)
        {

            try
            {
                string Error = ""; string message = "";
                if (fupEnvironmentalClearance.HasFile)
                {
                    Error = validations(fupEnvironmentalClearance);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["SRVCAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                        + Convert.ToString(Session["SRVCQID"]) + "\\" + "Environmental Clearance Consent for eshtablishment" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupEnvironmentalClearance.PostedFile.SaveAs(serverpath + "\\" + fupEnvironmentalClearance.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupEnvironmentalClearance.PostedFile.SaveAs(serverpath + "\\" + fupEnvironmentalClearance.PostedFile.FileName);
                            }
                        }


                        SRVCAttachments objEnvClr = new SRVCAttachments();
                        objEnvClr.UNITID = Convert.ToString(Session["SRVCUNITID"]);//Convert.ToString(Session["CFEUNITID"]);
                        objEnvClr.Questionnareid = Convert.ToString(Session["SRVCQID"]); //Convert.ToString(Session["CFEQID"]);
                        objEnvClr.MasterID = "6";
                        objEnvClr.FilePath = serverpath + fupEnvironmentalClearance.PostedFile.FileName;
                        objEnvClr.FileName = fupEnvironmentalClearance.PostedFile.FileName;
                        objEnvClr.FileType = fupEnvironmentalClearance.PostedFile.ContentType;
                        objEnvClr.FileDescription = "Environmental Clearance Consent for eshtablishment";
                        objEnvClr.CreatedBy = hdnUserID.Value;
                        objEnvClr.IPAddress = getclientIP();
                        objEnvClr.ReferenceNo = txtEnvClearance.Text;
                        result = objSrvcbal.InsertSRVCAttachments(objEnvClr);
                        if (result != "")
                        {
                            hypEnvClearance.Text = fupEnvironmentalClearance.PostedFile.FileName;
                            hypEnvClearance.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupEnvironmentalClearance.PostedFile.FileName);
                            hypEnvClearance.Target = "blank";
                            message = "alert('" + "Environmental Clearance Consent for eshtablishment Document Uploaded successfully" + "')";
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnAgreement_Click(object sender, EventArgs e)
        {

            try
            {
                string Error = ""; string message = "";
                if (fupAgreement.HasFile)
                {
                    Error = validations(fupAgreement);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["SRVCAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                        + Convert.ToString(Session["SRVCQID"]) + "\\" + "municipal authority and opearting agency" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupAgreement.PostedFile.SaveAs(serverpath + "\\" + fupAgreement.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupAgreement.PostedFile.SaveAs(serverpath + "\\" + fupAgreement.PostedFile.FileName);
                            }
                        }


                        SRVCAttachments objAgreement = new SRVCAttachments();
                        objAgreement.UNITID = Convert.ToString(Session["SRVCUNITID"]);//Convert.ToString(Session["CFEUNITID"]);
                        objAgreement.Questionnareid = Convert.ToString(Session["SRVCQID"]); //Convert.ToString(Session["CFEQID"]);
                        objAgreement.MasterID = "5";
                        objAgreement.FilePath = serverpath + fupAgreement.PostedFile.FileName;
                        objAgreement.FileName = fupAgreement.PostedFile.FileName;
                        objAgreement.FileType = fupAgreement.PostedFile.ContentType;
                        objAgreement.FileDescription = "municipal authority and opearting agency";
                        objAgreement.CreatedBy = hdnUserID.Value;
                        objAgreement.IPAddress = getclientIP();
                        objAgreement.ReferenceNo = txtAgreement.Text;
                        result = objSrvcbal.InsertSRVCAttachments(objAgreement);
                        if (result != "")
                        {
                            hypAgreement.Text = fupAgreement.PostedFile.FileName;
                            hypAgreement.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupAgreement.PostedFile.FileName);
                            hypAgreement.Target = "blank";
                            message = "alert('" + "Agreement Between municipal authority and opearting agency Document Uploaded successfully" + "')";
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
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

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                btnsave_Click(sender, e);
                if (ErrorMsg == "")
                    Response.Redirect("~/User/Services/BMWDetails.aspx?Next=" + "N");
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
                Response.Redirect("~/User/Services/OtherServices.aspx?Previous=" + "P");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void ddlAuthYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlAuthYears.SelectedValue == "1")
                {
                    txtAuthFee.Text = "5000";
                }
                else if (ddlAuthYears.SelectedValue == "5")
                {
                    txtAuthFee.Text = "25000";
                    txtAuthFee.Text = "25000";

                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnDisposal_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupDisposal.HasFile)
                {
                    Error = validations(fupDisposal);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["SRVCAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["SRVCQID"]) + "\\" + "Disposal" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupDisposal.PostedFile.SaveAs(serverpath + "\\" + fupDisposal.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupDisposal.PostedFile.SaveAs(serverpath + "\\" + fupDisposal.PostedFile.FileName);
                            }
                        }

                        SRVCAttachments objDisposal = new SRVCAttachments();
                        objDisposal.UNITID = Convert.ToString(Session["SRVCUNITID"]);//Convert.ToString(Session["CFEUNITID"]);
                        objDisposal.Questionnareid = Convert.ToString(Session["SRVCQID"]); //Convert.ToString(Session["CFEQID"]);
                        objDisposal.MasterID = "4";
                        objDisposal.FilePath = serverpath + fupDisposal.PostedFile.FileName;
                        objDisposal.FileName = fupDisposal.PostedFile.FileName;
                        objDisposal.FileType = fupDisposal.PostedFile.ContentType;
                        objDisposal.FileDescription = "Methodology for disposal";
                        objDisposal.CreatedBy = hdnUserID.Value;
                        objDisposal.IPAddress = getclientIP();
                        objDisposal.ReferenceNo = txtCBWTFSWM.Text;
                        result = objSrvcbal.InsertSRVCAttachments(objDisposal);
                        if (result != "")
                        {
                            hypSolidwaste.Text = fupDisposal.PostedFile.FileName;
                            hypSolidwaste.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupDisposal.PostedFile.FileName);
                            hypSolidwaste.Target = "blank";
                            message = "alert('" + "Methodology for disposal Document Uploaded successfully" + "')";
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
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