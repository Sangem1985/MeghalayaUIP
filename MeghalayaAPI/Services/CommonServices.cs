using MeghalayaAPI.Models;
using MeghalayaUIP.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static System.Net.WebRequestMethods;

namespace MeghalayaAPI.Services
{
    public class CommonServices
    {




        public async Task<ApiResponse> GetPanDetailsAsync(string stateId)
        {
            using (var client = new HttpClient())
            {
                // Set the request headers to accept JSON
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Prepare the URL for the GET request with the state_id as a query parameter
                string url = ConfigurationManager.AppSettings["GetPanDetailsUrl"].ToString()+ stateId;

                // Send GET request
                HttpResponseMessage response = await client.PostAsync(url, null).ConfigureAwait(false);

                // Check if the response status code is successful (200 OK)
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as string
                    var responseData = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response into ApiResponse object
                    return JsonConvert.DeserializeObject<ApiResponse>(responseData);
                }
                else
                {
                    // Handle error (you can throw an exception or handle it as needed)
                    throw new Exception($"Request failed with status code: {response.StatusCode}");
                }
            }
        }



        public async Task<ApiResponse_ACK> ACKPanDetailsAsync(List<string> consumedSwsIds, string stateId)
        {
            using (var client = new HttpClient())
            {
                // Set the request headers to accept JSON
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Prepare the URL for the POST request
                string url = ConfigurationManager.AppSettings["AckPanUrl"].ToString();

                // Create the request body object
                var Json_body = new
                {
                    consumedSwsIds = consumedSwsIds,
                    state_id = stateId
                };

                // Serialize the object to JSON string
                var JsonDetail = JsonConvert.SerializeObject(Json_body, Formatting.Indented);

                // Create HttpContent to send the JSON in the request body
                var content = new StringContent(JsonDetail, Encoding.UTF8, "application/json");

                // Send the POST request with the JSON content
                HttpResponseMessage response = await client.PostAsync(url, content).ConfigureAwait(false);

                // Check if the response status code is successful (200 OK)
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as string
                    var responseData = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response into ApiResponse_ACK object
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse_ACK>(responseData);

                    // Set the StatusCode in the ApiResponse_ACK object
                    apiResponse.StatusCode = (int)response.StatusCode;

                    // Return the ApiResponse_ACK object
                    return apiResponse;
                }
                else
                {
                    // Handle error (you can throw an exception or handle it as needed)
                    throw new Exception($"Request failed with status code: {response.StatusCode}");
                }
            }
        }


        public async Task<ApiResponse_License> GetLicenseIdAsync()
        {
            using (var client = new HttpClient())
            {
                // Set the request headers to accept JSON
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Prepare the URL for the POST request
                string url = ConfigurationManager.AppSettings["GetLicenseIdUrl"].ToString();

                // Create the request body object
                var Json_body = new List<ApprovalReq>
                {
                    new ApprovalReq
                    {
                        appliedOn = "1735838774",
                        approvalName = "NOC for extraction of Ground water / borewell",
                        approvalStatus = "A",
                        licenseId = "S025_D036_A0001",
                        stateId = "24",
                        swsId = "SW1927919137",
                        approvalDate = "1735838774"
                    }
                };
                

                // Serialize the object to JSON string
                var JsonDetail = JsonConvert.SerializeObject(Json_body, Formatting.Indented);

                // Create HttpContent to send the JSON in the request body
                var content = new StringContent(JsonDetail, Encoding.UTF8, "application/json");

                // Send the POST request with the JSON content
                HttpResponseMessage response = await client.PostAsync(url, content).ConfigureAwait(false);

                // Check if the response status code is successful (200 OK)
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as string
                    var responseData = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response into ApiResponse_ACK object
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse_License>(responseData);

                    // Set the StatusCode in the ApiResponse_ACK object
                    apiResponse.StatusCode = (int)response.StatusCode;

                    // Return the ApiResponse_ACK object
                    return apiResponse;
                }
                else
                {
                    // Handle error (you can throw an exception or handle it as needed)
                    throw new Exception($"Request failed with status code: {response.StatusCode}");
                }
            }
        }


        public async Task<string> PushDocumentAndGetApprovalCertificateAsync()
        {
            string WebUrlpushDocument = ConfigurationManager.AppSettings["PushDocUrl"].ToString();
            string fileUrl = "https://invest.meghalaya.gov.in/PdfFile.ashx?enc=nE5VexuHl3OJNqp7KTJ7Mm2G4LQc0rAfco/B6NFw1zZNjpPlVXrGbRjVpqjz2tz9BFQAy7+mCgCs8owsp2U+6tfvNGMWVMs7kumhmbCg0poFWgNRB1J94VuDgcPs6WLcXBI70s+k2yKgrfvgqa4UeVqVfnT/GyHea6sH83jOGnI45CEWmKR+dlZ72QUGTTwiCmLQJqiYfIs1Zt0eoCcqH8P2GEuoC6rY7rkB2Vxp0gjzHev1B4nuykJFPB2fvOvwupE5KBqWEqCEWlOPZEYk1LHWowoubclGv3ci5QKsr+B5A34b9nGN/tJuzQzLBlpqdstAaNs30jKC33Sj8SCCj8nsbuwI6Rfcgr93guuKuqsqd1a8f8WotclHbhHR7WwV";

            const string boundary = "----BoundaryString";

            // Prepare HttpWebRequest for document push
            var pushrequest = (HttpWebRequest)WebRequest.Create(WebUrlpushDocument);
            pushrequest.Method = "POST";
            pushrequest.ContentType = "multipart/form-data; boundary=" + boundary;
            pushrequest.Headers.Add("api-key", "Min1@PD02");
            pushrequest.Headers.Add("access-id", "MIN_TEST_0");
            pushrequest.Headers.Add("access-secret", "MintesT@1234");

            try
            {
                // Define the request payload model
                ApiReq_FilePush request = new ApiReq_FilePush
                {
                    documentId = "MDOC000099",
                    documentName = "License Certificate",
                    approvalId = "SW7928467561-S009_D011_A0001-1733324444000",
                    swsId = "SW1927919137",
                    investorReqId = "339130",
                    mnstryDprtmntId = "S009_D011_A0001"
                };

                // Serialize the request object to JSON
                string jsonPayload = JsonConvert.SerializeObject(request);

                // Write multipart form data (file + JSON payload)
                using (var stream = pushrequest.GetRequestStream())
                {
                    WriteMultipartFormData(stream, fileUrl, jsonPayload, boundary);
                }

                // Get response and extract contentId (approval certificate)
                using (var response = (HttpWebResponse)pushrequest.GetResponse())
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string responseText = await reader.ReadToEndAsync();
                    

                    // Parse response and return approval certificate (contentId)
                    var jsonResponse = JObject.Parse(responseText);
                    return jsonResponse["response"]?["contentId"]?.ToString();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                ErrorLog.LogData(Convert.ToString(ex), "GetCompanyDetails");
                ErrorLog.LogerrorDB(ex, "Service");
                return null;
            }
        }


        private void WriteMultipartFormData(Stream stream, string fileUrl, string jsonPayload, string boundary)
        {
            var boundaryBytes = Encoding.ASCII.GetBytes("--" + boundary + "\r\n");
            var newLineBytes = Encoding.ASCII.GetBytes("\r\n");

            // File Part
            stream.Write(boundaryBytes, 0, boundaryBytes.Length);
            string fileHeader = $"Content-Disposition: form-data; name=\"file\"; filename=\"file.pdf\"\r\nContent-Type: application/octet-stream\r\n\r\n";
            byte[] fileHeaderBytes = Encoding.UTF8.GetBytes(fileHeader);
            stream.Write(fileHeaderBytes, 0, fileHeaderBytes.Length);

            // Fetch file bytes from the URL
            byte[] fileData = new WebClient().DownloadData(fileUrl);
            stream.Write(fileData, 0, fileData.Length);
            stream.Write(newLineBytes, 0, newLineBytes.Length);  // New line after file content

            // JSON Part
            stream.Write(boundaryBytes, 0, boundaryBytes.Length);
            string jsonHeader = "Content-Disposition: form-data; name=\"requestJson\"\r\nContent-Type: application/json\r\n\r\n";
            byte[] jsonHeaderBytes = Encoding.UTF8.GetBytes(jsonHeader);
            stream.Write(jsonHeaderBytes, 0, jsonHeaderBytes.Length);

            // Write JSON payload
            byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonPayload);
            stream.Write(jsonBytes, 0, jsonBytes.Length);
            stream.Write(newLineBytes, 0, newLineBytes.Length);  // New line after JSON content

            // Closing Boundary
            byte[] closingBoundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            stream.Write(closingBoundaryBytes, 0, closingBoundaryBytes.Length);
        }





        public async Task<ApiResponse_License> UpdateToNSWSAsync()
        {
            string LicenseId = string.Empty;
            ApiResponse_License apiResponse_License = await GetLicenseIdAsync();
            if (apiResponse_License != null && apiResponse_License.Data != null)
            {
                // Check if the savedId list has valid IDs
                if (apiResponse_License.Data.savedId != null && apiResponse_License.Data.savedId.Count > 0)
                {
                    LicenseId = apiResponse_License.Data.savedId[0]; // Use the first saved ID
                }
                // If no valid savedId, check duplicateId
                else if (apiResponse_License.Data.duplicateId != null && apiResponse_License.Data.duplicateId.Count > 0)
                {
                    LicenseId = apiResponse_License.Data.duplicateId[0];  // Optionally use the first duplicate ID
                }
                // If no valid savedId or duplicateId, check errorId (handle it if necessary)
                else if (apiResponse_License.Data.errorId != null && apiResponse_License.Data.errorId.Count > 0)
                {
                    Console.WriteLine("Error IDs are present in the response.");
                }
            }
            string ApprovalCertificate = await PushDocumentAndGetApprovalCertificateAsync();

            using (var client = new HttpClient())
            {

                // Set the request headers to accept JSON
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Prepare the URL for the POST request
                string url = ConfigurationManager.AppSettings["UpdateToNSWSUrl"].ToString();

                // Create the request body object
                var Json_body = new List<ApiReq_UpdStsToNSWS>
                {
                    new ApiReq_UpdStsToNSWS
                    {
                         approvalCertificate = ApprovalCertificate,// "SW7150889414-MDOC000099-#DFLT#-$ORGID$-2",
                         approvalStatus  = "A",
                         approvalSubStatus  = "The request is approved by first level authority, Payment pending",
                         licenseReqId = LicenseId
                    }
                };

                // Serialize the object to JSON string
                var JsonDetail = JsonConvert.SerializeObject(Json_body, Formatting.Indented);

                // Create HttpContent to send the JSON in the request body
                var content = new StringContent(JsonDetail, Encoding.UTF8, "application/json");

                // Send the POST request with the JSON content
                HttpResponseMessage response = await client.PostAsync(url, content).ConfigureAwait(false);

                // Check if the response status code is successful (200 OK)
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as string
                    var responseData = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response into ApiResponse_ACK object
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse_License>(responseData);

                    // Set the StatusCode in the ApiResponse_ACK object
                    apiResponse.StatusCode = (int)response.StatusCode;

                    // Return the ApiResponse_ACK object
                    return apiResponse;
                }
                else
                {
                    // Handle error (you can throw an exception or handle it as needed)
                    throw new Exception($"Request failed with status code: {response.StatusCode}");
                }
            }
        }


        public async Task<ApiResponse_Token> GetAccessTokenAsync(string username, string password)
        {
            using (var client = new HttpClient())
            {
                // Set the request headers for URL-encoded form data
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Prepare the URL for the POST request
                string url = ConfigurationManager.AppSettings["GetTokenUrl"].ToString();

                // Create the URL-encoded body parameters for the token request
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("client_id", "sws_state"),
                    new KeyValuePair<string, string>("username", username),  // User's email
                    new KeyValuePair<string, string>("password", password),  // User's password
                    new KeyValuePair<string, string>("client_secret", "643790eb-2b2a-4187-8c43-54a663b840eb")
                });

                // Send the POST request with the URL-encoded content
                HttpResponseMessage response = await client.PostAsync(url, content).ConfigureAwait(false);

                // Check if the response status code is successful (200 OK)
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as string
                    var responseData = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response into ApiResponse_Token object
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse_Token>(responseData);

                    // Set the StatusCode in the ApiResponse_Token object
                    apiResponse.StatusCode = (int)response.StatusCode;

                    // Return the ApiResponse_Token object
                    return apiResponse;
                }
                else
                {
                    // Handle error (you can throw an exception or handle it as needed)
                    throw new Exception($"Request failed with status code: {response.StatusCode}");
                }
            }
        }


    }
}