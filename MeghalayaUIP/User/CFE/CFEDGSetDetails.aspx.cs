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
    public partial class CFEDGSetDetails : System.Web.UI.Page
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
            { lblmsg0.Text = ex.Message; Failure.Visible = true; }
        }
        protected void GetAppliedorNot()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfebal.GetAppliedApprovalIDs(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]), Convert.ToString(Session["CFEQID"]), "14", "6");


                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(ds.Tables[0].Rows[0]["CFEDA_APPROVALID"]) == "6")
                    {
                        BindDistricts();
                        BindData();
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
            }
        }
        protected void BindDistricts()
        {
            try
            {
                ddlLocDist.Items.Clear();
                ddlLocTaluka.Items.Clear();
                ddlLocVillage.Items.Clear();

                List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();

                objDistrictModel = mstrBAL.GetDistrcits();
                if (objDistrictModel != null)
                {
                    ddlLocDist.DataSource = objDistrictModel;
                    ddlLocDist.DataValueField = "DistrictId";
                    ddlLocDist.DataTextField = "DistrictName";
                    ddlLocDist.DataBind();
                }
                else
                {
                    ddlLocDist.DataSource = null;
                    ddlLocDist.DataBind();

                }
                AddSelect(ddlLocDist);
                AddSelect(ddlLocTaluka);
                AddSelect(ddlLocVillage);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }
        }
        public void BindData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfebal.RetrieveCFEDGSETDetails(hdnUserID.Value, UnitID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["UnitID"] = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_UNITID"]);
                    txtDoorNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_LOCDOORNO"]);
                    txtLocality.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_LOCALITY"]);
                    txtLandmark.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_LANDMARK"]);
                    ddlLocDist.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_LOCDISTRICTID"]);
                    ddlLocDist_SelectedIndexChanged(null, EventArgs.Empty);
                    ddlLocTaluka.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_LOCMANDALID"]);
                    ddlLocTaluka_SelectedIndexChanged(null, EventArgs.Empty);
                    ddlLocVillage.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_LOCVILLAGEID"]);
                    txtPincode.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_LOCPINCODE"]);
                    txtSupplierName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_SUPPLIERNAME"]);
                    txtConnectedLoad.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_TOTLCONNECTEDLOAD"]);
                    txtPropLoadfrmDGSet.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_TOTLPROPDGSETLOAD"]);
                    rblInterlockProvision.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_INTERLOCKPROVIDED"]);
                    txtMotorLoad.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_MOTORLOAD"]);
                    txtLghtsFansLoad.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_LIGHTSFANSLOAD"]);
                    txtOtherLoad.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_OTHERLOAD"]);
                    ddlGenRunningMode.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_GENRUNNINGMODE"]);
                    txtWrkComplDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_WRKCOMPLETIONDATE"]);
                    txtWrkStartDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_INSTLATIONSTARTDATE"]);
                    txtCommissiongDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_COMMISSIONINGDATE"]);
                    txtSuprvisorName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_SUPERVISORNAME"]);
                    txtSuprvisorLICno.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_SUPERVISORLICNO"]);
                    txtContractorName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_CONTRACTORNAME"]);
                    txtContractorLICno.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_CONTRACTORLICNO"]);
                    txtDGsetOperatorName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_DGSETOPERATORNAME"]);
                    txtDGSetCapacity.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_DGSETCAPACITY"]);
                    rblDGSetCapacity.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_DGSETCAPACITYIN"]);
                    txtPowerFactor.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_DGSETPOWERFACTOR"]);
                    txtRatedVolatge.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_DGSETRATEDVOLTAGE"]);
                    txtEngineDtls.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_DGSETENGINEDTLS"]);
                    txtAlternatorDtls.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_DGSETALTERNATORDTLS"]);
                    ddlEquipment.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_EQUIPMENTTYPE"]);
                    txtConductorDtls.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_EARTHCONDCTRDTLS"]);
                    txtConductorPaths.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_CONDUCTORPATHS"]);
                    txtElectrodeDtls.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_ELECTRODEDTLS"]);
                    txtImpedance.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_IMPEDANCE"]);
                    txtTotalImpedance.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_TOTALIMPEDANCE"]);
                    ddllighting.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_LIGHTINGTYPE"]);
                    txtAltrnatrInsTest.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_ALTERNATORTESTDTLS"]);
                    txtEarthTesterNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_EARTHTESTERNO"]);
                    txtEarthTesterMake.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_EARTHTESTERMAKE"]);
                    txtEarthTesterRange.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_EARTHTESTERRANGE"]);
                    txtMeggerNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_MEGGERNO"]);
                    txtMeggerMake.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_MEGGERMAKE"]);
                    txtMeggerRange.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEDG_MEGGERRANGE"]);

                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        if (Convert.ToInt32(ds.Tables[1].Rows[i]["CFEA_MASTERAID"]) == 30)//
                        {
                            hypManufacture.Visible = true;
                            hypManufacture.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + Convert.ToString(ds.Tables[1].Rows[i]["FILELOCATION"]);
                            hypManufacture.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[1].Rows[i]["CFEA_MASTERAID"]) == 31) //
                        {
                            hypTest.Visible = true;
                            hypTest.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + Convert.ToString(ds.Tables[1].Rows[i]["FILELOCATION"]);
                            hypTest.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[1].Rows[i]["CFEA_MASTERAID"]) == 32) //
                        {
                            hypSingleline.Visible = true;
                            hypSingleline.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + Convert.ToString(ds.Tables[1].Rows[i]["FILELOCATION"]);
                            hypSingleline.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }
        }
        protected void ddlLocDist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlLocTaluka.ClearSelection();
                ddlLocVillage.ClearSelection();
                if (ddlLocDist.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlLocTaluka, ddlLocDist.SelectedValue);
                }
                else return;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }

        }
        protected void ddlLocTaluka_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlLocVillage.ClearSelection();
                if (ddlLocTaluka.SelectedItem.Text != "--Select--")
                {

                    BindVillages(ddlLocVillage, ddlLocTaluka.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
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
                throw ex;
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
                throw ex;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                ErrorMsg = Validations();

                if (ErrorMsg == "")
                {
                    try
                    {
                        ErrorMsg = Validations();

                        if (ErrorMsg == "")
                        {
                            CFEDGset ObjCFEDGset = new CFEDGset();

                            ObjCFEDGset.CreatedBy = hdnUserID.Value;
                            ObjCFEDGset.IPAddress = getclientIP();
                            ObjCFEDGset.Questionnaireid = Convert.ToString(Session["CFEQID"]); //Convert.ToString(Session["CFEDG_CFEQDID"]);
                            ObjCFEDGset.UnitId = Convert.ToString(Session["CFEUNITID"]);
                            ObjCFEDGset.LocDoorno = txtDoorNo.Text;
                            ObjCFEDGset.Locality = txtLocality.Text;
                            ObjCFEDGset.Landamark = txtLandmark.Text;
                            ObjCFEDGset.LocDistrictID = ddlLocDist.SelectedValue;
                            ObjCFEDGset.LocMandalID = ddlLocTaluka.SelectedValue;
                            ObjCFEDGset.LocVillageID = ddlLocVillage.SelectedValue;
                            ObjCFEDGset.LocPincode = txtPincode.Text;
                            ObjCFEDGset.SupplierName = txtSupplierName.Text;
                            ObjCFEDGset.TotalConnectedLoad = txtConnectedLoad.Text;
                            ObjCFEDGset.PropLoadfromDGSet = txtPropLoadfrmDGSet.Text;
                            ObjCFEDGset.InterlockProvided = rblInterlockProvision.SelectedValue;
                            ObjCFEDGset.MotorLoad = txtMotorLoad.Text;
                            ObjCFEDGset.LightsandFansLoad = txtLghtsFansLoad.Text;
                            ObjCFEDGset.OtherlLoad = txtOtherLoad.Text;
                            ObjCFEDGset.GenRunningMode = ddlGenRunningMode.SelectedValue;
                            ObjCFEDGset.WorkCompletionDate = txtWrkComplDate.Text;
                            ObjCFEDGset.WorkStartingDate = txtWrkStartDate.Text;
                            ObjCFEDGset.CommissioningDate = txtCommissiongDate.Text;
                            ObjCFEDGset.SupervisorName = txtSuprvisorName.Text.Trim();
                            ObjCFEDGset.SupervisorLicNo = txtSuprvisorLICno.Text;
                            ObjCFEDGset.ContractorName = txtContractorName.Text.Trim();
                            ObjCFEDGset.ContractorLicNo = txtContractorLICno.Text;
                            ObjCFEDGset.DGSetOperatorNmae = txtDGsetOperatorName.Text.Trim();
                            ObjCFEDGset.DGSetCapacity = txtDGSetCapacity.Text;
                            ObjCFEDGset.DGSetCapacityin = rblDGSetCapacity.SelectedValue;
                            ObjCFEDGset.DGSetPowerFactor = txtPowerFactor.Text;
                            ObjCFEDGset.DGSetRatedVoltage = txtRatedVolatge.Text;
                            ObjCFEDGset.DGSetEngineDetails = txtEngineDtls.Text;
                            ObjCFEDGset.DGSetAlternatorDetails = txtAlternatorDtls.Text;
                            ObjCFEDGset.EquipmentType = ddlEquipment.SelectedValue;
                            ObjCFEDGset.EarthingCondctrDtls = txtConductorDtls.Text;
                            ObjCFEDGset.ConductrPaths = txtConductorPaths.Text;
                            ObjCFEDGset.ElectrodeDtls = txtElectrodeDtls.Text;
                            ObjCFEDGset.Impedance = txtImpedance.Text;
                            ObjCFEDGset.TotalImpedance = txtTotalImpedance.Text;
                            ObjCFEDGset.LighingType = ddllighting.SelectedValue;
                            ObjCFEDGset.AlternatorTestDtls = txtAltrnatrInsTest.Text;
                            ObjCFEDGset.EarthTesterNo = txtEarthTesterNo.Text;
                            ObjCFEDGset.EarthTesterMake = txtEarthTesterMake.Text;
                            ObjCFEDGset.EarthTesterRange = txtEarthTesterRange.Text;
                            ObjCFEDGset.MeggerNo = txtMeggerNo.Text;
                            ObjCFEDGset.MeggerMake = txtMeggerMake.Text;
                            ObjCFEDGset.MeggerRange = txtMeggerRange.Text;

                            result = objcfebal.INSERTCFEDGSET(ObjCFEDGset);

                            if (result != "")
                            {
                                success.Visible = true;
                                lblmsg.Text = "Details Submitted Successfully";
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
                        lblmsg0.Text = ex.Message; Failure.Visible = true;
                        MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
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

        protected void btnowner_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupManufacture.HasFile)
                {
                    Error = validations(fupManufacture);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Manufacturer" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupManufacture.PostedFile.SaveAs(serverpath + "\\" + fupManufacture.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupManufacture.PostedFile.SaveAs(serverpath + "\\" + fupManufacture.PostedFile.FileName);
                            }
                        }


                        CFEAttachments objManufacture = new CFEAttachments();
                        objManufacture.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objManufacture.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objManufacture.MasterID = "30";
                        objManufacture.FilePath = serverpath + fupManufacture.PostedFile.FileName;
                        objManufacture.FileName = fupManufacture.PostedFile.FileName;
                        objManufacture.FileType = fupManufacture.PostedFile.ContentType;
                        objManufacture.FileDescription = "Manufacturer Test Report of DG Set";
                        objManufacture.CreatedBy = hdnUserID.Value;
                        objManufacture.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objManufacture);
                        if (result != "")
                        {
                            hypManufacture.Text = fupManufacture.PostedFile.FileName;
                            hypManufacture.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + objManufacture.FilePath;
                            hypManufacture.Target = "blank";
                            message = "alert('" + "Manufacturer Test Report Document Uploaded successfully" + "')";
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
                if (fupTest.HasFile)
                {
                    Error = validations(fupTest);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "TestReport" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupTest.PostedFile.SaveAs(serverpath + "\\" + fupTest.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupTest.PostedFile.SaveAs(serverpath + "\\" + fupTest.PostedFile.FileName);
                            }
                        }


                        CFEAttachments objManufacture = new CFEAttachments();
                        objManufacture.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objManufacture.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objManufacture.MasterID = "31";
                        objManufacture.FilePath = serverpath + fupTest.PostedFile.FileName;
                        objManufacture.FileName = fupTest.PostedFile.FileName;
                        objManufacture.FileType = fupTest.PostedFile.ContentType;
                        objManufacture.FileDescription = "DG Set Test Report by Registered Contractor in Meghalaya";
                        objManufacture.CreatedBy = hdnUserID.Value;
                        objManufacture.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objManufacture);
                        if (result != "")
                        {
                            hypTest.Text = fupTest.PostedFile.FileName;
                            hypTest.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + objManufacture.FilePath;
                            hypTest.Target = "blank";
                            message = "alert('" + "Test Report by Registered Contractor in Meghalaya Uploaded successfully" + "')";
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
                if (fupSingleline.HasFile)
                {
                    Error = validations(fupSingleline);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\CFEAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Singleline" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupSingleline.PostedFile.SaveAs(serverpath + "\\" + fupSingleline.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupSingleline.PostedFile.SaveAs(serverpath + "\\" + fupSingleline.PostedFile.FileName);
                            }
                        }


                        CFEAttachments objManufacture = new CFEAttachments();
                        objManufacture.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objManufacture.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objManufacture.MasterID = "32";
                        objManufacture.FilePath = serverpath + fupSingleline.PostedFile.FileName;
                        objManufacture.FileName = fupSingleline.PostedFile.FileName;
                        objManufacture.FileType = fupSingleline.PostedFile.ContentType;
                        objManufacture.FileDescription = "Single Line Diagram of DG Set";
                        objManufacture.CreatedBy = hdnUserID.Value;
                        objManufacture.IPAddress = getclientIP();
                        result = objcfebal.InsertCFEAttachments(objManufacture);
                        if (result != "")
                        {
                            hypSingleline.Text = fupSingleline.PostedFile.FileName;
                            hypSingleline.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + objManufacture.FilePath;
                            hypSingleline.Target = "blank";
                            message = "alert('" + "Single Line Diagram of DG Set Uploaded successfully" + "')";
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
                if (!ValidateFileExtension(Attachment))
                {
                    Error = Error + slno + ". Document should not contain double extension (double . ) \\n";
                    slno = slno + 1;
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
        public string Validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                //if (string.IsNullOrEmpty(txtDoorNo.Text) || txtDoorNo.Text == "" || txtDoorNo.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Door No of the Location  \\n";
                //    slno = slno + 1;
                //}
                //if (string.IsNullOrEmpty(txtLocality.Text) || txtLocality.Text == "" || txtLocality.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Locality  \\n";
                //    slno = slno + 1;
                //}
                //if (string.IsNullOrEmpty(txtLandmark.Text) || txtLandmark.Text == "" || txtLandmark.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Landmark  \\n";
                //    slno = slno + 1;
                //}
                //if (ddlLocDist.SelectedIndex == -1 || ddlLocDist.SelectedItem.Text == "--Select--")
                //{
                //    errormsg = errormsg + slno + ". Please Select Distric \\n";
                //    slno = slno + 1;
                //}
                //if (ddlLocTaluka.SelectedIndex == -1 || ddlLocTaluka.SelectedItem.Text == "--Select--")
                //{
                //    errormsg = errormsg + slno + ". Please Select Mandal \\n";
                //    slno = slno + 1;
                //}
                //if (ddlLocVillage.SelectedIndex == -1 || ddlLocVillage.SelectedItem.Text == "--Select--")
                //{
                //    errormsg = errormsg + slno + ". Please Select Village \\n";
                //    slno = slno + 1;
                //}
                //if (string.IsNullOrEmpty(txtPincode.Text) || txtPincode.Text == "" || txtPincode.Text == null || txtPincode.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtPincode.Text, @"^0+(\.0+)?$"))
                //{
                //    errormsg = errormsg + slno + ". Please Enter Pincode No\\n";
                //    slno = slno + 1;
                //}
                if (string.IsNullOrEmpty(txtSupplierName.Text) || txtSupplierName.Text == "" || txtSupplierName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Supplier Name  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtConnectedLoad.Text) || txtConnectedLoad.Text == "" || txtConnectedLoad.Text == null || txtConnectedLoad.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtConnectedLoad.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Total Connected Load\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPropLoadfrmDGSet.Text) || txtPropLoadfrmDGSet.Text == "" || txtPropLoadfrmDGSet.Text == null || txtPropLoadfrmDGSet.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtPropLoadfrmDGSet.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Total Proposed Load to be Supplied from D.G. Sets (in KW)\\n";
                    slno = slno + 1;
                }
                if (rblInterlockProvision.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Details of Interlock/Change over arrangement provided or not \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtMotorLoad.Text) || txtMotorLoad.Text == "" || txtMotorLoad.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Motor Load\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLghtsFansLoad.Text) || txtLghtsFansLoad.Text == "" || txtLghtsFansLoad.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Lights and Fans Load\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtOtherLoad.Text) || txtOtherLoad.Text == "" || txtOtherLoad.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Other Load\\n";
                    slno = slno + 1;
                }
                if (ddlGenRunningMode.SelectedIndex == -1 || ddlGenRunningMode.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Generator Running Mode  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtWrkComplDate.Text) || txtWrkComplDate.Text == "" || txtWrkComplDate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Expected Date of Completion of work  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtWrkStartDate.Text) || txtWrkStartDate.Text == "" || txtWrkStartDate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Expected Date of starting of Installation work \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtCommissiongDate.Text) || txtCommissiongDate.Text == "" || txtCommissiongDate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Expected Date of Commissioning \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtSuprvisorName.Text.Trim()) || txtSuprvisorName.Text.Trim() == "" || txtSuprvisorName.Text.Trim() == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Suprvisor Name \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtSuprvisorLICno.Text) || txtSuprvisorLICno.Text == "" || txtSuprvisorLICno.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Supervisor License Number \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtContractorName.Text.Trim()) || txtContractorName.Text.Trim() == "" || txtContractorName.Text.Trim() == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name of the Contractor who will carry out the internal electricfication \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtContractorLICno.Text) || txtContractorLICno.Text == "" || txtContractorLICno.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Contractor License Number \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDGsetOperatorName.Text.Trim()) || txtDGsetOperatorName.Text.Trim() == "" || txtDGsetOperatorName.Text.Trim() == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name of the Person who will be authorized to operate the D.G Sets \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtDGSetCapacity.Text) || txtDGSetCapacity.Text == "" || txtDGSetCapacity.Text == null || txtDGSetCapacity.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtDGSetCapacity.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter  DG Set Capacity\\n";
                    slno = slno + 1;
                }
                if (rblDGSetCapacity.SelectedIndex == -1 || rblDGSetCapacity.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select DG Set Capacity in KW or KVA \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPowerFactor.Text) || txtPowerFactor.Text == "" || txtPowerFactor.Text == null || txtPowerFactor.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtPowerFactor.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Power Factor\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtRatedVolatge.Text) || txtRatedVolatge.Text == "" || txtRatedVolatge.Text == null || txtRatedVolatge.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtRatedVolatge.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Rated Volatge\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEngineDtls.Text) || txtEngineDtls.Text == "" || txtEngineDtls.Text == null || txtEngineDtls.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtEngineDtls.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Engine Make/Serial No. \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtAlternatorDtls.Text) || txtAlternatorDtls.Text == "" || txtAlternatorDtls.Text == null || txtAlternatorDtls.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtAlternatorDtls.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Alternator Make/Serial No \\n";
                    slno = slno + 1;
                }
                if (ddlEquipment.SelectedIndex == -1 || ddlEquipment.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Type of Equipment  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtConductorDtls.Text) || txtConductorDtls.Text == "" || txtConductorDtls.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Size & materials of earthing conductor \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtConductorPaths.Text) || txtConductorPaths.Text == "" || txtConductorPaths.Text == null || txtConductorPaths.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtConductorPaths.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter No. of independent conductor path \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtElectrodeDtls.Text) || txtElectrodeDtls.Text == "" || txtElectrodeDtls.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Type & size electrode and length/dia \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtImpedance.Text) || txtImpedance.Text == "" || txtImpedance.Text == null || txtImpedance.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtImpedance.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Impedance of the systems in ohm \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtTotalImpedance.Text) || txtTotalImpedance.Text == "" || txtTotalImpedance.Text == null || txtTotalImpedance.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtTotalImpedance.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Total Impedance of the system in ohm\\n";
                    slno = slno + 1;
                }

                if (ddllighting.SelectedIndex == -1 || ddllighting.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Type of lighting \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAltrnatrInsTest.Text) || txtAltrnatrInsTest.Text == "" || txtAltrnatrInsTest.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Details of Insulation Test of Alternator\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEarthTesterNo.Text) || txtEarthTesterNo.Text == "" || txtEarthTesterNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Earth Tester No \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEarthTesterMake.Text) || txtEarthTesterMake.Text == "" || txtEarthTesterMake.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Make of Earth Tester \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEarthTesterRange.Text) || txtEarthTesterRange.Text == "" || txtEarthTesterRange.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Range of Earth Tester\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtMeggerNo.Text) || txtMeggerNo.Text == "" || txtMeggerNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Megger No.\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtMeggerMake.Text) || txtMeggerMake.Text == "" || txtMeggerMake.Text == null || txtMeggerMake.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtMeggerMake.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Megger Make \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtMeggerRange.Text) || txtMeggerRange.Text == "" || txtMeggerRange.Text == null || txtMeggerRange.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtMeggerRange.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter megger Range\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypManufacture.Text) || hypManufacture.Text == "" || hypManufacture.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Manufacturer Test Report \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypTest.Text) || hypTest.Text == "" || hypTest.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Manufacturer Test Report \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypSingleline.Text) || hypSingleline.Text == "" || hypSingleline.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Manufacturer Test Report \\n";
                    slno = slno + 1;
                }

                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
                //MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
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
                Response.Redirect("~/User/CFE/CFEPowerDetails.aspx?Previous=" + "P");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }

        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave_Click(sender, e);
                if (ErrorMsg == "")
                    Response.Redirect("~/User/CFE/CFEFireDetails.aspx?Next=" + "N");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
    }
}