﻿using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.RenewalBAL;
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

namespace MeghalayaUIP.User.Renewal
{
    public partial class RENBusinessLicenseDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        RenewalBAL objRenbal = new RenewalBAL();
        string Questionnaire, ErrorMsg = "", result;
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
                    //if (Convert.ToString(Session["RENUNITID"]) != "")
                    //{ UnitID = Convert.ToString(Session["RENUNITID"]); }
                    if (Convert.ToString(Session["RENQID"]) != "")
                    {
                        Questionnaire = Convert.ToString(Session["RENQID"]);
                        if (!IsPostBack)
                        {
                            GetAppliedorNot();
                        }
                    }
                    else
                    {
                        string newurl = "~/User/Renewal/RENUserDashboard.aspx";
                        Response.Redirect(newurl);
                    }
                

                    Page.MaintainScrollPositionOnPostBack = true;
                    Failure.Visible = false;
                    success.Visible = false;
                    //if (!IsPostBack)
                    //{
                    //    GetAppliedorNot();
                    //}
                }
            }
            catch(Exception ex)
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
                DataSet ds = new DataSet();

                ds = objRenbal.GetRenAppliedApprovalID(hdnUserID.Value, Convert.ToString(Session["RENQID"]), "2", "");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(ds.Tables[0].Rows[0]["RENDA_APPROVALID"]) == "77")
                    {
                        BindBusinessType();
                        Binddata();
                    }
                }
                else
                {
                    if (Request.QueryString.Count > 0)
                    {
                        if (Convert.ToString(Request.QueryString[0]) == "N")
                            Response.Redirect("~/User/Renewal/RENCinemaLicenseDetails.aspx?Next=" + "N");
                        else if (Convert.ToString(Request.QueryString[0]) == "P")
                            Response.Redirect("~/User/Renewal/RENLegalmetrologyDetails.aspx?Previous=" + "P");
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

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                ErrorMsg = validations();
                if (ErrorMsg == "")
                {
                    RenBusinessLicDetails ObjRenBusinessLic = new RenBusinessLicDetails();

                    ObjRenBusinessLic.Questionnariid = Convert.ToString(Session["RENQID"]);
                    ObjRenBusinessLic.CreatedBy = hdnUserID.Value;
                    ObjRenBusinessLic.IPAddress = getclientIP();

                    ObjRenBusinessLic.LICNO = txtLicNo.Text;
                    ObjRenBusinessLic.LICISSUEDT = txtLicIssue.Text;
                    ObjRenBusinessLic.LICVALID = txtLicValid.Text;
                    ObjRenBusinessLic.NAMEOFBUSINESS = txtNameBusiness.Text;
                    ObjRenBusinessLic.ESTOWNED = rblOwned.SelectedValue;
                    ObjRenBusinessLic.NAMEREPRESENTATIVE = txtIndividualName.Text;
                    ObjRenBusinessLic.MOBILENO = txtMobileNo.Text;
                    ObjRenBusinessLic.EMAILID = txtEmailId.Text;
                    ObjRenBusinessLic.ADDRESS = txtAddress.Text;
                    ObjRenBusinessLic.NATUREBUSINESS = ddlNature.SelectedValue;
                    ObjRenBusinessLic.TYPEOFEST = rblApplication.SelectedValue;

                    result = objRenbal.InsertRENBusinessLicDet(ObjRenBusinessLic);

                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "Business License Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    string message = "alert('" + ErrorMsg + "')";
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



        public string validations()
        {
            try
            {
                int slno = 1;
                List<TextBox> emptyTextboxes = FindEmptyTextboxes(divText);
                List<DropDownList> emptyDropdowns = FindEmptyDropdowns(divText);
                List<RadioButtonList> emptyRadioButtonLists = FindEmptyRadioButtonLists(divText);
                string errormsg = "";
                if (string.IsNullOrEmpty(txtLicNo.Text) || txtLicNo.Text == "" || txtLicNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter License Number\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLicIssue.Text) || txtLicIssue.Text == "" || txtLicIssue.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter License issue Date\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLicValid.Text) || txtLicValid.Text == "" || txtLicValid.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter License Valid upto\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNameBusiness.Text) || txtNameBusiness.Text == "" || txtNameBusiness.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name of the Shop/Business Establishment\\n";
                    slno = slno + 1;
                }
                if (rblOwned.SelectedIndex == -1 || rblOwned.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Whether Establishment is owned \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtIndividualName.Text) || txtIndividualName.Text == "" || txtIndividualName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name of the Individual\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtMobileNo.Text) || txtMobileNo.Text == "" || txtMobileNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Mobile number\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEmailId.Text) || txtEmailId.Text == "" || txtEmailId.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter EmailId\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAddress.Text) || txtAddress.Text == "" || txtAddress.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Address\\n";
                    slno = slno + 1;
                }
                if (ddlNature.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Enter Nature Business\\n";
                    slno = slno + 1;
                }
                if (rblApplication.SelectedIndex == -1 || rblApplication.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Type of Establishment \\n";
                    slno = slno + 1;
                }
                //if (string.IsNullOrEmpty(hypPhoto.Text) || hypPhoto.Text == "" || hypPhoto.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please upload Passport Size Photograph of Individual \\n";
                //    slno = slno + 1;
                //}

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
        public void Binddata()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objRenbal.GetRenBusinessLicDet(hdnUserID.Value, Questionnaire);
                if (ds.Tables[0].Rows.Count > 0)
                {
                   // ViewState["UnitID"] = Convert.ToString(ds.Tables[0].Rows[0]["RENBD_UNITID"]);
                    txtLicNo.Text = ds.Tables[0].Rows[0]["RENBD_LICNUMBER"].ToString();
                    txtLicIssue.Text = ds.Tables[0].Rows[0]["RENBD_LICISSUEDT"].ToString();
                    txtLicValid.Text = ds.Tables[0].Rows[0]["RENBD_LICVALID"].ToString();
                    txtNameBusiness.Text = ds.Tables[0].Rows[0]["RENBD_NAMEOFBUSINESS"].ToString();
                    rblOwned.SelectedValue = ds.Tables[0].Rows[0]["RENBD_ESTOWNED"].ToString();
                    txtIndividualName.Text = ds.Tables[0].Rows[0]["RENBD_NAMEREPRESENTATIVE"].ToString();
                    txtMobileNo.Text = ds.Tables[0].Rows[0]["RENBD_MOBILENO"].ToString();
                    txtEmailId.Text = ds.Tables[0].Rows[0]["RENBD_EMAILID"].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0]["RENBD_ADDRESS"].ToString();
                    ddlNature.SelectedValue = ds.Tables[0].Rows[0]["RENBD_NATUREBUSINESS"].ToString();


                    rblApplication.SelectedValue = ds.Tables[0].Rows[0]["RENBD_TYPEOFEST"].ToString();

                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public void BindBusinessType()
        {
            try
            {
                ddlNature.Items.Clear();
                List<MasterBusinessType> objBusinessTypeModel = new List<MasterBusinessType>();
                objBusinessTypeModel = mstrBAL.GetBusinessType();
                if (objBusinessTypeModel != null)
                {

                    ddlNature.DataSource = objBusinessTypeModel;
                    ddlNature.DataValueField = "BUSINESSTYPEID";
                    ddlNature.DataTextField = "BUSINESSTYPENAME";
                    ddlNature.DataBind();
                }
                else
                {
                    ddlNature.DataSource = null;
                    ddlNature.DataBind();
                }
                AddSelect(ddlNature);
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
        protected void btndpr_Click(object sender, EventArgs e)
        {
            try
            {

                string Error = ""; string message = "";
                if (fupPhoto.HasFile)
                {
                    Error = validations(fupPhoto);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["RENAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["RENQID"]) + "\\" + "Authorized Representative" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupPhoto.PostedFile.SaveAs(serverpath + "\\" + fupPhoto.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupPhoto.PostedFile.SaveAs(serverpath + "\\" + fupPhoto.PostedFile.FileName);
                            }
                        }


                        RenAttachments objRenAttachments = new RenAttachments();
                       // objRenAttachments.UNITID = Convert.ToString(Session["RENUNITID"]);
                        objRenAttachments.Questionnareid = Convert.ToString(Session["RENQID"]);
                        objRenAttachments.MasterID = "130";
                        objRenAttachments.FilePath = serverpath + fupPhoto.PostedFile.FileName;
                        objRenAttachments.FileName = fupPhoto.PostedFile.FileName;
                        objRenAttachments.FileType = fupPhoto.PostedFile.ContentType;
                        objRenAttachments.FileDescription = "Passport Size Photograph of Individual";
                        objRenAttachments.CreatedBy = hdnUserID.Value;
                        objRenAttachments.IPAddress = getclientIP();
                        result = objRenbal.InsertAttachmentsRenewal(objRenAttachments);
                        if (result != "")
                        {
                            hypPhoto.Text = fupPhoto.PostedFile.FileName;
                            hypPhoto.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objRenAttachments.FilePath);
                            hypPhoto.Target = "blank";
                            message = "alert('" + "Passport Size Photograph of Individual Uploaded successfully" + "')";
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

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                btnsave_Click(sender, e);
                if (ErrorMsg == "")
                    Response.Redirect("~/User/Renewal/RENCinemaLicenseDetails.aspx?Next=" + "N");
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
                Response.Redirect("~/User/Renewal/RENLegalmetrologyDetails.aspx?Previous=" + "P");
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
            {
                throw ex;
            }
        }

        protected void rblOwned_SelectedIndexChanged(object sender, EventArgs e)
        {
            rblOwned.BorderColor = System.Drawing.Color.White;
        }

        protected void rblApplication_SelectedIndexChanged(object sender, EventArgs e)
        {
            rblApplication.BorderColor = System.Drawing.Color.White;
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