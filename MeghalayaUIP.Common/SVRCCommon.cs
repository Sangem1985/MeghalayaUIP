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

        public static string GetBMWEquipment = "USP_GETBMW_WASTETYPE";
        public static string InsertBMWDetails = "USP_INSBMWDETAILS";
        public static string InsertWasteDetails = "USP_INSBMWWASTEDETAILS";
        public static string InsertBMWBIOMEDICALDET = "USP_INSBMWEQUIPMENT";
        public static string GetSrvcBMWDetails = "USP_GETBMWDETAILS";
        public static string InsertSVRCAttachments = "USP_INSSRVCATTACHMNETS";

        public static string GetSRVCapplications = "USP_GETSRVCUSERDASHBOARD";

        public static string GetSRVCApprovals = "USP_GETSRVCAPPROVALS";
        public static string InsertSRVCDeptApprovals = "USP_INS_SRVCDPETAPPROVALS";
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
    public class SvrcBMWDet
    {
        public string UnitId { get; set; }
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
}
