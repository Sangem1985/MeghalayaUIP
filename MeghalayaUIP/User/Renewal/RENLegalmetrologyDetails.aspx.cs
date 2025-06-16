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
    public partial class RENLegalmetrologyDetails : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        RenewalBAL objRenbal = new RenewalBAL();
        string Questionnaire, ErrorMsg = "";
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
                            Binddata();
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
                    //if (!IsPostBack)
                    //{
                    //    GetAppliedorNot();
                    //}
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

                ds = objRenbal.GetRenAppliedApprovalID(hdnUserID.Value, Convert.ToString(Session["RENQID"]), "11", "");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (Convert.ToString(ds.Tables[0].Rows[i]["RENDA_APPROVALID"]) == "74")
                        {
                            divdealer74.Visible = true;
                        }
                        if (Convert.ToString(ds.Tables[0].Rows[i]["RENDA_APPROVALID"]) == "75")
                        {
                            divRepair75.Visible = true;

                        }
                        if (Convert.ToString(ds.Tables[0].Rows[i]["RENDA_APPROVALID"]) == "76")
                        {
                            divManufacture76.Visible = true;
                            divManu.Visible = true;
                        }
                    }

                }
                else
                {
                    if (Request.QueryString.Count > 0)
                    {
                        if (Convert.ToString(Request.QueryString[0]) == "N")
                            Response.Redirect("~/User/Renewal/RENBusinessLicenseDetails.aspx?Next=" + "N");
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

        protected void btnsave_Click(object sender, EventArgs e)
        {

            try
            {
                string result = "";
                ErrorMsg = validations();
                if (ErrorMsg == "")
                {
                    RenLegalMetrology objRenLegal = new RenLegalMetrology();
                    objRenLegal.Questionnariid = Convert.ToString(Session["RENQID"]);
                    objRenLegal.CreatedBy = hdnUserID.Value;
                    //   objRenLegal.UnitId = Convert.ToString(Session["RENUNITID"]);
                    objRenLegal.IPAddress = getclientIP();

                    objRenLegal.LICNO = txtLicNo.Text;
                    objRenLegal.LicenseIssuedManufacture = txtLicIssedYear.Text;
                    objRenLegal.DLLicenseIssuedDate = txtLiceIssuedDate1.Text;
                    objRenLegal.DLDatelastrenewal = txtLicDateTo.Text;
                    objRenLegal.DLExpirydatelastrenewal = txtLicValiddate.Text;
                    objRenLegal.DLRenewedONE = rbdLicRenleast.SelectedValue;
                    objRenLegal.RPLicenseIssuedDate = txtLicissuedDate1.Text;
                    objRenLegal.RPDatelastrenewal = txtlastdate1.Text;
                    objRenLegal.RPExpirydatelastrenewal = txtExpireDate1.Text;
                    objRenLegal.RPRenewedONE = rbdRenLeast.SelectedValue;
                    objRenLegal.MLTYPLIC = txtTypeLic.Text;
                    objRenLegal.MLNAMELIC = txtNameLic.Text;
                    objRenLegal.MLExpirydateLIC = txtExpireLic.Text;
                    objRenLegal.MLDateRenewal = txtDateLastRen.Text;
                    objRenLegal.MLExpirydatelasteren = txtExpirDate.Text;
                    objRenLegal.MLRenewedYear = txtRenYear.Text;
                    objRenLegal.MLLegalIssued = txtLegalLic.Text;
                    objRenLegal.MLLICIssuedDate = txtLicissuedDate.Text;
                    objRenLegal.MLLicRenewedleast = rbdLicRen.SelectedValue;

                    result = objRenbal.InsertRENLegalMetrologyDetails(objRenLegal);

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
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        //protected List<TextBox> FindEmptyTextboxes(Control container)
        //{

        //    List<TextBox> emptyTextboxes = new List<TextBox>();
        //    foreach (Control control in container.Controls)
        //    {
        //        if (control is TextBox)
        //        {
        //            TextBox textbox = (TextBox)control;
        //            if (string.IsNullOrWhiteSpace(textbox.Text))
        //            {
        //                emptyTextboxes.Add(textbox);
        //                textbox.BorderColor = System.Drawing.Color.Red;
        //            }
        //        }

        //        if (control.HasControls())
        //        {
        //            emptyTextboxes.AddRange(FindEmptyTextboxes(control));
        //        }
        //    }
        //    return emptyTextboxes;
        //}
        public string validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                if (string.IsNullOrEmpty(txtLicNo.Text) || txtLicNo.Text == "" || txtLicNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter License Number\\n";
                    slno = slno + 1;
                }
                //if (string.IsNullOrEmpty(txtBoilerDet.Text) || txtBoilerDet.Text == "" || txtBoilerDet.Text == null)
                //{
                //    errormsg = errormsg + slno + ". Please Enter Total amount of fee to be paid for Auto Renewal...!\\n";
                //    slno = slno + 1;
                //}
                if (string.IsNullOrEmpty(txtLicDateTo.Text) || txtLicDateTo.Text == "" || txtLicDateTo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter License Renewed upto Date.....!\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtLicValiddate.Text) || txtLicValiddate.Text == "" || txtLicValiddate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter License Valid upto Date......!\\n";
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

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                btnsave_Click(sender, e);
                if (ErrorMsg == "")
                    Response.Redirect("~/User/Renewal/RENBusinessLicenseDetails.aspx?Next=" + "N");
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
                Response.Redirect("~/User/Renewal/RENContractLabourDeatils.aspx?Previous=" + "P");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        public void Binddata()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objRenbal.GetRenLegalmetrologyDetails(hdnUserID.Value, Questionnaire);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtLicNo.Text = ds.Tables[0].Rows[0]["REN_LICNO"].ToString();


                    txtLicIssedYear.Text = ds.Tables[0].Rows[0]["RENMF_LICISSUEDYEAR"].ToString();
                    txtLiceIssuedDate1.Text = ds.Tables[0].Rows[0]["RENDL_LICENSEISSUEDATE"].ToString();
                    txtLicDateTo.Text = ds.Tables[0].Rows[0]["RENDL_DATELASTRENEWAL"].ToString();
                    txtLicValiddate.Text = ds.Tables[0].Rows[0]["RENDL_EXPIREDATELASTRENEWAL"].ToString();
                    rbdLicRenleast.Text = ds.Tables[0].Rows[0]["RENDL_LICNSERENEWED"].ToString();
                    txtLicissuedDate1.Text = ds.Tables[0].Rows[0]["RENRP_LICENSEISSUEDATE"].ToString();
                    txtlastdate1.Text = ds.Tables[0].Rows[0]["RENRP_DATELASTRENEWAL"].ToString();
                    txtExpireDate1.Text = ds.Tables[0].Rows[0]["RENRP_EXPIREDATELASTRENEWAL"].ToString();
                    rbdRenLeast.Text = ds.Tables[0].Rows[0]["RENRP_LICNSERENEWED"].ToString();
                    txtTypeLic.Text = ds.Tables[0].Rows[0]["RENLM_TYPELIC"].ToString();
                    txtNameLic.Text = ds.Tables[0].Rows[0]["RENLM_LICNAME"].ToString();
                    txtExpireLic.Text = ds.Tables[0].Rows[0]["RENLM_EXPIREDATELIC"].ToString();
                    txtDateLastRen.Text = ds.Tables[0].Rows[0]["RENLM_LASTRENDATE"].ToString();
                    txtExpirDate.Text = ds.Tables[0].Rows[0]["RENLM_EXPIREDATELASTRENEWAL"].ToString();
                    txtRenYear.Text = ds.Tables[0].Rows[0]["RENLM_RENEWEDYEAR"].ToString();
                    txtLegalLic.Text = ds.Tables[0].Rows[0]["RENLM_LEGALISSUEDLIC"].ToString();
                    txtLicissuedDate.Text = ds.Tables[0].Rows[0]["RENLM_LICISSUEDDATE"].ToString();
                    rbdLicRen.Text = ds.Tables[0].Rows[0]["RENLM_LICNSERENEWED"].ToString();

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