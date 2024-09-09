using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MeghalayaUIP.Common
{
    public class CFEConstants
    {
        public static string GetEntrepreneurDet = "USP_GETCFEENTREPRENEURDATA";
        public static string InsertEntrepreneurDetails = "USP_INSCFEENTREPRENEURDETAILS";
        public static string GetSector_Department = "USP_GET_SECTOR_DEPT";
        public static string InsertCFELandDetails = "USP_INSCFELANDDETAILS";
        public static string GetCFELandDet = "USP_GETRETRIVECFELANDDET";
        //Intent To Invest 
        public static string GetRetriveIntentInvest = "USP_GETINTENTTOINVESTAPPLDETAILS";
        //Intent To Invest 

        public static string GetPREREGandCFEapplications = "USP_GETPREREGANDCFEUSERDASHBOARD";
        public static string GetCFERegDetails = "USP_GETAPPROVEDINDUSTRYREGDATA";
        public static string RetrieveQuestionnaire = "USP_RETRIEVECFEQUESFILLEDDATA";
        public static string GetCFEApprovalsReq = "USP_GETCFEAPPROVALSWITHFEE";
        public static string InsertCFEQuestionnaire = "USP_INSCFEQUESTIONNAREDETAILS";
        public static string InsertCFEQuestionnaireApprovals = "USP_INSCFEREQUIREDAPPROVALS";
        public static string GetApprovalsReqFromTable = "USP_GETCFEQUESTIONNAIREAPPROVALS";

        public static string InsertCFEDepartmentapprovals = "USP_INSCFEDEPARTMENTAPPROVALS";
        public static string GetCFEObtainedOffline = "USP_GETCFEALREADYOBTAINEDAPPROVALS";
        public static string GetCFEIndustryDetails = "USP_GETCFEINDUSTRYDETAILS";
        public static string InsertCFEIndustryDetails = "USP_INSCFEINDUSTRYDETAILS";

        public static string GetCFELOMANDRMDetails = "USP_GETCFELOMANDRMDETAILS";
        public static string InsertCFEManufactureDetails = "USP_INSCFELINEOFMANFDETAILS";
        public static string InsertCFERAWMaterialDetails = "USP_INSCFERAWMATERIALDETAILS";

        public static string GetCFEPowerDetRetrive = "USP_GETRETRIVECFEPOWERDET";
        public static string InsertCFEPowerDet = "USP_INSCFEPOWERDETAILS";

        public static string GetRetriveFireDetails = "USP_GETRETRIVEFIRE";
        public static string InsertCFEFierDet = "USP_INSCFEFIREDETAILS"; 
        
        public static string InsertCFEForestDetails = "USP_INSCFEFORESTDETAILS";           
        public static string GetForestRetriveDet = "USP_GETRETRIVEFOREST";

        public static string INSERTCFEWaterDet = "USP_INSCFEWATERDETAILS";
        public static string GetCFEWaterDetails = "USP_GETCFEWATERDETAILS";

        public static string GetCFEApprovalsAmounttoPay = "USP_GETCFEAPPROVALSAMOUNTTOPAY";
        public static string InsertPaymentDetails = "USP_INSCFEPAYMENTDETAILS";
        public static string InsertCFEAttachments = "USP_INSCFEATTACHMENTS";
        public static string GetCFEAttachments = "USP_GETCFEATTACHMENTS";

        public static string GetUserCFEApplStatus = "USP_GETCFEAPPLSTATUS";
        public static string GetUserCFEApplStatusView = "USP_GETCFEAPPLSTATUSVIEW";

        public static string InsertCFELabourContractorDetails = "USP_INSCFECONTRACTLABOURDETAILS";
        public static string GetCFELabourContractorDet = "USP_GETCFECONTRACTLABOURDETAILS";
        public static string InsertCFEMigrantDetails = "USP_INSCFEMIGRANTWORKERDETAILS";
        public static string InsertCFELabourDet = "USP_INSCFELABOURDETAILS";
        public static string GetRetriveCFELabourDet = "USP_GETRETRIVECFELABOURDET";
        public static string GetCFEMigrantDetails = "USP_GETCFEMIGRANTWORKERDETAILS";

        public static string GetAppliedApprovalIDs = "USP_GETCFEAPPROVALIDS";
        public static string InsertDGSetDetails ="USP_INSCFEDGSETDETAILS";
        public static string GETANNUALTURNOVER = "USP_CHECK_ANNUALTURNOVER";
        public static string CFEENTERPRISETYPEDET = "USP_GETENTERPRISETYPEDET";
        public static string INSERTCFEDGSETDETAILS = "USP_INSCFEDGSETDETAILS";
        public static string GETCFEGSETDETAILS = "USP_GETCFEDGSETDETAILS";
        public static string InsertCFECEIGDEATISL = "USP_INSCFECEIGDETAILS";
        public static string GETCFEPOWERCEIGDETAILS = "USP_GETCFECFECEIGDETAILS";
        public static string InsertCFEPetroleum = "USP_INSCFEPETROLEUMDETAILS";
        public static string GETCFEPERTROLEUMDETAILS = "USP_GETCFEPETROLEUMDETAILS";
        public static string InsertCFEExplosiveManu = "USP_INSCFEMANUFACTUREEXPLOSIVE";
        public static string InsertCFEEXPLOSIVE = "USP_INSCFEEXPLOSIVEDETAILS";
        public static string GETEXPLOSIVEDETAILS = "USP_GETCFEEXPLOSIVEDETAILS";
        public static string InsertTaxDetails = "USP_INSCFEPROFFISSIONALBUSINESS";
        public static string InsertCFEProffessionalTaxDETAILS = "USP_INSCFEPROFFESSIONALTAXDETAILS";
        public static string GetCFETAXDETAILS = "USP_GETCFEPROFFESSIONALTAXDETAILS";
        public static string InsertCFEPCBHAZARDOUSDETAILS = "USP_INSCFEHAZWASTEDETAILS";
        public static string GetCFEHazardousDetails = "USP_GETCFEHAZWASTEDETAILS";
        public static string GetCFEQueryDashBoard = "USP_GETCFEQUERYRAISEDDEPT";

        /// <summary>
        /// DEPARTMENT STARTED
        /// </summary>

        public static string GetCFEDashBoard = "USP_CFEDASHBOARDCOUNT";
        public static string GetCFEDashBoardView = "USP_CFEDASHBOARDVIEW";
        public static string GetCFEApplicationDet = "USP_GETCFEAPPLICATIONDETAILS";
        public static string UpdateCFEDepartmentProcess = "USP_UPDATECFESCRUTINYACTION";
        ///END///

    }
    public class CFEDtls
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
    public class CFEQuestionnaireDet
    {
        public string UNITID { get; set; }
        public string PREREGUIDNO { get; set; }
        public string CFEQDID { get; set; }
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

        public string PropEmployment { get; set; }
        public string ProjectCost { get; set; }
        public string LandValue { get; set; }
        public string BuildingValue { get; set; }
        public string PlantnMachineryCost { get; set; }
        public string ExpectedTurnover { get; set; }
        public string TotalProjCost { get; set; }
        public string EnterpriseCategory { get; set; }
        public string PowerReqKW { get; set; }
        public string GeneratorReq { get; set; }
        public string BuildingHeight { get; set; }
        public string StoringRSDS { get; set; }

        public string ManfExplosives { get; set; }
        public string ManfPetroleum { get; set; }
        public string RdCtngPermission { get; set; }
        public string NonEncmbrnceCert { get; set; }
        public string CommTaxApproval { get; set; }
        public string HTMeteruse { get; set; }
        public string CEARegulationID { get; set; }
        public string PowerPlantID { get; set; }
        public string AggCapacity { get; set; }
        public string VoltageRating { get; set; }
        public string TreesFelling { get; set; }
        public string NoofTrees { get; set; }
        public string NonForstLandCert { get; set; }
        public string ForstDistLetr { get; set; }

        public string NearWaterBodyLocation { get; set; }
        public string ExistingBoreWell { get; set; }

        public string LabourAct1970 { get; set; }
        public string LabourAct1970_Workers { get; set; }
        public string LabourAct1979 { get; set; }
        public string LabourAct1979_Workers { get; set; }
        public string LabourAct1996 { get; set; }
        public string LabourAct1996_10Workers { get; set; }
        public string LabourAct1996_Workers { get; set; }

        public string ContractLabourAct { get; set; }
        public string ContractLabourAct_Workers { get; set; }
        public string ContractLabourAct1970 { get; set; }
        public string ContractLabourAct1970_Workers { get; set; }
        public string GrandWaterConnection { get; set; }
        public string WaterSupplyAgency { get; set; }
        public string RiverPublicTanker { get; set; }
        public string MuncipalAreawater { get; set; }
        public string NonMuncipalAreaUrban { get; set; }
        public string Investment { get; set; }
    }
    public class CFECommonDet
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
    public class CFEEntrepreneur
    {
        public string Questionnariid { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string CompanyName { get; set; }
        public string PromoterName { get; set; }
        public string SoWoDoName { get; set; }
        public string StateID { get; set; }
        public string StateName { get; set; }
        public string DistrictID { get; set; }
        public string DistrictName { get; set; }
        public string MandalID { get; set; }
        public string MandalName { get; set; }
        public string VillageID { get; set; }
        public string VillageName { get; set; }
        public string StreetName { get; set; }
        public string DoorNo { get; set; }
        public string Pincode { get; set; }
        public string MobileNo { get; set; }
        public string AltMobileNo { get; set; }
        public string Email { get; set; }
        public string Organization { get; set; }
        public string TelePhoneNo { get; set; }
        public string ProposalFor { get; set; }
        public string SocialStatus { get; set; }
        public string IsDiffAbled { get; set; }
        public string IsWomenEntr { get; set; }
        public string IsMinority { get; set; }
        public string LandValue { get; set; }
        public string BuildingValue { get; set; }
        public string Plant_Machinary { get; set; }
        public string TotalProjectValue { get; set; }
        public string DirectMale { get; set; }
        public string DirectFemale { get; set; }
        public string TotalEmp { get; set; }
        public string InDirectMale { get; set; }
        public string InDirectFemale { get; set; }
        public string RegistrationType { get; set; }
        public string RegistrationNo { get; set; }
        public string RegistrationDate { get; set; }
        public string FactoryType { get; set; }

    }
    public class CFELabour
    {
        public string Category_Estab { get; set; }
        public string Name_Contractor { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string Father_Name { get; set; }
        public string Door_No { get; set; }
        public string Locality { get; set; }
        public string District { get; set; }
        public string Mandal { get; set; }
        public string Village { get; set; }
        public string Pincode { get; set; }
        public string Other_State_Address { get; set; }
        public string EASTERN_WEST { get; set; }
        public string NORTH_GARO { get; set; }
        public string SOUTH_GARO { get; set; }
        public string WEST_GARO { get; set; }
        public string Date_birth { get; set; }
        public string Age { get; set; }
        public string Number { get; set; }
        public string Date { get; set; }
        public string DoorNo { get; set; }
        public string Localitys { get; set; }
        public string Districts { get; set; }
        public string Mandals { get; set; }
        public string Villages { get; set; }
        public string Pincodes { get; set; }
        public string Name { get; set; }
        public string Fathers_Name { get; set; }
        public string Ages { get; set; }
        public string Designation { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string DoorNos { get; set; }
        public string Localit { get; set; }
        public string Distric { get; set; }
        public string Manda { get; set; }
        public string Villag { get; set; }
        public string Name_Employer { get; set; }
        public string Door_Locality { get; set; }
        public string Dist { get; set; }
        public string Mand { get; set; }
        public string Vill { get; set; }
        public string Pin { get; set; }
        public string State_Address { get; set; }
        public string FullName { get; set; }
        public string District1 { get; set; }
        public string Mandal1 { get; set; }
        public string Village1 { get; set; }
        public string Door { get; set; }
        public string Pincode1 { get; set; }
        public string FullName1 { get; set; }
        public string District2 { get; set; }
        public string Mandal2 { get; set; }
        public string Village2 { get; set; }
        public string Door1 { get; set; }
        public string Name1 { get; set; }
        public string Mobile_No { get; set; }
        public string EmailId1 { get; set; }
        public string Father_Name1 { get; set; }
        public string DoorNo3 { get; set; }
        public string Locality1 { get; set; }
        public string District3 { get; set; }
        public string Mandal3 { get; set; }
        public string Village3 { get; set; }
        public string Pincode3 { get; set; }
        public string Designation1 { get; set; }
        public string Address { get; set; }
        public string Commence_Date { get; set; }
        public string End_Date { get; set; }
        public string Name2 { get; set; }
        public string DoorNo4 { get; set; }
        public string Locality2 { get; set; }
        public string District4 { get; set; }
        public string Mandal4 { get; set; }
        public string Village4 { get; set; }
        public string Pincode4 { get; set; }
        public string business_Estab { get; set; }
        public string Regitration_PE { get; set; }
        public string Nature_LAB_emp { get; set; }
        public string est_constraction { get; set; }
        public string max_emp_worker { get; set; }
        public string est_building_con { get; set; }
        public string max_migrant_work { get; set; }
        public string convicted_preceding { get; set; }
        public string revoking_Lic { get; set; }
        public string Principal_Emplyer_est { get; set; }
        public string Principal_Employer_cet { get; set; }
        public string Amount_paid { get; set; }
        public string Amount_payable { get; set; }
        public string Challan_No { get; set; }
        public string Challan_Date { get; set; }
        public string Attach_Challan { get; set; }
        public string Name_Contractors { get; set; }
        public string Addre { get; set; }
        public string Mobile1 { get; set; }
        public string Nature_work { get; set; }
        public string Max_Migrant_Workmen { get; set; }
        public string Est_Date { get; set; }
        public string Date_est_Completion { get; set; }
        public string Manufacture_Details { get; set; }
    }

    public class Water_Details
    {
        public string Questionnariid { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string Drinking_Water { get; set; }
        public string water_Industrial { get; set; }
        public string Quantity_Water { get; set; }
        public string Non_Consumptive_water { get; set; }
        public string OVERHEAD { get; set; }
        public string UNDERGROUND { get; set; }
        public string TANKER_CAPACITY { get; set; }
        public string WATERCONNECTION { get; set; }
        public string HOLDING { get; set; }
        public string WARDNO { get; set; }
        public string SUBDIVISION { get; set; }
        public string PREMISENUMBER { get; set; }
        public string WATERDEMAND { get; set; }
        public string ANYOTHERINFORMATION { get; set; }
        public string DISTRIC { get; set; }
        public string MANDAL { get; set; }
        public string VILLAGE { get; set; }
        public string LOCALITY { get; set; }
        public string LANDMARK { get; set; }
        public string PINCODE { get; set; }
        public string PURPOSECONN { get; set; }
        public string TYPECON { get; set; }
        public string DOMESTIC { get; set; }
        public string BULK { get; set; }

    }
    
    public class CFELand
    {
        public string Questionnariid { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string Survey_Plot { get; set; }
        public string District { get; set; }
        public string Mandal { get; set; }
        public string Village { get; set; }
        public string DistrictName { get; set; }
        public string MandalName { get; set; }
        public string VillageName { get; set; }
        public string Name_Grampanchayat { get; set; }
        public string Pincode { get; set; }
        public string Landline { get; set; }
        public string Total_Extent_Area { get; set; }
        public string Type_Building { get; set; }
        public string Land_Master_Plan { get; set; }
        public string Proposed_Area_Develop { get; set; }
        public string Total_Built_Area { get; set; }
        public string Height_Building { get; set; }
        public string Existing_Width { get; set; }
        public string Type_ApproachRoad { get; set; }
        public string Land_Locationfalls { get; set; }
        public string Building_Approval { get; set; }
        public string Industry_Product { get; set; }
        public string Category_Industry { get; set; }
        public string Name_indu_Under { get; set; }
        public string Road_Widening { get; set; }
        public string land_part { get; set; }
        public string Architect_LICNo { get; set; }
        public string Architect_Name { get; set; }
        public string Architect_MobileNo { get; set; }
        public string Structural_Engineer { get; set; }
        public string Structural_Mobile_No { get; set; }
        public string StructuralLicNo { get; set; }
        public string Architectural_dwg { get; set; }
        public string Common_Affidavit { get; set; }
    }
    public class CFEPower
    {
        public string Questionnariid { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string Con_Load_HP { get; set; }
        public string Maximum_KVA { get; set; }
        public string Voltage_Level { get; set; }
        public string Existing_Service { get; set; }
        public string Per_Day { get; set; }
        public string Per_Month { get; set; }
        public string Expected_Month_Trial { get; set; }
        public string Probable_Date_Power { get; set; }
        public string LoadReq { get; set; }
        public string EnergySource { get; set; }

    }
    public class CFEForest
    {
        public string Questionnariid { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string Species { get; set; }
        public string Est_Length_Timber { get; set; }
        public string Est_Volume_Timber { get; set; }
        public string Girth { get; set; }
        public string Est_Firewood { get; set; }
        public string No_Poles { get; set; }
        public string North { get; set; }
        public string East { get; set; }
        public string West { get; set; }
        public string South { get; set; }
        public string Area_Land { get; set; }
        public string Non_Forest_land_cet { get; set; }
        public string Loc_Address_Land { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Village { get; set; }
        public string Pincode { get; set; }
        public string Geographic_Land { get; set; }
        public string ordinates_desc { get; set; }
        public string Latitude { get; set; }
        public string Degrees { get; set; }
        public string Minutes { get; set; }
        public string Seconds { get; set; }
        public string Degree { get; set; }
        public string Minute { get; set; }
        public string Second { get; set; }
        public string GPS_Coordinates { get; set; }
        public string pur_Application { get; set; }
        public string Forest_Division { get; set; }
    }
    public class CFELineOfManuf
    {
        public string Questionnareid { get; set; }

        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string LOAID { get; set; }
        public string ManfItemName { get; set; }
        public string ManfItemAnnualCapacity { get; set; }
        public string ManfItemValue { get; set; }
        public string RMItemName { get; set; }
        public string RMItemAnnualCapacity { get; set; }
        public string RMItemValue { get; set; }
        public string RMSourceofSupply { get; set; }
    }
    public class CFEFire
    {

        public string Questionnariid { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string DistricId { get; set; }
        public string MandalId { get; set; }
        public string VillageId { get; set; }
        public string DistricName { get; set; }
        public string MandalName { get; set; }
        public string VillageName { get; set; }
        public string Locality { get; set; }
        public string Landmark { get; set; }
        public string Pincode { get; set; }
        public string HeightBuilding { get; set; }
        public string HeightFloor { get; set; }
        public string PlotArea { get; set; }
        public string builoduparea { get; set; }
        public string ProposedDrive { get; set; }
        public string ExistingRoad { get; set; }
        public string CategoryBuilding { get; set; }
        public string FeeAmount { get; set; }
        public string East { get; set; }
        public string Distancebuild { get; set; }
        public string West { get; set; }
        public string Distanceproposed { get; set; }
        public string North { get; set; }
        public string Distancemeter { get; set; }
        public string South { get; set; }
        public string buildingdist { get; set; }
        public string Firestation { get; set; }

    }
    public class Forest_Details
    {
        public string Questionnariid { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string Address { get; set; }
        public string Lattitude { get; set; }
        public string LatDegrees { get; set; }
        public string LatMinutes { get; set; }
        public string LatSeconds { get; set; }
        public string Longitude { get; set; }        
        public string LongDegrees { get; set; }
        public string LongMinutes { get; set; }
        public string LongSeconds { get; set; }
        public string GPSCoodinates { get; set; }
        public string Purpose { get; set; }
        public string ForestDivision { get; set; }
        public string information { get; set; }
        public string Species { get; set; }
        public string EstTimberLength { get; set; }
        public string EstTimberVolume { get; set; }
        public string Girth { get; set; }
        public string Est_Firewood { get; set; }
        public string No_Poles { get; set; }
        public string North { get; set; }
        public string East { get; set; }
        public string West { get; set; }
        public string South { get; set; }
        public string Area_Land { get; set; }
        public string Non_Forest_land_cert { get; set; }
        public string Loc_Address_Land { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Village { get; set; }
        public string Pincode { get; set; }
        public string Geographic_Land { get; set; }
        public string ordinates_desc { get; set; }      

    }
    public class CFEPayments
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
    public class CFEAttachments
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
    public class Labour_Details
    {
        public string Questionnariid { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string Category_Estab { get; set; }
        public string Name_Contractor { get; set; }
        public string Father_Name { get; set; }
        public string Age { get; set; }
        public string Designation { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string District { get; set; }
        public string DistrictName { get; set; }
        public string MandalName { get; set; }
        public string Mandal { get; set; }
        public string VillageName { get; set; }
        public string Village { get; set; }
        public string Door_No { get; set; }
        public string Locality { get; set; }
        public string Pincode { get; set; }

        public string ManagerName { get; set; }
        public string ManagerMobile { get; set; }
        public string ManagerEmail { get; set; }
        public string ManagerFather { get; set; }
        public string ManagerDoor { get; set; }
        public string ManagerLocality { get; set; }
        public string ManagerDistrict { get; set; }
        public string ManagerMandal { get; set; }
        public string ManagerVillage { get; set; }
        public string ManagerPincode { get; set; }
        public string ManagerDesignation { get; set; }
        public string NatureOflabourCont { get; set; }
        public string BuildingContractWork { get; set; }
        public string BuildingEmpDay { get; set; }
        public string EstDateBuilding { get; set; }
        public string MigrantWork { get; set; }
        public string ContractFiveYears { get; set; }
        public string Revoking { get; set; }
        public string PrincipleEmpWork { get; set; }
        public string ManuooCupation { get; set; }
        public string ContarctorName { get; set; }
        public string ContarctorFather { get; set; }
        public string ContarctorAge { get; set; }
        public string ContarctorMobile { get; set; }
        public string ContarctorEmailId { get; set; }
        public string ContarctorDistrict { get; set; }
        public string ContarctorMandals { get; set; }
        public string ContarctorVillages { get; set; }
        public string ContarctorDoor { get; set; }
        public string ContarctorLocality { get; set; }
        public string ContarctorPincode { get; set; }
        public string AgentName { get; set; }
        public string AgentDoorNo { get; set; }
        public string AgentLocality { get; set; }
        public string AgentDistric { get; set; }
        public string AgentMandal { get; set; }
        public string AgentVillage { get; set; }
        public string AgentPinCode { get; set; }
        public string CFECL_CONTRACTORNAMEADDRESS { get; set; }
        public string CFECL_WORKNAMENATURELOCATION { get; set; }
        public string CFECL_MAXCONTRACTLABOUR { get; set; }
        public string CFECL_CONTRACTDURATION { get; set; }
        public string CFECL_COMMENCEMENTDATEOFWORK { get; set; }
        public string CFECL_COMPLETIONDATEOFWORK { get; set; }
        public string CFECL_TERMINATIONDATEOFEMP { get; set; }

        public string CONTRACTORNAMEADDRESS { get; set; }
        public string MIGRANTNAMENATURELOCATION { get; set; }
        public string MAXCONTRACTMIGRANT { get; set; }
        public string CONTRACTDURATION { get; set; }
        public string COMMENCEMENTDATE { get; set; }
        public string COMPLETIONDATEOFWORK { get; set; }
        public string TERMINATIONDATEOFEMPMigrant { get; set; }

    }
    public class CFEDGset
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

    public class CFECEIG
    {
        public string Questionnareid { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string UnitId { get; set; }
        public string ALREADY { get; set; }
        public string PROPOSED { get; set; }
        public string TOTAL { get; set; }
        public string CONNECTEDLOAD { get; set; }
        public string INSTALLED { get; set; }
        public string PROPOSE { get; set; }
        public string TOTALS { get; set; }
        public string REGULATION { get; set; }
        public string voltage { get; set; }
        public string Plant { get; set; }
        public string CAPACITY { get; set; }
        public string LOCATIONFACTORY { get; set; }
        public string SURVEYNO { get; set; }
        public string EXTENT { get; set; }
        public string DISTRIC { get; set; }
        public string MANDAL { get; set; }
        public string VILLAGE { get; set; }
        public string STREETNAME { get; set; }
        public string PINCODE { get; set; }
        public string TELEPHOPNE { get; set; }
        public string NEARESTPHONENO { get; set; }
        public string DATE { get; set; }

    }
    public class CFEPETROLEUM
    {
        public string Questionnareid { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string UnitId { get; set; }
        public string NOCPETROLPUMP { get; set; }
        public string NOCREQ { get; set; }
        public string DISTRIC { get; set; }
        public string MANDAL { get; set; }
        public string VILLAGE { get; set; }
        public string LOCATEDROAD { get; set; }
        public string NAMEEST { get; set; }
        public string LANDHOLDINGNO { get; set; }
        public string LANDLEASER { get; set; }
        public string REGNO { get; set; }
        public string AREALANDHOLDINGNO { get; set; }
        public string NORTH { get; set; }
        public string EAST { get; set; }
        public string SOUTH { get; set; }
        public string WEST { get; set; }
        public string FRONTAGE { get; set; }
        public string DEPTH { get; set; }
    }
    public class CFEEXPLOSIVE
    {
        public string Questionnareid { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string UnitId { get; set; }
        public string EXPLOSIVESITE { get; set; }
        public string EXPLOSIVEROADVAN { get; set; }
        public string CRIMINAL1973 { get; set; }
        public string DETAIL { get; set; }
        public string EXPLOSIVE1884 { get; set; }
        public string DETAILS { get; set; }
        public string APPROVAL101 { get; set; }
        public string APPROVALDETAILS { get; set; }
        public string INFORMATION { get; set; }
        public string NAME { get; set; }
        public string CLASS { get; set; }
        public string DIVISION { get; set; }
        public string QUANTITYTIME { get; set; }
        public string QUANTITYMONTH { get; set; }
    }

    public class CFETAXDetails
    {
        public string Questionnareid { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string UnitId { get; set; }
        public string APPLYAS { get; set; }
        public string NAMEEST { get; set; }
        public string ADDRESSEST { get; set; }
        public string DISTRICEST { get; set; }
        public string PINCODEEST { get; set; }
        public string TOTALNOEMPEST { get; set; }
        public string DATE { get; set; }
        public string CONSTITUTIONEST { get; set; }
        public string GOODSSUPPLIESEST { get; set; }
        public string ADDITIONPLACEBUSINESS { get; set; }
        public string DESIGNATION { get; set; }
        public string REGUNDERACT { get; set; }
        public string REGTYPE { get; set; }
        public string REGNO { get; set; }
        public string PLACEBUSINESS { get; set; }
        public string ADDRESS { get; set; }
        public string DISTRIC { get; set; }
        public string TOTALWORKINGEMPTE { get; set; }

    }
    public class CFEPCBHAZARDOUSDET
    {
        public string Questionnareid { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string UnitId { get; set; }
        public string AUTHORIZATIONREQ { get; set; }
        public string WASTEHANDLEANNUM { get; set; }
        public string WASTESTOREDTIME { get; set; }
        public string QUANTITYWASTEANNUM { get; set; }
        public string QUANTITYSTOREDTIME { get; set; }
        public string YEAROFPRODUCTION { get; set; }
        public string INDUSTRYWORK { get; set; }
    }
    public class CFEQueryDet
    {      
      
        public string Unitid { get; set; }
        public string Investerid { get; set; }
        public string Deptid { get; set; }
        public string Approvalid { get; set; }
        public string QueryID { get; set; }
        public string IPAddress { get; set; }      
        public string QueryResponse { get; set; }     
        
    }

}
