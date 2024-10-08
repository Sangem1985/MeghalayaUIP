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

namespace MeghalayaUIP.Dept.Renewal
{
    public partial class RENApplDeptdrill : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        RenewalBAL objRenbal = new RenewalBAL();
        RENDtls ObjREN = new RENDtls();
        DeptUserInfo ObjUserInfo = new DeptUserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack == false)
                {
                    if (Session["DeptUserInfo"] != null)
                    {

                        if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
                        {
                            ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
                            BindApplStatus();
                        }
                        // username = ObjUserInfo.UserName;
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        public void BindApplStatus()
        {
            try
            {
                if (Session["DeptUserInfo"] != null)
                {

                    if (Session["DeptUserInfo"] != null && Session["DeptUserInfo"].ToString() != "")
                    {
                        ObjUserInfo = (DeptUserInfo)Session["DeptUserInfo"];
                    }
                    // username = ObjUserInfo.UserName;
                }
                ObjREN.UserID = ObjUserInfo.UserID;
                ObjREN.UserName = ObjUserInfo.UserName;
                ObjREN.Role = Convert.ToInt32(ObjUserInfo.Roleid);
                ObjREN.deptid = Convert.ToInt32(ObjUserInfo.Deptid);
                if (Request.QueryString["Status"].ToString() != "")
                {
                    ddlStatus.SelectedValue = Request.QueryString["Status"].ToString();
                    ddlStatus_SelectedIndexChanged(this, EventArgs.Empty);
                }

                dt = objRenbal.GetRENDashboard(ObjREN);

                LBLPRESCRUTINYPENDING.Text = dt.Rows[0]["PRESCRUTINYPENDING"].ToString();
                LBLPRESCRUTINYPENDINGWITHIN.Text = dt.Rows[0]["PRESCRUTINYPENDINGWITHIN"].ToString();
                LBLPRESCRUTINYPENDINGBEYOND.Text = dt.Rows[0]["PRESCRUTINYPENDINGBEYOND"].ToString();
                lblPRESCRUTINYCOMPLETED.Text = dt.Rows[0]["PRESCRUTINYCOMPLETED"].ToString();
                LBLPRESCRUTINYCOMPLETEDWITHIN.Text = dt.Rows[0]["PRESCRUTINYCOMPLETEDWITHIN"].ToString();
                LBLPRESCRUTINYCOMPLETEDBEYOND.Text = dt.Rows[0]["PRESCRUTINYCOMPLETEDBEYOND"].ToString();
                LBLAPPROVALPENDING.Text = dt.Rows[0]["APPROVALPENDING"].ToString();
                LBLAPPROVALPENDINGWITHIN.Text = dt.Rows[0]["APPROVALPENDINGWITHIN"].ToString();
                LBLAPPROVALPENDINGBEYOND.Text = dt.Rows[0]["APPROVALPENDINGBEYOND"].ToString();
                LBLTOTALAPPROVALISSUED.Text = dt.Rows[0]["TOTALAPPROVALISSUED"].ToString();
                LBLAPPROVALISSUEDWITHIN.Text = dt.Rows[0]["APPROVALISSUEDWITHIN"].ToString();
                LBLAPPROVALISSUEDBEYOND.Text = dt.Rows[0]["APPROVALISSUEDBEYOND"].ToString();
                lblPREREJECTED.Text = dt.Rows[0]["PREREJECTED"].ToString();
                LBLPREREJECTEDWITHIN.Text = dt.Rows[0]["PREREJECTEDWITHIN"].ToString();
                LBLPREREJECTEDBEYOND.Text = dt.Rows[0]["PREREJECTEDBEYOND"].ToString();
                lblREJECTED.Text = dt.Rows[0]["REJECTED"].ToString();
                lblREJECTEDWITHIN.Text = dt.Rows[0]["REJECTEDWITHIN"].ToString();
                lblREJECTEDBEYOND.Text = dt.Rows[0]["REJECTEDBEYOND"].ToString();

                lblTOTALOFFLINEAPPROVED.Text = dt.Rows[0]["OFFLINEAPPROVED"].ToString();
                lblOFFLINEWITHINAPPROVED.Text = dt.Rows[0]["OFFLINEAPPROVEDWITHIN"].ToString();
                lblOFFLINEBEYONDAPPROVED.Text = dt.Rows[0]["OFFLINEAPPROVEDBEYOND"].ToString();
                lblOFFLINEPENDING.Text = dt.Rows[0]["OFFLINEPENDING"].ToString();
                lblOFFLINEPENDINGWITHIN.Text = dt.Rows[0]["OFFLINEPENDINGWITHIN"].ToString();
                lblOFFLINEPENDINGBEYOND.Text = dt.Rows[0]["OFFLINEPENDINGBEYOND"].ToString();
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlStatus.SelectedValue == "ScrutinyPending")
                {
                    PrescrutinyPending.Visible = true;
                    Prescrutinycompleted.Visible = false;
                    PreScrutinyRejected.Visible = false;
                    Approvalunderprocess.Visible = false;
                    ApprovalIssued.Visible = false;
                    ApprovalRejected.Visible = false;
                }
                else if (ddlStatus.SelectedValue == "ScrutinyCompleted")
                {
                    PrescrutinyPending.Visible = false;
                    Prescrutinycompleted.Visible = true;
                    PreScrutinyRejected.Visible = false;
                    Approvalunderprocess.Visible = false;
                    ApprovalIssued.Visible = false;
                    ApprovalRejected.Visible = false;
                }
                else if (ddlStatus.SelectedValue == "ScrutinyRejected")
                {
                    PrescrutinyPending.Visible = false;
                    Prescrutinycompleted.Visible = false;
                    PreScrutinyRejected.Visible = true;
                    Approvalunderprocess.Visible = false;
                    ApprovalIssued.Visible = false;
                    ApprovalRejected.Visible = false;
                }
                else if (ddlStatus.SelectedValue == "ApprovalIssued")
                {
                    PrescrutinyPending.Visible = false;
                    Prescrutinycompleted.Visible = false;
                    PreScrutinyRejected.Visible = false;
                    Approvalunderprocess.Visible = false;
                    ApprovalIssued.Visible = true;
                    ApprovalRejected.Visible = false;
                }
                else if (ddlStatus.SelectedValue == "ApprovalPending")
                {
                    PrescrutinyPending.Visible = false;
                    Prescrutinycompleted.Visible = false;
                    PreScrutinyRejected.Visible = false;
                    Approvalunderprocess.Visible = true;
                    ApprovalIssued.Visible = false;
                    ApprovalRejected.Visible = false;
                }
                else if (ddlStatus.SelectedValue == "ApprovalRejected")
                {
                    PrescrutinyPending.Visible = false;
                    Prescrutinycompleted.Visible = false;
                    PreScrutinyRejected.Visible = false;
                    Approvalunderprocess.Visible = false;
                    ApprovalIssued.Visible = false;
                    ApprovalRejected.Visible = true;
                }
                else if (ddlStatus.SelectedValue == "OfflinePending")
                {
                    PrescrutinyPending.Visible = false;
                    Prescrutinycompleted.Visible = false;
                    PreScrutinyRejected.Visible = false;
                    Approvalunderprocess.Visible = false;
                    ApprovalIssued.Visible = false;
                    ApprovalRejected.Visible = false;
                    OfflineApprovalPending.Visible = true;
                }
                else if (ddlStatus.SelectedValue == "OfflineApproved")
                {
                    PrescrutinyPending.Visible = false;
                    Prescrutinycompleted.Visible = false;
                    PreScrutinyRejected.Visible = false;
                    Approvalunderprocess.Visible = false;
                    ApprovalIssued.Visible = false;
                    ApprovalRejected.Visible = false;
                    OfflineApprovalPending.Visible = false;
                    OfflineApproved.Visible = true;
                }
                else if (ddlStatus.SelectedValue == "0")
                {
                    PrescrutinyPending.Visible = true;
                    Prescrutinycompleted.Visible = true;
                    PreScrutinyRejected.Visible = true;
                    Approvalunderprocess.Visible = true;
                    ApprovalIssued.Visible = true;
                    ApprovalRejected.Visible = true;
                    OfflineApprovalPending.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Dept/Renewal/RENDeptDashboard.aspx");
            }
            catch (Exception ex)
            {
                Failure.Visible = true;
                lblmsg0.Text = ex.Message;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
    }
}