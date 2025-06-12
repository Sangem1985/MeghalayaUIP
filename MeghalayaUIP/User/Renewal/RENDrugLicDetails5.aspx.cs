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
    public partial class RENDrugLicDetails3 : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        RenewalBAL objRenbal = new RenewalBAL();
        string ErrorMsg = "", Questionnaire = "";
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

                ds = objRenbal.GetRenAppliedApprovalID(hdnUserID.Value, Convert.ToString(Session["RENQID"]), "8", "66");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (Convert.ToString(ds.Tables[0].Rows[i]["RENDA_APPROVALID"]) == "66")
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
                            Response.Redirect("~/User/Renewal/RENDrugLicDetails4.aspx?Next=" + "N");
                        else if (Convert.ToString(Request.QueryString[0]) == "P")
                            Response.Redirect("~/User/Renewal/RENDrugLicDetails65.aspx?Previous=" + "P");
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
                ds = objRenbal.GetRenDrugLicDetails3(hdnUserID.Value, Questionnaire);
                if (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0 || ds.Tables[2].Rows.Count > 0 || ds.Tables[3].Rows.Count > 0 || ds.Tables[4].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //  ViewState["UnitID"] = Convert.ToString(ds.Tables[0].Rows[0]["RENDL_UNITID"]);
                        ddlservice.SelectedValue = ds.Tables[0].Rows[0]["RENDL_SERVICETO"].ToString();
                        rblLicense.SelectedValue = ds.Tables[0].Rows[0]["RENDL_SPECIFYAPPLICATION"].ToString();

                        if (rblLicense.SelectedValue == "R")
                        {
                            divLicNo.Visible = true;
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



                        rblInspection.SelectedValue = ds.Tables[0].Rows[0]["RENDL_PREMISEINSPECTION"].ToString();
                        if (rblInspection.SelectedValue == "Y")
                        {
                            DateInsp.Visible = true;
                            txtDateInsp.Text = ds.Tables[0].Rows[0]["RENDL_INSPECTIONDATE"].ToString();
                        }
                        else { DateInsp.Visible = false; }


                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        //hdnUserID.Value = Convert.ToString(ds.Tables[1].Rows[0]["REND_CFOQDID"]);
                        ViewState["NameDrug"] = ds.Tables[1];
                        GVDrugName.DataSource = ds.Tables[1];
                        GVDrugName.DataBind();
                        GVDrugName.Visible = true;
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        //hdnUserID.Value = Convert.ToString(ds.Tables[2].Rows[0]["RENSTCFOQDID"]);
                        ViewState["TESTING"] = ds.Tables[2];
                        GVTEST.DataSource = ds.Tables[2];
                        GVTEST.DataBind();
                        GVTEST.Visible = true;
                    }
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        // hdnUserID.Value = Convert.ToString(ds.Tables[3].Rows[0]["RENDMCFOQDID"]);
                        ViewState["STAFF"] = ds.Tables[3];
                        GVSTAFF.DataSource = ds.Tables[3];
                        GVSTAFF.DataBind();
                        GVSTAFF.Visible = true;
                    }
                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        // hdnUserID.Value = Convert.ToString(ds.Tables[4].Rows[0]["RENDA_CFOQDID"]);
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
                    divLicNo.Visible = true;
                    divExpireDate.Visible = true;
                    divCancelLic.Visible = true;
                }
                else
                {
                    divLicNo.Visible = false;
                    divExpireDate.Visible = false;
                    divCancelLic.Visible = false;

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

        protected void btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txttradeLic.Text))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("RENQID", typeof(string));
                    dt.Columns.Add("REND_CREATEDBY", typeof(string));
                    dt.Columns.Add("REND_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("REND_DRUGNAME", typeof(string));




                    if (ViewState["NameDrug"] != null)
                    {
                        dt = (DataTable)ViewState["NameDrug"];
                    }

                    DataRow dr = dt.NewRow();
                    dr["RENQID"] = Convert.ToString(ViewState["RENQID"]);
                    dr["REND_CREATEDBY"] = hdnUserID.Value;
                    dr["REND_CREATEDBYIP"] = getclientIP();
                    dr["REND_DRUGNAME"] = txttradeLic.Text;



                    dt.Rows.Add(dr);
                    GVDrugName.Visible = true;
                    GVDrugName.DataSource = dt;
                    GVDrugName.DataBind();
                    ViewState["NameDrug"] = dt;
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
                if (string.IsNullOrEmpty(txtnames.Text) || string.IsNullOrEmpty(txtqualifies.Text) || string.IsNullOrEmpty(txtexpered.Text))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("RENQID", typeof(string));
                    dt.Columns.Add("RENST_CREATEDBY", typeof(string));
                    dt.Columns.Add("RENST_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("RENST_NAME", typeof(string));
                    dt.Columns.Add("RENST_QUALIFICATION", typeof(string));
                    dt.Columns.Add("RENST_EXPERIENCE", typeof(string));

                    if (ViewState["TESTING"] != null)
                    {
                        dt = (DataTable)ViewState["TESTING"];
                    }

                    DataRow dr = dt.NewRow();
                    dr["RENQID"] = Convert.ToString(ViewState["RENQID"]);
                    dr["RENST_CREATEDBY"] = hdnUserID.Value;
                    dr["RENST_CREATEDBYIP"] = getclientIP();
                    dr["RENST_NAME"] = txtnames.Text;
                    dr["RENST_QUALIFICATION"] = txtqualifies.Text;
                    dr["RENST_EXPERIENCE"] = txtexpered.Text;

                    dt.Rows.Add(dr);
                    GVTEST.Visible = true;
                    GVTEST.DataSource = dt;
                    GVTEST.DataBind();
                    ViewState["TESTING"] = dt;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void rblCancelledLic_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblCancelledLic.SelectedValue == "Y")
                {
                    LicNos.Visible = true;
                }
                else { LicNos.Visible = false; }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void rblInspection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblInspection.SelectedValue == "Y")
                {
                    DateInsp.Visible = true;
                }
                else { DateInsp.Visible = false; }
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
                    dt.Columns.Add("RENQID", typeof(string));
                    dt.Columns.Add("RENDA_CREATEDBY", typeof(string));
                    dt.Columns.Add("RENDA_CREATEDBYIP", typeof(string));
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
                    dt.Columns.Add("NAME", typeof(string));
                    dt.Columns.Add("QUALIFICATION", typeof(string));
                    dt.Columns.Add("EXPERIENCE", typeof(string));

                    if (ViewState["StaffEmployed"] != null)
                    {
                        dt = (DataTable)ViewState["StaffEmployed"];
                    }

                    DataRow dr = dt.NewRow();

                    dr["NAME"] = txtName.Text;
                    dr["QUALIFICATION"] = txtQualifications.Text;
                    dr["EXPERIENCE"] = txtExperiment.Text;

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

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                ErrorMsg = validations();
                if (ErrorMsg == "")
                {
                    RenDrugLicDet ObjRenDrug3 = new RenDrugLicDet();

                    int count = 0, count1 = 0, count2 = 0, count3 = 0;
                    for (int i = 0; i < GVDrugName.Rows.Count; i++)
                    {
                        ObjRenDrug3.Questionnariid = Convert.ToString(Session["RENQID"]);
                        ObjRenDrug3.CreatedBy = hdnUserID.Value;
                        //   ObjRenDrugLic3.UnitId = Convert.ToString(Session["RENUNITID"]);
                        ObjRenDrug3.IPAddress = getclientIP();
                        ObjRenDrug3.NameDrug = GVDrugName.Rows[i].Cells[1].Text;

                        string A = objRenbal.InsertDrugDetails(ObjRenDrug3);
                        if (A != "")
                        { count = count + 1; }
                    }
                  
                    for (int i = 0; i < GVTEST.Rows.Count; i++)
                    {
                        ObjRenDrug3.Questionnariid = Convert.ToString(Session["RENQID"]);
                        ObjRenDrug3.CreatedBy = hdnUserID.Value;
                        // ObjRenDrugLic.UnitId = Convert.ToString(Session["RENUNITID"]);
                        ObjRenDrug3.IPAddress = getclientIP();
                        ObjRenDrug3.Name = GVTEST.Rows[i].Cells[1].Text;
                        ObjRenDrug3.Qualification = GVTEST.Rows[i].Cells[2].Text;
                        ObjRenDrug3.Experience = GVTEST.Rows[i].Cells[3].Text;


                        string A = objRenbal.INSERTRENTestingDetails(ObjRenDrug3);
                        if (A != "")
                        { count1 = count + 1; }
                    }
                  
                    for (int i = 0; i < GVSTAFF.Rows.Count; i++)
                    {
                        ObjRenDrug3.Questionnariid = Convert.ToString(Session["RENQID"]);
                        ObjRenDrug3.CreatedBy = hdnUserID.Value;
                        //ObjRenDrugLic.UnitId = Convert.ToString(Session["RENUNITID"]);
                        ObjRenDrug3.IPAddress = getclientIP();
                        ObjRenDrug3.NameManu = GVSTAFF.Rows[i].Cells[1].Text;
                        ObjRenDrug3.QualificationManu = GVSTAFF.Rows[i].Cells[2].Text;
                        ObjRenDrug3.ExperienceManu = GVSTAFF.Rows[i].Cells[3].Text;



                        string A = objRenbal.InsertRENManufacture(ObjRenDrug3);
                        if (A != "")
                        { count2 = count + 1; }
                    }
                  

                    for (int i = 0; i < GVSpecify.Rows.Count; i++)
                    {
                        ObjRenDrug3.Questionnariid = Convert.ToString(Session["RENQID"]);
                        ObjRenDrug3.CreatedBy = hdnUserID.Value;
                        ObjRenDrug3.IPAddress = getclientIP();
                        ObjRenDrug3.AdditionalItem = GVSpecify.Rows[i].Cells[1].Text;

                        string A = objRenbal.InsertRenDrugItemDet(ObjRenDrug3);
                        if (A != "")
                        { count3 = count + 1; }
                    }
                  

                    ObjRenDrug3.Questionnariid = Convert.ToString(Session["RENQID"]);
                    ObjRenDrug3.CreatedBy = hdnUserID.Value;
                    ObjRenDrug3.IPAddress = getclientIP();
                    ObjRenDrug3.Serviceto = ddlservice.SelectedValue;
                    ObjRenDrug3.Licnumber = txtLicNo.Text;
                    ObjRenDrug3.ExpiryDate = txtExpiryDate.Text;
                    ObjRenDrug3.CancelledLic = rblCancelledLic.SelectedValue;
                    ObjRenDrug3.ApplicationPurpose = rblLicense.SelectedValue;
                    ObjRenDrug3.SpecifyLicno = txtSpecifyLicNo.Text;
                    ObjRenDrug3.PremiseInspection = rblInspection.SelectedValue;
                    ObjRenDrug3.DateInspection = txtDateInsp.Text;
                 

                    result = objRenbal.InsertRENDrugLicDetails3(ObjRenDrug3);

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

        protected void btnStaff_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtnames.Text) || string.IsNullOrEmpty(txtqualifies.Text) || string.IsNullOrEmpty(txtexpered.Text))
                {
                    lblmsg0.Text = "Please Enter All Details";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("RENQID", typeof(string));
                    dt.Columns.Add("RENDM_CREATEDBY", typeof(string));
                    dt.Columns.Add("RENDM_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("RENDM_NAME", typeof(string));
                    dt.Columns.Add("RENDM_QUALIFICATION", typeof(string));
                    dt.Columns.Add("RENDM_EXPERIENCE", typeof(string));

                    if (ViewState["STAFF"] != null)
                    {
                        dt = (DataTable)ViewState["STAFF"];
                    }

                    DataRow dr = dt.NewRow();
                    dr["RENQID"] = Convert.ToString(ViewState["RENQID"]);
                    dr["RENDM_CREATEDBY"] = hdnUserID.Value;
                    dr["RENDM_CREATEDBYIP"] = getclientIP();
                    dr["RENDM_NAME"] = txtName.Text;
                    dr["RENDM_QUALIFICATION"] = txtQualifications.Text;
                    dr["RENDM_EXPERIENCE"] = txtExperiment.Text;

                    dt.Rows.Add(dr);
                    GVSTAFF.Visible = true;
                    GVSTAFF.DataSource = dt;
                    GVSTAFF.DataBind();
                    ViewState["STAFF"] = dt;
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
                    ((DataTable)ViewState["STAFF"]).Rows.RemoveAt(e.RowIndex);
                    this.GVSTAFF.DataSource = ((DataTable)ViewState["STAFF"]).DefaultView;
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

        protected void btnPreviuos_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/Renewal/RENDrugLicDetails65.aspx?Previous=" + "P");
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
                    Response.Redirect("~/User/Renewal/RENDrugLicDetails4.aspx?Next=" + "N");
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


                if (rblLicense.SelectedValue == "Y")
                {
                    if (string.IsNullOrEmpty(txtDateInsp.Text) || txtDateInsp.Text == "" || txtDateInsp.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Date for Inspection\\n";
                        slno = slno + 1;
                    }
                }

                if (rblInspection.SelectedIndex == -1 || rblInspection.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select premise and plan ready for inspection \\n";
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
                        errormsg = errormsg + slno + ". Please Select previous cancelled license? \\n";
                        slno = slno + 1;
                    }
                    if (rblCancelledLic.SelectedValue == "Y")
                    {
                        if (string.IsNullOrEmpty(txtSpecifyLicNo.Text) || txtSpecifyLicNo.Text == "" || txtSpecifyLicNo.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please Enter specify license no\\n";
                            slno = slno + 1;
                        }
                        if (string.IsNullOrEmpty(txtSpecifyLicNo.Text) || txtSpecifyLicNo.Text == "" || txtSpecifyLicNo.Text == null)
                        {
                            errormsg = errormsg + slno + ". Please enter license no\\n";
                            slno = slno + 1;
                        }

                    }


                }
                if (GVDrugName.Rows.Count == 0)
                {
                    errormsg = errormsg + slno + ". Please enter drug name \\n";
                    slno = slno + 1;
                }
                if (GVTEST.Rows.Count == 0)
                {
                    errormsg = errormsg + slno + ". Please enter Test name \\n";
                    slno = slno + 1;
                }
                if (GVSTAFF.Rows.Count == 0)
                {
                    errormsg = errormsg + slno + ". Please enter Staff name \\n";
                    slno = slno + 1;
                }
                if (GVSpecify.Rows.Count == 0)
                {
                    errormsg = errormsg + slno + ". Please enter specify name \\n";
                    slno = slno + 1;
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