using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeghalayaAPI.Models
{
    public class PropertiesModel
    {
    }
    public class TSIPASSPropertiesModel
    {
    }

    public class LoginResponse
    {
        public bool Response { get; set; }
    }
    public class LoginUserRequest
    {
        //USER DETAILS
        public string username { get; set; }
        public string password { get; set; }
        public string panno { get; set; }
        public string Encpassword { get; set; }

    }

    public class NSWSKeylcoakAttributes
    {
        public string fullName { get; set; }
        public string email { get; set; }
        public string mobileNumber { get; set; }
        public string entityType { get; set; }
        public string pan { get; set; }
        public string regAddress1 { get; set; }
        public string regAddress2 { get; set; }
        public string regCountry { get; set; }
        public string regState { get; set; }
        public string regCity { get; set; }
        public string regPincode { get; set; }
        public string postalAddress1 { get; set; }
        public string postalAddress2 { get; set; }
        public string postalCountry { get; set; }
        public string postalState { get; set; }
        public string postalCity { get; set; }
        public string postalPincode { get; set; }
        public string cin { get; set; }
        public string llpin { get; set; }
        public string cinData { get; set; }
        public string companyName { get; set; }
    }
    public class FinancialDetail
    {
        public string profitLoss { get; set; }
        public string turnOver { get; set; }
        public string year { get; set; }
    }

    public class CinDto
    {
        public string cin { get; set; }
        public string companyName { get; set; }
        public string companyStatus { get; set; }
        public string email { get; set; }
        public string financialAuditStatus { get; set; }
        public List<FinancialDetail> financialDetails { get; set; }
        public string incorpdate { get; set; }
        public string registeredAddress { get; set; }
        public string rocCode { get; set; }
    }

    public class DirectorDetails
    {
        public string contactNumber { get; set; }
        public string din { get; set; }
        public string name { get; set; }
    }

    public class DinDetail
    {
        public string dinName { get; set; }
        public string dinStatus { get; set; }
        public string dob { get; set; }
        public string fatherName { get; set; }
    }

    public class DirectorDetailDto
    {
        public DirectorDetails directorDetails { get; set; }
        public DinDetail dinDetail { get; set; }
    }

    public class RootObject
    {
        public CinDto cinDto { get; set; }
        public List<DirectorDetailDto> directorDetailDtos { get; set; }
    }

    #region TSIPASS insert user parmeters
    public class InsertUserDetailsResponse
    {
        public string TSIPASSUserID { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMesssage { get; set; }
    }
    public class InsertNSWSUserRequest
    {
        //USER DETAILS
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string username { get; set; }
        //  public string Password { get; set; }
        public string investorSwsId { get; set; }
        public string CreatedIP { get; set; }
        //public string Firstname { get; set; }
        //public string Lastname { get; set; }
        // public string Address { get; set; }
        //public string Location { get; set; }
        // public string PANcardno { get; set; }
        //  public string AadharNo { get; set; }
        //public string NSWSCAFID { get; set; }

    }
    #endregion

    #region nsws send redirection parmeters
    public class requestredirectionurlnsws
    {
        public string departmentId { get; set; }
        public string licenseId { get; set; }
        public string redirectionUrl { get; set; }
        public string stateId { get; set; }
        public string swsId { get; set; }
    }
    public class responseofredirectionurlnsws
    {
        public string status { get; set; }
        public string message { get; set; }
        public string data { get; set; }
    }

    #endregion


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class SubField
    {
        public string name { get; set; }
        public string fieldKey { get; set; }
    }

    public class Field
    {
        public string name { get; set; }
        public string fieldKey { get; set; }
        public string serialNumber { get; set; }
        public string inputValue { get; set; }
        public List<SubField> subFields { get; set; }
    }

    public class Section
    {
        public string name { get; set; }
        public List<Field> fields { get; set; }
        public string sectionKey { get; set; }
        public string serialNumber { get; set; }
    }

    public class Data
    {
        public string investorSWSId { get; set; }
        public long dateOfInitiation { get; set; }
        public List<Section> sections { get; set; }
        public List<string> stateLicenses { get; set; }
    }

    public class ResponseSvc
    {
        public bool status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }
}