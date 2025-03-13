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
    public partial class CFEDrawingPlanDetails : System.Web.UI.Page
    {
        string ErrorMsg = "", UnitID, result;
        CFEBAL objcfebal = new CFEBAL();
        MasterBAL mstrBAL = new MasterBAL();
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
                    else
                    {
                        string newurl = "~/User/CFE/CFEUserDashboard.aspx";
                        Response.Redirect(newurl);
                    }

                    Page.MaintainScrollPositionOnPostBack = true;
                    Failure.Visible = false;
                    success.Visible = false;
                    if (!IsPostBack)
                    {
                        GetAppliedorNot();                      
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
        protected void GetAppliedorNot()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfebal.GetAppliedApprovalIDs(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]), Convert.ToString(Session["CFEQID"]), "14", "107");


                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (Convert.ToString(ds.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "107")
                        {
                            BindData();
                        }

                    }
                }
                else
                {
                    if (Request.QueryString.Count > 0)
                    {
                        if (Convert.ToString(Request.QueryString[0]) == "N")
                            Response.Redirect("~/User/CFE/CFEDGSetDetails.aspx?Next=" + "N");
                        else if (Convert.ToString(Request.QueryString[0]) == "P")
                            Response.Redirect("~/User/CFE/CFEPowerDetails.aspx?Previous=" + "P");
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
                ds = objcfebal.GetCFEPDCLDetails(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]));

                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["CFEDAD_LTSUPPLY"].ToString().Contains("Commercial"))
                            chkNature.Items[0].Selected = true;
                        if (ds.Tables[0].Rows[0]["CFEDAD_LTSUPPLY"].ToString().Contains("Industrial"))
                            chkNature.Items[1].Selected = true;
                        if (ds.Tables[0].Rows[0]["CFEDAD_LTSUPPLY"].ToString().Contains("WSLT"))
                            chkNature.Items[2].Selected = true;
                        if (ds.Tables[0].Rows[0]["CFEDAD_LTSUPPLY"].ToString().Contains("Agriculture"))
                            chkNature.Items[3].Selected = true;
                        if (ds.Tables[0].Rows[0]["CFEDAD_LTSUPPLY"].ToString().Contains("Domestic"))
                            chkNature.Items[4].Selected = true;
                        if (ds.Tables[0].Rows[0]["CFEDAD_LTSUPPLY"].ToString().Contains("General purpose"))
                            chkNature.Items[5].Selected = true;
                        if (ds.Tables[0].Rows[0]["CFEDAD_LTSUPPLY"].ToString().Contains("Public lighting"))
                            chkNature.Items[6].Selected = true;
                        if (ds.Tables[0].Rows[0]["CFEDAD_LTSUPPLY"].ToString().Contains("KJ"))
                            chkNature.Items[7].Selected = true;
                        if (ds.Tables[0].Rows[0]["CFEDAD_LTSUPPLY"].ToString().Contains("MeECL Employee"))
                            chkNature.Items[8].Selected = true;

                        rblstatus.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEDAD_STATUSRELATION"]);
                        txtPolicest.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDAD_POLICESATION"]);

                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            if (ds.Tables[1].Rows[i]["CFEA_MASTERAID"].ToString() == "49" && ds.Tables[1].Rows[i]["CFEA_MASTERAID"].ToString()!=""&& ds.Tables[1].Rows[i]["CFEA_MASTERAID"].ToString()!=null)
                            {
                                hypReport.Visible = true;
                                hypReport.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILEPATH"]));
                                hypReport.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                                txtReport.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_REFERENCENO"]);
                            }
                            if (ds.Tables[1].Rows[i]["CFEA_MASTERAID"].ToString() == "50")
                            {
                                hypduly.Visible = true;
                                hypduly.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILEPATH"]));
                                hypduly.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                                txtduly.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_REFERENCENO"]);
                            }
                            if (ds.Tables[1].Rows[i]["CFEA_MASTERAID"].ToString() == "51")
                            {
                                hypownership.Visible = true;
                                hypownership.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILEPATH"]));
                                hypownership.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                                txtownership.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_REFERENCENO"]);
                            }
                            if (ds.Tables[1].Rows[i]["CFEA_MASTERAID"].ToString() == "52")
                            {
                                hyppole.Visible = true;
                                hyppole.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILEPATH"]));
                                hyppole.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                                txtpole.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_REFERENCENO"]);
                            }
                            if (ds.Tables[1].Rows[i]["CFEA_MASTERAID"].ToString() == "53") 
                            {
                                hypowner.Visible = true;
                                hypowner.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILEPATH"]));
                                hypowner.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                                txtowner.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_REFERENCENO"]);
                            }
                            if (ds.Tables[1].Rows[i]["CFEA_MASTERAID"].ToString() == "54") 
                            {
                                hypPCB.Visible = true;
                                hypPCB.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILEPATH"]));
                                hypPCB.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                                txtPCB.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_REFERENCENO"]);
                            }
                            if (ds.Tables[1].Rows[i]["CFEA_MASTERAID"].ToString() == "55") 
                            {
                                hypBuilding.Visible = true;
                                hypBuilding.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILEPATH"]));
                                hypBuilding.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                                txtBuilding.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_REFERENCENO"]);
                            }
                            if (ds.Tables[1].Rows[i]["CFEA_MASTERAID"].ToString() == "56")
                            {
                                hypOccupancy.Visible = true;
                                hypOccupancy.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILEPATH"]));
                                hypOccupancy.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                                txtOccupancy.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_REFERENCENO"]);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg = Validations();
                if (ErrorMsg == "")
                {
                    CFEPDCLD Power = new CFEPDCLD();

                    var selectedItems = chkNature.Items.Cast<ListItem>()
                            .Where(li => li.Selected)
                            .Select(li => li.Text);

                    string selectedActivities = string.Join(", ", selectedItems);

                    Power.UnitId = Convert.ToString(Session["CFEUNITID"]);
                    Power.Createdby = hdnUserID.Value;
                    Power.Questionnariid = Convert.ToString(Session["CFEQID"]);
                    Power.IPAddress = getclientIP();
                    Power.StatusRelation = rblstatus.SelectedValue;
                    Power.PoliceStation = txtPolicest.Text;
                    Power.LTSupply = selectedActivities;

                    result = objcfebal.CFEPDCLDetails(Power);
                    if (result != "")
                    {
                        string message = "alert('" + "Power distribution corporation limited Details Saved Successfully" + "')";
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public string Validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                if (string.IsNullOrEmpty(txtPolicest.Text) || txtPolicest.Text == "" || txtPolicest.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Location and Address & Police Sation....! \\n";
                    slno = slno + 1;
                }
                if (rblstatus.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Status in Relation to the premises...! \\n";
                    slno = slno + 1;
                }
                if (chkNature.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Nature of LT Supply...! \\n";
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
        protected void btnDisposal_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupReport.HasFile)
                {
                    Error = validations(fupReport);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                        + Convert.ToString(Session["CFEQID"]) + "\\" + "electrical licensed contractor" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupReport.PostedFile.SaveAs(serverpath + "\\" + fupReport.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupReport.PostedFile.SaveAs(serverpath + "\\" + fupReport.PostedFile.FileName);
                            }
                        }


                        CFEAttachments objSWPRTD = new CFEAttachments();
                        objSWPRTD.UNITID = Convert.ToString(Session["CFEUNITID"]);//Convert.ToString(Session["CFEUNITID"]);
                        objSWPRTD.Questionnareid = Convert.ToString(Session["CFEQID"]); //Convert.ToString(Session["CFEQID"]);
                        objSWPRTD.MasterID = "49";
                        objSWPRTD.FilePath = serverpath + fupReport.PostedFile.FileName;
                        objSWPRTD.FileName = fupReport.PostedFile.FileName;
                        objSWPRTD.FileType = fupReport.PostedFile.ContentType;
                        objSWPRTD.FileDescription = "Test Report from the electrical licensed contractor";
                        objSWPRTD.CreatedBy = hdnUserID.Value;
                        objSWPRTD.IPAddress = getclientIP();
                        objSWPRTD.ReferenceNo = txtReport.Text;
                        result = objcfebal.InsertCFEAttachments(objSWPRTD);
                        if (result != "")
                        {
                            hypReport.Text = fupReport.PostedFile.FileName;
                            hypReport.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupReport.PostedFile.FileName);
                            hypReport.Target = "blank";
                            message = "alert('" + "Test Report from the electrical licensed contractor Document Uploaded successfully" + "')";
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

        protected void btnduly_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupduly.HasFile)
                {
                    Error = validations(fupduly);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                        + Convert.ToString(Session["CFEQID"]) + "\\" + "Agreement from duly filled" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupduly.PostedFile.SaveAs(serverpath + "\\" + fupduly.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupduly.PostedFile.SaveAs(serverpath + "\\" + fupduly.PostedFile.FileName);
                            }
                        }


                        CFEAttachments objSWPRTD = new CFEAttachments();
                        objSWPRTD.UNITID = Convert.ToString(Session["CFEUNITID"]);//Convert.ToString(Session["CFEUNITID"]);
                        objSWPRTD.Questionnareid = Convert.ToString(Session["CFEQID"]); //Convert.ToString(Session["CFEQID"]);
                        objSWPRTD.MasterID = "50";
                        objSWPRTD.FilePath = serverpath + fupduly.PostedFile.FileName;
                        objSWPRTD.FileName = fupduly.PostedFile.FileName;
                        objSWPRTD.FileType = fupduly.PostedFile.ContentType;
                        objSWPRTD.FileDescription = "Agreement from duly filled in";
                        objSWPRTD.CreatedBy = hdnUserID.Value;
                        objSWPRTD.IPAddress = getclientIP();
                        objSWPRTD.ReferenceNo = txtduly.Text;
                        result = objcfebal.InsertCFEAttachments(objSWPRTD);
                        if (result != "")
                        {
                            hypduly.Text = fupduly.PostedFile.FileName;
                            hypduly.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupduly.PostedFile.FileName);
                            hypduly.Target = "blank";
                            message = "alert('" + "Agreement from duly filled in Document Uploaded successfully" + "')";
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

        protected void btnownership_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupownership.HasFile)
                {
                    Error = validations(fupownership);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                        + Convert.ToString(Session["CFEQID"]) + "\\" + "Proof of ownership (in case the applicant is owner)" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupownership.PostedFile.SaveAs(serverpath + "\\" + fupownership.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupownership.PostedFile.SaveAs(serverpath + "\\" + fupownership.PostedFile.FileName);
                            }
                        }


                        CFEAttachments objSWPRTD = new CFEAttachments();
                        objSWPRTD.UNITID = Convert.ToString(Session["CFEUNITID"]);//Convert.ToString(Session["CFEUNITID"]);
                        objSWPRTD.Questionnareid = Convert.ToString(Session["CFEQID"]); //Convert.ToString(Session["CFEQID"]);
                        objSWPRTD.MasterID = "51";
                        objSWPRTD.FilePath = serverpath + fupownership.PostedFile.FileName;
                        objSWPRTD.FileName = fupownership.PostedFile.FileName;
                        objSWPRTD.FileType = fupownership.PostedFile.ContentType;
                        objSWPRTD.FileDescription = "Proof of ownership (in case the applicant is owner)";
                        objSWPRTD.CreatedBy = hdnUserID.Value;
                        objSWPRTD.IPAddress = getclientIP();
                        objSWPRTD.ReferenceNo = txtownership.Text;
                        result = objcfebal.InsertCFEAttachments(objSWPRTD);
                        if (result != "")
                        {
                            hypownership.Text = fupownership.PostedFile.FileName;
                            hypownership.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupownership.PostedFile.FileName);
                            hypownership.Target = "blank";
                            message = "alert('" + "Proof of ownership (in case the applicant is owner) Document Uploaded successfully" + "')";
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

        protected void btnpole_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fuppole.HasFile)
                {
                    Error = validations(fuppole);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                        + Convert.ToString(Session["CFEQID"]) + "\\" + "Number of the nearest electic pole" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fuppole.PostedFile.SaveAs(serverpath + "\\" + fuppole.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fuppole.PostedFile.SaveAs(serverpath + "\\" + fuppole.PostedFile.FileName);
                            }
                        }


                        CFEAttachments objSWPRTD = new CFEAttachments();
                        objSWPRTD.UNITID = Convert.ToString(Session["CFEUNITID"]);//Convert.ToString(Session["CFEUNITID"]);
                        objSWPRTD.Questionnareid = Convert.ToString(Session["CFEQID"]); //Convert.ToString(Session["CFEQID"]);
                        objSWPRTD.MasterID = "52";
                        objSWPRTD.FilePath = serverpath + fuppole.PostedFile.FileName;
                        objSWPRTD.FileName = fuppole.PostedFile.FileName;
                        objSWPRTD.FileType = fuppole.PostedFile.ContentType;
                        objSWPRTD.FileDescription = "Number of the nearest electic pole";
                        objSWPRTD.CreatedBy = hdnUserID.Value;
                        objSWPRTD.IPAddress = getclientIP();
                        objSWPRTD.ReferenceNo = txtpole.Text;
                        result = objcfebal.InsertCFEAttachments(objSWPRTD);
                        if (result != "")
                        {
                            hyppole.Text = fuppole.PostedFile.FileName;
                            hyppole.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fuppole.PostedFile.FileName);
                            hyppole.Target = "blank";
                            message = "alert('" + "Number of the nearest electic pole Document Uploaded successfully" + "')";
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

        protected void btnowner_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupowner.HasFile)
                {
                    Error = validations(fupowner);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                        + Convert.ToString(Session["CFEQID"]) + "\\" + "No objection certificate of the owner of the premises" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupowner.PostedFile.SaveAs(serverpath + "\\" + fupowner.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupowner.PostedFile.SaveAs(serverpath + "\\" + fupowner.PostedFile.FileName);
                            }
                        }


                        CFEAttachments objSWPRTD = new CFEAttachments();
                        objSWPRTD.UNITID = Convert.ToString(Session["CFEUNITID"]);//Convert.ToString(Session["CFEUNITID"]);
                        objSWPRTD.Questionnareid = Convert.ToString(Session["CFEQID"]); //Convert.ToString(Session["CFEQID"]);
                        objSWPRTD.MasterID = "53";
                        objSWPRTD.FilePath = serverpath + fupowner.PostedFile.FileName;
                        objSWPRTD.FileName = fupowner.PostedFile.FileName;
                        objSWPRTD.FileType = fupowner.PostedFile.ContentType;
                        objSWPRTD.FileDescription = "No objection certificate of the owner of the premises (in case the applicant is occupier)";
                        objSWPRTD.CreatedBy = hdnUserID.Value;
                        objSWPRTD.IPAddress = getclientIP();
                        objSWPRTD.ReferenceNo = txtowner.Text;
                        result = objcfebal.InsertCFEAttachments(objSWPRTD);
                        if (result != "")
                        {
                            hypowner.Text = fupowner.PostedFile.FileName;
                            hypowner.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupowner.PostedFile.FileName);
                            hypowner.Target = "blank";
                            message = "alert('" + "No objection certificate of the owner of the premises (in case the applicant is occupier) Document Uploaded successfully" + "')";
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

        protected void btnPCB_Click(object sender, EventArgs e)
        {

            try
            {
                string Error = ""; string message = "";
                if (fupPCB.HasFile)
                {
                    Error = validations(fupPCB);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                        + Convert.ToString(Session["CFEQID"]) + "\\" + "Pollution Control Board-If applicable" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupPCB.PostedFile.SaveAs(serverpath + "\\" + fupPCB.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupPCB.PostedFile.SaveAs(serverpath + "\\" + fupPCB.PostedFile.FileName);
                            }
                        }


                        CFEAttachments objSiteSelection = new CFEAttachments();
                        objSiteSelection.UNITID = Convert.ToString(Session["CFEUNITID"]); //Convert.ToString(Session["CFEUNITID"]);
                        objSiteSelection.Questionnareid = Convert.ToString(Session["CFEQID"]); //Convert.ToString(Session["CFEQID"]);
                        objSiteSelection.MasterID = "54";
                        objSiteSelection.FilePath = serverpath + fupPCB.PostedFile.FileName;
                        objSiteSelection.FileName = fupPCB.PostedFile.FileName;
                        objSiteSelection.FileType = fupPCB.PostedFile.ContentType;
                        objSiteSelection.FileDescription = "Attested copy of permission obtained from Pollution Control Board-If applicable";
                        objSiteSelection.CreatedBy = hdnUserID.Value;
                        objSiteSelection.IPAddress = getclientIP();
                        objSiteSelection.ReferenceNo = txtPCB.Text;
                        result = objcfebal.InsertCFEAttachments(objSiteSelection);
                        if (result != "")
                        {
                            hypPCB.Text = fupPCB.PostedFile.FileName;
                            hypPCB.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupPCB.PostedFile.FileName);
                            hypPCB.Target = "blank";
                            message = "alert('" + "Attested copy of permission obtained from Pollution Control Board-If applicable Document Uploaded successfully" + "')";
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

        protected void btnBuilding_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupBuilding.HasFile)
                {
                    Error = validations(fupBuilding);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                        + Convert.ToString(Session["CFEQID"]) + "\\" + "Building permission from the concerned authority" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupBuilding.PostedFile.SaveAs(serverpath + "\\" + fupBuilding.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupBuilding.PostedFile.SaveAs(serverpath + "\\" + fupBuilding.PostedFile.FileName);
                            }
                        }


                        CFEAttachments objSiteSelection = new CFEAttachments();
                        objSiteSelection.UNITID = Convert.ToString(Session["CFEUNITID"]); //Convert.ToString(Session["CFEUNITID"]);
                        objSiteSelection.Questionnareid = Convert.ToString(Session["CFEQID"]); //Convert.ToString(Session["CFEQID"]);
                        objSiteSelection.MasterID = "55";
                        objSiteSelection.FilePath = serverpath + fupBuilding.PostedFile.FileName;
                        objSiteSelection.FileName = fupBuilding.PostedFile.FileName;
                        objSiteSelection.FileType = fupBuilding.PostedFile.ContentType;
                        objSiteSelection.FileDescription = "Building permission from the concerned authority-If applicable";
                        objSiteSelection.CreatedBy = hdnUserID.Value;
                        objSiteSelection.IPAddress = getclientIP();
                        objSiteSelection.ReferenceNo = txtBuilding.Text;
                        result = objcfebal.InsertCFEAttachments(objSiteSelection);
                        if (result != "")
                        {
                            hypBuilding.Text = fupBuilding.PostedFile.FileName;
                            hypBuilding.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupBuilding.PostedFile.FileName);
                            hypBuilding.Target = "blank";
                            message = "alert('" + "Building permission from the concerned authority-If applicable Document Uploaded successfully" + "')";
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

        protected void btnOccupancy_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupOccupancy.HasFile)
                {
                    Error = validations(fupOccupancy);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                        + Convert.ToString(Session["CFEQID"]) + "\\" + "Occupancy Certificate from MUDA for areas within shillong Municipal limits" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupOccupancy.PostedFile.SaveAs(serverpath + "\\" + fupOccupancy.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupOccupancy.PostedFile.SaveAs(serverpath + "\\" + fupOccupancy.PostedFile.FileName);
                            }
                        }


                        CFEAttachments objSiteSelection = new CFEAttachments();
                        objSiteSelection.UNITID = Convert.ToString(Session["CFEUNITID"]); //Convert.ToString(Session["CFEUNITID"]);
                        objSiteSelection.Questionnareid = Convert.ToString(Session["CFEQID"]); //Convert.ToString(Session["CFEQID"]);
                        objSiteSelection.MasterID = "56";
                        objSiteSelection.FilePath = serverpath + fupOccupancy.PostedFile.FileName;
                        objSiteSelection.FileName = fupOccupancy.PostedFile.FileName;
                        objSiteSelection.FileType = fupOccupancy.PostedFile.ContentType;
                        objSiteSelection.FileDescription = "Occupancy Certificate from MUDA for areas within shillong Municipal limits";
                        objSiteSelection.CreatedBy = hdnUserID.Value;
                        objSiteSelection.IPAddress = getclientIP();
                        objSiteSelection.ReferenceNo = txtOccupancy.Text;
                         result = objcfebal.InsertCFEAttachments(objSiteSelection);
                        if (result != "")
                        {
                            hypOccupancy.Text = fupOccupancy.PostedFile.FileName;
                            hypOccupancy.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupOccupancy.PostedFile.FileName);
                            hypOccupancy.Target = "blank";
                            message = "alert('" + "Occupancy Certificate from MUDA for areas within shillong Municipal limits Document Uploaded successfully" + "')";
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
        public string validations(FileUpload Attachment)
        {
            try
            {
                string filesize = Convert.ToString(ConfigurationManager.AppSettings["FileSize"].ToString());
                int slno = 1; string Error = "";

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
        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                btnsave_Click(sender, e);
                if (ErrorMsg == "")
                    Response.Redirect("~/User/CFE/CFEDGSetDetails.aspx?Next=" + "N");
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
            Response.Redirect("~/User/CFE/CFEPowerDetails.aspx?Previous=" + "P");
        }

    }
}