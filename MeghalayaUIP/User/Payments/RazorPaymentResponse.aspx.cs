using iText.Layout.Borders;
using MeghalayaUIP.BAL.CFEBLL;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Payments
{
    public partial class RazorPaymentResponse : System.Web.UI.Page
    {
        CFEBAL objcfebal = new CFEBAL();
        //public int Amount;
        string OrderNo = "";
        string OrderId = "";
        string Amount = "";
        string Module, UnitID;
        protected void Page_Load(object sender, EventArgs e)
        {
            string IpAddress = getclientIP();
            if (Request.QueryString.Count > 0)
            {
                Module=Convert.ToString(Request.QueryString["Module"]);
                UnitID = Convert.ToString(Request.QueryString["UnitID"]);
            }
            if (Request.Form["razorpay_payment_id"] != null)
            {
                string paymentId = Request.Form["razorpay_payment_id"].ToString();
                string OrderId = Request.Form["razorpay_order_id"].ToString().ToString();
                string Signature = Request.Form["razorpay_signature"].ToString().ToString();
                //Amount = Convert.ToInt32(Session["PaymentAmount"].ToString()) * 100;

                string key = "rzp_test_l9labd1MMZqwzK";
                string secret = "iX44FqckwRPPRhuMmiltpKBd";

                /*Please use below code to refund the payment   
                 Refund refund = new Razorpay.Api.Payment((string) paymentId).Refund();*/

                string generated_signature = ComputeSha256Hash(OrderId + "|" + paymentId, secret);
                /*if (Signature.ToLower() == generated_signature.ToLower())
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Equal')", true);
                    return;
                }*/


                string A = objcfebal.UpdatePaymentResponse(paymentId, OrderId, Signature, IpAddress);

                DataSet dspaydtls = new DataSet();
                dspaydtls = objcfebal.GetPaymentOrderNo(OrderId);
                if (dspaydtls != null && dspaydtls.Tables.Count > 0 && dspaydtls.Tables[0].Rows.Count > 0)
                {
                    Amount = dspaydtls.Tables[0].Rows[0]["PAYMENT_AMOUNT"].ToString();
                    OrderNo = dspaydtls.Tables[0].Rows[0]["ONLINE_ORDER_NO"].ToString();
                }

                txtOrderNumber.InnerText = OrderNo;
                txtOrderId.InnerText = paymentId;
                txtAmount.InnerText = "₹ " + Amount + ".00";
                divFail.Visible = false;
                divSuccess.Visible = true;
            }
            else
            {
                string jsonData = Request.Form["error[metadata]"].ToString();

                PaymentInfo paymentInfo = JsonConvert.DeserializeObject<PaymentInfo>(jsonData);

                string paymentId = paymentInfo.PaymentId;
                OrderId = paymentInfo.OrderId;

                string code = Request.Form["error[code]"].ToString();
                string description = Request.Form["error[description]"].ToString();
                string source = Request.Form["error[source]"].ToString();
                string step = Request.Form["error[step]"].ToString();
                string reason = Request.Form["error[reason]"].ToString();

                DataSet dspaydtls = new DataSet();
                dspaydtls = objcfebal.GetPaymentOrderNo(OrderId);
                if (dspaydtls != null && dspaydtls.Tables.Count > 0 && dspaydtls.Tables[0].Rows.Count > 0)
                {
                    Amount = dspaydtls.Tables[0].Rows[0]["PAYMENT_AMOUNT"].ToString();
                    OrderNo = dspaydtls.Tables[0].Rows[0]["ONLINE_ORDER_NO"].ToString();
                }

                txtOrderNumber.InnerText = OrderNo;
                txtOrderId.InnerText = paymentId;
                txtAmount.InnerText = "₹ " + Amount + ".00";
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
        public static string ComputeSha256Hash(string message, string key)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(key);

            HMACSHA256 hmacsha256 = new HMACSHA256(keyByte);

            byte[] messageBytes = encoding.GetBytes(message);
            byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
            return ByteToString(hashmessage);
        }
        public static string ByteToString(byte[] buff)
        {
            string sbinary = "";

            for (int i = 0; i < buff.Length; i++)
            {
                sbinary += buff[i].ToString("X2"); // hex format
            }
            return (sbinary);
        }
        public class PaymentInfo
        {
            [JsonProperty("payment_id")]
            public string PaymentId { get; set; }

            [JsonProperty("order_id")]
            public string OrderId { get; set; }
        }
    }
}