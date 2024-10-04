using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeghalayaUIP.Common
{
    public class MasterConstants
    {
        public static string GetCountriesmaster = "USP_GET_COUNTRY";
        public static string GetStatesmaster = "USP_GET_STATE";
        public static string GetDistrcitsmaster = "USP_GET_DISTRICT";
        public static string GetMandalsmaster = "USP_GET_MANDALS";
        public static string GetVillagesmaster = "USP_GET_VILLAGE";
        public static string GetDeptmaster = "USP_GET_MASTER_DEPT_LIST";
        public static string GetSectormaster = "USP_GET_Sector";
        public static string GetLineOfActivitymaster = "USP_GET_LineofActivity";
        public static string GetPCBCategory = "USP_GET_PCBCategory";
        public static string GetConstitutionType = "USP_GETCONSTITUTIONTYPEMASTER";
        public static string GetPowerRequiredRange = "USP_GETPOWERRANGEMASTER";
        public static string GetElectricRegulations = "USP_GETELECTRICREGULATIONSMASTER";
        public static string GetVoltageMaster = "USP_GETVOLTAGEMASTER";
        public static string GetPowerPlantsMaster = "USP_GETPOWERPLANTSMASTER";
        public static string GetIndustryTypeMaster = "USP_GETINDUSTRYTYPEMASTER";
        public static string GetRegistrationType = "USP_GETREGISTRATIONTYPEMASTER";
        public static string GetCastemaster = "USP_GETCATSEMASTER";

        public static string InsertInvestment = "USP_INSINTENTTOINVEST";
        public static string Getsector = "USP_GETSECTORS";
        public static string GetEnterpriseType = "USP_GETENTERPRISETYPE";
        public static string GetPOWERENERGYLOAD = "USP_GET_POWERENERGYLOAD";

        public static string GetVoltages = "USP_GETVOLTAGE";
        public static string GetForestDivision = "USP_GETRFORESTDIVISIONSMASTER";
        public static string GetDepartmentmaster = "USP_GET_DEPARTMETS";//Departments for Grievance
        public static string GetModulesMaster = "USP_GETMODULESMASTER";//Modules for Grievance
        public static string GetCategoryEST = "USP_GETCATEGORYEST";
        public static string GetDistricEST = "USP_GETDISTESTABLISHMENT";

        public static string GetBoilerType = "USP_GETBOILERTYPE";
        public static string GetDistric = "USP_GETDISTRIC";
        public static string GetRegType = "USP_GETREGTYPE";
        public static string GETBuildingType = "USP_GETBUILDINGTYPES";
        public static string GetMARKET = "USP_GETMARKET";
        public static string GetAnnualgross = "USP_GETANNUALGROSS";
        public static string GETMaincategory = "USP_GETMAINCATEGORY";
        public static string GetCertifcateDetails = "USP_GETGETCERTIFCATEDETAILS";
        public static string GetAcknowlegementDetails = "USP_GET_ACKNOWLEDGEMENT_DETAILS";
        public static string GetSingleWindowDepts = "USP_GET_SINGLE_WINDOW_DASHBOARD_DEPTS";
        public static string GetSingleWindowApprovals = "USP_GET_SINGLE_WINDOW_DASHBOARD_APPROVALS";
        public static string GetDGPOWER = "USP_GETDGPOWER";
        public static string GetMAXPOWER = "USP_MAXAMOUNTPOWER";
        public static string GetWorkYears = "USP_NOOFWORKERSYEARS";

        public static string GetIndustryParks = "USP_INSINDUSTRIALPARKS";
        public static string GetWaterSource = "USP_GETWATERSOURCEMASTER";

        public static string GetCentralRepository = "USP_GET_CENTRALREPOSITORY_FILES";
        public static string GetInformationWizard = "USP_GETINFORMATIONWIZARD";
        public static string GetPageAuthorization = "USP_CHECK_ROLE_PAGE_AUTH";

        public static string GetGrievanceMisReport = "USP_GET_GRIEVANCE_MIS_REPORT";
        public static string GrievanceHandledDashboard = "USP_GET_QUERYHANDLING_DASHBOARD_EODB";

        public static string MISIIncentiveDashboard = "USP_GETINCENTIVEDASHBOARD";

        public static string GetYearMaster = "USP_GETYEAR";
        public static string GetMonthMaster = "USP_GETMONTH";
        //--------------------------///////////
        public static string GetUserAmmendments = "USP_GET_Comments_Ammendment_ID";
        public static string GetAmmendments = "USP_GET_AMMENDMENTS";
        public static string InsertDeptAmmendments = "USP_INS_DEPTAMMENDMENTS";

       // public static string GetAmmendments = "USP_GET_AMMENDMENTS";
        public static string InsertAmmendmentsComment = "USP_INSAMMENDMENTCOMMENTS";
        public static string GetAmmendmentsDepartments = "USP_GETDEPTDEPARTMENTS";
        public static string GetUserCommentsofAmmendments = "USP_GET_Comments_Ammendment_ID";
        public static string GetAmmendamentFullName = "GETAMMENDMENTDEPARTMENTDET";
        public static string GetGrievanceMisReportDrilldown = "USP_GET_GRIEVANCEMIS_REPORTDRILLDOWN";

        //-----------------------///
        public static string InsertUSERACCESSEDPAGES = "USP_INSUSERACCESSEDPAGES";
    }
    public class MasterCountry
    {
        public string CountryId { get; set; }
        public string CountryName { get; set; }

    }

    public class MasterStates
    {
        public string StateId { get; set; }
        public string StateName { get; set; }

    }
    public class MasterDistrcits
    {
        public string DistrictId { get; set; }
        public string DistrictName { get; set; }

    }

    public class MasterMandals
    {
        public string MandalId { get; set; }
        public string MandalName { get; set; }

    }

    public class MasterVillages
    {
        public string VillageId { get; set; }
        public string VillageName { get; set; }

    }

    public class MasterDepartment
    {
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }

    }
    public class MasterNationality
    {
        public string NationalityId { get; set; }
        public string Nationality { get; set; }

    }
    public class MasterEntrSector
    {
        public string SectorId { get; set; }
        public string SectorName { get; set; }

    }
    public class MasterDepartments
    {
        public string MD_DEPTID { get; set; }
        public string MD_DEPT_NAME { get; set; }

    }
    public class MasterLineOfActivity
    {
        public string LOAId { get; set; }
        public string LOAName { get; set; }

    }
    public class MasterSector
    {
        public string SectorId { get; set; }
        public string SectorName { get; set; }

    }
    public class MasterConstType
    {
        public string ConstId { get; set; }
        public string ConstName { get; set; }

    }
    public class MasterPowerReq
    {
        public string PowerReqID { get; set; }
        public string PowerReqRange { get; set; }

    }
    public class MasterElecRegulations
    {
        public string ElRegID { get; set; }
        public string ElRegNumber { get; set; }

    }
    public class MasterVoltages
    {
        public string VoltageID { get; set; }
        public string VoltageValue { get; set; }

    }
    public class MasterPowerPlants
    {
        public string PowerPlantID { get; set; }
        public string PowerPlantName { get; set; }

    }
    public class MasterIndustryType
    {
        public string IndustryTypeID { get; set; }
        public string IndustryType { get; set; }

    }
    public class MasterCaste
    {
        public string CASTEID { get; set; }
        public string CASTNAME { get; set; }
    }
    public class MasterRegistrationType
    {
        public string REGISTRATIONTYPEID { get; set; }
        public string REGISTRATIONTYPENAME { get; set; }
    }
    public class MasterSECTORS
    {
        public string SECTORID { get; set; }
        public string SECTORNAME { get; set; }
    }
    public class MasterENTERPRISETYPE
    {
        public string ENTERPRISETYPECODE { get; set; }
        public string ENTERPRISETYPE { get; set; }
    }
    public class MasterENERGYLOAD
    {
        public string ENERGYLOAD_ID { get; set; }
        public string ENERGYLOAD_NAME { get; set; }
    }
    public class MasterVoltage
    {
        public string VOLTAGEID { get; set; }
        public string VOLTAGERANGE { get; set; }
    }
    public class InvtentInvest
    {
        public string Questionnariid { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string CompanyName { get; set; }
        public string PAN { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Phoneno { get; set; }
        public string Pincode { get; set; }
        public string Emailid { get; set; }
        public string FaxNo { get; set; }
        public string Website { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string ProjectProposal { get; set; }
        public string InvestmentPrevious { get; set; }
        public string ProjectCategory { get; set; }
        public string Sector { get; set; }
        public string Proposed_Investment { get; set; }
        public string Proposed_Employment { get; set; }
        public string Project_Location { get; set; }
        public string Expected_Year { get; set; }
        public string Expectationstate_Govt { get; set; }

    }
    public class MasterForestDivision
    {
        public string FORESTDIV_ID { get; set; }
        public string FORESTDIV_NAME { get; set; }
    }
    public class MasterModule
    {
        public string ModuleID { get; set; }
        public string ModuleName { get; set; }
    }
    public class MasterCategoryEst
    {
        public string CATEGORYEST_ID { get; set; }
        public string CATEGORYEST_NAME { get; set; }
    }
    public class MasterDistricEST
    {
        public string DISTRICEST_ID { get; set; }
        public string DISTRICEST_NAME { get; set; }
    }
    public class MasterBOILERTYPE
    {
        public string BOILER_ID { get; set; }
        public string BOILER_NAME { get; set; }
    }
    public class MasterDistric
    {
        public string DISTRIC_ID { get; set; }
        public string DISTRIC_NAME { get; set; }
    }
    public class MasterREGTYPE
    {
        public string REGISTRATIONTYPE_ID { get; set; }
        public string REGISTRATIONTYPE_NAME { get; set; }
    }
    public class MasterBuildingType
    {
        public string BUILDINGTYPE_ID { get; set; }
        public string BUILDINGTYPE_NAME { get; set; }
    }   
    public class MasterMARKET
    {
        public string MARKET_ID { get; set; }
        public string MARKET_NAME { get; set; }
    }
    public class MasterANNUALGROSS
    {
        public string ANNUALGROSS_ID { get; set; }
        public string ANNUALGROSS_NAME { get; set; }
    }
    public class MasterMAINCATEGORY
    {
        public string MAINCATEGORY_ID { get; set; }
        public string MAINCATEGORY_NAME { get; set; }
    }
    public class MasterDGPOWER
    {
        public string DGPOWER_ID { get; set; }
        public string DGPOWER_NAME { get; set; }
    }
    public class MasterMAXAMOUNTPOWER
    {
        public string MAXAMOUNTPOWER_ID { get; set; }
        public string MAXAMOUNTPOWER_NAME { get; set; }
    }
    public class MasterNOOFWORKERSYEARS
    {
        public string NOOFWORKERSYEARS_ID { get; set; }
        public string NOOFWORKERS_NAME { get; set; }
    }
    public class MasterINDUSTRIALPARKS
    {
        public string INDUSTRIALPARK_ID { get; set; }
        public string INDUSTRIALPARK_NAME { get; set; }
    }
    public class MasterWaterSource
    {
        public string WATERSOURCE_ID { get; set; }
        public string WATERSOURCE_NAME { get; set; }
    }
    public class MasterYear
    {
        public string YEAR_ID { get; set; }
        public string YEAR { get; set; }
    }
    public class MasterMonth
    {
        public string MONTH_ID { get; set; }
        public string MONTH_NAME { get; set; }
    }
    public class Ammendmentvo
    {
        public string Dept_ID
        {
            get;
            set;
        }

        public string Dept_Name
        {
            get;
            set;
        }

        public string Ammendment
        {
            get;
            set;
        }
        public string Ammendment_Date
        {
            get;
            set;
        }
        public string Ammendment_Path
        {
            get;
            set;
        }
        public string UserName
        {
            get;
            set;
        }
        public string District
        {
            get;
            set;
        }
        public string MobileNo
        {
            get;
            set;
        }
        public string MailId
        {
            get;
            set;
        }
        public string Ammendment_Id
        {
            get;
            set;
        }
        public string Comments
        {
            get;
            set;
        }
        public string Created_By
        {
            get;
            set;
        }
        public string Amm_FileName
        {
            get;
            set;
        }
        public string Amm_Type
        {
            get;
            set;
        }
        public string IPAddress
        {
            get;
            set;
        }
    }



}
