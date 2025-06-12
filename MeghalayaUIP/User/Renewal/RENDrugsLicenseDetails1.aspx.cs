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
    public partial class RENDrugsLicenseDetails1 : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        RenewalBAL objRenbal = new RenewalBAL();
        string ErrorMsg = "", Questionnaire;
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

                    if (Convert.ToString(Session["RENQID"]) != "")
                    {
                        Questionnaire = Convert.ToString(Session["RENQID"]);
                        if (!IsPostBack)
                        {
                            GetAppliedorNot();

                        }
                    }
                    else
                    {
                        string newurl = "~/User/Renewal/RENUserDashboard.aspx";
                        Response.Redirect(newurl);
                    }

                    Page.MaintainScrollPositionOnPostBack = true;
                    Failure.Visible = false;
                    success.Visible = false;
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
                DataSet ds = new DataSet();

                ds = objRenbal.GetRenAppliedApprovalID(hdnUserID.Value, Convert.ToString(Session["RENQID"]), "8", "63");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (Convert.ToString(ds.Tables[0].Rows[i]["RENDA_APPROVALID"]) == "63")
                        {
                            BindDistricts();
                            Binddata();
                        }
                    }
                }
                else
                {
                    if (Request.QueryString.Count > 0)
                    {
                        if (Convert.ToString(Request.QueryString[0]) == "N")
                            Response.Redirect("~/User/Renewal/RENDrugsLicenseDetails2.aspx?Next=" + "N");
                        else if (Convert.ToString(Request.QueryString[0]) == "P")
                            Response.Redirect("~/User/Renewal/RENDrugsLicenseDetails.aspx?Previous=" + "P");
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message; Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public void Binddata()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objRenbal.GetRenDrugLicDetails(hdnUserID.Value, Questionnaire,63);
                if (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0 || ds.Tables[2].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlservice.SelectedValue = ds.Tables[0].Rows[0]["RENDL_SERVICETO"].ToString();

                        rblLicense.SelectedValue = ds.Tables[0].Rows[0]["RENDL_SPECIFYAPPLICATION"].ToString();

                        if (rblLicense.SelectedValue == "R")
                        {
                            pnlLicenseDetails.Visible = true;
                            txtLicNo.Text = ds.Tables[0].Rows[0]["RENDL_LICNO"].ToString();
                            txtExpiryDate.Text = ds.Tables[0].Rows[0]["RENDL_EXPIRYDATE"].ToString();
                            rblCancelledLic.SelectedValue = ds.Tables[0].Rows[0]["RENDL_LICCANCEL"].ToString().Trim();


                            if (rblCancelledLic.SelectedValue == "Y")
                            {
                                LicNos.Visible = true;
                                txtSpecifyLicNo.Text = ds.Tables[0].Rows[0]["RENDL_SPECIFYLICNO"].ToString();
                            }
                            else { LicNos.Visible = false; }

                        }
                        else
                        {
                            pnlLicenseDetails.Visible = false;
                        }

                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        ViewState["NameDrug"] = ds.Tables[1];
                        GVDrugName.DataSource = ds.Tables[1];
                        GVDrugName.DataBind();
                        GVDrugName.Visible = true;
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        ViewState["StaffEmployed"] = ds.Tables[2];
                        GVSTAFF.DataSource = ds.Tables[2];
                        GVSTAFF.DataBind();
                        GVSTAFF.Visible = true;
                        
                    }
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        ViewState["TESTING"] = ds.Tables[3];
                        GVTEST.DataSource = ds.Tables[3];
                        GVTEST.DataBind();
                        GVTEST.Visible = true;
                    }
                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        ViewState["SpecifyAdditional"] = ds.Tables[4];
                        GVSpecify.DataSource = ds.Tables[4];
                        GVSpecify.DataBind();
                        GVSpecify.Visible = true;
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

        protected void rblLicense_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblLicense.SelectedValue == "R")
                {
                    pnlLicenseDetails.Visible = true;
                }
                else
                {
                    pnlLicenseDetails.Visible = false;
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
                ddlservice.Items.Clear();

                List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();

                objDistrictModel = mstrBAL.GetDistrcits();
                if (objDistrictModel != null)
                {
                    ddlservice.DataSource = objDistrictModel;
                    ddlservice.DataValueField = "DistrictId";
                    ddlservice.DataTextField = "DistrictName";
                    ddlservice.DataBind();
                }
                else
                {
                    ddlservice.DataSource = null;
                    ddlservice.DataBind();
                }
                AddSelect(ddlservice);
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

        protected void btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txttradeLic.Text.Trim()))
                {
                    lblmsg0.Text = "Please Enter All Details..!";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("REND_DRUGNAME", typeof(string));

                    if (ViewState["NameDrug"] != null)
                    {
                        dt = (DataTable)ViewState["NameDrug"];
                    }

                    DataRow dr = dt.NewRow();

                    dr["REND_DRUGNAME"] = txttradeLic.Text.Trim();

                    dt.Rows.Add(dr);
                    GVDrugName.Visible = true;
                    GVDrugName.DataSource = dt;
                    GVDrugName.DataBind();
                    ViewState["NameDrug"] = dt;


                    txttradeLic.Text = "";


                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnTesting_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtnames.Text.Trim()) || string.IsNullOrEmpty(txtqualifies.Text.Trim()) || string.IsNullOrEmpty(txtexpered.Text.Trim()))
                {
                    lblmsg0.Text = "Please Enter All Details..!";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("RENDM_NAME", typeof(string));
                    dt.Columns.Add("RENDM_QUALIFICATION", typeof(string));
                    dt.Columns.Add("RENDM_EXPERIENCE", typeof(string));

                    if (ViewState["TESTING"] != null)
                    {
                        dt = (DataTable)ViewState["TESTING"];
                    }

                    DataRow dr = dt.NewRow();

                    dr["RENDM_NAME"] = txtnames.Text;
                    dr["RENDM_QUALIFICATION"] = txtqualifies.Text;
                    dr["RENDM_EXPERIENCE"] = txtexpered.Text;

                    dt.Rows.Add(dr);
                    GVTEST.Visible = true;
                    GVTEST.DataSource = dt;
                    GVTEST.DataBind();
                    ViewState["TESTING"] = dt;


                    txtnames.Text = "";
                    txtqualifies.Text = "";
                    txtexpered.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtName.Text.Trim()) || string.IsNullOrEmpty(txtQualifications.Text.Trim()) || string.IsNullOrEmpty(txtExperiment.Text.Trim()))
                {
                    lblmsg0.Text = "Please Enter All Details..!";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("RENST_NAME", typeof(string));
                    dt.Columns.Add("RENST_QUALIFICATION", typeof(string));
                    dt.Columns.Add("RENST_EXPERIENCE", typeof(string));

                    if (ViewState["StaffEmployed"] != null)
                    {
                        dt = (DataTable)ViewState["StaffEmployed"];
                    }

                    DataRow dr = dt.NewRow();

                    dr["RENST_NAME"] = txtName.Text;
                    dr["RENST_QUALIFICATION"] = txtQualifications.Text;
                    dr["RENST_EXPERIENCE"] = txtExperiment.Text;

                    dt.Rows.Add(dr);
                    GVSTAFF.Visible = true;
                    GVSTAFF.DataSource = dt;
                    GVSTAFF.DataBind();
                    ViewState["StaffEmployed"] = dt;


                    txtName.Text = "";
                    txtQualifications.Text = "";
                    txtExperiment.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void btnspecify_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSpecify.Text.Trim()))
                {
                    lblmsg0.Text = "Please Enter All Details..!";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("RENDA_ADDITIONALITEM", typeof(string));

                    if (ViewState["SpecifyAdditional"] != null)
                    {
                        dt = (DataTable)ViewState["SpecifyAdditional"];
                    }

                    DataRow dr = dt.NewRow();

                    dr["RENDA_ADDITIONALITEM"] = txtSpecify.Text;

                    dt.Rows.Add(dr);
                    GVSpecify.Visible = true;
                    GVSpecify.DataSource = dt;
                    GVSpecify.DataBind();
                    ViewState["SpecifyAdditional"] = dt;


                    txtSpecify.Text = "";

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
            try
            {
                string result = "";
                ErrorMsg = validations();
                if (ErrorMsg == "")
                {
                    RenDrugLicDet ObjRenDrugLic = new RenDrugLicDet();

                    int count = 0, count1 = 0, count2 = 0, count3 = 0;
                    for (int i = 0; i < GVDrugName.Rows.Count; i++)
                    {
                        ObjRenDrugLic.Questionnariid = Convert.ToString(Session["RENQID"]);
                        ObjRenDrugLic.CreatedBy = hdnUserID.Value;
                        ObjRenDrugLic.IPAddress = getclientIP();
                        ObjRenDrugLic.NameDrug = GVDrugName.Rows[i].Cells[1].Text;
                        ObjRenDrugLic.ApprovalID = 63;

                        string A = objRenbal.InsertDrugDetails(ObjRenDrugLic);
                        if (A != "")
                        { count = count + 1; }
                    }
                    
                    for (int i = 0; i < GVTEST.Rows.Count; i++)
                    {
                        ObjRenDrugLic.Questionnariid = Convert.ToString(Session["RENQID"]);
                        ObjRenDrugLic.CreatedBy = hdnUserID.Value;
                        ObjRenDrugLic.IPAddress = getclientIP();
                        ObjRenDrugLic.Name = GVTEST.Rows[i].Cells[1].Text;
                        ObjRenDrugLic.Qualification = GVTEST.Rows[i].Cells[2].Text;
                        ObjRenDrugLic.Experience = GVTEST.Rows[i].Cells[3].Text;
                        ObjRenDrugLic.ApprovalID = 63;

                        string A = objRenbal.INSERTRENTestingDetails(ObjRenDrugLic);
                        if (A != "")
                        { count1 = count + 1; }
                    }
                    for (int i = 0; i < GVSTAFF.Rows.Count; i++)
                    {
                        ObjRenDrugLic.Questionnariid = Convert.ToString(Session["RENQID"]);
                        ObjRenDrugLic.CreatedBy = hdnUserID.Value;
                        ObjRenDrugLic.IPAddress = getclientIP();
                        ObjRenDrugLic.Name = GVSTAFF.Rows[i].Cells[1].Text;
                        ObjRenDrugLic.Qualification = GVSTAFF.Rows[i].Cells[2].Text;
                        ObjRenDrugLic.Experience = GVSTAFF.Rows[i].Cells[3].Text;
                        ObjRenDrugLic.ApprovalID = 63;

                        string A = objRenbal.InsertRENManufacture(ObjRenDrugLic);
                        if (A != "")
                        { count2 = count + 1; }
                    }
                    for (int i = 0; i < GVSpecify.Rows.Count; i++)
                    {
                        ObjRenDrugLic.Questionnariid = Convert.ToString(Session["RENQID"]);
                        ObjRenDrugLic.CreatedBy = hdnUserID.Value;
                        ObjRenDrugLic.IPAddress = getclientIP();
                        ObjRenDrugLic.Name = GVSpecify.Rows[i].Cells[1].Text;
                        ObjRenDrugLic.ApprovalID = 63;

                        string A = objRenbal.InsertRenDrugItemDet(ObjRenDrugLic);
                        if (A != "")
                        { count3 = count + 1; }
                    }



                    ObjRenDrugLic.Questionnariid = Convert.ToString(Session["RENQID"]);
                    ObjRenDrugLic.CreatedBy = hdnUserID.Value;
                    ObjRenDrugLic.IPAddress = getclientIP();

                    ObjRenDrugLic.ServiceApply = ddlservice.SelectedValue;
                    ObjRenDrugLic.ApplicationPurpose = rblLicense.SelectedValue;
                    ObjRenDrugLic.Licnumber = txtLicNo.Text;
                    ObjRenDrugLic.ExpiryDate = txtExpiryDate.Text;
                    ObjRenDrugLic.CancelledLic = rblCancelledLic.SelectedValue;
                    ObjRenDrugLic.SpecifyLicno = txtSpecifyLicNo.Text;
                    ObjRenDrugLic.ApprovalID = 63;

                    result = objRenbal.InsertRENDrugLicDetails(ObjRenDrugLic);

                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "Renewal DrugLicense Details Submitted Successfully";
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
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
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

        protected void rblCancelledLic_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblCancelledLic.SelectedValue == "Y")
                {
                    LicNos.Visible = true;
                }
                else
                {
                    LicNos.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void GVDrugName_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVDrugName.Rows.Count > 0)
                {
                    ((DataTable)ViewState["NameDrug"]).Rows.RemoveAt(e.RowIndex);
                    this.GVDrugName.DataSource = ((DataTable)ViewState["NameDrug"]).DefaultView;
                    this.GVDrugName.DataBind();
                    GVDrugName.Visible = true;
                    GVDrugName.Focus();

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

        protected void GVTEST_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVTEST.Rows.Count > 0)
                {
                    ((DataTable)ViewState["TESTING"]).Rows.RemoveAt(e.RowIndex);
                    this.GVTEST.DataSource = ((DataTable)ViewState["TESTING"]).DefaultView;
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void GVSTAFF_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVSTAFF.Rows.Count > 0)
                {
                    ((DataTable)ViewState["StaffEmployed"]).Rows.RemoveAt(e.RowIndex);
                    this.GVSTAFF.DataSource = ((DataTable)ViewState["StaffEmployed"]).DefaultView;
                    this.GVSTAFF.DataBind();
                    GVSTAFF.Visible = true;
                    GVSTAFF.Focus();

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

        protected void GVSpecify_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVSpecify.Rows.Count > 0)
                {
                    ((DataTable)ViewState["SpecifyAdditional"]).Rows.RemoveAt(e.RowIndex);
                    this.GVSpecify.DataSource = ((DataTable)ViewState["SpecifyAdditional"]).DefaultView;
                    this.GVSpecify.DataBind();
                    GVSpecify.Visible = true;
                    GVSpecify.Focus();

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

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                btnsave_Click(sender, e);
                if (ErrorMsg == "")
                    Response.Redirect("~/User/Renewal/RENDrugsLicenseDetails2.aspx?Next=" + "N");
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

        public string validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";

                if (ddlservice.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select Service Apply To \\n";
                    slno = slno + 1;
                }
                if (rblLicense.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please specify the purpose of application \\n";
                    slno = slno + 1;
                }
                if (rblLicense.SelectedValue == "R")
                {
                    if (string.IsNullOrEmpty(txtLicNo.Text) || txtLicNo.Text == "" || txtLicNo.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter License Number\\n";
                        slno = slno + 1;
                    }
                    if (string.IsNullOrEmpty(txtExpiryDate.Text) || txtExpiryDate.Text == "" || txtExpiryDate.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Expiry date of license\\n";
                        slno = slno + 1;
                    }
                    if (rblCancelledLic.SelectedIndex == -1)
                    {
                        errormsg = errormsg + slno + ". Please Select Do you hold any previous cancelled license? \\n";
                        slno = slno + 1;
                    }
                    if (rblCancelledLic.SelectedValue == "Y")
                    {
                        if (string.IsNullOrEmpty(txtSpecifyLicNo.Text) || txtSpecifyLicNo.Text == "" || txtSpecifyLicNo.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter specify license no\\n";
                            slno = slno + 1;
                        }
                    }
                }

                return errormsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}