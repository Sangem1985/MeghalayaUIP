using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MeghalayaUIP.Common
{
    public class SvrcConstants
    {
        public static string GETANNUALTURNOVER = "USP_CHECK_ANNUALTURNOVER";
        public static string CFEENTERPRISETYPEDET = "USP_GETENTERPRISETYPEDET";

        public static string GetRENApplicantDetails = "USP_GETSRVCENTERPRISEDETAILS";

        public static string InsertRenApplicationDetails = "USP_INSSRVCENTERPRISEDETAILS";

        public static string GetBMWEquipment = "USP_GETBMW_WASTETYPE";
        public static string InsertBMWDetails = "USP_INSBMWDETAILS";

        public static string InsertWasteDetails = "USP_INSBMWWASTEDETAILS";
        public static string InsertBMWBIOMEDICALDET = "USP_INSBMWEQUIPMENT";
        public static string GetSrvcBMWDetails = "USP_GETBMWDETAILS";

        public static string InsertEWasteDetails = "USP_INSEWASTEDETAILS";
        public static string GetEWasteDetails = "USP_GETEWASTEDETAILS";

        public static string InsertProdPlasticsWasteDetails = "USP_INSSRVCPRODPLASTICWASTEDETAILS";
        public static string InsertBOPlasticsWasteDetails = "USP_INS_SRVCBOPLASTICWASTEDETAILS";

        public static string InsertHzrdsDetails = "USP_INSSRVCHAZZARDOUSDETAILS";
        public static string GetHzrdsDetails = "USP_GETHAZZARDOUSDETAILS";

        public static string InsertCDWMDetails = "USP_INSSRVCCDWMWASTEDETAILS";
        public static string GetSRVCCDWMDETAILS = "USP_GETSRVCCDWMDETAILS";


        public static string GetProdPlasticWasteDetails = "USP_GETPRODPLASTICWASTEDET";
        public static string GetBOPlasticWasteDetails = "USP_GETBOPLASTICWASTEDET";


        public static string InsertSVRCAttachments = "USP_INSSRVCATTACHMNETS";

        public static string GetSRVCapplications = "USP_GETSRVCUSERDASHBOARD";

        public static string GetSRVCApprovals = "USP_GETSRVCAPPROVALS";
        public static string InsertSRVCDeptApprovals = "USP_INS_SRVCDPETAPPROVALS";
        public static string InsertSRVCSWDdetails = "USP_INSSRVCSOLIDWASTEDETAILS";//"USP_INS_SRVCDPETAPPROVALS";
        public static string GetSrvcSWMDetails = "USP_GETSRVCSOLIDWASTEDET";
        public static string GetSrvcAppliedApprovalIDs = "USP_GETSRVCAPPROVALIDS";
        public static string GetSRVCApplUserDashboard = "USP_GETUSERSRVCAPPLTRACKER"; //USP_GETSRVCAPPLUSERDASHBOARD
        public static string GetSRVCApplicationDet = "USP_GETSRVCAPPLICATIONDET";
        public static string InsertPDCLDetails = "USP_INSSRVCPDCLDETAILS";
        public static string GetSrvcPDCLDetails = "USP_GETSRVCPDCLDETAILS";
        public static String GetSRVCDashBoard = "USP_SRVCDASHBOARDCOUNT";
        public static string GetSRVCDashBoardVIEW = "USP_SRVCDASHBOARDVIEW";
        public static string InsertPaymentDetails = "USP_INSSRVCPAYMENTDETAILS_BKP";
        public static string GetSRVCApprovalsAmounttoPay = "USP_GETSRVCAPPROVALSAMOUNTTOPAY";
        public static string SRVCInsertPaymentDetails = "USP_INSSRVCPAYMENTDETAILS";
        public static string GetSRVCUploadEnclosures = "USP_GETUPLOADENCLOSURES";
        public static string GetSRVCApplStatus = "USP_GETSRVCAPPLSTATUS";


    }

    public class SvrcApplicationDetails
    {
        public string Questionnariid { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string UidNo { get; set; }
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
    public class SVRCDtls
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
    public class SvrcBMWDet
    {
        public string UnitId { get; set; }
        public string Questionnariid { get; set; }
        public string Name_applicant { get; set; }
        public string HCFCBWTF { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string website { get; set; }
        public string Authorizationactivity { get; set; }
        public string AppliedCTO_CTE { get; set; }
        public string authorisationnumber { get; set; }
        public string authorisation_Date { get; set; }
        public string Pollution1974 { get; set; }
        public string ControlPollution1981 { get; set; }
        public string AddressHealthHCFCBWFT { get; set; }
        public string GPSCOORDINATES { get; set; }
        public string NumberBED { get; set; }
        public string patientsHCF { get; set; }
        public string healthcareCBMWTF { get; set; }
        public string NOBEDCBMWTF { get; set; }
        public string DISPOSALCBMWTF { get; set; }
        public string DISTANCECBMWTF { get; set; }
        public string BMWTREATED { get; set; }
        public string MODETRANSACTION { get; set; }
        public string Createdby { get; set; }
        public string IPAddress { get; set; }
        public string Category { get; set; }
        public string Waste { get; set; }
        public string QuantityGenerated { get; set; }
        public string MethodDisposal { get; set; }
        public string Bmwname { get; set; }
        public string NoUnit { get; set; }
        public string Capacity { get; set; }

        public string BedFee { get; set; }
    }
    public class PDCLD
    {
        public string UnitId { get; set; }
        public string Questionnariid { get; set; }
        public string StatusRelation { get; set; }
        public string PoliceStation { get; set; }
        public string LTSupply { get; set; }
        public string Createdby { get; set; }
        public string IPAddress { get; set; }
    }
    public class SRVCAttachments
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
    public class SRVCOtherServices
    {
        public string Questionnariid { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string ApprovalID { get; set; }
        public string SRVCApprovalsXml { get; set; }
    }
    public class SRVCApprovals
    {
        public string SRVCQDID { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string ApprovalId { get; set; }
        public string DeptId { get; set; }
        public string ApprovalFee { get; set; }
        public string UidNo { get; set; }
    }

    public class SWMdetails
    {
        public string unitid { get; set; }
        public string Questionnariid { get; set; }
        public string namelocaloperator { get; set; }
        public string nodalauthorisedagency { get; set; }
        public string authorizationopeartion { get; set; }
        public string totalquantitywaste { get; set; }
        public string quantitywasterecycle { get; set; }
        public string quantitywastetreated { get; set; }
        public string quantitywastedisposed { get; set; }
        public string quantityleachate { get; set; }
        public string treatmenttechleachate { get; set; }
        public string measurescep { get; set; }
        public string measuressafteyplant { get; set; }
        public string nosites { get; set; }
        public string quantitywasteperday { get; set; }
        public string detailsexistingsite { get; set; }
        public string methodologydetails { get; set; }
        public string checkenvironmentpollution { get; set; }
        public string createdby { get; set; }
        public string createdbyip { get; set; }

        public string authfee { get; set; }
        public string Totalsolid { get; set; }
    }

    public class SRVCCDWMdetails
    {
        public string unitid { get; set; }

        public string SRVCQDID { get; set; }
        public string Questionnareid { get; set; }
        public string NameLocalAuthority { get; set; }
        public string NameOfNodalOfficer { get; set; }
        public string DesignationOfNodalOfficer { get; set; }
        public string AuthorizationRequiredFor { get; set; }
        public string AvgQuantityHandledPerDay { get; set; }
        public string QuantityWasteProcessedPerDay { get; set; }
        public string SiteClearanceFromAuthority { get; set; }

        public string createdby { get; set; }
        public string createdbyip { get; set; }


    }


    public class SRVCApprovaled
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


    public class ServiceEWasteDetails
    {
        public string SrvcQdId { get; set; }
        public string UnitId { get; set; }
        public string UidNo { get; set; }
        public string Name { get; set; }
        public string DoorNo { get; set; }
        public string Locality { get; set; }
        public string StateId { get; set; }
        public string DistrictId { get; set; }
        public string District { get; set; }
        public string MandalId { get; set; }
        public string Mandal { get; set; }
        public string VillageId { get; set; }
        public string Village { get; set; }
        public string Landmark { get; set; }
        public string Pincode { get; set; }
        public string Designation { get; set; }
        public string EmailId { get; set; }
        public string Mobile { get; set; }
        public string AltMobile { get; set; }
        public string Landline { get; set; }
        public string Authorization { get; set; }

        public string EWasteAuthFee { get; set; }
        public string EWasteGenQuantity { get; set; }
        public string EWasteRefurbished { get; set; }
        public string EWasteDisposal { get; set; }
        public string EWasteRecycle { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIp { get; set; }

    }
    public class ServiceProdPlasticsWasteDetails
    {
        public string SrvcQdId { get; set; }
        public string UnitId { get; set; }
        public string NameOfProduct { get; set; }
        public string NameOfUnit { get; set; }
        public string CreatedByIp { get; set; }
        public string CarryBag { get; set; }
        public string MultilayeredPlastic { get; set; }
        public string ManufacturingCapacity { get; set; }
        public string PreviousRegistration { get; set; }
        public string RegistrationDate { get; set; }
        public string TotalCapitalInvestment { get; set; }
        public string YearOfCommencement { get; set; }
        public string ListQuantityProduct { get; set; }
        public string ListQuantityRawMaterial { get; set; }
        public string TotalQuantityWasteGenerated { get; set; }
        public string ModeOfStorageWithinPlant { get; set; }
        public string DisposalProvision { get; set; }
        public string Compliance { get; set; }
        public string CreatedBy { get; set; }
        public string Role { get; set; }

        public string WaterAct {  get; set; }

        public string SgUt {  get; set; }

        public string AirCont {  get; set; }

    }

    public class ServiceBOPlasticsWasteDetails
    {
        public string SrvcQdId { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string NameOfBrandOwner { get; set; }
        public string PreviousRegistrationNumber { get; set; }
        public string CreatedByIp { get; set; }
        public string RegistrationDate { get; set; }
        public string TotalCapitalInvestment { get; set; }
        public string YearOfCommencement { get; set; }
        public string ByProdProductList { get; set; }
        public string ByProdRawMaterialList { get; set; }

        public string TotalQuantityWasteGenerated { get; set; }

        public string ModeOfStorageWithinPlant { get; set; }

        public string DisposalProvision { get; set; }

        public string Role { get; set; }

        public string WaterAct { get; set; }

        public string SgUt { get; set; }

        public string AirCont { get; set; }
    }

    public class SRVCHAZZARDOUSDETAILS
    {
        public string SRVCQDID { get; set; }
        public string UNITID { get; set; }
        public string UIDNO { get; set; }
        public string FIRMNAME { get; set; }
        public string FIRMLOCATION { get; set; }
        public string OCCUPIERNAME { get; set; }
        public string EMAILID { get; set; }
        public string MOBILENO { get; set; }
        public string FAX { get; set; }
        public string ACTIVITIES { get; set; }
        public decimal WSTNTRQTYANUM { get; set; }
        public decimal WSTNTRQTYATM { get; set; }
        public string YEARCMSNG { get; set; }
        public string SHIFTS { get; set; }
        public string CREATEDBY { get; set; }
        public string CREATEDIP { get; set; }
    }

    public class CDWMDetails
    {
        public string NameLocalAuthority { get; set; }
        public string NameOfNodalOfficer { get; set; }
        public string DesignationOfNodalOfficer { get; set; }
        public string AuthorizationRequiredFor { get; set; }
        public string AvgQuantityHandledPerDay { get; set; }
        public string QuantityWasteProcessedPerDay { get; set; }
        public bool SiteClearanceFromAuthority { get; set; }
    }
    public class SRVCPayments
    {
        public string Questionnareid { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string SRVCUID { get; set; }
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



