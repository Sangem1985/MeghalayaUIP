using MeghalayaUIP.BAL.SVRCBAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Services
{
    public partial class SVRCPaymentPage : System.Web.UI.Page
    {
        SVRCBAL objSrvcbal = new SVRCBAL();
        string Quid; Decimal TotFee;
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
                    if (Convert.ToString(Session["SRVCQID"]) != "")
                    {
                        Quid = Convert.ToString(Session["SRVCQID"]);
                    }
                    else
                    {
                        string newurl = "~/User/CFE/SRVCUserDashboard.aspx";
                        Response.Redirect(newurl);
                    }

                    Page.MaintainScrollPositionOnPostBack = true;

                    if (!IsPostBack)
                    {
                        BindData();
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
        protected void BindData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objSrvcbal.GetSRVCPaymentAmounttoPay(hdnUserID.Value, Quid);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            hdnQuesID.Value = Convert.ToString(Session["SRVCQID"]);
                            hdnUIDNo.Value = Convert.ToString(ds.Tables[0].Rows[0]["UIDNO"]);
                            grdApprovals.DataSource = ds.Tables[0];
                            grdApprovals.DataBind();
                            grdApprovals.Visible = true;
                        }
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

        protected void grdApprovals_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if(e.Row.RowType == DataControlRowType.Header)
                {
                    CheckBox chkHeader = (CheckBox)e.Row.FindControl("chkHeader");
                    chkHeader.Checked = true; chkHeader.Enabled = false;

                }
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkSel = (CheckBox)e.Row.FindControl("chkSel");
                    chkSel.Checked = true; chkSel.Enabled = false;
                    decimal Approvalfee = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SRVCDA_APPROVALFEE"));
                    TotFee = TotFee + Approvalfee;
                    lblPaymentAmount.InnerText = TotFee.ToString();
                    ViewState["Amount"] = TotFee.ToString();
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

                SRVCPayments SRVCPayment = new SRVCPayments();
                foreach (GridViewRow row in grdApprovals.Rows)
                {
                    CheckBox ChkSelect = (CheckBox)row.FindControl("chkSel");
                    if (ChkSelect.Checked == true)
                    {
                        Label ApprovalID = (Label)row.FindControl("lblApprID");
                        Label DeptID = (Label)row.FindControl("lblDeptID");

                        SRVCPayment.Questionnareid = Convert.ToString(Session["SRVCQID"]);
                        SRVCPayment.SRVCUID = hdnUIDNo.Value;
                        SRVCPayment.DeptID = DeptID.Text;
                        SRVCPayment.ApprovalID = ApprovalID.Text;
                        SRVCPayment.OnlineOrderNo = receipt;
                        SRVCPayment.OnlineOrderAmount = row.Cells[4].Text;
                        SRVCPayment.PaymentFlag = "";
                        SRVCPayment.TransactionNo = "";
                        SRVCPayment.TransactionDate = DateTime.Now.ToString("yyyy-MM-dd");
                        SRVCPayment.BankName = "";
                        SRVCPayment.CreatedBy = hdnUserID.Value;
                        SRVCPayment.IPAddress = getclientIP();
                        TotalAmount = TotalAmount + Convert.ToDecimal(row.Cells[4].Text);

                        string A = objSrvcbal.SRVCInsertPaymentDet(SRVCPayment);
                        if (A != "")
                        { count = count + 1; }
                    }
                }
                if (TotalAmount > 0)
                {
                    PaymentAmount = ((int?)TotalAmount).ToString();
                    Session["PaymentAmount"] = ((int?)TotalAmount).ToString();
                    Response.Redirect("~/User/Payments/RazorPaymentPage.aspx?receipt=" + receipt + "&Amount=" + PaymentAmount + "&Module=SRVC");
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

        protected void chkSel_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int selRowIndex = ((GridViewRow)(((CheckBox)sender).Parent.Parent)).RowIndex;
                CheckBox cb = (CheckBox)grdApprovals.Rows[selRowIndex].FindControl("chkSel");
                Label lblAmount = (Label)grdApprovals.Rows[selRowIndex].FindControl("lblAmount");
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
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }
        protected void chkHeader_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkHeaderCheck = (CheckBox)sender;

            foreach (GridViewRow gRow in grdApprovals.Rows)
            {
                CheckBox ckRowSel = (CheckBox)gRow.FindControl("chkSel");
                ckRowSel.Checked = chkHeaderCheck.Checked;
            }
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/User/Services/CDWMDetails.aspx?Previous=" + "P");

        }
    }
}