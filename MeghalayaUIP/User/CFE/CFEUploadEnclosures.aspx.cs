using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Web.Services.Description;
using System.Data;
using System.Drawing;
using System.Net.Mail;
using MeghalayaUIP.CommonClass;
using System.Configuration;

namespace MeghalayaUIP.User.CFE
{
    public partial class CFEUploadEnclosures : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFEBAL objcfebal = new CFEBAL();

        string UnitID, result, errormsg = "";
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
                    if (Convert.ToString(Session["CFEUNITID"]) != "")
                    {
                        UnitID = Convert.ToString(Session["CFEUNITID"]);
                        hdnQuesid.Value = Convert.ToString(Session["CFEUNITID"]);
                    }
                    else
                    {
                        string newurl = "~/User/CFE/CFEUserDashboard.aspx";
                        Response.Redirect(newurl);
                    }

                    Page.MaintainScrollPositionOnPostBack = true;

                    Failure.Visible = false;
                    success.Visible = false;
                    if (!IsPostBack)
                    {

                        BindData();
                    }
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }
        protected void BindData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfebal.GetCFEAttachmentsData(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]));
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {


                        }
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                            {
                                if (Convert.ToInt32(ds.Tables[1].Rows[i]["CFEA_MASTERAID"]) == 11)//Aadhar
                                {
                                    hplAadhar.Visible = true;
                                    hplAadhar.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + Convert.ToString(ds.Tables[1].Rows[i]["FILELOCATION"]);
                                    hplAadhar.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                                }
                                if (Convert.ToInt32(ds.Tables[1].Rows[i]["CFEA_MASTERAID"]) == 12) //EPIC Document
                                {
                                    hplEPIC.Visible = true;
                                    hplEPIC.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + Convert.ToString(ds.Tables[1].Rows[i]["FILELOCATION"]);
                                    hplEPIC.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                                }
                                if (Convert.ToInt32(ds.Tables[1].Rows[i]["CFEA_MASTERAID"]) == 13) //Applicant Photograph
                                {
                                    hplApplPhoto.Visible = true;
                                    hplApplPhoto.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + Convert.ToString(ds.Tables[1].Rows[i]["FILELOCATION"]);
                                    hplApplPhoto.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                                }
                                if (Convert.ToInt32(ds.Tables[1].Rows[i]["CFEA_MASTERAID"]) == 14) //Land Document /Sale Deed
                                {
                                    hplLandDoc.Visible = true;
                                    hplLandDoc.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + Convert.ToString(ds.Tables[1].Rows[i]["FILELOCATION"]);
                                    hplLandDoc.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                                }
                                if (Convert.ToInt32(ds.Tables[1].Rows[i]["CFEA_MASTERAID"]) == 15) //Site Plan
                                {
                                    hplSitePlan.Visible = true;
                                    hplSitePlan.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + Convert.ToString(ds.Tables[1].Rows[i]["FILELOCATION"]);
                                    hplSitePlan.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                                }
                            }


                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnUpldAadhar_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupAadhar.HasFile)
                {
                    Error = validations(fupAadhar);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Aadhar" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupAadhar.PostedFile.SaveAs(serverpath + "\\" + fupAadhar.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupAadhar.PostedFile.SaveAs(serverpath + "\\" + fupAadhar.PostedFile.FileName);
                            }
                        }

                        CFEAttachments objAadhar = new CFEAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objAadhar.MasterID = "11";
                        objAadhar.FilePath = serverpath + fupAadhar.PostedFile.FileName;
                        objAadhar.FileName = fupAadhar.PostedFile.FileName;
                        objAadhar.FileType = fupAadhar.PostedFile.ContentType;
                        objAadhar.FileDescription = "Aadhar";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objAadhar);
                        if (result != "")
                        {
                            hplAadhar.Text = fupAadhar.PostedFile.FileName;
                            hplAadhar.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + serverpath + fupAadhar.PostedFile.FileName;
                            hplAadhar.Target = "blank";
                            message = "alert('" + "Aadhar Document Uploaded successfully" + "')";
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

        protected void btnUpldEPIC_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupEPIC.HasFile)
                {
                    Error = validations(fupEPIC);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "EPIC" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupEPIC.PostedFile.SaveAs(serverpath + "\\" + fupEPIC.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupEPIC.PostedFile.SaveAs(serverpath + "\\" + fupEPIC.PostedFile.FileName);
                            }
                        }

                        CFEAttachments objEPIC = new CFEAttachments();
                        objEPIC.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objEPIC.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objEPIC.MasterID = "12";
                        objEPIC.FilePath = serverpath + fupEPIC.PostedFile.FileName;
                        objEPIC.FileName = fupEPIC.PostedFile.FileName;
                        objEPIC.FileType = fupEPIC.PostedFile.ContentType;
                        objEPIC.FileDescription = "EPIC Document";
                        objEPIC.CreatedBy = hdnUserID.Value;
                        objEPIC.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objEPIC);
                        if (result != "")
                        {
                            hplEPIC.Text = fupEPIC.PostedFile.FileName;
                            hplEPIC.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + serverpath + fupEPIC.PostedFile.FileName;
                            hplEPIC.Target = "blank";
                            message = "alert('" + "EPIC Document Uploaded successfully" + "')";
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

        protected void btnUpldPhoto_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupApplPhoto.HasFile)
                {
                    Error = validations(fupApplPhoto);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Applicant Photo" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupApplPhoto.PostedFile.SaveAs(serverpath + "\\" + fupApplPhoto.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupApplPhoto.PostedFile.SaveAs(serverpath + "\\" + fupApplPhoto.PostedFile.FileName);
                            }
                        }


                        CFEAttachments objApplPhoto = new CFEAttachments();
                        objApplPhoto.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objApplPhoto.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objApplPhoto.MasterID = "13";
                        objApplPhoto.FilePath = serverpath + fupApplPhoto.PostedFile.FileName;
                        objApplPhoto.FileName = fupApplPhoto.PostedFile.FileName;
                        objApplPhoto.FileType = fupApplPhoto.PostedFile.ContentType;
                        objApplPhoto.FileDescription = "Applicant Photo";
                        objApplPhoto.CreatedBy = hdnUserID.Value;
                        objApplPhoto.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objApplPhoto);
                        if (result != "")
                        {
                            hplApplPhoto.Text = fupApplPhoto.PostedFile.FileName;
                            hplApplPhoto.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + serverpath + fupApplPhoto.PostedFile.FileName;
                            hplApplPhoto.Target = "blank";
                            message = "alert('" + "Applicant Photo Uploaded successfully" + "')";
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

        protected void btnUplLandDoc_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupLandDoc.HasFile)
                {
                    Error = validations(fupLandDoc);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Land Document" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupLandDoc.PostedFile.SaveAs(serverpath + "\\" + fupLandDoc.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupLandDoc.PostedFile.SaveAs(serverpath + "\\" + fupLandDoc.PostedFile.FileName);
                            }
                        }


                        CFEAttachments objLandDoc = new CFEAttachments();
                        objLandDoc.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objLandDoc.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objLandDoc.MasterID = "14";
                        objLandDoc.FilePath = serverpath + fupLandDoc.PostedFile.FileName;
                        objLandDoc.FileName = fupLandDoc.PostedFile.FileName;
                        objLandDoc.FileType = fupLandDoc.PostedFile.ContentType;
                        objLandDoc.FileDescription = "Land Document";
                        objLandDoc.CreatedBy = hdnUserID.Value;
                        objLandDoc.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objLandDoc);
                        if (result != "")
                        {
                            hplLandDoc.Text = fupLandDoc.PostedFile.FileName;
                            hplLandDoc.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + serverpath + fupLandDoc.PostedFile.FileName;
                            hplLandDoc.Target = "blank";
                            message = "alert('" + "Land Document Uploaded successfully" + "')";
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

        protected void btnUpldSitePlan_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupSitePlan.HasFile)
                {
                    Error = validations(fupSitePlan);
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
                            fupSitePlan.PostedFile.SaveAs(serverpath + "\\" + fupSitePlan.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupSitePlan.PostedFile.SaveAs(serverpath + "\\" + fupSitePlan.PostedFile.FileName);
                            }
                        }


                        CFEAttachments objSitePlan = new CFEAttachments();
                        objSitePlan.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objSitePlan.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objSitePlan.MasterID = "15";
                        objSitePlan.FilePath = serverpath + fupSitePlan.PostedFile.FileName;
                        objSitePlan.FileName = fupSitePlan.PostedFile.FileName;
                        objSitePlan.FileType = fupSitePlan.PostedFile.ContentType;
                        objSitePlan.FileDescription = "Site Plan";
                        objSitePlan.CreatedBy = hdnUserID.Value;
                        objSitePlan.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objSitePlan);
                        if (result != "")
                        {
                            hplSitePlan.Text = fupSitePlan.PostedFile.FileName;
                            hplSitePlan.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + serverpath + fupSitePlan.PostedFile.FileName;
                            hplSitePlan.Target = "blank";
                            message = "alert('" + "Site Plan Document Uploaded successfully" + "')";
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

                if (i == 2)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            { throw ex; }
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int slno = 1;

                if (string.IsNullOrEmpty(hplAadhar.Text) || hplAadhar.Text == "" || hplAadhar.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Upload Aadhar Document \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hplEPIC.Text) || hplEPIC.Text == "" || hplEPIC.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Upload EPIC Document \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hplApplPhoto.Text) || hplApplPhoto.Text == "" || hplApplPhoto.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Upload Photograpgh \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hplLandDoc.Text) || hplLandDoc.Text == "" || hplLandDoc.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Upload Land Document /Sale Deed  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hplSitePlan.Text) || hplSitePlan.Text == "" || hplSitePlan.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Upload Site Plan \\n";
                    slno = slno + 1;
                }
                if (errormsg == "")
                {
                    string message = "alert('" + "Attachments Details saved Successfully" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
                else
                {
                    string message = "alert('" + errormsg + "')";
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
        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/CFE/CFELabourDetails.aspx?Previous=" + "P");
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
                if (errormsg == "")
                    Response.Redirect("~/User/CFE/CFEPaymentPage.aspx");
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