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
        public static string GetConstitutionType=  "USP_GETCONSTITUTIONTYPEMASTER";
        public static string GetPowerRequiredRange = "USP_GETPOWERRANGEMASTER";
        public static string GetElectricRegulations = "USP_GETELECTRICREGULATIONSMASTER";
        public static string GetVoltageMaster = "USP_GETVOLTAGEMASTER";
        public static string GetPowerPlantsMaster = "USP_GETPOWERPLANTSMASTER";
        public static string GetIndustryTypeMaster = "USP_GETINDUSTRYTYPEMASTER";
        public static string GetRegistrationType = "USP_GETREGISTRATIONTYPEMASTER";
        public static string GetCastemaster = "USP_GETCATSEMASTER";


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

}
