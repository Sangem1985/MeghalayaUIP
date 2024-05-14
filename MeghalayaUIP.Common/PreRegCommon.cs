using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MeghalayaUIP.Common
{
    public class PreRegConstants
    {    /*-----------------------User-----------------------------*/
        public static string GetIndustryRegData = "USP_GET_INDUSTRYREG_DATA";
        public static string GetRevenueProjectionsMaster = "USP_GET_REVENUE_PROJECTIONS";
        public static string InsertIndRegBasicDetails = "USP_INS_PREREGBASICDETAILS"; /* "USP_INS_Insvester_basicdetails";*/
        public static string InsertIndRegRevenueDetails = "USP_INS_INVESTER_BASICREVENUE_PROJECTIONS";
        public static string InsertIndRegPromotersDetails = "USP_INS_INSVESTER_DIRECTOR_DETAILS";
        public static string GetIndustryRegUserDashboard = "USP_GETPREREGUSERDASHBOARD";
        public static string GetIndRegUserApplDetails = "USP_GETPREREGUSERDASHBOARDVIEWDETAILS";
        public static string UpdateIndRegApplQueryRespose = "USP_UPDATEPREREGAPPLQUERYRESPONSE"; 
        public static string GetIndustryRegistrationQueryDetails = "USP_GETPREREGDEPTRRAISEDQUERIES";
        /*-----------------------End of User-----------------------------*/

        //public static string InsertPreRegJDDept = "USP_INS_DEPARTMENT_APPROVALS";
        public static string GetSectorDepartments = "USP_GET_SECTOR_DEPT";
        public static string GetPreRegDashBoard = "USP_PREREGDASHBOARDCOUNT";
        public static string GetPreRegDashBoardView = "USP_PREREGDASHBOARDVIEW";
        public static string GetPreRegNodelOfficer = "USP_PREREGDASHBOARDVIEWDETAILS";
        public static string GetPreRegApprovals = "USP_UPDATEPREREGPROCESSACTION";       
        public static string PreRegUpdateQuery = "USP_UPDATEPREREGQUERYACTION";
        public static string GetDeptMst = "USP_GET_MASTER_DEPT_LIST";
        public static string GetIntentInvestdash = "USP_GETINTENTTOINVESTAPPL";
    }
    public class IndustryDetails
    {
        public string UserID { get; set; }
        public string IPAddress { get; set; }
        public string CompanyName { get; set; }
        public string CompanyPAN { get; set; }
        public string CompnyRegDt { get; set; }
        public string CompnyType { get; set; }
        public string CompnyProposal { get; set; }
        public string UdyamorIEMNo { get; set; }
        public string GSTNo { get; set; }
        public string AuthReprName { get; set; }
        public string AuthReprMobile { get; set; }
        public string AuthReprEmail { get; set; }
        public string AuthReprLocality { get; set; }
        public string AuthReprDist { get; set; }
        public string AuthReprDistID { get; set; }
        public string AuthReprTaluka { get; set; }
        public string AuthReprTalukaID { get; set; }
        public string AuthReprVillage { get; set; }
        public string AuthReprVillageID { get; set; }
        public string AuthReprPincode { get; set; }
        public string LandType { get; set; }
        public string PropLocDoorno { get; set; }
        public string PropLocLocality { get; set; }
        public string PropLocDist { get; set; }
        public string PropLocDistID { get; set; }
        public string PropLocTaluka { get; set; }
        public string PropLocTalukaID { get; set; }
        public string PropLocVillage { get; set; }
        public string PropLocVillageID { get; set; }
        public string PropLocPincode { get; set; }
        public string NatureofActivity { get; set; }
        public string ManfActivity { get; set; }
        public string Manfproduct { get; set; }
        public string ServiceActivity { get; set; }
        public string ServiceTobeProviding { get; set; }
        public string ProductionNO { get; set; }
        public string ServiceNo { get; set; }
        public string DCPorOperation { get; set; }
        public string AnnualCapacity { get; set; }
        public string EstimatedProjCost { get; set; }
        public string LandAreainSqft { get; set; }
        public string CivilConstr { get; set; }
        public string PlantnMachineryCost { get; set; }
        public string Rawmaterial { get; set; }
        public string BuildingAreaSqm { get; set; }
        public string WaterReqKLD { get; set; }
        public string PowerReqKV { get; set; }
        public string WasteDetails { get; set; }
        public string HazWasteDetails { get; set; }
        public string CapitalInvestment { get; set; }
        public string FixedAssets { get; set; }
        public string MeasurementUnits { get; set; }
        public string LandValue { get; set; }
        public string BuildingValue { get; set; }
        public string WaterValue { get; set; }
        public string ElectricityValue { get; set; }
        public string WorkingCapital { get; set; }
        public string CapitalSubsidy { get; set; }
        public string PromoterEquity { get; set; }
        public string LoanAmount { get; set; }
        public string EquityAmount { get; set; }
        public string UnsecuredLoan { get; set; }
        public string InternalResources { get; set; }
        public string CetralSchemeAmount { get; set; }
        public string UnnatiSchemeAmount { get; set; }
        public string StateSchemeAmount { get; set; }
        public string DoorNo { get; set; }
        public string RegistrationNo { get; set; }
        public string RegistrationType { get; set; }
        public string Year1Value { get; set; }
        public string Year2Value { get; set; }
        public string Year3Value { get; set; }
        public string Year4Value { get; set; }
        public string Year5Value { get; set; }
        public string RevProjID { get; set; }

        public string DPRFilepath { get; set; }
        public string DPRFileName { get; set; }
        public string UnitID { get; set; }
        public string Deptid { get; set; }        
        public string SectorName { get; set; }
        public string Lineofacitivityid { get; set; }
        public string Category { get; set; }
        public string QueryID { get; set; }
        public string QueryResponse { get; set; }
        public string EligibleFlag { get; set; }
    }
    public class PromoterDetails
    {
        public string PromoterFirstname { get; set; }
        public string PromoterLastname { get; set; }
        public string PromoterAadhar { get; set; }
        public string PromoterPAN { get; set; }
        public string PromoterDIN { get; set; }
        public string PromoterNationality { get; set; }
        public string PromoterAddress1 { get; set; }
        public string PromoterAddress2 { get; set; }
        public string PromoterVillage { get; set; }
        public string PromoterTaluka { get; set; }
        public string PromoterDist { get; set; }
        public string PromoterState { get; set; }
        public string PromoterPinCode { get; set; }
        public string PromoterCountry { get; set; }
        public string PromoterEmail { get; set; }
        public string PromoterMobile { get; set; }

    }
    public class PreRegDtls
    {
        public string UserName { get; set; }
        public string UserID { get; set; }
        public int Role { get; set; }
        public int? status { get; set; }
        public string Unitid { get; set; }
        public string Investerid { get; set; }
        public int Stage { get; set; }
        public string ViewStatus { get; set; }
        public string Remarks { get; set; }
        public int? deptid { get; set; }
        public string DeptDesc { get; set; }
        public string IPAddress { get; set; }
        public string LandArea { get; set; }
        public string Power { get; set; }
        public string Water { get; set; }
        public string WasteDetails { get; set; }
        public string HazDetails { get; set; }
        public string QuerytoDept { get; set; }
        public string QuerytoDeptID { get; set; } // FROM IMA TO DEPT (OR) FROM COMM TO IMA OR DEPT
        public string QueryID { get; set; }
        public string QueryResponse { get; set; }
    }
    public class InvBasicDtls
    {
        public string Registrationdate { get; set; }
        public string Udyamno { get; set; }
        public string Gstnno { get; set; }
        public string Rep_name { get; set; }
        public string Rep_mobile { get; set; }
        public string Rep_email { get; set; }
        public string Rep_locality { get; set; }
        public string Rep_district { get; set; }
        public string Rep_mandal { get; set; }
        public string Rep_village { get; set; }
        public string Rep_pincode { get; set; }
        public string Unit_doorno { get; set; }
        public string Unit_locality { get; set; }
        public string Unit_district { get; set; }
        public string Unit_mandal { get; set; }
        public string Unit_village { get; set; }
        public string Unit_picode { get; set; }
        public string Project_noa { get; set; }
        public string Project_mmsa { get; set; }
        public string Project_pmsp { get; set; }
        public string Project_dcp { get; set; }
        public string Project_prod_no { get; set; }
        public string Project_ac { get; set; }
        public string Project_epc { get; set; }
        public string Project_land { get; set; }
        public string Project_civil_constrction { get; set; }
        public string Project_pm { get; set; }
        public string Project_mmpp { get; set; }
        public string Project_building { get; set; }
        public string Project_hazardous { get; set; }
        public string Project_ifc { get; set; }
        public string Project_dfa { get; set; }
        public string Project_um { get; set; }
        public string Project_bs { get; set; }
        public string Project_water { get; set; }
        public string Project_electric { get; set; }
        public string Project_wc { get; set; }
        public string Frd_cs { get; set; }
        public string Frd_pe { get; set; }
        public string Frd_loan { get; set; }
    }
    public class InvDirDtls
    {
        public string Idd_firstname { get; set; }
        public string Idd_lastname { get; set; }
        public string Idd_adno { get; set; }
        public string Idd_pan { get; set; }
        public string Idd_dinno { get; set; }
        public string Idd_nationality { get; set; }
        public string Idd_doorno { get; set; }
        public string Idd_street { get; set; }
        public string Idd_city { get; set; }
        public string Idd_district { get; set; }
        public string Idd_mandal { get; set; }
        public string Idd_state { get; set; }
        public string Idd_pincode { get; set; }
        public string Idd_country { get; set; }
        public string Idd_email { get; set; }
        public string Idd_phone { get; set; }

    }
}
