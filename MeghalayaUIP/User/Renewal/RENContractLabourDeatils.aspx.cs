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
    public partial class RENContractLabourDeatils : System.Web.UI.Page
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

                ds = objRenbal.GetRenAppliedApprovalID(hdnUserID.Value, Convert.ToString(Session["RENUNITID"]), Convert.ToString(Session["RENQID"]), "10", "73");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(ds.Tables[0].Rows[0]["RENDA_APPROVALID"]) == "73")
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
                            Response.Redirect("~/User/Renewal/RENLegalmetrologyDetails.aspx?Next=" + "N");
                        else if (Convert.ToString(Request.QueryString[0]) == "P")
                            Response.Redirect("~/User/Renewal/RENContractLabourDeatils.aspx?Previous=" + "P");
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

        protected void btnaddmore_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ddlTittles.SelectedItem.Text) || string.IsNullOrEmpty(txtFullName.Text) || string.IsNullOrEmpty(txtAddress.Text))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("RENMD_UNITID", typeof(string));
                    dt.Columns.Add("RENMD_CREATEDBY", typeof(string));
                    dt.Columns.Add("RENMD_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("RENMD_TITLE", typeof(string));
                    dt.Columns.Add("RENMD_FULLNAME", typeof(string));
                    dt.Columns.Add("RENMD_ADDRESS", typeof(string));


                    if (ViewState["PERSONDETAILS"] != null)
                    {
                        dt = (DataTable)ViewState["PERSONDETAILS"];
                    }

                    DataRow dr = dt.NewRow();
                    dr["RENMD_UNITID"] = Convert.ToString(ViewState["UnitID"]);
                    dr["RENMD_CREATEDBY"] = hdnUserID.Value;
                    dr["RENMD_CREATEDBYIP"] = getclientIP();
                    dr["RENMD_TITLE"] = ddlTittles.SelectedItem.Text;
                    dr["RENMD_FULLNAME"] = txtFullName.Text;
                    dr["RENMD_ADDRESS"] = txtAddress.Text;


                    dt.Rows.Add(dr);
                    GVDETAILS.Visible = true;
                    GVDETAILS.DataSource = dt;
                    GVDETAILS.DataBind();
                    ViewState["PERSONDETAILS"] = dt;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void GVDETAILS_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVDETAILS.Rows.Count > 0)
                {
                    ((DataTable)ViewState["PERSONDETAILS"]).Rows.RemoveAt(e.RowIndex);
                    this.GVDETAILS.DataSource = ((DataTable)ViewState["PERSONDETAILS"]).DefaultView;
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

        protected void btnsave_Click(object sender, EventArgs e)
        {
           // string Quesstionriids = "1001";
            try
            {
                string result = "";
                ErrorMsg = validations();
                if (ErrorMsg == "")
                {
                    RenContractLabour ObjRenContractLic = new RenContractLabour();


                    int count = 0;
                    for (int i = 0; i < GVDETAILS.Rows.Count; i++)
                    {
                        ObjRenContractLic.Questionnariid = Convert.ToString(Session["RENQID"]);
                        ObjRenContractLic.CreatedBy = hdnUserID.Value;
                        ObjRenContractLic.UnitId = Convert.ToString(Session["RENUNITID"]);
                        ObjRenContractLic.IPAddress = getclientIP();
                        ObjRenContractLic.FULLTITLE = GVDETAILS.Rows[i].Cells[1].Text;
                        ObjRenContractLic.FULLNAME = GVDETAILS.Rows[i].Cells[2].Text;
                        ObjRenContractLic.FULLADDRESS = GVDETAILS.Rows[i].Cells[3].Text;



                        string A = objRenbal.InsertRenConLabourDetails(ObjRenContractLic);
                        if (A != "")
                        { count = count + 1; }
                    }
                    if (GVDETAILS.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = "Renewal Contract Labour Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }


                    ObjRenContractLic.Questionnariid = Convert.ToString(Session["RENQID"]);
                    ObjRenContractLic.CreatedBy = hdnUserID.Value;
                    ObjRenContractLic.UnitId = Convert.ToString(Session["RENUNITID"]);
                    ObjRenContractLic.IPAddress = getclientIP();

                    ObjRenContractLic.LICRENEWAL = txtLicNo.Text;
                    ObjRenContractLic.LICISSUEDATE = txtLicIssuedDate.Text;
                    ObjRenContractLic.LICRENEWALDATE = txtLicValidDate.Text;
                    ObjRenContractLic.TITLE = ddlTitle.SelectedItem.Text;
                    ObjRenContractLic.NAME = txtNames.Text;
                    ObjRenContractLic.EMAILID = txtEmailId.Text;
                    ObjRenContractLic.MOBILENO = txtMobileNo.Text;
                    ObjRenContractLic.FATHERNAME = txtFatherName.Text;
                    ObjRenContractLic.ESTNAME = txtEstName.Text;
                    ObjRenContractLic.DISTRIC = ddlDistrict.SelectedValue;
                    ObjRenContractLic.MANDAL = ddlMandal.SelectedValue;
                    ObjRenContractLic.VILLAGE = ddlVillage.SelectedValue;
                    ObjRenContractLic.LOCALITY = txtLocality.Text;
                    ObjRenContractLic.LANDMARK = txtLANDMARK.Text;
                    ObjRenContractLic.PINCODE = txtpincode.Text;
                    ObjRenContractLic.REGNUMBER = txtRegNo.Text;
                    ObjRenContractLic.REGDATE = txtRegDate.Text;
                    ObjRenContractLic.TYPEOFBUSINESS = txtBusiness.Text;
                    ObjRenContractLic.TITLE = ddltitleEMP.SelectedItem.Text;
                    ObjRenContractLic.EMPNAME = txtEMPNAME.Text;
                    ObjRenContractLic.NAME = txtName.Text;
                    ObjRenContractLic.ADDRESS = txtADDED.Text;
                    ObjRenContractLic.LABOUREMPEST = txtNatureLoc.Text;
                    ObjRenContractLic.NOOFDAYS = txtContractLabour.Text;
                    ObjRenContractLic.LABOURAPPROVED = txtApproved.Text;
                    ObjRenContractLic.MAXNOLABOUREMP = txtNoContract.Text;
                    ObjRenContractLic.WITHIN5YEARS = rblwithin5Year.SelectedValue;
                    ObjRenContractLic.DETAILS = txtDetails.Text;
                    ObjRenContractLic.REVOKINGLIC = rblRevoking.SelectedValue;
                    ObjRenContractLic.ORDERDATE = txtOrderDate.Text;
                    ObjRenContractLic.ESTWITHIN5YEAR = rblpast5year.SelectedValue;
                    ObjRenContractLic.ESTDETAILS = txtEstDetails.Text;
                    ObjRenContractLic.EMPDETAILS = txtEmpDetails.Text;
                    ObjRenContractLic.NATUREOFWORK = txtNature.Text;


                    result = objRenbal.InsertRENContractLabourDet(ObjRenContractLic);

                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "Renewal Contract Labour Details Submitted Successfully";
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



        public string validations()
        {
            try
            {
                int slno = 1;
                List<TextBox> emptyTextboxes = FindEmptyTextboxes(divText);
                List<DropDownList> emptyDropdowns = FindEmptyDropdowns(divText);
                List<RadioButtonList> emptyRadioButtonLists = FindEmptyRadioButtonLists(divText);
                string errormsg = "";
                if (string.IsNullOrEmpty(txtLicNo.Text) || txtLicNo.Text == "" || txtLicNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter License No Renewal Required\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLicIssuedDate.Text) || txtLicIssuedDate.Text == "" || txtLicIssuedDate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter License Issued Date\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLicValidDate.Text) || txtLicValidDate.Text == "" || txtLicValidDate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter License Renewal Valid Date\\n";
                    slno = slno + 1;
                }
                if (ddlTitle.SelectedIndex == -1 || ddlTitle.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Enter Title....!\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNames.Text) || txtNames.Text == "" || txtNames.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name...!\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEmailId.Text) || txtEmailId.Text == "" || txtEmailId.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter EmailId\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtMobileNo.Text) || txtMobileNo.Text == "" || txtMobileNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Mobile No....!\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtFatherName.Text) || txtFatherName.Text == "" || txtFatherName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter FatherName....!\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEstName.Text) || txtEstName.Text == "" || txtEstName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Establishment Name....!\\n";
                    slno = slno + 1;
                }
                if (ddlDistrict.SelectedIndex == -1 || ddlDistrict.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Distric\\n";
                    slno = slno + 1;
                }
                if (ddlMandal.SelectedIndex == -1 || ddlMandal.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Mandal\\n";
                    slno = slno + 1;
                }
                if (ddlVillage.SelectedIndex == -1 || ddlVillage.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Village\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLocality.Text) || txtLocality.Text == "" || txtLocality.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Locality....!\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLANDMARK.Text) || txtLANDMARK.Text == "" || txtLANDMARK.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter LandMark....!\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtpincode.Text) || txtpincode.Text == "" || txtpincode.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Pincode....!\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtRegNo.Text) || txtRegNo.Text == "" || txtRegNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Registration Number....!\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtRegDate.Text) || txtRegDate.Text == "" || txtRegDate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Registration Date....!\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtBusiness.Text) || txtBusiness.Text == "" || txtBusiness.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Type of Business, Trade, Industry, Manufacture....!\\n";
                    slno = slno + 1;
                }
                if (ddltitleEMP.SelectedIndex == -1 || ddltitleEMP.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Enter Title\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEMPNAME.Text) || txtEMPNAME.Text == "" || txtEMPNAME.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Employee Names....!\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtName.Text) || txtName.Text == "" || txtNames.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Names....!\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtADDED.Text) || txtADDED.Text == "" || txtADDED.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Address....!\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNatureLoc.Text) || txtNatureLoc.Text == "" || txtNatureLoc.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name, Nature and location of work in which contract labour Employee....!\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtContractLabour.Text) || txtContractLabour.Text == "" || txtContractLabour.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter No of days of contract labour....!\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtApproved.Text) || txtApproved.Text == "" || txtApproved.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Number of contract labour approved ....!\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNoContract.Text) || txtNoContract.Text == "" || txtNoContract.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Maximum number of contract labour proposed to be employed ....!\\n";
                    slno = slno + 1;
                }
                if (rblwithin5Year.SelectedIndex == -1 || rblwithin5Year.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Whether the contractor is convicted\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDetails.Text) || txtDetails.Text == "" || txtDetails.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Details ....!\\n";
                    slno = slno + 1;
                }
                if (rblRevoking.SelectedIndex == -1 || rblRevoking.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Whether there was any order against the contractor revoking \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtOrderDate.Text) || txtOrderDate.Text == "" || txtOrderDate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Order Date ....!\\n";
                    slno = slno + 1;
                }
                if (rblpast5year.SelectedIndex == -1 || rblpast5year.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Whether the contractor has work in any other establishment \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEstDetails.Text) || txtEstDetails.Text == "" || txtEstDetails.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Establishment's Details ....!\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEmpDetails.Text) || txtEmpDetails.Text == "" || txtEmpDetails.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Principal's Employers Details ....!\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNature.Text) || txtNature.Text == "" || txtNature.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Nature Of Work ....!\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(hypContractor.Text) || hypContractor.Text == "" || hypContractor.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Contractor's ....!\\n";
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
                ds = objRenbal.GetRenContractDetails(hdnUserID.Value, UnitID);
                if (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["UnitID"] = Convert.ToString(ds.Tables[0].Rows[0]["RENCLD_UNITID"]);
                        txtLicNo.Text = ds.Tables[0].Rows[0]["RENCLD_LICRENEWAL"].ToString();
                        txtLicIssuedDate.Text = ds.Tables[0].Rows[0]["RENCLD_LICISSUEDATE"].ToString();
                        txtLicValidDate.Text = ds.Tables[0].Rows[0]["RENCLD_LICRENEWALDATE"].ToString();
                        ddlTitle.SelectedItem.Text = ds.Tables[0].Rows[0]["RENCLD_TITLE"].ToString();
                        txtNames.Text = ds.Tables[0].Rows[0]["RENCLD_NAME"].ToString();
                        txtEmailId.Text = ds.Tables[0].Rows[0]["RENCLD_EMAILID"].ToString();
                        txtMobileNo.Text = ds.Tables[0].Rows[0]["RENCLD_MOBILENO"].ToString();
                        txtFatherName.Text = ds.Tables[0].Rows[0]["RENCLD_FATHERNAME"].ToString();
                        txtEstName.Text = ds.Tables[0].Rows[0]["RENCLD_ESTNAME"].ToString();
                        ddlDistrict.SelectedValue = ds.Tables[0].Rows[0]["RENCLD_DISTRIC"].ToString();
                        ddlDistrict_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlMandal.SelectedValue = ds.Tables[0].Rows[0]["RENCLD_MANDAL"].ToString();
                        ddlMandal_SelectedIndexChanged(null, EventArgs.Empty);
                        ddlVillage.SelectedValue = ds.Tables[0].Rows[0]["RENCLD_VILLAGE"].ToString();
                        txtLocality.Text = ds.Tables[0].Rows[0]["RENCLD_LOCALITY"].ToString();
                        txtLANDMARK.Text = ds.Tables[0].Rows[0]["RENCLD_LANDMARK"].ToString();
                        txtpincode.Text = ds.Tables[0].Rows[0]["RENCLD_PINCODE"].ToString();
                        txtRegNo.Text = ds.Tables[0].Rows[0]["RENCLD_REGNUMBER"].ToString();
                        txtRegDate.Text = ds.Tables[0].Rows[0]["RENCLD_REGDATE"].ToString();
                        txtBusiness.Text = ds.Tables[0].Rows[0]["RENCLD_TYPEOFBUSINESS"].ToString();
                        ddltitleEMP.SelectedItem.Text = ds.Tables[0].Rows[0]["RENCLD_TITLES"].ToString();
                        txtEMPNAME.Text = ds.Tables[0].Rows[0]["RENCLD_EMPNAME"].ToString();
                        txtName.Text = ds.Tables[0].Rows[0]["RENCLD_NAMES"].ToString();
                        txtADDED.Text = ds.Tables[0].Rows[0]["RENCLD_ADDRESS"].ToString();
                        txtNatureLoc.Text = ds.Tables[0].Rows[0]["RENCLD_LABOUREMPEST"].ToString();
                        txtContractLabour.Text = ds.Tables[0].Rows[0]["RENCLD_NOOFDAYS"].ToString();
                        txtApproved.Text = ds.Tables[0].Rows[0]["RENCLD_LABOURAPPROVED"].ToString();
                        txtNoContract.Text = ds.Tables[0].Rows[0]["RENCLD_MAXNOLABOUREMP"].ToString();
                        rblwithin5Year.SelectedValue = ds.Tables[0].Rows[0]["RENCLD_WITHIN5YEARS"].ToString();
                        if (rblwithin5Year.SelectedValue == "Y")
                        {
                            Details.Visible = true;
                            txtDetails.Text = ds.Tables[0].Rows[0]["RENCLD_DETAILS"].ToString();
                        }
                        else { Details.Visible = false; }
                       
                        rblRevoking.SelectedValue = ds.Tables[0].Rows[0]["RENCLD_REVOKINGLIC"].ToString();
                        if (rblRevoking.SelectedValue == "Y")
                        {
                            Orderdate.Visible = true;
                            txtOrderDate.Text = ds.Tables[0].Rows[0]["RENCLD_ORDERDATE"].ToString();
                        }
                        else { Orderdate.Visible = false; }
                       
                        rblpast5year.SelectedValue = ds.Tables[0].Rows[0]["RENCLD_ESTWITHIN5YEAR"].ToString();
                        if (rblpast5year.SelectedValue == "Y")
                        {
                            ESTdETAILS.Visible = true;
                            txtEstDetails.Text = ds.Tables[0].Rows[0]["RENCLD_ESTDETAILS"].ToString();
                            txtEmpDetails.Text = ds.Tables[0].Rows[0]["RENCLD_EMPDETAILS"].ToString();
                            txtNature.Text = ds.Tables[0].Rows[0]["RENCLD_NATUREOFWORK"].ToString();
                        }
                        else { ESTdETAILS.Visible = false; }
                       

                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        hdnUserID.Value = Convert.ToString(ds.Tables[1].Rows[0]["RENMD_RENQDID"]);
                        ViewState["PERSONDETAILS"]= ds.Tables[1];
                        GVDETAILS.DataSource = ds.Tables[1];
                        GVDETAILS.DataBind();
                        GVDETAILS.Visible = true;
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

        protected void btndpr_Click(object sender, EventArgs e)
        {
            try
            {

                string Error = ""; string message = "";
                if (fupContractor.HasFile)
                {
                    Error = validations(fupContractor);
                    if (Error == "")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["RENAttachments"];
                        string serverpath = sFileDir + hdnUserID.Value + "\\"
                         + Convert.ToString(Session["RENQID"]) + "\\" + "Upload Contractor's" + "\\";
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(serverpath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupContractor.PostedFile.SaveAs(serverpath + "\\" + fupContractor.PostedFile.FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(serverpath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupContractor.PostedFile.SaveAs(serverpath + "\\" + fupContractor.PostedFile.FileName);
                            }
                        }


                        RenAttachments objRenAttachments = new RenAttachments();
                        objRenAttachments.UNITID = Convert.ToString(Session["RENUNITID"]);
                        objRenAttachments.Questionnareid = Convert.ToString(Session["RENQID"]);
                        objRenAttachments.MasterID = "132";
                        objRenAttachments.FilePath = serverpath + fupContractor.PostedFile.FileName;
                        objRenAttachments.FileName = fupContractor.PostedFile.FileName;
                        objRenAttachments.FileType = fupContractor.PostedFile.ContentType;
                        objRenAttachments.FileDescription = "Upload Contractor's";
                        objRenAttachments.CreatedBy = hdnUserID.Value;
                        objRenAttachments.IPAddress = getclientIP();
                        result = objRenbal.InsertAttachmentsRenewal(objRenAttachments);
                        if (result != "")
                        {
                            hypContractor.Text = fupContractor.PostedFile.FileName;
                            hypContractor.NavigateUrl = "~/User/Dashboard/ServePdfFile.ashx?filePath=" + mstrBAL.EncryptFilePath(objRenAttachments.FilePath);
                            hypContractor.Target = "blank";
                            message = "alert('" + "Upload Contractor's Uploaded successfully" + "')";
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

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                btnsave_Click(sender, e);
                if (ErrorMsg == "")
                    Response.Redirect("~/User/Renewal/RENLegalmetrologyDetails.aspx?Next=" + "N");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void rblRevoking_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblRevoking.SelectedValue == "Y")
                {
                    Orderdate.Visible = true;
                }
                else { Orderdate.Visible = false; }
            }
            catch(Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblRevoking.BorderColor = System.Drawing.Color.White;
        }

        protected void rblpast5year_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblpast5year.SelectedValue == "Y")
                {
                    ESTdETAILS.Visible = true;
                }
                else { ESTdETAILS.Visible = false; }
            }
            catch(Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblpast5year.BorderColor = System.Drawing.Color.White;
        }

        protected void rblwithin5Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblwithin5Year.SelectedValue == "Y")
                {
                    Details.Visible = true;
                }
                else { Details.Visible = false; }
            }
            catch(Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblwithin5Year.BorderColor = System.Drawing.Color.White;
        }

        protected void btnPreviuos_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/Renewal/RENContractLabourDeatils.aspx?Previous=" + "P");
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

                if (i == 2 && fileType[i - 1].ToUpper().Trim() == "PDF")
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}