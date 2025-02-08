using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeghalayaUIP.Common
{
    internal class NSWSCommon
    {
    }
    public class NSWSConstants
    {

    }
    public class TokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("refresh_expires_in")]
        public int RefreshExpiresIn { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("not-before-policy")]
        public int NotBeforePolicy { get; set; }

        [JsonProperty("session_state")]
        public string SessionState { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }
    }
    public class CompanyInfo
    {
        public string PanNumber { get; set; }
        public string CinNumber { get; set; }
        public string SwsId { get; set; }
        public string NameAsPerPan { get; set; }
        public string GstIn { get; set; }
    }
    public class ApiResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<CompanyInfo> Data { get; set; }
    }

    public class ApiResponse_ACK
    {
        public bool Status { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public List<string> Data { get; set; }
    }




    public class ApprovalReq
    {
        public string addressOfTheBranch { get; set; }
        public string appliedOn { get; set; }
        public string approvalCertificate { get; set; }
        public string approvalDate { get; set; }
        public string approvalName { get; set; }
        public string approvalStatus { get; set; }
        public string approvalSubStatus { get; set; }
        public string branchName { get; set; }
        public string branchPinCode { get; set; }
        public string licenseCertificateNumber { get; set; }
        public string licenseId { get; set; }
        public string stateId { get; set; }
        public string swsId { get; set; }
    }

    public class License
    {
        public List<string> duplicateId { get; set; }
        public List<string> savedId { get; set; }
        public List<string> errorId { get; set; }
    }
    public class ApiResponse_License
    {
        public bool Status { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public License Data { get; set; }
    }

    public class ApiReq_UpdStsToNSWS
    {
        public string approvalCertificate { get; set; }
        public string approvalStatus { get; set; }
        public string approvalSubStatus { get; set; }
        public string licenseReqId { get; set; }

    }

    
    public class ApiResponse_UpdStsToNSWS
    {
        public bool Status { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public List<License> Data { get; set; }

    }

    public class ApiReq_FilePush
    {
        public string documentId { get; set; }
        public string documentName { get; set; }
        public string approvalId { get; set; }
        public string swsId { get; set; }
        public string investorReqId { get; set; }
        public string mnstryDprtmntId { get; set; }
    }

    public class ApiResponse_FilePush
    {
        public bool Status { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public String contentId { get; set; }
    }

    public class ApiResponse_Token
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public int refresh_expires_in { get; set; }
        public string refresh_token { get; set; }
        public string token_type { get; set; }
        public int not_before_policy { get; set; }
        public string session_state { get; set; }
        public string scope { get; set; }
        public int StatusCode { get; set; }
    }








}
