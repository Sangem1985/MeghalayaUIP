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
        string UnitID, ErrorMsg = "";
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
                    Binddata();
                }
            }
        }
        public void Binddata()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objcfobal.GetCFOContractors(hdnUserID.Value, UnitID);

                if (ds.Tables[1].Rows.Count > 0)
                {
                    ViewState["UnitID"] = Convert.ToString(ds.Tables[1].Rows[0]["CFOWC_UNITID"]);
                    rblPurApplication.SelectedValue = ds.Tables[1].Rows[0]["CFOWC_APPLPURPOSE"].ToString();
                    rblRegister.SelectedValue = ds.Tables[1].Rows[0]["CFOWC_CONTRREGCLASS"].ToString();
                    if (rblRegister.SelectedValue == "1")
                        director.Visible = true;
                    else director.Visible = false;
                    ddlDirector.SelectedValue = ds.Tables[1].Rows[0]["CFOWC_DIRECTORATE"].ToString();
                    if (rblRegister.SelectedValue == "2")
                        circle.Visible = true;
                    else circle.Visible = false;
                    ddlCircle.SelectedValue = ds.Tables[1].Rows[0]["CFOWC_CIRCLE"].ToString();
                    if (rblRegister.SelectedValue == "3")
                        division.Visible = true;
                    else division.Visible = false;
                    ddlDivision.SelectedValue = ds.Tables[1].Rows[0]["CFOWC_DIVISION"].ToString();
                    txtNameBank.Text = ds.Tables[1].Rows[0]["CFOWC_CONTRBANKNAME"].ToString();
                    txtTurnOver.Text = ds.Tables[1].Rows[0]["CFOWC_CONTRTURNOVER"].ToString();
                    txtFinancial.Text = ds.Tables[1].Rows[0]["CFOWC_CONTR3YRSTURNOVER"].ToString();
                    txtContractor.Text = ds.Tables[1].Rows[0]["CFOWC_CONTRSTARTDATE"].ToString();
                }




            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void rblRegister_SelectedIndexChanged(object sender, EventArgs e)
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

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                ErrorMsg = Validations();
                {
                    PublicWorKDepartment ObjCFOWorkDepartment = new PublicWorKDepartment();

                    ObjCFOWorkDepartment.UNITID = Convert.ToString(Session["CFOUNITID"]);
                    ObjCFOWorkDepartment.CreatedBy = hdnUserID.Value;
                    ObjCFOWorkDepartment.IPAddress = getclientIP();
                    ObjCFOWorkDepartment.Questionnariid = Convert.ToString(Session["CFOQID"]);
                    ObjCFOWorkDepartment.UnitId = Convert.ToString(Session["CFOUNITID"]);

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
                  //  ViewState["UnitID"] = result;
                    if (result != "")
                    {
                        success.Visible = true;
                        lblmsg.Text = "Public Work Details Submitted Successfully";
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

                if (string.IsNullOrEmpty(txtNameBank.Text) || txtNameBank.Text == "" || txtNameBank.Text == null)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Address\\n";
                    slno = slno + 1;
                }
                if (rblPurApplication.SelectedIndex == -1)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Purpose of Application \\n";
                    slno = slno + 1;
                }
                //if (rblRegister.SelectedValue == "1")
                //{
                //    applicant.Visible = true;
                //    director.Visible = true;
                //    if (ddlDirector.SelectedIndex == 0)
                //    {
                //        errormsg = errormsg + slno + ". Please Enter Directorate\\n";
                //        slno = slno + 1;
                //    }
                //    else { director.Visible = false; }
                //}
                //else if (rblRegister.SelectedValue == "2")
                //{
                //    applicant.Visible = true;
                //    circle.Visible = true;
                //    if (ddlCircle.SelectedIndex == 0)
                //    {
                //        errormsg = errormsg + slno + ". Please Enter Circle\\n";
                //        slno = slno + 1;
                //    }
                //    else { circle.Visible = false; }
                //}
                //else if (rblRegister.SelectedValue == "3")
                //{
                //    applicant.Visible = true;
                //    division.Visible = true;
                //    if (ddlDivision.SelectedIndex == 0)
                //    {
                //        errormsg = errormsg + slno + ". Please Enter Division\\n";
                //        slno = slno + 1;
                //    }
                //    else { division.Visible = false; }
                //}

                if (string.IsNullOrEmpty(txtTurnOver.Text) || txtTurnOver.Text == "" || txtTurnOver.Text == null)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Turn Over (in Rs. Lakhs)\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtFinancial.Text) || txtFinancial.Text == "" || txtFinancial.Text == null)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Total Value of Works in last 3 financial years (in Rs. Lakhs)\\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtContractor.Text) || txtContractor.Text == "" || txtContractor.Text == null)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Date from which working as contractor\\n";
                    slno = slno + 1;
                }

                return ErrorMsg;
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
                    Response.Redirect("~/User/CFO/CFODrugLicenseDetails.aspx?next=N");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
           // Response.Redirect("~/User/CFO/CFODrugLicenseDetails.aspx?next=N");
        }

        protected void btnPreviuos_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/CFO/CFOLegalMeterology.aspx?Previous=P");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }

           // Response.Redirect("~/User/CFO/CFOLegalMeterology.aspx?Previous=P");
        }
    }
}