using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
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
                        BindDistric();
                        BindDistricEST();
                        Binddata();
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
                ds1 = objcfebal.GetAppliedApprovalIDs(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]), Convert.ToString(Session["CFEQID"]), "5", "19");
                ds2 = objcfebal.GetAppliedApprovalIDs(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]), Convert.ToString(Session["CFEQID"]), "2", "22");

                if (ds.Tables[0].Rows.Count > 0 || ds1.Tables[0].Rows.Count > 0 || ds2.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    { }

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
        protected void BindDistricEST()
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
        protected void BindDistric()
        {
            try
            {
                ddldistric.Items.Clear();
                ddlmandal.Items.Clear();
                ddlvillage.Items.Clear();

                List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();
                string strmode = string.Empty;

                strmode = "";

                objDistrictModel = mstrBAL.GetDistrcits();
                if (objDistrictModel != null)
                {
                    ddldistric.DataSource = objDistrictModel;
                    ddldistric.DataValueField = "DistrictId";
                    ddldistric.DataTextField = "DistrictName";
                    ddldistric.DataBind();
                }
                else
                {
                    ddldistric.DataSource = null;
                    ddldistric.DataBind();

                    ddldistric.DataSource = null;
                    ddldistric.DataBind();
                }
                AddSelect(ddldistric);
                AddSelect(ddlmandal);
                AddSelect(ddlvillage);
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
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
                    txtwater.Text = ds.Tables[0].Rows[0]["CFEWD_WATERDRINK"].ToString();
                    txtIndustrial.Text = ds.Tables[0].Rows[0]["CFEWD_WATERPROCESS"].ToString();
                    txtQuantwater.Text = ds.Tables[0].Rows[0]["CFEWD_CONSUMPTIVEWATER"].ToString();
                    txtwaterReq.Text = ds.Tables[0].Rows[0]["CFEWD_NONCONSUMPTIVEWATER"].ToString();
                    rblwatercon.SelectedValue = ds.Tables[0].Rows[0]["CFEWD_WATERCONN"].ToString();
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
                    ddldistric.Text = ds.Tables[0].Rows[0]["CFEWD_DISTRIC"].ToString();
                    ddldistric_SelectedIndexChanged(null, EventArgs.Empty);
                    ddlmandal.Text = ds.Tables[0].Rows[0]["CFEWD_MANDAL"].ToString();
                    ddlmandal_SelectedIndexChanged(null, EventArgs.Empty);
                    ddlvillage.Text = ds.Tables[0].Rows[0]["CFEWD_VILLAGE"].ToString();
                    txtlocality.Text = ds.Tables[0].Rows[0]["CFEWD_LOCALITY"].ToString();
                    txtlandmark.Text = ds.Tables[0].Rows[0]["CFEWD_LANDMARK"].ToString();
                    txtpincode.Text = ds.Tables[0].Rows[0]["CFEWD_PINCODE"].ToString();
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

        protected void ddldistric_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlmandal.ClearSelection();
                ddlmandal.Items.Clear();
                AddSelect(ddlmandal);
                ddlvillage.ClearSelection();
                ddlvillage.Items.Clear();
                AddSelect(ddlvillage);
                if (ddldistric.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlmandal, ddldistric.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void ddlmandal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlvillage.ClearSelection();
                ddlvillage.Items.Clear();
                AddSelect(ddlvillage);
                if (ddlmandal.SelectedItem.Text != "--Select--")
                {

                    BindVillages(ddlvillage, ddlmandal.SelectedValue);
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
                    ObjCFEWater.Drinking_Water = txtwater.Text;
                    ObjCFEWater.water_Industrial = txtIndustrial.Text;
                    ObjCFEWater.Quantity_Water = txtQuantwater.Text;
                    ObjCFEWater.Non_Consumptive_water = txtwaterReq.Text;
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
                    ObjCFEWater.DISTRIC = ddldistric.SelectedValue;
                    ObjCFEWater.MANDAL = ddlmandal.SelectedValue;
                    ObjCFEWater.VILLAGE = ddlvillage.SelectedValue;
                    ObjCFEWater.LOCALITY = txtlocality.Text;
                    ObjCFEWater.LANDMARK = txtlandmark.Text;
                    ObjCFEWater.PINCODE = txtpincode.Text;
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
                if (ddldistric.SelectedIndex == -1 || ddldistric.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Distric \\n";
                    slno = slno + 1;
                }
                if (ddlmandal.SelectedIndex == -1 || ddlmandal.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Mandal \\n";
                    slno = slno + 1;
                }
                if (ddlvillage.SelectedIndex == -1 || ddlvillage.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Village \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtlocality.Text) || txtlocality.Text == "" || txtlocality.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter locality  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtlandmark.Text) || txtlandmark.Text == "" || txtlandmark.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Landmark \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtpincode.Text) || txtpincode.Text == "" || txtpincode.Text == null || txtpincode.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtpincode.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Picode \\n";
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
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Route Sketch Map" + "\\");
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
                            hypSketch.NavigateUrl = serverpath;
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
                int slno = 1; string Error = "";
                if (Attachment.PostedFile.ContentType != "application/pdf"
                     || !ValidateFileName(Attachment.PostedFile.FileName) || !ValidateFileExtension(Attachment))
                {

                    if (Attachment.PostedFile.ContentType != "application/pdf")
                    {
                        Error = Error + slno + ". Please Upload PDF Documents only \\n";
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
            }
        }
    }
}