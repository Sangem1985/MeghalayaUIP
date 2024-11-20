using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeghalayaUIP.Common
{
    public class CFOConstants
    {
        public static string GetCFOIndustryDetails = "USP_GETCFOINDUSTRYDETAILS";
        public static string InsertCFOIndustryDetails = "USP_INSCFOINDUSTRYDETAILS";
        public static string InsertCFOManufactureDetails = "USP_INSCFOLINEOFMANFDETAILS";
        public static string InsertCFORAWMaterialDetails = "USP_INSCFORAWMATERIALDETAILS";

        public static string InsertCFOLabourDet = "USP_INSCFOLABOURDETAILS";
        public static string InsertCFOLabourContractorDetails = "USP_INSCFOCONTRACTLABOURDETAILS";

        public static string InsertCFOLegalMetrologyDep = "USP_INSCFOLEGALMETROLOGYDETAILS";
        public static string InsertCFOMetrologyDet = "USP_INSCFOLMINSTRUMENTDETAILS";
        public static string InsertCFOProfessionalTax = "USP_INSCFOPROFTAXDETAILS";
        public static string INSERTCFOPROFESSIONALTAXSTATE = "USP_INSCFOPROFTAXSTATE";
        public static string INSERTCFOPROFESSIONALTAXCOUNTRY = "USP_INSCFOPROFTAXCOUNTRY";
        public static string INSERTCFOPROFESSIONALTAXFOREIGN = "USP_INSCFOPROFTAXFOREIGN";
        public static string InsertCFOExicseDept = "";
        public static string InsertCFOFireDepartment = "USP_INSCFOFIREDETAILS";
        public static string InsertPollutionControlBoardDet = "USP_INSCFOBNUSINESSNATURE";
        public static string InsertCFOPollutioncontrolDet = "USP_INSCFOBUSINESSLICDETAILS";
        public static string InsertCFOPublicWorkDep = "USP_INSCFOWORKCONTRACTORDETAILS";
        public static string IncerstCFOManufactureDet = "USP_INSCFODRUGLICMANFSTAFF";
        public static string IncerstCFOTestingDet = "USP_INSCFODRUGLICTESTINGSTAFF";
        public static string InsertCFODrugLicense = "USP_INSCFODRUGDETAILS";
        public static string InsertCFODrugLicenseDetails = "USP_INSCFODRUGLICDETAILS";
        public static string GetCFOObtainedOffline = "USP_GETCFOQUESTIONNAIREAPPROVALS";
        public static string GetApprovalsReqFromTable = "USP_GETCFOQUESTIONNAIREAPPROVALS";
        public static string InsertCFOAttachments = "USP_INSCFOATTACHMENTS"; 
        public static string InsertCFODepartmentapprovals = "USP_INSCFODEPARTMENTAPPROVALS";
        public static string GetCFEApprovedandCFOAppliedApplications = "USP_GETCFEAPPROVEDANDCFOAPPLIED";
        public static string GetRetriveExciseDet = "GetCFOExciseData";
        //chanikya/////
        public static string GetCFOApprovalsReq = "USP_GETCFOAPPROVALSWITHFEE";
        public static string GetCFORegDetails = "USP_GETAPPROVEDINDUSTRYREGDATA_CFO";
        public static string InsertCFOQuestionnaire = "USP_INSCFOQUESTIONNAREDETAILS";
        public static string InsertCFOQuestionnaireApprovals = "USP_INSCFOREQUIREDAPPROVALS";
        public static string RetrieveQuestionnaire = "USP_RETRIEVECFOQUESFILLEDDATA";
        public static string GetCFEApprovalsAmounttoPay = "USP_GETCFOAPPROVALSAMOUNTTOPAY";
        public static string InsertPaymentDetails = "USP_INSCFOPAYMENTDETAILS";
        public static string GetApprovalDataByDeptId = "USP_GETCFOAPPROVALBYDEPTID";

        public static string GetCFOTracker = "USP_GETUSERCFOAPPLTRACKER";
        public static string GetUserCFOApplStatus = "USP_GETCFOAPPLSTATUS";

        //------------------DEPARTMENT STARTED HERE ---------------------------------//

        public static string GetCFODashBoard = "USP_CFODASHBOARDCOUNT";
        public static string GetCFODashBoardView = "USP_CFODASHBOARDVIEW";
        public static string GetCFOApplicationDet = "USP_GETCFOAPPLICATIONDET";
        public static string UpdateCFODepartmentProcess = "USP_UPDATECFOSCRUTINYACTION";

        //------------------DEPARTMENT ENDED HERE ---------------------------------//
        public static string GetCFOLabourDet = "USP_GETCFOLABOURDETAILS";
        public static string GetCFOLegalMeterologyDetails = "USP_GETCFOLEGALMETROLOGYDETAILS";
        public static string GetCFOContractorsDetails = "USP_GETCFOWORKCONTRACTORDETAILS";
        public static string GetCFODrugLicDetails = "USP_GETCFODRUGLICDETAILS";
        public static string GetCFOProffessionalTaxDetails = "USP_GETCFOPROFTAXDETAILS";
        public static string GetCFOFireDet = "USP_GETCFOFIREDETAILS";
        public static string GetCFOBusinessLicDetails = "USP_GETCFOBUSINESSLICDETAILS";
        public static string GetCFOLINEOFACTIVITYDetails = "USP_GETCFOLINEOFACTIVITY";
       // public static string InsertCFOLineOfActivityDetails = "USP_INSCFOLINEOFACTIVITYDETAILS";
        public static string GetCFOQueryDashBoard = "USP_GETCFOQUERYRAISEDDEPT";
        public static string InsertCFOQueryResponse = "USP_UPDATECFOAPPLQUERYRESPONSE";

        public static string GetCFOAttachments = "USP_GETCFOATTACHMNETS";

        public static string GETANNUALTURNOVER = "USP_CHECK_ANNUALTURNOVER";
        public static string CFEENTERPRISETYPEDET = "USP_GETENTERPRISETYPEDET";
    }
    public class CFOExciseDetails
    {
        public int CFOExciseID { get; set; }
        public int CFOunitid { get; set; }
        public int CFOQID { get; set; }
        public string Artical5Selection { get; set; }
        public string ApplicantSelection { get; set; }
        public string MemberSelection { get; set; }
        public string TaxSelection { get; set; }
        public string SaleTaxSelection { get; set; }
        public string ProfessionSelection { get; set; }
        public string GovernmentSelection { get; set; }
        public string GovernmentDetails { get; set; }
        public string ViolationSelection { get; set; }
        public string ViolationDetails { get; set; }
        public string ConvictedSelection { get; set; }
        public string ConvictedDetails { get; set; }
        public string RenewBrand { get; set; }
        public DateTime? RegFromDate { get; set; }
        public DateTime? RegToDate { get; set; }
        public string FirmAddress { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedIp { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedIp { get; set; }
        public string Flag { get; set; }
        public List<CFOExciseBrandDetails> brandgridlist { get; set; }
        public List<CFOExciseLiquorDetails> liquorgridlist { get; set; }        
       // public List<CFOAttachments> CFOAttachment { get; set; }
    }
    [Serializable]
    public class CFOExciseBrandDetails
    {
        public int CFOExciseBrandID { get; set; }
        public int CFOunitid { get; set; }
        public int CFOQID { get; set; }
        public string NameOfBrand { get; set; }
        public string Strength { get; set; }
        public string Size { get; set; }
        public string NumberOfBottles { get; set; }
        public string MRPRs { get; set; }
        public string BulkLiter { get; set; }
        public string LandOnProof { get; set; }
        public string BottlePlant { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedIp { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedIp { get; set; }
        public string Flag { get; set; }
    }
    [Serializable]
    public class CFOExciseLiquorDetails
    {
        public int CFOExciseLiquorID { get; set; }
        public int CFOunitid { get; set; }
        public int CFOQID { get; set; }
        public string CountryID { get; set; }
        public string CountryName { get; set; }
        public string MRPSSelection { get; set; }
        public string BrandName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedIp { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedIp { get; set; }
        public string Flag { get; set; }
    }

    public class CFOLabourDet
    {
        public string Questionnariid { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string DirectorateBoiler { get; set; }
        public string Classification { get; set; }
        public string ProvideDetails { get; set; }
        public string Establishmentyear { get; set; }
        public string temperature { get; set; }
        public string BoilerRegulation { get; set; }
        public string generatortool { get; set; }
        public string Document { get; set; }
        public string firm { get; set; }
        public string regulationstrictly { get; set; }
        public string controversial { get; set; }
        public string materials { get; set; }
        public string OwnSystem { get; set; }
        public string Upload_Document { get; set; }
        public string NameManufacture { get; set; }
        public string manufactureYear { get; set; }
        public string manufactureplace { get; set; }
        public string BoilerNumber { get; set; }
        public string Intendedpressure { get; set; }
        public string manufacture { get; set; }
        public string HeaterRating { get; set; }
        public string Economiser { get; set; }
        public string MaximumTonne { get; set; }
        public string RatingHeaters { get; set; }
        public string WorkingSeason { get; set; }
        public string PressurePSI { get; set; }
        public string NameOwner { get; set; }
        public string BoilerType { get; set; }
        public string DescriptionBoiler { get; set; }
        public string BoilerRating { get; set; }
        public string ownershipBoiler { get; set; }
        public string Remarks { get; set; }
        public string ManufactureNames { get; set; }
        public string ManufactureYears { get; set; }
        public string Placemanu { get; set; }

        public string NameAgent { get; set; }
        public string Address { get; set; }
        public string NameNature { get; set; }
        public string contractorlabour { get; set; }
        public string Estimateddate { get; set; }
        public string Endingdate { get; set; }
        public string Maximumemployed { get; set; }
        public string withinfiveyear { get; set; }
        public string Details { get; set; }
        public string licenseDeposite { get; set; }
        public string OrderDate { get; set; }
        public string establishmentpast { get; set; }
        public string PrincipalEMP { get; set; }
        public string EstablishmentDET { get; set; }
        public string NatureWORK { get; set; }
        public string generalManagement { get; set; }
        public string AddressAgent { get; set; }
        public string CategoryEst { get; set; }
        public string NatureBusiness { get; set; }
        public string establishmentfamily { get; set; }
        public string employeeswork { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string Community { get; set; }
        public string FullPresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string HalfDay { get; set; }
        public string FullDay { get; set; }
        public string TotalNumberEMP { get; set; }

        public string NAME { get; set; }
        public string GENDER { get; set; }
        public string AGE { get; set; }
        public string COMMUNITY { get; set; }
        public string FULLADDRESS { get; set; }
        public string ADDRESS { get; set; }
        public string HALFDAY { get; set; }
        public string FULLDAY { get; set; }

    }
    public class CFOLEGALMETROLOGYDEP
    {
        public string Questionnariid { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string DateEstablish { get; set; }
        public string RegFactoryShop { get; set; }
        public string DateReg { get; set; }
        public string CurrentRegNumber { get; set; }
        public string LicADCnO { get; set; }
        public string RegDateNo { get; set; }
        public string RegCurrentNo { get; set; }
        public string PatnershipFirm { get; set; }
        public string CompanyLimited { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Weight { get; set; }
        public string Measures { get; set; }
        public string WeightingIns { get; set; }
        public string ProfessionalTax { get; set; }
        public string GST { get; set; }
        public string ITNUMBER { get; set; }
        public string StateCountry { get; set; }
        public string LICNUMBER { get; set; }
        public string WeightMeasure { get; set; }
        public string StateSide { get; set; }
        public string LICDeal { get; set; }
        public string GiveDetails { get; set; }
        public string Skilled { get; set; }
        public string SemiSkilled { get; set; }
        public string Unskilled { get; set; }
        public string SpecialistTrain { get; set; }
        public string MachinaryOwn { get; set; }
        public string ownershiplong { get; set; }
        public string FacilitiesSteel { get; set; }
        public string ElectricEnergy { get; set; }
        public string LICState { get; set; }
        public string Institution { get; set; }
        public string NameBankers { get; set; }
        public string GiveDetailsin { get; set; }
        public string stock { get; set; }
        public string GetDetails { get; set; }
        public string repairerLic { get; set; }
        public string results { get; set; }
        public string DetailsDet { get; set; }
        public string Instrumenttype { get; set; }
        public string Class { get; set; }
        public string Capacity { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string SerialNo { get; set; }
        public string Product { get; set; }
        public string Quantity { get; set; }

    }
    public class CFOTAXDEPARTMENT
    {
        public string Questionnariid { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string Article5 { get; set; }
        public string EXICISELIC { get; set; }
        public string EXICISESHOP { get; set; }
        public string INCOMETAX { get; set; }
        public string SALETAX { get; set; }
        public string PROFESSIONALTAX { get; set; }
        public string EXCISEDEP { get; set; }
        public string PROVIDE { get; set; }
        public string EXCISELAWRULE { get; set; }
        public string NONBALABEL { get; set; }
        public string COURTOFFENCE { get; set; }
        public string courtbailable { get; set; }
        public string BrandName { get; set; }
        public string Strength { get; set; }
        public string Size { get; set; }
        public string bottlesOne { get; set; }
        public string MRP { get; set; }
        public string Bulkliter { get; set; }
        public string LondonProof { get; set; }
        public string Nameaddress { get; set; }
        public string LiquorOrigin { get; set; }
        public string MRPRS { get; set; }
        public string Brand { get; set; }
        public string BrandsBIO { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Firm { get; set; }
    }
    public class CFOPROFESSIONALTAX
    {
        public string Questionnariid { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string NameEst { get; set; }
        public string AddressEst { get; set; }
        public string DistrictEst { get; set; }
        public string PinCode { get; set; }
        public string TotalEMP { get; set; }
        public string SERVIOCEEST { get; set; }
        public string Date { get; set; }
        public string GrossAnnual { get; set; }
        public string BusinessPlace { get; set; }
        public string Business { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string TotalworkingEMP { get; set; }
        public string BUSINESS { get; set; }
        public string PlaceBUSINESS { get; set; }
        public string AddressEST { get; set; }
        public string State { get; set; }
        public string Totalworkingemployees { get; set; }
        public string FORIGEN { get; set; }
        public string PrincipalWORK { get; set; }
        public string AddressWORK { get; set; }
        public string EmployerName { get; set; }
        public string MontlySalary { get; set; }
        public string Branch { get; set; }
        public string RegUnderAct { get; set; }
        public string RegistrationType { get; set; }
        public string RegisrationNo { get; set; }
    }
    public class HOMEDEPARTMENT
    {
        public string Questionnariid { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }

        public string BuildingName { get; set; }
        public string CategoryBuild { get; set; }
        public string FeeAmount { get; set; }
        public string District { get; set; }
        public string Mandal { get; set; }
        public string Village { get; set; }
        public string Locality { get; set; }
        public string Landmark { get; set; }
        public string Pincode { get; set; }
        public string PlotArea { get; set; }
        public string Breadth { get; set; }
        public string BuildUpArea { get; set; }
        public string RoadApproach { get; set; }
        public string East { get; set; }
        public string West { get; set; }
        public string North { get; set; }
        public string South { get; set; }
        public string DistanceEAST { get; set; }
        public string DistanceWEST { get; set; }
        public string DistanceNORTH { get; set; }
        public string DistanceSOUTH { get; set; }
        public string FireStation { get; set; }


    }
    public class PollutionControlBoard
    {
        public string Questionnariid { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string DateEst { get; set; }
        public string LocationStall { get; set; }
        public string HoldingNumber { get; set; }
        public string MarketName { get; set; }
        public string DistrictEST { get; set; }
        public string Stallnumber { get; set; }
        public string Municipality { get; set; }
        public string Details { get; set; }
        public string AnnualGross { get; set; }
        public string TotalAmount { get; set; }
        public string MainCategory { get; set; }
        public string SubCategory { get; set; }
        public string Fees { get; set; }

    }
    public class PublicWorKDepartment
    {
        public string Questionnariid { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }

        public string PurposeApplicant { get; set; }
        public string ContractorReg { get; set; }
        public string BankerName { get; set; }
        public string Director { get; set; }
        public string Circle { get; set; }
        public string Division { get; set; }
        public string Turnover { get; set; }
        public string financialYear { get; set; }
        public string Datework { get; set; }

    }
    public class CFOHealthyWelfare
    {
        public string Questionnariid { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }

        public string TypeApplication { get; set; }
        public string TradingLICDate { get; set; }
        public string Valideuptodate { get; set; }
        public string coldstorage { get; set; }
        public string cancelledlicense { get; set; }
        public string specifylicense { get; set; }
        public string readyinspection { get; set; }
        public string inceptionDate { get; set; }


        public string ManufName { get; set; }
        public string ManufQualification { get; set; }
        public string ManufExperience { get; set; }
        public string testingName { get; set; }
        public string testingQualification { get; set; }
        public string testingExperience { get; set; }
        public string NameDrug { get; set; }

    }

    public class CFOQuestionnaireDet
    {
        public string UNITID { get; set; }
        public string PREREGUIDNO { get; set; }
        public string CFEQDID { get; set; }
        public string CFOQDID { get; set; }
        public string CreatedBy { get; set; }
        public string ApprovalID { get; set; }
        public string DeptID { get; set; }
        public string ApprovalFee { get; set; }
        public string IsOffline { get; set; }
        public string IPAddress { get; set; }
        public string CompanyName { get; set; }
        public string CompanyType { get; set; }
        public string ProposalFor { get; set; }
        public string LandFromMIDCL { get; set; }
        public string PropLocDitrictID { get; set; }
        public string PropLocMandalID { get; set; }
        public string PropLocVillageID { get; set; }
        public string ExtentofLand { get; set; }
        public string Acres { get; set; }
        public string Gunthas { get; set; }
        public string Square_Meters { get; set; }
        public string BuiltUpArea { get; set; }
        public string SectorName { get; set; }
        public string Lineofacitivityid { get; set; }
        public string PCBCategory { get; set; }
        public string NatureofActivity { get; set; }
        public string UnitLocation { get; set; }
        public string Investment { get; set; }
        public string Employment { get; set; }

        public string PropEmployment { get; set; }
        public string ProjectCost { get; set; }
        public string LandValue { get; set; }
        public string BuildingValue { get; set; }
        public string PlantnMachineryCost { get; set; }
        public string ExpectedTurnover { get; set; }
        public string TotalProjCost { get; set; }
        public string EnterpriseCategory { get; set; }
        public string Power { get; set; }
        public string LabourAct2020 { get; set; }
        public string BoilerManfreg { get; set; }
        public string WorkContractorsReg { get; set; }
        public string BoilerReg { get; set; }
        public string FactoryLicence { get; set; }
        public string Labouract1979 { get; set; }
        public string Labouract1970 { get; set; }
        public string DrugLic { get; set; }
        public string Wandmreparerlic { get; set; }
        public string Wandmmanflic { get; set; }
        public string Wandmdealerlic { get; set; }
        public string Wandmverification { get; set; }
        public string Firesaftycert { get; set; }
        public string Exciselic { get; set; }
        public string Druglicconstchange { get; set; }
        public string Brandlabelreg { get; set; }
        public string Druglicmanffortest { get; set; }
        public string Drugloanlicmanfshedulec { get; set; }
        public string Drugloanlicmanfnotshedulec { get; set; }
        public string Druglicrepacksale { get; set; }
        public string Druglicmanfsalevaccnotshedulex { get; set; }
        public string Proftaxcert { get; set; }
        public string Cfopcb { get; set; }
        public string Occupancycert { get; set; }
        public string Boilerstmpipelineerection { get; set; }
        public string Boilerstmpipelineregistration { get; set; }
        public string Shpsestbreg_forma { get; set; }
        public string Businessslic { get; set; }
        public string Liquorlic { get; set; }
        public string Stateexciseverfcert { get; set; }
        public string PowerReqKW { get; set; }
        public string GrantManufacture { get; set; }
    }
    public class CFOPayments
    {
        public string Questionnareid { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string CFEUID { get; set; }
        public string DeptID { get; set; }
        public string ApprovalID { get; set; }
        public string OnlineOrderNo { get; set; }
        public string OnlineOrderAmount { get; set; }
        public string PaymentFlag { get; set; }
        public string TransactionNo { get; set; }
        public string TransactionDate { get; set; }
        public string BankName { get; set; }

    }
    public class CFODtls
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
    public class CFOCommonDet
    {
        public string Questionnariid { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string PreRegUID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyType { get; set; }
        public string CompanyPraposal { get; set; }
        public string CompanyRegType { get; set; }
        public string CompanyRegNo { get; set; }
        public string CompanyRegDate { get; set; }
        public string FactoryType { get; set; }
        public string AuthRep_Name { get; set; }
        public string AuthRep_SoWoDo { get; set; }
        public string AuthRep_Email { get; set; }
        public string AuthRep_Mobile { get; set; }
        public string AuthRep_AltMobile { get; set; }
        public string AuthRep_TelNo { get; set; }
        public string AuthRep_DoorNo { get; set; }
        public string AuthRep_Locality { get; set; }
        public string AuthRep_DistrictID { get; set; }
        public string AuthRep_DistrictName { get; set; }
        public string AuthRep_MandalID { get; set; }
        public string AuthRep_MandalName { get; set; }
        public string AuthRep_VillageID { get; set; }
        public string AuthRep_VillageName { get; set; }
        public string AuthRep_Pincode { get; set; }
        public string AuthRep_Caste { get; set; }
        public string AuthRep_Minority { get; set; }
        public string AuthRep_DiffAbled { get; set; }
        public string AuthRep_Woman { get; set; }

        public string Unit_Location { get; set; }
        public string Unit_DoorNo { get; set; }
        public string Unit_Locality { get; set; }
        public string Unit_DistrictID { get; set; }
        public string Unit_MandalID { get; set; }
        public string Unit_VillageID { get; set; }
        public string Unit_DistrictName { get; set; }
        public string Unit_MandalName { get; set; }
        public string Unit_VillageName { get; set; }
        public string Unit_Pincode { get; set; }
        public string Unit_TelNo { get; set; }
        public string BuildingHeight { get; set; }
        public string BuiltUpArea { get; set; }
        public string ExtentofLand { get; set; }

        public string DevelopmentArea { get; set; }
        public string ApprchRdType { get; set; }
        public string ApprchRdWidth { get; set; }
        public string AffectedRdWdng { get; set; }
        public string AffectedRdWidth { get; set; }
        public string TotalEmp { get; set; }
        public string DirectMale { get; set; }
        public string DirectFemale { get; set; }
        public string DirectOthers { get; set; }
        public string InDirectMale { get; set; }
        public string InDirectFemale { get; set; }
        public string InDirectOthers { get; set; }

        public string strctralLicNo { get; set; }
        public string strctralMobileNo { get; set; }
        public string strctralName { get; set; }
        public string ArchitechtureName { get; set; }
        public string ArchitechtureLICNo { get; set; }
        public string ArchitechtureMobileNo { get; set; }
        public string AffectedExtended { get; set; }
        public string RoadCutLocation { get; set; }
        public string RoadCut { get; set; }


    }
    public class CFOLineOfManuf
    {
        public string Questionnareid { get; set; }

        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UnitID { get; set; }
        public string LOAID { get; set; }
        public string ManfItemName { get; set; }
        public string ManfItemAnnualCapacity { get; set; }
        public string ManfItemValue { get; set; }
        public string RMItemName { get; set; }
        public string RMItemAnnualCapacity { get; set; }
        public string RMItemValue { get; set; }
        public string RMSourceofSupply { get; set; }
    }
    public class CFOAttachments
    {
        public string Questionnareid { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string CFOUID { get; set; }
        public string DeptID { get; set; }
        public string ApprovalID { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileDescription { get; set; }
        public string FileType { get; set; }
        public string MasterID { get; set; }
        public string ReferenceNo { get; set; }

    }
    public class CFOQueryDet
    {

        public string Unitid { get; set; }
        public string Investerid { get; set; }
        public string Deptid { get; set; }
        public string Approvalid { get; set; }
        public string QueryID { get; set; }
        public string IPAddress { get; set; }
        public string QueryResponse { get; set; }
        public string Questionnariid { get; set; }

    }

}
