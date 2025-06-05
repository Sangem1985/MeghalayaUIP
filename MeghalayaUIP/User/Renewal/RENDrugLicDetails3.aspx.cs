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
                     //   Questionnaire = Convert.ToString(Session["RENQID"]);
                        if (!IsPostBack)
                        {
                            // GetAppliedorNot();
                            BindDistricts();
                        }
                        //Binddata();
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
                if (rblCancelledLic.SelectedValue=="Y")
                {
                    LicNos.Visible = true;
                }
                else { LicNos.Visible = false; }
            }
            catch(Exception ex)
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
                    dt.Columns.Add("Specify", typeof(string));

                    if (ViewState["SpecifyAdditional"] != null)
                    {
                        dt = (DataTable)ViewState["SpecifyAdditional"];
                    }

                    DataRow dr = dt.NewRow();

                    dr["Specify"] = txtSpecify.Text;

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
    }
}