using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.EnterpriseServices.Internal;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFE
{
    public partial class CFEWaterDetails : System.Web.UI.Page
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void GetAppliedorNot()
        {
            try
            {
                DataSet ds = new DataSet(); DataSet ds1 = new DataSet(); DataSet ds2 = new DataSet();
                ds = objcfebal.GetAppliedApprovalIDs(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]), Convert.ToString(Session["CFEQID"]), "15", "20,21,23");
                        //20  Certificate for non - availability of water supply from water supply agency
                        //21  Permission to Draw Water from River/ Public Tanks
                        //23  Grant of Water Connection to Non Municipal areas
                ds1 = objcfebal.GetAppliedApprovalIDs(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]), Convert.ToString(Session["CFEQID"]), "5", "19"); //NoC for Ground Water Abstraction for Commercial Connection
                ds2 = objcfebal.GetAppliedApprovalIDs(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]), Convert.ToString(Session["CFEQID"]), "2", "22"); //Water Connection for the Municipal Area 

                if (ds.Tables[0].Rows.Count > 0 || ds1.Tables[0].Rows.Count > 0 || ds2.Tables[0].Rows.Count > 0)
                {
                    BindDistrics();
                    Binddata();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //if(CFEDA_APPROVALID)
                        divNoNMunicipalWaterConnection.Visible = true; //approval id 23
                        divNonAvlbltyWaterCert.Visible = true; //approval id 20
                    }
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        divMunicipalWaterConnection.Visible = true;  //approval id 22
                    }

                }
                else
                {
                    if (Request.QueryString.Count > 0)
                    {
                        if (Convert.ToString(Request.QueryString[0]) == "N")
                            Response.Redirect("~/User/CFE/CFELabourDetails.aspx?Next=" + "N");
                        else if (Convert.ToString(Request.QueryString[0]) == "P")
                            Response.Redirect("~/User/CFE/CFEForestDetails.aspx?Previous=" + "P");
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
        protected void BindDistrics()
        {
            try
            {
                ddlwardno.Items.Clear();
                List<MasterDistricEST> objDistricESTModel = new List<MasterDistricEST>();

                objDistricESTModel = mstrBAL.GetDistricEST();
                if (objDistricESTModel != null)
                {
                    ddlwardno.DataSource = objDistricESTModel;
                    ddlwardno.DataValueField = "DISTRICEST_ID";
                    ddlwardno.DataTextField = "DISTRICEST_NAME";
                    ddlwardno.DataBind();
                }
                else
                {
                    ddlwardno.DataSource = null;
                    ddlwardno.DataBind();
                }
                AddSelect(ddlwardno);

            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public void Binddata()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfebal.GetWaterDetailos(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    /*txtwater.Text = ds.Tables[0].Rows[0]["CFEWD_WATERDRINK"].ToString();
                    txtIndustrial.Text = ds.Tables[0].Rows[0]["CFEWD_WATERPROCESS"].ToString();
                    txtQuantwater.Text = ds.Tables[0].Rows[0]["CFEWD_CONSUMPTIVEWATER"].ToString();
                    txtwaterReq.Text = ds.Tables[0].Rows[0]["CFEWD_NONCONSUMPTIVEWATER"].ToString();
                    rblwatercon.SelectedValue = ds.Tables[0].Rows[0]["CFEWD_WATERCONN"].ToString();
                    ObjCFEWater.Drinking_Water = txtwater.Text;
                    ObjCFEWater.water_Industrial = txtIndustrial.Text;
                    ObjCFEWater.Quantity_Water = txtQuantwater.Text;
                    ObjCFEWater.Non_Consumptive_water = txtwaterReq.Text; 
                    if (string.IsNullOrEmpty(txtwater.Text) || txtwater.Text == "" || txtwater.Text == null || txtwater.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtwater.Text, @"^0+(\.0+)?$"))
                    {
                        errormsg = errormsg + slno + ". Please Enter Drinking Water (KL/Day) \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtIndustrial.Text) || txtIndustrial.Text == "" || txtIndustrial.Text == null || txtIndustrial.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtIndustrial.Text, @"^0+(\.0+)?$"))
                    {
                        errormsg = errormsg + slno + ". Please Enter Water Industrial (KL/Day) \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtQuantwater.Text) || txtQuantwater.Text == "" || txtQuantwater.Text == null || txtQuantwater.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtQuantwater.Text, @"^0+(\.0+)?$"))
                    {
                        errormsg = errormsg + slno + ". Please Enter Quantity of Water Required for Consumptive (KL/Day) \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtwaterReq.Text) || txtwaterReq.Text == "" || txtwaterReq.Text == null || txtwaterReq.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtwaterReq.Text, @"^0+(\.0+)?$"))
                    {
                        errormsg = errormsg + slno + ". Please Enter Quantity of Water Required for Non-Consumptive (KL/Day) \\n";
                        slno = slno + 1;
                    }
                    */



                    if (rblwatercon.SelectedValue == "3")
                    {
                        holdno.Visible = false;
                    }
                    else
                    {
                        holdno.Visible = true;
                    }
                    txtholding.Text = ds.Tables[0].Rows[0]["CFEWD_HOLDINGNO"].ToString();
                    ddlwardno.Text = ds.Tables[0].Rows[0]["CFEWD_WARDNO"].ToString();
                    txtsubdivision.Text = ds.Tables[0].Rows[0]["CFEWD_DIVISIONAL"].ToString();
                    txtpremise.Text = ds.Tables[0].Rows[0]["CFEWD_NOOFPREMISE"].ToString();
                    txtdemand.Text = ds.Tables[0].Rows[0]["CFEWD_DEMANDPERDAY"].ToString();
                    txtinformation.Text = ds.Tables[0].Rows[0]["CFEWD_INFORMATION"].ToString();
                   
                    txtconnection.Text = ds.Tables[0].Rows[0]["CFEWD_PURPOSECON"].ToString();
                    ddlconnection.SelectedValue = ds.Tables[0].Rows[0]["CFEWD_TYPECONN"].ToString();
                    if (ddlconnection.SelectedValue == "Y")
                    {
                        NominalDN.Visible = true;
                        DiameterDN.Visible = false;
                    }
                    else
                    {
                        NominalDN.Visible = false;
                        DiameterDN.Visible = true;
                    }
                    ddlDiameter.SelectedItem.Text = ds.Tables[0].Rows[0]["CFEWD_DOMESTIC"].ToString();
                    ddlDN.SelectedValue = ds.Tables[0].Rows[0]["CFEWD_BULK"].ToString();
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        if (Convert.ToInt32(ds.Tables[1].Rows[i]["CFEA_MASTERAID"]) == 48)//
                        {
                            hypSketch.Visible = true;
                            hypSketch.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["FILELOCATION"]));
                            hypSketch.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
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
        protected void rblwatercon_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblwatercon.SelectedValue == "3")
                {
                    holdno.Visible = false;
                }
                else
                {
                    holdno.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblwatercon.BorderColor = System.Drawing.Color.White;
        }

        protected void ddlconnection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlconnection.SelectedValue != "N")
                {
                    NominalDN.Visible = true;
                    DiameterDN.Visible = false;
                }
                else
                {
                    NominalDN.Visible = false;
                    DiameterDN.Visible = true;
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

                ErrorMsg = Validations();
                if (ErrorMsg == "")
                {
                    Water_Details ObjCFEWater = new Water_Details();
                    ObjCFEWater.Questionnariid = Convert.ToString(Session["CFEQID"]);
                    ObjCFEWater.CreatedBy = hdnUserID.Value;
                    ObjCFEWater.UNITID = Convert.ToString(Session["CFEUNITID"]);
                    ObjCFEWater.IPAddress = getclientIP();

                    //ObjCFEWater.OVERHEAD = txtoverhead.Text;
                    //ObjCFEWater.UNDERGROUND = txtunderground.Text;
                    //ObjCFEWater.TANKER_CAPACITY = ddlTanker.SelectedValue;
                    ObjCFEWater.WATERCONNECTION = rblwatercon.SelectedValue;
                    ObjCFEWater.HOLDING = txtholding.Text;
                    ObjCFEWater.WARDNO = ddlwardno.SelectedValue;
                    ObjCFEWater.SUBDIVISION = txtsubdivision.Text;
                    ObjCFEWater.PREMISENUMBER = txtpremise.Text;
                    ObjCFEWater.WATERDEMAND = txtdemand.Text;
                    ObjCFEWater.ANYOTHERINFORMATION = txtinformation.Text;
                 
                    ObjCFEWater.PURPOSECONN = txtconnection.Text;
                    ObjCFEWater.TYPECON = ddlconnection.SelectedValue;
                    ObjCFEWater.DOMESTIC = ddlDiameter.SelectedValue;
                    ObjCFEWater.BULK = ddlDN.SelectedValue;

                    result = objcfebal.InsertCFEWaterDetails(ObjCFEWater);

                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "Water Details Submitted Successfully";
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
        public string Validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";


                if (rblwatercon.SelectedIndex == -1 || rblwatercon.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select water connection \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtsubdivision.Text) || txtsubdivision.Text == "" || txtsubdivision.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Sub Divisional Office for Application \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtpremise.Text) || txtpremise.Text == "" || txtpremise.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Number of persons working in the premise \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtdemand.Text) || txtdemand.Text == "" || txtdemand.Text == null || txtdemand.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtdemand.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Water requirement per day demand \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtinformation.Text) || txtinformation.Text == "" || txtinformation.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Any Information \\n";
                    slno = slno + 1;
                }
               
                if (string.IsNullOrEmpty(txtconnection.Text) || txtconnection.Text == "" || txtconnection.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter  \\n";
                    slno = slno + 1;
                }
                if (ddlconnection.SelectedIndex == -1 || ddlconnection.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select type connection \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypSketch.Text) || hypSketch.Text == "" || hypSketch.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Route Sketch Map \\n";
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
        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/CFE/CFEForestDetails.aspx?Previous=" + "P");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

        }

        protected void btnSketch_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupSketch.HasFile)
                {
                    Error = validations(fupSketch);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Route Sketch Map" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupSketch.PostedFile.SaveAs(serverpath + "\\" + fupSketch.PostedFile.FileName);

                        CFEAttachments objManufacture = new CFEAttachments();
                        objManufacture.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objManufacture.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objManufacture.MasterID = "48";
                        objManufacture.FilePath = serverpath + fupSketch.PostedFile.FileName;
                        objManufacture.FileName = fupSketch.PostedFile.FileName;
                        objManufacture.FileType = fupSketch.PostedFile.ContentType;
                        objManufacture.FileDescription = "Route Sketch Map";
                        objManufacture.CreatedBy = hdnUserID.Value;
                        objManufacture.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objManufacture);
                        if (result != "")
                        {
                            hypSketch.Text = fupSketch.PostedFile.FileName;
                            hypSketch.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objManufacture.FilePath);
                            hypSketch.Target = "blank";
                            message = "alert('" + "Route Sketch Map Uploaded successfully" + "')";
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
                //List<TextBox> emptyTextboxes = FindEmptyTextboxes(divText);
                //List<DropDownList> emptyDropdowns = FindEmptyDropdowns(divText);
                //List<RadioButtonList> emptyRadioButtonLists = FindEmptyRadioButtonLists(divText);

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
                    Response.Redirect("~/User/CFE/CFELabourDetails.aspx?Next=" + "N");

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
        protected void rblProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblProperty.SelectedItem.Text == "Leased")
                {
                    divProperty.Visible = true;
                }
                else { divProperty.Visible = false; }
            }
            catch (Exception ex)
            {

            }
        }
    }
}