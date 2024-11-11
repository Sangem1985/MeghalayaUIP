using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Web;
using System.Security.Cryptography;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Web.UI;
using System.Xml;

namespace MeghalayaUIP.Common
{
    public class SMSandMail
    {
        string connstr = ConfigurationManager.ConnectionStrings["MIPASS"].ToString();
        public string SendSms(string UnitId, string InvestorId, string TemplateId, string transaction, string Module)
        {
            DataSet ds = new DataSet();
            string msg = "";
            ds = GetSMSData(UnitId, InvestorId, transaction, Module);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                bool ServerFlag = Convert.ToBoolean(ConfigurationManager.AppSettings["IsServer"].ToString());
                if (ServerFlag == true)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        try
                        {
                            msg = SendSingleSMS(ds.Tables[0].Rows[i]["MOBILENUMBER"].ToString(), ds.Tables[0].Rows[i]["SMSTEXT"].ToString(), ds.Tables[0].Rows[i]["TEMPLATEID"].ToString());
                            /*if (msg == "SUCCESS")
                            {*/
                                string strTo = ds.Tables[0].Rows[i]["MOBILENUMBER"].ToString();
                                string strMessage = ds.Tables[0].Rows[i]["SMSTEXT"].ToString();
                                string Template = ds.Tables[0].Rows[i]["TEMPLATEID"].ToString();
                                SMSANDMAILDetails(strTo, strMessage, UnitId, InvestorId, transaction, Module, Template, msg, "SMS");
                            /*}*/
                        }
                        catch (Exception ex)
                        {
                            string errorMsg = ex.Message;
                        }
                    }
                }
            }
            return msg;
        }
        public void SendEmail(string UnitId, string InvestorId,string transaction, string Module)
        {
            DataSet ds = new DataSet();
            ds = GetMaildata(UnitId, InvestorId, transaction, Module);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                bool ServerFlag = Convert.ToBoolean(ConfigurationManager.AppSettings["IsServer"].ToString());
                if (ServerFlag == true)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string NewAttachemntpath = "";
                        try
                        {
                            SendEmailSingle(ds.Tables[0].Rows[i]["TOMAILID"].ToString(), ds.Tables[0].Rows[i]["CCMAILIDS"].ToString(), ds.Tables[0].Rows[i]["MSUBJECT"].ToString(), ds.Tables[0].Rows[i]["BODY"].ToString(), NewAttachemntpath, Module, transaction, UnitId, InvestorId);
                        }
                        catch (Exception ex)
                        {
                            string errorMsg = ex.Message;
                        }

                    }
                }
            }
        }

        public DataSet GetSMSData(string UnitId, string InvestorId, string transaction, string Module)
        {
            DataSet ds = new DataSet();
            SqlConnection Scon = new SqlConnection(connstr);
            SqlDataAdapter da;
            try
            {
                da = new SqlDataAdapter("USP_GET_SMS_DATA", Scon);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@UNITID", SqlDbType.VarChar).Value = UnitId.ToString();
                da.SelectCommand.Parameters.Add("@INVESTORID", SqlDbType.VarChar).Value = InvestorId.ToString();
                da.SelectCommand.Parameters.Add("@TRANSACTION", SqlDbType.VarChar).Value = transaction.ToString();
                da.SelectCommand.Parameters.Add("@MODULE", SqlDbType.VarChar).Value = Module.ToString();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
        public DataSet GetMaildata(string UnitId, string InvestorId, string transaction, string Module)
        {
            DataSet ds = new DataSet();
            SqlConnection Scon = new SqlConnection(connstr);
            SqlDataAdapter da;
            try
            {
                da = new SqlDataAdapter("USP_GET_MAIL_DATA", Scon);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@UNITID", SqlDbType.VarChar).Value = UnitId.ToString();
                da.SelectCommand.Parameters.Add("@INVESTORID", SqlDbType.VarChar).Value = InvestorId.ToString();
                da.SelectCommand.Parameters.Add("@TRANSACTION", SqlDbType.VarChar).Value = transaction.ToString();
                da.SelectCommand.Parameters.Add("@MODULE", SqlDbType.VarChar).Value = Module.ToString();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
        public void SMSANDMAILDetails(string MobileNo, string SMSText, string UnitId, string InvestorId,
            string transaction, string Module, string Template, string msg, string Mode)
        {
            SqlConnection Scon = new SqlConnection(connstr);
            Scon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "USP_INS_SMS_MAIL_DTLS";
            try
            {
                cmd.Connection = Scon;
                cmd.Parameters.AddWithValue("@MOBILENO_EMAIL", Convert.ToString(MobileNo));
                cmd.Parameters.AddWithValue("@SMSTEXT", Convert.ToString(SMSText));
                cmd.Parameters.AddWithValue("@UNITID", Convert.ToString(UnitId));
                cmd.Parameters.AddWithValue("@INVESTORID", Convert.ToString(InvestorId));
                cmd.Parameters.AddWithValue("@MODULE", Convert.ToString(transaction));
                cmd.Parameters.AddWithValue("@SUBMODULE", Convert.ToString(Module));
                cmd.Parameters.AddWithValue("@SERVERRESPONSE", Convert.ToString(msg));
                cmd.Parameters.AddWithValue("@TEMPLATEID", Convert.ToString(Template));
                cmd.Parameters.AddWithValue("@MODE", Convert.ToString(Mode));
                cmd.ExecuteNonQuery();
                Scon.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Scon.Close();
                Scon.Dispose();
            }
        }
        public String SendSingleSMS(String mobileNo, String message, string templID)
        {
            String username = "IMA2024";
            String password = "IMA@Megha@2024";
            String senderid = "IMAMEG";
            String secureKey = "55040f3c-c20d-4351-bb39-f2146f39f69d";
            string strSMSAPIURL = System.Configuration.ConfigurationManager.AppSettings["SmsURL"];
            /*Latest Generated Secure Key*/

            Stream dataStream;
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            HttpWebRequest request = WebRequest.Create(strSMSAPIURL) as HttpWebRequest;
            request.ProtocolVersion = HttpVersion.Version10;
            request.KeepAlive = false;
            request.ServicePoint.ConnectionLimit = 1;

            ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
            request.Method = "POST";
            /*System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
            System.Net.ServicePointManager.CertificatePolicy= new */
            String encryptedPassword = encryptedPasswod(password);
            String NewsecureKey = hashGenerator(username.Trim(), senderid.Trim(), message.Trim(), secureKey.Trim());
            String smsservicetype = "singlemsg"; //For single message.
            String query = "username=" + HttpUtility.UrlEncode(username.Trim()) +
                "&password=" + HttpUtility.UrlEncode(encryptedPassword) +
                "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +
                "&content=" + HttpUtility.UrlEncode(message.Trim()) +
                "&mobileno=" + HttpUtility.UrlEncode(mobileNo) +
                "&senderid=" + HttpUtility.UrlEncode(senderid.Trim()) +
                "&key=" + HttpUtility.UrlEncode(NewsecureKey.Trim()) +
                "&templateid=" + HttpUtility.UrlEncode(templID.Trim());

            byte[] byteArray = Encoding.ASCII.GetBytes(query);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            String Status = ((HttpWebResponse)response).StatusDescription;
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            String responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }
        public void SendEmailSingle(string strTo, string CCmails, string EmailSubject, string EmailText,
            string AttachmentPath, string Module, string transaction, string UnitId, string InvestorId)
        {
            // string path = "";
            string EmailSend = "";
            string FromEmailId = "";
            string Password = "";

            try
            {
                try
                {
                    FromEmailId = Convert.ToString(ConfigurationManager.AppSettings["FromMail"]);
                    Password = Convert.ToString(ConfigurationManager.AppSettings["FromMailPwd"]);
                   
                    MailMessage message = new MailMessage(FromEmailId, strTo)
                    {
                        Subject = EmailSubject,
                        Body = EmailText
                    };
                    if ((Convert.ToString(ConfigurationManager.AppSettings["IsAttchmentsAllowed"]) == "true") && (Convert.ToString(AttachmentPath) != ""))
                    {
                        message.Attachments.Add(new Attachment(Convert.ToString(AttachmentPath)));
                    }
                    if (Convert.ToString(CCmails) != "")
                    {
                        foreach (string str4 in Convert.ToString(CCmails).Split(new char[] { ',' }))
                        {
                            message.CC.Add(new MailAddress(str4 ?? ""));
                        }
                    }
                    message.IsBodyHtml = Convert.ToString(ConfigurationManager.AppSettings["IsBodyHtml"]) == "true";
                    SmtpClient client = new SmtpClient
                    {
                        Host = Convert.ToString(ConfigurationManager.AppSettings["Host"]),
                        Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]),
                        UseDefaultCredentials = (Convert.ToString(ConfigurationManager.AppSettings["UseDefaultCredentials"]) != "true") ? false : true
                    };
                    if (!client.UseDefaultCredentials)
                    {
                        client.Credentials = new NetworkCredential(FromEmailId, Password);
                    }
                    client.EnableSsl = Convert.ToString(ConfigurationManager.AppSettings["EnableSsl"]) == "true";

                    client.Send(message);
                    EmailSend = "Y";

                    try
                    {   
                        SMSANDMAILDetails(strTo, EmailText, UnitId, InvestorId, transaction, Module,"","Email Sent Successfully","Email");
                    }
                    catch (Exception ex)
                    {
                        string errorMsg = ex.Message;
                        Console.WriteLine(ex.Message);
                    }
                }
                catch (Exception exception1)
                {
                    EmailSend = "N";
                    Console.WriteLine(exception1.Message);
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                Console.WriteLine(ex.Message);
            }
        }
        protected String encryptedPasswod(String password)
        {
            byte[] encPwd = Encoding.UTF8.GetBytes(password);
            HashAlgorithm sha1 = HashAlgorithm.Create("SHA1");
            byte[] pp = sha1.ComputeHash(encPwd);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in pp)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
        protected String hashGenerator(String Username, String sender_id, String message, String secure_key)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Username).Append(sender_id).Append(message).Append(secure_key);
            byte[] genkey = Encoding.UTF8.GetBytes(sb.ToString());
            HashAlgorithm sha1 = HashAlgorithm.Create("SHA512");
            byte[] sec_key = sha1.ComputeHash(genkey);
            StringBuilder sb1 = new StringBuilder();
            for (int i = 0; i < sec_key.Length; i++)
            {
                sb1.Append(sec_key[i].ToString("x2"));
            }
            return sb1.ToString();
        }
    }
}
