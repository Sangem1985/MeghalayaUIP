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

        public static string GetHelpDeskReports = "USP_GETHELPDESKSTATUS";

        public static string GetHelpDeskReportDrilldown = "";

        public static string GetFeedBackQuestions = "GETFEEDBACKQUES";
        public static string InsertFeedBackTracker = "SP_INSFEEDBACKTRACKER";
        public static string InsertFeedBack = "SP_INSFEEDBACK";

        public static string GetApllicationDetails = "USP_GETCMPLNC_DETAILS";

        ////////------------------ApplicationTracker----------------///////

        public static string GetApplicationTracker = "USP_GETAPPLICATIONTRACKER";

        public static string GetApplicationDetails = "USP_GETAPPLICATIONVIEW";
        ////////-----------------CHANGE PASSWORD---------------//////
        public static string GetUserChangePWD = "USP_UPDATE_INVESTERPASSWORD";
        public static string GetDeptChangePassword = "USP_UPDATE_MASTERUSERPASSWORD";
        public static string InsertPswdResetKey = "USP_INSERTFORGOTPASSWORDKEYS";
        public static string GetPswdResetKey = "USP_GETPASSWORDSECRETKEY";


    }

    public class FeedbackTracker
    {
        public int FBQ_TRACKERID { get; set; }
        public string FBQ_SUGGESTIONS { get; set; }
        public string FBQ_ISSUES { get; set; }
        public string FBQ_CATEGORY { get; set; }
    }

    public class FeedbackData
    {
        public int FBQ_QUESTIONID { get; set; }
        public string FBQ_FEEDBACKVALUE { get; set; }
        public string FBQ_FEEDBACKTEXT { get; set; }
        public string FBQ_CATEGORY { get; set; }
    }
}
