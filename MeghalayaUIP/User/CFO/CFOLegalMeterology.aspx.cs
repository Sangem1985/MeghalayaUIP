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
        CFOBAL objcfebal = new CFOBAL();
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
                Session["CFOUNITID"] = "1001";
                UnitID = Convert.ToString(Session["CFOUNITID"]);
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

                }
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
                    dr["CFOLMI_CFOUNITID"] = Convert.ToString(ViewState["UnitID"]);
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
            String Quesstionriids = "1001";
            string UnitId = "1001";
            try
            {
                string ErrorMsg = "", result = "";
                ErrorMsg = Validations();
                if (ErrorMsg == "")
                {
                    CFOLEGALMETROLOGYDEP ObjCFOlegalDet = new CFOLEGALMETROLOGYDEP();
                    int count = 0;
                    for (int i = 0; i < GVLegalDept.Rows.Count; i++)
                    {
                        ObjCFOlegalDet.Questionnariid = Quesstionriids;
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


                        string A = objcfebal.InsertCFOLegalMetrologyDet(ObjCFOlegalDet);
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



                    if (Convert.ToString(ViewState["UnitID"]) != "")
                    { ObjCFOlegalDet.UNITID = Convert.ToString(ViewState["UnitID"]); }
                    ObjCFOlegalDet.CreatedBy = hdnUserID.Value;
                    ObjCFOlegalDet.IPAddress = getclientIP();
                    ObjCFOlegalDet.Questionnariid = Quesstionriids;
                    ObjCFOlegalDet.UnitId = UnitId;

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



                    result = objcfebal.InsertCFOLegalMetrologyDetails(ObjCFOlegalDet);
                    ViewState["UnitID"] = result;
                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "CFO legalMetrology Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }

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
                if (string.IsNullOrEmpty(txtRegDate.Text) || txtRegDate.Text == "" || txtRegDate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Date\\n";
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
            Response.Redirect("~/User/CFO/CFOContractorsRegistration.aspx");
        }

        protected void btnPreviuos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User/CFO/CFOLabourDetails.aspx");
        }
    }
}