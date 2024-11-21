using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeghalayaUIP.Common
{
    public class RENConstants
    {
        public static string InsertRENPublicWorkDep = "USP_INSRENEWALWORKCONTRACTORDETAILS";
        public static string GetRenPublicWorkDep = "USP_GETRENEWALWORKCONTRACTORDETAILS";
        public static string InsertRENDrugLicDep = "USP_INSRENDRUGLICDETAILS";
        public static string InsertRenDrugDetails = "USP_INSRENDRUGDETAILS";
        public static string InsertDrugTesting = "USP_INSRENSTAFFTESTING";
        public static string InsertDrugManufactureDet = "USP_INSRENDRUGMANU";
        public static string InsertRenDrugItemDet = "USP_INSRENDARUGADDITIONALITEM";
        public static string GetRENDrugLicenseDetails = "USP_GETDRUGDETAILS";
        public static string InsertRenBusinessLicDet = "USP_INSRENBUSINESSDETAILS";
        public static string GetRenBusinessLicDetails = "USP_GETRENBUSINESSDETAILS";
        public static string InsertRenCinemaLicDetails = "USP_INSRENCINEMALICDETAILS";
        public static string GetRenCinemaLicDet = "USP_GETRENCINEMALICDET";
        public static string InsertRenContractLabourDetails = "USP_INSRENCONTRACTORLABOURDETAILS";
        public static string InsertRenConLoabourDetails = "USP_INSRENMANGERDETAILS";
        public static string GetRENContractDetails = "USP_GETRENCONTRACTORLABOURDETAILS";
        public static string InsertRenBoilerDetails = "USP_INSRENBOILERDETAILS";
        public static string GetBoilerDetails = "USP_GETRENBOILERDETAILS";
        public static string InsertRenShopEstablishmentDetails = "USP_INSRENSHOPESTABLISHMENT";
        public static string InsertRenShopesestablishLabourDetails = "USP_INSRENWORKPLACE";
        public static string InsertRenLabourEstablishmentDetails = "USP_INSEMPLOYEERSDETAILS";
        public static string InsertAttachmentDetails = "SP_INSERT_RENEWAL_ATTACHMENTS";
        public static string GetRenShopsEstablishment = "GET_RENEWALSHOPSESTABLISHMENT";
        public static string InsertRenPropertiesDetails = "USP_INSRENPROPERTIE";
        public static string InsertRenPatnerDetails = "USP_INSRENPATNERSHIP";
        public static string InsertRenLimitedCompanyDetails = "USP_RENLIMITEDCOMPANY";
        public static string InsertRenApplicationDetails = "USP_INSRENINDUSTRIEDETAILS";
        public static string GetRENApplicantDetails = "USP_GETRENINDUSTRIEDETAILS";
        public static string GetRENApprovalsReq = "USP_GETCFEAPPROVALSWITHFEE";
        public static string InsertRENSafteySecurityDetails = "USP_SAFETEYSECURITYDETAILS";
        public static string GetRenSafteySecurityDetails = "USP_GETSAFETEYSECURITYDETAILS";
        public static string InsertRenMigrantWorkDetails = "USP_INSRENMIGRANTWORK";
        public static string InsertRenContractorMigrantWorkDetails = "USP_INSRENCONTRACTORMIGRANT";
        public static string GetRENMigrantDetails = "USP_GETRENCONTRACTORMIGRANT";
        public static string InsertRENFactoryLicDetails = "USP_INSRENFACTORYLIC";
        public static string GetRenFactoriesLicenseDetails = "USP_GETRENFACTORYLIC";
        public static string GetRenApprovals = "USP_GETRENAPPROVALS";
        public static string GetRENapplications = "USP_GETRENEWALSUSERDASHBOARD";
        public static string InsertRenDeptApprovals = "USP_INS_RENDPETAPPROVALS";

        public static string GETANNUALTURNOVER = "USP_CHECK_ANNUALTURNOVER";
        public static string CFEENTERPRISETYPEDET = "USP_GETENTERPRISETYPEDET";

        public static string GetRENApplicationDet = "USP_GETRENAPPLICATIONDETAILS";


        public static string GetRENDashBoard = "USP_RENDASHBOARDCOUNT"; 
        public static string GetRENDashBoardView = "USP_RENDASHBOARDVIEW";

        public static string InsertRenLegalMetrologyDet = "USP_INSRENLEGALMETROLOGYDET";
        public static string GetLegalMetrologyDetails = "USP_GETRENLEGALMETROLOGY";

        //////------------------APPLIED APPROVALS--------------///////

        public static string GetAppliedApprovalIDs = "USP_GETRENAPPROVALIDS";

        /////////---------PAYMENT---------/////

        public static string InsertPaymentDetails = "USP_INSRENPAYMENTDETAILS";
        public static string GetRENApprovalsAmounttoPay = "USP_GETRENAPPROVALSAMOUNTTOPAY";

        public static string GetRENPaymentReceipt = "GET_RENPAYMENTRECEIPT";


    }

    public class RenPublicWorK
    {
        public string Questionnariid { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string ApplicantType { get; set; }
        public string PurposeApplicant { get; set; }
        public string ContractorReg { get; set; }
        public string TYPENAME { get; set; }
        public string TYPEAPPLICANT { get; set; }
        public string Director { get; set; }
        public string Circle { get; set; }
        public string Division { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string DateofNBirth { get; set; }
        public string NamePower { get; set; }
        public string PermanentAddress { get; set; }
        public string FullAddress { get; set; }
        public string Nationality { get; set; }
        public string StateDomicile { get; set; }
        public string MobileNo { get; set; }
        public string SocialCat { get; set; }
        public string Emailid { get; set; }
        public string BankerName { get; set; }
        public string Turnover { get; set; }
        public string financialYear { get; set; }
        public string Datework { get; set; }

    }
    public class RenDrugLicDet
    {
        public string Questionnariid { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }

        public string Licnumber { get; set; }
        public string ExpiryDate { get; set; }
        public string CancelledLic { get; set; }
        public string SpecifyLicno { get; set; }
        public string PremiseInspection { get; set; }
        public string DateInspection { get; set; }
        public string TotalAmount { get; set; }
        public string AdditionalFees { get; set; }
        public string LateFees { get; set; }
        public string RegFees { get; set; }
        public string TotalPaidAmount { get; set; }

        public string NameDrug { get; set; }

        public string Name { get; set; }
        public string Qualification { get; set; }
        public string Experience { get; set; }

        public string NameManu { get; set; }
        public string QualificationManu { get; set; }
        public string ExperienceManu { get; set; }

        public string AdditionalItem { get; set; }
    }
    public class RenBusinessLicDetails
    {
        public string Questionnariid { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string LICNO { get; set; }
        public string LICISSUEDT { get; set; }
        public string LICVALID { get; set; }
        public string NAMEOFBUSINESS { get; set; }
        public string ESTOWNED { get; set; }
        public string NAMEREPRESENTATIVE { get; set; }
        public string MOBILENO { get; set; }
        public string EMAILID { get; set; }
        public string ADDRESS { get; set; }
        public string NATUREBUSINESS { get; set; }
        public string TYPEOFEST { get; set; }


    }
    public class RenCinemaLicDetails
    {
        public string Questionnariid { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string OLDREGNO { get; set; }
        public string REGDATE { get; set; }
        public string NAMEESTCINEMA { get; set; }
        public string NOCISSUEDATE { get; set; }
        public string NUMBERSEAT { get; set; }
        public string CINEMATOGRAPHY { get; set; }
        public string BUSINESSTYPE { get; set; }
        public string NAMEPARTNER { get; set; }
        public string GSTNO { get; set; }
        public string OWNERSHIP { get; set; }
        public string DISTRIC { get; set; }
        public string MANDAL { get; set; }
        public string VILLAGE { get; set; }
        public string LOCALITY { get; set; }
        public string LANDMARK { get; set; }
        public string Pincode { get; set; }

    }
    public class RenContractLabour
    {
        public string Questionnariid { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string LICRENEWAL { get; set; }
        public string LICISSUEDATE { get; set; }
        public string LICRENEWALDATE { get; set; }
        public string TITLE { get; set; }
        public string NAME { get; set; }
        public string EMAILID { get; set; }
        public string MOBILENO { get; set; }
        public string FATHERNAME { get; set; }
        public string ESTNAME { get; set; }
        public string DISTRIC { get; set; }
        public string MANDAL { get; set; }
        public string VILLAGE { get; set; }
        public string LOCALITY { get; set; }
        public string LANDMARK { get; set; }
        public string PINCODE { get; set; }
        public string REGNUMBER { get; set; }
        public string REGDATE { get; set; }
        public string TYPEOFBUSINESS { get; set; }
        public string TITLES { get; set; }
        public string EMPNAME { get; set; }
        public string NAMES { get; set; }
        public string ADDRESS { get; set; }
        public string LABOUREMPEST { get; set; }
        public string NOOFDAYS { get; set; }
        public string LABOURAPPROVED { get; set; }
        public string MAXNOLABOUREMP { get; set; }
        public string WITHIN5YEARS { get; set; }
        public string DETAILS { get; set; }
        public string REVOKINGLIC { get; set; }
        public string ORDERDATE { get; set; }
        public string ESTWITHIN5YEAR { get; set; }
        public string ESTDETAILS { get; set; }
        public string EMPDETAILS { get; set; }
        public string NATUREOFWORK { get; set; }


        public string FULLTITLE { get; set; }
        public string FULLNAME { get; set; }
        public string FULLADDRESS { get; set; }
    }
    public class RenBoilerDetails
    {
        public string Questionnariid { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string LICNO { get; set; }
        public string LICISSUEDDATE { get; set; }
        public string LICVALIDDATE { get; set; }
        public string BOILERWORK { get; set; }
        public string FACTORYNAME { get; set; }
        public string ADDRESSFACTORY { get; set; }
        public string DISTRIC { get; set; }
        public string MANDAL { get; set; }
        public string VILLAGE { get; set; }
        public string LOCALITY { get; set; }
        public string PINCODE { get; set; }
        public string NAMEMANU { get; set; }
        public string YEARMANU { get; set; }
        public string PLACEMANU { get; set; }
        public string BOILERNO { get; set; }
        public string INTENDED { get; set; }
        public string FUEL { get; set; }
        public string HEATERRATING { get; set; }
        public string ECONOMISERATING { get; set; }
        public string MAXIMUMEVAPORATION { get; set; }
        public string REHEATER { get; set; }
        public string WORKINGSEASON { get; set; }
        public string WORKINGPRESSURE { get; set; }
        public string NAMEOWNER { get; set; }
        public string BOILERTYPE { get; set; }
        public string DESCBOILER { get; set; }
        public string BOILERRATING { get; set; }
        public string BOILEROWNERSHIP { get; set; }
        public string REMARKSTR { get; set; }
        public string REGNO { get; set; }
        public string BOILEROFTYPE { get; set; }
        public string BOILERRATINGS { get; set; }
        public string BOILERSITUATED { get; set; }
        public string MANUFACTUREPLACE { get; set; }
        public string MANUFACTUREYEAR { get; set; }
        public string OWNERNAMES { get; set; }
        public string MAXCOUNT { get; set; }
        public string MAXIMUMPRESSURE { get; set; }
        public string REPAIRS { get; set; }
        public string HYDRAULICALLY { get; set; }
        public string UPTO { get; set; }
        public string LOADING { get; set; }
        public string SAFETY { get; set; }
        public string PERIODDATE { get; set; }
        public string TODATE { get; set; }
        public string REMARK { get; set; }
        public string REGFEES { get; set; }
        public string TOTALAMOUNT { get; set; }

    }
    public class RenShopsEstablishment
    {
        public string Questionnariid { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string LICNO { get; set; }
        public string LICISSUEDATE { get; set; }
        public string LICVALIDUP { get; set; }
        public string NAMEEST { get; set; }
        public string CONSTITUTION { get; set; }
        public string APPLICANTNAME { get; set; }
        public string MOBILENO { get; set; }
        public string EMAILID { get; set; }
        public string NAMEOFMANAGER { get; set; }
        public string ADDRESS { get; set; }
        public string CATEGORYEST { get; set; }
        public string NATUREBUSINESS { get; set; }
        public string YOURFAMILY { get; set; }
        public string EMPLOYEESEST { get; set; }
        public string NOOFEMPLOYEE { get; set; }
        public string DISTRIC { get; set; }
        public string MANDAL { get; set; }
        public string VILLAGE { get; set; }
        public string LOCALITY { get; set; }
        public string PINCODE { get; set; }
        public string LANDMARK { get; set; }
        public string GODOWN { get; set; }
        public string REGRENEWEDDATE { get; set; }
        public string REGVALIDDATE { get; set; }
        public string YEARRENEWED { get; set; }
        public string FEES { get; set; }
        public string FEESNOTICE { get; set; }
        public string FINE { get; set; }
        public string PENALTY { get; set; }
        public string TOTALPAIDAMOUNT { get; set; }

        public string DISTICS { get; set; }
        public string MANDALS { get; set; }
        public string VILLAGES { get; set; }
        public string LOCALITYS { get; set; }
        public string PINCODES { get; set; }

        public string NAMES { get; set; }
        public string GENDER { get; set; }
        public string AGE { get; set; }
        public string RELATIONSHIP { get; set; }


     

        public string NAME_PROPERTIE { get; set; }
        public string COMMUNITIONADDRESS { get; set; }
        public string COMMUNITY { get; set; }
        public string COMMUNITYOTHER { get; set; }


        public string NAMEPATNER { get; set; }
        public string PATNERADDRESS { get; set; }


        public string NAMEDIRECTOR { get; set; }
        public string LIMITEDADDRESS { get; set; }

    }
    public class RenAttachments
    {
        public string Questionnareid { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string CFEUID { get; set; }
        public string DeptID { get; set; }
        public string ApprovalID { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileDescription { get; set; }
        public string FileType { get; set; }
        public string MasterID { get; set; }
        public string QueryID { get; set; }
        public string ReferenceNo { get; set; }
    }
    public class RenApplicationDetails
    {
        public string Questionnariid { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string ApprovalID { get; set; }
        public string Nameofunit { get; set; }
        public string companyType { get; set; }
        public string INDUSTRY { get; set; }
        public string CATEGORYREG { get; set; }
        public string RegNumber { get; set; }
        public string RegDate { get; set; }
        public string Sector { get; set; }
        public string LineofActivity { get; set; }
        public string PCB { get; set; }
        public string SURVEY { get; set; }
        public string LOCALITY { get; set; }
        public string LANMARK { get; set; }
        public string DISTRICT { get; set; }
        public string MANDAL { get; set; }
        public string VILLAGE { get; set; }
        public string EMAILID { get; set; }
        public string MOBILENO { get; set; }
        public string PINCODE { get; set; }
        public string TOTALEXTENT { get; set; }
        public string BUILDUPAREA { get; set; }
        public string NamePromoter { get; set; }
        public string SONOF { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string ALTERNATIVAENO { get; set; }
        public string LANDLINENO { get; set; }
        public string DoorNo { get; set; }
        public string Local { get; set; }
        public string State { get; set; }
        public string Districts { get; set; }
        public string Mandals { get; set; }
        public string Villages { get; set; }
        public string AppDistrict { get; set; }
        public string AppMandal { get; set; }
        public string AppVillge { get; set; }
        public string Pin { get; set; }
        public string Age { get; set; }
        public string Designation { get; set; }
        public string WOMEN { get; set; }
        public string ABLED { get; set; }
        public string DIRECTMALE { get; set; }
        public string DIRECTFEMALE { get; set; }
        public string DIRECTEMP { get; set; }
        public string INDIRECTMALE { get; set; }
        public string INDIRECTFEMALE { get; set; }
        public string INDIRECTEMP { get; set; }
        public string TOTALEMP { get; set; }
        public string LandSaleDeed { get; set; }
        public string Building { get; set; }
        public string PlantMachinary { get; set; }
        public string TotalProjectCost { get; set; }
        public string AnnualTurnOver { get; set; }
        public string ProjectCost { get; set; }
        public string EnterpriseCategory { get; set; }
        public string RenApprovalsXml { get; set; }

    }
    public class RenSafteySecurity
    {
        public string Questionnariid { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string MIGRANTREGNO { get; set; }
        public string DISTRICREGISSUED { get; set; }
        public string NAMEKIN { get; set; }
        public string ADDRESS { get; set; }
        public string FORCEININDIA { get; set; }
        public string CRIMINALCASE { get; set; }
        public string UNSOUNDMIND { get; set; }
        public string NATUREOFEMP { get; set; }
        public string EMPEXPECTEDDATE { get; set; }
        public string EXPECTEDDURATIONSTAY { get; set; }
        public string WORKDETAILS { get; set; }
        public string DISTRICAREA { get; set; }
        public string AREAOFWORK { get; set; }
        public string EXSTINGREGVALIDDATE { get; set; }
        public string DETAILSOFSPECIFICSKILL { get; set; }
        public string DISTRICAREAOFWORKER { get; set; }
        public string WORKADDRESSAREA { get; set; }
        public string REGRENEWEDDATE { get; set; }
        public string NAMEESTEMP { get; set; }
        public string ADDRESSEST { get; set; }
        public string CONTACTNO { get; set; }

    }
    public class RenMigrantwork
    {
        public string Questionnariid { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }

        public string LICRENO { get; set; }
        public string LICISSUEDDATE { get; set; }
        public string LICRENVALIDDATE { get; set; }
        public string TITLE { get; set; }
        public string NAME { get; set; }
        public string EMAILID { get; set; }
        public string MOBILENO { get; set; }
        public string FATHERNAME { get; set; }
        public string STATE { get; set; }
        public string DISTRIC { get; set; }
        public string MANDAL { get; set; }
        public string VILLAGE { get; set; }
        public string LOCALITY { get; set; }
        public string NEARLAND { get; set; }
        public string PINCODE { get; set; }
        public string DATEOFBIRTH { get; set; }
        public string DATE { get; set; }
        public string AGE { get; set; }
        public string STATES { get; set; }
        public string DISTRICS { get; set; }
        public string MANDALS { get; set; }
        public string VILLAGES { get; set; }
        public string LOCALITYS { get; set; }
        public string LANDMARKS { get; set; }
        public string PINCODES { get; set; }
        public string ARTICLE5 { get; set; }
        public string CRIMINALCASEAPP { get; set; }
        public string CONVICTED5APPLICATION { get; set; }
        public string DISTRICCOUNCIL { get; set; }
        public string LICENSE { get; set; }
        public string LICNOS { get; set; }
        public string DATEOFLICENSE { get; set; }
        public string VALIDDATE { get; set; }
        public string TRIBAL { get; set; }
        public string REMARK { get; set; }
        public string NAMEEST { get; set; }
        public string STATED { get; set; }
        public string DIST { get; set; }
        public string MAND { get; set; }
        public string VILLA { get; set; }
        public string LOCAL { get; set; }
        public string NEARESTLANDMAEK { get; set; }
        public string PIN { get; set; }
        public string TYPEOFBUSINESS { get; set; }
        public string REGNO { get; set; }
        public string DATEOFREG { get; set; }
        public string TITLES { get; set; }
        public string NAMEOFEMP { get; set; }
        public string MIGRANTNAMEEMP { get; set; }
        public string CONTRACTWORK { get; set; }
        public string DATECOMMENCING { get; set; }
        public string ENDINGDATE { get; set; }
        public string AGENTNAME { get; set; }
        public string MAXIMUMNOMIGRANT { get; set; }
        public string AGENTNAMEADDRESS { get; set; }
        public string CONTRACTOR { get; set; }
        public string DEATILS { get; set; }
        public string SUSPENDINGREVOKING { get; set; }
        public string ORDERNO { get; set; }
        public string ORDERDATE { get; set; }
        public string WORKESTPAST5YEARS { get; set; }
        public string ESTDETAILS { get; set; }
        public string PRINCIPLEEMPDETAILS { get; set; }
        public string NATUREWORK { get; set; }
        public string EMPENCLOSED { get; set; }


        public string TITLESS { get; set; }
        public string NAMES { get; set; }
        public string ADDRESS { get; set; }

    }
    public class RenFactoryLicense
    {
        public string Questionnariid { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string FULLNAME { get; set; }
        public string LICNO { get; set; }
        public string LICISSUEDDATE { get; set; }
        public string RENEWALNO { get; set; }
        public string RENEWALDATE { get; set; }
        public string LICVALIDYEAR { get; set; }
        public string FACTORIESL12MONTHS { get; set; }
        public string NEXT12MONTHS { get; set; }
        public string MANUPRODUCT { get; set; }
        public string PRINCIPALPRODUCT { get; set; }
        public string NAMESOFMANU { get; set; }
        public string MANUPRODUCT12MONTHS { get; set; }
        public string MAXNOEMP { get; set; }
        public string MAXNOWORK { get; set; }
        public string NOORDINARIYEMP { get; set; }
        public string UNITELECTRICPOWER { get; set; }
        public string TOTALCAPGENERATING { get; set; }
        public string TOTALDGSET { get; set; }
        public string MAXPOWER { get; set; }
        public string FULLNAMEMANAGER { get; set; }
        public string RESIDENTIALADDRESS { get; set; }
        public string FULLNAMEOWNER { get; set; }
        public string OWNERADDRESSBUILD { get; set; }
        public string NAMEOCCUPIER { get; set; }
        public string ADDRESSOCCUPIER { get; set; }
        public string PRIVATEFIRM { get; set; }
        public string PUBLICFIRM { get; set; }
        public string NAMEPROPRIETOR { get; set; }
        public string NAMEDIRECTORS { get; set; }
        public string GOVTLOCALFACTORY { get; set; }
        public string MANAGINGAPPOINTEDAGENT { get; set; }
        public string NAMECHIEFHEAD { get; set; }
        public string NAMEOFAGENT { get; set; }
        public string FACTORYEXTENDED { get; set; }
        public string REFNOAPPROVALSITE { get; set; }
        public string DATEOFAPPROVAL { get; set; }
        public string REFAPPROVALAUTHORITY { get; set; }
        public string DATEOFAPPROVALAUTHORITY { get; set; }
        public string FINALFEES { get; set; }
        public string PENALTY { get; set; }
        public string LICVALIDUPTO { get; set; }
        public string TOTALAMOUNTPAID { get; set; }


    }
    public class RenApprovals
    {
        public string RENQDID { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string ApprovalId { get; set; }
        public string DeptId { get; set; }
        public string ApprovalFee { get; set; }
        public string UidNo { get; set; }
    }
    public class RENDtls
    {
        public string UserName { get; set; }
        public string UserID { get; set; }
        public int Role { get; set; }
        public int? status { get; set; }
        public string Unitid { get; set; }
        public string Investerid { get; set; }
        public string Questionnaireid { get; set; }
        public int Stage { get; set; }
        public string ViewStatus { get; set; }
        public string Remarks { get; set; }
        public int? deptid { get; set; }
        public int? ApprovalId { get; set; }
        public string AdditionalAmount { get; set; }
        public string PrescrutinyRejectionFlag { get; set; }
        public string DeptDesc { get; set; }
        public string ReferenceNumber { get; set; }
        public string IPAddress { get; set; }
    }
    public class RenLegalMetrology
    {
        public string Questionnariid { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string LICNO { get; set; }
        public string AUTORENEWAL { get; set; }
        public string RENEWEDDATE { get; set; }
        public string LICVALIDDATE { get; set; }
    }
    public class RENPayments
    {
        public string Questionnareid { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string RENUID { get; set; }
        public string DeptID { get; set; }
        public string ApprovalID { get; set; }
        public string OnlineOrderNo { get; set; }
        public string OnlineOrderAmount { get; set; }
        public string PaymentFlag { get; set; }
        public string TransactionNo { get; set; }
        public string TransactionDate { get; set; }
        public string BankName { get; set; }

    }
}
