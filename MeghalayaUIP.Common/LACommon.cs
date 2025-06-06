﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeghalayaUIP.Common
{
    public class LANDConstants
    {
        public static string GetLandUserDashBoard = "USP_GETLANDUSERDASHBOARD";

        //public static string InsertIndustryDetails = "USP_INSLAINDUSTRIALESTATEDETAILS";
        public static string InsertIndustrialShedDetails = "USP_INSLAINDUSTRIALSHEDDETAILS";
        public static string InsertManufactureDetails = "USP_INSLAMANUFACTUREDETAILS";
        public static string InsertRawMaterialDetails = "USP_INSLARAWMATERIALDETAILS";
        public static string InsertPowerDetails = "USP_INSLAPOWERREQDETAILS";
        public static string InsertWaterDetails = "USP_INSLAWATERREQMANUDETAILS";
        public static string GetIndustrialShedDetails = "USP_GETLAINDUSTRIALSHEDDETAILS";
        public static string GetLandApplicationDet = "USP_GETLANDUSERDASHBOARDDETAILS";
        public static string SubmitLandApplication ="USP_SUBMITLANDAPPLICATION";
        public static string GetLANDApprovalsAmounttoPay = "USP_GETLANDAPPROVALSAMOUNTTOPAY";

        public static string InsertIndLandStateDetails = "USP_INSLAINDUSTRIALESTATEDETAILS";
        public static string GetLandDetails = "USP_UPDATEPLANDALLOTMENTPROCESACTION";
        public static string GetLandAllotmentDetails = "USP_UPDATELANDALLOTMENT";

        ////////////////////////////////////----------------------------------/////////////////////////////////
        ///
        public static string GetLandDeptDashBoard = "USP_GETLANDDASHBOARD";
        public static string GetLANDDashBoardView = "USP_LANDDASHBOARDDRILLDOWN";
        public static string GetLAAttachments = "USP_GETLAATTACHMENTS";
        public static string InsertLAAttachments = "USP_INSLAATTACHMENTS";

    }


    public class LANDQUESTIONNAIRE
    {
        public string Questionnariid { get; set; }
        public string UnitId { get; set; }
        public string UIDNO { get; set; }
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
        public string PROCESSINGFEE { get; set; }
        public string ANNUALTURNOVER { get; set; }
    }
    public class LADeptDtls
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
    public class LAAttachments
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
        public string UploadBy { get; set; }
        public string UploadByID { get; set; }

    }
    public class LANDALLOTMENTIND
    {

        public string UNITID { get; set; }
        public string Investerid { get; set; }
        public string status { get; set; }
        public string UserID { get; set; }
        public string deptid { get; set; }
        public string Remarks { get; set; }
        public string Payment { get; set; }
        public string IPAddress { get; set; }      

    }

}
