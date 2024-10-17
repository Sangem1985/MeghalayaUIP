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
    public partial class CFEPowerCEIGDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFEBAL objcfebal = new CFEBAL();
        string UnitID, result, ErrorMsg = "";

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
                DataSet ds = new DataSet();
                ds = objcfebal.GetAppliedApprovalIDs(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]), Convert.ToString(Session["CFEQID"]), "18", "14");


                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (Convert.ToString(ds.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "14")
                        {
                            BindDistricts();
                            GetElectricRegulations();
                            GetVoltageMaster();
                            GetPowerPlants();
                            Binddata();
                            BindAttachments();
                        }

                    }
                }
                else
                {
                    if (Request.QueryString.Count > 0)
                    {
                        if (Convert.ToString(Request.QueryString[0]) == "N")
                            Response.Redirect("~/User/CFE/CFEFireDetails.aspx?Next=" + "N");
                        else if (Convert.ToString(Request.QueryString[0]) == "P")
                            Response.Redirect("~/User/CFE/CFEPowerDetails.aspx?Previous=" + "P");
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindDistricts()
        {
            try
            {

                ddlDistrict.Items.Clear();
                ddlMandal.Items.Clear();
                ddlVillage.Items.Clear();

                List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();
                string strmode = string.Empty;
                strmode = "";
                objDistrictModel = mstrBAL.GetDistrcits();
                if (objDistrictModel != null)
                {
                    ddlDistrict.DataSource = objDistrictModel;
                    ddlDistrict.DataValueField = "DistrictId";
                    ddlDistrict.DataTextField = "DistrictName";
                    ddlDistrict.DataBind();
                }
                else
                {
                    ddlDistrict.DataSource = null;
                    ddlDistrict.DataBind();
                }
                AddSelect(ddlDistrict);
                AddSelect(ddlMandal);
                AddSelect(ddlVillage);

            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
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
        protected void GetElectricRegulations()
        {
            try
            {
                ddlRegulation.Items.Clear();

                List<MasterElecRegulations> objElReg = new List<MasterElecRegulations>();

                objElReg = mstrBAL.GetElectricRegulations();
                if (objElReg != null)
                {
                    ddlRegulation.DataSource = objElReg;
                    ddlRegulation.DataValueField = "ElRegID";
                    ddlRegulation.DataTextField = "ElRegNumber";
                    ddlRegulation.DataBind();
                }
                else
                {
                    ddlRegulation.DataSource = null;
                    ddlRegulation.DataBind();
                }
                AddSelect(ddlRegulation);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void GetVoltageMaster()
        {
            try
            {
                ddlvtg.Items.Clear();

                List<MasterVoltages> objVolt = new List<MasterVoltages>();

                objVolt = mstrBAL.GetVoltages();
                if (objVolt != null)
                {
                    ddlvtg.DataSource = objVolt;
                    ddlvtg.DataValueField = "VoltageID";
                    ddlvtg.DataTextField = "VoltageValue";
                    ddlvtg.DataBind();
                }
                else
                {
                    ddlvtg.DataSource = null;
                    ddlvtg.DataBind();
                }
                AddSelect(ddlvtg);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void GetPowerPlants()
        {
            try
            {
                ddlPlant.Items.Clear();

                List<MasterPowerPlants> objplants = new List<MasterPowerPlants>();

                objplants = mstrBAL.GetPowerPlantsMaster();
                if (objplants != null)
                {
                    ddlPlant.DataSource = objplants;
                    ddlPlant.DataValueField = "PowerPlantID";
                    ddlPlant.DataTextField = "PowerPlantName";
                    ddlPlant.DataBind();
                }
                else
                {
                    ddlPlant.DataSource = null;
                    ddlPlant.DataBind();
                }
                AddSelect(ddlPlant);
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
                ds = objcfebal.GetCFEPOWERCEIGDETAILS(hdnUserID.Value, UnitID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["UnitID"] = Convert.ToString(ds.Tables[0].Rows[0]["CFECD_CFEUNITID"]);
                    txtInstall.Text = ds.Tables[0].Rows[0]["CFECD_ALREADYINSTALLED"].ToString();
                    txtProposed.Text = ds.Tables[0].Rows[0]["CFECD_PROPOSED"].ToString();
                    txtTotal.Text = ds.Tables[0].Rows[0]["CFECD_TOTAL"].ToString();
                    ddlLOAD.SelectedValue = ds.Tables[0].Rows[0]["CFECD_CONNECTEDLOAD"].ToString();
                    txtAlready.Text = ds.Tables[0].Rows[0]["CFECD_ALREADTINSTALL"].ToString();
                    txtPropose.Text = ds.Tables[0].Rows[0]["CFECD_PROPSE"].ToString();
                    txtTotals.Text = ds.Tables[0].Rows[0]["CFECD_TOTALS"].ToString();
                    ddlRegulation.SelectedValue = ds.Tables[0].Rows[0]["CFECD_REGULATION"].ToString();
                    if (ddlRegulation.SelectedValue == "1")
                    {
                        divpowerplants1.Visible = true;
                        divpowerplants2.Visible = true;
                        divvoltages.Visible = false;
                        ddlPlant.SelectedValue = ds.Tables[0].Rows[0]["CFECD_PLANT"].ToString();
                        txtCapacity.Text = ds.Tables[0].Rows[0]["CFECD_CAPACITY"].ToString();
                    }
                    else
                    {
                        divpowerplants1.Visible = false;
                        divpowerplants2.Visible = false;
                        divvoltages.Visible = true;
                        ddlvtg.SelectedValue = ds.Tables[0].Rows[0]["CFECD_VOLTAGE"].ToString();
                    }

                    ddlLocFactory.SelectedValue = ds.Tables[0].Rows[0]["CFECD_FACTORYLOCATION"].ToString();
                    txtSurvey.Text = ds.Tables[0].Rows[0]["CFECD_SURVEYNO"].ToString();
                    txtExtent.Text = ds.Tables[0].Rows[0]["CFECD_EXTENT"].ToString();
                    ddlDistrict.SelectedValue = ds.Tables[0].Rows[0]["CFECD_DISTRIC"].ToString();
                    ddlDistrict_SelectedIndexChanged(null, EventArgs.Empty);
                    ddlMandal.SelectedValue = ds.Tables[0].Rows[0]["CFECD_MANDAL"].ToString();
                    ddlMandal_SelectedIndexChanged(null, EventArgs.Empty);
                    ddlVillage.SelectedValue = ds.Tables[0].Rows[0]["CFECD_VILLAGE"].ToString();
                    txtStreet.Text = ds.Tables[0].Rows[0]["CFECD_STREETNAME"].ToString();
                    txtPincode.Text = ds.Tables[0].Rows[0]["CFECD_PINCODE"].ToString();
                    txtTelephone.Text = ds.Tables[0].Rows[0]["CFECD_TELEPHONE"].ToString();
                    txtNearestNo.Text = ds.Tables[0].Rows[0]["CFECD_NEARTELEPHONENO"].ToString();
                    txtDate.Text = ds.Tables[0].Rows[0]["CFECD_DATE"].ToString();
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindAttachments()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfebal.GetCFEAttachmentsData(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]));
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {


                        }
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                            {
                                if (Convert.ToInt32(ds.Tables[1].Rows[i]["CFEA_MASTERAID"]) == 22)
                                {
                                    hypowner.Visible = true;
                                    hypowner.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["FILELOCATION"]));
                                    hypowner.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                                }
                                if (Convert.ToInt32(ds.Tables[1].Rows[i]["CFEA_MASTERAID"]) == 23)
                                {
                                    hypLic.Visible = true;
                                    hypLic.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["FILELOCATION"]));
                                    hypLic.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                                }
                                if (Convert.ToInt32(ds.Tables[1].Rows[i]["CFEA_MASTERAID"]) == 24)
                                {
                                    hypElectrical.Visible = true;
                                    hypElectrical.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["FILELOCATION"]));
                                    hypElectrical.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                                }
                                if (Convert.ToInt32(ds.Tables[1].Rows[i]["CFEA_MASTERAID"]) == 25)
                                {
                                    hypdiscoms.Visible = true;
                                    hypdiscoms.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["FILELOCATION"]));
                                    hypdiscoms.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                                }
                                if (Convert.ToInt32(ds.Tables[1].Rows[i]["CFEA_MASTERAID"]) == 26)
                                {
                                    hypenergy.Visible = true;
                                    hypenergy.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["FILELOCATION"]));
                                    hypenergy.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                                }
                                if (Convert.ToInt32(ds.Tables[1].Rows[i]["CFEA_MASTERAID"]) == 27)
                                {
                                    hypplan.Visible = true;
                                    hypplan.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["FILELOCATION"]));
                                    hypplan.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                                }
                                if (Convert.ToInt32(ds.Tables[1].Rows[i]["CFEA_MASTERAID"]) == 28)
                                {
                                    hypDraw.Visible = true;
                                    hypDraw.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["FILELOCATION"]));
                                    hypDraw.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                                }
                                if (Convert.ToInt32(ds.Tables[1].Rows[i]["CFEA_MASTERAID"]) == 29)
                                {
                                    hypEarth.Visible = true;
                                    hypEarth.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["FILELOCATION"]));
                                    hypEarth.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                                }
                            }

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
        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlMandal.ClearSelection();
                ddlMandal.Items.Clear();
                AddSelect(ddlMandal);
                ddlVillage.ClearSelection();
                ddlVillage.Items.Clear();
                AddSelect(ddlVillage);
                if (ddlDistrict.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlMandal, ddlDistrict.SelectedValue);
                }
                else return;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void ddlRegulation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlRegulation.SelectedValue == "1") //32
                {
                    divpowerplants1.Visible = true;
                    divpowerplants2.Visible = true;
                    divvoltages.Visible = false;
                }
                else if (ddlRegulation.SelectedValue == "2") //43(3)
                {
                    divpowerplants1.Visible = false;
                    divpowerplants2.Visible = false;
                    divvoltages.Visible = true;
                }
                else
                {
                    divvoltages.Visible = false;
                    divpowerplants1.Visible = false;
                    divpowerplants2.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void btnowner_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupoWNER.HasFile)
                {
                    Error = validations(fupoWNER);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Owner" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupoWNER.PostedFile.SaveAs(serverpath + "\\" + fupoWNER.PostedFile.FileName);

                        CFEAttachments objOwner = new CFEAttachments();
                        objOwner.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objOwner.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objOwner.MasterID = "22";
                        objOwner.FilePath = serverpath + fupoWNER.PostedFile.FileName;
                        objOwner.FileName = fupoWNER.PostedFile.FileName;
                        objOwner.FileType = fupoWNER.PostedFile.ContentType;
                        objOwner.FileDescription = "Agreement letter Contractor";
                        objOwner.CreatedBy = hdnUserID.Value;
                        objOwner.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objOwner);
                        if (result != "")
                        {
                            hypowner.Text = fupoWNER.PostedFile.FileName;
                            hypowner.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objOwner.FilePath);
                            hypowner.Target = "blank";
                            message = "alert('" + "Agreement letter between Contractor Document Uploaded successfully" + "')";
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
        protected void btnLic_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupLic.HasFile)
                {
                    Error = validations(fupLic);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Contractor License" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupLic.PostedFile.SaveAs(serverpath + "\\" + fupLic.PostedFile.FileName);

                        CFEAttachments objApplPhoto = new CFEAttachments();
                        objApplPhoto.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objApplPhoto.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objApplPhoto.MasterID = "23";
                        objApplPhoto.FilePath = serverpath + fupLic.PostedFile.FileName;
                        objApplPhoto.FileName = fupLic.PostedFile.FileName;
                        objApplPhoto.FileType = fupLic.PostedFile.ContentType;
                        objApplPhoto.FileDescription = "Contractor License";
                        objApplPhoto.CreatedBy = hdnUserID.Value;
                        objApplPhoto.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objApplPhoto);
                        if (result != "")
                        {
                            hypLic.Text = fupLic.PostedFile.FileName;
                            hypLic.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objApplPhoto.FilePath); 
                            hypLic.Target = "blank";
                            message = "alert('" + "Contractor License Uploaded successfully" + "')";
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
        protected void btnElectrical_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupElectrical.HasFile)
                {
                    Error = validations(fupElectrical);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Contractor/Project electrical" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupElectrical.PostedFile.SaveAs(serverpath + "\\" + fupElectrical.PostedFile.FileName);

                        CFEAttachments objApplPhoto = new CFEAttachments();
                        objApplPhoto.UNITID = Convert.ToString(Session["CFEQID"]);
                        objApplPhoto.Questionnareid = Convert.ToString(Session["CFEUNITID"]);
                        objApplPhoto.MasterID = "24";
                        objApplPhoto.FilePath = serverpath + fupElectrical.PostedFile.FileName;
                        objApplPhoto.FileName = fupElectrical.PostedFile.FileName;
                        objApplPhoto.FileType = fupElectrical.PostedFile.ContentType;
                        objApplPhoto.FileDescription = "Contractor/Project electrical";
                        objApplPhoto.CreatedBy = hdnUserID.Value;
                        objApplPhoto.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objApplPhoto);
                        if (result != "")
                        {
                            hypElectrical.Text = fupElectrical.PostedFile.FileName;
                            hypElectrical.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objApplPhoto.FilePath);
                            hypElectrical.Target = "blank";
                            message = "alert('" + "Contractor/Project electrical supervisor permit Uploaded successfully" + "')";
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
        protected void btnDiscoms_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupdiscoms.HasFile)
                {
                    Error = validations(fupdiscoms);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "DISCOMS" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupdiscoms.PostedFile.SaveAs(serverpath + "\\" + fupdiscoms.PostedFile.FileName);

                        CFEAttachments objApplPhoto = new CFEAttachments();
                        objApplPhoto.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objApplPhoto.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objApplPhoto.MasterID = "25";
                        objApplPhoto.FilePath = serverpath + fupdiscoms.PostedFile.FileName;
                        objApplPhoto.FileName = fupdiscoms.PostedFile.FileName;
                        objApplPhoto.FileType = fupdiscoms.PostedFile.ContentType;
                        objApplPhoto.FileDescription = "DISCOMS";
                        objApplPhoto.CreatedBy = hdnUserID.Value;
                        objApplPhoto.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objApplPhoto);
                        if (result != "")
                        {
                            hypdiscoms.Text = fupdiscoms.PostedFile.FileName;
                            hypdiscoms.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objApplPhoto.FilePath); 
                            hypdiscoms.Target = "blank";
                            message = "alert('" + "Feasibility report from the DISCOMS Uploaded successfully" + "')";
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
        protected void btnEnergy_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupenergy.HasFile)
                {
                    Error = validations(fupenergy);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Electrical Single line diagram" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupenergy.PostedFile.SaveAs(serverpath + "\\" + fupenergy.PostedFile.FileName);

                        CFEAttachments objApplPhoto = new CFEAttachments();
                        objApplPhoto.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objApplPhoto.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objApplPhoto.MasterID = "26";
                        objApplPhoto.FilePath = serverpath + fupenergy.PostedFile.FileName;
                        objApplPhoto.FileName = fupenergy.PostedFile.FileName;
                        objApplPhoto.FileType = fupenergy.PostedFile.ContentType;
                        objApplPhoto.FileDescription = "Electrical Single line diagram";
                        objApplPhoto.CreatedBy = hdnUserID.Value;
                        objApplPhoto.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objApplPhoto);
                        if (result != "")
                        {
                            hypenergy.Text = fupenergy.PostedFile.FileName;
                            hypenergy.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objApplPhoto.FilePath); 
                            hypenergy.Target = "blank";
                            message = "alert('" + "Electrical Single line diagram Uploaded successfully" + "')";
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
        protected void btnPlan_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupPlan.HasFile)
                {
                    Error = validations(fupPlan);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "structural Layout" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupPlan.PostedFile.SaveAs(serverpath + "\\" + fupPlan.PostedFile.FileName);

                        CFEAttachments objApplPhoto = new CFEAttachments();
                        objApplPhoto.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objApplPhoto.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objApplPhoto.MasterID = "27";
                        objApplPhoto.FilePath = serverpath + fupPlan.PostedFile.FileName;
                        objApplPhoto.FileName = fupPlan.PostedFile.FileName;
                        objApplPhoto.FileType = fupPlan.PostedFile.ContentType;
                        objApplPhoto.FileDescription = "structural Layouts";
                        objApplPhoto.CreatedBy = hdnUserID.Value;
                        objApplPhoto.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objApplPhoto);
                        if (result != "")
                        {
                            hypplan.Text = fupPlan.PostedFile.FileName;
                            hypplan.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objApplPhoto.FilePath); 
                            hypplan.Target = "blank";
                            message = "alert('" + "structural layout showing plan Uploaded successfully" + "')";
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
        protected void btnDraw_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupDraw.HasFile)
                {
                    Error = validations(fupDraw);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "General arrangement" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupDraw.PostedFile.SaveAs(serverpath + "\\" + fupDraw.PostedFile.FileName);

                        CFEAttachments objApplPhoto = new CFEAttachments();
                        objApplPhoto.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objApplPhoto.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objApplPhoto.MasterID = "28";
                        objApplPhoto.FilePath = serverpath + fupDraw.PostedFile.FileName;
                        objApplPhoto.FileName = fupDraw.PostedFile.FileName;
                        objApplPhoto.FileType = fupDraw.PostedFile.ContentType;
                        objApplPhoto.FileDescription = "General arrangement";
                        objApplPhoto.CreatedBy = hdnUserID.Value;
                        objApplPhoto.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objApplPhoto);
                        if (result != "")
                        {
                            hypDraw.Text = fupDraw.PostedFile.FileName;
                            hypDraw.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objApplPhoto.FilePath); 
                            hypDraw.Target = "blank";
                            message = "alert('" + "General arrangement of the equipment drawing showing the location Uploaded successfully" + "')";
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
        protected void btnEarth_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupEarth.HasFile)
                {
                    Error = validations(fupEarth);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "earthing layout" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupEarth.PostedFile.SaveAs(serverpath + "\\" + fupEarth.PostedFile.FileName);

                        CFEAttachments objApplPhoto = new CFEAttachments();
                        objApplPhoto.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objApplPhoto.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objApplPhoto.MasterID = "29";
                        objApplPhoto.FilePath = serverpath + fupEarth.PostedFile.FileName;
                        objApplPhoto.FileName = fupEarth.PostedFile.FileName;
                        objApplPhoto.FileType = fupEarth.PostedFile.ContentType;
                        objApplPhoto.FileDescription = "earthing layout";
                        objApplPhoto.CreatedBy = hdnUserID.Value;
                        objApplPhoto.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objApplPhoto);
                        if (result != "")
                        {
                            hypEarth.Text = fupEarth.PostedFile.FileName;
                            hypEarth.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objApplPhoto.FilePath);
                            hypEarth.Target = "blank";
                            message = "alert('" + "The earthing layout diagram Uploaded successfully" + "')";
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
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                ErrorMsg = validations();
                if (ErrorMsg == "")
                {
                    CFECEIG ObjCFECEIG = new CFECEIG();

                    ObjCFECEIG.Questionnareid = Convert.ToString(Session["CFEQID"]);
                    ObjCFECEIG.CreatedBy = hdnUserID.Value;
                    ObjCFECEIG.UnitId = Convert.ToString(Session["CFEUNITID"]);
                    ObjCFECEIG.IPAddress = getclientIP();

                    ObjCFECEIG.ALREADY = txtInstall.Text;
                    ObjCFECEIG.PROPOSED = txtProposed.Text;
                    ObjCFECEIG.TOTAL = txtTotal.Text;
                    ObjCFECEIG.CONNECTEDLOAD = ddlLOAD.SelectedValue;
                    ObjCFECEIG.INSTALLED = txtAlready.Text;
                    ObjCFECEIG.PROPOSE = txtPropose.Text;
                    ObjCFECEIG.TOTALS = txtTotals.Text;
                    ObjCFECEIG.REGULATION = ddlRegulation.SelectedValue;
                    ObjCFECEIG.voltage = ddlvtg.SelectedValue;
                    ObjCFECEIG.Plant = ddlPlant.SelectedValue;
                    ObjCFECEIG.CAPACITY = txtCapacity.Text;
                    ObjCFECEIG.LOCATIONFACTORY = ddlLocFactory.SelectedValue;
                    ObjCFECEIG.SURVEYNO = txtSurvey.Text;
                    ObjCFECEIG.EXTENT = txtExtent.Text;
                    ObjCFECEIG.DISTRIC = ddlDistrict.SelectedValue;
                    ObjCFECEIG.MANDAL = ddlMandal.SelectedValue;
                    ObjCFECEIG.VILLAGE = ddlVillage.SelectedValue;
                    ObjCFECEIG.STREETNAME = txtStreet.Text;
                    ObjCFECEIG.PINCODE = txtPincode.Text;
                    ObjCFECEIG.TELEPHOPNE = txtTelephone.Text;
                    ObjCFECEIG.NEARESTPHONENO = txtNearestNo.Text;
                    ObjCFECEIG.DATE = txtDate.Text;

                    result = objcfebal.InsertCFECEIGDetails(ObjCFECEIG);

                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "CEIG Details Submitted Successfully";
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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public string validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";

                if (string.IsNullOrEmpty(txtInstall.Text) || txtInstall.Text == "" || txtInstall.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Already Installed \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtProposed.Text) || txtProposed.Text == "" || txtProposed.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Proposed \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtTotal.Text) || txtTotal.Text == "" || txtTotal.Text == null || txtTotal.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtTotal.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Total \\n";
                    slno = slno + 1;
                }
                if (ddlLOAD.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Enter Type of Connected Load \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAlready.Text) || txtAlready.Text == "" || txtAlready.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Already Installed \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPropose.Text) || txtPropose.Text == "" || txtPropose.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Proposed \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtTotals.Text) || txtTotals.Text == "" || txtTotals.Text == null || txtTotal.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtTotal.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Total \\n";
                    slno = slno + 1;
                }
                if (ddlRegulation.SelectedIndex == -1 || ddlRegulation.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Regulation Type \\n";
                    slno = slno + 1;
                }
                if (ddlRegulation.SelectedValue == "1")
                {
                    if (ddlPlant.SelectedIndex == -1 || ddlPlant.SelectedItem.Text == "--Select--")
                    {
                        errormsg = errormsg + slno + ". Please Select Power Plant Type \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtCapacity.Text) || txtCapacity.Text == "" || txtCapacity.Text == null || txtCapacity.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtCapacity.Text, @"^0+(\.0+)?$"))
                    {
                        errormsg = errormsg + slno + ". Please Enter Aggregate Capacity  \\n";
                        slno = slno + 1;
                    }
                }
                if (ddlRegulation.SelectedValue == "2")
                {
                    if (ddlvtg.SelectedIndex == -1 || ddlvtg.SelectedItem.Text == "--Select--")
                    {
                        errormsg = errormsg + slno + ". Please Select Voltage Rating  \\n";
                        slno = slno + 1;
                    }
                }

                if (ddlLocFactory.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Enter Proposed Location of Factory \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtSurvey.Text) || txtSurvey.Text == "" || txtSurvey.Text == null || txtSurvey.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtSurvey.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Survey \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtExtent.Text) || txtExtent.Text == "" || txtExtent.Text == null || txtExtent.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtExtent.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Extent \\n";
                    slno = slno + 1;
                }
                if (ddlDistrict.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Enter Distric \\n";
                    slno = slno + 1;
                }
                if (ddlMandal.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Enter Mandal \\n";
                    slno = slno + 1;
                }
                if (ddlVillage.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Enter Village \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtStreet.Text) || txtStreet.Text == "" || txtStreet.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Street Name \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPincode.Text) || txtPincode.Text == "" || txtPincode.Text == null || txtPincode.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtPincode.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Pincode \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtTelephone.Text) || txtTelephone.Text == "" || txtTelephone.Text == null || txtTelephone.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtTelephone.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Telephone \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNearestNo.Text) || txtNearestNo.Text == "" || txtNearestNo.Text == null || txtNearestNo.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtNearestNo.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Phone Number \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDate.Text) || txtDate.Text == "" || txtDate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Date \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypowner.Text) || hypowner.Text == "" || hypowner.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Upload Agreement letter between Contractor & Owner \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypLic.Text) || hypLic.Text == "" || hypLic.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Upload Contractor License copy \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypElectrical.Text) || hypElectrical.Text == "" || hypElectrical.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Upload Contractor/Project electrical supervisor permit copy \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypdiscoms.Text) || hypdiscoms.Text == "" || hypdiscoms.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Upload Feasibility report from the DISCOMS \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypenergy.Text) || hypenergy.Text == "" || hypenergy.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Upload Electrical Single line diagram \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypplan.Text) || hypplan.Text == "" || hypplan.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Upload The structural layout showing plan and Elevations with sectional and safe clearances \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypDraw.Text) || hypDraw.Text == "" || hypDraw.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Upload General arrangement of the equipment drawing \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypEarth.Text) || hypEarth.Text == "" || hypEarth.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Upload The earthing layout diagram \\n";
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
                Response.Redirect("~/User/CFE/CFEProffessionalTax.aspx?Previous=" + "P");
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
                btnsave_Click(sender, e);
                if (ErrorMsg == "")
                    Response.Redirect("~/User/CFE/CFEForestDetails.aspx?Next=" + "N");
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