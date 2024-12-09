using System;
using System.Collections.Generic;
using System.Linq;
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
    public class SVRCCommon
    {

    }
}
