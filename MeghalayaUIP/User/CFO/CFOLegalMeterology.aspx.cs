using MeghalayaUIP.BAL.CFOBAL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using Org.BouncyCastle.Bcpg.Sig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFO
{
    public partial class CFOLegalMeterology : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFOBAL objcfobal = new CFOBAL();
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

                    if (Convert.ToString(Session["CFOUNITID"]) != "")
                    {
                        UnitID = Convert.ToString(Session["CFOUNITID"]);
                    }
                    else
                    {
                        string newurl = "~/User/CFO/CFOUserDashboard.aspx";
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void GetAppliedorNot()
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = objcfobal.GetApprovalDataByDeptId(hdnUserID.Value, Convert.ToString(Session["CFOUNITID"]), Convert.ToString(Session["CFOQID"]), "11", "");
                if (dsnew.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsnew.Tables[0].Rows.Count; i++)
                    {
                        //Licence as Repairers of Weights &Measures  40
                        //Licence as Manufacturer of Weights &Measures 41
                        //Licence as Dealers in Weights & Measures 42
                        //Initial Verification And Stamping of Weighing and Measuring Instrument 43	
                        if (Convert.ToString(dsnew.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "40")
                        {
                            divManfReprDlr.Visible = true;
                            divManfRepr.Visible = true;
                            divRepr.Visible = true;
                        }
                        if (Convert.ToString(dsnew.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "41")
                        {
                            divManfReprDlr.Visible = true;
                            divManfRepr.Visible = true;
                            divManf.Visible = true;
                        }
                        if (Convert.ToString(dsnew.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "42")
                        {
                            divManfReprDlr.Visible = true;
                            divDlr.Visible = true;
                        }
                        if (Convert.ToString(dsnew.Tables[0].Rows[i]["CFODA_APPROVALID"]) == "43")
                        {
                            intialverification.Visible = true;
                        }
                        Binddata();
                    }
                }
                else
                {
                    if (Request.QueryString[0].ToString() == "N")
                    {
                        Response.Redirect("~/User/CFO/CFOContractorsRegistration.aspx?next=N");
                    }
                    else
                    {
                        Response.Redirect("~/User/CFO/CFOLabourDetails.aspx?Previous=P");
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
        public void Binddata()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfobal.GetLegalMeterologyDet(hdnUserID.Value, UnitID);
                if (ds.Tables[1].Rows.Count > 0)
                {

                    ViewState["UnitID"] = Convert.ToString(ds.Tables[1].Rows[0]["CFOLGM_CFOUNITID"]);
                    txtESTDate.Text = ds.Tables[1].Rows[0]["CFOLGM_ESTBLSHDATE"].ToString();
                    rblfactory.SelectedValue = ds.Tables[1].Rows[0]["CFOLGM_HADESTBLSHREG"].ToString();
                    if (rblfactory.SelectedValue == "Y")
                    {
                        Registration.Visible = true;
                        txtRegDate.Text = ds.Tables[1].Rows[0]["CFOLGM_ESTBLSHREGDATE"].ToString();
                        txtRegNumber.Text = ds.Tables[1].Rows[0]["CFOLGM_ESTBLSHREGNO"].ToString();
                    }
                    else { Registration.Visible = false; }

                    rblMunicipal.SelectedValue = ds.Tables[1].Rows[0]["CFOLGM_HADMTLREG"].ToString();
                    if (rblMunicipal.SelectedValue == "Y")
                    {
                        ADCLicense.Visible = true;
                        txtDate.Text = ds.Tables[1].Rows[0]["CFOLGM_MTLREGDATE"].ToString();
                        txtcurrentReg.Text = ds.Tables[1].Rows[0]["CFOLGM_MTLREGNO"].ToString();
                    }
                    else
                    {
                        ADCLicense.Visible = false;
                    }
                    txtWeight.Text = ds.Tables[1].Rows[0]["CFOLGM_WEIGHS"].ToString();
                    txtMeasure.Text = ds.Tables[1].Rows[0]["CFOLGM_MEASURES"].ToString();
                    txtInstruWeight.Text = ds.Tables[1].Rows[0]["CFOLGM_WEIGHINGINSTR"].ToString();
                    txtTaxReg.Text = ds.Tables[1].Rows[0]["CFOLGM_PROFTAXREGNO"].ToString();
                    txtGST.Text = ds.Tables[1].Rows[0]["CFOLGM_GSTREGNO"].ToString();
                    txtITNmumber.Text = ds.Tables[1].Rows[0]["CFOLGM_ITNO"].ToString();
                    rblState.SelectedValue = ds.Tables[1].Rows[0]["CFOLGM_ISIMPORTING"].ToString();
                    if (rblState.SelectedValue == "Y")
                    {
                        State.Visible = true;
                        Country.Visible = true;
                        txtLICNumber.Text = ds.Tables[1].Rows[0]["CFOLGM_IMPORTLICNO"].ToString();
                        txtRegWeight.Text = ds.Tables[1].Rows[0]["CFOLGM_REGOFIMPORTER"].ToString();
                    }
                    else
                    {
                        State.Visible = false;
                        Country.Visible = false;
                    }

                    rblstateside.SelectedValue = ds.Tables[1].Rows[0]["CFOLGM_SELLINGPLACE"].ToString();
                    rblDealer.SelectedValue = ds.Tables[1].Rows[0]["CFOLGM_DEALERLICAPPLIED"].ToString();
                    if (rblDealer.SelectedValue == "Y")
                    {
                        DealerLic.Visible = true;
                        txtGiveDetails.Text = ds.Tables[1].Rows[0]["CFOLGM_DEALERLICDETAILS"].ToString();
                    }
                    else { DealerLic.Visible = false; }

                    txtskilled.Text = ds.Tables[1].Rows[0]["CFOLGM_SKILLEDEMP"].ToString();
                    txtsemiskilled.Text = ds.Tables[1].Rows[0]["CFOLGM_SEMISKILLEDEMP"].ToString();
                    txtunskilled.Text = ds.Tables[1].Rows[0]["CFOLGM_UNSKILLEDEMP"].ToString();
                    txttrained.Text = ds.Tables[1].Rows[0]["CFOLGM_TRAINEDEMP"].ToString();
                    txtmanuowned.Text = ds.Tables[1].Rows[0]["CFOLGM_MACHINERYDETAILS"].ToString();
                    txtownership.Text = ds.Tables[1].Rows[0]["CFOLGM_WORKSHOPDETAILS"].ToString();
                    txtsteel.Text = ds.Tables[1].Rows[0]["CFOLGM_TESTFACILITIES"].ToString();
                    rblelectric.SelectedValue = ds.Tables[1].Rows[0]["CFOLGM_ELCENRGYAVLBL"].ToString();
                    rblLicdealer.SelectedValue = ds.Tables[1].Rows[0]["CFOLGM_MANFLICAPPLIED"].ToString();
                    if (rblLicdealer.SelectedValue == "Y")
                    {
                        applieddealer.Visible = true;
                        txtDetails.Text = ds.Tables[1].Rows[0]["CFOLGM_MANFLICDETAILS"].ToString();
                    }
                    else { applieddealer.Visible = false; }

                    rblInstitute.SelectedValue = ds.Tables[1].Rows[0]["CFOLGM_LOANAVAILED"].ToString();
                    if (rblInstitute.SelectedValue == "Y")
                    {
                        NameBanker.Visible = true;
                        txtBanker.Text = ds.Tables[1].Rows[0]["CFOLGM_LOANBANKERS"].ToString();
                    }
                    else { NameBanker.Visible = false; }

                    if (rblInstitute.SelectedValue == "Y")
                    {
                        DetailsGet.Visible = true;
                        txtGetDetails.Text = ds.Tables[1].Rows[0]["CFOLGM_LOANDETAILS"].ToString();
                    }
                    else { DetailsGet.Visible = false; }

                    rblLoan.SelectedValue = ds.Tables[1].Rows[0]["CFOLGM_HADSUFFSTOCK"].ToString();
                    if (rblLoan.SelectedValue == "Y")
                    {
                        weightloan.Visible = true;
                        txtDetailsGET.Text = ds.Tables[1].Rows[0]["CFOLGM_STOCKDETAILS"].ToString();
                    }
                    else { weightloan.Visible = false; }

                    rblRepaire.SelectedValue = ds.Tables[1].Rows[0]["CFOLGM_REPAIRERLICAPPLIED"].ToString();
                    if (rblRepaire.Text == "Y")
                    {
                        License.Visible = true;
                        txtResults.Text = ds.Tables[1].Rows[0]["CFOLGM_REPAIRERLICDETAILS"].ToString();
                    }
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    ViewState["LegalDepartment"] = ds.Tables[2];
                    GVLegalDept.DataSource = ds.Tables[2];
                    GVLegalDept.DataBind();
                    GVLegalDept.Visible = true;
                }
                if (ds.Tables[3].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
                    {
                        if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 113)//
                        {
                            hypTaxClearance.Visible = true;
                            hypTaxClearance.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                            hypTaxClearance.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 114) //
                        {
                            hypweight.Visible = true;
                            hypweight.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                            hypweight.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 115) //
                        {
                            hypLabourLic.Visible = true;
                            hypLabourLic.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                            hypLabourLic.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 116)//
                        {
                            hypLease.Visible = true;
                            hypLease.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                            hypLease.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 117) //
                        {
                            hypGSTReg.Visible = true;
                            hypGSTReg.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                            hypGSTReg.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 118) //
                        {
                            hypTax.Visible = true;
                            hypTax.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                            hypTax.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 119) //
                        {
                            hypLabour.Visible = true;
                            hypLabour.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                            hypLabour.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
                        }
                        if (Convert.ToInt32(ds.Tables[3].Rows[i]["CFOA_MASTERAID"]) == 120) //
                        {
                            hypADC.Visible = true;
                            hypADC.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILEPATH"]));
                            hypADC.Text = Convert.ToString(ds.Tables[3].Rows[i]["CFOA_FILENAME"]);
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

        protected void btnAddDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtinstrment.Text) || string.IsNullOrEmpty(txtClass.Text) || string.IsNullOrEmpty(txtCapacity.Text) || string.IsNullOrEmpty(txtMake.Text) || string.IsNullOrEmpty(txtModel.Text) || string.IsNullOrEmpty(txtSerial.Text) || string.IsNullOrEmpty(txtProduct.Text) || string.IsNullOrEmpty(txtQuantity.Text))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("CFOLMI_CFOUNITID", typeof(string));
                    dt.Columns.Add("CFOLMI_CREATEDBY", typeof(string));
                    dt.Columns.Add("CFOLMI_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("CFOLMI_INSTRTYPE", typeof(string));
                    dt.Columns.Add("CFOLMI_INSTRCLASS", typeof(string));
                    dt.Columns.Add("CFOLMI_INSTRCAPACITY", typeof(string));
                    dt.Columns.Add("CFOLMI_INSTRMAKE", typeof(string));
                    dt.Columns.Add("CFOLMI_INSTRMODELNO", typeof(string));
                    dt.Columns.Add("CFOLMI_INSTRSLNO", typeof(string));
                    dt.Columns.Add("CFOLMI_INSTRPRODUCT", typeof(string));
                    dt.Columns.Add("CFOLMI_INSTRQUANTITY", typeof(string));

                    if (ViewState["LegalDepartment"] != null)
                    {
                        dt = (DataTable)ViewState["LegalDepartment"];
                    }

                    DataRow dr = dt.NewRow();
                    dr["CFOLMI_CFOUNITID"] = Convert.ToString(Session["CFOUNITID"]);
                    dr["CFOLMI_CREATEDBY"] = hdnUserID.Value;
                    dr["CFOLMI_CREATEDBYIP"] = getclientIP();
                    dr["CFOLMI_INSTRTYPE"] = txtinstrment.Text;
                    dr["CFOLMI_INSTRCLASS"] = txtClass.Text;
                    dr["CFOLMI_INSTRCAPACITY"] = txtCapacity.Text;
                    dr["CFOLMI_INSTRMAKE"] = txtMake.Text;
                    dr["CFOLMI_INSTRMODELNO"] = txtModel.Text;
                    dr["CFOLMI_INSTRSLNO"] = txtSerial.Text;
                    dr["CFOLMI_INSTRPRODUCT"] = txtProduct.Text;
                    dr["CFOLMI_INSTRQUANTITY"] = txtQuantity.Text;

                    dt.Rows.Add(dr);
                    GVLegalDept.Visible = true;
                    GVLegalDept.DataSource = dt;
                    GVLegalDept.DataBind();
                    ViewState["LegalDepartment"] = dt;

                    txtinstrment.Text = "";
                    txtClass.Text = "";
                    txtCapacity.Text = "";
                    txtMake.Text = "";
                    txtModel.Text = "";
                    txtSerial.Text = "";
                    txtProduct.Text = "";
                    txtQuantity.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void rblfactory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                if (rblfactory.SelectedItem.Text == "Yes")
                {
                    Registration.Visible = true;
                }
                else
                {
                    Registration.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblfactory.BorderColor = System.Drawing.Color.White;
        }

        protected void rblMunicipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblMunicipal.SelectedItem.Text == "Yes")
                {
                    ADCLicense.Visible = true;
                }
                else
                {
                    ADCLicense.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblMunicipal.BorderColor = System.Drawing.Color.White;
        }

        protected void rblState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                if (rblState.SelectedItem.Text == "Yes")
                {
                    State.Visible = true;
                    Country.Visible = true;
                }
                else
                {
                    State.Visible = false;
                    Country.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblState.BorderColor = System.Drawing.Color.White;
        }

        protected void rblDealer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (rblDealer.SelectedItem.Text == "Yes")
                {
                    DealerLic.Visible = true;
                }
                else
                {
                    DealerLic.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblDealer.BorderColor = System.Drawing.Color.White;
        }

        protected void rblLicdealer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                if (rblLicdealer.SelectedItem.Text == "Yes")
                {
                    applieddealer.Visible = true;
                }
                else
                {
                    applieddealer.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblLicdealer.BorderColor = System.Drawing.Color.White;
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {

            try
            {

                ErrorMsg = Validations();
                if (ErrorMsg == "")
                {
                    CFOLEGALMETROLOGYDEP ObjCFOlegalDet = new CFOLEGALMETROLOGYDEP();
                    int count = 0;
                    for (int i = 0; i < GVLegalDept.Rows.Count; i++)
                    {
                        ObjCFOlegalDet.Questionnariid = Convert.ToString(Session["CFOQID"]);
                        ObjCFOlegalDet.CreatedBy = hdnUserID.Value;
                        ObjCFOlegalDet.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        ObjCFOlegalDet.IPAddress = getclientIP();
                        ObjCFOlegalDet.Instrumenttype = GVLegalDept.Rows[i].Cells[1].Text;
                        ObjCFOlegalDet.Class = GVLegalDept.Rows[i].Cells[2].Text;
                        ObjCFOlegalDet.Capacity = GVLegalDept.Rows[i].Cells[3].Text;
                        ObjCFOlegalDet.Make = GVLegalDept.Rows[i].Cells[4].Text;
                        ObjCFOlegalDet.Model = GVLegalDept.Rows[i].Cells[5].Text;
                        ObjCFOlegalDet.SerialNo = GVLegalDept.Rows[i].Cells[6].Text;
                        ObjCFOlegalDet.Product = GVLegalDept.Rows[i].Cells[7].Text;
                        ObjCFOlegalDet.Quantity = GVLegalDept.Rows[i].Cells[8].Text;


                        string A = objcfobal.InsertCFOLegalMetrologyDet(ObjCFOlegalDet);
                        if (A != "")
                        { count = count + 1; }
                    }
                    if (GVLegalDept.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = "CFO Metrology Details Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }

                    ObjCFOlegalDet.UNITID = Convert.ToString(Session["CFOUNITID"]);
                    ObjCFOlegalDet.CreatedBy = hdnUserID.Value;
                    ObjCFOlegalDet.IPAddress = getclientIP();
                    ObjCFOlegalDet.Questionnariid = Convert.ToString(Session["CFOQID"]);
                    ObjCFOlegalDet.UnitId = Convert.ToString(Session["CFOUNITID"]);

                    ObjCFOlegalDet.DateEstablish = txtESTDate.Text;
                    ObjCFOlegalDet.RegFactoryShop = rblfactory.SelectedValue;
                    ObjCFOlegalDet.DateReg = txtRegDate.Text;
                    ObjCFOlegalDet.CurrentRegNumber = txtRegNumber.Text;
                    ObjCFOlegalDet.LicADCnO = rblMunicipal.SelectedValue;
                    ObjCFOlegalDet.RegDateNo = txtDate.Text;
                    ObjCFOlegalDet.RegCurrentNo = txtcurrentReg.Text;
                    //ObjCFOlegalDet.PatnershipFirm = rblFirm.SelectedValue;
                    //ObjCFOlegalDet.CompanyLimited = rblLimit.SelectedValue;
                    //ObjCFOlegalDet.Name = txtName.Text.Trim();
                    // ObjCFOlegalDet.Address = txtAddress.Text;
                    ObjCFOlegalDet.Weight = txtWeight.Text;
                    ObjCFOlegalDet.Measures = txtMeasure.Text;
                    ObjCFOlegalDet.WeightingIns = txtInstruWeight.Text;
                    ObjCFOlegalDet.ProfessionalTax = txtTaxReg.Text;
                    ObjCFOlegalDet.GST = txtGST.Text;
                    ObjCFOlegalDet.ITNUMBER = txtITNmumber.Text;
                    ObjCFOlegalDet.StateCountry = rblState.SelectedValue;
                    ObjCFOlegalDet.LICNUMBER = txtLICNumber.Text;
                    ObjCFOlegalDet.WeightMeasure = txtRegWeight.Text;
                    ObjCFOlegalDet.StateSide = rblstateside.SelectedValue;
                    ObjCFOlegalDet.LICDeal = rblDealer.SelectedValue;
                    ObjCFOlegalDet.GiveDetails = txtGiveDetails.Text;
                    ObjCFOlegalDet.Skilled = txtskilled.Text;
                    ObjCFOlegalDet.SemiSkilled = txtsemiskilled.Text;
                    ObjCFOlegalDet.Unskilled = txtunskilled.Text;
                    ObjCFOlegalDet.SpecialistTrain = txttrained.Text;
                    ObjCFOlegalDet.MachinaryOwn = txtmanuowned.Text;
                    ObjCFOlegalDet.ownershiplong = txtownership.Text;
                    ObjCFOlegalDet.FacilitiesSteel = txtsteel.Text;
                    ObjCFOlegalDet.ElectricEnergy = rblelectric.SelectedValue;
                    ObjCFOlegalDet.GiveDetailsin = txtDetails.Text;
                    ObjCFOlegalDet.LICState = rblLicdealer.SelectedValue;
                    ObjCFOlegalDet.Institution = rblInstitute.SelectedValue;
                    ObjCFOlegalDet.NameBankers = txtBanker.Text.Trim();
                    ObjCFOlegalDet.DetailsDet = txtGetDetails.Text;
                    ObjCFOlegalDet.stock = rblLoan.SelectedValue;
                    ObjCFOlegalDet.GetDetails = txtDetailsGET.Text;
                    ObjCFOlegalDet.repairerLic = rblRepaire.SelectedValue;
                    ObjCFOlegalDet.results = txtResults.Text.Trim();

                    result = objcfobal.InsertCFOLegalMetrologyDetails(ObjCFOlegalDet);

                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "Legal Meterology Details Submitted Successfully";
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



        public string Validations()
        {
            try
            {
                int slno = 1;
                List<TextBox> emptyTextboxes = FindEmptyTextboxes(divText);
                List<DropDownList> emptyDropdowns = FindEmptyDropdowns(divText);
                List<RadioButtonList> emptyRadioButtonLists = FindEmptyRadioButtonLists(divText);
                string errormsg = "";


                if (divManfReprDlr.Visible == true)
                {
                    if (string.IsNullOrEmpty(txtESTDate.Text) || txtESTDate.Text == "" || txtESTDate.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Date of establishment\\n";
                        slno = slno + 1;
                    }
                    if (rblFirm.SelectedIndex == -1 || rblFirm.SelectedItem.Text == "--Select--")
                    {
                        errormsg = errormsg + slno + ". Please Select Is it a partnership firm? \\n";
                        slno = slno + 1;
                    }
                    if (rblLimit.SelectedIndex == -1 || rblLimit.SelectedItem.Text == "--Select--")
                    {
                        errormsg = errormsg + slno + ". Please Select Is it a limited company? \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtTaxReg.Text) || txtTaxReg.Text == "" || txtTaxReg.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Professional Tax\\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtGST.Text) || txtGST.Text == "" || txtGST.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter GST\\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtITNmumber.Text) || txtITNmumber.Text == "" || txtITNmumber.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter IT NUMBER\\n";
                        slno = slno + 1;
                    }
                    if (rblfactory.SelectedIndex == -1)
                    {
                        errormsg = errormsg + slno + ". Please Select  Yes or No current registration number of factory/ shop/ establishment? \\n";
                        slno = slno + 1;
                    }
                    if (rblfactory.SelectedValue == "Y")
                    {
                        if (string.IsNullOrEmpty(txtRegDate.Text) || txtRegDate.Text == "" || txtRegDate.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter Reg Date\\n";
                            slno = slno + 1;
                        }
                        if (string.IsNullOrEmpty(txtRegNumber.Text) || txtRegNumber.Text == "" || txtRegNumber.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter Current Reg Number\\n";
                            slno = slno + 1;
                        }
                    }

                    if (rblMunicipal.SelectedIndex == -1)
                    {
                        errormsg = errormsg + slno + ". Please Select  Yes or No current registration number of Municipal Trade licence/ADC?  \\n";
                        slno = slno + 1;
                    }
                    if (rblMunicipal.SelectedValue == "Y")
                    {
                        if (string.IsNullOrEmpty(txtDate.Text) || txtDate.Text == "" || txtDate.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter Date of registration \\n";
                            slno = slno + 1;
                        }
                        if (string.IsNullOrEmpty(txtcurrentReg.Text) || txtcurrentReg.Text == "" || txtcurrentReg.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter Current Registration Number  \\n";
                            slno = slno + 1;
                        }
                    }
                    if (string.IsNullOrEmpty(txtWeight.Text) || txtWeight.Text == "" || txtWeight.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Weight\\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtMeasure.Text) || txtMeasure.Text == "" || txtMeasure.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Measure\\n";
                        slno = slno + 1;
                    }

                    if (string.IsNullOrEmpty(txtInstruWeight.Text) || txtInstruWeight.Text == "" || txtInstruWeight.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Instrument type \\n";
                        slno = slno + 1;
                    }
                }
                if (divManfRepr.Visible == true)
                {
                    if (string.IsNullOrEmpty(txtskilled.Text) || txtskilled.Text == "" || txtskilled.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Skilled Employee \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtsemiskilled.Text) || txtsemiskilled.Text == "" || txtsemiskilled.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Semi Skilled Employee \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtunskilled.Text) || txtunskilled.Text == "" || txtunskilled.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter UnSkilled Employee \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txttrained.Text) || txttrained.Text == "" || txttrained.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Specialist trained in the line\\n";
                        slno = slno + 1;
                    }
                    if (rblelectric.SelectedIndex == -1 || rblelectric.SelectedItem.Text == "--Select--")
                    {
                        errormsg = errormsg + slno + ". Please Select Availability of electric energy   \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtmanuowned.Text) || txtmanuowned.Text == "" || txtmanuowned.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Manufacture weight is Measure\\n";
                        slno = slno + 1;
                    }
                }
                if (divManf.Visible == true)
                {
                    if (string.IsNullOrEmpty(txtownership.Text) || txtownership.Text == "" || txtownership.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter foundry/workshop facilities\\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtsteel.Text) || txtsteel.Text == "" || txtsteel.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Facilities of steel casting\\n";
                        slno = slno + 1;
                    }
                    if (rblstateside.SelectedValue =="0")
                    {
                        errormsg = errormsg + slno + ". Please Select manufactured will be sold within the State or out side the state or both \\n";
                        slno = slno + 1;
                    }
                    if (rblInstitute.SelectedIndex == -1)
                    {
                        errormsg = errormsg + slno + ". Please Select Yes or No Do you received any loan from Government or financial Institution?\\n";
                        slno = slno + 1;
                    }
                    if (rblInstitute.SelectedValue == "Y")
                    {
                        if (string.IsNullOrEmpty(txtBanker.Text.Trim()) || txtBanker.Text.Trim() == "" || txtBanker.Text.Trim() == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter Bankers Details\\n";
                            slno = slno + 1;
                        }
                        if (string.IsNullOrEmpty(txtGetDetails.Text) || txtGetDetails.Text == "" || txtGetDetails.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter Give Details\\n";
                            slno = slno + 1;
                        }
                    }

                    if (rblLicdealer.SelectedIndex == -1)
                    {
                        errormsg = errormsg + slno + ". Please Select  Yes or No Have you applied previously for a manufacturer's licence?  \\n";
                        slno = slno + 1;
                    }
                    if (rblLicdealer.SelectedValue == "Y")
                    {
                        if (string.IsNullOrEmpty(txtDetails.Text) || txtDetails.Text == "" || txtDetails.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter Give Details\\n";
                            slno = slno + 1;
                        }
                    }
                }
                if (divRepr.Visible == true)
                {
                    if (rblRepaire.SelectedIndex == -1)
                    {
                        errormsg = errormsg + slno + ". Please Select Have you applied previously for a repairer's licence?  \\n";
                        slno = slno + 1;
                    }
                    if (rblRepaire.SelectedValue == "Y")
                    {
                        if (string.IsNullOrEmpty(txtResults.Text.Trim()) || txtResults.Text.Trim() == "" || txtResults.Text.Trim() == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter with what results?\\n";
                            slno = slno + 1;
                        }
                    }
                    if (rblLoan.SelectedIndex == -1)
                    {
                        errormsg = errormsg + slno + ". Please Select Have you sufficient stock of loan/test weights. etc.?\\n";
                        slno = slno + 1;
                    }
                    if (rblLoan.SelectedValue == "Y")
                    {
                        if (string.IsNullOrEmpty(txtDetailsGET.Text) || txtDetailsGET.Text == "" || txtDetailsGET.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter Give Details\\n";
                            slno = slno + 1;
                        }
                    }
                }
                if (divDlr.Visible == true)
                {
                    if (rblState.SelectedIndex == -1)
                    {
                        errormsg = errormsg + slno + ". Please Select  Yes or No import weights, etc. from places outside the State/Country?  \\n";
                        slno = slno + 1;
                    }
                    if (rblState.SelectedValue == "Y")
                    {
                        if (string.IsNullOrEmpty(txtLICNumber.Text) || txtLICNumber.Text == "" || txtLICNumber.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter Licence number  \\n";
                            slno = slno + 1;
                        }

                        if (string.IsNullOrEmpty(txtRegWeight.Text) || txtRegWeight.Text == "" || txtRegWeight.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter Registration of Importer of Weights and Measures  \\n";
                            slno = slno + 1;
                        }

                    }
                    if (rblDealer.SelectedIndex == -1)
                    {
                        errormsg = errormsg + slno + ". Please Select Yes or No a dealer's licence,either in this State or elsewhere ? \\n";
                        slno = slno + 1;
                    }
                    if (rblDealer.SelectedValue == "Y")
                    {
                        if (string.IsNullOrEmpty(txtGiveDetails.Text) || txtGiveDetails.Text == "" || txtGiveDetails.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter Give details  \\n";
                            slno = slno + 1;
                        }

                    }
                }                            
                if (intialverification.Visible == true)
                {
                    if (GVLegalDept.Rows.Count <= 0)
                    {
                        errormsg = errormsg + slno + ". Please Enter Instrument Details and click on Add Button  \\n";
                        slno = slno + 1;
                    }
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

        protected void rblInstitute_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                if (rblInstitute.SelectedItem.Text == "Yes")
                {
                    NameBanker.Visible = true;
                    DetailsGet.Visible = true;
                }
                else
                {
                    NameBanker.Visible = false;
                    DetailsGet.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblInstitute.BorderColor = System.Drawing.Color.White;
        }

        protected void rblLoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                if (rblLoan.SelectedItem.Text == "Yes")
                {
                    weightloan.Visible = true;
                }
                else
                {
                    weightloan.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblLoan.BorderColor = System.Drawing.Color.White;
        }

        protected void rblRepaire_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblRepaire.SelectedItem.Text == "Yes")
                {
                    License.Visible = true;
                }
                else
                {
                    License.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblRepaire.BorderColor = System.Drawing.Color.White;
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                btnsave_Click(sender, e);
                if (ErrorMsg == "")
                    Response.Redirect("~/User/CFO/CFOContractorsRegistration.aspx?next=N");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }

            //   Response.Redirect("~/User/CFO/CFOContractorsRegistration.aspx?next=N");
        }

        protected void GVLegalDept_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVLegalDept.Rows.Count > 0)
                {
                    ((DataTable)ViewState["LegalDepartment"]).Rows.RemoveAt(e.RowIndex);
                    this.GVLegalDept.DataSource = ((DataTable)ViewState["LegalDepartment"]).DefaultView;
                    this.GVLegalDept.DataBind();
                    GVLegalDept.Visible = true;
                    GVLegalDept.Focus();

                }
                else
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnTaxClearance_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupLetter.HasFile)
                {
                    Error = validations(fupLetter);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Letter of Consent from the Manufacturer" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupLetter.PostedFile.SaveAs(serverpath + "\\" + fupLetter.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "113";
                        objAadhar.FilePath = serverpath + fupLetter.PostedFile.FileName;
                        objAadhar.FileName = fupLetter.PostedFile.FileName;
                        objAadhar.FileType = fupLetter.PostedFile.ContentType;
                        objAadhar.FileDescription = "Letter of Consent from the Manufacturer";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypTaxClearance.Text = fupLetter.PostedFile.FileName;
                            hypTaxClearance.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objAadhar.FilePath);
                            hypTaxClearance.Target = "blank";
                            message = "alert('" + "Letter of Consent from the Manufacturer who wish to appoint you as a Dealer Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnGSTREG_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupWeight.HasFile)
                {
                    Error = validations(fupWeight);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Manufacturing Licence if you intend to import weights & measures" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupWeight.PostedFile.SaveAs(serverpath + "\\" + fupWeight.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "114";
                        objAadhar.FilePath = serverpath + fupWeight.PostedFile.FileName;
                        objAadhar.FileName = fupWeight.PostedFile.FileName;
                        objAadhar.FileType = fupWeight.PostedFile.ContentType;
                        objAadhar.FileDescription = "Manufacturing Licence if you intend to import weights & measures";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypweight.Text = fupWeight.PostedFile.FileName;
                            hypweight.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objAadhar.FilePath);
                            hypweight.Target = "blank";
                            message = "alert('" + "Manufacturing Licence if you intend to import weights & measures from outside the State Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnLabourLic_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupWeightdeal.HasFile)
                {
                    Error = validations(fupWeightdeal);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Model Approval Certificate of weights and measures" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupWeightdeal.PostedFile.SaveAs(serverpath + "\\" + fupWeightdeal.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "115";
                        objAadhar.FilePath = serverpath + fupWeightdeal.PostedFile.FileName;
                        objAadhar.FileName = fupWeightdeal.PostedFile.FileName;
                        objAadhar.FileType = fupWeightdeal.PostedFile.ContentType;
                        objAadhar.FileDescription = "Model Approval Certificate of weights and measures";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypLabourLic.Text = fupWeightdeal.PostedFile.FileName;
                            hypLabourLic.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objAadhar.FilePath);
                            hypLabourLic.Target = "blank";
                            message = "alert('" + "Model Approval Certificate of weights and measures to be deal with Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnTribals_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupLease.HasFile)
                {
                    Error = validations(fupLease);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Documentary proof of ownership" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupLease.PostedFile.SaveAs(serverpath + "\\" + fupLease.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "116";
                        objAadhar.FilePath = serverpath + fupLease.PostedFile.FileName;
                        objAadhar.FileName = fupLease.PostedFile.FileName;
                        objAadhar.FileType = fupLease.PostedFile.ContentType;
                        objAadhar.FileDescription = "Documentary proof of ownership";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypLease.Text = fupLease.PostedFile.FileName;
                            hypLease.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objAadhar.FilePath);
                            hypLease.Target = "blank";
                            message = "alert('" + "Documentary proof of ownership / Lease agreement of Premises with Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnTradeLic_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupGSTReg.HasFile)
                {
                    Error = validations(fupGSTReg);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "GST Registration Certificate" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupGSTReg.PostedFile.SaveAs(serverpath + "\\" + fupGSTReg.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "117";
                        objAadhar.FilePath = serverpath + fupGSTReg.PostedFile.FileName;
                        objAadhar.FileName = fupGSTReg.PostedFile.FileName;
                        objAadhar.FileType = fupGSTReg.PostedFile.ContentType;
                        objAadhar.FileDescription = "GST Registration Certificate";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypGSTReg.Text = fupGSTReg.PostedFile.FileName;
                            hypGSTReg.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objAadhar.FilePath);
                            hypGSTReg.Target = "blank";
                            message = "alert('" + "GST Registration Certificate Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnCastefirms_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupTax.HasFile)
                {
                    Error = validations(fupTax);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Professional Tax Certificate" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupTax.PostedFile.SaveAs(serverpath + "\\" + fupTax.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "118";
                        objAadhar.FilePath = serverpath + fupTax.PostedFile.FileName;
                        objAadhar.FileName = fupTax.PostedFile.FileName;
                        objAadhar.FileType = fupTax.PostedFile.ContentType;
                        objAadhar.FileDescription = "Professional Tax Certificate";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypTax.Text = fupTax.PostedFile.FileName;
                            hypTax.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objAadhar.FilePath);
                            hypTax.Target = "blank";
                            message = "alert('" + "Professional Tax Certificate Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnattorney_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupLabour.HasFile)
                {
                    Error = validations(fupLabour);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Labour Licence" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupLabour.PostedFile.SaveAs(serverpath + "\\" + fupLabour.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "119";
                        objAadhar.FilePath = serverpath + fupLabour.PostedFile.FileName;
                        objAadhar.FileName = fupLabour.PostedFile.FileName;
                        objAadhar.FileType = fupLabour.PostedFile.ContentType;
                        objAadhar.FileDescription = "Labour Licence";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypLabour.Text = fupLabour.PostedFile.FileName;
                            hypLabour.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objAadhar.FilePath);
                            hypLabour.Target = "blank";
                            message = "alert('" + "Labour Licence Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnLastissued_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupADC.HasFile)
                {
                    Error = validations(fupADC);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["CFOAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["CFOQID"]) + "\\" + "Trade Licence from respective ADC in case of Non Tribal" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        fupADC.PostedFile.SaveAs(serverpath + "\\" + fupADC.PostedFile.FileName);

                        CFOAttachments objAadhar = new CFOAttachments();
                        objAadhar.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objAadhar.Questionnareid = Convert.ToString(Session["CFOQID"]);
                        objAadhar.MasterID = "120";
                        objAadhar.FilePath = serverpath + fupADC.PostedFile.FileName;
                        objAadhar.FileName = fupADC.PostedFile.FileName;
                        objAadhar.FileType = fupADC.PostedFile.ContentType;
                        objAadhar.FileDescription = "Trade Licence from respective ADC in case of Non Tribal";
                        objAadhar.CreatedBy = hdnUserID.Value;
                        objAadhar.IPAddress = getclientIP();
                        result = objcfobal.InsertCFOAttachments(objAadhar);
                        if (result != "")
                        {
                            hypADC.Text = fupADC.PostedFile.FileName;
                            hypADC.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objAadhar.FilePath);
                            hypADC.Target = "blank";
                            message = "alert('" + "Trade Licence from respective ADC in case of Non Tribal Uploaded successfully" + "')";
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public string validations(FileUpload Attachment)
        {
            try
            {
                string filesize = Convert.ToString(ConfigurationManager.AppSettings["FileSize"].ToString());
                int slno = 1; string Error = "";
                if (Attachment.PostedFile.ContentType != "application/pdf"
                     || !ValidateFileName(Attachment.PostedFile.FileName) || !ValidateFileExtension(Attachment))
                {

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
                }
                return Error;
            }
            catch (Exception ex)
            { throw ex; }
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

        protected void rblFirm_SelectedIndexChanged(object sender, EventArgs e)
        {
            rblFirm.BorderColor = System.Drawing.Color.White;
        }

        protected void rblLimit_SelectedIndexChanged(object sender, EventArgs e)
        {
            rblLimit.BorderColor = System.Drawing.Color.White;
        }

        protected void rblstateside_SelectedIndexChanged(object sender, EventArgs e)
        {
            rblstateside.BorderColor = System.Drawing.Color.White;
        }

        protected void rblelectric_SelectedIndexChanged(object sender, EventArgs e)
        {
            rblelectric.BorderColor = System.Drawing.Color.White;
        }

        protected void btnPreviuos_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/CFO/CFOLabourDetails.aspx?Previous=P");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            // Response.Redirect("~/User/CFO/CFOLabourDetails.aspx?Previous=P");
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
    }
}