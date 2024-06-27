using MeghalayaUIP.BAL.CFEBLL;
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
                    { UnitID = Convert.ToString(Session["CFEUNITID"]); }
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
                        //lblAppstatus.Text = Convert.ToString(ds.Tables[0].Rows[0]["APPLSTATUS"]);
                        //lblCAFstatus.Text = Convert.ToString(ds.Tables[0].Rows[0]["CAFSTATUS"]);
                        lblApprovalsReq.Text = Convert.ToString(ds.Tables[0].Rows[0]["APPREQ"]);
                        lblApprovalsObtained.Text = Convert.ToString(ds.Tables[0].Rows[0]["APPROFFLINE"]);
                        lblApprovalsApplied.Text = Convert.ToString(ds.Tables[0].Rows[0]["APPRAPPLD"]);
                        lblApprovalstobeApplied.Text = Convert.ToString(ds.Tables[0].Rows[0]["TOBEAPPL"]);
                        lblAddlPaymentReq.Text = Convert.ToString(ds.Tables[0].Rows[0]["ADDLPAYMNT"]);
                        lblAddlPaymentPaid.Text = Convert.ToString(ds.Tables[0].Rows[0]["PAYMNTPAID"]);
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
                newurl = "~/User/Dashboard/Dashboardstatus.aspx?UnitID=" + Convert.ToString(Session["CFEUNITID"]) + "&Type=Applied";
                Response.Redirect(newurl);
            }
        }
        protected void linkOfflineAppr_Click(object sender, EventArgs e)
        {
            if (lblApprovalsObtained.Text != "0")
            {
                newurl = "~/User/Dashboard/Dashboardstatus.aspx?UnitID=" + Convert.ToString(Session["CFEUNITID"]) + "&Type=Applied";
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
                newurl = "~/User/Dashboard/Dashboardstatus.aspx?UnitID=" + Convert.ToString(Session["CFEUNITID"]) + "&Type=Applied";
                Response.Redirect(newurl);
            }
        }

        protected void linkAddlPaymnt_Click(object sender, EventArgs e)
        {
            if (lblAddlPaymentReq.Text != "0")
            {
                newurl = "~/User/Dashboard/Dashboardstatus.aspx?UnitID=" + Convert.ToString(Session["CFEUNITID"]) + "&Type=Applied";
                Response.Redirect(newurl);
            }
        }

        protected void linkAddlPaymntdone_Click(object sender, EventArgs e)
        {
            if (lblAddlPaymentPaid.Text != "0")
            {
                newurl = "~/User/Dashboard/Dashboardstatus.aspx?UnitID=" + Convert.ToString(Session["CFEUNITID"]) + "&Type=Applied";
                Response.Redirect(newurl);
            }
        }

        protected void linkQryRaised_Click(object sender, EventArgs e)
        {
            if (lblQueryRaised.Text != "0")
            {
                newurl = "~/User/Dashboard/Dashboardstatus.aspx?UnitID=" + Convert.ToString(Session["CFEUNITID"]) + "&Type=Applied";
                Response.Redirect(newurl);
            }
        }

        protected void linkQueryReplied_Click(object sender, EventArgs e)
        {
            if (lblQueryReplied.Text != "0")
            {
                newurl = "~/User/Dashboard/Dashboardstatus.aspx?UnitID=" + Convert.ToString(Session["CFEUNITID"]) + "&Type=Applied";
                Response.Redirect(newurl);
            }
        }

        protected void linkQueryYettoRespond_Click(object sender, EventArgs e)
        {
            if (lblQueryYettoRespond.Text != "0")
            {
                newurl = "~/User/Dashboard/Dashboardstatus.aspx?UnitID=" + Convert.ToString(Session["CFEUNITID"]) + "&Type=Applied";
                Response.Redirect(newurl);
            }
        }

        protected void linkScrtnyRejected_Click(object sender, EventArgs e)
        {
            if (lblScrtnyRejected.Text != "0")
            {
                newurl = "~/User/Dashboard/Dashboardstatus.aspx?UnitID=" + Convert.ToString(Session["CFEUNITID"]) + "&Type=Applied";
                Response.Redirect(newurl);
            }

        }

        protected void linkScrtnyCmpltd_Click(object sender, EventArgs e)
        {
            if (lblScrtnyCmpltd.Text != "0")
            {
                newurl = "~/User/Dashboard/Dashboardstatus.aspx?UnitID=" + Convert.ToString(Session["CFEUNITID"]) + "&Type=Applied";
                Response.Redirect(newurl);
            }
        }

        protected void linkScrtnyPendng_Click(object sender, EventArgs e)
        {
            if (lblScrtnyPendng.Text != "0")
            {
                newurl = "~/User/Dashboard/Dashboardstatus.aspx?UnitID=" + Convert.ToString(Session["CFEUNITID"]) + "&Type=Applied";
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
                newurl = "~/User/Dashboard/Dashboardstatus.aspx?UnitID=" + Convert.ToString(Session["CFEUNITID"]) + "&Type=UnderProcess";
                Response.Redirect(newurl);
            }

        }

        protected void linkApprovalRejected_Click(object sender, EventArgs e)
        {
            if (lblApprovalRejected.Text != "0")
            {
                newurl = "~/User/Dashboard/Dashboardstatus.aspx?UnitID=" + Convert.ToString(Session["CFEUNITID"]) + "&Type=Applied";
                Response.Redirect(newurl);
            }

        }

       
    }
}