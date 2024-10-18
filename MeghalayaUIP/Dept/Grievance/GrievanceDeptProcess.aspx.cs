using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.Dept.Grievance
{
    public partial class GrievanceDeptProcess : System.Web.UI.Page
    {
        DeptUserInfo ObjUserInfo = new DeptUserInfo();
        MGCommonBAL objcomBal = new MGCommonBAL();
        MasterBAL mstrBAL = new MasterBAL();
        string Reply_FilePath = "", Reply_FileType = "", Reply_FileName = "", ErrorMsg;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["DeptUserInfo"] != null)
                {
                    if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
                    {
                        ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
                    }
                    if (hdnUserID.Value == "")
                    {
                        hdnUserID.Value = ObjUserInfo.UserID;
                    }

                    Page.MaintainScrollPositionOnPostBack = true;
                    Failure.Visible = false;
                    success.Visible = false;
                    if (!IsPostBack)
                    {
                        if (Request.QueryString.Count > 0)
                        {
                            hdnGrvID.Value = Request.QueryString[0];
                            BindData(ObjUserInfo.Deptid);
                        }
                        else Response.Redirect("~/DeptLogin.aspx");

                    }
                }
                else
                {
                    Response.Redirect("~/DeptLogin.aspx");
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public void BindData(string DeptID)
        {
            try
            {
                DataSet ds = new DataSet();

                ds = objcomBal.GetDepGrievanceList(DeptID, Request.QueryString[0], null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblindustry.Text = Convert.ToString(ds.Tables[0].Rows[0]["UNITNAME"]);
                    lblEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["EMAIL"]);
                    lblUID.Text = Convert.ToString(ds.Tables[0].Rows[0]["UID_NO"]);
                    lblName.Text = Convert.ToString(ds.Tables[0].Rows[0]["APPLICANTNAME"]);
                    lblNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["MOBILE"]);
                    lblSubject.Text = Convert.ToString(ds.Tables[0].Rows[0]["SUBJECT"]);
                    lblDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["REGDATE"]);
                    lblDistric.Text = Convert.ToString(ds.Tables[0].Rows[0]["DistrictName"]);
                    lblDescription.Text = Convert.ToString(ds.Tables[0].Rows[0]["DESCRIPTION"]);
                    hplAttach.NavigateUrl = Convert.ToString(ds.Tables[0].Rows[0]["GRIEVANCE_FILEPATH"]);
                    hplAttach.Text = Convert.ToString(ds.Tables[0].Rows[0]["GRIEVNACE_FILENAME"]);

                }
                else
                {
                    lblmsg0.Text = "Some Internal Error Occured please try again";
                    Failure.Visible = true;
                }

            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int Result = 0;
                if (ddlProcess.SelectedItem.Text != "--Select--" && !string.IsNullOrEmpty(txtRemarks.Text) && txtRemarks.Text != ""
                    && txtRemarks.Text != null)
                {
                    string newPath = "";
                    string sFileDir = ConfigurationManager.AppSettings["GrievanceAttachments"];
                    if (fupReplyFile.HasFile)
                    {
                        ErrorMsg = validations(fupReplyFile);
                        if (ErrorMsg == "")
                        {
                            if ((fupReplyFile.PostedFile != null) && (fupReplyFile.PostedFile.ContentLength > 0))
                            {
                                string sFileName = System.IO.Path.GetFileName(fupReplyFile.PostedFile.FileName);
                                try
                                {

                                    string[] fileType = fupReplyFile.PostedFile.FileName.Split('.');
                                    int i = fileType.Length;
                                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" ||
                                        fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" ||
                                        fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" ||
                                        fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" ||
                                        fileType[i - 1].ToUpper().Trim() == "DWG")
                                    {

                                        newPath = System.IO.Path.Combine(sFileDir, hdnGrvID.Value + hdnUserID.Value);
                                        Reply_FilePath = newPath + System.DateTime.Now.ToString("ddMMyyyyhhmmss");
                                        Reply_FileType = fileType[i - 1].ToUpper().Trim();
                                        Reply_FileName = sFileName;
                                        //////////////
                                        // FileNameofrMail = Reply_FilePath + "\\" + Reply_FileType;
                                        if (!Directory.Exists(Reply_FilePath))

                                            System.IO.Directory.CreateDirectory(Reply_FilePath);
                                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(Reply_FilePath);
                                        int count = dir.GetFiles().Length;
                                        if (count == 0)
                                            fupReplyFile.PostedFile.SaveAs(Reply_FilePath + "\\" + Reply_FileName);
                                        else
                                        {
                                            if (count == 1)
                                            {
                                                string[] Files = Directory.GetFiles(Reply_FilePath);

                                                foreach (string file in Files)
                                                {
                                                    File.Delete(file);
                                                }
                                                fupReplyFile.PostedFile.SaveAs(Reply_FilePath + "\\" + Reply_FileName);
                                            }
                                        }

                                    }
                                    else
                                    {
                                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                                        //success.Visible = false;
                                        Failure.Visible = true;
                                    }

                                }
                                catch (Exception)//in case of an error
                                {
                                    DeleteFile(newPath + "\\" + sFileName);
                                }
                            }
                        }
                    }


                    Result = objcomBal.UpdateGrievanceDeptProcess(ddlProcess.SelectedItem.Text, ddlProcess.SelectedValue, txtRemarks.Text,
                        Reply_FilePath, Reply_FileType, Reply_FileName, hdnGrvID.Value, hdnUserID.Value,
                        Convert.ToString(ObjUserInfo.Deptid), getclientIP());
                    if (Result != 0)
                    {
                        lblmsg.Text = "Details Submited Successfully..!";
                        success.Visible = true;
                        string message = "alert('" + lblmsg.Text + "')";
                        //ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Submitted Successfully!');  window.location.href='GrievanceDeptDashbord.aspx'", true);

                    }
                    else
                    {
                        lblmsg0.Text = "Error Occured, Please try again!";
                        Failure.Visible = false;
                    }
                }
                else
                {
                    string ErrorMsg = "";
                    if (ddlProcess.SelectedItem.Text == "--Select--")
                        ErrorMsg = "Please Select Process \\n ";

                    if (string.IsNullOrEmpty(txtRemarks.Text) || txtRemarks.Text == "" || txtRemarks.Text == null)
                        ErrorMsg = ErrorMsg+"Please Enter Remarks";

                    string message = "alert('" + ErrorMsg + "')";
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
        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Dept/Grievance/GrievanceDeptView.aspx");
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
                    Error = Error + slno + ". Invalid File type \\n";
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
    }
}