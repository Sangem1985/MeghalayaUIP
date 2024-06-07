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

namespace MeghalayaUIP.User.CFE
{
    public partial class CFEUploadEnclosures : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFEBAL objcfebal = new CFEBAL();

        string UnitID, result;
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
                                if (Convert.ToInt32(ds.Tables[1].Rows[i]["CFEA_MASTERAID"]) == 1)//Aadhar
                                {
                                    hplAadhar.Visible = true;
                                    hplAadhar.NavigateUrl = Convert.ToString(ds.Tables[1].Rows[i]["FILELOCATION"]);
                                    hplAadhar.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                                }
                            }

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
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
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Aadhar" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupAadhar.PostedFile.SaveAs(serverpath + "\\" + fupAadhar.PostedFile.FileName);

                        CFEAttachments objAadhar = new CFEAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objAadhar.MasterID = "1";
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
                            hplAadhar.NavigateUrl = serverpath;
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }

        }
        public string validations(FileUpload Attachment)
        {
            try
            {
                int slno = 1; string Error = "";
                if (Attachment.PostedFile.ContentType != "application/pdf"
                     || !ValidateFileName(Attachment.PostedFile.FileName) || !ValidateFileExtension(Attachment))
                {

                    if (Attachment.PostedFile.ContentType != "application/pdf")
                    {
                        Error = Error + slno + ". Please Upload PDF Documents only \\n";
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
                }
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
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "EPIC" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupEPIC.PostedFile.SaveAs(serverpath + "\\" + fupEPIC.PostedFile.FileName);

                        CFEAttachments objEPIC = new CFEAttachments();
                        objEPIC.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objEPIC.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objEPIC.MasterID = "2";
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
                            hplEPIC.NavigateUrl = serverpath;
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
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
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Applicant Photo" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupApplPhoto.PostedFile.SaveAs(serverpath + "\\" + fupApplPhoto.PostedFile.FileName);

                        CFEAttachments objApplPhoto = new CFEAttachments();
                        objApplPhoto.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objApplPhoto.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objApplPhoto.MasterID = "3";
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
                            hplApplPhoto.NavigateUrl = serverpath;
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
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
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Land Document" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupLandDoc.PostedFile.SaveAs(serverpath + "\\" + fupLandDoc.PostedFile.FileName);

                        CFEAttachments objLandDoc = new CFEAttachments();
                        objLandDoc.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objLandDoc.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objLandDoc.MasterID = "4";
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
                            hplLandDoc.NavigateUrl = serverpath;
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
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
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                        + Convert.ToString(Session["CFEQID"]) + "\\" + "Site Plan" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupSitePlan.PostedFile.SaveAs(serverpath + "\\" + fupSitePlan.PostedFile.FileName);

                        CFEAttachments objSitePlan = new CFEAttachments();
                        objSitePlan.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objSitePlan.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objSitePlan.MasterID = "1";
                        objSitePlan.FilePath = serverpath + fupSitePlan.PostedFile.FileName;
                        objSitePlan.FileName = fupSitePlan.PostedFile.FileName;
                        objSitePlan.FileType = fupSitePlan.PostedFile.ContentType;
                        objSitePlan.FileDescription = "Aadhar";
                        objSitePlan.CreatedBy = hdnUserID.Value;
                        objSitePlan.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objSitePlan);
                        if (result != "")
                        {
                            hplSitePlan.Text = fupSitePlan.PostedFile.FileName;
                            hplSitePlan.NavigateUrl = serverpath;
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int slno = 1;
                string errormsg = "";
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

                }
                else 
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
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
            }

        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/CFE/CFEPaymentPage.aspx");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }

        }
    }
}