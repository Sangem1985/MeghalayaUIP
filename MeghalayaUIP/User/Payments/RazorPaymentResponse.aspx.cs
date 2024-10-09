using MeghalayaUIP.BAL.CFEBLL;
using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Payments
{
    public partial class RazorPaymentResponse : System.Web.UI.Page
    {
        CFEBAL objcfebal = new CFEBAL();
        public int Amount;
        string OrderNo = "";
        string OrderId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Request.Form["razorpay_payment_id"] != null)
            string IpAddress = getclientIP();
            if (Request.QueryString["error"] == null)
            {
                string paymentId = Request.QueryString["paymentid"].ToString();
                string OrderId = Request.QueryString["orderid"].ToString();
                string Signature = Request.QueryString["signature"].ToString();
                Amount = Convert.ToInt32(Session["PaymentAmount"].ToString()) * 100;

                Dictionary<string, object> input = new Dictionary<string, object>();
                input.Add("amount", Amount);

                string key = "rzp_test_q9BWc8q5PkutRv";
                string secret = "8916qyvOByxlwtx3U229pdB0";

                RazorpayClient client = new RazorpayClient(key, secret);

                Dictionary<string, string> attributes = new Dictionary<string, string>();

                attributes.Add("razorpay_payment_id", paymentId);
                attributes.Add("razorpay_order_id", OrderId);
                attributes.Add("razorpay_signature", Signature);

                Utils.verifyPaymentSignature(attributes);

                /*Please use below code to refund the payment   
                 Refund refund = new Razorpay.Api.Payment((string) paymentId).Refund();*/
               

                string A = objcfebal.UpdatePaymentResponse(paymentId, OrderId, Signature, IpAddress);

                txtOrderNumber.InnerText = Session["OrderNo"].ToString();
                txtOrderId.InnerText = paymentId;
                txtAmount.InnerText = "₹" + Session["PaymentAmount"].ToString() + ".00";
                divFail.Visible = false;
                divSuccess.Visible = true;
            }
            else 
            {
                string paymentId = Request.QueryString["paymentid"].ToString();
                Amount = Convert.ToInt32(Session["PaymentAmount"].ToString()) * 100;

                string code= Request.QueryString["error"].ToString();
                string description = Request.QueryString["errordesc"].ToString();
                string source = Request.QueryString["errorsource"].ToString();
                string step = Request.QueryString["errorstep"].ToString();
                string reason = Request.QueryString["errorreason"].ToString();

                txtOrderNumber.InnerText = Session["OrderNo"].ToString();
                txtOrderId.InnerText = paymentId;
                txtAmount.InnerText = "₹" + Session["PaymentAmount"].ToString() + ".00";
                divSuccess.Visible = false;
                string A = objcfebal.UpdatePaymentErrorResponse(paymentId, OrderId, "", IpAddress, code, description, source, step, reason);
                divFail.Visible = true;
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
    }
}