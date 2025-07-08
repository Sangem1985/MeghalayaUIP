using MeghalayaUIP.BAL.CFOBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.CFO
{
    public partial class CFOAddlPayment : System.Web.UI.Page
    {
        CFOBAL objcfobal = new CFOBAL();
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

                    if (!IsPostBack)
                    {
                        BindApplStatus();
                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
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
                //UnitID = "1007";
                dsApprovals = objcfobal.GetCFOTracker(hdnUserID.Value, UnitID, Request.QueryString[1].ToString());
                if (dsApprovals.Tables.Count > 0)
                {
                    if (dsApprovals.Tables[0].Rows.Count > 0)
                    {
                        grdTrackerDetails.DataSource = dsApprovals.Tables[0];
                        grdTrackerDetails.DataBind();
                        lblDOA.Text = Convert.ToString(dsApprovals.Tables[0].Rows[0]["DATEOFAPPLICATION"]);
                        hdnQuesID.Value = Convert.ToString(dsApprovals.Tables[0].Rows[0]["CFODA_CFOQDID"]);
                    }
                    if (dsApprovals.Tables[1].Rows.Count > 0)
                    {
                        lblUnitID.Text = Convert.ToString(dsApprovals.Tables[1].Rows[0]["CFOQD_CFOUIDNO"]);
                        lblUnitNmae.Text = Convert.ToString(dsApprovals.Tables[1].Rows[0]["CFOQD_COMPANYNAME"]);
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

                //string Orderno = "Bank" + DateTime.Now.Year + DateTime.Now.Month +
                //    DateTime.Now.Day + DateTime.Now.Minute + DateTime.Now.Year + DateTime.Now.Second + DateTime.Now.Millisecond;
                //string result;
                int count = 0;
                CFOPayments objpay = new CFOPayments();
                foreach (GridViewRow row in grdTrackerDetails.Rows)
                {

                    Label ApprovalID = (Label)row.FindControl("lblApprID");
                    Label DeptID = (Label)row.FindControl("lblDeptID") as Label;
                    Label Amount = (Label)row.FindControl("lblAmount");

                    objpay.UNITID = Convert.ToString(Session["CFOUNITID"]);
                    objpay.Questionnareid = hdnQuesID.Value;
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

                    string A = objcfobal.INSPaymentDetailsCFOAddl(objpay);
                    if (A != "")
                    { count = count + 1; }

                }
                if (TotalAmount > 0)
                {
                    PaymentAmount = ((int?)TotalAmount).ToString();
                    Session["PaymentAmount"] = ((int?)TotalAmount).ToString();
                    Response.Redirect("~/User/Payments/RazorPaymentPage.aspx?receipt=" + receipt + "&Amount=" + PaymentAmount + "&Module=CFO");
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
                    decimal Approvalfee = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CFODA_ADDITONALFEE"));
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