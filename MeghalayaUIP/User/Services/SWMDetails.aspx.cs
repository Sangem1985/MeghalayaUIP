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

namespace MeghalayaUIP.User.Services
{
    public partial class SWMDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        SVRCBAL objSrvcbal = new SVRCBAL();

        string ErrorMsg = "", result;
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

                if (!IsPostBack)
                {
                    
                }
            }

        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg = stepValidations();
                if (ErrorMsg == "")
                {


                    SWMdetails swmdetails = new SWMdetails
                    {
                        namelocaloperator = txtNameLocalBody.Text,
                        nodalauthorisedagency = txtDesignation.Text,
                        authorizationopeartion = string.Join(",", CHKAuthorization.Items.Cast<ListItem>()
                                       .Where(item => item.Selected)
                                       .Select(item => item.Value)),
                        totalquantitywaste = Convert.ToDouble(txtWasteProduced.Text),
                        quantitywasterecycle = Convert.ToDouble(txtWasteRecycled.Text),
                        quantitywastetreated = Convert.ToDouble(txtWasteTreated.Text),
                        quantitywastedisposed = Convert.ToDouble(txtWasteDisposed.Text),
                        quantityleachate = Convert.ToDouble(txtQuanLeachate.Text),
                        treatmenttechleachate = txtTreatmentLeachate.Text,
                        measurescep = txtMeasuresForPrevention.Text,
                        measuressafteyplant = txtMeasuresForSafety.Text,
                        nosites = Convert.ToInt32(txtSiteIdentified.Text),
                        quantitywasteperday = Convert.ToDouble(txtQantityWasteDisposed.Text),
                        detailsexistingsite = txtExistingSiteUnderOperation.Text,
                        methodologydetails = txtLandfillingDetails.Text,
                        checkenvironmentpollution = txtMeasureToChkEnvPoltn.Text,
                        createdby = "UserName", // Replace with actual user name
                        createdbyip = getclientIP()

                    };

                    result = objSrvcbal.SRVCSWDDetails(swmdetails);
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
                if(string.IsNullOrEmpty(txtWasteProduced.Text) || txtWasteProduced.Text == "" || txtWasteProduced.Text == null)
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
                if (!fupDisposal.HasFile)
                {
                    errormsg += slno + ". Please upload the methodology for disposal \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtTreatmentLeachate.Text) || txtTreatmentLeachate.Text == "" || txtTreatmentLeachate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter  treatment technology for leachate \\n";
                    slno = slno + 1;
                }
                if(string.IsNullOrEmpty(txtMeasuresForPrevention.Text) || txtMeasuresForPrevention.Text == "" || txtMeasuresForPrevention.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter measures to be taken for prevention and control of environmental pollution \\n";
                    slno = slno + 1;
                }
                if(string.IsNullOrEmpty(txtMeasuresForSafety.Text) || txtMeasuresForSafety.Text == "" || txtMeasuresForSafety.Text == null)
                {
                    errormsg = errormsg + slno + ". Please enter measures to be taken for safety of workers working in the plant \\n";                                                   
                    slno = slno + 1;
                }
                if (!fupDetailsSolidWaste.HasFile)
                {
                    errormsg += slno + ". Please upload the details on solid waste processing/recycling/treatment/disposal facility \\n";
                    slno++;
                }
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
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                        + Convert.ToString(Session["CFEQID"]) + "\\" + "Site Plan" + "\\";
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
                        objSWPRTD.UNITID = "1001";//Convert.ToString(Session["CFEUNITID"]);
                        objSWPRTD.Questionnareid = "1001"; //Convert.ToString(Session["CFEQID"]);
                        objSWPRTD.MasterID = "15";
                        objSWPRTD.FilePath = serverpath + fupDetailsSolidWaste.PostedFile.FileName;
                        objSWPRTD.FileName = fupDetailsSolidWaste.PostedFile.FileName;
                        objSWPRTD.FileType = fupDetailsSolidWaste.PostedFile.ContentType;
                        objSWPRTD.FileDescription = "Site Plan";
                        objSWPRTD.CreatedBy = hdnUserID.Value;
                        objSWPRTD.IPAddress = getclientIP();
                        objSWPRTD.ReferenceNo = txtSWPRTD.Text;
                        result = objSrvcbal.InsertSRVCAttachments(objSWPRTD);
                        if (result != "")
                        {
                            hypSWPRTD.Text = fupDetailsSolidWaste.PostedFile.FileName;
                            hypSWPRTD.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupDetailsSolidWaste.PostedFile.FileName);
                            hypSWPRTD.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
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
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                        + Convert.ToString(Session["CFEQID"]) + "\\" + "Site Plan" + "\\";
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
                        objSiteSelection.UNITID = "1001";//Convert.ToString(Session["CFEUNITID"]);
                        objSiteSelection.Questionnareid = "1001"; //Convert.ToString(Session["CFEQID"]);
                        objSiteSelection.MasterID = "15";
                        objSiteSelection.FilePath = serverpath + fupDetailSiteSelection.PostedFile.FileName;
                        objSiteSelection.FileName = fupDetailSiteSelection.PostedFile.FileName;
                        objSiteSelection.FileType = fupDetailSiteSelection.PostedFile.ContentType;
                        objSiteSelection.FileDescription = "Site Plan";
                        objSiteSelection.CreatedBy = hdnUserID.Value;
                        objSiteSelection.IPAddress = getclientIP();
                        objSiteSelection.ReferenceNo = txtDetailSiteSel.Text;
                        result = objSrvcbal.InsertSRVCAttachments(objSiteSelection);
                        if (result != "")
                        {
                            hypDetailSiteSel.Text = fupDetailSiteSelection.PostedFile.FileName;
                            hypDetailSiteSel.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupDetailSiteSelection.PostedFile.FileName);
                            hypDetailSiteSel.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
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
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                        + Convert.ToString(Session["CFEQID"]) + "\\" + "Site Plan" + "\\";
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
                        objSiteClr.UNITID = "1001";//Convert.ToString(Session["CFEUNITID"]);
                        objSiteClr.Questionnareid = "1001"; //Convert.ToString(Session["CFEQID"]);
                        objSiteClr.MasterID = "15";
                        objSiteClr.FilePath = serverpath + fupSiteClearance.PostedFile.FileName;
                        objSiteClr.FileName = fupSiteClearance.PostedFile.FileName;
                        objSiteClr.FileType = fupSiteClearance.PostedFile.ContentType;
                        objSiteClr.FileDescription = "Site Plan";
                        objSiteClr.CreatedBy = hdnUserID.Value;
                        objSiteClr.IPAddress = getclientIP();
                        objSiteClr.ReferenceNo = txtSiteClr.Text;
                        result = objSrvcbal.InsertSRVCAttachments(objSiteClr);
                        if (result != "")
                        {
                            hypSiteClr.Text = fupSiteClearance.PostedFile.FileName;
                            hypSiteClr.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupSiteClearance.PostedFile.FileName);
                            hypSiteClr.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
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
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                        + Convert.ToString(Session["CFEQID"]) + "\\" + "Site Plan" + "\\";
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
                        objEnvClr.UNITID = "1001";//Convert.ToString(Session["CFEUNITID"]);
                        objEnvClr.Questionnareid = "1001"; //Convert.ToString(Session["CFEQID"]);
                        objEnvClr.MasterID = "15";
                        objEnvClr.FilePath = serverpath + fupEnvironmentalClearance.PostedFile.FileName;
                        objEnvClr.FileName = fupEnvironmentalClearance.PostedFile.FileName;
                        objEnvClr.FileType = fupEnvironmentalClearance.PostedFile.ContentType;
                        objEnvClr.FileDescription = "Site Plan";
                        objEnvClr.CreatedBy = hdnUserID.Value;
                        objEnvClr.IPAddress = getclientIP();
                        objEnvClr.ReferenceNo = txtEnvClearance.Text;
                        result = objSrvcbal.InsertSRVCAttachments(objEnvClr);
                        if (result != "")
                        {
                            hypEnvClearance.Text = fupEnvironmentalClearance.PostedFile.FileName;
                            hypEnvClearance.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupEnvironmentalClearance.PostedFile.FileName);
                            hypEnvClearance.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
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
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                        + Convert.ToString(Session["CFEQID"]) + "\\" + "Site Plan" + "\\";
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
                        objAgreement.UNITID = "1001";//Convert.ToString(Session["CFEUNITID"]);
                        objAgreement.Questionnareid = "1001"; //Convert.ToString(Session["CFEQID"]);
                        objAgreement.MasterID = "15";
                        objAgreement.FilePath = serverpath + fupAgreement.PostedFile.FileName;
                        objAgreement.FileName = fupAgreement.PostedFile.FileName;
                        objAgreement.FileType = fupAgreement.PostedFile.ContentType;
                        objAgreement.FileDescription = "Site Plan";
                        objAgreement.CreatedBy = hdnUserID.Value;
                        objAgreement.IPAddress = getclientIP();
                        objAgreement.ReferenceNo = txtAgreement.Text;
                        result = objSrvcbal.InsertSRVCAttachments(objAgreement);
                        if (result != "")
                        {
                            hypAgreement.Text = fupAgreement.PostedFile.FileName;
                            hypAgreement.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupAgreement.PostedFile.FileName);
                            hypAgreement.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
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
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Disposal" + "\\";
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
                        objDisposal.UNITID = "1001";//Convert.ToString(Session["CFEUNITID"]);
                        objDisposal.Questionnareid = "101"; //Convert.ToString(Session["CFEQID"]);
                        objDisposal.MasterID = "";
                        objDisposal.FilePath = serverpath + fupDisposal.PostedFile.FileName;
                        objDisposal.FileName = fupDisposal.PostedFile.FileName;
                        objDisposal.FileType = fupDisposal.PostedFile.ContentType;
                        objDisposal.FileDescription = "";
                        objDisposal.CreatedBy = hdnUserID.Value;
                        objDisposal.IPAddress = getclientIP();
                        objDisposal.ReferenceNo = txtCBWTFSWM.Text;
                        result = objSrvcbal.InsertSRVCAttachments(objDisposal);
                        if (result != "")
                        {
                            hypSolidwaste.Text = fupDisposal.PostedFile.FileName;
                            hypSolidwaste.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupDisposal.PostedFile.FileName);
                            hypSolidwaste.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
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