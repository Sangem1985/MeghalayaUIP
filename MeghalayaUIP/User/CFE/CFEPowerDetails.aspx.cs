using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace MeghalayaUIP.User.CFE
{
    public partial class CFEPowerDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFEBAL objcfebal = new CFEBAL();
        string UnitID;
        protected void Page_Load(object sender, EventArgs e)
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
                    BindVoltages();
                    BindENERGYLOAD();
                    GetAppliedorNot();
                    BINDDATA();
                }
            }
        }
        protected void GetAppliedorNot()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfebal.GetAppliedApprovalIDs(hdnUserID.Value, Convert.ToString(Session["CFEUNITID"]), Convert.ToString(Session["CFEQID"]), "14");


                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (Convert.ToString(ds.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "25")
                        {
                            //divsupervision.Visible = true;
                            //divContrLabr.Visible = true;
                        }
                        if (Convert.ToString(ds.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "26")
                        {
                            //divsupervision.Visible = true;
                            //divMigrLabr.Visible = true;
                        }
                        if (Convert.ToString(ds.Tables[0].Rows[i]["CFEDA_APPROVALID"]) == "27")
                        {
                            //div4questions.Visible = true;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }
        }

        public string Stepvalidations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                if (string.IsNullOrEmpty(txtHP.Text) || txtHP.Text == "" || txtHP.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Load Connected  \\n";
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
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
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
            }
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/CFE/CFELabourDetails.aspx");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {


            try
            {
                string ErrorMsg = "", result = "";
                ErrorMsg = Stepvalidations();
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
                    // ViewState["UnitID"] = result;
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
                }
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/CFE/CFEFireDetails.aspx");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
    }
}