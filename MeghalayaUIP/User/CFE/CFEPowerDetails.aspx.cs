using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static AjaxControlToolkit.AsyncFileUpload.Constants;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MeghalayaUIP.User.CFE
{
    public partial class CFEPowerDetails : System.Web.UI.Page
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
                DataSet ds = new DataSet();
                ds = objcfebal.GetAppliedApprovalIDs(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]), Convert.ToString(Session["CFEQID"]), "14", "3,4");


                if (ds.Tables[0].Rows.Count > 0)
                {
                    BindVoltages();
                    BindENERGYLOAD();
                    BindSubdivision();
                    BINDDATA();
                }
                else
                {
                    if (Request.QueryString.Count > 0)
                    {
                        if (Convert.ToString(Request.QueryString[0]) == "N")
                            Response.Redirect("~/User/CFE/CFEDrawingPlanDetails.aspx?Next=" + "N");
                        else if (Convert.ToString(Request.QueryString[0]) == "P")
                            Response.Redirect("~/User/CFE/CFEHazWasteDetails.aspx?Previous=" + "P");
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
        protected void BindENERGYLOAD()
        {
            try
            {
                ddlloadenergy.Items.Clear();

                List<MasterENERGYLOAD> objCategoryModel = new List<MasterENERGYLOAD>();

                objCategoryModel = mstrBAL.GetPowerEnergyLoad();
                if (objCategoryModel != null)
                {
                    ddlloadenergy.DataSource = objCategoryModel;
                    ddlloadenergy.DataValueField = "ENERGYLOAD_ID";
                    ddlloadenergy.DataTextField = "ENERGYLOAD_NAME";
                    ddlloadenergy.DataBind();
                }
                else
                {
                    ddlloadenergy.DataSource = null;
                    ddlloadenergy.DataBind();
                }
                AddSelect(ddlloadenergy);
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindSubdivision()
        {
            try
            {
                ddlSubDiv.Items.Clear();

                List<MasterSubDivisions> objCategoryModel = new List<MasterSubDivisions>();

                objCategoryModel = mstrBAL.GetSubDivisions();
                if (objCategoryModel != null)
                {
                    ddlSubDiv.DataSource = objCategoryModel;
                    ddlSubDiv.DataValueField = "SubDiv_ID";
                    ddlSubDiv.DataTextField = "SubDiv_NAME";
                    ddlSubDiv.DataBind();
                }
                else
                {
                    ddlSubDiv.DataSource = null;
                    ddlSubDiv.DataBind();
                }
                AddSelect(ddlSubDiv);
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
        public void BindVoltages()
        {
            try
            {
                ddlvtglevel.Items.Clear();
                List<MasterVoltage> objVoltageModel = new List<MasterVoltage>();
                objVoltageModel = mstrBAL.GetVoltageRange();
                if (objVoltageModel != null)
                {
                    ddlvtglevel.DataSource = objVoltageModel;
                    ddlvtglevel.DataValueField = "VOLTAGEID";
                    ddlvtglevel.DataTextField = "VOLTAGERANGE";
                    ddlvtglevel.DataBind();
                }
                else
                {
                    ddlvtglevel.DataSource = null;
                    ddlvtglevel.DataBind();
                }
                AddSelect(ddlvtglevel);

            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public void BINDDATA()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfebal.GetPowerDetailsRetrive(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]));

                if (ds.Tables[0].Rows.Count > 0)
                {   
                    ddlSubDiv.SelectedValue = ds.Tables[0].Rows[0]["CFEPD_SUBDIVISION"].ToString();
                    ddlSubDiv_SelectedIndexChanged(null, EventArgs.Empty);
                    ddlDist.SelectedValue = ds.Tables[0].Rows[0]["CFEPD_DISTRICT"].ToString();
                    ddlDist_SelectedIndexChanged(null, EventArgs.Empty);
                    ddlPincode.SelectedValue = ds.Tables[0].Rows[0]["CFEPD_PINCODEID"].ToString();
                }
                /*
                txtHP.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEPD_CONNECTEDLOAD"]);
                txtMaxDemand.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEPD_MAXIMUMDEMAND"]);
                ddlvtglevel.SelectedValue = ds.Tables[0].Rows[0]["CFEPD_VOLTEAGELEVEL"].ToString();
                //ddlPermise.SelectedValue = ds.Tables[0].Rows[0]["CFEPD_EXISTINGSERVICE"].ToString();
                txtMaxhours.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEPD_WRKNGHRSPERDAY"]);
                txtMonth.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEPD_WRKNGHRSPERMONTH"]);
                txttrailProduct.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEPD_TRIALPRODUCTIONDATE"]);
                txtPowersupply.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEPD_POWERREQDATE"]);
                txtenergy.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEPD_REQLOAD"]);
                ddlloadenergy.SelectedValue = ds.Tables[0].Rows[0]["CFEPD_ENERGYSOURCE"].ToString();

                txtPrpse.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEPD_PURPOSE"]);
                rblCmplnc.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEPD_LOADTYPE"]);
                string loadCharacterData = Convert.ToString(ds.Tables[0].Rows[0]["CFEPD_CHARLOADTYPE"]);

                if (!string.IsNullOrEmpty(loadCharacterData))
                {
                    string[] selectedLoadCharacterItems = loadCharacterData.Split('/');
                    foreach (ListItem item in chkCharacterSupply.Items)
                    {
                        if (selectedLoadCharacterItems.Contains(item.Text))
                        {
                            item.Selected = true;
                        }
                    }
                }

                rblInPhase.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEPD_CONCTDLOAD"]);
                txtYear1.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEPD_YEAR1"]);
                txtYear2.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEPD_YEAR2"]);
                txtYear3.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEPD_YEAR3"]);
                txtYear4.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEPD_YEAR4"]);
                txtYear5.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEPD_YEAR5"]);
                txtEleChg.Text = Convert.ToString(ds.Tables[0].Rows[0]["CFEPD_ELECHARGE"]);
                ddlSubDiv.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEPD_SUBDIVISION"]);
                ddlSubDiv_SelectedIndexChanged(null, EventArgs.Empty);
                ddlDist.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CFEPD_DISTRICT"]);
                
                if (ds.Tables[1].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        if (ds.Tables[1].Rows[i]["CFEA_MASTERAID"].ToString() == "49")
                        {
                            hypCosmrEnty.Visible = true;
                            hypCosmrEnty.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILEPATH"]));
                            hypCosmrEnty.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                        }
                        if (ds.Tables[1].Rows[i]["CFEA_MASTERAID"].ToString() == "50")
                        {
                            hypCsmrBody.Visible = true;
                            hypCsmrBody.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILEPATH"]));
                            hypCsmrBody.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                        }
                        if (ds.Tables[1].Rows[i]["CFEA_MASTERAID"].ToString() == "51")
                        {
                            hypPCB.Visible = true;
                            hypPCB.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILEPATH"]));
                            hypPCB.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                        }
                        if (ds.Tables[1].Rows[i]["CFEA_MASTERAID"].ToString() == "52")
                        {
                            hypMCB.Visible = true;
                            hypMCB.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILEPATH"]));
                            hypMCB.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                        }
                        if (ds.Tables[1].Rows[i]["CFEA_MASTERAID"].ToString() == "53")
                        {
                            hypEnvClr.Visible = true;
                            hypEnvClr.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILEPATH"]));
                            hypEnvClr.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                        }
                        if (ds.Tables[1].Rows[i]["CFEA_MASTERAID"].ToString() == "54")
                        {
                            hypSglWdw.Visible = true;
                            hypSglWdw.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILEPATH"]));
                            hypSglWdw.Text = Convert.ToString(ds.Tables[1].Rows[i]["CFEA_FILENAME"]);
                        }
                    }
                }
                if (rblInPhase.SelectedValue == "Yes")
                {
                    isLoadInPhase.Visible = true;
                }
                else if (rblInPhase.SelectedValue == "No")
                {
                    isLoadInPhase.Visible = false;
                }
                */
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

                ErrorMsg = StepValidations();

                if (ErrorMsg == "")
                {

                    CFEPower objCFEPower = new CFEPower();


                    objCFEPower.CreatedBy = hdnUserID.Value;
                    objCFEPower.IPAddress = getclientIP();
                    objCFEPower.Questionnariid = Convert.ToString(Session["CFEQID"]);
                    objCFEPower.UnitId = Convert.ToString(Session["CFEUNITID"]);
                    objCFEPower.Con_Load_HP = txtHP.Text;
                    objCFEPower.Maximum_KVA = txtMaxDemand.Text;
                    objCFEPower.Voltage_Level = ddlvtglevel.SelectedValue;
                    objCFEPower.Existing_Service = ddlPermise.SelectedValue;
                    objCFEPower.Per_Day = txtMaxhours.Text;
                    objCFEPower.Per_Month = txtMonth.Text;
                    objCFEPower.Expected_Month_Trial = txttrailProduct.Text;
                    objCFEPower.Probable_Date_Power = txtPowersupply.Text;
                    objCFEPower.LoadReq = txtenergy.Text;
                    objCFEPower.EnergySource = ddlloadenergy.SelectedValue;

                    objCFEPower.Purpose = txtPrpse.Text;
                    objCFEPower.LoadType = rblCmplnc.SelectedValue;
                    objCFEPower.Pincode = ddlPincode.SelectedValue;

                    List<string> selectedLoadCharacterItems = new List<string>();
                    foreach (ListItem item in chkCharacterSupply.Items)
                    {
                        if (item.Selected)
                        {
                            selectedLoadCharacterItems.Add(item.Text);
                        }
                    }
                    objCFEPower.LoadCharacter = string.Join("/", selectedLoadCharacterItems);

                    objCFEPower.ConnectedLoadReq = rblInPhase.SelectedValue;
                    objCFEPower.Year1 = txtYear1.Text;
                    objCFEPower.Year2 = txtYear2.Text;
                    objCFEPower.Year3 = txtYear3.Text;
                    objCFEPower.Year4 = txtYear4.Text;
                    objCFEPower.Year5 = txtYear5.Text;
                    objCFEPower.ElectricityCharge = txtEleChg.Text;
                    objCFEPower.SUBDIVISION = ddlSubDiv.SelectedValue;
                    objCFEPower.DISTRICT = ddlDist.SelectedValue;
                   // objCFEPower.RESPONSEOUTPUT = RegNo;
                    objCFEPower.REGNO = hdnapiReg.Value;


                    result = objcfebal.InsertCFEPowerDetails(objCFEPower);

                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "POWER Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                    DataSet dss = new DataSet();
                    dss = GetDataPower();
                    if (dss.Tables.Count>0 && dss.Tables[0].Rows.Count > 0)
                    {
                        string RegNo = Post(dss);
                        if (RegNo != "")
                        {
                            CFEDtls objcfeDtls = new CFEDtls();
                            
                        }
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
        public string StepValidations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
              
                if (ddlSubDiv.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please select Sub Division  \\n";
                    slno = slno + 1;
                }
                if (ddlDist.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please select Disctrict  \\n";
                    slno = slno + 1;
                }
                if (ddlPincode.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please select Pincode  \\n";
                    slno = slno + 1;
                }

                /*
                  List<TextBox> emptyTextboxes = FindEmptyTextboxes(divText);
                List<DropDownList> emptyDropdowns = FindEmptyDropdowns(divText);
                if (string.IsNullOrEmpty(txtHP.Text) || txtHP.Text == "" || txtHP.Text == null || txtHP.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtHP.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Load Connected  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtMaxDemand.Text) || txtMaxDemand.Text == "" || txtMaxDemand.Text == null || txtMaxDemand.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtMaxDemand.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Maximum Demand in KVA  \\n";
                    slno = slno + 1;
                }
                if (ddlvtglevel.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Enter Required Voltage Level  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtMaxhours.Text) || txtMaxhours.Text == "" || txtMaxhours.Text == null || txtMaxhours.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtMaxhours.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Per Day...  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtMonth.Text) || txtMonth.Text == "" || txtMonth.Text == null || txtMonth.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtMonth.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Per Month....  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txttrailProduct.Text) || txttrailProduct.Text == "" || txttrailProduct.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Expected Month and Year of Trial Production  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPowersupply.Text) || txtPowersupply.Text == "" || txtPowersupply.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Probable Date of Requirement of Power Supply  \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtenergy.Text) || txtenergy.Text == "" || txtenergy.Text == null || txtenergy.Text.All(c => c == '0') || System.Text.RegularExpressions.Regex.IsMatch(txtenergy.Text, @"^0+(\.0+)?$"))
                {
                    errormsg = errormsg + slno + ". Please Enter Quantum of energy/load required (in KW) \\n";
                    slno = slno + 1;
                }
                if (ddlloadenergy.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Enter Proposed source of energy/load \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPrpse.Text) || txtPrpse.Text == "" || txtPrpse.Text == null)
                {
                    errormsg += slno + ". Please Enter Purpose \\n";
                    slno++;
                }
                if (rblCmplnc.SelectedIndex == -1)
                {
                    errormsg += slno + ". Please Select Load Type \\n";
                    slno++;
                }
                if (chkCharacterSupply.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select character of supply \\n";
                    slno = slno + 1;
                }
                if (rblInPhase.SelectedIndex == -1)
                {
                    errormsg += slno + ". Please Select Phase Details \\n";
                    slno++;
                }
                if (rblCmplnc.SelectedItem != null && rblCmplnc.SelectedItem.Text == "Yes")
                {
                    if (string.IsNullOrEmpty(txtYear1.Text) || txtYear1.Text.All(c => c == '0'))
                    {
                        errormsg += slno + ". Please Enter Projected Demand for Year 1 \\n";
                        slno++;
                    }
                    if (string.IsNullOrEmpty(txtYear2.Text) || txtYear2.Text.All(c => c == '0'))
                    {
                        errormsg += slno + ". Please Enter Projected Demand for Year 2 \\n";
                        slno++;
                    }
                    if (string.IsNullOrEmpty(txtYear3.Text) || txtYear3.Text.All(c => c == '0'))
                    {
                        errormsg += slno + ". Please Enter Projected Demand for Year 3 \\n";
                        slno++;
                    }
                    if (string.IsNullOrEmpty(txtYear4.Text) || txtYear4.Text.All(c => c == '0'))
                    {
                        errormsg += slno + ". Please Enter Projected Demand for Year 4 \\n";
                        slno++;
                    }
                    if (string.IsNullOrEmpty(txtYear5.Text) || txtYear5.Text.All(c => c == '0'))
                    {
                        errormsg += slno + ". Please Enter Projected Demand for Year 5 \\n";
                        slno++;
                    }
                }
                if (string.IsNullOrEmpty(txtEleChg.Text) || txtEleChg.Text == "" || txtEleChg.Text == null)
                {
                    errormsg += slno + ". Please Enter Electricity Charges \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(hypCosmrEnty.Text) || hypCosmrEnty.Text == "" || hypCosmrEnty.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Attach the entity of the consumer body \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypCsmrBody.Text) || hypCsmrBody.Text == "" || hypCsmrBody.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Attach the proprietorship of the consumer body \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypPCB.Text) || hypPCB.Text == "" || hypPCB.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Attach the clearances from the Pollution Control Board (s) (as may be required) \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypMCB.Text) || hypMCB.Text == "" || hypMCB.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Attach the clearances from Municipal or Cantonment Board and Urban Affairs authorities \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypEnvClr.Text) || hypEnvClr.Text == "" || hypEnvClr.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Attach environmental clearance from the concerned authorities \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypSglWdw.Text) || hypSglWdw.Text == "" || hypSglWdw.Text == null)
                {
                    errormsg = errormsg + slno + ". Please upload Attach approval of the Single Window Agency of the Industries Departments \\n";
                    slno = slno + 1;
                }
                */

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
                Response.Redirect("~/User/CFE/CFEHazWasteDetails.aspx?Previous=" + "P");
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
                    Response.Redirect("~/User/CFE/CFEDrawingPlanDetails.aspx?Next=" + "N");
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

        protected void btnCosmrEnty_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupCosmrEnty.HasFile)
                {
                    Error = validations(fupCosmrEnty);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + " entity of the consumer body" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupCosmrEnty.PostedFile.SaveAs(serverpath + "\\" + fupCosmrEnty.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupCosmrEnty.PostedFile.SaveAs(serverpath + "\\" + fupCosmrEnty.PostedFile.FileName);
                            }
                        }

                        CFEAttachments objCosmrEnty = new CFEAttachments();
                        objCosmrEnty.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objCosmrEnty.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objCosmrEnty.MasterID = "49";
                        objCosmrEnty.FilePath = serverpath + fupCosmrEnty.PostedFile.FileName;
                        objCosmrEnty.FileName = fupCosmrEnty.PostedFile.FileName;
                        objCosmrEnty.FileType = fupCosmrEnty.PostedFile.ContentType;
                        objCosmrEnty.FileDescription = "Attach the entity of the consumer body";
                        objCosmrEnty.CreatedBy = hdnUserID.Value;
                        objCosmrEnty.IPAddress = getclientIP();
                        //objCosmrEnty.ReferenceNo = txtCosmrEnty.Text;
                        result = objcfebal.InsertCFEAttachments(objCosmrEnty);
                        if (result != "")
                        {
                            hypCosmrEnty.Text = fupCosmrEnty.PostedFile.FileName;
                            hypCosmrEnty.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupCosmrEnty.PostedFile.FileName);
                            hypCosmrEnty.Target = "blank";
                            message = "alert('" + "Attach the entity of the consumer body Uploaded successfully" + "')";
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
        protected void btnCsmrBody_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupCsmrBody.HasFile)
                {
                    Error = validations(fupCsmrBody);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Proprietorship of the consumer body" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupCsmrBody.PostedFile.SaveAs(serverpath + "\\" + fupCsmrBody.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupCsmrBody.PostedFile.SaveAs(serverpath + "\\" + fupCsmrBody.PostedFile.FileName);
                            }
                        }


                        CFEAttachments objCsmrBody = new CFEAttachments();
                        objCsmrBody.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objCsmrBody.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objCsmrBody.MasterID = "50";
                        objCsmrBody.FilePath = serverpath + fupCsmrBody.PostedFile.FileName;
                        objCsmrBody.FileName = fupCsmrBody.PostedFile.FileName;
                        objCsmrBody.FileType = fupCsmrBody.PostedFile.ContentType;
                        objCsmrBody.FileDescription = "Attach the Proprietorship of the consumer body";
                        objCsmrBody.CreatedBy = hdnUserID.Value;
                        objCsmrBody.IPAddress = getclientIP();
                        //objCsmrBody.ReferenceNo = txtCsmrBody.Text;
                        result = objcfebal.InsertCFEAttachments(objCsmrBody);
                        if (result != "")
                        {
                            hypCsmrBody
                            .Text = fupCsmrBody.PostedFile.FileName;
                            hypCsmrBody.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupCsmrBody.PostedFile.FileName);
                            hypCsmrBody.Target = "blank";
                            message = "alert('" + "Attach the Proprietorship of the consumer body Uploaded successfully" + "')";
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
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Clearances from the Pollution Control Board Document" + "\\";
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


                        CFEAttachments objPCB = new CFEAttachments();
                        objPCB.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objPCB.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objPCB.MasterID = "51";
                        objPCB.FilePath = serverpath + fupPCB.PostedFile.FileName;
                        objPCB.FileName = fupPCB.PostedFile.FileName;
                        objPCB.FileType = fupPCB.PostedFile.ContentType;
                        objPCB.FileDescription = "Clearances from the Pollution Control Board Document";
                        objPCB.CreatedBy = hdnUserID.Value;
                        objPCB.IPAddress = getclientIP();
                        //objPCB.ReferenceNo = txtPCB.Text;
                        result = objcfebal.InsertCFEAttachments(objPCB);
                        if (result != "")
                        {
                            hypPCB.Text = fupPCB.PostedFile.FileName;
                            hypPCB.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupPCB.PostedFile.FileName);
                            hypPCB.Target = "blank";
                            message = "alert('" + "Clearances from the Pollution Control Board Uploaded successfully" + "')";
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
        protected void btnMCB_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupMCB.HasFile)
                {
                    Error = validations(fupMCB);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Clearances from Municipal or Cantonment Board and Urban Affairs authorities" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupMCB.PostedFile.SaveAs(serverpath + "\\" + fupMCB.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupMCB.PostedFile.SaveAs(serverpath + "\\" + fupMCB.PostedFile.FileName);
                            }
                        }


                        CFEAttachments objMCB = new CFEAttachments();
                        objMCB.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objMCB.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objMCB.MasterID = "52";
                        objMCB.FilePath = serverpath + fupMCB.PostedFile.FileName;
                        objMCB.FileName = fupMCB.PostedFile.FileName;
                        objMCB.FileType = fupMCB.PostedFile.ContentType;
                        objMCB.FileDescription = "Clearances from Municipal or Cantonment Board and Urban Affairs authorities";
                        objMCB.CreatedBy = hdnUserID.Value;
                        objMCB.IPAddress = getclientIP();
                        //objMCB.ReferenceNo = txtMCB.Text;
                        result = objcfebal.InsertCFEAttachments(objMCB);
                        if (result != "")
                        {
                            hypMCB.Text = fupMCB.PostedFile.FileName;
                            hypMCB.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupMCB.PostedFile.FileName);
                            hypMCB.Target = "blank";
                            message = "alert('" + "Clearances from Municipal or Cantonment Board and Urban Affairs authorities Document Uploaded successfully" + "')";
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
        protected void btnEnvClr_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupEnvClr.HasFile)
                {
                    Error = validations(fupEnvClr);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Environmental clearance from the concerned authorities Document" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupEnvClr.PostedFile.SaveAs(serverpath + "\\" + fupEnvClr.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupEnvClr.PostedFile.SaveAs(serverpath + "\\" + fupEnvClr.PostedFile.FileName);
                            }
                        }


                        CFEAttachments objEnvClr = new CFEAttachments();
                        objEnvClr.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objEnvClr.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objEnvClr.MasterID = "53";
                        objEnvClr.FilePath = serverpath + fupEnvClr.PostedFile.FileName;
                        objEnvClr.FileName = fupEnvClr.PostedFile.FileName;
                        objEnvClr.FileType = fupEnvClr.PostedFile.ContentType;
                        objEnvClr.FileDescription = "Environmental clearance from the concerned authorities Document";
                        objEnvClr.CreatedBy = hdnUserID.Value;
                        objEnvClr.IPAddress = getclientIP();
                        //objEnvClr.ReferenceNo = txtEnvClr.Text;
                        result = objcfebal.InsertCFEAttachments(objEnvClr);
                        if (result != "")
                        {
                            hypEnvClr.Text = fupEnvClr.PostedFile.FileName;
                            hypEnvClr.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupEnvClr.PostedFile.FileName);
                            hypEnvClr.Target = "blank";
                            message = "alert('" + "Environmental clearance from the concerned authorities Document Uploaded successfully" + "')";
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
        protected void btnSglWdw_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupSglWdw.HasFile)
                {
                    Error = validations(fupSglWdw);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFEAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFEQID"]) + "\\" + "Approval of the Single Window Agency of the Industries Departments Document" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);
                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupSglWdw.PostedFile.SaveAs(serverpath + "\\" + fupSglWdw.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupSglWdw.PostedFile.SaveAs(serverpath + "\\" + fupSglWdw.PostedFile.FileName);
                            }
                        }


                        CFEAttachments objSglWdw = new CFEAttachments();
                        objSglWdw.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objSglWdw.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objSglWdw.MasterID = "54";
                        objSglWdw.FilePath = serverpath + fupSglWdw.PostedFile.FileName;
                        objSglWdw.FileName = fupSglWdw.PostedFile.FileName;
                        objSglWdw.FileType = fupSglWdw.PostedFile.ContentType;
                        objSglWdw.FileDescription = "Approval of the Single Window Agency of the Industries Departments Document";
                        objSglWdw.CreatedBy = hdnUserID.Value;
                        objSglWdw.IPAddress = getclientIP();
                        //objSglWdw.ReferenceNo = txtSglWdw.Text;
                        result = objcfebal.InsertCFEAttachments(objSglWdw);
                        if (result != "")
                        {
                            hypSglWdw.Text = fupSglWdw.PostedFile.FileName;
                            hypSglWdw.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(serverpath + fupSglWdw.PostedFile.FileName);
                            hypSglWdw.Target = "blank";
                            message = "alert('" + "Approval of the Single Window Agency of the Industries Departments Document Uploaded successfully" + "')";
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

        protected void rblInPhase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblInPhase.SelectedValue == "Yes")
            {
                isLoadInPhase.Visible = true;
            }
            else if (rblInPhase.SelectedValue == "No")
            {
                isLoadInPhase.Visible = false;
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

        protected void ddlSubDiv_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlDist.SelectedValue.ToString() != "--Select--")
                {
                    ddlDist.Items.Clear();
                    AddSelect(ddlDist);
                    //lblPCBCategory.Text = "";
                    BindSubDivDistricts(ddlSubDiv.SelectedItem.Value);

                }
            }
            catch (Exception ex)
            {

                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }


        }
        protected void BindSubDivDistricts(string SubDiv)
        {
            try
            {
                List<MasterDistrcits> objLOA = mstrBAL.GetSubDivDistricts(Convert.ToInt32(SubDiv));

                if (objLOA != null && objLOA.Count > 0)
                {
                    ddlDist.DataSource = objLOA;
                    ddlDist.DataValueField = "DistrictId";
                    ddlDist.DataTextField = "DistrictName";
                    ddlDist.DataBind();
                }
                else
                {

                    ddlDist.DataSource = null;
                    ddlDist.DataBind();
                }

                AddSelect(ddlDist);
            }
            catch (Exception ex)
            {

                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void ddlDist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<MasterPincodes> objPincodes = mstrBAL.GetPincodes(Convert.ToInt32(ddlDist.SelectedValue));

                if (objPincodes != null && objPincodes.Count > 0)
                {
                    ddlPincode.DataSource = objPincodes;
                    ddlPincode.DataValueField = "Pincode_ID";
                    ddlPincode.DataTextField = "Pincode_NAME";
                    ddlPincode.DataBind();
                }
                else
                {

                    ddlPincode.DataSource = null;
                    ddlPincode.DataBind();
                }

                AddSelect(ddlPincode);
            }
            catch (Exception ex)
            {

                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

       
        protected void btnOccProof_Click(object sender, EventArgs e)
        {

        }

        public DataSet GetDataPower()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfebal.GetPowerDetailsAPI(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]));
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string Post(DataSet ds)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            using (var client = new HttpClient())
            {
                var url = "https://uat.mepdcl.trm.ieasybill.com/api/registration/new";

                var requestBody = new
                {
                    Subdivisonname = Convert.ToString(ds.Tables[0].Rows[0]["SUBDIVISIONNAME"]),
                    Subdivison = Convert.ToString(ds.Tables[0].Rows[0]["CFEPD_SUBDIVISION"]),
                    District = Convert.ToString(ds.Tables[0].Rows[0]["CFEPD_DISTRICT"]),
                    DistrictName = Convert.ToString(ds.Tables[0].Rows[0]["DistName"]),
                    //  Applicationfor = Convert.ToString(ds.Tables[0].Rows[0]["Applicationfor"]),
                    //Applicationtype = Convert.ToString(ds.Tables[0].Rows[0]["Applicationtype"]),
                    Applicationtype = Convert.ToInt32(ds.Tables[0].Rows[0]["Applicationtype"]),
                    Applicationfor = Convert.ToInt32(ds.Tables[0].Rows[0]["Applicationfor"]),
                    PinCode = Convert.ToInt32(ds.Tables[0].Rows[0]["CFEID_REPPINCODE"]),
                    state = Convert.ToInt32(ds.Tables[0].Rows[0]["CFEID_STATEID"]),
                    Address_of_inst = Convert.ToString(ds.Tables[0].Rows[0]["ADDRESS"]),
                    Owner_type = Convert.ToInt32(ds.Tables[0].Rows[0]["CFEQD_COMPANYTYPE"]),
                    Purpose = Convert.ToInt32(ds.Tables[0].Rows[0]["PROPOSALFOR"]),
                    AppliedLoad = Convert.ToInt32(ds.Tables[0].Rows[0]["AppliedLoad"]),
                    Applicatent_Name = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_REPNAME"]),
                    Father_name = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_REPSoWoDo"]),
                    MotherName = Convert.ToString(ds.Tables[0].Rows[0]["MOTHERNAME"]),
                    Mobile_number = Convert.ToString(ds.Tables[0].Rows[0]["Mobile_number"]),
                    Phone = Convert.ToString(ds.Tables[0].Rows[0]["Phone"]),
                    Email = Convert.ToString(ds.Tables[0].Rows[0]["Email"]),
                    Door_no = Convert.ToInt32(ds.Tables[0].Rows[0]["DOORNO"]),
                    Perm_Address = Convert.ToString(ds.Tables[0].Rows[0]["ADDRESSED"]),
                    Cast = Convert.ToString(ds.Tables[0].Rows[0]["CATEGORY"]),
                    IdentityProof = Convert.ToString(ds.Tables[0].Rows[0]["PROOF"]),
                    CreatedBy = Convert.ToString(ds.Tables[0].Rows[0]["CFEID_CREATEDBY"]),
                    CreatorName= Convert.ToString(ds.Tables[0].Rows[0]["CFEID_COMPANYNAME"]),
                    MIPA_ApplicationID= Convert.ToInt32(ds.Tables[0].Rows[0]["CFEID_CFEQDID"]),
                    lstDocuments = new[]
                    {
                    new {
                        documantId = 2,
                        documentName = "Proof of ownership/occupancy",
                        document_path = "doc1.pdf"
                    },
                    new {
                        documantId = 3,
                        documentName = "Proof of Identification",
                        document_path = "doc2.pdf"
                    }
                    }
                };
                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    var resultContent = response.Content.ReadAsStringAsync().Result;
                    dynamic Response = JsonConvert.DeserializeObject(resultContent);
                    string application_Reg_no = Response["application_Reg_no"]?.ToString();
                    string message = Response["message"]?.ToString();
                    hdnapiReg.Value = application_Reg_no;
                    return application_Reg_no + "," + message;
                }

                throw new Exception("Failed  " + response.StatusCode);
            }
        }
    }
}