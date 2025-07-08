using MeghalayaUIP.BAL.CFEBLL;
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

namespace MeghalayaUIP.User.CFE
{
    public partial class CFECLUDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFEBAL objcfebal = new CFEBAL();
        string Result = "", ErrorMsg = "", UnitID;
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
                    if (Convert.ToString(Session["CFEUNITID"]) != "")
                    {
                        UnitID = Convert.ToString(Session["CFEUNITID"]);
                    }
                    //else
                    //{
                    //    string newurl = "~/User/CFE/CFEUserDashboard.aspx";
                    //    Response.Redirect(newurl);
                    //}

                    Page.MaintainScrollPositionOnPostBack = true;

                    if (!IsPostBack)
                    {
                        BindDistricts();
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
                ds = objcfebal.GetCFECLUDETAILS(hdnUserID.Value, UnitID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["UnitID"] = Convert.ToString(ds.Tables[0].Rows[0]["CFEUNITID"]);
                    if (ds.Tables[0].Rows[0]["CFECL_OWNERSHIPPROOF"].ToString().Contains("Sale Deed"))
                        CHKAuthorized.Items[0].Selected = true;
                    if (ds.Tables[0].Rows[0]["CFECL_OWNERSHIPPROOF"].ToString().Contains("Patta"))
                        CHKAuthorized.Items[1].Selected = true;
                    if (ds.Tables[0].Rows[0]["CFECL_OWNERSHIPPROOF"].ToString().Contains("Land Holding Certificate"))
                        CHKAuthorized.Items[2].Selected = true;

                    ddlDistric.SelectedValue = ds.Tables[0].Rows[0]["CFECL_DISTRIC"].ToString();
                    ddlDistric_SelectedIndexChanged(null, EventArgs.Empty);
                    ddlMandal.Text = ds.Tables[0].Rows[0]["CFECL_MANDAL"].ToString();
                    ddlMandal_SelectedIndexChanged(null, EventArgs.Empty);
                    ddlVillage.Text = ds.Tables[0].Rows[0]["CFECL_VILLAGE"].ToString();
                    txtLand.Text = ds.Tables[0].Rows[0]["CFECL_EXTENTLAND"].ToString();
                    ddlownership.SelectedValue = ds.Tables[0].Rows[0]["CFECL_TYPEOWNERSHIP"].ToString();

                    ddlCurrentLand.SelectedValue = ds.Tables[0].Rows[0]["CFECL_CURRENTLANDUSE"].ToString();

                    if (ddlCurrentLand.SelectedValue == "4")
                    {
                        divOther.Visible = true;
                        txtOther.Text = ds.Tables[0].Rows[0]["CFECL_OTHERS"].ToString();
                    }

                    ddlLandProposed.SelectedValue = ds.Tables[0].Rows[0]["CFECL_PROPOSEDLANDUSE"].ToString();


                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        if (Convert.ToInt32(ds.Tables[1].Rows[i]["CFEA_MASTERAID"]) == 55)
                        {
                            hypSaledeed.Visible = true;
                            hypSaledeed.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["FILELOCATION"]));
                            hypSaledeed.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[1].Rows[i]["CFEA_MASTERAID"]) == 56)
                        {
                            hypPatta.Visible = true;
                            hypPatta.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["FILELOCATION"]));
                            hypPatta.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[1].Rows[i]["CFEA_MASTERAID"]) == 57)
                        {
                            hypLand.Visible = true;
                            hypLand.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["FILELOCATION"]));
                            hypLand.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[1].Rows[i]["CFEA_MASTERAID"]) == 58)
                        {
                            hypLocation.Visible = true;
                            hypLocation.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["FILELOCATION"]));
                            hypLocation.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[1].Rows[i]["CFEA_MASTERAID"]) == 59)
                        {
                            hypAffidavit.Visible = true;
                            hypAffidavit.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["FILELOCATION"]));
                            hypAffidavit.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[1].Rows[i]["CFEA_MASTERAID"]) == 60)
                        {
                            hypNOC.Visible = true;
                            hypNOC.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["FILELOCATION"]));
                            hypNOC.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[1].Rows[i]["CFEA_MASTERAID"]) == 184)
                        {
                            hypLatitude.Visible = true;
                            hypLatitude.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["FILELOCATION"]));
                            hypLatitude.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
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
        protected void ddlCurrentLand_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlCurrentLand.SelectedValue == "10")
                {
                    divOther.Visible = true;
                }
                else { divOther.Visible = false; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CHKAuthorized_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                divSaleDeed.Visible = false;
                divPatta.Visible = false;
                divLand.Visible = false;

                foreach (ListItem item in CHKAuthorized.Items)
                {
                    if (item.Selected)
                    {
                        switch (item.Value)
                        {
                            case "1":
                                divSaleDeed.Visible = true;
                                break;
                            case "2":
                                divPatta.Visible = true;
                                break;
                            case "3":
                                divLand.Visible = true;
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void BindDistricts()
        {

            try
            {

                ddlDistric.Items.Clear();
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
                    ddlDistric.DataSource = objDistrictModel;
                    ddlDistric.DataValueField = "DistrictId";
                    ddlDistric.DataTextField = "DistrictName";
                    ddlDistric.DataBind();

                }
                else
                {
                    ddlDistric.DataSource = null;
                    ddlDistric.DataBind();
                }
                AddSelect(ddlDistric);
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
                    //ddlApplTaluka.Enabled = true;
                    //ddlApplVillage.Enabled = false;

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
                    //ddlApplVillage.Enabled = true ;
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

        protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlVillage.ClearSelection();
                ddlVillage.Items.Clear();
                AddSelect(ddlVillage);

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

        protected void ddlDistric_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlMandal.ClearSelection();
                ddlMandal.Items.Clear();
                AddSelect(ddlMandal);
                if (ddlDistric.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlMandal, ddlDistric.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg = Validations();

                if (ErrorMsg == "")
                {

                    CFECLU objCFECLU = new CFECLU();

                    var selectedItems = CHKAuthorized.Items.Cast<ListItem>()
                                 .Where(li => li.Selected)
                                 .Select(li => li.Text);

                    string selectedActivities = string.Join(", ", selectedItems);

                    objCFECLU.Questionnariid = "1001"; //Convert.ToString(Session["CFEQID"]);
                    objCFECLU.Createdby = hdnUserID.Value;
                    objCFECLU.UnitId = "1001"; //Convert.ToString(Session["CFEUNITID"]);
                    objCFECLU.IPAddress = getclientIP();
                    objCFECLU.District = ddlDistric.SelectedValue;
                    objCFECLU.Mandal = ddlMandal.SelectedValue;
                    objCFECLU.Village = ddlVillage.SelectedValue;
                    objCFECLU.ExtendLand = txtLand.Text;
                    objCFECLU.TypeOwnership = ddlownership.SelectedValue;
                    objCFECLU.OwnershipProof = selectedActivities;
                    objCFECLU.CurrentLand = ddlCurrentLand.SelectedValue;
                    objCFECLU.LandUse = ddlLandProposed.SelectedValue;
                    objCFECLU.Others = txtOther.Text;

                    Result = objcfebal.InsertCFECLU(objCFECLU);

                    if (Result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = " Change Of Land Use Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
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

        protected void btnSaledeed_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupSaledeed.HasFile)
                {
                    Error = validations(fupSaledeed);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Sale Deed" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupSaledeed.PostedFile.SaveAs(serverpath + "\\" + fupSaledeed.PostedFile.FileName);

                        CFEAttachments objOwner = new CFEAttachments();
                        objOwner.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objOwner.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objOwner.MasterID = "55";
                        objOwner.FilePath = serverpath + fupSaledeed.PostedFile.FileName;
                        objOwner.FileName = fupSaledeed.PostedFile.FileName;
                        objOwner.FileType = fupSaledeed.PostedFile.ContentType;
                        objOwner.FileDescription = "Sale Deed";
                        objOwner.CreatedBy = hdnUserID.Value;
                        objOwner.IPAddress = getclientIP();
                        Result = objcfebal.InsertCFEAttachments(objOwner);
                        if (Result != "")
                        {
                            hypSaledeed.Text = fupSaledeed.PostedFile.FileName;
                            hypSaledeed.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objOwner.FilePath);
                            hypSaledeed.Target = "blank";
                            message = "alert('" + "Sale Deed Document Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        public string Validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";


                if (ddlDistric.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select District \\n";
                    slno = slno + 1;
                }
                if (ddlMandal.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Mandal \\n";
                    slno = slno + 1;
                }
                if (ddlVillage.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Village \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLand.Text) || txtLand.Text == "" || txtLand.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Extent of Land \\n";
                    slno = slno + 1;
                }
                if (ddlownership.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Type of Ownership \\n";
                    slno = slno + 1;
                }
                if (CHKAuthorized.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Check Ownership Proof(upload)  \\n";
                    slno = slno + 1;
                }
                if (ddlCurrentLand.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Current Land Use \\n";
                    slno = slno + 1;
                }
                if (ddlCurrentLand.SelectedValue == "4")
                {
                    if (string.IsNullOrEmpty(txtOther.Text) || txtOther.Text == "" || txtOther.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Others \\n";
                        slno = slno + 1;
                    }
                }
                if (ddlLandProposed.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Proposed Land Use \\n";
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

        protected void btnPatta_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupPatta.HasFile)
                {
                    Error = validations(fupPatta);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Patta" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupPatta.PostedFile.SaveAs(serverpath + "\\" + fupPatta.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupPatta.PostedFile.SaveAs(serverpath + "\\" + fupPatta.PostedFile.FileName);
                            }
                        }


                        CFEAttachments objManufacture = new CFEAttachments();
                        objManufacture.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objManufacture.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objManufacture.MasterID = "56";
                        objManufacture.FilePath = serverpath + fupPatta.PostedFile.FileName;
                        objManufacture.FileName = fupPatta.PostedFile.FileName;
                        objManufacture.FileType = fupPatta.PostedFile.ContentType;
                        objManufacture.FileDescription = "Patta";
                        objManufacture.CreatedBy = hdnUserID.Value;
                        objManufacture.IPAddress = getclientIP();
                        Result = objcfebal.InsertCFEAttachments(objManufacture);
                        if (Result != "")
                        {
                            hypPatta.Text = fupPatta.PostedFile.FileName;
                            hypPatta.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objManufacture.FilePath);
                            hypPatta.Target = "blank";
                            message = "alert('" + "Patta Document Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnLand_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupLand.HasFile)
                {
                    Error = validations(fupLand);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Land Holding Certificate" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupLand.PostedFile.SaveAs(serverpath + "\\" + fupLand.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupLand.PostedFile.SaveAs(serverpath + "\\" + fupLand.PostedFile.FileName);
                            }
                        }


                        CFEAttachments objManufacture = new CFEAttachments();
                        objManufacture.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objManufacture.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objManufacture.MasterID = "57";
                        objManufacture.FilePath = serverpath + fupLand.PostedFile.FileName;
                        objManufacture.FileName = fupLand.PostedFile.FileName;
                        objManufacture.FileType = fupLand.PostedFile.ContentType;
                        objManufacture.FileDescription = "Land Holding Certificate";
                        objManufacture.CreatedBy = hdnUserID.Value;
                        objManufacture.IPAddress = getclientIP();
                        Result = objcfebal.InsertCFEAttachments(objManufacture);
                        if (Result != "")
                        {
                            hypLand.Text = fupLand.PostedFile.FileName;
                            hypLand.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objManufacture.FilePath);
                            hypLand.Target = "blank";
                            message = "alert('" + "Land Holding Certificate Document Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnLocation_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupLocation.HasFile)
                {
                    Error = validations(fupLocation);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Location Map(Showing access)" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupLocation.PostedFile.SaveAs(serverpath + "\\" + fupLocation.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupLocation.PostedFile.SaveAs(serverpath + "\\" + fupLocation.PostedFile.FileName);
                            }
                        }


                        CFEAttachments objManufacture = new CFEAttachments();
                        objManufacture.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objManufacture.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objManufacture.MasterID = "58";
                        objManufacture.FilePath = serverpath + fupLocation.PostedFile.FileName;
                        objManufacture.FileName = fupLocation.PostedFile.FileName;
                        objManufacture.FileType = fupLocation.PostedFile.ContentType;
                        objManufacture.FileDescription = "Location Map(Showing access)";
                        objManufacture.CreatedBy = hdnUserID.Value;
                        objManufacture.IPAddress = getclientIP();
                        Result = objcfebal.InsertCFEAttachments(objManufacture);
                        if (Result != "")
                        {
                            hypLocation.Text = fupLocation.PostedFile.FileName;
                            hypLocation.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objManufacture.FilePath);
                            hypLocation.Target = "blank";
                            message = "alert('" + "Location Map(Showing access) Document Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnAffidavit_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupAffidavit.HasFile)
                {
                    Error = validations(fupAffidavit);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Self-Declaration/Affidavit" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupAffidavit.PostedFile.SaveAs(serverpath + "\\" + fupAffidavit.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupAffidavit.PostedFile.SaveAs(serverpath + "\\" + fupAffidavit.PostedFile.FileName);
                            }
                        }


                        CFEAttachments objManufacture = new CFEAttachments();
                        objManufacture.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objManufacture.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objManufacture.MasterID = "59";
                        objManufacture.FilePath = serverpath + fupAffidavit.PostedFile.FileName;
                        objManufacture.FileName = fupAffidavit.PostedFile.FileName;
                        objManufacture.FileType = fupAffidavit.PostedFile.ContentType;
                        objManufacture.FileDescription = "Self-Declaration/Affidavit";
                        objManufacture.CreatedBy = hdnUserID.Value;
                        objManufacture.IPAddress = getclientIP();
                        Result = objcfebal.InsertCFEAttachments(objManufacture);
                        if (Result != "")
                        {
                            hypAffidavit.Text = fupAffidavit.PostedFile.FileName;
                            hypAffidavit.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objManufacture.FilePath);
                            hypAffidavit.Target = "blank";
                            message = "alert('" + "Self-Declaration/Affidavit Document Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnNOC_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupNOC.HasFile)
                {
                    Error = validations(fupNOC);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "NOCs" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupNOC.PostedFile.SaveAs(serverpath + "\\" + fupNOC.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupNOC.PostedFile.SaveAs(serverpath + "\\" + fupNOC.PostedFile.FileName);
                            }
                        }


                        CFEAttachments objManufacture = new CFEAttachments();
                        objManufacture.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objManufacture.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objManufacture.MasterID = "60";
                        objManufacture.FilePath = serverpath + fupNOC.PostedFile.FileName;
                        objManufacture.FileName = fupNOC.PostedFile.FileName;
                        objManufacture.FileType = fupNOC.PostedFile.ContentType;
                        objManufacture.FileDescription = "NOCs(if near forest/water bodies)";
                        objManufacture.CreatedBy = hdnUserID.Value;
                        objManufacture.IPAddress = getclientIP();
                        Result = objcfebal.InsertCFEAttachments(objManufacture);
                        if (Result != "")
                        {
                            hypNOC.Text = fupNOC.PostedFile.FileName;
                            hypNOC.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objManufacture.FilePath);
                            hypNOC.Target = "blank";
                            message = "alert('" + "NOCs(if near forest/water bodies) Document Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnLatitude_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupLatitude.HasFile)
                {
                    Error = validations(fupLatitude);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Longitude and Latitude of the Plot" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupLatitude.PostedFile.SaveAs(serverpath + "\\" + fupLatitude.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupLatitude.PostedFile.SaveAs(serverpath + "\\" + fupLatitude.PostedFile.FileName);
                            }
                        }


                        CFEAttachments objManufacture = new CFEAttachments();
                        objManufacture.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objManufacture.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objManufacture.MasterID = "184";
                        objManufacture.FilePath = serverpath + fupLatitude.PostedFile.FileName;
                        objManufacture.FileName = fupLatitude.PostedFile.FileName;
                        objManufacture.FileType = fupLatitude.PostedFile.ContentType;
                        objManufacture.FileDescription = "Longitude and Latitude of the Plot";
                        objManufacture.CreatedBy = hdnUserID.Value;
                        objManufacture.IPAddress = getclientIP();
                        Result = objcfebal.InsertCFEAttachments(objManufacture);
                        if (Result != "")
                        {
                            hypLatitude.Text = fupLatitude.PostedFile.FileName;
                            hypLatitude.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objManufacture.FilePath);
                            hypLatitude.Target = "blank";
                            message = "alert('" + "Longitude and Latitude of the Plot Document Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
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

    }
}