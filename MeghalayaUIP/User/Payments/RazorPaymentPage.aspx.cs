using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using iText.Layout.Borders;
using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.Common;
using Newtonsoft.Json;
using Razorpay.Api;

namespace MeghalayaUIP.User.Payments
{
    public partial class RazorPaymentPage : System.Web.UI.Page
    {
        CFEBAL objcfebal = new CFEBAL();
        public string orderId;
        public string InvestorId; 
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["UserInfo"] != null)
                    {
                        var ObjUserInfo = new UserInfo(); string Receiptorder = "";
                        if (Session["UserInfo"] != null && Session["UserInfo"].ToString() != "")
                        {
                            ObjUserInfo = (UserInfo)Session["UserInfo"];
                            Session["INSTRIDPM"] = ObjUserInfo.Userid.ToString();
                            int orderAmount = Convert.ToInt32(Session["PaymentAmount"].ToString()) * 100;
                            if (Request.QueryString["receipt"] != null)
                            {
                                Receiptorder = Request.QueryString["receipt"].ToString();
                            }
                            Dictionary<string, object> input = new Dictionary<string, object>();
                            input.Add("amount", orderAmount);
                            input.Add("currency", "INR");
                            input.Add("receipt", Receiptorder);

                            string key = "rzp_test_q9BWc8q5PkutRv";
                            string secret = "8916qyvOByxlwtx3U229pdB0";
                            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                            RazorpayClient client = new RazorpayClient(key, secret);

                            Razorpay.Api.Order order = client.Order.Create(input);
                            orderId = order["id"].ToString();

                            string Receipt = ""; int Amount;
                            if (Request.QueryString["receipt"] != null)
                            {
                                Receipt = Request.QueryString["receipt"].ToString();
                            }
                            Amount = Convert.ToInt32(Session["PaymentAmount"].ToString()) * 100;
                            string UnitID = Convert.ToString(Session["CFEUNITID"]);



                            DataSet dspaydtls = new DataSet();
                            dspaydtls = objcfebal.GetUnitDetailsforPayment(UnitID, Session["INSTRIDPM"].ToString());

                            if (dspaydtls != null && dspaydtls.Tables.Count > 0 && dspaydtls.Tables[0].Rows.Count > 0)
                            {
                                string currency = "INR"; var ImageLogo = "";
                                string KeyId=hdn_key_id.Value = "rzp_test_q9BWc8q5PkutRv";
                                string OrderId=hdn_order_id.Value = orderId;
                                string PayAmount=hdn_amount.Value = Amount.ToString();
                                string Name=hdn_name.Value = dspaydtls.Tables[0].Rows[0]["REP_NAME"].ToString();
                                string Desc=hdn_description.Value = "Meghalaya Description";
                                string Mail=hdn_email.Value = dspaydtls.Tables[0].Rows[0]["REP_EMAIL"].ToString();
                                string Contact = hdn_contact.Value = dspaydtls.Tables[0].Rows[0]["REP_MOBILE"].ToString();
                                string IpAddress= getclientIP();

                                Dictionary<string, string> notes = new Dictionary<string, string>()
                                {
                                    {"Note1","Payment Note1" },{"Note2","Payment Note2" }
                                };
                                hdn_notes.Value = JsonConvert.SerializeObject(notes);

                                string A = objcfebal.InsertPaymentRequest(UnitID, Session["INSTRIDPM"].ToString(), Receiptorder, OrderId, PayAmount, Name, Desc, Mail, Contact,"", IpAddress);

                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                string errorMsg = ex.Message;
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

        protected void btnPay_Click(object sender, EventArgs e)
        {
            string Receipt = ""; int Amount;
            if (Request.QueryString["receipt"] != null)
            {
                Receipt = Request.QueryString["receipt"].ToString();
            }
            Amount = Convert.ToInt32(Session["PaymentAmount"].ToString()) * 100;
            string UnitID = Convert.ToString(Session["CFEUNITID"]);

            

            DataSet dspaydtls = new DataSet();
            dspaydtls = objcfebal.GetUnitDetailsforPayment(UnitID, Session["INSTRIDPM"].ToString());

            if (dspaydtls != null && dspaydtls.Tables.Count > 0 && dspaydtls.Tables[0].Rows.Count > 0)
            {
                var currency = "INR"; var ImageLogo = "";
                var Key ="rzp_test_q9BWc8q5PkutRv";
                var orderid = orderId;
                var amount = Amount.ToString();
                var name = dspaydtls.Tables[0].Rows[0]["REP_NAME"].ToString();
                var Desc  = "Meghalaya Description";
                var email = dspaydtls.Tables[0].Rows[0]["REP_EMAIL"].ToString();
                var Phone = dspaydtls.Tables[0].Rows[0]["REP_MOBILE"].ToString();

                Dictionary<string, string> notes = new Dictionary<string, string>()
                                {
                                    {"Note1","Payment Note1" },{"Note2","Payment Note2" }
                                };

                string jsFunction = "OpenPaymentWindow('" + Key + "','" + amount + "','" + currency + "','" + name + "','" + Desc + "','" + ImageLogo + "','" + orderid + "','" + email + "','" + Phone + "','" + JsonConvert.SerializeObject(notes) + "')";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenPaymentWindow", jsFunction, true);
            }
        }
    }
}