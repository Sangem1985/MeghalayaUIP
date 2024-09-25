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
    public partial class RENShopsEstablishment : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        RenewalBAL objRenbal = new RenewalBAL();
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
        protected void GetAppliedorNot()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = objRenbal.GetRenAppliedApprovalID(hdnUserID.Value, Convert.ToString(Session["RENUNITID"]), Convert.ToString(Session["RENQID"]), "10", "70");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(ds.Tables[0].Rows[0]["RENDA_APPROVALID"]) == "70")
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
                            Response.Redirect("~/User/Renewal/RENContractorMigrantWork.aspx?Next=" + "N");
                        else if (Convert.ToString(Request.QueryString[0]) == "P")
                            Response.Redirect("~/User/Renewal/RENBoilerDetails.aspx?Previous=" + "P");
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }
        }
        protected void btnaddmore_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ddldist.SelectedValue) || string.IsNullOrEmpty(ddlMAND.SelectedValue) || string.IsNullOrEmpty(ddlVilla.SelectedValue) || string.IsNullOrEmpty(txtLocal.Text) || string.IsNullOrEmpty(txtpincode.Text))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("RENWP_UNITID", typeof(string));
                    dt.Columns.Add("RENWP_CREATEDBY", typeof(string));
                    dt.Columns.Add("RENWP_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("RENWP_DISTRIC", typeof(string));
                    dt.Columns.Add("RENWP_MANDAL", typeof(string));
                    dt.Columns.Add("RENWP_VILLAGE", typeof(string));
                    dt.Columns.Add("RENWP_LOCALITY", typeof(string));
                    dt.Columns.Add("RENWP_PINCODE", typeof(string));



                    if (ViewState["DETAILS"] != null)
                    {
                        dt = (DataTable)ViewState["DETAILS"];
                    }

                    DataRow dr = dt.NewRow();
                    dr["RENWP_UNITID"] = Convert.ToString(ViewState["UnitID"]);
                    dr["RENWP_CREATEDBY"] = hdnUserID.Value;
                    dr["RENWP_CREATEDBYIP"] = getclientIP();
                    dr["RENWP_DISTRIC"] = ddldist.SelectedValue;
                    dr["RENWP_MANDAL"] = ddlMAND.SelectedValue;
                    dr["RENWP_VILLAGE"] = ddlVilla.SelectedValue;
                    dr["RENWP_LOCALITY"] = txtLocal.Text;
                    dr["RENWP_PINCODE"] = txtpincode.Text;


                    dt.Rows.Add(dr);
                    GVDETAILS.Visible = true;
                    GVDETAILS.DataSource = dt;
                    GVDETAILS.DataBind();
                    ViewState["DETAILS"] = dt;
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(ddlGender.SelectedValue) || string.IsNullOrEmpty(txtAge.Text) || string.IsNullOrEmpty(ddlRelation.SelectedValue))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("RENED_UNITID", typeof(string));
                    dt.Columns.Add("RENED_CREATEDBY", typeof(string));
                    dt.Columns.Add("RENED_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("RENED_NAME", typeof(string));
                    dt.Columns.Add("RENED_GENDER", typeof(string));
                    dt.Columns.Add("RENED_AGE", typeof(string));
                    dt.Columns.Add("RENED_RELATIONSHIP", typeof(string));



                    if (ViewState["EMPLOYEES"] != null)
                    {
                        dt = (DataTable)ViewState["EMPLOYEES"];
                    }

                    DataRow dr = dt.NewRow();
                    dr["RENED_UNITID"] = Convert.ToString(ViewState["UnitID"]);
                    dr["RENED_CREATEDBY"] = hdnUserID.Value;
                    dr["RENED_CREATEDBYIP"] = getclientIP();
                    dr["RENED_NAME"] = txtName.Text;
                    dr["RENED_GENDER"] = ddlGender.SelectedValue;
                    dr["RENED_AGE"] = txtAge.Text;
                    dr["RENED_RELATIONSHIP"] = ddlRelation.SelectedValue;



                    dt.Rows.Add(dr);
                    GVTEST.Visible = true;
                    GVTEST.DataSource = dt;
                    GVTEST.DataBind();
                    ViewState["EMPLOYEES"] = dt;
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }
        protected void BindDistricts()
        {
            try
            {

                ddlDistrict.Items.Clear();
                ddlMandal.Items.Clear();
                ddlVillage.Items.Clear();

                ddldist.Items.Clear();
                ddlMAND.Items.Clear();
                ddlVilla.Items.Clear();

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

                    ddldist.DataSource = objDistrictModel;
                    ddldist.DataValueField = "DistrictId";
                    ddldist.DataTextField = "DistrictName";
                    ddldist.DataBind();

                }
                else
                {
                    ddlDistrict.DataSource = null;
                    ddlDistrict.DataBind();

                    ddldist.DataSource = null;
                    ddldist.DataBind();

                }
                AddSelect(ddlDistrict);
                AddSelect(ddlMandal);
                AddSelect(ddlVillage);

                AddSelect(ddldist);
                AddSelect(ddlMAND);
                AddSelect(ddlVilla);


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
                //Failure.Visible = true;
                //lblmsg0.Text = ex.Message;
                throw ex;
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
                ddlMAND.ClearSelection();
                ddlVilla.ClearSelection();
                if (ddldist.SelectedItem.Text != "--Select--")
                {
                    BindMandal(ddlMAND, ddldist.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }

        protected void ddlMAND_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlVilla.ClearSelection();
                if (ddlMAND.SelectedItem.Text != "--Select--")
                {
                    BindVillages(ddlVilla, ddlMAND.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
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
                    RenShopsEstablishment ObjRenShopEst = new RenShopsEstablishment();

                    int count = 0, count1 = 0, count2 = 0, count3 = 0, count4 = 0;
                    for (int i = 0; i < GVDETAILS.Rows.Count; i++)
                    {
                        ObjRenShopEst.Questionnariid = Convert.ToString(Session["RENQID"]); 
                        ObjRenShopEst.CreatedBy = hdnUserID.Value;
                        ObjRenShopEst.UnitId = Convert.ToString(Session["RENUNITID"]);
                        ObjRenShopEst.IPAddress = getclientIP();
                        ObjRenShopEst.DISTICS = GVDETAILS.Rows[i].Cells[1].Text;
                        ObjRenShopEst.MANDALS = GVDETAILS.Rows[i].Cells[2].Text;
                        ObjRenShopEst.VILLAGES = GVDETAILS.Rows[i].Cells[3].Text;
                        ObjRenShopEst.LOCALITYS = GVDETAILS.Rows[i].Cells[4].Text;
                        ObjRenShopEst.PINCODES = GVDETAILS.Rows[i].Cells[5].Text;




                        string A = objRenbal.InsertRenewalShopsDetails(ObjRenShopEst);
                        if (A != "")
                        { count = count + 1; }
                    }
                    if (GVDETAILS.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = "Renewal Shops Establishment Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }

                    for (int i = 0; i < GVTEST.Rows.Count; i++)
                    {
                        ObjRenShopEst.Questionnariid = Convert.ToString(Session["RENQID"]); 
                        ObjRenShopEst.CreatedBy = hdnUserID.Value;
                        ObjRenShopEst.UnitId = Convert.ToString(Session["RENUNITID"]);
                        ObjRenShopEst.IPAddress = getclientIP();
                        ObjRenShopEst.NAMES = GVTEST.Rows[i].Cells[1].Text;
                        ObjRenShopEst.GENDER = GVTEST.Rows[i].Cells[2].Text;
                        ObjRenShopEst.AGE = GVTEST.Rows[i].Cells[3].Text;
                        ObjRenShopEst.RELATIONSHIP = GVTEST.Rows[i].Cells[4].Text;




                        string A = objRenbal.INSERTRENTRenLabourEstablishmentDetails(ObjRenShopEst);
                        if (A != "")
                        { count1 = count + 1; }
                    }
                    if (GVTEST.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = "Renewal Renewal Shops Establishment Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                    for (int i = 0; i < GVPROPERTIE.Rows.Count; i++)
                    {
                        ObjRenShopEst.Questionnariid = Convert.ToString(Session["RENQID"]); 
                        ObjRenShopEst.CreatedBy = hdnUserID.Value;
                        ObjRenShopEst.UnitId = Convert.ToString(Session["RENUNITID"]);
                        ObjRenShopEst.IPAddress = getclientIP();
                        ObjRenShopEst.NAME_PROPERTIE = GVPROPERTIE.Rows[i].Cells[1].Text;
                        ObjRenShopEst.COMMUNITIONADDRESS = GVPROPERTIE.Rows[i].Cells[2].Text;
                        ObjRenShopEst.COMMUNITY = GVPROPERTIE.Rows[i].Cells[3].Text;
                        ObjRenShopEst.COMMUNITYOTHER = GVPROPERTIE.Rows[i].Cells[4].Text;

                        string A = objRenbal.InsertRenPropertiesDetails(ObjRenShopEst);
                        if (A != "")
                        { count2 = count + 1; }
                    }
                    if (GVPROPERTIE.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = "Renewal Renewal Shops Establishment Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                    for (int i = 0; i < GVPATNER.Rows.Count; i++)
                    {
                        ObjRenShopEst.Questionnariid = Convert.ToString(Session["RENQID"]); 
                        ObjRenShopEst.CreatedBy = hdnUserID.Value;
                        ObjRenShopEst.UnitId = Convert.ToString(Session["RENUNITID"]);
                        ObjRenShopEst.IPAddress = getclientIP();
                        ObjRenShopEst.NAMEPATNER = GVPATNER.Rows[i].Cells[1].Text;
                        ObjRenShopEst.PATNERADDRESS = GVPATNER.Rows[i].Cells[2].Text;


                        string A = objRenbal.InsertRenPatnerDetails(ObjRenShopEst);
                        if (A != "")
                        { count3 = count + 1; }
                    }
                    if (GVPATNER.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = "Renewal Shops Establishment Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                    for (int i = 0; i < GVLIMITED.Rows.Count; i++)
                    {
                        ObjRenShopEst.Questionnariid = Convert.ToString(Session["RENQID"]); 
                        ObjRenShopEst.CreatedBy = hdnUserID.Value;
                        ObjRenShopEst.UnitId = Convert.ToString(Session["RENUNITID"]);
                        ObjRenShopEst.IPAddress = getclientIP();
                        ObjRenShopEst.NAMEPATNER = GVLIMITED.Rows[i].Cells[1].Text;
                        ObjRenShopEst.PATNERADDRESS = GVLIMITED.Rows[i].Cells[2].Text;


                        string A = objRenbal.InsertRenLimitedCompanyDetails(ObjRenShopEst);
                        if (A != "")
                        { count4 = count + 1; }
                    }
                    if (GVLIMITED.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = "Renewal Shops Establishment Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }


                    ObjRenShopEst.Questionnariid = Convert.ToString(Session["RENQID"]); 
                    ObjRenShopEst.CreatedBy = hdnUserID.Value;
                    ObjRenShopEst.UnitId = Convert.ToString(Session["RENUNITID"]);
                    ObjRenShopEst.IPAddress = getclientIP();

                    ObjRenShopEst.LICNO = txtLicNo.Text;
                    ObjRenShopEst.LICISSUEDATE = txtLicIssueDate.Text;
                    ObjRenShopEst.LICVALIDUP = txtLicValidDate.Text;
                    ObjRenShopEst.NAMEEST = txttradeLic.Text;
                    ObjRenShopEst.CONSTITUTION = ddlconstitution.SelectedValue;
                    ObjRenShopEst.APPLICANTNAME = txtApplicantName.Text;
                    ObjRenShopEst.MOBILENO = txtMobileNo.Text;
                    ObjRenShopEst.EMAILID = txtEmailId.Text;
                    ObjRenShopEst.NAMEOFMANAGER = txtNameAgent.Text;
                    ObjRenShopEst.ADDRESS = txtAddressAgent.Text;
                    ObjRenShopEst.CATEGORYEST = ddlCategory.SelectedValue;
                    ObjRenShopEst.NATUREBUSINESS = txtNature.Text;
                    ObjRenShopEst.YOURFAMILY = rblFamilymember.SelectedValue;
                    ObjRenShopEst.EMPLOYEESEST = rblEMPEst.SelectedValue;
                    ObjRenShopEst.NOOFEMPLOYEE = txtEMPNo.Text;
                    ObjRenShopEst.DISTRIC = ddlDistrict.SelectedValue;
                    ObjRenShopEst.MANDAL = ddlMandal.SelectedValue;
                    ObjRenShopEst.VILLAGE = ddlVillage.SelectedValue;
                    ObjRenShopEst.LOCALITY = txtlocate.Text;
                    ObjRenShopEst.PINCODE = txtpin.Text;
                    ObjRenShopEst.LANDMARK = txtLandmark.Text;
                    ObjRenShopEst.GODOWN = rblOwnership.SelectedValue;
                    ObjRenShopEst.REGRENEWEDDATE = lblRegDate.Text;
                    ObjRenShopEst.REGVALIDDATE = lblRegUptoDate.Text;
                    ObjRenShopEst.YEARRENEWED = lblYearRenewed.Text;
                    ObjRenShopEst.FEES = lblFees.Text;
                    ObjRenShopEst.FEESNOTICE = lblFeesChange.Text;
                    ObjRenShopEst.FINE = lblFine.Text;
                    ObjRenShopEst.PENALTY = lblPenalty.Text;
                    ObjRenShopEst.TOTALPAIDAMOUNT = lblTotalPaid.Text;


                    result = objRenbal.InsertRenShopEstablishmentDetails(ObjRenShopEst);

                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "Renewal Shop Establishment Details Submitted Successfully";
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
                if (string.IsNullOrEmpty(txtLicNo.Text) || txtLicNo.Text == "" || txtLicNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter License No for which renewal\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLicIssueDate.Text) || txtLicIssueDate.Text == "" || txtLicIssueDate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter License Issued Date\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLicValidDate.Text) || txtLicValidDate.Text == "" || txtLicValidDate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter License valid Date\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txttradeLic.Text) || txttradeLic.Text == "" || txttradeLic.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name of Establishment \\n";
                    slno = slno + 1;
                }
                if (ddlconstitution.SelectedIndex == -1 || ddlconstitution.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Constitution Business \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtApplicantName.Text) || txtApplicantName.Text == "" || txtApplicantName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Applicant Name \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtMobileNo.Text) || txtMobileNo.Text == "" || txtMobileNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Mobile No \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEmailId.Text) || txtEmailId.Text == "" || txtEmailId.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter EmailId\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNameAgent.Text) || txtNameAgent.Text == "" || txtNameAgent.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Managaer Name or Agent Name\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAddressAgent.Text) || txtAddressAgent.Text == "" || txtAddressAgent.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Address Managaer/Agent Name\\n";
                    slno = slno + 1;
                }
                //if (ddlCategory.SelectedIndex == -1 || ddlCategory.SelectedItem.Text == "--Select--")
                //{
                //    errormsg = errormsg + slno + ". Please Select Category Esatblishment \\n";
                //    slno = slno + 1;
                //}
                if (string.IsNullOrEmpty(txtNature.Text) || txtNature.Text == "" || txtNature.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Nature of Business\\n";
                    slno = slno + 1;
                }
                if (rblFamilymember.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select family members employed in the establishment \\n";
                    slno = slno + 1;
                }
                if (rblEMPEst.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Do you have employees working in the establishment \\n";
                    slno = slno + 1;
                }
                //if (string.IsNullOrEmpty(txtEMPNo.Text) || txtEMPNo.Text == "" || txtEMPNo.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Nature of Business\\n";
                //    slno = slno + 1;
                //}
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
                if (string.IsNullOrEmpty(txtlocate.Text) || txtlocate.Text == "" || txtlocate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Locality \\n";
                    slno = slno + 1;
                }
                //if (string.IsNullOrEmpty(txtpincode.Text) || txtpincode.Text == "" || txtpincode.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Unit PinCode \\n";
                //    slno = slno + 1;
                //}
                if (string.IsNullOrEmpty(txtLandmark.Text) || txtLandmark.Text == "" || txtLandmark.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter LandMark \\n";
                    slno = slno + 1;
                }
                if (rblOwnership.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select other office/godown/warehouse attached to this establishment situated \\n";
                    slno = slno + 1;
                }
                //if (string.IsNullOrEmpty(hypEmployeelist.Text) || hypEmployeelist.Text == "" || hypEmployeelist.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Employee List Only.....! \\n";
                //    slno = slno + 1;
                //}
                //if (string.IsNullOrEmpty(hypEmployer.Text) || hypEmployer.Text == "" || hypEmployer.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Photo of the Employer.....! \\n";
                //    slno = slno + 1;
                //}
                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btndpr_Click(object sender, EventArgs e)
        {
            try
            {

                string Error = ""; string message = ""; string result = "";
                if (fupEmployeelist.HasFile)
                {
                    Error = validations(fupEmployeelist);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\RenewalsAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["RENQID"]) + "\\" + "Employee List Only" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupEmployeelist.PostedFile.SaveAs(serverpath + "\\" + fupEmployeelist.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupEmployeelist.PostedFile.SaveAs(serverpath + "\\" + fupEmployeelist.PostedFile.FileName);
                            }
                        }


                        RenAttachments objRenAttachments = new RenAttachments();
                        objRenAttachments.UNITID = Convert.ToString(Session["RENUNITID"]);
                        objRenAttachments.Questionnareid = Convert.ToString(Session["RENQID"]);
                        objRenAttachments.MasterID = "135";
                        objRenAttachments.FilePath = serverpath + fupEmployeelist.PostedFile.FileName;
                        objRenAttachments.FileName = fupEmployeelist.PostedFile.FileName;
                        objRenAttachments.FileType = fupEmployeelist.PostedFile.ContentType;
                        objRenAttachments.FileDescription = "Employee List Only";
                        objRenAttachments.CreatedBy = hdnUserID.Value;
                        objRenAttachments.IPAddress = getclientIP();
                        result = objRenbal.InsertAttachmentsRenewal(objRenAttachments);
                        if (result != "")
                        {
                            hypEmployeelist.Text = fupEmployeelist.PostedFile.FileName;
                            hypEmployeelist.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + objRenAttachments.FilePath;
                            hypEmployeelist.Target = "blank";
                            message = "alert('" + "Employee List Only Uploaded successfully" + "')";
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
            }
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

        protected void btnphoto_Click(object sender, EventArgs e)
        {
            try
            {


                string Error = ""; string message = "";string result = "";
                if (fupEmployer.HasFile)
                {
                    Error = validations(fupEmployer);
                    if (Error == "")
                    {
                        string serverpath = HttpContext.Current.Server.MapPath("~\\RenewalsAttachments\\" + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["RENQID"]) + "\\" + "Photo of the Employer" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupEmployer.PostedFile.SaveAs(serverpath + "\\" + fupEmployer.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupEmployer.PostedFile.SaveAs(serverpath + "\\" + fupEmployer.PostedFile.FileName);
                            }
                        }


                        RenAttachments objRenAttachments = new RenAttachments();
                        objRenAttachments.UNITID = Convert.ToString(Session["RENUNITID"]);
                        objRenAttachments.Questionnareid = Convert.ToString(Session["RENQID"]);
                        objRenAttachments.MasterID = "134";
                        objRenAttachments.FilePath = serverpath + fupEmployer.PostedFile.FileName;
                        objRenAttachments.FileName = fupEmployer.PostedFile.FileName;
                        objRenAttachments.FileType = fupEmployer.PostedFile.ContentType;
                        objRenAttachments.FileDescription = "Photo of the Employer/Proprietor";
                        objRenAttachments.CreatedBy = hdnUserID.Value;
                        objRenAttachments.IPAddress = getclientIP();
                        result = objRenbal.InsertAttachmentsRenewal(objRenAttachments);
                        if (result != "")
                        {
                            hypEmployer.Text = fupEmployer.PostedFile.FileName;
                            hypEmployer.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + objRenAttachments.FilePath;
                            hypEmployer.Target = "blank";
                            message = "alert('" + "Photo of the Employer/Proprietor Uploaded successfully" + "')";
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

        protected void GVDETAILS_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVDETAILS.Rows.Count > 0)
                {
                    ((DataTable)ViewState["DETAILS"]).Rows.RemoveAt(e.RowIndex);
                    this.GVDETAILS.DataSource = ((DataTable)ViewState["DETAILS"]).DefaultView;
                    this.GVDETAILS.DataBind();
                    GVDETAILS.Visible = true;
                    GVDETAILS.Focus();

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

        protected void GVTEST_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVTEST.Rows.Count > 0)
                {
                    ((DataTable)ViewState["EMPLOYEES"]).Rows.RemoveAt(e.RowIndex);
                    this.GVTEST.DataSource = ((DataTable)ViewState["EMPLOYEES"]).DefaultView;
                    this.GVTEST.DataBind();
                    GVTEST.Visible = true;
                    GVTEST.Focus();

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
        public void Binddata()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objRenbal.GetRenShposEstablishmentLabourDetails(hdnUserID.Value, UnitID);
                if (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0 || ds.Tables[2].Rows.Count > 0 || ds.Tables[3].Rows.Count > 0 || ds.Tables[4].Rows.Count > 0 || ds.Tables[5].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["UnitID"] = Convert.ToString(ds.Tables[0].Rows[0]["RENSE_UNITID"]);
                        txtLicNo.Text = ds.Tables[0].Rows[0]["RENSE_LICNO"].ToString();
                        txtLicIssueDate.Text = ds.Tables[0].Rows[0]["RENSE_LICISSUEDATE"].ToString();
                        txtLicValidDate.Text = ds.Tables[0].Rows[0]["RENSE_LICVALIDUP"].ToString();
                        txttradeLic.Text = ds.Tables[0].Rows[0]["RENSE_NAMEEST"].ToString();
                        ddlconstitution.SelectedValue = ds.Tables[0].Rows[0]["RENSE_CONSTITUTION"].ToString();
                        ddlconstitution_SelectedIndexChanged(null, EventArgs.Empty);
                        txtApplicantName.Text = ds.Tables[0].Rows[0]["RENSE_APPLICANTNAME"].ToString();
                        txtMobileNo.Text = ds.Tables[0].Rows[0]["RENSE_MOBILENO"].ToString();
                        txtEmailId.Text = ds.Tables[0].Rows[0]["RENSE_EMAILID"].ToString();
                        txtNameAgent.Text = ds.Tables[0].Rows[0]["RENSE_NAMEOFMANAGER"].ToString();
                        txtAddressAgent.Text = ds.Tables[0].Rows[0]["RENSE_ADDRESS"].ToString();
                        ddlCategory.SelectedValue = ds.Tables[0].Rows[0]["RENSE_CATEGORYEST"].ToString();
                        txtNature.Text = ds.Tables[0].Rows[0]["RENSE_NATUREBUSINESS"].ToString();
                        rblFamilymember.SelectedValue = ds.Tables[0].Rows[0]["RENSE_YOURFAMILY"].ToString();
                        if (rblFamilymember.SelectedValue == "Y")
                        {
                            GVTEST.Visible = true;
                        }
                        else { GVTEST.Visible = false; }
                        rblEMPEst.SelectedValue = ds.Tables[0].Rows[0]["RENSE_EMPLOYEESEST"].ToString();
                        if (rblEMPEst.SelectedValue == "Y")
                        {
                            NumberEmp.Visible = true;
                            txtEMPNo.Text = ds.Tables[0].Rows[0]["RENSE_NOOFEMPLOYEE"].ToString();
                        }
                        else { NumberEmp.Visible = false; }
                       
                        ddlDistrict.SelectedItem.Text = ds.Tables[0].Rows[0]["RENSE_DISTRIC"].ToString();
                        ddldist_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlMandal.SelectedItem.Text = ds.Tables[0].Rows[0]["RENSE_MANDAL"].ToString();
                        ddlMandal_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlVillage.SelectedItem.Text = ds.Tables[0].Rows[0]["RENSE_VILLAGE"].ToString();
                        txtlocate.Text = ds.Tables[0].Rows[0]["RENSE_LOCALITY"].ToString();
                        txtpin.Text = ds.Tables[0].Rows[0]["RENSE_PINCODE"].ToString();
                        txtLandmark.Text = ds.Tables[0].Rows[0]["RENSE_LANDMARK"].ToString();
                        rblOwnership.SelectedValue = ds.Tables[0].Rows[0]["RENSE_GODOWN"].ToString();
                        if (rblOwnership.SelectedValue == "Y")
                        {
                            DETAILSGRID.Visible = true;
                        }
                        else { DETAILSGRID.Visible = false; }
                        lblRegDate.Text = ds.Tables[0].Rows[0]["RENSE_REGRENEWEDDATE"].ToString();
                        lblRegUptoDate.Text = ds.Tables[0].Rows[0]["RENSE_REGVALIDDATE"].ToString();
                        lblYearRenewed.Text = ds.Tables[0].Rows[0]["RENSE_YEARRENEWED"].ToString();
                        lblFees.Text = ds.Tables[0].Rows[0]["RENSE_FEES"].ToString();
                        lblFeesChange.Text = ds.Tables[0].Rows[0]["RENSE_FEESNOTICE"].ToString();
                        lblFine.Text = ds.Tables[0].Rows[0]["RENSE_FINE"].ToString();
                        lblPenalty.Text = ds.Tables[0].Rows[0]["RENSE_PENALTY"].ToString();
                        lblTotalPaid.Text = ds.Tables[0].Rows[0]["RENSE_TOTALPAIDAMOUNT"].ToString();

                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        hdnUserID.Value = Convert.ToString(ds.Tables[1].Rows[0]["RENWP_RENQDID"]);
                        ViewState["DETAILS"]= ds.Tables[1];
                        GVDETAILS.DataSource = ds.Tables[1];
                        GVDETAILS.DataBind();
                        GVDETAILS.Visible = true;
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        hdnUserID.Value = Convert.ToString(ds.Tables[2].Rows[0]["RENED_RENQDID"]);
                        ViewState["EMPLOYEES"]= ds.Tables[2];
                        GVTEST.DataSource = ds.Tables[2];
                        GVTEST.DataBind();
                        GVTEST.Visible = true;
                    }
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        hdnUserID.Value = Convert.ToString(ds.Tables[3].Rows[0]["RENP_RENQDID"]);
                        ViewState["PROPERTIE"]= ds.Tables[3];
                        GVPROPERTIE.DataSource = ds.Tables[3];
                        GVPROPERTIE.DataBind();
                        GVPROPERTIE.Visible = true;
                    }
                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        hdnUserID.Value = Convert.ToString(ds.Tables[4].Rows[0]["RENPS_RENQDID"]);
                        ViewState["PATNER"]= ds.Tables[4];
                        GVPATNER.DataSource = ds.Tables[4];
                        GVPATNER.DataBind();
                        GVPATNER.Visible = true;
                    }
                    if (ds.Tables[5].Rows.Count > 0)
                    {
                        hdnUserID.Value = Convert.ToString(ds.Tables[5].Rows[0]["RENLC_RENQDID"]);
                        ViewState["LIMITED"]= ds.Tables[5];
                        GVLIMITED.DataSource = ds.Tables[5];
                        GVLIMITED.DataBind();
                        GVLIMITED.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }

        protected void rblEMPEst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblEMPEst.SelectedValue == "Y")
            {
                NumberEmp.Visible = true;
            }
            else { NumberEmp.Visible = false; }
        }

        protected void rblFamilymember_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblFamilymember.SelectedValue == "Y")
            {
                TestGrid.Visible = true;
            }
            else { TestGrid.Visible = false; }
        }

        protected void rblOwnership_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblOwnership.SelectedValue == "Y")
            {
                DETAILSGRID.Visible = true;
            }
            else { DETAILSGRID.Visible = false; }
        }

        protected void ddlcommunity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlcommunity.SelectedValue == "4")
            {
                other.Visible = true;
            }
            else { other.Visible = false; }
        }

        protected void ddlconstitution_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlconstitution.SelectedValue == "1")
            {
                Proprietor.Visible = true;
                Partnership.Visible = false;
                LimitedCompany.Visible = false;
            }
            else if (ddlconstitution.SelectedValue == "2")
            {
                Partnership.Visible = true;
                Proprietor.Visible = false;
                LimitedCompany.Visible = false;
            }
            else if (ddlconstitution.SelectedValue == "3")
            {
                LimitedCompany.Visible = true;
                Proprietor.Visible = false;
                Partnership.Visible = false;
            }
        }

        protected void btnAddDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtProprtie.Text) || string.IsNullOrEmpty(txtcommonAddress.Text) || string.IsNullOrEmpty(ddlcommunity.SelectedValue))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("RENP_UNITID", typeof(string));
                    dt.Columns.Add("RENP_CREATEDBY", typeof(string));
                    dt.Columns.Add("RENP_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("RENP_NAMEPROPERTIE", typeof(string));
                    dt.Columns.Add("RENP_COMMUNICATIONADDRESS", typeof(string));
                    dt.Columns.Add("RENP_COMMUNITY", typeof(string));
                    dt.Columns.Add("RENP_COMMUNITYOTHER", typeof(string));




                    if (ViewState["PROPERTIE"] != null)
                    {
                        dt = (DataTable)ViewState["PROPERTIE"];
                    }

                    DataRow dr = dt.NewRow();
                    dr["RENP_UNITID"] = Convert.ToString(ViewState["UnitID"]);
                    dr["RENP_CREATEDBY"] = hdnUserID.Value;
                    dr["RENP_CREATEDBYIP"] = getclientIP();
                    dr["RENP_NAMEPROPERTIE"] = txtProprtie.Text;
                    dr["RENP_COMMUNICATIONADDRESS"] = txtcommonAddress.Text;
                    dr["RENP_COMMUNITY"] = ddlcommunity.SelectedValue;
                    if (ddlcommunity.SelectedValue == "4")
                    {
                        dr["RENP_COMMUNITYOTHER"] = txtOther.Text;
                    }


                    dt.Rows.Add(dr);
                    GVPROPERTIE.Visible = true;
                    GVPROPERTIE.DataSource = dt;
                    GVPROPERTIE.DataBind();
                    ViewState["PROPERTIE"] = dt;
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }

        protected void btnpatner_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtPartner.Text) || string.IsNullOrEmpty(txtAddressCommon.Text))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("RENPS_UNITID", typeof(string));
                    dt.Columns.Add("RENPS_CREATEDBY", typeof(string));
                    dt.Columns.Add("RENPS_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("RENPS_NAMEPATNER", typeof(string));
                    dt.Columns.Add("RENPS_COMMUNICATIONADDRESS", typeof(string));



                    if (ViewState["PATNER"] != null)
                    {
                        dt = (DataTable)ViewState["PATNER"];
                    }

                    DataRow dr = dt.NewRow();
                    dr["RENPS_UNITID"] = Convert.ToString(ViewState["UnitID"]);
                    dr["RENPS_CREATEDBY"] = hdnUserID.Value;
                    dr["RENPS_CREATEDBYIP"] = getclientIP();
                    dr["RENPS_NAMEPATNER"] = txtPartner.Text;
                    dr["RENPS_COMMUNICATIONADDRESS"] = txtAddressCommon.Text;



                    dt.Rows.Add(dr);
                    GVPATNER.Visible = true;
                    GVPATNER.DataSource = dt;
                    GVPATNER.DataBind();
                    ViewState["PATNER"] = dt;
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }

        protected void btncompanydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNameDirect.Text) || string.IsNullOrEmpty(txtAddressCommunicate.Text))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("RENLC_UNITID", typeof(string));
                    dt.Columns.Add("RENLC_CREATEDBY", typeof(string));
                    dt.Columns.Add("RENLC_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("RENLC_NAMEOFDIRECTOR", typeof(string));
                    dt.Columns.Add("RENLC_COMMUNICATIONADDRESS", typeof(string));



                    if (ViewState["LIMITED"] != null)
                    {
                        dt = (DataTable)ViewState["LIMITED"];
                    }

                    DataRow dr = dt.NewRow();
                    dr["RENLC_UNITID"] = Convert.ToString(ViewState["UnitID"]);
                    dr["RENLC_CREATEDBY"] = hdnUserID.Value;
                    dr["RENLC_CREATEDBYIP"] = getclientIP();
                    dr["RENLC_NAMEOFDIRECTOR"] = txtNameDirect.Text;
                    dr["RENLC_COMMUNICATIONADDRESS"] = txtAddressCommunicate.Text;



                    dt.Rows.Add(dr);
                    GVLIMITED.Visible = true;
                    GVLIMITED.DataSource = dt;
                    GVLIMITED.DataBind();
                    ViewState["LIMITED"] = dt;
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
            }
        }

        protected void GVPROPERTIE_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVPROPERTIE.Rows.Count > 0)
                {
                    ((DataTable)ViewState["PROPERTIE"]).Rows.RemoveAt(e.RowIndex);
                    this.GVPROPERTIE.DataSource = ((DataTable)ViewState["PROPERTIE"]).DefaultView;
                    this.GVPROPERTIE.DataBind();
                    GVPROPERTIE.Visible = true;
                    GVPROPERTIE.Focus();

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

        protected void GVPATNER_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVPATNER.Rows.Count > 0)
                {
                    ((DataTable)ViewState["PATNER"]).Rows.RemoveAt(e.RowIndex);
                    this.GVPATNER.DataSource = ((DataTable)ViewState["PATNER"]).DefaultView;
                    this.GVPATNER.DataBind();
                    GVPATNER.Visible = true;
                    GVPATNER.Focus();

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

        protected void GVLIMITED_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVLIMITED.Rows.Count > 0)
                {
                    ((DataTable)ViewState["LIMITED"]).Rows.RemoveAt(e.RowIndex);
                    this.GVLIMITED.DataSource = ((DataTable)ViewState["LIMITED"]).DefaultView;
                    this.GVLIMITED.DataBind();
                    GVLIMITED.Visible = true;
                    GVLIMITED.Focus();

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

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                btnsave_Click(sender, e);
                if (ErrorMsg == "")
                    Response.Redirect("~/User/Renewal/RENContractorMigrantWork.aspx?Next=" + "N");
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
                Response.Redirect("~/User/Renewal/RENBoilerDetails.aspx?Previous=" + "P");
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