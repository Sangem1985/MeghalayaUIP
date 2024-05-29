using MeghalayaUIP.BAL.CFOBAL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFO
{
    public partial class CFOContractorsRegistration : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFOBAL objcfobal = new CFOBAL();
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
                Session["CFOUNITID"] = "1001";
                UnitID = Convert.ToString(Session["CFOUNITID"]);
                if (Convert.ToString(Session["CFOUNITID"]) != "")
                { UnitID = Convert.ToString(Session["CFOUNITID"]); }
                else
                {
                    string newurl = "~/User/CFO/CFOUserDashboard.aspx";
                    Response.Redirect(newurl);
                }
                Page.MaintainScrollPositionOnPostBack = true;
                Failure.Visible = false;
                success.Visible = false;
                if (!IsPostBack)
                {
                    DataSet dsnew = new DataSet();
                    dsnew = objcfobal.GetApprovalDataByDeptId(Session["CFOQID"].ToString(), Session["CFOUNITID"].ToString(), "16");
                    if (dsnew.Tables[0].Rows.Count > 0)
                    {

                    }
                    else
                    {
                        if (Request.QueryString[0].ToString() == "N")
                        {
                            Response.Redirect("~/User/CFO/CFODrugLicenseDetails.aspx?next=N");
                        }
                        else
                        {
                            Response.Redirect("~/User/CFO/CFOLegalMeterology.aspx?Previous=P");
                        }
                    }
                }
            }
        }

        protected void rblRegister_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblRegister.SelectedValue == "1")
            {
                director.Visible = true;
                applicant.Visible = true;
            }
            else if (rblRegister.SelectedValue == "2")
            {
                applicant.Visible = true;
                director.Visible = true;
                circle.Visible = true;
            }
            else if (rblRegister.SelectedValue == "3")
            {
                applicant.Visible = true;
                director.Visible = true;
                circle.Visible = true;
                division.Visible = true;
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            String Quesstionriids = "1001";
            string UnitId = "1001";

            try
            {
                string ErrorMsg = "", result = "";
                ErrorMsg = Validations();
                {
                    PublicWorKDepartment ObjCFOWorkDepartment = new PublicWorKDepartment();

                    { ObjCFOWorkDepartment.UNITID = Convert.ToString(ViewState["UnitID"]); }
                    ObjCFOWorkDepartment.CreatedBy = hdnUserID.Value;
                    ObjCFOWorkDepartment.IPAddress = getclientIP();
                    ObjCFOWorkDepartment.Questionnariid = Quesstionriids;
                    ObjCFOWorkDepartment.UnitId = UnitId;

                    ObjCFOWorkDepartment.PurposeApplicant = rblPurApplication.SelectedValue;
                    ObjCFOWorkDepartment.ContractorReg = rblRegister.SelectedValue;
                    ObjCFOWorkDepartment.Director = ddlDirector.SelectedValue;
                    ObjCFOWorkDepartment.Circle = ddlCircle.SelectedValue;
                    ObjCFOWorkDepartment.Division = ddlDivision.SelectedValue;
                    ObjCFOWorkDepartment.BankerName = txtNameBank.Text;
                    ObjCFOWorkDepartment.Turnover = txtTurnOver.Text;
                    ObjCFOWorkDepartment.financialYear = txtFinancial.Text;
                    ObjCFOWorkDepartment.Datework = txtContractor.Text;

                    result = objcfobal.InsertCFOPublicworkDetails(ObjCFOWorkDepartment);
                    ViewState["UnitID"] = result;
                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "CFO Publick Work Details Submitted Successfully";
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
        public string Validations()
        {
            try
            {
                int slno = 1;
                string errormsg = "";
                if (string.IsNullOrEmpty(txtNameBank.Text) || txtNameBank.Text == "" || txtNameBank.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Address\\n";
                    slno = slno + 1;
                }
                if (rblPurApplication.SelectedIndex == -1 || rblPurApplication.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Distric \\n";
                    slno = slno + 1;
                }
                if (rblRegister.SelectedIndex == -1 || rblRegister.SelectedItem.Text == "--Select--")
                {
                    errormsg = errormsg + slno + ". Please Select Place of Business in Meghalaya \\n";
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
            Response.Redirect("~/User/CFO/CFODrugLicenseDetails.aspx");
        }

        protected void btnPreviuos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User/CFO/CFOLegalMeterology.aspx");
        }
    }
}