using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using MeghalayaUIP.BAL.CFOBAL;
using MeghalayaUIP.CommonClass;
using System.Security.Policy;
using MeghalayaUIP.Common;

namespace MeghalayaUIP.User.CFO
{
    public partial class CFODepartmentServiceAPI : System.Web.UI.Page
    {
        CFOBAL objcfobal = new CFOBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            string uidno = "CTO/2025/1093/115";
            Int32 unitid = 1093;
            string deptid = "14";
            string approvalid = "3";

            DataSet dscommondetails = new DataSet();
            dscommondetails = objcfobal.GetCFOCommonDetails(uidno, deptid, approvalid, unitid);
            if (dscommondetails != null && dscommondetails.Tables.Count > 0 && dscommondetails.Tables[0].Rows.Count > 0)
            {
                string token = "";
                var JsonDetails = ""; //JsonConvert.SerializeObject(GWS);
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)48 | (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                string apiUrl = "https://uat.mepdcl.trm.ieasybill.com/api/Authorization/GenerateBearerToken";

                using (var client = new HttpClient())
                {

                    var postData = new Dictionary<string, string>
{
    { "Userid", "MIPA" },
    { "Password", "IIITS@2025#" }
};

                    var json = JsonConvert.SerializeObject(postData);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = client.PostAsync(apiUrl, content).Result;
                    MGCommonClass.LogData(content.ToString());
                    var result = response.Content.ReadAsStringAsync().Result;
                    MGCommonClass.LogData(result);

                    // Deserialize as a list since the response is a JSON array
                    var jsonList = JsonConvert.DeserializeObject<List<dynamic>>(result);

                    // Access the first object in the array
                    var json1 = jsonList[0];

                    // Extract the token
                    token = json1.token;
                    MGCommonClass.LogData("Token: " + token);
                    // Store or use the access token as needed
                }
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
                //request.Method = "POST"; // Set HTTP method (GET, POST, etc.)

                // Set bearer token in the Authorization header
                //request.Headers["Authorization"] = "Bearer" + token;
                string WEBSERVICE_URL = "https://uat.mepdcl.trm.ieasybill.com/api/collection/payments";
                try
                {
                    var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL);
                    if (webRequest != null)
                    {
                        webRequest.Method = "POST";
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";
                        webRequest.Headers["Authorization"] = "Bearer " + token;

                        // Create request body object
                        var requestBody = new
                        {
                            ApplicationNumber = dscommondetails.Tables[0].Rows[0]["ApplicationNumber"].ToString(),
                            ConnectionId = dscommondetails.Tables[0].Rows[0]["ConnectionId"].ToString(),
                            Application_Unique_id = dscommondetails.Tables[0].Rows[0]["Application_Unique_id"].ToString(),
                            LocationCode = dscommondetails.Tables[0].Rows[0]["LocationCode"].ToString(),
                            Amount = dscommondetails.Tables[0].Rows[0]["Amount"].ToString(),
                            TransactionDate = Convert.ToDateTime(dscommondetails.Tables[0].Rows[0]["TransactionDate"]).ToString("dd-MM-yyyy"), // Format: DD-MM-YYYY
                            ReceiptNumber = dscommondetails.Tables[0].Rows[0]["ReceiptNumber"].ToString(),
                            Transaction_Type = dscommondetails.Tables[0].Rows[0]["Transaction_Type"].ToString(), // Only: Cash, DD, RTGS
                            Debited_Acc_Num = dscommondetails.Tables[0].Rows[0]["Debited_Acc_Num"].ToString(), // Optional
                            Debited_acc_name = dscommondetails.Tables[0].Rows[0]["Debited_acc_name"].ToString(), // Optional
                            Debited_ifsc_code = dscommondetails.Tables[0].Rows[0]["Debited_ifsc_code"].ToString(), // Optional
                            Debited_bank_name = dscommondetails.Tables[0].Rows[0]["Debited_bank_name"].ToString(), // Optional
                            Debited_branch_name = dscommondetails.Tables[0].Rows[0]["Debited_branch_name"].ToString(), // Optional
                            UTRNumber = dscommondetails.Tables[0].Rows[0]["UTRNumber"].ToString() // Optional
                        };


                        // Convert to JSON string
                        string JsonDetails1 = JsonConvert.SerializeObject(requestBody);
                        MGCommonClass.LogData("Json Request: " + JsonDetails1);
                        // Convert JSON string to byte array
                        byte[] byteArray = Encoding.UTF8.GetBytes(JsonDetails1);

                        // Set content length
                        webRequest.ContentLength = byteArray.Length;

                        // Write JSON data to request body
                        using (Stream dataStream = webRequest.GetRequestStream())
                        {
                            dataStream.Write(byteArray, 0, byteArray.Length);
                        }

                        try
                        {
                            // Get response
                            using (WebResponse response = webRequest.GetResponse())
                            {
                                using (Stream responseStream = response.GetResponseStream())
                                {
                                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                                    string responseJson = reader.ReadToEnd();
                                    Console.WriteLine("Response: " + responseJson);
                                    MGCommonClass.LogData("Response : " + responseJson);
                                    if (responseJson.Contains("success"))
                                    {
                                        // Handle success
                                        CFODepartmentServiceApi objCfoDtls = new CFODepartmentServiceApi();
                                        objCfoDtls.UNITID = Convert.ToInt32(unitid).ToString();
                                        objCfoDtls.DeptId = deptid;
                                        objCfoDtls.ApprovalId = approvalid;
                                        objCfoDtls.Response = responseJson;
                                        objCfoDtls.APPLEVEL = "Y";
                                        objCfoDtls.CFOUID = uidno;
                                        objCfoDtls.IPAddress = getclientIP();


                                        string Result = objcfobal.CFODepartmentService(objCfoDtls);
                                    }
                                    else
                                    {
                                        CFODepartmentServiceApi objCfoDtls = new CFODepartmentServiceApi();
                                        objCfoDtls.UNITID = Convert.ToInt32(unitid).ToString();
                                        objCfoDtls.DeptId = deptid;
                                        objCfoDtls.ApprovalId = approvalid;
                                        objCfoDtls.Response = responseJson;
                                        objCfoDtls.APPLEVEL = "N";
                                        objCfoDtls.CFOUID = uidno;
                                        objCfoDtls.IPAddress = getclientIP();


                                        string Result = objcfobal.CFODepartmentService(objCfoDtls);
                                    }
                                }
                            }
                        }
                        catch (WebException ex)
                        {
                            if (ex.Response != null)
                            {
                                using (WebResponse errorResponse = ex.Response)
                                {
                                    using (Stream errorStream = errorResponse.GetResponseStream())
                                    {
                                        StreamReader reader = new StreamReader(errorStream, Encoding.GetEncoding("utf-8"));
                                        string errorText = reader.ReadToEnd();
                                        MGCommonClass.LogData("Error response: " + errorText);
                                    }
                                }
                            }
                        }


                       
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }
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