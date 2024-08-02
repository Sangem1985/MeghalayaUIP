using MeghalayaUIP.BAL.CFOBAL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFO
{
    public partial class CFOLegalMeterology : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFOBAL objcfobal = new CFOBAL();
        string UnitID, ErrorMsg = "";
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
                //UnitID = Convert.ToString(Session["CFOUNITID"]);
                if (Convert.ToString(Session["CFOUNITID"]) != "")
                { UnitID = Convert.ToString(Session["CFOUNITID"]); }
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
                    DataSet dsnew = new DataSet();
                    dsnew = objcfobal.GetApprovalDataByDeptId(Session["CFOQID"].ToString(), Session["CFOUNITID"].ToString(), "11");
                    if (dsnew.Tables[0].Rows.Count > 0)
                    {

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
                    Binddata();
                }
            }
        }
        public void Binddata()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfobal.GetLegalMeterologyDet(hdnUserID.Value, UnitID);
                if (ds.Tables[1].Rows.Count > 0 || ds.Tables[2].Rows.Count > 0)
                {
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
                            DateReg.Visible = true;
                            txtDate.Text = ds.Tables[1].Rows[0]["CFOLGM_MTLREGDATE"].ToString();
                            txtcurrentReg.Text = ds.Tables[1].Rows[0]["CFOLGM_MTLREGNO"].ToString();
                        }
                        else
                        {
                            ADCLicense.Visible = false;
                            DateReg.Visible = false;
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
                        hdnUserID.Value = Convert.ToString(ds.Tables[2].Rows[0]["CFOLMI_CFOQDID"]);
                        ViewState["LegalDepartment"]= ds.Tables[2];
                        GVLegalDept.DataSource = ds.Tables[2];
                        GVLegalDept.DataBind();
                        GVLegalDept.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
                throw ex;
            }
        }

        protected void rblfactory_SelectedIndexChanged(object sender, EventArgs e)
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

        protected void rblMunicipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblMunicipal.SelectedItem.Text == "Yes")
            {
                ADCLicense.Visible = true;
                DateReg.Visible = true;
            }
            else
            {
                ADCLicense.Visible = false;
                DateReg.Visible = false;
            }
        }

        protected void rblState_SelectedIndexChanged(object sender, EventArgs e)
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

        protected void rblDealer_SelectedIndexChanged(object sender, EventArgs e)
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

        protected void rblLicdealer_SelectedIndexChanged(object sender, EventArgs e)
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

        protected void btnsave_Click(object sender, EventArgs e)
        {
            //String Quesstionriids = "1001";
            //string UnitId = "1001";
            try
            {
                string result = "";
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
                    ObjCFOlegalDet.PatnershipFirm = rblFirm.SelectedValue;
                    ObjCFOlegalDet.CompanyLimited = rblLimit.SelectedValue;
                    ObjCFOlegalDet.Name = txtName.Text;
                    ObjCFOlegalDet.Address = txtAddress.Text;
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
                    ObjCFOlegalDet.NameBankers = txtBanker.Text;
                    ObjCFOlegalDet.DetailsDet = txtGetDetails.Text;
                    ObjCFOlegalDet.stock = rblLoan.SelectedValue;
                    ObjCFOlegalDet.GetDetails = txtDetailsGET.Text;
                    ObjCFOlegalDet.repairerLic = rblRepaire.SelectedValue;
                    ObjCFOlegalDet.results = txtResults.Text;

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
                throw ex;
            }
        }
        public string Validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                if (string.IsNullOrEmpty(txtInstruWeight.Text) || txtInstruWeight.Text == "" || txtInstruWeight.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Instrument type \\n";
                    slno = slno + 1;
                }

                if (string.IsNullOrEmpty(txtName.Text) || txtName.Text == "" || txtName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAddress.Text) || txtAddress.Text == "" || txtAddress.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Address\\n";
                    slno = slno + 1;
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
                if (string.IsNullOrEmpty(txtskilled.Text) || txtskilled.Text == "" || txtskilled.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Skilled\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtsemiskilled.Text) || txtsemiskilled.Text == "" || txtsemiskilled.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Semi Skilled\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtunskilled.Text) || txtunskilled.Text == "" || txtunskilled.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter UnSkilled\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txttrained.Text) || txttrained.Text == "" || txttrained.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Specialist trainedline\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtmanuowned.Text) || txtmanuowned.Text == "" || txtmanuowned.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Manufacture weight is Measure\\n";
                    slno = slno + 1;
                }
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
                if (rblfactory.SelectedIndex == -1)
                {
                   
                    errormsg = errormsg + slno + ". Please Select  Yes or No current registration number of factory/ shop/ establishment? \\n";
                    slno = slno + 1;

                }
                if (rblfactory.SelectedValue == "Y")
                {
                    if (string.IsNullOrEmpty(txtRegDate.Text) || txtRegDate.Text == "" || txtRegDate.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Date\\n";
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
                    ADCLicense.Visible = true;
                    if (string.IsNullOrEmpty(txtDate.Text) || txtDate.Text == "" || txtDate.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Date of registration \\n";
                        slno = slno + 1;
                    }
                    else { ADCLicense.Visible = false; }

                    DateReg.Visible = true;

                    if (string.IsNullOrEmpty(txtcurrentReg.Text) || txtcurrentReg.Text == "" || txtcurrentReg.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Current Registration Number  \\n";
                        slno = slno + 1;
                    }
                    else { DateReg.Visible = false; }

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
                if (rblState.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select  Yes or No import weights, etc. from places outside the State/Country?  \\n";
                    slno = slno + 1;
                }
                if (rblState.SelectedValue == "Y")
                {
                    State.Visible = true;

                    if (string.IsNullOrEmpty(txtLICNumber.Text) || txtLICNumber.Text == "" || txtLICNumber.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Licence number  \\n";
                        slno = slno + 1;
                    }
                    else { State.Visible = false; }

                    Country.Visible = true;

                    if (string.IsNullOrEmpty(txtRegWeight.Text) || txtRegWeight.Text == "" || txtRegWeight.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Registration of Importer of Weights and Measures  \\n";
                        slno = slno + 1;
                    }
                    else { Country.Visible = false; }
                }
                if (rblstateside.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select manufactured will be sold within the State or out side the state or both \\n";
                    slno = slno + 1;
                }
                if (rblDealer.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Yes or No a dealer's licence,either in this State or elsewhere ? \\n";
                    slno = slno + 1;
                }
                if (rblDealer.SelectedValue == "Y")
                {
                    DealerLic.Visible = true;

                    if (string.IsNullOrEmpty(txtGiveDetails.Text) || txtGiveDetails.Text == "" || txtGiveDetails.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Give details  \\n";
                        slno = slno + 1;
                    }
                    else { DealerLic.Visible = false; }
                }
                if (rblelectric.SelectedIndex == -1 || rblelectric.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Availability of electric energy   \\n";
                    slno = slno + 1;
                }

                if (rblLicdealer.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select  Yes or No Have you applied previously for a manufacturer's licence?  \\n";
                    slno = slno + 1;
                }
                if (rblLicdealer.SelectedValue == "Y")
                {
                    applieddealer.Visible = true;
                    if (string.IsNullOrEmpty(txtDetails.Text) || txtDetails.Text == "" || txtDetails.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Give Details\\n";
                        slno = slno + 1;
                    }
                    else { applieddealer.Visible = false; }

                }
                if (rblInstitute.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Yes or No Do you received any loan from Government or financial Institution?\\n";
                    slno = slno + 1;
                }
                if (rblInstitute.SelectedValue == "Y")
                {
                    NameBanker.Visible = true;
                    if (string.IsNullOrEmpty(txtBanker.Text) || txtBanker.Text == "" || txtBanker.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Bankers Details\\n";
                        slno = slno + 1;
                    }
                    else { NameBanker.Visible = false; }

                    DetailsGet.Visible = true;
                    if (string.IsNullOrEmpty(txtGetDetails.Text) || txtGetDetails.Text == "" || txtGetDetails.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Give Details\\n";
                        slno = slno + 1;
                    }
                    else { DetailsGet.Visible = false; }
                }
                if (rblLoan.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Have you sufficient stock of loan/test weights. etc.?\\n";
                    slno = slno + 1;
                }
                if (rblLoan.SelectedValue == "Y")
                {
                    weightloan.Visible = true;
                    if (string.IsNullOrEmpty(txtDetailsGET.Text) || txtDetailsGET.Text == "" || txtDetailsGET.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Give Details\\n";
                        slno = slno + 1;
                    }
                    else { weightloan.Visible = false; }
                }
                if (rblRepaire.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Have you applied previously for a repairer's licence?  \\n";
                    slno = slno + 1;
                }
                if (rblRepaire.SelectedValue == "Y")
                {
                    License.Visible = true;
                    if (string.IsNullOrEmpty(txtResults.Text) || txtResults.Text == "" || txtResults.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter with what results?\\n";
                        slno = slno + 1;
                    }
                    else { License.Visible = false; }
                }
                if (GVLegalDept.Rows.Count <= 0)
                {
                    errormsg = errormsg + slno + ". Please Enter Instrument Details \\n";
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

        protected void rblInstitute_SelectedIndexChanged(object sender, EventArgs e)
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

        protected void rblLoan_SelectedIndexChanged(object sender, EventArgs e)
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

        protected void rblRepaire_SelectedIndexChanged(object sender, EventArgs e)
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
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
            }
           // Response.Redirect("~/User/CFO/CFOLabourDetails.aspx?Previous=P");
        }
    }
}