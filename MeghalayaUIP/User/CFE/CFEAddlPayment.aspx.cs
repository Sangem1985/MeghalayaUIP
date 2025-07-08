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
    public partial class CFEAddlPayment : System.Web.UI.Page
    {
        MGCommonBAL objcommonBAL = new MGCommonBAL();
        MasterBAL mstrBAL = new MasterBAL();
        CFEBAL objcfebal = new CFEBAL();
        string UnitID; Decimal TotFee;
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

                    if (Request.QueryString.Count > 0)
                    {
                        UnitID = Convert.ToString(Request.QueryString[0]);
                        lblType.Text = " " + Request.QueryString[1].ToString() + ":";
                        if (Request.QueryString[1].ToString() == "UnderProcess")
                        { lblType.Text = " Under Process:"; }
                        if (Request.QueryString[1].ToString() == "ScrutinyCompleted")
                        { lblType.Text = " Scrutiny Completed:"; }
                        if (Request.QueryString[1].ToString() == "ScrutinyPending")
                        { lblType.Text = " Scrutiny Pending:"; }

                    }
                    else
                    {
                        string newurl = "~/User/MainDashboard.aspx";
                        Response.Redirect(newurl);
                    }

                    Page.MaintainScrollPositionOnPostBack = true;


                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
                if (!IsPostBack)
                {
                    BindApplStatus();
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void BindApplStatus()
        {
            try
            {
                DataSet dsApprovals = new DataSet();
                UnitID = Convert.ToString(Request.QueryString[0]);

                dsApprovals = objcommonBAL.GetCFEUserDashboardStatus(hdnUserID.Value, UnitID, Request.QueryString[1].ToString());
                if (dsApprovals.Tables.Count > 0)
                {
                    if (dsApprovals.Tables[0].Rows.Count > 0)
                    {
                        grdTrackerDetails.DataSource = dsApprovals.Tables[0];
                        grdTrackerDetails.DataBind();
                        lblDOA.Text = Convert.ToString(dsApprovals.Tables[0].Rows[0]["DATEOFAPPLICATION"]);
                    }
                    if (dsApprovals.Tables[1].Rows.Count > 0)
                    {
                        lblUnitID.Text = Convert.ToString(dsApprovals.Tables[1].Rows[0]["CFEQD_CFEUIDNO"]);
                        lblUnitNmae.Text = Convert.ToString(dsApprovals.Tables[1].Rows[0]["CFEQD_COMPANYNAME"]);

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

        protected void chkSel_CheckedChanged(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((CheckBox)sender).Parent.Parent)).RowIndex;
            CheckBox cb = (CheckBox)grdTrackerDetails.Rows[selRowIndex].FindControl("chkSel");
            Label lblAmount = (Label)grdTrackerDetails.Rows[selRowIndex].FindControl("lblAmount");
            if (ViewState["Amount"] == null)
            {
                ViewState["Amount"] = 0;
            }
            decimal PrvAmount = Convert.ToDecimal(ViewState["Amount"].ToString());
            decimal TotalPaymentAmount;

            if (cb.Checked)
            {
                TotalPaymentAmount = PrvAmount + Convert.ToDecimal(lblAmount.Text);

            }
            else
            {
                TotalPaymentAmount = PrvAmount - Convert.ToDecimal(lblAmount.Text);
            }
            lblPaymentAmount.InnerText = TotalPaymentAmount.ToString();
            ViewState["Amount"] = TotalPaymentAmount.ToString();
        }

        protected void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                decimal TotalAmount = 0;
                string PaymentAmount = "";
                string receipt = "MIP_" + DateTime.Now.Year + DateTime.Now.Month +
                    DateTime.Now.Day + DateTime.Now.Minute + DateTime.Now.Year + DateTime.Now.Second + DateTime.Now.Millisecond;
                Session["OrderNo"] = receipt;
                string result;
                int count = 0;

                CFEPayments objpay = new CFEPayments();
                foreach (GridViewRow row in grdTrackerDetails.Rows)
                {
                    CheckBox ChkSelect = (CheckBox)row.FindControl("chkSel");
                    if (ChkSelect.Checked == true)
                    {
                        Label ApprovalID = (Label)row.FindControl("lblApprovalId");
                        Label DeptID = (Label)row.FindControl("lblDeptId");
                        Label Amount = (Label)row.FindControl("lblAmount");

                        objpay.UNITID = Convert.ToString(Session["CFEUNITID"]);
                        objpay.Questionnareid = Convert.ToString(Session["CFEQID"]);
                        objpay.CFEUID = lblUnitID.Text;
                        objpay.DeptID = DeptID.Text;
                        objpay.ApprovalID = ApprovalID.Text;
                        objpay.OnlineOrderNo = receipt;
                        objpay.OnlineOrderAmount = Amount.Text;
                        objpay.PaymentFlag = "";
                        objpay.TransactionNo = "";
                        objpay.TransactionDate = DateTime.Now.ToString("yyyy-MM-dd");
                        objpay.BankName = "";
                        objpay.CreatedBy = hdnUserID.Value;
                        objpay.IPAddress = getclientIP();
                        TotalAmount = TotalAmount + Convert.ToDecimal(Amount.Text);
                        string A = objcfebal.InsAddlPaymentDetails(objpay);
                        if (A != "")
                        { count = count + 1; }
                    }
                }
                if (TotalAmount > 0)
                {
                    PaymentAmount = ((int?)TotalAmount).ToString();
                    Session["PaymentAmount"] = ((int?)TotalAmount).ToString();
                    Response.Redirect("~/User/Payments/RazorPaymentPage.aspx?receipt=" + receipt + "&Amount=" + PaymentAmount + "&Module=CFE");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select atleast one Approval')", true);
                    return;
                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
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

        protected void grdTrackerDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    CheckBox chkHeader = (CheckBox)e.Row.FindControl("chkHeader");
                    chkHeader.Checked = true; //chkHeader.Enabled = false;

                }
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkSel = (CheckBox)e.Row.FindControl("chkSel");
                    chkSel.Checked = true; //chkSel.Enabled = false;
                    decimal Approvalfee = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CFDA_ADDITONALFEE"));
                    TotFee = TotFee + Approvalfee;
                    Label lblAmount = (Label)e.Row.FindControl("lblAmount");
                    if (ViewState["Amount"] == null)
                    {
                        ViewState["Amount"] = 0;
                    }
                    decimal PrvAmount = Convert.ToDecimal(ViewState["Amount"].ToString());
                    decimal TotalPaymentAmount;


                    TotalPaymentAmount = PrvAmount + Convert.ToDecimal(lblAmount.Text);


                    lblPaymentAmount.InnerText = TotalPaymentAmount.ToString();
                    ViewState["Amount"] = TotalPaymentAmount.ToString();
                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[3].Text = "Total";
                    e.Row.Cells[4].Text = TotFee.ToString();
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkHeaderCheck = (CheckBox)sender;

            foreach (GridViewRow gRow in grdTrackerDetails.Rows)
            {
                CheckBox ckRowSel = (CheckBox)gRow.FindControl("chkSel");
                ckRowSel.Checked = chkHeaderCheck.Checked;
            }
        }

    }
}