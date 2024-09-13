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
                    BINDDATA();
                    //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    //{
                    //if (Convert.ToString(ds.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "3")
                    //{
                    //}
                    //if (Convert.ToString(ds.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "4")
                    //{
                    //}
                    //}
                }
                else
                {
                    if (Request.QueryString.Count > 0)
                    {
                        if (Convert.ToString(Request.QueryString[0]) == "N")
                            Response.Redirect("~/User/CFE/CFEDGSetDetails.aspx?Next=" + "N");
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
                    //ViewState["UnitID"] = Convert.ToString(ds.Tables[0].Rows[0]["CFEPD_UNITID"]);
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
                    CFEPower objCFEPower = new CFEPower();

                    objCFEPower.UNITID = Convert.ToString(Session["CFEUNITID"]);
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

                    result = objcfebal.InsertCFEPowerDetails(objCFEPower);

                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "POWER Details Submitted Successfully";
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
            }
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave_Click(sender, e);
                if (ErrorMsg == "")
                    Response.Redirect("~/User/CFE/CFEDGSetDetails.aspx?Next=" + "N");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
    }
}