﻿using System;
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

        public static string InsertRegSocietiesDetails = "USP_SRVCMEMBERDETAILS";
        public static string InsRegSocietiesDet = "USP_SRVCREGSOCIETIESEDETAILS";
        public static string GetRegSocietiesDetails = "USP_GETREGSOCIETIESDET";
        public static string GETSRVCGSETDETAILS = "";
        public static string INSERTSRVCDGSETDETAILS = "";
        public static string InsertLabourContractorDetails = "";
        public static string GETSRVCLabour7DETAILS = "";
        public static string InsertTourismDetails = "";
        public static string GETSRVCTourismDetails = "";
        public static string InsertEncumberanceDetails = "";
        public static string GETSRVCNonEncumbranceDetails = "";
        public static string InsertLabourworkmenDetails = "USP_INSSRVCLABOURDETAILSCONTRACT1979";
        public static string InsertLabour1970Details = "";
        public static string InsertSrvcLabourMotorDetails = "USP_INSSRVCLABOURMOTORDETAILS";
        public static string GetSrvcLabourMotorDet = "USP_GETLABOURMOTORDETAILS";
        public static string INSERTSRVCEXCISEDETAILS = "USP_INSSRVCEXCISEDETAILS";
        public static string GetSrvcExciseDet = "USP_GETEXCISEDET";
        public static string INSERTSRVCDRUGDETAILS = "USP_INSSRVCDRUGDETAILS";
        public static string GetSRVCDRUGDet = "USP_GETSRVCDRUGEDET";
        public static string INSERTSRVCFORESTDETAILS = "USP_INSSRVCNONFORESTDETAILS";
        public static string GetSRVCFORESTDet = "USP_GETSRVCNONFORESTDETAILS";
        public static string INSERTSRVCLabourAct1970DETAILS = "";
        public static string GetSRVCLabourAct1970TDet = "";
        public static string GetSRVCLabourAct2020TDet = "";
        public static string INSERTSRVCLABOURMIGRANTACT2020DET = "";
        public static string GetSRVCLabourMigrantAct1979DET = "";
        public static string INSERTSRVCLABOURMIGRANT1979DETAILS = "";
        public static string INSLegalMetrologyDet = "";
        public static string INSLegalMetrologyDetails115 = "";
        public static string GetSRVCLegalMetrologyDet115 = "";
        public static string GetSRVCLegalMetrology = "";
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
        public string AppliedFor { get; set; }
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
        public string BedType { get; set; }
        public string AuthYears { get; set; }
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
    public class LabourConstructionwork
    {
        public string UnitId { get; set; }
        public string Questionnariid { get; set; }
        public string FullNamePE { get; set; }
        public string AddressPE { get; set; }
        public string StatePE { get; set; }
        public string DistrictPE { get; set; }
        public string MandalPE { get; set; }
        public string VillagePE { get; set; }
        public string DistPE { get; set; }
        public string MandalesPE { get; set; }
        public string VillagesPE { get; set; }
        public string PostOfficePE { get; set; }
        public string PincodePE { get; set; }
        public string NameManager { get; set; }
        public string AddressManager { get; set; }
        public string DistrictManager { get; set; }
        public string MandalManager { get; set; }
        public string VillageManager { get; set; }
        public string PoliceStationManager { get; set; }
        public string PostOfficeManager { get; set; }
        public string PincodeManager { get; set; }
        public string NatureofBuilding { get; set; }
        public string NoofWorkEmpDay { get; set; }
        public string EstConDate { get; set; }
        public string EstConworkDate { get; set; }
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
    public class SRVCRegSocietiesDetailos
    {
        public string SRVCQDID { get; set; }
        public string Applicationassociation { get; set; }
        public string District { get; set; }
        public string SUBDIVISION { get; set; }
        public string TypeApplication { get; set; }
        public string OldRegNumber { get; set; }
        public string RegDate { get; set; }
        public string NameAssociation { get; set; }
        public string AddressSociety { get; set; }
        public string Dateest { get; set; }
        public string ContactNo { get; set; }
        public string GeneralNo { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string FullAddress { get; set; }
        public string Policestation { get; set; }
        public string Designation { get; set; }
        public string MobileNo { get; set; }
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

        public string WaterAct { get; set; }

        public string SgUt { get; set; }

        public string AirCont { get; set; }

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
    public class SRVCDGset
    {
        public string Questionnaireid { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string LocDoorno { get; set; }
        public string Locality { get; set; }
        public string Landamark { get; set; }
        public string LocDistrictID { get; set; }
        public string LocMandalID { get; set; }
        public string LocVillageID { get; set; }
        public string LocPincode { get; set; }
        public string SupplierName { get; set; }
        public string TotalConnectedLoad { get; set; }
        public string PropLoadfromDGSet { get; set; }

        public string InterlockProvided { get; set; }
        public string MotorLoad { get; set; }
        public string LightsandFansLoad { get; set; }

        public string OtherlLoad { get; set; }

        public string GenRunningMode { get; set; }

        public string WorkCompletionDate { get; set; }

        public string WorkStartingDate { get; set; }
        public string CommissioningDate { get; set; }
        public string SupervisorName { get; set; }
        public string SupervisorLicNo { get; set; }
        public string ContractorName { get; set; }

        public string ContractorLicNo { get; set; }

        public string DGSetOperatorNmae { get; set; }

        public string DGSetCapacity { get; set; }

        public string DGSetCapacityin { get; set; }

        public string DGSetPowerFactor { get; set; }
        public string DGSetRatedVoltage { get; set; }

        public string DGSetEngineDetails { get; set; }

        public string DGSetAlternatorDetails { get; set; }
        public string EquipmentType { get; set; }
        public string EarthingCondctrDtls { get; set; }
        public string ConductrPaths { get; set; }
        public string ElectrodeDtls { get; set; }

        public string Impedance { get; set; }
        public string TotalImpedance { get; set; }
        public string LighingType { get; set; }
        public string AlternatorTestDtls { get; set; }
        public string EarthTesterNo { get; set; }
        public string EarthTesterMake { get; set; }
        public string EarthTesterRange { get; set; }
        public string MeggerNo { get; set; }
        public string MeggerMake { get; set; }
        public string MeggerRange { get; set; }
    }
    public class SRVCTourism
    {
        public string Questionnariid { get; set; }
        public string NatureOrganization { get; set; }
        public string YearRegComm { get; set; }
        public string NameDirector { get; set; }
        public string Interestsindicated { get; set; }
        public string NameEmp { get; set; }
        public string DesignationEmp { get; set; }
        public string QualificationsEmp { get; set; }
        public string ExperienceEmp { get; set; }
        public string MonthlySalaryEmp { get; set; }
        public string LengthEmp { get; set; }
        public string SpaceSqft { get; set; }
        public string LocationArea { get; set; }
        public string ReceptionArea { get; set; }
        public string AccessibilityToilet { get; set; }
        public string NameBankers { get; set; }
        public string NameAuditors { get; set; }
        public string indicatemembership { get; set; }
        public string PostOfficeManager { get; set; }
        public string touristtraffic { get; set; }
        public string Clientele { get; set; }
        public string domestictouristtraffic { get; set; }
        public string Numberconferences { get; set; }
        public string Createdby { get; set; }
        public string IPAddress { get; set; }
        public string XMLData { get; set; }
    }
    public class SRVCEncumbrance
    {
        public string Questionnariid { get; set; }
        public string Applyservice { get; set; }
        public string Depty { get; set; }
        public string Division { get; set; }
        public string Search { get; set; }
        public string searchfrom { get; set; }
        public string ApplicantDocument { get; set; }
        public string others { get; set; }
        public string SearchNecessary { get; set; }
        public string NatureDocument { get; set; }
        public string Dated { get; set; }
        public string Location { get; set; }
        public string Direction { get; set; }
        public string Description { get; set; }
        public string Distance { get; set; }
        public string AreaIn { get; set; }
        public string Area { get; set; }
        public string Createdby { get; set; }
        public string IPAddress { get; set; }
    }
    public class Labourworkme6
    {
        public string Questionnariid { get; set; }
        public string DateofBirth { get; set; }
        public string Date { get; set; }
        public string Age { get; set; }
        public string State { get; set; }
        public string Districtid { get; set; }
        public string Mandaleid { get; set; }
        public string Villageid { get; set; }
        public string District { get; set; }
        public string Mandal { get; set; }
        public string Village { get; set; }
        public string Locality { get; set; }
        public string Landmark { get; set; }
        public string Pincode { get; set; }
        public string Artical5 { get; set; }
        public string Criminalcase { get; set; }
        public string ConvictedCrimecase { get; set; }
        public string DistrictCouncil { get; set; }
        public string License { get; set; }
        public string Licenseno { get; set; }
        public string DateofLicense { get; set; }
        public string ValidDate { get; set; }
        public string Trible { get; set; }
        public string Reason { get; set; }
        public string NameEst { get; set; }
        public string TypeofBusiness { get; set; }
        public string RegNoEst { get; set; }
        public string DateofReg { get; set; }
        public string DistrictEst { get; set; }
        public string MandalEst { get; set; }
        public string VillageEst { get; set; }
        public string LocalityEst { get; set; }
        public string LandMarkEst { get; set; }
        public string PincodeEst { get; set; }
        public string TitleEmpDet { get; set; }
        public string NameEmpPrincipal { get; set; }
        public string NameLocationNature { get; set; }
        public string DurationWorkDay { get; set; }
        public string CommencingDate { get; set; }
        public string EndingDate { get; set; }
        public string NameAgent { get; set; }
        public string MaxMigrantWorkmenNo { get; set; }
        public string MigrantState { get; set; }
        public string MigrantDistrict { get; set; }
        public string MigrantNameAddress { get; set; }
        public string Convicted5Year { get; set; }
        public string Details { get; set; }
        public string suspendinglicense { get; set; }
        public string OrderNo { get; set; }
        public string OrderDate { get; set; }
        public string ContractEst5Year { get; set; }
        public string Establishment { get; set; }
        public string PrincipalEmp { get; set; }
        public string NatureWork { get; set; }
        public string PrincipalEmployer { get; set; }
        public string Createdby { get; set; }
        public string IPAddress { get; set; }
    }
    public class MigrantModel
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
    public class DirectorXmlDTO
    {
        public string XmlData { get; set; }
        public int SRVCQDID { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByIP { get; set; }
    }
    public class Labour1970
    {
        public string Questionnariid { get; set; }
        public string EmpName { get; set; }
        public string Father { get; set; }
        public string EmpEMail { get; set; }
        public string EmpMobileNo { get; set; }
        public string State { get; set; }
        public string DistrictId { get; set; }
        public string MandalId { get; set; }
        public string VillageId { get; set; }
        public string District { get; set; }
        public string Mandal { get; set; }
        public string Village { get; set; }
        public string Locality { get; set; }
        public string Landmark { get; set; }
        public string Station { get; set; }
        public string PostOffice { get; set; }
        public string Pincode { get; set; }
        public string DirectorsTitle { get; set; }
        public string DirectorsName { get; set; }
        public string DirectorsAddress { get; set; }
        public string ManagerTitle { get; set; }
        public string ManagerName { get; set; }
        public string ManagerAddress { get; set; }
        public string LabourName { get; set; }
        public string LabourLocation { get; set; }
        public string LabourMaximumno { get; set; }
        public string LabourDurationDay { get; set; }
        public string LabourestDate { get; set; }
        public string LabourEstDatework { get; set; }
        public string LabourEmpContract { get; set; }
        public string Createdby { get; set; }
        public string IPAddress { get; set; }
    }
    public class SRVCLabourMotor
    {
        public string Questionnariid { get; set; }
        public string NatureMotor { get; set; }
        public string TotalNo { get; set; }
        public string Totalroute { get; set; }
        public string TotalNoVehicle { get; set; }
        public string MaxNoMotor { get; set; }
        public string TypeOfTransport { get; set; }
        public string PartnershipName { get; set; }
        public string PartnershipAddress { get; set; }
        public string DirectorFullName { get; set; }
        public string DirectorResAddress { get; set; }
        public string ProprietorshipName { get; set; }
        public string ProprietorshipAddress { get; set; }
        public string SectorName { get; set; }
        public string SectorAddress { get; set; }
        public string VehicleNo { get; set; }
        public string TypeVehicle { get; set; }
        public string Createdby { get; set; }
        public string IPAddress { get; set; }
        public string XMLData { get; set; }
    }
    public class SRVCEXICEBRAND
    {
        public string Questionnariid { get; set; }
        public string NameBrand { get; set; }
        public string Strength { get; set; }
        public string Size { get; set; }
        public string Noofbottles { get; set; }
        public string MRP { get; set; }
        public string Bulkliter { get; set; }
        public string PartnershipName { get; set; }
        public string LondonProof { get; set; }
        public string NameAddress { get; set; }
        public string Country { get; set; }
        public string RegBIOBrand { get; set; }
        public string NameofBrand { get; set; }
        public string RENBIOBrand { get; set; }
        public string RegFromDate { get; set; }
        public string ToDate { get; set; }
        public string NameaddressFirm { get; set; }
        public string AIM { get; set; }
        public string Object { get; set; }
        public string MemberName { get; set; }
        public string MemberDesignation { get; set; }
        public string MemberOccupation { get; set; }
        public string MemberAddress { get; set; }
        public string MemberState { get; set; }
        public string MemberDistrict { get; set; }
        public string MemberMobileno { get; set; }
        public string Createdby { get; set; }
        public string IPAddress { get; set; }
        public string XMLData { get; set; }
    }
    public class SRVCDRUGDETAILS
    {
        public string Questionnariid { get; set; }
        public string ApplicationType { get; set; }
        public string Select { get; set; }
        public string NameCompetent { get; set; }
        public string PharmacistDate { get; set; }
        public string PharmacistRegNo { get; set; }
        public string RetailName { get; set; }
        public string RetailRegNo { get; set; }
        public string RetailValidDate { get; set; }
        public string ValidTNT { get; set; }
        public string MunicipallityDate { get; set; }
        public string ColdStorage { get; set; }
        public string DrugsCategory { get; set; }
        public string Createdby { get; set; }
        public string IPAddress { get; set; }
        public string XMLData { get; set; }
    }
    public class SRVCForestDetails
    {
        public string Questionnariid { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string ForestDivision { get; set; }
        public string LandType { get; set; }
        public string LandArea { get; set; }
        public string NonForest { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string Manadal { get; set; }
        public string Village { get; set; }
        public string Pincode { get; set; }

    }
    public class SRVCLABOURACT1970DETAILS
    {
        public string Questionnariid { get; set; }
        public string Title { get; set; }
        public string PrincipalEMPNAME { get; set; }
        public string State { get; set; }
        public string DISTRICTID { get; set; }
        public string MANDALID { get; set; }
        public string VILLAGEID { get; set; }
        public string DISTRICT { get; set; }
        public string MANDAL { get; set; }
        public string VILLAGE { get; set; }
        public string Locality { get; set; }
        public string Landmark { get; set; }
        public string PoliceStation { get; set; }
        public string PostOffice { get; set; }
        public string PinCode { get; set; }
        public string TypeBusiness { get; set; }
        public string RegNo { get; set; }
        public string RegDate { get; set; }
        public string DirectorsTitle { get; set; }
        public string DirectorsName { get; set; }
        public string DirectorsAddress { get; set; }
        public string ManagerTitle { get; set; }
        public string ManagerName { get; set; }
        public string ManagerAddress { get; set; }
        public string Nameagentmanager { get; set; }
        public string Addressagentmanager { get; set; }
        public string NameNatureEmp { get; set; }
        public string LabourNoDays { get; set; }
        public string EstDate { get; set; }
        public string EndingDate { get; set; }
        public string MaxnoLabourEmp { get; set; }
        public string Othersconvicted { get; set; }
        public string Details { get; set; }
        public string Othersrevoking { get; set; }
        public string OrderDate { get; set; }
        public string otherscontractorEst { get; set; }
        public string PrincipalEmpDetails { get; set; }
        public string EstDetails { get; set; }
        public string Naturework { get; set; }
        public string Createdby { get; set; }
        public string IPAddress { get; set; }
        public string XMLData { get; set; }
    }
    public class SRVCLABOURAMIGRANTWORK2020
    {
        public string Questionnariid { get; set; }
        public string Namekin { get; set; }
        public string Address { get; set; }
        public string convictedlaw { get; set; }
        public string criminalCase { get; set; }
        public string Declaration { get; set; }
        public string EmpDesignation { get; set; }
        public string Datecommencement { get; set; }
        public string Expected { get; set; }
        public string DetailsWork { get; set; }
        public string District { get; set; }
        public string Areawork { get; set; }
        public string EstName { get; set; }
        public string EstAddress { get; set; }
        public string EstContact { get; set; }
        public string Createdby { get; set; }
        public string IPAddress { get; set; }
    }
    public class SRVCLABOURAMIGRANT1979DETAILS
    {
        public string Questionnariid { get; set; }
        public string PrincipalEMPNAME { get; set; }
        public string PrincipalFather { get; set; }
        public string PrincipalEMAILID { get; set; }
        public string PrincipalMOBILENO { get; set; }
        public string State { get; set; }
        public string DISTRICTID { get; set; }
        public string MANDALID { get; set; }
        public string VILLAGEID { get; set; }
        public string DISTRICT { get; set; }
        public string MANDAL { get; set; }
        public string VILLAGE { get; set; }
        public string Locality { get; set; }
        public string Landmark { get; set; }
        public string PoliceStation { get; set; }
        public string PostOffice { get; set; }
        public string PinCode { get; set; }
        public string DirectorsTitle { get; set; }
        public string DirectorsName { get; set; }
        public string DirectorsAddress { get; set; }
        public string ManagerTitle { get; set; }
        public string ManagerName { get; set; }
        public string ManagerAddress { get; set; }
        public string NameContractor { get; set; }
        public string ContractorAddress { get; set; }
        public string ContractorNameEMP { get; set; }
        public string ContractorMaximumNo { get; set; }
        public string DurationProposedDay { get; set; }
        public string EstDate { get; set; }
        public string EstDatework { get; set; }
        public string EstDateEmp { get; set; }
        public string Createdby { get; set; }
        public string IPAddress { get; set; }
        public string XMLData { get; set; }
    }
    public class SRVCLegalMetrology
    {
        public string Questionnariid { get; set; }
        public string District { get; set; }
        public string Mandal { get; set; }
        public string Village { get; set; }
        public string landmark { get; set; }
        public string Station { get; set; }
        public string PostOffice { get; set; }
        public string Pincode { get; set; }
        public string DateOfEST { get; set; }
        public string RegShopEst { get; set; }
        public string RegADC { get; set; }
        public string DateofReg { get; set; }
        public string CurrentRegNo { get; set; }
        public string DateOfRegADC { get; set; }
        public string CurrentRegNoADC { get; set; }
        public string partnershipfirm { get; set; }
        public string limitedcompany { get; set; }
        public string Namepartner { get; set; }
        public string Addresspartner { get; set; }
        public string Fatherpartner { get; set; }
        public string NameManaging { get; set; }
        public string AddressManaging { get; set; }
        public string FatherManaging { get; set; }
        public string NatureManu { get; set; }
        public string Weights { get; set; }
        public string Measures { get; set; }
        public string WeightingInstrument { get; set; }
        public string Skilled { get; set; }
        public string Semiskilled { get; set; }
        public string Unskilled { get; set; }
        public string Specialisttrain { get; set; }
        public string electricenergy { get; set; }
        public string Detailsmachinery { get; set; }
        public string Detailsworkshop { get; set; }
        public string FacilitiesCasting { get; set; }
        public string receivedloan { get; set; }
        public string bankersName { get; set; }
        public string GiveBankerDetails { get; set; }
        public string GST { get; set; }
        public string ProfessionalTaxReg { get; set; }
        public string ITNumber { get; set; }
        public string manufacturedSold { get; set; }
        public string manufacturerLicense { get; set; }
        public string GiveLicenseDetails { get; set; }     
        public string Createdby { get; set; }
        public string IPAddress { get; set; }
        public string XMLData { get; set; }
    }
    public class SRVCLegalMetrology115
    {
        public string Questionnariid { get; set; }
        public string Dateestablishment { get; set; }
        public string RegFactoryEst { get; set; }
        public string ShopRegDate { get; set; }
        public string ShopCurrentRegNo { get; set; }
        public string RegNoADC { get; set; }
        public string ADCDateReg { get; set; }
        public string ADCCurrentRegNo { get; set; }
        public string partnershipfirm { get; set; }
        public string limitedcompany { get; set; }
        public string Namepartner { get; set; }
        public string Addresspartner { get; set; }
        public string NameManaging { get; set; }
        public string AddressManaging { get; set; }
        public string Weights { get; set; }
        public string Measures { get; set; }
        public string WeightingInstrument { get; set; }
        public string ProfessionalTaxReg { get; set; }
        public string GST { get; set; }
        public string ITNumber { get; set; }
        public string State { get; set; }
        public string LicNo { get; set; }
        public string RegWeightMeasure { get; set; }
        public string DealerLic { get; set; }      
        public string GiveDetails { get; set; }
        public string Instrumenttype { get; set; }
        public string Class { get; set; }
        public string Capacity { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string SerialNo { get; set; }
        public string Product { get; set; }
        public string Quantity { get; set; }       
        public string Createdby { get; set; }
        public string IPAddress { get; set; }
        public string XMLData { get; set; }
    }
}



