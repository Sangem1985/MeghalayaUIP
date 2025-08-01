using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.BAL.CFOBAL;
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

namespace MeghalayaUIP.User.CFO
{
    public partial class CFOPaymentPage : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        CFEBAL objcfebal = new CFEBAL();
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
                    if (Convert.ToString(Session["CFOUNITID"]) != "")
                    {
                        UnitID = Convert.ToString(Session["CFOUNITID"]);
                    }
                    else
                    {
                        string newurl = "~/User/CFO/CFOUserDashboard.aspx";
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
                ds = objcfobal.GetPaymentAmounttoPay(hdnUserID.Value, Convert.ToString(Session["CFOUNITID"]));
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            hdnQuesID.Value = Convert.ToString(ds.Tables[0].Rows[0]["CFODA_CFOQDID"]);
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
        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                 Response.Redirect("~/User/CFO/CFOUploadEnclosures.aspx");
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
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    decimal Approvalfee = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CFODA_APPROVALFEE"));
                    TotFee = TotFee + Approvalfee;
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

                //string Orderno = "Bank" + DateTime.Now.Year + DateTime.Now.Month +
                //    DateTime.Now.Day + DateTime.Now.Minute + DateTime.Now.Year + DateTime.Now.Second + DateTime.Now.Millisecond;
                //string result;
                int count = 0;
                CFOPayments objpay = new CFOPayments();
                foreach (GridViewRow row in grdApprovals.Rows)
                {
                    CheckBox ChkSelect = (CheckBox)row.FindControl("chkSel");
                    if (ChkSelect.Checked == true)
                    {
                        Label ApprovalID = (Label)row.FindControl("lblApprID");
                        Label DeptID = (Label)row.FindControl("lblDeptID") as Label;

                        objpay.UNITID = Convert.ToString(Session["CFOUNITID"]);
                        objpay.Questionnareid = hdnQuesID.Value;
                        objpay.CFEUID = hdnUIDNo.Value;
                        objpay.DeptID = DeptID.Text;
                        objpay.ApprovalID = ApprovalID.Text;
                        objpay.OnlineOrderNo = receipt;
                        objpay.OnlineOrderAmount = row.Cells[4].Text;
                        objpay.PaymentFlag = "";
                        objpay.TransactionNo = "";
                        objpay.TransactionDate = DateTime.Now.ToString("yyyy-MM-dd");
                        objpay.BankName = "";
                        objpay.CreatedBy = hdnUserID.Value;
                        objpay.IPAddress = getclientIP();
                        TotalAmount = TotalAmount + Convert.ToDecimal(row.Cells[4].Text);

                        string A = objcfobal.InsertPaymentDetails(objpay);
                        if (A != "")
                        { count = count + 1; }
                    }
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


                /* if (grdApprovals.Rows.Count == count)
                 {
                     success.Visible = true;
                     lblmsg.Text = "Payment Details Submitted Successfully";
                     string message = "alert('" + lblmsg.Text + "')";
                     ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                 }*/

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
    }
}