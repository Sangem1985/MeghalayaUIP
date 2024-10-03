using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.RenewalBAL;
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

namespace MeghalayaUIP.User.Renewal
{
    public partial class RENContractorMigrantWork : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        RenewalBAL objRenbal = new RenewalBAL();
        string UnitID, ErrorMsg = "", result;
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void GetAppliedorNot()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = objRenbal.GetRenAppliedApprovalID(hdnUserID.Value, Convert.ToString(Session["RENUNITID"]), Convert.ToString(Session["RENQID"]), "10", "71");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(ds.Tables[0].Rows[0]["RENDA_APPROVALID"]) == "71")
                    {
                        BindStates();
                        BindDistricts();
                        //BindSectors();
                        //BindConstitutionType();
                        //TotalAmount();
                        BindData();
                    }
                }
                else
                {
                    if (Request.QueryString.Count > 0)
                    {
                        if (Convert.ToString(Request.QueryString[0]) == "N")
                            Response.Redirect("~/User/Renewal/RENFactoriesLicense.aspx?Next=" + "N");
                        else if (Convert.ToString(Request.QueryString[0]) == "P")
                            Response.Redirect("~/User/Renewal/RENShopsEstablishment.aspx?Previous=" + "P");
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }
        }

        protected void rblDistricCouncil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblDistricCouncil.SelectedValue == "Y")
            {
                Licdetails.Visible = true;
                Validdate.Visible = true;
                Tribal.Visible = false;
                Reasons.Visible = false;
            }
            else
            {
                Tribal.Visible = true;
                Reasons.Visible = true;
                Licdetails.Visible = false;
                Validdate.Visible = false;
            }
        }

        protected void rblfiveyears_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblfiveyears.SelectedValue == "Y")
            {
                EstablishDetails.Visible = true;
            }
            else
            {
                EstablishDetails.Visible = false;
            }
        }

        protected void rblLicSuspending_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblLicSuspending.SelectedValue == "Y")
            {
                Order.Visible = true;
            }
            else
            {
                Order.Visible = false;
            }
        }

        protected void rblContractor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblContractor.SelectedValue == "Y")
            {
                Details.Visible = true;
            }
            else
            {
                Details.Visible = false;
            }
        }
        protected void BindStates()
        {
            try
            {
                ddlstate.Items.Clear();
                ddlStatedt.Items.Clear();
                ddlSates.Items.Clear();

                List<MasterStates> objStatesModel = new List<MasterStates>();

                objStatesModel = mstrBAL.GetStates();
                if (objStatesModel != null)
                {
                    ddlstate.DataSource = objStatesModel;
                    ddlstate.DataValueField = "StateId";
                    ddlstate.DataTextField = "StateName";
                    ddlstate.DataBind();

                    ddlStatedt.DataSource = objStatesModel;
                    ddlStatedt.DataValueField = "StateId";
                    ddlStatedt.DataTextField = "StateName";
                    ddlStatedt.DataBind();

                    ddlSates.DataSource = objStatesModel;
                    ddlSates.DataValueField = "StateId";
                    ddlSates.DataTextField = "StateName";
                    ddlSates.DataBind();
                }
                else
                {
                    ddlstate.DataSource = null;
                    ddlstate.DataBind();

                    ddlStatedt.DataSource = null;
                    ddlStatedt.DataBind();

                    ddlSates.DataSource = null;
                    ddlSates.DataBind();
                }
                AddSelect(ddlstate);
                AddSelect(ddlStatedt);
                AddSelect(ddlSates);
            }
            catch (Exception ex)
            {
                throw ex;
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
                throw ex;
            }
        }
        protected void BindDistricts()
        {
            try
            {
                ddlDistricdt.Items.Clear();
                ddlMandaldt.Items.Clear();
                ddlVillagesdt.Items.Clear();

                ddlDistric.Items.Clear();
                ddlMandal.Items.Clear();
                ddlVillage.Items.Clear();

                ddldist.Items.Clear();
                ddlmand.Items.Clear();
                ddlvilla.Items.Clear();

                List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();
                string strmode = string.Empty;
                //if (ObjUserInformation.User_Level == "2")
                //{
                strmode = "";
                //}
                objDistrictModel = mstrBAL.GetDistrcits();
                if (objDistrictModel != null)
                {
                    ddlDistricdt.DataSource = objDistrictModel;
                    ddlDistricdt.DataValueField = "DistrictId";
                    ddlDistricdt.DataTextField = "DistrictName";
                    ddlDistricdt.DataBind();

                    ddlDistric.DataSource = objDistrictModel;
                    ddlDistric.DataValueField = "DistrictId";
                    ddlDistric.DataTextField = "DistrictName";
                    ddlDistric.DataBind();

                    ddldist.DataSource = objDistrictModel;
                    ddldist.DataValueField = "DistrictId";
                    ddldist.DataTextField = "DistrictName";
                    ddldist.DataBind();

                }
                else
                {
                    ddlDistricdt.DataSource = null;
                    ddlDistricdt.DataBind();

                    ddlDistric.DataSource = null;
                    ddlDistric.DataBind();

                    ddldist.DataSource = null;
                    ddldist.DataBind();

                }
                AddSelect(ddlDistricdt);
                AddSelect(ddlMandaldt);
                AddSelect(ddlVillagesdt);

                AddSelect(ddlDistric);
                AddSelect(ddlMandal);
                AddSelect(ddlVillage);

                AddSelect(ddldist);
                AddSelect(ddlmand);
                AddSelect(ddlvilla);


            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
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
            }
        }

        protected void ddlDistricdt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlMandaldt.ClearSelection();
                ddlVillagesdt.ClearSelection();
                if (ddlDistricdt.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlMandaldt, ddlDistricdt.SelectedValue);
                }
                else return;
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }

        protected void ddlMandaldt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlVillagesdt.Items.Clear();
                if (ddlMandaldt.SelectedItem.Text != "--Select--")
                {
                    BindVillages(ddlVillagesdt, ddlMandaldt.SelectedValue);
                }
                else return;
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }

        protected void ddlDistric_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlMandal.ClearSelection();
                ddlVillage.ClearSelection();
                if (ddlDistric.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlMandal, ddlDistric.SelectedValue);
                }
                else return;
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }

        protected void ddldist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlmand.ClearSelection();
                ddlvilla.ClearSelection();
                if (ddldist.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlmand, ddldist.SelectedValue);
                }
                else return;
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }

        protected void ddlmand_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlvilla.ClearSelection();
                if (ddlmand.SelectedItem.Text != "--Select--")
                {

                    BindVillages(ddlvilla, ddlmand.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }

        protected void btnMigrant_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ddlTitle.SelectedValue) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtAddress.Text))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("RENMW_UNITID", typeof(string));
                    dt.Columns.Add("RENMW_CREATEDBY", typeof(string));
                    dt.Columns.Add("RENMW_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("RENMW_TITLE", typeof(string));
                    dt.Columns.Add("RENMW_NAME", typeof(string));
                    dt.Columns.Add("RENMW_ADDRESS", typeof(string));



                    if (ViewState["Migrant"] != null)
                    {
                        dt = (DataTable)ViewState["Migrant"];
                    }

                    DataRow dr = dt.NewRow();
                    dr["RENMW_UNITID"] = Convert.ToString(ViewState["UnitID"]);
                    dr["RENMW_CREATEDBY"] = hdnUserID.Value;
                    dr["RENMW_CREATEDBYIP"] = getclientIP();
                    dr["RENMW_TITLE"] = ddlTitle.SelectedValue;
                    dr["RENMW_NAME"] = txtName.Text;
                    dr["RENMW_ADDRESS"] = txtAddress.Text;


                    dt.Rows.Add(dr);
                    GVMigrant.Visible = true;
                    GVMigrant.DataSource = dt;
                    GVMigrant.DataBind();
                    ViewState["Migrant"] = dt;
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
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

        protected void rblDateofBirth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblDateofBirth.SelectedValue == "D")
            {
                DateBirth.Visible = true;
                Age.Visible = false;
            }
            else
            {
                Age.Visible = true;
                DateBirth.Visible = false;
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
                    RenMigrantwork ObjRenMigrant = new RenMigrantwork();

                    int count = 0;
                    for (int i = 0; i < GVMigrant.Rows.Count; i++)
                    {
                        ObjRenMigrant.Questionnariid = Convert.ToString(Session["RENQID"]);
                        ObjRenMigrant.CreatedBy = hdnUserID.Value;
                        ObjRenMigrant.UnitId = Convert.ToString(Session["RENUNITID"]);
                        ObjRenMigrant.IPAddress = getclientIP();
                        ObjRenMigrant.TITLESS = GVMigrant.Rows[i].Cells[1].Text;
                        ObjRenMigrant.NAMES = GVMigrant.Rows[i].Cells[2].Text;
                        ObjRenMigrant.ADDRESS = GVMigrant.Rows[i].Cells[3].Text;




                        string A = objRenbal.InsertMigrantWorkDetails(ObjRenMigrant);
                        if (A != "")
                        { count = count + 1; }
                    }
                    if (GVMigrant.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = "Renewal Migrant work Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }


                    ObjRenMigrant.LICRENO = txtRenLicNo.Text;
                    ObjRenMigrant.LICISSUEDDATE = txtRenLicIssued.Text;
                    ObjRenMigrant.LICRENVALIDDATE = txtRenValid.Text;
                    ObjRenMigrant.TITLE = txtTitlesdt.Text;
                    ObjRenMigrant.NAME = txtNAMES.Text;
                    ObjRenMigrant.EMAILID = txtEmail.Text;
                    ObjRenMigrant.MOBILENO = txtMobileNo.Text;
                    ObjRenMigrant.FATHERNAME = txtFather.Text;
                    ObjRenMigrant.STATE = ddlStatedt.SelectedValue;
                    ObjRenMigrant.DISTRIC = ddlDistricdt.SelectedValue;
                    ObjRenMigrant.MANDAL = ddlMandaldt.SelectedValue;
                    ObjRenMigrant.VILLAGE = ddlVillagesdt.SelectedValue;
                    ObjRenMigrant.LOCALITY = txtLocalition.Text;
                    ObjRenMigrant.NEARLAND = txtNearLandMark.Text;
                    ObjRenMigrant.PINCODE = txtpinS.Text;
                    ObjRenMigrant.DATEOFBIRTH = rblDateofBirth.SelectedValue;
                    ObjRenMigrant.DATE = txtDateBirth.Text;
                    ObjRenMigrant.AGE = txtAges.Text;
                    ObjRenMigrant.STATES = ddlSates.SelectedValue;
                    ObjRenMigrant.DISTRICS = ddlDistric.SelectedValue;
                    ObjRenMigrant.MANDALS = ddlMandal.SelectedValue;
                    ObjRenMigrant.VILLAGES = ddlVillage.SelectedValue;
                    ObjRenMigrant.LOCALITYS = txtLocal.Text;
                    ObjRenMigrant.LANDMARKS = txtNearMark.Text;
                    ObjRenMigrant.PINCODES = txtPin.Text;
                    ObjRenMigrant.ARTICLE5 = rblArtical5.SelectedValue;
                    ObjRenMigrant.CRIMINALCASEAPP = rblMakeApplicationCrime.SelectedValue;
                    ObjRenMigrant.CONVICTED5APPLICATION = rblCriminalCase.SelectedValue;
                    ObjRenMigrant.DISTRICCOUNCIL = rblDistricCouncil.SelectedValue;
                    ObjRenMigrant.LICENSE = ddlLic.SelectedValue;
                    ObjRenMigrant.LICNOS = txtLicNo.Text;
                    ObjRenMigrant.DATEOFLICENSE = txtDateLic.Text;
                    ObjRenMigrant.VALIDDATE = txtValidDate.Text;
                    ObjRenMigrant.TRIBAL = rblTribal.SelectedValue;
                    ObjRenMigrant.REMARK = txtReasons.Text;
                    ObjRenMigrant.NAMEEST = txtNameofEstablish.Text;
                    ObjRenMigrant.STATED = ddlstate.SelectedValue;
                    ObjRenMigrant.DIST = ddldist.SelectedValue;
                    ObjRenMigrant.MAND = ddlmand.SelectedValue;
                    ObjRenMigrant.VILLA = ddlvilla.SelectedValue;
                    ObjRenMigrant.LOCAL = txtLocality.Text;
                    ObjRenMigrant.NEARESTLANDMAEK = txtLandmark.Text;
                    ObjRenMigrant.PIN = txtPincode.Text;
                    ObjRenMigrant.TYPEOFBUSINESS = txtbusiness.Text;
                    ObjRenMigrant.REGNO = txtRegNoEst.Text;
                    ObjRenMigrant.DATEOFREG = txtDateRegCert.Text;
                    ObjRenMigrant.TITLES = ddlTitles.SelectedValue;
                    ObjRenMigrant.NAMEOFEMP = txtNameEmp.Text;
                    ObjRenMigrant.MIGRANTNAMEEMP = txtNameMigrantEmp.Text;
                    ObjRenMigrant.CONTRACTWORK = txtContractorMin.Text;
                    ObjRenMigrant.DATECOMMENCING = txtCommencingDate.Text;
                    ObjRenMigrant.ENDINGDATE = txtEnding.Text;
                    ObjRenMigrant.AGENTNAME = txtSiteManager.Text;
                    ObjRenMigrant.MAXIMUMNOMIGRANT = txtMaxEstEmp.Text;
                    ObjRenMigrant.AGENTNAMEADDRESS = txtMigrantWorkmen.Text;
                    ObjRenMigrant.CONTRACTOR = rblContractor.SelectedValue;
                    ObjRenMigrant.DEATILS = txtDetail.Text;
                    ObjRenMigrant.SUSPENDINGREVOKING = rblLicSuspending.SelectedValue;
                    ObjRenMigrant.ORDERNO = txtOrderNo.Text;
                    ObjRenMigrant.ORDERDATE = txtOrderDate.Text;
                    ObjRenMigrant.WORKESTPAST5YEARS = rblfiveyears.SelectedValue;
                    ObjRenMigrant.ESTDETAILS = txtEstablishDetails.Text;
                    ObjRenMigrant.PRINCIPLEEMPDETAILS = txtEmpDetails.Text;
                    ObjRenMigrant.NATUREWORK = txtNature.Text;
                    ObjRenMigrant.EMPENCLOSED = rblEmpClosed.SelectedValue;

                    result = objRenbal.InsertRENMigrantContractorDetails(ObjRenMigrant);

                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "Renewal ContractorMigrantWork Details Submitted Successfully";
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
        public string validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";

                if (string.IsNullOrEmpty(txtRenLicNo.Text) || txtRenLicNo.Text == "" || txtRenLicNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter License Number\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtRenLicIssued.Text) || txtRenLicIssued.Text == "" || txtRenLicIssued.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter License Issued Date\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtRenValid.Text) || txtRenValid.Text == "" || txtRenValid.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter License Valid Date\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtTitlesdt.Text) || txtTitlesdt.Text == "" || txtTitlesdt.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Title\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNAMES.Text) || txtNAMES.Text == "" || txtNAMES.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEmail.Text) || txtEmail.Text == "" || txtEmail.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Email\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtMobileNo.Text) || txtMobileNo.Text == "" || txtMobileNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Mobileno\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtFather.Text) || txtFather.Text == "" || txtFather.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter FatherName\\n";
                    slno = slno + 1;
                }
                if (ddlStatedt.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Select State....! \\n";
                    slno = slno + 1;
                }
                if (ddlDistricdt.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Select distric....! \\n";
                    slno = slno + 1;
                }
                //if (ddlMandaldt.SelectedIndex == 0)
                //{
                //    errormsg = errormsg + slno + ". Please Select Mandal....! \\n";
                //    slno = slno + 1;
                //}
                //if (ddlVillagesdt.SelectedIndex == 0)
                //{
                //    errormsg = errormsg + slno + ". Please Select Village....! \\n";
                //    slno = slno + 1;
                //}
                if (string.IsNullOrEmpty(txtLocalition.Text) || txtLocalition.Text == "" || txtLocalition.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter locality\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNearLandMark.Text) || txtNearLandMark.Text == "" || txtNearLandMark.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Landmark\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtpinS.Text) || txtpinS.Text == "" || txtpinS.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Pincode\\n";
                    slno = slno + 1;
                }
                if (rblDateofBirth.SelectedValue == "D")
                {
                    if (string.IsNullOrEmpty(txtDateBirth.Text) || txtDateBirth.Text == "" || txtDateBirth.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Date\\n";
                        slno = slno + 1;
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(txtAges.Text) || txtAges.Text == "" || txtAges.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter AGE...!\\n";
                        slno = slno + 1;
                    }
                }
                if (ddlSates.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Select State....! \\n";
                    slno = slno + 1;
                }
                if (ddlDistric.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Select distric....! \\n";
                    slno = slno + 1;
                }
                if (ddlMandal.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Select Mandal....! \\n";
                    slno = slno + 1;
                }
                if (ddlVillage.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Select Village....! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLocal.Text) || txtLocal.Text == "" || txtLocal.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter locality\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNearMark.Text) || txtNearMark.Text == "" || txtNearMark.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Landmark\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPin.Text) || txtPin.Text == "" || txtPin.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Pincode\\n";
                    slno = slno + 1;
                }
                if (rblArtical5.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Enter ARTICAL FIVE YEARS\\n";
                    slno = slno + 1;
                }
                if (rblMakeApplicationCrime.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Enter Criminal Case is pending at the time of making\\n";
                    slno = slno + 1;
                }
                if (rblCriminalCase.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Enter Criminal-Case at any time during the period of five years immediately preceding the date\\n";
                    slno = slno + 1;
                }
                if (rblCriminalCase.SelectedValue == "Y")
                {
                    if (ddlLic.SelectedIndex == 0)
                    {
                        errormsg = errormsg + slno + ". Please Select License....! \\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtLicNo.Text) || txtLicNo.Text == "" || txtLicNo.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter License No\\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtDateLic.Text) || txtDateLic.Text == "" || txtDateLic.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Date of License No\\n";
                        slno = slno + 1;
                    }
                }
                else
                {
                    if (rblTribal.SelectedIndex == -1)
                    {
                        errormsg = errormsg + slno + ". Please Enter Tribal\\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtReasons.Text) || txtReasons.Text == "" || txtReasons.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Reason...!\\n";
                        slno = slno + 1;
                    }
                }
                if (string.IsNullOrEmpty(txtNameofEstablish.Text) || txtNameofEstablish.Text == "" || txtNameofEstablish.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name of the establishment...!\\n";
                    slno = slno + 1;
                }
                if (ddlstate.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Select State....! \\n";
                    slno = slno + 1;
                }
                if (ddldist.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Select distric....! \\n";
                    slno = slno + 1;
                }
                if (ddlmand.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Select Mandal....! \\n";
                    slno = slno + 1;
                }
                if (ddlvilla.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Select Village....! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLocality.Text) || txtLocality.Text == "" || txtLocality.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter locality\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLandmark.Text) || txtLandmark.Text == "" || txtLandmark.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Landmark\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPincode.Text) || txtPincode.Text == "" || txtPincode.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Pincode\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtbusiness.Text) || txtbusiness.Text == "" || txtbusiness.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Type of business, trade, industry, manufacture or occupation\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtRegNoEst.Text) || txtRegNoEst.Text == "" || txtRegNoEst.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Registration Number of the establishment \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDateRegCert.Text) || txtDateRegCert.Text == "" || txtDateRegCert.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Date of certificate of registration \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypContractors.Text) || hypContractors.Text == "" || hypContractors.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Contractor's Photo \\n";
                    slno = slno + 1;
                }

                return errormsg;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void BindData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objRenbal.GetRenMigrantWorker(hdnUserID.Value, UnitID);
                if (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["UnitID"] = Convert.ToString(ds.Tables[0].Rows[0]["RENCM_UNITID"]);
                        txtRenLicNo.Text = ds.Tables[0].Rows[0]["RENCM_LICRENO"].ToString();
                        txtRenLicIssued.Text = ds.Tables[0].Rows[0]["RENCM_LICISSUEDDATE"].ToString();
                        txtRenValid.Text = ds.Tables[0].Rows[0]["RENCM_LICRENVALIDDATE"].ToString();
                        txtTitlesdt.Text = ds.Tables[0].Rows[0]["RENCM_TITLE"].ToString();
                        txtNAMES.Text = ds.Tables[0].Rows[0]["RENCM_NAME"].ToString();
                        txtEmail.Text = ds.Tables[0].Rows[0]["RENCM_EMAILID"].ToString();
                        txtMobileNo.Text = ds.Tables[0].Rows[0]["RENCM_MOBILENO"].ToString();
                        txtFather.Text = ds.Tables[0].Rows[0]["RENCM_FATHERNAME"].ToString();
                        ddlStatedt.SelectedValue = ds.Tables[0].Rows[0]["RENCM_STATE"].ToString();
                        ddlDistricdt.SelectedValue = ds.Tables[0].Rows[0]["RENCM_DISTRIC"].ToString();
                        ddlDistricdt_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlMandaldt.SelectedValue = ds.Tables[0].Rows[0]["RENCM_MANDAL"].ToString();
                        ddlMandaldt_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlVillagesdt.SelectedValue = ds.Tables[0].Rows[0]["RENCM_VILLAGE"].ToString();
                        txtLocalition.Text = ds.Tables[0].Rows[0]["RENCM_LOCALITY"].ToString();
                        txtNearLandMark.Text = ds.Tables[0].Rows[0]["RENCM_NEARLAND"].ToString();
                        txtpinS.Text = ds.Tables[0].Rows[0]["RENCM_PINCODE"].ToString();
                        rblDateofBirth.SelectedValue = ds.Tables[0].Rows[0]["RENCM_BIRTHAGE"].ToString();
                        if (rblDateofBirth.SelectedValue == "D")
                        {
                            DateBirth.Visible = true;
                            txtDateBirth.Text = ds.Tables[0].Rows[0]["RENCM_DATEOFBIRTH"].ToString();
                        }
                        else
                        {
                            Age.Visible = true;
                            txtAges.Text = ds.Tables[0].Rows[0]["RENCM_AGE"].ToString();
                        }

                        ddlSates.SelectedValue = ds.Tables[0].Rows[0]["RENCM_STATES"].ToString();
                        ddlDistric.SelectedValue = ds.Tables[0].Rows[0]["RENCM_DISTRICS"].ToString();
                        ddlDistric_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlMandal.SelectedValue = ds.Tables[0].Rows[0]["RENCM_MANDALS"].ToString();
                        ddlMandal_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlVillage.SelectedValue = ds.Tables[0].Rows[0]["RENCM_VILLAGES"].ToString();
                        txtLocal.Text = ds.Tables[0].Rows[0]["RENCM_LOCALITYS"].ToString();
                        txtNearMark.Text = ds.Tables[0].Rows[0]["RENCM_LANDMARKS"].ToString();
                        txtPin.Text = ds.Tables[0].Rows[0]["RENCM_PINCODES"].ToString();
                        rblArtical5.SelectedValue = ds.Tables[0].Rows[0]["RENCM_ARTICLE5"].ToString();
                        rblMakeApplicationCrime.SelectedValue = ds.Tables[0].Rows[0]["RENCM_CRIMINALCASEAPP"].ToString();
                        rblCriminalCase.SelectedValue = ds.Tables[0].Rows[0]["RENCM_CONVICTED5APPLICATION"].ToString();
                        rblDistricCouncil.SelectedValue = ds.Tables[0].Rows[0]["RENCM_DISTRICCOUNCIL"].ToString();
                        if (rblDistricCouncil.SelectedValue == "Y")
                        {
                            Licdetails.Visible = true;
                            ddlLic.SelectedValue = ds.Tables[0].Rows[0]["RENCM_LICENSE"].ToString();
                            Validdate.Visible = true;
                            txtValidDate.Text = ds.Tables[0].Rows[0]["RENCM_VALIDDATE"].ToString();
                        }
                        else
                        {
                            Tribal.Visible = true;
                            rblTribal.SelectedValue = ds.Tables[0].Rows[0]["RENCM_TRIBAL"].ToString();
                            Reasons.Visible = true;
                            txtReasons.Text = ds.Tables[0].Rows[0]["RENCM_REMARK"].ToString();
                        }

                        txtLicNo.Text = ds.Tables[0].Rows[0]["RENCM_LICNOS"].ToString();
                        txtDateLic.Text = ds.Tables[0].Rows[0]["RENCM_DATEOFLICENSE"].ToString();

                        txtNameofEstablish.Text = ds.Tables[0].Rows[0]["RENCM_NAMEEST"].ToString();
                        ddlstate.SelectedValue = ds.Tables[0].Rows[0]["RENCM_STATED"].ToString();
                        ddldist.SelectedValue = ds.Tables[0].Rows[0]["RENCM_DIST"].ToString();
                        ddldist_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlmand.SelectedValue = ds.Tables[0].Rows[0]["RENCM_MAND"].ToString();
                        ddlmand_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlvilla.SelectedValue = ds.Tables[0].Rows[0]["RENCM_VILLA"].ToString();
                        txtLocality.Text = ds.Tables[0].Rows[0]["RENCM_LOCAL"].ToString();
                        txtLandmark.Text = ds.Tables[0].Rows[0]["RENCM_NEARESTLANDMAEK"].ToString();
                        txtPincode.Text = ds.Tables[0].Rows[0]["RENCM_PIN"].ToString();
                        txtbusiness.Text = ds.Tables[0].Rows[0]["RENCM_TYPEOFBUSINESS"].ToString();
                        txtRegNoEst.Text = ds.Tables[0].Rows[0]["RENCM_REGNO"].ToString();
                        txtDateRegCert.Text = ds.Tables[0].Rows[0]["RENCM_DATEOFREG"].ToString();
                        ddlTitles.SelectedValue = ds.Tables[0].Rows[0]["RENCM_TITLES"].ToString();
                        txtNameEmp.Text = ds.Tables[0].Rows[0]["RENCM_NAMEOFEMP"].ToString();
                        txtNameMigrantEmp.Text = ds.Tables[0].Rows[0]["RENCM_MIGRANTNAMEEMP"].ToString();
                        txtContractorMin.Text = ds.Tables[0].Rows[0]["RENCM_CONTRACTWORK"].ToString();
                        txtCommencingDate.Text = ds.Tables[0].Rows[0]["RENCM_DATECOMMENCING"].ToString();
                        txtEnding.Text = ds.Tables[0].Rows[0]["RENCM_ENDINGDATE"].ToString();
                        txtSiteManager.Text = ds.Tables[0].Rows[0]["RENCM_AGENTNAME"].ToString();
                        txtMaxEstEmp.Text = ds.Tables[0].Rows[0]["RENCM_MAXIMUMNOMIGRANT"].ToString();
                        txtMigrantWorkmen.Text = ds.Tables[0].Rows[0]["RENCM_AGENTNAMEADDRESS"].ToString();
                        rblContractor.Text = ds.Tables[0].Rows[0]["RENCM_5CONTRACTOR"].ToString();
                        if (rblContractor.SelectedValue == "Y")
                        {
                            Details.Visible = true;
                            txtDetail.Text = ds.Tables[0].Rows[0]["RENCM_DEATILS"].ToString();
                        }
                        else { Details.Visible = false; }

                        rblLicSuspending.SelectedValue = ds.Tables[0].Rows[0]["RENCM_SUSPENDINGREVOKING"].ToString();
                        if (rblLicSuspending.SelectedValue == "Y")
                        {
                            Order.Visible = true;
                            txtOrderNo.Text = ds.Tables[0].Rows[0]["RENCM_ORDERNO"].ToString();
                            txtOrderDate.Text = ds.Tables[0].Rows[0]["RENCM_ORDERDATE"].ToString();
                        }


                        rblfiveyears.SelectedValue = ds.Tables[0].Rows[0]["RENCM_WORKESTPAST5YEARS"].ToString();
                        if (rblfiveyears.SelectedValue == "Y")
                        {
                            EstablishDetails.Visible = true;
                            txtEstablishDetails.Text = ds.Tables[0].Rows[0]["RENCM_ESTDETAILS"].ToString();
                            txtEmpDetails.Text = ds.Tables[0].Rows[0]["RENCM_PRINCIPLEEMPDETAILS"].ToString();
                            txtNature.Text = ds.Tables[0].Rows[0]["RENCM_NATUREWORK"].ToString();
                        }

                        rblEmpClosed.SelectedValue = ds.Tables[0].Rows[0]["RENCM_EMPENCLOSED"].ToString();

                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        hdnUserID.Value = Convert.ToString(ds.Tables[1].Rows[0]["RENMW_RENQDID"]);
                        ViewState["Migrant"]= ds.Tables[1];
                        GVMigrant.DataSource = ds.Tables[1];
                        GVMigrant.DataBind();
                        GVMigrant.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                btnsave_Click(sender, e);
                if (ErrorMsg == "")
                    Response.Redirect("~/User/Renewal/RENFactoriesLicense.aspx?Next=" + "N");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btndpr_Click(object sender, EventArgs e)
        {
            try
            {
                string Error = ""; string message = "";
                if (fupContractors.HasFile)
                {
                    Error = validations(fupContractors);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["RENAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["RENQID"]) + "\\" + "Contractor's Photo" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupContractors.PostedFile.SaveAs(serverpath + "\\" + fupContractors.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupContractors.PostedFile.SaveAs(serverpath + "\\" + fupContractors.PostedFile.FileName);
                            }
                        }


                        RenAttachments objRenAttachments = new RenAttachments();
                        objRenAttachments.UNITID = Convert.ToString(Session["RENUNITID"]);
                        objRenAttachments.Questionnareid = Convert.ToString(Session["RENQID"]);
                        objRenAttachments.MasterID = "133";
                        objRenAttachments.FilePath = serverpath + fupContractors.PostedFile.FileName;
                        objRenAttachments.FileName = fupContractors.PostedFile.FileName;
                        objRenAttachments.FileType = fupContractors.PostedFile.ContentType;
                        objRenAttachments.FileDescription = "Upload Contractor's Photo";
                        objRenAttachments.CreatedBy = hdnUserID.Value;
                        objRenAttachments.IPAddress = getclientIP();
                        result = objRenbal.InsertAttachmentsRenewal(objRenAttachments);
                        if (result != "")
                        {
                            hypContractors.Text = fupContractors.PostedFile.FileName;
                            hypContractors.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + objRenAttachments.FilePath;
                            hypContractors.Target = "blank";
                            message = "alert('" + "Contractor's Photo Uploaded successfully" + "')";
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
                throw ex;
            }
        }

        protected void btnPreviuos_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/Renewal/RENShopsEstablishment.aspx?Previous=" + "P");
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
    }
}