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
    public partial class RENContractRegistationDetails : System.Web.UI.Page
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
                    //Session["RENWC_UNITID"] = "1001";
                    //UnitID = Convert.ToString(Session["RENWC_UNITID"]);

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

                ds = objRenbal.GetRenAppliedApprovalID(hdnUserID.Value, Convert.ToString(Session["RENQID"]), "16", "");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(ds.Tables[0].Rows[0]["RENDA_APPROVALID"]) == "79")
                    {
                        BindStates();
                        BindCaste();
                        Binddata();
                    }
                }
                else
                {
                    if (Request.QueryString.Count > 0)
                    {
                        if (Convert.ToString(Request.QueryString[0]) == "N")
                            Response.Redirect("~/User/Renewal/RENPaymentPage.aspx?Next=" + "N");
                        else if (Convert.ToString(Request.QueryString[0]) == "P")
                            Response.Redirect("~/User/Renewal/RENCinemaLicenseDetails.aspx?Previous=" + "P");
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
        protected void rblApplicant_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                if (rblApplicant.SelectedValue == "Y")
                {
                    ApplicantName.Visible = true;
                    social.Visible = true;
                    PowerAttorney.Visible = false;
                }
                else
                {
                    PowerAttorney.Visible = true;
                    social.Visible = false;
                    ApplicantName.Visible = false;
                }
            }
            catch(Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblApplicant.BorderColor = System.Drawing.Color.White;
        }

        protected void rblRegister_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                if (rblRegister.SelectedValue == "1")
                {
                    director.Visible = true;
                    applicant.Visible = true;
                    circle.Visible = false;
                    division.Visible = false;
                }
                else if (rblRegister.SelectedValue == "2")
                {
                    applicant.Visible = true;
                    director.Visible = true;
                    circle.Visible = true;
                    division.Visible = false;
                }
                else if (rblRegister.SelectedValue == "3")
                {
                    applicant.Visible = true;
                    director.Visible = true;
                    circle.Visible = true;
                    division.Visible = true;
                }
            }
            catch(Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
            rblRegister.BorderColor = System.Drawing.Color.White;
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
          //  string Quesstionriids = "1001";
            try
            {
                string result = "";
                ErrorMsg = Stepvalidations();
                if (ErrorMsg == "")
                {
                    RenPublicWorK ObjRenPublicWork = new RenPublicWorK();

                    ObjRenPublicWork.Questionnariid = Convert.ToString(Session["RENQID"]);
                    ObjRenPublicWork.CreatedBy = hdnUserID.Value;
                    ObjRenPublicWork.UnitId = Convert.ToString(Session["RENUNITID"]);
                    ObjRenPublicWork.IPAddress = getclientIP();

                    ObjRenPublicWork.ApplicantType = rblApplication.SelectedValue;
                    ObjRenPublicWork.PurposeApplicant = rblPurApplication.SelectedValue;
                    ObjRenPublicWork.ContractorReg = rblRegister.SelectedValue;
                    ObjRenPublicWork.TYPENAME = txtNameApplicant.Text;
                    ObjRenPublicWork.TYPEAPPLICANT = rblApplicant.SelectedValue;
                    ObjRenPublicWork.Director = ddlDirector.SelectedValue;
                    ObjRenPublicWork.Circle = ddlCircle.SelectedValue;
                    ObjRenPublicWork.Division = ddlDivision.SelectedValue;
                    ObjRenPublicWork.FatherName = txtFather.Text;
                    ObjRenPublicWork.MotherName = txtMother.Text;
                    ObjRenPublicWork.DateofNBirth = txtBirth.Text;
                    ObjRenPublicWork.NamePower = txtpowerattorney.Text;
                    ObjRenPublicWork.PermanentAddress = txtPermanent.Text;
                    ObjRenPublicWork.FullAddress = txtcommuniction.Text;
                    ObjRenPublicWork.Nationality = ddlnational.SelectedValue;
                    ObjRenPublicWork.StateDomicile = ddlstate.SelectedValue;
                    ObjRenPublicWork.MobileNo = txtmobile.Text;
                    ObjRenPublicWork.SocialCat = ddlsocial.SelectedValue;
                    ObjRenPublicWork.Emailid = txtEmail.Text;
                    ObjRenPublicWork.BankerName = txtNameBank.Text;
                    ObjRenPublicWork.Turnover = txtTurnOver.Text;
                    ObjRenPublicWork.financialYear = txtFinancial.Text;
                    ObjRenPublicWork.Datework = txtContractor.Text;

                    result = objRenbal.InsertRENPublicWorkDep(ObjRenPublicWork);

                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "Public Work Details Submitted Successfully";
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



        public string Stepvalidations()
        {
            try
            {
                int slno = 1;
                List<TextBox> emptyTextboxes = FindEmptyTextboxes(divText);
                List<DropDownList> emptyDropdowns = FindEmptyDropdowns(divText);
                List<RadioButtonList> emptyRadioButtonLists = FindEmptyRadioButtonLists(divText);
                string errormsg = "";

                if (rblApplication.SelectedIndex == -1 || rblApplication.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Type Applicant \\n";
                    slno = slno + 1;
                }
                if (rblPurApplication.SelectedIndex == -1 || rblPurApplication.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Purpose Of Application \\n";
                    slno = slno + 1;
                }
                if (rblRegister.SelectedIndex == -1 || rblRegister.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Contractor registering \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNameApplicant.Text) || txtNameApplicant.Text == "" || txtNameApplicant.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name Applicant \\n";
                    slno = slno + 1;
                }
                if (rblApplicant.SelectedIndex == -1 || rblApplicant.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Type Applicant \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtBirth.Text) || txtBirth.Text == "" || txtBirth.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Date of Birth \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtPermanent.Text) || txtPermanent.Text == "" || txtPermanent.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Permanent Address \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtcommuniction.Text) || txtcommuniction.Text == "" || txtcommuniction.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Communication Address \\n";
                    slno = slno + 1;
                }
                //if (ddlnational.SelectedIndex == -1 || ddlnational.SelectedItem.Text == "--Select--")
                //{
                //    errormsg = errormsg + slno + ". Please Select Nationality \\n";
                //    slno = slno + 1;
                //}
                //if (ddlstate.SelectedIndex == -1 || ddlstate.SelectedItem.Text == "--Select--")
                //{
                //    errormsg = errormsg + slno + ". Please Select State of Domicile \\n";
                //    slno = slno + 1;
                //}
                if (string.IsNullOrEmpty(txtmobile.Text) || txtmobile.Text == "" || txtmobile.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Mobile No\\n";
                    slno = slno + 1;
                }
                //if (ddlsocial.SelectedIndex == -1 || ddlsocial.SelectedItem.Text == "--Select--")
                //{
                //    errormsg = errormsg + slno + ". Please Select Social Category \\n";
                //    slno = slno + 1;
                //}
                if (string.IsNullOrEmpty(txtEmail.Text) || txtEmail.Text == "" || txtEmail.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter EmailId \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNameBank.Text) || txtNameBank.Text == "" || txtNameBank.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name of Bank \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtTurnOver.Text) || txtTurnOver.Text == "" || txtTurnOver.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter TurnOver \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtFinancial.Text) || txtFinancial.Text == "" || txtFinancial.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter financial Year \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtContractor.Text) || txtContractor.Text == "" || txtContractor.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Date of Contractor \\n";
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
                ds = objRenbal.GetRenPublicWork(hdnUserID.Value, UnitID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["UnitID"] = Convert.ToString(ds.Tables[0].Rows[0]["RENWC_UNITID"]);
                    rblApplication.SelectedValue = ds.Tables[0].Rows[0]["RENWC_APPLTYPE"].ToString();
                    rblPurApplication.SelectedValue = ds.Tables[0].Rows[0]["RENWC_APPLPURPOSE"].ToString();
                    rblRegister.SelectedValue = ds.Tables[0].Rows[0]["RENWC_CONTRREGCLASS"].ToString();
                    txtNameApplicant.Text = ds.Tables[0].Rows[0]["RENWC_NAMEAPPL"].ToString();
                    rblApplicant.SelectedValue = ds.Tables[0].Rows[0]["RENWC_TYPEAPPL"].ToString();
                    ddlDirector.SelectedValue = ds.Tables[0].Rows[0]["RENWC_DIRECTORATE"].ToString();
                    ddlCircle.SelectedValue = ds.Tables[0].Rows[0]["RENWC_CIRCLE"].ToString();
                    ddlDivision.SelectedValue = ds.Tables[0].Rows[0]["RENWC_DIVISION"].ToString();
                    txtFather.Text = ds.Tables[0].Rows[0]["RENWC_FATHERNAME"].ToString();
                    txtMother.Text = ds.Tables[0].Rows[0]["RENWC_MOTHERNAME"].ToString();
                    txtBirth.Text = ds.Tables[0].Rows[0]["RENWC_DATEOFBIRTH"].ToString();
                    txtpowerattorney.Text = ds.Tables[0].Rows[0]["RENWC_POWERATTORNEY"].ToString();
                    txtPermanent.Text = ds.Tables[0].Rows[0]["RENWC_PERMANENTADDRE"].ToString();
                    txtcommuniction.Text = ds.Tables[0].Rows[0]["RENWC_FULLADDRESS"].ToString();
                    ddlnational.SelectedValue = ds.Tables[0].Rows[0]["RENWC_NATIONALITY"].ToString();
                    ddlstate.SelectedValue = ds.Tables[0].Rows[0]["RENWC_STATEDOMICILE"].ToString();
                    txtmobile.Text = ds.Tables[0].Rows[0]["RENWC_MOBILENO"].ToString();
                    ddlsocial.SelectedValue = ds.Tables[0].Rows[0]["RENWC_SOCIALCATG"].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0]["RENWC_EMAILID"].ToString();
                    txtNameBank.Text = ds.Tables[0].Rows[0]["RENWC_CONTRBANKNAME"].ToString();
                    txtTurnOver.Text = ds.Tables[0].Rows[0]["RENWC_CONTRTURNOVER"].ToString();
                    txtFinancial.Text = ds.Tables[0].Rows[0]["RENWC_CONTR3YRSTURNOVER"].ToString();
                    txtContractor.Text = ds.Tables[0].Rows[0]["RENWC_CONTRSTARTDATE"].ToString();

                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        public void BindCaste()
        {
            try
            {
                ddlsocial.Items.Clear();

                List<MasterCaste> objCasteModel = new List<MasterCaste>();
                objCasteModel = mstrBAL.GetCaste();
                if (objCasteModel != null)
                {
                    ddlsocial.DataSource = objCasteModel;
                    ddlsocial.DataValueField = "CASTEID";
                    ddlsocial.DataTextField = "CASTNAME";
                    ddlsocial.DataBind();
                }
                else
                {
                    ddlsocial.DataSource = null;
                    ddlsocial.DataBind();
                }
                AddSelect(ddlsocial);
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
        protected void BindStates()
        {
            try
            {
                ddlstate.Items.Clear();

                List<MasterStates> objStatesModel = new List<MasterStates>();

                objStatesModel = mstrBAL.GetStates();
                if (objStatesModel != null)
                {
                    ddlstate.DataSource = objStatesModel;
                    ddlstate.DataValueField = "StateId";
                    ddlstate.DataTextField = "StateName";
                    ddlstate.DataBind();
                }
                else
                {
                    ddlstate.DataSource = null;
                    ddlstate.DataBind();
                }
                AddSelect(ddlstate);
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
                    Response.Redirect("~/User/Renewal/RENPaymentPage.aspx?Next=" + "N");
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
                Response.Redirect("~/User/Renewal/RENCinemaLicenseDetails.aspx?Previous=" + "P");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void rblApplication_SelectedIndexChanged(object sender, EventArgs e)
        {
            rblApplicant.BorderColor = System.Drawing.Color.White;
        }

        protected void rblPurApplication_SelectedIndexChanged(object sender, EventArgs e)
        {
            rblPurApplication.BorderColor = System.Drawing.Color.White;
        }

        protected void ddlnational_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlnational.SelectedValue == "2")
                {
                    SateDomical.Visible = false;
                }
                else
                {
                    SateDomical.Visible = true;
                }
            }
            catch(Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
    }
}