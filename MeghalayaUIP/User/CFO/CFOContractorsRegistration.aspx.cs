using MeghalayaUIP.BAL.CFOBAL;
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

namespace MeghalayaUIP.User.CFO
{
    public partial class CFOContractorsRegistration : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFOBAL objcfobal = new CFOBAL();
        string UnitID, ErrorMsg = "", result = "";
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
                    if (Convert.ToString(Session["CFOUNITID"]) != "")
                    { UnitID = Convert.ToString(Session["CFOUNITID"]); }
                    else
                    {
                        string newurl = "~/User/CFO/CFOUserDashboard.aspx";
                        Response.Redirect(newurl);
                    }
                    Page.MaintainScrollPositionOnPostBack = true;
                    Failure.Visible = false;
                    success.Visible = false;
                    if (!IsPostBack)
                    {
                        DataSet dsnew = new DataSet();
                        dsnew = objcfobal.GetApprovalDataByDeptId(Session["CFOQID"].ToString(), Session["CFOUNITID"].ToString(), "16");
                        if (dsnew.Tables[0].Rows.Count > 0)
                        {

                        }
                        else
                        {
                            if (Request.QueryString[0].ToString() == "N")
                            {
                                Response.Redirect("~/User/CFO/CFODrugLicenseDetails.aspx?next=N");
                            }
                            else
                            {
                                Response.Redirect("~/User/CFO/CFOLegalMeterology.aspx?Previous=P");
                            }
                        }
                        Binddata();
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
        public void Binddata()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfobal.GetCFOContractors(hdnUserID.Value, UnitID);

                if (ds.Tables[1].Rows.Count > 0)
                {
                    ViewState["UnitID"] = Convert.ToString(ds.Tables[1].Rows[0]["CFOWC_UNITID"]);
                    rblPurApplication.SelectedValue = ds.Tables[1].Rows[0]["CFOWC_APPLPURPOSE"].ToString();
                    rblRegister.SelectedValue = ds.Tables[1].Rows[0]["CFOWC_CONTRREGCLASS"].ToString();
                    if (rblRegister.SelectedValue == "1")
                        director.Visible = true;
                    else director.Visible = false;
                    ddlDirector.SelectedValue = ds.Tables[1].Rows[0]["CFOWC_DIRECTORATE"].ToString();
                    if (rblRegister.SelectedValue == "2")
                        circle.Visible = true;
                    else circle.Visible = false;
                    ddlCircle.SelectedValue = ds.Tables[1].Rows[0]["CFOWC_CIRCLE"].ToString();
                    if (rblRegister.SelectedValue == "3")
                        division.Visible = true;
                    else division.Visible = false;
                    ddlDivision.SelectedValue = ds.Tables[1].Rows[0]["CFOWC_DIVISION"].ToString();
                    txtNameBank.Text = ds.Tables[1].Rows[0]["CFOWC_CONTRBANKNAME"].ToString();
                    txtTurnOver.Text = ds.Tables[1].Rows[0]["CFOWC_CONTRTURNOVER"].ToString();
                    txtFinancial.Text = ds.Tables[1].Rows[0]["CFOWC_CONTR3YRSTURNOVER"].ToString();
                    txtContractor.Text = ds.Tables[1].Rows[0]["CFOWC_CONTRSTARTDATE"].ToString();
                }

                if (ds.Tables[2].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                    {
                        if (Convert.ToInt32(ds.Tables[2].Rows[i]["CFOA_MASTERAID"]) == 61)
                        {
                            hypTaxClearance.Visible = true;
                            hypTaxClearance.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[2].Rows[i]["FILELOCATION"]));
                            hypTaxClearance.Text = Convert.ToString(ds.Tables[2].Rows[i]["CFOA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[2].Rows[i]["CFOA_MASTERAID"]) == 62)
                        {
                            hypGSTREG.Visible = true;
                            hypGSTREG.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[2].Rows[i]["FILELOCATION"]));
                            hypGSTREG.Text = Convert.ToString(ds.Tables[2].Rows[i]["CFOA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[2].Rows[i]["CFOA_MASTERAID"]) == 63)
                        {
                            hypLabourLic.Visible = true;
                            hypLabourLic.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[2].Rows[i]["FILELOCATION"]));
                            hypLabourLic.Text = Convert.ToString(ds.Tables[2].Rows[i]["CFOA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[2].Rows[i]["CFOA_MASTERAID"]) == 64)
                        {
                            hypTribals.Visible = true;
                            hypTribals.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[2].Rows[i]["FILELOCATION"]));
                            hypTribals.Text = Convert.ToString(ds.Tables[2].Rows[i]["CFOA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[2].Rows[i]["CFOA_MASTERAID"]) == 65)
                        {
                            hypTradeLic.Visible = true;
                            hypTradeLic.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[2].Rows[i]["FILELOCATION"]));
                            hypTradeLic.Text = Convert.ToString(ds.Tables[2].Rows[i]["CFOA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[2].Rows[i]["CFOA_MASTERAID"]) == 66)
                        {
                            hypCastefirms.Visible = true;
                            hypCastefirms.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[2].Rows[i]["FILELOCATION"]));
                            hypCastefirms.Text = Convert.ToString(ds.Tables[2].Rows[i]["CFOA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[2].Rows[i]["CFOA_MASTERAID"]) == 67)
                        {
                            hypattorney.Visible = true;
                            hypattorney.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[2].Rows[i]["FILELOCATION"]));
                            hypattorney.Text = Convert.ToString(ds.Tables[2].Rows[i]["CFOA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[2].Rows[i]["CFOA_MASTERAID"]) == 68)
                        {
                            hypLastissued.Visible = true;
                            hypLastissued.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[2].Rows[i]["FILELOCATION"]));
                            hypLastissued.Text = Convert.ToString(ds.Tables[2].Rows[i]["CFOA_FILENAME"]);
                        }
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

        protected void rblRegister_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblRegister.SelectedValue == "1")
            {
                director.Visible = true;
                applicant.Visible = true;
                circle.Visible = false;
                division.Visible = false;
            }
            else if (rblRegister.SelectedValue == "2")
            {
                applicant.Visible = true;
                director.Visible = true;
                circle.Visible = true;
                division.Visible = false;
            }
            else if (rblRegister.SelectedValue == "3")
            {
                applicant.Visible = true;
                director.Visible = true;
                circle.Visible = true;
                division.Visible = true;
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {

                ErrorMsg = Validations();
                {
                    PublicWorKDepartment ObjCFOWorkDepartment = new PublicWorKDepartment();

                    ObjCFOWorkDepartment.UNITID = Convert.ToString(Session["CFOUNITID"]);
                    ObjCFOWorkDepartment.CreatedBy = hdnUserID.Value;
                    ObjCFOWorkDepartment.IPAddress = getclientIP();
                    ObjCFOWorkDepartment.Questionnariid = Convert.ToString(Session["CFOQID"]);
                    ObjCFOWorkDepartment.UnitId = Convert.ToString(Session["CFOUNITID"]);

                    ObjCFOWorkDepartment.PurposeApplicant = rblPurApplication.SelectedValue;
                    ObjCFOWorkDepartment.ContractorReg = rblRegister.SelectedValue;
                    ObjCFOWorkDepartment.Director = ddlDirector.SelectedValue;
                    ObjCFOWorkDepartment.Circle = ddlCircle.SelectedValue;
                    ObjCFOWorkDepartment.Division = ddlDivision.SelectedValue;
                    ObjCFOWorkDepartment.BankerName = txtNameBank.Text.Trim();
                    ObjCFOWorkDepartment.Turnover = txtTurnOver.Text;
                    ObjCFOWorkDepartment.financialYear = txtFinancial.Text;
                    ObjCFOWorkDepartment.Datework = txtContractor.Text;

                    result = objcfobal.InsertCFOPublicworkDetails(ObjCFOWorkDepartment);
                    //  ViewState["UnitID"] = result;
                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "Public Work Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
        public string Validations()
        {
            try
            {
                int slno = 1;

                if (string.IsNullOrEmpty(txtNameBank.Text.Trim()) || txtNameBank.Text.Trim() == "" || txtNameBank.Text.Trim() == null)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Address\\n";
                    slno = slno + 1;
                }
                if (rblPurApplication.SelectedIndex == -1)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Purpose of Application \\n";
                    slno = slno + 1;
                }
                //if (rblRegister.SelectedValue == "1")
                //{
                //    applicant.Visible = true;
                //    director.Visible = true;
                //    if (ddlDirector.SelectedIndex == 0)
                //    {
                //        errormsg = errormsg + slno + ". Please Enter Directorate\\n";
                //        slno = slno + 1;
                //    }
                //    else { director.Visible = false; }
                //}
                //else if (rblRegister.SelectedValue == "2")
                //{
                //    applicant.Visible = true;
                //    circle.Visible = true;
                //    if (ddlCircle.SelectedIndex == 0)
                //    {
                //        errormsg = errormsg + slno + ". Please Enter Circle\\n";
                //        slno = slno + 1;
                //    }
                //    else { circle.Visible = false; }
                //}
                //else if (rblRegister.SelectedValue == "3")
                //{
                //    applicant.Visible = true;
                //    division.Visible = true;
                //    if (ddlDivision.SelectedIndex == 0)
                //    {
                //        errormsg = errormsg + slno + ". Please Enter Division\\n";
                //        slno = slno + 1;
                //    }
                //    else { division.Visible = false; }
                //}

                if (string.IsNullOrEmpty(txtTurnOver.Text) || txtTurnOver.Text == "" || txtTurnOver.Text == null)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Turn Over (in Rs. Lakhs)\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtFinancial.Text) || txtFinancial.Text == "" || txtFinancial.Text == null)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Total Value of Works in last 3 financial years (in Rs. Lakhs)\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtContractor.Text) || txtContractor.Text == "" || txtContractor.Text == null)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Date from which working as contractor\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypTaxClearance.Text) || hypTaxClearance.Text == "" || hypTaxClearance.Text == null)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please upload Tax Clearance Certificate on Professional Tax \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypGSTREG.Text) || hypGSTREG.Text == "" || hypGSTREG.Text == null)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please upload GST Registration \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypLabourLic.Text) || hypLabourLic.Text == "" || hypLabourLic.Text == null)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please upload Certificate of Labour License\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypTribals.Text) || hypTribals.Text == "" || hypTribals.Text == null)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please upload Balance sheets for last three financial years \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypTradeLic.Text) || hypTradeLic.Text == "" || hypTradeLic.Text == null)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please upload Trading license In case of SC, ST and OBC \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypCastefirms.Text) || hypCastefirms.Text == "" || hypCastefirms.Text == null)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please upload Caste certificate In case of firms \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypattorney.Text) || hypattorney.Text == "" || hypattorney.Text == null)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please upload Power of attorney In case of renewals \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypLastissued.Text) || hypLastissued.Text == "" || hypLastissued.Text == null)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please upload  Last issued \\n";
                    slno = slno + 1;
                }

                return ErrorMsg;
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

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                btnsave_Click(sender, e);

                if (ErrorMsg == "")
                    Response.Redirect("~/User/CFO/CFODrugLicenseDetails.aspx?next=N");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            // Response.Redirect("~/User/CFO/CFODrugLicenseDetails.aspx?next=N");
        }

        protected void btnTaxClearance_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupTaxClearance.HasFile)
                {
                    Error = validations(fupTaxClearance);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Tax Clearance Certificate" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupTaxClearance.PostedFile.SaveAs(serverpath + "\\" + fupTaxClearance.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "61";
                        objAadhar.FilePath = serverpath + fupTaxClearance.PostedFile.FileName;
                        objAadhar.FileName = fupTaxClearance.PostedFile.FileName;
                        objAadhar.FileType = fupTaxClearance.PostedFile.ContentType;
                        objAadhar.FileDescription = "Tax Clearance Certificate on Professional Tax";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypTaxClearance.Text = fupTaxClearance.PostedFile.FileName;
                            hypTaxClearance.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objAadhar.FilePath);
                            hypTaxClearance.Target = "blank";
                            message = "alert('" + "Tax Clearance Certificate on Professional Tax Uploaded successfully" + "')";
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

        protected void btnGSTREG_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupGSTREG.HasFile)
                {
                    Error = validations(fupGSTREG);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "GST Registration" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupGSTREG.PostedFile.SaveAs(serverpath + "\\" + fupGSTREG.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "62";
                        objAadhar.FilePath = serverpath + fupGSTREG.PostedFile.FileName;
                        objAadhar.FileName = fupGSTREG.PostedFile.FileName;
                        objAadhar.FileType = fupGSTREG.PostedFile.ContentType;
                        objAadhar.FileDescription = "GST Registration";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypGSTREG.Text = fupGSTREG.PostedFile.FileName;
                            hypGSTREG.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objAadhar.FilePath);
                            hypGSTREG.Target = "blank";
                            message = "alert('" + "GST Registration Uploaded successfully" + "')";
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

        protected void btnLabourLic_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupLabourLic.HasFile)
                {
                    Error = validations(fupLabourLic);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Certificate of Labour License" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupLabourLic.PostedFile.SaveAs(serverpath + "\\" + fupLabourLic.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "63";
                        objAadhar.FilePath = serverpath + fupLabourLic.PostedFile.FileName;
                        objAadhar.FileName = fupLabourLic.PostedFile.FileName;
                        objAadhar.FileType = fupLabourLic.PostedFile.ContentType;
                        objAadhar.FileDescription = "Certificate of Labour License";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypLabourLic.Text = fupLabourLic.PostedFile.FileName;
                            hypLabourLic.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objAadhar.FilePath);
                            hypLabourLic.Target = "blank";
                            message = "alert('" + "Certificate of Labour License Uploaded successfully" + "')";
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

        protected void btnTribals_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupTribals.HasFile)
                {
                    Error = validations(fupTribals);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "certified by CA In case of non-Tribals" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupTribals.PostedFile.SaveAs(serverpath + "\\" + fupTribals.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "64";
                        objAadhar.FilePath = serverpath + fupTribals.PostedFile.FileName;
                        objAadhar.FileName = fupTribals.PostedFile.FileName;
                        objAadhar.FileType = fupTribals.PostedFile.ContentType;
                        objAadhar.FileDescription = "certified by CA In case of non-Tribals";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypTribals.Text = fupTribals.PostedFile.FileName;
                            hypTribals.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objAadhar.FilePath);
                            hypTribals.Target = "blank";
                            message = "alert('" + "Balance sheets for last three financial years, certified by CA In case of non-Tribals Uploaded successfully" + "')";
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

        protected void btnTradeLic_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupTradeLic.HasFile)
                {
                    Error = validations(fupTradeLic);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Trading license In case of SC, ST and OBC" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupTradeLic.PostedFile.SaveAs(serverpath + "\\" + fupTradeLic.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "65";
                        objAadhar.FilePath = serverpath + fupTradeLic.PostedFile.FileName;
                        objAadhar.FileName = fupTradeLic.PostedFile.FileName;
                        objAadhar.FileType = fupTradeLic.PostedFile.ContentType;
                        objAadhar.FileDescription = "Trading license In case of SC, ST and OBC";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypTradeLic.Text = fupTradeLic.PostedFile.FileName;
                            hypTradeLic.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objAadhar.FilePath);
                            hypTradeLic.Target = "blank";
                            message = "alert('" + "Trading license In case of SC, ST and OBC Uploaded successfully" + "')";
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

        protected void btnCastefirms_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupCastefirms.HasFile)
                {
                    Error = validations(fupCastefirms);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Caste certificate In case of firms" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupCastefirms.PostedFile.SaveAs(serverpath + "\\" + fupCastefirms.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "66";
                        objAadhar.FilePath = serverpath + fupCastefirms.PostedFile.FileName;
                        objAadhar.FileName = fupCastefirms.PostedFile.FileName;
                        objAadhar.FileType = fupCastefirms.PostedFile.ContentType;
                        objAadhar.FileDescription = "Caste certificate In case of firms";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypCastefirms.Text = fupCastefirms.PostedFile.FileName;
                            hypCastefirms.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objAadhar.FilePath);
                            hypCastefirms.Target = "blank";
                            message = "alert('" + "Caste certificate In case of firms Uploaded successfully" + "')";
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

        protected void btnattorney_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupattorney.HasFile)
                {
                    Error = validations(fupattorney);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Power of attorney" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupattorney.PostedFile.SaveAs(serverpath + "\\" + fupattorney.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "67";
                        objAadhar.FilePath = serverpath + fupattorney.PostedFile.FileName;
                        objAadhar.FileName = fupattorney.PostedFile.FileName;
                        objAadhar.FileType = fupattorney.PostedFile.ContentType;
                        objAadhar.FileDescription = "Power of attorney In case of renewals";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypattorney.Text = fupattorney.PostedFile.FileName;
                            hypattorney.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objAadhar.FilePath);
                            hypattorney.Target = "blank";
                            message = "alert('" + "Power of attorney In case  Uploaded successfully" + "')";
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

        protected void btnLastissued_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupLastissued.HasFile)
                {
                    Error = validations(fupLastissued);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Last issued " + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupLastissued.PostedFile.SaveAs(serverpath + "\\" + fupLastissued.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "68";
                        objAadhar.FilePath = serverpath + fupLastissued.PostedFile.FileName;
                        objAadhar.FileName = fupLastissued.PostedFile.FileName;
                        objAadhar.FileType = fupLastissued.PostedFile.ContentType;
                        objAadhar.FileDescription = "Last issued";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypLastissued.Text = fupLastissued.PostedFile.FileName;
                            hypLastissued.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objAadhar.FilePath);
                            hypLastissued.Target = "blank";
                            message = "alert('" + "Last issued Uploaded successfully" + "')";
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
                // }
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
        protected void btnPreviuos_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/CFO/CFOLegalMeterology.aspx?Previous=P");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

            // Response.Redirect("~/User/CFO/CFOLegalMeterology.aspx?Previous=P");
        }
    }
}