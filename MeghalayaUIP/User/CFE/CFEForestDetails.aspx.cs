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
    public partial class CFEForestDetails : System.Web.UI.Page
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
                        BindDivisionForest();
                        Binddata();

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
                ds = objcfebal.GetAppliedApprovalIDs(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]), Convert.ToString(Session["CFEQID"]), "4", "");


                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (Convert.ToString(ds.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "15")
                        {

                        }
                        if (Convert.ToString(ds.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "16")
                        {

                        }

                    }
                }
                else
                {
                    if (Request.QueryString.Count > 0)
                    {
                        if (Convert.ToString(Request.QueryString[0]) == "N")
                            Response.Redirect("~/User/CFE/CFEWaterDetails.aspx?Next=" + "N");
                        else if (Convert.ToString(Request.QueryString[0]) == "P")
                            Response.Redirect("~/User/CFE/CFEPowerCEIGDetails.aspx?Previous=" + "P");
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
                string errormsg = "";
                if (string.IsNullOrEmpty(txtspecies.Text.Trim()) || txtspecies.Text.Trim() == "" || txtspecies.Text.Trim() == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Species \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtTimberlength.Text) || txtTimberlength.Text == "" || txtTimberlength.Text == null || txtTimberlength.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtTimberlength.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Length Of Timber (in Meters) \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtTimberVolume.Text) || txtTimberVolume.Text == "" || txtTimberVolume.Text == null || txtTimberVolume.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtTimberVolume.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter  Volume Of Timber (in Meters) \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtGirth.Text) || txtGirth.Text == "" || txtGirth.Text == null || txtGirth.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtGirth.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Girth (in Meters) \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEstimated.Text) || txtEstimated.Text == "" || txtEstimated.Text == null || txtEstimated.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtEstimated.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Firewood/Rootwood/Faggot \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtpole.Text) || txtpole.Text == "" || txtpole.Text == null || txtpole.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtpole.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter No of Pole \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNorth.Text) || txtNorth.Text == "" || txtNorth.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter North \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEast.Text) || txtEast.Text == "" || txtEast.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter East \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtWest.Text) || txtWest.Text == "" || txtWest.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter West \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtSouth.Text) || txtSouth.Text == "" || txtSouth.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter South \\n";
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
                ds = objcfebal.GetForestRetrive(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]));

                if (ds.Tables[0].Rows.Count > 0)
                {
                    //ViewState["UnitID"] = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_UNITID"]);
                    txtAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_ADDRESS"]);
                    RblLatitude.SelectedValue = ds.Tables[0].Rows[0]["CFEFD_LATTITUDE"].ToString();
                    txtLatDegrees.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_DEGREES"]);
                    txtLatMinutes.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_MINUTES"]);
                    txtLatSeconds.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_SECONDS"]);
                    rblLongitude.SelectedValue = ds.Tables[0].Rows[0]["CFEFD_LONGITUDE"].ToString();
                    txtLongDegrees.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_DEGREE"]);
                    txtLongMinutes.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_MINUTE"]);
                    txtLongSeconds.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_SECOND"]);
                    txtGPSCordinates.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_GPSCOORDINATES"]);
                    txtPurpose.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_PURPOSEAPPLICATION"]);
                    ddlForest.SelectedValue = ds.Tables[0].Rows[0]["CFEFD_FORESTDIVISION"].ToString();
                    txtInformation.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_INFORMATION"]);

                    txtspecies.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_SPECIES"]);
                    txtTimberlength.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_TIMBERLENGTH"]);
                    txtTimberVolume.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_TIMBERVOLUME"]);
                    txtGirth.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_GIRTH"]);
                    txtEstimated.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_ESTIMATED"]);
                    txtpole.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_POLES"]);

                    txtNorth.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_NORTH"]);
                    txtEast.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_EAST"]);
                    txtWest.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_WEST"]);
                    txtSouth.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_SOUTH"]);
                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindDivisionForest()
        {
            try
            {
                ddlForest.Items.Clear();

                List<MasterForestDivision> objStatesModel = new List<MasterForestDivision>();

                objStatesModel = mstrBAL.GetForestDivision();
                if (objStatesModel != null)
                {
                    ddlForest.DataSource = objStatesModel;
                    ddlForest.DataValueField = "FORESTDIV_ID";
                    ddlForest.DataTextField = "FORESTDIV_NAME";
                    ddlForest.DataBind();
                }
                else
                {
                    ddlForest.DataSource = null;
                    ddlForest.DataBind();
                }
                AddSelect(ddlForest);
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                ErrorMsg = Validations();
                if (ErrorMsg == "")
                {
                    Forest_Details objCFEQForest = new Forest_Details();

                    objCFEQForest.UNITID = Convert.ToString(Session["CFEUNITID"]);
                    objCFEQForest.CreatedBy = hdnUserID.Value;
                    objCFEQForest.IPAddress = getclientIP();
                    objCFEQForest.Questionnariid = Convert.ToString(Session["CFEQID"]);
                    objCFEQForest.UnitId = Convert.ToString(Session["CFEUNITID"]);
                    objCFEQForest.Address = txtAddress.Text.Trim();
                    objCFEQForest.Lattitude = RblLatitude.SelectedValue;
                    objCFEQForest.LatDegrees = txtLatDegrees.Text;
                    objCFEQForest.LatMinutes = txtLatMinutes.Text;
                    objCFEQForest.LatSeconds = txtLatSeconds.Text;
                    objCFEQForest.Longitude = rblLongitude.SelectedValue;
                    objCFEQForest.LongDegrees = txtLongDegrees.Text;
                    objCFEQForest.LongMinutes = txtLongMinutes.Text;
                    objCFEQForest.LongSeconds = txtLongSeconds.Text;
                    objCFEQForest.GPSCoodinates = txtGPSCordinates.Text;
                    objCFEQForest.Purpose = txtPurpose.Text;
                    objCFEQForest.ForestDivision = ddlForest.SelectedValue;
                    objCFEQForest.information = txtInformation.Text;
                    objCFEQForest.Species = txtspecies.Text.Trim();
                    objCFEQForest.EstTimberLength = txtTimberlength.Text;
                    objCFEQForest.EstTimberVolume = txtTimberVolume.Text;
                    objCFEQForest.Girth = txtGirth.Text;
                    objCFEQForest.Est_Firewood = txtEstimated.Text;
                    objCFEQForest.No_Poles = txtpole.Text;
                    objCFEQForest.North = txtNorth.Text;
                    objCFEQForest.East = txtEast.Text;
                    objCFEQForest.West = txtWest.Text;
                    objCFEQForest.South = txtSouth.Text;

                    result = objcfebal.InsertCFEForestDet(objCFEQForest);

                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "Forest Details Submitted Successfully";
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
        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/CFE/CFEPowerCEIGDetails.aspx?Previous=" + "P");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        //protected void btnGPS_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string Error = ""; string message = "";
        //        if (fupGPS.HasFile)
        //        {
        //            Error = validations(fupGPS);
        //            if (Error == "")
        //            {
        //                string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
        //                 + Convert.ToString(Session["CFEQID"]) + "\\" + "GPS Coordinates" + "\\");
        //                if (!Directory.Exists(serverpath))
        //                {
        //                    Directory.CreateDirectory(serverpath);

        //                }
        //                fupGPS.PostedFile.SaveAs(serverpath + "\\" + fupGPS.PostedFile.FileName);

        //                CFEAttachments objManufacture = new CFEAttachments();
        //                objManufacture.UNITID = Convert.ToString(Session["CFEUNITID"]);
        //                objManufacture.Questionnareid = Convert.ToString(Session["CFEQID"]);
        //                objManufacture.MasterID = "33";
        //                objManufacture.FilePath = serverpath + fupGPS.PostedFile.FileName;
        //                objManufacture.FileName = fupGPS.PostedFile.FileName;
        //                objManufacture.FileType = fupGPS.PostedFile.ContentType;
        //                objManufacture.FileDescription = "GPS Coordinates";
        //                objManufacture.CreatedBy = hdnUserID.Value;
        //                objManufacture.IPAddress = getclientIP();
        //                result = objcfebal.InsertCFEAttachments(objManufacture);
        //                if (result != "")
        //                {
        //                    hypGPS.Text = fupGPS.PostedFile.FileName;
        //                    hypGPS.NavigateUrl = serverpath;
        //                    hypGPS.Target = "blank";
        //                    message = "alert('" + "GPS Coordinates Uploaded successfully" + "')";
        //                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        //                }
        //            }
        //            else
        //            {
        //                message = "alert('" + Error + "')";
        //                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        //            }
        //        }
        //        else
        //        {
        //            message = "alert('" + "Please Upload Document" + "')";
        //            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblmsg0.Text = ex.Message; Failure.Visible = true;
        //        MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
        //    }
        //}

        protected void btnownership_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupOwnership.HasFile)
                {
                    Error = validations(fupOwnership);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "ownership of land" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupOwnership.PostedFile.SaveAs(serverpath + "\\" + fupOwnership.PostedFile.FileName);

                        CFEAttachments objManufacture = new CFEAttachments();
                        objManufacture.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objManufacture.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objManufacture.MasterID = "33";
                        objManufacture.FilePath = serverpath + fupOwnership.PostedFile.FileName;
                        objManufacture.FileName = fupOwnership.PostedFile.FileName;
                        objManufacture.FileType = fupOwnership.PostedFile.ContentType;
                        objManufacture.FileDescription = "Lease deed or Agreement of Sale or any related";
                        objManufacture.CreatedBy = hdnUserID.Value;
                        objManufacture.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objManufacture);
                        if (result != "")
                        {
                            hypownership.Text = fupOwnership.PostedFile.FileName;
                            hypownership.NavigateUrl = serverpath;
                            hypownership.Target = "blank";
                            message = "alert('" + "Lease deed or Agreement of Sale or any related Uploaded successfully" + "')";
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

        protected void btnland_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupland.HasFile)
                {
                    Error = validations(fupland);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Rough map of the concerned land" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupland.PostedFile.SaveAs(serverpath + "\\" + fupland.PostedFile.FileName);

                        CFEAttachments objManufacture = new CFEAttachments();
                        objManufacture.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objManufacture.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objManufacture.MasterID = "34";
                        objManufacture.FilePath = serverpath + fupland.PostedFile.FileName;
                        objManufacture.FileName = fupland.PostedFile.FileName;
                        objManufacture.FileType = fupland.PostedFile.ContentType;
                        objManufacture.FileDescription = "Rough map of the concerned land";
                        objManufacture.CreatedBy = hdnUserID.Value;
                        objManufacture.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objManufacture);
                        if (result != "")
                        {
                            hypland.Text = fupland.PostedFile.FileName;
                            hypland.NavigateUrl = serverpath;
                            hypland.Target = "blank";
                            message = "alert('" + "Rough map of the concerned land Uploaded successfully" + "')";
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

        protected void btnNOCLand_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupNOCLand.HasFile)
                {
                    Error = validations(fupNOCLand);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "NoC from the concerned Autonomous District Council" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupNOCLand.PostedFile.SaveAs(serverpath + "\\" + fupNOCLand.PostedFile.FileName);

                        CFEAttachments objManufacture = new CFEAttachments();
                        objManufacture.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objManufacture.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objManufacture.MasterID = "35";
                        objManufacture.FilePath = serverpath + fupNOCLand.PostedFile.FileName;
                        objManufacture.FileName = fupNOCLand.PostedFile.FileName;
                        objManufacture.FileType = fupNOCLand.PostedFile.ContentType;
                        objManufacture.FileDescription = "NoC from the concerned Autonomous District Council for land";
                        objManufacture.CreatedBy = hdnUserID.Value;
                        objManufacture.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objManufacture);
                        if (result != "")
                        {
                            hypNOCLand.Text = fupNOCLand.PostedFile.FileName;
                            hypNOCLand.NavigateUrl = serverpath;
                            hypNOCLand.Target = "blank";
                            message = "alert('" + "NoC from the concerned Autonomous District Council for land use Uploaded successfully" + "')";
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

        protected void btnforestdfo_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupForestDFO.HasFile)
                {
                    Error = validations(fupForestDFO);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Distance from Forest Certificate from DFO" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupForestDFO.PostedFile.SaveAs(serverpath + "\\" + fupForestDFO.PostedFile.FileName);

                        CFEAttachments objManufacture = new CFEAttachments();
                        objManufacture.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objManufacture.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objManufacture.MasterID = "36";
                        objManufacture.FilePath = serverpath + fupForestDFO.PostedFile.FileName;
                        objManufacture.FileName = fupForestDFO.PostedFile.FileName;
                        objManufacture.FileType = fupForestDFO.PostedFile.ContentType;
                        objManufacture.FileDescription = "Distance from Forest Certificate from DFO (Wild-life)";
                        objManufacture.CreatedBy = hdnUserID.Value;
                        objManufacture.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objManufacture);
                        if (result != "")
                        {
                            hypforestdfo.Text = fupForestDFO.PostedFile.FileName;
                            hypforestdfo.NavigateUrl = serverpath;
                            hypforestdfo.Target = "blank";
                            message = "alert('" + "Distance from Forest Certificate from DFO (Wild-life) Uploaded successfully" + "')";
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
                    Response.Redirect("~/User/CFE/CFEWaterDetails.aspx?Next=" + "N");

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
    }
}