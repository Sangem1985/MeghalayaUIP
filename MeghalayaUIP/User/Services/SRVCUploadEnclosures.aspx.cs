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
    public partial class SRVCUploadEnclosures : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        SVRCBAL objSrvcbal = new SVRCBAL();

        
        string SRVCQID, result, errormsg = "";
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
                    if (Convert.ToString(Session["SRVCQID"]) != "")
                    {
                        SRVCQID = Convert.ToString(Session["SRVCQID"]);
                    }
                    else
                    {
                        string newurl = "~/User/Services/SRVCUserDashboard.aspx";
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
                ds = objSrvcbal.GetSRVCUploadEnclosures(Convert.ToString(Session["SRVCQID"]), hdnUserID.Value);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["SRVCA_MASTERID"]) == 14) //Land Document /Sale Deed
                                {
                                    hypLandDoc.Visible = true;
                                    hypLandDoc.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[0].Rows[i]["SRVCA_FILEPATH"]));
                                    hypLandDoc.Text = Convert.ToString(ds.Tables[0].Rows[i]["SRVCA_FILENAME"]);
                                    txtLandDoc.Text = Convert.ToString(ds.Tables[0].Rows[i]["SRVCA_FILLREFNO"]);

                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["SRVCA_MASTERID"]) == 15) //Site Plan
                                {
                                    hypSitePlan.Visible = true;
                                    hypSitePlan.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[0].Rows[i]["SRVCA_FILEPATH"]));
                                    hypSitePlan.Text = Convert.ToString(ds.Tables[0].Rows[i]["SRVCA_FILENAME"]);
                                    txtSitePlan.Text = Convert.ToString(ds.Tables[0].Rows[i]["SRVCA_FILLREFNO"]);
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

        protected void btnLandDoc_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupLandDoc.HasFile)
                {
                    Error = validations(fupLandDoc);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["SRVCAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["SRVCQID"]) + "\\" + "Land Document" + "\\";
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

                        SRVCAttachments objLandDoc = new SRVCAttachments();
                        objLandDoc.UNITID = Convert.ToString(Session["SRVCUNITID"]); //Convert.ToString(Session["CFEUNITID"]);
                        objLandDoc.Questionnareid = Convert.ToString(Session["SRVCQID"]);  //Convert.ToString(Session["CFEQID"]);
                        objLandDoc.MasterID = "14";
                        objLandDoc.FilePath = serverpath + fupLandDoc.PostedFile.FileName;
                        objLandDoc.FileName = fupLandDoc.PostedFile.FileName;
                        objLandDoc.FileType = fupLandDoc.PostedFile.ContentType;
                        objLandDoc.FileDescription = "Land Document";
                        objLandDoc.CreatedBy = hdnUserID.Value;
                        objLandDoc.IPAddress = getclientIP();
                        objLandDoc.ReferenceNo = txtLandDoc.Text;
                        result = objSrvcbal.InsertSRVCAttachments(objLandDoc);
                        if (result != "")
                        {
                            hypLandDoc.Text = fupLandDoc.PostedFile.FileName;
                            hypLandDoc.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupLandDoc.PostedFile.FileName);
                            hypLandDoc.Target = "blank";
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

        protected void btnSitePlan_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupSitePlan.HasFile)
                {
                    Error = validations(fupSitePlan);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["SRVCAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["SRVCQID"]) + "\\" + "Site Plan / Plan Layout" + "\\";
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

                        SRVCAttachments objSitePlan = new SRVCAttachments();
                        objSitePlan.UNITID = Convert.ToString(Session["SRVCUNITID"]); //Convert.ToString(Session["CFEUNITID"]);
                        objSitePlan.Questionnareid = Convert.ToString(Session["SRVCQID"]);  //Convert.ToString(Session["CFEQID"]);
                        objSitePlan.MasterID = "15";
                        objSitePlan.FilePath = serverpath + fupSitePlan.PostedFile.FileName;
                        objSitePlan.FileName = fupSitePlan.PostedFile.FileName;
                        objSitePlan.FileType = fupSitePlan.PostedFile.ContentType;
                        objSitePlan.FileDescription = "Site Plan / Plan Layout";
                        objSitePlan.CreatedBy = hdnUserID.Value;
                        objSitePlan.IPAddress = getclientIP();
                        objSitePlan.ReferenceNo = txtSitePlan.Text;
                        result = objSrvcbal.InsertSRVCAttachments(objSitePlan);
                        if (result != "")
                        {
                            hypSitePlan.Text = fupSitePlan.PostedFile.FileName;
                            hypSitePlan.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupSitePlan.PostedFile.FileName);
                            hypSitePlan.Target = "blank";
                            message = "alert('" + "Site Plan / Plan Layout Document Uploaded successfully" + "')";
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

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                int slno = 1;

                if (string.IsNullOrEmpty(hypLandDoc.Text) || hypLandDoc.Text == "" || hypLandDoc.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Upload Land Document \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypLandDoc.Text) || hypLandDoc.Text == "" || hypLandDoc.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Upload Site Plan/Plan Layout Document \\n";
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

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/Services/CDWMDetails.aspx?Previous=" + "P");
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
                Response.Redirect("~/User/Services/SVRCPaymentPage.aspx?Next=" + "N");
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