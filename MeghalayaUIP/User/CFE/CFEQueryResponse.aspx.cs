using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFE
{
    public partial class CFEQueryResponse : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFEBAL objcfebal = new CFEBAL();
        string Unitid, result, Questionnareid;
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
                        string UnitID = Request.QueryString[0].ToString();
                        string QueryID = Request.QueryString[1].ToString();

                        if (UnitID != "" && QueryID != "")
                        {
                            BindData(UnitID, QueryID);
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
        public void BindData(string Unitid, string QueryID)
        {
            try
            {
                DataSet ds = new DataSet();
                string Dept = Request.QueryString[0].ToString();
                ds = objcfebal.GetCFEQueryDashBoard(Unitid, QueryID);
                if (ds.Tables.Count > 0)
                {
                    lblUnitName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQD_COMPANYNAME"]);
                    lblApprovalName.Text = Convert.ToString(ds.Tables[0].Rows[0]["ApprovalName"]);
                    lblQueryBy.Text = Convert.ToString(ds.Tables[0].Rows[0]["QUERYBY"]);
                    lblQueryRaisedDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["QUERYDATE"]);
                    lblQueryDescription.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQ_QUERYRAISEDESC"]);

                    lblUnitId.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQ_CFEUNITID"]);
                    lblQuesID.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQ_CFEQDID"]);
                    lblQryid.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQID"]);
                    lblDeptID.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQ_DEPTID"]);
                    lblApprovalID.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEQ_APPROVALID"]);

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
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "RESPONSEATTACHMNETS" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupAttachment.PostedFile.SaveAs(serverpath + "\\" + fupAttachment.PostedFile.FileName);

                        CFEAttachments objAadhar = new CFEAttachments();
                        objAadhar.UNITID = lblUnitId.Text;
                        objAadhar.Questionnareid = lblQuesID.Text;
                        objAadhar.MasterID = "";
                        objAadhar.QueryID=lblQryid.Text;
                        objAadhar.FilePath = serverpath + fupAttachment.PostedFile.FileName;
                        objAadhar.FileName = fupAttachment.PostedFile.FileName;
                        objAadhar.FileType = fupAttachment.PostedFile.ContentType;
                        objAadhar.FileDescription = "RESPONSE ATTACHMENT";
                        objAadhar.DeptID = "0";
                        objAadhar.ApprovalID = "0";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objAadhar);
                        if (result != "")
                        {
                            hplAttachment.Text = fupAttachment.PostedFile.FileName;
                            hplAttachment.NavigateUrl = serverpath;
                            hplAttachment.Target = "blank";
                            message = "alert('" + "CFEQUERYRESPONSE Uploaded successfully" + "')";
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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                CFEQueryDet CFEQuery = new CFEQueryDet();

                CFEQuery.Unitid = lblUnitId.Text;
                CFEQuery.Deptid = lblDeptID.Text;
                CFEQuery.Approvalid = lblApprovalID.Text;
                CFEQuery.QueryID = lblQryid.Text;
                CFEQuery.Investerid = hdnUserID.Value;
                CFEQuery.IPAddress = getclientIP();
                CFEQuery.QueryResponse = txtQueryResponse.Text;
                CFEQuery.Questionarieid = lblQuesID.Text;

                result = objcfebal.InsertCFEQueryResponse(CFEQuery);

                btnSubmit.Enabled = false;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", $"alert('Query Replied Successfully!');  window.location.href='CFEQueryDashboard.aspx?UnitID={lblUnitId.Text}'", true);
                return;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
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