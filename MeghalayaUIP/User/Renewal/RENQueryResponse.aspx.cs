using MeghalayaUIP.BAL.RenewalBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Services.Description;


namespace MeghalayaUIP.User.Renewal
{
    public partial class RENQueryResponse : System.Web.UI.Page
    {
        RenewalBAL objrenbal = new RenewalBAL();
        string RENQID, result;
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

                    if (!IsPostBack)
                    {
                        string RENQID = Request.QueryString[0].ToString();
                        string QueryID = Request.QueryString[1].ToString();

                        if (RENQID != "" && QueryID != "")
                        {
                            BindData(RENQID, QueryID);
                        }
                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public void BindData(string RENQID, string QueryID)
        {
            try
            {
                DataSet ds = new DataSet();
                string Dept = Request.QueryString[0].ToString();
                ds = objrenbal.GetRENQueryDashBoard(RENQID, QueryID);
                if (ds.Tables.Count > 0)
                {
                    lblUnitName.Text = Convert.ToString(ds.Tables[0].Rows[0]["RENID_NAMEOFUNIT"]);
                    lblApprovalName.Text = Convert.ToString(ds.Tables[0].Rows[0]["ApprovalName"]);
                    lblQueryBy.Text = Convert.ToString(ds.Tables[0].Rows[0]["QUERYBY"]);
                    lblQueryRaisedDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["QUERYDATE"]);
                    lblQueryDescription.Text = Convert.ToString(ds.Tables[0].Rows[0]["RENQ_QUERYRAISEDESC"]);
                    lblApplicationID.Text = Convert.ToString(ds.Tables[0].Rows[0]["RENID_UIDNO"]);

                    // lblRENQid.Text = Convert.ToString(ds.Tables[0].Rows[0]["RENID_RENQDID"]);
                    lblQuesID.Text = Convert.ToString(ds.Tables[0].Rows[0]["RENID_RENQDID"]);
                    lblQryid.Text = Convert.ToString(ds.Tables[0].Rows[0]["RENQID"]);
                    lblDeptID.Text = Convert.ToString(ds.Tables[0].Rows[0]["RENQ_DEPTID"]);
                    lblApprovalID.Text = Convert.ToString(ds.Tables[0].Rows[0]["RENQ_APPROVALID"]);

                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }
        protected void btnUpldAttachment_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupAttachment.HasFile)
                {
                    Error = validations(fupAttachment);
                    if (Error == "")
                    {
                        string sFileDir = System.Configuration.ConfigurationManager.AppSettings["RENAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(lblQuesID.Text) + "\\" + "RESPONSEATTACHMNETS" + "\\" + lblDeptID.Text + "\\" + lblApprovalID.Text + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupAttachment.PostedFile.SaveAs(serverpath + "\\" + fupAttachment.PostedFile.FileName);

                        RenAttachments objRenAttachments = new RenAttachments();
                        //objRenAttachments.UNITID = lblUnitId.Text;
                        objRenAttachments.Questionnareid = lblQuesID.Text;
                        objRenAttachments.MasterID = "";
                        objRenAttachments.QueryID = lblQryid.Text;
                        objRenAttachments.FilePath = serverpath + fupAttachment.PostedFile.FileName;
                        objRenAttachments.FileName = fupAttachment.PostedFile.FileName;
                        objRenAttachments.FileType = fupAttachment.PostedFile.ContentType;
                        objRenAttachments.FileDescription = "RESPONSE ATTACHMENT";
                        objRenAttachments.DeptID = lblDeptID.Text;
                        objRenAttachments.ApprovalID = lblApprovalID.Text;
                        objRenAttachments.CreatedBy = hdnUserID.Value;
                        objRenAttachments.IPAddress = getclientIP();
                        result = objrenbal.InsertAttachmentsRenewal(objRenAttachments);
                        if (result != "")
                        {
                            hplAttachment.Text = fupAttachment.PostedFile.FileName;
                            hplAttachment.NavigateUrl = serverpath;
                            hplAttachment.Target = "blank";
                            message = "alert('" + "Document Uploaded successfully" + "')";
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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtQueryResponse.Text.Trim() != "")
                {
                    RENQueryDet RENQuery = new RENQueryDet();

                    //  CFEQuery.Unitid = lblUnitId.Text;
                    RENQuery.Deptid = lblDeptID.Text;
                    RENQuery.Approvalid = lblApprovalID.Text;
                    RENQuery.QueryID = lblQryid.Text;
                    RENQuery.Investerid = hdnUserID.Value;
                    RENQuery.IPAddress = getclientIP();
                    RENQuery.QueryResponse = txtQueryResponse.Text;
                    RENQuery.Questionarieid = lblQuesID.Text;

                    result = objrenbal.InsertRENQueryResponse(RENQuery); // PROCEDURE USP_UPDATERENAPPLQUERYRESPONSE

                    btnSubmit.Enabled = false;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", $"alert('Query Replied Successfully!');  window.location.href='RENUserDashboard.aspx?RENID_RENQDID={lblRENQid.Text}'", true);
                    return;
                }
                else
                {
                    string message = "alert('" + "Please enter Query Response " + "')";
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
    }
}