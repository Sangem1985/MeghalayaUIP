using MeghalayaUIP.BAL.CommonBAL;
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
    public partial class RENCinemaLicenseDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        RenewalBAL objRenbal = new RenewalBAL();
        string UnitID, ErrorMsg = "", result;
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
                    if (Convert.ToString(Session["RENUNITID"]) != "")
                    { UnitID = Convert.ToString(Session["RENUNITID"]); }
                    else
                    {
                        string newurl = "~/User/Renewal/RENUserDashboard.aspx";
                        Response.Redirect(newurl);
                    }
                    //Session["UNITID"] = "1001";
                    //UnitID = Convert.ToString(Session["UNITID"]);

                    Page.MaintainScrollPositionOnPostBack = true;
                    Failure.Visible = false;
                    success.Visible = false;
                    if (!IsPostBack)
                    {
                        GetAppliedorNot();
                    }
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

                ds = objRenbal.GetRenAppliedApprovalID(hdnUserID.Value, Convert.ToString(Session["RENUNITID"]), Convert.ToString(Session["RENQID"]), "13", "");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(ds.Tables[0].Rows[0]["RENDA_APPROVALID"]) == "78")
                    {
                        BindDistricts();
                        Binddata();
                    }
                }
                else
                {
                    if (Request.QueryString.Count > 0)
                    {
                        if (Convert.ToString(Request.QueryString[0]) == "N")
                            Response.Redirect("~/User/Renewal/RENContractRegistationDetails.aspx?Next=" + "N");
                        else if (Convert.ToString(Request.QueryString[0]) == "P")
                            Response.Redirect("~/User/Renewal/RENBusinessLicenseDetails.aspx?Previous=" + "P");
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
        protected void BindDistricts()
        {
            try
            {

                ddlDistrict.Items.Clear();
                ddlMandal.Items.Clear();
                ddlVillage.Items.Clear();

                List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();
                string strmode = string.Empty;
                //if (ObjUserInformation.User_Level == "2")
                //{
                strmode = "";
                //}
                objDistrictModel = mstrBAL.GetDistrcits();
                if (objDistrictModel != null)
                {
                    ddlDistrict.DataSource = objDistrictModel;
                    ddlDistrict.DataValueField = "DistrictId";
                    ddlDistrict.DataTextField = "DistrictName";
                    ddlDistrict.DataBind();


                }
                else
                {
                    ddlDistrict.DataSource = null;
                    ddlDistrict.DataBind();


                }
                AddSelect(ddlDistrict);
                AddSelect(ddlMandal);
                AddSelect(ddlVillage);

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindMandal(DropDownList ddlmndl, string DistrictID)
        {
            try
            {
                List<MasterMandals> objMandal = mstrBAL.GetMandals(DistrictID);

                if (objMandal != null && objMandal.Count > 0)
                {
                    ddlmndl.DataSource = objMandal;
                    ddlmndl.DataValueField = "MandalId";
                    ddlmndl.DataTextField = "MandalName";
                    ddlmndl.DataBind();
                }
                else
                {

                    ddlmndl.DataSource = null;
                    ddlmndl.DataBind();
                }

                AddSelect(ddlmndl);
            }
            catch (Exception ex)
            {

                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }
        protected void BindVillages(DropDownList ddlvlg, string MandalID)
        {
            try
            {
                List<MasterVillages> objVillage = new List<MasterVillages>();
                string strmode = string.Empty;

                objVillage = mstrBAL.GetVillages(MandalID);

                if (objVillage != null)
                {
                    ddlvlg.DataSource = objVillage;
                    ddlvlg.DataValueField = "VillageId";
                    ddlvlg.DataTextField = "VillageName";
                    ddlvlg.DataBind();
                }
                else
                {
                    ddlvlg.DataSource = null;
                    ddlvlg.DataBind();
                }
                AddSelect(ddlvlg);
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

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlMandal.ClearSelection();
                ddlVillage.ClearSelection();
                if (ddlDistrict.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlMandal, ddlDistrict.SelectedValue);
                }
                else return;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlVillage.ClearSelection();
                if (ddlMandal.SelectedItem.Text != "--Select--")
                {

                    BindVillages(ddlVillage, ddlMandal.SelectedValue);
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
          //  string Quesstionriids = "1001";
            try
            {
                string result = "";
                ErrorMsg = validations();
                if (ErrorMsg == "")
                {
                    RenCinemaLicDetails ObjRenCinemaLicDet = new RenCinemaLicDetails();

                    ObjRenCinemaLicDet.Questionnariid = Convert.ToString(Session["RENQID"]); 
                    ObjRenCinemaLicDet.CreatedBy = hdnUserID.Value;
                    ObjRenCinemaLicDet.UnitId = Convert.ToString(Session["RENUNITID"]);
                    ObjRenCinemaLicDet.IPAddress = getclientIP();

                    ObjRenCinemaLicDet.OLDREGNO = txtOldRegNumber.Text;
                    ObjRenCinemaLicDet.REGDATE = txtRegDate.Text;
                    ObjRenCinemaLicDet.NAMEESTCINEMA = txtEstName.Text;
                    ObjRenCinemaLicDet.NOCISSUEDATE = txtIssuedDate.Text;
                    ObjRenCinemaLicDet.NUMBERSEAT = txtNumberseats.Text;
                    ObjRenCinemaLicDet.CINEMATOGRAPHY = txtCinematography.Text;
                    ObjRenCinemaLicDet.BUSINESSTYPE = rblBusinesstype.SelectedValue;
                    ObjRenCinemaLicDet.NAMEPARTNER = txtProprietorname.Text;
                    ObjRenCinemaLicDet.GSTNO = txtGstinno.Text;
                    ObjRenCinemaLicDet.OWNERSHIP = rblOwned.SelectedValue;
                    ObjRenCinemaLicDet.DISTRIC = ddlDistrict.SelectedValue;
                    ObjRenCinemaLicDet.MANDAL = ddlMandal.SelectedValue;
                    ObjRenCinemaLicDet.VILLAGE = ddlVillage.SelectedValue;
                    ObjRenCinemaLicDet.LOCALITY = txtLocality.Text;
                    ObjRenCinemaLicDet.LANDMARK = txtLandmark.Text;
                    ObjRenCinemaLicDet.Pincode = txtPincode.Text;

                    result = objRenbal.InsertRENCinemaLicDet(ObjRenCinemaLicDet);

                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "Cinema License Details Submitted Successfully";
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
        public string validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                if (string.IsNullOrEmpty(txtOldRegNumber.Text) || txtOldRegNumber.Text == "" || txtOldRegNumber.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Old Registration Number\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtRegDate.Text) || txtRegDate.Text == "" || txtRegDate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Registration Date\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEstName.Text) || txtEstName.Text == "" || txtEstName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name OF Establishment Cinema \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtIssuedDate.Text) || txtIssuedDate.Text == "" || txtIssuedDate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Issue Date \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNumberseats.Text) || txtNumberseats.Text == "" || txtNumberseats.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Number OF Seat \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtCinematography.Text) || txtCinematography.Text == "" || txtCinematography.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter cinematography equipment's \\n";
                    slno = slno + 1;
                }
                if (rblBusinesstype.SelectedIndex == -1 || rblBusinesstype.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Type of Business\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtProprietorname.Text) || txtProprietorname.Text == "" || txtProprietorname.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name of the Proprietor \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtGstinno.Text) || txtGstinno.Text == "" || txtGstinno.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter GSTIN number of Business \\n";
                    slno = slno + 1;
                }
                if (rblOwned.SelectedIndex == -1 || rblOwned.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Ownership of Premises\\n";
                    slno = slno + 1;
                }
                if (ddlDistrict.SelectedIndex == -1 || ddlDistrict.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Distric\\n";
                    slno = slno + 1;
                }
                if (ddlMandal.SelectedIndex == -1 || ddlMandal.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Mandal\\n";
                    slno = slno + 1;
                }
                if (ddlVillage.SelectedIndex == -1 || ddlVillage.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Village\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLocality.Text) || txtLocality.Text == "" || txtLocality.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Locality \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLandmark.Text) || txtLandmark.Text == "" || txtLandmark.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Landmark \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPincode.Text) || txtPincode.Text == "" || txtPincode.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Pincode \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypDirector.Text) || hypDirector.Text == "" || hypDirector.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Photograph of the Proprietor/ Managing Partner...! \\n";
                    slno = slno + 1;
                }
                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
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
        public void Binddata()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objRenbal.GetRenCinemaLicDetails(hdnUserID.Value, UnitID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["UnitID"] = Convert.ToString(ds.Tables[0].Rows[0]["RENCD_UNITID"]);
                    txtOldRegNumber.Text = ds.Tables[0].Rows[0]["RENCD_OLDREGNO"].ToString();
                    txtRegDate.Text = ds.Tables[0].Rows[0]["RENCD_REGDATE"].ToString();
                    txtEstName.Text = ds.Tables[0].Rows[0]["RENCD_NAMEESTCINEMA"].ToString();
                    txtIssuedDate.Text = ds.Tables[0].Rows[0]["RENCD_NOCISSUEDATE"].ToString();
                    txtNumberseats.Text = ds.Tables[0].Rows[0]["RENCD_NUMBERSEAT"].ToString();
                    txtCinematography.Text = ds.Tables[0].Rows[0]["RENCD_CINEMATOGRAPHY"].ToString();
                    rblBusinesstype.SelectedValue = ds.Tables[0].Rows[0]["RENCD_BUSINESSTYPE"].ToString();
                    txtProprietorname.Text = ds.Tables[0].Rows[0]["RENCD_NAMEPARTNER"].ToString();
                    txtGstinno.Text = ds.Tables[0].Rows[0]["RENCD_GSTNO"].ToString();
                    rblOwned.SelectedValue = ds.Tables[0].Rows[0]["RENCD_OWNERSHIP"].ToString();
                    ddlDistrict.SelectedValue = ds.Tables[0].Rows[0]["RENCD_DISTRIC"].ToString();
                    ddlDistrict_SelectedIndexChanged(null, EventArgs.Empty);
                    ddlMandal.SelectedValue = ds.Tables[0].Rows[0]["RENCD_MANDAL"].ToString();
                    ddlMandal_SelectedIndexChanged(null, EventArgs.Empty);
                    ddlVillage.SelectedValue = ds.Tables[0].Rows[0]["RENCD_VILLAGE"].ToString();
                    txtLocality.Text = ds.Tables[0].Rows[0]["RENCD_LOCALITY"].ToString();
                    txtLandmark.Text = ds.Tables[0].Rows[0]["RENCD_LANDMARK"].ToString();
                    txtPincode.Text = ds.Tables[0].Rows[0]["RENCD_PINCODE"].ToString();

                }
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
                if (fupDirector.HasFile)
                {
                    Error = validations(fupDirector);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["RENAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["RENQID"]) + "\\" + "Managing Director" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupDirector.PostedFile.SaveAs(serverpath + "\\" + fupDirector.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupDirector.PostedFile.SaveAs(serverpath + "\\" + fupDirector.PostedFile.FileName);
                            }
                        }


                        RenAttachments objRenAttachments = new RenAttachments();
                        objRenAttachments.UNITID = Convert.ToString(Session["RENUNITID"]);
                        objRenAttachments.Questionnareid = Convert.ToString(Session["RENQID"]);
                        objRenAttachments.MasterID = "131";
                        objRenAttachments.FilePath = serverpath + fupDirector.PostedFile.FileName;
                        objRenAttachments.FileName = fupDirector.PostedFile.FileName;
                        objRenAttachments.FileType = fupDirector.PostedFile.ContentType;
                        objRenAttachments.FileDescription = "Photograph of the Proprietor/ Managing Partner";
                        objRenAttachments.CreatedBy = hdnUserID.Value;
                        objRenAttachments.IPAddress = getclientIP();
                        result = objRenbal.InsertAttachmentsRenewal(objRenAttachments);
                        if (result != "")
                        {
                            hypDirector.Text = fupDirector.PostedFile.FileName;
                            hypDirector.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objRenAttachments.FilePath);
                            hypDirector.Target = "blank";
                            message = "alert('" + "Photograph of the Proprietor/ Managing Partner Uploaded successfully" + "')";
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
                    Response.Redirect("~/User/Renewal/RENContractRegistationDetails.aspx?Next=" + "N");
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
                Response.Redirect("~/User/Renewal/RENBusinessLicenseDetails.aspx?Previous=" + "P");
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