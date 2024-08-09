using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.BAL.RenewalBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace MeghalayaUIP.User.Renewal
{
    public partial class RENSafetySecurityDetails : System.Web.UI.Page
    {

        MasterBAL mstrBAL = new MasterBAL();
        RenewalBAL objRenbal = new RenewalBAL();
        string UnitID;
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

                ds = objRenbal.GetRenAppliedApprovalID(hdnUserID.Value, Convert.ToString(Session["RENUNITID"]), Convert.ToString(Session["RENQID"]), "", "");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(ds.Tables[0].Rows[0]["RENDA_APPROVALID"]) == "6")
                    {
                        BindDistricts();
                        BindData();
                    }
                }
                else
                {
                    if (Request.QueryString.Count > 0)
                    {
                        if (Convert.ToString(Request.QueryString[0]) == "N")
                            Response.Redirect("~/User/CFE/CFEFireDetails.aspx?Next=" + "N");
                        else if (Convert.ToString(Request.QueryString[0]) == "P")
                            Response.Redirect("~/User/CFE/CFEPowerDetails.aspx?Previous=" + "P");
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
           
            try
            {
                string ErrorMsg = "", result = "";
                ErrorMsg = validations();
                if (ErrorMsg == "")
                {
                    RenSafteySecurity ObjRenSafteySecurity = new RenSafteySecurity();

                    ObjRenSafteySecurity.Questionnariid = Convert.ToString(Session["RENQID"]);
                    ObjRenSafteySecurity.CreatedBy = hdnUserID.Value;
                    ObjRenSafteySecurity.UnitId = Convert.ToString(Session["RENUNITID"]);
                    ObjRenSafteySecurity.IPAddress = getclientIP();
                    ObjRenSafteySecurity.MIGRANTREGNO = txtMigrantRegNo.Text;
                    ObjRenSafteySecurity.DISTRICREGISSUED = ddlRegIssued.SelectedValue;
                    ObjRenSafteySecurity.NAMEKIN = txtName.Text;
                    ObjRenSafteySecurity.ADDRESS = txtAddress.Text;
                    ObjRenSafteySecurity.FORCEININDIA = rblApplication.SelectedValue;
                    ObjRenSafteySecurity.CRIMINALCASE = rblcrime.SelectedValue;
                    ObjRenSafteySecurity.UNSOUNDMIND = rblmind.SelectedValue;
                    ObjRenSafteySecurity.NATUREOFEMP = txtEmpDesignation.Text;
                    ObjRenSafteySecurity.EMPEXPECTEDDATE = txtEmpDate.Text;
                    ObjRenSafteySecurity.EXPECTEDDURATIONSTAY = txtDurationstay.Text;
                    ObjRenSafteySecurity.WORKDETAILS = txtDetailswork.Text;
                    ObjRenSafteySecurity.DISTRICAREA = ddldistarea.SelectedValue;
                    ObjRenSafteySecurity.AREAOFWORK = txtAreaOfworkadd.Text;
                    ObjRenSafteySecurity.EXSTINGREGVALIDDATE = txtValidDate.Text;
                    ObjRenSafteySecurity.DETAILSOFSPECIFICSKILL = txtDetailsskill.Text;
                    ObjRenSafteySecurity.DISTRICAREAOFWORKER = ddldistricwork.SelectedValue;
                    ObjRenSafteySecurity.WORKADDRESSAREA = txtAreaWorkcomm.Text;
                    ObjRenSafteySecurity.REGRENEWEDDATE = txtRegDate.Text;
                    ObjRenSafteySecurity.NAMEESTEMP = txtNameEstEmp.Text;
                    ObjRenSafteySecurity.ADDRESSEST = txtAddressEst.Text;
                    ObjRenSafteySecurity.CONTACTNO = txtContactNo.Text;

                    result = objRenbal.InsertRENSafteySecurityDetails(ObjRenSafteySecurity);

                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "Renewal Saftey Security Details Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }

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

                if (string.IsNullOrEmpty(txtMigrantRegNo.Text) || txtMigrantRegNo.Text == "" || txtMigrantRegNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Registration Migrant Number\\n";
                    slno = slno + 1;
                }
                if (ddlRegIssued.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Select District in which Registration was Issued....! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtName.Text) || txtName.Text == "" || txtName.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter NAME\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAddress.Text) || txtAddress.Text == "" || txtAddress.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Address\\n";
                    slno = slno + 1;
                }
                if (rblApplication.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Enter  was convicted of any offence under any law in force in India?\\n";
                    slno = slno + 1;
                }
                if (rblcrime.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Enter applicant has any criminal case pending against him/her?\\n";
                    slno = slno + 1;
                }
                if (rblmind.SelectedIndex == -1)
                {
                    errormsg = errormsg + slno + ". Please Enter Declaration that the applicant is not of unsound mind\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEmpDesignation.Text) || txtEmpDesignation.Text == "" || txtEmpDesignation.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Nature of Employment/Designation\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtEmpDate.Text) || txtEmpDate.Text == "" || txtEmpDate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter employment or expected date of commencement\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDurationstay.Text) || txtDurationstay.Text == "" || txtDurationstay.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Expected duration of stay\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDetailswork.Text) || txtDetailswork.Text == "" || txtDetailswork.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Details of the work\\n";
                    slno = slno + 1;
                }
                if (ddldistarea.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Select District of the area of work....! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAreaOfworkadd.Text) || txtAreaOfworkadd.Text == "" || txtAreaOfworkadd.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Area of work \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtValidDate.Text) || txtValidDate.Text == "" || txtValidDate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Existing Registration Valid Up to Date \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtDetailsskill.Text) || txtDetailsskill.Text == "" || txtDetailsskill.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Details of the work\\n";
                    slno = slno + 1;
                }
                if (ddldistricwork.SelectedIndex == 0)
                {
                    errormsg = errormsg + slno + ". Please Select District of the area of work(H)....! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAreaWorkcomm.Text) || txtAreaWorkcomm.Text == "" || txtAreaWorkcomm.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Area of work \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtRegDate.Text) || txtRegDate.Text == "" || txtRegDate.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Registration will be Renewed Upto Date\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNameEstEmp.Text) || txtNameEstEmp.Text == "" || txtNameEstEmp.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Name of the Establishment/Employer\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtAddressEst.Text) || txtAddressEst.Text == "" || txtAddressEst.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Address of the establishment\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtContactNo.Text) || txtContactNo.Text == "" || txtContactNo.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Contact number of Establishment/Employeer\\n";
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
        protected void BindDistricts()
        {
            try
            {
                ddlRegIssued.Items.Clear();
                ddldistarea.Items.Clear();
                ddldistricwork.Items.Clear();




                List<MasterDistrcits> objDistrictModel = new List<MasterDistrcits>();
                string strmode = string.Empty;
                //if (ObjUserInformation.User_Level == "2")
                //{
                strmode = "";
                //}
                objDistrictModel = mstrBAL.GetDistrcits();
                if (objDistrictModel != null)
                {
                    ddlRegIssued.DataSource = objDistrictModel;
                    ddlRegIssued.DataValueField = "DistrictId";
                    ddlRegIssued.DataTextField = "DistrictName";
                    ddlRegIssued.DataBind();

                    ddldistarea.DataSource = objDistrictModel;
                    ddldistarea.DataValueField = "DistrictId";
                    ddldistarea.DataTextField = "DistrictName";
                    ddldistarea.DataBind();

                    ddldistricwork.DataSource = objDistrictModel;
                    ddldistricwork.DataValueField = "DistrictId";
                    ddldistricwork.DataTextField = "DistrictName";
                    ddldistricwork.DataBind();



                }
                else
                {
                    ddlRegIssued.DataSource = null;
                    ddlRegIssued.DataBind();

                    ddldistarea.DataSource = null;
                    ddldistarea.DataBind();

                    ddldistricwork.DataSource = null;
                    ddldistricwork.DataBind();



                }
                AddSelect(ddlRegIssued);
                AddSelect(ddldistarea);
                AddSelect(ddldistricwork);





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
        public void BindData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objRenbal.GetRenSafteySecurity(hdnUserID.Value, UnitID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["UnitID"] = Convert.ToString(ds.Tables[0].Rows[0]["RENSD_UNITID"]);
                    txtMigrantRegNo.Text = ds.Tables[0].Rows[0]["RENSD_MIGRANTREGNO"].ToString();
                    ddlRegIssued.SelectedValue = ds.Tables[0].Rows[0]["RENSD_DISTRICREGISSUED"].ToString();
                    txtName.Text = ds.Tables[0].Rows[0]["RENSD_NAMEKIN"].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0]["RENSD_ADDRESS"].ToString();
                    rblApplication.SelectedValue = ds.Tables[0].Rows[0]["RENSD_FORCEININDIA"].ToString();
                    rblcrime.SelectedValue = ds.Tables[0].Rows[0]["RENSD_CRIMINALCASE"].ToString();
                    rblmind.SelectedValue = ds.Tables[0].Rows[0]["RENSD_UNSOUNDMIND"].ToString();
                    txtEmpDesignation.Text = ds.Tables[0].Rows[0]["RENSD_NATUREOFEMP"].ToString();
                    txtEmpDate.Text = ds.Tables[0].Rows[0]["RENSD_EMPEXPECTEDDATE"].ToString();
                    txtDurationstay.Text = ds.Tables[0].Rows[0]["RENSD_EXPECTEDDURATIONSTAY"].ToString();
                    txtDetailswork.Text = ds.Tables[0].Rows[0]["RENSD_WORKDETAILS"].ToString();
                    ddldistarea.Text = ds.Tables[0].Rows[0]["RENSD_DISTRICAREA"].ToString();
                    txtAreaOfworkadd.Text = ds.Tables[0].Rows[0]["RENSD_AREAOFWORK"].ToString();
                    txtValidDate.Text = ds.Tables[0].Rows[0]["RENSD_EXSTINGREGVALIDDATE"].ToString();
                    txtDetailsskill.Text = ds.Tables[0].Rows[0]["RENSD_DETAILSOFSPECIFICSKILL"].ToString();
                    ddldistricwork.SelectedValue = ds.Tables[0].Rows[0]["RENSD_DISTRICAREAOFWORKER"].ToString();
                    txtAreaWorkcomm.Text = ds.Tables[0].Rows[0]["RENSD_WORKADDRESSAREA"].ToString();
                    txtRegDate.Text = ds.Tables[0].Rows[0]["RENSD_REGRENEWEDDATE"].ToString();
                    txtNameEstEmp.Text = ds.Tables[0].Rows[0]["RENSD_NAMEESTEMP"].ToString();
                    txtAddressEst.Text = ds.Tables[0].Rows[0]["RENSD_ADDRESSEST"].ToString();
                    txtContactNo.Text = ds.Tables[0].Rows[0]["RENSD_CONTACTNO"].ToString();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    
}