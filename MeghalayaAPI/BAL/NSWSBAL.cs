using MeghalayaAPI.DAL;
using MeghalayaAPI.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace MeghalayaAPI.BAL
{
    public class NSWSBAL
    {
        NSWSDAL ObjNswsdal = new NSWSDAL();
        public DataTable NSWSUserAuthentication(string Username, string Password)
        {
            return ObjNswsdal.NSWSUserAuthentication(Username, Password);
        }
        public InsertUserDetailsResponse NSWSINSERTUSERDetails(InsertNSWSUserRequest objRequest)
        {
            InsertUserDetailsResponse objResponse = new InsertUserDetailsResponse();
            try
            {
                string errormsg = ValidateFormControlsUserInsert(objRequest);
                if (errormsg.Trim().TrimStart() != "")
                {
                    objResponse.TSIPASSUserID = "";
                    objResponse.ResponseCode = Convert.ToString(ErrorLog.ErrorCodes.Failed).ToString();
                    objResponse.ResponseMesssage = errormsg;
                }
                else
                {
                    ErrorLog.LogData(objRequest.ToString(), "NSWSINSERTUSERDetails");
                    string i = ObjNswsdal.InsertNSWSOnlineUsers(objRequest);
                    if (i == "")
                    {
                        objResponse.TSIPASSUserID = "";
                        objResponse.ResponseCode = Convert.ToString(ErrorLog.ErrorCodes.Failed).ToString();
                        objResponse.ResponseMesssage = "Some thing went Wrong";
                    }
                    else if (i == "0")
                    {
                        objResponse.TSIPASSUserID = "";
                        objResponse.ResponseCode = Convert.ToString(ErrorLog.ErrorCodes.Failed).ToString();
                        objResponse.ResponseMesssage = "User already Exist";
                    }
                    else
                    {
                        objResponse.TSIPASSUserID = Convert.ToString(i);
                        objResponse.ResponseCode = Convert.ToString(ErrorLog.ErrorCodes.Success).ToString();
                        objResponse.ResponseMesssage = "Status Updated Successfully";
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
            }
            return objResponse;
        }
        public string ValidateFormControlsUserInsert(InsertNSWSUserRequest objRequest_validcheck)
        {
            int slno = 1;
            string ErrorMsg = "";
            try
            {
                object obj_test = objRequest_validcheck;
                if (obj_test == null)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter correct parmeters\\n";
                    slno = slno + 1;
                }
                else
                {
                    #region Userdetails

                    if (objRequest_validcheck.Fullname.TrimStart().TrimEnd().Trim() == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter Fullname\\n";
                        slno = slno + 1;
                    }
                    if (objRequest_validcheck.Email.TrimStart().TrimEnd().Trim() == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter Email\\n";
                        slno = slno + 1;
                    }
                    if (objRequest_validcheck.MobileNo.TrimStart().TrimEnd().Trim() == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter Mobile Number\\n";
                        slno = slno + 1;
                    }
                    if (objRequest_validcheck.username.TrimStart().TrimEnd().Trim() == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter username\\n";
                        slno = slno + 1;
                    }
                    if (objRequest_validcheck.investorSwsId.TrimStart().TrimEnd().Trim() == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter investorSwsId\\n";
                        slno = slno + 1;
                    }

                    if (objRequest_validcheck.username.TrimStart().TrimEnd().Trim() != objRequest_validcheck.Email.TrimStart().TrimEnd().Trim())
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Entered username and EmailID should be equal\\n";
                        slno = slno + 1;
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                ErrorMsg = ErrorMsg + Convert.ToString(ex);
                ErrorLog.LogError(ex);
            }
            return ErrorMsg;
        }

        #region  Nsws calling Token
        public string PostFormUrlEncoded(string NSWSinvestorSwsId)
        {
            string token = string.Empty;
            string tokenType = string.Empty;
            string expiresin = string.Empty;
            string refreshexpiresin = string.Empty;
            string refreshtoken = string.Empty;
            string notbeforepolicy = string.Empty;
            string session_state = string.Empty;
            string scope = string.Empty;

            try
            {
                //string url = "https://sso-uat-nsws.investindia.gov.in/auth/realms/madhyam/protocol/openid-connect/token";

                string client_id = ConfigurationManager.AppSettings["client_id"].ToString();
                string client_secret = ConfigurationManager.AppSettings["client_secret"].ToString();
                string grant_type = ConfigurationManager.AppSettings["grant_type"].ToString();
                string username = ConfigurationManager.AppSettings["username"].ToString();
                string password = ConfigurationManager.AppSettings["password"].ToString();

                string url = ConfigurationManager.AppSettings["AuthenticateNSWSUsertoken"].ToString();
                List<KeyValuePair<string, string>> allIputParams = new List<KeyValuePair<string, string>>();

                allIputParams.Add(new KeyValuePair<string, string>("client_id", client_id));
                allIputParams.Add(new KeyValuePair<string, string>("client_secret", client_secret));
                allIputParams.Add(new KeyValuePair<string, string>("grant_type", grant_type));
                allIputParams.Add(new KeyValuePair<string, string>("username", username));
                allIputParams.Add(new KeyValuePair<string, string>("password", password));

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                ErrorLog.LogData(url.ToString(), NSWSinvestorSwsId + "nswsposttokenurl");
                ErrorLog.LogData(allIputParams.ToString(), NSWSinvestorSwsId + "nswsposttokenparmeters");

                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Content = new FormUrlEncodedContent(allIputParams);
                var httpClient = new HttpClient();
                var response = httpClient.SendAsync(request).Result;

                ErrorLog.LogData(Convert.ToString(response), NSWSinvestorSwsId + "nswsresponsetokenurl");
                HttpStatusCode statusCode = response.StatusCode;

                if (Convert.ToString(statusCode) == "200" || Convert.ToString(statusCode) == "OK")
                {
                    using (HttpContent content = response.Content)
                    {
                        var json = content.ReadAsStringAsync();
                        ErrorLog.LogData(Convert.ToString(json), NSWSinvestorSwsId + "nswsresponsejsontokenurl");
                        JObject jobj = JsonConvert.DeserializeObject<dynamic>(json.Result);
                        ErrorLog.LogData(Convert.ToString(jobj), NSWSinvestorSwsId + "nswsresponsejobjecttokenurl");
                        token = jobj.Value<string>("access_token");
                        expiresin = jobj.Value<string>("expires_in");
                        refreshexpiresin = jobj.Value<string>("refresh_expires_in");
                        refreshtoken = jobj.Value<string>("refresh_token");
                        tokenType = jobj.Value<string>("token_type");
                        notbeforepolicy = jobj.Value<string>("not-before-policy");
                        session_state = jobj.Value<string>("session_state");
                        scope = jobj.Value<string>("scope");
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
            }
            return token;
        }
        #endregion

        #region  Nsws calling NSWS CAF Details
        public async Task<ResponseSvc> Getcafdetailsofnsws(string NSWSinvestorSwsId)
        {
            string authorizeToken = PostFormUrlEncoded(NSWSinvestorSwsId);

            // Initialization.  
            ResponseSvc responecafdetail = new ResponseSvc();
            // HTTP GET.  
            using (var client = new HttpClient())
            {
                try
                {
                    string StateID = ConfigurationManager.AppSettings["NSWSStateID"].ToString();
                    // string urldata = "https://uat-nsws.investindia.gov.in/gateway/form-builder/caf/public/SW8577172400/29";
                    string urldata = ConfigurationManager.AppSettings["AuthenticateNSWSCAFDETAILStoken"].ToString() + NSWSinvestorSwsId + "/" + StateID;
                    // Initialization  
                    string authorization = authorizeToken;
                    // Setting Authorization.  
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorization);
                    // Setting Base address.  
                    //client.BaseAddress = new Uri("https://uat-nsws.investindia.gov.in/gateway/form-builder/caf/public/" + NSWSinvestorSwsId + "/"+ StateID);
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["AuthenticateNSWSCAFDETAILStoken"].ToString() + NSWSinvestorSwsId + "/" + StateID);
                    // Setting content type.  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    // Initialization.  
                    HttpResponseMessage response = new HttpResponseMessage();
                    // HTTP GET  
                    response = await client.GetAsync(urldata).ConfigureAwait(false);
                    // General.LogData(Convert.ToString(response), NSWSinvestorSwsId + "nswscafresponse");
                    HttpStatusCode statusCode = response.StatusCode;

                    if (Convert.ToString(statusCode) == "200" || Convert.ToString(statusCode) == "OK")
                    {
                        using (HttpContent content = response.Content)
                        {
                            var json = content.ReadAsStringAsync().Result;
                            // General.LogData(Convert.ToString(json), NSWSinvestorSwsId + "nswscaf");
                            ResponseSvc rv = JsonConvert.DeserializeObject<ResponseSvc>(json);
                            bool status = rv.status;
                            string message = rv.message;
                            responecafdetail.status = Convert.ToBoolean(rv.status);
                            responecafdetail.message = rv.message;
                            Data d = (Data)rv.data;

                            long data_dateOfInitiation = 0;
                            string data_investorSWSId = "";
                            string nswsstatelicensecount = "";
                            string nswssectioncount = "";
                            if (d != null)
                            {
                                data_dateOfInitiation = d.dateOfInitiation;
                                data_investorSWSId = d.investorSWSId;
                                if (d.stateLicenses != null)
                                {
                                    nswsstatelicensecount = Convert.ToString(d.stateLicenses.Count);
                                }
                                if (d.sections != null)
                                {
                                    nswssectioncount = Convert.ToString(d.sections.Count);
                                }


                            }

                            #region main table

                            DataTable dt_responseinsertmain = new DataTable();
                            dt_responseinsertmain.Columns.Add("status", typeof(string));
                            dt_responseinsertmain.Columns.Add("message", typeof(string));
                            dt_responseinsertmain.Columns.Add("data_investorSWSId", typeof(string));
                            dt_responseinsertmain.Columns.Add("data_dateOfInitiation", typeof(string));
                            dt_responseinsertmain.Columns.Add("sectioncount", typeof(string));
                            dt_responseinsertmain.Columns.Add("statelicensecount", typeof(string));

                            DataRow drs_maintable = dt_responseinsertmain.NewRow();
                            drs_maintable["status"] = Convert.ToString(status);
                            drs_maintable["message"] = message;
                            drs_maintable["data_investorSWSId"] = data_investorSWSId;
                            drs_maintable["data_dateOfInitiation"] = data_dateOfInitiation;
                            drs_maintable["sectioncount"] = nswssectioncount;
                            drs_maintable["statelicensecount"] = nswsstatelicensecount;
                            dt_responseinsertmain.Rows.Add(drs_maintable);

                            #endregion

                            #region stateslicense
                            DataTable dt_responseinsertstates = new DataTable();
                            dt_responseinsertmain.Columns.Add("NSWSStateLicensceID", typeof(string));
                            // dt_responseinsertmain.Columns.Add("nswscafdetailsID", typeof(string));
                            if (!string.IsNullOrEmpty(nswsstatelicensecount))
                            {
                                if (status == true)
                                {
                                    if (d.stateLicenses != null)
                                    {
                                        if (d.stateLicenses.Count > 0)
                                        {

                                            //List<string> statelicensedata = d.stateLicenses;
                                            //dt_responseinsertstates = Common.ToDataTable(statelicensedata);
                                            string Datacolumnname = "NSWSStateLicensceID";
                                            dt_responseinsertstates = CommonDAL.ListToDataTable(d.stateLicenses, Datacolumnname);
                                        }
                                    }
                                }
                            }
                            #endregion

                            #region section data
                            DataTable dt_sectiondata = new DataTable();
                            dt_sectiondata.Columns.Add("sectionName", typeof(string));
                            dt_sectiondata.Columns.Add("Sectionkey", typeof(string));
                            dt_sectiondata.Columns.Add("SectionserialNumber", typeof(string));
                            dt_sectiondata.Columns.Add("fieldCount", typeof(string));
                            dt_sectiondata.Columns.Add("fieldname", typeof(string));
                            dt_sectiondata.Columns.Add("fieldKey", typeof(string));
                            dt_sectiondata.Columns.Add("fieldserialNumber", typeof(string));
                            dt_sectiondata.Columns.Add("fieldinputValue", typeof(string));
                            dt_sectiondata.Columns.Add("SubfieldCount", typeof(string));
                            dt_sectiondata.Columns.Add("Subfieldname", typeof(string));
                            dt_sectiondata.Columns.Add("SubfieldKey", typeof(string));
                            // dt_sectiondata.Columns.Add("nswscafdetailsID", typeof(string));
                            if (!string.IsNullOrEmpty(nswssectioncount))
                            {
                                if (status == true)
                                {
                                    if (d.sections != null)
                                    {
                                        if (d.sections.Count > 0)
                                        {
                                            List<Section> sectiondata = d.sections;

                                            string sectionName = "";
                                            string Sectionkey = "";
                                            string SectionserialNumber = "";
                                            string fieldCount = "";
                                            string fieldname = "";
                                            string fieldKey = "";
                                            string fieldserialNumber = "";
                                            string fieldinputValue = "";
                                            string SubfieldCount = "";
                                            string Subfieldname = "";
                                            string SubfieldKey = "";
                                            foreach (var r in sectiondata)
                                            {
                                                DataRow drs_sectionalldata = dt_sectiondata.NewRow();
                                                sectionName = r.name; ;
                                                Sectionkey = r.sectionKey;
                                                SectionserialNumber = r.serialNumber;


                                                if (r.fields != null)
                                                {
                                                    fieldCount = Convert.ToString(r.fields.Count);
                                                    List<Field> secfield = r.fields;
                                                    if (r.fields.Count > 0)
                                                    {
                                                        foreach (var sr in secfield)
                                                        //foreach (var sr in r.fields)
                                                        {

                                                            fieldname = sr.name;
                                                            fieldKey = sr.fieldKey;
                                                            fieldserialNumber = sr.serialNumber;
                                                            fieldinputValue = sr.inputValue;


                                                            if (sr.subFields != null)
                                                            {
                                                                SubfieldCount = Convert.ToString(sr.subFields.Count);
                                                                if (sr.subFields.Count > 0)
                                                                {
                                                                    foreach (var srr in sr.subFields)
                                                                    {
                                                                        drs_sectionalldata["sectionName"] = sectionName;
                                                                        drs_sectionalldata["Sectionkey"] = Sectionkey;
                                                                        drs_sectionalldata["SectionserialNumber"] = SectionserialNumber;
                                                                        drs_sectionalldata["fieldCount"] = fieldCount;
                                                                        drs_sectionalldata["fieldname"] = fieldname;
                                                                        drs_sectionalldata["fieldKey"] = fieldKey;
                                                                        drs_sectionalldata["fieldserialNumber"] = fieldserialNumber;
                                                                        drs_sectionalldata["fieldinputValue"] = fieldinputValue;
                                                                        drs_sectionalldata["SubfieldCount"] = SubfieldCount;
                                                                        drs_sectionalldata["Subfieldname"] = srr.name;
                                                                        drs_sectionalldata["SubfieldKey"] = srr.fieldKey;
                                                                        dt_sectiondata.Rows.Add(drs_sectionalldata);
                                                                        drs_sectionalldata = dt_sectiondata.NewRow();
                                                                        //string Subfieldname = "";
                                                                        //string SubfieldKey = "";
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    drs_sectionalldata["sectionName"] = sectionName;
                                                                    drs_sectionalldata["Sectionkey"] = Sectionkey;
                                                                    drs_sectionalldata["SectionserialNumber"] = SectionserialNumber;
                                                                    drs_sectionalldata["fieldCount"] = fieldCount;
                                                                    drs_sectionalldata["fieldname"] = fieldname;
                                                                    drs_sectionalldata["fieldKey"] = fieldKey;
                                                                    drs_sectionalldata["fieldserialNumber"] = fieldserialNumber;
                                                                    drs_sectionalldata["fieldinputValue"] = fieldinputValue;
                                                                    drs_sectionalldata["SubfieldCount"] = SubfieldCount;
                                                                    dt_sectiondata.Rows.Add(drs_sectionalldata);
                                                                    drs_sectionalldata = dt_sectiondata.NewRow();
                                                                }
                                                            }
                                                            else
                                                            {
                                                                drs_sectionalldata["sectionName"] = sectionName;
                                                                drs_sectionalldata["Sectionkey"] = Sectionkey;
                                                                drs_sectionalldata["SectionserialNumber"] = SectionserialNumber;
                                                                drs_sectionalldata["fieldCount"] = fieldCount;
                                                                drs_sectionalldata["fieldname"] = fieldname;
                                                                drs_sectionalldata["fieldKey"] = fieldKey;
                                                                drs_sectionalldata["fieldserialNumber"] = fieldserialNumber;
                                                                drs_sectionalldata["fieldinputValue"] = fieldinputValue;
                                                                dt_sectiondata.Rows.Add(drs_sectionalldata);
                                                                drs_sectionalldata = dt_sectiondata.NewRow();
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        drs_sectionalldata["sectionName"] = sectionName;
                                                        drs_sectionalldata["Sectionkey"] = Sectionkey;
                                                        drs_sectionalldata["SectionserialNumber"] = SectionserialNumber;
                                                        drs_sectionalldata["fieldCount"] = fieldCount;
                                                        dt_sectiondata.Rows.Add(drs_sectionalldata);
                                                    }
                                                }
                                                else
                                                {
                                                    drs_sectionalldata["sectionName"] = sectionName;
                                                    drs_sectionalldata["Sectionkey"] = Sectionkey;
                                                    drs_sectionalldata["SectionserialNumber"] = SectionserialNumber;
                                                    dt_sectiondata.Rows.Add(drs_sectionalldata);
                                                }

                                            }

                                        }
                                    }
                                }
                            }
                            #endregion


                            //int nswscafdetailsID = CFEDAL.DB_InsertnswsCAFmainDetailsbytesting(dt_responseinsertmain, dt_responseinsertstates, dt_sectiondata);
                        }
                    }



                }
                catch (Exception ex)
                {
                    ErrorLog.LogError(ex);
                }
            }
            return responecafdetail;

        }

        #endregion

    }
}