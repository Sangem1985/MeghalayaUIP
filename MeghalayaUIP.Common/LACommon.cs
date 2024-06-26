using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeghalayaUIP.Common
{
    public class LANDConstants
    {

        public static string InsertIndustryDetails = "USP_INSLAINDUSTRIALESTATEDETAILS";
        public static string InsertManufactureDetails = "USP_INSLAMANUFACTUREDETAILS";
        public static string InsertRawMaterialDetails = "USP_INSLARAWMATERIALDETAILS";
        public static string InsertPowerDetails = "USP_INSLAPOWERREQDETAILS";
        public static string InsertWaterDetails = "USP_INSLAWATERREQMANUDETAILS";
        public static string InsertIndustrialShedDetails = "USP_INSLAINDUSTRIALSHEDDETAILS";
        public static string GetIndustrialShedDetails = "USP_GETLAINDUSTRIALSHEDDETAILS";
        public static string GetLandUserDashBoard = "USP_GETLANDUSERDASHBOARD";
        public static string GetLandApplicationDet = "USP_GETLANDUSERDASHBOARDDETAILS";

    }


    public class LANDQUESTIONNAIRE
    {
        public string Questionnariid { get; set; }
        public string UnitId { get; set; }
        public string CreatedBy { get; set; }
        public string IPAddress { get; set; }
        public string UNITID { get; set; }
        public string COMPANYNAME { get; set; }
        public string DISTRIC { get; set; }
        public string MANDAL { get; set; }
        public string VILLAGE { get; set; }
        public string EQUITY { get; set; }
        public string LOANBANK { get; set; }
        public string UnsecuredLOAN { get; set; }
        public string INTERNALRESOURCE { get; set; }
        public string OTHERSOURCE { get; set; }
        public string TOTAL { get; set; }
        public string ENTERPRISE { get; set; }
        public string PMLAKH { get; set; }
        public string TOTALPROJECTCOST { get; set; }
        public string WASTEGENERATOR { get; set; }
        public string NAMEINDUSTRYPARK { get; set; }
        public string QUANTUMLAND { get; set; }
        public string SHEDSNO { get; set; }

        public string NAMEPRODUCT { get; set; }
        public string MUNUCAPACITY { get; set; }
        public string APPROXVALUE { get; set; }

        public string RAWMATERIALNAME { get; set; }
        public string ANNUALCONSUMPTION { get; set; }
        public string APPROXVALUELAKH { get; set; }

        public string QUANTUMENERGYLOAD { get; set; }
        public string SOURCEENERGYLOAD { get; set; }

        public string WATERMANU { get; set; }
        public string SOURCEWATER { get; set; }
    }
}
