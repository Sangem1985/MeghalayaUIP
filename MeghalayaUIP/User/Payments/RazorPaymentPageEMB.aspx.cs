using iText.Layout.Borders;
using MeghalayaUIP.BAL.CFEBLL;
using MeghalayaUIP.Common;
using Newtonsoft.Json;
using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP.User.Payments
{
    public partial class RazorPaymentPageEMB : System.Web.UI.Page
    {
        CFEBAL objcfebal = new CFEBAL();
        public string orderId;
        public string InvestorId;
        public string KeyId;
        public string secret;
        public string PayAmount;
        public string Name;
        public string Desc;
        public string Mail;
        public string Contact;
        public string IpAddress;
        public string Notes;
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
                            input.Add("amount", 100); 
                            input.Add("currency", "INR");
                            input.Add("receipt", Receiptorder);
                            input.Add("payment_capture", 1);


                            KeyId = "rzp_test_l9labd1MMZqwzK";
                            string secret = "iX44FqckwRPPRhuMmiltpKBd";

                            RazorpayClient client = new RazorpayClient(KeyId, secret);

                            
                            Razorpay.Api.Order order = client.Order.Create(input);

                            
                            orderId = order["id"].ToString();

                            string Receipt = ""; int Amount;
                            if (Request.QueryString["receipt"] != null)
                            {
                                Receipt = Request.QueryString["receipt"].ToString();
                            }
                            Amount = Convert.ToInt32(Session["PaymentAmount"].ToString()) * 100;
                            string UnitID = "", Module = "";

                            if (Request.QueryString["Module"] != null)
                            {
                                if (Convert.ToString(Request.QueryString["Module"]) == "LAND")
                                {
                                    UnitID = Convert.ToString(Session["LANDUNITID"]);
                                    Module = "LAND";                                   
                                }
                                if (Convert.ToString(Request.QueryString["Module"]) == "CFE")
                                {
                                    UnitID = Convert.ToString(Session["CFEUNITID"]);
                                    Module = "CFE";
                                }
                                if (Convert.ToString(Request.QueryString["Module"]) == "CFO")
                                {
                                    UnitID = Convert.ToString(Session["CFOUNITID"]);
                                    Module = "CFO";
                                }
                                if (Convert.ToString(Request.QueryString["Module"]) == "REN")
                                {
                                    UnitID = Convert.ToString(Session["RENQID"]);
                                    Module = "REN";
                                }
                                if (Convert.ToString(Request.QueryString["Module"]) == "SRVC")
                                {
                                    UnitID = Convert.ToString(Session["SRVCQID"]);
                                    Module = "SRVC";
                                }
                                hdncallback_url.Value = "https://localhost:44379/User/Payments/RazorPaymentResponse.aspx?Module=" +
                                     Module + "&UnitID=" + UnitID;
                            }
                            //string UnitID = Convert.ToString(Session["CFEUNITID"]);



                            DataSet dspaydtls = new DataSet();
                            dspaydtls = objcfebal.GetUnitDetailsforPayment(UnitID, Session["INSTRIDPM"].ToString(), Module);

                            if (dspaydtls != null && dspaydtls.Tables.Count > 0 && dspaydtls.Tables[0].Rows.Count > 0)
                            {   
                                PayAmount  = Amount.ToString();
                                Name =  dspaydtls.Tables[0].Rows[0]["REP_NAME"].ToString();
                                Desc = "Meghalaya Description";
                                Mail  = dspaydtls.Tables[0].Rows[0]["REP_EMAIL"].ToString();
                                Contact  = dspaydtls.Tables[0].Rows[0]["REP_MOBILE"].ToString();
                                Notes = "Hyderabad";
                                IpAddress = getclientIP();

                                Dictionary<string, string> notes = new Dictionary<string, string>()
                                {
                                    {"Note1","Payment Note1" },{"Note2","Payment Note2" }
                                };
                                //hdn_notes.Value = JsonConvert.SerializeObject(notes);


                                string A = objcfebal.InsertPaymentRequest(UnitID, Session["INSTRIDPM"].ToString(), Receiptorder, orderId, PayAmount, Name, Desc, Mail, Contact, Notes, IpAddress);

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

    }
}