using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.LABAL;
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

namespace MeghalayaUIP.User.LA
{
    public partial class LAEnclosures : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        LABAL Objland = new LABAL();
        string UnitID, result, errormsg = "";
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
                    if (Convert.ToString(Session["LANDUNITID"]) != "")
                    {
                        UnitID = Convert.ToString(Session["LANDUNITID"]);
                        hdnQuesid.Value = Convert.ToString(Session["LANDUNITID"]);
                    }
                    else
                    {
                        string newurl = "~/User/LA/LAUserDashboard.aspx";
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = Objland.GetLAAttachmentsData(hdnUserID.Value, Convert.ToString(Session["LANDUNITID"]));
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["LAA_MASTERAID"]) == 177)
                                {
                                    hplPANSign.Visible = true;
                                    hplPANSign.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[0].Rows[i]["FILELOCATION"]));
                                    hplPANSign.Text = Convert.ToString(ds.Tables[0].Rows[i]["LAA_FILENAME"]);
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["LAA_MASTERAID"]) == 178)
                                {
                                    hplAuthority.Visible = true;
                                    hplAuthority.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[0].Rows[i]["FILELOCATION"]));
                                    hplAuthority.Text = Convert.ToString(ds.Tables[0].Rows[i]["LAA_FILENAME"]);
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["LAA_MASTERAID"]) == 179) 
                                {
                                    hplPANPhoto.Visible = true;
                                    hplPANPhoto.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[0].Rows[i]["FILELOCATION"]));
                                    hplPANPhoto.Text = Convert.ToString(ds.Tables[0].Rows[i]["LAA_FILENAME"]);
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["LAA_MASTERAID"]) == 180) 
                                {
                                    hplTecho.Visible = true;
                                    hplTecho.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[0].Rows[i]["FILELOCATION"]));
                                    hplTecho.Text = Convert.ToString(ds.Tables[0].Rows[i]["LAA_FILENAME"]);
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["LAA_MASTERAID"]) == 181) 
                                {
                                    hpllayout.Visible = true;
                                    hpllayout.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[0].Rows[i]["FILELOCATION"]));
                                    hpllayout.Text = Convert.ToString(ds.Tables[0].Rows[i]["LAA_FILENAME"]);
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["LAA_MASTERAID"]) == 182)
                                {
                                    hplYear.Visible = true;
                                    hplYear.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[0].Rows[i]["FILELOCATION"]));
                                    hplYear.Text = Convert.ToString(ds.Tables[0].Rows[i]["LAA_FILENAME"]);
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["LAA_MASTERAID"]) == 183) 
                                {
                                    hplStateGov.Visible = true;
                                    hplStateGov.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[0].Rows[i]["FILELOCATION"]));
                                    hplStateGov.Text = Convert.ToString(ds.Tables[0].Rows[i]["LAA_FILENAME"]);
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
        protected void btnUpldPANSign_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupPANSign.HasFile)
                {
                    Error = validations(fupPANSign);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["LANDAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["LANDQDID"]) + "\\" + "PAN card and Photo ID of authorized" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupPANSign.PostedFile.SaveAs(serverpath + "\\" + fupPANSign.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupPANSign.PostedFile.SaveAs(serverpath + "\\" + fupPANSign.PostedFile.FileName);
                            }
                        }

                        LAAttachments objAadhar = new LAAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["LANDUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["LANDQDID"]);
                        objAadhar.MasterID = "177";
                        objAadhar.FilePath = serverpath + fupPANSign.PostedFile.FileName;
                        objAadhar.FileName = fupPANSign.PostedFile.FileName;
                        objAadhar.FileType = fupPANSign.PostedFile.ContentType;
                        objAadhar.FileDescription = "Pan And Photo Card";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = Objland.InsertLAAttachments(objAadhar);
                        if (result != "")
                        {
                            hplPANSign.Text = fupPANSign.PostedFile.FileName;
                            hplPANSign.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupPANSign.PostedFile.FileName);
                            hplPANSign.Target = "blank";
                            message = "alert('" + "PAN card and Photo ID of authorized signatory Document Uploaded successfully" + "')";
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
        protected void btnAuthority_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupAuthority.HasFile)
                {
                    Error = validations(fupAuthority);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["LANDAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["LANDQDID"]) + "\\" + "authorizing authorized signatory to sign" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupAuthority.PostedFile.SaveAs(serverpath + "\\" + fupAuthority.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupAuthority.PostedFile.SaveAs(serverpath + "\\" + fupAuthority.PostedFile.FileName);
                            }
                        }

                        LAAttachments objAadhar = new LAAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["LANDUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["LANDQDID"]);
                        objAadhar.MasterID = "178";
                        objAadhar.FilePath = serverpath + fupAuthority.PostedFile.FileName;
                        objAadhar.FileName = fupAuthority.PostedFile.FileName;
                        objAadhar.FileType = fupAuthority.PostedFile.ContentType;
                        objAadhar.FileDescription = "Board Resolution Authority";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = Objland.InsertLAAttachments(objAadhar);
                        if (result != "")
                        {
                            hplAuthority.Text = fupAuthority.PostedFile.FileName;
                            hplAuthority.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupAuthority.PostedFile.FileName);
                            hplAuthority.Target = "blank";
                            message = "alert('" + "Board’s resolution authorizing authorized signatory to sign applicati Document Uploaded successfully" + "')";
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

        protected void btnUpldPANPhoto_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupPANPhoto.HasFile)
                {
                    Error = validations(fupPANPhoto);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["LANDAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["LANDQDID"]) + "\\" + "PAN Card and Photo of all partners" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupPANPhoto.PostedFile.SaveAs(serverpath + "\\" + fupPANPhoto.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupPANPhoto.PostedFile.SaveAs(serverpath + "\\" + fupPANPhoto.PostedFile.FileName);
                            }
                        }

                        LAAttachments objAadhar = new LAAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["LANDUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["LANDQDID"]);
                        objAadhar.MasterID = "179";
                        objAadhar.FilePath = serverpath + fupPANPhoto.PostedFile.FileName;
                        objAadhar.FileName = fupPANPhoto.PostedFile.FileName;
                        objAadhar.FileType = fupPANPhoto.PostedFile.ContentType;
                        objAadhar.FileDescription = "Pancard";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = Objland.InsertLAAttachments(objAadhar);
                        if (result != "")
                        {
                            hplPANPhoto.Text = fupPANPhoto.PostedFile.FileName;
                            hplPANPhoto.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupPANPhoto.PostedFile.FileName);
                            hplPANPhoto.Target = "blank";
                            message = "alert('" + "PAN Card and Photo of all partners/promoters Document Uploaded successfully" + "')";
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

        protected void btnUplTecho_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupTecho.HasFile)
                {
                    Error = validations(fupTecho);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["LANDAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["LANDQDID"]) + "\\" + "Techno Economic Feasibility" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupTecho.PostedFile.SaveAs(serverpath + "\\" + fupTecho.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupTecho.PostedFile.SaveAs(serverpath + "\\" + fupTecho.PostedFile.FileName);
                            }
                        }

                        LAAttachments objAadhar = new LAAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["LANDUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["LANDQDID"]);
                        objAadhar.MasterID = "180";
                        objAadhar.FilePath = serverpath + fupTecho.PostedFile.FileName;
                        objAadhar.FileName = fupTecho.PostedFile.FileName;
                        objAadhar.FileType = fupTecho.PostedFile.ContentType;
                        objAadhar.FileDescription = "Techno Economic";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = Objland.InsertLAAttachments(objAadhar);
                        if (result != "")
                        {
                            hplTecho.Text = fupTecho.PostedFile.FileName;
                            hplTecho.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupTecho.PostedFile.FileName);
                            hplTecho.Target = "blank";
                            message = "alert('" + "Techno Economic Feasibility Report Document Uploaded successfully" + "')";
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

        protected void btnPlantlayout_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupPlantlayout.HasFile)
                {
                    Error = validations(fupPlantlayout);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["LANDAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["LANDQDID"]) + "\\" + "Plant layout" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupPlantlayout.PostedFile.SaveAs(serverpath + "\\" + fupPlantlayout.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupPlantlayout.PostedFile.SaveAs(serverpath + "\\" + fupPlantlayout.PostedFile.FileName);
                            }
                        }

                        LAAttachments objAadhar = new LAAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["LANDUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["LANDQDID"]);
                        objAadhar.MasterID = "181";
                        objAadhar.FilePath = serverpath + fupPlantlayout.PostedFile.FileName;
                        objAadhar.FileName = fupPlantlayout.PostedFile.FileName;
                        objAadhar.FileType = fupPlantlayout.PostedFile.ContentType;
                        objAadhar.FileDescription = "Plant Layout";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = Objland.InsertLAAttachments(objAadhar);
                        if (result != "")
                        {
                            hpllayout.Text = fupPlantlayout.PostedFile.FileName;
                            hpllayout.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupPlantlayout.PostedFile.FileName);
                            hpllayout.Target = "blank";
                            message = "alert('" + "Plant layout indicating therein area for installation Document Uploaded successfully" + "')";
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

        protected void btnYear_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupYear.HasFile)
                {
                    Error = validations(fupYear);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["LANDAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["LANDQDID"]) + "\\" + "Last 3 (three) years Balance Sheet" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupYear.PostedFile.SaveAs(serverpath + "\\" + fupYear.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupYear.PostedFile.SaveAs(serverpath + "\\" + fupYear.PostedFile.FileName);
                            }
                        }

                        LAAttachments objAadhar = new LAAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["LANDUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["LANDQDID"]);
                        objAadhar.MasterID = "182";
                        objAadhar.FilePath = serverpath + fupYear.PostedFile.FileName;
                        objAadhar.FileName = fupYear.PostedFile.FileName;
                        objAadhar.FileType = fupYear.PostedFile.ContentType;
                        objAadhar.FileDescription = "Balance sheet";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = Objland.InsertLAAttachments(objAadhar);
                        if (result != "")
                        {
                            hplYear.Text = fupYear.PostedFile.FileName;
                            hplYear.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupYear.PostedFile.FileName);
                            hplYear.Target = "blank";
                            message = "alert('" + "Last 3 (three) years Balance Sheet Document Uploaded successfully" + "')";
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

        protected void btnStateGov_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupstateGov.HasFile)
                {
                    Error = validations(fupstateGov);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["LANDAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["LANDQDID"]) + "\\" + "State Government/lessor" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupstateGov.PostedFile.SaveAs(serverpath + "\\" + fupstateGov.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupstateGov.PostedFile.SaveAs(serverpath + "\\" + fupstateGov.PostedFile.FileName);
                            }
                        }

                        LAAttachments objAadhar = new LAAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["LANDUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["LANDQDID"]);
                        objAadhar.MasterID = "183";
                        objAadhar.FilePath = serverpath + fupstateGov.PostedFile.FileName;
                        objAadhar.FileName = fupstateGov.PostedFile.FileName;
                        objAadhar.FileType = fupstateGov.PostedFile.ContentType;
                        objAadhar.FileDescription = "State Government";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = Objland.InsertLAAttachments(objAadhar);
                        if (result != "")
                        {
                            hplYear.Text = fupstateGov.PostedFile.FileName;
                            hplYear.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupstateGov.PostedFile.FileName);
                            hplYear.Target = "blank";
                            message = "alert('" + "State Government/lessor Document Uploaded successfully" + "')";
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int slno = 1;

                if (string.IsNullOrEmpty(hplPANSign.Text) || hplPANSign.Text == "" || hplPANSign.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Upload PAN card and Photo ID Document \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hplAuthority.Text) || hplAuthority.Text == "" || hplAuthority.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Upload Board’s resolution authorizing authorized signatory to sign Document \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hplPANPhoto.Text) || hplPANPhoto.Text == "" || hplPANPhoto.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Upload PAN Card and Photo of all partners/promoters \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hplTecho.Text) || hplTecho.Text == "" || hplTecho.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Upload Techno Economic Feasibility Report  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hpllayout.Text) || hpllayout.Text == "" || hpllayout.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Upload  Plant layout indicating therein area \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hplYear.Text) || hplYear.Text == "" || hplYear.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Upload Last 3 (three) years Balance Sheet  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hplStateGov.Text) || hplStateGov.Text == "" || hplStateGov.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Upload the State Government/lessor \\n";
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

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/LA/LAQuestionnaire.aspx?Previous=" + "P");
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
                btnSave_Click(sender, e);
                if (errormsg == "")
                    Response.Redirect("~/User/LA/LAPaymentPage.aspx");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
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