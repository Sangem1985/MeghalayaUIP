using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.PreRegBAL;
using MeghalayaUIP.Common;
using System;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.IO;
using System.Text.RegularExpressions;
using System.Configuration;
using MeghalayaUIP.CommonClass;

namespace MeghalayaUIP.User.PreReg
{
    public partial class IndustryRegistrationQueryDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        PreRegBAL indstregBAL = new PreRegBAL();
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
                        string InvesterID = Request.QueryString[1].ToString();
                        //string Dept = Request.QueryString[2].ToString();
                        string QueryID = Request.QueryString[2].ToString();
                        BindData(UnitID, ObjUserInfo.Userid, QueryID);
                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }


        }
        public void BindData(string Unitid, string InvesterID, string Queryid)
        {
            try
            {
                DataSet ds = new DataSet();
                string Dept = Request.QueryString[2].ToString();
                ds = indstregBAL.GetIndustryRegistrationQueryDetails(Unitid, InvesterID, Queryid);
                if (ds.Tables.Count > 0)
                {
                    lblUnitId.Text = Convert.ToString(ds.Tables[0].Rows[0]["UNITID"]);
                    lblQueryID.Text = Convert.ToString(ds.Tables[0].Rows[0]["IMAQID"]);
                    lblinvesterID.Text = Convert.ToString(ds.Tables[0].Rows[0]["INVESTERID"]);
                    lbldeptID.Text = Convert.ToString(ds.Tables[0].Rows[0]["QUERYBY"]);
                    lblUnitName.Text = Convert.ToString(ds.Tables[0].Rows[0]["COMPANYNAME"]);
                    lblRmId.Text = Convert.ToString(ds.Tables[0].Rows[0]["PREREGUIDNO"]);
                    lblQueryRaised.Text = Convert.ToString(ds.Tables[0].Rows[0]["QUERYBY"]);
                    lblQueryRaisedDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["QUERYDATE"]);
                    lblQueryDescription.Text = Convert.ToString(ds.Tables[0].Rows[0]["QUERYRAISEDESC"]);
                    lblQueryBy.Text = Convert.ToString(ds.Tables[0].Rows[0]["QUERYBYDEPT"]);
                    //  btnAttach.Text = Convert.ToString(ds.Tables[0].Rows[0]["RESPONSEBYIP"]);
                }

            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }



        }

        protected void btnUpldAttachment_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblUnitId.Text != "")
                {
                    string Error = ""; string message = "";
                    string newPath = "";
                    string sFileDir = Server.MapPath("~\\PreRegAttachments");
                    if (fupAttachment.HasFile)
                    {
                        Error = validations(fupAttachment);
                        if (Error == "")
                        {
                            if ((fupAttachment.PostedFile != null) && (fupAttachment.PostedFile.ContentLength > 0))
                            {
                                string sFileName = System.IO.Path.GetFileName(fupAttachment.PostedFile.FileName);
                                try
                                {
                                    newPath = System.IO.Path.Combine(sFileDir, hdnUserID.Value, lblUnitId.Text + "\\RESPONSEATTACHMENTS");

                                    if (!Directory.Exists(newPath))
                                        System.IO.Directory.CreateDirectory(newPath);

                                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                                    fupAttachment.PostedFile.SaveAs(newPath + "\\" + sFileName);

                                    //int count = dir.GetFiles().Length;
                                    //if (count == 0)
                                    //    fupAttachment.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                    //else
                                    //{
                                    //    if (count == 1)
                                    //    {
                                    //        string[] Files = Directory.GetFiles(newPath);

                                    //        foreach (string file in Files)
                                    //        {
                                    //            File.Delete(file);
                                    //        }
                                    //        fupAttachment.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                    //    }
                                    //}

                                    IndustryDetails objattachments = new IndustryDetails();

                                    objattachments.UnitID = lblUnitId.Text;
                                    objattachments.UserID = hdnUserID.Value;
                                    objattachments.InvestorId = hdnUserID.Value;
                                    objattachments.FileType = fupAttachment.PostedFile.ContentType;
                                    objattachments.FileName = sFileName.ToString();
                                    objattachments.Filepath = newPath.ToString() + "\\" + sFileName;
                                    objattachments.FileDescription = "RESPONSE ATTACHMENT";
                                    objattachments.Deptid = "0";
                                    objattachments.ApprovalId = "0";
                                    objattachments.QueryID = lblQueryID.Text;
                                    objattachments.ResponseFileBy = "APPLICANT";

                                    int result = 0;
                                    result = indstregBAL.InsertAttachments_PREREG_RESPONSE(objattachments);

                                    if (result > 0)
                                    {
                                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                        hplAttachment.Text = fupAttachment.FileName;
                                        hplAttachment.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + objattachments.Filepath;
                                        success.Visible = true;
                                        Failure.Visible = false;
                                    }
                                    else
                                    {
                                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                                        success.Visible = false;
                                        Failure.Visible = true;
                                    }

                                }
                                catch (Exception)//in case of an error
                                {

                                    DeleteFile(newPath + "\\" + sFileName);
                                }
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
                        lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }
                }
                else
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "Some Internal Error Occured";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", lblmsg0.Text, true);
                    return;
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

                if (string.IsNullOrEmpty(txtQueryResponse.Text.Trim()) || txtQueryResponse.Text.Trim() == "" && txtQueryResponse.Text.Trim() == null)
                {
                    string message = "alert('" + "Please Enter Query Response" + "')";
                    txtQueryResponse.Focus();
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                else
                {
                    DataSet ds = new DataSet();

                    PreRegDtls PRE = new PreRegDtls();
                    if (Convert.ToString(ViewState["UnitID"]) != "")
                    { PRE.Unitid = Convert.ToString(ViewState["UnitID"]); }
                    PRE.Investerid = hdnUserID.Value;
                    PRE.IPAddress = getclientIP();
                    PRE.Unitid = lblUnitId.Text;
                    PRE.UserName = lblUnitName.Text;
                    PRE.QueryResponse = txtQueryResponse.Text;
                    //PRE.deptid = lbldept.Text;
                    PRE.QuerytoDeptID = lbldeptID.Text;
                    PRE.QuerytoDept = lblQueryDescription.Text;
                    PRE.QueryID = lblQueryID.Text;
                    string indus = indstregBAL.UpdateIndRegApplQueryRespose(PRE);

                    btnSubmit.Enabled = false;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", $"alert('Query Replied Successfully!');  window.location.href='IndustryRegistrationUserDashboard.aspx?UnitID={lblUnitId.Text}'", true);

                    return;
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

        public string validations(FileUpload Attachment)
        {
            try
            {
                string filesize = Convert.ToString(ConfigurationManager.AppSettings["FileSize"].ToString());
                int slno = 1; string Error = "";
                if (Attachment.PostedFile.ContentType != "application/pdf"
                     || !ValidateFileName(Attachment.PostedFile.FileName) || !ValidateFileExtension(Attachment))
                {

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


    }
}