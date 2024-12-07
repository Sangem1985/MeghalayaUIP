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
    public partial class CFEExplosivesNOC : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFEBAL objcfebal = new CFEBAL();
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
                ds = objcfebal.GetAppliedApprovalIDs(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]), Convert.ToString(Session["CFEQID"]), "13", "9");


                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (Convert.ToString(ds.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "9")
                        {                          
                            Binddata();                         
                        }
                    }
                }
                else
                {
                    if (Request.QueryString.Count > 0)
                    {
                        if (Convert.ToString(Request.QueryString[0]) == "N")
                            Response.Redirect("~/User/CFE/CFEFuelNOC.aspx?Next=" + "N");
                        else if (Convert.ToString(Request.QueryString[0]) == "P")
                            Response.Redirect("~/User/CFE/CFEFireDetails.aspx?Previous=" + "P");
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public void Binddata()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfebal.GetCFEEXPLOSIVE(hdnUserID.Value, UnitID);
              
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["UnitID"] = Convert.ToString(ds.Tables[0].Rows[0]["CFEED_CFEUNITID"]);
                        txtExplosive.Text = ds.Tables[0].Rows[0]["CFEED_EXPLOSIVESITE"].ToString();
                        txtRoadVan.Text = ds.Tables[0].Rows[0]["CFEED_EXPLOSIVEROADVAN"].ToString();
                        rblcriminal1973.SelectedValue = ds.Tables[0].Rows[0]["CFEED_CRIMINAL1973"].ToString();
                        if (rblcriminal1973.SelectedValue == "Y")
                        {
                            Details.Visible = true;
                            txtDetails.Text = ds.Tables[0].Rows[0]["CFEED_DETAIL"].ToString();
                        }
                        else { Details.Visible = false; }
                        rblLIC1884.SelectedValue = ds.Tables[0].Rows[0]["CFEED_EXPLOSIVE1884"].ToString();
                        if (rblLIC1884.SelectedValue == "Y")
                        {
                            LicDetails.Visible = true;
                            txtDet.Text = ds.Tables[0].Rows[0]["CFEED_DETAILS"].ToString();
                        }
                        else { LicDetails.Visible = false; }
                        rblApproval101.SelectedValue = ds.Tables[0].Rows[0]["CFEED_APPROVAL101"].ToString();
                        if (rblApproval101.SelectedValue == "Y")
                        {
                            approvaldet.Visible = true;
                            txtDetail.Text = ds.Tables[0].Rows[0]["CFEED_APPROVALDETAILS"].ToString();
                        }
                        else { approvaldet.Visible = false; }
                        txtinformation.Text = ds.Tables[0].Rows[0]["CFEED_ANYINFORMATION"].ToString();


                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        //hdnUserID.Value = Convert.ToString(ds.Tables[1].Rows[0]["CFEME_CFEQDID"]);
                        ViewState["MANUFACTURE"] = ds.Tables[1];
                        GVEXPLOSIVE.DataSource = ds.Tables[1];
                        GVEXPLOSIVE.DataBind();
                        GVEXPLOSIVE.Visible = true;
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                        {
                            if (Convert.ToInt32(ds.Tables[2].Rows[i]["CFEA_MASTERAID"]) == 39)
                            {
                                hypNocHeadman.Visible = true;
                                hypNocHeadman.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[2].Rows[i]["CFEA_FILEPATH"]));
                                hypNocHeadman.Text = Convert.ToString(ds.Tables[2].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(ds.Tables[2].Rows[i]["CFEA_MASTERAID"]) == 40)
                            {
                                hypfireDepartment.Visible = true;
                                hypfireDepartment.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[2].Rows[i]["CFEA_FILEPATH"]));
                                hypfireDepartment.Text = Convert.ToString(ds.Tables[2].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(ds.Tables[2].Rows[i]["CFEA_MASTERAID"]) == 41)
                            {
                                hypsite.Visible = true;
                                hypsite.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath((Convert.ToString(ds.Tables[2].Rows[i]["CFEA_FILEPATH"])));
                                hypsite.Text = Convert.ToString(ds.Tables[2].Rows[i]["CFEA_FILENAME"]);
                            }
                            if (Convert.ToInt32(ds.Tables[2].Rows[i]["CFEA_MASTERAID"]) == 42)
                            {
                                hypExplosives.Visible = true;
                                hypExplosives.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath((Convert.ToString(ds.Tables[2].Rows[i]["CFEA_FILEPATH"])));
                                hypExplosives.Text = Convert.ToString(ds.Tables[2].Rows[i]["CFEA_FILENAME"]);
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
        protected void rblcriminal1973_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblcriminal1973.SelectedValue == "Y")
                {
                    Details.Visible = true;
                }
                else { Details.Visible = false; }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblcriminal1973.BorderColor = System.Drawing.Color.White;

        }
        protected void rblLIC1884_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblLIC1884.SelectedValue == "Y")
                {
                    LicDetails.Visible = true;
                }
                else { LicDetails.Visible = false; }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblLIC1884.BorderColor = System.Drawing.Color.White;
        }
        protected void rblApproval101_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblApproval101.SelectedValue == "Y")
                {
                    approvaldet.Visible = true;
                }
                else { approvaldet.Visible = false; }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblApproval101.BorderColor = System.Drawing.Color.White;
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtName.Text.Trim()) || string.IsNullOrEmpty(txtClass.Text) || string.IsNullOrEmpty(txtDivision.Text) || string.IsNullOrEmpty(txtQuantityTime.Text) || String.IsNullOrEmpty(txtQuantityMonth.Text))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("CFEME_CFEUNITID", typeof(string));
                    dt.Columns.Add("CFEME_CREATEDBY", typeof(string));
                    dt.Columns.Add("CFEME_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("CFEME_NAME", typeof(string));
                    dt.Columns.Add("CFEME_CLASS", typeof(string));
                    dt.Columns.Add("CFEME_DIVISION", typeof(string));
                    dt.Columns.Add("CFEME_QUANTITYTIME", typeof(string));
                    dt.Columns.Add("CFEME_QUANTITYMONTH", typeof(string));


                    if (ViewState["MANUFACTURE"] != null)
                    {
                        dt = (DataTable)ViewState["MANUFACTURE"];
                    }

                    DataRow dr = dt.NewRow();
                    dr["CFEME_CFEUNITID"] = Convert.ToString(Session["CFEUNITID"]);
                    dr["CFEME_CREATEDBY"] = hdnUserID.Value;
                    dr["CFEME_CREATEDBYIP"] = getclientIP();
                    dr["CFEME_NAME"] = txtName.Text.Trim();
                    dr["CFEME_CLASS"] = txtClass.Text;
                    dr["CFEME_DIVISION"] = txtDivision.Text;
                    dr["CFEME_QUANTITYTIME"] = txtQuantityTime.Text;
                    dr["CFEME_QUANTITYMONTH"] = txtQuantityMonth.Text;

                    dt.Rows.Add(dr);
                    GVEXPLOSIVE.Visible = true;
                    GVEXPLOSIVE.DataSource = dt;
                    GVEXPLOSIVE.DataBind();
                    ViewState["MANUFACTURE"] = dt;
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                ErrorMsg = validations();
                if (ErrorMsg == "")
                {
                    CFEEXPLOSIVE ObjCFEExplosive = new CFEEXPLOSIVE();

                    int count = 0;

                    for (int i = 0; i < GVEXPLOSIVE.Rows.Count; i++)
                    {
                        ObjCFEExplosive.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        ObjCFEExplosive.CreatedBy = hdnUserID.Value;
                        ObjCFEExplosive.UnitId = Convert.ToString(Session["CFEUNITID"]);
                        ObjCFEExplosive.IPAddress = getclientIP();
                        ObjCFEExplosive.NAME = GVEXPLOSIVE.Rows[i].Cells[1].Text;
                        ObjCFEExplosive.CLASS = GVEXPLOSIVE.Rows[i].Cells[2].Text;
                        ObjCFEExplosive.DIVISION = GVEXPLOSIVE.Rows[i].Cells[3].Text;
                        ObjCFEExplosive.QUANTITYTIME = GVEXPLOSIVE.Rows[i].Cells[4].Text;
                        ObjCFEExplosive.QUANTITYMONTH = GVEXPLOSIVE.Rows[i].Cells[5].Text;

                        string A = objcfebal.InsertCFEExplosiveManuDetails(ObjCFEExplosive);
                        if (A != "")
                        { count = count + 1; }
                    }
                    if (GVEXPLOSIVE.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = "Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }

                    ObjCFEExplosive.Questionnareid = Convert.ToString(Session["CFEQID"]);
                    ObjCFEExplosive.CreatedBy = hdnUserID.Value;
                    ObjCFEExplosive.UnitId = Convert.ToString(Session["CFEUNITID"]);
                    ObjCFEExplosive.IPAddress = getclientIP();

                    ObjCFEExplosive.EXPLOSIVESITE = txtExplosive.Text;
                    ObjCFEExplosive.EXPLOSIVEROADVAN = txtRoadVan.Text;
                    ObjCFEExplosive.CRIMINAL1973 = rblcriminal1973.SelectedValue;
                    ObjCFEExplosive.DETAIL = txtDetails.Text;
                    ObjCFEExplosive.EXPLOSIVE1884 = rblLIC1884.SelectedValue;
                    ObjCFEExplosive.DETAILS = txtDet.Text;
                    ObjCFEExplosive.APPROVAL101 = rblApproval101.SelectedValue;
                    ObjCFEExplosive.APPROVALDETAILS = txtDetail.Text;
                    ObjCFEExplosive.INFORMATION = txtinformation.Text;

                    result = objcfebal.InsertCFEExplosiveDetails(ObjCFEExplosive);

                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = " Details Submitted Successfully";
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public string validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                List<TextBox> emptyTextboxes = FindEmptyTextboxes(divText);
                List<RadioButtonList> emptyRadioButtonLists = FindEmptyRadioButtonLists(divText);

                if (string.IsNullOrEmpty(txtExplosive.Text) || txtExplosive.Text == "" || txtExplosive.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Details of site where explosives  License\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtRoadVan.Text) || txtRoadVan.Text == "" || txtRoadVan.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Details of explosives road van\\n";
                    slno = slno + 1;
                }
                if (rblcriminal1973.SelectedIndex == -1)
                {
                    Details.Visible = true;
                    if (string.IsNullOrEmpty(txtDetails.Text) || txtDetails.Text == "" || txtDetails.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Details \\n";
                        slno = slno + 1;
                    }
                }
                if (rblLIC1884.SelectedIndex == -1)
                {
                    if (string.IsNullOrEmpty(txtDet.Text) || txtDet.Text == "" || txtDet.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Details \\n";
                        slno = slno + 1;
                    }
                }
                if (rblApproval101.SelectedIndex == -1)
                {
                    if (string.IsNullOrEmpty(txtDetails.Text) || txtDetails.Text == "" || txtDetails.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Details \\n";
                        slno = slno + 1;
                    }
                }
                if (string.IsNullOrEmpty(txtinformation.Text) || txtinformation.Text == "" || txtinformation.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Any information \\n";
                    slno = slno + 1;
                }
                if (GVEXPLOSIVE.Rows.Count <= 0)
                {
                    errormsg = errormsg + slno + ". Please Enter Explosive GridView Details\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypNocHeadman.Text) || hypNocHeadman.Text == "" || hypNocHeadman.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload NOC from Headman for proposed site for rural areas and NOC from Local Authority \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypfireDepartment.Text) || hypfireDepartment.Text == "" || hypfireDepartment.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Clearance certificate from Fire Department \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypsite.Text) || hypsite.Text == "" || hypsite.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Site layout \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypExplosives.Text) || hypExplosives.Text == "" || hypExplosives.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Clearance from Deputy Controller of Explosives \\n";
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
        protected void GVEXPLOSIVE_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVEXPLOSIVE.Rows.Count > 0)
                {
                    ((DataTable)ViewState["MANUFACTURE"]).Rows.RemoveAt(e.RowIndex);
                    this.GVEXPLOSIVE.DataSource = ((DataTable)ViewState["MANUFACTURE"]).DefaultView;
                    this.GVEXPLOSIVE.DataBind();
                    GVEXPLOSIVE.Visible = true;
                    GVEXPLOSIVE.Focus();

                }
                else
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/CFE/CFEFireDetails.aspx?Previous=" + "P");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);

            }
        }

        protected void btnNocHeadMan_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupNocHeadman.HasFile)
                {
                    Error = validations(fupNocHeadman);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "NOC from Headman for proposed site for rural areas" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupNocHeadman.PostedFile.SaveAs(serverpath + "\\" + fupNocHeadman.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupNocHeadman.PostedFile.SaveAs(serverpath + "\\" + fupNocHeadman.PostedFile.FileName);
                            }
                        }

                        CFEAttachments objManufacture = new CFEAttachments();
                        objManufacture.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objManufacture.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objManufacture.MasterID = "39";
                        objManufacture.FilePath = serverpath + fupNocHeadman.PostedFile.FileName;
                        objManufacture.FileName = fupNocHeadman.PostedFile.FileName;
                        objManufacture.FileType = fupNocHeadman.PostedFile.ContentType;
                        objManufacture.FileDescription = "NOC from Headman for proposed site for rural areas and NOC from Local Authority for urban areas";
                        objManufacture.CreatedBy = hdnUserID.Value;
                        objManufacture.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objManufacture);
                        if (result != "")
                        {
                            hypNocHeadman.Text = fupNocHeadman.PostedFile.FileName;
                            hypNocHeadman.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupNocHeadman.PostedFile.FileName);
                            hypNocHeadman.Target = "blank";
                            message = "alert('" + "NOC from Headman for proposed site for rural areas and NOC from Local Authority for urban areas Uploaded successfully" + "')";
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

        protected void btnFireDepartment_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupFireDepartment.HasFile)
                {
                    Error = validations(fupFireDepartment);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Clearance certificate from Fire Department" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupFireDepartment.PostedFile.SaveAs(serverpath + "\\" + fupFireDepartment.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupFireDepartment.PostedFile.SaveAs(serverpath + "\\" + fupFireDepartment.PostedFile.FileName);
                            }
                        }

                        CFEAttachments objManufacture = new CFEAttachments();
                        objManufacture.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objManufacture.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objManufacture.MasterID = "40";
                        objManufacture.FilePath = serverpath + fupFireDepartment.PostedFile.FileName;
                        objManufacture.FileName = fupFireDepartment.PostedFile.FileName;
                        objManufacture.FileType = fupFireDepartment.PostedFile.ContentType;
                        objManufacture.FileDescription = "Clearance certificate from Fire Department";
                        objManufacture.CreatedBy = hdnUserID.Value;
                        objManufacture.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objManufacture);
                        if (result != "")
                        {
                            hypfireDepartment.Text = fupFireDepartment.PostedFile.FileName;
                            hypfireDepartment.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupFireDepartment.PostedFile.FileName);
                            hypfireDepartment.Target = "blank";
                            message = "alert('" + "Clearance certificate from Fire Department Uploaded successfully" + "')";
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

        protected void btnsite_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupsite.HasFile)
                {
                    Error = validations(fupsite);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "site where explosives will be used and distance of site" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupsite.PostedFile.SaveAs(serverpath + "\\" + fupsite.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupsite.PostedFile.SaveAs(serverpath + "\\" + fupsite.PostedFile.FileName);
                            }
                        }

                        CFEAttachments objManufacture = new CFEAttachments();
                        objManufacture.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objManufacture.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objManufacture.MasterID = "41";
                        objManufacture.FilePath = serverpath + fupsite.PostedFile.FileName;
                        objManufacture.FileName = fupsite.PostedFile.FileName;
                        objManufacture.FileType = fupsite.PostedFile.ContentType;
                        objManufacture.FileDescription = "Details of site where explosives will be used and distance of site (Site layout)";
                        objManufacture.CreatedBy = hdnUserID.Value;
                        objManufacture.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objManufacture);
                        if (result != "")
                        {
                            hypsite.Text = fupsite.PostedFile.FileName;
                            hypsite.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupsite.PostedFile.FileName);
                            hypsite.Target = "blank";
                            message = "alert('" + "Details of site where explosives will be used and distance of site of use from the storage premises (Site layout) Uploaded successfully" + "')";
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

        protected void btnExplosives_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupExplosives.HasFile)
                {
                    Error = validations(fupExplosives);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Clearance from Deputy Controller of Explosives" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupExplosives.PostedFile.SaveAs(serverpath + "\\" + fupExplosives.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupExplosives.PostedFile.SaveAs(serverpath + "\\" + fupExplosives.PostedFile.FileName);
                            }
                        }

                        CFEAttachments objManufacture = new CFEAttachments();
                        objManufacture.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objManufacture.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objManufacture.MasterID = "42";
                        objManufacture.FilePath = serverpath + fupExplosives.PostedFile.FileName;
                        objManufacture.FileName = fupExplosives.PostedFile.FileName;
                        objManufacture.FileType = fupExplosives.PostedFile.ContentType;
                        objManufacture.FileDescription = "Clearance from Deputy Controller of Explosives";
                        objManufacture.CreatedBy = hdnUserID.Value;
                        objManufacture.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objManufacture);
                        if (result != "")
                        {
                            hypExplosives.Text = fupExplosives.PostedFile.FileName;
                            hypExplosives.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupExplosives.PostedFile.FileName);
                            hypExplosives.Target = "blank";
                            message = "alert('" + "Clearance from Deputy Controller of Explosives Uploaded successfully" + "')";
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

        public string validations(FileUpload Attachment)
        {
            try
            {
                string filesize = Convert.ToString(ConfigurationManager.AppSettings["FileSize"].ToString());
                int slno = 1; string Error = "";
                List<TextBox> emptyTextboxes = FindEmptyTextboxes(divText);
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
                //}
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
                btnSave_Click(sender, e);
                if (ErrorMsg == "")
                    Response.Redirect("~/User/CFE/CFEFuelNOC.aspx?Next=" + "N");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                if (ex.Message != "Thread was being aborted.")
                {
                    MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
                }

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

    }
}