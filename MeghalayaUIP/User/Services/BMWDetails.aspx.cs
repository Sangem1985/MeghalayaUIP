using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.SVRCBAL;
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

namespace MeghalayaUIP.User.Services
{
    public partial class BMWDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        SVRCBAL objSrvcbal = new SVRCBAL();

        string Category, ErrorMsg, result, UnitID;
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

                if (!IsPostBack)
                {
                    BindBMW();
                    BindWasteDetails();
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ddlcategory.SelectedValue) || string.IsNullOrEmpty(ddlwaste.SelectedValue) || string.IsNullOrEmpty(txtQuantity.Text) || string.IsNullOrEmpty(txtMethod.Text))
                {
                    lblmsg0.Text = "Please Enter All Details of BMW WASTE";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("BMW_TYPE", typeof(string));
                    dt.Columns.Add("BMW_NAME", typeof(string));
                    dt.Columns.Add("BMW_QUANTITYGENERATED", typeof(string));
                    dt.Columns.Add("BMW_TREATMENTDISPOSAL", typeof(string));

                    if (ViewState["BMWWasteData"] != null)
                    {
                        dt = (DataTable)ViewState["BMWWasteData"];
                    }
                    DataRow dr = dt.NewRow();
                    dr["BMW_TYPE"] = ddlcategory.SelectedValue;
                    dr["BMW_NAME"] = ddlwaste.SelectedValue;
                    dr["BMW_QUANTITYGENERATED"] = txtQuantity.Text;
                    dr["BMW_TREATMENTDISPOSAL"] = txtMethod.Text;

                    dt.Rows.Add(dr);
                    GVWaste.Visible = true;
                    GVWaste.DataSource = dt;
                    GVWaste.DataBind();
                    ViewState["BMWWasteData"] = dt;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindWasteDetails()
        {
            try
            {
                ddlcategory.Items.Clear();


                // List<MasterBMWWASTE> objWaste = new List<MasterBMWWASTE>();
                DataSet ds = new DataSet();

                ds = mstrBAL.GetWasteDet(Category);
                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlcategory.DataSource = ds.Tables[0];
                    ddlcategory.DataValueField = "BMW_TYPE";
                    ddlcategory.DataTextField = "BMW_TYPE";
                    ddlcategory.DataBind();

                }
                else
                {
                    ddlcategory.DataSource = null;
                    ddlcategory.DataBind();


                }
                AddSelect(ddlcategory);

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindCategory(DropDownList ddlwaste, string Category)
        {
            try
            {
                ddlwaste.Items.Clear();

                DataSet ds = new DataSet();
                ds = mstrBAL.GetWasteDet(Category);
                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlwaste.DataSource = ds.Tables[1];
                    ddlwaste.DataValueField = "BMW_TYPE";
                    ddlwaste.DataTextField = "BMW_NAME";
                    ddlwaste.DataBind();
                }
                else
                {
                    ddlwaste.DataSource = null;
                    ddlwaste.DataBind();
                }
                AddSelect(ddlwaste);

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
        protected void BindBMW()
        {
            try
            {
                DataSet dt = new DataSet();

                dt = objSrvcbal.BMWEquipment();

                if (dt != null && dt.Tables.Count > 2)
                {
                    GVBIOMedical.DataSource = dt.Tables[2];
                    GVBIOMedical.DataBind();
                }
                else
                {
                    GVBIOMedical.DataSource = null;
                    GVBIOMedical.DataBind();
                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlwaste.ClearSelection();
                AddSelect(ddlwaste);
                if (ddlcategory.SelectedItem.Text != "--Select--")
                {
                    BindCategory(ddlwaste, ddlcategory.SelectedValue);
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
        public string SaveBMWMedical()
        {
            string result = "";
        
            DataTable dt = new DataTable();
            dt.Columns.Add("BMW_UNITID");
            dt.Columns.Add("BMW_CREATEDBY");
            dt.Columns.Add("BMW_EQUIPMENT");
            dt.Columns.Add("BMW_NO_UNIT");
            dt.Columns.Add("BMW_CAPACITY_UNIT");

           
            if (GVBIOMedical.Rows.Count > 0)
            {
                foreach (GridViewRow row in GVBIOMedical.Rows)
                {
                    
                    Label lblitem = row.FindControl("lblItemName") as Label;
                    TextBox txtsource = row.FindControl("txtSource") as TextBox;
                    TextBox txtcapacity = row.FindControl("txtCapacity") as TextBox;

                    if (lblitem != null && txtsource != null && txtcapacity != null)
                    {
                       
                        DataRow dr = dt.NewRow();                       
                        dr["BMW_EQUIPMENT"] = lblitem.Text;
                        dr["BMW_NO_UNIT"] = txtsource.Text;
                        dr["BMW_CAPACITY_UNIT"] = txtcapacity.Text;

                        dt.Rows.Add(dr);
                    }
                }
                if (dt.Rows.Count > 0)
                {
                   // SvrcBMWDet objSrvcbal = new SvrcBMWDet();
                    result = objSrvcbal.InsertBMWWASTEDET(dt, "1001", hdnUserID.Value, getclientIP());
                }
            }

            return result;
        }

        protected void btnBiomedicalwaste_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupBiomedicalwaste.HasFile)
                {
                    Error = validations(fupBiomedicalwaste);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["SRVCAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Aadhar" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupBiomedicalwaste.PostedFile.SaveAs(serverpath + "\\" + fupBiomedicalwaste.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupBiomedicalwaste.PostedFile.SaveAs(serverpath + "\\" + fupBiomedicalwaste.PostedFile.FileName);
                            }
                        }

                        SRVCAttachments objAadhar = new SRVCAttachments();
                        objAadhar.UNITID = "1001";//Convert.ToString(Session["CFEUNITID"]);
                        objAadhar.Questionnareid = "101"; //Convert.ToString(Session["CFEQID"]);
                        objAadhar.MasterID = "";
                        objAadhar.FilePath = serverpath + fupBiomedicalwaste.PostedFile.FileName;
                        objAadhar.FileName = fupBiomedicalwaste.PostedFile.FileName;
                        objAadhar.FileType = fupBiomedicalwaste.PostedFile.ContentType;
                        objAadhar.FileDescription = "";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objSrvcbal.InsertSRVCAttachments(objAadhar);
                        if (result != "")
                        {
                            hyplegalnotice.Text = fupBiomedicalwaste.PostedFile.FileName;
                            hyplegalnotice.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupBiomedicalwaste.PostedFile.FileName);
                            hyplegalnotice.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
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

        protected void btnlegalnotice_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fuplegalnotice.HasFile)
                {
                    Error = validations(fuplegalnotice);
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
                            fuplegalnotice.PostedFile.SaveAs(serverpath + "\\" + fuplegalnotice.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fuplegalnotice.PostedFile.SaveAs(serverpath + "\\" + fuplegalnotice.PostedFile.FileName);
                            }
                        }


                        SRVCAttachments objSitePlan = new SRVCAttachments();
                        objSitePlan.UNITID = "1001";//Convert.ToString(Session["CFEUNITID"]);
                        objSitePlan.Questionnareid = "1001"; //Convert.ToString(Session["CFEQID"]);
                        objSitePlan.MasterID = "15";
                        objSitePlan.FilePath = serverpath + fuplegalnotice.PostedFile.FileName;
                        objSitePlan.FileName = fuplegalnotice.PostedFile.FileName;
                        objSitePlan.FileType = fuplegalnotice.PostedFile.ContentType;
                        objSitePlan.FileDescription = "Site Plan";
                        objSitePlan.CreatedBy = hdnUserID.Value;
                        objSitePlan.IPAddress = getclientIP();
                        result = objSrvcbal.InsertSRVCAttachments(objSitePlan);
                        if (result != "")
                        {
                            hyplegalnotice.Text = fuplegalnotice.PostedFile.FileName;
                            hyplegalnotice.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fuplegalnotice.PostedFile.FileName);
                            hyplegalnotice.Target = "blank";
                            message = "alert('" + " Document Uploaded successfully" + "')";
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

                if (i == 2 && fileType[i - 1].ToUpper().Trim() == "PDF")
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            { throw ex; }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg = Stepvalidations();
                if (ErrorMsg == "")
                {
                    SvrcBMWDet ObjBMWDetails = new SvrcBMWDet();
                    int count = 0;
                    for (int i = 0; i < GVWaste.Rows.Count; i++)
                    {
                        ObjBMWDetails.Createdby = hdnUserID.Value;
                        ObjBMWDetails.UnitId = "1001";
                        ObjBMWDetails.IPAddress = getclientIP();
                        ObjBMWDetails.Category = ddlcategory.SelectedValue;
                        ObjBMWDetails.Waste = ddlwaste.SelectedValue;
                        ObjBMWDetails.QuantityGenerated = txtQuantity.Text;
                        ObjBMWDetails.MethodDisposal = txtMethod.Text;

                        string A = objSrvcbal.SRVCBMWWASTEDET(ObjBMWDetails);
                        if (A != "")
                        { count = count + 1; }
                    }
                    if (GVWaste.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = "BMWDETAILS Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                  

                    var selectedItems = CHKAuthorized.Items.Cast<ListItem>()
                             .Where(li => li.Selected)
                             .Select(li => li.Text);

                    string selectedActivities = string.Join(", ", selectedItems);


                    ObjBMWDetails.UnitId = "1001";
                    ObjBMWDetails.Createdby = hdnUserID.Value;
                    ObjBMWDetails.IPAddress = getclientIP();
                    ObjBMWDetails.Name_applicant = txtNameApplicant.Text;
                    ObjBMWDetails.HCFCBWTF = rblMedical.SelectedValue;
                    ObjBMWDetails.email = txtEmailId.Text;
                    ObjBMWDetails.mobile = txtMobileNo.Text;
                    ObjBMWDetails.website = txtweb.Text;
                    ObjBMWDetails.Authorizationactivity = selectedActivities;
                    ObjBMWDetails.AppliedCTO_CTE = rblauthorisation.SelectedValue;
                    ObjBMWDetails.authorisationnumber = txtRenno.Text;
                    ObjBMWDetails.authorisation_Date = txtAuthorisationDate.Text;
                    ObjBMWDetails.Pollution1974 = txtPCB.Text;
                    ObjBMWDetails.ControlPollution1981 = txtPCB1981.Text;
                    ObjBMWDetails.AddressHealthHCFCBWFT = rblHealth.SelectedValue;
                    ObjBMWDetails.GPSCOORDINATES = rblGPS.SelectedValue;
                    ObjBMWDetails.NumberBED = txtNoHCF.Text;
                    ObjBMWDetails.patientsHCF = txtHCFNO.Text;
                    ObjBMWDetails.healthcareCBMWTF = txtHealthCBMWFT.Text;
                    ObjBMWDetails.NOBEDCBMWTF = txtNobedcbmwtf.Text;
                    ObjBMWDetails.DISPOSALCBMWTF = txtcapacitytreat.Text;
                    ObjBMWDetails.DISTANCECBMWTF = txtdistance.Text;
                    ObjBMWDetails.BMWTREATED = txtwastetreat.Text;
                    ObjBMWDetails.MODETRANSACTION = txtBiowaste.Text;


                    result = objSrvcbal.SRVCBMWDetails(ObjBMWDetails);
                    result = SaveBMWMedical();
                    if (result != "")
                    {                        
                        string message = "alert('" + "BMW Details Saved Successfully" + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    string message = "alert('" + ErrorMsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Stepvalidations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                if (string.IsNullOrEmpty(txtNameApplicant.Text) || txtNameApplicant.Text == "" || txtNameApplicant.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name of the Applicant...! \\n";
                    slno = slno + 1;
                }
                if (rblMedical.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Name of the health care facility HCF/CBWTF...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEmailId.Text) || txtEmailId.Text == "" || txtEmailId.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter E-Mail ID...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtMobileNo.Text) || txtMobileNo.Text == "" || txtMobileNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Mobile Number...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtweb.Text) || txtweb.Text == "" || txtweb.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Website Address...! \\n";
                    slno = slno + 1;
                }
                if (rblauthorisation.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Applied for CTO/CTE...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtRenno.Text) || txtRenno.Text == "" || txtRenno.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter renewal previous authorisation number...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAuthorisationDate.Text) || txtAuthorisationDate.Text == "" || txtAuthorisationDate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter renewal previous authorisation Date...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPCB.Text) || txtPCB.Text == "" || txtPCB.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Prevention and Control of Pollution) Act, 1974...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPCB1981.Text) || txtPCB1981.Text == "" || txtPCB1981.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Prevention and Control of Pollution) Act, 1981...! \\n";
                    slno = slno + 1;
                }
                if (rblHealth.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Address health care facility (HCF)/(CBWTF)...! \\n";
                    slno = slno + 1;
                }
                if (rblGPS.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select GPS coordinates of health care facility (HCF)/(CBWTF)...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNoHCF.Text) || txtNoHCF.Text == "" || txtNoHCF.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Number of beds of HCF...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtHCFNO.Text) || txtHCFNO.Text == "" || txtHCFNO.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Number of patients treated per month by HCF...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtHealthCBMWFT.Text) || txtHealthCBMWFT.Text == "" || txtHealthCBMWFT.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Number of patients treated per month by HCF...! \\n";
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

    }
}