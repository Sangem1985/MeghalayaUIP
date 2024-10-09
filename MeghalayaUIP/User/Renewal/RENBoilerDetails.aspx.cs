using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.RenewalBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Renewal
{
    public partial class RENBoilerDetails : System.Web.UI.Page
    {

        MasterBAL mstrBAL = new MasterBAL();
        RenewalBAL objRenbal = new RenewalBAL();
        string UnitID, ErrorMsg = "";
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
                    if (Convert.ToString(Session["RENUNITID"]) != "")
                    { UnitID = Convert.ToString(Session["RENUNITID"]); }
                    else
                    {
                        string newurl = "~/User/Renewal/RENUserDashboard.aspx";
                        Response.Redirect(newurl);
                    }
                    //Session["UNITID"] = "1001";
                    //UnitID = Convert.ToString(Session["UNITID"]);

                    Page.MaintainScrollPositionOnPostBack = true;
                    Failure.Visible = false;
                    success.Visible = false;
                    if (!IsPostBack)
                    {
                        GetAppliedorNot();
                    }
                }
            }
            catch(Exception ex)
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

                ds = objRenbal.GetRenAppliedApprovalID(hdnUserID.Value, Convert.ToString(Session["RENUNITID"]), Convert.ToString(Session["RENQID"]), "10", "69");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(ds.Tables[0].Rows[0]["RENDA_APPROVALID"]) == "69")
                    {
                        BindDistricts();
                        Binddata();
                    }
                }
                else
                {
                    if (Request.QueryString.Count > 0)
                    {
                        if (Convert.ToString(Request.QueryString[0]) == "N")
                            Response.Redirect("~/User/Renewal/RENShopsEstablishment.aspx?Next=" + "N");
                        else if (Convert.ToString(Request.QueryString[0]) == "P")
                            Response.Redirect("~/User/Renewal/RENSafetySecurityDetails.aspx?Previous=" + "P");
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
        protected void BindDistricts()
        {
            try
            {

                ddlDistrict.Items.Clear();
                ddlMandal.Items.Clear();
                ddlVillage.Items.Clear();

                List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();
                string strmode = string.Empty;
                //if (ObjUserInformation.User_Level == "2")
                //{
                strmode = "";
                //}
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
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

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlMandal.ClearSelection();
                ddlVillage.ClearSelection();
                if (ddlDistrict.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlMandal, ddlDistrict.SelectedValue);
                }
                else return;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlVillage.ClearSelection();
                if (ddlMandal.SelectedItem.Text != "--Select--")
                {

                    BindVillages(ddlVillage, ddlMandal.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void rblOwnership_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                if (rblOwnership.SelectedValue == "Y")
                {
                    Remark.Visible = true;
                }
                else { Remark.Visible = false; }
            }
            catch(Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
           // string Quesstionriids = "1001";
            try
            {
                string result = "";
                ErrorMsg = validations();
                if (ErrorMsg == "")
                {
                    RenBoilerDetails ObjRenBoilerDetails = new RenBoilerDetails();

                    ObjRenBoilerDetails.Questionnariid = Convert.ToString(Session["RENQID"]);
                    ObjRenBoilerDetails.CreatedBy = hdnUserID.Value;
                    ObjRenBoilerDetails.UnitId = Convert.ToString(Session["RENUNITID"]);
                    ObjRenBoilerDetails.IPAddress = getclientIP();

                    ObjRenBoilerDetails.LICNO = txtRenLic.Text;
                    ObjRenBoilerDetails.LICISSUEDDATE = txtLicIssDate.Text;
                    ObjRenBoilerDetails.LICVALIDDATE = txtLicValid.Text;
                    ObjRenBoilerDetails.BOILERWORK = txtBoilerDet.Text;
                    ObjRenBoilerDetails.FACTORYNAME = txtFactoryName.Text;
                    ObjRenBoilerDetails.ADDRESSFACTORY = txtEstAddress.Text;
                    ObjRenBoilerDetails.DISTRIC = ddlDistrict.SelectedValue;
                    ObjRenBoilerDetails.MANDAL = ddlMandal.SelectedValue;
                    ObjRenBoilerDetails.VILLAGE = ddlVillage.SelectedValue;
                    ObjRenBoilerDetails.LOCALITY = txtLocality.Text;
                    ObjRenBoilerDetails.PINCODE = txtPincode.Text;
                    ObjRenBoilerDetails.NAMEMANU = txtNameManu.Text;
                    ObjRenBoilerDetails.YEARMANU = txtYearManu.Text;
                    ObjRenBoilerDetails.PLACEMANU = txtManuPlace.Text;
                    ObjRenBoilerDetails.BOILERNO = txtBoilerNo.Text;
                    ObjRenBoilerDetails.INTENDED = txtIntended.Text;
                    ObjRenBoilerDetails.FUEL = ddlFuel.SelectedValue;
                    ObjRenBoilerDetails.HEATERRATING = txtHeater.Text;
                    ObjRenBoilerDetails.ECONOMISERATING = txtEconomiser.Text;
                    ObjRenBoilerDetails.MAXIMUMEVAPORATION = txtEvaporation.Text;
                    ObjRenBoilerDetails.REHEATER = txtReHeater.Text;
                    ObjRenBoilerDetails.WORKINGSEASON = ddlWorkingsea.SelectedValue;
                    ObjRenBoilerDetails.WORKINGPRESSURE = txtPressure.Text;
                    ObjRenBoilerDetails.NAMEOWNER = txtNameOwner.Text;
                    ObjRenBoilerDetails.BOILERTYPE = ddlBoilerType.SelectedValue;
                    ObjRenBoilerDetails.DESCBOILER = txtDescBoiler.Text;
                    ObjRenBoilerDetails.BOILERRATING = ddlBoilerRate.SelectedValue;
                    ObjRenBoilerDetails.BOILEROWNERSHIP = rblOwnership.SelectedValue;
                    ObjRenBoilerDetails.REMARKSTR = txtRemaek.Text;
                    ObjRenBoilerDetails.REGNO = txtRegNo.Text;
                    ObjRenBoilerDetails.BOILEROFTYPE = ddlboiler.SelectedValue;
                    ObjRenBoilerDetails.BOILERRATINGS = ddlRatingBoiler.SelectedValue;
                    ObjRenBoilerDetails.BOILERSITUATED = txtPlantSituated.Text;
                    ObjRenBoilerDetails.MANUFACTUREPLACE = txtManufacture.Text;
                    ObjRenBoilerDetails.MANUFACTUREYEAR = txtYearManufacture.Text;
                    ObjRenBoilerDetails.OWNERNAMES = txtOwner.Text;
                    ObjRenBoilerDetails.MAXCOUNT = txtMaxCount.Text;
                    ObjRenBoilerDetails.MAXIMUMPRESSURE = txtMaxPressure.Text;
                    ObjRenBoilerDetails.REPAIRS = txtRepaire.Text;
                    ObjRenBoilerDetails.HYDRAULICALLY = txtHydraulical.Text;
                    ObjRenBoilerDetails.UPTO = txtUpto.Text;
                    ObjRenBoilerDetails.LOADING = txtLoading.Text;
                    ObjRenBoilerDetails.SAFETY = txtSaftey.Text;
                    ObjRenBoilerDetails.PERIODDATE = txtPeriodDate.Text;
                    ObjRenBoilerDetails.TODATE = txtDateTo.Text;
                    ObjRenBoilerDetails.REMARK = txtRemarktype.Text;
                    ObjRenBoilerDetails.REGFEES = txtRegFees.Text;
                    ObjRenBoilerDetails.TOTALAMOUNT = txtAmountPaid.Text;

                    result = objRenbal.InsertRENBoilerDetails(ObjRenBoilerDetails);

                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "Renewal Boiler Details Submitted Successfully";
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
        public string validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                if (string.IsNullOrEmpty(txtRenLic.Text) || txtRenLic.Text == "" || txtRenLic.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter License Renewal Required\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLicIssDate.Text) || txtLicIssDate.Text == "" || txtLicIssDate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter License Issued Date\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLicValid.Text) || txtLicValid.Text == "" || txtLicValid.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter License Valid Date\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtBoilerDet.Text) || txtBoilerDet.Text == "" || txtBoilerDet.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Work or Plant where Boiler situated\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtFactoryName.Text) || txtFactoryName.Text == "" || txtFactoryName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Factory/Establishment Name\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEstAddress.Text) || txtEstAddress.Text == "" || txtEstAddress.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Address of Factory/Establishment\\n";
                    slno = slno + 1;
                }
                if (ddlDistrict.SelectedIndex == -1 || ddlDistrict.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Unit District \\n";
                    slno = slno + 1;
                }
                if (ddlMandal.SelectedIndex == -1 || ddlMandal.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Unit Mandal/Taluka \\n";
                    slno = slno + 1;
                }
                if (ddlVillage.SelectedIndex == -1 || ddlVillage.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Unit Village \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLocality.Text) || txtLocality.Text == "" || txtLocality.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Locality \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPincode.Text) || txtPincode.Text == "" || txtPincode.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Unit PinCode \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNameManu.Text) || txtNameManu.Text == "" || txtNameManu.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name of the Manufacturer\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtYearManu.Text) || txtYearManu.Text == "" || txtYearManu.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Year of Manufacture\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtManuPlace.Text) || txtManuPlace.Text == "" || txtManuPlace.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Place of Manufacture\\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtBoilerNo.Text) || txtBoilerNo.Text == "" || txtBoilerNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Boiler Maker's Number\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtIntended.Text) || txtIntended.Text == "" || txtIntended.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Intended Working Pressure\\n";
                    slno = slno + 1;
                }
                //if (ddlFuel.SelectedIndex == -1 || ddlFuel.SelectedItem.Text == "--Select--")
                //{
                //    errormsg = errormsg + slno + ". Please Select Fuel use \\n";
                //    slno = slno + 1;
                //}
                if (string.IsNullOrEmpty(txtHeater.Text) || txtHeater.Text == "" || txtHeater.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Super Heater Rating\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEconomiser.Text) || txtEconomiser.Text == "" || txtEconomiser.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Economiser Rating\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEvaporation.Text) || txtEvaporation.Text == "" || txtEvaporation.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Maximum Continuous Evaporation\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtReHeater.Text) || txtReHeater.Text == "" || txtReHeater.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Re-Heater Rating\\n";
                    slno = slno + 1;
                }
                //if (ddlWorkingsea.SelectedIndex == -1 || ddlWorkingsea.SelectedItem.Text == "--Select--")
                //{
                //    errormsg = errormsg + slno + ". Please Select Working Season \\n";
                //    slno = slno + 1;
                //}
                if (string.IsNullOrEmpty(txtPressure.Text) || txtPressure.Text == "" || txtPressure.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Working Pressure\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNameOwner.Text) || txtNameOwner.Text == "" || txtNameOwner.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name of Owner\\n";
                    slno = slno + 1;
                }
                //if (ddlBoilerType.SelectedIndex == -1 || ddlBoilerType.SelectedItem.Text == "--Select--")
                //{
                //    errormsg = errormsg + slno + ". Please Select Boiler Type \\n";
                //    slno = slno + 1;
                //}
                if (string.IsNullOrEmpty(txtDescBoiler.Text) || txtDescBoiler.Text == "" || txtDescBoiler.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Description Of Boiler\\n";
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
                ds = objRenbal.GetRenBoilerDetails(hdnUserID.Value, UnitID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["UnitID"] = Convert.ToString(ds.Tables[0].Rows[0]["RENBD_UNITID"]);
                    txtRenLic.Text = ds.Tables[0].Rows[0]["RENBD_LICNO"].ToString();
                    txtLicIssDate.Text = ds.Tables[0].Rows[0]["RENBD_LICNO"].ToString();
                    txtLicValid.Text = ds.Tables[0].Rows[0]["RENBD_LICVALIDDATE"].ToString();
                    txtBoilerDet.Text = ds.Tables[0].Rows[0]["RENBD_BOILERPLANT"].ToString();
                    txtFactoryName.Text = ds.Tables[0].Rows[0]["RENBD_FACTORYNAME"].ToString();
                    txtEstAddress.Text = ds.Tables[0].Rows[0]["RENBD_FACTORYADDRESS"].ToString();
                    ddlDistrict.SelectedValue = ds.Tables[0].Rows[0]["RENBD_DISTRIC"].ToString();
                    ddlDistrict_SelectedIndexChanged(null, EventArgs.Empty);
                    ddlMandal.SelectedValue = ds.Tables[0].Rows[0]["RENBD_MANDAL"].ToString();
                    ddlMandal_SelectedIndexChanged(null, EventArgs.Empty);
                    ddlVillage.SelectedValue = ds.Tables[0].Rows[0]["RENBD_VILLAGE"].ToString();
                    txtLocality.Text = ds.Tables[0].Rows[0]["RENBD_LOCALITY"].ToString();
                    txtPincode.Text = ds.Tables[0].Rows[0]["RENBD_PINCODE"].ToString();
                    txtNameManu.Text = ds.Tables[0].Rows[0]["RENBD_NAMEMANU"].ToString();
                    txtYearManu.Text = ds.Tables[0].Rows[0]["RENBD_YEARMANU"].ToString();
                    txtManuPlace.Text = ds.Tables[0].Rows[0]["RENBD_PLACEMANU"].ToString();
                    txtBoilerNo.Text = ds.Tables[0].Rows[0]["RENBD_BOILERMAKERNO"].ToString();
                    txtIntended.Text = ds.Tables[0].Rows[0]["RENBD_INTENDEDPRESSURE"].ToString();
                    ddlFuel.SelectedValue = ds.Tables[0].Rows[0]["RENBD_FULE"].ToString();
                    txtHeater.Text = ds.Tables[0].Rows[0]["RENBD_SUPERHEATER"].ToString();
                    txtEconomiser.Text = ds.Tables[0].Rows[0]["RENBD_ECONOMISERRATING"].ToString();
                    txtEvaporation.Text = ds.Tables[0].Rows[0]["RENBD_MAXIMUMEVAPORATION"].ToString();
                    txtReHeater.Text = ds.Tables[0].Rows[0]["RENBD_REHEATERRATING"].ToString();
                    ddlWorkingsea.SelectedValue = ds.Tables[0].Rows[0]["RENBD_WORKINGSEASON"].ToString();
                    txtPressure.Text = ds.Tables[0].Rows[0]["RENBD_WORKINGPRESSURE"].ToString();
                    txtNameOwner.Text = ds.Tables[0].Rows[0]["RENBD_NAMEOWNER"].ToString();
                    ddlBoilerType.SelectedValue = ds.Tables[0].Rows[0]["RENBD_TYPEBOILER"].ToString();
                    txtDescBoiler.Text = ds.Tables[0].Rows[0]["RENBD_DESCBOILER"].ToString();
                    ddlBoilerRate.SelectedValue = ds.Tables[0].Rows[0]["RENBD_BOILERRATE"].ToString();
                    rblOwnership.SelectedValue = ds.Tables[0].Rows[0]["RENBD_BOILEROWNERSHIP"].ToString();
                    if (rblOwnership.SelectedValue == "Y")
                    {
                        Remark.Visible = true;
                    }
                    else { Remark.Visible = false; }
                    txtRemaek.Text = ds.Tables[0].Rows[0]["RENBD_REMARKSTRANS"].ToString();
                    txtRegNo.Text = ds.Tables[0].Rows[0]["RENBD_REGNO"].ToString();
                    ddlboiler.SelectedValue = ds.Tables[0].Rows[0]["RENBD_BOILERTY"].ToString();
                    ddlRatingBoiler.SelectedValue = ds.Tables[0].Rows[0]["RENBD_BOILERRATING"].ToString();
                    txtPlantSituated.Text = ds.Tables[0].Rows[0]["RENBD_WORKPLANTBOILER"].ToString();
                    txtManufacture.Text = ds.Tables[0].Rows[0]["RENBD_PLACEMANUFACTURE"].ToString();
                    txtYearManufacture.Text = ds.Tables[0].Rows[0]["RENBD_YEARMANUFACTURE"].ToString();
                    txtOwner.Text = ds.Tables[0].Rows[0]["RENBD_NAMEMANUFACTURE"].ToString();
                    txtMaxCount.Text = ds.Tables[0].Rows[0]["RENBD_MAXCOUNT"].ToString();
                    txtMaxPressure.Text = ds.Tables[0].Rows[0]["RENBD_MAXIMUMPRESSURE"].ToString();
                    txtRepaire.Text = ds.Tables[0].Rows[0]["RENBD_REPAIRS"].ToString();
                    txtHydraulical.Text = ds.Tables[0].Rows[0]["RENBD_HYDRAULICALLY"].ToString();
                    txtUpto.Text = ds.Tables[0].Rows[0]["RENBD_UPTO"].ToString();
                    txtLoading.Text = ds.Tables[0].Rows[0]["RENBD_LOADING"].ToString();
                    txtSaftey.Text = ds.Tables[0].Rows[0]["RENBD_SAFTEY"].ToString();
                    txtPeriodDate.Text = ds.Tables[0].Rows[0]["RENBD_PERIODDATE"].ToString();
                    txtDateTo.Text = ds.Tables[0].Rows[0]["RENBD_TODATE"].ToString();
                    txtRemarktype.Text = ds.Tables[0].Rows[0]["RENBD_REMARK"].ToString();
                    txtRegFees.Text = ds.Tables[0].Rows[0]["RENBD_REGFEES"].ToString();
                    txtAmountPaid.Text = ds.Tables[0].Rows[0]["RENBD_TOTALAMOUNT"].ToString();

                }
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
                    Response.Redirect("~/User/Renewal/RENShopsEstablishment.aspx?Next=" + "N");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnPreviuos_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/Renewal/RENDrugsLicenseDetails.aspx?Previous=" + "P");
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