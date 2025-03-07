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
using static AjaxControlToolkit.AsyncFileUpload.Constants;

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
                            divDistanceLetter.Visible = true;
                        }
                        if (Convert.ToString(ds.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "16")
                        {
                            divNonForestLand.Visible = true;
                        }
                        if (Convert.ToString(ds.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "24")
                        {
                            divTreeFelling.Visible = true;
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
        public void Binddata()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfebal.GetForestRetrive(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]));

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlForest.SelectedValue = ds.Tables[0].Rows[0]["CFEFD_FORESTDIVID"].ToString();
                    ddlLandType.SelectedValue = ds.Tables[0].Rows[0]["CFEFD_LANDTYPE"].ToString();
                    RblLatitude.SelectedValue = ds.Tables[0].Rows[0]["CFEFD_LATTITUDE"].ToString();
                    txtLatDegrees.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_LATDEGREES"]);
                    txtLatMinutes.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_LATMINUTES"]);
                    txtLatSeconds.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_LATSECONDS"]);
                    rblLongitude.SelectedValue = ds.Tables[0].Rows[0]["CFEFD_LONGITUDE"].ToString();
                    txtLongDegrees.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_LONGDEGREES"]);
                    txtLongMinutes.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_LONGMINUTES"]);
                    txtLongSeconds.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_LONGSECONDS"]);
                    txtGPSCordinates.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_GPSCOORDINATESDESC"]);
                    txtDistncLtrPurpose.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_DISTANCELTRPURPOSE"]);
                    txtInformation.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_INFORMATION"]);

                    txtLandArea.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_INFORMATION"]);
                    txtNFLPurpose.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_INFORMATION"]);
                    if (Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_LOPPINGPERMSN"]) != "")
                    {
                        chkPermType.Items[0].Selected = true;
                        txtLoppingPurpose.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_LOPPINGPURPOSE"]);
                        if (ds.Tables[3].Rows.Count > 0)
                        {
                            grdLopped.DataSource = ds.Tables[3];
                            grdLopped.DataBind();
                            ViewState["LopTrees"] = ds.Tables[3];
                        }
                        chkPermType_SelectedIndexChanged(null, EventArgs.Empty);
                    }
                    if (Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_FELLINGPERMSN"]) != "")
                    {
                        chkPermType.Items[1].Selected = true;
                        txtFellingPurpose.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEFD_FELLINPURPOSE"]);
                        if (ds.Tables[4].Rows.Count > 0)
                        {
                            grdFelled.DataSource = ds.Tables[4];
                            grdFelled.DataBind();
                            ViewState["FellTrees"] = ds.Tables[4];
                        }
                        chkPermType_SelectedIndexChanged(null, EventArgs.Empty);
                    }


                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                    {
                        if (Convert.ToInt32(ds.Tables[2].Rows[i]["CFEA_MASTERAID"]) == 33)
                        {
                            hypownership.Visible = true;
                            hypownership.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[2].Rows[i]["FILELOCATION"]));
                            hypownership.Text = Convert.ToString(ds.Tables[2].Rows[i]["CFEA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[2].Rows[i]["CFEA_MASTERAID"]) == 34)
                        {
                            hypland.Visible = true;
                            hypland.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[2].Rows[i]["FILELOCATION"]));
                            hypland.Text = Convert.ToString(ds.Tables[2].Rows[i]["CFEA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[2].Rows[i]["CFEA_MASTERAID"]) == 35)
                        {
                            hypNOCLand.Visible = true;
                            hypNOCLand.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[2].Rows[i]["FILELOCATION"]));
                            hypNOCLand.Text = Convert.ToString(ds.Tables[2].Rows[i]["CFEA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[2].Rows[i]["CFEA_MASTERAID"]) == 36)
                        {
                            hypforestdfo.Visible = true;
                            hypforestdfo.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[2].Rows[i]["FILELOCATION"]));
                            hypforestdfo.Text = Convert.ToString(ds.Tables[2].Rows[i]["CFEA_FILENAME"]);
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


        protected void chkPermType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkPermType.Items[0].Selected == true)
                divLopped.Visible = true;
            else divLopped.Visible = false;
            if (chkPermType.Items[1].Selected == true)
                divFelled.Visible = true;
            else divFelled.Visible = false;
        }
        protected void btnAddLopp_Click(object sender, EventArgs e)
        {
            try
            {

                string ErrorMsg = ""; int slno = 0;
                if (string.IsNullOrEmpty(txtLopLocName.Text.Trim()) || txtLopLocName.Text.Trim() == "" || txtLopLocName.Text.Trim() == null)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Local Name of the Tree \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLopScfName.Text.Trim()) || txtLopScfName.Text.Trim() == "" || txtLopScfName.Text.Trim() == null)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Scientific Name of the Tree \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLopTreeCount.Text.Trim()) || txtLopTreeCount.Text.Trim() == "" || txtLopTreeCount.Text.Trim() == null)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter No.of Trees \\n";
                    slno = slno + 1;
                }

                if (ErrorMsg == "")
                {

                    DataTable dt = new DataTable();
                    dt.Columns.Add("CFELP_LOCALNAME", typeof(string));
                    dt.Columns.Add("CFELP_SCIENTIFICNAME", typeof(string));
                    dt.Columns.Add("CFELP_NOOFTREES", typeof(string));


                    if (ViewState["LopTrees"] != null)
                    {
                        dt = (DataTable)ViewState["LopTrees"];
                    }
                    DataRow dr = dt.NewRow();

                    dr["CFELP_LOCALNAME"] = txtLopLocName.Text.Trim();
                    dr["CFELP_SCIENTIFICNAME"] = txtLopScfName.Text.Trim();
                    dr["CFELP_NOOFTREES"] = txtLopTreeCount.Text.Trim();


                    dt.Rows.Add(dr);
                    grdLopped.Visible = true;
                    grdLopped.DataSource = dt;
                    grdLopped.DataBind();
                    ViewState["LopTrees"] = dt;

                    txtLopLocName.Text = "";
                    txtLopScfName.Text = "";
                    txtLopTreeCount.Text = "";

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
        protected void btnAddFell_Click(object sender, EventArgs e)
        {
            try
            {

                string ErrorMsg = ""; int slno = 0;
                if (string.IsNullOrEmpty(txtFellLocName.Text.Trim()) || txtFellLocName.Text.Trim() == "" || txtFellLocName.Text.Trim() == null)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Local Name of the Tree \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtFellScfName.Text.Trim()) || txtFellScfName.Text.Trim() == "" || txtFellScfName.Text.Trim() == null)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Scientific Name of the Tree \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtFellTreeCount.Text.Trim()) || txtFellTreeCount.Text.Trim() == "" || txtFellTreeCount.Text.Trim() == null)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter No.of Trees \\n";
                    slno = slno + 1;
                }

                if (ErrorMsg == "")
                {

                    DataTable dt = new DataTable();
                    dt.Columns.Add("CFEFL_LOCALNAME", typeof(string));
                    dt.Columns.Add("CFEFL_SCIENTIFICNAME", typeof(string));
                    dt.Columns.Add("CFEFL_NOOFTREES", typeof(string));


                    if (ViewState["FellTrees"] != null)
                    {
                        dt = (DataTable)ViewState["FellTrees"];
                    }
                    DataRow dr = dt.NewRow();

                    dr["CFEFL_LOCALNAME"] = txtFellLocName.Text.Trim();
                    dr["CFEFL_SCIENTIFICNAME"] = txtFellScfName.Text.Trim();
                    dr["CFEFL_NOOFTREES"] = txtFellTreeCount.Text.Trim();

                    dt.Rows.Add(dr);
                    grdFelled.Visible = true;
                    grdFelled.DataSource = dt;
                    grdFelled.DataBind();
                    ViewState["LopTrees"] = dt;

                    txtFellLocName.Text = "";
                    txtFellScfName.Text = "";
                    txtFellTreeCount.Text = "";

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
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "ownership of land" + "\\";
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
                            hypownership.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objManufacture.FilePath);
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
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Rough map of the concerned land" + "\\";
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
                            hypland.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objManufacture.FilePath);
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
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "NoC from the concerned Autonomous District Council" + "\\";
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
                            hypNOCLand.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objManufacture.FilePath);
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
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Distance from Forest Certificate from DFO" + "\\";
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
                            hypforestdfo.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objManufacture.FilePath);
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


                    objCFEQForest.ForestDivision = ddlForest.SelectedValue;
                    objCFEQForest.LandType = ddlLandType.SelectedValue;
                    objCFEQForest.Lattitude = RblLatitude.SelectedValue;
                    objCFEQForest.LatDegrees = txtLatDegrees.Text;
                    objCFEQForest.LatMinutes = txtLatMinutes.Text;
                    objCFEQForest.LatSeconds = txtLatSeconds.Text;
                    objCFEQForest.Longitude = rblLongitude.SelectedValue;
                    objCFEQForest.LongDegrees = txtLongDegrees.Text;
                    objCFEQForest.LongMinutes = txtLongMinutes.Text;
                    objCFEQForest.LongSeconds = txtLongSeconds.Text;
                    objCFEQForest.GPSCoodinates = txtGPSCordinates.Text;
                    objCFEQForest.DistncLtrPurpose = txtDistncLtrPurpose.Text;
                    objCFEQForest.Information = txtInformation.Text;

                    objCFEQForest.NFLPurpose = txtNFLPurpose.Text;
                    objCFEQForest.LandArea = txtLandArea.Text;
                    if (chkPermType.Items[0].Selected == true)
                        objCFEQForest.LoppPermType = "Tree Lopping Permission Required";
                    if (chkPermType.Items[1].Selected == true)
                        objCFEQForest.FellPermType = "Tree Felling Permission Required";

                    objCFEQForest.FellPermPurpose = txtFellingPurpose.Text;
                    objCFEQForest.LoppPermPurpose = txtLoppingPurpose.Text;

                    result = objcfebal.InsertCFEForestDet(objCFEQForest);

                    if (result != "")
                    {
                        int count1 = 0, count2 = 0;
                        if (grdLopped.Rows.Count > 0)
                        {
                            for (int i = 0; i < grdLopped.Rows.Count; i++)
                            {

                                objCFEQForest.Questionnariid = Convert.ToString(Session["CFEQID"]);

                                objCFEQForest.UNITID = Convert.ToString(Session["CFEUNITID"]);
                                objCFEQForest.LocalName = grdLopped.Rows[i].Cells[1].Text.Trim();
                                objCFEQForest.ScfcName = grdLopped.Rows[i].Cells[2].Text;
                                objCFEQForest.NoofTrees = grdLopped.Rows[i].Cells[3].Text;
                                objCFEQForest.CreatedBy = hdnUserID.Value;
                                objCFEQForest.IPAddress = getclientIP();

                                string A = objcfebal.InsertCFETreesLopped(objCFEQForest);
                                if (A != "")
                                { count1 = count1 + 1; }
                            }
                        }
                        if (grdFelled.Rows.Count > 0)
                        {
                            for (int i = 0; i < grdFelled.Rows.Count; i++)
                            {

                                objCFEQForest.Questionnariid = Convert.ToString(Session["CFEQID"]);

                                objCFEQForest.UNITID = Convert.ToString(Session["CFEUNITID"]);
                                objCFEQForest.LocalName = grdFelled.Rows[i].Cells[1].Text.Trim();
                                objCFEQForest.ScfcName = grdFelled.Rows[i].Cells[2].Text;
                                objCFEQForest.NoofTrees = grdFelled.Rows[i].Cells[3].Text;
                                objCFEQForest.CreatedBy = hdnUserID.Value;
                                objCFEQForest.IPAddress = getclientIP();

                                string A = objcfebal.InsertCFETreesFelled(objCFEQForest);
                                if (A != "")
                                { count2 = count2 + 1; }
                            }
                        }
                        if (grdLopped.Rows.Count == count1 && grdFelled.Rows.Count == count2)
                        {
                            success.Visible = true;
                            lblmsg.Text = "Forest Details Submitted Successfully";
                            string message = "alert('" + lblmsg.Text + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
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
        public string Validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                List<TextBox> emptyTextboxes = FindEmptyTextboxes(divText);
                List<DropDownList> emptyDropdowns = FindEmptyDropdowns(divText);
                List<RadioButtonList> emptyRadioButtonLists = FindEmptyRadioButtonLists(divText);

                if (ddlForest.SelectedValue == "0" || ddlForest.SelectedValue == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Forest Division \\n";
                    slno = slno + 1;
                }
                if (ddlLandType.SelectedValue == "0" || ddlLandType.SelectedValue == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Land Type \\n";
                    slno = slno + 1;
                }
                if (divDistanceLetter.Visible == true)
                {
                    if (RblLatitude.SelectedIndex == -1)
                    {
                        errormsg = errormsg + slno + ". Please Select GPS Coordinates Latitude \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtLatDegrees.Text.Trim()) || txtLatDegrees.Text.Trim() == "" || txtLatDegrees.Text.Trim() == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Latitude Degrees \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtLatMinutes.Text.Trim()) || txtLatMinutes.Text.Trim() == "" || txtLatMinutes.Text.Trim() == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Latitude Minutes \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtLatSeconds.Text.Trim()) || txtLatSeconds.Text.Trim() == "" || txtLatSeconds.Text.Trim() == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Latitude Seconds \\n";
                        slno = slno + 1;
                    }

                    if (rblLongitude.SelectedIndex == -1)
                    {
                        errormsg = errormsg + slno + ". Please Select GPS Coordinates Longitude \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtLongDegrees.Text.Trim()) || txtLongDegrees.Text.Trim() == "" || txtLongDegrees.Text.Trim() == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Longitude Degrees \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtLongMinutes.Text.Trim()) || txtLongMinutes.Text.Trim() == "" || txtLongMinutes.Text.Trim() == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Longitude Minutes \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtLongSeconds.Text.Trim()) || txtLongSeconds.Text.Trim() == "" || txtLongSeconds.Text.Trim() == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Longitude Seconds \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtGPSCordinates.Text.Trim()) || txtGPSCordinates.Text.Trim() == "" || txtGPSCordinates.Text.Trim() == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter GPS Cordinates Description \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtDistncLtrPurpose.Text.Trim()) || txtDistncLtrPurpose.Text.Trim() == "" || txtDistncLtrPurpose.Text.Trim() == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Purpose of Application \\n";
                        slno = slno + 1;
                    }

                    if (string.IsNullOrEmpty(txtInformation.Text.Trim()) || txtInformation.Text.Trim() == "" || txtInformation.Text.Trim() == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Information \\n";
                        slno = slno + 1;
                    }
                }
                if (divNonForestLand.Visible == true)
                {
                    if (string.IsNullOrEmpty(txtLandArea.Text.Trim()) || txtLandArea.Text.Trim() == "" || txtLandArea.Text.Trim() == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Information \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtNFLPurpose.Text.Trim()) || txtNFLPurpose.Text.Trim() == "" || txtNFLPurpose.Text.Trim() == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Information \\n";
                        slno = slno + 1;
                    }
                }
                if (divTreeFelling.Visible == true)
                {
                    if (chkPermType.Items[0].Selected == false && chkPermType.Items[1].Selected == false)
                    {
                        errormsg = errormsg + slno + ". Please select type of permssion required \\n";
                        slno = slno + 1;

                    }
                    if (chkPermType.Items[0].Selected == true)
                    {

                        if (string.IsNullOrEmpty(txtFellingPurpose.Text.Trim()) || txtFellingPurpose.Text.Trim() == "" || txtFellingPurpose.Text.Trim() == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter Purpose of tree Felling \\n";
                            slno = slno + 1;
                        }
                        if (grdFelled.Rows.Count == 0)
                        {
                            errormsg = errormsg + slno + ". Please Enter the Details Of Trees to be felled \\n";
                            slno = slno + 1;
                        }
                    }
                    if (chkPermType.Items[1].Selected == true)
                    {
                        if (string.IsNullOrEmpty(txtLoppingPurpose.Text.Trim()) || txtLoppingPurpose.Text.Trim() == "" || txtLoppingPurpose.Text.Trim() == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter Purpose of tree Branches Lopping/Cutting \\n";
                            slno = slno + 1;
                        }
                        if (grdLopped.Rows.Count == 0)
                        {
                            errormsg = errormsg + slno + ". Please Enter the Details of trees whose branches are to be Lopped \\n";
                            slno = slno + 1;
                        }
                    }

                }
                if (string.IsNullOrEmpty(hypownership.Text) || hypownership.Text == "" || hypownership.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Proof of ownership of land \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypland.Text) || hypland.Text == "" || hypland.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Rough map of the concerned land \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypNOCLand.Text) || hypNOCLand.Text == "" || hypNOCLand.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload NoC from the concerned Autonomous District Council for land \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypforestdfo.Text) || hypforestdfo.Text == "" || hypforestdfo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Distance from Forest Certificate from DFO \\n";
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
                Response.Redirect("~/User/CFE/CFEPowerCEIGDetails.aspx?Previous=" + "P");
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
                if (ErrorMsg == "")
                    Response.Redirect("~/User/CFE/CFEWaterDetails.aspx?Next=" + "N");

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
        protected List<DropDownList> FindEmptyDropdowns(Control container)
        {
            List<DropDownList> emptyDropdowns = new List<DropDownList>();

            foreach (Control control in container.Controls)
            {
                if (control is DropDownList)
                {
                    DropDownList dropdown = (DropDownList)control;
                    if (string.IsNullOrWhiteSpace(dropdown.SelectedValue) || dropdown.SelectedValue == "" || dropdown.SelectedItem.Text == "--Select--" || dropdown.SelectedIndex == -1)
                    {
                        emptyDropdowns.Add(dropdown);
                        dropdown.BorderColor = System.Drawing.Color.Red;
                    }
                }

                if (control.HasControls())
                {
                    emptyDropdowns.AddRange(FindEmptyDropdowns(control));
                }
            }

            return emptyDropdowns;
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