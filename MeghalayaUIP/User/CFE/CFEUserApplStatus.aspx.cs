using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFE
{
    public partial class CFEUserApplStatus : System.Web.UI.Page
    {
        string UnitID;

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
                    if (Convert.ToString(Session["UNITID"]) != "")
                    { UnitID = Convert.ToString(Session["UNITID"]); }
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        public void BindApplStatus()
        {
            try
            {
                lblAppstatus.Text = "Submitted";
                lblCAFstatus.Text = "Submitted";
                lblApprovalsReq.Text = "22";
                lblApprovalsObtained.Text = "0";
                lblApprovalsApplied.Text = "0";
                lblApprovalstobeApplied.Text = "0";
                lblAddlPaymentReq.Text = "0";
                lblAddlPaymentPaid.Text = "0";
                lblQueryRaised.Text = "0";
                lblQueryReplied.Text = "0";
                lblQueryYettoRespond.Text = "0";
                lblScrtnyRejected.Text = "0";
                lblScrtnyCmpltd.Text = "0";
                lblScrtnyPendng.Text = "0";
                lblApprovalIssued.Text = "0";
                lblApprovalPending.Text = "0";
                lblApprovalRejected.Text = "0";
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
    }
}