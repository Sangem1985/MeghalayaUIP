﻿using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFE
{
    public partial class CFEUserApplStatus : System.Web.UI.Page
    {
        string UnitID, newurl = "";

        CFEBAL objcfebal = new CFEBAL();
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
                    if (Convert.ToString(Session["CFEUNITID"]) != "")
                    {
                        UnitID = Convert.ToString(Session["CFEUNITID"]);                        
                    }
                    else
                    {
                        string newurl = "~/User/CFE/CFEUserDashboard.aspx";
                        Response.Redirect(newurl);
                    }
                    Page.MaintainScrollPositionOnPostBack = true;
                    if (!IsPostBack)
                    {
                        BindApplStatus();
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
                DataSet ds = new DataSet();
                ds = objcfebal.GetUserCFEApplStatus(hdnUserID.Value, UnitID);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lbluidno.Text = lblApprovalsReq.Text = Convert.ToString(ds.Tables[0].Rows[0]["UIDNO"]);
                        //lblAppstatus.Text = Convert.ToString(ds.Tables[0].Rows[0]["APPLSTATUS"]);
                        //lblCAFstatus.Text = Convert.ToString(ds.Tables[0].Rows[0]["CAFSTATUS"]);
                        lblApprovalsReq.Text = Convert.ToString(ds.Tables[0].Rows[0]["APPREQ"]);
                        lblApprovalsObtained.Text = Convert.ToString(ds.Tables[0].Rows[0]["APPROFFLINE"]);
                        lblApprovalsApplied.Text = Convert.ToString(ds.Tables[0].Rows[0]["APPRAPPLD"]);
                        lblApprovalstobeApplied.Text = Convert.ToString(ds.Tables[0].Rows[0]["TOBEAPPL"]);
                        lblPaymntdone.Text = Convert.ToString(ds.Tables[0].Rows[0]["PAYMNTPAID"]);
                        lblAddlPaymentReq.Text = Convert.ToString(ds.Tables[0].Rows[0]["ADDLPAYMNT"]);
                        lblAddlPaymentPaid.Text = Convert.ToString(ds.Tables[0].Rows[0]["ADDLPAYMNTPAID"]);
                        lblQueryRaised.Text = Convert.ToString(ds.Tables[0].Rows[0]["QRYRAISE"]);
                        lblQueryReplied.Text = Convert.ToString(ds.Tables[0].Rows[0]["QRYRESPOND"]);
                        lblQueryYettoRespond.Text = Convert.ToString(ds.Tables[0].Rows[0]["QRYTOBERSPND"]);
                        lblScrtnyRejected.Text = Convert.ToString(ds.Tables[0].Rows[0]["SCRTNYREJ"]);
                        lblScrtnyCmpltd.Text = Convert.ToString(ds.Tables[0].Rows[0]["SCRTNYAPPRVD"]);
                        lblScrtnyPendng.Text = Convert.ToString(ds.Tables[0].Rows[0]["SCRTNYPENDING"]);
                        lblApprovalIssued.Text = Convert.ToString(ds.Tables[0].Rows[0]["APPRISSUED"]);
                        lblApprovalPending.Text = Convert.ToString(ds.Tables[0].Rows[0]["APPRUNDRPROCESS"]);
                        lblApprovalRejected.Text = Convert.ToString(ds.Tables[0].Rows[0]["APPRREJ"]);
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
        protected void linkApprReq_Click(object sender, EventArgs e)
        {
            if (lblApprovalsReq.Text != "0")
            {
                newurl = "~/User/Dashboard/Dashboardstatus.aspx?UnitID=" + Convert.ToString(Session["CFEUNITID"]) + "&Type=ApprRequired";
                Response.Redirect(newurl);
            }
        }
        protected void linkOfflineAppr_Click(object sender, EventArgs e)
        {
            if (lblApprovalsObtained.Text != "0")
            {
                newurl = "~/User/Dashboard/Dashboardstatus.aspx?UnitID=" + Convert.ToString(Session["CFEUNITID"]) + "&Type=OfflineApprovals";
                Response.Redirect(newurl);
            }

        }

        protected void linkApprApplied_Click(object sender, EventArgs e)
        {
            if (lblApprovalsApplied.Text != "0")
            {
                newurl = "~/User/Dashboard/Dashboardstatus.aspx?UnitID=" + Convert.ToString(Session["CFEUNITID"]) + "&Type=Applied";
                Response.Redirect(newurl);
            }
        }

        protected void linkTobeApplied_Click(object sender, EventArgs e)
        {
            if (lblApprovalstobeApplied.Text != "0")
            {
                newurl = "~/User/Dashboard/Dashboardstatus.aspx?UnitID=" + Convert.ToString(Session["CFEUNITID"]) + "&Type=TobeApplied";
                Response.Redirect(newurl);
            }
        }

        protected void linkAddlPaymnt_Click(object sender, EventArgs e)
        {
            if (lblAddlPaymentReq.Text != "0")
            {
                newurl = "~/User/CFE/CFEAddlPayment.aspx?UnitID=" + Convert.ToString(Session["CFEUNITID"]) + "&Type=AddlPayment";
                Response.Redirect(newurl);
            }
        }

        protected void linkAddlPaymntdone_Click(object sender, EventArgs e)
        {
            if (lblAddlPaymentPaid.Text != "0")
            {
                newurl = "~/User/Dashboard/Dashboardstatus.aspx?UnitID=" + Convert.ToString(Session["CFEUNITID"]) + "&Type=AddlPaymentDone";
                Response.Redirect(newurl);
            }
        }

        protected void linkQryRaised_Click(object sender, EventArgs e)
        {
            if (lblQueryRaised.Text != "0")
            {
                newurl = "~/User/Dashboard/Dashboardstatus.aspx?UnitID=" + Convert.ToString(Session["CFEUNITID"]) + "&Type=QueryRaised";
                Response.Redirect(newurl);
            }
        }

        protected void linkQueryReplied_Click(object sender, EventArgs e)
        {
            if (lblQueryReplied.Text != "0")
            {
                newurl = "~/User/Dashboard/Dashboardstatus.aspx?UnitID=" + Convert.ToString(Session["CFEUNITID"]) + "&Type=QueryReplied";
                Response.Redirect(newurl);
            }
        }

        protected void linkQueryYettoRespond_Click(object sender, EventArgs e)
        {
            if (lblQueryYettoRespond.Text != "0")
            {
                newurl = "~/User/Dashboard/Dashboardstatus.aspx?UnitID=" + Convert.ToString(Session["CFEUNITID"]) + "&Type=QueryYettoRespond";
                Response.Redirect(newurl);
            }
        }

        protected void linkScrtnyRejected_Click(object sender, EventArgs e)
        {
            if (lblScrtnyRejected.Text != "0")
            {
                newurl = "~/User/Dashboard/Dashboardstatus.aspx?UnitID=" + Convert.ToString(Session["CFEUNITID"]) + "&Type=ScrutinyRejected";
                Response.Redirect(newurl);
            }

        }

        protected void linkScrtnyCmpltd_Click(object sender, EventArgs e)
        {
            if (lblScrtnyCmpltd.Text != "0")
            {
                newurl = "~/User/Dashboard/Dashboardstatus.aspx?UnitID=" + Convert.ToString(Session["CFEUNITID"]) + "&Type=ScrutinyCompleted";
                Response.Redirect(newurl);
            }
        }

        protected void linkScrtnyPendng_Click(object sender, EventArgs e)
        {
            if (lblScrtnyPendng.Text != "0")
            {
                newurl = "~/User/Dashboard/Dashboardstatus.aspx?UnitID=" + Convert.ToString(Session["CFEUNITID"]) + "&Type=ScrutinyPending";
                Response.Redirect(newurl);
            }
        }

        protected void linkApprovalIssued_Click(object sender, EventArgs e)
        {
            if (lblApprovalIssued.Text != "0")
            {
                newurl = "~/User/Dashboard/Dashboardstatus.aspx?UnitID=" + Convert.ToString(Session["CFEUNITID"]) + "&Type=Approved";
                Response.Redirect(newurl);
            }

        }

        protected void linkApprovalPending_Click(object sender, EventArgs e)
        {
            if (lblApprovalPending.Text != "0")
            {
                newurl = "~/User/Dashboard/Dashboardstatus.aspx?UnitID=" + Convert.ToString(Session["CFEUNITID"]) + "&Type=ApprovalPending";
                Response.Redirect(newurl);
            }

        }       

        protected void linkPaymntdone_Click(object sender, EventArgs e)
        {
            if (lblPaymntdone.Text != "0")
            {
                newurl = "~/User/Dashboard/Dashboardstatus.aspx?UnitID=" + Convert.ToString(Session["CFEUNITID"]) + "&Type=Applied";
                Response.Redirect(newurl);
            }
        }

        protected void linkApprovalRejected_Click(object sender, EventArgs e)
        {
            if (lblApprovalRejected.Text != "0")
            {
                newurl = "~/User/Dashboard/Dashboardstatus.aspx?UnitID=" + Convert.ToString(Session["CFEUNITID"]) + "&Type=Rejected";
                Response.Redirect(newurl);
            }

        }
        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlStatus.SelectedValue == "ApplicationStage")
                {
                    //divApplicationStages.Visible = true;
                  //  divPaymentStages.Visible = false;
                    divPreScrutinyStages.Visible = false;
                    divApprovalStages.Visible = false;
                }
                else if (ddlStatus.SelectedValue == "PaymentStage")
                {
                   // divPaymentStages.Visible = true;
                   // divApplicationStages.Visible = false;
                    divPreScrutinyStages.Visible = false;
                    divApprovalStages.Visible = false;
                }
                else if (ddlStatus.SelectedValue == "Pre-ScrutinyStage")
                {
                    divPreScrutinyStages.Visible = true;
                    //divPaymentStages.Visible = false;
                   // divApplicationStages.Visible = false;
                    divApprovalStages.Visible = false;
                }
                else if (ddlStatus.SelectedValue == "ApprovalStage")
                {
                    divApprovalStages.Visible = true;
                    //divApplicationStages.Visible = false;
                   // divPaymentStages.Visible = false;
                    divPreScrutinyStages.Visible = false;
                }
                else if (ddlStatus.SelectedValue == "0")
                {
                    //divApplicationStages.Visible = true;
                    //divPaymentStages.Visible = true;
                    divPreScrutinyStages.Visible = true;
                    divApprovalStages.Visible = true;
                }

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