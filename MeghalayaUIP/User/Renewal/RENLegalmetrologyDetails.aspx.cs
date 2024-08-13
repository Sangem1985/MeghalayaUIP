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
        string UnitID, ErrorMsg = "";
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
                throw ex;
            }
        }
        protected void GetAppliedorNot()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = objRenbal.GetRenAppliedApprovalID(hdnUserID.Value, Convert.ToString(Session["RENUNITID"]), Convert.ToString(Session["RENQID"]), "11", "");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(ds.Tables[0].Rows[0]["RENDA_APPROVALID"]) == "76")
                    {
                        Binddata();
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
                lblmsg0.Text = ex.Message; Failure.Visible = true;
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
          //  string Questionnariid = "1001";
            try
            {
                string result = "";
                ErrorMsg = validations();
                if (ErrorMsg == "")
                {
                    RenLegalMetrology objRenLegal = new RenLegalMetrology();
                    objRenLegal.Questionnariid = Convert.ToString(Session["RENQID"]);
                    objRenLegal.CreatedBy = hdnUserID.Value;
                    objRenLegal.UnitId = Convert.ToString(Session["RENUNITID"]);
                    objRenLegal.IPAddress = getclientIP();

                    objRenLegal.LICNO = txtLicNo.Text;
                    objRenLegal.AUTORENEWAL = txtBoilerDet.Text;
                    objRenLegal.RENEWEDDATE = txtLicDateTo.Text;
                    objRenLegal.LICVALIDDATE = txtLicValiddate.Text;

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
            catch(Exception ex)
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
                    errormsg = errormsg + slno + ". Please Enter License Number\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtBoilerDet.Text) || txtBoilerDet.Text == "" || txtBoilerDet.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Total amount of fee to be paid for Auto Renewal...!\\n";
                    slno = slno + 1;
                }
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
                ds = objRenbal.GetRenLegalmetrologyDetails(hdnUserID.Value, UnitID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["UnitID"] = Convert.ToString(ds.Tables[0].Rows[0]["RENLM_UNITID"]);
                    txtLicNo.Text = ds.Tables[0].Rows[0]["RENLM_LICNO"].ToString();
                    txtBoilerDet.Text = ds.Tables[0].Rows[0]["RENLM_AUTORENEWAL"].ToString();
                    txtLicDateTo.Text = ds.Tables[0].Rows[0]["RENLM_RENEWEDDATE"].ToString();
                    txtLicValiddate.Text = ds.Tables[0].Rows[0]["RENLM_LICVALIDDATE"].ToString();
                   
                   
                   

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}