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
using MeghalayaUIP.DAL.CommonDAL;
using Newtonsoft.Json;
using Razorpay.Api;

namespace MeghalayaUIP.User.Payments
{
    public partial class RazorPaymentPage : System.Web.UI.Page
    {
        CFEBAL objcfebal = new CFEBAL();
        public string orderId, InvestorId, KeyId, secret, PayAmount, Name, Desc, Mail, Contact, IpAddress, Notes, CallbackUrl, Cancelurl;
        public string UnitID = "", Module = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["UserInfo"] != null)
                {
                    if (!Page.IsPostBack)
                    {
                        var ObjUserInfo = new UserInfo(); string Receiptorder = "";
                        if (Session["UserInfo"] != null && Session["UserInfo"].ToString() != "")
                        {
                            ObjUserInfo = (UserInfo)Session["UserInfo"];
                            Session["INSTRIDPM"] = ObjUserInfo.Userid.ToString();
                            decimal orderAmount = Convert.ToDecimal(Session["PaymentAmount"].ToString()) * 100;
                            if (Request.QueryString["receipt"] != null)
                            {
                                Receiptorder = Request.QueryString["receipt"].ToString();
                            }
                            Dictionary<string, object> input = new Dictionary<string, object>();
                            input.Add("amount", orderAmount);
                            input.Add("currency", "INR");
                            input.Add("receipt", Receiptorder);
                            KeyId = System.Configuration.ConfigurationManager.AppSettings["PGKey"];
                            secret = System.Configuration.ConfigurationManager.AppSettings["PGSecret"];

                            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                            RazorpayClient client = new RazorpayClient(KeyId, secret);
                            Razorpay.Api.Order order = client.Order.Create(input);
                            orderId = order["id"].ToString();

                            string Receipt = ""; decimal Amount;
                            if (Request.QueryString["receipt"] != null)
                            {
                                Receipt = Request.QueryString["receipt"].ToString();
                            }
                            Amount = Convert.ToDecimal(Session["PaymentAmount"].ToString()) * 100;
                         
                            if (Request.QueryString["Module"] != null)
                            {
                                if (Convert.ToString(Request.QueryString["Module"]) == "LAND")
                                {
                                    UnitID = Convert.ToString(Session["LANDUNITID"]);
                                    Module = "LAND";
                                }
                                if (Convert.ToString(Request.QueryString["Module"]) == "CFE")
                                { UnitID = Convert.ToString(Session["CFEUNITID"]);
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
                            }
                            DataSet dspaydtls = new DataSet();
                            dspaydtls = objcfebal.GetUnitDetailsforPayment(UnitID, Session["INSTRIDPM"].ToString(), Module);
                            if (dspaydtls != null && dspaydtls.Tables.Count > 0 && dspaydtls.Tables[0].Rows.Count > 0)
                            {
                                UIPPayments pay = new UIPPayments();
                                pay.PayAmount = Amount.ToString();
                                pay.Name = dspaydtls.Tables[0].Rows[0]["REP_NAME"].ToString();
                                pay.Desc = "Meghalaya Description";
                                pay.Mail = dspaydtls.Tables[0].Rows[0]["REP_EMAIL"].ToString();
                                pay.Contact = dspaydtls.Tables[0].Rows[0]["REP_MOBILE"].ToString();
                                pay.Notes = "Hyderabad";
                                string BaseUrl = System.Configuration.ConfigurationManager.AppSettings["PGReturnurl"];
                                CallbackUrl = BaseUrl + "?Module=" + Module + "&UnitID=" + UnitID;


                                Cancelurl = System.Configuration.ConfigurationManager.AppSettings["PGCancelurl"];
                                pay.IpAddress = getclientIP();
                                Dictionary<string, string> notes = new Dictionary<string, string>()
                                {
                                    {"Note1","Payment Note1" },{"Note2","Payment Note2" }
                                };

                                //string A = objcfebal.InsertPaymentRequest(UnitID,Module, Session["INSTRIDPM"].ToString(), Receiptorder, orderId, PayAmount, Name, Desc, Mail, Contact, Notes, IpAddress);
                                string A = objcfebal.InsertPaymentRequest(pay);
                            }
                        }
                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
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