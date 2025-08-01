using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.SVRCBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Services
{
    public partial class SRVCLegalMeterology : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        SVRCBAL objSrvcbal = new SVRCBAL();
        string ErrorMsg = "", result = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDistricts();
            }
        }
        public void BindData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objSrvcbal.GetSRVCLegalMetrologyDetails(hdnUserID.Value, Convert.ToString(Session["SRVCQID"]));

                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddldistrict.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        ddldistrict_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlMandal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        ddlMandal_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlVillage.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtLandmark.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtStation.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtPostOffice.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtPincode.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtDateWorkshop.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        rblRegNoFactEst.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        rblRegNoFactEst_SelectedIndexChanged(null, EventArgs.Empty);
                        rblMunicipalADC.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        rblMunicipalADC_SelectedIndexChanged(null, EventArgs.Empty);
                        txtRegDate.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtRegNumber.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtDate.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtcurrentReg.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        rblpartnership.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        rblpartnership_SelectedIndexChanged(null, EventArgs.Empty);
                        rblcompany.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        rblcompany_SelectedIndexChanged(null, EventArgs.Empty);
                        txtNatureManu.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtWeight.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtMeasure.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtInstruWeight.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtskilled.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtsemiskilled.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtunskilled.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txttrained.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        rblelectric.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtmanuowned.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtownership.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtsteel.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        rblFinance.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        rblFinance_SelectedIndexChanged(null, EventArgs.Empty);
                        txtBanker.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtGetDetails.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtGST.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtTaxRegNo.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        txtITNo.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        rblstateside.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        rblLicdealer.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0][""]);
                        rblLicdealer_SelectedIndexChanged(null, EventArgs.Empty);
                        txtDetails.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        GVpartners.DataSource = ds.Tables[1];
                        GVpartners.DataBind();
                        GVpartners.Visible = true;
                        ViewState["PartnersDetails"] = ds.Tables[1];
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        DataTable dt = ds.Tables[2];
                        ViewState["ManagerDetails"] = dt;
                        GVManaging.Visible = true;
                        GVManaging.DataSource = dt;
                        GVManaging.DataBind();
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
        protected void rblRegNoFactEst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblRegNoFactEst.SelectedValue == "Y")
            {
                divRegistration.Visible = true;
            }
            else { divRegistration.Visible = false; }

        }
        protected void rblMunicipalADC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblMunicipalADC.SelectedValue == "Y")
            {
                divADCLicense.Visible = true;
            }
            else { divADCLicense.Visible = false; }
        }
        protected void rblpartnership_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblpartnership.SelectedValue == "Y")
            {
                divpartnership.Visible = true;
            }
            else { divpartnership.Visible = false; }
        }
        protected void rblcompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblcompany.SelectedValue == "Y")
            {
                divcompany.Visible = true;
            }
            else { divcompany.Visible = false; }
        }
        protected void rblFinance_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblFinance.SelectedValue == "Y")
            {
                divFinanceBank.Visible = true;
                divGiveInstitute.Visible = true;
            }
            else
            {
                divFinanceBank.Visible = false;
                divGiveInstitute.Visible = false;
            }
        }
        protected void rblLicdealer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblLicdealer.SelectedValue == "Y")
            {
                divapplieddealer.Visible = true;
            }
            else { divapplieddealer.Visible = false; }
        }
        protected void BindDistricts()
        {
            try
            {

                ddldistrict.Items.Clear();
                ddlMandal.Items.Clear();
                ddlVillage.Items.Clear();

                List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();
                string strmode = string.Empty;

                strmode = "";

                objDistrictModel = mstrBAL.GetDistrcits();
                if (objDistrictModel != null)
                {
                    ddldistrict.DataSource = objDistrictModel;
                    ddldistrict.DataValueField = "DistrictId";
                    ddldistrict.DataTextField = "DistrictName";
                    ddldistrict.DataBind();

                }
                else
                {
                    ddldistrict.DataSource = null;
                    ddldistrict.DataBind();
                }
                AddSelect(ddldistrict);
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
        protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlMandal.ClearSelection();
                ddlVillage.ClearSelection();
                if (ddldistrict.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlMandal, ddldistrict.SelectedValue);
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
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg = stepValidations();
                if (ErrorMsg == "")
                {
                    SRVCLegalMetrology objLegal = new SRVCLegalMetrology();

                    DataTable dt = PartnersDetails;
                    DataSet ds = new DataSet("Root");
                    ds.Tables.Add(dt.Copy());

                    string xmlData;
                    using (StringWriter sw = new StringWriter())
                    {
                        ds.WriteXml(sw);
                        xmlData = sw.ToString();
                    }


                    {
                        objLegal.Questionnariid = "101";//Convert.ToString(Session["SRVCQID"]);
                        objLegal.Createdby = "1001"; //hdnUserID.Value;
                        objLegal.IPAddress = getclientIP();
                        objLegal.XMLData = GetDirectorXML();
                    };
                    result = objSrvcbal.InsertLeaglPartnersDetails(objLegal);


                    DataTable dt1 = ManagerDetails;
                    DataSet ds1 = new DataSet("Root");
                    ds1.Tables.Add(dt1.Copy());

                    string xmlData1;
                    using (StringWriter sw = new StringWriter())
                    {
                        ds.WriteXml(sw);
                        xmlData1 = sw.ToString();
                    }


                    {
                        objLegal.Questionnariid = "101";//Convert.ToString(Session["SRVCQID"]);
                        objLegal.Createdby = "1001"; //hdnUserID.Value;
                        objLegal.IPAddress = getclientIP();
                        objLegal.XMLData = GetManagerXML();
                    };
                    result = objSrvcbal.InsertLegalManagerDetails(objLegal);



                    objLegal.Questionnariid = "101";//Convert.ToString(Session["SRVCQID"]);
                    objLegal.Createdby = "1001"; //hdnUserID.Value;
                    objLegal.IPAddress = getclientIP();
                    objLegal.District = ddldistrict.SelectedValue;
                    objLegal.Mandal = ddlMandal.SelectedValue;
                    objLegal.Village = ddlVillage.SelectedValue;
                    objLegal.landmark = txtLandmark.Text;
                    objLegal.Station = txtStation.Text;
                    objLegal.PostOffice = txtPostOffice.Text;
                    objLegal.Pincode = txtPincode.Text;
                    objLegal.DateOfEST = txtDateWorkshop.Text;
                    objLegal.RegShopEst = rblRegNoFactEst.SelectedValue;
                    objLegal.RegADC = rblMunicipalADC.SelectedValue;
                    objLegal.DateofReg = txtRegDate.Text;
                    objLegal.CurrentRegNo = txtRegNumber.Text;
                    objLegal.DateOfRegADC = txtDate.Text;
                    objLegal.CurrentRegNoADC = txtcurrentReg.Text;
                    objLegal.partnershipfirm = rblpartnership.SelectedValue;
                    objLegal.limitedcompany = rblcompany.SelectedValue;
                    objLegal.NatureManu = txtNatureManu.Text;
                    objLegal.Weights = txtWeight.Text;
                    objLegal.Measures = txtMeasure.Text;
                    objLegal.WeightingInstrument = txtInstruWeight.Text;
                    objLegal.Skilled = txtskilled.Text;
                    objLegal.Semiskilled = txtsemiskilled.Text;
                    objLegal.Unskilled = txtunskilled.Text;
                    objLegal.Specialisttrain = txttrained.Text;
                    objLegal.electricenergy = rblelectric.SelectedValue;
                    objLegal.Detailsmachinery = txtmanuowned.Text;
                    objLegal.Detailsworkshop = txtownership.Text;
                    objLegal.FacilitiesCasting = txtsteel.Text;
                    objLegal.receivedloan = rblFinance.SelectedValue;
                    objLegal.bankersName = txtBanker.Text;
                    objLegal.GiveBankerDetails = txtGetDetails.Text;
                    objLegal.GST = txtGST.Text;
                    objLegal.ProfessionalTaxReg = txtTaxRegNo.Text;
                    objLegal.ITNumber = txtITNo.Text;
                    objLegal.manufacturedSold = rblstateside.SelectedValue;
                    objLegal.manufacturerLicense = rblLicdealer.SelectedValue;
                    objLegal.GiveLicenseDetails = txtDetails.Text;

                    result = objSrvcbal.InsertSRVCLegalMetrologyDetails(objLegal);

                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "LegalMetrology Details Submitted Successfully";
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public string stepValidations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                if (ddldistrict.SelectedIndex == -1 || ddldistrict.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select District \\n";
                    slno = slno + 1;
                }
                if (ddlMandal.SelectedIndex == -1 || ddlMandal.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Mandal \\n";
                    slno = slno + 1;
                }
                if (ddlVillage.SelectedIndex == -1 || ddlVillage.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Village \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLandmark.Text) || txtLandmark.Text.Trim() == "")
                {
                    errormsg += slno + ". Please enter Nearest landmark...! \\n";
                    slno++;
                }

                if (string.IsNullOrEmpty(txtStation.Text) || txtStation.Text.Trim() == "")
                {
                    errormsg += slno + ". Please enter Police Station ...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtPostOffice.Text) || txtPostOffice.Text.Trim() == "" || txtPostOffice.Text == null)
                {
                    errormsg += slno + ". Please enter Post Office...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtPincode.Text) || txtPincode.Text.Trim() == "" || txtPincode.Text == null)
                {
                    errormsg += slno + ". Please enter Pincode...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtDateWorkshop.Text) || txtDateWorkshop.Text.Trim() == "" || txtDateWorkshop.Text == null)
                {
                    errormsg += slno + ". Please Date of Establishment of workshop/factory ...! \\n";
                    slno++;
                }
                if (rblRegNoFactEst.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select registration number of factory/ shop/ establishment \\n";
                    slno = slno + 1;
                }
                if (rblRegNoFactEst.SelectedValue == "Y")
                {
                    if (string.IsNullOrEmpty(txtRegDate.Text) || txtRegDate.Text.Trim() == "" || txtRegDate.Text == null)
                    {
                        errormsg += slno + ". Please enter Date of registration(w)...! \\n";
                        slno++;
                    }
                    if (string.IsNullOrEmpty(txtRegNumber.Text) || txtRegNumber.Text.Trim() == "" || txtRegNumber.Text == null)
                    {
                        errormsg += slno + ". Please enter Current registration number(w) ...! \\n";
                        slno++;
                    }
                }
                if (rblRegNoFactEst.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select registration number of Municipal Trade licence/ADC?....! \\n";
                    slno = slno + 1;
                }
                if (rblMunicipalADC.SelectedValue == "Y")
                {
                    if (string.IsNullOrEmpty(txtDate.Text) || txtDate.Text.Trim() == "" || txtDate.Text == null)
                    {
                        errormsg += slno + ". Please enter Date of registration...! \\n";
                        slno++;
                    }
                    if (string.IsNullOrEmpty(txtcurrentReg.Text) || txtcurrentReg.Text.Trim() == "" || txtcurrentReg.Text == null)
                    {
                        errormsg += slno + ". Please enter Current registration number(w) ...! \\n";
                        slno++;
                    }
                }
                if (string.IsNullOrEmpty(txtNatureManu.Text) || txtNatureManu.Text.Trim() == "" || txtNatureManu.Text == null)
                {
                    errormsg += slno + ". Please enter Nature of manufacturing activities at present...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtWeight.Text) || txtWeight.Text.Trim() == "" || txtWeight.Text == null)
                {
                    errormsg += slno + ". Please enter Weights...! \\n";
                    slno++;
                }


                if (string.IsNullOrEmpty(txtMeasure.Text) || txtMeasure.Text.Trim() == "" || txtMeasure.Text == null)
                {
                    errormsg += slno + ". Please enter Measures...! \\n";
                    slno++;
                }
                if (string.IsNullOrEmpty(txtInstruWeight.Text) || txtInstruWeight.Text.Trim() == "" || txtInstruWeight.Text == null)
                {
                    errormsg += slno + ". Please enter txtInstruWeight...! \\n";
                    slno++;
                }
                //if (string.IsNullOrEmpty(txtWeight.Text) || txtWeight.Text.Trim() == "" || txtWeight.Text == null)
                //{
                //    errormsg += slno + ". Please enter Weights...! \\n";
                //    slno++;
                //}
                //if (string.IsNullOrEmpty(txtWeight.Text) || txtWeight.Text.Trim() == "" || txtWeight.Text == null)
                //{
                //    errormsg += slno + ". Please enter Weights...! \\n";
                //    slno++;
                //}
                //if (string.IsNullOrEmpty(txtWeight.Text) || txtWeight.Text.Trim() == "" || txtWeight.Text == null)
                //{
                //    errormsg += slno + ". Please enter Weights...! \\n";
                //    slno++;
                //}
                //if (string.IsNullOrEmpty(txtWeight.Text) || txtWeight.Text.Trim() == "" || txtWeight.Text == null)
                //{
                //    errormsg += slno + ". Please enter Weights...! \\n";
                //    slno++;
                //}
                //if (string.IsNullOrEmpty(txtWeight.Text) || txtWeight.Text.Trim() == "" || txtWeight.Text == null)
                //{
                //    errormsg += slno + ". Please enter Weights...! \\n";
                //    slno++;
                //}
                //if (string.IsNullOrEmpty(txtWeight.Text) || txtWeight.Text.Trim() == "" || txtWeight.Text == null)
                //{
                //    errormsg += slno + ". Please enter Weights...! \\n";
                //    slno++;
                //}



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
        protected void GVpartners_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string name = GVpartners.Rows[e.RowIndex].Cells[1].Text.Trim();

                SRVCLegalMetrology objLegal = new SRVCLegalMetrology();
                {
                    objLegal.Questionnariid = "101"; //Convert.ToString(Session["SRVCQID"]);
                    objLegal.Namepartner = name;
                };
                string result = objSrvcbal.DeletePatner(objLegal);

                DataTable dt = PartnersDetails;
                dt.Rows.RemoveAt(e.RowIndex);
                PartnersDetails = dt;

                GVpartners.DataSource = dt;
                GVpartners.DataBind();
                GVpartners.Visible = dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
        protected void btnAddPartners_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPartnermName.Text) ||
                    string.IsNullOrWhiteSpace(txtPartnerAddress.Text) || string.IsNullOrWhiteSpace(txtPartnerFather.Text))
                {
                    lblmsg0.Text = "Please enter all required details.";
                    Failure.Visible = true;
                    return;
                }

                DataTable dt = PartnersDetails;

                DataRow dr = dt.NewRow();
                dr[""] = txtPartnermName.Text.Trim();
                dr[""] = txtPartnerAddress.Text.Trim();
                dr[""] = txtPartnerFather.Text.Trim();
                dt.Rows.Add(dr);

                PartnersDetails = dt;

                GVpartners.Visible = true;
                GVpartners.DataSource = dt;
                GVpartners.DataBind();

                txtPartnermName.Text = "";
                txtPartnerAddress.Text = "";
                txtPartnerFather.Text = "";
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        private DataTable PartnersDetails
        {
            get
            {
                if (ViewState["PartnersDetails"] == null)
                {
                    DataTable dt = new DataTable("Table1");
                    dt.Columns.Add("", typeof(string));
                    dt.Columns.Add("", typeof(string));
                    dt.Columns.Add("", typeof(string));
                    ViewState["PartnersDetails"] = dt;
                }
                return (DataTable)ViewState["PartnersDetails"];
            }
            set
            {
                ViewState["PartnersDetails"] = value;
            }
        }
        protected void GVManaging_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string name = GVManaging.Rows[e.RowIndex].Cells[1].Text.Trim();

                SRVCLegalMetrology objLegal = new SRVCLegalMetrology();
                {
                    objLegal.Questionnariid = "101"; //Convert.ToString(Session["SRVCQID"]);
                    objLegal.NameManaging = name;
                };
                string result = objSrvcbal.DeleteLegalManagerDet(objLegal);

                DataTable dt = ManagerDetails;
                dt.Rows.RemoveAt(e.RowIndex);
                ManagerDetails = dt;

                GVManaging.DataSource = dt;
                GVManaging.DataBind();
                GVManaging.Visible = dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
        private string GetDirectorXML()
        {
            DataTable dt = PartnersDetails;
            DataSet ds = new DataSet("Root");
            ds.Tables.Add(dt.Copy());

            using (StringWriter sw = new StringWriter())
            {
                ds.WriteXml(sw);
                return sw.ToString();
            }
        }
        protected void btnManager_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtManagerName.Text) ||
                    string.IsNullOrWhiteSpace(txtManagerAddress.Text) || string.IsNullOrWhiteSpace(txtManagerFather.Text))
                {
                    lblmsg0.Text = "Please enter all required details.";
                    Failure.Visible = true;
                    return;
                }

                DataTable dt = ManagerDetails;

                DataRow dr = dt.NewRow();
                dr[""] = txtManagerName.Text.Trim();
                dr[""] = txtManagerAddress.Text.Trim();
                dr[""] = txtManagerFather.Text.Trim();
                dt.Rows.Add(dr);

                ManagerDetails = dt;

                GVManaging.Visible = true;
                GVManaging.DataSource = dt;
                GVManaging.DataBind();

                txtManagerName.Text = "";
                txtManagerAddress.Text = "";
                txtManagerFather.Text = "";
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        private DataTable ManagerDetails
        {
            get
            {
                if (ViewState["ManagerDetails"] == null)
                {
                    DataTable dt = new DataTable("Table1");
                    dt.Columns.Add("", typeof(string));
                    dt.Columns.Add("", typeof(string));
                    dt.Columns.Add("", typeof(string));
                    ViewState["ManagerDetails"] = dt;
                }
                return (DataTable)ViewState["ManagerDetails"];
            }
            set
            {
                ViewState["ManagerDetails"] = value;
            }
        }
        private string GetManagerXML()
        {
            DataTable dt = ManagerDetails;
            DataSet ds = new DataSet("Root");
            ds.Tables.Add(dt.Copy());

            using (StringWriter sw = new StringWriter())
            {
                ds.WriteXml(sw);
                return sw.ToString();
            }
        }
    }
}