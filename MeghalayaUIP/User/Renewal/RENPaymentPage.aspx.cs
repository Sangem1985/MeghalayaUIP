using MeghalayaUIP.BAL.CommonBAL;
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

namespace MeghalayaUIP.User.Renewal
{
    public partial class RENPaymentPage : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        RenewalBAL objRenbal = new RenewalBAL();
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
                    if (Convert.ToString(Session["RENUNITID"]) != "")
                    {
                        UnitID = Convert.ToString(Session["RENUNITID"]);
                    }
                    else
                    {
                        string newurl = "~/User/Renewal/RENUserDashboard.aspx";
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
                ds = objRenbal.GetPaymentAmounttoPay(hdnUserID.Value, UnitID);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            //PE1001MEG15520241007
                            hdnQuesID.Value = Convert.ToString(Session["RENQID"]);
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
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    decimal Approvalfee = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "RENDA_APPROVALFEE"));
                    TotFee = TotFee + Approvalfee;
                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[2].Text = "Total";
                    e.Row.Cells[3].Text = TotFee.ToString();
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
                string Orderno = "Bank" + DateTime.Now.Year + DateTime.Now.Month +
                    DateTime.Now.Day + DateTime.Now.Minute + DateTime.Now.Year + DateTime.Now.Second + DateTime.Now.Millisecond;
               // string result;
                int count = 0;
                RENPayments objpay = new RENPayments();
                foreach (GridViewRow row in grdApprovals.Rows)
                {

                    Label ApprovalID = (Label)row.FindControl("lblApprID");
                    Label DeptID = (Label)row.FindControl("lblDeptID") as Label;

                    objpay.UNITID = Convert.ToString(Session["RENUNITID"]);
                    objpay.Questionnareid = Convert.ToString(Session["RENQID"]);
                    objpay.RENUID = hdnUIDNo.Value;
                    objpay.DeptID = DeptID.Text;
                    objpay.ApprovalID = ApprovalID.Text;
                    objpay.OnlineOrderNo = Orderno;
                    objpay.OnlineOrderAmount = row.Cells[3].Text;
                    objpay.PaymentFlag = "Y";
                    objpay.TransactionNo = "234432";
                    objpay.TransactionDate = DateTime.Now.ToString("yyyy-MM-dd");
                    objpay.BankName = "SBI";
                    objpay.CreatedBy = hdnUserID.Value;
                    objpay.IPAddress = getclientIP();

                    string A = objRenbal.InsertPaymentDetails(objpay);
                    if (A != "")
                    { count = count + 1; }

                }
                if (grdApprovals.Rows.Count == count)
                {

                    success.Visible = true;
                    lblmsg.Text = "Payment Details Submitted Successfully";
                    string message = "alert('" + lblmsg.Text + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/User/CFE/CFEUploadEnclosures.aspx");
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
    }
}