using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeghalayaUIP.Common
{
    public static class CommonConstants
    {
        public static string LogEorror = "USP_INS_ERRORLOG";

        public static string GetMainApplicantDashBoard = "USP_GET_UNITS_BY_INVESTORS";
        public static string GetApplbyModuleName = "USP_GETAPPLBYMODULENAME";
        public static string GetUserCFETracker = "USP_GETUSERCFEAPPLTRACKER";
        //public static string GetUserStatusByModule = "USP_GET_APPLICATIONS_STATUS_COUNT";
        public static string GetUserStatusByModule = "USP_GETUSERALLAPPLSTATUS";

        public static string InsertGrievance = "USP_INS_GRIEVANCE";
        public static string GetUserGrievanceList= "USP_GETUSERGRIEVANCES";
        public static string GetGrowthFinancialYear = "USP_GET_GROWTH_FINANCIALYEAR";

        public static string GETCENTRALINSPECTIONDASHBOARD = "USP_GETCENTRALINSPDASHBAORD";
        public static string GetCFEApprovalsReq = "USP_GETKNOWYOURAPPROVALSCFE";
        public static string GetCFOApprovalsReq = "USP_GETKNOWYOURAPPROVALSCFO";

        //-----dept----
        public static string GetDeptGrievanceDashboard = "USP_GETDEPTGRIEVANCEDASHBOARD";
        public static string GetDepGrievanceList = "USP_GETGRIEVANCEBYDEPT";
        public static string UpdateGrievanceDeptProcess = "USP_UPDATEGRIEVANCEDEPTPROCESS";

        /////////////---------HelpDesk----------------////////
        ///

        public static string InsertHelpDesk = "USP_INSHELPDESK";
        public static string GetUserHelpDeskList = "USP_GETUSERHELPDESK";
    }
}
