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
    public partial class RENDrugsLicenseDetails3 : System.Web.UI.Page
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

                ds = objRenbal.GetRenAppliedApprovalID(hdnUserID.Value, Convert.ToString(Session["RENQID"]), "8", "65");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (Convert.ToString(ds.Tables[0].Rows[i]["RENDA_APPROVALID"]) == "65")
                        {
                            divTestAnalysis65.Visible = true;
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
                            Response.Redirect("~/User/Renewal/RENDrugsLicenseDetails4.aspx?Next=" + "N");
                        else if (Convert.ToString(Request.QueryString[0]) == "P")
                            Response.Redirect("~/User/Renewal/RENDrugsLicenseDetails2.aspx?Previous=" + "P");
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
                ds = objRenbal.GetRenDrugLicDetails(hdnUserID.Value, Questionnaire,65);
                if (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0)
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
                                txtSpecifyLicNo.Text = ds.Tables[0].Rows[0]["RENDL_LICNOSPECIFY"].ToString();
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
                        ViewState["DRUGES"] = ds.Tables[1];
                        GVDruges.DataSource = ds.Tables[1];
                        GVDruges.DataBind();
                        GVDruges.Visible = true;
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
        protected void btnDrugName_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDrugName.Text.Trim()))
                {
                    lblmsg0.Text = "Please Enter All Details..!";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("REND_DRUGNAME", typeof(string));

                    if (ViewState["DRUGES"] != null)
                    {
                        dt = (DataTable)ViewState["DRUGES"];
                    }

                    DataRow dr = dt.NewRow();

                    dr["REND_DRUGNAME"] = txtDrugName.Text.Trim();

                    dt.Rows.Add(dr);
                    GVDruges.Visible = true;
                    GVDruges.DataSource = dt;
                    GVDruges.DataBind();
                    ViewState["DRUGES"] = dt;

                    txtDrugName.Text = "";
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

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                ErrorMsg = validations();
                if (ErrorMsg == "")
                {
                    RenDrugLicDet ObjRenDrugLic = new RenDrugLicDet();

                    int count = 0;
                    for (int i = 0; i < GVDruges.Rows.Count; i++)
                    {
                        ObjRenDrugLic.Questionnariid = Convert.ToString(Session["RENQID"]);
                        ObjRenDrugLic.CreatedBy = hdnUserID.Value;
                        ObjRenDrugLic.IPAddress = getclientIP();
                        ObjRenDrugLic.NameDrug = GVDruges.Rows[i].Cells[1].Text;
                        ObjRenDrugLic.ApprovalID = 65;

                        string A = objRenbal.InsertDrugDetails(ObjRenDrugLic);
                        if (A != "")
                        { count = count + 1; }
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
                    ObjRenDrugLic.ApprovalID = 65;

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

        protected void GVDruges_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVDruges.Rows.Count > 0)
                {
                    ((DataTable)ViewState["DRUGES"]).Rows.RemoveAt(e.RowIndex);
                    this.GVDruges.DataSource = ((DataTable)ViewState["DRUGES"]).DefaultView;
                    this.GVDruges.DataBind();
                    GVDruges.Visible = true;
                    GVDruges.Focus();

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
                Response.Redirect("~/User/Renewal/RENDrugsLicenseDetails2.aspx?Previous=" + "P");
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
                    Response.Redirect("~/User/Renewal/RENDrugsLicenseDetails4.aspx?Next=" + "N");
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
    }
}