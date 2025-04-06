using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeghalayaUIP.DAL.CommonDAL;
using MeghalayaUIP.Common;
using System.Diagnostics;

namespace MeghalayaUIP.BAL.CommonBAL
{
    public partial class MGCommonBAL
    {
        public MGCommonDAL objCommonDAL { get; } = new MGCommonDAL();
        public string LogerrorDB(Exception ex, string path, string CreatedBy)
        {
            return objCommonDAL.LogerrorDB(ex, path, CreatedBy);
        }
        public DataSet GetMainApplicantDashBoard(String Investerid)
        {
            return objCommonDAL.GetMainApplicantDashBoard(Investerid);
        }
        public int InsertGrievance(string RegisterType, string ModuleType, string UIDNo, string UnitID, string UnitName, string ApplcantName,
            string DistID, string Email, string Mobile, string intDeptid, string Subject, string Description, string Grivance_FilePath,
            string Grivance_FileType, string GrievnaceFileName, string Createdby, string IPAddress)
        {
            return objCommonDAL.InsertGrievance(RegisterType, ModuleType, UIDNo, UnitID, UnitName, ApplcantName,
              DistID, Email, Mobile, intDeptid, Subject, Description, Grivance_FilePath,
              Grivance_FileType, GrievnaceFileName, Createdby, IPAddress);
        }
        public DataSet GetApplByModuleName(string UserID, string ModuleID)
        {
            return objCommonDAL.GetApplByModuleName(UserID, ModuleID);
        }
        public DataSet GetCFEUserDashboardStatus(string UserID, string UnitID, string Type)
        {
            return objCommonDAL.GetCFEUserDashboardStatus(UserID, UnitID, Type);
        }
        public DataSet GetUserDashboardStatusByModule(string UserID, string UnitID)
        {
            return objCommonDAL.GetUserDashboardStatusByModule(UserID, UnitID);
        }
        public DataSet GetDepGrievanceDashboard(string DeptID, string Userid)
        {
            return objCommonDAL.GetDepGrievanceDashboard(DeptID, Userid);
        }
        public DataSet GetUserGrievanceList(string Userid)
        {
            return objCommonDAL.GetUserGrievanceList(Userid);
        }

        public DataSet GetDepGrievanceList(string DeptID, string GrvncID, string Status)
        {
            return objCommonDAL.GetDepGrievanceList(DeptID, GrvncID, Status);
        }
        public int UpdateGrievanceDeptProcess(string Process, string ProcessFalg, string Remarks, string ReplyFilePath, string ReplyFileType,
            string ReplyFileName, string GrvncID, string UserID, string DeptID, string IPAddress)
        {
            return objCommonDAL.UpdateGrievanceDeptProcess(Process, ProcessFalg, Remarks, ReplyFilePath, ReplyFileType, ReplyFileName,
                GrvncID, UserID, DeptID, IPAddress);
        }
        public DataSet GetGrowthFinancialYear()
        {
            return objCommonDAL.GetGrowthFinancialYear();
        }
        public DataSet GetCentralInspection(string fYear, string tMonth, string Insepction)
        {
            return objCommonDAL.GetCentralInspection(fYear, tMonth, Insepction);
        }
        public DataTable GetApprovalsReqWithFee(CFEQuestionnaireDet objCFEQ)
        { return objCommonDAL.GetApprovalsReqWithFee(objCFEQ); }
        public DataSet GetApprovalsReqWithFee(CFOQuestionnaireDet objCFOQ)
        {
            return objCommonDAL.GetApprovalsReqWithFee(objCFOQ);
        }

        //////-------------------HELPDESK------------------------/////

        public int InsertHelpDesk(string UnitName, string ApplcantName, string UIDNo,
           string Mobile, string HelpDesk, string Email, string Description, string File_Path,
          string File_Type, string FileName, string UserType, string Username, string Createdby, string IPAddress)
        {
            return objCommonDAL.InsertHelpDesk(UnitName, ApplcantName, UIDNo,
                Mobile, HelpDesk, Email, Description, File_Path,
                File_Type, FileName, UserType, Username, Createdby, IPAddress);

        }
        public DataSet GetUserHelpDeskList(string Userid)
        {
            return objCommonDAL.GetUserHelpDeskList(Userid);
        }
        public DataSet GetApplicationTracker(string Applicationtype, string Unitname, string UId)
        {
            return objCommonDAL.GetApplicationTracker(Applicationtype, Unitname, UId);
        }
        public string ChangeUserPassword(string Created, string Username, string Password, string Decripty, string IPAddress)
        {
            return objCommonDAL.ChangeUserPassword(Created, Username, Password, Decripty, IPAddress);
        }
        public string ChangeDeptUserPassword(string Created, string Username, string Password, string Decripty, string IPAddress)
        {
            return objCommonDAL.ChangeDeptUserPassword(Created, Username, Password, Decripty, IPAddress);
        }
        public string InsertPswdResetKey(string Email, string SecretKey, string IPAddress)
        {
            return objCommonDAL.InsertPswdResetKey(Email, SecretKey, IPAddress);
        }
        public DataSet GetPswdResetKey(string Email, string SecretKey)
        { 
            return objCommonDAL.GetPswdResetKey(Email, SecretKey); 
        }
        public DataSet GETHelpDeskReport(string FDate,string TDate)
        {
            return objCommonDAL.GETHelpDeskReport(FDate, TDate);
        }
        public DataSet GetHelpDeskReportDrilldown(string HDType, string Status, string FDate, string TDate)
        {
            return objCommonDAL.GetHelpDeskReportDrilldown(HDType, Status, FDate, TDate);
        }

        public DataSet GetFeedBackQuestions()
        {
            return objCommonDAL.GetFeedBackQuestions();
        }

        public int InsertFeedbackTracker(FeedbackTracker tracker)
        {
            return objCommonDAL.InsertFeedbackTracker(tracker);
        }
        public DataSet HelpdeskDrilldown(string HelpDeskId, string Createdby)
        {
            return objCommonDAL.HelpdeskDrilldown(HelpDeskId, Createdby);
        }

        public string InsertFeedback(int trackerId, List<FeedbackData> feedbackList)
        {
            return objCommonDAL.InsertFeedback(trackerId, feedbackList);
        }
        public DataSet GetApplicationDetails(string Unitid,string Createdby)
        {
            return objCommonDAL.GetApplicationDetails(Unitid, Createdby);
        }
        public DataSet GetApplicationView(string TypeOfApplication, string Invester, string UnitName)
        {
            return objCommonDAL.GetApplicationView(TypeOfApplication, Invester, UnitName);
        }
    }
}
