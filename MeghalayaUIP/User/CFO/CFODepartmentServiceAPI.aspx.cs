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

namespace MeghalayaUIP.User.CFO
{
    public partial class CFODepartmentServiceAPI : System.Web.UI.Page
    {
        CFOBAL objcfobal = new CFOBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            string uidno = "MIP_20258145202554690";
            Int32 unitid = 1057;
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
                    MGCommonClass.LogData(token);
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
                        //     webRequest.Headers.Add("token", "bd16b347e586f05339f830b3a85d8aefa8da92c1");
                        //webRequest.Headers =  "bd16b347e586f05339f830b3a85d8aefa8da92c1";
                        webRequest.Method = "POST";
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";
                        webRequest.Headers["Authorization"] = "Bearer " + token;

                        // Convert JSON string to byte array
                        byte[] byteArray = Encoding.UTF8.GetBytes(JsonDetails);

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
                                // Read response
                                using (Stream responseStream = response.GetResponseStream())
                                {
                                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                                    string responseJson = reader.ReadToEnd();
                                    Console.WriteLine("Response: " + responseJson);
                                    if (responseJson.Contains("success"))
                                    {
                                    }
                                }
                            }
                        }
                        catch (WebException ex)
                        {
                            // Handle exception
                            if (ex.Response != null)
                            {
                                using (WebResponse errorResponse = ex.Response)
                                {
                                    using (Stream errorStream = errorResponse.GetResponseStream())
                                    {
                                        StreamReader reader = new StreamReader(errorStream, Encoding.GetEncoding("utf-8"));
                                        string errorText = reader.ReadToEnd();
                                        Console.WriteLine("Error response: " + errorText);
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

    }
}