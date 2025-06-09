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
    public partial class RENDrugLicDetails1 : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        RenewalBAL objRenbal = new RenewalBAL();
        string ErrorMsg = "", Questionnaire;
        RenDrugLicDet ObjRenDrugLic = new RenDrugLicDet();
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
                            BindDistricts();
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

                ds = objRenbal.GetRenAppliedApprovalID(hdnUserID.Value, Convert.ToString(Session["RENQID"]), "8", "62");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(ds.Tables[0].Rows[0]["RENDA_APPROVALID"]) == "62")
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
                            Response.Redirect("~/User/Renewal/RENDrugLicDetails2.aspx?Next=" + "N");
                        else if (Convert.ToString(Request.QueryString[0]) == "P")
                            Response.Redirect("~/User/Renewal/RenewalServices.aspx?Previous=" + "P");
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
                ds = objRenbal.GetRenDrugLicDetails(hdnUserID.Value, Questionnaire);
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
                        ViewState["NameDrug"] = ds.Tables[1];
                        GVDrugName.DataSource = ds.Tables[1];
                        GVDrugName.DataBind();
                        GVDrugName.Visible = true;
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        ViewState["TESTING"] = ds.Tables[2];
                        GVTEST.DataSource = ds.Tables[2];
                        GVTEST.DataBind();
                        GVTEST.Visible = true;
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
                    //dt.Columns.Add("RENQID", typeof(string));
                    //dt.Columns.Add("REND_CREATEDBY", typeof(string));
                    //dt.Columns.Add("REND_CREATEDBYIP", typeof(string));
                    dt.Columns.Add("REND_DRUGNAME", typeof(string));




                    if (ViewState["NameDrug"] != null)
                    {
                        dt = (DataTable)ViewState["NameDrug"];
                    }

                    DataRow dr = dt.NewRow();
                    //dr["RENQID"] = Convert.ToString(ViewState["RENQID"]);
                    //dr["REND_CREATEDBY"] = hdnUserID.Value;
                    //dr["REND_CREATEDBYIP"] = getclientIP();
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
                    dt.Columns.Add("RENST_NAME", typeof(string));
                    dt.Columns.Add("RENST_QUALIFICATION", typeof(string));
                    dt.Columns.Add("RENST_EXPERIENCE", typeof(string));

                    if (ViewState["TESTING"] != null)
                    {
                        dt = (DataTable)ViewState["TESTING"];
                    }

                    DataRow dr = dt.NewRow();                 
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

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                ErrorMsg = validations();
                if (ErrorMsg == "")
                {

                    int count = 0, count1 = 0;
                    for (int i = 0; i < GVDrugName.Rows.Count; i++)
                    {
                        ObjRenDrugLic.Questionnariid = Convert.ToString(Session["RENQID"]);
                        ObjRenDrugLic.CreatedBy = hdnUserID.Value;
                        ObjRenDrugLic.IPAddress = getclientIP();
                        ObjRenDrugLic.NameDrug = GVDrugName.Rows[i].Cells[1].Text;


                        string A = objRenbal.InsertDrugDetails(ObjRenDrugLic);
                        if (A != "")
                        { count = count + 1; }
                    }
                    if (GVDrugName.Rows.Count == count)
                    {
                        success.Visible = true;
                        lblmsg.Text = "Renewal Drug Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }

                    for (int i = 0; i < GVTEST.Rows.Count; i++)
                    {
                        ObjRenDrugLic.Questionnariid = Convert.ToString(Session["RENQID"]);
                        ObjRenDrugLic.CreatedBy = hdnUserID.Value;
                        ObjRenDrugLic.IPAddress = getclientIP();
                        ObjRenDrugLic.Name = GVTEST.Rows[i].Cells[1].Text;
                        ObjRenDrugLic.Qualification = GVTEST.Rows[i].Cells[2].Text;
                        ObjRenDrugLic.Experience = GVTEST.Rows[i].Cells[3].Text;


                        string A = objRenbal.INSERTRENTestingDetails(ObjRenDrugLic);
                        if (A != "")
                        { count1 = count + 1; }
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
                    ObjRenDrugLic.PremiseInspection = rblInspection.SelectedValue;
                    ObjRenDrugLic.DateInspection = txtDateInsp.Text;


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
                else
                {
                    DateInsp.Visible = false;
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

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                btnsave_Click(sender, e);
                if (ErrorMsg == "")
                    Response.Redirect("~/User/Renewal/RENDrugLicDetails2.aspx?Next=" + "N");
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
                Response.Redirect("~/User/Renewal/RenewalServices.aspx?Previous=" + "P");
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
                if (rblInspection.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Select premise and plan ready for inspection? \\n";
                    slno = slno + 1;
                }
                if (rblInspection.SelectedValue == "Y")
                {
                    if (string.IsNullOrEmpty(txtDateInsp.Text) || txtDateInsp.Text == "" || txtDateInsp.Text == null)
                    {
                        errormsg = errormsg + slno + ". Please Enter Date for Inspection \\n";
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

    }
}